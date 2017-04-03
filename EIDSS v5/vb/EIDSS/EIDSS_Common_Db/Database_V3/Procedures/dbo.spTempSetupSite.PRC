SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spTempSetupSite]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spTempSetupSite]
GO



--##SUMMARY Creates default administrator with login/password = super/super for the specific site

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 29.11.2009

--##RETURNS Doesn't use

/*
--Example of procedure call:

exec spTempSetupSite 2

*/





CREATE    proc spTempSetupSite(
	@SiteID bigint--##PARAM @SiteID - Site ID
	)
as

IF EXISTS(SELECT * FROM tstLocalSiteOptions WHERE strName = 'SiteID')
	UPDATE tstLocalSiteOptions
	SET		strValue = CAST(@SiteID AS NVARCHAR)
	WHERE	strName = 'SiteID'
ELSE
	INSERT INTO tstLocalSiteOptions(
		strName
		,strValue
	)
	VALUES(
		'SiteID'
		,CAST(@SiteID AS NVARCHAR)
	)

EXEC spTempCreateUser 'super', @SiteID, 'super'
DECLARE @DbVersion NVARCHAR(20)
SELECT @DbVersion = strDatabaseVersion FROM tstVersionCompare WHERE strModuleName = 'MainDatabaseVersion'
IF @DbVersion IS NULL
BEGIN
	SET @DbVersion = '3.0.0'
	INSERT INTO tstVersionCompare
           (
			[strModuleName]
           ,[strModuleVersion]
           ,[strDatabaseVersion]
			)
     VALUES
           (
			'MainDatabaseVersion'
           ,'3.0.0'
           ,@DbVersion
			)
	INSERT INTO tstVersionCompare
           (
			[strModuleName]
           ,[strModuleVersion]
           ,[strDatabaseVersion]
			)
     VALUES
           (
			'eidss'
           ,'3.0.0'
           ,@DbVersion
			)
END
IF Not @DbVersion IS NULL
BEGIN
	IF EXISTS(SELECT * FROM tstLocalSiteOptions WHERE strName = 'DatabaseVersion')
		UPDATE tstLocalSiteOptions
		SET		strValue = @DbVersion+'.0'
		WHERE	strName = 'DatabaseVersion'
	ELSE
		INSERT INTO tstLocalSiteOptions(
			strName
			,strValue
		)
		VALUES(
			'DatabaseVersion'
			,@DbVersion+'.0'
		)


END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

