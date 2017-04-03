SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateCaseExists]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateCaseExists]
GO
--##SUMMARY Checks if the aggregate case record with passed parameters exists

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 3.12.2009

--##RETURNS Returns 1 if aggregate case record exists, 0 in other case

/*
--Example of procedure call:

DECLARE @StartDate datetime
DECLARE @FinishDate datetime
DECLARE @AdminUnit bigint
DECLARE @AggrCaseType bigint
DECLARE @CaseID bigint


EXECUTE spAggregateCaseExists
   @StartDate
  ,@FinishDate
  ,@AdminUnit
  ,@AggrCaseType
  ,@CaseID OUTPUT
*/



CREATE                  PROCEDURE dbo.spAggregateCaseExists(
	 @StartDate AS DATETIME --##PARAM @StartDate - start date of aggregate case period
	,@FinishDate AS DATETIME --##PARAM @StartDate - end date of aggregate case period
	,@AdminUnit AS BIGINT --##PARAM @AdminUnit - administrative unit  ID (should point to Country, Region, Rayon or Settlement)
	,@AggrCaseType AS BIGINT --##PARAM @AggrCaseType - aggregate case type, reference to rftAggregateCaseType (19000102)
	,@CaseID AS BIGINT OUTPUT --##PARAM @CaseID	aggregate case ID. If NULL is passed, procedure searches among all cases that complaint other parameters
)
AS
SET DATEFORMAT 'dmy'  
SELECT @CaseID = idfAggrCase  
			FROM	tlbAggrCase
			WHERE	datStartDate = @StartDate  
					AND datFinishDate = @FinishDate  
					AND idfsAdministrativeUnit = @AdminUnit  
					AND idfsAggrCaseType = @AggrCaseType
					AND (@CaseID IS NULL OR idfAggrCase	<> @CaseID)
IF @@ROWCOUNT>0
	RETURN 1
ELSE
	RETURN 0








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

