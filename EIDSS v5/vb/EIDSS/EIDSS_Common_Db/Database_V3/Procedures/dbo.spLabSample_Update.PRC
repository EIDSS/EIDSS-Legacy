SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSample_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSample_Update]
GO

CREATE PROCEDURE [dbo].[spLabSample_Update] 
	@idfMaterial bigint,
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

declare @status as int

select @status = intRowStatus from tlbMaterial
				 where idfMaterial=@idfMaterial
   
if @status = 1
   set @status = 0

UPDATE	tlbMaterial
set
		strFieldBarcode=@strFieldBarcode,
		idfsSpecimenType=@idfsSpecimenType,
		idfParty=@idfParty,
		idfFieldCollectedByOffice=@idfFieldCollectedByOffice,
		idfFieldCollectedByPerson=@idfFieldCollectedByPerson,
		datFieldCollectionDate=@datFieldCollectionDate,
		datFieldSentDate=@datFieldSentDate,
		idfTesting=@idfTesting,
		intRowStatus=@status
where	idfMaterial=@idfMaterial

END

GO