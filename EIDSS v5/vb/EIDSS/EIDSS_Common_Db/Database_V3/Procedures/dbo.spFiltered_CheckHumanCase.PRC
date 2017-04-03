SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckHumanCase]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckHumanCase]
GO
/*
if Object_ID('tempdb..##NodeTable') is null
create table ##NodeTable(
	idfNode BIGINT  NOT NULL, 
	strNodeTable nvarchar(200) COLLATE database_default,
	intStatus int )

declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
exec spFiltered_CheckHumanCase @ID

drop  table ##NodeTable
*/
CREATE      proc spFiltered_CheckHumanCase (@event bigint)
AS

--1.
-- objects for investigation (add new!)
-- созданный кейс
INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfObject],75610000000, 0 --!!!!!!!!!!!!!!
FROM [tauDataAuditDetailCreate] AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75610000000 --tlbHumanCase
AND b.idfNode IS NULL 

-- дедубликация
INSERT INTO [##NodeTable]
SELECT DISTINCT a1.[idfDeduplicationResultCase],75610000000, 0 --!!!!!!!!!!!!!!
FROM [tauDataAuditDetailUpdate] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfObject] = a1.[idfHumanCase]
INNER JOIN [tlbHumanCase] AS a2
ON a2.[idfHumanCase] = a1.[idfDeduplicationResultCase]
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a1.[idfDeduplicationResultCase]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75610000000 --tlbHumanCase
AND a.[idfColumn] = 855730000000 --idfDeduplicationResultCase
AND b.idfNode IS NULL 

-- изменяемый кейс
INSERT INTO [##NodeTable]
SELECT a1.[idfHumanCase],75610000000, 0
FROM [tauDataAuditEvent] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfMainObject] = a1.[idfHumanCase]
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a1.[idfHumanCase]
WHERE a.[idfDataAuditEvent] = @event 
AND b.idfNode IS NULL 

-- 2.
CREATE TABLE #SiteList (
	idfNode BIGINT  NOT NULL,
	idfsSite BIGINT,
	strSiteID VARCHAR(36) collate database_default
	)

-- by site
--Здесь используем только сайт создания, таблицу с сайтами переноса прикладываем в конце
INSERT INTO [#SiteList] (	[idfNode],	[idfsSite],	[strSiteID])
SELECT DISTINCT a.idfHumanCase, a2.[idfsSite], a2.[strSiteID]
FROM [tlbHumanCase] AS a
INNER JOIN [tlbCase] AS a1
ON a.[idfHumanCase] = a1.[idfCase] 
INNER JOIN [tstSite] AS a2
ON a1.[idfsSite] = a2.[idfsSite]
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.idfHumanCase AND b.intStatus = 0

-- by Rayon
INSERT INTO [#SiteList] (	[idfNode],	[idfsSite],	[strSiteID])
SELECT DISTINCT a.idfHumanCase, f.idfsSite, f.strSiteID
FROM [tlbHumanCase] AS a
INNER JOIN [tlbCase] AS a1
ON a.[idfHumanCase] = a1.[idfCase] 
INNER JOIN [tlbParty] AS c
ON a1.[idfCase] = c.[idfCase]
INNER JOIN [tlbHuman] AS d
ON c.[idfParty] = d.[idfHuman]
INNER JOIN [tlbGeoLocation] AS e
ON d.[idfCurrentResidenceAddress] = e.idfGeoLocation
INNER JOIN fnFiltered_RayonOrganizationList() AS f
ON e.idfsRayon = f.idfsRayon 
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.idfHumanCase AND b.intStatus = 0
LEFT JOIN [#SiteList] AS g
ON a.[idfHumanCase] = g.[idfNode] AND f.idfsSite = g.[idfsSite]
WHERE g.[idfNode] IS NULL 

-- parent transfer out
-- [tlbTransferOUT].[idfSendToOffice]
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, sb5.[idfsSite], sb5.[strSiteID]
FROM [tlbHumanCase] AS a
INNER JOIN [tlbParty] AS b1
ON a.[idfHumanCase] = b1.[idfCase]
INNER JOIN [tlbMaterial] AS b2
ON b1.[idfParty] = b2.[idfParty]
INNER JOIN [tlbContainer] AS b3
ON b2.[idfMaterial] = b3.[idfMaterial]
INNER JOIN [tlbTransferOutContainerList] AS b4
ON b3.[idfContainer] = b4.[idfContainer]
INNER JOIN [tlbTransferOUT] AS b5
ON b4.[idfTransferOut] = b5.[idfTransferOut]
-- представленная ниже идея не верна! А вдруг список еще не заполнен?
--INNER JOIN [tflTransferOutFiltered] AS b6
--ON b5.[idfTransferOut] = b6.[idfTransferOut]
INNER JOIN [tstSite] AS sb5 
ON b5.[idfSendToOffice] = sb5.[idfOffice] AND sb5.[intRowStatus] = 0
LEFT JOIN [#SiteList] AS c
ON sb5.[idfsSite] = c.[idfsSite] AND a.[idfHumanCase] = c.[idfNode]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfHumanCase] AND d.intStatus = 0
WHERE c.[idfNode] IS NULL 

--[tlbTransferOUT].[idfSendFromOffice]
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, sb5.[idfsSite], sb5.[strSiteID]
FROM [tlbHumanCase] AS a
INNER JOIN [tlbParty] AS b1
ON a.[idfHumanCase] = b1.[idfCase]
INNER JOIN [tlbMaterial] AS b2
ON b1.[idfParty] = b2.[idfParty]
INNER JOIN [tlbContainer] AS b3
ON b2.[idfMaterial] = b3.[idfMaterial]
INNER JOIN [tlbTransferOutContainerList] AS b4
ON b3.[idfContainer] = b4.[idfContainer]
INNER JOIN [tlbTransferOUT] AS b5
ON b4.[idfTransferOut] = b5.[idfTransferOut]
INNER JOIN [tstSite] AS sb5 
ON b5.[idfSendFromOffice] = sb5.[idfOffice] AND sb5.[intRowStatus] = 0
LEFT JOIN [#SiteList] AS c
ON sb5.[idfsSite] = c.[idfsSite] AND a.[idfHumanCase] = c.[idfNode]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfHumanCase] AND d.intStatus = 0
WHERE c.[idfNode] IS NULL 

-- parent by dedublication 
-- dedublication by [tflogCaseFiltered]
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b6.[idfsSite], b6.[strSiteID]
FROM [tlbHumanCase] AS a
INNER JOIN [tlbHumanCase] AS b1
ON a.[idfHumanCase] = b1.[idfDeduplicationResultCase]
INNER JOIN [tflogCaseFiltered] AS b6
ON b1.[idfHumanCase] = b6.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfHumanCase] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b6.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

-----------------by [tflogCaseFiltered]
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b6.[idfsSite], b6.[strSiteID]
FROM [tlbHumanCase] AS a
INNER JOIN [tlbHumanCase] AS b1
ON a.[idfHumanCase] = b1.[idfDeduplicationResultCase]
INNER JOIN [tflCaseFiltered] AS b6
ON b1.[idfHumanCase] = b6.[idfCase]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfHumanCase] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b6.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

-- dedublication by [idfsSite]
INSERT INTO [#SiteList] 
SELECT DISTINCT d.idfNode, b6.[idfsSite], b6.[strSiteID]
FROM [tlbHumanCase] AS a
INNER JOIN [tlbHumanCase] AS b1
ON a.[idfHumanCase] = b1.[idfDeduplicationResultCase]
INNER JOIN [tlbCase] AS b2
ON b1.[idfHumanCase] = b2.[idfCase]
INNER JOIN [tstSite] AS b6
ON b2.[idfsSite] = b6.[idfsSite]
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfHumanCase] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON b6.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

-- organizations
INSERT INTO [#SiteList] 
SELECT d.idfNode, s.[idfsSite], s.[strSiteID]
FROM [tlbHumanCase] AS a
INNER JOIN [tstSite] AS s
ON a.[idfSentByOffice] = s.[idfOffice] AND s.[intRowStatus] = 0
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfHumanCase] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON s.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT d.idfNode, s.[idfsSite], s.[strSiteID]
FROM [tlbHumanCase] AS a
INNER JOIN [tstSite] AS s
ON a.[idfReceivedByOffice] = s.[idfOffice] AND s.[intRowStatus] = 0
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfHumanCase] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON s.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT d.idfNode, s.[idfsSite], s.[strSiteID]
FROM [tlbHumanCase] AS a
INNER JOIN [tstSite] AS s
ON a.[idfInvestigatedByOffice] = s.[idfOffice] AND s.[intRowStatus] = 0
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfHumanCase] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON s.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
WHERE c.[idfNode] IS NULL 

INSERT INTO [#SiteList] 
SELECT d.idfNode, s.[idfsSite], s.[strSiteID]
FROM [tlbHumanCase] AS a
INNER JOIN [tlbParty] AS a1
ON a.[idfHumanCase] = a1.[idfCase]
INNER JOIN [tlbMaterial] AS a2
ON a1.[idfParty] = a2.[idfParty]
INNER JOIN [tstSite] AS s
ON a2.[idfFieldCollectedByOffice] = s.[idfOffice] AND s.[intRowStatus] = 0
INNER JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfHumanCase] AND d.intStatus = 0
LEFT JOIN [#SiteList] AS c
ON s.[idfsSite] = c.[idfsSite] AND d.idfNode = c.[idfNode]
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
WHERE c21.idfsSite IS NULL and c2.idfsSite IS NULL 

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
SELECT DISTINCT c.[idfParty], 75670000000 /*tlbParty*/, 0 --CASE WHEN b.intStatus = 2 THEN 0 ELSE 1 END 
FROM [tlbCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode --AND b.intStatus = 2
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [tlbParty] AS c 
ON a.[idfCase] = c.[idfCase]
LEFT JOIN [##NodeTable] AS d
ON d.idfNode = c.[idfParty]
WHERE d.idfNode IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT c.[idfHuman], 75670000000 /*tlbParty*/, 0
FROM [tlbCase] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode --AND b.intStatus = 2
INNER JOIN [tlbContactedCasePerson] AS c 
ON a.[idfCase] = c.[idfHumanCase]
LEFT JOIN [##NodeTable] AS d
ON d.idfNode = c.[idfHuman]
WHERE d.idfNode IS NULL 

-- ROOT Party
INSERT INTO [##NodeTable]
SELECT DISTINCT c.[idfRootParty], 75670000000 /*tlbParty*/, 0-- CASE WHEN b.intStatus = 2 THEN 0 ELSE 1 END 
FROM [tlbCase] AS a
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode --AND b.intStatus = 2
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [tlbParty] AS c 
ON a.[idfCase] = c.[idfCase]
LEFT JOIN [##NodeTable] AS d
ON d.idfNode = c.[idfRootParty]
WHERE d.idfNode IS NULL and c.[idfRootParty] IS NOT NULL

INSERT INTO [##NodeTable]
SELECT DISTINCT c2.[idfRootParty], 75670000000 /*tlbParty*/, 0
FROM [tlbCase] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode --AND b.intStatus = 2
INNER JOIN [tlbContactedCasePerson] AS c 
ON a.[idfCase] = c.[idfHumanCase]
INNER JOIN [tlbParty] AS c2 
ON c.[idfHuman] = c2.[idfParty]
LEFT JOIN [##NodeTable] AS d
ON d.idfNode = c2.[idfRootParty]
WHERE d.idfNode IS NULL and c2.[idfRootParty] IS NOT NULL

-- Outbreak
INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfOutbreak], 75660000000 /*tlbOutbreak*/, 0--CASE WHEN b.intStatus = 2 THEN 0 ELSE 1 END 
FROM [tlbCase] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS d
ON d.idfNode = a.[idfOutbreak]
WHERE d.idfNode IS NULL 
AND a.[idfOutbreak] IS NOT NULL 

-- 5.
-- GeoLocation
INSERT INTO [tflGeoLocationFiltered]([idfGeoLocation],[idfsSite],[strSiteID])
SELECT DISTINCT a1.[idfPointGeoLocation], c.[idfsSite],c.[strSiteID]
FROM [tlbCase] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflGeoLocationFiltered] AS c2 
ON a1.[idfPointGeoLocation] = c2.[idfGeoLocation] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogGeoLocationFiltered] AS c21 
ON a1.[idfPointGeoLocation] = c21.[idfGeoLocation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflogGeoLocationFiltered]([idfGeoLocation],[idfsSite],[strSiteID])
SELECT DISTINCT a1.[idfPointGeoLocation], c.[idfsSite],c.[strSiteID]
FROM [tlbCase] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogGeoLocationFiltered] AS c21 
ON a1.[idfPointGeoLocation] = c21.[idfGeoLocation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a1.[idfPointGeoLocation], 75580000000 /*tlbGeoLocation*/, 1
FROM [tlbCase] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode --AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS rr
ON a1.[idfPointGeoLocation] = rr.idfNode
WHERE rr.idfNode IS NULL 

-- Observation
INSERT INTO [tflObservationFitered]([idfObservation],[idfsSite],[strSiteID])
SELECT DISTINCT a1.[idfCSObservation], c.[idfsSite],c.[strSiteID]
FROM [tlbCase] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflObservationFitered] AS c2 
ON a1.[idfCSObservation] = c2.[idfObservation] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogObservationFitered] AS c21 
ON a1.[idfCSObservation] = c21.[idfObservation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 


INSERT INTO [tflogObservationFitered]([idfObservation],[idfsSite],[strSiteID])
SELECT DISTINCT a1.[idfCSObservation], c.[idfsSite],c.[strSiteID]
FROM [tlbCase] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogObservationFitered] AS c21 
ON a1.[idfCSObservation] = c21.[idfObservation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a1.[idfCSObservation], 75640000000 /*tlbObservation*/, 1
FROM [tlbCase] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode --AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS rr
ON a1.[idfCSObservation] = rr.idfNode
WHERE rr.idfNode IS NULL 

INSERT INTO [tflObservationFitered]([idfObservation],[idfsSite],[strSiteID])
SELECT DISTINCT a1.[idfEpiObservation], c.[idfsSite],c.[strSiteID]
FROM [tlbCase] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflObservationFitered] AS c2 
ON a1.[idfEpiObservation] = c2.[idfObservation] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogObservationFitered] AS c21 
ON a1.[idfEpiObservation] = c21.[idfObservation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflogObservationFitered]([idfObservation],[idfsSite],[strSiteID])
SELECT DISTINCT a1.[idfEpiObservation], c.[idfsSite],c.[strSiteID]
FROM [tlbCase] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode AND b.intStatus = 2
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogObservationFitered] AS c21 
ON a1.[idfEpiObservation] = c21.[idfObservation] AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL 

INSERT INTO [##NodeTable]
SELECT DISTINCT a1.[idfEpiObservation], 75640000000 /*tlbObservation*/, 1
FROM [tlbCase] AS a
INNER JOIN [tlbHumanCase] AS a1
ON a.[idfCase] = a1.[idfHumanCase]
INNER JOIN [##NodeTable] AS b
ON a.[idfCase] = b.idfNode --AND b.intStatus = 2
LEFT JOIN [##NodeTable] AS rr
ON a1.[idfEpiObservation] = rr.idfNode
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
WHERE c21.idfsSite IS NULL 

DROP TABLE [#SiteList]

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

