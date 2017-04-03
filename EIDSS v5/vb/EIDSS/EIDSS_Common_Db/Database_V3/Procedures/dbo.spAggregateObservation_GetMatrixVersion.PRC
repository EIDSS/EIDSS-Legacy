SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateObservation_GetMatrixVersion]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateObservation_GetMatrixVersion]
GO


--##SUMMARY Returns aggregate matrix version related with specific observation.


--##REMARKS Author: Zurin M.
--##REMARKS Create date: 11.02.2010

--##RETURNS -1 if case related with observation is not found
--##RETURNS  0 if case related with observation is found
 


/*
--Example of procedure call:
DECLARE @RC int
DECLARE @idfObservation bigint
DECLARE @idfVersion bigint
SET @idfObservation = 1
EXECUTE @RC = spAggregateObservation_GetMatrixVersion
   @idfObservation  
Print @RC
Print @idfVersion


*/

CREATE PROCEDURE dbo.spAggregateObservation_GetMatrixVersion
(
	@idfObservation as bigint  --##PARAM @idfObservation - ID of observation related with aggregate case
)
As Begin
--	Declare @ResultTable As Table 
--	(
--		[idfVersion] Bigint
--		,[idfsAggrCaseType] Bigint		
--	)
--
--	Declare @idfVersion bigint
	Declare @idfAggregateCaseSection BigInt
	-- определим секцию, к которой принадлежит данный кейс
	If Exists(Select Top 1 1 From dbo.tlbAggrCase Where idfDiagnosticObservation = @idfObservation) Begin
		Set @idfAggregateCaseSection = 71460000000	
	End Else If Exists(Select Top 1 1 From dbo.tlbAggrCase Where idfProphylacticObservation = @idfObservation) Begin
		Set @idfAggregateCaseSection = 71300000000
	End Else If Exists(Select Top 1 1 From dbo.tlbAggrCase Where idfSanitaryObservation = @idfObservation) Begin		
		Set @idfAggregateCaseSection = 71260000000
	End Else If Exists(Select Top 1 1 From dbo.tlbAggrCase Where idfCaseObservation = @idfObservation) Begin
		Declare @idfsAggrCaseType Bigint
		Select @idfsAggrCaseType = idfsAggrCaseType From dbo.tlbAggrCase Where idfCaseObservation = @idfObservation;
		-- 10102001 - Human, иначе Vet
		If ( @idfsAggrCaseType = 10102001) Set @idfAggregateCaseSection = 71190000000 Else Set @idfAggregateCaseSection = 71090000000
	End;	

	Select  CASE @idfAggregateCaseSection 
				WHEN 71460000000 THEN idfDiagnosticVersion
				WHEN 71300000000 THEN idfProphylacticVersion
				WHEN 71260000000 THEN idfSanitaryVersion
				ELSE idfVersion	END AS idfVersion		
				,idfsAggrCaseType
				,@idfAggregateCaseSection As [idfAggregateCaseSection]
	From dbo.tlbAggrCase
	Where	(idfCaseObservation = @idfObservation
			Or idfDiagnosticObservation = @idfObservation
			Or idfProphylacticObservation = @idfObservation
			Or idfSanitaryObservation = @idfObservation)
			And intRowStatus = 0
	
--	Select 	
--			[idfVersion]
--			,[idfsAggrCaseType]
--			,@idfAggregateCaseSection As [idfAggregateCaseSection]
--	From @ResultTable

	IF @@ROWCOUNT=0
		RETURN -1
	RETURN 0
End
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

