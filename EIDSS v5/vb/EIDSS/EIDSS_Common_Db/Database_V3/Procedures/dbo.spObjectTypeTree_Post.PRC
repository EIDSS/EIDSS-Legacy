SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spObjectTypeTree_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spObjectTypeTree_Post]
GO




CREATE PROCEDURE dbo.spObjectTypeTree_Post
(
	@idfsParentObjectType	AS bigint,
	@idfsRelatedObjectType	AS bigint,
	@idfsStatus				AS bigint
)
AS

IF @idfsStatus=10107001 --'brrObjectTypeINACTIVE'
BEGIN
	DELETE
	FROM	trtObjectTypeToObjectType 
	WHERE	idfsParentObjectType=@idfsParentObjectType AND
			idfsRelatedObjectType=@idfsRelatedObjectType AND
			intRowStatus = 0
END
ELSE
BEGIN
	UPDATE	trtObjectTypeToObjectType 
	SET		idfsStatus=@idfsStatus
	WHERE	idfsParentObjectType=@idfsParentObjectType AND
			idfsRelatedObjectType=@idfsRelatedObjectType AND
			intRowStatus = 0
	
	IF @@ROWCOUNT=0
	BEGIN
		INSERT INTO trtObjectTypeToObjectType 
			(
				idfsParentObjectType,
				idfsRelatedObjectType,
				idfsStatus
			) 
		VALUES
			(
				@idfsParentObjectType,
				@idfsRelatedObjectType,
				@idfsStatus
			)
	END

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

