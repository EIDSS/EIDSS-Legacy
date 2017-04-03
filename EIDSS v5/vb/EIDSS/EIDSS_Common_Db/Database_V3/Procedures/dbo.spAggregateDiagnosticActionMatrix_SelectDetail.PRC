SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateDiagnosticActionMatrix_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateDiagnosticActionMatrix_SelectDetail]
GO


--##SUMMARY Selects data for AggregateDiagnosticActionMTXDetail form
--##SUMMARY that defines the list of diagnostic actions and species that should be displayed on VetAggregateActionDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 03.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

EXECUTE spAggregateDiagnosticActionMatrix_SelectDetail 

*/


CREATE       procedure dbo.spAggregateDiagnosticActionMatrix_SelectDetail
as
/*
				,@idfsParameterInvestigationType2 = 231670000000
				,@idfsParameterSpecies2 = 239030000000
				,@idfsParameterDisease2 = 226930000000
				,@idfsParameterOIECode2 = 234430000000
*/
SELECT	 tlbAggrDiagnosticActionMTX.idfAggrDiagnosticActionMTX
		,ISNULL(tlbAggrMatrixVersionHeader.idfVersion,0) AS idfVersion
		,Species.idfAggrMatrixVersion as idfSpeciesRow
		,CAST (ISNULL(Species.varValue,tlbAggrDiagnosticActionMTX.idfsSpeciesType) AS BIGINT) AS idfsSpeciesType
		,Disease.idfAggrMatrixVersion as idfDiagnosisRow
		,CAST (ISNULL(Disease.varValue,tlbAggrDiagnosticActionMTX.idfsDiagnosis) AS BIGINT) AS idfsDiagnosis
		,OIECode.idfAggrMatrixVersion as idfOIECodeRow
		,CAST (ISNULL(OIECode.varValue,trtDiagnosis.strOIECode) AS NVARCHAR(200)) AS strOIECode
		,DiagnosticAction.idfAggrMatrixVersion as idfDiagnosticActionRow
		,CAST (ISNULL(DiagnosticAction.varValue,tlbAggrDiagnosticActionMTX.idfsDiagnosticAction) AS BIGINT) AS idfsDiagnosticAction
		,Disease.intNumRow
FROM	tlbAggrDiagnosticActionMTX
INNER JOIN dbo.tlbAggrMatrixVersionHeader ON
	tlbAggrMatrixVersionHeader.intRowStatus = 0
INNER JOIN trtDiagnosis ON 
	trtDiagnosis.idfsDiagnosis = tlbAggrDiagnosticActionMTX.idfsDiagnosis
INNER JOIN  tlbAggrMatrixVersion Disease
ON 
	Disease.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	AND Disease.idfRow = tlbAggrDiagnosticActionMTX.idfAggrDiagnosticActionMTX
	AND Disease.idfsParameter = 226930000000 -- Disease
	AND Disease.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion OIECode
ON 
	OIECode.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	AND OIECode.idfRow = tlbAggrDiagnosticActionMTX.idfAggrDiagnosticActionMTX
	and OIECode.idfsParameter = 234430000000 -- OIECode
	AND OIECode.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion Species
ON 
	Species.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	AND Species.idfRow = tlbAggrDiagnosticActionMTX.idfAggrDiagnosticActionMTX
	and Species.idfsParameter = 239030000000 -- Species Type
	AND Species.idfVersion = Disease.idfVersion
	AND Species.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion DiagnosticAction
ON 
	DiagnosticAction.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	AND DiagnosticAction.idfRow = tlbAggrDiagnosticActionMTX.idfAggrDiagnosticActionMTX
	and DiagnosticAction.idfsParameter = 231670000000 -- InvestigationType
	AND DiagnosticAction.intRowStatus = 0
WHERE
		tlbAggrDiagnosticActionMTX.intRowStatus = 0
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
		idfsAggrCaseSection = 71460000000 /*Diagnostic matrix*/
		and intRowStatus = 0
ORDER BY CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) DESC, datStartDate DESC

--Lookup list of all available matrix versions
EXEC spAggregateMatrixVersion_SelectLookup 'en',71460000000 /*Diagnostic matrix*/



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

