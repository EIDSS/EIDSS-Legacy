SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAddress_SelectDetailFull]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAddress_SelectDetailFull]
GO






CREATE         PROCEDURE dbo.spAddress_SelectDetailFull(
	@idfAddress AS bigint,
	@LanguageID As nvarchar(50)
)
AS
-- 0- Address
SELECT  
	idfGeoLocation, 
	strApartment, 
	strBuilding, 
	strHouse, 
	strPostCode, 
	strStreetName, 
	tlbGeoLocation.idfsCountry,
	idfsRegion,
	idfsRayon, 
	idfsSettlement,
	idfsResidentType,
	Country.[Name] as strCountryName,
	Region.[Name] as strRegionName,
	Rayon.[Name] as strRayonName,
	Settlement.[Name] as strSettlementName
FROM
	tlbGeoLocation
	left outer join	dbo.fnGisReference(@LanguageID,19000001) Country
		on	Country.idfsReference = tlbGeoLocation.idfsCountry
	left outer join	dbo.fnGisReference(@LanguageID,19000003) Region
		on	Region.idfsReference = tlbGeoLocation.idfsRegion
	left outer join	dbo.fnGisReference(@LanguageID,19000002) Rayon
		on	Rayon.idfsReference = tlbGeoLocation.idfsRayon
	left outer join	dbo.fnGisReference(@LanguageID,19000004) Settlement
		on	Settlement.idfsReference = tlbGeoLocation.idfsSettlement
WHERE
	idfGeoLocation = @idfAddress
	and tlbGeoLocation.intRowStatus = 0



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

