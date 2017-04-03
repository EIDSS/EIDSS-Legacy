SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSettlement_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSettlement_SelectLookup]
GO

--##SUMMARY Selects lookup list of settlements.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use


/*
--Example of a call of procedure:

EXEC spSettlement_SelectLookup 'en'
EXEC spSettlement_SelectLookup 'en', 3260000000

*/
CREATE         PROCEDURE dbo.spSettlement_SelectLookup
	@LanguageID As nvarchar(50),  --##PARAM @LanguageID - language ID
	@RayonID as bigint = NULL,   --##PARAM @idfsRayon - settlement rayon. If NULL is passed, entire list of settlements is returned
	@ID as bigint = NULL   --##PARAM @ID - ID of specific settlement. If not null, returns only this specific settlement, in other case entire list is returned
AS
SELECT	
	gisBaseReference.idfsGISBaseReference AS idfsSettlement, 
	isnull(gisStringNameTranslation.strTextString, gisBaseReference.strDefault) AS strSettlementName,
	gisSettlement.idfsRayon,
	gisSettlement.idfsRegion,
	gisSettlement.idfsCountry
FROM dbo.gisBaseReference 
INNER JOIN 	gisSettlement	ON	
	gisBaseReference.idfsGISBaseReference = gisSettlement.idfsSettlement 
	AND ( @RayonID IS NULL OR gisSettlement.idfsRayon = @RayonID )
	AND ( (NOT @RayonID IS NULL)OR  (@ID IS NULL) OR (gisSettlement.idfsSettlement = @ID) )
	   inner join tstSite
on tstSite.idfsCountry=gisSettlement.idfsCountry and tstSite.idfsSite=dbo.fnSiteID()
LEFT JOIN gisStringNameTranslation  ON 
	gisBaseReference.idfsGISBaseReference = gisStringNameTranslation.idfsGISBaseReference
 	AND gisStringNameTranslation.idfsLanguage = dbo.fnGetLanguageCode(@LanguageID)
WHERE	
	 gisBaseReference.idfsGISReferenceType = 19000004 --'rftSettlement'
	 AND gisBaseReference.intRowStatus = 0  
ORDER BY strSettlementName


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

