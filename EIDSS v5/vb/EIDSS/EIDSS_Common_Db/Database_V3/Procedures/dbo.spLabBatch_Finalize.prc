SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabBatch_Finalize]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabBatch_Finalize]
GO 
 
 
create proc [dbo].[spLabBatch_Finalize]
	@idfBatchTest bigint
as 
 -- 1. Close tests of batch - Set status - Complite
	update	tlbBatchTest
	set		idfsBatchStatus=10001001
	where	idfBatchTest=@idfBatchTest

	update	tlbTesting
	set		idfsTestStatus=10001001
	where	idfBatchTest=@idfBatchTest

/*
	-- 2. Set tests' Complite date

	-- Get date from batch
	declare @TestedDate datetime
	select @TestedDate=datStartDate from activity where idfActivity = @BatchID

	update t set datComplete_Date=@TestedDate
	from 
	testing t 
	inner join activity_relationship rel
		on (rel.idfRelated_Activity=t.idfActivity 
			and idfsActivity_Relation_Type='artTestToBatch' 
			and rel.intRowStatus=0
			)
	where rel.idfParent_Activity = @BatchID

	 -- 3. Close batch
	update Activity 
		set idfsActivity_Status='acsCompleted',
			datFinishDate = getdate()
	where idfActivity = @BatchID
*/





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

