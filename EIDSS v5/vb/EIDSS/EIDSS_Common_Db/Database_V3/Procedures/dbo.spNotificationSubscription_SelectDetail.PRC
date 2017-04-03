SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spNotificationSubscription_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spNotificationSubscription_SelectDetail]
GO



--##SUMMARY Selects data for NotificationSubscription form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
EXEC spNotificationSubscription_SelectDetail , '12345', 'en'
*/




CREATE     PROCEDURE dbo.spNotificationSubscription_SelectDetail(
	@ClientID AS NVARCHAR(36), --##PARAM @ClientID - client application ID
	@LangID AS NVARCHAR(50) --##PARAM @LangID - language ID
)
AS
CREATE TABLE [#tmpSubscription] (
	idfsEventTypeID bigint NOT NULL,
	strClient NVARCHAR(200) COLLATE database_default NOT NULL,
	EventName  NVARCHAR(200)COLLATE database_default NULL,
	Subscription Int NULL
	CONSTRAINT [constrain_10] PRIMARY KEY  NONCLUSTERED 
	(
		idfsEventTypeID,
		strClient
	)  ON [PRIMARY] 
) ON [PRIMARY]
INSERT INTO #tmpSubscription
SELECT
	idfsReference,
	@ClientID,
	[Name],
	0 
FROM 
	fnReference(@LANGID, 19000025) --'rftEventType'

WHERE
	idfsReference in (
		10025007, --'evtCaseStatusChange',
		10025005, -- 'evtCaseDiseaseChange',
		10025008,  -- 'evtCaseStatusChangeReceived',
		10025006, --'evtCaseDiseaseChangeReceived',
		10025014, --'evtNewVetCase',
		10025010, --'evtNewHumanCase',
		10025016, --'evtOutbreak',
		10025018, --'evtOutbreakNotificationReceived',
		10025022, --'evtReplicationFailed',
		10025026, --'evtReplicationSucceeded',
		10025024, --'evtReplicationRetrying',
		10025025, --'evtReplicationStarted',
		10025013, --'evtNewTestResult',
		10025003, --'evtNewTestResultReceived',
		10025031, --'HumanCaseNotification',
		10025032, --'VetCaseNotification',
		--, --'evtMaterialDestruction',
		10025004 --'evtNotificationServiceNotRunning'
)
UPDATE #tmpSubscription
SET 
	#tmpSubscription.Subscription = 1
FROM
	tstEventSubscription
WHERE
	#tmpSubscription.idfsEventTypeID=tstEventSubscription.idfsEventTypeID
	AND tstEventSubscription.strClient = @ClientID
SELECT * From #tmpSubscription
ORDER BY idfsEventTypeID







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

