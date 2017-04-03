SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spNextNumbers_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spNextNumbers_SelectDetail]
GO
 

--##SUMMARY Selects specific numbering object data for NextNumbersDetail form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 24.11.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spNextNumbers_SelectDetail 10057019, 'en'
*/

CREATE       PROCEDURE dbo.spNextNumbers_SelectDetail 
	@idfsNumberName AS BIGINT,--##PARAM @idfsNumberName - numbering object type
	@LangID AS NVARCHAR(50)--##PARAM @LangID - language ID
AS
DECLARE @ObjectName NVARCHAR(200)
SELECT 
	@ObjectName = fnReference.[Name]
FROM 	fnReference(@LangID, 19000057/*rftNumberingType*/)
WHERE 
	idfsReference = @idfsNumberName

DECLARE @EnglishName NVARCHAR(200)
SELECT 
	@EnglishName = fnReference.[Name]
FROM 	fnReference('en', 19000057/*rftNumberingType*/)
WHERE 
	idfsReference = @idfsNumberName

SELECT 
	[idfsNumberName], 
	[strPrefix], 
	[strSuffix], 
	[intNumberValue], 
	[intMinNumberLength], 
	@ObjectName as strObjectName,
	@EnglishName as strEnglishName,
	[blnUsePrefix],
	[blnUseSiteID],
	[blnUseYear],
	[blnUseHACSCodeSite],
	[blnUseAlphaNumericValue], 
	[intYear]
FROM 
	dbo.tstNextNumbers
WHERE 
	idfsNumberName = @idfsNumberName







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

