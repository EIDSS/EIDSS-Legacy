SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSettlement_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSettlement_SelectDetail]
GO


--##SUMMARY Selects data for SettlementDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 23.11.2009

--##RETURNS Doesn't use
/*
--Example of a call of procedure:
DECLARE @idfsSettlement bigint
DECLARE @LANGID varchar(50)
EXECUTE spSettlement_SelectDetail
   @idfsSettlement
  ,@LANGID

EXECUTE spSettlement_SelectDetail
   NULL
  ,'en'

*/


CREATE     PROCEDURE dbo.spSettlement_SelectDetail(
	@idfsSettlement AS VARCHAR(36), --##PARAM @idfsSettlement - settlement ID
	@LANGID as NVARCHAR(50) --##PARAM @LANGID - language ID
)
AS
SELECT  
	idfsSettlement,
	dblLongitude, 
	dblLatitude, 
	idfsSettlementType, 
	idfsRayon, 
	idfsCountry, 
	idfsRegion,
	strSettlementCode,
	natSettlement.[Name] as strNationalName,
	enSettlement.[Name] as strEnglishName,
	blnIsCustomSettlement
FROM 
	gisSettlement
LEFT JOIN 
	fnGisReference(@LANGID,19000004) as natSettlement --'rftSettlement'
on	natSettlement.idfsReference = idfsSettlement
LEFT JOIN 
	fnGisReference('en',19000004) as enSettlement --'rftSettlement'
on	enSettlement.idfsReference = idfsSettlement
WHERE
	idfsSettlement = @idfsSettlement 



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

