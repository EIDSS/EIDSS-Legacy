SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCheckPermission]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spCheckPermission]
GO

/*
declare @ret integer
exec @ret=spCheckPermission 0,0,0
select @ret
*/

CREATE PROCEDURE spCheckPermission
	@idfsSystemFunction bigint,
	@idfsObjectOperation bigint,
	@idfObjectID bigint
AS
BEGIN

	declare	@user bigint
	set @user=dbo.fnUserID()

	DECLARE @permission bit
	set		@permission=0

	declare	@employee as bigint

	select	@employee=tstUserTable.idfPerson
	from	tstUserTable
	where	tstUserTable.idfUserID=@user

	select	@permission=Case when intPermission=2 then 1 else 0 end
	from	fnEvaluatePermissions(@employee)
	where	idfsSystemFunction=@idfsSystemFunction and idfsObjectOperation=@idfsObjectOperation

	exec spLogSecurityEvent
		@idfUserID=@user,
		@idfsAction=10110004,
		@success=@permission,
		@idfObjectID=@idfObjectID

	RETURN @permission

END
GO
