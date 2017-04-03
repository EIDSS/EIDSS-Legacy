SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spTestResult2Test_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spTestResult2Test_SelectDetail]
GO



--##SUMMARY Selects data for Test->TestResult matrix form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 22.11.2009

--##RETURNS Doesn't use





CREATE          PROCEDURE dbo.spTestResult2Test_SelectDetail(
	@LANGID as NVARCHAR(50)
	)
AS
--0 virtual record for test lookup binging
SELECT cast(0 as bigint) as idfsReference

--1 test results related with test types
SELECT  
	idfsTestType,
	idfsTestResult,
	TestResult.[Name] AS TestResultName,
	0 as TestKind --laboratory test
FROM 	trtTestTypeToTestResult
INNER JOIN dbo.fnReference(@LANGID, 19000096) TestResult ON --'rftTestResult'
	idfsTestResult= TestResult.idfsReference
WHERE
	intRowStatus = 0

UNION

SELECT  
	idfsPensideTestType as idfsTestType,
	idfsPensideTestResult as idfsTestResult,
	TestResult.[Name] AS TestResultName,
	1 as TestKind -- penside test
FROM 	trtPensideTestTypeToTestResult
INNER JOIN dbo.fnReference(@LANGID, 19000105) TestResult ON --'rftPensideTestResult'
	idfsPensideTestResult= TestResult.idfsReference
WHERE
	intRowStatus = 0




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

