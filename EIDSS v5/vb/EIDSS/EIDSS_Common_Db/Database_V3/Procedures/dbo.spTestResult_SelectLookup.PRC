SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spTestResult_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spTestResult_SelectLookup]
GO
--##SUMMARY Selects lookup list of test results joint with test test types to which test result belongs.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 18.01.2011

--##RETURNS Doesn't use


/*
--Example of procedure call:

EXEC spTestResult_SelectLookup 'en'

*/
CREATE   PROCEDURE dbo.spTestResult_SelectLookup
	@LanguageID As nvarchar(50)/*,
	@idfsTestType AS VARCHAR(36)*/
AS

SELECT
			trtTestTypeToTestResult.idfsTestType,
			trtTestTypeToTestResult.idfsTestResult idfsReference,
			Result.Name
from		trtTestTypeToTestResult
left join	fnReference(@LanguageID,19000096) Result
on			Result.idfsReference=trtTestTypeToTestResult.idfsTestResult
WHERE  		trtTestTypeToTestResult.intRowStatus=0
ORDER BY 
			Result.intOrder, Result.Name

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

