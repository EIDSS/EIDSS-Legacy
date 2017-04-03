SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabBatch_Create]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabBatch_Create]
GO 

CREATE proc [dbo].[spLabBatch_Create]
	@idfBatchTest bigint,
	@idfsTestType bigint,
	@idfPerformedByOffice bigint,
	@strBarcode nvarchar(200)=null,
	@idfObservation bigint
as 

-- Get barcode number for new Batch
DECLARE @SiteID bigint
set @SiteID = dbo.fnSiteID()

if(@strBarcode is null)
	exec dbo.spGetNextNumber 10057005 , @strBarcode OUTPUT, NULL --'nbtBatchTest'

insert into	tlbObservation(idfObservation) values(@idfObservation)

insert into	tlbBatchTest(
		idfBatchTest,
		strBarcode,
		idfsTestType,
		idfPerformedByOffice,	
		idfObservation,
		idfsBatchStatus,
		idfsSite
)
values(
		@idfBatchTest,
		@strBarcode,
		@idfsTestType,
		@idfPerformedByOffice,
		@idfObservation,
		10001003, --In Process
		@SiteID
)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

