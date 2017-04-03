SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckVetCase]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckVetCase]
GO
/*
if Object_ID('tempdb..##NodeTable') is null
create table ##NodeTable(
	idfNode BIGINT  NOT NULL, 
	strNodeTable nvarchar(200) COLLATE database_default,
	intStatus int )

declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
exec spFiltered_CheckVetCase @ID

drop  table ##NodeTable
*/
CREATE      proc spFiltered_CheckVetCase (@event bigint)
AS

-- 1.
-- objects for investigation (add new!)
INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfObject],75800000000, 0 --!!!!!!!!!!!!!!
FROM [tauDataAuditDetailCreate] AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75800000000  --tlbVetCase
AND b.idfNode IS NULL 

-- изменяемый кейс
INSERT INTO [##NodeTable]
SELECT a1.[idfVetCase],75800000000, 0
FROM [tauDataAuditEvent] AS a
INNER JOIN [tlbVetCase] AS a1
ON a.[idfMainObject] = a1.[idfVetCase]
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a1.[idfVetCase]
WHERE a.[idfDataAuditEvent] = @event 
AND b.idfNode IS NULL 

-- 2.
CREATE TABLE #SiteList (
	idfNode BIGINT  NOT NULL,
	idfsSite BIGINT,
	strSiteID VARCHAR(36) collate database_default
	)

-- by site
INSERT INTO [#SiteList] (	[idfNode],	[idfsSite],	[strSiteID])
SELECT a.idfVetCase, a2.[idfsSite], a2.[strSiteID]
FROM [tlbVetCase] AS a 
INNER JOIN [tstSite] AS a2
ON a.[idfsSite] = a2.[idfsSite]
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.idfVetCase AND b.intStatus = 0

-- by Rayon
INSERT INTO [#SiteList] (	[idfNode],	[idfsSite],	[strSiteID])
SELECT DISTINCT a.[idfVetCase], f.idfsSite, f.strSiteID
FROM [tlbVetCase] AS a
INNER JOIN [tlbCase] AS a1
ON a.[idfVetCase] = a1.[idfCase] 
INNER JOIN [tlbParty] AS c
ON a1.[idfCase] = c.[idfCase]
INNER JOIN [tlbFarm] AS d
ON c.[idfParty] = d.[idfFarm]
LEFT JOIN [tlbGeoLocation] AS e
ON d.[idfFarmAddress] = e.idfGeoLocation
LEFT JOIN [tlbGeoLocation] AS e1
ON d.[idfFarmLocation] = e1.[idfGeoLocation]
INNER JOIN fnFiltered_RayonOrganizationList() AS f
ON ISNULL(e.idfsRayon, e1.[idfsRayon]) = f.idfsRayon 
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfVetCase] AND b.intStatus = 0
LEFT JOIN [#SiteList] AS g
ON b.idfNode = g.[idfNode] AND f.idfsSite = g.[idfsSite]
WHERE g.[idfNode] IS NULL 

-- parent transfer out
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b6.[idfsSite], b6.[strSiteID]
FROM [tlbVetCase] AS a
INNER JOIN [tlbParty] AS b1
ON a.[idfVetCase] = b1.[idfCase]
INNER JOIN [tlbMaterial] AS b2
ON b1.[idfParty] = b2.[idfParty]
INNER JOIN [tlbContainer] AS b3
ON b2.[idfMaterial] = b3.[idfMaterial]
INNER JOIN [tlbTransferOutContainerList] AS b4
ON b3.[idfContainer] = b4.[idfContainer]
INNER JOIN [tlbTransferOUT] AS b5
ON b4.[idfTransferOut] = b5.[idfTransferOut]
INNER JOIN [tstSite] AS b6 
ON b5.[idfSendToOffice] = b6.[idfOffice] AND b6.[intRowStatus] = 0
LEFT JOIN [#SiteList] AS c
ON b6.[idfsSite] = c.[idfsSite] AND a.[idfVetCase] = c.[idfNode]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfVetCase] AND d.intStatus = 0
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b6.[idfsSite], b6.[strSiteID]
FROM [tlbVetCase] AS a
INNER JOIN [tlbParty] AS b1
ON a.[idfVetCase] = b1.[idfCase]
INNER JOIN [tlbMaterial] AS b2
ON b1.[idfParty] = b2.[idfParty]
INNER JOIN [tlbContainer] AS b3
ON b2.[idfMaterial] = b3.[idfMaterial]
INNER JOIN [tlbTransferOutContainerList] AS b4
ON b3.[idfContainer] = b4.[idfContainer]
INNER JOIN [tlbTransferOUT] AS b5
ON b4.[idfTransferOut] = b5.[idfTransferOut]
INNER JOIN [tstSite] AS b6 
ON b5.[idfSendFromOffice] = b6.[idfOffice] AND b6.[intRowStatus] = 0
LEFT JOIN [#SiteList] AS c
ON b6.[idfsSite] = c.[idfsSite] AND a.[idfVetCase] = c.[idfNode]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfVetCase] AND d.intStatus = 0
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
LEFT JOIN dbo.tflogCaseFiltered AS d
ON c.[strSiteID] = d.[strSiteID] AND c.[idfNode] = d.[idfCase]
WHERE b.intStatus = 0 
AND d.[idfsSite] IS NULL 

UPDATE b 
SET intStatus = 1 /*проверено, без изменений*/
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
WHERE b.intStatus = 0 

INSERT INTO [tflCaseFiltered]([idfCase],[idfsSite],[strSiteID])
SELECT DISTINCT b.[idfNode],c.[idfsSite], c.[strSiteID]
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflCaseFiltered] AS c2 
ON b.[idfNode] = c2.idfCase AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogCaseFiltered] AS c21 
ON b.[idfNode] = c21.idfCase AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflogCaseFiltered]([idfCase],[idfsSite],[strSiteID])
SELECT DISTINCT b.[idfNode],c.[idfsSite], c.[strSiteID]
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogCaseFiltered] AS c21 
ON b.[idfNode] = c21.idfCase AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL 

-- 4.
-- Party
INSERT INTO [##NodeTable]
SELECT DISTINCT c.[idfParty], 75670000000 /*tlbParty*/, 0--CASE WHEN b.intStatus = 2 THEN 0 ELSE 1 END 
FROM [tlbVetCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfVetCase] = b.idfNode AND b.intStatus = 2
INNER JOIN [tlbParty] AS c 
ON a.[idfVetCase] = c.[idfCase]
LEFT JOIN [##NodeTable] AS d
ON d.idfNode = c.[idfParty]
WHERE d.idfNode IS NULL 

-- ROOT Party
INSERT INTO [##NodeTable]
SELECT DISTINCT c.[idfRootParty], 75670000000 /*tlbParty*/, 0--CASE WHEN b.intStatus = 2 THEN 0 ELSE 1 END 
FROM [tlbVetCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfVetCase] = b.idfNode AND b.intStatus = 2
INNER JOIN [tlbParty] AS c 
ON a.[idfVetCase] = c.[idfCase]
LEFT JOIN [##NodeTable] AS d
ON d.idfNode = c.[idfRootParty]
WHERE d.idfNode IS NULL AND  c.[idfRootParty] IS NOT NULL

-- Root Farm -> Owner Party
INSERT INTO [##NodeTable]
SELECT DISTINCT f2.idfHuman, 75670000000 /*tlbParty*/, 0--CASE WHEN b.intStatus = 2 THEN 0 ELSE 1 END 
FROM [tlbVetCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfVetCase] = b.idfNode AND b.intStatus = 2
INNER JOIN [tlbParty] AS c 
ON a.[idfVetCase] = c.[idfCase]
INNER JOIN [tlbParty] AS c2 -- ROOT
ON c.idfRootParty = c2.idfParty
INNER JOIN dbo.tlbFarm AS f2 -- ROOT FARM
ON c2.idfParty = f2.idfFarm
LEFT JOIN [##NodeTable] AS d
ON d.idfNode = f2.idfHuman -- root farm owner 1) has no connection to case and 2) is not a root of case farm owner
WHERE d.idfNode IS NULL AND  f2.idfHuman IS NOT NULL

-- Outbreak
INSERT INTO [##NodeTable]
SELECT DISTINCT aa.[idfOutbreak], 75660000000 /*tlbOutbreak*/,0-- CASE WHEN b.intStatus = 2 THEN 0 ELSE 1 END 
FROM [tlbVetCase] AS a
INNER JOIN [tlbCase] AS aa
ON a.[idfVetCase] = aa.[idfCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfVetCase] = b.idfNode AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS d
ON d.idfNode = aa.[idfOutbreak]
WHERE d.idfNode IS NULL 
AND aa.[idfOutbreak] IS NOT NULL 

-- 5.
-- Observation
INSERT INTO [tflObservationFitered]([idfObservation],[idfsSite],[strSiteID])
SELECT DISTINCT a1.[idfObservation], c.[idfsSite],c.[strSiteID]
FROM [tlbCase] AS a
INNER JOIN [tlbVetCase] AS a1
ON a.[idfCase] = a1.[idfVetCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflObservationFitered] AS c2 
ON a1.[idfObservation] = c2.[idfObservation] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogObservationFitered] AS c21 
ON a1.[idfObservation] = c21.[idfObservation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL

INSERT INTO [tflogObservationFitered]([idfObservation],[idfsSite],[strSiteID])
SELECT DISTINCT a1.[idfObservation], c.[idfsSite],c.[strSiteID]
FROM [tlbCase] AS a
INNER JOIN [tlbVetCase] AS a1
ON a.[idfCase] = a1.[idfVetCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogObservationFitered] AS c21 
ON a1.[idfObservation] = c21.[idfObservation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL

INSERT INTO [##NodeTable]
SELECT DISTINCT a1.[idfObservation], 75640000000 /*tlbObservation*/, 1
FROM [tlbCase] AS a
INNER JOIN [tlbVetCase] AS a1
ON a.[idfCase] = a1.[idfVetCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode --AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS rr
ON a1.[idfObservation] = rr.idfNode
WHERE rr.idfNode IS NULL 

-- Notification
INSERT INTO [tflNotificationFiltered] (	[idfNotification],[idfsSite],[strSiteID]) 
SELECT DISTINCT a1.[idfNotification], c.[idfsSite],c.[strSiteID]
FROM [tlbCase] AS a
INNER JOIN [tstNotification] AS a1
ON a.[idfCase] = a1.[idfNotificationObject]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflNotificationFiltered] AS c2 
ON a1.[idfNotification] = c2.[idfNotification] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogNotificationFiltered] AS c21 
ON a1.[idfNotification] = c21.[idfNotification] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflogNotificationFiltered] (	[idfNotification],[idfsSite],[strSiteID]) 
SELECT DISTINCT a1.[idfNotification], c.[idfsSite],c.[strSiteID]
FROM [tlbCase] AS a
INNER JOIN [tstNotification] AS a1
ON a.[idfCase] = a1.[idfNotificationObject]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogNotificationFiltered] AS c21 
ON a1.[idfNotification] = c21.[idfNotification] AND c.[idfsSite] = c21.[idfsSite]
WHERE  c21.idfsSite IS NULL 

DROP TABLE [#SiteList]

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

