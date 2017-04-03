SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetVaccination]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetVaccination]


GO

--##SUMMARY Select data for Vet Vaccinatoion report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 22.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepVetVaccination 'en', 7110000002

*/

CREATE  Procedure [dbo].[spRepVetVaccination]
    (
        @LangID as nvarchar(10),
        @ObjID	as bigint
    )
as

	select  	
				rfDiagnosis.[Name]			as Diagnosis,
				tVaccination.datVaccinationDate, 
				rfType.[Name]				as strType, 
				rfRoute.[Name]				as strRouteAdministered
	
		from		dbo.tlbCase		as tCase
	-- get vet case
	inner join	dbo.tlbVetCase		as tVetCase
			on	tCase.idfCase = tVetCase.idfVetCase
		   and  tCase.intRowStatus = 0
	inner join	dbo.tlbVaccination	as tVaccination
			on	tVetCase.idfVetCase = tVaccination.idfVetCase
		   and  tVaccination.intRowStatus = 0
		-- Get Diagnosis
	 left join	fnReference(@LangID, 19000019 /*'rftDiagnosis' */)	as rfDiagnosis
			on	rfDiagnosis.idfsReference = tVaccination.idfsDiagnosis
		-- Get Type
	 left join	fnReference(@LangID, 19000099 /*'rftVaccinationType' */)	as rfType
			on	rfType.idfsReference = tVaccination.idfsVaccinationType
		-- Get Route
	 left join	fnReference(@LangID, 19000098 /*'rftVaccinationRoute' */)	as rfRoute
			on	rfRoute.idfsReference = tVaccination.idfsVaccinationRoute
		 
		 where	tCase.idfCase = @ObjID
		 
		

			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

