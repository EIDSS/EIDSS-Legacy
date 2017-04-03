SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spHumanCaseDeduplication_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spHumanCaseDeduplication_SelectDetail]
GO

--##SUMMARY Selects data for two specified human cases (one of them is marked as survivor, 
--##SUMMARY and another case is marked as superseded).

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 01.03.2010

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
declare	@SurvivorID		bigint
declare	@SupersededID	bigint
declare	@LangID			varchar(36)

execute	spHumanCaseDeduplication_SelectDetail
	@SurvivorID,
	@SupersededID,
	@LangID
*/



create procedure	spHumanCaseDeduplication_SelectDetail
(		 @SurvivorID	bigint		--##PARAM @SurvivorID Id of the survivor case
		,@SupersededID	bigint		--##PARAM @SupersededID Id of the superseded case
		,@LangID		varchar(36)	--##PARAM @LangID Language Id
)
as

-- 0 tlbHumanCase
select		case tlbCase.idfCase
				when @SurvivorID
					then 'Survivor'
				when @SupersededID
					then 'Superseded'
				else 'None'
			end as rowType,
			tlbCase.idfCase,
			tlbCase.strCaseID,
			tlbHumanCase.strLocalIdentifier,
			tlbHumanCase.idfsTentativeDiagnosis,
			TentativeDiagnosis.[Name] as TentativeDiagnosis_Name,
			tlbHumanCase.datTentativeDiagnosisDate,

			tlbHuman.idfHuman,
			tlbHuman.strLastName,
			tlbHuman.strSecondName,
			tlbHuman.strFirstName,
			tlbHuman.datDateofBirth,
			tlbHumanCase.intPatientAge,
			tlbHumanCase.idfsHumanAgeType,
			HumanAgeType.[Name] as HumanAgeType_Name,
			tlbHuman.idfsHumanGender,
			HumanGender.[Name] as HumanGender_Name,
			tlbHuman.idfCurrentResidenceAddress,
			tlbCurrentResidenceAddress.Region,
			tlbCurrentResidenceAddress.Rayon,
			tlbCurrentResidenceAddress.Settlement,
			tlbCurrentResidenceAddress.Street,
			tlbCurrentResidenceAddress.PostalCode,
			tlbCurrentResidenceAddress.House,
			tlbCurrentResidenceAddress.Building,
			tlbCurrentResidenceAddress.Appartment,
			tlbHuman.strHomePhone,
			tlbHuman.idfsNationality,
			Nationality.[Name] as Nationality_Name,
			tlbHuman.strEmployerName,
			tlbHuman.idfEmployerAddress,
			dbo.fnCreateAddressString	
			(	@LangID,
				tlbEmployerAddress.Country,
				tlbEmployerAddress.Region,
				tlbEmployerAddress.Rayon,
				tlbEmployerAddress.PostalCode,
				tlbEmployerAddress.SettlementType,
				tlbEmployerAddress.Settlement,
				tlbEmployerAddress.Street,
				tlbEmployerAddress.House,
				tlbEmployerAddress.Building,
				tlbEmployerAddress.Appartment,
				tlbEmployerAddress.ResidentType
			) as EmployerAddress_Name,

			tlbHumanCase.datOnSetDate,
			tlbHumanCase.idfsFinalState,
			FinalState.[Name] as FinalState_Name,
			tlbHumanCase.idfsFinalDiagnosis,
			FinalDiagnosis.[Name] as FinalDiagnosis_Name,
			tlbHumanCase.datFinalDiagnosisDate,
			tlbHumanCase.idfsHospitalizationStatus,
			HospitalizationStatus.[Name] as HospitalizationStatus_Name,
			tlbHumanCase.strCurrentLocation,
			tlbHumanCase.strNote,

			tlbHumanCase.idfEpiObservation,
			tlbHumanCase.idfCSObservation
from		(
	tlbHumanCase
	left join	fnReference(@LangID, 19000019) TentativeDiagnosis		-- rftDiagnosis
	on			TentativeDiagnosis.idfsReference = tlbHumanCase.idfsTentativeDiagnosis
	left join	fnReference(@LangID, 19000042) HumanAgeType				-- rftHumanAgeType
	on			HumanAgeType.idfsReference = tlbHumanCase.idfsHumanAgeType
	left join	fnReference(@LangID, 19000035) FinalState				-- rftFinalState
	on			FinalState.idfsReference = tlbHumanCase.idfsFinalState
	left join	fnReference(@LangID, 19000019) FinalDiagnosis			-- rftDiagnosis
	on			FinalDiagnosis.idfsReference = tlbHumanCase.idfsFinalDiagnosis
	left join	fnReference(@LangID, 19000041) HospitalizationStatus	-- rftHospStatus
	on			HospitalizationStatus.idfsReference = tlbHumanCase.idfsHospitalizationStatus
			)
inner join	tlbCase
on			tlbCase.idfCase = tlbHumanCase.idfHumanCase
			and tlbCase.intRowStatus = 0
inner join	(
	tlbParty
	inner join	tlbHuman
	on			tlbHuman.idfHuman = tlbParty.idfParty
	left join	fnAddressAsRow(@LangID) tlbCurrentResidenceAddress
	on			tlbCurrentResidenceAddress.idfGeoLocation = tlbHuman.idfCurrentResidenceAddress
	left join	fnAddressAsRow(@LangID) tlbEmployerAddress
	on			tlbEmployerAddress.idfGeoLocation = tlbHuman.idfEmployerAddress
	left join	fnReference(@LangID, 19000043) HumanGender				-- rftHumanGender
	on			HumanGender.idfsReference = tlbHuman.idfsHumanGender
	left join	fnReference(@LangID, 19000054) Nationality				-- rftNationality
	on			Nationality.idfsReference = tlbHuman.idfsNationality
			)
on			tlbParty.idfCase = tlbHumanCase.idfHumanCase
			and tlbParty.idfsPartyType = 10072006						-- Human
			and tlbParty.intRowStatus = 0
where		(	tlbHumanCase.idfHumanCase = @SurvivorID
				or tlbHumanCase.idfHumanCase = @SupersededID)


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

