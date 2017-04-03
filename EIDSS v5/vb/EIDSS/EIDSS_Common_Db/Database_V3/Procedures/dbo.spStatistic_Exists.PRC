SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spStatistic_Exists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spStatistic_Exists]
GO
--##SUMMARY Checks if the statistic record with passed parameters exists

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 24.11.2009

--##RETURNS Returns 1 if statistic record exists, 0 in other case

/*
--Example of a call of procedure:
DECLARE @RC int
DECLARE @Area bigint
DECLARE @StatisticDataType bigint
DECLARE @StatisticPeriodType bigint
DECLARE @StartDate datetime
DECLARE @Statistic bigint
DECLARE @idfsMainBaseReference bigint
DECLARE @StatisticOut bigint
SET  @Area = 37020000000
SET @StatisticDataType = 39850000000 
SET @StatisticPeriodType  = 10091005
SET @StartDate = GETDATE()
SET @Statistic  = null

EXECUTE @RC = spStatistic_Exists
   @Area
  ,@StatisticDataType
  ,@StatisticPeriodType
  ,@StartDate
  ,@Statistic
  ,@idfsMainBaseReference
, @StatisticOut OUTPUT
Print @RC
Print @StatisticOut

*/



CREATE                  PROCEDURE dbo.spStatistic_Exists(
	@Area AS BIGINT --##PARAM @Area - area ID (should point to Country, Region, Rayon or Settlement)
	,@StatisticDataType AS BIGINT --##PARAM @StatisticDataType - statistic data type, reference to rftStatisticDataType (19000090)
	,@StatisticPeriodType AS BIGINT --##PARAM @StatisticPeriodType	statistic period type, reference to rftStatisticPeriodType (19000091)
	,@StartDate AS DATETIME --##PARAM @StartDate - start date of statistic period
	,@Statistic AS BIGINT --##PARAM @Statistic - ID of statistic record. If NULL, is not taken into account
	,@idfsMainBaseReference AS BIGINT --##PARAM @idfsMainBaseReference - ID parameter value. If NULL, is not taken into account
	,@ExistingStatistic AS BIGINT OUTPUT --##PARAM @ExistingStatistic - returns ID of found statistic record
)
AS
select @ExistingStatistic = idfStatistic
from tlbStatistic
where idfsStatisticDataType = @StatisticDataType  
	and idfsStatisticPeriodType = @StatisticPeriodType  
	and DATEPART(dayofyear,datStatisticStartDate) = DATEPART(dayofyear,@StartDate)  
	and DATEPART(year,datStatisticStartDate) = DATEPART(year,@StartDate)  
	and idfsArea = @Area 
	and (@idfsMainBaseReference IS NULL OR idfsMainBaseReference = @idfsMainBaseReference)
	and (@Statistic IS NULL OR idfStatistic <> @Statistic)
if NOT @ExistingStatistic IS NULL
	Return 1
ELSE
	return 0








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

