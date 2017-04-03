/****** Object:  StoredProcedure [dbo].[spsysWriteExtPropertiesForTable]    Script Date: 11/18/2009 13:03:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spsysWriteExtPropertiesForTable]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spsysWriteExtPropertiesForTable]

GO


--##SUMMARY This procedure write extended property value of table and column 

--##REMARKS Author: Romasheva S.
--##REMARKS 
--##REMARKS Update date: 

--##RETURNS 


/*
Example of a call of procedure:

-- заполнить extended property для таблицы
EXEC dbo.spsysWriteExtPropertiesForTable 'tstNewID' ,'Таблица для генерации новых ID', NULL, NULL


-- заполнить extended property для поля таблицы
EXEC dbo.spsysWriteExtPropertiesForTable 'tstNewID', NULL, 'NewID', 'Поле генерирующее новые ID'

*/



CREATE PROCEDURE 
  [dbo].[spsysWriteExtPropertiesForTable]
  (
  @TableName varchar(100),
  @TableDescription varchar(1000),
  @FieldName varchar(100) = NULL,
  @FieldDescription varchar(1000) = NULL,
  @ExPropName varchar(100) = 'MS_Description'
  )  
AS

-- Добавим свойство MS_Description таблице, если у таблицы уже есть свойство, удалим его
  IF (@FieldName IS NULL) OR (@FieldDescription IS NULL)
  BEGIN
    IF EXISTS(
              SELECT * FROM 
                  ::fn_listextendedproperty(NULL, 'USER', 'dbo', 'Table', @TableName, NULL, NULL)
              WHERE name = @ExPropName        
             )
    BEGIN
      EXEC dbo.sp_dropextendedproperty @ExPropName, 'USER', 'dbo', 'Table', @TableName, NULL, NULL
    END
    IF @TableDescription IS NOT NULL
      EXEC dbo.sp_addextendedproperty @ExPropName, @TableDescription, 'USER', 'dbo', 'Table', @TableName, NULL, NULL
  END

  IF (@FieldName IS NOT NULL) AND (@FieldDescription IS NOT NULL)
  BEGIN
    IF EXISTS(
              SELECT * FROM 
                  ::fn_listextendedproperty(NULL, 'USER', 'dbo', 'Table', @TableName, 'Column', @FieldName)
              WHERE name = @ExPropName 
             )
    BEGIN
      EXEC dbo.sp_dropextendedproperty @ExPropName, 'USER', 'dbo', 'Table', @TableName, 'Column', @FieldName
    END

    IF @FieldDescription IS NOT NULL
      EXEC dbo.sp_addextendedproperty @ExPropName, @FieldDescription, 'USER', 'dbo', 'Table', @TableName, 'Column', @FieldName    

  END






