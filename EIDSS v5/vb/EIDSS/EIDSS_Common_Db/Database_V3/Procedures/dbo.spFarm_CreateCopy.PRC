SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFarm_CreateCopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFarm_CreateCopy]
GO





--##SUMMARY Creates farm object copy.
--##SUMMARY This procedure is called in the case when we create copy of non root farm
--##SUMMARY 1. We select root farm in the farms list (as source farm) and should create this farm copy related with case or monitoring session
--##SUMMARY    a. If target farm exists we copy farm info itself and also copy address/location/farm owner information to the objects correspodent defined in target farm
--##SUMMARY    b. If there is no target farm exist, we create new farm, address, location, owner objects as copies of source objects but each with its own ID.
--##SUMMARY    Source farm became Root form for the target farm in this case. Source farm Root owner bacame target farm root owner.
--##SUMMARY 2. We create new farm on the Vet Case or on Monitoring session form. In this case we should create root copy of the created farm.



--##REMARKS Author: Zurin M.
--##REMARKS Create date: 02.10.2010

--##RETURNS Doesn't use


/*
--Example of procedure call:
DECLARE @idfSourceFarm bigint
DECLARE @idfTargetFarm bigint
DECLARE @idfCase bigint
DECLARE @idfMonitoringSession bigint


EXECUTE @spFarm_CreateCopy
   @idfSourceFarm
  ,@idfTargetFarm OUTPUT
  ,@idfCase
  ,@idfMonitoringSession
*/







CREATE             PROCEDURE dbo.spFarm_CreateCopy
	@idfSourceFarm bigint,--##PARAM @idfFarm - farm ID
	@idfTargetFarm bigint OUTPUT,--##PARAM @idfRootFarm - root farm ID, during posting data for root farm must be NULL
	@idfCase bigint,--##PARAM @idfCase - case to which farm is attached, during posting data for root farm must be NULL
	@idfMonitoringSession bigint--##PARAM @idfMonitoringSession - monitoring to which farm is attached, during posting data for root farm must be NULL

AS

--Select root farm data
DECLARE @idfSourceFarmLocation bigint
DECLARE @idfSourceFarmAddress bigint
DECLARE	@idfRootOwner bigint
DECLARE	@idfRootFarm bigint
DECLARE	@strOwnerLastName NVARCHAR(200)
DECLARE	@strOwnerFirstName NVARCHAR(200)
DECLARE	@strOwnerMiddleName NVARCHAR(200)
DECLARE @strContactPhone nvarchar(200)
DECLARE @strInternationalName nvarchar(200)
DECLARE @strNationalName nvarchar(200)
DECLARE @strFarmCode nvarchar(200)
DECLARE @strFax nvarchar(200)
DECLARE @strEmail nvarchar(200)
DECLARE @blnIsLivestock bit
DECLARE @blnIsAvian bit
DECLARE @idfsAvianFarmType bigint
DECLARE @idfsAvianProductionType bigint
DECLARE @idfsFarmCategory bigint
DECLARE @idfsOwnershipStructure bigint
DECLARE @idfsMovementPattern bigint
DECLARE @idfsIntendedUse bigint
DECLARE @idfsGrazingPattern bigint
DECLARE @idfsLivestockProductionType bigint
DECLARE @intLivestockSickAnimalQty int
DECLARE @intLivestockTotalAnimalQty int
DECLARE @intLivestockDeadAnimalQty int
DECLARE @intAvianSickAnimalQty int
DECLARE @intAvianTotalAnimalQty int
DECLARE @intAvianDeadAnimalQty int
DECLARE @strNote nvarchar(2000)
DECLARE @intBuidings int
DECLARE @intBirdsPerBuilding int

Select  
	@idfSourceFarmLocation = idfFarmLocation
	,@idfSourceFarmAddress = idfFarmAddress
	,@idfRootOwner = ownerParty.idfRootParty
	,@idfRootFarm = tlbParty.idfRootParty
	,@strOwnerLastName = tlbHuman.strLastName
	,@strOwnerFirstName = tlbHuman.strFirstName
	,@strOwnerMiddleName = tlbHuman.strSecondName  
      ,@idfsAvianFarmType = idfsAvianFarmType
      ,@idfsAvianProductionType = idfsAvianProductionType
      ,@idfsFarmCategory = idfsFarmCategory
      ,@idfsOwnershipStructure = idfsOwnershipStructure
      ,@idfsMovementPattern = @idfsMovementPattern
      ,@idfsIntendedUse = idfsIntendedUse
      ,@idfsGrazingPattern = idfsGrazingPattern
      ,@idfsLivestockProductionType = idfsLivestockProductionType
      ,@strInternationalName = strInternationalName
      ,@strNationalName = strNationalName
      ,@strFarmCode = strFarmCode
      ,@strFax = strFax
      ,@strEmail = strEmail
      ,@strContactPhone = strContactPhone
      ,@intLivestockSickAnimalQty = intLivestockSickAnimalQty
      ,@intLivestockTotalAnimalQty = intLivestockTotalAnimalQty
      ,@intLivestockDeadAnimalQty = intLivestockDeadAnimalQty
      ,@intAvianSickAnimalQty = intAvianSickAnimalQty
      ,@intAvianTotalAnimalQty = intAvianTotalAnimalQty
      ,@intAvianDeadAnimalQty = intAvianDeadAnimalQty
      ,@strNote = strNote
      ,@blnIsLivestock = blnIsLivestock
      ,@blnIsAvian = blnIsAvian
      ,@intBuidings = intBuidings
      ,@intBirdsPerBuilding = intBirdsPerBuilding
FROM tlbFarm
INNER JOIN tlbParty ON
	tlbFarm.idfFarm = tlbParty.idfParty 
LEFT OUTER JOIN tlbHuman 
	on tlbHuman.idfHuman=tlbFarm.idfHuman 
LEFT OUTER JOIN tlbParty ownerParty 
	on ownerParty.idfParty=tlbHuman.idfHuman 
WHERE 
	idfFarm = @idfSourceFarm
IF @@ROWCOUNT=0 --no source farm is found, do nothing
	RETURN -1

DECLARE @idfTargetFarmLocation bigint
DECLARE @idfTargetFarmAddress bigint
DECLARE @idfTargetOwner bigint
	

IF  ISNULL(@idfTargetFarm,-1)<0 
BEGIN
	EXEC dbo.spsysGetNewID @idfTargetFarm OUTPUT
END

--Check if target farm exists
DECLARE @TargetAction int
SELECT 
	 @idfTargetFarmLocation = idfFarmLocation 
	,@idfTargetFarmAddress = idfFarmAddress
	,@idfTargetOwner = idfHuman
FROM tlbFarm 
WHERE idfFarm = @idfTargetFarm


	
IF @@ROWCOUNT>0
	SET @TargetAction = 16
ELSE
	SET @TargetAction = 4


IF @idfTargetFarmLocation IS NULL
	EXEC dbo.spsysGetNewID @idfTargetFarmLocation OUTPUT
IF @idfTargetFarmAddress IS NULL
	EXEC dbo.spsysGetNewID @idfTargetFarmAddress OUTPUT
IF @idfTargetOwner IS NULL
	EXEC dbo.spsysGetNewID @idfTargetOwner OUTPUT
--copy of farm locations
EXEC spGeoLocation_CreateCopy	@idfSourceFarmLocation, @idfTargetFarmLocation
EXEC spGeoLocation_CreateCopy	@idfSourceFarmAddress, @idfTargetFarmAddress


EXECUTE spFarmPanel_Post
   @TargetAction -- @Action
  ,@idfTargetFarm
  ,@idfRootFarm OUTPUT
  ,@idfCase
  ,@idfMonitoringSession
  ,@strContactPhone
  ,@strInternationalName
  ,@strNationalName
  ,@strFarmCode OUTPUT
  ,@strFax
  ,@strEmail
  ,@idfTargetFarmLocation
  ,@idfTargetFarmAddress
  ,@blnIsLivestock
  ,@blnIsAvian
  ,@idfTargetOwner
  ,@idfRootOwner OUTPUT
  ,@strOwnerLastName
  ,@strOwnerFirstName
  ,@strOwnerMiddleName


IF @blnIsAvian = 1
BEGIN 
	EXECUTE spAvianFarmDetail_Post
	   @idfTargetFarm
	  ,@intBuidings
	  ,@intBirdsPerBuilding

END 
IF @blnIsLivestock = 1
BEGIN 

EXECUTE spLivestockFarmProduction_Post
   @idfTargetFarm
  ,@idfRootFarm
  ,@idfsOwnershipStructure
  ,@idfsLivestockProductionType
  ,@idfsGrazingPattern
  ,@idfsMovementPattern
END 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

