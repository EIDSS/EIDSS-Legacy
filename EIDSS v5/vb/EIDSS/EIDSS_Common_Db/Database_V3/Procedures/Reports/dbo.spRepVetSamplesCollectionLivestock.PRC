SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetSamplesCollectionLivestock]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetSamplesCollectionLivestock]


GO 

--##SUMMARY Select Avian samples list for avian investigation report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 22.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepVetSamplesCollectionLivestock 4970000002 , 'en' 
  
*/ 

CREATE  Procedure [dbo].[spRepVetSamplesCollectionLivestock] 
    (
        @ObjID	as bigint,
        @LangID as nvarchar(10)
    )
as 

	select   
				 tlbAnimal.strAnimalCode	as AnimalID
				,fnSpeciesType.[Name]		as strSpecies
				,fnAnimalAge.[Name]			as AnimalAge
				,fnAnimalGender.[Name]		as strGender
				,null						as CSstring
				,fnMaterial.SpecimenType	as MaterialType
				,fnMaterial.strFieldBarcode
				,tlbAnimal.idfObservation
				,tlbAnimal.idfAnimal
				
				/*
				fnContainer.AnimalName			AS AnimalID,
				fnContainer.SpeciesName			AS strSpecies,
				rfAnimalGender.[Name]			AS strGender,
				rfAnimalAge.[Name]				as AnimalAge,
				null							as CSstring,
				fnContainer.SpecimenType		as MaterialType,
				fnContainer.strFieldBarcode		as strFieldBarcode,
				tAnimal.idfObservation			as idfObservation
				*/
		
	from		tlbCase		as tCase
	inner join	tlbVetCase	as tVetCase
			on	tCase.idfCase = tVetCase.idfVetCase
			and tCase.intRowStatus = 0
	-- get farm
	inner join
				(
								tlbFarm
					inner join	tlbParty		as farmParty
					on			tlbFarm.idfFarm = farmParty.idfParty 
					and			farmParty.intRowStatus = 0
				)
	on 			farmParty.idfCase = tCase.idfCase
	inner join	(
								tlbHerd
					inner join	tlbParty		as herdParty
					on			tlbHerd.idfHerd = herdParty.idfParty 
					and			herdParty.intRowStatus = 0
				)
	on			tlbHerd.idfFarm = tlbFarm.idfFarm
	inner join	(	
					tlbSpecies
					inner join	tlbParty		as speciesParty
					on			tlbSpecies.idfSpecies = speciesParty.idfParty 
					and			speciesParty.intRowStatus = 0
					inner join	dbo.fnReference(@LangID,19000086) as fnSpeciesType
					on			fnSpeciesType.idfsReference = tlbSpecies.idfsSpeciesType
				)
	on			tlbSpecies.idfHerd  = tlbHerd.idfHerd
	inner join	(
					tlbAnimal
					inner join	tlbParty		as animalParty
					on			tlbAnimal.idfAnimal = animalParty.idfParty 
					and			animalParty.intRowStatus = 0
					left join	dbo.fnReference(@LangID,19000007) as fnAnimalGender
					on			fnAnimalGender.idfsReference = tlbAnimal.idfsAnimalGender
					left join	dbo.fnReference(@LangID,19000005) as fnAnimalAge
					on			fnAnimalAge.idfsReference = tlbAnimal.idfsAnimalAge
				)
	on			tlbAnimal.idfSpecies  = tlbSpecies.idfSpecies
	
	

	inner join	fnMaterialList(@LangID) fnMaterial
	on			fnMaterial.idfParty = tlbAnimal.idfAnimal
	and			fnMaterial.idfCase = tCase.idfCase
	
	where tCase.idfCase =@ObjID

--select * from fnMaterialList('en') fnMaterial
			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



	