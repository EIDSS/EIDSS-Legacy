SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spVetCase_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spVetCase_CanDelete]
GO

--##SUMMARY Checks if vet case can be deleted.
--##SUMMARY This procedure is called before case deleting. Case is deleted only if procedure enables this.
--##SUMMARY Now we consider that case can be deleted only if it contains no important information:
--##SUMMARY  - Case farm contains no species/animal (and thus no specimens too)
--##SUMMARY  - Case has no attached tests 
--##SUMMARY  - Case has no vaccination records
--##SUMMARY  - Case has no case log records
--##SUMMARY  - No outbreaks refer this case
--##SUMMARY  - There is no control measures records related with case

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 4.12.2009

--##RETURNS 0 if case can't be deleted 
--##RETURNS 1 if case can be deleted 
		


/*
Example of procedure call:

DECLARE @ID bigint
DECLARE @Result bit
EXEC spVetCase_CanDelete @ID, @Result OUTPUT
Print @Result

*/




CREATE            PROCEDURE dbo.spVetCase_CanDelete( 
	@ID AS BIGINT,--##PARAM  @ID - Vet case ID
	@Result AS BIT OUTPUT --##PARAM  @Result - 0 if case can't be deleted, 1 in other case
)
as


if (exists	(
	SELECT		*
	FROM		tlbParty
	INNER JOIN	tlbSpecies ON
				tlbParty.idfParty = tlbSpecies.idfSpecies
	WHERE		idfCase = @ID 
				AND tlbParty.idfsPartyType = 10072004/*Species*/ 
				AND tlbParty.intRowStatus=0  
				AND tlbSpecies.idfsSpeciesType <> 947220000000/*Undefined*/
			)
	OR
	exists	(
		select		*
		from		tlbPensideTest
		where		idfVetCase = @ID and intRowStatus=0
			)
	OR
	exists	(
		select		*
		from		tlbVaccination
		where		idfVetCase = @ID and intRowStatus=0
			)
	OR
	exists	(
		select		*
		from		tlbVetCaseLog
		where		idfVetCase = @ID and intRowStatus=0
			)
	OR
	exists	(
		select		*
		from		tlbTesting
		where		idfCase = @ID and intRowStatus=0
			)
	OR
	exists	(
		select		*
		from		tlbCase
		inner join	tlbOutbreak ON
					tlbOutbreak.idfOutbreak = tlbCase.idfOutbreak
					and tlbOutbreak.intRowStatus = 0
		where		idfCase = @ID and tlbCase.intRowStatus=0
			)
	OR
	exists	(
		select		*
		from		dbo.tlbActivityParameters
		INNER JOIN tlbVetCase ON
			tlbVetCase.idfObservation = tlbActivityParameters.idfObservation
		where	idfVetCase = @ID and tlbActivityParameters.intRowStatus=0 and (varValue IS NOT NULL OR CAST(varValue AS NVARCHAR) <> N'')
			)
)
		
	set @Result=0

else
	set @Result=1

return @Result




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

