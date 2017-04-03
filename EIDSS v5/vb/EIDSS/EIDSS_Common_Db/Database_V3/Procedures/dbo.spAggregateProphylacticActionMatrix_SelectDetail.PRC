SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateProphylacticActionMatrix_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateProphylacticActionMatrix_SelectDetail]
GO


--##SUMMARY Selects data for AggregateProphylacticActionMTXDetail form
--##SUMMARY that defines the list of cases and species that should be displayed on AggregateVetCaseDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 03.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

EXECUTE spAggregateProphylacticActionMatrix_SelectDetail 

*/


CREATE       procedure dbo.spAggregateProphylacticActionMatrix_SelectDetail
as
/*
				,@idfsParameterMeasureType3 = 245270000000
				,@idfsParameterMeasureCode3 = 233170000000
				,@idfsParameterSpecies3 = 239050000000
				,@idfsParameterDisease3 = 226950000000
				,@idfsParameterOIECode3	 = 234450000000	
*/
SELECT	 tlbAggrProphylacticActionMTX.idfAggrProphylacticActionMTX
		,ISNULL(tlbAggrMatrixVersionHeader.idfVersion,0) AS idfVersion
		,Species.idfAggrMatrixVersion as idfSpeciesRow
		,CAST (ISNULL(Species.varValue,tlbAggrProphylacticActionMTX.idfsSpeciesType) AS BIGINT) AS idfsSpeciesType
		,Disease.idfAggrMatrixVersion as idfDiagnosisRow
		,CAST (ISNULL(Disease.varValue,tlbAggrProphylacticActionMTX.idfsDiagnosis) AS BIGINT) AS idfsDiagnosis
		,OIECode.idfAggrMatrixVersion as idfOIECodeRow
		,CAST (ISNULL(OIECode.varValue,trtDiagnosis.strOIECode) AS NVARCHAR(200)) AS strOIECode
		,ActionType.idfAggrMatrixVersion as idfActionTypeRow
		,CAST (ISNULL(ActionType.varValue,tlbAggrProphylacticActionMTX.idfsProphilacticAction) AS BIGINT) AS idfsProphilacticAction
		,ActionCode.idfAggrMatrixVersion as idfActionCodeRow
		,CAST (ISNULL(ActionCode.varValue,trtProphilacticAction.strActionCode) AS NVARCHAR(200)) AS strActionCode
		,Disease.intNumRow
FROM	tlbAggrProphylacticActionMTX
INNER JOIN dbo.tlbAggrMatrixVersionHeader ON
	tlbAggrMatrixVersionHeader.intRowStatus = 0
INNER JOIN trtDiagnosis ON 
	trtDiagnosis.idfsDiagnosis = tlbAggrProphylacticActionMTX.idfsDiagnosis
INNER JOIN trtProphilacticAction ON 
	trtProphilacticAction.idfsProphilacticAction = tlbAggrProphylacticActionMTX.idfsProphilacticAction
	and trtProphilacticAction.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion Disease
ON 
	Disease.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	AND Disease.idfRow = tlbAggrProphylacticActionMTX.idfAggrProphylacticActionMTX
	and Disease.idfsParameter = 226950000000 -- Disease
	AND Disease.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion OIECode
ON 
	OIECode.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	AND OIECode.idfRow = tlbAggrProphylacticActionMTX.idfAggrProphylacticActionMTX
	and OIECode.idfsParameter = 234450000000 -- OIECode
	AND OIECode.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion Species
ON 
	Species.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	AND Species.idfRow = tlbAggrProphylacticActionMTX.idfAggrProphylacticActionMTX
	and Species.idfsParameter = 239050000000 -- Species Type
	AND Species.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion ActionType
ON 
	ActionType.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	AND ActionType.idfRow = tlbAggrProphylacticActionMTX.idfAggrProphylacticActionMTX
	and ActionType.idfsParameter = 245270000000 -- Prohilactic Action Type
	AND ActionType.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion ActionCode
ON 
	ActionCode.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	AND ActionCode.idfRow = tlbAggrProphylacticActionMTX.idfAggrProphylacticActionMTX
	and ActionCode.idfsParameter = 233170000000 -- Prohilactic Action Code
	AND ActionCode.intRowStatus = 0
WHERE
		tlbAggrProphylacticActionMTX.intRowStatus = 0
Order By
	Disease.intNumRow


--Current matrix version
--We select latest matrix version as default current version
SELECT TOP 1
		idfVersion
      ,idfsAggrCaseSection
      ,MatrixName
      ,datStartDate 
      ,blnIsActive
      ,blnIsDefault
FROM	tlbAggrMatrixVersionHeader
WHERE 
		idfsAggrCaseSection = 71300000000 /*ProphilacticAction matrix*/
		and intRowStatus = 0
ORDER BY CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) DESC, datStartDate DESC

--Lookup list of all available matrix versions
EXEC spAggregateMatrixVersion_SelectLookup 'en', 71300000000 /*ProphilacticAction matrix*/


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

