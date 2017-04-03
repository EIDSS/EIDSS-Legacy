SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sptemp_CreateVetCase]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sptemp_CreateVetCase]
GO



/*
exec dbo.sptemp_CreateVetCase 1
*/

CREATE    PROCEDURE dbo.sptemp_CreateVetCase
	@caseNum int
as

DECLARE @suffix NVARCHAR(100)
SET @suffix = CAST(@caseNum as NVARCHAR)

DECLARE @curDate DATETIME
SET @curDate = GETDATE()

DECLARE @idfCase bigint
DECLARE @idfOutbreak bigint
DECLARE @idfsCaseStatus bigint
DECLARE @idfsCaseProgressStatus bigint
DECLARE @idfsShowDiagnosis bigint
DECLARE @idfsCaseType bigint
DECLARE @datEnteredDate datetime
DECLARE @strCaseID nvarchar(200)
DECLARE @idfsTentativeDiagnosis bigint
DECLARE @idfsTentativeDiagnosis1 bigint
DECLARE @idfsTentativeDiagnosis2 bigint
DECLARE @idfsFinalDiagnosis bigint
DECLARE @idfPersonInvestigatedBy bigint
DECLARE @idfPersonEnteredBy bigint
DECLARE @idfPersonReportedBy bigint
DECLARE @idfObservation bigint
DECLARE @idfsFormTemplate bigint
DECLARE @idfsSite bigint
DECLARE @datReportDate datetime
DECLARE @datAssignedDate datetime
DECLARE @datInvestigationDate datetime
DECLARE @datTentativeDiagnosisDate datetime
DECLARE @datTentativeDiagnosis1Date datetime
DECLARE @datTentativeDiagnosis2Date datetime
DECLARE @datFinalDiagnosisDate datetime
DECLARE @strSampleNotes nvarchar(1000)
DECLARE @strTestNotes nvarchar(1000)
DECLARE @strSummaryNotes nvarchar(1000)
DECLARE @strClinicalNotes nvarchar(1000)
DECLARE @strFieldAccessionID nvarchar(200)

exec spSysGetNewID @idfCase OUTPUT
exec spSysGetNewID @idfObservation OUTPUT

exec spGetNextNumber 10057024,@strCaseID output, NULL
exec spGetNextNumber 10057025,@strFieldAccessionID output, NULL

--Initialize vet case parameters
SET @idfsTentativeDiagnosis=2480000000
SET @idfsFinalDiagnosis=2450000000
SELECT TOP 1 @idfPersonReportedBy=idfPerson from  dbo.tlbPerson
SET @idfPersonInvestigatedBy=@idfPersonReportedBy
SET @idfsCaseType = 10012003
SET @idfsCaseProgressStatus = 10109001 -- In process, Closed = 10109002

EXECUTE spVetCase_Post
   @idfCase
  ,@idfOutbreak
  ,@idfsCaseStatus
  ,@idfsCaseProgressStatus
  ,@idfsShowDiagnosis
  ,@idfsCaseType
  ,@datEnteredDate
  ,@strCaseID
  ,@idfsTentativeDiagnosis
  ,@idfsTentativeDiagnosis1
  ,@idfsTentativeDiagnosis2
  ,@idfsFinalDiagnosis
  ,@idfPersonInvestigatedBy
  ,@idfPersonEnteredBy
  ,@idfPersonReportedBy
  ,@idfObservation
  ,@idfsFormTemplate
  ,@idfsSite
  ,@datReportDate
  ,@datAssignedDate
  ,@datInvestigationDate
  ,@datTentativeDiagnosisDate
  ,@datTentativeDiagnosis1Date
  ,@datTentativeDiagnosis2Date
  ,@datFinalDiagnosisDate
  ,@strSampleNotes
  ,@strTestNotes
  ,@strSummaryNotes
  ,@strClinicalNotes
  ,@strFieldAccessionID



DECLARE @idfFarmLocation bigint
DECLARE @idfFarmAddress bigint
exec spSysGetNewID @idfFarmLocation OUTPUT
exec spSysGetNewID @idfFarmAddress OUTPUT


exec spGeoLocation_Post @idfFarmLocation,NULL,10036003,780000000,37020000000,3260000000,NULL,NULL,6,5,0.01,NULL,NULL
exec spAddress_Post @idfFarmAddress,780000000,37020000000,3260000000,259730000000,NULL,NULL,NULL,NULL,NULL,NULL

--Fill farm informatiom
DECLARE @idfFarm bigint
DECLARE @idfRootFarm bigint
DECLARE @strContactPhone nvarchar(200)
DECLARE @strInternationalName nvarchar(200)
DECLARE @strNationalName nvarchar(200)
DECLARE @strFarmCode nvarchar(200)
DECLARE @strFax nvarchar(200)
DECLARE @strEmail nvarchar(200)
DECLARE @blnIsLivestock bit
DECLARE @blnIsAvian bit
DECLARE @idfOwner bigint
DECLARE @idfRootOwner bigint
DECLARE @strOwnerLastName nvarchar(200)
DECLARE @strOwnerFirstName nvarchar(200)
DECLARE @strOwnerMiddleName nvarchar(200)

exec spSysGetNewID @idfRootFarm OUTPUT
exec spSysGetNewID @idfFarm OUTPUT
exec spSysGetNewID @idfOwner OUTPUT

--Initialize farm attributes
SET @strContactPhone= '1000'  +@suffix
SET @strNationalName=N'Farm '+@suffix
SET @strFax=N'8(495)'+@suffix
SET @strEmail=N'a'++@suffix+'@a.com'
SET @strOwnerLastName=N'owner '+@suffix

EXECUTE spFarmPanel_Post 
   4 --@Action
  ,@idfFarm
  ,@idfRootFarm OUTPUT
  ,@idfCase
  ,NULL--@idfMonitoringSession
  ,@strContactPhone
  ,NULL--@strInternationalName
  ,@strNationalName
  ,@strFarmCode OUTPUT
  ,@strFax
  ,@strEmail
  ,@idfFarmLocation
  ,@idfFarmAddress
  ,1 --@blnIsLivestock
  ,NULL--@blnIsAvian
  ,@idfOwner
  ,@idfRootOwner OUTPUT
  ,@strOwnerLastName
  ,@strOwnerFirstName
  ,@strOwnerMiddleName

--Insert Farm Node
DECLARE @intTotalAnimalQty int
DECLARE @intSickAnimalQty int
DECLARE @intDeadAnimalQty int

exec spSysGetNewID @idfObservation OUTPUT

EXECUTE spVetFarmTree_Post
   4 --@Action
  ,@idfCase
  ,@idfFarm --@idfParty
  ,10072005 --@idfsPartyType
  ,@strFarmCode OUTPUT
  ,NULL --@idfParentParty
  ,@idfObservation
  ,@idfsFormTemplate
  ,@intTotalAnimalQty
  ,@intSickAnimalQty
  ,@intDeadAnimalQty
  ,NULL--@strAverageAge
  ,NULL--@datStartOfSignsDate
  ,NULL--@strNote

--Add Herd
DECLARE @idfHerd bigint
exec spSysGetNewID @idfHerd OUTPUT
declare @strName nvarchar(200)
set @strName=''
EXECUTE spVetFarmTree_Post
   4 --@Action
  ,@idfCase
  ,@idfHerd --@idfParty
  ,10072003 --@idfsPartyType
  ,@strName OUTPUT
  ,@idfFarm --@idfParentParty
  ,NULL--@idfObservation
  ,NULL --@idfsFormTemplate
  ,NULL --@intTotalAnimalQty
  ,NULL--@intSickAnimalQty
  ,NULL--@intDeadAnimalQty
  ,NULL--@strAverageAge
  ,NULL--@datStartOfSignsDate
  ,NULL--@strNote

DECLARE @idfSpecies bigint
DECLARE @idfSpecies1 bigint
DECLARE @idfSpecies2 bigint

--Add Species to the Herd
exec spSysGetNewID @idfSpecies OUTPUT
exec spSysGetNewID @idfObservation OUTPUT
Set @strName = '39170000000' --species ID as string
SET @intTotalAnimalQty= CAST((RAND()*100) AS INT)
SET @intSickAnimalQty= CAST((RAND()*100) AS INT)
SET @intDeadAnimalQty= CAST((RAND()*100) AS INT)

EXECUTE spVetFarmTree_Post
   4 --@Action
  ,@idfCase
  ,@idfSpecies --@idfParty
  ,10072004 --@idfsPartyType
  ,@strName OUTPUT
  ,@idfHerd --@idfParentParty
  ,@idfObservation
  ,NULL --@idfsFormTemplate
  ,@intTotalAnimalQty
  ,@intSickAnimalQty
  ,@intDeadAnimalQty
  ,NULL--@strAverageAge
  ,NULL--@datStartOfSignsDate
  ,NULL--@strNote

--Add Herd 1
DECLARE @idfHerd1 bigint
exec spSysGetNewID @idfHerd1 OUTPUT
set @strName=''
EXECUTE spVetFarmTree_Post
   4 --@Action
  ,@idfCase
  ,@idfHerd1 --@idfParty
  ,10072003 --@idfsPartyType
  ,@strName OUTPUT
  ,@idfFarm --@idfParentParty
  ,NULL--@idfObservation
  ,NULL --@idfsFormTemplate
  ,NULL --@intTotalAnimalQty
  ,NULL--@intSickAnimalQty
  ,NULL--@intDeadAnimalQty
  ,NULL--@strAverageAge
  ,NULL--@datStartOfSignsDate
  ,NULL--@strNote

--Add 2 species to Herd 1
exec spSysGetNewID @idfSpecies1 OUTPUT
exec spSysGetNewID @idfObservation OUTPUT
Set @strName = '39180000000'--species ID as string
SET @intTotalAnimalQty= CAST((RAND()*100) AS INT)
SET @intSickAnimalQty= CAST((RAND()*100) AS INT)
SET @intDeadAnimalQty= CAST((RAND()*100) AS INT)
EXECUTE spVetFarmTree_Post
   4 --@Action
  ,@idfCase
  ,@idfSpecies1 --@idfParty
  ,10072004 --@idfsPartyType
  ,@strName OUTPUT
  ,@idfHerd1 --@idfParentParty
  ,@idfObservation
  ,NULL --@idfsFormTemplate
  ,@intTotalAnimalQty
  ,@intSickAnimalQty
  ,@intDeadAnimalQty
  ,NULL--@strAverageAge
  ,NULL--@datStartOfSignsDate
  ,NULL--@strNote

exec spSysGetNewID @idfSpecies2 OUTPUT
exec spSysGetNewID @idfObservation OUTPUT
Set @strName = '39210000000'--species ID as string
SET @intTotalAnimalQty= CAST((RAND()*100) AS INT)
SET @intSickAnimalQty= CAST((RAND()*100) AS INT)
SET @intDeadAnimalQty= CAST((RAND()*100) AS INT)
EXECUTE spVetFarmTree_Post
   4 --@Action
  ,@idfCase
  ,@idfSpecies2 --@idfParty
  ,10072004 --@idfsPartyType
  ,@strName OUTPUT
  ,@idfHerd1 --@idfParentParty
  ,@idfObservation
  ,NULL --@idfsFormTemplate
  ,@intTotalAnimalQty
  ,@intSickAnimalQty
  ,@intDeadAnimalQty
  ,NULL--@strAverageAge
  ,NULL--@datStartOfSignsDate
  ,NULL--@strNote

DECLARE @idfAnimal bigint
DECLARE @idfsAnimalAge bigint
DECLARE @idfsAnimalGender bigint
DECLARE @strAnimalCode nvarchar(200)
DECLARE @strDescription nvarchar(200)
DECLARE @idfsAnimalCondition bigint

--Add animals
exec spSysGetNewID @idfAnimal OUTPUT
exec spSysGetNewID @idfObservation OUTPUT
SET @idfsAnimalAge = 20000000
SET @idfsAnimalGender=10007001

EXECUTE spVetCaseAnimals_Post 
   4--@Action
  ,@idfAnimal
  ,@idfHerd
  ,@idfsAnimalAge
  ,@idfsAnimalGender
  ,@strAnimalCode OUTPUT
  ,NULL--@strDescription
  ,NULL--@idfsAnimalCondition
  ,@idfSpecies
  ,@idfObservation
  ,NULL--@idfsFormTemplate
  ,@idfCase

exec spSysGetNewID @idfAnimal OUTPUT
exec spSysGetNewID @idfObservation OUTPUT
SET @idfsAnimalAge = 30000000
SET @idfsAnimalGender=10007002

EXECUTE spVetCaseAnimals_Post 
   4--@Action
  ,@idfAnimal
  ,@idfHerd1
  ,@idfsAnimalAge
  ,@idfsAnimalGender
  ,@strAnimalCode OUTPUT
  ,NULL--@strDescription
  ,NULL--@idfsAnimalCondition
  ,@idfSpecies
  ,@idfObservation
  ,NULL--@idfsFormTemplate
  ,@idfCase

DECLARE @idfsOwnershipStructure bigint
DECLARE @idfsLivestockProductionType bigint
DECLARE @idfsGrazingPattern bigint
DECLARE @idfsMovementPattern bigint
SET @idfsOwnershipStructure=10800000000
SET @idfsLivestockProductionType=10540000000
SET @idfsGrazingPattern=5240000000
SET @idfsMovementPattern=NULL
exec spLivestockFarmProduction_Post @idfFarm,@idfRootFarm,@idfsOwnershipStructure,@idfsLivestockProductionType,@idfsGrazingPattern,@idfsMovementPattern


--exec spLabSample_Create @idfMaterial=74130000000,@strFieldBarcode=N'22222',@idfsSpecimenType=39330000000,@idfParty=74120000000,@datFieldCollectionDate='2009-11-27 23:27:54:703',@idfFieldCollectedByOffice=48120000000,@idfFieldCollectedByPerson=NULL
--exec spVaccination_Post @Action=4,@idfVaccination=74100000000,@idfVetCase=73950000000,@idfSpecies=74030000000,@idfsVaccinationType=41640000000,@idfsVaccinationRoute=41590000000,@idfsDiagnosis=490000000,@datVaccinationDate='2009-11-27 00:00:00:000',@strManufacturer=NULL,@strLotNumber=NULL,@intNumberVaccinated=NULL,@strNote=NULL
--exec spPensideTest_Post @Action=4,@idfPensideTest=74140000000,@idfVetCase=73950000000,@idfParty=74120000000,@idfsPensideTestResult=3,@idfsPensideTestType=1,@idfMaterial=74130000000
--exec spVetCaseLog_Post @Action=4,@idfVetCaseLog=74150000000,@idfsCaseLogStatus=10103001,@idfVetCase=73950000000,@idfPerson=72870000000,@datCaseLogDate='2009-11-27 23:28:27:297',@strActionRequired=N'1123123',@strNote=N'1231231231'

GO