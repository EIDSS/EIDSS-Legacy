 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepHumCaseForm]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepHumCaseForm]


GO

--##SUMMARY Select data for Human Case Investigation report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 10.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepHumCaseForm 'ru', 2660000241

*/

CREATE  Procedure [dbo].[spRepHumCaseForm]
	(
		@LangID as nvarchar(10),
		@ObjID	as bigint
	)
AS	
	select 
	rfHumanCase.idfCase							as idfCase,
	rfHumanCase.strLocalIdentifier				as LocalID,
	rfSendByOffice.[Name]						as OrgSentNotification,
	rfInvestigatedByOffice.[Name]				as OrgConductInv,
	--- Reg Address ---
	rfRegistratedRegion.[Name]					as RegRegion,
	rfRegistratedRayon.[Name]					as RegRayon,	
	rfRegistratedSettlement.[Name]				as RegVillage,
	tRegistratedLocation.strStreetName			as RegStreet,
	tRegistratedLocation.strPostCode			as RegPostalCode,
	tRegistratedLocation.strBuilding			as RegBuld,
	tRegistratedLocation.strHouse				as RegHouse,
	tRegistratedLocation.strApartment			as RegApp,
	rfHumanCase.strRegistrationPhone			as RegPhone,
	---- Employer Address---
	rfEmployerRegion.[name]						as EmpRegion,
	rfEmployerRayon.[name]						as EmpRayon,
	rfEmployerSettlement.[name]					as EmpVillage,
	tEmployerLocation.strStreetName				as EmpStreet,
	rfHumanCase.strWorkPhone					as EmpPhone,
	tEmployerLocation.strPostCode				as EmpPostalCode,
	tEmployerLocation.strBuilding				as EmpBuild,
	tEmployerLocation.strHouse					as EmpHouse,
	tEmployerLocation.strApartment				as EmpApp,
	---
	rfInitialCaseStatus.[Name]					as InitCaseStatus,
	rfHumanCase.datNotificationDate				as DateFromHealthCareProvider, -- dbo.Activity.datReportDate
	rfHumanCase.strCaseId						as CaseIdentifier,
	rfHumanCase.datInvestigationStartDate		as StartingDateOfInvestigation,
	rfHumanCase.strPatientFullName				as NameOfPatient,
	rfHumanCase.datDateOfBirth					as DOB,
	rfHumanCase.strPatientAgeType				as AgeType,
	rfHumanCase.intPatientAge					as Age,
	rfHumanCase.strPatientGender				as Sex,
	rfNationality.[Name]						as Citizenship,
	---- Home Address---
	rfCurrentRegion.[Name]						as Region,
	rfCurrentRayon.[Name]						as Rayon,	
	rfCurrentSettlement.[Name]					as City,
	tCurrentLocation.strStreetName				as Street,
	tCurrentLocation.strPostCode				as strPost_Code,
	rfHumanCase.strHomePhone					as PhoneNumber,
	rfOccupationType.[name]						as Occupation,
	tCurrentLocation.strBuilding				as BuildingNum,
	tCurrentLocation.strHouse					as HouseNum,
	tCurrentLocation.strApartment				as AptNum,
	---
	rfHumanCase.strEmployerName					as NameOfEmployer,
	rfHumanCase.datFacilityLastVisit			as datFacilityLastVisit,
	rfHumanCase.datExposureDate					as DateOfExposure,
	rfHumanCase.datOnSetDate					as DateofSymptomsOnset,
	rfHumanCase.datFirstSoughtCareDate			as DateOfFirstSoughtCare,
	rfHumanCase.strSoughtCareFacility			as FacilityOfPatientSoughtCare,
	rfHumanCase.datHospitalizationDate			as HospitalizationDate,
	rfHumanCase.datDischargeDate				as DateOfDischarged,
	rfHumanCase.strHospitalizationPlace			as PlaceOfHospitalization,
	rfHospitalisationYN.[name]					as Hospitalization,
	rfHumanCase.strClinicalNotes				as ClinicalComments,
	rfCaseStatus.[Name]							as FinalCaseClassification,
	isnull(rfHumanCase.strFinalDiagnosis, rfHumanCase.strTentetiveDiagnosis) as FinalDiagnosis,
	isnull(rfHumanCase.datFinalDiagnosisDate, rfHumanCase.datTentativeDiagnosisDate) as FinalDiagDate,
	rfHumanCase.strTentetiveDiagnosis			as InitialDiagnosis,
	rfHumanCase.datTentativeDiagnosisDate		as InitialDiagDate,
	rfHumanCase.strClinicalDiagnosis			as ClinicalDiagnosis,
	rfSpecimenCollectedYN.[Name]				as SpeciemenCollected,
	rfHumanCase.strNotCollectedReason			as ReasonForNotCollectingSpeciemens,
	rfTherapyYN.[Name]							as Antibiotics,
	ltrim(	ltrim(tDiagBasis.strClinicalDiagBasis + 
		case 
			when (tDiagBasis.strClinicalDiagBasis = ' ') or 
				 (tDiagBasis.strLabDiagBasis = ' ') 
				then ' '
				else ', '
		end) +
		 ltrim(tDiagBasis.strLabDiagBasis +				
		case 
			when (	(tDiagBasis.strClinicalDiagBasis = ' ') and
					(tDiagBasis.strLabDiagBasis = ' ')
				 ) 	or 
				 (tDiagBasis.strEpiDiagBasis = ' ')
				then ' '
				else ', '
		end )
		 + ltrim(tDiagBasis.strEpiDiagBasis)
	 ) as BasisOfDiagnosis,
	rfOutcome.[Name]							as Outcome,
	rfHumanCase.datDateOfDeath					as DateOfDeath,
	rfRelatedToOutbreakYN.[Name]				as RelatedToOutbreak,
	tOutbreak.strOutbreakID						as OutbreakID,
	rfHumanCase.strSummaryNotes					as SummaryComments,
	rfHumanCase.strEpidemiologistsName			as EpiName

	from		dbo.fnRepGetHumanCaseProperties(@LangID) as rfHumanCase
	-- Get HOME ADDRESS 
	 left join	dbo.tlbGeoLocation tCurrentLocation
			on	rfHumanCase.idfCurrentResidenceAddress = tCurrentLocation.idfGeoLocation
 	 left join	fnGisReference(@LangID, 19000001 /*'rftCountry'*/) rfCurrentCountry 
			on	rfCurrentCountry.idfsReference = tCurrentLocation.idfsCountry
	 left join	fnGisReference(@LangID, 19000003 /*'rftRegion'*/)  rfCurrentRegion 
			on	rfCurrentRegion.idfsReference = tCurrentLocation.idfsRegion
	 left join	fnGisReference(@LangID, 19000002 /*'rftRayon'*/)   rfCurrentRayon 
			on	rfCurrentRayon.idfsReference = tCurrentLocation.idfsRayon
	 left join	fnGisReference(@LangID, 19000004 /*'rftSettlement'*/) rfCurrentSettlement
			on	rfCurrentSettlement.idfsReference = tCurrentLocation.idfsSettlement
	-- Get Registrated ADDRESS 
	 left join	dbo.tlbGeoLocation tRegistratedLocation
			on	rfHumanCase.idfRegistrationAddress = tRegistratedLocation.idfGeoLocation
 	 left join	fnGisReference(@LangID, 19000001 /*'rftCountry'*/) rfRegistratedCountry 
			on	rfRegistratedCountry.idfsReference = tRegistratedLocation.idfsCountry
	 left join	fnGisReference(@LangID, 19000003 /*'rftRegion'*/)  rfRegistratedRegion 
			on	rfRegistratedRegion.idfsReference = tRegistratedLocation.idfsRegion
	 left join	fnGisReference(@LangID, 19000002 /*'rftRayon'*/)   rfRegistratedRayon 
			on	rfRegistratedRayon.idfsReference = tRegistratedLocation.idfsRayon
	 left join	fnGisReference(@LangID, 19000004 /*'rftSettlement'*/) rfRegistratedSettlement
			on	rfRegistratedSettlement.idfsReference = tRegistratedLocation.idfsSettlement
	-- Get Employer ADDRESS 
	 left join	dbo.tlbGeoLocation tEmployerLocation
			on	rfHumanCase.idfEmployerAddress = tEmployerLocation.idfGeoLocation
 	 left join	fnGisReference(@LangID, 19000001 /*'rftCountry'*/) rfEmployerCountry 
			on	rfEmployerCountry.idfsReference = tEmployerLocation.idfsCountry
	 left join	fnGisReference(@LangID, 19000003 /*'rftRegion'*/)  rfEmployerRegion 
			on	rfEmployerRegion.idfsReference = tEmployerLocation.idfsRegion
	 left join	fnGisReference(@LangID, 19000002 /*'rftRayon'*/)   rfEmployerRayon 
			on	rfEmployerRayon.idfsReference = tEmployerLocation.idfsRayon
	 left join	fnGisReference(@LangID, 19000004 /*'rftSettlement'*/) rfEmployerSettlement
			on	rfEmployerSettlement.idfsReference = tEmployerLocation.idfsSettlement

	-- Get sent by office name
	 left join  (
						tlbOffice as tSendByOffice
			 left join  fnReference(@LangID, 19000046 /*'rftInstitutionName'*/) as rfSendByOffice
					on  rfSendByOffice.idfsReference = tSendByOffice.idfsOfficeName
			)
		on  tSendByOffice.idfOffice = rfHumanCase.idfSentByOffice
	-- Get investigated by office name
	 left join  (
						tlbOffice as tInvestigatedByOffice
			 left join  fnReference(@LangID, 19000046 /*'rftInstitutionName'*/) as rfInvestigatedByOffice
					on  rfInvestigatedByOffice.idfsReference = tInvestigatedByOffice.idfsOfficeName
			)
		on  tInvestigatedByOffice.idfOffice = rfHumanCase.idfInvestigatedByOffice
	-- Get Case status
	 left join  fnReference(@LangID, 19000011 /*'rftCaseStatus'*/)		as rfCaseStatus
			on  rfCaseStatus.idfsReference = rfHumanCase.idfsCaseStatus
	 left join  fnReference(@LangID, 19000011 /*'rftCaseStatus'*/)		as rfInitialCaseStatus
			on  rfInitialCaseStatus.idfsReference = rfHumanCase.idfsInitialCaseStatus
	-- Get Nationality
	 left join	fnReference(@LangID, 19000054 /*'rftNationality'*/)		as rfNationality
			on	rfNationality.idfsReference = rfHumanCase.idfsNationality
	-- Get OcupationType
	 left join	fnReference(@LangID, 19000061 /*'rftOccupationType'*/)	as rfOccupationType
			on	rfOccupationType.idfsReference = rfHumanCase.idfsOccupationType
	-- Get is Hospitalisation
	 left join	fnReference(@LangID, 19000100 /*'rftYesNoValue'*/)		as rfHospitalisationYN
			on  rfHospitalisationYN.idfsReference = rfHumanCase.idfsYNHospitalization
	-- Get is SpecimenCollected
	 left join	fnReference(@LangID, 19000100 /*'rftYesNoValue'*/)		as rfSpecimenCollectedYN
			on  rfSpecimenCollectedYN.idfsReference=rfHumanCase.idfsYNSpecimenCollected
	-- Get is AntimicrobialTherapy
	 left join	fnReference(@LangID, 19000100 /*'rftYesNoValue'*/)		as rfTherapyYN
			on  rfTherapyYN.idfsReference=rfHumanCase.idfsYNAntimicrobialTherapy
	-- Get is RelatedToOutbreak
	 left join	fnReference(@LangID, 19000100 /*'rftYesNoValue'*/)		as rfRelatedToOutbreakYN
			on  rfRelatedToOutbreakYN.idfsReference=rfHumanCase.idfsYNRelatedToOutbreak
	-- Get is Outcome
	 left join	fnReference(@LangID, 19000064 /*'rftOutcome'*/) as rfOutcome
			on	rfOutcome.idfsReference=rfHumanCase.idfsOutcome
	-- Get Outbreak
	 left join	dbo.tlbOutbreak as tOutbreak
			on	tOutbreak.idfOutbreak = rfHumanCase.idfOutbreak
	-- basis of diagnosis
	 left join	(
	 				select	
	 						tHumanCase.idfHumanCase		as idfCase,
		 					case
	 							when (tHumanCase.blnClinicalDiagBasis is null or tHumanCase.blnClinicalDiagBasis = 0) then ' '
	 							else refClinical.[Name]
	 						end		
	 						as strClinicalDiagBasis,
		 					case
	 							when (tHumanCase.blnLabDiagBasis is null or tHumanCase.blnLabDiagBasis = 0) then ' '
	 							else refLab.[Name]
	 						end		
 							as strLabDiagBasis,
		 					case
	 							when (tHumanCase.blnEpiDiagBasis is null or tHumanCase.blnEpiDiagBasis = 0) then ' '
	 							else refEpi.[Name]
	 						end		
	 						as strEpiDiagBasis
	 						
					  from	tlbHumanCase as tHumanCase
				inner join  fnReference(@LangID, 19000107 /*'rftDiagConfirmMethod'*/) as refClinical
						on  tHumanCase.idfHumanCase = @ObjID
					   and  refClinical.idfsReference = 10105001
				inner join  fnReference(@LangID, 19000107 /*'rftDiagConfirmMethod'*/) as refLab
						on	refLab.idfsReference = 10105002
				inner join  fnReference(@LangID, 19000107 /*'rftDiagConfirmMethod'*/) as refEpi
						on  refEpi.idfsReference = 10105003
				) as tDiagBasis
			on tDiagBasis.idfCase = rfHumanCase.idfCase

	-- Filter condition
		where	@ObjID = rfHumanCase.idfCase
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

