SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spChangeDiagnosisHistory_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spChangeDiagnosisHistory_SelectDetail]
GO

--##SUMMARY Selects history of diagnosis changes for a specified human case.

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 19.08.2010

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
declare	@idfCase	bigint
declare	@LangID		nvarchar(50)

execute	spChangeDiagnosisHistory_SelectDetail
	 @idfCase
	,@LangID
*/



create procedure	spChangeDiagnosisHistory_SelectDetail
(	 @idfCase	bigint			--##PARAM @idfCase Case Id
	,@LangID	nvarchar(50)	--##PARAM @LangID Language Id	
)
as

-- 0 tlbChangeDiagnosisHistory
select		tlbChangeDiagnosisHistory.idfChangeDiagnosisHistory,
			tlbChangeDiagnosisHistory.idfHumanCase,
			tlbChangeDiagnosisHistory.idfUserID,
			tlbChangeDiagnosisHistory.idfsPreviousDiagnosis,
			tlbChangeDiagnosisHistory.idfsCurrentDiagnosis,
			tlbChangeDiagnosisHistory.datChangedDate,
			tlbChangeDiagnosisHistory.strReason,
			tstUserTable.idfPerson,
			IsNull(tlbPerson.strFamilyName, N'') + 
			IsNull(N' ' + tlbPerson.strFirstName, N'') +
			IsNull(N' ' + tlbPerson.strSecondName, N'') as PersonName,
			Institution.[Abbreviation] as Organization,
			PreviousDiagnosis.[Name] as PreviousDiagnosisName,
			CurrentDiagnosis.[Name] as CurrentDiagnosisName
from		tlbChangeDiagnosisHistory
inner join	tlbCase
on			tlbCase.idfCase = tlbChangeDiagnosisHistory.idfHumanCase
			and tlbCase.intRowStatus = 0
inner join	tstUserTable
on			tstUserTable.idfUserID = tlbChangeDiagnosisHistory.idfUserID
			and tstUserTable.intRowStatus = 0
left join	fnReference(@LangID, 19000019) PreviousDiagnosis	-- rftDiagnosis
on			PreviousDiagnosis.idfsReference = tlbChangeDiagnosisHistory.idfsPreviousDiagnosis
left join	fnReference(@LangID, 19000019) CurrentDiagnosis		-- rftDiagnosis
on			CurrentDiagnosis.idfsReference = tlbChangeDiagnosisHistory.idfsCurrentDiagnosis
left join	(
	tlbPerson
	inner join	tlbEmployee
	on			tlbEmployee.idfEmployee = tlbPerson.idfPerson
				and tlbEmployee.intRowStatus = 0
	left join	dbo.fnInstitution(@LangID) Institution
	on			Institution.idfOffice = tlbPerson.idfInstitution
			)
on			tlbPerson.idfPerson = tstUserTable.idfPerson
where		tlbChangeDiagnosisHistory.idfHumanCase = @idfCase
			and tlbChangeDiagnosisHistory.intRowStatus = 0


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

