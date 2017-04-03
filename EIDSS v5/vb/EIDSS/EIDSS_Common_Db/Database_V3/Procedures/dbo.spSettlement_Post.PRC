SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSettlement_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSettlement_Post]
GO
--##SUMMARY Posts settlement data.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use


/*
--Example of a call of procedure:

DECLARE @idfsSettlement bigint
DECLARE @strEnglishName nvarchar(200)
DECLARE @strNationalName nvarchar(200)
DECLARE @LANGID varchar(50)
DECLARE @dblLatitude float
DECLARE @dblLongitude float
DECLARE @idfsSettlementType bigint
DECLARE @idfsRayon bigint
DECLARE @idfsRegion bigint
DECLARE @idfsCountry bigint


EXECUTE spSettlement_Post
   @idfsSettlement
  ,@strEnglishName
  ,@strNationalName
  ,@LANGID
  ,@dblLatitude
  ,@dblLongitude
  ,@idfsSettlementType
  ,@idfsRayon
  ,@idfsRegion
  ,@idfsCountry
*/


CREATE proc spSettlement_Post(
	@idfsSettlement bigint, --##PARAM @idfsSettlement - settlement ID
	@strEnglishName nvarchar(200), --##PARAM @strEnglishName - settlement name in English
	@strNationalName nvarchar(200), --##PARAM @strNationalName - settlement name in language defined by @LANGID
	@LANGID varchar(50), --##PARAM @LANGID - language ID
	@dblLatitude float, --##PARAM @dblLatitude - settlement latitude
	@dblLongitude float, --##PARAM @dblLongitude - settlement longitude
	@idfsSettlementType bigint, --##PARAM @idfsSettlementType - settlement type, reference to rftSettlementType (19000083)
	@idfsRayon bigint, --##PARAM @idfsRayon - settlement rayon
	@idfsRegion bigint, --##PARAM @idfsRegion - settlement region
	@idfsCountry bigint, --##PARAM @idfsCountry -  settlement country
	@strSettlementCode nvarchar(200),
	@blnIsCustomSettlement bit
	)
as
if not exists(select idfsGISBaseReference from dbo.gisBaseReference
		where idfsGISBaseReference = @idfsSettlement)
begin
	insert into dbo.gisBaseReference(
		idfsGISBaseReference,
		idfsGISReferenceType,
		strDefault
	)
	values(
		@idfsSettlement,
		19000004, --'rftSettlement',
		@strEnglishName
	)
	insert into dbo.gisSettlement(
		idfsSettlement, 
		dblLongitude, 
		dblLatitude, 
		idfsSettlementType, 
		idfsRayon, 
		idfsCountry, 
		idfsRegion,
		strSettlementCode,
		blnIsCustomSettlement
		)
	values (
		@idfsSettlement, 
		@dblLongitude, 
		@dblLatitude, 
		@idfsSettlementType, 
		@idfsRayon, 
		@idfsCountry, 
		@idfsRegion,
		@strSettlementCode,
		@blnIsCustomSettlement
		)
	insert into dbo.gisStringNameTranslation(
		idfsGISBaseReference, 
		idfsLanguage, 
		strTextString)
	values (
		@idfsSettlement,
		dbo.fnGetLanguageCode(@LANGID),
		@strNationalName)
end
else
begin
	update dbo.gisBaseReference
	set
		strDefault=@strEnglishName
	where
		idfsGISBaseReference=@idfsSettlement
		AND ISNULL(@strEnglishName,N'')<>ISNULL(strDefault,N'')

	update dbo.gisSettlement
	set		 
		dblLongitude = @dblLongitude, 
		dblLatitude = @dblLatitude, 
		idfsSettlementType = @idfsSettlementType, 
		idfsRayon = @idfsRayon, 
		idfsCountry = @idfsCountry, 
		idfsRegion = @idfsRegion,
		strSettlementCode = @strSettlementCode,
		blnIsCustomSettlement = @blnIsCustomSettlement
	where 
		idfsSettlement = @idfsSettlement
	update dbo.gisStringNameTranslation
	set	
		strTextString=@strNationalName
	where
		idfsGISBaseReference=@idfsSettlement 
		AND idfsLanguage=dbo.fnGetLanguageCode(@LANGID)
		AND ISNULL(@strNationalName,N'')<>ISNULL(strTextString,N'')
	update dbo.gisStringNameTranslation
	set	
		strTextString=@strEnglishName
	where
		idfsGISBaseReference=@idfsSettlement 
		AND idfsLanguage=dbo.fnGetLanguageCode('en')
		AND ISNULL(@strEnglishName,N'')<>ISNULL(strTextString,N'')
end

EXEC spGisSetWKBSettlement 	@idfsSettlement


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

