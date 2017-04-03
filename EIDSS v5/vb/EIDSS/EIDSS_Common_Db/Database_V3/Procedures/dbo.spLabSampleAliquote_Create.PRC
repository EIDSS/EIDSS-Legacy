SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleAliquote_Create]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleAliquote_Create]
GO

CREATE PROCEDURE [dbo].[spLabSampleAliquote_Create] 
	-- Add the parameters for the stored procedure here
	--@idfMaterial bigint,
	@idfContainer bigint,
	@idfParentContainer bigint,
	--@idfRootParentContainer bigint,
	@strBarcode nvarchar(200)/*,
	@idfOffice bigint,
	@idfEmployee bigint*/
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	declare @idfRootParentContainer bigint
	declare @idfMaterial bigint

	select	
			@idfRootParentContainer=idfRootParentContainer,
			@idfMaterial=idfMaterial
	from	tlbContainer
	where	idfContainer=@idfParentContainer

	SET NOCOUNT ON;
	INSERT INTO tlbContainer(
				idfContainer,
				idfParentContainer,
				idfRootParentContainer,
				datCreationDate,
				strBarcode,
				idfMaterial,
				idfsContainerStatus) 
	VALUES(
				@idfContainer,
				@idfParentContainer,
				@idfRootParentContainer,
				GETUTCDATE(),
				@strBarcode,
				@idfMaterial,
				10015007/*'cotInRepository'*/)

	--DECLARE @idfSplitting uniqueidentifier
	--SET @idfSplitting=NEWID()
	
	--INSERT INTO Activity(idfActivity,idfsActivity_Type,idfsActivity_Status,datStartDate)
	--VALUES(@idfSplitting,'actSplitting','acsUndefined',GETDATE())
	--INSERT INTO Lab_Manage_Activity(idfActivity,idfsLab_Manage_Activity_Type) VALUES(@idfSplitting,'latDef')

	--associate container with activity
	--INSERT INTO Container_Participation(idfActivity,idfContainer) VALUES(@idfSplitting,@idfContainer)

	-- log who receive material
	--INSERT INTO Office_for_Activity(idfOffice,idfActivity,idfsOffice_for_Activity_Type) VALUES(@idfOffice,@idfSplitting,'oatPerformedBy')
	--INSERT INTO Employee_for_Activity(idfEmployee,idfActivity,idfsEmployee_for_Activity_Type) VALUES(@idfEmployee,@idfSplitting,'eatPerformedBy')
END
GO
