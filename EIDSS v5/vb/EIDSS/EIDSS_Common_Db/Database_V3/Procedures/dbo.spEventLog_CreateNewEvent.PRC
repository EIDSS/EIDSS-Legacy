SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEventLog_CreateNewEvent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEventLog_CreateNewEvent]
GO

--##SUMMARY Creates new event record.
--##SUMMARY Can be called by by EIDSS, EIDSS Client Agent or by EIDSS Notification Service.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

DECLARE @idfsEventTypeID bigint
DECLARE @idfObjectID bigint
DECLARE @strInformationString nvarchar(200)
DECLARE @strNote nvarchar(200)
DECLARE @ClientID nvarchar(50)
DECLARE @datEventDatatime datetime
DECLARE @intProcessed int
DECLARE @idfUserID bigint
DECLARE @EventID bigint

EXECUTE spEventLog_CreateNewEvent
   @idfsEventTypeID
  ,@idfObjectID
  ,@strInformationString
  ,@strNote
  ,@ClientID
  ,@datEventDatatime
  ,@intProcessed
  ,@idfUserID
  ,@EventID OUTPUT

*/


CREATE         procedure dbo.spEventLog_CreateNewEvent( 
	@idfsEventTypeID as bigint,--##PARAM @idfsEventTypeID - event type
	@idfObjectID as bigint,--##PARAM @idfObjectID - ID of object related with event (it can be ID of case or outbreak for example)
	@strInformationString  as nvarchar(200),--##PARAM - additional information about event, used for displaing some text information realted with event
	@strNote  as nvarchar(200),--##PARAM @strNote - currently doesn't use
	@ClientID as nvarchar(50), --##PARAM @ClientID - client ID of application that creates event
	@datEventDatatime as datetime = null,--##PARAM @datEventDatatime - event date, if null is passed current date is used.
	@intProcessed as int = 0,--##PARAM @intProcessed - flag that marks event as processed already
	@idfUserID as bigint = null,--##PARAM @idfUserID - ID of user that created this event, if NULL is passed current user ID is used.
	@EventID as bigint output--##PARAM @EventID - ID of created event. If NULL is passed, new ID is assigned inside procedure and returned to calling application.
)
as
	declare @datEventDatatime_New as datetime
	if @idfUserID IS NULL
		set @idfUserID = dbo.fnUserID()
	IF @EventID IS NULL
		exec  dbo.spsysGetNewID @EventID OUTPUT
	set @datEventDatatime_New = @datEventDatatime
	if (@datEventDatatime_New is null)
	begin
		set @datEventDatatime_New = GetDate()
	end
	
	insert into tstEvent(
		idfEventID, 
		idfsEventTypeID, 
		idfObjectID,
		strInformationString, 
		strNote, 
		datEventDatatime,
		strClient,
		idfUserID,
		intProcessed
	)
	values(
		@EventID, 
		@idfsEventTypeID, 
		@idfObjectID,
		@strInformationString, 
		@strNote, 
		@datEventDatatime_New,
		@ClientID,
		@idfUserID,
		@intProcessed
	)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

