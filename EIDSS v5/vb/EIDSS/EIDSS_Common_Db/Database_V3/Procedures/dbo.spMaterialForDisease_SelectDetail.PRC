SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spMaterialForDisease_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spMaterialForDisease_SelectDetail]
GO

--##SUMMARY Selects data for disease -> material matrix (Material_For_DiseaseDetail form)

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 24.11.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
EXECUTE spMaterialForDisease_SelectDetail
*/


CREATE   PROCEDURE dbo.spMaterialForDisease_SelectDetail
AS

SELECT 	trtMaterialForDisease.idfMaterialForDisease,
	trtMaterialForDisease.idfsSpecimenType,
	trtMaterialForDisease.idfsDiagnosis, 
	trtMaterialForDisease.intRecommendedQty
FROM trtMaterialForDisease
inner join trtDiagnosis	on
	trtDiagnosis.idfsDiagnosis = trtMaterialForDisease.idfsDiagnosis
	and trtDiagnosis.intRowStatus = 0
inner join trtBaseReference	on
	trtBaseReference.idfsBaseReference = trtMaterialForDisease.idfsSpecimenType
	and trtBaseReference.intRowStatus = 0
	and trtBaseReference.idfsReferenceType = 19000087 --Sample Type
WHERE   trtMaterialForDisease.intRowStatus = 0 


--1 master Diagnosis
SELECT 
	CAST (-1 as bigint) idfsDiagnosis





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

