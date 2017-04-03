SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateCase_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateCase_SelectDetail]
GO




--##SUMMARY Selects data for AggregateCaseDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 07.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @idfAggrCase bigint
EXECUTE spAggregateCase_SelectDetail 
	@idfAggrCase

*/




CREATE                                     proc	spAggregateCase_SelectDetail
		@idfAggrCase	bigint --##PARAM @idfAggrCase - aggregate case ID
as
-- Aggregate case
EXEC spAggregateCaseHeader_SelectDetail 	@idfAggrCase, 10102001 --Aggregate case

--1 Default matrix version
SELECT idfVersion 
FROM	tlbAggrMatrixVersionHeader
WHERE 
		idfsAggrCaseSection = 71190000000 --HumanCase section
		and intRowStatus = 0
		and blnIsActive = 1
ORDER BY CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) DESC, datStartDate DESC


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

