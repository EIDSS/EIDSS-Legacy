SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSite_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSite_SelectLookup]
GO

--##SUMMARY Selects lookup list of registerd sites for current country.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 13.12.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:
exec spSite_SelectLookup 'en'
*/

CREATE        PROCEDURE dbo.spSite_SelectLookup
	@LanguageID nvarchar(50) --##PARAM @LanguageID - language ID
AS
DECLARE @CountryID BIGINT
SELECT @CountryID = idfsCountry FROM tstSite
WHERE idfsSite = dbo.fnSiteID()

SELECT 
	idfsSite
	,idfsSiteType
	,ISNULL(dbo.fnInstitution.Abbreviation, strSiteName) as strSiteName
	,strServerName
	,strSiteID
	,ISNULL(dbo.fnReference.Name,dbo.fnReference.strDefault) AS strSiteType
	,dbo.fnInstitution.[Name] AS OfficeName
	,dbo.fnInstitution.Abbreviation AS OfficeAbbreviation
  FROM tstSite
INNER JOIN dbo.fnInstitution(@LanguageID) ON
	tstSite.idfOffice = dbo.fnInstitution.idfOffice
INNER JOIN dbo.fnReference(@LanguageID, 19000085/*Site Type*/) ON
	tstSite.idfsSiteType = dbo.fnReference.idfsReference
WHERE
	tstSite.intRowStatus = 0
	AND tstSite.idfsCountry = @CountryID 
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

