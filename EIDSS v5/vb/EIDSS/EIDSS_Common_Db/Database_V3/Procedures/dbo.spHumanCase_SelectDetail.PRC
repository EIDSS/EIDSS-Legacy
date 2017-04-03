SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spHumanCase_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spHumanCase_SelectDetail]
GO

--##SUMMARY Selects data for a specified human case.

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 22.01.2010

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
declare	@idfCase	bigint

execute	spHumanCase_SelectDetail
	@idfCase
*/



create procedure	spHumanCase_SelectDetail
(		@idfCase	bigint		--##PARAM @idfCase Case Id
)
as

-- 0 tlbHumanCase
select		tlbCase.idfCase,
			tlbCase.idfOutbreak,
			tlbCase.datEnteredDate,
			tlbCase.strCaseID,
			tlbCase.idfsCaseProgressStatus,
			tlbHumanCase.idfsFinalState,
			tlbHumanCase.idfsHospitalizationStatus,
			tlbHumanCase.idfsHumanAgeType,
			tlbHumanCase.idfsYNAntimicrobialTherapy,
			tlbHumanCase.idfsYNHospitalization,
			tlbHumanCase.idfsYNSpecimenCollected,
			tlbHumanCase.idfsYNRelatedToOutbreak,
			tlbHumanCase.idfsOutcome,
			tlbHumanCase.idfsTentativeDiagnosis,
			tlbHumanCase.idfsFinalDiagnosis,
			tlbHumanCase.idfsInitialCaseStatus,
			tlbHumanCase.idfSentByOffice,
			tlbHumanCase.idfReceivedByOffice,
			tlbHumanCase.idfInvestigatedByOffice,
			tlbHumanCase.idfPointGeoLocation,
			tlbHumanCase.idfEpiObservation,
			tlbEpiObservation.idfsFormTemplate as idfsEPIFormTemplate,
			tlbHumanCase.idfCSObservation,
			tlbCSObservation.idfsFormTemplate as idfsCSFormTemplate,
			tlbHumanCase.datNotificationDate,
			tlbHumanCase.datCompletionPaperFormDate,
			tlbHumanCase.datFirstSoughtCareDate,
			tlbHumanCase.datModificationDate,
			tlbHumanCase.datHospitalizationDate,
			tlbHumanCase.datFacilityLastVisit,
			tlbHumanCase.datExposureDate,
			tlbHumanCase.datDischargeDate,
			tlbHumanCase.datOnSetDate,
			tlbHumanCase.datInvestigationStartDate,
			tlbHumanCase.datTentativeDiagnosisDate,
			tlbHumanCase.datFinalDiagnosisDate,
			tlbHumanCase.strNote,
			tlbHumanCase.strCurrentLocation,
			tlbHumanCase.strHospitalizationPlace,
			tlbHumanCase.strLocalIdentifier,
			tlbHumanCase.strSoughtCareFacility,
			tlbHumanCase.strSentByFirstName,
			tlbHumanCase.strSentByPatronymicName,
			tlbHumanCase.strSentByLastName,
			tlbHumanCase.strReceivedByFirstName,
			tlbHumanCase.strReceivedByPatronymicName,
			tlbHumanCase.strReceivedByLastName,
			tlbHumanCase.strEpidemiologistsName,
			tlbHumanCase.strNotCollectedReason,
			tlbHumanCase.strClinicalDiagnosis,
			tlbHumanCase.intPatientAge,
			tlbHumanCase.blnClinicalDiagBasis,
			tlbHumanCase.blnLabDiagBasis,
			tlbHumanCase.blnEpiDiagBasis,
			tlbHumanCase.strClinicalNotes,
			tlbHumanCase.strSummaryNotes,
			tlbHumanCase.idfsFinalCaseStatus,
			tlbHuman.idfHuman,
			tlbHuman.idfsOccupationType,
			tlbHuman.idfRegistrationAddress,
			tlbHuman.datDateOfDeath,
			tlbHuman.strRegistrationPhone,
			tlbHuman.strWorkPhone,
			tlbCase.idfsSite
from		tlbHumanCase
inner join	tlbCase
on			tlbCase.idfCase = tlbHumanCase.idfHumanCase
			and tlbCase.intRowStatus = 0
left join	(
	tlbParty
	inner join	tlbHuman
	on			tlbHuman.idfHuman = tlbParty.idfParty
			)
on			tlbParty.idfCase = tlbHumanCase.idfHumanCase
			and tlbParty.idfsPartyType = 10072006			-- Human
			and tlbParty.intRowStatus = 0
left join	tlbObservation as tlbCSObservation
on			tlbCSObservation.idfObservation = tlbHumanCase.idfCSObservation
			and tlbCSObservation.intRowStatus = 0
left join	tlbObservation as tlbEpiObservation
on			tlbEpiObservation.idfObservation = tlbHumanCase.idfEpiObservation
			and tlbEpiObservation.intRowStatus = 0
where		tlbHumanCase.idfHumanCase = @idfCase


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

