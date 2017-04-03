GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRepHumFormN1Location]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRepHumFormN1Location]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY This procedure returns geo information related with current site.

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 02.02.2011

--##RETURNS Don't use  

/*
--Example of a call of procedure:

exec spRepHumFormN1Location 'ru'


*/ 
 
CREATE PROCEDURE [dbo].[spRepHumFormN1Location]
	@LangId varchar(36)
AS
BEGIN


 	select		tLoc.idfsCountry,
				tLoc.idfsRegion, 
				tLoc.idfsRayon, 
				tLoc.idfsSettlement, 
				rfCountry.[Name]	as strCountry,
				rfRegion.[Name]		as strRegion,
				rfRayon.[Name]		as strRayon,
				rfSettlement.[Name]	as strSettlement
	from 		tstSite					as tSite
	 left join	dbo.fnInstitution(@LangId) as	fnInst
			on	tSite.idfOffice = fnInst.idfOffice
	 left join	dbo.tlbGeoLocation			as tLoc
			on	fnInst.idfLocation = tLoc.idfGeoLocation
 	 left join	fnGisReference(@LangID, 19000001 /*'rftCountry'*/)as  rfCountry 
			on	rfCountry.idfsReference = tLoc.idfsCountry
	 left join	fnGisReference(@LangID, 19000003 /*'rftRegion'*/) as  rfRegion 
			on	rfRegion.idfsReference = tLoc.idfsRegion
	 left join	fnGisReference(@LangID, 19000002 /*'rftRayon'*/)  as rfRayon 
			on	rfRayon.idfsReference = tLoc.idfsRayon
	 left join	fnGisReference(@LangID, 19000004 /*'rftSettlement'*/) as rfSettlement
			on	rfSettlement.idfsReference = tLoc.idfsSettlement
	where	tSite.idfsSite = dbo.fnSiteID()
END
GO
