
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptemp_GetVetCaseParams]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptemp_GetVetCaseParams]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
	Declare @VetCase xml
	Declare @Farm xml
	exec sptemp_GetVetCaseParams 'VAZBA000100038', @VetCase output, @Farm output
	Select @VetCase, @Farm
*/

CREATE    PROCEDURE [dbo].[sptemp_GetVetCaseParams]
	@strCaseID nvarchar(200),
	@VetCase xml output,
	@Farm xml output
as


Select @VetCase = (
	Select 
		idfOutbreak,
		idfsTentativeDiagnosis,
		idfsTentativeDiagnosis1,
		idfsTentativeDiagnosis2,
		idfsFinalDiagnosis,
		idfsCaseStatus,
		idfsCaseType,
		idfPersonReportedBy,
		idfPersonInvestigatedBy,
		idfsCaseProgressStatus,
		convert(nvarchar(10), datEnteredDate, 20) as datEnteredDate,
		idfPersonEnteredBy,
		Cas.idfsSite,
		convert(nvarchar(10), datReportDate, 20) as datReportDate,
		convert(nvarchar(10), datAssignedDate, 20) as datAssignedDate,
		convert(nvarchar(10), datInvestigationDate, 20) as datInvestigationDate,
		convert(nvarchar(10), datTentativeDiagnosisDate, 20) as datTentativeDiagnosisDate,
		convert(nvarchar(10), datTentativeDiagnosis1Date, 20) as datTentativeDiagnosis1Date,
		convert(nvarchar(10), datTentativeDiagnosis2Date, 20) as datTentativeDiagnosis2Date,
		convert(nvarchar(10), datFinalDiagnosisDate, 20) as datFinalDiagnosisDate,
		Cas.strSampleNotes,
		strTestNotes,
		strSummaryNotes,
		strClinicalNotes,

		convert(xml, (select 
				idfsCaseLogStatus,
				idfPerson,
				convert(nvarchar(10), datCaseLogDate, 20) as datCaseLogDate,
				strActionRequired,
				strNote
			From dbo.tlbCase Cas
			Inner Join dbo.tlbVetCaseLog Vcl On Cas.idfCase = Vcl.idfVetCase
			Where Cas.strCaseID = @strCaseID
			For Xml Path('Log'), Root('Logs'))
			)

	From dbo.tlbCase Cas
	Inner Join dbo.tlbVetCase Vcs On Cas.idfCase = Vcs.idfVetCase
	Where strCaseID = @strCaseID
	For Xml Path(''), Root('VetCase')
	)


Select @Farm = (
	Select
		convert(xml, (select 
			idfsGroundType,
			idfsGeoLocationType,
			idfsCountry,
			idfsRegion,
			idfsRayon,
			idfsSettlement,
			strDescription,
			dblLatitude,
			dblLongitude,
			dblAccuracy,
			dblDistance,
			dblAlignment
		From dbo.tlbGeoLocation Glk 
		Where Glk.idfGeoLocation = Frm.idfFarmLocation
		For Xml Path(''), Root('GeoLocation'))
		),
	
		convert(xml, (select 
			idfsCountry,
			idfsRegion,
			idfsRayon,
			idfsSettlement,
			idfsResidentType,
			strApartment,
			strBuilding,
			strStreetName,
			strHouse,
			strPostCode
		From dbo.tlbGeoLocation Glk 
		Where Glk.idfGeoLocation = Frm.idfFarmAddress
		For Xml Path(''), Root('Address'))
		),
	
		idfMonitoringSession,
		strContactPhone,
		strInternationalName,
		strNationalName,
		strFax,
		strEmail,
		blnIsLivestock,
		blnIsAvian,
		strOwnerLastName,
		strOwnerFirstName,
		strOwnerMiddleName,
		idfsOwnershipStructure,
		idfsLivestockProductionType,
		idfsGrazingPattern,
		idfsMovementPattern,

		idfsAvianFarmType,
		idfsAvianProductionType,
		idfsIntendedUse,
		intBuidings,
		intBirdsPerBuilding,

		convert(xml, (select 

			convert(xml, (select 
				idfsSpeciesType as strName,
				intTotalAnimalQty,
				intSickAnimalQty,
				intDeadAnimalQty,
				strAverageAge,
				convert(nvarchar(10), datStartOfSignsDate, 20) as datStartOfSignsDate,
				strNote,

				convert(xml, (select 
					idfsAnimalAge,
					idfsAnimalGender,
					idfsAnimalCondition,
					strDescription,

					convert(xml, (select 
						strFieldBarcode,
						idfsSpecimenType,
						convert(nvarchar(10), datFieldCollectionDate, 20) as datFieldCollectionDate,
						convert(nvarchar(10), datFieldSentDate, 20) as datFieldSentDate,
						idfFieldCollectedByOffice,
						idfFieldCollectedByPerson,
						idfTesting,

						convert(xml, (select 
							datAccession,
							strCondition,
							idfsAccessionCondition,
							strNote,
							idfSubdivision,
							idfInDepartment,
							idfAccesionByPerson,

							convert(xml, (select 
								idfMonitoringSession,
								idfsTestType,
								idfsTestForDiseaseType,
								idfsDiagnosis

							From dbo.tlbTesting Tst
							Where Tst.idfContainer = Acc.idfContainer
							For Xml Path('LabTest'), Root('LabTests')))
						For Xml Path(''), Root('Accession'))),

						convert(xml, (select 
							idfsPensideTestResult,
							idfsPensideTestType

						From dbo.tlbPensideTest Pst
						Where Pst.idfMaterial = Mtr.idfMaterial
						For Xml Path('PensideTest'), Root('PensideTests')))

					From dbo.tlbMaterial Mtr
						Left Outer Join tlbContainer Cnt On Cnt.idfMaterial = Mtr.idfMaterial
						Left Outer Join tlbAccessionIN Acc On Acc.idfMaterial = Mtr.idfMaterial
					Where Mtr.idfParty = Anm.idfAnimal
					For Xml Path('LabSample'), Root('LabSamples'))
					) 

				From dbo.tlbAnimal Anm
				Where Anm.idfSpecies = Spc.idfSpecies
				For Xml Path('Animal'), Root('Animals'))
				),

				convert(xml, (select 
					idfsVaccinationType,
					idfsVaccinationRoute,
					idfsDiagnosis,
					convert(nvarchar(10), datVaccinationDate, 20) as datVaccinationDate,
					strManufacturer,
					strLotNumber,
					intNumberVaccinated,
					strNote
				From dbo.tlbVaccination Vcn
				Where Vcn.idfSpecies = Spc.idfSpecies
				For Xml Path('Vaccination'), Root('Vaccinations'))
				),

				convert(xml, (select 
					strFieldBarcode,
					idfsSpecimenType,
					convert(nvarchar(10), datFieldCollectionDate, 20) as datFieldCollectionDate,
					convert(nvarchar(10), datFieldSentDate, 20) as datFieldSentDate,
					idfFieldCollectedByOffice,
					idfFieldCollectedByPerson,
					idfTesting,

					convert(xml, (select 
						datAccession,
						strCondition,
						idfsAccessionCondition,
						strNote,
						idfSubdivision,
						idfInDepartment,
						idfAccesionByPerson,

						convert(xml, (select 
							idfMonitoringSession,
							idfsTestType,
							idfsTestForDiseaseType,
							idfsDiagnosis

						From dbo.tlbTesting Tst
						Where Tst.idfContainer = Acc.idfContainer
						For Xml Path('LabTest'), Root('LabTests')))
					For Xml Path(''), Root('Accession'))),

					convert(xml, (select 
						idfsPensideTestResult,
						idfsPensideTestType

					From dbo.tlbPensideTest Pst
					Where Pst.idfMaterial = Mtr.idfMaterial
					For Xml Path('PensideTest'), Root('PensideTests')))

				From dbo.tlbMaterial Mtr
					Left Outer Join tlbContainer Cnt On Cnt.idfMaterial = Mtr.idfMaterial
					Left Outer Join tlbAccessionIN Acc On Acc.idfMaterial = Mtr.idfMaterial
				Where Mtr.idfParty = Spc.idfSpecies
				For Xml Path('LabSample'), Root('LabSamples'))
				) 

			From dbo.tlbSpecies Spc 
			Where Spc.idfHerd = Hrd.idfHerd
			For Xml Path('Species'), Root('Speciess'))
			) 

		From dbo.tlbHerd Hrd
		Where Hrd.idfFarm = Frm.idfFarm
		For Xml Path('Herd'), Root('Herds'))
		)

	From dbo.tlbCase Cas
	Inner Join dbo.tlbParty Prt1 On Cas.idfCase = Prt1.idfCase
	Inner Join dbo.tlbFarm Frm On Frm.idfFarm = Prt1.idfParty
	Where strCaseID = @strCaseID
		And Prt1.idfsPartyType = 10072005 -- Farm
	For Xml Path(''), Root('Farm')
	)


