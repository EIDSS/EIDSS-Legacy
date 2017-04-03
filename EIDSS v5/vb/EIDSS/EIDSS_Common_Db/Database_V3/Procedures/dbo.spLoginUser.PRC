IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLoginUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLoginUser]
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

/*
--Example of procedure call:
*/

CREATE PROCEDURE [dbo].[spLoginUser]
	@Organization AS NVARCHAR(200),--##PARAM @Organization - organization abbreviation
	@UserName AS NVARCHAR(200),--##PARAM @UserName - user login
	@Password AS varbinary(max) = NULL,--##PARAM @Password - user password
	@Result as int output
AS
BEGIN

	declare @UserID bigint

	exec spLoginUserInternal @Organization,@UserName,@Password, null ,@Result output,@UserID output

	return

END
