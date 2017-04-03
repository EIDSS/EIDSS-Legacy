SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spTestForDisease_Post') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spTestForDisease_Post
GO

--##SUMMARY Posts data from TestForDiseaseDetail form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 06.04.2010

--##RETURNS Doesn't use

/*
Example of procedure call:

EXECUTE spTestForDisease_Post

*/

CREATE  PROCEDURE dbo.spTestForDisease_Post
	 @Action int  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
	,@idfTestForDisease bigint OUTPUT  --##PARAM @idfTestForDisease - record ID 
	,@idfsTestForDiseaseType bigint  --##PARAM @idfsTestForDiseaseType - TestForDisease Type
	,@idfsTestType bigint  --##PARAM @idfsTestType - Test Type
	,@idfsSpecimenType bigint  --##PARAM @idfsSpecimenType - Specimen Type
	,@idfsDiagnosis bigint  --##PARAM @idfsDiagnosis - Diagnosis ID
	,@intRecommendedQty int  --##PARAM @intRecommendedQty - recommended tests qty
AS

IF @Action = 4
BEGIN
	IF @idfTestForDisease IS NULL OR @idfTestForDisease < 0
		EXEC spsysGetNewID @idfTestForDisease OUTPUT

	INSERT INTO trtTestForDisease (
				idfTestForDisease
			   ,idfsTestForDiseaseType
			   ,idfsTestType
			   ,idfsSpecimenType
			   ,idfsDiagnosis
			   ,intRecommendedQty
				)
		 VALUES
			   (
				@idfTestForDisease
			   ,@idfsTestForDiseaseType
			   ,@idfsTestType
			   ,@idfsSpecimenType
			   ,@idfsDiagnosis
			   ,@intRecommendedQty
			   )
	INSERT INTO trtTestForDiseasetoCountry (
				idfTestForDisease
			   ,idfsCountry
				)
		 VALUES
			   (
				@idfTestForDisease
			   ,dbo.fnCurrentCountry()
			   )
END

IF @Action = 8
BEGIN
	DELETE FROM trtTestForDiseasetoCountry WHERE idfTestForDisease = @idfTestForDisease
	DELETE FROM trtTestForDisease WHERE idfTestForDisease = @idfTestForDisease
END

IF @Action = 16
BEGIN
	UPDATE trtTestForDisease
	   SET 
		  idfsTestForDiseaseType = @idfsTestForDiseaseType
		  ,idfsTestType = @idfsTestType
		  ,idfsSpecimenType = @idfsSpecimenType
		  ,idfsDiagnosis = @idfsDiagnosis
		  ,intRecommendedQty = @intRecommendedQty
	 WHERE 
			idfTestForDisease = @idfTestForDisease
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

