SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASSessionAnimals_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASSessionAnimals_SelectDetail]
GO

--##SUMMARY Selects list of animals related with specific monitoring session.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 08.07.2010

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
DECLARE @ID BIGINT 
SET @ID = 1
exec spASSessionAnimals_SelectDetail @ID, 'en'
*/

CREATE            PROC	spASSessionAnimals_SelectDetail
		@idfMonitoringSession	BIGINT  --##PARAM @idfMonitoringSession -  ID of monitoring session for wich the animals are listed
		--,@LangID		NVARCHAR(50)  --##PARAM @LangID - language ID
AS
-- 0 Animal
SELECT  	 
	tlbAnimal.idfAnimal,  
	tlbAnimal.idfsAnimalAge,
	tlbAnimal.idfsAnimalGender, 
	tlbAnimal.strAnimalCode, 
	tlbAnimal.idfSpecies,
	tlbAnimal.strName,
	tlbAnimal.strColor,
	tlbSpecies.idfsSpeciesType,  
	tlbParty.idfMonitoringSession--,
--	Gender.[Name] AS strGender,
--	Species.[Name] AS strSpecies

FROM tlbAnimal
INNER JOIN tlbSpecies ON 
	tlbSpecies.idfSpecies=tlbAnimal.idfSpecies 
INNER JOIN tlbParty SpeciesParty ON
	SpeciesParty.idfParty = tlbSpecies.idfSpecies
	and SpeciesParty.introwstatus=0 
--INNER JOIN tlbHerd ON 
--	tlbHerd.idfHerd=tlbSpecies.idfHerd 
--INNER JOIN tlbParty HerdParty ON
--	HerdParty.idfParty = tlbHerd.idfHerd
--	and HerdParty.introwstatus=0 
INNER JOIN tlbParty ON
	tlbParty.idfParty = tlbAnimal.idfAnimal
	and tlbParty.idfsPartyType = 10072002 --Animal
--LEFT OUTER JOIN fnReference(@LangID,19000007/*rftAnimalGenderList*/) Gender ON
--	Gender.idfsReference=tlbAnimal.idfsAnimalGender
--LEFT OUTER JOIN fnReference(@LangID,19000086/*'rftSpeciesList'*/) Species ON
--	Species.idfsReference=tlbSpecies.idfsSpeciesType

WHERE	tlbParty.idfMonitoringSession=@idfMonitoringSession 
		and tlbParty.idfCase IS NULL
		and NOT @idfMonitoringSession IS NULL
		and tlbParty.intRowStatus = 0




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

