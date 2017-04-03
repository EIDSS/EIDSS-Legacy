SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spNextNumbers_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spNextNumbers_Post]
GO


--##SUMMARY Posts numbering object data from NextNumbersDetail form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 24.11.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
DECLARE @idfsNumberName bigint
DECLARE @strDocumentName nvarchar(200)
DECLARE @strPrefix nvarchar(50)
DECLARE @strSuffix nvarchar(50)
DECLARE @intYear int
DECLARE @intNumberValue bigint
DECLARE @intMinNumberLength int
DECLARE @blnUsePrefix bit
DECLARE @blnUseSiteID bit
DECLARE @blnUseYear bit
DECLARE @blnUseHACSCodeSite bit
DECLARE @blnUseAlphaNumericValue bit
DECLARE @strObjectName nvarchar(200)
DECLARE @strEnglishName nvarchar(200)

EXECUTE spNextNumbers_Post
   'en'
  ,@idfsNumberName
  ,@strDocumentName
  ,@strPrefix
  ,@strSuffix
  ,@intYear
  ,@intNumberValue
  ,@intMinNumberLength
  ,@blnUsePrefix
  ,@blnUseSiteID
  ,@blnUseYear
  ,@blnUseHACSCodeSite
  ,@blnUseAlphaNumericValue
  ,@strObjectName
  ,@strEnglishName
*/

CREATE       PROCEDURE dbo.spNextNumbers_Post 
			@LangID NVARCHAR(50)--##PARAM @LangID - language ID
		   ,@idfsNumberName bigint--##PARAM @idfsNumberName - numbering object type
           ,@strDocumentName NVARCHAR(200)
           ,@strPrefix NVARCHAR(50)
           ,@strSuffix NVARCHAR(50)
           ,@intYear int
           ,@intNumberValue bigint
           ,@intMinNumberLength int
           ,@blnUsePrefix bit
           ,@blnUseSiteID bit
           ,@blnUseYear bit
           ,@blnUseHACSCodeSite bit
           ,@blnUseAlphaNumericValue bit
		   ,@strObjectName nvarchar(200)
		   ,@strEnglishName nvarchar(200)
AS

EXECUTE spBaseReference_SysPost 
    @idfsNumberName
  , 19000057/*rftNumberingType*/
  ,@LANGID
  ,@strEnglishName
  ,@strObjectName
  ,NULL
  ,NULL
IF EXISTS (SELECT idfsNumberName FROM tstNextNumbers WHERE idfsNumberName = @idfsNumberName)
BEGIN
	UPDATE tstNextNumbers
	   SET 
		  strDocumentName = @strDocumentName
		  ,strPrefix = @strPrefix
		  ,strSuffix = @strSuffix
		  --,intYear = @intYear
		  ,intNumberValue = @intNumberValue
		  ,intMinNumberLength = @intMinNumberLength
		  ,blnUsePrefix = @blnUsePrefix
		  ,blnUseSiteID = @blnUseSiteID
		  ,blnUseYear = @blnUseYear
		  ,blnUseHACSCodeSite = @blnUseHACSCodeSite
		  ,blnUseAlphaNumericValue = @blnUseAlphaNumericValue
	 WHERE idfsNumberName = @idfsNumberName
END 
ELSE
BEGIN
INSERT INTO tstNextNumbers
           ([idfsNumberName]
           ,[strDocumentName]
           ,[strPrefix]
           ,[strSuffix]
           ,[intYear]
           ,[intNumberValue]
           ,[intMinNumberLength]
           ,[blnUsePrefix]
           ,[blnUseSiteID]
           ,[blnUseYear]
           ,[blnUseHACSCodeSite]
           ,[blnUseAlphaNumericValue]
		)
     VALUES
           (
			@idfsNumberName
           ,@strDocumentName
           ,@strPrefix
           ,@strSuffix
           ,YEAR(GETDATE())
           ,@intNumberValue
           ,@intMinNumberLength
           ,@blnUsePrefix
           ,@blnUseSiteID
           ,@blnUseYear
           ,@blnUseHACSCodeSite
           ,@blnUseAlphaNumericValue
		)
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

