SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spOutbreak_PopulateCaseInfo') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spOutbreak_PopulateCaseInfo
GO


--##SUMMARY Selects outbreak data for OutbreakDetail form.
--##SUMMARY Called by OutbreakDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 25.11.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:

DECLARE @OutbreakID bigint
DECLARE @LangID nvarchar(50)


EXECUTE spOutbreak_PopulateCaseInfo
   750650000000
  ,'en'

*/


CREATE     PROCEDURE dbo.spOutbreak_PopulateCaseInfo
	@CaseID AS bigint,  --##PARAM @CaseID - case ID
	@LangID NVARCHAR(50)  --##PARAM @LangID - lanquage ID
as

DECLARE @CaseType AS BIGINT
SELECT		@CaseType = idfsCaseType
FROM		tlbCase
WHERE		idfCase = @CaseID
			and intRowStatus = 0

IF @CaseType IS NULL
	RETURN 1

IF @CaseType = 10012001 --human case
BEGIN
	select		CaseStatus.Name as strCaseStatus, 
				convert(int, case when CaseStatus.idfsReference = 350000000 then 1 else 0 end) as Confirmed,
				Diagnosis.Name as strDiagnosis, 
				isnull(tlbHumanCase.datOnSetDate, 
				isnull(
					(
						select max(datChangedDate) from tlbChangeDiagnosisHistory
						where tlbChangeDiagnosisHistory.idfHumanCase = tlbHumanCase.idfHumanCase
					),
				isnull(tlbHumanCase.datFinalDiagnosisDate,
				isnull(tlbHumanCase.datNotificationDate, 
				tlbCase.datEnteredDate)))) as datEnteredDate,
				dbo.fnGeoLocationString(@LangID,tlbHumanCase.idfPointGeoLocation,null) As strGeoLocation,
				dbo.fnAddressString(@LangID,tlbHuman.idfCurrentResidenceAddress) As strAddress 
	from		tlbCase
	inner join  tlbHumanCase on 
		tlbHumanCase.idfHumanCase = tlbCase.idfCase
	inner join		(
		tlbParty
		inner join	tlbHuman
		on			tlbHuman.idfHuman = tlbParty.idfParty
					)
	on				tlbParty.idfCase = tlbHumanCase.idfHumanCase
					and tlbParty.idfsPartyType = 10072006				-- Human
					and tlbParty.intRowStatus = 0
	left join	dbo.fnReference(@LangID,19000019) as Diagnosis --'rftDiagnosis'
	on			tlbCase.idfsShowDiagnosis = Diagnosis.idfsReference
	left join	dbo.fnReference(@LangID,19000011) as CaseStatus --'rftCaseStatus'
	on			tlbCase.idfsCaseStatus = CaseStatus.idfsReference
	where tlbCase.idfCase = @CaseID
END
ELSE --vet case
BEGIN
	select		
				CaseStatus.Name as strCaseStatus, 
				convert(int, case when CaseStatus.idfsReference = 350000000 then 1 else 0 end) as Confirmed,
				Diagnosis.Name as strDiagnosis, 

				isnull(tlbVetCase.datInvestigationDate, 
				isnull(
					(
						select max(s1.dat) from 
						(
							select tlbVetCase1.datTentativeDiagnosisDate as dat
							from tlbVetCase as tlbVetCase1 where tlbVetCase1.idfVetCase = tlbVetCase.idfVetCase
							union		All
							select tlbVetCase1.datTentativeDiagnosis1Date as dat
							from tlbVetCase as tlbVetCase1 where tlbVetCase1.idfVetCase = tlbVetCase.idfVetCase
							union		All
							select tlbVetCase1.datTentativeDiagnosis2Date as dat
							from tlbVetCase as tlbVetCase1 where tlbVetCase1.idfVetCase = tlbVetCase.idfVetCase
							union		All
							select tlbVetCase1.datFinalDiagnosisDate as dat
							from tlbVetCase as tlbVetCase1 where tlbVetCase1.idfVetCase = tlbVetCase.idfVetCase
						) s1
					),
				isnull(tlbVetCase.datReportDate,
				tlbCase.datEnteredDate))) as datEnteredDate,

				dbo.fnGeoLocationString(@LangID,tlbFarm.idfFarmLocation,null) As strGeoLocation,
				dbo.fnAddressString(@LangID,tlbFarm.idfFarmAddress) As strAddress  

	from		tlbCase
	inner join  tlbVetCase on 
		tlbVetCase.idfVetCase = tlbCase.idfCase
	left join	dbo.fnReference(@LangID,19000019) as Diagnosis --'rftDiagnosis'
	on			tlbCase.idfsShowDiagnosis = Diagnosis.idfsReference
	left join	dbo.fnReference(@LangID,19000011) as CaseStatus --'rftCaseStatus'
	on			tlbCase.idfsCaseStatus = CaseStatus.idfsReference
	left join(
			tlbParty
			inner join	tlbFarm
			on			tlbFarm.idfFarm = tlbParty.idfParty
		)	on			tlbCase.idfCase = tlbParty.idfCase
	where tlbCase.idfCase = @CaseID
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

