IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLoginUserInternal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLoginUserInternal]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY Performs login to the system.
--##SUMMARY Login uses @Organization, @UserName, @Password
--##SUMMARY Password encoded using Challenge value returned by spLoginChallenge
--##SUMMARY After successfull login current connection context is assotiated with @ClientID and user defined by login.

--##REMARKS Author: Kletkin
--##REMARKS Create date: 31.05.2010

--##RETURNS @Result parameter returns the extended error code
--##RETURNS 		0 - No errors
--##RETURNS 		2 - User with such login/password is not found
--##RETURNS 		6 - Login is locked after 3 unsuccessfull login attempt. 

--@Flags 1-skip expiration check

/*
--Example of procedure call:
*/

CREATE PROCEDURE [dbo].[spLoginUserInternal]
	@Organization as nvarchar(200),--##PARAM @Organization - organization abbreviation
	@UserName as nvarchar(200),--##PARAM @UserName - user login
	@Password as varbinary(max),--##PARAM @Password - user password
	@Flags as int=null,
	@Result as int output,
	@UserID as bigint output
AS
BEGIN

	declare @context nvarchar(100)
	set @context=dbo.fnGetContext()

	declare @localSite bigint
	select	@localSite=strValue
	from	tstLocalSiteOptions 
	where	strName='SiteID'

	declare @challenge varbinary(max)
	select	@challenge=binChallenge
	from	tstLocalConnectionContext
	where	strConnectionContext=@context

	Declare @error2 Nvarchar(255), @error6 Nvarchar(255) 
	Select @error2 = 'User with such login/password is not found',
			@error6 = 'Login is locked' ;

	if @challenge is null
	Begin	
		exec spLogSecurityEvent @UserID,10110000,0, @error2	
		set @Result=2
		return
	end

	--declare @timestamp as datetime
	--set @timestamp=DATEADD(minute,-30,GETDATE())

	--declare @user bigint
	declare	@storedPassword varbinary(max)
	declare @tryCount int
	declare @person bigint
	declare @userSite bigint
	declare @firstName nvarchar(200)
	declare @secondName nvarchar(200)
	declare @familyName nvarchar(200)
	declare @institution bigint
	declare @tryDate datetime
	declare @passwordSet datetime

SELECT 
--	DISTINCT
	@UserID=tstUserTable.idfUserID, 
	@userSite=tstSite.idfsSite,
	@storedPassword=tstUserTable.binPassword,
	--@tryCount=Logins.TryCount,
	@tryCount=tstUserTable.intTry,
	@tryDate=tstUserTable.datTryDate,
	@passwordSet=tstUserTable.datPasswordSet,
	@person=tlbPerson.idfPerson,
	@firstName=tlbPerson.strFirstName,
	@secondName=tlbPerson.strSecondName,
	@familyName=tlbPerson.strFamilyName,
	@institution=tlbOffice.idfOffice/*,
	isnull(OfficeAbbreviation.Name, OfficeAbbreviation.strDefault) as Abbreviation*/
FROM		tstUserTable 
INNER JOIN	tlbPerson
On			tstUserTable.idfPerson = tlbPerson.idfPerson
INNER JOIN	tlbEmployee
On			tlbEmployee.idfEmployee = tlbPerson.idfPerson
			and tlbEmployee.intRowStatus = 0
INNER JOIN	tlbOffice
ON			tlbOffice.idfOffice = tlbPerson.idfInstitution
			and tlbOffice.intRowStatus = 0
LEFT JOIN	tstSite
ON			tstSite.idfOffice=tlbPerson.idfInstitution and
			tstSite.intRowStatus=0
INNER JOIN	dbo.fnReference('en',19000045) as OfficeAbbreviation 
ON			OfficeAbbreviation.idfsReference = tlbOffice.idfsOfficeAbbreviation
/*LEFT JOIN	
			(
			SELECT	idfUserID,count(*) as TryCount
			FROM	tstSecurityAudit
			WHERE	idfsAction=10110000 and--login			
					idfsResult=10120001 and--failed
					datActionDate>=@timestamp
			GROUP BY idfUserID
			)Logins
ON			Logins.idfUserID=tstUserTable.idfUserID*/
WHERE		strAccountName=@UserName
			AND isnull(OfficeAbbreviation.Name, OfficeAbbreviation.strDefault) = @Organization
			AND tstUserTable.idfsSite = @localSite
--			AND tstUserTable.strPassword = @Password
			AND tstUserTable.intRowStatus = 0
ORDER BY	tstSite.idfsSite

if @UserID is null or @storedPassword is null
Begin
	exec spLogSecurityEvent @UserID,10110000,0, @error2
	set @Result=2
	return
end

declare @lockInterval int
declare @lockTreshold int

select @lockInterval=intAccountLockTimeout from dbo.fnPolicyValue()
select @lockTreshold=intAccountTryCount from dbo.fnPolicyValue()

--is account locked
if @tryCount>=@lockTreshold and datediff(minute,@tryDate,getutcdate())<@lockInterval
begin
	exec spLogSecurityEvent @UserID,10110000,0, @error6
	set @Result=6
	return
end

declare @total varbinary(100)
declare @byte tinyint 
declare @i int
set @i=1
declare @challengepos int
set @challengepos=1

while @i<=DATALENGTH(@storedPassword)
begin
	set @byte=substring(@storedPassword,@i,1)
	set @byte=@byte ^ cast (substring(@challenge,@challengepos,1) as tinyint)
	
	if (@total is null) set @total=cast(@byte as varbinary)
	else set @total=@total+cast(@byte as varbinary)
	set @i=@i+1
	set @challengepos=@challengepos+1
	if @challengepos>DATALENGTH(@challenge) set @challengepos=1
end

select @total=hashbytes('SHA1',@total)

if @total<>@password
begin
	update	tstUserTable
	set		intTry=isnull(intTry,0)+1,
			datTryDate=getutcdate()
	where	idfUserID=@UserID
	exec spLogSecurityEvent @UserID,10110000,0, @error2
	set @Result= 2
	return
end

--is password expired
if (isnull(@Flags,0) & 1)=0
begin
	declare @passwordAge int
	select @passwordAge=intPasswordAge from dbo.fnPolicyValue()

	if datediff(d,isnull(@passwordSet,'2000-01-01T00:00:00'),getutcdate())>=@passwordAge
	begin
		--exec spLogSecurityEvent @UserID,1,0
		set @Result=9
		return
	end
end

---------actual site calculation
if not exists(select * from tstLocalSiteOptions where strName='WebSiteMode' and strValue is not null)
begin
	set @userSite=@localSite	
end
set @userSite=isnull(@userSite,@localSite)
---------actual site calculation

update	tstLocalConnectionContext
set		idfUserID=@UserID,
		idfsSite=@userSite,
		datLastUsed=getutcdate()
where	strConnectionContext=@context

update	tstUserTable
set		intTry=null,
		datTryDate=getutcdate()
where	idfUserID=@UserID

exec spLogSecurityEvent @UserID,10110000,1

set @Result=0
select 
		@UserID as 'idfUserID',
		@person as 'idfPerson',
		@firstName as 'strFirstName',
		@secondName as 'strSecondName',
		@familyName as 'strFamilyName',
		@institution as 'idfInstitution'

return

END
