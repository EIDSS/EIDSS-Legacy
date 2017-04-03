SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGetNextNumberRange]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGetNextNumberRange]
GO





--##SUMMARY Selects tha range of unique barcodes for printing. 
--##SUMMARY After this procedure call the barcode counter in the tstNextNumbers table is increased to @Count. 
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.12.2009

--##RETURNS Doesn't use



/*
Example of procedure call:

DECLARE @NextNumberName bigint
DECLARE @Count int
DECLARE @InstallationSite bigint

EXECUTE spGetNextNumberRange
   @NextNumberName
  ,@Count
  ,@InstallationSite

*/


CREATE     PROCEDURE dbo.spGetNextNumberRange 
	@NextNumberName AS bigint, --##PARAM @NumberingObjectID - ID of numbering object to print
	@Count AS int, --##PARAM @Count - the number of barcodes in the printing range
	@InstallationSite bigint --##PARAM @InstallationSite - ID of site for which barcode is printing
AS

DECLARE @i int
IF EXISTS (SELECT Name FROM SYSOBJECTS WHERE Name = '#NextNumberRange')
BEGIN
	DROP TABLE #NextNumberRange
END

CREATE TABLE #NextNumberRange ( 
	NumbersRange nvarchar (200) COLLATE database_default NOT NULL  PRIMARY KEY
	)

SET @i=0
DECLARE @NextNumberValue nvarchar(200)
While @i<@Count
BEGIN
-- Set parameter values
	EXEC [dbo].[spGetNextNumber] @NextNumberName, @NextNumberValue OUTPUT, @InstallationSite 	
	Insert Into #NextNumberRange
		(NumbersRange)
	VALUES
		(@NextNumberValue)
		
SET @i=@i+1
END

Select NumbersRange
FROM #NextNumberRange









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

