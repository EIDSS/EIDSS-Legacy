SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleTransfer_Send]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleTransfer_Send]
GO

CREATE PROCEDURE [dbo].[spLabSampleTransfer_Send]
	@idfContainer bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @barcode nvarchar(200)
	declare @test bigint

	select		top 1
				@test=tlbTesting.idfTesting,
				@barcode=tlbContainer.strBarcode
	from		tlbTesting
	inner join	tlbContainer
	on			tlbContainer.idfContainer=tlbTEsting.idfContainer and
				tlbContainer.intRowStatus=0
	where		tlbTesting.idfContainer=@idfContainer and
				tlbTesting.intRowStatus=0 and
				tlbTesting.idfsTestStatus=10001005

	if @test is not null
	begin
			    RAISERROR ('errContainerTransfer %s', 16, 1, @barcode)
	end

	UPDATE	tlbContainer
	SET		idfsContainerStatus=10015010,--cotOutOfRepository
			idfSubdivision=null
	WHERE	idfContainer=@idfContainer
	
	--exec spLabSample_Store @idfContainer=@idfContainer,@idfSubdivision=NULL
END
GO