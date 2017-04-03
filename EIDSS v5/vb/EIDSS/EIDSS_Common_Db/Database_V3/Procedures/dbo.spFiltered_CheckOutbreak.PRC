SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckOutbreak]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckOutbreak]
GO
/*
if Object_ID('tempdb..##NodeTable') is null
create table ##NodeTable(
	idfNode BIGINT  NOT NULL, 
	strNodeTable nvarchar(200) COLLATE database_default,
	intStatus int )

declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
exec spFiltered_CheckOutbreak @ID

drop  table ##NodeTable
*/
CREATE      proc spFiltered_CheckOutbreak (@event bigint)
AS



-- objects for investigation (add new!)
INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfObject],75660000000, 0 --!!!!!!!!!!!!!!
FROM [tauDataAuditDetailCreate] AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75660000000  --tlbOutbreak
AND b.idfNode IS NULL 

-- 2.
CREATE TABLE #SiteList (
	idfNode BIGINT  NOT NULL,
	idfsSite BIGINT,
	strSiteID VARCHAR(36) collate database_default
	)

-- by site
INSERT INTO [#SiteList] (	[idfNode],	[idfsSite],	[strSiteID])
SELECT DISTINCT a.idfOutbreak, a2.[idfsSite], a2.[strSiteID]
FROM [tlbOutbreak] AS a
INNER JOIN [tauDataAuditDetailCreate] AS d1
ON a.[idfOutbreak] = d1.[idfObject]
INNER JOIN [tauDataAuditEvent] AS d2
ON d1.[idfDataAuditEvent] = d2.[idfDataAuditEvent]
INNER JOIN [tstUserTable] AS d3
ON d2.[idfUserID] = d3.[idfUserID]
INNER JOIN [tstSite] AS a2
ON d3.[idfsSite] = a2.[idfsSite]
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.idfOutbreak AND b.intStatus = 0

-- parent case
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbOutbreak] AS a
INNER JOIN [tlbCase] AS a1
ON a1.idfOutbreak = a.[idfOutbreak]
INNER JOIN [tflCaseFiltered] AS b
ON a1.[idfCase] = b.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfOutbreak] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbOutbreak] AS a
INNER JOIN [tlbCase] AS a1
ON a1.idfOutbreak = a.[idfOutbreak]
INNER JOIN [tflogCaseFiltered] AS b
ON a1.[idfCase] = b.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfOutbreak] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

-- SiteRelationTable
INSERT INTO [#SiteList] 
SELECT  distinct a.[idfNode], b.[relatedSite], b.[relatedSiteID]
FROM #SiteList AS a
INNER JOIN dbo.[fnFiltered_FullSiteList]() AS b ON a.[idfsSite] = b.[parentSite] AND b.[idfsSiteRelationType] = 10084001 --reported only
LEFT JOIN #SiteList AS a2 ON a.[idfNode] = a2.[idfNode] AND a2.[idfsSite] = b.[relatedSite]
WHERE a2.[idfNode] IS NULL 

-- 3.
UPDATE b 
SET intStatus = 2 /* проверено, изменения*/
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN dbo.tflogOutbreakFiltered AS d
ON c.[strSiteID] = d.[strSiteID] AND c.[idfNode] = d.[idfOutbreak]
WHERE b.intStatus = 0 
AND d.[idfsSite] IS NULL 

UPDATE b 
SET intStatus = 1 /*проверено, без изменений*/
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
WHERE b.intStatus = 0 

INSERT INTO [tflOutbreakFiltered]([idfOutbreak],[idfsSite],[strSiteID])
SELECT DISTINCT b.[idfNode],c.[idfsSite], c.[strSiteID]
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflOutbreakFiltered] AS c2 
ON b.[idfNode] = c2.[idfOutbreak] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogOutbreakFiltered] AS c21 
ON b.[idfNode] = c21.[idfOutbreak] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflogOutbreakFiltered]([idfOutbreak],[idfsSite],[strSiteID])
SELECT DISTINCT b.[idfNode],c.[idfsSite], c.[strSiteID]
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogOutbreakFiltered] AS c21 
ON b.[idfNode] = c21.[idfOutbreak] AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL 

-- 4.

-- 5.
-- GeoLocation
INSERT INTO [tflGeoLocationFiltered]([idfGeoLocation],[idfsSite],[strSiteID])
SELECT DISTINCT a2.[idfGeoLocation], c.[idfsSite],c.[strSiteID]
FROM [tlbOutbreak] AS a
INNER JOIN [tlbGeoLocation] AS a2
ON a.[idfGeoLocation] = a2.idfGeoLocation
INNER JOIN [##NodeTable] AS b
ON a.[idfOutbreak] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflGeoLocationFiltered] AS c2 
ON a2.[idfGeoLocation] = c2.[idfGeoLocation] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflGeoLocationFiltered] AS c21 
ON a2.[idfGeoLocation] = c21.[idfGeoLocation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflogGeoLocationFiltered]([idfGeoLocation],[idfsSite],[strSiteID])
SELECT DISTINCT a2.[idfGeoLocation], c.[idfsSite],c.[strSiteID]
FROM [tlbOutbreak] AS a
INNER JOIN [tlbGeoLocation] AS a2
ON a.[idfGeoLocation] = a2.idfGeoLocation
INNER JOIN [##NodeTable] AS b
ON a.[idfOutbreak] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflGeoLocationFiltered] AS c21 
ON a2.[idfGeoLocation] = c21.[idfGeoLocation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a2.[idfGeoLocation], 75580000000 /*tlbGeoLocation*/, 1
FROM [tlbOutbreak] AS a
INNER JOIN [tlbGeoLocation] AS a2
ON a.[idfGeoLocation] = a2.idfGeoLocation
INNER JOIN [##NodeTable] AS b
ON a.[idfOutbreak] = b.idfNode --AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS rr
ON a2.[idfGeoLocation] = rr.idfNode
WHERE rr.idfNode IS NULL 

-- Notification
INSERT INTO [tflNotificationFiltered] (	[idfNotification],[idfsSite],[strSiteID]) 
SELECT DISTINCT a1.[idfNotification], c.[idfsSite],c.[strSiteID]
FROM [tlbOutbreak] AS a
INNER JOIN [tstNotification] AS a1
ON a.[idfOutbreak] = a1.[idfNotificationObject]
INNER JOIN [##NodeTable] AS b
ON a.[idfOutbreak] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflNotificationFiltered] AS c2 
ON a1.[idfNotification] = c2.[idfNotification] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflNotificationFiltered] AS c21 
ON a1.[idfNotification] = c21.[idfNotification] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflogNotificationFiltered] (	[idfNotification],[idfsSite],[strSiteID]) 
SELECT DISTINCT a1.[idfNotification], c.[idfsSite],c.[strSiteID]
FROM [tlbOutbreak] AS a
INNER JOIN [tstNotification] AS a1
ON a.[idfOutbreak] = a1.[idfNotificationObject]
INNER JOIN [##NodeTable] AS b
ON a.[idfOutbreak] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflNotificationFiltered] AS c21 
ON a1.[idfNotification] = c21.[idfNotification] AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL 

DROP TABLE [#SiteList]


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

