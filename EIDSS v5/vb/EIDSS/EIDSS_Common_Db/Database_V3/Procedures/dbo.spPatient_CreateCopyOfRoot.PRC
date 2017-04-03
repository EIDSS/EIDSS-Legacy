SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPatient_CreateCopyOfRoot]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPatient_CreateCopyOfRoot]
GO

--##SUMMARY Creates a copy of the original human.
--##SUMMARY If the original human does not exist, no new entries will not be added.
--##SUMMARY If the human-copy does not exist, a new record will be created.

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 26.01.2010

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
declare	@idfHuman		bigint
declare	@idfRootHuman	bigint
declare	@idfCase		bigint

exec spPatient_CreateCopyOfRoot 
	 @idfHuman output
	,@idfRootHuman
*/


create	procedure	spPatient_CreateCopyOfRoot
(	 @idfHuman						bigint			--##PARAM @idfHuman Human Id
	,@idfRootHuman					bigint			--##PARAM @idfRootHuman Id of the original human (must be not null) (reference to tlbParty)
	,@idfCase						bigint	= null	--##PARAM @idfCase Id of the case, for which this human is a patient (reference to tlbCase); this parameter could be not specified
)
as

if	exists	(
		select		*
		from		tlbParty
		inner join	tlbHuman
		on			tlbHuman.idfHuman = tlbParty.idfParty
		where		tlbParty.idfParty = @idfRootHuman
					and tlbParty.idfRootParty is null
					and tlbParty.idfCase is null
					and tlbParty.intRowStatus = 0
			)
	and @idfHuman is not null
begin

	-- Update reference parameters related to tlbParty
	declare	@idfsPartyType bigint
	set	@idfsPartyType = null
	select	@idfsPartyType = PartyType.idfsBaseReference
	from	trtBaseReference PartyType
	where	PartyType.idfsBaseReference = 10072006		-- Human
			and PartyType.idfsReferenceType = 19000072	-- rftPartyType
			and PartyType.intRowStatus = 0

	if not exists	(
		select		*
		from		tlbHumanCase HumanCase
		inner join	tlbCase
		on			tlbCase.idfCase = HumanCase.idfHumanCase
					and tlbCase.intRowStatus = 0
		where		HumanCase.idfHumanCase = @idfCase
					)
	begin
		set @idfCase = null
	end

	-- Post tlbParty
	if exists	(
		select	*
		from	tlbParty
		where	idfParty = @idfHuman
				)
	begin
		update	tlbParty
		set		idfsPartyType		=	@idfsPartyType,
				idfCase				=	@idfCase,
				idfRootParty		=	@idfRootHuman

		where	idfParty = @idfHuman
	end
	else begin
		insert into	tlbParty
		(	idfParty,
			idfsPartyType,
			idfCase,
			idfRootParty
		)
		values
		(	@idfHuman,
			@idfsPartyType,
			@idfCase,
			@idfRootHuman
		)
	end

	-- Update reference parameters related to tlbHuman
	declare	@idfsOccupationType				bigint
	declare	@idfsNationality				bigint
	declare	@idfsHumanGender				bigint
	declare	@idfRootCurrentResidenceAddress	bigint
	declare	@idfRootEmployerAddress			bigint
	declare	@idfRootRegistrationAddress		bigint
	declare	@datDateofBirth					datetime
	declare	@datDateOfDeath					datetime
	declare	@strLastName					nvarchar(200)
	declare	@strSecondName					nvarchar(200)
	declare	@strFirstName					nvarchar(200)
	declare	@strRegistrationPhone			nvarchar(200)
	declare	@strEmployerName				nvarchar(200)
	declare	@strHomePhone					nvarchar(200)
	declare	@strWorkPhone					nvarchar(200)

	declare	@idfCurrentResidenceAddress		bigint
	declare	@idfEmployerAddress				bigint
	declare	@idfRegistrationAddress			bigint

	select	@idfsOccupationType				= tlbHuman.idfsOccupationType,
			@idfsNationality				= tlbHuman.idfsNationality,
			@idfsHumanGender				= tlbHuman.idfsHumanGender,
			@idfRootCurrentResidenceAddress	= tlbHuman.idfCurrentResidenceAddress,
			@idfRootEmployerAddress			= tlbHuman.idfEmployerAddress,
			@idfRootRegistrationAddress		= tlbHuman.idfRegistrationAddress,
			@datDateofBirth					= tlbHuman.datDateofBirth,	
			@datDateOfDeath					= tlbHuman.datDateOfDeath,
			@strLastName					= tlbHuman.strLastName,
			@strSecondName					= tlbHuman.strSecondName,
			@strFirstName					= tlbHuman.strFirstName,
			@strRegistrationPhone			= tlbHuman.strRegistrationPhone,
			@strEmployerName				= tlbHuman.strEmployerName,
			@strHomePhone					= tlbHuman.strHomePhone,
			@strWorkPhone					= tlbHuman.strWorkPhone
	from	tlbHuman
	where	tlbHuman.idfHuman = @idfRootHuman

	if not exists	(
			select	*
			from	trtBaseReference OccupationType
			where	OccupationType.idfsBaseReference = @idfsOccupationType
					and OccupationType.idfsReferenceType = 19000061	-- rftOccupationType
					and OccupationType.intRowStatus = 0
					)
	begin
		set	@idfsOccupationType = null
	end

	if not exists	(
			select	*
			from	trtBaseReference Nationality
			where	Nationality.idfsBaseReference = @idfsNationality
					and Nationality.idfsReferenceType = 19000054	-- rftNationality
					and Nationality.intRowStatus = 0
					)
	begin
		set	@idfsNationality = null
	end

	if not exists	(
			select	*
			from	trtBaseReference HumanGender
			where	HumanGender.idfsBaseReference = @idfsHumanGender
					and HumanGender.idfsReferenceType = 19000043	-- rftHumanGender
					and HumanGender.intRowStatus = 0
					)
	begin
		set	@idfsHumanGender = null
	end

	-- Get id for idfCurrentResidenceAddress
	set	@idfCurrentResidenceAddress = null
	select		@idfCurrentResidenceAddress	= tlbGeoLocation.idfGeoLocation
	from		tlbHuman
	inner join	tlbGeoLocation
	on			tlbGeoLocation.idfGeoLocation = tlbHuman.idfCurrentResidenceAddress
				and tlbGeoLocation.intRowStatus = 0
	where		tlbHuman.idfHuman = @idfHuman

	if @idfRootCurrentResidenceAddress is null
		set	@idfCurrentResidenceAddress = null
	else if @idfCurrentResidenceAddress is null
		exec spsysGetNewID @idfCurrentResidenceAddress output

	-- Get id for idfEmployerAddress
	set	@idfEmployerAddress = null
	select		@idfEmployerAddress	= tlbGeoLocation.idfGeoLocation
	from		tlbHuman
	inner join	tlbGeoLocation
	on			tlbGeoLocation.idfGeoLocation = tlbHuman.idfEmployerAddress
				and tlbGeoLocation.intRowStatus = 0
	where		tlbHuman.idfHuman = @idfHuman

	if @idfRootEmployerAddress is null
		set	@idfEmployerAddress = null
	else if @idfEmployerAddress is null
		exec spsysGetNewID @idfEmployerAddress output

	-- Get id for idfRegistrationAddress
	set	@idfRegistrationAddress = null
	select		@idfRegistrationAddress	= tlbGeoLocation.idfGeoLocation
	from		tlbHuman
	inner join	tlbGeoLocation
	on			tlbGeoLocation.idfGeoLocation = tlbHuman.idfRegistrationAddress
				and tlbGeoLocation.intRowStatus = 0

	if @idfRootRegistrationAddress is null
		set	@idfRegistrationAddress = null
	else if @idfRegistrationAddress is null
		exec spsysGetNewID @idfRegistrationAddress output

	-- Copy addresses for the copy of the root human
	if @idfCurrentResidenceAddress is not null
		exec spGeoLocation_CreateCopy	
				@idfRootCurrentResidenceAddress,
				@idfCurrentResidenceAddress

	if @idfEmployerAddress is not null
		exec spGeoLocation_CreateCopy	
				@idfRootEmployerAddress,
				@idfEmployerAddress

	if @idfRegistrationAddress is not null
		exec spGeoLocation_CreateCopy	
				@idfRootRegistrationAddress,
				@idfRegistrationAddress

	-- Post tlbHuman
	if exists	(
		select	*
		from	tlbHuman
		where	idfHuman = @idfHuman
				)
	begin
		update	tlbHuman
		set		idfsOccupationType			=	@idfsOccupationType,
				idfsNationality				=	@idfsNationality,
				idfsHumanGender				=	@idfsHumanGender,
				idfCurrentResidenceAddress	=	@idfCurrentResidenceAddress,
				idfEmployerAddress			=	@idfEmployerAddress,
				idfRegistrationAddress		=	@idfRegistrationAddress,
				datDateofBirth				=	@datDateofBirth,
				datDateOfDeath				=	@datDateOfDeath,
				strLastName					=	@strLastName,
				strSecondName				=	@strSecondName,
				strFirstName				=	@strFirstName,
				strRegistrationPhone		=	@strRegistrationPhone,
				strEmployerName				=	@strEmployerName,
				strHomePhone				=	@strHomePhone,
				strWorkPhone				=	@strWorkPhone				

		where	idfHuman = @idfHuman
	end
	else begin
		insert into	tlbHUman
		(	idfHuman,
			idfsOccupationType,
			idfsNationality,
			idfsHumanGender,
			idfCurrentResidenceAddress,
			idfEmployerAddress,
			idfRegistrationAddress,
			datDateofBirth,
			datDateOfDeath,
			strLastName,
			strSecondName,
			strFirstName,
			strRegistrationPhone,
			strEmployerName,
			strHomePhone,
			strWorkPhone
			
		)
		values
		(	@idfHuman,
			@idfsOccupationType,
			@idfsNationality,
			@idfsHumanGender,
			@idfCurrentResidenceAddress,
			@idfEmployerAddress,
			@idfRegistrationAddress,
			@datDateofBirth,
			@datDateOfDeath,
			@strLastName,
			@strSecondName,
			@strFirstName,
			@strRegistrationPhone,
			@strEmployerName,
			@strHomePhone,
			@strWorkPhone
		)
	end
end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

