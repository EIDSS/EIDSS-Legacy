SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleTransfer_Receive]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleTransfer_Receive]
GO

CREATE PROCEDURE [dbo].[spLabSampleTransfer_Receive] 
	@idfTransferIn bigint, --transferIn
	@idfTransferOut bigint, --transferIn
	@strBarcode nvarchar(200),--new container barcode
--	@idfOldContainer bigint, --source container
	@idfContainer bigint, --source container
	@idfContainerNew bigint,--newly created container
	@idfMaterial bigint,
	@datCreationDate datetime, --date received
	@strNote nvarchar(200),
	@strCondition nvarchar(200),
	@idfSubdivision bigint,
	@idfInDepartment bigint,
	@idfReceivedByPerson bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	exec spLabSample_Store @idfSubdivision=@idfSubdivision, @idfContainer=@idfContainer

	INSERT INTO tlbContainer(
			idfContainer,
			idfParentContainer,
			idfRootParentContainer,
			datCreationDate,
			idfMaterial,
			idfsContainerStatus,
			strBarcode,
			idfInDepartment,
			--idfSubdivision,
			strNote
			)
	VALUES	(
			@idfContainerNew,
			@idfContainer,
			@idfContainerNew,
			@datCreationDate,
			@idfMaterial,
			10015007, --'cotInRepository'
			@strBarcode,
			@idfInDepartment,
			--@idfSubdivision,
			@strNote
			)

	insert into tlbTransferIn(
			idfTransferIn,
			idfContainer,
			idfOldContainer,
			idfReceivedByPerson,
			idfTransferOut,
			--strNote,
			strCondition
			)
	values	(
			@idfTransferIn,
			@idfContainerNew,
			@idfContainer,
			@idfReceivedByPerson,
			@idfTransferOut,
			--@strNote,
			@strCondition
			)

	exec spLabSampleOnSite @idfMaterial
END
GO