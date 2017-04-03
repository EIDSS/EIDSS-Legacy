SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMeasureReference_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMeasureReference_Post]
GO





CREATE     PROCEDURE dbo.spMeasureReference_Post 
	@Action INT,-- 4 - Added, 8 - Deleted, 16 - Modified
	@idfsBaseReference BIGINT,
	@idfsReferenceType BIGINT,
	@strDefault VARCHAR(200),
	@strActionCode NVARCHAR(200),
	@Name  NVARCHAR(200),
	@intHACode INT,
	@intOrder INT,
	@LangID  NVARCHAR(50)
AS
BEGIN
	IF @Action = 8
	BEGIN

		DELETE FROM trtSanitaryAction 
		WHERE idfsSanitaryAction = @idfsBaseReference

		DELETE FROM trtProphilacticAction 
		WHERE idfsProphilacticAction = @idfsBaseReference
		
		EXEC spsysBaseReference_Delete @idfsBaseReference
		

	END
	ELSE
	BEGIN
		EXEC dbo.spBaseReference_SysPost 
				@idfsBaseReference,
				@idfsReferenceType,
				@LANGID,
				@strDefault,
				@Name,
				@intHACode,
				@intOrder
		IF @Action = 4 --Added
		BEGIN
			IF @idfsReferenceType = 19000074 --rftProphilacticActionList
				INSERT INTO trtProphilacticAction
				(idfsProphilacticAction, strActionCode) 
                VALUES  (@idfsBaseReference, @strActionCode)
			IF @idfsReferenceType = 19000079 --rftSanitaryActionList
				INSERT INTO trtSanitaryAction
				(idfsSanitaryAction, strActionCode) 
                VALUES  (@idfsBaseReference, @strActionCode)
		END
		IF @Action = 16 --Modified
		BEGIN
			IF @idfsReferenceType = 19000074 --rftProphilacticActionList
				UPDATE trtProphilacticAction
				SET strActionCode = @strActionCode
                WHERE  idfsProphilacticAction = @idfsBaseReference
			IF @idfsReferenceType = 19000079 --rftSanitaryActionList
				UPDATE trtSanitaryAction
				SET strActionCode = @strActionCode
                WHERE  idfsSanitaryAction = @idfsBaseReference
		END
		
	END

END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

