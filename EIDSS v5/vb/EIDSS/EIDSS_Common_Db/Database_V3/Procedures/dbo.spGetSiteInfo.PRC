
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spGetSiteInfo]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spGetSiteInfo]
GO 

--##SUMMARY This procedure returns site, country and organization information related with current site.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 05.11.2009

--##RETURNS Don't use


/*
--Example of a call of procedure:

exec dbo.[spGetSiteInfo] 'en'
*/


CREATE PROCEDURE [dbo].[spGetSiteInfo](
	@LanguageID NVARCHAR(10) --##PARAM LanguageID - language ID for localized strings
	)
AS
BEGIN

SELECT	dbo.fnGisReference.idfsReference as idfsCountry, 
		dbo.fnGisReference.[Name] as strCountryName,
		CAST(ISNULL(tlbGeoLocation.idfsRegion, -1) as bigint) as idfsRegion,
		tstSite.idfsSite,
		tstSite.strHASCsiteID,
		tstSite.strSiteName,
		tstSite.strSiteID,
		tstSite.idfsSiteType,
		dbo.fnReference.Name as strSiteTypeName,
		tstSite.idfOffice,
		fnInstitution.[Name] As strOrganizationName
		 
FROM	dbo.fnGisReference(@LanguageID,19000001) --'rftCountry'
inner join	gisCountry
on		dbo.fnGisReference.idfsReference = gisCountry.idfsCountry
inner join	tstSite 
on		tstSite.idfsCountry = gisCountry.idfsCountry
inner join dbo.fnReference(@LanguageID, 19000085) --rftSiteType
on		tstSite.idfsSiteType = fnReference.idfsReference
inner join dbo.fnInstitution(@LanguageID) 
on		tstSite.idfOffice = fnInstitution.idfOffice
Left OUTER JOIN tlbGeoLocation 
on		fnInstitution.idfLocation = tlbGeoLocation.idfGeoLocation
where	tstSite.idfsSite = dbo.fnSiteID()

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
