SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vwAreaInfo]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vwAreaInfo]
GO

--##SUMMARY Selects the translated list of areas names used in statistic forms
--##SUMMARY It is used in fn_Statistic_SelectList for displaying area name related with statistic record

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 27.04.2010

--##RETURNS Doesn't use

/*
--Example of view call:

SELECT * FROM  dbo.vwAreaInfo
*/


CREATE view dbo.vwAreaInfo
as

--Country names
select 
	gisCountry.idfsCountry as idfsArea, 
	IsNull(scountry.strTextString, country.strDefault) as strAreaName, 
	10089001 as AreaType, 
	scountry.idfsLanguage  
from   gisCountry  
inner join gisBaseReference country ON
	gisCountry.idfsCountry = country.idfsGISBaseReference
	and country.intRowStatus = 0
left join gisStringNameTranslation scountry
on			country.idfsGISBaseReference = scountry.idfsGISBaseReference
WHERE 
	gisCountry.intRowStatus = 0
--Region names
union
select 
	gisRegion.idfsRegion as idfsArea, 
	IsNull(sregion.strTextString, region.strDefault) as strAreaName, 
	10089003 as AreaType, 
	sregion.idfsLanguage  
from   gisRegion  
inner join gisBaseReference region ON
	gisRegion.idfsRegion = region.idfsGISBaseReference
	and region.intRowStatus = 0
left join gisStringNameTranslation sregion
on			region.idfsGISBaseReference = sregion.idfsGISBaseReference
WHERE 
	gisRegion.intRowStatus = 0
--Rayon names in format [Region], [Rayon]
union
select 
	gisRayon.idfsRayon as idfsArea, 
	IsNull(sregion.strTextString, region.strDefault)+ ', ' +IsNull(srayon.strTextString, rayon.strDefault) as strAreaName, 
	10089002 as AreaType, 
	srayon.idfsLanguage  
from   gisRayon  
inner join gisBaseReference rayon ON
	gisRayon.idfsRayon = rayon.idfsGISBaseReference
	and rayon.intRowStatus = 0
left join gisStringNameTranslation srayon
on			rayon.idfsGISBaseReference = srayon.idfsGISBaseReference
inner join gisBaseReference region ON
	gisRayon.idfsRegion = region.idfsGISBaseReference
	and region.intRowStatus = 0
left join gisStringNameTranslation sregion
on			region.idfsGISBaseReference = sregion.idfsGISBaseReference
			and sregion.idfsLanguage = srayon.idfsLanguage
WHERE 
	gisRayon.intRowStatus = 0
--Settlement names in format [Region], [Rayon], [Settlement]
union
select 
	gisSettlement.idfsSettlement as idfsArea, 
	IsNull(sregion.strTextString, region.strDefault)+ ', ' +IsNull(srayon.strTextString, rayon.strDefault) + ', ' +IsNull(ssettlement.strTextString, settlement.strDefault) as strAreaName, 
	10089004 as AreaType, 
	ssettlement.idfsLanguage  
from   gisSettlement  
inner join gisBaseReference settlement ON
	gisSettlement.idfsSettlement = settlement.idfsGISBaseReference
	and settlement.intRowStatus = 0
left join gisStringNameTranslation ssettlement
on			settlement.idfsGISBaseReference = ssettlement.idfsGISBaseReference
inner join gisBaseReference rayon ON
	gisSettlement.idfsRayon = rayon.idfsGISBaseReference
	and rayon.intRowStatus = 0
left join gisStringNameTranslation srayon
on			rayon.idfsGISBaseReference = srayon.idfsGISBaseReference
			and ssettlement.idfsLanguage = srayon.idfsLanguage
inner join gisBaseReference region ON
	gisSettlement.idfsRegion = region.idfsGISBaseReference
	and region.intRowStatus = 0
left join gisStringNameTranslation sregion
on			region.idfsGISBaseReference = sregion.idfsGISBaseReference
			and sregion.idfsLanguage = ssettlement.idfsLanguage
WHERE 
	gisSettlement.intRowStatus = 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

