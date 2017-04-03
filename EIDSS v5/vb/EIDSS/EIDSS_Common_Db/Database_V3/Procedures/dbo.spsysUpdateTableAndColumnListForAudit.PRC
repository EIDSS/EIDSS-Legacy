SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spsysUpdateTableAndColumnListForAudit]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spsysUpdateTableAndColumnListForAudit]

GO


/*
exec 
*/
CREATE PROCEDURE dbo.spsysUpdateTableAndColumnListForAudit
(
@TableName NVARCHAR(128)
)
AS

DECLARE @ColumnName  NVARCHAR(128)
DECLARE @idfColumn BIGINT
DECLARE @idfTable BIGINT


SELECT @idfTable = idfTable FROM dbo.tauTable
WHERE strName = @TableName

IF @idfTable IS NULL 
BEGIN 
    EXEC dbo.spsysGetNewID @idfTable OUT
    INSERT INTO dbo.tauTable (idfTable, strName)
    VALUES (@idfTable, @TableName)
END

DECLARE cur CURSOR LOCAL STATIC 
FOR 
SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = @TableName
AND  COLUMN_NAME NOT IN ('rowguid', 'intRowStatus', 'idfsSite') 
AND NOT  (DATA_TYPE IN ('image') OR (DATA_TYPE IN ('nvarchar', 'varchar') AND CHARACTER_MAXIMUM_LENGTH = -1 /*nvarchar(max)*/))

OPEN cur 

FETCH NEXT FROM cur INTO @ColumnName

WHILE @@FETCH_STATUS = 0 
BEGIN
	IF NOT EXISTS (SELECT * FROM dbo.tauColumn WHERE idfTable = @idfTable AND strName = @ColumnName)
	BEGIN 
	    EXEC dbo.spsysGetNewID @idfColumn OUT
    	
	    INSERT INTO dbo.tauColumn (idfColumn, idfTable, strName)
	    VALUES (@idfColumn, @idfTable, @ColumnName)
  END	
	FETCH NEXT FROM cur INTO @ColumnName
END

DELETE FROM dbo.tauColumn
WHERE idfTable = @idfTable AND 
      strName NOT IN (
                       SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS
                       WHERE TABLE_NAME = @TableName
                             AND  COLUMN_NAME NOT IN ('rowguid', 'intRowStatus', 'idfsSite') 
                             AND NOT  (DATA_TYPE IN ('image') OR (DATA_TYPE = 'nvarchar' AND CHARACTER_MAXIMUM_LENGTH = -1))
                       
                     )


CLOSE cur
DEALLOCATE cur 



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

