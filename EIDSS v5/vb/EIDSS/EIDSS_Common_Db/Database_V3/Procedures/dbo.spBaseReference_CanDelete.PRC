SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spBaseReference_CanDelete') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spBaseReference_CanDelete
GO

--##SUMMARY 

--##REMARKS Author: Romasheva S.
--##REMARKS Create date: 24.03.2011

--##RETURNS 

/*
Example of procedure call:

    DECLARE @Result BIT
    DECLARE @ID BIGINT
    SET @ID = 380000000  


    EXECUTE spBaseReference_CanDelete 
       @ID
      ,@Result out
      
    PRINT   @Result
    
    
    SET @ID = 0 


    EXECUTE spBaseReference_CanDelete 
       @ID
      ,@Result out
      
    PRINT   @Result
    

*/

CREATE  PROCEDURE dbo.spBaseReference_CanDelete
    @ID BIGINT ,
    @Result BIT OUT 
AS

    SET NOCOUNT ON 
    
    DECLARE @FKtable TABLE
    (
    PKTABLE_QUALIFIER  sysname ,
    PKTABLE_OWNER  sysname ,
    PKTABLE_NAME  sysname ,
    PKCOLUMN_NAME  sysname ,
    FKTABLE_QUALIFIER  sysname ,
    FKTABLE_OWNER  sysname ,
    FKTABLE_NAME  sysname ,
    FKCOLUMN_NAME  sysname ,
    KEY_SEQ  smallint ,
    UPDATE_RULE  smallint ,
    DELETE_RULE  smallint ,
    FK_NAME  sysname ,
    PK_NAME  sysname ,
    DEFERRABILITY smallint
    )

    INSERT INTO @FKtable
    EXEC sp_fkeys @pktable_name = N'trtBaseReference',
       @pktable_owner = N'dbo'
       

    DECLARE @FKTABLE_NAME  sysname
    DECLARE @FKCOLUMN_NAME sysname
    DECLARE @RowStatusExists bit
    DECLARE @sql NVARCHAR(MAX)
    DECLARE @ChildPK sysname 
    DECLARE @ParentTable sysname
    DECLARE @ParentPK sysname


    SET @Result = 1

    DECLARE cur CURSOR LOCAL STATIC
    FOR 
    SELECT 
        fkt.FKTABLE_NAME, 
        fkt.FKCOLUMN_NAME,
        CASE WHEN isc.COLUMN_NAME IS NOT NULL THEN 1 ELSE 0 END AS RowStatusExists
    FROM @FKtable fkt
        LEFT JOIN information_schema.columns isc
        ON isc.TABLE_NAME = fkt.FKTABLE_NAME AND 
           isc.COLUMN_NAME = 'intRowStatus'
    WHERE fkt.FKTABLE_NAME NOT IN 
                        (
						'trtStringNameTranslation' 
						,'trtBaseReferenceToCountry' 
						,'trtDerivativeForSampleType' 
						,'trtDerivativeForSampleTypeToCountry' 
						,'trtMaterialForDisease' 
						,'trtMaterialForDiseaseToCountry' 
						,'trtPensideTestTypeToTestResult' 
						,'trtPensideTestTypeToTestResultToCountry' 
						,'trtSpeciesTypeToAnimalAge' 
						,'trtSpeciesTypeToAnimalAgeToCountry' 
						,'trtTestForDisease' 
						,'trtTestForDiseaseToCountry' 
						,'trtTestTypeToTestResult' 
						,'trtTestTypeToTestResultToCountry'
                        )

    OPEN cur 

    FETCH NEXT FROM cur INTO @FKTABLE_NAME, @FKCOLUMN_NAME, @RowStatusExists

    WHILE @@FETCH_STATUS = 0 AND @Result = 1
    BEGIN
        SET @sql = 
        '
        IF EXISTS (SELECT * FROM ' + @FKTABLE_NAME + ' WHERE ' + @FKCOLUMN_NAME + ' =  @ID '+ 
        CASE WHEN @RowStatusExists = 1 THEN ' AND intRowStatus = 0 ' ELSE '' END +  
        ')
        SET @Result = 0
        '
        --PRINT @sql
        EXEC sp_executesql 
            @sql, 
            N'@ID bigint, @Result bit out',
            @ID = @ID, @Result = @Result OUT
            
        IF @Result = 0 AND @RowStatusExists = 0
        BEGIN
            SELECT
               @ChildPK = FK.COLUMN_NAME,
               @ParentTable = PK.TABLE_NAME,
               @ParentPK = PK.COLUMN_NAME
            FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE PK
                JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C 
                    ON PK.CONSTRAINT_NAME=C.UNIQUE_CONSTRAINT_NAME
                JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE FK 
                    ON C.CONSTRAINT_NAME=FK.CONSTRAINT_NAME AND 
                       PK.ORDINAL_POSITION=FK.ORDINAL_POSITION
                JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
                    ON tc.TABLE_NAME = fk.TABLE_NAME AND
                       tc.CONSTRAINT_TYPE = 'PRIMARY KEY' 
                JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE CCU
                    ON TC.CONSTRAINT_NAME = CCU.CONSTRAINT_NAME AND
                       tc.TABLE_NAME = ccu.TABLE_NAME AND
                       ccu.COLUMN_NAME = fk.COLUMN_NAME
                JOIN information_schema.columns isc
                    ON isc.TABLE_NAME = pk.TABLE_NAME AND 
                       isc.COLUMN_NAME = 'intRowStatus'
            WHERE FK.TABLE_NAME =	@FKTABLE_NAME		
            
        SET @sql = 
        '
        IF EXISTS (SELECT * FROM ' + @FKTABLE_NAME + ' fkt 
            INNER JOIN ' + @ParentTable + ' pt 
            ON fkt.' + @ChildPK + ' = pt.' + @ParentPK + '
               AND pt.intRowStatus = 0
        WHERE fkt.' + @FKCOLUMN_NAME + ' =  @ID  
        ) SET @Result = 0
        '
        --PRINT @sql
        EXEC sp_executesql 
            @sql, 
            N'@ID bigint, @Result bit out',
            @ID = @ID, @Result = @Result OUT
            
            
			  END
          
        FETCH NEXT FROM cur INTO @FKTABLE_NAME, @FKCOLUMN_NAME, @RowStatusExists
    END

    CLOSE cur
    DEALLOCATE cur



