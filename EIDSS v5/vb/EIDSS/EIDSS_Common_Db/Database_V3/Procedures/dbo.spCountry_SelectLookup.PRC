SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCountry_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCountry_SelectLookup]
GO





--exec spCountry_SelectLookup 'en'


CREATE       PROCEDURE dbo.spCountry_SelectLookup
	@LanguageID As nvarchar(50)
AS
SELECT	fnGisReference.idfsReference as idfsCountry, fnGisReference.[Name] as strCountryName, gisCountry.strCode as strCountryCode
FROM	dbo.fnGisReference(@LanguageID,19000001) --'rftCountry'
join	gisCountry
on	fnGisReference.idfsReference = gisCountry.idfsCountry
ORDER BY strCountryName


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

