SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepLimCaseTestsValidation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepLimCaseTestsValidation]


GO

--##SUMMARY Select data for Test report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 10.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepLimCaseTestsValidation 11000000241 , 'en' 

*/

CREATE  Procedure [dbo].[spRepLimCaseTestsValidation]
    (
        @ObjID	as bigint,
        @LangID as nvarchar(10)
    )
as

	declare @cYes as nvarchar(20)
	declare @cNo as nvarchar(20)
	select @cYes=[Name] from fnreference(@LangID,19000100 /*'rftYesNoValue'*/) where idfsReference=10100001 /*'ynvYes'*/
	select @cNo=[Name] from fnreference(@LangID,19000100 /*'rftYesNoValue'*/) where idfsReference=10100002 /*'ynvNo'*/

	select  
	rfDiagnosis.[Name]					as Diagnosis,
	rfTestType.[name]					as TestName,
	rfTestForDisease.[Name]				as TestType,
	idfsInterpretedStatus				as intRuleStatus,
	tValidation.strInterpretedComment	as strRuleComment,
	tValidation.datInterpretationDate	as interpretedDate,
	dbo.fnCreateNameString(tInterpretedBy.strFamilyName, tInterpretedBy.strFirstName, tInterpretedBy.strSecondName) as InterpretedBy,

	case tValidation.blnValidateStatus 
		when 0 then @cNo
		when 1 then @cYes
	end									as intValidateStatus,
	dbo.fnCreateNameString(tInterpretedBy.strFamilyName, tInterpretedBy.strFirstName, tInterpretedBy.strSecondName) as InterpretedBy,
	tValidation.strValidateComment		as strValidateComment,
	dbo.fnCreateNameString(tValidatedBy.strFamilyName, tValidatedBy.strFirstName, tValidatedBy.strSecondName) as ValidatedBy,
	tValidation.datValidationDate		as validatedDate

	
	from 
				dbo.tlbTesting			as tTests
	 left join	dbo.fnReference(@LANGID, 19000097 ) rfTestType --rftTestType
			on	rfTestType.idfsReference = tTests.idfsTestType
	 left join	dbo.fnReference(@LANGID,19000095)	as rfTestForDisease
			on	tTests.idfsTestForDiseaseType = rfTestForDisease.idfsReference
	-- Get Tests  Validation		
	 inner join	tlbTestValidation		as tValidation
			on	tTests.idfTesting = tValidation.idfTesting 
		   and	tTests.intRowStatus = 0 
		   and	tValidation.intRowStatus = 0
	 left join	tlbPerson				as tValidatedBy
			on	tValidation.idfValidatedByPerson = tValidatedBy.idfPerson
	 left join	tlbPerson				as tInterpretedBy 
			on	tValidation.idfInterpretedByPerson = tInterpretedBy.idfPerson
	-- Get Diagnosis
	 left join	fnReference(@LangID, 19000019/*'rftDiagnosis' */) as rfDiagnosis
			on	rfDiagnosis.idfsReference = tValidation.idfsDiagnosis

	-- Filter Condition
		 where	(tTests.idfCase=@ObjID 	or tTests.idfMonitoringSession=@ObjID)
		   and	tTests.intRowStatus = 0



	
			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

