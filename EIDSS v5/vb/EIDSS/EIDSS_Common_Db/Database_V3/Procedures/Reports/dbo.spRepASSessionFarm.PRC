 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepASSessionFarm]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepASSessionFarm]


GO

--##SUMMARY Selects list of farms, heards, species amd animals related with specific monitoring session for report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 08.07.2010

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepASSessionFarm  712900000000, 'en'

*/

CREATE  Procedure [dbo].[spRepASSessionFarm]
	(
		@idfCase bigint,
		@LangID nvarchar(20)
	)
AS	


select   
			--farm
			 tlbFarm.idfFarm
			,tlbFarm.strFarmCode
			,RTRIM(ISNULL(tlbHuman.strLastName +N' ',N'') +ISNULL(tlbHuman.strFirstName +N' ',N'') + ISNULL(tlbHuman.strSecondName,N'')) 
									as strOwnerName
			,dbo.fnGeoLocationString(@LangID,tlbFarm.idfFarmAddress,null) 
									as strFarmAddress
			--species + animals + samples
			,tlbAnimal.strAnimalCode	
			,fnSpeciesType.[Name]	as strSpeciesType
			,fnAnimalAge.[Name]		as strAnimalAge
			,tlbAnimal.strColor		as strAnimalColor	
			,tlbAnimal.strName		as strAnimalName	
			,fnAnimalGender.[Name]	as strAnimalGender
			,fnMaterial.strFieldBarcode
			,fnMaterial.SpecimenType as strSpecimenName

			
	
from		tlbMonitoringSession tSession
-- get farm
left join
			(
							tlbFarm
				inner join	tlbParty		as farmParty
				on			tlbFarm.idfFarm = farmParty.idfParty 
				and			farmParty.intRowStatus = 0
				
				left join	tlbHuman 
				on			tlbHuman.idfHuman=tlbFarm.idfHuman 
				left join	tlbParty		as ownerParty 
				on			ownerParty.idfParty=tlbHuman.idfHuman 
			)
on 			farmParty.idfMonitoringSession = tSession.idfMonitoringSession
left join	(
							tlbHerd
				inner join	tlbParty		as herdParty
				on			tlbHerd.idfHerd = herdParty.idfParty 
				and			herdParty.intRowStatus = 0
			)
on			tlbHerd.idfFarm = tlbFarm.idfFarm
left join	(	
				tlbSpecies
				inner join	tlbParty		as speciesParty
				on			tlbSpecies.idfSpecies = speciesParty.idfParty 
				and			speciesParty.intRowStatus = 0
				inner join	dbo.fnReference(@LangID,19000086) as fnSpeciesType
				on			fnSpeciesType.idfsReference = tlbSpecies.idfsSpeciesType
			)
on			tlbSpecies.idfHerd  = tlbHerd.idfHerd
left join	(
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

left join	fnMaterialList(@LangID) fnMaterial
on			fnMaterial.idfParty = tlbAnimal.idfAnimal
and			fnMaterial.idfMonitoringSession = tSession.idfMonitoringSession
where		tSession.idfMonitoringSession = @idfCase
and			tSession.intRowStatus = 0
	
	
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



