SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckParty]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckParty]
GO
/*
if Object_ID('tempdb..##NodeTable') is null
create table ##NodeTable(
	idfNode BIGINT  NOT NULL, 
	strNodeTable nvarchar(200) COLLATE database_default,
	intStatus int )

declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
exec spFiltered_CheckParty @ID

drop  table ##NodeTable
*/
CREATE      proc spFiltered_CheckParty (@event bigint)
AS


-- 1.
-- objects for investigation (add new!)
INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfObject],75670000000, 0 --!!!!!!!!!!!!!!
FROM [tauDataAuditDetailCreate] AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75670000000  --tlbParty
AND b.idfNode IS NULL 

-- и еще добавить к фермам стада/группы/животных
INSERT INTO [##NodeTable]
SELECT DISTINCT a.idfHerd,75670000000, 0
FROM dbo.tlbHerd AS a
INNER JOIN [##NodeTable] AS a2
ON a2.idfNode = a.idfFarm
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.idfHerd
WHERE b.idfNode IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a.idfSpecies,75670000000, 0
FROM dbo.tlbSpecies AS a
INNER JOIN [##NodeTable] AS a2
ON a2.idfNode = a.idfHerd
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.idfSpecies
WHERE b.idfNode IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a.idfAnimal,75670000000, 0
FROM dbo.tlbAnimal AS a
INNER JOIN [##NodeTable] AS a2
ON a2.idfNode = a.idfSpecies
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.idfAnimal
WHERE b.idfNode IS NULL 

-- add human to farm (bug#1965 with root farm /non-root human)
INSERT INTO [##NodeTable]
SELECT DISTINCT a.idfHuman,75670000000, 0
FROM dbo.tlbFarm AS a
INNER JOIN [##NodeTable] AS a2
ON a2.idfNode = a.idfFarm
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.idfHuman
WHERE b.idfNode IS NULL 

-- 2.
CREATE TABLE #SiteList (
	idfNode BIGINT  NOT NULL,
	idfsSite BIGINT,
	strSiteID VARCHAR(36) collate database_default
	)

-- by site
INSERT INTO [#SiteList] (	[idfNode],	[idfsSite],	[strSiteID])
SELECT DISTINCT a.[idfParty],a2.[idfsSite], a2.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tstSite] AS a2
ON a.[idfsSite] = a2.[idfsSite]
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfParty] AND b.intStatus = 0

---- full access for list members
--INSERT INTO [#SiteList] (	[idfNode],	[idfsSite],	[strSiteID])
--SELECT a.idfParty, a2.idfsSite, a2.strSiteID
--FROM [tlbParty] AS a
--LEFT JOIN dbo.tlbContactedCasePerson AS aa
--ON a.idfParty = aa.[idfHuman]
--INNER JOIN [tstSite] AS a2 
--ON (a.idfCase IS NULL AND a.[idfMonitoringSession] IS NULL AND aa.[idfHuman] IS NULL)
--AND 
----	a2.[idfsSiteType] IN (10085004,10085006,10085007) AND 
--		a2.[intRowStatus] = 0
--INNER JOIN [##NodeTable] AS b
--ON b.idfNode = a.idfParty AND b.intStatus = 0

-- parent case
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tflCaseFiltered] AS b
ON a.[idfCase] = b.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tflogCaseFiltered] AS b
ON a.[idfCase] = b.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

-- contact case
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbContactedCasePerson] AS aa
ON a.[idfParty] = aa.[idfHuman]
INNER JOIN [tflCaseFiltered] AS b
ON aa.[idfHumanCase] = b.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbContactedCasePerson] AS aa
ON a.[idfParty] = aa.[idfHuman]
INNER JOIN [tflogCaseFiltered] AS b
ON aa.[idfHumanCase] = b.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

-- parent session
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tflMonitoringSessionFiltered] AS b
ON a.[idfMonitoringSession] = b.[idfMonitoringSession]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tflogMonitoringSessionFiltered] AS b
ON a.[idfMonitoringSession] = b.[idfMonitoringSession]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

-- for ROOT party by CASE party
-- раньше чем parent party  поскольку у стад/групп/животных не указывается ROOT, даже если он есть
-- и значения должны быть передраны с родительской фермы
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbParty] AS b1
ON a.[idfParty] = b1.[idfRootParty]
INNER JOIN [tflPartyFiltered] AS b
ON b1.[idfParty] = b.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbParty] AS b1
ON a.[idfParty] = b1.[idfRootParty]
INNER JOIN [tflogPartyFiltered] AS b
ON b1.[idfParty] = b.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbParty] AS b1
ON a.[idfParty] = b1.[idfRootParty]
INNER JOIN [#SiteList] AS b
ON b1.[idfParty] = b.[idfNode]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 


-- parent party
-- Herd <- Farm
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbHerd] AS b1
ON a.[idfParty] = b1.[idfHerd]
INNER JOIN [tflPartyFiltered] AS b
ON b1.[idfFarm] = b.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbHerd] AS b1
ON a.[idfParty] = b1.[idfHerd]
INNER JOIN [tflogPartyFiltered] AS b
ON b1.[idfFarm] = b.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbHerd] AS b1
ON a.[idfParty] = b1.[idfHerd]
INNER JOIN [#SiteList] AS b
ON b1.[idfFarm] = b.[idfNode]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

-- Human (farm owner) <- Farm
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbFarm] AS b1
ON a.[idfParty] = b1.[idfHuman]
INNER JOIN [tflPartyFiltered] AS b
ON b1.[idfFarm] = b.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbFarm] AS b1
ON a.[idfParty] = b1.[idfHuman]
INNER JOIN [tflogPartyFiltered] AS b
ON b1.[idfFarm] = b.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbFarm] AS b1
ON a.[idfParty] = b1.[idfHuman]
INNER JOIN [#SiteList] AS b
ON b1.[idfFarm] = b.[idfNode]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

-- Species <- Herd
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbSpecies] AS b1
ON a.[idfParty] = b1.[idfSpecies]
INNER JOIN [tflPartyFiltered] AS b
ON b1.[idfHerd] = b.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbSpecies] AS b1
ON a.[idfParty] = b1.[idfSpecies]
INNER JOIN [tflogPartyFiltered] AS b
ON b1.[idfHerd] = b.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbSpecies] AS b1
ON a.[idfParty] = b1.[idfSpecies]
INNER JOIN [#SiteList] AS b
ON b1.[idfHerd] = b.[idfNode]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

-- Animale <- Species
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbAnimal] AS b1
ON a.[idfParty] = b1.[idfAnimal]
INNER JOIN [tflPartyFiltered] AS b
ON b1.[idfSpecies] = b.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbAnimal] AS b1
ON a.[idfParty] = b1.[idfAnimal]
INNER JOIN [tflogPartyFiltered] AS b
ON b1.[idfSpecies] = b.[idfParty]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b.[idfsSite], b.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbAnimal] AS b1
ON a.[idfParty] = b1.[idfAnimal]
INNER JOIN [#SiteList] AS b
ON b1.[idfSpecies] = b.[idfNode]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfParty] AND d.intStatus = 0
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
LEFT JOIN tflogPartyFiltered AS d
ON c.[strSiteID] = d.[strSiteID] AND c.[idfNode] = d.[idfParty]
WHERE b.intStatus = 0 
AND d.[idfsSite] IS NULL 

UPDATE b 
SET intStatus = 1 /*проверено, без изменений*/
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
WHERE b.intStatus = 0 

INSERT INTO [tflPartyFiltered]([idfParty],[idfsSite],[strSiteID])
SELECT DISTINCT b.[idfNode],c.[idfsSite], c.[strSiteID]
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflPartyFiltered] AS c2 
ON b.[idfNode] = c2.[idfParty] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogPartyFiltered] AS c21 
ON b.[idfNode] = c21.[idfParty] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflogPartyFiltered]([idfParty],[idfsSite],[strSiteID])
SELECT DISTINCT b.[idfNode],c.[idfsSite], c.[strSiteID]
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogPartyFiltered] AS c21 
ON b.[idfNode] = c21.[idfParty] AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL 

-- 4.
-- BatchTest
INSERT INTO [##NodeTable]
SELECT DISTINCT b3.[idfBatchTest], 75480000000 /*tlbBatchTest*/, 0--CASE WHEN b.intStatus = 2 THEN 0 ELSE 1 END 
FROM [tlbParty] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfParty] = b.idfNode AND b.intStatus = 2
INNER JOIN [tlbMaterial] AS b1
ON a.[idfParty] = b1.[idfParty]
INNER JOIN [tlbContainer] AS b2
ON b1.[idfMaterial] = b2.[idfMaterial]
INNER JOIN [tlbTesting] AS b3
ON b2.[idfContainer] = b3.[idfContainer]
LEFT JOIN [##NodeTable] AS d
ON d.idfNode = b3.[idfBatchTest]
WHERE d.idfNode IS NULL 
AND b3.[idfBatchTest] IS NOT NULL 

-- ExternalBatchTest
INSERT INTO [##NodeTable]
SELECT DISTINCT b3.idfExtBatchTest, 729200000000 /*tlbExtBatchTest*/,0-- CASE WHEN b.intStatus = 2 THEN 0 ELSE 1 END 
FROM [tlbParty] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfParty] = b.idfNode AND b.intStatus = 2
INNER JOIN [tlbMaterial] AS b1
ON a.[idfParty] = b1.[idfParty]
INNER JOIN [tlbContainer] AS b2
ON b1.[idfMaterial] = b2.[idfMaterial]
INNER JOIN [tlbTesting] AS b3
ON b2.[idfContainer] = b3.[idfContainer]
LEFT JOIN [##NodeTable] AS d
ON d.idfNode = b3.[idfBatchTest]
WHERE d.idfNode IS NULL 
AND b3.idfExtBatchTest IS NOT NULL 

-- 5.
-- GeoLocation
INSERT INTO [tflGeoLocationFiltered]([idfGeoLocation],[idfsSite],[strSiteID])
SELECT DISTINCT a2.[idfGeoLocation], c.[idfsSite],c.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbHuman] AS a1
ON a.[idfParty] = a1.[idfHuman]
INNER JOIN [tlbGeoLocation] AS a2
ON a1.[idfCurrentResidenceAddress] = a2.[idfGeoLocation] 
	OR a1.[idfEmployerAddress] = a2.[idfGeoLocation]
	OR a1.[idfRegistrationAddress] = a2.[idfGeoLocation]
INNER JOIN [##NodeTable] AS b
ON a.[idfParty] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflGeoLocationFiltered] AS c2 
ON a2.[idfGeoLocation] = c2.[idfGeoLocation] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogGeoLocationFiltered] AS c21 
ON a2.[idfGeoLocation] = c21.[idfGeoLocation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflogGeoLocationFiltered]([idfGeoLocation],[idfsSite],[strSiteID])
SELECT DISTINCT a2.[idfGeoLocation], c.[idfsSite],c.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbHuman] AS a1
ON a.[idfParty] = a1.[idfHuman]
INNER JOIN [tlbGeoLocation] AS a2
ON a1.[idfCurrentResidenceAddress] = a2.[idfGeoLocation] 
	OR a1.[idfEmployerAddress] = a2.[idfGeoLocation]
	OR a1.[idfRegistrationAddress] = a2.[idfGeoLocation]
INNER JOIN [##NodeTable] AS b
ON a.[idfParty] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogGeoLocationFiltered] AS c21 
ON a2.[idfGeoLocation] = c21.[idfGeoLocation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a2.[idfGeoLocation], 75580000000 /*tlbGeoLocation*/, 1
FROM [tlbParty] AS a
INNER JOIN [tlbHuman] AS a1
ON a.[idfParty] = a1.[idfHuman]
INNER JOIN [tlbGeoLocation] AS a2
ON a1.[idfCurrentResidenceAddress] = a2.[idfGeoLocation] 
	OR a1.[idfEmployerAddress] = a2.[idfGeoLocation]
	OR a1.[idfRegistrationAddress] = a2.[idfGeoLocation]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode --AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS rr
ON a2.[idfGeoLocation] = rr.idfNode
WHERE rr.idfNode IS NULL 

INSERT INTO [tflGeoLocationFiltered]([idfGeoLocation],[idfsSite],[strSiteID])
SELECT DISTINCT a2.[idfGeoLocation], c.[idfsSite],c.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbFarm] AS a1
ON a.[idfParty] = a1.[idfFarm]
INNER JOIN [tlbGeoLocation] AS a2
ON a1.[idfFarmAddress] = a2.[idfGeoLocation]
	OR a1.[idfFarmLocation] = a2.[idfGeoLocation]
INNER JOIN [##NodeTable] AS b
ON a.[idfParty] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflGeoLocationFiltered] AS c2 
ON a2.[idfGeoLocation] = c2.[idfGeoLocation] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogGeoLocationFiltered] AS c21 
ON a2.[idfGeoLocation] = c21.[idfGeoLocation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflGeoLocationFiltered]([idfGeoLocation],[idfsSite],[strSiteID])
SELECT DISTINCT a2.[idfGeoLocation], c.[idfsSite],c.[strSiteID]
FROM [tlbParty] AS a
INNER JOIN [tlbFarm] AS a1
ON a.[idfParty] = a1.[idfFarm]
INNER JOIN [tlbGeoLocation] AS a2
ON a1.[idfFarmAddress] = a2.[idfGeoLocation]
	OR a1.[idfFarmLocation] = a2.[idfGeoLocation]
INNER JOIN [##NodeTable] AS b
ON a.[idfParty] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogGeoLocationFiltered] AS c21 
ON a2.[idfGeoLocation] = c21.[idfGeoLocation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a2.[idfGeoLocation], 75580000000 /*tlbGeoLocation*/, 1
FROM [tlbParty] AS a
INNER JOIN [tlbFarm] AS a1
ON a.[idfParty] = a1.[idfFarm]
INNER JOIN [tlbGeoLocation] AS a2
ON a1.[idfFarmAddress] = a2.[idfGeoLocation]
	OR a1.[idfFarmLocation] = a2.[idfGeoLocation]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode --AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS rr
ON a2.[idfGeoLocation] = rr.idfNode
WHERE rr.idfNode IS NULL 

-- Observation
INSERT INTO [tflObservationFitered]([idfObservation],[idfsSite],[strSiteID])
SELECT d.[idfObservation], c.[idfsSite],c.[strSiteID]
FROM [tlbParty] AS a
LEFT JOIN [tlbFarm] AS a1
ON a.[idfParty] = a1.[idfFarm]
LEFT JOIN [tlbAnimal] AS a2
ON a.[idfParty] = a2.[idfAnimal]
LEFT JOIN [tlbSpecies] AS a3
ON a.[idfParty] = a3.[idfSpecies]
INNER JOIN [tlbObservation] AS d
ON a3.[idfObservation] = d.[idfObservation]
	OR a2.[idfObservation] = d.[idfObservation]
	OR a1.[idfObservation] = d.[idfObservation]
INNER JOIN [##NodeTable] AS b
ON a.[idfParty] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflObservationFitered] AS c2 
ON d.[idfObservation] = c2.[idfObservation] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogObservationFitered] AS c21 
ON d.[idfObservation] = c21.[idfObservation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflogObservationFitered]([idfObservation],[idfsSite],[strSiteID])
SELECT d.[idfObservation], c.[idfsSite],c.[strSiteID]
FROM [tlbParty] AS a
LEFT JOIN [tlbFarm] AS a1
ON a.[idfParty] = a1.[idfFarm]
LEFT JOIN [tlbAnimal] AS a2
ON a.[idfParty] = a2.[idfAnimal]
LEFT JOIN [tlbSpecies] AS a3
ON a.[idfParty] = a3.[idfSpecies]
INNER JOIN [tlbObservation] AS d
ON a3.[idfObservation] = d.[idfObservation]
	OR a2.[idfObservation] = d.[idfObservation]
	OR a1.[idfObservation] = d.[idfObservation]
INNER JOIN [##NodeTable] AS b
ON a.[idfParty] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogObservationFitered] AS c21 
ON d.[idfObservation] = c21.[idfObservation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT d.[idfObservation], 75640000000 /*tlbObservation*/, 1
FROM [tlbParty] AS a
LEFT JOIN [tlbFarm] AS a1
ON a.[idfParty] = a1.[idfFarm]
LEFT JOIN [tlbAnimal] AS a2
ON a.[idfParty] = a2.[idfAnimal]
LEFT JOIN [tlbSpecies] AS a3
ON a.[idfParty] = a3.[idfSpecies]
INNER JOIN [tlbObservation] AS d
ON a3.[idfObservation] = d.[idfObservation]
	OR a2.[idfObservation] = d.[idfObservation]
	OR a1.[idfObservation] = d.[idfObservation]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode --AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS rr
ON d.[idfObservation] = rr.idfNode
WHERE rr.idfNode IS NULL 

DROP TABLE [#SiteList]


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

