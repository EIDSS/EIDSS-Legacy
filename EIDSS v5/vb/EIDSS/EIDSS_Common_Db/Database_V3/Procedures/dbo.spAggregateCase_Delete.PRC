SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateCase_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateCase_Delete]
GO



--##SUMMARY Deletes human aggregate case object.
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 07.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @ID bigint
EXECUTE spAggregateCase_Delete 
	@ID

*/




CREATE                                   proc	spAggregateCase_Delete
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

