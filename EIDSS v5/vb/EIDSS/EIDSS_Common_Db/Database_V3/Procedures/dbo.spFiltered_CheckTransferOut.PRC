SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckTransferOut]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckTransferOut]
GO
/*
if Object_ID('tempdb..##NodeTable') is null
create table ##NodeTable(
	idfNode BIGINT  NOT NULL, 
	strNodeTable nvarchar(200) COLLATE database_default,
	intStatus int )

declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
exec spFiltered_CheckTransferOut @ID

drop  table ##NodeTable
*/
CREATE      proc spFiltered_CheckTransferOut (@event bigint)
AS



-- objects for investigation (add new!)
INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfObject],75770000000, 0
FROM [tauDataAuditDetailCreate] AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75770000000 --tlbTransferOUT
AND b.idfNode IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfObject],75770000000, 0
FROM [tauDataAuditDetailUpdate] AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75770000000 --tlbTransferOUT
AND a.[idfColumn] = 80750000000	--idfSendToOffice
AND b.idfNode IS NULL 

-- проверка необходимости изменений
CREATE TABLE #SiteList (
	idfNode BIGINT  NOT NULL,
	idfsSite BIGINT,
	strSiteID varchar(36) collate database_default
	)
	
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode,b1.[idfsSite], b1.[strSiteID]
FROM [tlbTransferOUT] AS a
INNER JOIN [tstSite] AS b1
ON a.[idfSendFromOffice] = b1.[idfOffice]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfTransferOut] AND d.intStatus = 0

INSERT INTO [#SiteList] 
SELECT d.idfNode,  b1.[idfsSite], b1.[strSiteID]
FROM [tlbTransferOUT] AS a
INNER JOIN [tstSite] AS b1
ON a.idfSendToOffice = b1.[idfOffice]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfTransferOut] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b1.[idfsSite] = c.[idfsSite] AND a.[idfTransferOut] = c.[idfNode]
WHERE c.[idfNode] IS NULL 

-- SiteRelationTable
INSERT INTO [#SiteList] 
SELECT  distinct a.[idfNode], b.[relatedSite], b.[relatedSiteID]
FROM #SiteList AS a
INNER JOIN dbo.[fnFiltered_FullSiteList]() AS b ON a.[idfsSite] = b.[parentSite] AND b.[idfsSiteRelationType] = 10084001 --reported only
LEFT JOIN #SiteList AS a2 ON a.[idfNode] = a2.[idfNode] AND a2.[idfsSite] = b.[relatedSite]
WHERE a2.[idfNode] IS NULL 

-----------------------------------------------------------	
UPDATE b 
SET intStatus = 2 /* проверено, изменения*/
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogTransferOutFiltered] AS d
ON c.[strSiteID] = d.[strSiteID] AND c.[idfNode] = d.[idfTransferOut]
WHERE b.intStatus = 0 
AND d.[idfsSite] IS NULL 

UPDATE b 
SET intStatus = 1 /*проверено, без изменений*/
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
WHERE b.intStatus = 0 

-- реализация изменений
INSERT INTO [tflTransferOutFiltered] ([idfTransferOut],[strSiteID],[idfsSite]) 
SELECT a.[idfNode],
	   b2.[strSiteID],
	   b2.[idfsSite]
FROM #SiteList AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfNode] = b.idfNode AND b.intStatus = 2
INNER JOIN [tstSite] AS b2
ON a.[idfsSite] = b2.[idfsSite]
LEFT JOIN [tflTransferOutFiltered] AS c
ON c.[strSiteID] = a.[strSiteID] AND c.[idfTransferOut] = a.[idfNode]
LEFT JOIN [tflogTransferOutFiltered] AS c2
ON c2.[strSiteID] = a.[strSiteID] AND c2.[idfTransferOut] = a.[idfNode]
WHERE c.[idfsSite] IS NULL and c2.[idfsSite] IS NULL 

INSERT INTO [tflogTransferOutFiltered] ([idfTransferOut],[strSiteID],[idfsSite]) 
SELECT a.[idfNode],
	   b2.[strSiteID],
	   b2.[idfsSite]
FROM #SiteList AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfNode] = b.idfNode AND b.intStatus = 2
INNER JOIN [tstSite] AS b2
ON a.[idfsSite] = b2.[idfsSite]
LEFT JOIN [tflogTransferOutFiltered] AS c2
ON c2.[strSiteID] = a.[strSiteID] AND c2.[idfTransferOut] = a.[idfNode]
WHERE c2.[idfsSite] IS NULL 

DROP TABLE [#SiteList]

-- внесение дочерних сущностей в очередь изменений
INSERT INTO [##NodeTable]
SELECT DISTINCT c5.[idfCase],75490000000 /*tlbCase*/, 0
FROM [tlbTransferOUT] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfTransferOut] = b.idfNode AND b.intStatus = 2
INNER JOIN [tlbTransferOutContainerList] AS c1
ON a.[idfTransferOut] = c1.[idfTransferOut]
INNER JOIN [tlbContainer] AS c2
ON c1.[idfContainer] = c2.[idfContainer]
INNER JOIN [tlbMaterial] AS c3
ON c2.[idfMaterial] = c3.[idfMaterial]
INNER JOIN [tlbParty] AS c4
ON c3.[idfParty] = c4.[idfParty]
INNER JOIN [tlbCase] AS c5
ON c4.[idfCase] = c5.[idfCase]
LEFT JOIN [##NodeTable] AS bbb
ON bbb.idfNode = c5.[idfCase]
WHERE bbb.idfNode IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT c5.[idfMonitoringSession],707040000000 /*tlbMonitoringSession*/, 0
FROM [tlbTransferOUT] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfTransferOut] = b.idfNode AND b.intStatus = 2
INNER JOIN [tlbTransferOutContainerList] AS c1
ON a.[idfTransferOut] = c1.[idfTransferOut]
INNER JOIN [tlbContainer] AS c2
ON c1.[idfContainer] = c2.[idfContainer]
INNER JOIN [tlbMaterial] AS c3
ON c2.[idfMaterial] = c3.[idfMaterial]
INNER JOIN [tlbParty] AS c4
ON c3.[idfParty] = c4.[idfParty]
INNER JOIN [tlbMonitoringSession] AS c5
ON c4.[idfMonitoringSession] = c5.[idfMonitoringSession]
LEFT JOIN [##NodeTable] AS bbb
ON bbb.idfNode = c5.[idfMonitoringSession]
WHERE bbb.idfNode IS NULL 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

