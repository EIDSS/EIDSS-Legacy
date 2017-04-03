SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckExtBatchTest]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckExtBatchTest]
GO
/*
if Object_ID('tempdb..##NodeTable') is null
create table ##NodeTable(
	idfNode BIGINT  NOT NULL, 
	strNodeTable nvarchar(200) COLLATE database_default,
	intStatus int )

declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
exec spFiltered_CheckExtBatchTest @ID

drop  table ##NodeTable
*/
CREATE      proc spFiltered_CheckExtBatchTest (@event bigint)
AS



-- objects for investigation (add new!)
INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfObject],729200000000, 0 --!!!!!!!!!!!!!!
FROM [tauDataAuditDetailCreate] AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 729200000000 --tlbExtBatchTest
AND b.idfNode IS NULL 

-- 2.
CREATE TABLE #SiteList (
	idfNode BIGINT  NOT NULL,
	idfsSite BIGINT,
	strSiteID VARCHAR(36) collate database_default
	)

-- by site
INSERT INTO [#SiteList] (	[idfNode],	[idfsSite],	[strSiteID])
SELECT DISTINCT a.idfExtBatchTest, a2.[idfsSite], a2.[strSiteID]
FROM [tlbExtBatchTest] AS a
INNER JOIN [tauDataAuditDetailCreate] AS d1
ON a.[idfExtBatchTest] = d1.[idfObject]
INNER JOIN [tauDataAuditEvent] AS d2
ON d1.[idfDataAuditEvent] = d2.[idfDataAuditEvent]
INNER JOIN [tstUserTable] AS d3
ON d2.[idfUserID] = d3.[idfUserID]
INNER JOIN [tstSite] AS a2
ON d3.[idfsSite] = a2.[idfsSite]
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.idfExtBatchTest AND b.intStatus = 0

-- parent party
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbExtBatchTest] AS a
INNER JOIN [tlbTesting] AS a1
ON a.[idfExtBatchTest] = a1.[idfExtBatchTest]
INNER JOIN [tlbContainer] AS a2
ON a1.[idfContainer] = a2.[idfContainer]
INNER JOIN [tlbMaterial] AS a3
ON a2.[idfMaterial] = a3.[idfMaterial]
INNER JOIN [tlbParty] AS a4
ON a3.[idfParty] = a4.[idfParty]
INNER JOIN [tflogPartyFiltered] AS b
ON a4.[idfParty] = b.[idfParty]
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND a.[idfExtBatchTest] = c.[idfNode]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfExtBatchTest] AND d.intStatus = 0
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbExtBatchTest] AS a
INNER JOIN [tlbTesting] AS a1
ON a.[idfExtBatchTest] = a1.[idfExtBatchTest]
INNER JOIN [tlbContainer] AS a2
ON a1.[idfContainer] = a2.[idfContainer]
INNER JOIN [tlbMaterial] AS a3
ON a2.[idfMaterial] = a3.[idfMaterial]
INNER JOIN [tlbParty] AS a4
ON a3.[idfParty] = a4.[idfParty]
INNER JOIN [tflPartyFiltered] AS b
ON a4.[idfParty] = b.[idfParty]
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND a.[idfExtBatchTest] = c.[idfNode]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfExtBatchTest] AND d.intStatus = 0
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
LEFT JOIN dbo.tflogAllBatchTestFiltered AS d
ON c.[strSiteID] = d.[strSiteID] AND c.[idfNode] = d.[idfBatchTest]
WHERE b.intStatus = 0 
AND d.[idfsSite] IS NULL 

UPDATE b 
SET intStatus = 1 /*проверено, без изменений*/
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
WHERE b.intStatus = 0 

INSERT INTO [tflAllBatchTestFiltered]([idfBatchTest],[idfsSite],[strSiteID])
SELECT DISTINCT b.[idfNode],c.[idfsSite], c.[strSiteID]
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN dbo.tflAllBatchTestFiltered AS d
ON c.[strSiteID] = d.[strSiteID] AND c.[idfNode] = d.[idfBatchTest]
LEFT JOIN dbo.tflogAllBatchTestFiltered AS d2
ON c.[strSiteID] = d2.[strSiteID] AND c.[idfNode] = d2.[idfBatchTest]
WHERE d.idfsSite IS NULL and d2.idfsSite IS NULL 

INSERT INTO [tflogAllBatchTestFiltered]([idfBatchTest],[idfsSite],[strSiteID])
SELECT DISTINCT b.[idfNode],c.[idfsSite], c.[strSiteID]
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN dbo.tflogAllBatchTestFiltered AS d2
ON c.[strSiteID] = d2.[strSiteID] AND c.[idfNode] = d2.[idfBatchTest]
WHERE d2.idfsSite IS NULL 
-- 4.

-- 5.

DROP TABLE [#SiteList]


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

