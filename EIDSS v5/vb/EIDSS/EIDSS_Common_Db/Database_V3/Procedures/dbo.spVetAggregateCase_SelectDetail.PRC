SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spVetAggregateCase_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spVetAggregateCase_SelectDetail]
GO



--##SUMMARY Selects data for VetAggregateCaseDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 01.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @idfAggrCase bigint
EXECUTE spVetAggregateCase_SelectDetail 
	@idfAggrCase

*/



CREATE PROC	spVetAggregateCase_SelectDetail
		@idfAggrCase	bigint --##PARAM @idfAggrCase - aggregate case ID
as
-- Aggregate case
EXEC spAggregateCaseHeader_SelectDetail 	@idfAggrCase, 10102002 --Vet aggregate case
--Default matrix version
SELECT idfVersion 
FROM	tlbAggrMatrixVersionHeader
WHERE 
		idfsAggrCaseSection = 71090000000 --VetCase section
		and intRowStatus = 0
		and blnIsActive = 1
ORDER BY CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) DESC, datStartDate DESC

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

