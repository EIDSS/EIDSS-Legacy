SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAggregateSettings_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAggregateSettings_Post]
GO


--##SUMMARY Posts AggregateSettings data

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 01.12.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:
DECLARE @idfsAggrCaseType bigint
DECLARE @idfsCountry bigint
DECLARE @idfsStatisticAreaType bigint
DECLARE @idfsStatisticPeriodType bigint

EXECUTE spAggregateSettings_Post
   @idfsAggrCaseType
  ,@idfsCountry
  ,@idfsStatisticAreaType
  ,@idfsStatisticPeriodType
*/


CREATE       procedure dbo.spAggregateSettings_Post
			 @idfsAggrCaseType		bigint --##PARAM @idfsAggrCaseType - aggregate case type
			,@idfsCountry			bigint --##PARAM @idfsCountry - country ID for posted settings
			,@idfsStatisticAreaType	bigint --##PARAM @idfsStatisticAreaType - statistic area type
			,@idfsStatisticPeriodType bigint --##PARAM @idfsStatisticPeriodType - statistic period type
as
IF EXISTS(SELECT * FROM tstAggrSetting WHERE idfsAggrCaseType=@idfsAggrCaseType AND idfsCountry = @idfsCountry)
	UPDATE tstAggrSetting
	   SET 
		   idfsStatisticAreaType = @idfsStatisticAreaType
		  ,idfsStatisticPeriodType = @idfsStatisticPeriodType
	 WHERE  idfsAggrCaseType=@idfsAggrCaseType AND idfsCountry = @idfsCountry
ELSE
	INSERT INTO tstAggrSetting
           (
			idfsAggrCaseType
           ,idfsCountry
           ,idfsStatisticAreaType
           ,idfsStatisticPeriodType
			)
     VALUES
           (
			@idfsAggrCaseType
           ,@idfsCountry
           ,@idfsStatisticAreaType
           ,@idfsStatisticPeriodType
			)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

