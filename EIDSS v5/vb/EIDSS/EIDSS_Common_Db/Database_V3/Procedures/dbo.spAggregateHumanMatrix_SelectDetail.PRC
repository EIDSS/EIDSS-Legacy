SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateHumanCaseMatrix_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateHumanCaseMatrix_SelectDetail]
GO


--##SUMMARY Selects data for AggregateHumanCaseMTXDetail form
--##SUMMARY that defines the list of diagnosis that should be displayed on AggregateCaseDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 11.02.2011

--##RETURNS Doesn't use



/*
--Example of procedure call:

EXECUTE spAggregateHumanCaseMatrix_SelectDetail 

*/


CREATE       procedure dbo.spAggregateHumanCaseMatrix_SelectDetail
as
/*
				@idfsParameterDiagnosis0 = 226890000000
				,@idfsParameterICD10Code0 = 229630000000
*/
SELECT	 
		trtDiagnosis.idfsDiagnosis as idfHumanCaseMtx
		,ISNULL(tlbAggrMatrixVersionHeader.idfVersion,0) AS idfVersion
		,Disease.idfAggrMatrixVersion as idfDiagnosisRow
		,IDCCode.idfAggrMatrixVersion as idfIDCCodeRow
		,trtDiagnosis.idfsDiagnosis
		,trtDiagnosis.strIDC10
		,Disease.intNumRow
FROM	trtDiagnosis
Inner Join fnReferenceLookup('en', 19000019/*rftDiagnosis*/,2) humanDiagnosis --to select only human cases
On trtDiagnosis.idfsDiagnosis = humanDiagnosis.idfsReference
INNER JOIN dbo.tlbAggrMatrixVersionHeader ON
	tlbAggrMatrixVersionHeader.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion Disease
ON 
	Disease.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	and Disease.varValue = trtDiagnosis.idfsDiagnosis
	and Disease.idfsParameter = 226890000000 -- Disease
	AND Disease.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion IDCCode
ON 
	IDCCode.idfVersion = tlbAggrMatrixVersionHeader.idfVersion
	AND IDCCode.idfRow = Disease.idfRow
	and IDCCode.idfsParameter = 229630000000 -- IDCCode
	AND IDCCode.intRowStatus = 0
WHERE
		trtDiagnosis.intRowStatus = 0
		And trtDiagnosis.idfsUsingType = 10020002/*Aggregate Case*/
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
		idfsAggrCaseSection = 71190000000 /*Human case matrix*/
		and intRowStatus = 0
ORDER BY CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) DESC, datStartDate DESC

--Lookup list of all available matrix versions
EXEC spAggregateMatrixVersion_SelectLookup 'en',71190000000 /*Human case matrix*/



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

