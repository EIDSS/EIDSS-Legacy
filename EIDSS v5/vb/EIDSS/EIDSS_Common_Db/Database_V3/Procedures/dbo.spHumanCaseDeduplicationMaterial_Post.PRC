SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spHumanCaseDeduplicationMaterial_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spHumanCaseDeduplicationMaterial_Post]
GO

--##SUMMARY Saves links from selected samples to survivor de-duplicated case 
--##SUMMARY and deletes other samples related to cases-candidates for de-duplication.

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 18.08.2010

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
declare	@SurvivorID			bigint
declare	@SupersededID		bigint
declare	@SurvivorPartyID	bigint
declare	@SupersededPartyID	bigint
declare	@MaterialID			bigint
declare	@AddToSurvivorCase	bit


exec spHumanCaseDeduplicationMaterial_Post 
	 @SurvivorID		
	,@SupersededID		
	,@SurvivorPartyID	
	,@SupersededPartyID	
	,@MaterialID		
	,@AddToSurvivorCase	

*/


create	procedure	spHumanCaseDeduplicationMaterial_Post
(	
	 @SurvivorID		bigint	--##PARAM @SurvivorID Id of the survivor case
	,@SupersededID		bigint	--##PARAM @SupersededID Id of the superseded case
	,@SurvivorPartyID	bigint	--##PARAM @SurvivorPartyID Id of the survivor patient
	,@SupersededPartyID	bigint	--##PARAM @SupersededPartyID Id of the superseded patient
	,@MaterialID		bigint	--##PARAM @MaterialID Sample Id
	,@AddToSurvivorCase	bit		--##PARAM @AddToSurvivorCase Flag that determines whether to update or delete sample
)
as

if	exists	(
		select		*
		from		tlbMaterial
		inner join	tlbParty
		on			tlbParty.idfParty = tlbMaterial.idfParty
					and tlbParty.intRowStatus = 0
		where		tlbMaterial.intRowStatus = 0
					and	tlbMaterial.idfMaterial = @MaterialID
					and (	(	tlbParty.idfCase = @SurvivorID 
								and tlbParty.idfParty = @SurvivorPartyID)
							or (	tlbParty.idfCase = @SupersededID 
									and tlbParty.idfParty = @SupersededPartyID)
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
	and (@AddToSurvivorCase is not null)
begin
	if (@AddToSurvivorCase = 0)
	begin
		-- Delete samples and test that user didn't select

		-- Select a list of samples for deletion
		declare	@tlbMaterial_del	table (idfMaterial bigint not null primary key)

		insert into	@tlbMaterial_del	(idfMaterial)
		values	(@MaterialID)

		-- Select child samples for deletion 
		declare	@GoOn		int
		set @GoOn = 1
		declare	@RootGoOn	int
		set	@RootGoOn = 0

		while	@GoOn > 0
		begin
			insert into	@tlbMaterial_del	(idfMaterial)
			select distinct
						tlbMaterial.idfMaterial
			from		tlbMaterial
			inner join	@tlbMaterial_del tlbMaterial_del
			on			tlbMaterial_del.idfMaterial = tlbMaterial.idfRootParentMaterial
			left join	@tlbMaterial_del tlbMaterial_del_ex
			on			tlbMaterial_del_ex.idfMaterial = tlbMaterial.idfMaterial
			where		tlbMaterial_del_ex.idfMaterial is null

			set	@RootGoOn = @@rowcount

			insert into	@tlbMaterial_del	(idfMaterial)
			select distinct
						tlbMaterial.idfMaterial
			from		tlbMaterial
			inner join	@tlbMaterial_del tlbMaterial_del
			on			tlbMaterial_del.idfMaterial = tlbMaterial.idfParentMaterial
			left join	@tlbMaterial_del tlbMaterial_del_ex
			on			tlbMaterial_del_ex.idfMaterial = tlbMaterial.idfMaterial
			where		tlbMaterial_del_ex.idfMaterial is null

			set	@GoOn = @@rowcount
			set	@GoOn = @GoOn + @RootGoOn
		end

		-- Select a list of containers for deletion
		declare	@tlbContainer_del	table (idfContainer bigint not null primary key)

		-- Select containers of samples marked for deletion
		insert into	@tlbContainer_del	(idfContainer)
		select distinct
					tlbContainer.idfContainer
		from		tlbContainer
		inner join	@tlbMaterial_del tlbMaterial_del
		on			tlbMaterial_del.idfMaterial = tlbContainer.idfMaterial

		-- Select child containers for deletion 
		set @GoOn = 1
		set	@RootGoOn = 0

		while	@GoOn > 0
		begin
			insert into	@tlbContainer_del	(idfContainer)
			select distinct
						tlbContainer.idfContainer
			from		tlbContainer
			inner join	@tlbContainer_del tlbContainer_del
			on			tlbContainer_del.idfContainer = tlbContainer.idfRootParentContainer
			left join	@tlbContainer_del tlbContainer_del_ex
			on			tlbContainer_del_ex.idfContainer = tlbContainer.idfContainer
			where		tlbContainer_del_ex.idfContainer is null

			set	@RootGoOn = @@rowcount

			insert into	@tlbContainer_del	(idfContainer)
			select distinct
						tlbContainer.idfContainer
			from		tlbContainer
			inner join	@tlbContainer_del tlbContainer_del
			on			tlbContainer_del.idfContainer = tlbContainer.idfParentContainer
			left join	@tlbContainer_del tlbContainer_del_ex
			on			tlbContainer_del_ex.idfContainer = tlbContainer.idfContainer
			where		tlbContainer_del_ex.idfContainer is null

			set	@GoOn = @@rowcount
			set	@GoOn = @GoOn + @RootGoOn
		end

		-- Select a list of tests for deletion
		declare	@tlbTesting_del		table (idfTesting bigint not null primary key)

		-- Select tests of containers marked for deletion
		insert into	@tlbTesting_del	(idfTesting)
		select distinct
					tlbTesting.idfTesting
		from		tlbTesting
		inner join	@tlbContainer_del tlbContainer_del
		on			tlbContainer_del.idfContainer = tlbTesting.idfContainer

		-- Delete from related tables
		delete		aIn
		from		tlbAccessionIN aIn
		inner join	@tlbMaterial_del tlbMaterial_del
		on			tlbMaterial_del.idfMaterial = aIn.idfMaterial

		delete		aIn
		from		tlbAccessionIN aIn
		inner join	@tlbContainer_del tlbContainer_del
		on			tlbContainer_del.idfContainer = aIn.idfContainer

		delete		ap
		from		tlbActivityParameters ap
		inner join	tlbTesting
		on			tlbTesting.idfObservation = ap.idfObservation
		inner join	@tlbTesting_del tlbTesting_del
		on			tlbTesting_del.idfTesting = tlbTesting.idfTesting

		delete		mos
		from		tlbMaterialOnSite mos
		inner join	@tlbMaterial_del tlbMaterial_del
		on			tlbMaterial_del.idfMaterial = mos.idfMaterial

		delete		o
		from		tlbObservation o
		inner join	tlbTesting
		on			tlbTesting.idfObservation = o.idfObservation
		inner join	@tlbTesting_del tlbTesting_del
		on			tlbTesting_del.idfTesting = tlbTesting.idfTesting

		delete		tv
		from		tlbTestValidation tv
		inner join	@tlbTesting_del tlbTesting_del
		on			tlbTesting_del.idfTesting = tv.idfTesting

		delete		tIn
		from		tlbTransferIn tIn
		inner join	@tlbContainer_del tlbContainer_del
		on			tlbContainer_del.idfContainer = tIn.idfContainer

		delete		tIn
		from		tlbTransferIn tIn
		inner join	@tlbContainer_del tlbContainer_del
		on			tlbContainer_del.idfContainer = tIn.idfOldContainer

		delete		tOutCL
		from		tlbTransferOutContainerList tOutCL
		inner join	@tlbContainer_del tlbContainer_del
		on			tlbContainer_del.idfContainer = tOutCL.idfContainer

		-- Delete tests, containers and samples
		delete		t
		from		tlbTesting t
		inner join	@tlbTesting_del tlbTesting_del
		on			tlbTesting_del.idfTesting = t.idfTesting

		delete		c
		from		tlbContainer c
		inner join	@tlbContainer_del tlbContainer_del
		on			tlbContainer_del.idfContainer = c.idfContainer

		delete		m
		from		tlbMaterial m
		inner join	@tlbMaterial_del tlbMaterial_del
		on			tlbMaterial_del.idfMaterial = m.idfMaterial
		
	end
	else begin
		-- Updates links from samples and related teststo survivor patient and case

		update		t
		set			t.idfCase = @SurvivorID
		from		tlbTesting t
		inner join	tlbContainer
		on			tlbContainer.idfContainer = t.idfContainer
					and tlbContainer.intRowStatus = 0
		inner join	tlbMaterial
		on			tlbMaterial.idfMaterial = tlbContainer.idfMaterial
					and tlbMaterial.intRowStatus = 0
					and tlbMaterial.idfMaterial = @MaterialID
		where		t.idfCase = @SupersededID

		update		m
		set			m.idfParty = @SurvivorPartyID
		from		tlbMaterial m
		inner join	tlbParty
		on			tlbParty.idfParty = m.idfParty
					and tlbParty.intRowStatus = 0
		where		m.intRowStatus = 0
					and	m.idfMaterial = @MaterialID
					and tlbParty.idfCase = @SupersededID 
					and tlbParty.idfParty = @SupersededPartyID


		update		hc_survivor
		set			hc_survivor.idfsYNSpecimenCollected = 10100001	-- Yes
		from		(
			tlbCase c_survivor
			inner join	tlbHumanCase hc_survivor
			on			hc_survivor.idfHumanCase = c_survivor.idfCase
					)
		where		c_survivor.idfCase = @SurvivorID
					and IsNull(hc_survivor.idfsYNSpecimenCollected, 10100003)	-- Unknown
						<> 10100001	-- Yes


	end
end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

