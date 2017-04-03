SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabBatch_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabBatch_SelectDetail]
GO



create proc [dbo].[spLabBatch_SelectDetail]
				@idfBatchTest bigint,
				@LANGID varchar(10)
as 

select 
	tlbBatchTest.idfBatchTest,
	tlbBatchTest.strBarcode,	
	tlbBatchTest.idfsBatchStatus,
	tlbBatchTest.idfsTestType,
	TestName = TestType.Name,
	tlbBatchTest.datPerformedDate,
	tlbBatchTest.datValidatedDate,
	tlbBatchTest.idfPerformedByOffice,
	tlbBatchTest.idfPerformedByPerson,
	tlbBatchTest.idfValidatedByOffice,
	tlbBatchTest.idfValidatedByPerson,
	--TestedBy = eaTested.idfEmployee,
	--ValidatedBy = eaValidated.idfEmployee,
	--office.idfOffice, 
	--tlbBatchTast.idfsFFormTemplateID,
	tlbBatchTest.idfObservation,
	tlbObservation.idfsFormTemplate

from		tlbBatchTest 
left join	tlbObservation
on			tlbBatchTest.idfObservation=tlbObservation.idfObservation
left join	fnReference(@LANGID, 19000097) TestType
					on TestType.idfsReference = tlbBatchTest.idfsTestType

/*	inner join activity a on a.idfActivity=b.idfActivity
	left outer join activity_Relationship Obser 
			on (a.idfActivity=Obser.idfParent_Activity and Obser.idfsActivity_Relation_type= 'artBatchObservToBatch')
						

	left outer join employee_for_activity eaTested 
					on eaTested.idfActivity = b.idfActivity  and eaTested.intRowStatus=0
					and eaTested.idfsEmployee_for_Activity_Type  ='eatPerformedBy'

	left outer join employee_for_activity eaValidated 
					on eaValidated.idfActivity = b.idfActivity  and eaValidated.intRowStatus=0
					and eaValidated.idfsEmployee_for_Activity_Type  ='eatValidatedBy'

	left outer join office_for_activity office	
					on office.idfActivity = b.idfActivity and office.intRowStatus=0
					and office.idfsOffice_for_Activity_Type = 'oatToInstitution'

*/	
where tlbBatchTest.idfBatchTest=@idfBatchTest
/*
select 
		tlbTesting.idfTesting,
		tlbTesting.idfBatchTest,
		tlbTesting.intTestNumber,
		tlbTesting.idfsTestResult,
		tlbTesting.idfObservation,
		cast(0 as bigint) as idfsTemplate,
		Cnt.strBarcode,
		Cnt.DiagnosisName,
		Cnt.SpecimenType,
		Cnt.idfCase
from		tlbTesting
inner join	fnContainerList(@LangID)Cnt
on			Cnt.idfContainer=tlbTesting.idfContainer			
where		tlbTesting.idfBatchTest=@idfBatchTest
*/

select
		Tests.idfTesting,
		--Tests.idfBatchTest,
		Tests.intTestNumber,--
		Tests.idfsTestResult,
		Tests.idfObservation,
		Tests.TestType,
		cast(0 as bigint) as idfsTemplate,
		Tests.strBarcode,--
		Tests.DiagnosisName,--
		Tests.SpecimenType,--
		Tests.idfCase,
		Tests.TestCategory,
		Tests.idfsFormTemplate
from	fnTestList(@LangID)Tests
where	Tests.idfBatchTest=@idfBatchTest


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

