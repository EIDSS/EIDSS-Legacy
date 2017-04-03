SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckASS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckASS]
GO
/*
if Object_ID('tempdb..##NodeTable') is null
create table ##NodeTable(
	idfNode BIGINT  NOT NULL, 
	strNodeTable nvarchar(200) COLLATE database_default,
	intStatus int )

declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
exec spFiltered_CheckASS @ID

drop  table ##NodeTable
*/
CREATE      proc spFiltered_CheckASS (@event bigint)
AS



-- objects for investigation (add new!)
INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfObject],707040000000, 0
FROM [tauDataAuditDetailCreate] AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 707040000000  --tlbMonitoringSession
AND b.idfNode IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT c5.[idfMonitoringSession],707040000000 /*tlbMonitoringSession*/, 0
FROM [tauDataAuditDetailCreate] AS a --a.idfContainer, a.idfTransferOut
INNER JOIN [tlbTransferOutContainerList] AS c1
ON a.[idfObject] = c1.[idfContainer] AND a.[idfObjectDetail] = c1.[idfTransferOut]
INNER JOIN [tlbContainer] AS c2
ON c1.[idfContainer] = c2.[idfContainer]
INNER JOIN [tlbMaterial] AS c3
ON c2.[idfMaterial] = c3.[idfMaterial]
INNER JOIN [tlbParty] AS c4
ON c3.[idfParty] = c4.[idfParty]
INNER JOIN [tlbMonitoringSession] AS c5
ON c4.[idfMonitoringSession] = c5.[idfMonitoringSession]
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = c5.[idfMonitoringSession]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75780000000 ---tlbTransferOutContainerList
AND b.idfNode IS NULL 

--- update [tlbMonitoringSession]
INSERT INTO [##NodeTable]
SELECT DISTINCT c5.[idfMonitoringSession],707040000000 /*tlbMonitoringSession*/, 0
FROM dbo.tauDataAuditDetailUpdate AS a 
INNER JOIN [tlbMonitoringSession] AS c5
ON a.idfObject = c5.[idfMonitoringSession]
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = c5.[idfMonitoringSession]
WHERE a.[idfDataAuditEvent] = @event 
AND b.idfNode IS NULL 

--- update farm address
INSERT INTO [##NodeTable]
SELECT DISTINCT c5.[idfMonitoringSession],707040000000 /*tlbMonitoringSession*/, 0
FROM dbo.tauDataAuditDetailUpdate AS a 
INNER JOIN dbo.tlbGeoLocation AS c1
ON a.[idfObject] = c1.idfGeoLocation
INNER JOIN dbo.tlbFarm as c2
on c1.idfGeoLocation = c2.idfFarmAddress
INNER JOIN [tlbParty] AS c4
ON c2.idfFarm = c4.[idfParty]
INNER JOIN [tlbMonitoringSession] AS c5
ON c4.[idfMonitoringSession] = c5.[idfMonitoringSession]
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = c5.[idfMonitoringSession]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75780000000 ---tlbTransferOutContainerList
AND b.idfNode IS NULL 

--- update farm location
INSERT INTO [##NodeTable]
SELECT DISTINCT c5.[idfMonitoringSession],707040000000 /*tlbMonitoringSession*/, 0
FROM dbo.tauDataAuditDetailUpdate AS a 
INNER JOIN dbo.tlbGeoLocation AS c1
ON a.[idfObject] = c1.idfGeoLocation
INNER JOIN dbo.tlbFarm as c2
on c1.idfGeoLocation = c2.idfFarmLocation
INNER JOIN [tlbParty] AS c4
ON c2.idfFarm = c4.[idfParty]
INNER JOIN [tlbMonitoringSession] AS c5
ON c4.[idfMonitoringSession] = c5.[idfMonitoringSession]
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = c5.[idfMonitoringSession]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75780000000 ---tlbTransferOutContainerList
AND b.idfNode IS NULL 

-- проверка необходимости изменений
CREATE TABLE #SiteList (
	idfNode BIGINT  NOT NULL,
	idfsSite BIGINT,
	strSiteID VARCHAR(36) collate database_default
	)
	
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite], a2.[strSiteID]
FROM [tlbMonitoringSession] AS a
INNER JOIN [tstSite] AS a2
ON a.[idfsSite] = a2.[idfsSite]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfMonitoringSession] AND d.intStatus = 0

-- by TransferOut
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b6.[idfsSite], b6.[strSiteID]
FROM [tlbMonitoringSession] AS a
INNER JOIN [tlbParty] AS b1
ON a.[idfMonitoringSession] = b1.[idfMonitoringSession]
INNER JOIN [tlbMaterial] AS b2
ON b1.[idfParty] = b2.[idfParty]
INNER JOIN [tlbContainer] AS b3
ON b2.[idfMaterial] = b3.[idfMaterial]
INNER JOIN [tlbTransferOutContainerList] AS b4
ON b3.[idfContainer] = b4.[idfContainer]
INNER JOIN [tlbTransferOUT] AS b5
ON b4.[idfTransferOut] = b5.[idfTransferOut]
INNER JOIN [tflogTransferOutFiltered] AS b6
ON b5.[idfTransferOut] = b6.[idfTransferOut]
LEFT JOIN [#SiteList] AS c
ON b6.[idfsSite] = c.[idfsSite] AND a.[idfMonitoringSession] = c.[idfNode]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfMonitoringSession] AND d.intStatus = 0
WHERE c.[idfNode] IS NULL 


INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b6.[idfsSite], b6.[strSiteID]
FROM [tlbMonitoringSession] AS a
INNER JOIN [tlbParty] AS b1
ON a.[idfMonitoringSession] = b1.[idfMonitoringSession]
INNER JOIN [tlbMaterial] AS b2
ON b1.[idfParty] = b2.[idfParty]
INNER JOIN [tlbContainer] AS b3
ON b2.[idfMaterial] = b3.[idfMaterial]
INNER JOIN [tlbTransferOutContainerList] AS b4
ON b3.[idfContainer] = b4.[idfContainer]
INNER JOIN [tlbTransferOUT] AS b5
ON b4.[idfTransferOut] = b5.[idfTransferOut]
INNER JOIN [tflTransferOutFiltered] AS b6
ON b5.[idfTransferOut] = b6.[idfTransferOut]
LEFT JOIN [#SiteList] AS c
ON b6.[idfsSite] = c.[idfsSite] AND a.[idfMonitoringSession] = c.[idfNode]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfMonitoringSession] AND d.intStatus = 0
WHERE c.[idfNode] IS NULL 

-- by Rayon (by current site)
INSERT INTO [#SiteList] (	[idfNode],	[idfsSite],	[strSiteID])
SELECT a.[idfMonitoringSession], f.idfsSite, f.strSiteID
FROM [tlbMonitoringSession] AS a
INNER JOIN [tstSite] AS a1
ON a.[idfsSite] = a1.[idfsSite]
INNER JOIN [tlbOffice] AS a2
ON a1.[idfOffice] = a2.[idfOffice]
INNER JOIN [tlbGeoLocation] AS a3
ON a2.[idfLocation] = a3.[idfGeoLocation]
INNER JOIN [fnFiltered_RayonOrganizationList]() AS f
ON a3.[idfsRayon] = f.[idfsRayon]
LEFT JOIN [#SiteList] AS g
ON a.[idfMonitoringSession] = g.[idfNode] AND f.[idfsSite] = g.[idfsSite]
INNER JOIN ##NodeTable AS b
ON a.[idfMonitoringSession] = b.idfNode
WHERE g.[idfNode] IS NULL 

-- by Rayon (by MonitoringSession rayon)
INSERT INTO [#SiteList] (	[idfNode],	[idfsSite],	[strSiteID])
SELECT a.[idfMonitoringSession], f.idfsSite, f.strSiteID
FROM [tlbMonitoringSession] AS a
INNER JOIN [fnFiltered_RayonOrganizationList]() AS f
ON a.[idfsRayon] = f.[idfsRayon]
LEFT JOIN [#SiteList] AS g
ON a.[idfMonitoringSession] = g.[idfNode] AND f.[idfsSite] = g.[idfsSite]
INNER JOIN ##NodeTable AS b
ON a.[idfMonitoringSession] = b.idfNode
WHERE g.[idfNode] IS NULL 

-- by Rayon (by farm address rayon)
INSERT INTO [#SiteList] (	[idfNode],	[idfsSite],	[strSiteID])
SELECT a.[idfMonitoringSession], f.idfsSite, f.strSiteID
FROM [tlbMonitoringSession] AS a 
inner join dbo.tlbParty as b
on a.idfMonitoringSession = b.idfMonitoringSession
inner join dbo.tlbFarm as c 
on b.idfParty = c.idfFarm
inner join dbo.tlbGeoLocation as d
on c.idfFarmAddress = d.idfGeoLocation
INNER JOIN [fnFiltered_RayonOrganizationList]() AS f
ON d.[idfsRayon] = f.[idfsRayon]
LEFT JOIN [#SiteList] AS g
ON a.[idfMonitoringSession] = g.[idfNode] AND f.[idfsSite] = g.[idfsSite]
INNER JOIN ##NodeTable AS b1
ON a.[idfMonitoringSession] = b1.idfNode
WHERE g.[idfNode] IS NULL 

-- by Rayon (by farm location rayon)
INSERT INTO [#SiteList] (	[idfNode],	[idfsSite],	[strSiteID])
SELECT a.[idfMonitoringSession], f.idfsSite, f.strSiteID
FROM [tlbMonitoringSession] AS a 
inner join dbo.tlbParty as b
on a.idfMonitoringSession = b.idfMonitoringSession
inner join dbo.tlbFarm as c 
on b.idfParty = c.idfFarm
inner join dbo.tlbGeoLocation as d
on c.idfFarmLocation = d.idfGeoLocation
INNER JOIN [fnFiltered_RayonOrganizationList]() AS f
ON d.[idfsRayon] = f.[idfsRayon]
LEFT JOIN [#SiteList] AS g
ON a.[idfMonitoringSession] = g.[idfNode] AND f.[idfsSite] = g.[idfsSite]
INNER JOIN ##NodeTable AS b1
ON a.[idfMonitoringSession] = b1.idfNode
WHERE g.[idfNode] IS NULL 

-- SiteRelationTable
INSERT INTO [#SiteList] 
SELECT  distinct a.[idfNode], b.[relatedSite], b.[relatedSiteID]
FROM #SiteList AS a
INNER JOIN dbo.[fnFiltered_FullSiteList]() AS b ON a.[idfsSite] = b.[parentSite] AND b.[idfsSiteRelationType] = 10084001 --reported only
LEFT JOIN #SiteList AS a2 ON a.[idfNode] = a2.[idfNode] AND a2.[idfsSite] = b.[relatedSite]
WHERE a2.[idfNode] IS NULL 

-- 3.
--------------------------------------------------------------------------------	
UPDATE b 
SET intStatus = 2 /* проверено, изменени€*/
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN dbo.tflogMonitoringSessionFiltered AS d
ON c.[strSiteID] = d.[strSiteID] AND c.[idfNode] = d.idfMonitoringSession
WHERE b.intStatus = 0 
AND d.[idfsSite] IS NULL 

UPDATE b 
SET intStatus = 1 /*проверено, без изменений*/
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
WHERE b.intStatus = 0 

-- реализаци€ изменений
INSERT INTO [tflMonitoringSessionFiltered] ([idfMonitoringSession],[strSiteID],[idfsSite]) 
SELECT a.[idfNode],
	   a.[strSiteID],
	   a.[idfsSite]
FROM #SiteList AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfNode] = b.idfNode AND b.intStatus = 2
LEFT JOIN [tflMonitoringSessionFiltered] AS c
ON c.[strSiteID] = a.[strSiteID] AND c.[idfMonitoringSession] = a.[idfNode]
LEFT JOIN [tflogMonitoringSessionFiltered] AS c2
ON c2.[strSiteID] = a.[strSiteID] AND c2.[idfMonitoringSession] = a.[idfNode]
WHERE c.[idfsSite] IS NULL and  c2.[idfsSite] IS NULL 

INSERT INTO [tflogMonitoringSessionFiltered] ([idfMonitoringSession],[strSiteID],[idfsSite]) 
SELECT a.[idfNode],
	   a.[strSiteID],
	   a.[idfsSite]
FROM #SiteList AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfNode] = b.idfNode AND b.intStatus = 2
LEFT JOIN [tflogMonitoringSessionFiltered] AS c2
ON c2.[strSiteID] = a.[strSiteID] AND c2.[idfMonitoringSession] = a.[idfNode]
WHERE c2.[idfsSite] IS NULL 

-- внесение дочерних сущностей в очередь изменений
-- Party
INSERT INTO [##NodeTable]
SELECT DISTINCT c.[idfParty], 75670000000 /*tlbParty*/, 0
FROM [tlbMonitoringSession] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfMonitoringSession] = b.idfNode AND b.intStatus = 2
INNER JOIN [tlbParty] AS c 
ON a.[idfMonitoringSession] = c.[idfMonitoringSession]
-- ROOT Party
INSERT INTO [##NodeTable]
SELECT DISTINCT c.[idfRootParty], 75670000000 /*tlbParty*/, 0
FROM [tlbMonitoringSession] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfMonitoringSession] = b.idfNode AND b.intStatus = 2
INNER JOIN [tlbParty] AS c 
ON a.[idfMonitoringSession] = c.[idfMonitoringSession]
where  c.[idfRootParty] IS NOT NULL
--BatchTest
INSERT INTO [##NodeTable]
SELECT DISTINCT c4.[idfBatchTest], 75480000000	/*tlbBatchTest*/, 0
FROM [tlbMonitoringSession] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfMonitoringSession] = b.idfNode AND b.intStatus = 2
INNER JOIN [tlbParty] AS c 
ON a.[idfMonitoringSession] = c.[idfMonitoringSession]
INNER JOIN [tlbMaterial] AS c2
ON c.[idfParty] = c2.[idfParty]
INNER JOIN [tlbTesting] AS c3
ON c2.[idfTesting] = c3.[idfTesting]
INNER JOIN [tlbBatchTest] AS c4
ON c3.[idfBatchTest] = c4.[idfBatchTest]
--ExternalBatchTest
INSERT INTO [##NodeTable]
SELECT DISTINCT c4.[idfExtBatchTest], 72920000000 /*tlbExtBatchTest*/, 0 
FROM [tlbMonitoringSession] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfMonitoringSession] = b.idfNode AND b.intStatus = 2
INNER JOIN [tlbParty] AS c 
ON a.[idfMonitoringSession] = c.[idfMonitoringSession]
INNER JOIN [tlbMaterial] AS c2
ON c.[idfParty] = c2.[idfParty]
INNER JOIN [tlbTesting] AS c3
ON c2.[idfTesting] = c3.[idfTesting]
INNER JOIN [tlbExtBatchTest] AS c4
ON c3.[idfExtBatchTest] = c4.[idfExtBatchTest]

-- Update дочерних сущностей
-- Notification
INSERT INTO [tflNotificationFiltered] (	[idfNotification],[idfsSite],[strSiteID]) 
SELECT DISTINCT a1.[idfNotification], c.[idfsSite],c.[strSiteID]
FROM [tlbMonitoringSession] AS a
INNER JOIN [tstNotification] AS a1
ON a.[idfMonitoringSession] = a1.[idfNotificationObject]
INNER JOIN [##NodeTable] AS b
ON a.[idfMonitoringSession] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflNotificationFiltered] AS c2 
ON a1.[idfNotification] = c2.[idfNotification] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogNotificationFiltered] AS c21 
ON a1.[idfNotification] = c21.[idfNotification] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflogNotificationFiltered] (	[idfNotification],[idfsSite],[strSiteID]) 
SELECT DISTINCT a1.[idfNotification], c.[idfsSite],c.[strSiteID]
FROM [tlbMonitoringSession] AS a
INNER JOIN [tstNotification] AS a1
ON a.[idfMonitoringSession] = a1.[idfNotificationObject]
INNER JOIN [##NodeTable] AS b
ON a.[idfMonitoringSession] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogNotificationFiltered] AS c21 
ON a1.[idfNotification] = c21.[idfNotification] AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL 

DROP TABLE [#SiteList]

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

