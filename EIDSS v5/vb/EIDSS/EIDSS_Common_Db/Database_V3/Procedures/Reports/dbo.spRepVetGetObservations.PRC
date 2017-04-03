SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetGetObservations]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetGetObservations]


GO

--##SUMMARY Select observations for Veterinary Case.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 24.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepVetGetObservations 4970000002, 'ru'

*/

CREATE  Procedure [dbo].[spRepVetGetObservations]
    (
        @ObjID	as bigint,
        @LangID as nvarchar(10)
    )
as
	-- Get Case and Farm observations

	select  	tVetCase.idfVetCase			as idfCase,	
				tVetCase.idfObservation		as idfCaseObservation,
				tFarm.idfObservation		as idfFarmObservation
	from		dbo.tlbVetCase	as tVetCase
	inner join	dbo.tlbCase		as tCase
			on	tCase.idfCase = tVetCase.idfVetCase
		   and  tCase.intRowStatus = 0
	 left join	dbo.tlbParty	as tFarmParty
			on	tVetCase.idfVetCase = tFarmParty.idfCase
	inner join	dbo.tlbFarm		as tFarm
			on	tFarmParty.idfParty = tFarm.idfFarm
		   and  tFarmParty.intRowStatus = 0
		 where	tVetCase.idfVetCase = @ObjID
		 
	-- Get Species observations 
	select  	tVetCase.idfVetCase			as idfCase,	
				tSpecies.idfObservation		as idfSpeciesObservation,
				fnSpecies.[Name]			as strSpeciesName
	from		dbo.tlbVetCase	as tVetCase
	 left join	dbo.tlbParty	as tSpeciesParty
			on	tVetCase.idfVetCase = tSpeciesParty.idfCase
	inner join	dbo.tlbSpecies		as tSpecies
			on	tSpeciesParty.idfParty = tSpecies.idfSpecies
		   and  tSpeciesParty.intRowStatus = 0
	 left join	fnReference(@LangID, 19000086) as fnSpecies
			on	tSpecies.idfsSpeciesType = fnSpecies.idfsReference
		 where	tVetCase.idfVetCase = @ObjID
		 
		 
		 --select * from trtBaseReference where idfsBaseReference = 39110000000
	-- Get Animal observations 
	select  	tVetCase.idfVetCase			as idfCase,	
				tAnimal.idfObservation		as idfAnimalObservation,
				tAnimal.strName				as strAnimalName
	from		dbo.tlbVetCase	as tVetCase
	 left join	dbo.tlbParty	as tAnimalParty
			on	tVetCase.idfVetCase = tAnimalParty.idfCase
	inner join	dbo.tlbAnimal		as tAnimal
			on	tAnimalParty.idfParty = tAnimal.idfAnimal
		   and  tAnimalParty.intRowStatus = 0
		 where	tVetCase.idfVetCase = @ObjID
		 
			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

