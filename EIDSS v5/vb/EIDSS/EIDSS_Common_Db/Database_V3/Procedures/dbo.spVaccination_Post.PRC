SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spVaccination_Post') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spVaccination_Post
GO



--##SUMMARY Posts vet case vaccination data related with specific case.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
DECLARE @Action int
DECLARE @idfVaccination bigint
DECLARE @idfVetCase bigint
DECLARE @idfSpecies bigint
DECLARE @idfsVaccinationType bigint
DECLARE @idfsVaccinationRoute bigint
DECLARE @idfsDiagnosis bigint
DECLARE @datVaccinationDate datetime
DECLARE @strManufacturer nvarchar(200)
DECLARE @strLotNumber nvarchar(200)
DECLARE @intNumberVaccinated int
DECLARE @strNote nvarchar(2000)


EXECUTE spVaccination_Post 
   @Action
  ,@idfVaccination
  ,@idfVetCase
  ,@idfSpecies
  ,@idfsVaccinationType
  ,@idfsVaccinationRoute
  ,@idfsDiagnosis
  ,@datVaccinationDate
  ,@strManufacturer
  ,@strLotNumber
  ,@intNumberVaccinated
  ,@strNote
*/

CREATE             Proc	spVaccination_Post
			@Action INT --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
			,@idfVaccination bigint --##PARAM @idfVaccination - vaccnation record ID
			,@idfVetCase bigint --##PARAM @idfVetCase - ID of case to which vaccination belongs
			,@idfSpecies bigint --##PARAM @idfSpecies - vaccinated species
			,@idfsVaccinationType bigint --##PARAM @idfsVaccinationType - vaccination type, reference to rftVaccinationType (19000099)
			,@idfsVaccinationRoute bigint --##PARAM  @idfsVaccinationRoute -vaccination route, reference to rftVaccinationRoute (19000098)
			,@idfsDiagnosis bigint --##PARAM @idfsDiagnosis - vaccianation diagnosis
			,@datVaccinationDate datetime --##PARAM @datVaccinationDate - vaccination date
			,@strManufacturer nvarchar(200) --##PARAM @strManufacturer - manufacurer of vaccine
			,@strLotNumber nvarchar(200) --##PARAM @strLotNumber - vaccine lot number
			,@intNumberVaccinated int --##PARAM @intNumberVaccinated - number of vaccinated animals
			,@strNote nvarchar(2000) --##PARAM - @strNote - arbitrary text data related with vaccination
As

IF @Action = 16 --update
BEGIN
UPDATE tlbVaccination
   SET 
      idfVetCase = @idfVetCase
      ,idfSpecies = @idfSpecies
      ,idfsVaccinationType = @idfsVaccinationType
      ,idfsVaccinationRoute = @idfsVaccinationRoute
      ,idfsDiagnosis = @idfsDiagnosis
      ,datVaccinationDate = @datVaccinationDate
      ,strManufacturer = @strManufacturer
      ,strLotNumber = @strLotNumber
      ,intNumberVaccinated = @intNumberVaccinated
      ,strNote = @strNote
 WHERE 
	idfVaccination = @idfVaccination
	and intRowStatus = 0

END
ELSE IF @Action = 8 --delete
BEGIN
	DELETE tlbVaccination WHERE idfVaccination = @idfVaccination
END

ELSE IF @Action = 4
BEGIN
INSERT INTO tlbVaccination
           (idfVaccination
           ,idfVetCase
           ,idfSpecies
           ,idfsVaccinationType
           ,idfsVaccinationRoute
           ,idfsDiagnosis
           ,datVaccinationDate
           ,strManufacturer
           ,strLotNumber
           ,intNumberVaccinated
           ,strNote)
     VALUES
			(	
			@idfVaccination 
           ,@idfVetCase 
           ,@idfSpecies 
           ,@idfsVaccinationType 
           ,@idfsVaccinationRoute 
           ,@idfsDiagnosis 
           ,@datVaccinationDate 
           ,@strManufacturer
           ,@strLotNumber
           ,@intNumberVaccinated
           ,@strNote
			)	
END

RETURN 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

