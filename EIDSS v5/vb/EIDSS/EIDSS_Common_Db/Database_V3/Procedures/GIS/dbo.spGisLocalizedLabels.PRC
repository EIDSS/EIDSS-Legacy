SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


-- DROP IF EXIST
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGisLocalizedLabels]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGisLocalizedLabels]
GO



--##SUMMARY Select localized labels for GIS objects
--##SUMMARY Used by map for rendering localized labels
--##RETURNS Table with GIS reference ID and localized field 'Name'

--##REMARKS Author: Nikulin E.
--##REMARKS Create date: 24.06.2010


/*
	Dependences
		Tables:
			dbo.gisBaseReference
			dbo.gisStringNameTranslation
		Functions:
			dbo.fnGetLanguageCode
*/

/*
--Example of procedure call:
DECLARE @LANGID NVARCHAR(50)
DECLARE @TYPE BIGINT

SET @LANGID = 'ru'	 	
SET @TYPE = 19000001 --rftCountry

EXECUTE spGisLocalizedLabels
   @LANGID
  ,@TYPE
*/

CREATE PROCEDURE [dbo].[spGisLocalizedLabels]
	@LANGID  NVARCHAR(50),	--##PARAM @LANGID - Language ID
	@TYPE BIGINT			--##PARAM @TYPE - GIS reference type
AS
			SELECT
			b.idfsGISBaseReference AS [Id], 
				IsNull(c.strTextString, b.strDefault) AS [Name]
			FROM
			dbo.gisBaseReference AS b WITH(NOLOCK)
			LEFT JOIN dbo.gisStringNameTranslation AS c WITH(NOLOCK)
			ON b.idfsGISBaseReference=c.idfsGISBaseReference and idfsLanguage=dbo.fnGetLanguageCode(@LANGID)
			WHERE b.idfsGISReferenceType=@TYPE
