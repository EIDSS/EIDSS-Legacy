SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLogin_Validate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLogin_Validate]
GO



--##SUMMARY Checks if user with requested login exists on specific site.

--##REMARKS Author: Zurin M.
--##REMARKS Upadte date: 19.01.2010

--##RETURNS 0 if such user doesn't exist
--##RETURNS	-1 if user exists already or incorrect input parameters are passed


/*
--Example of procedure call:
DECLARE @idfPerson bigint
DECLARE @strAccountName nvarchar(200)
DECLARE @idfsSite bigint
DECLARE @Result int


EXECUTE spLogin_Validate 
   @idfPerson
  ,@strAccountName
  ,@idfsSite
  ,@Result OUTPUT

Print @Result

*/



CREATE            PROCEDURE [dbo].[spLogin_Validate]( 
	@idfPerson		AS BIGINT,			--##PARAM @idfPerson - ID of person related with requested login
	@strAccountName	AS NVARCHAR(200),	--##PARAM @strAccountName - user login
	@idfsSite		AS BIGINT=NULL,		--##PARAM @idfsSite - site ID where user supposed to be registered, if null is passed current site is used for validation
	@Result			AS INTEGER OUTPUT	--##PARAM @Result - validation result:0 - no such login, 1 - empty UserName/person ID, 2 - login exists
)
AS

SET @Result=0

------------------- full info
IF ISNULL(@strAccountName,N'')=N'' OR @idfPerson IS NULL
BEGIN
	SET @Result = 1
	Return -1
END

IF @idfsSite IS NULL 
BEGIN
	SET @idfsSite=dbo.fnSiteID()
END

SELECT 
	tstUserTable.idfUserID
FROM 
	tstUserTable 
INNER JOIN tlbPerson On
	tstUserTable.idfPerson = tlbPerson.idfPerson
INNER JOIN tlbEmployee On
	tlbPerson.idfPerson = tlbEmployee.idfEmployee
	and tlbEmployee.intRowStatus = 0
WHERE 
	strAccountName=@strAccountName
	AND tstUserTable.idfsSite = @idfsSite --dbo.fnSiteID()
	AND tstUserTable.intRowStatus = 0
	AND tstUserTable.idfPerson<>@idfPerson

IF @@ROWCOUNT>0 
BEGIN
	SET @Result = 2
	Return -1
END
RETURN 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

