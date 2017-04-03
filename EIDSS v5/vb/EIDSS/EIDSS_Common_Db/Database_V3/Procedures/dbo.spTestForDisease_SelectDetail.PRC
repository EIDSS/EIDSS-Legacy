SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spTestForDisease_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spTestForDisease_SelectDetail]
GO

--##SUMMARY Selects data for TestForDiseaseDetail form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 06.04.2010

--##RETURNS Doesn't use

/*
Example of procedure call:

EXECUTE spTestForDisease_SelectDetail

*/

CREATE  PROCEDURE dbo.spTestForDisease_SelectDetail
AS
--0 TestForDisease
SELECT 	idfTestForDisease,
	idfsTestType,
	idfsDiagnosis, 
	idfsTestForDiseaseType, 
	--idfsSpecimenType,
	intRecommendedQty
FROM dbo.trtTestForDisease
--inner join trtBaseReference as 	SampleType on
--	SampleType.idfsBaseReference = trtTestForDisease.idfsSpecimenType
--	and SampleType.intRowStatus = 0
--	and SampleType.idfsReferenceType = 19000087 --Sample Type
inner join trtBaseReference	as TestType on
	TestType.idfsBaseReference = trtTestForDisease.idfsTestType
	and TestType.intRowStatus = 0
	and TestType.idfsReferenceType = 19000097 --Test Type
WHERE   trtTestForDisease.intRowStatus = 0 
--1 master Diagnosis
SELECT 
	CAST (-1 as bigint) idfsDiagnosis





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

