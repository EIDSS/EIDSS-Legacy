SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCaseTests_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCaseTests_SelectDetail]
GO



CREATE       PROCEDURE dbo.spCaseTests_SelectDetail
	@idfCase AS bigint,
	@LangID NVARCHAR(50)
AS

select 
	tlbTesting.idfTesting,
	tlbTesting.idfObservation,
	tlbTesting.idfsTestStatus,
	Container.strBarcode,
	Original.strFieldBarcode,--Container.strFieldBarcode,
	SpecimenType.Name as SpecimenType,--Container.SpecimenType,
	tlbTesting.idfsTestType,
	TestName.Name as TestName,
	TestType.Name as TestType,
	tlbBatchTest.strBarcode as strBatchCode,
	isnull(tlbBatchTest.datPerformedDate,tlbExtBatchTest.datPerformedDate) as datPerformedDate,
	tlbBatchTest.datValidatedDate,
	--tlbBatchTest.idfsBatchStatus,
	TestResult.Name as TestResult,
	ActivityStatus.Name as TestStatus,
	Container.DepartmentName,
	Container.AnimalName,
	Diagnosis.Name as DiagnosisName
/*,
	Observation.idfRelated_Activity as idfObservation*/
from		tlbTesting
inner join	fnContainerList(@LangID) Container
on			tlbTesting.idfContainer=Container.idfContainer and tlbTesting.intRowStatus=0
left join	tlbMaterial Original
on			Original.idfMaterial=Container.idfRootParentMaterial
left join	fnReference(@LangID, 19000087) SpecimenType --rftSpecimenType
on			SpecimenType.idfsReference = Original.idfsSpecimenType

left join	fnReference(@LangID,19000019) Diagnosis
on			tlbTesting.idfsDiagnosis=Diagnosis.idfsReference
left join	tlbBatchTest
on			tlbBatchTest.idfBatchTest=tlbTesting.idfBatchTest
left join	tlbExtBatchTest
on			tlbExtBatchTest.idfExtBatchTest=tlbTesting.idfExtBatchTest
left join	fnReference(@LangID,19000001) ActivityStatus 
on			tlbTesting.idfsTestStatus=ActivityStatus.idfsReference
left join	fnReference(@LangID,19000097) TestName
on			tlbTesting.idfsTestType=TestName.idfsReference
left join	fnReference(@LangID,19000096) TestResult 
on			tlbTesting.idfsTestResult=TestResult.idfsReference
left join	fnReference(@LangID,19000095) TestType
on			tlbTesting.idfsTestForDiseaseType=TestType.idfsReference
where		tlbTesting.idfCase=@idfCase or
			tlbTesting.idfMonitoringSession=@idfCase

select
			tlbTestValidation.idfTestValidation,
			tlbTesting.idfTesting,
			tlbTestValidation.idfsDiagnosis,

			tlbTestValidation.blnValidateStatus,
			tlbTestValidation.idfValidatedByPerson,
			tlbTestValidation.strValidateComment,
			tlbTestValidation.datValidationDate,
			
			tlbTestValidation.idfsInterpretedStatus,
			tlbTestValidation.idfInterpretedByPerson,
			tlbTestValidation.strInterpretedComment,
			tlbTestValidation.datInterpretationDate

from		tlbTestValidation
inner join	tlbTesting
on			tlbTesting.idfTesting=tlbTestValidation.idfTesting and 
			tlbTesting.intRowStatus=0 and
			tlbTestValidation.intRowStatus=0
/*inner join	tlbBatchTest
on			tlbBatchTest.idfBatchTest=tlbTesting.idfBatchTest and
			tlbBatchTest.idfsBatchStatus=10001001 and
			tlbTesting.intRowStatus=0 and
			tlbBatchTest.intRowStatus=0*/
left join	tlbPerson Validated
on			tlbTestValidation.idfValidatedByPerson=Validated.idfPerson
left join	tlbPerson Interpreted
on			tlbTestValidation.idfInterpretedByPerson=Interpreted.idfPerson
where		tlbTesting.idfCase=@idfCase or
			tlbTesting.idfMonitoringSession=@idfCase



GO