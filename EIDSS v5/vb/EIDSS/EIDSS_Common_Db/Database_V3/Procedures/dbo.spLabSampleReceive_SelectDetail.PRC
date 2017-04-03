SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleReceive_SelectDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleReceive_SelectDetail]
GO

/*
exec spLabSampleReceive_SelectDetail 82650000000 ,'en'
*/

CREATE PROCEDURE [dbo].[spLabSampleReceive_SelectDetail]
	@CaseID bigint, 
	@LangID varchar(20)
AS

BEGIN
	SET NOCOUNT ON;

-- returns materials
select Material.*,

			tlbContainer.strBarcode,
			--tlbContainer.datCreationDate,
			--tlbContainer.idfContainer,
			tlbContainer.idfInDepartment,
			tlbContainer.idfSubdivision,
			--RepositorySchema.Path,
			tlbContainer.strNote/*,
			Material.strCondition,
			Material.idfAccesionByPerson,
			Material.idfsAccessionCondition,
			Material.datAccession*//*,
			case when tlbMaterialOnSite.UsageCount>0 then 1 else 0 end as Received*/

from	fn_CaseSamples(@CaseID,@LangID) Material
left join	tlbContainer
on			tlbContainer.idfContainer=Material.idfContainer
/*
left join	
			(
			tlbContainer
			inner join	tlbAccessionIN
			on			tlbAccessionIN.idfContainer=tlbContainer.idfContainer
			)
on		tlbContainer.idfMaterial=Material.idfMaterial
*/
/*left join	dbo.fn_RepositorySchema(null,null,null) as RepositorySchema 
on			RepositorySchema.idfSubdivision=tlbContainer.idfSubdivision*/
where		Material.Used=0 or Material.idfsSite=dbo.fnSiteID()

-- returns animals
select		Animal.idfParty,
			Animal.idfSpecies,
			Animal.idfAnimal,
			Animal.strAnimalCode,
			Animal.SpeciesName as strSpecies,
			Gender.Name as strGender
from		fnAnimalList(@LangID) Animal
left join	fnReference(@LangID,19000007) Gender
on			Gender.idfsReference=Animal.idfsAnimalGender
where		Animal.idfCase=@CaseID or Animal.idfMonitoringSession=@CaseID

--return case information
SELECT 
	@CaseID as ID,
	tlbCase.idfsCaseType,
	tlbMonitoringSession.idfMonitoringSession,
	tlbMonitoringSession.strMonitoringSessionID,
	tlbCampaign.strCampaignID,
	tlbCampaign.strCampaignName,

	SessionStatus.Name as SessionStatus,
	CampaignType.Name as CampaignType,
	
	tlbCase.strCaseID,
	tlbHumanCase.datOnsetDate,
	tlbCase.strSampleNotes,
	tlbHumanCase.strLocalIdentifier,
	tlbVetCase.strFieldAccessionID,
	dbo.fnGeoLocationString(@LangID,Farm.idfFarmAddress,null) as FarmAddress,
	Farm.strNationalName,
	IsNull(FarmOwner.strLastName + ' ', '')+IsNull(FarmOwner.strFirstName + ' ', '') + IsNull(FarmOwner.strSecondName, '') as FarmOwner,
	IsNull(Patient.strLastName + ' ', '')+IsNull(Patient.strFirstName + ' ', '') + IsNull(Patient.strSecondName, '') as PatientName,
	Patient.idfHuman,
	IsNull(LTrim(Str(tlbHumanCase.intPatientAge)) + ' (' + AgeType.Name + ')', '') as Age,
	DiagnosisName.Name as idfsInitialDiagnosis,
	dbo.fnGeoLocationString(@LangID,Patient.idfCurrentResidenceAddress,null) as CurrentResidence,
	Patient.datDateOfBirth,
	tlbHumanCase.datTentativeDiagnosisDate as datDiagnosisDate
FROM		tlbCase
full join
			(
				tlbMonitoringSession
				left join	tlbCampaign
				on			tlbCampaign.idfCampaign=tlbMonitoringSession.idfCampaign
				left join	fnReference(@LangID,19000117)SessionStatus
				on			SessionStatus.idfsReference=tlbMonitoringSession.idfsMonitoringSessionStatus
				left join	fnReference(@LangID,19000116)CampaignType
				on			CampaignType.idfsReference=tlbCampaign.idfsCampaignType
			)
on			1=0 --always false
left join	tlbHumanCase
on			tlbHumanCase.idfHumanCase=tlbcase.idfCase
left join	tlbVetCase
on			tlbVetCase.idfVetCase=tlbcase.idfCase
left join	(
			tlbParty HumanParty
			inner join	tlbHuman Patient
			on			Patient.idfHuman=HumanParty.idfParty and
						HumanParty.intRowStatus=0
			)
on			HumanParty.idfCase=tlbCase.idfCase
left join	(
			tlbFarm Farm
			inner join	tlbParty FarmParty
			on			FarmParty.idfParty=Farm.idfFarm and
						FarmParty.intRowStatus=0
			left join	(
						tlbHuman as FarmOwner
						inner join	tlbParty OwnerParty
						on			FarmOwner.idfHuman=OwnerParty.idfParty and
									OwnerParty.intRowStatus=0
			)
			on			FarmOwner.idfHuman=Farm.idfHuman
			)
on			FarmParty.idfCase=tlbCase.idfCase
left join	fnReference(@LangID, 19000042 ) AgeType on AgeType.idfsReference = tlbHumanCase.idfsHumanAgeType 
left join	fnReference(@LangID, 19000019 ) DiagnosisName on DiagnosisName.idfsReference = tlbCase.idfsShowDiagnosis
where	tlbCase.idfCase=@CaseID or tlbMonitoringSession.idfMonitoringSession=@CaseID


--return antibiotics information

select
		tlbAntimicrobialTherapy.idfAntimicrobialTherapy,
		tlbAntimicrobialTherapy.strAntimicrobialTherapyName
from	tlbAntimicrobialTherapy
where	tlbAntimicrobialTherapy.idfHumanCase=@CaseID and tlbAntimicrobialTherapy.intRowstatus=0

END


GO