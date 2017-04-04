
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_hmisRayon_gisRayon__idfsRayon]') AND parent_object_id = OBJECT_ID(N'[dbo].[hmisRayon]'))
ALTER TABLE [dbo].[hmisRayon] DROP CONSTRAINT [FK_hmisRayon_gisRayon__idfsRayon]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hmisRayon]') AND type in (N'U'))
DROP TABLE [dbo].[hmisRayon]
GO

CREATE TABLE [dbo].[hmisRayon] (
	[hmisRayon] [bigint] IDENTITY(1,1) NOT NULL,
	[strHmisRayon] [nvarchar](36) NOT NULL,
	[idfsRayon] [bigint] NOT NULL
CONSTRAINT [XPKhmisRayon] PRIMARY KEY CLUSTERED 
(
	[hmisRayon] ASC
)
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[hmisRayon]  WITH NOCHECK ADD  CONSTRAINT [FK_hmisRayon_trtRayon__idfsRayon] FOREIGN KEY([idfsRayon])
REFERENCES [dbo].[gisRayon] ([idfsRayon])
NOT FOR REPLICATION 
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hmisRayon_SelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[hmisRayon_SelectLookup]
GO

--exec hmisRayon_SelectLookup 'en' , 37040000000
CREATE procedure [dbo].[hmisRayon_SelectLookup] (
	@LangID as nvarchar(50), --##PARAM @LangID - language ID
	@RegionID as bigint
)
as
select	
	rayon.idfsReference as idfsRayon
	,rayon.[name] as strRayonName
	,hmisRayon.strHmisRayon
	,rayon.[ExtendedName] as strRayonExtendedName
	,gisRayon.idfsRegion
	,gisRayon.idfsCountry
	,rayon.intRowStatus
	,region.ExtendedName as strRegionExtendedName
	,country.name as strCountryName
FROM	dbo.fnGisExtendedReferenceRepair(@LangID,19000002) rayon--'rftRayon' 
inner join hmisRayon
	on idfsReference = hmisRayon.idfsRayon
inner join 	gisRayon 
	on	rayon.idfsReference = gisRayon.idfsRayon 
inner join 	gisCountry
	on	gisRayon.idfsCountry = gisCountry.idfsCountry
inner join dbo.fnGisExtendedReferenceRepair(@LangID,19000003) region
	on region.idfsReference = gisRayon.idfsRegion
join dbo.fnGisReferenceRepair(@LangID,19000001) country
	on country.idfsReference = gisRayon.idfsCountry
WHERE	
	gisRayon.idfsRegion = isnull(@RegionID, gisRayon.idfsRegion)
	and gisRayon.idfsCountry in (select distinct idfsCountry from tstCustomizationPackage)
ORDER BY strRayonName

GO

