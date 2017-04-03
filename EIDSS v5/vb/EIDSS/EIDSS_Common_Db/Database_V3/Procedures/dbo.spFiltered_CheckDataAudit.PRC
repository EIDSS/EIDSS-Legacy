SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckDataAudit]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckDataAudit]
GO
/*
declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
exec spFiltered_CheckDataAudit @ID
*/
CREATE      proc spFiltered_CheckDataAudit (@event bigint)
AS



-- реализация изменений
INSERT INTO [tflDataAuditEventFiltered] ([idfDataAuditEvent],[strSiteID],[idfsSite]) 
SELECT a.[idfDataAuditEvent],
	   b2.[strSiteID],
	   a.[idfsSite]
FROM [tauDataAuditEvent] AS a
INNER JOIN [tstSite] AS b2
ON a.[idfsSite] = b2.[idfsSite]
LEFT JOIN [tflDataAuditEventFiltered] AS c
ON a.[idfDataAuditEvent] = c.[idfDataAuditEvent] AND a.[idfsSite] = c.[idfsSite]
LEFT JOIN [tflogDataAuditEventFiltered] AS c2
ON a.[idfDataAuditEvent] = c2.[idfDataAuditEvent] AND a.[idfsSite] = c2.[idfsSite]
WHERE a.[idfDataAuditEvent] = @event
AND c.[idfsSite] IS NULL 
AND c2.[idfsSite] IS NULL 

INSERT INTO [tflogDataAuditEventFiltered] ([idfDataAuditEvent],[strSiteID],[idfsSite]) 
SELECT a.[idfDataAuditEvent],
	   b2.[strSiteID],
	   a.[idfsSite]
FROM [tauDataAuditEvent] AS a
INNER JOIN [tstSite] AS b2
ON a.[idfsSite] = b2.[idfsSite]
LEFT JOIN [tflogDataAuditEventFiltered] AS c2
ON a.[idfDataAuditEvent] = c2.[idfDataAuditEvent] AND a.[idfsSite] = c2.[idfsSite]
WHERE a.[idfDataAuditEvent] = @event
AND c2.[idfsSite] IS NULL 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

