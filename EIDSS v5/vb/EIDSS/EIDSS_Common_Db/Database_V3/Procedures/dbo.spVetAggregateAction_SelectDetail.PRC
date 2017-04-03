SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spVetAggregateAction_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spVetAggregateAction_SelectDetail]
GO


--##SUMMARY Selects data for VetAggregateActionDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 06.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @idfAggrCase bigint
EXECUTE spVetAggregateAction_SelectDetail 
	@idfAggrCase

*/




CREATE                                     proc	spVetAggregateAction_SelectDetail
		@idfAggrCase	bigint --##PARAM @idfAggrCase - aggregate case ID
as

-- 0/1 Aggregate case/ aggregate settings
EXEC spAggregateCaseHeader_SelectDetail 	@idfAggrCase, 10102003 --Vet aggregate action

--2 Default Diagnostic matrix version
SELECT idfVersion 
FROM	tlbAggrMatrixVersionHeader
WHERE 
		idfsAggrCaseSection = 71460000000 --diagnostic section
		and intRowStatus = 0
		and blnIsActive = 1
ORDER BY CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) DESC, datStartDate DESC



--3 Default Prophylactic matrix version
SELECT idfVersion 
FROM	tlbAggrMatrixVersionHeader
WHERE 
		idfsAggrCaseSection = 71300000000 --prophilactic section
		and intRowStatus = 0
		and blnIsActive = 1
ORDER BY CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) DESC, datStartDate DESC


--4 Default Sanitary matrix version
SELECT idfVersion 
FROM	tlbAggrMatrixVersionHeader
WHERE 
		idfsAggrCaseSection = 71260000000 --Sanitary section
		and intRowStatus = 0
		and blnIsActive = 1
ORDER BY CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) DESC, datStartDate DESC



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

