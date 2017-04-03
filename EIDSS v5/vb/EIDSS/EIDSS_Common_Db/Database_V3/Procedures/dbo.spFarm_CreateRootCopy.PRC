SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFarm_CreateRootCopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFarm_CreateRootCopy]
GO





--##SUMMARY Creates farm object copy.
--##SUMMARY There are 2 main scenario of this procedure using:
--##SUMMARY 1. We select root farm in the farms list (as source farm) and should create this farm copy related with case or monitoring session
--##SUMMARY    a. If target farm exists we copy farm info itself and also copy address/location/farm owner information to the objects correspodent defined in target farm
--##SUMMARY    b. If there is no target farm exist, we create new farm, address, location, owner objects as copies of source objects but each with its own ID.
--##SUMMARY    Source farm became Root form for the target farm in this case. Source farm Root owner bacame target farm root owner.
--##SUMMARY 2. We create new farm on the Vet Case or on Monitoring session form. In this case we should create root copy of the created farm.



--##REMARKS Author: Zurin M.
--##REMARKS Create date: 29.06.2010

--##RETURNS Doesn't use


/*
--Example of procedure call:

*/







CREATE             PROCEDURE dbo.spFarm_CreateRootCopy
	@idfRootFarm bigint,--##PARAM @idfFarm - farm ID
	@idfTargetFarm bigint OUTPUT,--##PARAM @idfRootFarm - root farm ID, during posting data for root farm must be NULL
	@idfCase bigint,--##PARAM @idfCase - case to which farm is attached, during posting data for root farm must be NULL
	@idfMonitoringSession bigint--##PARAM @idfMonitoringSession - monitoring to which farm is attached, during posting data for root farm must be NULL

AS
--Print '@idfFarm='+CAST(ISNULL(@idfTargetFarm,'NULL') AS VARCHAR)+'@idfTargetFarm='+CAST(ISNULL(@idfRootFarm,'NULL') AS VARCHAR)+'@idfMonitoringSession='+CAST(ISNULL(@idfMonitoringSession,'NULL') AS VARCHAR)

--Select root farm data
DECLARE @idfRootFarmLocation bigint
DECLARE @idfRootFarmAddress bigint
DECLARE	@idfRootOwner bigint
DECLARE	@strOwnerLastName NVARCHAR(200)
DECLARE	@strOwnerFirstName NVARCHAR(200)
DECLARE	@strOwnerMiddleName NVARCHAR(200)

Select  
	@idfRootFarmLocation = idfFarmLocation,
	@idfRootFarmAddress = idfFarmAddress,
	@idfRootOwner = ownerParty.idfRootParty,
	@strOwnerLastName = tlbHuman.strLastName,
	@strOwnerFirstName = tlbHuman.strFirstName,
	@strOwnerMiddleName = tlbHuman.strSecondName  
FROM tlbFarm
INNER JOIN tlbParty ON
	tlbFarm.idfFarm = tlbParty.idfParty 
LEFT OUTER JOIN tlbHuman 
	on tlbHuman.idfHuman=tlbFarm.idfHuman 
LEFT OUTER JOIN tlbParty ownerParty 
	on ownerParty.idfParty=tlbHuman.idfHuman 
WHERE 
	idfFarm = @idfRootFarm
IF @@ROWCOUNT=0 --no root farm is found, do nothing
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

--copy root farm locations
EXEC spGeoLocation_CreateCopy	@idfRootFarmLocation, @idfTargetFarmLocation
EXEC spGeoLocation_CreateCopy	@idfRootFarmAddress, @idfTargetFarmAddress

EXEC spFarmPanel_PostOwnerData	@idfTargetOwner,
								@idfRootOwner OUTPUT,
								@idfCase,
								@idfMonitoringSession,
								@strOwnerLastName,
								@strOwnerFirstName,
								@strOwnerMiddleName

IF @TargetAction=16 --Modified
UPDATE [tlbFarm] 
   SET 
       tlbFarm.idfsAvianFarmType = rootFarm.idfsAvianFarmType
      ,tlbFarm.idfsAvianProductionType = rootFarm.idfsAvianProductionType
      ,tlbFarm.idfsFarmCategory = rootFarm.idfsFarmCategory
      ,tlbFarm.idfsOwnershipStructure = rootFarm.idfsOwnershipStructure
      ,tlbFarm.idfsMovementPattern = rootFarm.idfsMovementPattern
      ,tlbFarm.idfsIntendedUse = rootFarm.idfsIntendedUse
      ,tlbFarm.idfsGrazingPattern = rootFarm.idfsGrazingPattern
      ,tlbFarm.idfsLivestockProductionType = rootFarm.idfsLivestockProductionType
      ,tlbFarm.idfHuman = @idfTargetOwner
      ,tlbFarm.idfFarmAddress = @idfTargetFarmAddress
      ,tlbFarm.idfFarmLocation = @idfTargetFarmLocation
      ,tlbFarm.idfObservation = rootFarm.idfObservation
      ,tlbFarm.strInternationalName = rootFarm.strInternationalName
      ,tlbFarm.strNationalName = rootFarm.strNationalName
      ,tlbFarm.strFarmCode = rootFarm.strFarmCode
      ,tlbFarm.strFax = rootFarm.strFax
      ,tlbFarm.strEmail = rootFarm.strEmail
      ,tlbFarm.strContactPhone = rootFarm.strContactPhone
      ,tlbFarm.strOwnerFirstName = rootFarm.strOwnerFirstName
      ,tlbFarm.strOwnerMiddleName = rootFarm.strOwnerMiddleName
      ,tlbFarm.strOwnerLastName = rootFarm.strOwnerLastName
      ,tlbFarm.intLivestockSickAnimalQty = rootFarm.intLivestockSickAnimalQty
      ,tlbFarm.intLivestockTotalAnimalQty = rootFarm.intLivestockTotalAnimalQty
      ,tlbFarm.intLivestockDeadAnimalQty = rootFarm.intLivestockDeadAnimalQty
      ,tlbFarm.intAvianSickAnimalQty = rootFarm.intAvianSickAnimalQty
      ,tlbFarm.intAvianTotalAnimalQty = rootFarm.intAvianTotalAnimalQty
      ,tlbFarm.intAvianDeadAnimalQty = rootFarm.intAvianDeadAnimalQty
      ,tlbFarm.strNote = rootFarm.strNote
      ,tlbFarm.blnIsLivestock = rootFarm.blnIsLivestock
      ,tlbFarm.blnIsAvian = rootFarm.blnIsAvian
      ,tlbFarm.intBuidings = rootFarm.intBuidings
      ,tlbFarm.intBirdsPerBuilding = rootFarm.intBirdsPerBuilding
	FROM tlbFarm AS rootFarm
		INNER JOIN tlbFarm ON
			rootFarm.idfFarm = @idfRootFarm
	WHERE 
		tlbFarm.idfFarm=@idfTargetFarm
IF @TargetAction=4 --Added
BEGIN
	
	Print 'inserting party idfParty = ' + CAST(@idfTargetFarm as VARCHAR)+', idfRootParty = ' +  ISNULL(CAST(@idfRootFarm as VARCHAR),'NULL')

	INSERT INTO tlbParty(
		idfParty
		,idfsPartyType
		,idfsSite
		,idfRootParty
		,idfCase
		,idfMonitoringSession
	   )
	 VALUES(
			@idfTargetFarm
			,10072005 --Farm,
			,dbo.fnSiteID()
			,@idfRootFarm
			,@idfCase
			,@idfMonitoringSession
			)

INSERT INTO tlbFarm (
		idfFarm
       ,idfsAvianFarmType
       ,idfsAvianProductionType
       ,idfsFarmCategory
       ,idfsOwnershipStructure
       ,idfsMovementPattern
       ,idfsIntendedUse
       ,idfsGrazingPattern
       ,idfsLivestockProductionType
       ,idfHuman
       ,idfFarmAddress
       ,idfFarmLocation
       ,idfObservation
       ,strInternationalName
       ,strNationalName
       ,strFarmCode
       ,strFax
       ,strEmail
       ,strContactPhone
       ,strOwnerFirstName
       ,strOwnerMiddleName
       ,strOwnerLastName
	  ,intLivestockSickAnimalQty
	  ,intLivestockTotalAnimalQty
	  ,intLivestockDeadAnimalQty
	  ,intAvianSickAnimalQty
	  ,intAvianTotalAnimalQty
	  ,intAvianDeadAnimalQty
       ,strNote
       ,blnIsLivestock
       ,blnIsAvian
       ,intBuidings
       ,intBirdsPerBuilding
	)

SELECT @idfTargetFarm
      ,idfsAvianFarmType
      ,idfsAvianProductionType
      ,idfsFarmCategory
      ,idfsOwnershipStructure
      ,idfsMovementPattern
      ,idfsIntendedUse
      ,idfsGrazingPattern
      ,idfsLivestockProductionType
      ,@idfTargetOwner--idfHuman
      ,@idfTargetFarmAddress
      ,@idfTargetFarmLocation
      ,idfObservation
      ,strInternationalName
      ,strNationalName
      ,strFarmCode
      ,strFax
      ,strEmail
      ,strContactPhone
      ,strOwnerFirstName
      ,strOwnerMiddleName
      ,strOwnerLastName
      ,intLivestockSickAnimalQty
      ,intLivestockTotalAnimalQty
      ,intLivestockDeadAnimalQty
      ,intAvianSickAnimalQty
      ,intAvianTotalAnimalQty
      ,intAvianDeadAnimalQty
      ,strNote
      ,blnIsLivestock
      ,blnIsAvian
      ,intBuidings
      ,intBirdsPerBuilding
  FROM tlbFarm
WHERE 
	idfFarm = @idfRootFarm

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

