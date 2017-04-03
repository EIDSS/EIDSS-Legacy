SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPensideTests_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPensideTests_SelectDetail]
GO

--##SUMMARY Selects list of penside tests related with specific case.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 22.11.2009

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
DECLARE @ID BIGINT 
SET @ID = 70550000000
exec spPensideTests_SelectDetail 
	@ID,
	'en'
*/

CREATE       PROCEDURE dbo.spPensideTests_SelectDetail
	@idfCase AS BIGINT --##PARAM @idfCase - case ID for wich the penside tests are selected
	,@LangID AS NVARCHAR(50) --##PARAM @LangID - language ID
AS

SELECT idfPensideTest
      ,idfVetCase
      ,tlbPensideTest.idfParty
      --,idfSpecies
      ,tlbPensideTest.idfMaterial
      --,idfsSpecimenType
	  ,idfsPensideTestResult
      ,idfsPensideTestType
      --,strFieldSampleID
	  ,dbo.fnReference.Name AS strSpecimenName	
  FROM tlbPensideTest
INNER JOIN tlbMaterial ON
	tlbMaterial.idfMaterial = tlbPensideTest.idfMaterial
	AND tlbMaterial.intRowStatus = 0
INNER JOIN dbo.fnReference(@LangID,19000087/*rftSpecimenType*/) ON
	dbo.fnReference.idfsReference = tlbMaterial.idfsSpecimenType
WHERE
	tlbPensideTest.idfVetCase = @idfCase
	and tlbPensideTest.intRowStatus = 0



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

