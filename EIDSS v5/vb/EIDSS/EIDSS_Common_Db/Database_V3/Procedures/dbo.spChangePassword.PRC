IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spChangePassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spChangePassword]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--##SUMMARY Change password for specified user
--##SUMMARY Current password should be encoded according Login procedure
--##SUMMARY New password should be in hashed
--##SUMMARY After this procedure password should be changed

--##REMARKS Author: Kletkin
--##REMARKS Create date: 31.05.2010

--##RETURNS @Result parameter returns the error code
--##RETURNS			0 - No errors
--##RETURNS 		1 - One of mandatory input parameters is not defined
--##RETURNS 		2 - User with such login/password is not found
--##RETURNS 		6 - Login is locked after 3 unsuccessfull login attempt. 
--##RETURNS			7 - Invalid parameter.
--##RETURNS			8 - Password policy violated.

/*
--Example of procedure call:
nothing
*/

CREATE            PROCEDURE [dbo].[spChangePassword]( 
	@Organization AS NVARCHAR(200),--##PARAM @Organization - organization abbreviation
	@UserName AS NVARCHAR(200),--##PARAM @UserName - user login
	@CurrentPassword AS VARBINARY(MAX), --##PARAM @Password - user password
	@NewPassword AS VARBINARY(MAX), --##PARAM @Password - user password
	@Result AS INTEGER OUTPUT--##PARAM @Result - returns extended result of login attempt. 0 means successfull login, other value is the error code.
)
AS

if DATALENGTH(@NewPassword)<20
begin
	set @Result=7
	return
end

declare @idfUser as bigint

exec spLoginUserInternal @Organization,@UserName,@CurrentPassword,1,@Result output,@idfUser output
if @Result<>0 return

declare @count int
select	@count=intPasswordHistoryLength
from	fnPolicyValue()

if @count>0
begin
	/*if exists(
		select	top(@count-1) idfUserID
		from	tstUserTableOldPassword
		where	idfUserID=@idfUser and
				intRowStatus=0 and
				blbOldPassword=@NewPassword
		order by datExpiredDate desc
		union
		select	idfUserID
		from	tstUserTable
		where	idfUserID=@idfUser and
				intRowStatus=0 and
				blbPassword=@NewPassword
	)*/
	
	if @NewPassword in
		(
		select	top(@count-1) binOldPassword
		from	tstUserTableOldPassword
		where	idfUserID=@idfUser and
				intRowStatus=0
		order by datExpiredDate desc
		union
		select	binPassword
		from	tstUserTable
		where	idfUserID=@idfUser		
		)
	begin
		set @Result=8
		return
	end
end

declare @pid bigint
exec spSysgetNewID @pid out

insert into tstUserTableOldPassword(
		idfUserOldPassword,
		idfUserID,
		datExpiredDate,
		binOldPassword)
select	@pid,
		@idfUser,
		getutcdate(),
		binPassword
from	tstUserTable
where	idfUserID=@idfUser

set @Result=0

update	tstUserTable
set		binPassword=@NewPassword,
		datPasswordSet=getutcdate()
where	idfUserID=@idfUser

return
