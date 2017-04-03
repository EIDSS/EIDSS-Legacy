SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateMatrixVersion_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateMatrixVersion_SelectLookup]
GO


--##SUMMARY Selects lookup list of aggregate matrix versions for specific aggregate matrix type.
--##SUMMARY Usable matix types are:
--##SUMMARY     VetCase = 71090000000
--##SUMMARY     DiagnosticAction = 71460000000
--##SUMMARY     ProphylacticAction = 71300000000
--##SUMMARY     HumanCase = 71190000000
--##SUMMARY     SanitaryAction = 71260000000


--##REMARKS Author: Zurin M.
--##REMARKS Create date: 9.02.2010

--##RETURNS Doesn't use


/*
--Example of procedure call:
exec spAggregateMatrixVersion_SelectLookup 'en', NULL
*/

CREATE      PROCEDURE dbo.spAggregateMatrixVersion_SelectLookup
	@LanguageID As nvarchar(50), --##PARAM @LanguageID - language ID
	@idfMatrix as bigint = NULL  --##PARAM @idfMatrix - aggregate matrix ID

AS
if @idfMatrix is null --correct matrixes defaults during loading lookup cache
BEGIN
	exec spAggregateMatrixVersion_CorrectDefault 71090000000
	exec spAggregateMatrixVersion_CorrectDefault 71190000000
	exec spAggregateMatrixVersion_CorrectDefault 71460000000
	exec spAggregateMatrixVersion_CorrectDefault 71300000000
	exec spAggregateMatrixVersion_CorrectDefault 71260000000
END
SELECT idfVersion
      ,idfsAggrCaseSection
      ,MatrixName
      ,datStartDate
      ,blnIsActive
      ,blnIsDefault
	  ,CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) AS intState
FROM	tlbAggrMatrixVersionHeader
WHERE 
		(@idfMatrix IS NULL OR idfsAggrCaseSection = @idfMatrix)
		and intRowStatus = 0
ORDER BY intState DESC, datStartDate DESC

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

