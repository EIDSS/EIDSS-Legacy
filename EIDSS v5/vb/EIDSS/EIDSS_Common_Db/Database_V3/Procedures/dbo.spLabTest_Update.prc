SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabTest_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabTest_Update]
GO
 


create proc [dbo].[spLabTest_Update]
	@idfTesting bigint,
	@idfsTestResult bigint=null,
	@intTestNumber int=null,
	@idfsTestStatus bigint=null
as 

update	tlbTesting
set		
		idfsTestResult = IsNull(@idfsTestResult,idfsTestResult),
		idfsTestStatus = IsNull(@idfsTestStatus,idfsTestStatus),
		intTestNumber = @intTestNumber
where	idfTesting=@idfTesting

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
