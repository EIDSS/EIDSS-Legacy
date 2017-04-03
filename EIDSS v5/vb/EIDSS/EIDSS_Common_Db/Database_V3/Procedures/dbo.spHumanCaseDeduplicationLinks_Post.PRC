SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spHumanCaseDeduplicationLinks_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spHumanCaseDeduplicationLinks_Post]
GO

--##SUMMARY Replace required links from superseded case to survivor case for de-duplication.

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 18.08.2010

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
declare	@SurvivorID			bigint
declare	@SupersededID		bigint
declare	@SurvivorPartyID	bigint
declare	@SupersededPartyID	bigint


exec spHumanCaseDeduplicationLinks_Post 
	 @SurvivorID		
	,@SupersededID		
	,@SurvivorPartyID	
	,@SupersededPartyID	

*/


create	procedure	spHumanCaseDeduplicationLinks_Post
(	
	 @SurvivorID		bigint	--##PARAM @SurvivorID Id of the survivor case
	,@SupersededID		bigint	--##PARAM @SupersededID Id of the superseded case
	,@SurvivorPartyID	bigint	--##PARAM @SurvivorPartyID Id of the survivor patient
	,@SupersededPartyID	bigint	--##PARAM @SupersededPartyID Id of the superseded patient
)
as

if	exists	(
		select		*
		from		tlbHumanCase
		inner join	tlbCase
		on			tlbCase.idfCase = tlbHumanCase.idfHumanCase
					and tlbCase.intRowStatus = 0
		inner join	(
			tlbParty
			inner join	tlbHuman
			on			tlbHuman.idfHuman = tlbParty.idfParty
					)
		on			tlbParty.idfCase = tlbHumanCase.idfHumanCase
					and tlbParty.idfsPartyType = 10072006	-- Human
					and tlbParty.intRowStatus = 0
		where		(	tlbHumanCase.idfHumanCase = @SupersededID
						and tlbParty.idfParty = @SupersededPartyID
					)
			)
	and exists	(
			select		*
			from		tlbHumanCase
			inner join	tlbCase
			on			tlbCase.idfCase = tlbHumanCase.idfHumanCase
						and tlbCase.intRowStatus = 0
			inner join	(
				tlbParty
				inner join	tlbHuman
				on			tlbHuman.idfHuman = tlbParty.idfParty
						)
			on			tlbParty.idfCase = tlbHumanCase.idfHumanCase
						and tlbParty.idfsPartyType = 10072006	-- Human
						and tlbParty.intRowStatus = 0
			where		(	tlbHumanCase.idfHumanCase = @SupersededID
							and tlbParty.idfParty = @SupersededPartyID
						)
				)
begin
	-- Updates links to outbreak for survivor case if it is not included in any another outbreak
	update		hc_survivor
	set			hc_survivor.idfsYNRelatedToOutbreak = 10100001	-- Yes
	from		(
		tlbCase c_survivor
		inner join	tlbHumanCase hc_survivor
		on			hc_survivor.idfHumanCase = c_survivor.idfCase
		left join	tlbOutbreak o_survivor
		on			o_survivor.idfOutbreak = c_survivor.idfOutbreak
					and o_survivor.intRowStatus = 0
				)
	inner join	(
		tlbCase c_superseded
		inner join	tlbOutbreak o_superseded
		on			o_superseded.idfOutbreak = c_superseded.idfOutbreak
					and o_superseded.intRowStatus = 0
				)
	on			c_superseded.idfCase = @SupersededID
	where		c_survivor.idfCase = @SurvivorID
				and o_survivor.idfOutbreak is null


	update		c_survivor
	set			c_survivor.idfOutbreak = o_superseded.idfOutbreak
	from		(
		tlbCase c_survivor
		left join	tlbOutbreak o_survivor
		on			o_survivor.idfOutbreak = c_survivor.idfOutbreak
					and o_survivor.intRowStatus = 0
				)
	inner join	(
		tlbCase c_superseded
		inner join	tlbOutbreak o_superseded
		on			o_superseded.idfOutbreak = c_superseded.idfOutbreak
					and o_superseded.intRowStatus = 0
				)
	on			c_superseded.idfCase = @SupersededID
	where		c_survivor.idfCase = @SurvivorID
				and o_survivor.idfOutbreak is null


	-- Updates links from contacts of superseded case to survivor case 
	-- if it doesn't include copies of corresponding root parties as patient or contacts
	update		ccp_superseded
	set			ccp_superseded.idfHumanCase = @SurvivorID
	from		tlbContactedCasePerson ccp_superseded
	inner join	tlbParty p_ccp_superseded
	on			p_ccp_superseded.idfParty = ccp_superseded.idfHuman
				and p_ccp_superseded.intRowStatus = 0
	left join	(
		tlbParty p_survivor
		inner join	tlbHuman h_survivor
		on			h_survivor.idfHuman = p_survivor.idfParty			
				)
	on			p_survivor.idfCase = @SurvivorID
				and p_survivor.idfRootParty = p_ccp_superseded.idfRootParty
				and p_survivor.idfsPartyType = 10072006	-- Human
				and p_survivor.intRowStatus = 0
	left join	(
		tlbContactedCasePerson ccp_survivor
		inner join	tlbParty p_cpp_survivor
		on		p_cpp_survivor.idfParty = ccp_survivor.idfHuman
				and p_cpp_survivor.intRowStatus = 0
				)
	on			ccp_survivor.intRowStatus = 0
				and ccp_survivor.idfHumanCase = @SurvivorID
				and p_cpp_survivor.idfRootParty = p_ccp_superseded.idfRootParty
	where		ccp_superseded.intRowStatus = 0
				and ccp_superseded.idfHumanCase = @SupersededID
				and p_survivor.idfParty is null
				and ccp_survivor.idfContactedCasePerson is null

	-- Mark superseded case as de-duplicated with survivor case
	update		hc
	set			hc.idfDeduplicationResultCase = @SurvivorID
	from		tlbHumanCase hc
	where		hc.idfHumanCase = @SupersededID
end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

