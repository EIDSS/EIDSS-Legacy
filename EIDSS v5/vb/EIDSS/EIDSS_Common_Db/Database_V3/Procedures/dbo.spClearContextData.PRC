SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spClearContextData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spClearContextData]
GO


--##SUMMARY Clears current session data in tstLocalConnectionContext table.
--##SUMMARY Cuurent connection context is used as primary key for location current record in the tstLocalConnectionContext table.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 20.01.2010

--##RETURNS Doesn't use

/*
--Example of procedure call:

EXECUTE spClearContextData 
   0
  ,1

*/

CREATE         procedure dbo.spClearContextData( 
	@ClearEventID as BIT,  --##PARAM @ClearEventID - bit flag that indicates should we clear current session EventID value or not
	@ClearDataAuditEvent as BIT --##PARAM @ClearDataAuditEvent - bit flag that indicates should we clear current session DataAuditEvent ID value or not
)
as
	DECLARE @idfsConnectionContext AS VARCHAR(200)
	SELECT 	@idfsConnectionContext = dbo.fnGetContext()
	IF NOT @idfsConnectionContext IS NULL
	BEGIN
--			IF @ClearDataAuditEvent = 1 EXEC dbo.spFiltered_CheckEvent

			UPDATE dbo.tstLocalConnectionContext
			SET 
				  idfUserID = dbo.fnUserID()
				  ,idfDataAuditEvent = CASE @ClearDataAuditEvent WHEN 1 THEN NULL ELSE idfDataAuditEvent END
				  ,idfEventID = CASE @ClearEventID WHEN 1 THEN NULL ELSE idfEventID END
			WHERE strConnectionContext = @idfsConnectionContext

	END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

