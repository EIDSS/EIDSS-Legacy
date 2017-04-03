SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepUniOutbreakReport]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepUniOutbreakReport]

 
GO

--##SUMMARY Select data for Outbreak report report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 11.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec dbo.spRepUniOutbreakReport @LANGID=N'en',@OBJID=N'15110000241'


*/

CREATE  Procedure [dbo].[spRepUniOutbreakReport]
    (
        @LangID as nvarchar(10), 
        @ObjID	as bigint
    )
as

	select		tOutbreak.strOutbreakID				as OutbreakID,
				rfOutbreakStatus.[Name]				as OutbreakStatus,
				rfDiagnosis.[Name]					as Diagnosis,
				tCase.strCaseID						as CaseID,
				rfCaseType.[Name]					as ActType,
				tCase.datEnteredDate				as CaseDate,
				(
					case
						when (tHuman.idfCurrentResidenceAddress is not null) then dbo.fnAddressString(@LangID, tHuman.idfCurrentResidenceAddress)
						when (tFarm.idfFarmLocation is not null) then dbo.fnAddressString(@LangID, tFarm.idfFarmAddress)
					end
				)								 	as Location,
				rfCaseStatus.[Name]					as CaseStatus

	from		dbo.tlbOutbreak	as tOutbreak
	-- Get Case
	 left join	dbo.tlbCase					as tCase
			on	tCase.idfOutbreak = tOutbreak.idfOutbreak
	-- Get Human Case Location
	 left join	
			 ( 
						dbo.tlbHumanCase	as tHumanCase
			inner join	dbo.tlbParty		as tHumanParty
					on	tHumanCase.idfHumanCase = tHumanParty.idfCase
			inner join	dbo.tlbHuman		as tHuman
					on	tHumanParty.idfParty = tHuman.idfHuman
				   and  tHumanParty.intRowStatus = 0
			 )
			on	tCase.idfCase = tHumanCase.idfHumanCase

	-- Get Vet Case Location
	 left join	
			 ( 
						dbo.tlbVetCase	as tVetCase
			inner join	dbo.tlbParty		as tVetParty
					on	tVetCase.idfVetCase = tVetParty.idfCase
			inner join	dbo.tlbFarm		as tFarm
					on	tVetParty.idfParty = tFarm.idfFarm
				   and  tVetParty.intRowStatus = 0
			 )
			on	tCase.idfCase = tVetCase.idfVetCase
			
	-- Get Diagnosis
	 left join	fnReference(@LangID, 19000019 /*'rftDiagnosis' */)		as rfDiagnosis
			on	rfDiagnosis.idfsReference = tOutbreak.idfsDiagnosis
	-- Get Outbreak Status 
	 left join  fnReference(@LangID, 19000063 /*'rftOutbreakStatus'*/)	as rfOutbreakStatus
			on  rfOutbreakStatus.idfsReference = tOutbreak.idfsOutbreakStatus
	-- Get Case Status
	 left join  fnReference(@LangID, 19000011 /*'rftCaseStatus'*/)		as rfCaseStatus
			on  rfCaseStatus.idfsReference = tCase.idfsCaseStatus
	-- Get Case Type
	 left join  fnReference(@LangID, 19000012 /*'rftCaseType' */)		as rfCaseType
			on  rfCaseType.idfsReference = tCase.idfsCaseType

	-- Filter Condition
		 where	tOutbreak.idfOutbreak = @ObjID
		   and	tOutbreak.intRowStatus = 0

			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

