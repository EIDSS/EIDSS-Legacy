SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGetContextData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGetContextData]
GO


--##SUMMARY Returns current session data from tstLocalConnectionContext table.
--##SUMMARY Current connection context is used as primary key for location current record in the tstLocalConnectionContext table.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.01.2010

--##RETURNS Doesn't use

/*
--Example of procedure call:

DECLARE @idfUserID bigint
DECLARE @idfEventID bigint
DECLARE @idfDataAuditEvent bigint


EXECUTE spGetContextData
   @idfUserID OUTPUT
  ,@idfEventID OUTPUT
  ,@idfDataAuditEvent OUTPUT

Print ISNULL(@idfUserID,-1)
Print ISNULL(@idfEventID,-2)
Print ISNULL(@idfDataAuditEvent,-3)

*/

CREATE         procedure dbo.spGetContextData( 
	@idfUserID AS BIGINT OUTPUT,  --##PARAM @idfUserID - returns current session user ID
	@idfEventID AS BIGINT OUTPUT,  --##PARAM @idfEventID - returns current session event ID
	@idfDataAuditEvent AS BIGINT OUTPUT --##PARAM @idfDataAuditEvent - returns current session DataAuditEvent ID
)
as
	DECLARE @idfsConnectionContext AS VARCHAR(200)
	SELECT 	@idfsConnectionContext = dbo.fnGetContext()
	IF NOT @idfsConnectionContext IS NULL
	BEGIN
			SELECT  
				  @idfUserID = idfUserID
				  ,@idfDataAuditEvent = idfDataAuditEvent
				  ,@idfEventID = idfEventID
			FROM tstLocalConnectionContext
			WHERE strConnectionContext = @idfsConnectionContext
	END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

