SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabBatch_AddTest]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabBatch_AddTest]
GO


create proc spLabBatch_AddTest
 @idfBatchTest bigint,
 @idfTesting bigint

as 

update	tlbTesting
set		idfBatchTest=@idfBatchTest, idfsTestStatus = 10001003
where	idfTesting=@idfTesting and idfBatchTest is null

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

