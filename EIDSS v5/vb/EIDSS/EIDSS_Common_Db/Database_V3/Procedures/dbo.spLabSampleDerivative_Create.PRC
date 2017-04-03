SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleDerivative_Create]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleDerivative_Create]
GO

CREATE PROCEDURE [dbo].[spLabSampleDerivative_Create]
	-- Add the parameters for the stored procedure here
	@idfContainer bigint,
	@idfParentContainer bigint,
	--@idfRootParentContainer bigint,
	@idfMaterial bigint,
	@idfsSpecimenType bigint,
	@strBarcode nvarchar(200)/*,
	@idfEmployee uniqueidentifier=null,
	@idfOffice uniqueidentifier=null*/
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--declare @idfRootParentContainer bigint
	declare @idfParentMaterial bigint
	declare @strFieldBarcode nvarchar(200)
	declare @idfParty bigint
	declare @idfRootParentMaterial bigint

	select	
				--@idfRootParentContainer=idfRootParentContainer,
				@idfParentMaterial=tlbMaterial.idfMaterial,
				@idfRootParentMaterial=idfRootParentMaterial,
				@strFieldBarcode=strFieldBarcode,
				@idfParty=idfParty
	from		tlbContainer
	inner join	tlbMaterial
	on			tlbMaterial.idfMaterial=tlbContainer.idfMaterial
	where		idfContainer=@idfParentContainer

	insert into	tlbMaterial(
					idfMaterial,
					idfParentMaterial,
					idfRootParentMaterial,
					strFieldBarcode,
					--idfsMaterial_Type,
					idfsSpecimenType,
					idfParty,
					idfFieldCollectedByOffice,
					idfFieldCollectedByPerson,
					--datRegistration_Date,
					datFieldCollectionDate,
					datFieldSentDate)
	values		(
					@idfMaterial,
					@idfParentMaterial,
					@idfRootParentMaterial,
					@strFieldBarcode,
					--@idfsMaterial_Type,
					@idfsSpecimenType,
					@idfParty,
					null/*@idfFieldCollectedByOffice*/,
					null/*@idfFieldCollectedByPerson*/,
					--@datRegistrationDate,
					null/*@datFieldCollectedDate*/,
					null/*@datFieldSentDate*/)



--mark material as located on this site
	exec spLabSampleOnSite @idfMaterial

	insert into tlbContainer(
				idfContainer,
				idfParentContainer,
				idfRootParentContainer,
				idfsContainerStatus,
				datCreationDate,
				strBarcode,
				idfMaterial
				)
	VALUES(
				@idfContainer,
				@idfParentContainer,
				@idfContainer,
				10015007,--inRepository
				GETUTCDATE(),
				@strBarcode,
				@idfMaterial
			)

END
GO
