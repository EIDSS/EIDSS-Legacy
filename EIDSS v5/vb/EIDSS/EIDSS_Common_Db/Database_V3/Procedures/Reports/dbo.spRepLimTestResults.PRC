SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepLimTestResults]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepLimTestResults]


GO

--##SUMMARY Select data for Test results report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 15.12.2009

--##RETURNS Doesn't use 

/*
--Example of a call of procedure:

exec spRepLimTestResults  'en', 124350000000

*/

CREATE  Procedure [dbo].[spRepLimTestResults]
    (
		@LangID as nvarchar(10),
        @ObjID	as bigint
    )
as
	select  
				fnContainer.idfsCaseType			as idfsCase_Type,
				fnContainer.BatchTestCode			as BatchBarcode,
				fnContainer.TestCategory			as Category,
				fnContainer.TestResult				as TestResult,
				fnContainer.TestType				as TestType,
				fnContainer.datPerformedDate		as datComplete_Date,
				fnContainer.[Status]				as [Status],
				fnContainer.strBarcode				as SampleID,
				fnContainer.strFieldBarcode			as OriginalSampleID,
				fnContainer.SpecimenType			as SpecimenType,
				fnContainer.CaseID					as CaseID,
				tCase.CaseStatus					as CaseStatus,
				tCase.CaseType						as CaseType, 
				fnContainer.DiagnosisName			as DiagnosisName,	
				fnContainer.datFieldCollectionDate	as datCollectionDate,
				dbo.fnCreateNameString(rfPerformedBy.strFamilyName, rfPerformedBy.strFirstName, rfPerformedBy.strSecondName) as PerformedBy,
				rfPerformedOffice.[Name]			as PerformedByOrganization,
				fnContainer.HumanName				as PatientName,
				fnContainer.AnimalName				as AnimalName

	from		tlbTesting		as tTests
	 left join	dbo.fnTestList(@LANGID) fnContainer
			on	fnContainer.idfContainer = tTests.idfContainer
		   and	fnContainer.idfTesting = tTests.idfTesting
	-- Get Case 
	 left join	(
				 select		tlbCase.idfCase			as idfCase,
							rfCaseStatus.[Name]		as CaseStatus,
							rfCaseType.[Name]		as CaseType
				 from		tlbCase		
				-- Get Case Type
				 left join  fnReference(@LangID, 19000012 /*'rftCaseType' */)	as rfCaseType
						on  rfCaseType.idfsReference = tlbCase.idfsCaseType
				-- Get Case Status
				 left join  fnReference(@LangID, 19000011 /*'rftCaseStatus' */)	as rfCaseStatus
						on  rfCaseStatus.idfsReference = tlbCase.idfsCaseStatus
					 where	tlbCase.intRowStatus=0
				) as tCase
			on	tCase.idfCase = tTests.idfCase
	-- Get Case 
	 left join	dbo.fnInstitution (@LangID) as rfPerformedOffice
			on	rfPerformedOffice.idfOffice = fnContainer.idfPerformedByOffice

	 left join	tlbPerson				as rfPerformedBy
			on	rfPerformedBy.idfPerson = fnContainer.idfPerformedByPerson	

		 where	tTests.idfTesting = @ObjID
		   and	tTests.intRowStatus=0
			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
