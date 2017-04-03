SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCaseSamples_Post]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spCaseSamples_Post]
GO

CREATE PROCEDURE [dbo].[spCaseSamples_Post]
	@Action int, 
	@idfMaterial bigint OUTPUT,
	@strFieldBarcode nvarchar(200),
	@idfsSpecimenType bigint,
	@idfParty bigint,
	@datFieldCollectionDate datetime=NULL,
	@datFieldSentDate datetime=NULL,
	@idfFieldCollectedByOffice bigint=NULL,
	@idfFieldCollectedByPerson bigint=NULL,
	@idfTesting bigint=NULL
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

IF @Action = 4 --insert
BEGIN
	EXECUTE spLabSample_Create 
	   @idfMaterial OUTPUT
	  ,@strFieldBarcode
	  ,@idfsSpecimenType
	  ,@idfParty
	  ,@datFieldCollectionDate
	  ,@datFieldSentDate
	  ,@idfFieldCollectedByOffice
	  ,@idfFieldCollectedByPerson
	  ,@idfTesting
END
ELSE IF @Action = 8 --delete
BEGIN
	EXECUTE spLabSample_Delete 
		@idfMaterial
END
ELSE IF @Action = 16 --update
BEGIN
	EXECUTE spLabSample_Update 
	   @idfMaterial
	  ,@strFieldBarcode
	  ,@idfsSpecimenType
	  ,@idfParty
	  ,@datFieldCollectionDate
	  ,@datFieldSentDate
	  ,@idfFieldCollectedByOffice
	  ,@idfFieldCollectedByPerson
	  ,@idfTesting
END

END
GO