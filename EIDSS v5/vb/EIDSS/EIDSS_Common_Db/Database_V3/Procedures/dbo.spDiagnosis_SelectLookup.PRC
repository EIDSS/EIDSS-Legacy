SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDiagnosis_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spDiagnosis_SelectLookup]
GO


--##SUMMARY Selects data for diagnosis lookup tables

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use

/*
--Example of procedure call:

exec  dbo.spDiagnosis_SelectLookup 'en', 32, 10020001 -- 'dutStandartCase'
*/


CREATE      procedure dbo.spDiagnosis_SelectLookup (
	@LanguageID as nvarchar(50), --##PARAM @LanguageID - language ID
	@HACode as int = null,  --##PARAM @HACode - bit mask that defines area where diagnosis are used (human, livestock or avian)
	@DiagnosisUsingType as bigint = NULL --##PARAM @DiagnosisUsingType - diagnosis type (standard or aggregate)
)
as
select	trtDiagnosis.idfsDiagnosis
		, fnReference.Name
		, trtDiagnosis.strIDC10
		, trtDiagnosis.strOIECode 
		, fnReference.intHACode
from	dbo.fnReference(@LanguageID, 19000019) --rftDiagnosis
inner join trtDiagnosis
	on trtDiagnosis.idfsDiagnosis = fnReference.idfsReference
where		(@HACode = 0 or @HACode is null or intHACode is null or 
			CASE 
						--1=animal, 32=livestock , 64=avian
						--below we assume that client will never pass animal bit without livstock or avian bits
						WHEN (intHACode & 97) > 1 THEN (~1 & intHACode) & @HACode -- if avian or livstock bits are set, clear animal bit in  b.intHA_Code
						WHEN (intHACode & 97) = 1 THEN (~1 & intHACode | 96) & @HACode --if only animal bit is set, clear clear animal bit and set both avian and livstock bits in  b.intHA_Code
						ELSE intHACode & @HACode  END >0)
			AND (@DiagnosisUsingType IS NULL OR trtDiagnosis.idfsDiagnosis IS NULL OR trtDiagnosis.idfsUsingType = @DiagnosisUsingType)
order by	fnReference.intOrder, fnReference.Name  

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

