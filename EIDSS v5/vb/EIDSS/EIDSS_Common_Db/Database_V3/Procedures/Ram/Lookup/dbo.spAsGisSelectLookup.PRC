GO
/****** Object:  StoredProcedure [dbo].[spAsGisSelectLookup]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsGisSelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsGisSelectLookup]

/****** Object:  StoredProcedure [dbo].[spAsGisSelectLookup]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY select layouts for analytical module

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 12.01.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

exec spAsGisSelectLookup 'en'

*/ 
 
CREATE PROCEDURE [dbo].[spAsGisSelectLookup]
	@LanguageID	as nvarchar(50)
AS
BEGIN
	select		fnCountry.idfsReference,
				fnCountry.idfsGISReferenceType,
				fnCountry.ExtendedName,
				null as dblLatitude,
				null as dblLongitude,
				fnCountry.idfsReference as idfsCountry				
	from		fnGisExtendedReference(@LanguageID,19000001) as fnCountry
union			
	select		fnRegion.idfsReference,
				fnRegion.idfsGISReferenceType,
				fnRegion.ExtendedName,
				null as dblLatitude,
				null as dblLongitude,
				gisCountry.idfsCountry				
	from		fnGisExtendedReference(@LanguageID,19000003) as fnRegion
	inner join	gisRegion 
	on			gisRegion.idfsRegion = fnRegion.idfsReference 
	inner join 	gisCountry
	on			gisRegion.idfsCountry = gisCountry.idfsCountry
	inner join	tstSite
	on			tstSite.idfsCountry = gisRegion.idfsCountry 
	and			tstSite.idfsSite=dbo.fnSiteID()
union		
	select		fnRayon.idfsReference,
				fnRayon.idfsGISReferenceType,
				fnRayon.ExtendedName	,
				null as dblLatitude,
				null as dblLongitude,
				gisCountry.idfsCountry				
	from		fnGisExtendedReference(@LanguageID,19000002) as fnRayon
	inner join	gisRayon 
	on			gisRayon.idfsRayon = fnRayon.idfsReference 
	inner join 	gisCountry
	on			gisRayon.idfsCountry = gisCountry.idfsCountry
	inner join	tstSite
	on			tstSite.idfsCountry = gisRayon.idfsCountry 
	and			tstSite.idfsSite=dbo.fnSiteID()
union	
	select		fnSettlement.idfsReference,
				fnSettlement.idfsGISReferenceType,
				fnSettlement.ExtendedName,
				gisSettlement.dblLatitude,
				gisSettlement.dblLongitude,
				gisCountry.idfsCountry				
	from		fnGisExtendedReference(@LanguageID,19000004) as fnSettlement
	inner join	gisSettlement 
	on			gisSettlement.idfsSettlement = fnSettlement.idfsReference 
	inner join 	gisCountry
	on			gisSettlement.idfsCountry = gisCountry.idfsCountry
	inner join	tstSite
	on			tstSite.idfsCountry = gisSettlement.idfsCountry 
	and			tstSite.idfsSite=dbo.fnSiteID()
END
GO
