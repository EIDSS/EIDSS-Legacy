SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPensideTestResult_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPensideTestResult_SelectLookup]
GO

--##SUMMARY Selects the list of penside test results in relation with Penside test type.
--##SUMMARY The special PensideTestType = 0 can be used for retieving full Penside tests results list.
--##SUMMARY It is assumed that returned recorrd set will be filters in client appliction by the Penside test type to receive test results for specific test type.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
EXEC spPensideTestResult_SelectLookup 'en'
*/

CREATE   PROCEDURE dbo.spPensideTestResult_SelectLookup
	@LanguageID As nvarchar(50)--##PARAM @LanguageID - language ID
AS
DECLARE @tmp Table
(
	idfRowNumber bigint  IDENTITY(1,1) not null PRIMARY KEY ,
	idfsPensideTestType bigint,
	idfsReference bigint,
	[Name] nvarchar(200),
	intOrder int
)

insert into @tmp(
	idfsReference,
	[Name],
	idfsPensideTestType,
	intOrder
)	
(SELECT 	
	idfsReference,
	[Name],
	0 AS idfsPensideTestType,
	intOrder
FROM dbo.fnReferenceLookup(@LanguageID, 19000105/*rftPensideTestResult*/,NULL)

UNION 

SELECT 	
	idfsReference,
	[Name],
	trtPensideTestTypeToTestResult.idfsPensideTestType,
	intOrder
FROM dbo.fnReferenceLookup(@LanguageID,19000105/*rftPensideTestResult*/,NULL)
INNER JOIN trtPensideTestTypeToTestResult ON 
	trtPensideTestTypeToTestResult.idfsPensideTestResult = dbo.fnReferenceLookup.idfsReference
WHERE 
	trtPensideTestTypeToTestResult.intRowStatus = 0 
)
SELECT 
	idfRowNumber,
	idfsReference,
	[Name],
	idfsPensideTestType
FROM @tmp
ORDER BY intOrder, [Name]





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

