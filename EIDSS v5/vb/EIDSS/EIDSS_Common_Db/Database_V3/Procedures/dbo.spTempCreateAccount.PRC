SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spTempCreateAccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spTempCreateAccount]
GO







CREATE    proc spTempCreateAccount (
	@Account nvarchar(50),
	@Password nvarchar(50)
)
as

if exists(select * from  master.dbo.syslogins where name=@Account)
begin
	declare @res int
	exec @res = sp_password @Password, @Password, @Account
	if @res = 1
		return
end
else
	exec sp_addlogin  @loginame =  @Account 
     	,  @passwd =  @Password 

declare @UserName varchar(200)

set @UserName = null
select @UserName = a.name
from dbo.sysusers as a
inner join master.dbo.syslogins as b on a.sid = b.sid
where b.name=@Account
if (not @UserName is null)
	exec sp_revokedbaccess @UserName
if exists( select * from dbo.sysusers where name=@Account)
	exec sp_revokedbaccess @Account

--exec sp_droplogin @Account

exec sp_grantdbaccess @Account
exec sp_addsrvrolemember @Account , 'securityadmin'
exec sp_addrolemember 'db_owner',@Account
exec sp_addrolemember 'db_accessadmin',@Account







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

