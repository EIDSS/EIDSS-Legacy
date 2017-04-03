SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleDestruction_Post]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleDestruction_Post]
GO

CREATE PROCEDURE [dbo].[spLabSampleDestruction_Post]
	@idfContainer bigint,
	@idfsContainerStatus bigint,
	@destroy bit,
	@idfDestroyedByPerson bigint=null
	--@idfOffice bigint=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--DECLARE @status nvarchar(20)
	--SET @status='acsUndefined'
	IF @destroy=1
	BEGIN
		
		--SET @status='acsCompleted'
		UPDATE	tlbContainer
		SET		idfsContainerStatus=@idfsContainerStatus,
				idfDestroyedByPerson=@idfDestroyedByPerson,
				datDestructionDate=getdate(),
				idfSubdivision=null--,
				--idfInDepartment=-1 --Disposition
		WHERE	idfContainer=@idfContainer
		--exec spLabSample_Store @idfContainer=@idfContainer,@idfSubdivision=NULL
	END
	ELSE
	BEGIN
		UPDATE	tlbContainer
		SET		idfsContainerStatus=@idfsContainerStatus
		WHERE	idfContainer=@idfContainer
	END
/*
	DECLARE @activity uniqueidentifier
	SELECT @activity=Activity.idfActivity
	FROM Activity INNER JOIN Container_Participation ON Activity.idfActivity=Container_Participation.idfActivity
	WHERE Activity.idfsActivity_Type='actDestruction' AND Container_Participation.idfContainer=@idfContainer AND Activity.intRowStatus=0
	IF @activity IS NULL
	BEGIN
		SET @activity=NEWID()

		INSERT INTO Activity(idfActivity,idfsActivity_Type,idfsActivity_Status) 
		VALUES(@activity,'actDestruction',@status)

		INSERT INTO Lab_Manage_Activity(idfActivity,idfsLab_Manage_Activity_Type) VALUES(@activity,'latDef')

		INSERT INTO Container_Participation(idfActivity,idfContainer) VALUES(@activity,@idfContainer)
	END
	ELSE
	BEGIN
		UPDATE Activity SET idfsActivity_Status=@status
		WHERE idfActivity=@activity
	END
*/
/*	
	if @idfOffice IS NULL
	BEGIN
		DELETE FROM Office_for_Activity
		WHERE idfActivity=@activity AND idfsOffice_for_Activity_Type='oatToDepartment' AND intRowStatus=0
	END
	ELSE
	BEGIN
		UPDATE Office_for_Activity SET idfOffice=@idfOffice
		WHERE idfActivity=@activity AND idfsOffice_for_Activity_Type='oatToDepartment' AND intRowStatus=0
		IF @@ROWCOUNT=0
			INSERT INTO Office_For_Activity(idfActivity,idfOffice,idfsOffice_For_Activity_Type)
			VALUES(@activity,@idfOffice,'oatToDepartment')
	END
*/
END
GO