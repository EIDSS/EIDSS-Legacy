SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetPensideTestsList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetPensideTestsList]


GO

--##SUMMARY Select data for Penside Tests for Vet report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 23.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepVetPensideTestsList 7110000002 , 'en' 
 
*/ 

CREATE  Procedure [dbo].[spRepVetPensideTestsList] 
    (
        @ObjID	as bigint,
        @LangID as nvarchar(10)
    )
as
	select		rfTestType.[Name]				as TestUsed,
				isnull(tAnimal.strAnimalCode, tHerd.strHerdCode)		as AnimalID,
				tMaterial.strFieldBarcode		as SampleID,
				rfSpecimenType.[Name]			as SampleType,
				rfTestResult.[Name]				as TestResult 	
	 
	from		dbo.tlbCase			as tCase
	-- get vet case
	inner join	dbo.tlbVetCase		as tVetCase
			on	tCase.idfCase = tVetCase.idfVetCase
		   and  tCase.intRowStatus = 0
	inner join	dbo.tlbPensideTest	as tTest
			on	tVetCase.idfVetCase = tTest.idfVetCase
			and tTest.intRowStatus = 0
	 left join	dbo.fnReference(@LangID, 19000105 /*rftPensideTestResult*/)	as rfTestResult
			on	rfTestResult.idfsReference = tTest.idfsPensideTestResult
	 left join	dbo.fnReference(@LangID, 19000104 /*rftPensideTestType*/)	as rfTestType
			on	rfTestType.idfsReference = tTest.idfsPensideTestType
	 left join	dbo.tlbMaterial		as tMaterial
			on	tTest.idfMaterial = tMaterial.idfMaterial		
	 left join	dbo.fnReference(@LangID, 19000087 /*rftSpecimenType*/)		as rfSpecimenType
			on	tMaterial.idfsSpecimenType = rfSpecimenType.idfsReference
	 left join	dbo.tlbParty		as tParty
			on	tParty.idfParty = tTest.idfParty
	 left join	dbo.tlbSpecies		as tSpecies
			on	tParty.idfParty = tSpecies.idfSpecies
	 left join	dbo.tlbHerd			as tHerd
			on	tSpecies.idfHerd = tHerd.idfHerd
	 left join	dbo.tlbAnimal		as tAnimal
			on	tParty.idfParty = tAnimal.idfAnimal
		 where  tCase.idfCase = @ObjID			
		   and	tParty.intRowStatus = 0
			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

