
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_hmisSettlement_gisSettlement__idfsSettlement]') AND parent_object_id = OBJECT_ID(N'[dbo].[hmisSettlement]'))
ALTER TABLE [dbo].[hmisSettlement] DROP CONSTRAINT [FK_hmisSettlement_gisSettlement__idfsSettlement]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hmisSettlement]') AND type in (N'U'))
DROP TABLE [dbo].[hmisSettlement]
GO

CREATE TABLE [dbo].[hmisSettlement] (
	[hmisSettlement] [bigint] IDENTITY(1,1) NOT NULL,
	[strHmisSettlement] [nvarchar](36) NOT NULL,
	[idfsSettlement] [bigint] NOT NULL
CONSTRAINT [XPKhmisSettlement] PRIMARY KEY CLUSTERED 
(
	[hmisSettlement] ASC
)
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[hmisSettlement]  WITH NOCHECK ADD  CONSTRAINT [FK_hmisSettlement_trtSettlement__idfsSettlement] FOREIGN KEY([idfsSettlement])
REFERENCES [dbo].[gisSettlement] ([idfsSettlement])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[hmisSettlement_SelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[hmisSettlement_SelectLookup]
GO

--exec hmisSettlement_SelectLookup 'en' , 37040000000
CREATE procedure [dbo].[hmisSettlement_SelectLookup] (
	@LangID as nvarchar(50), --##PARAM @LangID - language ID
	@RayonID as bigint
)
as
select	
	settlement.idfsReference AS idfsSettlement, 
	settlement.name AS strSettlementName,
	hmisSettlement.strHmisSettlement,
	settlement.ExtendedName AS strSettlementExtendedName,
	gisSettlement.idfsRayon,
	gisSettlement.idfsRegion,
	gisSettlement.idfsCountry,
	settlementType.name as strSettlementType,
	settlement.intRowStatus,
	country.name as strCountryName,
	region.ExtendedName as strRegionExtendedName,
	rayon.ExtendedName as strRayonExtendedName
FROM dbo.fnGisExtendedReferenceRepair(@LangID,19000004) settlement
INNER JOIN 	gisSettlement	
	ON	settlement.idfsReference = gisSettlement.idfsSettlement 
inner join hmisSettlement
	on idfsReference = hmisSettlement.idfsSettlement
join tstCustomizationPackage tcpac on
	tcpac.idfsCountry = gisSettlement.idfsCountry
inner join tstSite
	on	tstSite.idfCustomizationPackage=tcpac.idfCustomizationPackage 
	and tstSite.idfsSite=dbo.fnSiteID()
left join fnGisReference(@LangID, 19000005) settlementType 
	on settlementType.idfsReference = gisSettlement.idfsSettlementType
left join dbo.fnGisExtendedReferenceRepair(@LangID,19000003) region
	on region.idfsReference = gisSettlement.idfsRegion
left join dbo.fnGisExtendedReferenceRepair(@LangID,19000002) rayon
	on rayon.idfsReference = gisSettlement.idfsRayon
left join dbo.fnGisReferenceRepair(@LangID,19000001) country
	on country.idfsReference = gisSettlement.idfsCountry

WHERE	
( @RayonID IS NULL OR gisSettlement.idfsRayon = @RayonID )
ORDER BY strSettlementName
GO


