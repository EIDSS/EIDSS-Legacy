
GO
/****** Object:  StoredProcedure [dbo].[spGetBarcodeRange]    Script Date: 07/25/2008 19:32:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetBarcodeRange]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spGetBarcodeRange]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--##SUMMARY Selects tha range of unique barcodes for printing.
--##SUMMARY After this procedure call the barcode counter in the tstNextNumbers table is increased to @Count.
--##SUMMARY In distinguish with spGetNextNumberRange this procedure returns the table that contains optional
--##SUMMARY text headers and footers (that is always empty in current version) for printing barcodes.
--##SUMMARY This procedure is called from BarcodePrint form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.12.2009

--##RETURNS Doesn't use



/*
Example of procedure call:

DECLARE @NextNumberName bigint
DECLARE @Count int
DECLARE @InstallationSite bigint

EXECUTE spGetBarcodeRange
@NextNumberName
,@Count
,@InstallationSite

*/


CREATE     PROCEDURE [dbo].[spGetBarcodeRange]
@NextNumberName AS bigint, --##PARAM @NumberingObjectID - ID of numbering object to print
@Count AS int, --##PARAM @Count - the number of barcodes in the printing range
@InstallationSite bigint --##PARAM @InstallationSite - ID of site for which barcode is printing
AS
SET @InstallationSite = ISNULL(@InstallationSite, dbo.fnSiteID())

IF EXISTS (SELECT Name FROM SYSOBJECTS WHERE Name = '#BarcodeRange')
BEGIN
DROP TABLE #BarcodeRange
END

CREATE TABLE #BarcodeRange
(
NumbersRange nvarchar (200) COLLATE database_default NOT NULL  PRIMARY KEY,
[TopLine] nvarchar (100) COLLATE database_default,
[BottomLine] nvarchar (100) COLLATE database_default
)

INSERT INTO #BarcodeRange (NumbersRange)
EXEC spGetNextNumberRange @NextNumberName, @Count, @InstallationSite

UPDATE	#BarcodeRange
SET [TopLine] = ''

UPDATE	#BarcodeRange
SET [BottomLine] = ''

SELECT * FROM #BarcodeRange

DROP TABLE #BarcodeRange



GO









