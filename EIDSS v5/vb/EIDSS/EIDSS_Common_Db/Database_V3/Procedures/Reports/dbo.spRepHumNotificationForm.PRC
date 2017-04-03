SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepHumNotificationForm]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepHumNotificationForm]

GO

--##SUMMARY Select data for Human Notification form report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 08.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepHumNotificationForm 'en', 124000000000

*/

CREATE  Procedure [dbo].[spRepHumNotificationForm]
	(
		@LangID as nvarchar(10),
		@ObjID	as bigint
	)
AS	
	select 
	rfHumanCase.strLocalIdentifier				as FieldCaseID,
	rfHumanCase.datCompletionPaperFormDate		as DateOfCompletionForm,
	rfHumanCase.strCaseId						as CaseIdentifier,
	rfHumanCase.strTentetiveDiagnosis			as Diagnosis,
	rfHumanCase.datTentativeDiagnosisDate		as DateOfDiagnosis,
	rfHumanCase.strPatientFullName				as NameOfPatient,
	rfHumanCase.datDateOfBirth					as DOB,
	rfHumanCase.strPatientAgeType				as AgeType,
	rfHumanCase.intPatientAge					as Age,
	rfHumanCase.strPatientGender				as Sex,
	rfCurrentRegion.[Name]						as Region,
	rfCurrentRayon.[Name]						as Rayon,	
	rfCurrentSettlement.[Name]					as City,
	tCurrentLocation.strPostCode				as PostalCode,
	tCurrentLocation.strStreetName				as Street,
	rfHumanCase.strHomePhone					as PhoneNumber,
	rfHumanCase.strEmployerName					as NameOfEmployer,
	rfHumanCase.datFacilityLastVisit			as DateofLastVisitToEmployer,
	tCurrentLocation.strBuilding				as BuildingNum,
	tCurrentLocation.strHouse					as HouseNum,
	tCurrentLocation.strApartment				as AptNum,
	rfNationality.[Name]						as Nationality,
	dbo.fnAddressString(@LangID, rfHumanCase.idfEmployerAddress) AS AddressOfEmployerOrChildrenFacility ,
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
	
	rfHumanCase.datOnSetDate					as DateofSymptomsOnset,
	rfHumanCase.strFinalState					as SatusOfThePatient,
	rfHumanCase.strFinalDiagnosis				as ChangedDiagnosis,
	rfHumanCase.datFinalDiagnosisDate			as DateOfChangedDiagnosis,
	rfHumanCase.idfsHospitalizationStatus		as HomeHospitalOther,
	rfHumanCase.strCurrentLocation				as HospitalName,
	rfHumanCase.strNote							as Comments,
	rfHumanCase.datNotificationDate				as NotificationDate,
	rfHumanCase.datNotificationDate				as NotificationTime,
	rfHumanCase.strSentByFullName				as SentByName,
	rfSendByOffice.[Name]						as SentbyFacility,
	rfHumanCase.strReceivedByFullName			as ReceivedbyName,
	rfReceivedByOffice.[Name]					as ReceivedFacility

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
	 left join	fnReference(@LangID, 19000054 /*'rftNationality'*/) as rfNationality
			on	rfNationality.idfsReference=rfHumanCase.idfsNationality
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
	-- Get office name
	 left join  (
							tlbOffice as tSendByOffice
				 left join  fnReference(@LangID, 19000046 /*'rftInstitutionName'*/) as rfSendByOffice
						on  rfSendByOffice.idfsReference = tSendByOffice.idfsOfficeName
				)
			on  tSendByOffice.idfOffice = rfHumanCase.idfSentByOffice	 
	 left join  (
							tlbOffice as tReceivedByOffice
				 left join  fnReference(@LangID, 19000046 /*'rftInstitutionName'*/) as rfReceivedByOffice
						on  rfReceivedByOffice.idfsReference = tReceivedByOffice.idfsOfficeName
				)
			on  tReceivedByOffice.idfOffice = rfHumanCase.idfReceivedByOffice

	-- Filter condition
	where	@ObjID = idfCase

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

