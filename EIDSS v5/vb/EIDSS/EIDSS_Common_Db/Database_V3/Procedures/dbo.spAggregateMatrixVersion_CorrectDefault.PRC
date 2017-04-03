SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateMatrixVersion_CorrectDefault]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateMatrixVersion_CorrectDefault]
GO


--##SUMMARY Corrects blnIsDefault field for specific matrix type. Correction is needed to avoid  the next problems:
--##SUMMARY  - multiple default matrixes are possible because of replication
--##SUMMARY  - Default matrix can be not defined explicitly by some reason

--##SUMMARY Usable matix types are:
--##SUMMARY     VetCase = 71090000000
--##SUMMARY     DiagnosticAction = 71460000000
--##SUMMARY     ProphylacticAction = 71300000000
--##SUMMARY     HumanCase = 71190000000
--##SUMMARY     SanitaryAction = 71260000000


--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.12.2010

--##RETURNS Doesn't use


/*
--Example of procedure call:
exec spAggregateMatrixVersion_CorrectDefault 71260000000
*/

CREATE      PROCEDURE dbo.spAggregateMatrixVersion_CorrectDefault
	@idfMatrix as bigint = NULL  --##PARAM @idfMatrix - aggregate matrix ID

AS
DECLARE @DefVersion as bigint
SELECT TOP 1 @DefVersion = idfVersion
FROM	tlbAggrMatrixVersionHeader
WHERE 
		idfsAggrCaseSection = @idfMatrix
		and intRowStatus = 0
		and blnIsActive = 1
ORDER BY  CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) DESC, datStartDate DESC
--Default version exists
IF not @DefVersion is null
BEGIN
	--make matrix version default explicitly
	--this statement shoudl do nothing if default version is defined explicitly
	UPDATE tlbAggrMatrixVersionHeader
		SET blnIsDefault = 1
	WHERE 
			idfVersion = @DefVersion
			and ISNULL(blnIsDefault,0) <> 1
	--Clear blnIsDefault field for all versions except default 
	UPDATE tlbAggrMatrixVersionHeader
		SET blnIsDefault = 0
	WHERE 
			idfVersion <> @DefVersion
			and idfsAggrCaseSection = @idfMatrix
			and intRowStatus = 0
			and blnIsActive = 1
			and ISNULL(blnIsDefault,0) <> 0
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

