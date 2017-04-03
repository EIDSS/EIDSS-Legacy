SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spVetAggregateCase_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spVetAggregateCase_Delete]
GO


--##SUMMARY Deletes veterinary aggregate case object.
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 03.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @ID bigint
EXECUTE spVetAggregateCase_Delete 
	@ID

*/



CREATE   PROC	spVetAggregateCase_Delete
	@ID AS BIGINT --#PARAM @ID - aggregate case ID
as
DECLARE @idfObservation BIGINT
SELECT @idfObservation = idfCaseObservation
FROM tlbAggrCase
WHERE idfAggrCase = @ID

DELETE FROM tlbAggrCase WHERE idfAggrCase = @ID

EXEC spObservation_Delete @idfObservation

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

