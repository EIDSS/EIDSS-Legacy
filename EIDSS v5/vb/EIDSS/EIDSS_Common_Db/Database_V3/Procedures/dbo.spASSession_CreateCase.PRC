SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASSession_CreateCase]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASSession_CreateCase]
GO


 

--##SUMMARY Creates case for specified farm in monitoring session
--##SUMMARY During case creation it 
--##SUMMARY 1. Creates case itslef
--##SUMMARY 2. Links farm (including farm structure tree) to the case
--##SUMMARY 3. Links Animals/samples/tests with positive result to the case
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 02.08.2010

--##RETURNS 0 - if case is created successfully
--##RETURNS 1 - source farm doesn't exists
--##RETURNS 2 - case is already created for this farm and monitoring session
/*
--Example of a call of procedure:
DECLARE @idfFarm bigint

EXECUTE spASSession_CreateCase 
	@idfFarm
	,@idfCase OUTPUT
Print @idfCase
*/

CREATE            Proc	spASSession_CreateCase
		@idfFarm bigint
		,@CasesList varchar(4000) OUTPUT
As
if NOT Exists( SELECT * from tlbParty 
		WHERE idfParty = @idfFarm and intRowStatus = 0)
	return 1 --Farm doesn't exist

IF NOT EXISTS (SELECT Top 1 idfAnimal From tlbAnimal
				Inner Join tlbParty animalParty on 
					animalParty.idfParty = tlbAnimal.idfAnimal and animalParty.intRowStatus=0
				Inner Join tlbMaterial ON 
					tlbMaterial.idfParty = tlbAnimal.idfAnimal and tlbMaterial.intRowStatus=0
				Inner Join tlbContainer ON 
					tlbMaterial.idfMaterial = tlbContainer.idfMaterial and tlbContainer.intRowStatus=0
				Inner Join tlbTesting ON
					tlbTesting.idfContainer = tlbContainer.idfContainer and tlbTesting.intRowStatus=0
				Inner Join tlbTestValidation on 
					tlbTestValidation.idfTesting = tlbTesting.idfTesting and tlbTestValidation.intRowStatus=0
				INNER JOIN tlbSpecies ON 
					tlbSpecies.idfSpecies = tlbAnimal.idfSpecies
				inner join tlbParty speciesParty on 
					speciesParty.idfParty = tlbSpecies.idfSpecies and speciesParty.intRowStatus=0
				Inner join tlbHerd on 
					tlbSpecies.idfHerd = tlbHerd.idfHerd 
				inner join tlbParty herdParty on 
					herdParty.idfParty = tlbHerd.idfHerd and herdParty.intRowStatus=0
				WHERE tlbHerd.idfFarm = @idfFarm 
					and tlbTestValidation.idfsInterpretedStatus = 10104001
					and ISNULL(tlbTestValidation.blnCaseCreated,0) <>1
				)
	return 3 --farm has no positive test results

--Get FF Templates
create table #tmpTemplate(
	idfsFormTemplate bigint,
	IsUNITemplate BIT
)
Declare @DeterminantList nvarchar(600)
--Animal CS Determinant contains country only


DECLARE @idfCase AS bigint
DECLARE @currentDiagnosis AS BIGINT
DECLARE @idfAnimal AS BIGINT
DECLARE @idfTestValidation AS BIGINT
DECLARE @blnCaseCreated AS BIT
DECLARE @idfsDiagnosis AS BIGINT
DECLARE @idfsCountry AS BIGINT
DECLARE @idfsAnimalCSTemplate AS BIGINT
DECLARE @idfsContolMeasureTemplate AS BIGINT
SET @currentDiagnosis = -1
SET @idfsCountry = CAST (dbo.fnCurrentCountry() as NVARCHAR)


DECLARE crAnimal CURSOR  LOCAL FORWARD_ONLY STATIC FOR
SELECT DISTINCT idfAnimal, tlbTestValidation.idfsDiagnosis,tlbTestValidation.idfTestValidation 
FROM tlbAnimal
	Inner Join tlbParty animalParty on 
		animalParty.idfParty = tlbAnimal.idfAnimal and animalParty.intRowStatus=0
	Inner Join tlbMaterial ON 
		tlbMaterial.idfParty = tlbAnimal.idfAnimal and tlbMaterial.intRowStatus=0
	Inner Join tlbContainer ON 
		tlbMaterial.idfMaterial = tlbContainer.idfMaterial and tlbContainer.intRowStatus=0
	Inner Join tlbTesting ON
		tlbTesting.idfContainer = tlbContainer.idfContainer and tlbTesting.intRowStatus=0
	Inner Join tlbTestValidation on 
		tlbTestValidation.idfTesting = tlbTesting.idfTesting and tlbTestValidation.intRowStatus=0
	INNER JOIN tlbSpecies ON 
		tlbSpecies.idfSpecies = tlbAnimal.idfSpecies
	inner join tlbParty speciesParty on 
		speciesParty.idfParty = tlbSpecies.idfSpecies and speciesParty.intRowStatus=0
	Inner join tlbHerd on 
		tlbSpecies.idfHerd = tlbHerd.idfHerd 
	inner join tlbParty herdParty on 
		herdParty.idfParty = tlbHerd.idfHerd and herdParty.intRowStatus=0
	WHERE tlbHerd.idfFarm = @idfFarm 
		and dbo.tlbTestValidation.idfsInterpretedStatus = 10104001
		and ISNULL(tlbTestValidation.blnCaseCreated,0) <>1
	ORDER BY tlbTestValidation.idfsDiagnosis,  idfAnimal, tlbTestValidation.idfTestValidation 

OPEN crAnimal
FETCH NEXT FROM crAnimal into @idfAnimal, @idfsDiagnosis, @idfTestValidation

WHILE @@FETCH_STATUS = 0 
BEGIN
	IF @currentDiagnosis = -1 OR @currentDiagnosis<>@idfsDiagnosis
	BEGIN
		SET @idfCase = NULL
		SET @currentDiagnosis = @idfsDiagnosis
		SET @DeterminantList = CAST (dbo.fnCurrentCountry() as NVARCHAR) + ';'+CAST (@idfsDiagnosis as NVARCHAR)
		--Get Animal CS Template
		DELETE FROM  #tmpTemplate
		insert #tmpTemplate EXECUTE spFFGetActualTemplate 
		   @idfsCountry
		  ,@idfsDiagnosis
		  ,10034013 --Animal CS
		select TOP 1 @idfsAnimalCSTemplate = idfsFormTemplate
		from #tmpTemplate
		IF @idfsAnimalCSTemplate = -1
			SET @idfsAnimalCSTemplate = NULL

		DELETE FROM  #tmpTemplate
		--Get Control measures	template
		insert #tmpTemplate EXECUTE spFFGetActualTemplate 
		   @idfsCountry
		  ,@idfsDiagnosis
		  ,10034014 --Control measures

		select TOP 1 @idfsContolMeasureTemplate = idfsFormTemplate
		from #tmpTemplate
		IF @idfsContolMeasureTemplate = -1
			SET @idfsContolMeasureTemplate = NULL


		EXEC spASSession_CreateCaseForDiagnosis @idfFarm, @idfsDiagnosis, @idfsContolMeasureTemplate, @idfCase OUTPUT
		if (NOT @idfCase IS NULL)
		BEGIN
			IF ISNULL(@CasesList,'') = ''
				SET @CasesList = CAST(@idfCase as varchar)
			ELSE
				SET @CasesList = ISNULL(@CasesList,'') + ','+ CAST(@idfCase as varchar)
				
		END
	END
	EXEC spASSession_AddAnimalToCase @idfCase, @idfAnimal, @idfsAnimalCSTemplate
	UPDATE tlbTestValidation
	SET 
		blnCaseCreated = 1
	WHERE
		idfTestValidation = @idfTestValidation
	FETCH NEXT FROM crAnimal INTO  @idfAnimal, @idfsDiagnosis, @idfTestValidation
END --crAnimal cursor end

CLOSE crAnimal
DEALLOCATE crAnimal

drop table #tmpTemplate


return 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

