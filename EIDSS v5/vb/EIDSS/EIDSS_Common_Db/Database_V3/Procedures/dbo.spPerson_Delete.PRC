SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPerson_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPerson_Delete]
GO





CREATE   Proc spPerson_Delete
		@idfPerson bigint
As
-- StaffPosition

Update tlbEmployee SET intRowStatus = 1 WHERE idfEmployee = @idfPerson





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

