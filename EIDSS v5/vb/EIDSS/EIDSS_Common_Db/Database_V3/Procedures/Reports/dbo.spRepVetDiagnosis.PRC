SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetDiagnosis]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetDiagnosis]


GO

--##SUMMARY Select data for Diagnosis details for Vet report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 22.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepVetDiagnosis 139040000000 , 'en' 

*/ 

CREATE  Procedure [dbo].[spRepVetDiagnosis]
    (
        @ObjID	as bigint,
        @LangID as nvarchar(10)
    )
as

	select		rfDiagnosis0.[Name]		as strTentativeDiagnosis,
				rfDiagnosis1.[Name]		as strTentativeDiagnosis1,
				rfDiagnosis2.[Name]		as strTentativeDiagnosis2,
				rfDiagnosisf.[Name]		as strFinalDiagnosis
	
	from		dbo.tlbCase		as tCase
	-- get vet case
	inner join	dbo.tlbVetCase	as tVetCase
			on	tCase.idfCase = tVetCase.idfVetCase
		   and  tCase.intRowStatus = 0
	-- Get Diagnosis
	 left join	fnReference(@LangID, 19000019 /*'rftDiagnosis' */)		as rfDiagnosis0
			on	rfDiagnosis0.idfsReference = tVetCase.idfsTentativeDiagnosis
	 left join	fnReference(@LangID, 19000019 /*'rftDiagnosis' */)		as rfDiagnosis1
			on	rfDiagnosis1.idfsReference = tVetCase.idfsTentativeDiagnosis1	
	 left join	fnReference(@LangID, 19000019 /*'rftDiagnosis' */)		as rfDiagnosis2
			on	rfDiagnosis2.idfsReference = tVetCase.idfsTentativeDiagnosis2
	 left join	fnReference(@LangID, 19000019 /*'rftDiagnosis' */)		as rfDiagnosisf
			on	rfDiagnosisf.idfsReference = tVetCase.idfsFinalDiagnosis
		 where  tCase.idfCase = @ObjID
			
			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

