SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spStatistic_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spStatistic_Post]
GO
--##SUMMARY Selects data for StatisticDetail form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 24.11.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

DECLARE @idfStatistic BIGINT
EXECUTE spStatistic_Post @idfStatistic

*/



CREATE                  PROCEDURE dbo.spStatistic_Post(
		 @Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
		,@idfStatistic AS BIGINT --##PARAM @idfStatistic - statistic record ID
		,@idfsStatisticDataType AS BIGINT --##PARAM @idfsStatisticDataType - statistic data type
		,@idfsMainBaseReference AS BIGINT --##PARAM @idfsMainBaseReference - statistic base reference
		,@idfsStatisticAreaType AS BIGINT --##PARAM @idfsStatisticAreaType - statistic area type
		,@idfsStatisticPeriodType AS BIGINT --##PARAM @idfsStatisticPeriodType - statistic period type
		,@idfsArea AS BIGINT --##PARAM @idfsArea - statistic area
		,@datStatisticStartDate DATETIME --##PARAM @datStatisticStartDate - start date
		,@datStatisticFinishDate DATETIME --##PARAM @datStatisticFinishDate - finish date 
		,@varValue SQL_VARIANT  --##PARAM @varValue - statistic content
)
AS

IF @Action=4
	INSERT INTO tlbStatistic
        (
			idfStatistic
           ,idfsStatisticDataType
           ,idfsMainBaseReference
           ,idfsStatisticAreaType
           ,idfsStatisticPeriodType
           ,idfsArea
           ,datStatisticStartDate
           ,datStatisticFinishDate
           ,varValue
		)
     VALUES
        (
			@idfStatistic
           ,@idfsStatisticDataType
           ,@idfsMainBaseReference
           ,@idfsStatisticAreaType
           ,@idfsStatisticPeriodType
           ,@idfsArea
           ,@datStatisticStartDate
           ,@datStatisticFinishDate
           ,@varValue
		)
ELSE IF @Action = 8
	EXECUTE spStatistic_Delete @idfStatistic
ELSE IF @Action = 16
	UPDATE tlbStatistic
	   SET 
		   idfsStatisticDataType = @idfsStatisticDataType
		  ,idfsMainBaseReference = @idfsMainBaseReference
		  ,idfsStatisticAreaType = @idfsStatisticAreaType
		  ,idfsStatisticPeriodType = @idfsStatisticPeriodType
		  ,idfsArea = @idfsArea
		  ,datStatisticStartDate = @datStatisticStartDate
		  ,datStatisticFinishDate = @datStatisticFinishDate
		  ,varValue = @varValue
	 WHERE 
		   idfStatistic = @idfStatistic






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

