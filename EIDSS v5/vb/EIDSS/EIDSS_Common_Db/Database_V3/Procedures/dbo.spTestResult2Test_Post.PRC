SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spTestResult2Test_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spTestResult2Test_Post]
GO




--##SUMMARY Posts data from Test->TestResult matrix form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 22.11.2009

--##RETURNS Doesn't use

/*
--Example of procedure call:
DECLARE @Action int
DECLARE @idfsTestType bigint
DECLARE @idfsTestResult bigint
DECLARE @TestKind int


EXECUTE spTestResult2Test_Post
   @Action
  ,@idfsTestType
  ,@idfsTestResult
  ,@TestKind
*/



CREATE          PROCEDURE dbo.spTestResult2Test_Post(
	@Action as INT, --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
	@idfsTestType AS bigint, --##PARAM @idfsTestType - test type (reference to rftTestType or to rftPensideTestType)
	@idfsTestResult as bigint, --##PARAM @idfsTestResult - test result (reference to rftTestResult or to rftPensideTestResult)
	@TestKind as int --##PARAM @TestKind - kind of record: 0 - laboratory test, 1 - penside test
	)
AS
--@Action=16 --modified
--has no sence because both PK fields are passed as parameter


IF @Action = 8 --deleted
BEGIN
	IF @TestKind = 0
	BEGIN
		DELETE FROM trtTestTypeToTestResultToCountry
		WHERE
			idfsTestType=@idfsTestType
			AND idfsTestResult = @idfsTestResult
		DELETE FROM trtTestTypeToTestResult
		WHERE
			idfsTestType=@idfsTestType
			AND idfsTestResult = @idfsTestResult

	END		
	ELSE IF @TestKind = 1
	BEGIN
		DELETE FROM trtPensideTestTypeToTestResultToCountry
		WHERE
			idfsPensideTestType=@idfsTestType
			AND idfsPensideTestResult = @idfsTestResult
		DELETE FROM trtPensideTestTypeToTestResult
		WHERE
			idfsPensideTestType=@idfsTestType
			AND idfsPensideTestResult = @idfsTestResult
	END
END
ELSE IF @Action=4 --new
BEGIN
	IF @TestKind = 0
	BEGIN
		if EXISTS( SELECT * FROM trtTestTypeToTestResult WHERE idfsTestType=@idfsTestType
				AND idfsTestResult = @idfsTestResult)
			UPDATE trtTestTypeToTestResult
			SET
				intRowStatus = 0
			WHERE
				idfsTestType=@idfsTestType
				AND idfsTestResult = @idfsTestResult
		ELSE
			INSERT INTO trtTestTypeToTestResult(
				idfsTestType,
				idfsTestResult
			)VALUES(
				@idfsTestType,
				@idfsTestResult
			)
		if EXISTS( SELECT * FROM trtTestTypeToTestResultToCountry WHERE idfsTestType=@idfsTestType
				AND idfsTestResult = @idfsTestResult)
			UPDATE trtTestTypeToTestResultToCountry
			SET
				intRowStatus = 0
			WHERE
				idfsTestType=@idfsTestType
				AND idfsTestResult = @idfsTestResult
		ELSE
			INSERT INTO trtTestTypeToTestResultToCountry(
				idfsTestType,
				idfsTestResult,
				idfsCountry
			)VALUES(
				@idfsTestType,
				@idfsTestResult,
				dbo.fnCurrentCountry()
			)

	END
	ELSE IF @TestKind = 1
	BEGIN
		IF EXISTS( SELECT * FROM trtPensideTestTypeToTestResult WHERE idfsPensideTestType=@idfsTestType
					AND idfsPensideTestResult = @idfsTestResult)
			UPDATE trtPensideTestTypeToTestResult
			SET
				intRowStatus = 0
			WHERE
				idfsPensideTestType=@idfsTestType
				AND idfsPensideTestResult = @idfsTestResult		
		ELSE
			INSERT INTO trtPensideTestTypeToTestResult(
				idfsPensideTestType,
				idfsPensideTestResult
			)VALUES(
				@idfsTestType,
				@idfsTestResult
			)
		IF EXISTS( SELECT * FROM trtPensideTestTypeToTestResultToCountry WHERE idfsPensideTestType=@idfsTestType
					AND idfsPensideTestResult = @idfsTestResult)
			UPDATE trtPensideTestTypeToTestResultToCountry
			SET
				intRowStatus = 0
			WHERE
				idfsPensideTestType=@idfsTestType
				AND idfsPensideTestResult = @idfsTestResult		
		ELSE
			INSERT INTO trtPensideTestTypeToTestResultToCountry(
				idfsPensideTestType,
				idfsPensideTestResult,
				idfsCountry
			)VALUES(
				@idfsTestType,
				@idfsTestResult,
				dbo.fnCurrentCountry()
			)
	END
END
Return 0



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

