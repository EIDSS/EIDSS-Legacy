IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCheckVersion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spCheckVersion]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY Checks that application and database versions matches each other

--##REMARKS Author: Kletkin
--##REMARKS Create date: 31.05.2010

--##RETURNS @Result parameter returns the extended error code
--##RETURNS 		0 - No errors
--##RETURNS 		1 - One of mandatory input parameters is not defined
--##RETURNS 		3 - The application version doesn't correspond to database version
--##RETURNS 		4 - The application requires the newest database version
--##RETURNS 		5 - The database version is absent or in incorrect format

/*
--Example of procedure call:

declare @result integer
exec spCheckVersion N'eidss',N'3.0.6.1',@result out
select @result

*/

CREATE            PROCEDURE [dbo].[spCheckVersion]( 
	@ModuleName AS NVARCHAR(200) = NULL,--##PARAM @ModulName - the name of application executable file
	@ModuleVersion AS NVARCHAR(200) = NULL,--##PARAM @ModulVersion - version of application executable file
	@Result AS INTEGER OUTPUT--##PARAM @Result - returns extended result of login attempt. 0 means successfull login, other value is the error code.
)
AS

declare @ScriptVersion nvarchar(50)
declare @i int, @j int

SET @Result=0

------------------ version compare
if isnull(@ModuleVersion,N'') = N'' or isnull(@ModuleName,N'') = N''
BEGIN
	SET @Result = 5
	Return -1
END

select  @ScriptVersion = strValue 
from dbo.tstLocalSiteOptions
where strName = 'DatabaseVersion'

if isnull(@ScriptVersion,N'') = N'' 
BEGIN
	SET @Result = 5
	Return -1
END

set @i = 0
set @j = charindex('.',@ScriptVersion,@i)
while @j>0
BEGIN
	set @i = @j
	set @j = charindex('.',@ScriptVersion,@i+1)
END
if @i>0
set @ScriptVersion = substring(@ScriptVersion, 0,@i)

set @i = 0
set @j = charindex('.',@ModuleVersion,@i)
while @j>0
BEGIN
	set @i = @j
	set @j = charindex('.',@ModuleVersion,@i+1)
END
if @i>0
set @ModuleVersion = substring(@ModuleVersion, 0,@i)

if
not exists(select * from dbo.tstVersionCompare where strModuleName = 'MainDatabaseVersion'
	and strDatabaseVersion = @ScriptVersion)
BEGIN
	set @Result = 5
	RETURN -1
END

if exists(select * from dbo.tstVersionCompare where strModuleName = @ModuleName 
	and strModuleVersion = @ModuleVersion)
BEGIN
	if not exists(select * from dbo.tstVersionCompare where strModuleName = @ModuleName 
		and strModuleVersion = @ModuleVersion
		and strDatabaseVersion = @ScriptVersion)
	BEGIN
		set @Result = 3
		RETURN -1
	END
END
else
BEGIN
	set @Result = 4
	RETURN -1	
END

RETURN 0


