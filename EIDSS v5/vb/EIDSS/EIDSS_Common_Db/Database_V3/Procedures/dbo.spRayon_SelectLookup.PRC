SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRayon_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRayon_SelectLookup]
GO


--exec spRayon_SelectLookup 'en', null, null
--exec spRayon_SelectLookup 'en' , 37020000000


CREATE       PROCEDURE dbo.spRayon_SelectLookup
	@LanguageID As nvarchar(50),
	@RegionID as bigint = NULL ,
	@ID as bigint = NULL

AS
SELECT	idfsReference as idfsRayon, [Name] as strRayonName, gisRayon.idfsRegion, gisRayon.idfsCountry
FROM	dbo.fnGisReference(@LanguageID,19000002)--'rftRayon' 
join 	gisRayon 
on	idfsReference = gisRayon.idfsRayon 
join 	gisCountry
on	gisRayon.idfsCountry = gisCountry.idfsCountry
--inner join tstSite
--on tstSite.idfsCountry=gisRayon.idfsCountry and tstSite.idfsSite=dbo.fnSiteID()


WHERE	
	gisRayon.idfsRegion = isnull(@RegionID, gisRayon.idfsRegion)
	AND (@ID IS NULL OR @ID = idfsRayon)
	and gisRayon.idfsCountry in (select distinct idfscountry from tstSite)
ORDER BY strRayonName



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

