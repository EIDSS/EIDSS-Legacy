SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASSession_AddAnimalToCase]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASSession_AddAnimalToCase]
GO


 

--##SUMMARY Creates case for specified farm in monitoring session
--##SUMMARY During case creation it 
--##SUMMARY 1. Creates case itslef
--##SUMMARY 2. Links farm (including farm structure tree) to the case
--##SUMMARY 3. Links Animals/samples/tests with positive result to the case
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 02.08.2010

--##RETURNS 0 - if case is created successfully
--##RETURNS 1 - source farm doesn't exists
--##RETURNS 2 - case is already created for this farm and monitoring session
/*
--Example of a call of procedure:
DECLARE @idfFarm bigint

EXECUTE spASSession_AddAnimalToCase 
	@idfFarm
	,@idfCase OUTPUT
Print @idfCase
*/

CREATE            Proc	spASSession_AddAnimalToCase
		 @idfCase bigint 
		,@idfAnimal bigint
		,@idfsFormTemplate bigint
As

DECLARE @idfsAnimalAge bigint
DECLARE @idfsAnimalGender bigint
DECLARE @strAnimalCode nvarchar(200)
DECLARE @strDescription nvarchar(200)
DECLARE @idfsAnimalCondition bigint
DECLARE @strHerdCode nvarchar(200)
DECLARE @idfsSpeciesType bigint
DECLARE @idfTargetSpecies bigint
DECLARE @idfObservation bigint
DECLARE @idfTargetAnimal bigint
DECLARE @idfTargetHerd bigint


SELECT 
   @idfsAnimalAge = idfsAnimalAge
  ,@idfsAnimalGender = idfsAnimalGender
  ,@strAnimalCode = strAnimalCode
  ,@strDescription = strDescription
  ,@idfsAnimalCondition = idfsAnimalCondition
  ,@strHerdCode = strHerdCode
  ,@idfsSpeciesType = tlbSpecies.idfsSpeciesType
FROM tlbAnimal
	Inner Join tlbParty animalParty on 
		animalParty.idfParty = tlbAnimal.idfAnimal and animalParty.intRowStatus=0
	INNER JOIN tlbSpecies ON 
		tlbSpecies.idfSpecies = tlbAnimal.idfSpecies
	inner join tlbParty speciesParty on 
		speciesParty.idfParty = tlbSpecies.idfSpecies and speciesParty.intRowStatus=0
	Inner join tlbHerd on 
		tlbSpecies.idfHerd = tlbHerd.idfHerd 
	inner join tlbParty herdParty on 
		herdParty.idfParty = tlbHerd.idfHerd and herdParty.intRowStatus=0
	WHERE tlbAnimal.idfAnimal = @idfAnimal

SELECT 
	@idfTargetSpecies = idfSpecies 
	,@idfTargetHerd = tlbHerd.idfHerd 
FROM tlbSpecies
	Inner join tlbHerd on 
		tlbSpecies.idfHerd = tlbHerd.idfHerd 
	inner join tlbParty speciesParty on 
		speciesParty.idfParty = tlbSpecies.idfSpecies and speciesParty.intRowStatus=0
WHERE
	speciesParty.idfCase = @idfCase
	and tlbSpecies.idfsSpeciesType = @idfsSpeciesType
	and tlbHerd.strHerdCode = @strHerdCode

EXEC spsysGetNewID @idfObservation OUTPUT
EXEC spsysGetNewID @idfTargetAnimal OUTPUT

EXECUTE spVetCaseAnimals_Post
   4 --@Action
  ,@idfTargetAnimal
  ,@idfTargetHerd
  ,@idfsAnimalAge
  ,@idfsAnimalGender
  ,@strAnimalCode  OUTPUT
  ,@strDescription
  ,@idfsAnimalCondition
  ,@idfTargetSpecies
  ,@idfObservation
  ,@idfsFormTemplate
  ,@idfCase

return 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

