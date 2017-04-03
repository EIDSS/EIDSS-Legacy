SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckTransferIN]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckTransferIN]
GO
/*
if Object_ID('tempdb..##NodeTable') is null
create table ##NodeTable(
	idfNode BIGINT  NOT NULL, 
	strNodeTable nvarchar(200) COLLATE database_default,
	intStatus int )

declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
exec spFiltered_CheckTransferIN @ID

drop  table ##NodeTable
*/
CREATE      proc spFiltered_CheckTransferIN (@event bigint)
AS


-- objects for investigation (add new!)
INSERT INTO [##NodeTable]
SELECT a.[idfObject],75760000000, 0
FROM [tauDataAuditDetailCreate] AS a
LEFT JOIN [##NodeTable] AS b
ON b.idfNode = a.[idfObject]
WHERE a.[idfDataAuditEvent] = @event 
AND a.[idfObjectTable] = 75760000000  --tlbTransferIn
AND b.idfNode IS NULL 

-- проверка необходимости изменений
UPDATE b 
SET b.intStatus = CASE WHEN c.[idfTransferIn] IS NULL THEN 2 /* проверено, изменения*/ ELSE 1 /*проверено, без изменений*/ END  
FROM [tlbTransferIn] AS a
INNER JOIN [tlbContainer] AS a2
ON a.[idfContainer] = a2.[idfContainer]
INNER JOIN [##NodeTable] AS b
ON a.[idfTransferIn] = b.idfNode AND b.intStatus = 0
INNER JOIN dbo.fnFiltered_FullSiteList() AS b2
ON a2.[idfsSite] = b2.[parentSite]  AND b.[idfsSiteRelationType] = 10084001 --reported only
LEFT JOIN [tflogTransferINFiltered] AS c
ON a.[idfTransferIn] = c.[idfTransferIn] AND b2.[relatedSite] = c.[strSiteID]

-- реализация изменений
INSERT INTO [tflTransferINFiltered] ([idfTransferIn],[strSiteID],[idfsSite]) 
SELECT distinct a.[idfTransferIn],
	   b2.[relatedSiteID],
	   b2.[relatedSite]
FROM [tlbTransferIn] AS a
INNER JOIN [tlbContainer] AS a2
ON a.[idfContainer] = a2.[idfContainer]
INNER JOIN [##NodeTable] AS b
ON a.[idfTransferIn] = b.idfNode 
INNER JOIN [fnFiltered_FullSiteList]() AS b2
ON a2.[idfsSite] = b2.[parentSite] AND b.[idfsSiteRelationType] = 10084001 --reported only
LEFT JOIN [tflTransferINFiltered] AS c
ON a.[idfTransferIn] = c.[idfTransferIn] AND b2.[relatedSite] = c.[strSiteID]
LEFT JOIN [tflogTransferINFiltered] AS c2
ON a.[idfTransferIn] = c2.[idfTransferIn] AND b2.[relatedSite] = c2.[strSiteID]
WHERE c.[strSiteID] IS NULL and c2.[strSiteID] IS NULL 

INSERT INTO [tflogTransferINFiltered] ([idfTransferIn],[strSiteID],[idfsSite]) 
SELECT distinct a.[idfTransferIn],
	   b2.[relatedSiteID],
	   b2.[relatedSite]
FROM [tlbTransferIn] AS a
INNER JOIN [tlbContainer] AS a2
ON a.[idfContainer] = a2.[idfContainer]
INNER JOIN [##NodeTable] AS b
ON a.[idfTransferIn] = b.idfNode 
INNER JOIN [fnFiltered_FullSiteList]() AS b2
ON a2.[idfsSite] = b2.[parentSite] AND b.[idfsSiteRelationType] = 10084001 --reported only
LEFT JOIN [tflogTransferINFiltered] AS c2
ON a.[idfTransferIn] = c2.[idfTransferIn] AND b2.[relatedSite] = c2.[strSiteID]
WHERE c2.[strSiteID] IS NULL 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

