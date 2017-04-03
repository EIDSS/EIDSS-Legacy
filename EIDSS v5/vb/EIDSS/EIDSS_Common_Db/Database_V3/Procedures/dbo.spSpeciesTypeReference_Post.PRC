SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSpeciesTypeReference_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSpeciesTypeReference_Post]
GO





CREATE     PROCEDURE dbo.spSpeciesTypeReference_Post 
	@Action INT,-- 4 - Added, 8 - Deleted, 16 - Modified
	@idfsBaseReference BIGINT,
	--@idfsReferenceType BIGINT,
	@strDefault VARCHAR(200),
	@strCode NVARCHAR(50),
	@Name  NVARCHAR(200),
	@intHACode INT,
	@intOrder INT,
	@LangID  NVARCHAR(50)
AS
BEGIN
	
	Declare @idfsReferenceType BIGINT
	Select @idfsReferenceType = 19000086

	IF @Action = 8
	BEGIN

		DELETE FROM  trtSpeciesType
		WHERE idfsSpeciesType = @idfsBaseReference
		
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
			INSERT INTO trtSpeciesType
			(idfsSpeciesType, strCode) 
            VALUES  (@idfsBaseReference, @strCode)
		END
		IF @Action = 16 --Modified
		BEGIN
			UPDATE trtSpeciesType
			SET strCode = @strCode
            WHERE idfsSpeciesType = @idfsBaseReference
		END
		
	END

END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

