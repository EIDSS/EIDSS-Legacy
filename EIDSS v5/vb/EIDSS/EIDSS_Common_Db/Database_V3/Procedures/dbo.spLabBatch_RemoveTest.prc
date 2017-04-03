
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabBatch_RemoveTest]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabBatch_RemoveTest]
GO 


create proc spLabBatch_RemoveTest
 @idfBatchTest bigint,
 @idfTesting bigint
as

update	tlbTesting
set		idfBatchTest=null
where	idfTesting=@idfTesting and idfBatchTest=@idfBatchTest

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

