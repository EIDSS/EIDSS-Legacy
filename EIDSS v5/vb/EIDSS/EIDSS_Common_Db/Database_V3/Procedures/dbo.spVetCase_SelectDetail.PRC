SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spVetCase_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spVetCase_SelectDetail]
GO

--##SUMMARY Selects data for specific veterinary case.
--##SUMMARY These data are shared between several case conrols.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
@idfCase @idfAnimal bigint

EXECUTE spVetCase_SelectDetail
   @idfCase
  ,'en'
*/



Create            Proc	spVetCase_SelectDetail
		@idfCase	bigint,  --##PARAM @idfCase - case ID
		@LangID		nvarchar(50) --##PARAM @LangID - language ID
As
-- 0 Case Activity
Select 

	tlbCase.idfCase
	,tlbCase.idfsCaseStatus
	,tlbCase.idfsCaseProgressStatus
	,tlbCase.idfsShowDiagnosis
	,tlbCase.idfsCaseType
	,tlbCase.idfOutbreak
	,tlbOutbreak.strOutbreakID
	,tlbCase.datEnteredDate
	,tlbCase.strCaseID
	,tlbVetCase.idfsTentativeDiagnosis
	,tlbVetCase.idfsTentativeDiagnosis1
	,tlbVetCase.idfsTentativeDiagnosis2
	,tlbVetCase.idfsFinalDiagnosis
	,tlbVetCase.idfPersonInvestigatedBy
	,tlbVetCase.idfPersonEnteredBy
	,tlbVetCase.idfPersonReportedBy
	,tlbVetCase.idfObservation
	,tlbObservation.idfsFormTemplate
	,tlbVetCase.idfsSite
	,tlbVetCase.datReportDate
	,tlbVetCase.datAssignedDate
	,tlbVetCase.datInvestigationDate
	,tlbVetCase.datTentativeDiagnosisDate
	,tlbVetCase.datTentativeDiagnosis1Date
	,tlbVetCase.datTentativeDiagnosis2Date
	,tlbVetCase.datFinalDiagnosisDate
	,tlbCase.strSampleNotes
	,tlbVetCase.strTestNotes
	,tlbVetCase.strSummaryNotes
	,tlbVetCase.strClinicalNotes
	,tlbVetCase.strFieldAccessionID
	,tlbParty.idfParty as idfFarm
	,tlbParty.idfRootParty  as idfRootFarm
	,FinalDiagnosis.strOIECode as strFinalDiagnosisOIECode
	,TentativeDiagnosis.strOIECode as strTentativeDiagnosisOIECode
	,TentativeDiagnosis1.strOIECode as strTentativeDiagnosis1OIECode
	,TentativeDiagnosis2.strOIECode as strTentativeDiagnosis2OIECode

FROM tlbCase
INNER JOIN tlbVetCase ON
	tlbCase.idfCase=tlbVetCase.idfVetCase
LEFT OUTER JOIN dbo.tlbParty ON
	tlbParty.idfCase = tlbCase.idfCase 
	and tlbParty.idfsPartyType = 10072005-- Farm
	and tlbParty.intRowStatus = 0
LEFT OUTER JOIN tlbObservation ON
	tlbObservation.idfObservation = tlbVetCase.idfObservation
	AND tlbObservation.intRowStatus = 0
LEFT OUTER JOIN tlbOutbreak ON
	tlbOutbreak.idfOutbreak = tlbCase.idfOutbreak
	AND tlbOutbreak.intRowStatus = 0
LEFT OUTER JOIN trtDiagnosis FinalDiagnosis ON
	FinalDiagnosis.idfsDiagnosis = tlbVetCase.idfsFinalDiagnosis
LEFT OUTER JOIN trtDiagnosis TentativeDiagnosis ON
	TentativeDiagnosis.idfsDiagnosis = tlbVetCase.idfsTentativeDiagnosis
LEFT OUTER JOIN trtDiagnosis TentativeDiagnosis1 ON
	TentativeDiagnosis1.idfsDiagnosis = tlbVetCase.idfsTentativeDiagnosis1
LEFT OUTER JOIN trtDiagnosis TentativeDiagnosis2 ON
	TentativeDiagnosis2.idfsDiagnosis = tlbVetCase.idfsTentativeDiagnosis2
Where 
	tlbCase.idfCase=@idfCase
	and tlbCase.introwstatus=0


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

