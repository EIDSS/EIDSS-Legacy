SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spStatisticType_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spStatisticType_SelectDetail]
GO








--exec spStatisticType_SelectDetail 'en'




CREATE              PROCEDURE dbo.spStatisticType_SelectDetail(
	@LANGID as NVARCHAR(50)
)
AS

SELECT  
	trtStatisticDataType.idfsStatisticDataType as idfsBaseReference,
	fnReference.[strDefault],
	fnReference.[Name],
	trtStatisticDataType.idfsReferenceType,
	trtStatisticDataType.idfsStatisticAreaType,
	trtStatisticDataType.idfsStatisticPeriodType
FROM 
	trtStatisticDataType
LEFT JOIN 
	fnReference(@LANGID,19000090) ON--'rftStatisticDataType'
	fnReference.idfsReference = trtStatisticDataType.idfsStatisticDataType
WHERE 
	trtStatisticDataType.intRowStatus = 0







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

