SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRegion_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRegion_SelectLookup]
GO



--exec spRegion_SelectLookup 'en'
--exec spRegion_SelectLookup 'en' , 780000000

CREATE          PROCEDURE dbo.spRegion_SelectLookup
	@LanguageID As nvarchar(50),
	@CountryID as bigint = NULL,
	@ID as bigint = NULL
AS
SELECT	
	idfsReference as idfsRegion, [Name] as strRegionName, gisRegion.strCode as strRegionCode, gisRegion.idfsCountry
FROM	
	dbo.fnGisReference(@LanguageID,19000003) --'rftRegion'
inner join 	
	gisRegion
on
	idfsReference = gisRegion.idfsRegion 
	
--inner join 
--	tstSite
--on 
--	tstSite.idfsCountry=gisRegion.idfsCountry-- and tstSite.idfsSite=dbo.fnSiteID()

WHERE	
	gisRegion.idfsCountry = isnull(@CountryID, gisRegion.idfsCountry)
	AND (@ID IS NULL OR @ID = gisRegion.idfsRegion)
	and gisRegion.idfsCountry in (select distinct idfscountry from tstSite)
ORDER BY strRegionName



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

