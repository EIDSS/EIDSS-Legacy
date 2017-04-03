SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateSanitaryActionMatrix_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateSanitaryActionMatrix_SelectDetail]
GO


--##SUMMARY Selects data for AggregateSanitaryActionMTXDetail form
--##SUMMARY that defines the list of sanitary actions that should be displayed on VetAggregateActionDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 15.02.2011

--##RETURNS Doesn't use



/*
--Example of procedure call:

EXECUTE spAggregateSanitaryActionMatrix_SelectDetail 

*/


CREATE       procedure dbo.spAggregateSanitaryActionMatrix_SelectDetail
as
/*
				,@idfsParameterMeasureType4 = 233190000000
				,@idfsParameterMeasureCode4 = 233150000000
*/
SELECT	 trtSanitaryAction.idfsSanitaryAction as idfSanitaryActionMTX		
		,ISNULL(tlbAggrMatrixVersionHeader.idfVersion,0) AS idfVersion
		,ActionVersion.idfAggrMatrixVersion as idfActionTypeRow
		,trtSanitaryAction.idfsSanitaryAction
		,ActionCode.idfAggrMatrixVersion as idfActionCodeRow
		,trtSanitaryAction.strActionCode
		,ActionVersion.intNumRow
FROM	trtSanitaryAction
INNER JOIN dbo.tlbAggrMatrixVersionHeader ON
	tlbAggrMatrixVersionHeader.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion ActionVersion
ON
	tlbAggrMatrixVersionHeader.idfVersion = ActionVersion.idfVersion	
	AND ActionVersion.varValue = trtSanitaryAction.idfsSanitaryAction
	and ActionVersion.idfsParameter = 233190000000 -- action ID
	AND ActionVersion.intRowStatus = 0
INNER JOIN  tlbAggrMatrixVersion ActionCode
ON 
	ActionCode.idfRow = ActionVersion.idfRow
	and ActionCode.idfsParameter = 233150000000 -- action code
	and ActionCode.idfVersion = ActionVersion.idfVersion -- action code
	AND ActionCode.intRowStatus = 0
WHERE
		trtSanitaryAction.intRowStatus = 0
Order By
	ActionVersion.intNumRow
	

--Current matrix version
--We select latest matrix version as default current version
SELECT TOP 1
		idfVersion
      ,idfsAggrCaseSection
      ,MatrixName
      ,datStartDate 
      ,blnIsActive
      ,blnIsDefault
FROM	tlbAggrMatrixVersionHeader
WHERE 
		idfsAggrCaseSection = 71260000000 /*Sanitary action matrix*/
		and intRowStatus = 0
ORDER BY CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) DESC, datStartDate DESC

--Lookup list of all available matrix versions
EXEC spAggregateMatrixVersion_SelectLookup 'en',71260000000 /*Sanitary action matrix*/



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

