SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSpeciesTypeReference_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSpeciesTypeReference_SelectDetail]
GO

--##SUMMARY Selects data for SpeciesTypeReferenceDetail form

--##REMARKS Author: Vdovin
--##REMARKS Create date: 29.09.2010

--##RETURNS Doesn't use

/*
Example of procedure call:

EXEC spSpeciesTypeReference_SelectDetail 'en'

*/





CREATE     PROCEDURE [dbo].[spSpeciesTypeReference_SelectDetail] 
	@LANGID  nvarchar(50) --##PARAM @LANGID - language ID
AS
-- 0 BaseReference
SELECT trtBaseReference.idfsBaseReference
      ,trtBaseReference.idfsReferenceType
      ,trtBaseReference.strBaseReferenceCode
      ,ISNULL(trtStringNameTranslation.strTextString, trtBaseReference.strDefault) AS [Name]
	  ,trtBaseReference.strDefault
      ,trtBaseReference.intHACode
      ,trtBaseReference.intOrder
	  ,trtSpeciesType.strCode
FROM trtBaseReference
INNER JOIN trtReferenceType ON 
	trtReferenceType.idfsReferenceType = trtBaseReference.idfsReferenceType
left join	trtStringNameTranslation ON	
	trtBaseReference.idfsBaseReference = trtStringNameTranslation.idfsBaseReference 
	and trtStringNameTranslation.idfsLanguage = dbo.fnGetLanguageCode(@LANGID)
LEFT JOIN	trtSpeciesType ON
	trtSpeciesType.idfsSpeciesType = trtBaseReference.idfsBaseReference
WHERE 
	trtReferenceType.idfsReferenceType =19000086 --rftSpeciesList
	and trtSpeciesType.intRowStatus = 0
ORDER BY 
	trtBaseReference.intOrder
	,trtBaseReference.strDefault
	,[Name]

/*
-- 1 ReferenceType
SELECT 
	trtReferenceType.idfsReferenceType 
	,dbo.fnReference.Name as strReferenceTypeName
	,trtReferenceType.intStandard
	,CAST (NULL as bigint) idfsCurrentReferenceType 
FROM dbo.fnReference(@LANGID, 19000076)
INNER JOIN trtReferenceType ON
	trtReferenceType.idfsReferenceType = dbo.fnReference.idfsReference 
WHERE 
	trtReferenceType.idfsReferenceType =19000086 --rftSpeciesList

order by 
	strReferenceTypeName
*/

--2 - HACodesList
EXEC spHACode_SelectCheckList @LANGID

/*
--3 --master ReferenceType
SELECT 
	CAST (19000086 as bigint) idfsReferenceType 
*/
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

