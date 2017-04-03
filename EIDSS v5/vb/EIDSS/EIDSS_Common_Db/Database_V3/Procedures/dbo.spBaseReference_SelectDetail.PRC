SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spBaseReference_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spBaseReference_SelectDetail]
GO

--##SUMMARY Selects list of base references editable in standard editor for ReferenceDetail form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

EXEC spBaseReference_SelectDetail 'en'
*/





CREATE     PROCEDURE [dbo].[spBaseReference_SelectDetail] 
	@LangID  nvarchar(50)  --##PARAM @LangID - language ID
AS
-- 0 BaseReference
SELECT trtBaseReference.idfsBaseReference
      ,trtBaseReference.idfsReferenceType
      ,trtBaseReference.strBaseReferenceCode
      ,ISNULL(trtStringNameTranslation.strTextString, trtBaseReference.strDefault) AS [Name]
	  ,trtBaseReference.strDefault
      ,trtBaseReference.intHACode
      ,trtBaseReference.intOrder
FROM trtBaseReference
INNER JOIN trtReferenceType ON 
	trtReferenceType.idfsReferenceType = trtBaseReference.idfsReferenceType
left join	trtStringNameTranslation ON	
	trtBaseReference.idfsBaseReference = trtStringNameTranslation.idfsBaseReference 
	and trtStringNameTranslation.idfsLanguage = dbo.fnGetLanguageCode(@LangID)
WHERE
	trtBaseReference.intRowStatus=0
ORDER BY 
	trtBaseReference.intOrder
	,trtBaseReference.strDefault
	,[Name]

-- 1 ReferenceType
SELECT 
	trtReferenceType.idfsReferenceType 
	,dbo.fnReference.Name as strReferenceTypeName
	--,trtReferenceType.strPrefix
	,trtReferenceType.intStandard
	,CAST (NULL as bigint) idfsCurrentReferenceType 
FROM dbo.fnReference(@LangID, 19000076)
INNER JOIN trtReferenceType ON
	trtReferenceType.idfsReferenceType = dbo.fnReference.idfsReference 
WHERE	(intStandard & 4)<>0 
		and trtReferenceType.intRowStatus=0
order by 
	strReferenceTypeName


--2 - HACodesList
EXEC spHACode_SelectCheckList @LangID

--3 --master ReferenceType
SELECT 
	CAST (-1 as bigint) idfsReferenceType 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

