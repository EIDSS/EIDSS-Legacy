SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spPensideTest_Post') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spPensideTest_Post
GO



--##SUMMARY Posts penside tests data related with specific vet case.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 26.11.2009

--##RETURNS Doesn't use

/*
--Example of procedure call:
DECLARE @Action int
DECLARE @idfPensideTest bigint
DECLARE @idfVetCase bigint
DECLARE @idfAnimal bigint
DECLARE @idfSpecies bigint
DECLARE @idfsPensideTestResult bigint
DECLARE @idfsPensideTestType bigint
DECLARE @idfMaterial datetime


EXECUTE spPensideTest_Post 
   @Action
  ,@idfPensideTest
  ,@idfVetCase
  ,@idfAnimal
  ,@idfSpecies
  ,@idfsPensideTestResult
  ,@idfsPensideTestType
  ,@idfMaterial
*/

CREATE             Proc	spPensideTest_Post
			@Action INT --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
			,@idfPensideTest bigint --##PARAM @idfPensideTest - penside test record ID
			,@idfVetCase bigint --##PARAM @idfVetCase - ID of case to which vaccination belongs
			,@idfParty bigint --##PARAM @idfParty - ID of party to which test is applied (animal for livestock cases or species for avian cases)
			,@idfsPensideTestResult bigint --##PARAM @idfsPensideTestResult - penside test result, reference to rftPensideTestResult (19000105)
			,@idfsPensideTestType bigint --##PARAM  @idfsPensideTestType -penside test type, reference to rftPensideTestType (19000104)
			,@idfMaterial bigint --##PARAM @idfMaterial - ID of sample to which test is applied
As

IF @Action = 16 --update
BEGIN
UPDATE tlbPensideTest
   SET 
       idfVetCase = @idfVetCase
      ,idfParty = @idfParty
      ,idfsPensideTestResult = @idfsPensideTestResult
      ,idfsPensideTestType = @idfsPensideTestType
      ,idfMaterial = @idfMaterial
WHERE 
	idfPensideTest = @idfPensideTest
	and intRowStatus = 0

END
ELSE IF @Action = 8 --delete
BEGIN
	DELETE tlbPensideTest WHERE idfPensideTest = @idfPensideTest
END

ELSE IF @Action = 4
BEGIN
	INSERT INTO tlbPensideTest
           (
			idfPensideTest
           ,idfVetCase
           ,idfParty
           ,idfsPensideTestResult
           ,idfsPensideTestType
           ,idfMaterial
			)
     VALUES
           (
			@idfPensideTest
           ,@idfVetCase
           ,@idfParty
           ,@idfsPensideTestResult
           ,@idfsPensideTestType
           ,@idfMaterial
			)

END

RETURN 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

