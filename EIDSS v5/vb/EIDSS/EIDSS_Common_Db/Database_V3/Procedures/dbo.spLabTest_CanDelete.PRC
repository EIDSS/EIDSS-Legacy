SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabTest_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabTest_CanDelete]
GO

CREATE            PROCEDURE dbo.spLabTest_CanDelete( 
	@ID as bigint,
	@Result as bit output
)
AS

if exists(
	select		tlbTesting.idfTesting
	from		tlbTesting
	inner join	tlbBatchTest
	on			tlbTesting.idfTesting=@ID and
				tlbBatchTest.idfBatchTest=tlbTesting.idfBatchTest and
				tlbTesting.intRowStatus=0 and
				tlbBatchTest.idfsBatchStatus=10001001--Completed
	)
	set @Result=0
else
	set @Result=1

return @Result

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

