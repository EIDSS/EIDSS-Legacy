SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckNotificationPost]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckNotificationPost]
GO

/*
declare @ID bigint
select @ID = max(idfNotification) from dbo.[tstNotification]

select * from dbo.[tstNotification] where idfNotification = @id

exec spFiltered_CheckNotificationPost @ID

select * from [tflNotificationFiltered] where idfNotification = @id


*/
CREATE      proc spFiltered_CheckNotificationPost (@notification bigint)
AS


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
WHERE a.[idfsNotificationType] IN (
10056002, --Test Results Received
10056005, --Case diagnosis changed notification
10056006, --Case status changed notification
10056008, --Human Case
10056011, --Outbreak
10056012 --Vet Case
)
AND a.[idfNotification] = @notification

INSERT INTO [#SiteList] ([idfNode],[idfsSite],[strSiteID]) 
SELECT DISTINCT a.[idfNotification], a1.[idfsSite], a1.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN [tflogCaseFiltered] AS a1
ON a.[idfNotificationObject] = a1.[idfCase]
WHERE a.[idfsNotificationType] IN (
10056002, --Test Results Received
10056005, --Case diagnosis changed notification
10056006, --Case status changed notification
10056008, --Human Case
10056011, --Outbreak
10056012 --Vet Case
)
AND a.[idfNotification] = @notification

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
AND a.[idfNotification] = @notification

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
AND a.[idfNotification] = @notification

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
AND a.[idfNotification] = @notification

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
AND a.[idfNotification] = @notification

INSERT INTO [#SiteList] ([idfNode],[idfsSite],[strSiteID]) 
SELECT DISTINCT a.[idfNotification], a1.[idfsSite], a1.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN [tflOutbreakFiltered] AS a1
ON a.[idfNotificationObject] = a1.[idfOutbreak]
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
AND a.[idfNotification] = @notification

INSERT INTO [#SiteList] ([idfNode],[idfsSite],[strSiteID]) 
SELECT DISTINCT a.[idfNotification], a1.[idfsSite], a1.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN [tflogOutbreakFiltered] AS a1
ON a.[idfNotificationObject] = a1.[idfOutbreak]
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
AND a.[idfNotification] = @notification

-- 3.
INSERT INTO [tflNotificationFiltered] ([idfNotification],[idfsSite],[strSiteID]) 
SELECT DISTINCT c.[idfNode],c.[idfsSite], c.[strSiteID]
FROM [#SiteList] AS c
LEFT JOIN [tflNotificationFiltered] AS c2 
ON c.[idfNode] = c2.[idfNotification] AND c.[idfsSite] = c2.[idfsSite]
LEFT JOIN [tflogNotificationFiltered] AS c21 
ON c.[idfNode] = c21.[idfNotification] AND c.[idfsSite] = c21.[idfsSite]
WHERE c2.idfsSite IS NULL and c21.idfsSite IS NULL 

INSERT INTO [tflogNotificationFiltered] ([idfNotification],[idfsSite],[strSiteID]) 
SELECT DISTINCT c.[idfNode],c.[idfsSite], c.[strSiteID]
FROM [#SiteList] AS c
LEFT JOIN [tflogNotificationFiltered] AS c21 
ON c.[idfNode] = c21.[idfNotification] AND c.[idfsSite] = c21.[idfsSite]
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
LEFT JOIN [tflNotificationFiltered] AS c 
ON a.idfNotification = c.[idfNotification] AND a2.[strSiteID] = c.[strSiteID]
LEFT JOIN [tflNotificationFiltered] AS c2 
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
AND a.[idfNotification] = @notification

INSERT INTO [tflogNotificationFiltered]([idfNotification],[idfsSite],[strSiteID])
SELECT distinct a.idfNotification, a2.[idfsSite], a2.[strSiteID]
FROM [tstNotification] AS a
INNER JOIN [tstSite] AS a2
ON 
--	a2.[idfsSiteType] IN (10085004,10085005,10085006,10085007) AND 
	a2.[intRowStatus] = 0 --cross join on all SS
LEFT JOIN [tflNotificationFiltered] AS c2 
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
AND a.[idfNotification] = @notification
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

