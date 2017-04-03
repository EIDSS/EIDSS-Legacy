SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spOutbreak_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spOutbreak_Delete]
GO





CREATE    PROCEDURE dbo.spOutbreak_Delete
	@ID AS bigint
as
DECLARE @RC AS BIT
EXEC spOutbreak_CanDelete @ID, @RC OUTPUT
IF @RC = 0
	RETURN -1

delete from tlbOutbreakNote
where idfOutbreak = @ID

delete from tlbOutbreak
where idfOutbreak = @ID

update tlbCase
set idfOutbreak = null
WHERE idfOutbreak = @ID

RETURN 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

