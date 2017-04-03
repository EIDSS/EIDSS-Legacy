SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGeoLocation_CreateCopy]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGeoLocation_CreateCopy]
GO
--##SUMMARY Copies values from one geolocation record to another one.
--##SUMMARY If record with @idfGeoLocationCopy doesn't exist, new record with this ID is created
--##SUMMARY If original location record doesn't exist the empty record with @idfGeoLocationCopy is created

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 07.11.2009

--##RETURNS 0 if record was successfully copied
--##RETURNS -1 if original record doesn't exist


/*
--Example of a call of procedure:
DECLARE @RC int
DECLARE @idfGeoLocation bigint
DECLARE @idfGeoLocationCopy bigint
SET @idfGeoLocation = 226950000000
SET @idfGeoLocationCopy = 1

EXECUTE @RC = spGeoLocation_CreateCopy
   @idfGeoLocation
  ,@idfGeoLocationCopy
*/


CREATE         PROCEDURE dbo.spGeoLocation_CreateCopy(
	   @idfGeoLocation as bigint --##PARAM idfGeoLocation - ID of original geolocation record
      ,@idfGeoLocationCopy as bigint --##PARAM idfGeoLocationCopy - ID of geolocation record to which orignal geolocation data will be copied
)
AS
IF NOT EXISTS(SELECT * FROM dbo.tlbGeoLocation WHERE idfGeoLocation = @idfGeoLocation)
BEGIN
	INSERT INTO tlbGeoLocation  
			(idfGeoLocation)
	VALUES	(@idfGeoLocationCopy)

	RETURN -1
END
IF EXISTS(SELECT * FROM dbo.tlbGeoLocation WHERE idfGeoLocation = @idfGeoLocationCopy)

UPDATE new 
   SET 
		idfsGroundType = old.idfsGroundType
		,idfsGeoLocationType = old.idfsGeoLocationType
		,idfsCountry = old.idfsCountry
		,idfsRegion = old.idfsRegion
		,idfsRayon = old.idfsRayon
		,idfsSettlement = old.idfsSettlement
		,strDescription = old.strDescription
		,dblDistance = old.dblDistance
		,dblLatitude = old.dblLatitude
		,dblLongitude = old.dblLongitude
		,dblAccuracy = old.dblAccuracy
		,dblAlignment = old.dblAlignment
		,strApartment = old.strApartment
		,strBuilding = old.strBuilding
		,strStreetName = old.strStreetName
		,strHouse = old.strHouse
		,strPostCode = old.strPostCode
		,idfsResidentType = old.idfsResidentType

FROM tlbGeoLocation old
INNER JOIN tlbGeoLocation new ON
	new.idfGeoLocation = @idfGeoLocationCopy
Where 
	old.idfGeoLocation = @idfGeoLocation

ELSE
	INSERT INTO tlbGeoLocation
			   (
				idfGeoLocation
				,idfsGroundType
				,idfsGeoLocationType
				,idfsCountry
				,idfsRegion
				,idfsRayon
				,idfsSettlement
				,strDescription
				,dblDistance
				,dblLatitude
				,dblLongitude
				,dblAccuracy
				,dblAlignment
				,strApartment
				,strBuilding
				,strStreetName
				,strHouse
				,strPostCode
				,idfsResidentType
			   )
		SELECT
				@idfGeoLocationCopy
				,idfsGroundType
				,idfsGeoLocationType
				,idfsCountry
				,idfsRegion
				,idfsRayon
				,idfsSettlement
				,strDescription
				,dblDistance
				,dblLatitude
				,dblLongitude
				,dblAccuracy
				,dblAlignment
				,strApartment
				,strBuilding
				,strStreetName
				,strHouse
				,strPostCode
				,idfsResidentType
		FROM tlbGeoLocation
		WHERE
			idfGeoLocation = @idfGeoLocation

RETURN 0



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

