SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDiagnosisReference_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spDiagnosisReference_SelectDetail]
GO

--##SUMMARY Selects data for DiagnosisReferenceDetail form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 4.12.2009

--##RETURNS Doesn't use

/*
Example of procedure call:

EXEC spDiagnosisReference_SelectDetail 'en'

*/


CREATE     PROCEDURE [dbo].[spDiagnosisReference_SelectDetail] 
	@LangID  nvarchar(50) --##PARAM @LangID - language ID
AS
-- 0 BaseReference

SELECT	fnReference.idfsReference AS idfsBaseReference, 
		fnReference.[Name],
		fnReference.strDefault,
		fnReference.intHACode,
		fnReference.intOrder,
		trtDiagnosis.strIDC10, 
		trtDiagnosis.strOIECode,
		trtDiagnosis.idfsUsingType
FROM	fnReference(@LangID, 19000019/*Diagnosis*/)
INNER JOIN trtDiagnosis ON 
		fnReference.idfsReference = trtDiagnosis.idfsDiagnosis
WHERE	trtDiagnosis.intRowStatus = 0 
ORDER BY 
		fnReference.strDefault 

--1 - HACodesList
EXEC spHACode_SelectCheckList @LangID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

