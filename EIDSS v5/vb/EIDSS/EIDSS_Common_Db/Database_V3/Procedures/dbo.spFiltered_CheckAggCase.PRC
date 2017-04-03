SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckAggCase]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckAggCase]
GO
/*
if Object_ID('tempdb..##NodeTable') is null
create table ##NodeTable(
	idfNode BIGINT  NOT NULL, 
	strNodeTable nvarchar(200) COLLATE database_default,
	intStatus int )

declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
exec spFiltered_CheckAggCase @ID

drop  table ##NodeTable
*/
CREATE      proc spFiltered_CheckAggCase (@event bigint)
AS


-- objects for investigation (add new!)
INSERT INTO [##NodeTable]
SELECT a.[idfObject],75420000000, 0
FROM [tauDataAuditDetailCreate] AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75420000000	--tlbAggrCase
AND b.idfNode IS NULL 

-- проверка необходимости изменений
UPDATE b 
SET b.intStatus = CASE WHEN c.[idfAggrCase] IS NULL THEN 2 /* проверено, изменения*/ ELSE 1 /*проверено, без изменений*/ END  
FROM [tlbAggrCase] AS a
INNER JOIN [tstSite] AS s
ON a.[idfEnteredByOffice] = s.[idfOffice]
INNER JOIN [fnFiltered_FullSiteList]() AS b2
ON s.[idfsSite] = b2.[parentSite] AND b2.[idfsSiteRelationType] = 10084001 --reported only
LEFT JOIN tflogAggrCaseFiltered AS c
ON a.[idfAggrCase] = c.[idfAggrCase] AND b2.[relatedSiteID] = c.[strSiteID]
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode AND b.intStatus = 0

-- реализация изменений
INSERT INTO [tflAggrCaseFiltered] ([idfAggrCase],[strSiteID],[idfsSite]) 
SELECT distinct a.[idfAggrCase],b2.[relatedSiteID], b2.[relatedSite]
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode 
INNER JOIN [tstSite] AS s
ON a.[idfEnteredByOffice] = s.[idfOffice]
INNER JOIN [fnFiltered_FullSiteList]() AS b2
ON s.[idfsSite] = b2.[parentSite]   AND b2.[idfsSiteRelationType] = 10084001 --reported only
LEFT JOIN tflAggrCaseFiltered AS c
ON a.[idfAggrCase] = c.[idfAggrCase] AND b2.[relatedSiteID] = c.[strSiteID]
LEFT JOIN tflogAggrCaseFiltered AS c2
ON a.[idfAggrCase] = c2.[idfAggrCase] AND b2.[relatedSiteID] = c2.[strSiteID]
WHERE c.[idfAggrCase] IS NULL and c2.[idfAggrCase] IS NULL 

INSERT INTO [tflogAggrCaseFiltered] ([idfAggrCase],[strSiteID],[idfsSite]) 
SELECT distinct  a.[idfAggrCase],b2.[relatedSiteID], b2.[relatedSite]
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode
INNER JOIN [tstSite] AS s
ON a.[idfEnteredByOffice] = s.[idfOffice]
INNER JOIN [fnFiltered_FullSiteList]() AS b2
ON s.[idfsSite] = b2.[parentSite]   AND b2.[idfsSiteRelationType] = 10084001 --reported only
LEFT JOIN tflogAggrCaseFiltered AS c2
ON a.[idfAggrCase] = c2.[idfAggrCase] AND b2.[relatedSiteID] = c2.[strSiteID]
WHERE c2.[idfAggrCase] IS NULL 

-- исправление тупиковых дочерних сущностей
-- Observation
INSERT INTO [tflObservationFitered] ([idfObservation],[strSiteID],[idfsSite]) 
SELECT distinct  c.[idfObservation],b2.[strSiteID],b2.[idfsSite]
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode 
INNER JOIN [tflogAggrCaseFiltered] AS b2
ON a.[idfAggrCase] = b2.[idfAggrCase]
INNER JOIN dbo.tlbObservation AS c
ON c.idfObservation = a.[idfCaseObservation]
LEFT JOIN [tflObservationFitered] AS c2
ON c.[idfObservation] = c2.[idfObservation] AND b2.[strSiteID] = c2.[strSiteID]
LEFT JOIN [tflogObservationFitered] AS c21
ON c.[idfObservation] = c21.[idfObservation] AND b2.[strSiteID] = c21.[strSiteID]
WHERE c2.[idfsSite] IS NULL and c21.[idfsSite] IS NULL 

INSERT INTO [tflogObservationFitered] ([idfObservation],[strSiteID],[idfsSite]) 
SELECT distinct  c.[idfObservation],b2.[strSiteID],b2.[idfsSite]
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode 
INNER JOIN [tflogAggrCaseFiltered] AS b2
ON a.[idfAggrCase] = b2.[idfAggrCase]
INNER JOIN dbo.tlbObservation AS c
ON c.idfObservation = a.[idfCaseObservation]
LEFT JOIN [tflogObservationFitered] AS c21
ON c.[idfObservation] = c21.[idfObservation] AND b2.[strSiteID] = c21.[strSiteID]
WHERE  c21.[idfsSite] IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfCaseObservation], 75640000000 /*tlbObservation*/, 1
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS rr
ON a.[idfCaseObservation] = rr.idfNode
WHERE rr.idfNode IS NULL and a.[idfCaseObservation] is not null

---

INSERT INTO [tflObservationFitered] ([idfObservation],[strSiteID],[idfsSite]) 
SELECT  distinct c.[idfObservation],b2.[strSiteID],b2.[idfsSite]
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode --AND b.intStatus = 2
INNER JOIN [tflogAggrCaseFiltered] AS b2
ON a.[idfAggrCase] = b2.[idfAggrCase]
INNER JOIN dbo.tlbObservation AS c
ON c.idfObservation = a.[idfDiagnosticObservation]
LEFT JOIN [tflObservationFitered] AS c2
ON c.[idfObservation] = c2.[idfObservation] AND b2.[strSiteID] = c2.[strSiteID]
LEFT JOIN [tflogObservationFitered] AS c21
ON c.[idfObservation] = c21.[idfObservation] AND b2.[strSiteID] = c21.[strSiteID]
WHERE c2.[idfsSite] IS NULL and c21.[idfsSite] IS NULL 

INSERT INTO [tflogObservationFitered] ([idfObservation],[strSiteID],[idfsSite]) 
SELECT  distinct c.[idfObservation],b2.[strSiteID],b2.[idfsSite]
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode --AND b.intStatus = 2
INNER JOIN [tflogAggrCaseFiltered] AS b2
ON a.[idfAggrCase] = b2.[idfAggrCase]
INNER JOIN dbo.tlbObservation AS c
ON c.idfObservation = a.[idfDiagnosticObservation]
LEFT JOIN [tflogObservationFitered] AS c21
ON c.[idfObservation] = c21.[idfObservation] AND b2.[strSiteID] = c21.[strSiteID]
WHERE  c21.[idfsSite] IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfDiagnosticObservation], 75640000000 /*tlbObservation*/, 1
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS rr
ON a.[idfDiagnosticObservation] = rr.idfNode
WHERE rr.idfNode IS NULL and a.[idfDiagnosticObservation] is not null
---

INSERT INTO [tflObservationFitered] ([idfObservation],[strSiteID],[idfsSite]) 
SELECT  distinct c.[idfObservation],b2.[strSiteID],b2.[idfsSite]
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode --AND b.intStatus = 2
INNER JOIN [tflogAggrCaseFiltered] AS b2
ON a.[idfAggrCase] = b2.[idfAggrCase]
INNER JOIN dbo.tlbObservation AS c
ON c.idfObservation = a.[idfProphylacticObservation]
LEFT JOIN [tflObservationFitered] AS c2
ON c.[idfObservation] = c2.[idfObservation] AND b2.[strSiteID] = c2.[strSiteID]
LEFT JOIN [tflogObservationFitered] AS c21
ON c.[idfObservation] = c21.[idfObservation] AND b2.[strSiteID] = c21.[strSiteID]
WHERE c2.[idfsSite] IS NULL and c21.[idfsSite] IS NULL 

INSERT INTO [tflogObservationFitered] ([idfObservation],[strSiteID],[idfsSite]) 
SELECT  distinct c.[idfObservation],b2.[strSiteID],b2.[idfsSite]
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode --AND b.intStatus = 2
INNER JOIN [tflogAggrCaseFiltered] AS b2
ON a.[idfAggrCase] = b2.[idfAggrCase]
INNER JOIN dbo.tlbObservation AS c
ON c.idfObservation = a.[idfProphylacticObservation]
LEFT JOIN [tflogObservationFitered] AS c21
ON c.[idfObservation] = c21.[idfObservation] AND b2.[strSiteID] = c21.[strSiteID]
WHERE  c21.[idfsSite] IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfProphylacticObservation], 75640000000 /*tlbObservation*/, 1
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS rr
ON a.[idfProphylacticObservation] = rr.idfNode
WHERE rr.idfNode IS NULL and a.[idfProphylacticObservation] is not null
---

INSERT INTO [tflObservationFitered] ([idfObservation],[strSiteID],[idfsSite]) 
SELECT  distinct c.[idfObservation],b2.[strSiteID],b2.[idfsSite]
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode --AND b.intStatus = 2
INNER JOIN [tflogAggrCaseFiltered] AS b2
ON a.[idfAggrCase] = b2.[idfAggrCase]
INNER JOIN dbo.tlbObservation AS c
ON c.idfObservation = a.[idfSanitaryObservation]
LEFT JOIN [tflObservationFitered] AS c2
ON c.[idfObservation] = c2.[idfObservation] AND b2.[strSiteID] = c2.[strSiteID]
LEFT JOIN [tflogObservationFitered] AS c21
ON c.[idfObservation] = c21.[idfObservation] AND b2.[strSiteID] = c21.[strSiteID]
WHERE c2.[idfsSite] IS NULL and c21.[idfsSite] IS NULL 

INSERT INTO [tflogObservationFitered] ([idfObservation],[strSiteID],[idfsSite]) 
SELECT  distinct c.[idfObservation],b2.[strSiteID],b2.[idfsSite]
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode --AND b.intStatus = 2
INNER JOIN [tflogAggrCaseFiltered] AS b2
ON a.[idfAggrCase] = b2.[idfAggrCase]
INNER JOIN dbo.tlbObservation AS c
ON c.idfObservation = a.[idfSanitaryObservation]
LEFT JOIN [tflogObservationFitered] AS c21
ON c.[idfObservation] = c21.[idfObservation] AND b2.[strSiteID] = c21.[strSiteID]
WHERE  c21.[idfsSite] IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfSanitaryObservation], 75640000000 /*tlbObservation*/, 1
FROM [tlbAggrCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfAggrCase] = b.idfNode AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS rr
ON a.[idfSanitaryObservation] = rr.idfNode
WHERE rr.idfNode IS NULL and a.[idfSanitaryObservation] is not null
---

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

