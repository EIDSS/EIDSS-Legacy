CREATE PROCEDURE [dbo].[spAUMVersionCompare_Post]
(
	@eidssVersionShort varchar(50)
	,@versionDatabaseShort varchar(50)
)
AS
Begin
	if not exists(select top 1 1 from dbo.tstVersionCompare where
		[strModuleVersion] = @versionDatabaseShort
		and [strDatabaseVersion] = @versionDatabaseShort
		and [strModuleName] = 'MainDatabaseVersion') begin
			Update dbo.tstVersionCompare
				set [strModuleVersion] = @versionDatabaseShort
					,[strDatabaseVersion] = @versionDatabaseShort
				where [strModuleName] = 'MainDatabaseVersion';			
		end;

	If Not Exists(Select top 1 1 from dbo.tstVersionCompare 
          where [strModuleName]='eidss' and [strModuleVersion]=@eidssVersionShort and [strDatabaseVersion]=@versionDatabaseShort)
            Insert into dbo.tstVersionCompare ([strModuleName],[strModuleVersion],[strDatabaseVersion])
                values('eidss', @eidssVersionShort, @versionDatabaseShort);

end;
