SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckGeoLocation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckGeoLocation]
GO
/*
if Object_ID('tempdb..##NodeTable') is null
create table ##NodeTable(
	idfNode BIGINT  NOT NULL, 
	strNodeTable nvarchar(200) COLLATE database_default,
	intStatus int )

declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
exec spFiltered_CheckGeoLocation @ID

drop  table ##NodeTable
*/
CREATE      proc spFiltered_CheckGeoLocation (@event bigint)
AS



-- objects for investigation (add new!)
INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfObject],75580000000, 1 ---0!!!!!!!!!!!!!!
FROM [tauDataAuditDetailCreate] AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75580000000	--tlbGeoLocation
AND b.idfNode IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfObject],75580000000, 1 ---0!!!!!!!!!!!!!!
FROM dbo.tauDataAuditDetailUpdate AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75580000000	--tlbGeoLocation
AND b.idfNode IS NULL 

--------------------------------------------
-- by site
-- остальные варианты расмотрены в других процедурах

INSERT INTO [tflGeoLocationFiltered]([idfGeoLocation],[idfsSite],[strSiteID])
SELECT  distinct a.idfGeoLocation, a2.[relatedSite],a2.[relatedSiteID]
FROM [tlbGeoLocation] AS a
INNER JOIN [fnFiltered_FullSiteList]() AS a2 
ON a.idfsSite = a2.[parentSite]  AND a2.[idfsSiteRelationType] = 10084001 --reported only
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.idfGeoLocation
LEFT JOIN [tflGeoLocationFiltered] AS c 
ON a.idfGeoLocation = c.[idfGeoLocation] AND a2.[relatedSiteID]= c.[strSiteID]
LEFT JOIN [tflogGeoLocationFiltered] AS c2 
ON a.idfGeoLocation = c2.[idfGeoLocation] AND a2.[relatedSiteID]= c2.[strSiteID]
WHERE c.idfsSite IS NULL and c2.idfsSite IS NULL 

INSERT INTO [tflogGeoLocationFiltered]([idfGeoLocation],[idfsSite],[strSiteID])
SELECT  distinct a.idfGeoLocation, a2.[relatedSite],a2.[relatedSiteID]
FROM [tlbGeoLocation] AS a
INNER JOIN [fnFiltered_FullSiteList]() AS a2 
ON a.idfsSite = a2.[parentSite]  AND a2.[idfsSiteRelationType] = 10084001 --reported only
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.idfGeoLocation
LEFT JOIN [tflogGeoLocationFiltered] AS c2 
ON a.idfGeoLocation = c2.[idfGeoLocation] AND a2.[relatedSiteID]= c2.[strSiteID]
WHERE c2.idfsSite IS NULL 

---- адреса организаций рассылаем на все сайты

INSERT INTO [tflGeoLocationFiltered]([idfGeoLocation],[idfsSite],[strSiteID])
SELECT  distinct a.idfGeoLocation, a2.[idfsSite],a2.[strSiteID]
FROM [tlbGeoLocation] AS a
INNER JOIN [tlbOffice] AS d
ON a.[idfGeoLocation] = d.[idfLocation]
INNER JOIN [tstSite] AS a2 
ON 
--	a2.[idfsSiteType] IN (10085004,10085006,10085007) AND 
	a2.[intRowStatus] = 0
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.idfGeoLocation
LEFT JOIN [tflGeoLocationFiltered] AS c 
ON a.idfGeoLocation = c.[idfGeoLocation] AND a2.[strSiteID]= c.[strSiteID]
WHERE c.idfsSite IS NULL 

INSERT INTO [tflogGeoLocationFiltered]([idfGeoLocation],[idfsSite],[strSiteID])
SELECT distinct  a.idfGeoLocation, a2.[idfsSite],a2.[strSiteID]
FROM [tlbGeoLocation] AS a
INNER JOIN [tlbOffice] AS d
ON a.[idfGeoLocation] = d.[idfLocation]
INNER JOIN [tstSite] AS a2 
ON 
--	a2.[idfsSiteType] IN (10085004,10085006,10085007) AND 
	a2.[intRowStatus] = 0
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.idfGeoLocation
LEFT JOIN [tflogGeoLocationFiltered] AS c 
ON a.idfGeoLocation = c.[idfGeoLocation] AND a2.[strSiteID]= c.[strSiteID]
WHERE c.idfsSite IS NULL 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

