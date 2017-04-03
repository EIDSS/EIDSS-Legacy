SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spVetAggregateAction_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spVetAggregateAction_Delete]
GO


--##SUMMARY Deletes veterinary aggregate action object.
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 06.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @ID bigint
EXECUTE spVetAggregateAction_Delete 
	@ID

*/




CREATE                                   proc	spVetAggregateAction_Delete
	@ID as bigint --##PARAM @ID - aggregate action ID
as

DECLARE @idfDiagnosticObservation BIGINT
DECLARE @idfProphylacticObservation BIGINT
DECLARE @idfSanitaryObservation BIGINT

SELECT	@idfDiagnosticObservation = idfDiagnosticObservation,
		@idfProphylacticObservation = idfProphylacticObservation,
		@idfSanitaryObservation = idfSanitaryObservation
FROM tlbAggrCase
WHERE idfAggrCase = @ID

DELETE FROM tlbAggrCase WHERE idfAggrCase = @ID

EXEC spObservation_Delete @idfDiagnosticObservation
EXEC spObservation_Delete @idfProphylacticObservation
EXEC spObservation_Delete @idfSanitaryObservation


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

