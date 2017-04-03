SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEventLog_SelectNewEvents]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEventLog_SelectNewEvents]
GO



--##SUMMARY Selects new events for passed client application.
--##SUMMARY Can be called by EIDSS, EIDSS Client Agent or by EIDSS Notification Service.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
EXEC spEventLog_SelectNewEvents 'en', '00110A967B9A', 0
*/

CREATE            procedure dbo.spEventLog_SelectNewEvents(
	@LangID as nvarchar(50), --##PARAM @LangID - language ID
	@ClientID as nvarchar(50), --##PARAM @ClientID - client application ID, defined in application configuration file. If client ID is not defined there, client PC MAC addres is used as client ID.
	@IsNotificationClient as BIT --##PARAM @IsNotificationClient - bit flag that identifies was this procedure from EIDSS notification service or not
)
as

begin tran T1

declare @LastEvent as bigint
declare @LastEventStr as nvarchar(200)
declare @CurrLastEvent as bigint
declare @ClientFieldName as nvarchar(200)
declare @idfUserID as bigint

select	@idfUserID = idfUserId 
from	tstUserTable 
where	strAccountName = SYSTEM_USER

set @ClientFieldName = N'LastEvent(' + @ClientID + ')'
set @CurrLastEvent = 0

select top 1 @CurrLastEvent = intRowNum 
from		tstEvent
order by	intRowNum desc
print 'Last Reported Event = ' + convert(nvarchar(200), @CurrLastEvent)
IF @IsNotificationClient = 1 
BEGIN
	IF EXISTS (SELECT	strValue 
			FROM	tstLocalSiteOptions 
			WHERE	strName = 'LastNotificationEvent')
		UPDATE	tstLocalSiteOptions
		SET		strValue = CONVERT(NVARCHAR(200), GETDATE(),120)
		WHERE	strName = 'LastNotificationEvent'
	ELSE
		INSERT INTO tstLocalSiteOptions(
			[strName], [strValue]
		)
		VALUES(
			'LastNotificationEvent', 
			convert(NVARCHAR(200), GetDate(), 120)
		)	
END

select	@LastEventStr = strValue 
from	tstLocalSiteOptions 
where	strName = @ClientFieldName

if @@ROWCOUNT = 0
begin
	print 'insert new event num ' + @ClientFieldName + ',' + convert(nvarchar(200), @CurrLastEvent)
	insert into tstLocalSiteOptions(
		[strName], [strValue]
	)
	values(
		@ClientFieldName, 
		convert(nvarchar(200), @CurrLastEvent)
	)
	commit tran T1
	return -1
end
else if @LastEventStr is null
begin
	print 'update last event num ' + @ClientFieldName + ',' + convert(nvarchar(200), @CurrLastEvent)
	update	tstLocalSiteOptions
	set		strValue = convert(nvarchar(200), @CurrLastEvent)
	where	strName = @ClientFieldName
	commit tran T1
	return -1
end
set @LastEvent = convert(bigint, @LastEventStr)

print 'update last event num 1' + @ClientFieldName + ',' + convert(nvarchar(200), @CurrLastEvent)

update	tstLocalSiteOptions
set		strValue = convert(nvarchar(200), @CurrLastEvent)
--from	tstLocalSiteOptions, tstEvent, tstEventSubscription
where	strName = @ClientFieldName
--		and ((tstEventSubscription.strClient = @ClientID
--		and tstEventSubscription.idfsEventTypeID = tstEvent.idfsEventTypeID)
--		or tstEvent.idfsEventTypeID = 10025001)	--evtLanguageChanged 
if @@ERROR <> 0
begin
	print 'ERROR'
	if @@TRANCOUNT < 2
		rollback tran T1
	else
		commit tran T1
	return -1
end

print 'select all events after' + convert(nvarchar(200), @LastEvent)
select		idfEventID, 
			tstEvent.idfsEventTypeID, 
			EventType.[Name] as EventName, 
			idfObjectID, 
			strInformationString, 
			strNote, 
			datEventDatatime, 
			intRowNum,
			N'Any User' as TargetUser,
			tstEvent.strClient,
			idfUserID,
			IsNull(tstEvent.intProcessed, 0) as intProcessed

from		tstEvent
inner join	dbo.tstEventSubscription 
on			tstEventSubscription.idfsEventTypeID = tstEvent.idfsEventTypeID
join		fnReference(@LangID, 19000025) EventType --'rftEventType'
on			EventType.idfsReference = tstEvent.idfsEventTypeID

where		tstEventSubscription.strClient = @ClientID
			and tstEvent.intRowNum > @LastEvent
			and tstEvent.intRowNum <= @CurrLastEvent
			and 	tstEventSubscription.idfsEventTypeID in (
				10025002, --evtLookupTableChanged
				10025007, --'evtCaseStatusChange',
				10025005, --'evtCaseDiseaseChange',
				10025008, --'evtCaseStatusChangeReceived',
				10025006, --'evtCaseDiseaseChangeReceived',
				10025014, --'evtNewVetCase',
				10025010, --'evtNewHumanCase',
				10025016, --'evtOutbreak',
				10025018, --'evtOutbreakNotificationReceived',
				10025017, --'evtReplicationFailed',
				10025026,  --'evtReplicationSucceeded',
				10025024, --'evtReplicationRetrying',
				10025025, --'evtReplicationStarted',
				10025013, --'evtNewTestResult',
				10025003, --'evtNewTestResultReceived',
				10025029, --'AVRLayoutUpdate'
				10025030, --SettlementChanged
				10025031, --'HumanCaseNotification',
				10025032, --'VetCaseNotification',
				--'evtMaterialDestruction',
				10025004, --'evtNotificationServiceNotRunning',
				10025015, --'evtNtfyReplicationRequestedByUser',
				10025023)--,'evtReplicationRequestedByUser')
/*
10025001	evtLanguageChanged
10025002	evtLookupTableChanged
10025003	evtNewTestResultReceived
10025004	evtNotificationServiceNotRunning
10025005	evtCaseDiseaseChange
10025006	evtCaseDiseaseChangeReceived
10025007	evtCaseStatusChange
10025008	evtCaseStatusChangeReceived
10025009	evtDef
10025010	evtNewHumanCase
10025011	evtNewReferral
10025012	evtNewTestRequest
10025013	evtNewTestResult
10025014	evtNewVetCase
10025015	evtNtfyReplicationRequestedByUser
10025016	evtOutbreak
10025017	evtOutbreakNotificationFail
10025018	evtOutbreakNotificationReceived
10025019	evtOutbreakNotificationRetrying
10025020	evtOutbreakNotificationSending
10025021	evtOutbreakNotificationSucceeded
10025022	evtReplicationFailed
10025023	evtReplicationRequestedByUser
10025024	evtReplicationRetrying
10025025	evtReplicationStarted
10025026	evtReplicationSucceeded
*/
UNION
select		idfEventID, 
			tstEvent.idfsEventTypeID, 
			EventType.[Name] as EventName, 
			idfObjectID, 
			strInformationString, 
			strNote, 
			datEventDatatime, 
			intRowNum,
			N'Any User' as TargetUser,
			tstEvent.strClient,
			idfUserID,
			IsNull(tstEvent.intProcessed, 0) as intProcessed

from		tstEvent
join		fnReference('en', 19000025) EventType --'rftEventType'
on			EventType.idfsReference = tstEvent.idfsEventTypeID

WHERE 
			tstEvent.idfsEventTypeID = 10025001 --'evtLanguageChanged'
			and tstEvent.intRowNum > @LastEvent
			and tstEvent.intRowNum <= @CurrLastEvent
			AND tstEvent.strClient = @ClientID


order by	tstEvent.intRowNum desc

commit tran T1



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

