SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetHerdDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetHerdDetails]


GO

--##SUMMARY Select data for Herd details for Avian report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 22.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
exec dbo.spRepVetHerdDetails @ObjID=4970000002,@LangID=N'ru'
select * from tlbCase

*/ 

CREATE  Procedure [dbo].[spRepVetHerdDetails]
    (
        @ObjID	as bigint,
        @LangID as nvarchar(10)
    )
as
	select  
	case 
		when strSpeciesType is null then tHerd.strHerdCode
		else null
	end									as HerdCode,
	strSpeciesType						as SpeciesID,
	unSpecies.intTotalAnimalQty			as Total,
	unSpecies.intSickAnimalQty			as Sick,
	unSpecies.intDeadAnimalQty			AS Dead,
	unSpecies.strAverageAge				as AVGAge,
	unSpecies.datStartOfSignsDate		as SignsDate,
	unSpecies.strType					as [Type],
	unSpecies.strNote					as strNote

	from		dbo.tlbCase as tCase
	-- get vet case
	inner join	dbo.tlbVetCase	as tVetCase
			on	tCase.idfCase = tVetCase.idfVetCase
		   and  tCase.intRowStatus = 0
	-- Get Farm
	 inner join	dbo.tlbParty	as tFarmParty
			on	tVetCase.idfVetCase = tFarmParty.idfCase
	 inner join	dbo.tlbFarm		as tFarm
			on	tFarmParty.idfParty = tFarm.idfFarm
		   and  tFarmParty.intRowStatus = 0
	 inner join	(		
						dbo.tlbHerd		as tHerd
			inner join	dbo.tlbParty	as tHerdParty
					on	tHerd.idfHerd = tHerdParty.idfParty
				   and  tHerdParty.intRowStatus = 0
				)
			on	tHerd.idfFarm = tFarm.idfFarm
	 left join	(
	 
				select		tInnerHerd.intSickAnimalQty,
							tInnerHerd.intTotalAnimalQty,
							tInnerHerd.intDeadAnimalQty,
							null					as strAverageAge,
							null					as datStartOfSignsDate,
							null					as strSpeciesType,
							tInnerHerd.strNote,
							tInnerHerd.idfHerd,
							'pptCaseHerd'			as strType,
							null					as idfSpecies
						
				  from		dbo.tlbHerd		as tInnerHerd
				inner join	dbo.tlbParty	as tInnerHerdParty
						on	tInnerHerd.idfHerd = tInnerHerdParty.idfParty
					   and  tInnerHerdParty.intRowStatus = 0
			union					   
				select		tSpecies.intSickAnimalQty,
							tSpecies.intTotalAnimalQty,
							tSpecies.intDeadAnimalQty,
							tSpecies.strAverageAge,
							tSpecies.datStartOfSignsDate,
							rfSpeciesType.[Name]	as strSpeciesType,
							tSpecies.strNote,
							tSpecies.idfHerd,
							'pptCaseHerdSpecies'	as strType,
							tSpecies.idfSpecies		as idfSpecies
						
				  from		dbo.tlbSpecies		as tSpecies
				 left join	dbo.fnReference(@LangID, 19000086 /*'rftSpeciesList'*/) as rfSpeciesType
						on	rfSpeciesType.idfsReference = tSpecies.idfsSpeciesType
				inner join	dbo.tlbParty		as tSpeciesParty
						on	tSpecies.idfSpecies = tSpeciesParty.idfParty
					   and  tSpeciesParty.intRowStatus = 0
				 

				) as unSpecies
			on	unSpecies.idfHerd = tHerd.idfHerd
		 where	tCase.idfCase = @ObjID
		 order by unSpecies.idfHerd, unSpecies.idfSpecies
			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

