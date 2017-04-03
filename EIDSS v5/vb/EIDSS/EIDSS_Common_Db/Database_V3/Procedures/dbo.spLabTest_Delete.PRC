SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLabTest_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLabTest_Delete]
GO





CREATE     PROCEDURE dbo.spLabTest_Delete(
	@ID as bigint
)
AS

	delete
	from	tlbTesting
	where	tlbTesting.idfTesting=@ID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

