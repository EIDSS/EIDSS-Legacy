SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spPerson_Post') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spPerson_Post
GO


--##SUMMARY Post person data from PersonDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 13.12.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:

DECLARE @Action int
DECLARE @idfPerson bigint
DECLARE @idfsStaffPosition bigint
DECLARE @idfInstitution bigint
DECLARE @idfDepartment bigint
DECLARE @strFamilyName nvarchar(200)
DECLARE @strFirstName nvarchar(200)
DECLARE @strSecondName nvarchar(200)
DECLARE @strContactPhone nvarchar(200)
DECLARE @strBarcode nvarchar(200)
DECLARE @idfsSite bigint

EXECUTE spPerson_Post
   @Action
  ,@idfPerson
  ,@idfsStaffPosition
  ,@idfInstitution
  ,@idfDepartment
  ,@strFamilyName
  ,@strFirstName
  ,@strSecondName
  ,@strContactPhone
  ,@strBarcode
  ,@idfsSite

*/



CREATE        PROCEDURE dbo.spPerson_Post
( 
		 @Action as int  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
		,@idfPerson as bigint--##PARAM @idfPerson person ID
		,@idfsStaffPosition as bigint--##PARAM @idfsStaffPosition - person position (reference to rftPosition, 19000073)
		,@idfInstitution as bigint--##PARAM @idfInstitution - person organization
		,@idfDepartment as bigint--##PARAM @idfDepartment - person department
		,@strFamilyName as nvarchar(200)--##PARAM @strFamilyName - person last name
		,@strFirstName as nvarchar(200)--##PARAM @strFirstName - person first name
		,@strSecondName as nvarchar(200)--##PARAM @strSecondName - person second name
		,@strContactPhone as nvarchar(200)--##PARAM @strContactPhone - person contact phone
		,@strBarcode as nvarchar(200)--##PARAM @strBarcode - person uniquue barcode (doesn't use now)
		,@idfsSite bigint--##PARAM @idfsSite - site where the record was created
)
	
AS

IF @Action = 4 --insert
BEGIN
	INSERT INTO tlbEmployee
           (
			idfEmployee
           ,idfsEmployeeType
           ,idfsSite
           )
     VALUES
           (
			@idfPerson
           ,10023002 --@idfsEmployeeType, Person
           ,ISNULL(@idfsSite,dbo.fnSiteID())
           )

	INSERT INTO tlbPerson
           (
			idfPerson
           ,idfsStaffPosition
           ,idfInstitution
           ,idfDepartment
           ,strFamilyName
           ,strFirstName
           ,strSecondName
           ,strContactPhone
           ,strBarcode
			)
     VALUES
           (
			@idfPerson
           ,@idfsStaffPosition
           ,@idfInstitution
           ,@idfDepartment
           ,@strFamilyName
           ,@strFirstName
           ,@strSecondName
           ,@strContactPhone
           ,@strBarcode
           )
END
ELSE IF @Action=16 --Update
BEGIN
	UPDATE tlbPerson
	   SET 
		   idfsStaffPosition = @idfsStaffPosition
		  ,idfInstitution = @idfInstitution
		  ,idfDepartment = @idfDepartment
		  ,strFamilyName = @strFamilyName
		  ,strFirstName = @strFirstName
		  ,strSecondName = @strSecondName
		  ,strContactPhone = @strContactPhone
		  ,strBarcode = @strBarcode
	 WHERE 
		idfPerson=@idfPerson
END
ELSE IF @Action=8 --DELETE
	exec spPerson_Delete @idfPerson

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

