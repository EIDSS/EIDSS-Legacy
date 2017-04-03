SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRayon_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRayon_SelectDetail]
GO





CREATE       PROCEDURE dbo.spRayon_SelectDetail(
	@idfsRayon AS BIGINT,
	@LANGID as NVARCHAR(50)
)
AS
SELECT  
	idfsRayon, 
	idfsCountry, 
	idfsRegion,
	natRayon.[Name] as strNationalName,
	enRayon.[Name] as strEnglishName,
	strHASC
FROM 
	gisRayon
LEFT JOIN 
	fnGisReference(@LANGID,19000002) as natRayon --'rftRayon'
on	natRayon.idfsReference = idfsRayon
LEFT JOIN 
	fnGisReference('en',19000002) as enRayon --'rftRayon'
on	enRayon.idfsReference = idfsRayon
WHERE
	idfsRayon = @idfsRayon 





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

