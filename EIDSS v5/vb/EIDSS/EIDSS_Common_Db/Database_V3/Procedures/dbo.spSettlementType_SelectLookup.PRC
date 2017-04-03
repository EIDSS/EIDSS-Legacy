SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSettlementType_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSettlementType_SelectLookup]
GO

--##SUMMARY Selects lookup list of settlement types.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 23.11.2009

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
exec spSettlementType_SelectLookup 'en'
*/

CREATE        PROCEDURE dbo.spSettlementType_SelectLookup
	@LanguageID nvarchar(50) --##PARAM @LanguageID - language ID
AS
SELECT	
	gisBaseReference.idfsGISBaseReference AS idfsReference, 
	isnull(gisStringNameTranslation.strTextString, gisBaseReference.strDefault) AS [Name]
FROM dbo.gisBaseReference 
LEFT JOIN gisStringNameTranslation  ON 
	gisBaseReference.idfsGISBaseReference = gisStringNameTranslation.idfsGISBaseReference
 	AND gisStringNameTranslation.idfsLanguage = dbo.fnGetLanguageCode(@LanguageID)
WHERE	
	 gisBaseReference.idfsGISReferenceType = 19000005 --'SettlementType'
	 AND gisBaseReference.intRowStatus = 0  
ORDER BY intOrder, [Name]

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

