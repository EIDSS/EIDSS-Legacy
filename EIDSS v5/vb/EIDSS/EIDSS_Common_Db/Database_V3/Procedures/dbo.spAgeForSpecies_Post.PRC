SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spAgeForSpecies_Post') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spAgeForSpecies_Post
GO

--##SUMMARY Posts data from DerivativeForSampleType form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 11.09.2010

--##RETURNS Doesn't use

/*
Example of procedure call:

DECLARE @Action int
DECLARE @idfsSpeciesType bigint
DECLARE @idfsAnimalAge bigint


EXECUTE spAgeForSpecies_Post 
   @Action
  ,@idfsSpeciesType
  ,@idfsAnimalAge

*/

CREATE  PROCEDURE dbo.spAgeForSpecies_Post
	 @Action int  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
	,@idfSpeciesTypeToAnimalAge bigint OUTPUT  --##PARAM @idfSpeciesTypeToAnimalAge - record ID
	,@idfsSpeciesType bigint OUTPUT  --##PARAM @idfsSpeciesType - species type
	,@idfsAnimalAge bigint  --##PARAM @idfsAnimalAge - animal age reference
AS


IF @Action = 8
BEGIN
	DELETE FROM  dbo.trtSpeciesTypeToAnimalAgeToCountry
	WHERE idfSpeciesTypeToAnimalAge = @idfSpeciesTypeToAnimalAge 
	DELETE FROM trtSpeciesTypeToAnimalAge 
	WHERE idfSpeciesTypeToAnimalAge = @idfSpeciesTypeToAnimalAge 
END
ELSE IF @Action = 16
BEGIN
		UPDATE trtSpeciesTypeToAnimalAge
		SET
			idfsSpeciesType = @idfsSpeciesType 
			,idfsAnimalAge = @idfsAnimalAge
		WHERE
			idfSpeciesTypeToAnimalAge = @idfSpeciesTypeToAnimalAge 
END
ELSE IF @Action = 4
BEGIN
		EXEC spsysGetNewID @idfSpeciesTypeToAnimalAge OUTPUT
		INSERT INTO trtSpeciesTypeToAnimalAge(
			idfSpeciesTypeToAnimalAge,
			idfsSpeciesType,
			idfsAnimalAge
		)VALUES(
			@idfSpeciesTypeToAnimalAge,
			@idfsSpeciesType,
			@idfsAnimalAge
		)
		INSERT INTO trtSpeciesTypeToAnimalAgeToCountry(
			idfSpeciesTypeToAnimalAge,
			idfsCountry
		)VALUES(
			@idfSpeciesTypeToAnimalAge,
			dbo.fnCurrentCountry()
		)

END

RETURN 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

