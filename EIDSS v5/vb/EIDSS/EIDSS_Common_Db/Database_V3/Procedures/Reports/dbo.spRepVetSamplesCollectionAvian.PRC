SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetSamplesCollectionAvian]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetSamplesCollectionAvian]


GO

--##SUMMARY Select Avian samples list for avian investigation report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 22.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepVetSamplesCollectionAvian 8370000002 , 'en' 
 

*/ 

CREATE  Procedure [dbo].[spRepVetSamplesCollectionAvian] 
    (
        @ObjID	as bigint,
        @LangID as nvarchar(10)
    )
as 

	select		
				fnSpeciesType.[Name]			as SpeciesName,
				fnMaterial.strFieldBarcode		as strFieldBarcode,
				fnMaterial.SpecimenType		as SpecimenType
							
	from		dbo.tlbCase		as tCase
	inner join	dbo.tlbVetCase	as tVetCase
			on	tCase.idfCase = tVetCase.idfVetCase
		   and  tCase.intRowStatus = 0
		   
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

	inner join	fnMaterialList(@LangID) fnMaterial
	on			fnMaterial.idfCase = tCase.idfCase
	and			fnMaterial.idfParty =tlbSpecies.idfSpecies
	
	where tCase.idfCase =@ObjID
			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

