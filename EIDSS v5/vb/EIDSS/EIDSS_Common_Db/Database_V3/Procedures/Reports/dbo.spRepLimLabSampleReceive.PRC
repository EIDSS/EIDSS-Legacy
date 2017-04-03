SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepLimLabSampleReceive]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepLimLabSampleReceive]

GO

--##SUMMARY Select data for Accession in report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 16.12.2009

--##RETURNS Doesn't use
 
/*
--Example of a call of procedure:

exec dbo.spRepLimLabSampleReceive @ObjID=47280000204,@LangID='ru'

exec dbo.spRepLimLabSampleReceive @ObjID=7630000010,@LangID='ru'

exec dbo.spRepLimLabSampleReceive @ObjID=88200000241,@LangID='ru'



 // empty
 exec dbo.spRepLimLabSampleReceive @ObjID=37470000010,@LangID='en'

*/

CREATE  Procedure [dbo].[spRepLimLabSampleReceive]
    (
        @ObjID	as bigint,
        @LangID as nvarchar(10) 
    )
    
as
	select		
				isnull(tCase.idfCase, tSession.idfMonitoringSession )
													as idfCase,
				isnull(tCase.strCaseID, tSession.strMonitoringSessionID) 
													as CaseID,
				isnull(tHumanCase.datOnSetDate, tVetCase.datInvestigationDate) 
													as DateOfSymptoms,
				case
					when (tCase.idfCase is null) then 2
					else 
						case 
							when (tCase.idfsCaseType =10012001 /*cstRoutineHumanCaseReport*/) then 1   else 0	
						end
				end									as intCaseType,
				isnull(tHumanCase.strLocalIdentifier, tVetCase.strFieldAccessionID)			
													as LocalID,
				dbo.fnGeoLocationString(@LangID, tFarm.idfFarmAddress, null)	as FarmAddress,
				tFarm.strNationalName				as FarmName,
				dbo.fnCreateNameString(tFarmOwner.strLastName, tFarmOwner.strFirstName, tFarmOwner.strSecondName)	
													as FarmOwner,
				dbo.fnCreateNameString(tHuman.strLastName, tHuman.strFirstName, tHuman.strSecondName)				
													as PatientName,
				IsNull(Str(tHumanCase.intPatientAge) + ' (' + rfAgeType.[Name] + ')', '')	
													as Age,
				rfDiagnosis.[Name]					as DiagnosisInitial,
				dbo.fnGeoLocationString(@LangID, tHuman.idfCurrentResidenceAddress, null)	
													as CurrentResidence,

				fnMaterial.strFieldBarcode			as LocalSampleID,
				fnMaterial.SpecimenType				as SampleType,
				fnAnimal.AnimalName					as AnimalID,
				fnAnimal.SpeciesName				as Species,
				fnMaterial.datFieldCollectionDate	as CollectionDate,
				fnMaterial.datFieldSentDate			as DateSent,
				tContainer.strBarcode				as LabSampleID,
				tContainer.datCreationDate			as AccessionDate,
				tAccession.strCondition				as SampleCondition,
				fnRepository.Path					as Location,
				tContainer.strNote					as Comment,
				fnDepartment.[Name]					as FunctionalArea,
				dbo.fnCreateNameString(tAccessionPerson.strFamilyName, tAccessionPerson.strFirstName, tAccessionPerson.strSecondName) 
													as AccessionedBy,
				dbo.fnCreateNameString(tCollectedPerson.strFamilyName, tCollectedPerson.strFirstName, tCollectedPerson.strSecondName) 
													as CollectedByPerson,
				tHuman.idfCurrentResidenceAddress	as	idfCurrentResidenceAddress,
				fnASRegion.Name						as strASRegion,
				fnASRayon.Name						as strASRayon,
				fnASSettlement.Name					as strASSettlement,
				(
					select
								fnDiagnosis.[Name] + '; '
					from		tlbMonitoringSessionToDiagnosis	tSTD
					inner join	dbo.fnReference(@LangID,19000019) fnDiagnosis
					on			tSTD.idfsDiagnosis = fnDiagnosis.idfsReference 		
					where		tSTD.idfMonitoringSession = @ObjID
					and			tSTD.intRowStatus = 0
					Order By	tSTD.intOrder	
					for xml path('')
				)									as strDiagnosisList,
				tCampaign.strCampaignID				as strCampaignID,
				tCampaign.strCampaignName			as strCampaignName,
				fnCampaignType.[Name]				as strCampaignType
				
				
				
	--get session				
	from	 (	
						dbo.tlbMonitoringSession	as tSession
					
			-- Get campaign
			 left join	dbo.tlbCampaign as tCampaign
					on	tCampaign.idfCampaign = tSession.idfCampaign 
			 left join	fnReference(@LangID,19000116) fnCampaignType
					on	fnCampaignType.idfsReference = tCampaign.idfsCampaignType
			 	 
			-- Get session address
			 left join	fnGisReference(@LangID,19000003) fnASRegion
					on	fnASRegion.idfsReference = tSession.idfsRegion
			left join	fnGisReference(@LangID,19000002) fnASRayon
					on	fnASRayon.idfsReference = tSession.idfsRayon
			left join	fnGisReference(@LangID,19000004) fnASSettlement
					on	fnASSettlement.idfsReference = tSession.idfsSettlement
			)
	-- get case
	full join (
						dbo.tlbCase					as tCase
			-- get human case
			 left join	( 
									dbo.tlbHumanCase as tHumanCase
						-- Get Human Age type 
						 left join	fnReference(@LangID, 19000042 /* rftHumanAgeType*/) rfAgeType
								on	tHumanCase.idfsHumanAgeType	= rfAgeType.idfsReference
						-- Get patient
						inner join	dbo.tlbParty	as tHumanParty
								on	tHumanCase.idfHumanCase = tHumanParty.idfCase
						inner join	dbo.tlbHuman	as tHuman
								on	tHumanParty.idfParty = tHuman.idfHuman
							   and  tHumanParty.intRowStatus = 0
						)
					on	tCase.idfCase = tHumanCase.idfHumanCase

			-- get vet case
			 left join  (
									dbo.tlbVetCase	as tVetCase
						-- Get Farm
						inner join	dbo.tlbParty	as tFarmParty
								on	tVetCase.idfVetCase = tFarmParty.idfCase
						inner join	dbo.tlbFarm		as tFarm
								on	tFarmParty.idfParty = tFarm.idfFarm
							   and  tFarmParty.intRowStatus = 0
						 left join	tlbHuman		as tFarmOwner
								on	tFarm.idfHuman = tFarmOwner.idfHuman
						)
					on	tCase.idfCase = tVetCase.idfVetCase

			-- Get Diagnosis
			 left join	fnReference(@LangID, 19000019/*'rftDiagnosis' */) as rfDiagnosis
					on	rfDiagnosis.idfsReference = tCase.idfsShowDiagnosis
			 /* it should be final, not initial
					on	rfDiagnosis.idfsReference = tHumanCase.idfsTentativeDiagnosis
					or	rfDiagnosis.idfsReference = tVetCase.idfsTentativeDiagnosis
					*/
			)
			on		tCase.idfCase = tSession.idfMonitoringSession
-- Get Accession, Container, Matererial
	 left join	(
							fnMaterialList(@LangID) fnMaterial
				 left join	fnAnimalList(@LangID) fnAnimal
						on	fnMaterial.idfParty = fnAnimal.idfParty
				 left join	dbo.tlbPerson as tCollectedPerson
						on	tCollectedPerson.idfPerson = fnMaterial.idfFieldCollectedByPerson

						left join
								(
											tlbContainer		as tContainer
								inner join	tlbAccessionIn		as tAccession
										on	tAccession.idfContainer = tContainer.idfContainer
									   and  tAccession.intRowStatus = 0
								 left join	dbo.tlbPerson		as tAccessionPerson
										on	tAccessionPerson.idfPerson = tAccession.idfAccesionByPerson
								 left join	dbo.fn_RepositorySchema (@LangID, null, null) as fnRepository
										on	tContainer.idfSubdivision = fnRepository.idfSubdivision								 
								 left join	fnDepartment(@LangID) as fnDepartment
										on	fnDepartment.idfDepartment = tContainer.idfInDepartment
								)
							on	tContainer.idfMaterial = fnMaterial.idfMaterial
				)
				on	((fnMaterial.idfCase = tCase.idfCase) or	
					(fnMaterial.idfMonitoringSession = tSession.idfMonitoringSession))

		 where	((tCase.intRowStatus = 0	   and	tCase.idfCase = @ObjID)
				or (tSession.intRowStatus = 0  and	tSession.idfMonitoringSession = @ObjID))
			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
