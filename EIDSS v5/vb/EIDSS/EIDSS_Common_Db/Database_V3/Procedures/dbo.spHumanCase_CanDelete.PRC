SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spHumanCase_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spHumanCase_CanDelete]
GO

--##SUMMARY Checks if a human case could be deleted.
--##SUMMARY This procedure is called before the deletion of the case. Case can only be deleted when the procedure allows it.
--##SUMMARY The case is allowed to delete, if it has In Progress status and does not contain any of the materials or tests, and is not included in the outbreak.

--##REMARKS Author: Mirnaya O.
--##REMARKS 
--##REMARKS Update date: 28.12.2009

--##RETURNS Returns 0 if the case can not be deleted.
--##RETURNS Returns 1 if the case can be deleted.


/*
Example of a call of procedure:
declare @ID bigint
declare @Result bit
exec spHumanCase_CanDelete @ID, @Result output
print @Result
*/



create	procedure	spHumanCase_CanDelete
( 
	@ID as bigint,--##PARAM  @ID - Human case ID
	@Result as bit output --##PARAM  @Result 0 if the case can not be deleted, 1 - otherwise
)
as
if	exists	(
		select		*
		from		tlbParty
		inner join	tlbMaterial
		on			tlbMaterial.idfParty = tlbParty.idfParty
					and tlbMaterial.intRowStatus = 0
		where		tlbParty.intRowStatus = 0
					and tlbParty.idfCase = @ID
			)
		or exists	(
		select		*
		from		tlbCase
		inner join	tlbTesting
		on			tlbTesting.idfCase = tlbCase.idfCase
					and tlbTesting.intRowStatus = 0
		where		tlbCase.idfCase = @ID
					)
		or exists	(
		select		*
		from		tlbOutbreak
		inner join	tlbCase
		on			tlbCase.idfOutbreak = tlbOutbreak.idfOutbreak
					and tlbCase.idfCase = @ID
		where		tlbOutbreak.intRowStatus = 0
					)
		or exists	(
		select		*
		from		tlbCase
		where		tlbCase.idfsCaseProgressStatus = 10109002	-- Closed
					and tlbCase.idfCase = @ID
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

