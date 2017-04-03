
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sptemp_CreateVetCaseParams]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sptemp_CreateVetCaseParams]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
exec dbo.sptemp_CreateVetCaseParams
'<VetCase>
	<!--idfOutbreak></idfOutbreak-->
	<idfsTentativeDiagnosis>2030000000</idfsTentativeDiagnosis>
	<idfsTentativeDiagnosis1>1930000000</idfsTentativeDiagnosis1>
	<idfsTentativeDiagnosis2>2480000000</idfsTentativeDiagnosis2>
	<idfsFinalDiagnosis>1500000000</idfsFinalDiagnosis>
	<idfsCaseStatus>350000000</idfsCaseStatus>
	<idfsCaseType>10012003</idfsCaseType>
	<idfPersonReportedBy>71050000000</idfPersonReportedBy>
	<idfPersonInvestigatedBy>71050000000</idfPersonInvestigatedBy>
	<idfsCaseProgressStatus>10109001</idfsCaseProgressStatus>
	<datEnteredDate>2010-05-01</datEnteredDate>
	<idfPersonEnteredBy>709240000000</idfPersonEnteredBy>
	<idfsSite>4</idfsSite>
	<datReportDate>2010-05-01</datReportDate>
	<datAssignedDate>2010-05-01</datAssignedDate>
	<datInvestigationDate>2010-05-01</datInvestigationDate>
	<datTentativeDiagnosisDate>2010-05-01</datTentativeDiagnosisDate>
	<datTentativeDiagnosis1Date>2010-05-01</datTentativeDiagnosis1Date>
	<datTentativeDiagnosis2Date>2010-05-01</datTentativeDiagnosis2Date>
	<datFinalDiagnosisDate>2010-05-01</datFinalDiagnosisDate>
	<!--strSampleNotes></strSampleNotes-->
	<!--strTestNotes></strTestNotes-->
	<!--strSummaryNotes></strSummaryNotes-->
	<!--strClinicalNotes></strClinicalNotes-->

	<Logs>
		<Log>
			<idfsCaseLogStatus>10103001</idfsCaseLogStatus>
			<idfPerson>709240000000</idfPerson>
			<datCaseLogDate>2010-02-02</datCaseLogDate>
			<strActionRequired>wwwww</strActionRequired>
			<strNote>asdsadas</strNote>
		</Log>
		<Log>
			<idfsCaseLogStatus>10103002</idfsCaseLogStatus>
			<idfPerson>709240000000</idfPerson>
			<datCaseLogDate>2010-03-03</datCaseLogDate>
			<strActionRequired>qqqqqq</strActionRequired>
			<strNote>sdfsdfsdfsdfsdfsdfsdf</strNote>
		</Log>
	</Logs>
</VetCase>',
'<Farm>
	<GeoLocation>
		<!--idfsGroundType></idfsGroundType-->
		<idfsGeoLocationType>10036003</idfsGeoLocationType>
		<idfsCountry>170000000</idfsCountry>
		<idfsRegion>30160000000</idfsRegion>
		<idfsRayon>2560000000</idfsRayon>
		<idfsSettlement>57760000000</idfsSettlement>
		<!--strDescription></strDescription-->
		<dblLatitude>40.6123</dblLatitude>
		<dblLongitude>48.8574</dblLongitude>
		<dblAccuracy>0.01</dblAccuracy>
		<!--dblDistance></dblDistance-->
		<!--dblAlignment></dblAlignment-->
	</GeoLocation>
	<Address>
		<idfsCountry>170000000</idfsCountry>
		<idfsRegion>30160000000</idfsRegion>
		<idfsRayon>2560000000</idfsRayon>
		<idfsSettlement>57760000000</idfsSettlement>
		<!--idfsResidentType></idfsResidentType-->
		<strApartment>33</strApartment>
		<strBuilding>22</strBuilding>
		<strStreetName>street</strStreetName>
		<strHouse>11</strHouse>
		<strPostCode>1234546</strPostCode>
	</Address>


	<!--idfMonitoringSession></idfMonitoringSession-->
	<strContactPhone>111</strContactPhone>
	<strInternationalName>farm1</strInternationalName>
	<strNationalName>farm2</strNationalName>
	<strFax>222</strFax>
	<strEmail>333</strEmail>
	<blnIsLivestock>1</blnIsLivestock>
	<!--blnIsAvian></blnIsAvian-->
	<strOwnerLastName>farm</strOwnerLastName>
	<strOwnerFirstName>owner</strOwnerFirstName>
	<strOwnerMiddleName></strOwnerMiddleName>

	<idfsOwnershipStructure>10810000000</idfsOwnershipStructure>
	<idfsLivestockProductionType>10540000000</idfsLivestockProductionType>
	<idfsGrazingPattern>5240000000</idfsGrazingPattern>
	<idfsMovementPattern>10610000000</idfsMovementPattern>

	<!--idfsAvianFarmType></idfsAvianFarmType-->
	<!--idfsAvianProductionType></idfsAvianProductionType-->
	<!--idfsIntendedUse></idfsIntendedUse-->
	<!--intBuidings></intBuidings-->
	<!--intBirdsPerBuilding></intBirdsPerBuilding-->

	<Herds>
		<Herd>
			<Speciess>
				<Species>
					<strName>39260000000</strName>
					<intTotalAnimalQty>100</intTotalAnimalQty>
					<intSickAnimalQty>1</intSickAnimalQty>
					<intDeadAnimalQty>2</intDeadAnimalQty>
					<!--strAverageAge></strAverageAge-->
					<!--datStartOfSignsDate></datStartOfSignsDate-->
					<strNote>qqq</strNote>
				</Species>
				<Species>
					<strName>39250000000</strName>
					<intTotalAnimalQty>200</intTotalAnimalQty>
					<intSickAnimalQty>2</intSickAnimalQty>
					<intDeadAnimalQty>3</intDeadAnimalQty>
					<!--strAverageAge></strAverageAge-->
					<!--datStartOfSignsDate></datStartOfSignsDate-->
					<!--strNote>aaa</strNote-->
					<Animals>
						<Animal>
							<idfsAnimalAge>80000000</idfsAnimalAge>
							<idfsAnimalGender>10007001</idfsAnimalGender>
							<idfsAnimalCondition>190000000</idfsAnimalCondition>
							<strDescription>descr1</strDescription>
							
							<!-- for Livestock -->
							<LabSamples>
								<LabSample>
									<strFieldBarcode>QQQQQ1</strFieldBarcode>
									<idfsSpecimenType>39320000000</idfsSpecimenType>
									<datFieldCollectionDate>2010-06-06</datFieldCollectionDate>
									<!--datFieldSentDate></datFieldSentDate-->
									<idfFieldCollectedByOffice>48160000000</idfFieldCollectedByOffice>
									<idfFieldCollectedByPerson>711970000000</idfFieldCollectedByPerson>
									<!--idfTesting></idfTesting-->
									<PensideTests>
										<PensideTest>
											<idfsPensideTestResult>40490000000</idfsPensideTestResult>
											<idfsPensideTestType>40560000000</idfsPensideTestType>
										</PensideTest>
										<PensideTest>
											<idfsPensideTestResult>40480000000</idfsPensideTestResult>
											<idfsPensideTestType>40540000000</idfsPensideTestType>
										</PensideTest>
									</PensideTests>
								</LabSample>
								<LabSample>
									<strFieldBarcode>WWWWW1</strFieldBarcode>
									<idfsSpecimenType>39330000000</idfsSpecimenType>
									<datFieldCollectionDate>2010-07-07</datFieldCollectionDate>
									<!--datFieldSentDate></datFieldSentDate-->
									<idfFieldCollectedByOffice>48130000000</idfFieldCollectedByOffice>
									<idfFieldCollectedByPerson>711910000000</idfFieldCollectedByPerson>
									<!--idfTesting></idfTesting-->
									<Accession>
										<datAccession>2010-08-08</datAccession>
										<strCondition>5</strCondition>
										<idfsAccessionCondition>10108001</idfsAccessionCondition>
										<strNote>3</strNote>
										<!--idfSubdivision></idfSubdivision-->
										<!--idfDepartment></idfDepartment-->
										<idfAccesionByPerson>709240000000</idfAccesionByPerson>
										<LabTests>
											<LabTest>
												<!--idfMonitoringSession></idfMonitoringSession-->
												<idfsTestType>40630000000</idfsTestType>
												<idfsTestForDiseaseType>10095003</idfsTestForDiseaseType>
												<idfsDiagnosis>1930000000</idfsDiagnosis>
											</LabTest>
										</LabTests>
									</Accession>
								</LabSample>
							</LabSamples>

						</Animal>
						<Animal>
							<idfsAnimalAge>60000000</idfsAnimalAge>
							<idfsAnimalGender>10007002</idfsAnimalGender>
							<idfsAnimalCondition>170000000</idfsAnimalCondition>
							<strDescription>descr2</strDescription>
						</Animal>
					</Animals>
					<Vaccinations>
						<Vaccination>
							<idfsVaccinationType>41660000000</idfsVaccinationType>
							<idfsVaccinationRoute>41590000000</idfsVaccinationRoute>
							<idfsDiagnosis>1930000000</idfsDiagnosis>
							<datVaccinationDate>2010-01-01</datVaccinationDate>
							<strManufacturer>rrr</strManufacturer>
							<strLotNumber>5</strLotNumber>
							<intNumberVaccinated>4</intNumberVaccinated>
							<strNote>fdf</strNote>
						</Vaccination>
						<Vaccination>
							<idfsVaccinationType>41680000000</idfsVaccinationType>
							<idfsVaccinationRoute>41610000000</idfsVaccinationRoute>
							<idfsDiagnosis>1500000000</idfsDiagnosis>
							<datVaccinationDate>2010-02-02</datVaccinationDate>
							<strManufacturer>ttt</strManufacturer>
							<strLotNumber>tt</strLotNumber>
							<intNumberVaccinated>5</intNumberVaccinated>
							<strNote>fdfddf</strNote>
						</Vaccination>
					</Vaccinations>

					<!-- for Avian -->
					<LabSamples>
						<LabSample>
							<strFieldBarcode>QQQQQ1</strFieldBarcode>
							<idfsSpecimenType>39320000000</idfsSpecimenType>
							<datFieldCollectionDate>2010-06-06</datFieldCollectionDate>
							<!--datFieldSentDate></datFieldSentDate-->
							<idfFieldCollectedByOffice>48160000000</idfFieldCollectedByOffice>
							<idfFieldCollectedByPerson>711970000000</idfFieldCollectedByPerson>
							<!--idfTesting></idfTesting-->
							<PensideTests>
								<PensideTest>
									<idfsPensideTestResult>40490000000</idfsPensideTestResult>
									<idfsPensideTestType>40560000000</idfsPensideTestType>
								</PensideTest>
								<PensideTest>
									<idfsPensideTestResult>40480000000</idfsPensideTestResult>
									<idfsPensideTestType>40540000000</idfsPensideTestType>
								</PensideTest>
							</PensideTests>
						</LabSample>
						<LabSample>
							<strFieldBarcode>WWWWW1</strFieldBarcode>
							<idfsSpecimenType>39330000000</idfsSpecimenType>
							<datFieldCollectionDate>2010-07-07</datFieldCollectionDate>
							<!--datFieldSentDate></datFieldSentDate-->
							<idfFieldCollectedByOffice>48130000000</idfFieldCollectedByOffice>
							<idfFieldCollectedByPerson>711910000000</idfFieldCollectedByPerson>
							<!--idfTesting></idfTesting-->
							<Accession>
								<datAccession>2010-08-08</datAccession>
								<strCondition>5</strCondition>
								<idfsAccessionCondition>10108001</idfsAccessionCondition>
								<strNote>3</strNote>
								<!--idfSubdivision></idfSubdivision-->
								<!--idfDepartment></idfDepartment-->
								<idfAccesionByPerson>709240000000</idfAccesionByPerson>
								<LabTests>
									<LabTest>
										<!--idfMonitoringSession></idfMonitoringSession-->
										<idfsTestType>40630000000</idfsTestType>
										<idfsTestForDiseaseType>10095003</idfsTestForDiseaseType>
										<idfsDiagnosis>1930000000</idfsDiagnosis>
									</LabTest>
								</LabTests>
							</Accession>
						</LabSample>
					</LabSamples>

				</Species>
			</Speciess>
		</Herd>
		<Herd>
			<Speciess>
				<Species>
					<strName>39250000000</strName>
					<intTotalAnimalQty>300</intTotalAnimalQty>
					<intSickAnimalQty>4</intSickAnimalQty>
					<intDeadAnimalQty>5</intDeadAnimalQty>
					<!--strAverageAge></strAverageAge-->
					<!--datStartOfSignsDate></datStartOfSignsDate-->
					<strNote>qqq</strNote>
				</Species>
			</Speciess>
		</Herd>
 	</Herds>
</Farm>'


*/

CREATE    PROCEDURE [dbo].[sptemp_CreateVetCaseParams]
	@VetCase xml,
	@Farm xml
as


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

EXEC spSysGetNewID @idfCase OUTPUT
SET @idfOutbreak = @VetCase.value('(/VetCase/idfOutbreak)[1]', 'bigint')
SET @idfsCaseStatus = @VetCase.value('(/VetCase/idfsCaseStatus)[1]', 'bigint')
SET @idfsCaseProgressStatus = @VetCase.value('(/VetCase/idfsCaseProgressStatus)[1]', 'bigint')
SET @idfsCaseType = @VetCase.value('(/VetCase/idfsCaseType)[1]', 'bigint')
SET @datEnteredDate = @VetCase.value('(/VetCase/datEnteredDate)[1]', 'datetime')
EXEC spGetNextNumber 10057024,@strCaseID output,0
SET @idfsTentativeDiagnosis = @VetCase.value('(/VetCase/idfsTentativeDiagnosis)[1]', 'bigint')
SET @idfsTentativeDiagnosis1 = @VetCase.value('(/VetCase/idfsTentativeDiagnosis1)[1]', 'bigint')
SET @idfsTentativeDiagnosis2 = @VetCase.value('(/VetCase/idfsTentativeDiagnosis2)[1]', 'bigint')
SET @idfsFinalDiagnosis = @VetCase.value('(/VetCase/idfsFinalDiagnosis)[1]', 'bigint')
SET @idfPersonInvestigatedBy = @VetCase.value('(/VetCase/idfPersonInvestigatedBy)[1]', 'bigint')
SET @idfPersonEnteredBy = @VetCase.value('(/VetCase/idfPersonEnteredBy)[1]', 'bigint')
SET @idfPersonReportedBy = @VetCase.value('(/VetCase/idfPersonReportedBy)[1]', 'bigint')
SET @idfsSite = @VetCase.value('(/VetCase/idfsSite)[1]', 'bigint')
SET @datReportDate = @VetCase.value('(/VetCase/datReportDate)[1]', 'datetime')
SET @datAssignedDate = @VetCase.value('(/VetCase/datAssignedDate)[1]', 'datetime')
SET @datInvestigationDate = @VetCase.value('(/VetCase/datInvestigationDate)[1]', 'datetime')
SET @datTentativeDiagnosisDate = @VetCase.value('(/VetCase/datTentativeDiagnosisDate)[1]', 'datetime')
SET @datTentativeDiagnosis1Date = @VetCase.value('(/VetCase/datTentativeDiagnosis1Date)[1]', 'datetime')
SET @datTentativeDiagnosis2Date = @VetCase.value('(/VetCase/datTentativeDiagnosis2Date)[1]', 'datetime')
SET @datFinalDiagnosisDate = @VetCase.value('(/VetCase/datFinalDiagnosisDate)[1]', 'datetime')
SET @strSampleNotes = @VetCase.value('(/VetCase/strSampleNotes)[1]', 'nvarchar(1000)')
SET @strTestNotes = @VetCase.value('(/VetCase/strTestNotes)[1]', 'nvarchar(1000)')
SET @strSummaryNotes = @VetCase.value('(/VetCase/strSummaryNotes)[1]', 'nvarchar(1000)')
SET @strClinicalNotes = @VetCase.value('(/VetCase/strClinicalNotes)[1]', 'nvarchar(1000)')
EXEC spGetNextNumber 10057025,@strFieldAccessionID output,0

SET @idfsShowDiagnosis = dbo.fnVetCaseGetShowDiagnosis(
	@idfsTentativeDiagnosis,
	@idfsTentativeDiagnosis1,
	@idfsTentativeDiagnosis2,
	@idfsFinalDiagnosis, 
	@datTentativeDiagnosisDate, 
	@datTentativeDiagnosis1Date, 
	@datTentativeDiagnosis2Date, 
	@datFinalDiagnosisDate
	)

--##PARAM @idfsCaseType - case type, reference to rftCaseType (19000012). Can be Livestock(10012003) or Avian(10012004)
Declare @IsLivestock bit
Declare @IsAvian bit
Select @IsLivestock = 0
Select @IsAvian = 0
If @idfsCaseType = 10012003 Select @IsLivestock = 1
Else If @idfsCaseType = 10012004 Select @IsAvian = 1

If @IsLivestock = 1
	Begin
		EXEC spFFGetFormTemplate @idfsShowDiagnosis, 10034014, @idfsFormTemplate OUTPUT
	End
Else If @IsAvian = 1
	Begin
		Select @idfsFormTemplate = NULL
	End

EXEC spSysGetNewID @idfObservation OUTPUT

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



DECLARE @idfGeoLocation as bigint
DECLARE @idfsGroundType as bigint
DECLARE @idfsGeoLocationType as bigint
DECLARE @idfsCountry as bigint
DECLARE @idfsRegion as bigint
DECLARE @idfsRayon as bigint
DECLARE @idfsSettlement as bigint
DECLARE @strDescription as nvarchar(200)
DECLARE @dblLatitude as float
DECLARE @dblLongitude as float
DECLARE @dblRelLatitude as float
DECLARE @dblRelLongitude as float
DECLARE @dblAccuracy as float
DECLARE @dblDistance as float
DECLARE @dblAlignment as float

EXEC spSysGetNewID @idfGeoLocation OUTPUT
SET @idfsGroundType = @Farm.value('(/Farm/GeoLocation/idfsGroundType)[1]', 'bigint')
SET @idfsGeoLocationType = @Farm.value('(/Farm/GeoLocation/idfsGeoLocationType)[1]', 'bigint')
SET @idfsCountry = @Farm.value('(/Farm/GeoLocation/idfsCountry)[1]', 'bigint')
SET @idfsRegion = @Farm.value('(/Farm/GeoLocation/idfsRegion)[1]', 'bigint')
SET @idfsRayon = @Farm.value('(/Farm/GeoLocation/idfsRayon)[1]', 'bigint')
SET @idfsSettlement = @Farm.value('(/Farm/GeoLocation/idfsSettlement)[1]', 'bigint')
SET @strDescription = @Farm.value('(/Farm/GeoLocation/strDescription)[1]', 'nvarchar(200)')
SET @dblLatitude = @Farm.value('(/Farm/GeoLocation/dblLatitude)[1]', 'float')
SET @dblLongitude = @Farm.value('(/Farm/GeoLocation/dblLongitude)[1]', 'float')
SET @dblRelLatitude = @Farm.value('(/Farm/GeoLocation/dblRelLatitude)[1]', 'float')
SET @dblRelLongitude = @Farm.value('(/Farm/GeoLocation/dblRelLongitude)[1]', 'float')
SET @dblAccuracy = @Farm.value('(/Farm/GeoLocation/dblAccuracy)[1]', 'float')
SET @dblDistance = @Farm.value('(/Farm/GeoLocation/dblDistance)[1]', 'float')
SET @dblAlignment = @Farm.value('(/Farm/GeoLocation/dblAlignment)[1]', 'float')

exec spGeoLocation_Post 
	 @idfGeoLocation
	,@idfsGroundType
	,@idfsGeoLocationType
	,@idfsCountry
	,@idfsRegion
	,@idfsRayon
	,@idfsSettlement
	,@strDescription
	,@dblLatitude
	,@dblLongitude
	,@dblRelLatitude
	,@dblRelLongitude
	,@dblAccuracy
	,@dblDistance
	,@dblAlignment


DECLARE @idfAddress AS bigint
DECLARE @idfsResidentType AS bigint
DECLARE @strApartment AS NVARCHAR(200)
DECLARE @strBuilding AS NVARCHAR(200)
DECLARE @strStreetName AS NVARCHAR(200)
DECLARE @strHouse AS NVARCHAR(200)
DECLARE @strPostCode AS NVARCHAR(200)

EXEC spSysGetNewID @idfAddress OUTPUT
SET @idfsCountry = @Farm.value('(/Farm/Address/idfsCountry)[1]', 'bigint')
SET @idfsRegion = @Farm.value('(/Farm/Address/idfsRegion)[1]', 'bigint')
SET @idfsRayon = @Farm.value('(/Farm/Address/idfsRayon)[1]', 'bigint')
SET @idfsSettlement = @Farm.value('(/Farm/Address/idfsSettlement)[1]', 'bigint')
SET @idfsResidentType = @Farm.value('(/Farm/Address/idfsResidentType)[1]', 'bigint')
SET @strApartment = @Farm.value('(/Farm/Address/strApartment)[1]', 'nvarchar(200)')
SET @strBuilding = @Farm.value('(/Farm/Address/strBuilding)[1]', 'nvarchar(200)')
SET @strStreetName = @Farm.value('(/Farm/Address/strStreetName)[1]', 'nvarchar(200)')
SET @strHouse = @Farm.value('(/Farm/Address/strHouse)[1]', 'nvarchar(200)')
SET @strPostCode = @Farm.value('(/Farm/Address/strPostCode)[1]', 'nvarchar(200)')

exec spAddress_Post
	 @idfAddress
	,@idfsCountry
	,@idfsRegion
	,@idfsRayon
	,@idfsSettlement
	,@idfsResidentType
	,@strApartment
	,@strBuilding
	,@strStreetName
	,@strHouse
	,@strPostCode



DECLARE @idfFarm bigint
DECLARE @idfRootFarm bigint
DECLARE @idfMonitoringSession bigint
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

EXEC spSysGetNewID @idfFarm OUTPUT
EXEC spSysGetNewID @idfRootFarm OUTPUT
SET @idfMonitoringSession = @Farm.value('(/Farm/idfMonitoringSession)[1]', 'bigint')
SET @strContactPhone = @Farm.value('(/Farm/strContactPhone)[1]', 'nvarchar(200)')
SET @strInternationalName = @Farm.value('(/Farm/strInternationalName)[1]', 'nvarchar(200)')
SET @strNationalName = @Farm.value('(/Farm/strNationalName)[1]', 'nvarchar(200)')
SET @strFax = @Farm.value('(/Farm/strFax)[1]', 'nvarchar(200)')
SET @strEmail = @Farm.value('(/Farm/strEmail)[1]', 'nvarchar(200)')
SET @blnIsLivestock = @Farm.value('(/Farm/blnIsLivestock)[1]', 'bit')
SET @blnIsAvian = @Farm.value('(/Farm/blnIsAvian)[1]', 'bit')
EXEC spSysGetNewID @idfOwner OUTPUT
SET @strOwnerLastName = @Farm.value('(/Farm/strOwnerLastName)[1]', 'nvarchar(200)')
SET @strOwnerFirstName = @Farm.value('(/Farm/strOwnerFirstName)[1]', 'nvarchar(200)')
SET @strOwnerMiddleName = @Farm.value('(/Farm/strOwnerMiddleName)[1]', 'nvarchar(200)')

exec spFarmPanel_Post 
   4
  ,@idfFarm
  ,@idfRootFarm OUTPUT
  ,@idfCase
  ,@idfMonitoringSession
  ,@strContactPhone
  ,@strInternationalName
  ,@strNationalName
  ,@strFarmCode OUTPUT
  ,@strFax
  ,@strEmail
  ,@idfGeoLocation
  ,@idfAddress
  ,@blnIsLivestock
  ,@blnIsAvian
  ,@idfOwner
  ,@idfRootOwner OUTPUT
  ,@strOwnerLastName
  ,@strOwnerFirstName
  ,@strOwnerMiddleName



--Insert Farm Node
EXEC spSysGetNewID @idfObservation OUTPUT
DECLARE @FFTypeFarm bigint
If @IsLivestock = 1 select @FFTypeFarm = 10034015
Else If @IsAvian = 1 select @FFTypeFarm = 10034007
EXEC spFFGetFormTemplate @idfsShowDiagnosis, @FFTypeFarm, @idfsFormTemplate OUTPUT

DECLARE @intTotalAnimalQty int
DECLARE @intSickAnimalQty int
DECLARE @intDeadAnimalQty int

SET @intTotalAnimalQty = convert(int, @Farm.value('sum(/Farm/Herds/Herd/Speciess/Species/intTotalAnimalQty)', 'float'))
SET @intSickAnimalQty = convert(int, @Farm.value('sum(/Farm/Herds/Herd/Speciess/Species/intSickAnimalQty)', 'float'))
SET @intDeadAnimalQty = convert(int, @Farm.value('sum(/Farm/Herds/Herd/Speciess/Species/intDeadAnimalQty)', 'float'))

exec spVetFarmTree_Post
	 4 --@Action int,   --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
	,@idfCase --@idfCase bigint, --##PARAM @idfCase - ID of case to which animal belongs
	,@idfFarm --@idfParty bigint, --##PARAM @idfParty - reference to farm, herd or species record (depending on @idfsPartyType)
	,10072005 --@idfsPartyType bigint, --##PARAM @idfsPartyType - type of posted record (can reference farm, herd or species)
	,@strFarmCode OUTPUT --@strName nvarchar(200) OUTPUT, --##PARAM @strName - the the human readable name of the farm tree node. Displays farm code, herd code, of idfSpeciesType
	,NULL --@idfParentParty bigint, --##PARAM @idfParentParty - ID of parent node
	,@idfObservation --@idfObservation bigint, --##PARAM @idfObservation - ID of observation related with current node
	,@idfsFormTemplate --@idfsFormTemplate BIGINT, --##PARAM @idfsFormTemplate - reference to template that was used last time for control measures flexible form 
	,@intTotalAnimalQty --@intTotalAnimalQty int, --##PARAM @intTotalAnimalQty - Total Animal Qty related with current node
	,@intSickAnimalQty --@intSickAnimalQty int, --##PARAM @intSickAnimalQty - Sick Animal Qty related with current node
	,@intDeadAnimalQty --@intDeadAnimalQty int, --##PARAM @intDeadAnimalQty - Dead Animal Qty related with current node
	,NULL --@strAverageAge nvarchar(200), --##PARAM @strAverageAge - Average age of animal related with current node
	,NULL --@datStartOfSignsDate datetime, --##PARAM @datStartOfSignsDate - date when signs was started
	,NULL --@strNote nvarchar(2000) --##PARAM @strNote


Declare @Herd xml
DECLARE Herds CURSOR FOR 
SELECT T.c.query('.') AS result
FROM   @Farm.nodes('/Farm/Herds/Herd') T(c)

OPEN Herds
FETCH NEXT FROM Herds INTO @Herd

WHILE @@FETCH_STATUS = 0
BEGIN
	DECLARE @strName nvarchar(200)


	--Add Herd
	DECLARE @idfHerd bigint
	exec spSysGetNewID @idfHerd OUTPUT
	set @strName=''
	SET @intTotalAnimalQty = convert(int, @Herd.value('sum(/Herd/Speciess/Species/intTotalAnimalQty)', 'float'))
	SET @intSickAnimalQty = convert(int, @Herd.value('sum(/Herd/Speciess/Species/intSickAnimalQty)', 'float'))
	SET @intDeadAnimalQty = convert(int, @Herd.value('sum(/Herd/Speciess/Species/intDeadAnimalQty)', 'float'))

	exec spVetFarmTree_Post
		 4 --@Action int,   --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
		,@idfCase --@idfCase bigint, --##PARAM @idfCase - ID of case to which animal belongs
		,@idfHerd --@idfParty bigint, --##PARAM @idfParty - reference to farm, herd or species record (depending on @idfsPartyType)
		,10072003 --@idfsPartyType bigint, --##PARAM @idfsPartyType - type of posted record (can reference farm, herd or species)
		,@strName OUTPUT --@strName nvarchar(200) OUTPUT, --##PARAM @strName - the the human readable name of the farm tree node. Displays farm code, herd code, of idfSpeciesType
		,@idfFarm --@idfParentParty bigint, --##PARAM @idfParentParty - ID of parent node
		,NULL --@idfObservation bigint, --##PARAM @idfObservation - ID of observation related with current node
		,NULL --@idfsFormTemplate BIGINT, --##PARAM @idfsFormTemplate - reference to template that was used last time for control measures flexible form 
		,@intTotalAnimalQty --@intTotalAnimalQty int, --##PARAM @intTotalAnimalQty - Total Animal Qty related with current node
		,@intSickAnimalQty --@intSickAnimalQty int, --##PARAM @intSickAnimalQty - Sick Animal Qty related with current node
		,@intDeadAnimalQty --@intDeadAnimalQty int, --##PARAM @intDeadAnimalQty - Dead Animal Qty related with current node
		,NULL --@strAverageAge nvarchar(200), --##PARAM @strAverageAge - Average age of animal related with current node
		,NULL --@datStartOfSignsDate datetime, --##PARAM @datStartOfSignsDate - date when signs was started
		,NULL --@strNote nvarchar(2000) --##PARAM @strNote


	Declare @Species xml
	DECLARE Species CURSOR FOR 
	SELECT T.c.query('.') AS result
	FROM   @Herd.nodes('/Herd/Speciess/Species') T(c)

	OPEN Species
	FETCH NEXT FROM Species INTO @Species

	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE @strNote nvarchar(200)
		DECLARE @strAverageAge nvarchar(200)
		DECLARE @datStartOfSignsDate datetime
		SET @strName = @Species.value('(/Species/strName)[1]', 'nvarchar(200)')
		SET @intTotalAnimalQty = @Species.value('(/Species/intTotalAnimalQty)[1]', 'int')
		SET @intSickAnimalQty = @Species.value('(/Species/intSickAnimalQty)[1]', 'int')
		SET @intDeadAnimalQty = @Species.value('(/Species/intDeadAnimalQty)[1]', 'int')
		SET @strAverageAge = @Species.value('(/Species/strAverageAge)[1]', 'nvarchar(200)')
		SET @datStartOfSignsDate = @Species.value('(/Species/datStartOfSignsDate)[1]', 'datetime')
		SET @strNote = @Species.value('(/Species/strNote)[1]', 'nvarchar(200)')

		--Add Species to the Herd
		DECLARE @idfSpecies bigint
		exec spSysGetNewID @idfSpecies OUTPUT
		EXEC spSysGetNewID @idfObservation OUTPUT
		DECLARE @FFTypeSpecies bigint
		If @IsLivestock = 1 select @FFTypeSpecies = 10034016
		Else If @IsAvian = 1 select @FFTypeSpecies = 10034008
		EXEC spFFGetFormTemplate @idfsShowDiagnosis, @FFTypeSpecies, @idfsFormTemplate OUTPUT

		exec spVetFarmTree_Post
			 4 --@Action int,   --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
			,@idfCase --@idfCase bigint, --##PARAM @idfCase - ID of case to which animal belongs
			,@idfSpecies --@idfParty bigint, --##PARAM @idfParty - reference to farm, herd or species record (depending on @idfsPartyType)
			,10072004 --@idfsPartyType bigint, --##PARAM @idfsPartyType - type of posted record (can reference farm, herd or species)
			,@strName OUTPUT --@strName nvarchar(200) OUTPUT, --##PARAM @strName - the the human readable name of the farm tree node. Displays farm code, herd code, of idfSpeciesType
			,@idfHerd --@idfParentParty bigint, --##PARAM @idfParentParty - ID of parent node
			,@idfObservation --@idfObservation bigint, --##PARAM @idfObservation - ID of observation related with current node
			,@idfsFormTemplate --@idfsFormTemplate BIGINT, --##PARAM @idfsFormTemplate - reference to template that was used last time for control measures flexible form 
			,@intTotalAnimalQty --@intTotalAnimalQty int, --##PARAM @intTotalAnimalQty - Total Animal Qty related with current node
			,@intSickAnimalQty --@intSickAnimalQty int, --##PARAM @intSickAnimalQty - Sick Animal Qty related with current node
			,@intDeadAnimalQty --@intDeadAnimalQty int, --##PARAM @intDeadAnimalQty - Dead Animal Qty related with current node
			,@strAverageAge --@strAverageAge nvarchar(200), --##PARAM @strAverageAge - Average age of animal related with current node
			,@datStartOfSignsDate --@datStartOfSignsDate datetime, --##PARAM @datStartOfSignsDate - date when signs was started
			,@strNote --@strNote nvarchar(2000) --##PARAM @strNote



		Declare @Animals xml
		DECLARE Animals CURSOR FOR 
		SELECT T.c.query('.') AS result
		FROM   @Species.nodes('/Species/Animals/Animal') T(c)

		OPEN Animals
		FETCH NEXT FROM Animals INTO @Animals

		WHILE @@FETCH_STATUS = 0
		BEGIN

			DECLARE @idfAnimal bigint
			DECLARE @idfsAnimalAge bigint
			DECLARE @idfsAnimalGender bigint
			DECLARE @strAnimalCode nvarchar(200)
			DECLARE @strDescriptionA nvarchar(200)
			DECLARE @idfsAnimalCondition bigint

			--Add animals
			exec spSysGetNewID @idfAnimal OUTPUT
			EXEC spSysGetNewID @idfObservation OUTPUT
			EXEC spFFGetFormTemplate @idfsShowDiagnosis, 10034013, @idfsFormTemplate OUTPUT

			SET @strDescriptionA = @Animals.value('(/Animal/strDescription)[1]', 'nvarchar(200)')
			SET @idfsAnimalAge = @Animals.value('(/Animal/idfsAnimalAge)[1]', 'bigint')
			SET @idfsAnimalGender = @Animals.value('(/Animal/idfsAnimalGender)[1]', 'bigint')
			SET @idfsAnimalCondition = @Animals.value('(/Animal/idfsAnimalCondition)[1]', 'bigint')

			EXEC spVetCaseAnimals_Post
				 4 --@Action int,  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
				,@idfAnimal --@idfAnimal BIGINT,  --##PARAM @idfAnimal - animal ID
				,@idfHerd --@idfHerd BIGINT, --##PARAM @idfHerd - animal herd ID
				,@idfsAnimalAge --@idfsAnimalAge BIGINT, --##PARAM @idfsAnimalAge - animal age, reference to rftAnimalAgeList (19000005)
				,@idfsAnimalGender --@idfsAnimalGender BIGINT, --##PARAM @idfsAnimalGender - animal gender, reference to rftAnimalGenderList (19000007)
				,@strAnimalCode OUTPUT --@strAnimalCode NVARCHAR(200) OUTPUT, --##PARAM @strAnimalCode - animal barcode
				,@strDescriptionA --@strDescription NVARCHAR(200), --##PARAM @strDescription - animal description, currently is not defined by client app
				,@idfsAnimalCondition --@idfsAnimalCondition BIGINT, --##PARAM @idfsAnimalCondition - animal state, reference to  rftAnimalCondition (19000006)
				,@idfSpecies --@idfSpecies BIGINT, --##PARAM @idfSpecies - animal species, reference to tlbSpecies table. Species defind by this value must be included to herd defined by @idfHerd
				,@idfObservation --@idfObservation BIGINT,--##PARAM @idfObservation - animal clinical signs, reference flexible form data
				,@idfsFormTemplate --@idfsFormTemplate BIGINT,--##PARAM @idfsFormTemplate - flexible form template ID
				,@idfCase --@idfCase BIGINT --##PARAM @idfCase - ID of case to which animal belongs




			Declare @LabSamples xml
			DECLARE LabSamples CURSOR FOR 
			SELECT T.c.query('.') AS result
			FROM   @Animals.nodes('/Animal/LabSamples/LabSample') T(c)

			OPEN LabSamples
			FETCH NEXT FROM LabSamples INTO @LabSamples

			WHILE @@FETCH_STATUS = 0
			BEGIN

				DECLARE @idfMaterial bigint
				DECLARE @strFieldBarcode nvarchar(200)
				DECLARE @idfsSpecimenType bigint
				DECLARE @datFieldCollectionDate datetime
				DECLARE @datFieldSentDate datetime
				DECLARE @idfFieldCollectedByOffice bigint
				DECLARE @idfFieldCollectedByPerson bigint
				DECLARE @idfTesting bigint

				DECLARE @idfContainer bigint
				DECLARE @strBarcode nvarchar(200)
				DECLARE @datAccession datetime
				DECLARE @strCondition nvarchar(200)
				DECLARE @idfsAccessionCondition bigint
				DECLARE @strNoteAccession nvarchar(200)
				DECLARE @idfSubdivision bigint
				DECLARE @idfDepartment bigint
				DECLARE @idfAccesionByPerson bigint

				EXEC spSysGetNewID @idfMaterial OUTPUT
				SET @strFieldBarcode = @LabSamples.value('(/LabSample/strFieldBarcode)[1]', 'nvarchar(200)')
				SET @idfsSpecimenType = @LabSamples.value('(/LabSample/idfsSpecimenType)[1]', 'bigint')
				SET @datFieldCollectionDate = @LabSamples.value('(/LabSample/datFieldCollectionDate)[1]', 'datetime')
				SET @datFieldSentDate = @LabSamples.value('(/LabSample/datFieldSentDate)[1]', 'datetime')
				SET @idfFieldCollectedByOffice = @LabSamples.value('(/LabSample/idfFieldCollectedByOffice)[1]', 'bigint')
				SET @idfFieldCollectedByPerson = @LabSamples.value('(/LabSample/idfFieldCollectedByPerson)[1]', 'bigint')
				SET @idfTesting = @LabSamples.value('(/LabSample/idfTesting)[1]', 'bigint')

				SET @datAccession = @LabSamples.value('(/LabSample/Accession/datAccession)[1]', 'datetime')
				SET @strCondition = @LabSamples.value('(/LabSample/Accession/strCondition)[1]', 'nvarchar(200)')
				SET @idfsAccessionCondition = @LabSamples.value('(/LabSample/Accession/idfsAccessionCondition)[1]', 'bigint')
				SET @strNoteAccession = @LabSamples.value('(/LabSample/Accession/strNote)[1]', 'nvarchar(200)')
				SET @idfSubdivision = @LabSamples.value('(/LabSample/Accession/idfSubdivision)[1]', 'bigint')
				SET @idfDepartment = @LabSamples.value('(/LabSample/Accession/idfDepartment)[1]', 'bigint')
				SET @idfAccesionByPerson = @LabSamples.value('(/LabSample/Accession/idfAccesionByPerson)[1]', 'bigint')

				exec spLabSample_Create
					 @idfMaterial
					,@strFieldBarcode
					,@idfsSpecimenType
					,@idfAnimal
					,@datFieldCollectionDate
					,@datFieldSentDate
					,@idfFieldCollectedByOffice
					,@idfFieldCollectedByPerson
					,@idfTesting


				If Not @datAccession Is Null
					Begin
						EXEC spSysGetNewID @idfContainer OUTPUT
						EXEC spGetNextNumber 10057020,@strBarcode output,0

						exec spLabSampleReceive_PostDetail
							 @idfContainer
							,@idfMaterial
							,@strBarcode
							,@datAccession
							,@strCondition
							,@idfsAccessionCondition
							,@strNoteAccession
							,@idfSubdivision
							,@idfDepartment
							,@idfAccesionByPerson


						Declare @LabTests xml
						DECLARE LabTests CURSOR FOR 
						SELECT T.c.query('.') AS result
						FROM   @LabSamples.nodes('/LabSample/Accession/LabTests/LabTest') T(c)

						OPEN LabTests
						FETCH NEXT FROM LabTests INTO @LabTests

						WHILE @@FETCH_STATUS = 0
						BEGIN

							DECLARE @idfLabTesting bigint
							DECLARE @idfLabMonitoringSession bigint
							DECLARE @idfsTestType bigint
							DECLARE @idfsTestForDiseaseType bigint
							DECLARE @idfsLabDiagnosis bigint

							EXEC spSysGetNewID @idfLabTesting OUTPUT
							SET @idfLabMonitoringSession = @LabTests.value('(/LabTest/idfMonitoringSession)[1]', 'bigint')
							SET @idfsTestType = @LabTests.value('(/LabTest/idfsTestType)[1]', 'bigint')
							SET @idfsTestForDiseaseType = @LabTests.value('(/LabTest/idfsTestForDiseaseType)[1]', 'bigint')
							SET @idfsLabDiagnosis = @LabTests.value('(/LabTest/idfsDiagnosis)[1]', 'bigint')

							exec spLabTest_Create
								 @idfLabTesting
								,@idfContainer
								,@idfCase
								,@idfLabMonitoringSession
								,@idfsTestType
								,@idfsTestForDiseaseType
								,@idfsLabDiagnosis

							FETCH NEXT FROM LabTests INTO @LabTests
						END

						CLOSE LabTests
						DEALLOCATE LabTests

					End


				Declare @PensideTests xml
				DECLARE PensideTests CURSOR FOR 
				SELECT T.c.query('.') AS result
				FROM   @LabSamples.nodes('/LabSample/PensideTests/PensideTest') T(c)

				OPEN PensideTests
				FETCH NEXT FROM PensideTests INTO @PensideTests

				WHILE @@FETCH_STATUS = 0
				BEGIN

					DECLARE @idfPensideTest bigint
					DECLARE @idfsPensideTestResult bigint
					DECLARE @idfsPensideTestType bigint

					EXEC spSysGetNewID @idfPensideTest OUTPUT
					SET @idfsPensideTestResult = @PensideTests.value('(/PensideTest/idfsPensideTestResult)[1]', 'bigint')
					SET @idfsPensideTestType = @PensideTests.value('(/PensideTest/idfsPensideTestType)[1]', 'bigint')

					exec spPensideTest_Post
						4 --@Action INT --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
						,@idfPensideTest --@idfPensideTest bigint --##PARAM @idfPensideTest - penside test record ID
						,@idfCase --@idfVetCase bigint --##PARAM @idfVetCase - ID of case to which vaccination belongs
						,@idfAnimal --@idfParty bigint --##PARAM @idfParty - ID of party to which test is applied (animal for livestock cases or species for avian cases)
						,@idfsPensideTestResult --@idfsPensideTestResult bigint --##PARAM @idfsPensideTestResult - penside test result, reference to rftPensideTestResult (19000105)
						,@idfsPensideTestType --@idfsPensideTestType bigint --##PARAM  @idfsPensideTestType -penside test type, reference to rftPensideTestType (19000104)
						,@idfMaterial --@idfMaterial bigint --##PARAM @idfMaterial - ID of sample to which test is applied

					FETCH NEXT FROM PensideTests INTO @PensideTests
				END

				CLOSE PensideTests
				DEALLOCATE PensideTests


				FETCH NEXT FROM LabSamples INTO @LabSamples
			END

			CLOSE LabSamples
			DEALLOCATE LabSamples

			FETCH NEXT FROM Animals INTO @Animals
		END

		CLOSE Animals
		DEALLOCATE Animals




		Declare @Vaccinations xml
		DECLARE Vaccinations CURSOR FOR 
		SELECT T.c.query('.') AS result
		FROM   @Species.nodes('/Species/Vaccinations/Vaccination') T(c)

		OPEN Vaccinations
		FETCH NEXT FROM Vaccinations INTO @Vaccinations

		WHILE @@FETCH_STATUS = 0
		BEGIN
			DECLARE @idfVaccination bigint
			DECLARE @idfsVaccinationType bigint
			DECLARE @idfsVaccinationRoute bigint
			DECLARE @idfsDiagnosis bigint
			DECLARE @datVaccinationDate datetime
			DECLARE @strManufacturer nvarchar(200)
			DECLARE @strLotNumber nvarchar(200)
			DECLARE @intNumberVaccinated int
			DECLARE @strNoteV nvarchar(200)

			exec spSysGetNewID @idfVaccination OUTPUT

			SET @idfsVaccinationType = @Vaccinations.value('(/Vaccination/idfsVaccinationType)[1]', 'bigint')
			SET @idfsVaccinationRoute = @Vaccinations.value('(/Vaccination/idfsVaccinationRoute)[1]', 'bigint')
			SET @idfsDiagnosis = @Vaccinations.value('(/Vaccination/idfsDiagnosis)[1]', 'bigint')
			SET @datVaccinationDate = @Vaccinations.value('(/Vaccination/datVaccinationDate)[1]', 'datetime')
			SET @strManufacturer = @Vaccinations.value('(/Vaccination/strManufacturer)[1]', 'nvarchar(200)')
			SET @strLotNumber = @Vaccinations.value('(/Vaccination/strLotNumber)[1]', 'nvarchar(200)')
			SET @intNumberVaccinated = @Vaccinations.value('(/Vaccination/intNumberVaccinated)[1]', 'int')
			SET @strNoteV = @Vaccinations.value('(/Vaccination/strNote)[1]', 'nvarchar(200)')

			EXEC spVaccination_Post
				 4 --@Action INT --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
				,@idfVaccination --@idfVaccination bigint --##PARAM @idfVaccination - vaccnation record ID
				,@idfCase --@idfVetCase bigint --##PARAM @idfVetCase - ID of case to which vaccination belongs
				,@idfSpecies --@idfSpecies bigint --##PARAM @idfSpecies - vaccinated species
				,@idfsVaccinationType --@idfsVaccinationType bigint --##PARAM @idfsVaccinationType - vaccination type, reference to rftVaccinationType (19000099)
				,@idfsVaccinationRoute --@idfsVaccinationRoute bigint --##PARAM  @idfsVaccinationRoute -vaccination route, reference to rftVaccinationRoute (19000098)
				,@idfsDiagnosis --@idfsDiagnosis bigint --##PARAM @idfsDiagnosis - vaccianation diagnosis
				,@datVaccinationDate --@datVaccinationDate datetime --##PARAM @datVaccinationDate - vaccination date
				,@strManufacturer --@strManufacturer nvarchar(200) --##PARAM @strManufacturer - manufacurer of vaccine
				,@strLotNumber --@strLotNumber nvarchar(200) --##PARAM @strLotNumber - vaccine lot number
				,@intNumberVaccinated --@intNumberVaccinated int --##PARAM @intNumberVaccinated - number of vaccinated animals
				,@strNoteV --@strNote nvarchar(2000) --##PARAM - @strNote - arbitrary text data related with vaccination


			FETCH NEXT FROM Vaccinations INTO @Vaccinations
		END

		CLOSE Vaccinations
		DEALLOCATE Vaccinations




		Declare @LabSamples1 xml
		DECLARE LabSamples1 CURSOR FOR 
		SELECT T.c.query('.') AS result
		FROM   @Species.nodes('/Species/LabSamples/LabSample') T(c)

		OPEN LabSamples1
		FETCH NEXT FROM LabSamples1 INTO @LabSamples1

		WHILE @@FETCH_STATUS = 0
		BEGIN

			DECLARE @idfMaterial1 bigint
			DECLARE @strFieldBarcode1 nvarchar(200)
			DECLARE @idfsSpecimenType1 bigint
			DECLARE @datFieldCollectionDate1 datetime
			DECLARE @datFieldSentDate1 datetime
			DECLARE @idfFieldCollectedByOffice1 bigint
			DECLARE @idfFieldCollectedByPerson1 bigint
			DECLARE @idfTesting1 bigint

			DECLARE @idfContainer1 bigint
			DECLARE @strBarcode1 nvarchar(200)
			DECLARE @datAccession1 datetime
			DECLARE @strCondition1 nvarchar(200)
			DECLARE @idfsAccessionCondition1 bigint
			DECLARE @strNoteAccession1 nvarchar(200)
			DECLARE @idfSubdivision1 bigint
			DECLARE @idfDepartment1 bigint
			DECLARE @idfAccesionByPerson1 bigint


			EXEC spSysGetNewID @idfMaterial1 OUTPUT
			SET @strFieldBarcode1 = @LabSamples1.value('(/LabSample/strFieldBarcode)[1]', 'nvarchar(200)')
			SET @idfsSpecimenType1 = @LabSamples1.value('(/LabSample/idfsSpecimenType)[1]', 'bigint')
			SET @datFieldCollectionDate1 = @LabSamples1.value('(/LabSample/datFieldCollectionDate)[1]', 'datetime')
			SET @datFieldSentDate1 = @LabSamples1.value('(/LabSample/datFieldSentDate)[1]', 'datetime')
			SET @idfFieldCollectedByOffice1 = @LabSamples1.value('(/LabSample/idfFieldCollectedByOffice)[1]', 'bigint')
			SET @idfFieldCollectedByPerson1 = @LabSamples1.value('(/LabSample/idfFieldCollectedByPerson)[1]', 'bigint')
			SET @idfTesting1 = @LabSamples1.value('(/LabSample/idfTesting)[1]', 'bigint')

			SET @datAccession1 = @LabSamples1.value('(/LabSample/Accession/datAccession)[1]', 'datetime')
			SET @strCondition1 = @LabSamples1.value('(/LabSample/Accession/strCondition)[1]', 'nvarchar(200)')
			SET @idfsAccessionCondition1 = @LabSamples1.value('(/LabSample/Accession/idfsAccessionCondition)[1]', 'bigint')
			SET @strNoteAccession1 = @LabSamples1.value('(/LabSample/Accession/strNote)[1]', 'nvarchar(200)')
			SET @idfSubdivision1 = @LabSamples1.value('(/LabSample/Accession/idfSubdivision)[1]', 'bigint')
			SET @idfDepartment1 = @LabSamples1.value('(/LabSample/Accession/idfDepartment)[1]', 'bigint')
			SET @idfAccesionByPerson1 = @LabSamples1.value('(/LabSample/Accession/idfAccesionByPerson)[1]', 'bigint')


			exec spLabSample_Create
				 @idfMaterial1
				,@strFieldBarcode1
				,@idfsSpecimenType1
				,@idfSpecies
				,@datFieldCollectionDate1
				,@datFieldSentDate1
				,@idfFieldCollectedByOffice1
				,@idfFieldCollectedByPerson1
				,@idfTesting1

			If Not @datAccession1 Is Null
				Begin
					EXEC spSysGetNewID @idfContainer1 OUTPUT
					EXEC spGetNextNumber 10057020,@strBarcode1 output,0
					exec spLabSampleReceive_PostDetail
						 @idfContainer1
						,@idfMaterial1
						,@strBarcode1
						,@datAccession1
						,@strCondition1
						,@idfsAccessionCondition1
						,@strNoteAccession1
						,@idfSubdivision1
						,@idfDepartment1
						,@idfAccesionByPerson1


					Declare @LabTests1 xml
					DECLARE LabTests1 CURSOR FOR 
					SELECT T.c.query('.') AS result
					FROM   @LabSamples1.nodes('/LabSample/Accession/LabTests/LabTest') T(c)

					OPEN LabTests1
					FETCH NEXT FROM LabTests1 INTO @LabTests1

					WHILE @@FETCH_STATUS = 0
					BEGIN

						DECLARE @idfLabTesting1 bigint
						DECLARE @idfLabMonitoringSession1 bigint
						DECLARE @idfsTestType1 bigint
						DECLARE @idfsTestForDiseaseType1 bigint
						DECLARE @idfsLabDiagnosis1 bigint

						EXEC spSysGetNewID @idfLabTesting1 OUTPUT
						SET @idfLabMonitoringSession1 = @LabTests1.value('(/LabTest/idfMonitoringSession)[1]', 'bigint')
						SET @idfsTestType1 = @LabTests1.value('(/LabTest/idfsTestType)[1]', 'bigint')
						SET @idfsTestForDiseaseType1 = @LabTests1.value('(/LabTest/idfsTestForDiseaseType)[1]', 'bigint')
						SET @idfsLabDiagnosis1 = @LabTests1.value('(/LabTest/idfsDiagnosis)[1]', 'bigint')

						exec spLabTest_Create
							 @idfLabTesting1
							,@idfContainer1
							,@idfCase
							,@idfLabMonitoringSession1
							,@idfsTestType1
							,@idfsTestForDiseaseType1
							,@idfsLabDiagnosis1

						FETCH NEXT FROM LabTests1 INTO @LabTests1
					END

					CLOSE LabTests1
					DEALLOCATE LabTests1
				End



			Declare @PensideTests1 xml
			DECLARE PensideTests1 CURSOR FOR 
			SELECT T.c.query('.') AS result
			FROM   @LabSamples1.nodes('/LabSample/PensideTests/PensideTest') T(c)

			OPEN PensideTests1
			FETCH NEXT FROM PensideTests1 INTO @PensideTests1

			WHILE @@FETCH_STATUS = 0
			BEGIN

				DECLARE @idfPensideTest1 bigint
				DECLARE @idfsPensideTestResult1 bigint
				DECLARE @idfsPensideTestType1 bigint

				EXEC spSysGetNewID @idfPensideTest1 OUTPUT
				SET @idfsPensideTestResult1 = @PensideTests1.value('(/PensideTest/idfsPensideTestResult)[1]', 'bigint')
				SET @idfsPensideTestType1 = @PensideTests1.value('(/PensideTest/idfsPensideTestType)[1]', 'bigint')

				exec spPensideTest_Post
					4 --@Action INT --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
					,@idfPensideTest1 --@idfPensideTest bigint --##PARAM @idfPensideTest - penside test record ID
					,@idfCase --@idfVetCase bigint --##PARAM @idfVetCase - ID of case to which vaccination belongs
					,@idfSpecies --@idfParty bigint --##PARAM @idfParty - ID of party to which test is applied (animal for livestock cases or species for avian cases)
					,@idfsPensideTestResult1 --@idfsPensideTestResult bigint --##PARAM @idfsPensideTestResult - penside test result, reference to rftPensideTestResult (19000105)
					,@idfsPensideTestType1 --@idfsPensideTestType bigint --##PARAM  @idfsPensideTestType -penside test type, reference to rftPensideTestType (19000104)
					,@idfMaterial1 --@idfMaterial bigint --##PARAM @idfMaterial - ID of sample to which test is applied

				FETCH NEXT FROM PensideTests1 INTO @PensideTests1
			END

			CLOSE PensideTests1
			DEALLOCATE PensideTests1



			FETCH NEXT FROM LabSamples1 INTO @LabSamples1
		END

		CLOSE LabSamples1
		DEALLOCATE LabSamples1



		FETCH NEXT FROM Species INTO @Species
	END

	CLOSE Species
	DEALLOCATE Species

	FETCH NEXT FROM Herds INTO @Herd
END

CLOSE Herds
DEALLOCATE Herds


If @IsLivestock = 1 
Begin
	DECLARE @idfsOwnershipStructure bigint
	DECLARE @idfsLivestockProductionType bigint
	DECLARE @idfsGrazingPattern bigint
	DECLARE @idfsMovementPattern bigint
	SET @idfsOwnershipStructure = @Farm.value('(/Farm/idfsOwnershipStructure)[1]', 'bigint')
	SET @idfsLivestockProductionType = @Farm.value('(/Farm/idfsLivestockProductionType)[1]', 'bigint')
	SET @idfsGrazingPattern = @Farm.value('(/Farm/idfsGrazingPattern)[1]', 'bigint')
	SET @idfsMovementPattern = @Farm.value('(/Farm/idfsMovementPattern)[1]', 'bigint')

	exec spLivestockFarmProduction_Post
		 @idfFarm
		,@idfRootFarm
		,@idfsOwnershipStructure
		,@idfsLivestockProductionType
		,@idfsGrazingPattern
		,@idfsMovementPattern
End
Else If @IsAvian = 1 
Begin
	DECLARE @idfsAvianFarmType bigint
	DECLARE @idfsAvianProductionType bigint
	DECLARE @idfsIntendedUse bigint
	DECLARE @intBuidings int
	DECLARE @intBirdsPerBuilding int
	SET @idfsAvianFarmType = @Farm.value('(/Farm/idfsAvianFarmType)[1]', 'bigint')
	SET @idfsAvianProductionType = @Farm.value('(/Farm/idfsAvianProductionType)[1]', 'bigint')
	SET @idfsIntendedUse = @Farm.value('(/Farm/idfsIntendedUse)[1]', 'bigint')
	SET @intBuidings = @Farm.value('(/Farm/intBuidings)[1]', 'int')
	SET @intBirdsPerBuilding = @Farm.value('(/Farm/intBirdsPerBuilding)[1]', 'int')

	exec spAvianFarmProduction_Post
		 @idfFarm
		,@idfRootFarm
		,@idfsAvianFarmType
		,@idfsAvianProductionType
		,@idfsIntendedUse

	exec spAvianFarmDetail_Post
		 @idfFarm
		,@intBuidings
		,@intBirdsPerBuilding


End

Declare @Logs xml
DECLARE Logs CURSOR FOR 
SELECT T.c.query('.') AS result
FROM   @VetCase.nodes('/VetCase/Logs/Log') T(c)

OPEN Logs
FETCH NEXT FROM Logs INTO @Logs

WHILE @@FETCH_STATUS = 0
BEGIN

	DECLARE @idfVetCaseLog bigint
	DECLARE @idfsCaseLogStatus bigint
	DECLARE @idfPerson bigint
	DECLARE @datCaseLogDate datetime
	DECLARE @strActionRequired nvarchar(200)
	DECLARE @strNoteL nvarchar(1000)

	exec spSysGetNewID @idfVetCaseLog OUTPUT
	SET @idfsCaseLogStatus = @Logs.value('(/Log/idfsCaseLogStatus)[1]', 'bigint')
	SET @idfPerson = @Logs.value('(/Log/idfPerson)[1]', 'bigint')
	SET @datCaseLogDate = @Logs.value('(/Log/datCaseLogDate)[1]', 'datetime')
	SET @strActionRequired = @Logs.value('(/Log/strActionRequired)[1]', 'nvarchar(200)')
	SET @strNoteL = @Logs.value('(/Log/strNote)[1]', 'nvarchar(1000)')

	exec spVetCaseLog_Post
		 4 --@Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
		,@idfVetCaseLog --@idfVetCaseLog bigint  --##PARAM @idfVetCaseLog - case log record ID
		,@idfsCaseLogStatus --@idfsCaseLogStatus bigint --##PARAM @idfsCaseLogStatus - status of case log action, reference to rftVetCaseLogStatus (19000103)
		,@idfCase --@idfVetCase bigint --##PARAM @idfVetCase - case ID
		,@idfPerson --@idfPerson bigint --##PARAM @idfPerson - ID of person that performed case log action
		,@datCaseLogDate --@datCaseLogDate datetime --##PARAM @datCaseLogDate - date of case log action
		,@strActionRequired --@strActionRequired nvarchar(200) --##PARAM @strActionRequired - short description of case log action
		,@strNoteL --@strNote nvarchar(1000) --##PARAM @strNote - expanded description of case log action

	FETCH NEXT FROM Logs INTO @Logs
END

CLOSE Logs
DEALLOCATE Logs


