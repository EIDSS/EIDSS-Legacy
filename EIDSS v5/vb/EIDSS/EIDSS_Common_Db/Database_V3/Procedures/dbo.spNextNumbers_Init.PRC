SET QUOTED_IDENTIFIER ON 

GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spNextNumbers_Init]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spNextNumbers_Init]
GO








--##SUMMARY Initializes tstNextNumbers with default values.
--##SUMMARY Called from spGetNextNumber if tstNextNumbers contains no record related with related number type.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of procedure call:
EXEC spNextNumbers_Init 
*/


CREATE              PROCEDURE dbo.spNextNumbers_Init 
AS

DECLARE @RC int

EXEC @RC = dbo.spNextNumber_Init 10057006, N'Box Barcode', N'B', N'', 0, 4 
EXEC @RC = dbo.spNextNumber_Init 10057011, N'Freezer Barcode', N'W', N'', 0, 4
EXEC @RC = dbo.spNextNumber_Init 10057012, N'Shelf Barcode', N'G', N'', 0, 4
--EXEC @RC = dbo.spNextNumber_Init 10057017, N'Rack Barcode', N'K', N'', 0, 4
--EXEC @RC = dbo.spNextNumber_Init 10057018, N'Rack Position Barcode', N'L', N'', 0, 4
EXEC @RC = dbo.spNextNumber_Init 10057001, N'Human Aggregate Case', N'A', N'', 0, 4,1
EXEC @RC = dbo.spNextNumber_Init 10057003, N'Vet Aggregate Case', N'Q', N'', 0, 4,1
EXEC @RC = dbo.spNextNumber_Init 10057002, N'Vet Aggregate Action', N'Z', N'', 0, 4,1
EXEC @RC = dbo.spNextNumber_Init 10057004, N'Animal', N'X', N'', 0, 4, 1
EXEC @RC = dbo.spNextNumber_Init 10057010, N'Farm', N'F', N'', 0, 4, 1
EXEC @RC = dbo.spNextNumber_Init 10057013, N'Animal Group', N'I', N'', 0, 4, 1
EXEC @RC = dbo.spNextNumber_Init 10057014, N'Human Case', N'H', N'', 0, 4, 1
EXEC @RC = dbo.spNextNumber_Init 10057015, N'Outbreak', N'O', N'', 0, 4, 1
--EXEC @RC = dbo.spNextNumber_Init 10057016, N'Patient ID', N'P', N'', 0, 4, 1
EXEC @RC = dbo.spNextNumber_Init 10057019, N'Sample Field Barcode', N'M', N'', 0, 4, 1
EXEC @RC = dbo.spNextNumber_Init 10057020, N'Sample', N'S', N'', 0, 4, 1
EXEC @RC = dbo.spNextNumber_Init 10057022, N'Pendide Test', N'T', N'', 0, 4, 1
--EXEC @RC = dbo.spNextNumber_Init 10057023, N'Test Request', N'R', N'', 0, 4, 1
EXEC @RC = dbo.spNextNumber_Init 10057024, N'Vet Case', N'V', N'', 0, 4, 1
EXEC @RC = dbo.spNextNumber_Init 10057025, N'Vet Case Field Accession Number', N'N', N'', 0, 4, 1
EXEC @RC = dbo.spNextNumber_Init 10057005, N'Batch Test Barcode',N'C',N'',0,4,1
EXEC @RC = dbo.spNextNumber_Init 10057026, N'Sample Transfer Barcode', N'Y', N'', 0, 4, 1
EXEC @RC = dbo.spNextNumber_Init 10057027, N'Active Surveillance Campaign', N'D', N'', 0, 4, 1
EXEC @RC = dbo.spNextNumber_Init 10057028, N'Active Surveillance Session', N'E', N'', 0, 4, 1


--	EXEC @RC = dbo.spNextNumber_Init 10057007, N'Accession In Act', N'C', N'', 0, 4, 1
--	EXEC @RC = dbo.spNextNumber_Init 10057009, N'Destruction Act', N'D', N'', 0, 4, 1
---- PACS
--if @ModuleName = 'pacs_main' or @ModuleName is null
--begin
--	EXEC @RC = dbo.spNextNumber_Init 10057007, N'Accession In Act', N'C', N'', 0, 4
--	EXEC @RC = dbo.spNextNumber_Init 10057008, N'Transfer Out Barcode', N'Y', N'', 0, 4
--	EXEC @RC = dbo.spNextNumber_Init 10057009, N'Destruction Act', N'D', N'', 0, 4
--	EXEC @RC = dbo.spNextNumber_Init 10057021, N'Strain Passport Barcode', N'N', N'', 0, 4
--	EXEC @RC = dbo.spNextNumber_Init 10057020, N'Sample Barcode', N'S', N'', 0, 4, 1
--	EXEC @RC = dbo.spNextNumber_Init 10057026, N'Container Barcode', N'J', N'', 0, 4
--end


RETURN @RC












GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

