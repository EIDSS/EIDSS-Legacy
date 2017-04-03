SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spDerivativeForSampleType_Post') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spDerivativeForSampleType_Post
GO

--##SUMMARY Posts data from DerivativeForSampleType form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 11.09.2010

--##RETURNS Doesn't use

/*
Example of procedure call:

DECLARE @Action int
DECLARE @idfDerivativeForSampleType bigint
DECLARE @idfsSampleType bigint
DECLARE @idfsDerivativeType bigint


EXECUTE spDerivativeForSampleType_Post 
   @Action
  ,@idfDerivativeForSampleType OUTPUT
  ,@idfsSampleType
  ,@idfsDerivativeType

*/

CREATE  PROCEDURE dbo.spDerivativeForSampleType_Post
	 @Action int  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
	,@idfDerivativeForSampleType bigint OUTPUT  --##PARAM @idfDerivativeForSampleType - record ID 
	,@idfsSampleType bigint  --##PARAM @idfsSampleType - Sample Type
	,@idfsDerivativeType bigint  --##PARAM @idfsDerivativeType - Derivative Type that can be created from sample
AS

IF @Action = 4
BEGIN
	IF @idfDerivativeForSampleType IS NULL OR @idfDerivativeForSampleType < 0
		EXEC spsysGetNewID @idfDerivativeForSampleType OUTPUT
	

	INSERT INTO trtDerivativeForSampleType
           (idfDerivativeForSampleType
           ,idfsSampleType
           ,idfsDerivativeType
			)
     VALUES
           (@idfDerivativeForSampleType
           ,@idfsSampleType
           ,@idfsDerivativeType
			)

	INSERT INTO trtDerivativeForSampleTypeToCountry
           (idfDerivativeForSampleType
           ,idfsCountry
			)
     VALUES
           (@idfDerivativeForSampleType
           ,dbo.fnCurrentCountry()
			)
END

IF @Action = 8
BEGIN
	DELETE FROM trtDerivativeForSampleTypeToCountry WHERE idfDerivativeForSampleType = @idfDerivativeForSampleType
	DELETE FROM trtDerivativeForSampleType WHERE idfDerivativeForSampleType = @idfDerivativeForSampleType
END

IF @Action = 16
BEGIN
	UPDATE trtDerivativeForSampleType
	   SET 
		  idfsSampleType = @idfsSampleType
		  ,idfsDerivativeType = @idfsDerivativeType
	 WHERE 
			idfDerivativeForSampleType = @idfDerivativeForSampleType
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

