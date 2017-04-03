SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spStatistic_GetDataType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spStatistic_GetDataType]
GO
--##SUMMARY Selects statistic parameters for specific statistic data type

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 26.11.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

DECLARE @idfsStatisticDataType BIGINT
EXECUTE spStatistic_GetDataType @idfsStatisticDataType

*/



CREATE                  PROCEDURE dbo.spStatistic_GetDataType(
	@idfsStatisticDataType AS BIGINT --##PARAM @idfsStatisticDataType - Statistic Data Type
)
AS
SELECT 
       idfsReferenceType
      ,idfsStatisticAreaType
      ,idfsStatisticPeriodType
  FROM trtStatisticDataType
WHERE idfsStatisticDataType = @idfsStatisticDataType




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

