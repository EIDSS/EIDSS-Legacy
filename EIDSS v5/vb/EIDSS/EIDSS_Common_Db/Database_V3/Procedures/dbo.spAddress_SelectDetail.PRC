SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAddress_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAddress_SelectDetail]
GO






CREATE         PROCEDURE dbo.spAddress_SelectDetail(
	@idfAddress AS bigint
)
AS
-- 0- Address
SELECT  idfGeoLocation, 
	strApartment, 
	strBuilding, 
	strHouse, 
	strPostCode, 
	strStreetName, 
	idfsCountry,
	idfsRegion,
	idfsRayon, 
	idfsSettlement,
	idfsResidentType 
FROM
	tlbGeoLocation
WHERE
	idfGeoLocation = @idfAddress
	and intRowStatus = 0








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

