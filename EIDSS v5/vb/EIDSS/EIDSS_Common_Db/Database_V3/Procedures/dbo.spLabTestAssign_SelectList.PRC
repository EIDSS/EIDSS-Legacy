SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--spLabTestAssign_SelectList @LangID='en'

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabTestAssign_SelectList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabTestAssign_SelectList]
GO

CREATE PROCEDURE [dbo].[spLabTestAssign_SelectList] 
	@LangID nvarchar(50),
	@HACode integer
AS
BEGIN

	select 
		ref.idfsReference,
		Name as TestName,
		cast(10095003 as bigint) as idfsTestForDiseaseType --tdtPresumptive
	from		/*Test_Type
	inner join	*/fnReference(@LangID,19000097) ref --rftTestType
	--on			ref.idfsReference=Test_Type.idfsTest_Type
	where		/*ISNULL(Test_Type.blnPensideTest,0)<>1
	and			*/(ref.intHACode is NULL or ((ref.intHACode & @HACode) = @HACode))

	select 
		trtTestForDisease.idfTestForDisease,	
		ref.idfsReference,
		--Test_Type.idfsTest_Type,
		--idfsTestForDiseaseType,
		ref.Name as TestName, 
		trtTestForDisease.idfsTestForDiseaseType,
		trtTestForDisease.idfsDiagnosis
	from		fnReference(@LangID,19000097) ref --rftTestType
	--on			ref.idfsReference=Test_Type.idfsTest_Type
	inner join	trtTestForDisease
	on			trtTestForDisease.idfsTestType=ref.idfsReference and trtTestForDisease.intRowStatus = 0
	where		/*ISNULL(Test_Type.blnPensideTest,0)<>1
	and			*/(ref.intHACode is NULL or ((ref.intHACode & @HACode) = @HACode))

END


GO