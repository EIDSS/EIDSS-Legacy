SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateVetCaseMatrix_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateVetCaseMatrix_SelectDetail]
GO


--##SUMMARY Selects data for AggregateVetCaseMTXDetail form
--##SUMMARY that defines the list of cases and species that should be displayed on AggregateVetCaseDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 03.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

EXECUTE spAggregateVetCaseMatrix_SelectDetail 

*/


CREATE       procedure dbo.spAggregateVetCaseMatrix_SelectDetail
as
/*
@idfsParameterSpecies1 = 239010000000
@idfsParameterDisease1 = 226910000000
@idfsParameterOIECode1 = 234410000000
*/
-- 0 Matix itself with all versions
SELECT	 tlbAggrVetCaseMTX.idfAggrVetCaseMTX
		,tlbAggrMatrixVersionHeader.idfVersion
		,Species.idfAggrMatrixVersion as idfSpeciesRow 
		,CAST (ISNULL(Species.varValue,tlbAggrVetCaseMTX.idfsSpeciesType) AS BIGINT) AS idfsSpeciesType
		,Disease.idfAggrMatrixVersion as idfDiagnosisRow
		,CAST (ISNULL(Disease.varValue,tlbAggrVetCaseMTX.idfsDiagnosis) AS BIGINT) AS idfsDiagnosis
		,OIECode.idfAggrMatrixVersion as idfOIECodeRow
		,CAST (ISNULL(OIECode.varValue,trtDiagnosis.strOIECode) AS NVARCHAR(200)) AS strOIECode
		,Disease.intNumRow
FROM	tlbAggrVetCaseMTX
INNER JOIN dbo.tlbAggrMatrixVersionHeader ON
	tlbAggrMatrixVersionHeader.intRowStatus = 0
INNER JOIN trtDiagnosis ON 
	trtDiagnosis.idfsDiagnosis = tlbAggrVetCaseMTX.idfsDiagnosis
INNER JOIN  tlbAggrMatrixVersion Disease
ON 
	Disease.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	AND Disease.idfRow = tlbAggrVetCaseMTX.idfAggrVetCaseMTX
	and Disease.idfsParameter = 226910000000 -- Disease
	AND Disease.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion OIECode
ON 
	OIECode.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	AND OIECode.idfRow = tlbAggrVetCaseMTX.idfAggrVetCaseMTX
	and OIECode.idfsParameter = 234410000000 -- OIECode
	AND OIECode.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion Species
ON 
	Species.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	and Species.idfRow = tlbAggrVetCaseMTX.idfAggrVetCaseMTX
	and Species.idfsParameter = 239010000000 -- Species Type
	AND Species.intRowStatus = 0
WHERE
		tlbAggrVetCaseMTX.intRowStatus = 0
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
		idfsAggrCaseSection = 71090000000 /*VetCase matrix*/
		and intRowStatus = 0
		--and blnIsActive = 1
ORDER BY CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) DESC, datStartDate DESC

--Lookup list of all available matrix versions
EXEC spAggregateMatrixVersion_SelectLookup 'en',71090000000 /*VetCase matrix*/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

