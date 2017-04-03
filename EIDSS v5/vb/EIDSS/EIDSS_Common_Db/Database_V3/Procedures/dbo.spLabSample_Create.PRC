SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSample_Create]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSample_Create]
GO

CREATE PROCEDURE [dbo].[spLabSample_Create] 
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

DECLARE @datRegistrationDate as datetime
SET @datRegistrationDate =GETDATE()

--DECLARE @NextNumberValue nvarchar(200)
--exec spGetNextNumber 'nbtSampleNumber', @NextNumberValue OUTPUT, NULL
IF (@idfMaterial IS NULL) OR EXISTS (SELECT idfMaterial FROM tlbMaterial WHERE idfMaterial = @idfMaterial)
BEGIN
	EXEC spsysGetNewID @idfMaterial OUTPUT
END	
-- insert Material
INSERT INTO	tlbMaterial(
				idfMaterial,
				idfParentMaterial,
				idfRootParentMaterial,
				strFieldBarcode,
				idfsSpecimenType,
				idfParty,
				idfFieldCollectedByOffice,
				idfFieldCollectedByPerson,
				datFieldCollectionDate,
				datFieldSentDate,
				idfTesting)
VALUES		(
				@idfMaterial,
				null,
				@idfMaterial,
				@strFieldBarcode,
				@idfsSpecimenType,
				@idfParty,
				@idfFieldCollectedByOffice,
				@idfFieldCollectedByPerson,
				@datFieldCollectionDate,
				@datFieldSentDate,
				@idfTesting)

END

GO