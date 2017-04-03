SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spVetCaseAnimals_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spVetCaseAnimals_SelectDetail]
GO

--##SUMMARY Selects list of animals related with specific case.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
DECLARE @ID BIGINT 
SET @ID = 1
exec spVetCaseAnimals_SelectDetail @ID, 'en'
*/

CREATE            PROC	spVetCaseAnimals_SelectDetail
		@idfCase	BIGINT  --##PARAM @idfCase - case ID for wich the animals are selected
		,@LangID		NVARCHAR(50)  --##PARAM @LangID - language ID
AS
-- 0 Animal
SELECT  	 
	tlbAnimal.idfAnimal,  
	tlbHerd.idfHerd, 
	tlbHerd.strHerdCode, 
	tlbAnimal.idfsAnimalAge,
	tlbAnimal.idfsAnimalGender, 
	tlbAnimal.strAnimalCode, 
	tlbAnimal.strDescription, 
	tlbAnimal.idfsAnimalCondition, 
	tlbAnimal.idfSpecies, 
	tlbSpecies.idfsSpeciesType,
	tlbAnimal.idfObservation,
	tlbObservation.idfsFormTemplate,
	Gender.[Name] AS strGender,
	Species.[Name] AS strSpecies

FROM tlbAnimal
INNER JOIN tlbSpecies ON 
	tlbSpecies.idfSpecies=tlbAnimal.idfSpecies 
INNER JOIN tlbParty SpeciesParty ON
	SpeciesParty.idfParty = tlbSpecies.idfSpecies
	and SpeciesParty.introwstatus=0 
INNER JOIN tlbHerd ON 
	tlbHerd.idfHerd=tlbSpecies.idfHerd 
INNER JOIN tlbParty HerdParty ON
	HerdParty.idfParty = tlbHerd.idfHerd
	and HerdParty.introwstatus=0 
INNER JOIN tlbParty ON
	tlbParty.idfParty = tlbAnimal.idfAnimal
	and tlbParty.idfsPartyType = 10072002 --Animal
LEFT OUTER JOIN fnReference(@LangID,19000007/*rftAnimalGenderList*/) Gender ON
	Gender.idfsReference=tlbAnimal.idfsAnimalGender
LEFT OUTER JOIN fnReference(@LangID,19000086/*'rftSpeciesList'*/) Species ON
	Species.idfsReference=tlbSpecies.idfsSpeciesType
LEFT OUTER JOIN tlbObservation ON
	tlbObservation.idfObservation = tlbAnimal.idfObservation
	AND tlbObservation.intRowStatus = 0

WHERE	tlbParty.idfCase=@idfCase
		and tlbParty.intRowStatus = 0




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

