SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSetContextData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSetContextData]
GO

--##SUMMARY Saves additional data related with current connection context in the tstLocalConnectionContext table.
--##SUMMARY If procedure is called from client application, connection context contains application ClientID.
--##SUMMARY tstLocalConnectionContext table stores some additional session data that are required for correct triggers work.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 20.01.2010

--##RETURNS Doesn't use

/*
--Example of procedure call:
DECLARE @idfEventID bigint
DECLARE @idfDataAuditEvent bigint
DECLARE @idfUserID bigint


EXECUTE spSetContextData 
   @idfEventID
  ,@idfDataAuditEvent
  ,@idfUserID

*/



CREATE         procedure dbo.spSetContextData( 
	@idfEventID as bigint,  --##PARAM @idfEventID - ID of record in tstEventTable table that should be pocessed. If NULL is passed, the current session idfEventID value will not be changed
	@idfDataAuditEvent as bigint --##PARAM @idfDataAuditEvent - ID of record in DataAuditEvent table that should be pocessed. If NULL is passed, the current session idfDataAuditEvent value will not be changed
)
as
	DECLARE @idfsConnectionContext AS VARCHAR(200)
	SELECT 	@idfsConnectionContext = dbo.fnGetContext()
	
	IF EXISTS (SELECT strConnectionContext FROM dbo.tstLocalConnectionContext
				WHERE strConnectionContext = @idfsConnectionContext)
			UPDATE dbo.tstLocalConnectionContext
			SET 
idfDataAuditEvent = ISNULL(@idfDataAuditEvent,idfDataAuditEvent)
				  ,idfEventID = ISNULL(@idfEventID,idfEventID)
			WHERE strConnectionContext = @idfsConnectionContext
	ELSE
			INSERT INTO dbo.tstLocalConnectionContext
					   ([strConnectionContext]
					   ,[idfEventID]
					   ,[idfDataAuditEvent])
				 VALUES
					   (@idfsConnectionContext
					   ,@idfEventID
					   ,@idfDataAuditEvent)	


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

