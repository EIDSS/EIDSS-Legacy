SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spVetCase_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spVetCase_Delete]
GO







--##SUMMARY Deletes vet case object.
--##SUMMARY Can be called from VetCaseList/LivestockCaseDetail/AvianCaseDetail forms. In this case spVetCase_CanDelete
--##SUMMARY procedure should enable case deleting only if there is test/specimens related with case, case farm has no herds/animals
--##SUMMARY , and also no vaccinations and case log records exists.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 4.12.2009

--##RETURNS Doesn't use



/*
Example of procedure call:

DECLARE @ID bigint
EXEC spVetCase_Delete @ID

*/




CREATE         Proc spVetCase_Delete
		@ID bigint --##PARAM  @ID - Vet case ID
As
--TODO: Delete samples, tests here?

DECLARE @FarmID BIGINT

SELECT	@FarmID = idfParty 
FROM	tlbParty
WHERE 
		idfCase=@ID AND idfsPartyType = 10072005 --Farm

EXEC spFarm_Delete @FarmID


DELETE tlbVetCaseLog WHERE idfVetCase = @ID
DELETE tlbVaccination WHERE idfVetCase = @ID
DELETE tlbPensideTest WHERE idfVetCase = @ID
DELETE tlbVetCase WHERE idfVetCase = @ID
DELETE tlbCase WHERE idfCase = @ID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

