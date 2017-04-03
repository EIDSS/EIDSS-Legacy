SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDepartment_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spDepartment_Post]
GO





--##SUMMARY Post department data. Called from OrganizationDetail and DepartmentDetail forms

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use

/*
--Example of procedure call:
DECLARE @Action int
DECLARE @idfDepartment bigint
DECLARE @idfOrganization bigint
DECLARE @DefaultName nvarchar(200)
DECLARE @Name nvarchar(200)
DECLARE @idfsCountry bigint
DECLARE @LangID nvarchar(50)

EXECUTE spDepartment_Post
   @Action
  ,@idfDepartment
  ,@idfOrganization
  ,@DefaultName
  ,@Name
  ,@idfsCountry
  ,@LangID

*/










CREATE         PROCEDURE dbo.spDepartment_Post 
	@Action AS INT, --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
	@idfDepartment AS bigint, --##PARAM @idfDepartment - Department ID
	@idfOrganization AS bigint, --##PARAM @idfOrganization - Organization ID
	@DefaultName AS NVARCHAR(200), --##PARAM @DefaultName - department name in English
	@Name AS NVARCHAR(200), --##PARAM @Name - department name in language defined by @LangID
	@idfsCountry bigint, --##PARAM @idfsCountry - department country
	@LangID As nvarchar(50) --##PARAM @LangID - language ID
AS
IF @Action = 8 --Delete
BEGIN
	EXEC dbo.spDepartment_Delete @idfDepartment
	return 0
END

DECLARE @idfsOfficeName VARCHAR(36)
SELECT 
	@idfsOfficeName = idfsOfficeName
FROM 
	dbo.tlbOffice
WHERE 
	idfOffice=@idfDepartment

DECLARE @NewRecord BIT
IF @@ROWCOUNT=0
BEGIN
	exec spsysGetNewID @idfsOfficeName OUTPUT
	SET @NewRecord = 1
END
	
EXEC spBaseReference_SysPost @idfsOfficeName, 19000046, @LangID, @DefaultName, @Name, 0 --'rftInstitutionName'
IF @NewRecord=1
BEGIN
	IF @idfDepartment IS NULL
		exec spsysGetNewID @idfDepartment OUTPUT
	
	INSERT INTO tlbOffice
           (
			idfOffice
           ,idfsOfficeName
           ,idfsOfficeAbbreviation
           ,idfsOfficeType
           ,idfsCountry
           ,idfParentOffice
           ,idfLocation
           ,idfsSite
           ,strContactPhone
			)
     VALUES
           (
			@idfDepartment
           ,@idfsOfficeName
           ,NULL --@idfsOfficeAbbreviation
           ,10062001 --@idfsOfficeType Department
           ,@idfsCountry
           ,@idfOrganization --@idfParentOffice
           ,null
           ,dbo.fnSiteID()
           ,null
           )
	
END













GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

