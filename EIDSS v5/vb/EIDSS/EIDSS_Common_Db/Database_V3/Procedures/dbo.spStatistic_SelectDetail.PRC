SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spStatistic_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spStatistic_SelectDetail]
GO
--##SUMMARY Selects data for StatisticDetail form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 24.11.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

DECLARE @idfStatistic BIGINT
SET @idfStatistic = 73890000000
EXECUTE spStatistic_SelectDetail @idfStatistic, 'en'

*/



CREATE                  PROCEDURE dbo.spStatistic_SelectDetail(
	@idfStatistic AS BIGINT, --##PARAM @idfStatistic - statistic record ID
	@LangID AS NVARCHAR(50) --##PARAM @LangID - languageID
)
AS

--0 Statistic
SELECT tlbStatistic.idfStatistic
      ,tlbStatistic.idfsStatisticDataType
      ,tlbStatistic.idfsMainBaseReference
      ,tlbStatistic.idfsStatisticAreaType
      ,tlbStatistic.idfsStatisticPeriodType
      ,tlbStatistic.idfsArea
      ,tlbStatistic.datStatisticStartDate
      ,tlbStatistic.datStatisticFinishDate
      ,tlbStatistic.varValue
	  ,ParamType.Name as strParameterType
	  ,sdt.idfsReferenceType
FROM tlbStatistic 
LEFT OUTER JOIN	trtStatisticDataType sdt
ON				sdt.[idfsStatisticDataType] = tlbStatistic.[idfsStatisticDataType]
LEFT OUTER JOIN	fnReference(@LANGID, 19000076/*'rftReferenceTypeName'*/) ParamType
ON				ParamType.[idfsReference] = sdt.idfsReferenceType
WHERE tlbStatistic.idfStatistic = @idfStatistic
	AND tlbStatistic.intRowStatus = 0








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

