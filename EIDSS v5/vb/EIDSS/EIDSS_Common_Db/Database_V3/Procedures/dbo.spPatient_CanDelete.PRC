SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPatient_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPatient_CanDelete]
GO

--##SUMMARY Checks if a human could be deleted.
--##SUMMARY This procedure is called before the deletion of the human. Human can only be deleted when the procedure allows it.
--##SUMMARY The human is allowed to delete, if he isn't a patient or contact person of any case, or a farm owner, and hasn't any specimens or copies.

--##REMARKS Author: Mirnaya O.
--##REMARKS 
--##REMARKS Update date: 22.01.2010

--##RETURNS Returns 0 if the human can not be deleted.
--##RETURNS Returns 1 if the human can be deleted.


/*
Example of a call of procedure:
declare @ID bigint
declare @Result bit
exec spPatient_CanDelete @ID, @Result output
print @Result
*/



create	procedure	spPatient_CanDelete
( 
	@ID as bigint,			--##PARAM  @ID - Human Id
	@Result as bit output	--##PARAM  @Result 0 if the human can not be deleted, 1 - otherwise
)
as
if	exists	(
		select		*
		from		tlbCase
		inner join	tlbParty
		on			tlbParty.idfCase = tlbCase.idfCase
					and tlbParty.idfParty = @ID
					and tlbParty.intRowStatus = 0
		where		tlbCase.intRowStatus = 0
			)
		or exists	(
			select		*
			from		tlbMaterial
			inner join	tlbParty
			on			tlbParty.idfParty = tlbMaterial.idfParty
						and tlbParty.idfParty = @ID
						and tlbParty.intRowStatus = 0
			where		tlbMaterial.intRowStatus = 0
					)
		or exists	(
			select		*
			from		tlbContactedCasePerson
			inner join	tlbParty
			on			tlbParty.idfParty = tlbContactedCasePerson.idfHuman
						and tlbParty.idfParty = @ID
						and tlbParty.intRowStatus = 0
			where		tlbContactedCasePerson.intRowStatus = 0
					)
		or exists	(
			select		*
			from		(
				tlbFarm
				inner join	tlbParty as tlbFarmParty
				on			tlbFarmParty.idfParty = tlbFarm.idfFarm
							and tlbFarmParty.intRowStatus = 0
						)
				inner join	tlbParty as tlbHumanParty
				on			tlbHumanParty.idfParty = tlbFarm.idfHuman
							and tlbHumanParty.idfParty = @ID
							and tlbHumanParty.intRowStatus = 0
					)
		or exists	(
			select		*
			from		tlbParty as tlbCopyParty
			inner join	tlbParty as tlbHumanParty
			on			tlbHumanParty.idfParty = tlbCopyParty.idfRootParty
						and tlbHumanParty.idfParty = @ID
						and tlbHumanParty.intRowStatus = 0
			where		tlbCopyParty.intRowStatus = 0
					)
	set @Result = 0
else
	set @Result = 1

return @Result




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

