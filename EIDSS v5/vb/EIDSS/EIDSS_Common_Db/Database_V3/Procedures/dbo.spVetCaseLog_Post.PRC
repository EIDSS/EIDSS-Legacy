SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spVetCaseLog_Post') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spVetCaseLog_Post
GO

--##SUMMARY Posts case log data related with specific case.
--##SUMMARY Called by CaseLog panel.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 24.11.2009

--##RETURNS Doesn't use


/*
--Example of a call of procedure:

DECLARE @Action int
DECLARE @idfVetCaseLog bigint
DECLARE @idfsCaseLogStatus bigint
DECLARE @idfVetCase bigint
DECLARE @idfPerson bigint
DECLARE @datCaseLogDate datetime
DECLARE @strActionRequired nvarchar(200)
DECLARE @strNote nvarchar(1000)

EXECUTE spVetCaseLog_Post
   @Action
  ,@idfVetCaseLog
  ,@idfsCaseLogStatus
  ,@idfVetCase
  ,@idfPerson
  ,@datCaseLogDate
  ,@strActionRequired
  ,@strNote

*/








Create    Proc	spVetCaseLog_Post
			 @Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
			,@idfVetCaseLog bigint  --##PARAM @idfVetCaseLog - case log record ID
			,@idfsCaseLogStatus bigint --##PARAM @idfsCaseLogStatus - status of case log action, reference to rftVetCaseLogStatus (19000103)
			,@idfVetCase bigint --##PARAM @idfVetCase - case ID
			,@idfPerson bigint --##PARAM @idfPerson - ID of person that performed case log action
			,@datCaseLogDate datetime --##PARAM @datCaseLogDate - date of case log action
			,@strActionRequired nvarchar(200) --##PARAM @strActionRequired - short description of case log action
			,@strNote nvarchar(1000) --##PARAM @strNote - expanded description of case log action

As
IF @Action = 16 --update
BEGIN
UPDATE tlbVetCaseLog
   SET 
       idfsCaseLogStatus = @idfsCaseLogStatus
      ,idfVetCase = @idfVetCase
      ,idfPerson = @idfPerson
      ,datCaseLogDate = @datCaseLogDate
      ,strActionRequired = @strActionRequired
      ,strNote = @strNote
 WHERE 
	idfVetCaseLog = @idfVetCaseLog
			
END
ELSE IF @Action = 8 --delete
BEGIN
	DELETE tlbVetCaseLog WHERE idfVetCaseLog = @idfVetCaseLog
END
ELSE IF @Action = 4 --insert
BEGIN
	INSERT INTO tlbVetCaseLog
           (
			idfVetCaseLog
           ,idfsCaseLogStatus
           ,idfVetCase
           ,idfPerson
           ,datCaseLogDate
           ,strActionRequired
           ,strNote
           )
     VALUES
           (
			@idfVetCaseLog
           ,@idfsCaseLogStatus
           ,@idfVetCase
           ,@idfPerson
           ,@datCaseLogDate
           ,@strActionRequired
           ,@strNote
			)
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

