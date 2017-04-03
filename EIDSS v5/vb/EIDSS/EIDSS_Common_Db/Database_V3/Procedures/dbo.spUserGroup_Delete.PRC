SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUserGroup_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUserGroup_Delete]
GO



CREATE PROCEDURE dbo.spUserGroup_Delete(@ID as bigint)
AS

	DELETE FROM tlbEmployeeGroup
	WHERE idfEmployeeGroup=@ID

RETURN 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

