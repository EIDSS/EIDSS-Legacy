SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spObjectAccess_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spObjectAccess_Post]
GO





CREATE PROCEDURE dbo.spObjectAccess_Post
(
	@Action 				AS int, -- 4 - Added, 8 - Deleted, 16 - Modified
--	@LanguageID 			As nvarchar(50),

	@idfObjectAccess		AS bigint,
	@idfsObjectID				AS bigint	= NULL,
	@idfsObjectType				AS bigint 	= NULL,
	@idfActor				AS bigint	= NULL,
--	@ActorTypeID			AS varchar(36) 		= NULL,
	@idfsObjectOperation	AS bigint 	= NULL,
	@intPermission			AS int 		= NULL,
	@idfsOnSite				AS bigint
)
AS

--DECLARE @idfsSite 			bigint
--DECLARE @idfUserID 			bigint
--DECLARE @AccessID 			bigint
--DECLARE @ObjectTypeID		bigint

-- Get user code
--SET @idfUserID = NULL
-- Get site code
--SELECT @idfsSite = dbo.fnSiteID()

-- Add or Modify
IF @Action = 4 OR @Action = 16
BEGIN
	--BEGIN TRANSACTION 
	--SET @AccessID = NULL

	-- Get type ID
	--SET @ObjectTypeID=@ObjectType
	--SELECT @ObjectTypeID = LB.idfsReference
	--FROM fnReference(@LanguageID, 'rftObjectType') AS LB
	--WHERE LB.strDefault = @ObjectType

	UPDATE	tstObjectAccess
	SET		intPermission = @intPermission
	WHERE	idfObjectAccess = @idfObjectAccess

	IF @@ROWCOUNT=0
		INSERT INTO	tstObjectAccess
		(
			idfObjectAccess,
			idfsObjectType,
			idfsObjectID,
			idfsObjectOperation,
			idfActor,
			intPermission,
			idfsOnSite
		)
		VALUES
		(
			@idfObjectAccess,
			@idfsObjectType,
			@idfsObjectID,
			@idfsObjectOperation,
			@idfActor,
			@intPermission,			
			@idfsOnSite
		)
	--END IF

/*
	SELECT 	@AccessID = OA.idfObjectAccess
	FROM 	ObjectAccess OA
	WHERE OA.idfObjectAccess = @idfObjectAccess 
	--
	AND OA.intRowStatus = 0 
	AND OA.idfsOnSite=@OnSite

	IF(@AccessID IS NULL)
	BEGIN
		SET @AccessID = NEWID()
		INSERT INTO  ObjectAccess
		(
			idfObjectAccess,
			idfsObjectType,
			idfsObjectOperation,
			idfsActorType,
			idfsObjectID,
			idfActorID,
			intPermission,

			idfsOnSite
		)
		VALUES
		(
			@idfObjectAccess, 				-- idfObjectAccess
			@ObjectTypeID, 			-- idfsObjectType
			@idfsObjectOperationID, -- idfsObjectOperation
			@ActorTypeID, 			-- idfsActorType
			@ObjectID, 				-- idfsObjectID
			@ActorID, 				-- idfActorID
			@Permission, 			-- intPermission
			
			@OnSite
		)
	END
	ELSE
	BEGIN
		UPDATE ObjectAccess SET intPermission = @Permission WHERE idfObjectAccess = @AccessID
	END
	COMMIT*/
END
-- Delete
IF @Action = 8
BEGIN
	DELETE FROM tstObjectAccess 
	WHERE idfObjectAccess = @idfObjectAccess
	--
	AND intRowStatus = 0 
	AND idfsOnSite=@idfsOnSite
END
RETURN 0
/*
select * from ObjectAccess
where 	idfObjectAccess = isnull(idfBaseID, idfObjectAccess)
		AND ISNULL(intRowStatus, 0) = 0 


exec spObjectAccess_Post @Action = 8, @LanguageID = N'en', @ObjectID = N'rootCultureTreeNode', @idfObjectAccess = 'FB5DD0CE-EBF3-4756-82D1-28A1E9B2A496'
exec spObjectAccess_Post @Action = 8, @LanguageID = N'en', @ObjectID = N'rootCultureTreeNode', @idfObjectAccess = '6106800E-BF93-4650-ACAD-5FE080D45101'
exec spObjectAccess_Post @Action = 8, @LanguageID = N'en', @ObjectID = N'rootCultureTreeNode', @idfObjectAccess = 'B527D188-CBC1-4E34-B687-707DAA474ED4'

exec spObjectAccess_Post @Action = 16, @LanguageID = N'en', @ObjectID = N'rootCultureTreeNode', @idfObjectAccess = '41A65210-BDBB-4BE2-A924-EC796BA227B8', @ObjectType = N'Culture', @ActorID = 'A9386DB9-53A0-451D-A62B-01BED384DF5A', @ActorTypeID = N'acrPerson', @idfsObjectOperationID = N'ObjectOperationCreate', @Permission = 1
exec spObjectAccess_Post @Action = 16, @LanguageID = N'en', @ObjectID = N'rootCultureTreeNode', @idfObjectAccess = 'B57F1907-FDBA-4DE6-944A-F3D57B05240E', @ObjectType = N'Culture', @ActorID = 'A9386DB9-53A0-451D-A62B-01BED384DF5A', @ActorTypeID = N'acrPerson', @idfsObjectOperationID = N'ObjectOperationWrite', @Permission = 1
*/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

