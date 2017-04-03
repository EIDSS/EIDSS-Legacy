SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabBatch_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabBatch_Update]
GO



create proc spLabBatch_Update
	@idfBatchTest bigint,
	@strBarcode varchar(200), 
	@idfsTestType bigint, 

	@datPerformedDate dateTime,
	--@idfPerformedByOffice bigint,
	@idfPerformedByPerson bigint = null,

	@datValidatedDate dateTime, 
	@idfValidatedByPerson bigint = null
as 


update	tlbBatchTest 
set 
		strBarcode = @strBarcode,
		idfsTestType = @idfsTestType,
		datPerformedDate = @datPerformedDate,
		--idfPerformedByOffice = @idfPerformedByOffice,
		idfPerformedByPerson = @idfPerformedByPerson,
		datValidatedDate = @datValidatedDate,
		idfValidatedByPerson = @idfValidatedByPerson
where	idfBatchTest = @idfBatchTest

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
