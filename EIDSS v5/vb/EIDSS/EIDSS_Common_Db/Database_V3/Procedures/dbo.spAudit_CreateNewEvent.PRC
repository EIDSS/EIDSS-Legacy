SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO 

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAudit_CreateNewEvent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAudit_CreateNewEvent]
GO

--##SUMMARY Creates head data audit record and saves its primary key in the tstLocalConnectionContext table.
--##SUMMARY Triggers should get audit record ID from tstLocalConnectionContext table using current connection context as primary key
--##SUMMARY and insert audit detail records related with head oudit record.
--##SUMMARY After finising data posting/deleting transaction client application should call spClearContextData procedure
--##SUMMARY to clear audit record ID from tstLocalConnectionContext table and precent futher record using in audit triggers.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 20.01.2010

--##RETURNS Doesn't use

/*
--Example of procedure call:
DECLARE @idfsDataAuditEventType bigint
DECLARE @idfsDataAuditObjectType bigint
DECLARE @strMainObjectTable bigint
DECLARE @idfsMainObject bigint
DECLARE @strReason nvarchar(200)
DECLARE @idfDataAuditEvent bigint

SET @idfsDataAuditEventType  = 10016001
SET @idfsDataAuditObjectType  = 10017053
SET @strMainObjectTable  = 0
SET @idfsMainObject =1


EXECUTE spAudit_CreateNewEvent
   @idfsDataAuditEventType
  ,@idfsDataAuditObjectType
  ,@strMainObjectTable
  ,@idfsMainObject
  ,@strReason
  ,@idfDataAuditEvent OUTPUT
print @idfDataAuditEvent
*/

CREATE         procedure dbo.spAudit_CreateNewEvent( 
	@idfsDataAuditEventType as bigint,
	@idfsDataAuditObjectType as bigint,
	@strMainObjectTable as bigint,
	@idfsMainObject  as bigint = null,
	@strReason as nvarchar(200) = null,
	@idfDataAuditEvent as bigint output
)
as
	
	exec  dbo.spsysGetNewID @idfDataAuditEvent OUTPUT
	
	INSERT INTO [dbo].[tauDataAuditEvent]
           ([idfDataAuditEvent]
           ,[idfsDataAuditEventType]
           ,[idfsDataAuditObjectType]
           ,[idfMainObjectTable]
           ,[idfMainObject]
           ,[idfsSite]
           ,[idfUserID]
           ,[datEnteringDate]
           ,[strHostname]
	)
     VALUES
           (@idfDataAuditEvent
           ,@idfsDataAuditEventType
           ,@idfsDataAuditObjectType
           ,@strMainObjectTable
           ,@idfsMainObject
           ,dbo.fnSiteID() --idfsSite
           ,dbo.fnUserID() --idfUserID
           ,GetDate()      --datEnteringDate
           ,HOST_NAME()
			)
	IF @@ERROR <> 0
		SET @idfDataAuditEvent = null
	ELSE
		EXEC dbo.spSetContextData
		   NULL --@idfEventID
		  ,@idfDataAuditEvent


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

