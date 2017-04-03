SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUserGroupContent_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUserGroupContent_Post]
GO


CREATE PROCEDURE dbo.spUserGroupContent_Post
(
	@Action 				AS int, -- 4 - Added, 8 - Deleted, 16 - Modified

	@ID						AS bigint,
	@MemberID				AS bigint
)
AS
--DECLARE @idfsSite 			varchar(36)
--DECLARE @idfUserID 			uniqueidentifier

-- Get user code
--SET @idfUserID = NULL
-- Get site code
--SELECT @idfsSite = dbo.fnSiteID()

-- Add or Modify
IF @Action = 4 OR @Action = 16
BEGIN
	IF((@ID IS NULL) OR (@MemberID IS NULL))
	BEGIN
	   RAISERROR ('Invalid argument list', 16, 1)
	END

	UPDATE	tlbEmployeeGroupMember
	SET		intRowStatus = 0 
	WHERE	tlbEmployeeGroupMember.idfEmployeeGroup=@ID
			AND tlbEmployeeGroupMember.idfEmployee = @MemberID
	
	IF @@ROWCOUNT=0
	BEGIN
		--DECLARE @membership bigint
		--exec spsysGetNewID @id=@membership out
		INSERT INTO	tlbEmployeeGroupMember
		(
			--idfEmployeeGroupMember,
			idfEmployeeGroup,
			idfEmployee
		)
		VALUES
		(
			--@membership,
			@ID,
			@MemberID
		)
	END
END
-- Delete
IF @Action = 8
BEGIN
	IF((@ID IS NULL) OR (@MemberID IS NULL))
	BEGIN
	   RAISERROR ('Invalid argument list', 16, 1)
	END
	-- Drop relations
	DELETE FROM	tlbEmployeeGroupMember
	WHERE		idfEmployeeGroup = @ID AND
				idfEmployee = @MemberID AND 
				intRowStatus = 0
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

