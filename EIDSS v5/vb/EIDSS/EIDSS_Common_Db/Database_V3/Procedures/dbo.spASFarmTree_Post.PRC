SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spASFarmTree_Post') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spASFarmTree_Post
GO






--##SUMMARY Posts farm tree data. These data includes info about farm and its child herds/species
--##SUMMARY loaded by VetFarmTree_SelectDetail procedure

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

DECLARE @Action int
DECLARE @idfMonitoringSession bigint
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


EXECUTE spASFarmTree_Post
   @Action
  ,@idfMonitoringSession
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



CREATE              Proc	spASFarmTree_Post
		@Action int,   --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
		@idfMonitoringSession bigint, --##PARAM @idfMonitoringSession - ID of monitoring session to which animal belongs
		@idfParty bigint, --##PARAM @idfParty - reference to farm, herd or species record (depending on @idfsPartyType)
		@idfsPartyType bigint, --##PARAM @idfsPartyType - type of posted record (can reference farm, herd or species)
		@strName nvarchar(200) OUTPUT, --##PARAM @strName - the the human readable name of the farm tree node. Displays farm code, herd code, of idfSpeciesType
		@idfParentParty bigint, --##PARAM @idfParentParty - ID of parent node
		@intTotalAnimalQty int, --##PARAM @intTotalAnimalQty - Total Animal Qty related with current node
		@strNote nvarchar(2000) --##PARAM @strNote
As

DECLARE @Party Table
(
	idfParty bigint
)

IF @idfsPartyType = 10072005 --'pptCaseFarm'
BEGIN
	IF @Action <>8 --if we insert or update farm node 
	BEGIN
		UPDATE tlbFarm
		SET 
		  intLivestockTotalAnimalQty = @intTotalAnimalQty
		  ,strNote = @strNote
		WHERE idfFarm = @idfParty
		UPDATE tlbParty
		SET
		  idfMonitoringSession = @idfMonitoringSession	
		WHERE idfParty = @idfParty
			
	END
--	IF @@ROWCOUNT=0
--		RAISERROR ('ivalid post operation for farm in farm tree', 16, 1)

END

IF @idfsPartyType = 10072003 --'pptCaseHerd'
BEGIN
	IF @Action = 16
	BEGIN
		UPDATE tlbHerd
		   SET  
			  idfFarm = @idfParentParty
			  ,strHerdCode = @strName
			  ,intTotalAnimalQty = @intTotalAnimalQty
			  ,strNote = @strNote
		 WHERE idfHerd=@idfParty
		UPDATE tlbParty
		SET
		  idfMonitoringSession = @idfMonitoringSession	
		WHERE idfParty = @idfParty
	END
	IF @Action = 8 --Delete
	BEGIN
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
				   ,idfMonitoringSession
				   ,idfsSite
					)
			 VALUES
				   (
					@idfParty
				   ,@idfsPartyType
				   ,NULL
				   ,@idfMonitoringSession
				   ,dbo.fnSiteID()
				   )

		--Herd itself
			INSERT INTO tlbHerd
					   (
						idfHerd
					   ,idfFarm
					   ,strHerdCode
					   ,intTotalAnimalQty
					   ,strNote)
				 VALUES
					   (
						@idfParty
					   ,@idfParentParty
					   ,@strName
					   ,@intTotalAnimalQty
					   ,@strNote)
	END
	
END


IF @idfsPartyType = 10072004 --'Species'
BEGIN
	IF @Action = 16
	BEGIN
		UPDATE tlbSpecies
		   SET 
			  idfsSpeciesType = CAST(@strName AS bigint)
			  ,idfHerd = @idfParentParty
			  ,intTotalAnimalQty = @intTotalAnimalQty
			  ,strNote = @strNote
		 WHERE idfSpecies = @idfParty
		UPDATE tlbParty
		SET
		  idfMonitoringSession = @idfMonitoringSession	
		WHERE idfParty = @idfParty
	END
	IF @Action = 8 --Delete
	BEGIN

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

	END


	IF @Action = 4
	BEGIN
		INSERT INTO tlbParty
			   (
				idfParty
			   ,idfsPartyType
			   ,idfRootParty
			   ,idfMonitoringSession
			   ,idfsSite
				)
		 VALUES
			   (
				@idfParty
			   ,@idfsPartyType
			   ,NULL
			   ,@idfMonitoringSession
			   ,dbo.fnSiteID()
			   )
		--Species itself
		INSERT INTO tlbSpecies
				   (idfSpecies
				   ,idfsSpeciesType
				   ,idfHerd
				   ,intTotalAnimalQty
				   ,strNote)
			 VALUES
				   (@idfParty
				   ,CAST(@strName AS bigint)
				   ,@idfParentParty
				   ,@intTotalAnimalQty
				   ,@strNote)	
	END
END










GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

