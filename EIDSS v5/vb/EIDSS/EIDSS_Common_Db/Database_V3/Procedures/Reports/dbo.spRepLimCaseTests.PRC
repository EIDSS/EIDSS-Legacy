SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepLimCaseTests]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepLimCaseTests]


GO

--##SUMMARY Select data for Test report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 10.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepLimCaseTests 10530000002 , 'en' 

*/

CREATE  Procedure [dbo].[spRepLimCaseTests]
    (
        @ObjID	as bigint,
        @LangID as nvarchar(10)
    )
as
	select  
	tTests.idfTesting					as idfTest,
	tTests.idfObservation				as idfTestObservation,
	tTests.strFieldBarcode				as strFieldBarcode,
	tTests.strBarcode					as LabBarcode,
	tTests.SpecimenType					as SpecimenType,
	tTests.TestType						as TestName,
	tTests.idfsTestType					as idfsTestType,
	tTests.BatchTestCode				as TestRunID,
	tTests.datPerformedDate				as DateTested,
	tTests.DepartmentName				as FunctionalArea,
	tTests.TestCategory					as TestType,
	tTests.[Status]						as TestStatus,
	tTests.TestResult					as TestResult,
	tTests.AnimalName					as AnimalName
	--rfCaseType.[Name]					as ActivityType
	
	from	fnTestList(@LangID)	as tTests
	where	tTests.idfCase = @ObjID 
	or		tTests.idfMonitoringSession = @ObjID 
		   
		/*   
	-- Get Case 		
				dbo.tlbCase						as tCase	
	 left join	fnTestList(@LangID)	as tTests
			on	tCase.idfCase = tTests.idfCase
	 Get Case Type
	 left join  fnReference(@LangID, 19000012 /*'rftCaseType' */)	as rfCaseType
			on  rfCaseType.idfsReference = tCase.idfsCaseType

	-- Filter Condition
		 where	-- tTests.idfsTestStatus = 10001001 /*Completed in dbo.fnReference('en', 19000001 ) -- idfsActivity_Status*/
		   
				tCase.intRowStatus = 0
		   and	tCase.idfCase = @ObjID

		*/
		

			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





