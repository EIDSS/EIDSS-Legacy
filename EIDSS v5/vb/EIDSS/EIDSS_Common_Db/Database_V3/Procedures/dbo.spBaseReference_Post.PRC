SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spBaseReference_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spBaseReference_Post]
GO


--##SUMMARY Posts data from ReferenceDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
DECLARE @Action int
DECLARE @idfsBaseReference bigint
DECLARE @idfsReferenceType bigint
DECLARE @strDefault varchar(200)
DECLARE @Name nvarchar(200)
DECLARE @intHACode int
DECLARE @intOrder int
DECLARE @LangID nvarchar(50)

EXECUTE spBaseReference_Post
   @Action
  ,@idfsBaseReference
  ,@idfsReferenceType
  ,@strDefault
  ,@Name
  ,@intHACode
  ,@intOrder
  ,@LangID

*/




CREATE     PROCEDURE dbo.spBaseReference_Post 
	@Action INT, --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
	@idfsBaseReference BIGINT, --##PARAM @idfsBaseReference - reference ID
	@idfsReferenceType BIGINT, --##PARAM @idfsReferenceType - reference type ID
	@strDefault VARCHAR(200), --##PARAM @strDefault - default reference name, used if there is no refernece translation
	@Name  NVARCHAR(200), --##PARAM @Name - reference name in the language defined by @LangID
	@intHACode INT, --##PARAM @intHACode - bit mask for reference using
	@intOrder INT, --##PARAM @intOrder - reference record order for sorting
	@LangID  NVARCHAR(50) --##PARAM @LangID - language ID

AS
BEGIN
	IF @Action = 8
	BEGIN
		--This is the temporary fix, we should create special editor for Species list
		IF @idfsReferenceType = 19000086 --rftSpeciesList
		BEGIN
			DELETE FROM  dbo.trtSpeciesTypeToAnimalAge
			WHERE idfsSpeciesType = @idfsBaseReference
			DELETE FROM  dbo.trtSpeciesType
			WHERE idfsSpeciesType = @idfsBaseReference
		END
		DELETE FROM trtStringNameTranslation 
		WHERE idfsBaseReference = @idfsBaseReference
		DELETE FROM trtBaseReference 
		WHERE idfsBaseReference = @idfsBaseReference
	END
	ELSE
	BEGIN
		EXEC dbo.spBaseReference_SysPost 
				@idfsBaseReference,
				@idfsReferenceType,
				@LangID,
				@strDefault,
				@Name,
				@intHACode,
				@intOrder
	END
	--This is the temporary fix, we should create special editor for Species list
	IF @idfsReferenceType = 19000086 --Species List
	BEGIN
		IF @Action = 4
		BEGIN
			INSERT INTO trtSpeciesType
			   (
					[idfsSpeciesType]
			   )
			VALUES
			   (
				@idfsBaseReference
			   )			
		END
	END

END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

