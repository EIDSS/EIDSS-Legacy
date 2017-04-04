
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_hmisRegion_gisRegion__idfsRegion]') AND parent_object_id = OBJECT_ID(N'[dbo].[hmisRegion]'))
ALTER TABLE [dbo].[hmisRegion] DROP CONSTRAINT [FK_hmisRegion_gisRegion__idfsRegion]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hmisRegion]') AND type in (N'U'))
DROP TABLE [dbo].[hmisRegion]
GO

CREATE TABLE [dbo].[hmisRegion] (
	[hmisRegion] [bigint] IDENTITY(1,1) NOT NULL,
	[strHmisRegion] [nvarchar](36) NOT NULL,
	[idfsRegion] [bigint] NOT NULL
CONSTRAINT [XPKhmisRegion] PRIMARY KEY CLUSTERED 
(
	[hmisRegion] ASC
)
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[hmisRegion]  WITH NOCHECK ADD  CONSTRAINT [FK_hmisRegion_trtRegion__idfsRegion] FOREIGN KEY([idfsRegion])
REFERENCES [dbo].[gisRegion] ([idfsRegion])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hmisRegion_SelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[hmisRegion_SelectLookup]
GO

--exec hmisRegion_SelectLookup 'en' , 780000000
CREATE procedure [dbo].[hmisRegion_SelectLookup] (
	@LangID as nvarchar(50), --##PARAM @LangID - language ID
	@CountryID as bigint
)
as
select	
	region.idfsReference as idfsRegion, 
	region.[name] as strRegionName, 
	hmisRegion.strHmisRegion,
	region.[ExtendedName] as strRegionExtendedName, 
	gisRegion.strCode as strRegionCode, 
	gisRegion.idfsCountry, 
	region.intRowStatus,
	country.name AS strCountryName
FROM	
	dbo.fnGisExtendedReferenceRepair(@LangID,19000003) region--'rftRegion'
inner join hmisRegion
	on idfsReference = hmisRegion.idfsRegion
inner join gisRegion
	on idfsReference = gisRegion.idfsRegion 
inner join dbo.fnGisReferenceRepair(@LangID,19000001) country
	on  country.idfsReference = gisRegion.idfsCountry
WHERE	
	gisRegion.idfsCountry = isnull(@CountryID, gisRegion.idfsCountry)
	and gisRegion.idfsCountry in (select distinct idfsCountry from tstSite)
ORDER BY strRegionName

GO
