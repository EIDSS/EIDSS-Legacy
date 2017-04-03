SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spMaterialForDisease_Post') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spMaterialForDisease_Post
GO

--##SUMMARY Posts data from disease -> material matrix (Material_For_DiseaseDetail form)

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 24.11.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
EXECUTE spMaterialForDisease_Post
*/


CREATE   PROCEDURE dbo.spMaterialForDisease_Post
			 @Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
           ,@idfMaterialForDisease bigint --##PARAM @idfMaterialForDisease - posted record ID
           ,@idfsSpecimenType bigint --##PARAM @idfsSpecimenType - specimen type, reference to rftSpecimenType (19000087)
           ,@idfsDiagnosis bigint --##PARAM @idfsDiagnosis - diagnosis ID
           ,@intRecommendedQty int --##PARAM @intRecommendedQty - reccomended qty of specimens to collect

AS
IF @Action = 4 -- add record
BEGIN
	INSERT INTO trtMaterialForDisease
           (
			idfMaterialForDisease
           ,idfsSpecimenType
           ,idfsDiagnosis
           ,intRecommendedQty
			)
     VALUES
           (@idfMaterialForDisease
           ,@idfsSpecimenType
           ,@idfsDiagnosis
           ,@intRecommendedQty
			)
	INSERT INTO trtMaterialForDiseaseToCountry
           (
			idfMaterialForDisease
           ,idfsCountry
			)
     VALUES
           (@idfMaterialForDisease
           ,dbo.fnCurrentCountry()
			)
END
ELSE IF @Action = 8 --delete
BEGIN
	DELETE FROM trtMaterialForDiseaseToCountry WHERE idfMaterialForDisease = @idfMaterialForDisease
	DELETE FROM trtMaterialForDisease WHERE idfMaterialForDisease = @idfMaterialForDisease
END
ELSE IF @Action = 16 --update
	UPDATE trtMaterialForDisease
	   SET 
		   idfsSpecimenType = @idfsSpecimenType
		  ,idfsDiagnosis = @idfsDiagnosis
		  ,intRecommendedQty = @intRecommendedQty
	 WHERE 
			idfMaterialForDisease = @idfMaterialForDisease


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

