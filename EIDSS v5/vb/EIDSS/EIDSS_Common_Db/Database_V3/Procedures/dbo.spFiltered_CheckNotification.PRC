SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckNotification]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckNotification]
GO
/*
if Object_ID('tempdb..##NodeTable') is null
create table ##NodeTable(
	idfNode BIGINT  NOT NULL, 
	strNodeTable nvarchar(200) COLLATE database_default,
	intStatus int )

declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
exec spFiltered_CheckNotification @ID

drop  table ##NodeTable
*/

CREATE      proc spFiltered_CheckNotification (@event bigint)
AS



-- objects for investigation (add new!)
INSERT INTO [##NodeTable]
SELECT DISTINCT a.[idfObject],76140000000, 1 ---0!!!!!!!!!!!!!!
FROM [tauDataAuditDetailCreate] AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 76140000000  --tstNotification
AND b.idfNode IS NULL 

CREATE TABLE #SiteList (
	idfNode BIGINT  NOT NULL,
	idfsSite BIGINT,
	strSiteID VARCHAR(36) collate database_default
	)

INSERT INTO [#SiteList] ([idfNode],[idfsSite],[strSiteID]) 
SELECT DISTINCT a.[idfNotification], a1.[idfsSite], a1.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN [tflCaseFiltered] AS a1
ON a.[idfNotificationObject] = a1.[idfCase]
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfNotification] AND b.intStatus = 0
WHERE a.[idfsNotificationType] IN (
10056002, --Test Results Received
10056005, --Case diagnosis changed notification
10056006, --Case status changed notification
10056008, --Human Case
10056011, --Outbreak
10056012 --Vet Case
)

INSERT INTO [#SiteList] ([idfNode],[idfsSite],[strSiteID]) 
SELECT DISTINCT a.[idfNotification], a1.[idfsSite], a1.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN [tflogCaseFiltered] AS a1
ON a.[idfNotificationObject] = a1.[idfCase]
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfNotification] AND b.intStatus = 0
WHERE a.[idfsNotificationType] IN (
10056002, --Test Results Received
10056005, --Case diagnosis changed notification
10056006, --Case status changed notification
10056008, --Human Case
10056011, --Outbreak
10056012 --Vet Case
)

INSERT INTO [#SiteList] ([idfNode],[idfsSite],[strSiteID]) 
SELECT DISTINCT a.[idfNotification], w.[idfsSite], w.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN tlbTesting AS a1
ON a.[idfNotificationObject] = a1.[idfTesting]
INNER JOIN [tlbContainer] AS a2
ON a1.[idfContainer] = a2.[idfContainer]
INNER JOIN [tlbMaterial] AS a3
ON a2.idfMaterial = a3.idfMaterial
INNER JOIN [tlbParty] AS a4 
ON a3.idfParty = a4.idfParty
INNER JOIN [tflCaseFiltered] AS w 
ON a4.idfCase = w.idfCase
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfNotification] AND b.intStatus = 0
LEFT JOIN [#SiteList] AS g
ON a.[idfNotification] = g.[idfNode] AND w.idfsSite = g.[idfsSite]
WHERE g.[idfNode] IS NULL 
AND a.[idfsNotificationType] IN (
10056002, --Test Results Received
10056005, --Case diagnosis changed notification
10056006, --Case status changed notification
10056008, --Human Case
10056011, --Outbreak
10056012 --Vet Case
)

INSERT INTO [#SiteList] ([idfNode],[idfsSite],[strSiteID]) 
SELECT DISTINCT a.[idfNotification], w.[idfsSite], w.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN tlbTesting AS a1
ON a.[idfNotificationObject] = a1.[idfTesting]
INNER JOIN [tlbContainer] AS a2
ON a1.[idfContainer] = a2.[idfContainer]
INNER JOIN [tlbMaterial] AS a3
ON a2.idfMaterial = a3.idfMaterial
INNER JOIN [tlbParty] AS a4 
ON a3.idfParty = a4.idfParty
INNER JOIN [tflogCaseFiltered] AS w 
ON a4.idfCase = w.idfCase
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfNotification] AND b.intStatus = 0
LEFT JOIN [#SiteList] AS g
ON a.[idfNotification] = g.[idfNode] AND w.idfsSite = g.[idfsSite]
WHERE g.[idfNode] IS NULL 
AND a.[idfsNotificationType] IN (
10056002, --Test Results Received
10056005, --Case diagnosis changed notification
10056006, --Case status changed notification
10056008, --Human Case
10056011, --Outbreak
10056012 --Vet Case
)

INSERT INTO [#SiteList] ([idfNode],[idfsSite],[strSiteID]) 
SELECT DISTINCT a.[idfNotification], w.[idfsSite], w.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN tlbTesting AS a1
ON a.[idfNotificationObject] = a1.[idfTesting]
INNER JOIN [tlbContainer] AS a2
ON a1.[idfContainer] = a2.[idfContainer]
INNER JOIN [tlbMaterial] AS a3
ON a2.idfMaterial = a3.idfMaterial
INNER JOIN [tlbParty] AS a4 
ON a3.idfParty = a4.idfParty
INNER JOIN [tflMonitoringSessionFiltered] AS w 
ON a4.idfCase = w.[idfMonitoringSession]
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfNotification] AND b.intStatus = 0
LEFT JOIN [#SiteList] AS g
ON a.[idfNotification] = g.[idfNode] AND w.idfsSite = g.[idfsSite]
WHERE g.[idfNode] IS NULL 
AND a.[idfsNotificationType] IN (
10056002, --Test Results Received
10056005, --Case diagnosis changed notification
10056006, --Case status changed notification
10056008, --Human Case
10056011, --Outbreak
10056012 --Vet Case
)

INSERT INTO [#SiteList] ([idfNode],[idfsSite],[strSiteID]) 
SELECT DISTINCT a.[idfNotification], w.[idfsSite], w.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN tlbTesting AS a1
ON a.[idfNotificationObject] = a1.[idfTesting]
INNER JOIN [tlbContainer] AS a2
ON a1.[idfContainer] = a2.[idfContainer]
INNER JOIN [tlbMaterial] AS a3
ON a2.idfMaterial = a3.idfMaterial
INNER JOIN [tlbParty] AS a4 
ON a3.idfParty = a4.idfParty
INNER JOIN [tflogMonitoringSessionFiltered] AS w 
ON a4.idfCase = w.[idfMonitoringSession]
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfNotification] AND b.intStatus = 0
LEFT JOIN [#SiteList] AS g
ON a.[idfNotification] = g.[idfNode] AND w.idfsSite = g.[idfsSite]
WHERE g.[idfNode] IS NULL 
AND a.[idfsNotificationType] IN (
10056002, --Test Results Received
10056005, --Case diagnosis changed notification
10056006, --Case status changed notification
10056008, --Human Case
10056011, --Outbreak
10056012 --Vet Case
)

INSERT INTO [#SiteList] ([idfNode],[idfsSite],[strSiteID]) 
SELECT DISTINCT a.[idfNotification], a1.[idfsSite], a1.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN [tflOutbreakFiltered] AS a1
ON a.[idfNotificationObject] = a1.[idfOutbreak]
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfNotification] AND b.intStatus = 0
LEFT JOIN [#SiteList] AS g
ON a.[idfNotification] = g.[idfNode] AND a1.idfsSite = g.[idfsSite]
WHERE g.[idfNode] IS NULL 
AND a.[idfsNotificationType] IN (
10056002, --Test Results Received
10056005, --Case diagnosis changed notification
10056006, --Case status changed notification
10056008, --Human Case
10056011, --Outbreak
10056012 --Vet Case
)

INSERT INTO [#SiteList] ([idfNode],[idfsSite],[strSiteID]) 
SELECT DISTINCT a.[idfNotification], a1.[idfsSite], a1.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN [tflogOutbreakFiltered] AS a1
ON a.[idfNotificationObject] = a1.[idfOutbreak]
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfNotification] AND b.intStatus = 0
LEFT JOIN [#SiteList] AS g
ON a.[idfNotification] = g.[idfNode] AND a1.idfsSite = g.[idfsSite]
WHERE g.[idfNode] IS NULL 
AND a.[idfsNotificationType] IN (
10056002, --Test Results Received
10056005, --Case diagnosis changed notification
10056006, --Case status changed notification
10056008, --Human Case
10056011, --Outbreak
10056012 --Vet Case
)
-- 3.
UPDATE b 
SET intStatus = 2 /* проверено, изменения*/
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN dbo.tflogNotificationFiltered AS d
ON c.[strSiteID] = d.[strSiteID] AND c.[idfNode] = d.[idfNotification]
WHERE b.intStatus = 0 
AND d.[idfsSite] IS NULL 

UPDATE b 
SET intStatus = 1 /*проверено, без изменений*/
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
WHERE b.intStatus = 0 

INSERT INTO [tflNotificationFiltered] ([idfNotification],[idfsSite],[strSiteID]) 
SELECT DISTINCT b.[idfNode],c.[idfsSite], c.[strSiteID]
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflNotificationFiltered] AS c2 
ON b.[idfNode] = c2.[idfNotification] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogNotificationFiltered] AS c21 
ON b.[idfNode] = c21.[idfNotification] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflogNotificationFiltered] ([idfNotification],[idfsSite],[strSiteID]) 
SELECT DISTINCT b.[idfNode],c.[idfsSite], c.[strSiteID]
FROM [##NodeTable] AS b
INNER JOIN [#SiteList] AS c
ON b.idfNode = c.[idfNode]
LEFT JOIN [tflogNotificationFiltered] AS c21 
ON b.[idfNode] = c21.[idfNotification] AND c.[idfsSite] = c21.[idfsSite]
WHERE c21.idfsSite IS NULL 

----- Other

declare @Country bigint
select @country = idfsCountry
from dbo.tstSite where idfsSite = dbo.fnSiteID()

INSERT INTO [tflNotificationFiltered]([idfNotification],[idfsSite],[strSiteID])
SELECT distinct a.idfNotification, a2.[idfsSite], a2.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN [tstSite] AS a2
ON 
--	a2.[idfsSiteType] IN (10085004,10085005,10085006,10085007) AND 
	a2.[intRowStatus] = 0 --cross join on all SS
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.idfNotification
LEFT JOIN [tflNotificationFiltered] AS c 
ON a.idfNotification = c.[idfNotification] AND a2.[strSiteID] = c.[strSiteID]
LEFT JOIN [tflogNotificationFiltered] AS c2 
ON a.idfNotification = c2.[idfNotification] AND a2.[strSiteID] = c2.[strSiteID]
WHERE c.idfsSite IS NULL and c2.idfsSite IS NULL 
and a2.idfsCountry = @Country
AND a.[idfsNotificationType] NOT IN (
10056002, --Test Results Received
10056005, --Case diagnosis changed notification
10056006, --Case status changed notification
10056008, --Human Case
10056011, --Outbreak
10056012 --Vet Case
)

INSERT INTO [tflogNotificationFiltered]([idfNotification],[idfsSite],[strSiteID])
SELECT distinct a.idfNotification, a2.[idfsSite], a2.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN [tstSite] AS a2
ON 
--	a2.[idfsSiteType] IN (10085004,10085005,10085006,10085007) AND 
	a2.[intRowStatus] = 0 --cross join on all SS
INNER JOIN [##NodeTable] AS b
ON b.idfNode = a.idfNotification
LEFT JOIN [tflogNotificationFiltered] AS c2 
ON a.idfNotification = c2.[idfNotification] AND a2.[strSiteID] = c2.[strSiteID]
WHERE c2.idfsSite IS NULL 
and a2.idfsCountry = @Country
AND a.[idfsNotificationType] NOT IN (
10056002, --Test Results Received
10056005, --Case diagnosis changed notification
10056006, --Case status changed notification
10056008, --Human Case
10056011, --Outbreak
10056012 --Vet Case
)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

