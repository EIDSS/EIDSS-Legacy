SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spTempCreateUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spTempCreateUser]
GO

--##SUMMARY Creates user with admin priveledges on the specific site
--##SUMMARY Should not be called from the client application.
--##SUMMARY Used by DBManager or can be called directly by administrators for first user creation.
--##SUMMARY If user with @Account name exists already on the site with @SiteID but doesn't refer do any employee, procedure creates new employee, 
--##SUMMARY assotiates it with existing user and overrides user password with passed one.

--##REMARKS Author: Zurin M.
--##REMARKS Update date: 15.03.2010

--##RETURNS Doesn't use

/*
--Example of procedure call:
exec spTempCreateUser 'super',2,'super'
*/


CREATE    proc spTempCreateUser(
	@Account nvarchar(200), --##PARAM @Account - user login
	@SiteID bigint,--##PARAM @SiteID - Site ID
	@Password nvarchar(500)--##PARAM @Password - user password 
	)
as


 declare @EmployeeID bigint
 declare @UserID bigint
 declare @Office bigint

if not exists(select * from dbo.tstUserTable where strAccountName = @Account 
	and idfsSite = @SiteID)
begin
	begin tran
	DECLARE @ID bigint
	EXECUTE dbo.spsysGetNewID  @EmployeeID OUTPUT

	select @Office = a.idfOffice
	from dbo.tstSite as a
	where a.idfsSite = @SiteID

	if @Office is not null 
	begin

		insert into dbo.tlbEmployee(idfEmployee,idfsSite,idfsEmployeeType,intRowStatus)
		values(@EmployeeID, @SiteID,10023002,0)

		insert into dbo.tlbPerson(idfPerson,strFirstName,idfInstitution )
		values(@EmployeeID, @Account, @Office)
	 
		EXECUTE dbo.spsysGetNewID  @UserID OUTPUT

		INSERT INTO dbo.tstUserTable
				   ([idfUserID]
				   ,[strAccountName]
				   ,[idfsSite]
				   ,[idfPerson]
				   ,[binPassword]
				   ,[datPasswordSet])
			 VALUES
				   (@UserID
				   ,@Account --[strAccountName]
				   ,@SiteID --idfsSite
				   ,@EmployeeID --[idfPerson]
				   ,hashbytes('SHA1',@Password) --<strPassword, varchar(500),>
				   ,getutcdate())
	end
	commit tran
end

if exists(select * from dbo.tstUserTable where strAccountName = @Account 
	and idfsSite = @SiteID and idfPerson is null)
begin
	begin tran
	EXECUTE dbo.spsysGetNewID  @EmployeeID OUTPUT
	select @Office = a.idfOffice
	from dbo.tstSite as a
	where a.idfsSite = @SiteID

	if @Office is not null 
	begin
		 insert into dbo.tlbEmployee(idfEmployee,idfsSite,idfsEmployeeType,intRowStatus)
		 values(@EmployeeID, @SiteID,10023002,0)

		 insert into dbo.tlbPerson(idfPerson,strFirstName,idfInstitution )
		 values(@EmployeeID, @Account, @Office)
		 
		 update dbo.tstUserTable
			set idfPerson = @EmployeeID,
				binPassword = hashbytes('SHA1',@Password),
				datPasswordSet=getutcdate(),
				intRowStatus=0
		 where strAccountName = @Account and idfsSite = @SiteID 
	end

	commit tran
end





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

