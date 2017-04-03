SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAddress_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAddress_Post]
GO


CREATE         PROCEDURE dbo.spAddress_Post(
	@idfGeoLocation AS bigint,
	@idfsCountry AS  bigint,
	@idfsRegion AS  bigint,
	@idfsRayon AS  bigint,
	@idfsSettlement AS bigint,
	@idfsResidentType AS bigint,
	@strApartment AS NVARCHAR(200),
	@strBuilding AS NVARCHAR(200),
	@strStreetName AS NVARCHAR(200),
	@strHouse AS NVARCHAR(200),
	@strPostCode AS NVARCHAR(200)

)
AS

EXEC spStreet_Post @strStreetName, @idfsSettlement
EXEC spPostalCode_Post @strPostCode, @idfsSettlement

IF EXISTS(SELECT * FROM dbo.tlbGeoLocation WHERE idfGeoLocation = @idfGeoLocation)
	UPDATE tlbGeoLocation
	   SET 
			idfsGeoLocationType = 10036001 --'lctAddress'
			,idfsCountry = @idfsCountry
			,idfsRegion = @idfsRegion
			,idfsRayon = @idfsRayon
			,strApartment = @strApartment
			,strBuilding = @strBuilding
			,strStreetName = @strStreetName
			,strHouse = @strHouse
			,strPostCode = @strPostCode
			,idfsSettlement = @idfsSettlement
			,idfsResidentType = ISNULL(@idfsResidentType,38970000000) --'Private'
			
	 WHERE 
			idfGeoLocation = @idfGeoLocation
ELSE
	INSERT INTO tlbGeoLocation
			   (
				idfGeoLocation
				,idfsGeoLocationType
				,idfsCountry
				,idfsRegion
				,idfsRayon
				,strApartment
				,strBuilding
				,strStreetName
				,strHouse
				,strPostCode
				,idfsSettlement
				,idfsResidentType
			   )
		 VALUES
			   (
				@idfGeoLocation
				,10036001 --'lctAddress'
				,@idfsCountry
				,@idfsRegion
				,@idfsRayon
				,@strApartment
				,@strBuilding
				,@strStreetName
				,@strHouse
				,@strPostCode
				,@idfsSettlement
				,ISNULL(@idfsResidentType,38970000000) --'Private'
				)







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

