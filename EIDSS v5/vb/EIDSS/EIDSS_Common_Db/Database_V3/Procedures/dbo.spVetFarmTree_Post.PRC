SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spVetFarmTree_Post') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spVetFarmTree_Post
GO






--##SUMMARY Posts farm tree data. These data includes info about farm and its child herds/species
--##SUMMARY loaded by VetFarmTree_SelectDetail procedure

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

DECLARE @Action int
DECLARE @idfCase bigint
DECLARE @idfParty bigint
DECLARE @idfsPartyType bigint
DECLARE @strName nvarchar(200)
DECLARE @idfParentParty bigint
DECLARE @idfObservation bigint
DECLARE @intTotalAnimalQty int
DECLARE @intSickAnimalQty int
DECLARE @intDeadAnimalQty int
DECLARE @strAverageAge nvarchar(200)
DECLARE @datStartOfSignsDate datetime
DECLARE @strNote nvarchar(2000)


EXECUTE spVetFarmTree_Post
   @Action
  ,@idfCase
  ,@idfParty
  ,@idfsPartyType
  ,@strName OUTPUT
  ,@idfParentParty
  ,@idfObservation
  ,@intTotalAnimalQty
  ,@intSickAnimalQty
  ,@intDeadAnimalQty
  ,@strAverageAge
  ,@datStartOfSignsDate
  ,@strNote
*/



CREATE              Proc	spVetFarmTree_Post
		@Action int,   --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
		@idfCase bigint, --##PARAM @idfCase - ID of case to which animal belongs
		@idfParty bigint, --##PARAM @idfParty - reference to farm, herd or species record (depending on @idfsPartyType)
		@idfsPartyType bigint, --##PARAM @idfsPartyType - type of posted record (can reference farm, herd or species)
		@strName nvarchar(200) OUTPUT, --##PARAM @strName - the the human readable name of the farm tree node. Displays farm code, herd code, of idfSpeciesType
		@idfParentParty bigint, --##PARAM @idfParentParty - ID of parent node
		@idfObservation bigint, --##PARAM @idfObservation - ID of observation related with current node
		@idfsFormTemplate BIGINT, --##PARAM @idfsFormTemplate - reference to template that was used last time for control measures flexible form 
		@intTotalAnimalQty int, --##PARAM @intTotalAnimalQty - Total Animal Qty related with current node
		@intSickAnimalQty int, --##PARAM @intSickAnimalQty - Sick Animal Qty related with current node
		@intDeadAnimalQty int, --##PARAM @intDeadAnimalQty - Dead Animal Qty related with current node
		@strAverageAge nvarchar(200), --##PARAM @strAverageAge - Average age of animal related with current node
		@datStartOfSignsDate datetime, --##PARAM @datStartOfSignsDate - date when signs was started
		@strNote nvarchar(2000) --##PARAM @strNote
As

DECLARE @CaseType AS BIGINT 
DECLARE @Observation Table
(
	idfObservation bigint
)
DECLARE @Party Table
(
	idfParty bigint
)

Select 
	@CaseType = idfsCaseType
FROM tlbCase
Where 
	idfCase=@idfCase
	and introwstatus=0

SET @CaseType = ISNULL(@CaseType,0)

IF @idfsPartyType = 10072005 --'pptCaseFarm'
BEGIN
--	IF @Action = 16 --update
	EXEC spObservation_Post	@idfObservation, @idfsFormTemplate
	BEGIN
		UPDATE tlbFarm
		SET 
		  idfObservation = @idfObservation
		  ,intAvianSickAnimalQty = CASE WHEN @CaseType = 10012004/*avian*/ THEN @intSickAnimalQty ELSE intLivestockSickAnimalQty END
		  ,intLivestockSickAnimalQty = CASE WHEN @CaseType <> 10012004/*avian*/ THEN @intSickAnimalQty ELSE intLivestockSickAnimalQty END
		  ,intAvianTotalAnimalQty = CASE WHEN @CaseType = 10012004/*avian*/ THEN @intTotalAnimalQty ELSE intLivestockTotalAnimalQty END
		  ,intLivestockTotalAnimalQty = CASE WHEN @CaseType <> 10012004/*avian*/ THEN @intTotalAnimalQty ELSE intLivestockTotalAnimalQty END
		  ,intAvianDeadAnimalQty = CASE WHEN @CaseType = 10012004/*avian*/ THEN @intDeadAnimalQty ELSE intLivestockDeadAnimalQty END
		  ,intLivestockDeadAnimalQty = CASE WHEN @CaseType <> 10012004/*avian*/ THEN @intDeadAnimalQty ELSE intLivestockDeadAnimalQty END
		  ,strNote = @strNote
		WHERE idfFarm = @idfParty
		UPDATE tlbParty
		SET
		  idfCase = @idfCase	
		WHERE idfParty = @idfParty
			
	END
	IF @@ROWCOUNT=0
		RAISERROR ('ivalid post operation for farm in farm tree', 16, 1)

END

IF @idfsPartyType = 10072003 --'pptCaseHerd'
BEGIN
	IF @Action = 16
	BEGIN
		UPDATE tlbHerd
		   SET  
			  idfFarm = @idfParentParty
			  ,strHerdCode = @strName
			  ,intSickAnimalQty = @intSickAnimalQty
			  ,intTotalAnimalQty = @intTotalAnimalQty
			  ,intDeadAnimalQty = @intDeadAnimalQty
			  ,strNote = @strNote
		 WHERE idfHerd=@idfParty
		UPDATE tlbParty
		SET
		  idfCase = @idfCase	
		WHERE idfParty = @idfParty
	END
	IF @Action = 8 --Delete
	BEGIN
		--Animal observations
		insert into @Observation
		(
		idfObservation
		)
		SELECT
			tlbAnimal.idfObservation
		FROM tlbAnimal
		INNER JOIN tlbSpecies ON
			tlbAnimal.idfSpecies = tlbSpecies.idfSpecies
		WHERE 
			tlbSpecies.idfHerd = @idfParty

		--Species observations
		insert into @Observation
		(
		idfObservation
		)
		SELECT
			idfObservation
		FROM tlbSpecies
		WHERE 
			tlbSpecies.idfHerd = @idfParty
		--store herd party
		INSERT INTO @Party
			(idfParty)
		SELECT
			idfHerd
		FROM tlbHerd
		WHERE
			tlbHerd.idfHerd = @idfParty

		--store species party
		INSERT INTO @Party
			(idfParty)
		SELECT
			idfSpecies
		from	tlbSpecies
		inner join tlbHerd on
				tlbSpecies.idfHerd = tlbHerd.idfHerd
		WHERE
			tlbHerd.idfHerd = @idfParty

		--store animal party
		INSERT INTO @Party
			(idfParty)
		SELECT
			idfAnimal
		from	tlbAnimal
		inner join tlbSpecies on
				tlbSpecies.idfSpecies = tlbAnimal.idfSpecies
		inner join tlbHerd on
				tlbSpecies.idfHerd = tlbHerd.idfHerd
		WHERE
			tlbHerd.idfHerd = @idfParty


		DELETE tlbAnimal 
		FROM tlbAnimal
		INNER JOIN tlbSpecies ON
			tlbAnimal.idfSpecies = tlbSpecies.idfSpecies
		WHERE 
			tlbSpecies.idfHerd = @idfParty
			
		DELETE tlbSpecies 
		WHERE 
			tlbSpecies.idfHerd = @idfParty

		DELETE tlbHerd 
		WHERE 
			tlbHerd.idfHerd = @idfParty
		delete  tlbParty
		where	idfParty in (Select idfParty from @Party)

		DELETE dbo.tlbActivityParameters
		WHERE 	idfObservation in (Select idfObservation from @Observation)

		delete	tlbObservation
		where	idfObservation in (Select idfObservation from @Observation)



	END

	IF @Action = 4
	BEGIN
			IF ISNULL(@strName,N'') = N'' OR LEFT(ISNULL(@strName,N''),4)='(new'
			BEGIN
				EXEC dbo.spGetNextNumber 10057013, @strName OUTPUT , NULL --N'Herd'
			END

		--Party
			INSERT INTO tlbParty
				   (
					idfParty
				   ,idfsPartyType
				   ,idfRootParty
				   ,idfCase
				   ,idfsSite
					)
			 VALUES
				   (
					@idfParty
				   ,@idfsPartyType
				   ,NULL
				   ,@idfCase
				   ,dbo.fnSiteID()
				   )

		--Herd itself
			INSERT INTO tlbHerd
					   (
						idfHerd
					   ,idfFarm
					   ,strHerdCode
					   ,intSickAnimalQty
					   ,intTotalAnimalQty
					   ,intDeadAnimalQty
					   ,strNote)
				 VALUES
					   (
						@idfParty
					   ,@idfParentParty
					   ,@strName
					   ,@intSickAnimalQty
					   ,@intTotalAnimalQty
					   ,@intDeadAnimalQty
					   ,@strNote)
	END
	
END


IF @idfsPartyType = 10072004 --'Species'
BEGIN
	IF @Action = 16
	BEGIN
		EXEC spObservation_Post	@idfObservation, @idfsFormTemplate
		UPDATE tlbSpecies
		   SET 
			  idfsSpeciesType = CAST(@strName AS bigint)
			  ,idfHerd = @idfParentParty
			  ,idfObservation = @idfObservation
			  ,datStartOfSignsDate = @datStartOfSignsDate
			  ,strAverageAge = @strAverageAge
			  ,intSickAnimalQty = @intSickAnimalQty
			  ,intTotalAnimalQty = @intTotalAnimalQty
			  ,intDeadAnimalQty = @intDeadAnimalQty
			  ,strNote = @strNote
		 WHERE idfSpecies = @idfParty
		UPDATE tlbParty
		SET
		  idfCase = @idfCase	
		WHERE idfParty = @idfParty
	END
	IF @Action = 8 --Delete
	BEGIN
		--Animal observations
		insert into @Observation
		(
		idfObservation
		)
		SELECT
			idfObservation
		FROM tlbAnimal
		WHERE 
			idfSpecies = @idfParty

		--Species observations
		insert into @Observation
		(
		idfObservation
		)
		SELECT
			idfObservation
		FROM tlbSpecies
		WHERE 
			idfSpecies = @idfParty

		--store species party
		INSERT INTO @Party
			(idfParty)
		SELECT
			idfSpecies
		from	tlbSpecies
		WHERE
			idfSpecies = @idfParty

		--store animal party
		INSERT INTO @Party
			(idfParty)
		SELECT
			idfAnimal
		from	tlbAnimal
		inner join tlbSpecies on
				tlbSpecies.idfSpecies = tlbAnimal.idfSpecies
		WHERE
			tlbSpecies.idfSpecies = @idfParty


		DELETE tlbAnimal 
		FROM tlbAnimal
		WHERE 
			idfSpecies = @idfParty
			
		DELETE tlbSpecies 
		WHERE 
			idfSpecies = @idfParty

		delete  tlbParty
		where	idfParty in (Select idfParty from @Party)

		DELETE dbo.tlbActivityParameters
		WHERE 	idfObservation in (Select idfObservation from @Observation)

		delete	tlbObservation
		where	idfObservation in (Select idfObservation from @Observation)
	END


	IF @Action = 4
	BEGIN
		EXEC spObservation_Post	@idfObservation, @idfsFormTemplate

		INSERT INTO tlbParty
			   (
				idfParty
			   ,idfsPartyType
			   ,idfRootParty
			   ,idfCase
			   ,idfsSite
				)
		 VALUES
			   (
				@idfParty
			   ,@idfsPartyType
			   ,NULL
			   ,@idfCase
			   ,dbo.fnSiteID()
			   )
		--Species itself
		INSERT INTO tlbSpecies
				   (idfSpecies
				   ,idfsSpeciesType
				   ,idfHerd
				   ,idfObservation
				   ,datStartOfSignsDate
				   ,strAverageAge
				   ,intSickAnimalQty
				   ,intTotalAnimalQty
				   ,intDeadAnimalQty
				   ,strNote)
			 VALUES
				   (@idfParty
				   ,CAST(@strName AS bigint)
				   ,@idfParentParty
				   ,@idfObservation
				   ,@datStartOfSignsDate
				   ,@strAverageAge
				   ,@intSickAnimalQty
				   ,@intTotalAnimalQty
				   ,@intDeadAnimalQty
				   ,@strNote)	
	END
END










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

