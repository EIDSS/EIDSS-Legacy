SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUserGroup_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUserGroup_Post]
GO


CREATE PROCEDURE dbo.spUserGroup_Post
(
	@Action 				AS int, -- 4 - Added, 8 - Deleted, 16 - Modified

	@ID						AS bigint = NULL,	
	@strName				AS nvarchar(200) = NULL,
	@strNationalName		AS nvarchar(200) = NULL,
	@idfsEmployeeGroupName	AS bigint = NULL,
	@strDescription			AS nvarchar(200) = NULL,
	@LANGID					As nvarchar(50) = 'en'

)
AS
--DECLARE @idfsSite 			varchar(36)
--DECLARE @idfUserID 			uniqueidentifier

-- Get user code
--SET @idfUserID = NULL
-- Get site code
--SELECT @idfsSite = dbo.fnSiteID()

-- Add or Modify
IF @Action = 4
BEGIN
	if @idfsEmployeeGroupName IS NULL
		exec spsysGetNewID @idfsEmployeeGroupName OUTPUT

	INSERT INTO tlbEmployee
	(
		idfEmployee,
		idfsEmployeeType
	)
	VALUES 
	(
		@ID,
		10023001 --group
	)

	EXEC spBaseReference_SysPost @idfsEmployeeGroupName, 19000022, @LANGID, @strName, @strNationalName, 0 

	INSERT INTO tlbEmployeeGroup
	(
		idfEmployeeGroup,
		strName,
		strDescription,
		idfsEmployeeGroupName
	)
	VALUES 
	(
		@ID,
		@strName,
		@strDescription,
		@idfsEmployeeGroupName
	)
END
-- Modify
IF @Action = 16
BEGIN
--	BEGIN TRANSACTION 
		if @idfsEmployeeGroupName IS NULL
			exec spsysGetNewID @idfsEmployeeGroupName OUTPUT
		if @LANGID = 'en'
			SET @strNationalName = @strName
		EXEC spBaseReference_SysPost @idfsEmployeeGroupName, 19000022, @LANGID, @strName, @strNationalName, 0 

		UPDATE	tlbEmployeeGroup
		SET		strName = @strName,
				strDescription = @strDescription,
				idfsEmployeeGroupName = @idfsEmployeeGroupName
		WHERE	idfEmployeeGroup = @ID
--	COMMIT
END
-- Delete
IF @Action = 8
BEGIN
/*	IF(EXISTS(SELECT * FROM Employee_Relationship WHERE idfParent_Employee = @ID AND intRowStatus = 0 ))
	BEGIN
	   RAISERROR ('Cannot remove group. Group is not empty.', 16, 1)
	   ROLLBACK TRANSACTION
	END*/
	-- Drop relations
	--DELETE FROM Employee_Relationship WHERE idfRelated_Employee = @ID
	-- Drop item
	DELETE FROM tlbEmployeeGroup WHERE idfEmployeeGroup = @ID
	DELETE FROM tlbEmployee WHERE idfEmployee = @ID
	DELETE FROM trtStringNameTranslation 
	WHERE idfsBaseReference = @idfsEmployeeGroupName

	DELETE FROM 	dbo.trtBaseReference
	WHERE 
		idfsBaseReference = @idfsEmployeeGroupName 

END
/*
select * from Employee where idfsEmployee_Type = 'emtGroup'
exec spUserGroup_Post @Action = 4, @ID = '88BD3886-FB4A-4DA7-9C34-BB67B6DC0720', @Name = N'GName', @Description = N'GDescription'
*/


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

