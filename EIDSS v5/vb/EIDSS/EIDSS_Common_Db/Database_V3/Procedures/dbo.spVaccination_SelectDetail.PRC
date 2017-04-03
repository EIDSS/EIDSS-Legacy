SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spVaccination_SelectDetail') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spVaccination_SelectDetail
GO



--##SUMMARY Selects vaccination data related with specific case.
--##SUMMARY Called from VaccinationPanel.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
DECLARE @idfCase bigint

EXECUTE spVaccination_SelectDetail
  ,@idfCase
*/






CREATE              Proc	spVaccination_SelectDetail
		@idfCase	bigint  --##PARAM @idfCase - case ID
As

--0 Vaccination info
SELECT 
		idfVaccination
		,idfVetCase
		,idfSpecies
		,idfsVaccinationType
		,idfsVaccinationRoute
		,idfsDiagnosis
		,datVaccinationDate
		,strManufacturer
		,strLotNumber
		,intNumberVaccinated
		,strNote
  FROM tlbVaccination
WHERE
		idfVetCase = @idfCase
		and intRowStatus = 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

