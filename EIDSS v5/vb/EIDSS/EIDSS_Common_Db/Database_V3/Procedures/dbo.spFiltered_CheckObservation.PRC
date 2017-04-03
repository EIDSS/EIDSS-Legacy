SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckObservation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckObservation]
GO
/*
if Object_ID('tempdb..##NodeTable') is null
create table ##NodeTable(
	idfNode BIGINT  NOT NULL, 
	strNodeTable nvarchar(200) COLLATE database_default,
	intStatus int )

declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
exec spFiltered_CheckObservation @ID

drop  table ##NodeTable
*/
CREATE      proc spFiltered_CheckObservation (@event bigint)
AS



-- objects for investigation (add new!)
INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfObject],75640000000, 0
FROM [tauDataAuditDetailCreate] AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75640000000	--tlbObservation
AND b.idfNode IS NULL 

-- проверка необходимости изменений
CREATE TABLE #SiteList (
	idfNode BIGINT  NOT NULL,
	idfsSite BIGINT,
	strSiteID VARCHAR(36) collate database_default
	)
	
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite], a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tauDataAuditDetailCreate] AS d1
ON a.[idfObservation] = d1.[idfObject]
INNER JOIN [tauDataAuditEvent] AS d2
ON d1.[idfDataAuditEvent] = d2.[idfDataAuditEvent]
INNER JOIN [tstUserTable] AS d3
ON d2.[idfUserID] = d3.[idfUserID]
INNER JOIN [tstSite] AS a2
ON d3.[idfsSite] = a2.[idfsSite]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0

-- BatchTest
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbBatchTest] AS b
ON a.[idfObservation] = b.[idfBatchTest]
INNER JOIN [tflAllBatchTestFiltered] AS a2
ON b.[idfBatchTest] = a2.[idfBatchTest]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbBatchTest] AS b
ON a.[idfObservation] = b.[idfBatchTest]
INNER JOIN [tflogAllBatchTestFiltered] AS a2
ON b.[idfBatchTest] = a2.[idfBatchTest]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

--HumanCase
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbHumanCase] AS b
ON a.[idfObservation] = b.[idfCSObservation]
INNER JOIN [tflCaseFiltered] AS a2
ON b.[idfHumanCase] = a2.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbHumanCase] AS b
ON a.[idfObservation] = b.[idfCSObservation]
INNER JOIN [tflogCaseFiltered] AS a2
ON b.[idfHumanCase] = a2.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbHumanCase] AS b
ON a.[idfObservation] = b.[idfEpiObservation]
INNER JOIN [tflCaseFiltered] AS a2
ON b.[idfHumanCase] = a2.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbHumanCase] AS b
ON a.[idfObservation] = b.[idfEpiObservation]
INNER JOIN [tflogCaseFiltered] AS a2
ON b.[idfHumanCase] = a2.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

--VetCase
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbVetCase] AS b
ON a.[idfObservation] = b.[idfObservation]
INNER JOIN [tflCaseFiltered] AS a2
ON b.[idfVetCase] = a2.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbVetCase] AS b
ON a.[idfObservation] = b.[idfObservation]
INNER JOIN [tflogCaseFiltered] AS a2
ON b.[idfVetCase] = a2.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

-- Testing
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbTesting] AS b
ON a.[idfObservation] = b.[idfObservation]
INNER JOIN [tlbContainer] AS b2
ON b.[idfContainer] = b2.[idfContainer]
INNER JOIN [tlbMaterial] AS b3
ON b2.[idfMaterial] = b3.[idfMaterial]
INNER JOIN [tlbParty] AS b4
ON b3.[idfParty] = b4.[idfParty]
INNER JOIN [tflPartyFiltered] AS a2
ON b4.[idfParty] = a2.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbTesting] AS b
ON a.[idfObservation] = b.[idfObservation]
INNER JOIN [tlbContainer] AS b2
ON b.[idfContainer] = b2.[idfContainer]
INNER JOIN [tlbMaterial] AS b3
ON b2.[idfMaterial] = b3.[idfMaterial]
INNER JOIN [tlbParty] AS b4
ON b3.[idfParty] = b4.[idfParty]
INNER JOIN [tflogPartyFiltered] AS a2
ON b4.[idfParty] = a2.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

-- Party
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbFarm] AS b
ON a.[idfObservation] = b.[idfObservation]
INNER JOIN [tflPartyFiltered] AS a2
ON b.[idfFarm] = a2.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbFarm] AS b
ON a.[idfObservation] = b.[idfObservation]
INNER JOIN [tflogPartyFiltered] AS a2
ON b.[idfFarm] = a2.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbSpecies] AS b
ON a.[idfObservation] = b.[idfObservation]
INNER JOIN [tflPartyFiltered] AS a2
ON b.[idfSpecies] = a2.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbSpecies] AS b
ON a.[idfObservation] = b.[idfObservation]
INNER JOIN [tflogPartyFiltered] AS a2
ON b.[idfSpecies] = a2.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbAnimal] AS b
ON a.[idfObservation] = b.[idfObservation]
INNER JOIN [tflPartyFiltered] AS a2
ON b.[idfAnimal] = a2.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbAnimal] AS b
ON a.[idfObservation] = b.[idfObservation]
INNER JOIN [tflogPartyFiltered] AS a2
ON b.[idfAnimal] = a2.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

--AggCase
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbAggrCase] AS b
ON a.[idfObservation] = b.[idfCaseObservation]
INNER JOIN [tflAggrCaseFiltered] AS a2
ON b.[idfAggrCase] = a2.[idfAggrCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbAggrCase] AS b
ON a.[idfObservation] = b.[idfCaseObservation]
INNER JOIN [tflogAggrCaseFiltered] AS a2
ON b.[idfAggrCase] = a2.[idfAggrCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbAggrCase] AS b
ON a.[idfObservation] = b.[idfDiagnosticObservation]
INNER JOIN [tflAggrCaseFiltered] AS a2
ON b.[idfAggrCase] = a2.[idfAggrCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbAggrCase] AS b
ON a.[idfObservation] = b.[idfDiagnosticObservation]
INNER JOIN [tflogAggrCaseFiltered] AS a2
ON b.[idfAggrCase] = a2.[idfAggrCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbAggrCase] AS b
ON a.[idfObservation] = b.[idfProphylacticObservation]
INNER JOIN [tflAggrCaseFiltered] AS a2
ON b.[idfAggrCase] = a2.[idfAggrCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, a2.[idfsSite],a2.[strSiteID]
FROM [tlbObservation] AS a
INNER JOIN [tlbAggrCase] AS b
ON a.[idfObservation] = b.[idfProphylacticObservation]
INNER JOIN [tflogAggrCaseFiltered] AS a2
ON b.[idfAggrCase] = a2.[idfAggrCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfObservation] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS d2
ON d.idfNode = d2.[idfNode] AND a2.[idfsSite] = d2.[idfsSite]
WHERE d2.[idfNode] IS NULL 

-- SiteRelationTable
INSERT INTO [#SiteList] 
SELECT distinct  a.[idfNode], b.[relatedSite], b.[relatedSiteID]
FROM #SiteList AS a
INNER JOIN dbo.[fnFiltered_FullSiteList]() AS b ON a.[idfsSite] = b.[parentSite] AND b.[idfsSiteRelationType] = 10084001 --reported only
LEFT JOIN #SiteList AS a2 ON a.[idfNode] = a2.[idfNode] AND a2.[idfsSite] = b.[relatedSite]
WHERE a2.[idfNode] IS NULL 

--сравнение
UPDATE b 
SET intStatus = 2 /* проверено, изменения*/
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN dbo.tflogObservationFitered AS d
ON c.[strSiteID] = d.[strSiteID] AND c.[idfNode] = d.idfObservation
WHERE b.intStatus = 0 
AND d.[idfsSite] IS NULL 

UPDATE b 
SET intStatus = 1 /*проверено, без изменений*/
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
WHERE b.intStatus = 0 

--внесение изменений
INSERT INTO [tflObservationFitered]([idfObservation],[idfsSite],[strSiteID])
SELECT a.[idfNode],
	   b2.[idfsSite],
	   b2.[strSiteID]
FROM #SiteList AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfNode] = b.idfNode AND b.intStatus = 2
INNER JOIN [tstSite] AS b2
ON a.[idfsSite] = b2.[idfsSite]
LEFT JOIN [tflObservationFitered] AS c
ON c.[strSiteID] = a.[strSiteID] AND c.[idfObservation] = a.[idfNode]
LEFT JOIN [tflogObservationFitered] AS c2
ON c2.[strSiteID] = a.[strSiteID] AND c2.[idfObservation] = a.[idfNode]
WHERE c.[idfsSite] IS NULL and c2.[idfsSite] IS NULL 

INSERT INTO [tflObservationFitered]([idfObservation],[idfsSite],[strSiteID])
SELECT a.[idfNode],
	   b2.[idfsSite],
	   b2.[strSiteID]
FROM #SiteList AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfNode] = b.idfNode AND b.intStatus = 2
INNER JOIN [tstSite] AS b2
ON a.[idfsSite] = b2.[idfsSite]
LEFT JOIN [tflogObservationFitered] AS c2
ON c2.[strSiteID] = a.[strSiteID] AND c2.[idfObservation] = a.[idfNode]
WHERE c2.[idfsSite] IS NULL 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

