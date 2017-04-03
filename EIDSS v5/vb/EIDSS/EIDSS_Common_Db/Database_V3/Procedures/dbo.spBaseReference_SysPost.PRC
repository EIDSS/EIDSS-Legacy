/****** Object:  StoredProcedure [dbo].[spBaseReference_Post1]    Script Date: 05/22/2008 12:48:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBaseReference_SysPost]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spBaseReference_SysPost]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO



--##SUMMARY Allows to create new reference or change the parameters of the existing one
--##SUMMARY If NULL is passed as @DefaultName, @NationalName,  @HACode or @Order parameter, the corresponded field value in 
--##SUMMARY trtBaseReference table is not changed.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 5.12.2009

--##RETURNS Doesn't use

/*
Example of procedure call:

DECLARE @ReferenceID bigint
DECLARE @ReferenceType bigint
DECLARE @LangID nvarchar(50)
DECLARE @DefaultName varchar(200)
DECLARE @NationalName nvarchar(200)
DECLARE @HACode int
DECLARE @Order int


EXECUTE spBaseReference_SysPost
   @ReferenceID
  ,@ReferenceType
  ,@LangID
  ,@DefaultName
  ,@NationalName
  ,@HACode
  ,@Order

*/

CREATE     PROCEDURE [dbo].[spBaseReference_SysPost] 
	@ReferenceID BIGINT, --##PARAM @ReferenceID - reference ID
	@ReferenceType BIGINT, --##PARAM @ReferenceType - reference type ID
	@LangID  nvarchar(50), --##PARAM @LangID - language ID
	@DefaultName VARCHAR(200), --##PARAM @DefaultName - default reference name, used if there is no refernece translation
	@NationalName  NVARCHAR(200), --##PARAM @NationalName - reference name in the language defined by @LangID
	@HACode INT = NULL, --##PARAM @HACode - bit mask for reference using
	@Order INT = NULL --##PARAM @Order - reference record order for sorting
AS
Begin
IF EXISTS (SELECT idfsBaseReference FROM trtBaseReference WHERE idfsBaseReference = @ReferenceID )
BEGIN
	UPDATE trtBaseReference
	SET
		idfsReferenceType = @ReferenceType, 
		strDefault = ISNULL(@DefaultName,strDefault),
		intHACode = ISNULL(@HACode,intHACode),
		intOrder = ISNULL(@Order,intOrder)
	WHERE 
		idfsBaseReference = @ReferenceID
 		--AND ISNULL(strDefault,N'')<>ISNULL(@DefaultName,N'')	
END
ELSE
BEGIN
	INSERT INTO trtBaseReference(
		idfsBaseReference, 
		idfsReferenceType, 
		intHACode, 
		strDefault,
		intOrder
		)
	VALUES(
		@ReferenceID, --idfsBaseReference
		@ReferenceType, --idfsReferenceType
		@HACode, --intHACode
		@DefaultName, --strDefault
		@Order
	)
	Declare @CountryID bigint
	SELECT @CountryID = dbo.fnCurrentCountry()
	IF @CountryID IS NULL
	BEGIN
		EXEC spsysBaseReferenceToCountry_Post @ReferenceID, 170000000 --Azerbaijan
		EXEC spsysBaseReferenceToCountry_Post @ReferenceID, 780000000 --Georgia
		EXEC spsysBaseReferenceToCountry_Post @ReferenceID, 1240000000 --Kazakhstan
	END
	ELSE
	BEGIN
		EXEC spsysBaseReferenceToCountry_Post @ReferenceID, @CountryID
	END

	
END
EXEC spStringTranslation_Post @ReferenceID, @LangID, @DefaultName, @NationalName

End




