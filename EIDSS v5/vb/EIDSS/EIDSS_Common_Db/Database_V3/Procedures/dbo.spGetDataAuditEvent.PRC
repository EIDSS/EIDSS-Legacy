
--##SUMMARY This procedure return ID of current (active) Data Audit Event.
--##SUMMARY If active event not exists, procedure create new event and return new event ID.

--##REMARKS Author: Zhdanova A.
--##REMARKS
--##REMARKS Update date: 23.01.2010

--##PARAM @event - output: event ID

--##RETURNS Don't use


/*
--Example of a call of procedure:

declare @event bigint

exec dbo.[spGetDataAuditEvent] @event output
print @event

exec dbo.[spGetDataAuditEvent] @event output
print @event

exec dbo.[spGetDataAuditEvent] @event output
print @event

print 'Совпадает?'
*/

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetDataAuditEvent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spGetDataAuditEvent]
GO

create proc [dbo].[spGetDataAuditEvent](@event bigint output)
as
begin

set @event = null

declare @context varchar(50)
declare @context_b as varbinary(128)
set @context = dbo.fnGetContext()

select @event = idfDataAuditEvent
from dbo.tstLocalConnectionContext
where strConnectionContext = @context

if @event is null
begin
	exec dbo.[spsysGetNewID] @event output
	insert  into [tauDataAuditEvent] (
		[idfDataAuditEvent],
		[idfsDataAuditObjectType],
		[idfsDataAuditEventType],
		[idfMainObject],
		[idfMainObjectTable],
		[idfUserID],
		[idfsSite],
		[datEnteringDate],
		[strHostname]
	) 
	values
		(@event,
		NULL,
		10016004, --'daeFreeDataUpdate'
		null,
		null,
		dbo.fnUserID(),
		dbo.fnSiteID(),
		getdate(),
		HOST_NAME()
		)

	IF  @context is NULL OR @context = ''
		SET  @context = newid()
		
	IF NOT EXISTS(SELECT * FROM dbo.[tstLocalConnectionContext] WHERE [strConnectionContext] = @context)
	BEGIN
		insert into dbo.[tstLocalConnectionContext](strConnectionContext,idfDataAuditEvent)
		values(@context, @event)
		set @context_b = cast(cast (@context as varchar(50)) as varbinary(128))
		SET CONTEXT_INFO @context_b
	END 
	ELSE 
		update dbo.[tstLocalConnectionContext]
		set idfDataAuditEvent = @event
		where strConnectionContext = @context
end
end







