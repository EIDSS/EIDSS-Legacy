SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spUser_Post') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spUser_Post
GO


--##SUMMARY Post user data from PersonDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 14.12.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:

DECLARE @Action int
DECLARE @idfUserID bigint
DECLARE @idfPerson bigint
DECLARE @idfsSite bigint
DECLARE @strAccountName nvarchar(200)
DECLARE @strPassword nvarchar(200)

EXECUTE spUser_Post
   @Action
  ,@idfUserID
  ,@idfPerson
  ,@idfsSite
  ,@strAccountName
  ,@strPassword

*/



CREATE        PROCEDURE dbo.spUser_Post
( 
		 @Action as int  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
		,@idfUserID as bigint--##PARAM @idfUserID - user ID
		,@idfPerson as bigint--##PARAM @idfPerson - person ID
		,@idfsSite bigint--##PARAM @idfsSite - site where user can login to system
		,@strAccountName as nvarchar(200)--##PARAM @strAccountName - user login
		--,@blbPassword as varbinary(max)=null--##PARAM @strPassword - user password
)
	
AS

IF @Action = 4 --insert
BEGIN
	INSERT INTO tstUserTable
           (
			idfUserID
			,idfPerson
			,idfsSite
			,strAccountName
			,binPassword
           )
     VALUES
           (
			@idfUserID
			,@idfPerson
			,ISNULL(@idfsSite,dbo.fnSiteID())
			,@strAccountName
			--,isnull(@blbPassword,newid())--@strPassword
			,newid()
           )
END
ELSE IF @Action=16 --Update
BEGIN
	UPDATE tstUserTable --login form allows changing of user login and password only
	   SET 
			strAccountName = @strAccountName
			--,blbPassword = isnull(@blbPassword,blbPassword)
	 WHERE 
		idfUserID=@idfUserID
END
ELSE IF @Action=8 --DELETE
	DELETE FROM tstUserTable
	WHERE 		idfUserID=@idfUserID
	

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

