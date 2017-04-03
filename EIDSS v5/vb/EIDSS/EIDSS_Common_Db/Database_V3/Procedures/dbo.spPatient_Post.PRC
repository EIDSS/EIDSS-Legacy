SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPatient_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPatient_Post]
GO

--##SUMMARY Saves information about the human (patient or farm owner).

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 23.01.2010

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
declare	@idfHuman					bigint
declare	@idfRootHuman				bigint
declare	@idfCase					bigint
declare	@idfsOccupationType			bigint
declare	@idfsNationality			bigint
declare	@idfsHumanGender			bigint
declare	@idfCurrentResidenceAddress	bigint
declare	@idfEmployerAddress			bigint
declare	@idfRegistrationAddress		bigint
declare	@datDateofBirth				datetime
declare	@datDateOfDeath				datetime
declare	@strLastName				nvarchar(200)
declare	@strSecondName				nvarchar(200)
declare	@strFirstName				nvarchar(200)
declare	@strRegistrationPhone		nvarchar(200)
declare	@strEmployerName			nvarchar(200)
declare	@strHomePhone				nvarchar(200)
declare	@strWorkPhone				nvarchar(200)

exec spPatient_Post 
	 @idfHuman
	,@idfRootHuman
	,@idfCase
	,@idfsOccupationType
	,@idfsNationality
	,@idfsHumanGender
	,@idfCurrentResidenceAddress
	,@idfEmployerAddress
	,@idfRegistrationAddress
	,@datDateofBirth
	,@datDateOfDeath
	,@strLastName
	,@strSecondName
	,@strFirstName
	,@strRegistrationPhone
	,@strEmployerName
	,@strHomePhone
	,@strWorkPhone
*/


create	procedure	spPatient_Post
(	 @idfHuman						bigint			--##PARAM @idfHuman Human Id
	,@idfRootHuman					bigint	= null	--##PARAM @idfRootHuman Id of the original human (must be null for original human) (reference to tlbParty)
	,@idfCase						bigint	= null	--##PARAM @idfCase Id of the case, for which this human is a patient (reference to tlbCase); this parameter could be not specified
	,@idfsOccupationType			bigint			--##PARAM @idfsOccupationType Id of the occupation (reference to trtBaseReference with type rftOccupationType (19000061))
	,@idfsNationality				bigint			--##PARAM @idfsNationality Id of the nationality or citizenship (reference to trtBaseReference with type rftNationality (19000054))
	,@idfsHumanGender				bigint			--##PARAM @@idfsHumanGender Id of the patient sex (reference to trtBaseReference with type rftHumanGender (19000043))
	,@idfCurrentResidenceAddress	bigint			--##PARAM @idfCurrentResidenceAddress Id of the current residence address (reference to tlbGeoLocation)
	,@idfEmployerAddress			bigint			--##PARAM @idfEmployerAddress Id of the address of the employer, children's facility, and school (reference to tlbGeoLocation)
	,@idfRegistrationAddress		bigint			--##PARAM @idfRegistrationAddress Id of the permanent residence address (reference to tlbGeoLocation)
	,@datDateofBirth				datetime		--##PARAM @datDateofBirth Date of birth
	,@datDateOfDeath				datetime		--##PARAM @datDateOfDeath Date of death
	,@strLastName					nvarchar(200)	--##PARAM @strLastName Last name of the patient
	,@strSecondName					nvarchar(200)	--##PARAM @strSecondName Second name of the patient
	,@strFirstName					nvarchar(200)	--##PARAM @strFirstName First name of the patient
	,@strRegistrationPhone			nvarchar(200)	--##PARAM @strRegistrationPhone Phone number of the permanent residence
	,@strEmployerName				nvarchar(200)	--##PARAM @strEmployerName Name of employer
	,@strHomePhone					nvarchar(200)	--##PARAM @strHomePhone Phone number of the current residence
	,@strWorkPhone					nvarchar(200)	--##PARAM @strWorkPhone Phone number of the employer, children's facility, and school
)
as

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

	if not exists	(
		select		*
		from		tlbParty
		where		tlbParty.idfParty = @idfRootHuman
					)
	begin
		set @idfRootHuman = null
	end

	update	tlbParty
	set		idfsPartyType		=	@idfsPartyType,
			idfCase				=	@idfCase,
			idfRootParty		=	@idfRootHuman

	where	idfParty = @idfHuman

	update	tlbParty
	set		idfsPartyType		=	@idfsPartyType,
			idfCase				=	null,
			idfRootParty		=	null

	where	idfParty = @idfRootHuman
end
else begin
	if	not exists	(
			select		*
			from		tlbParty
			where		tlbParty.idfParty = @idfRootHuman
					)
		and @idfRootHuman is not null
	begin
		insert into	tlbParty
		(	idfParty,
			idfsPartyType,
			idfCase,
			idfRootParty
		)
		values
		(	@idfRootHuman,
			@idfsPartyType,
			null,
			null
		)
	end
	else begin
		update	tlbParty
		set		idfsPartyType		=	@idfsPartyType,
				idfCase				=	null,
				idfRootParty		=	null

		where	idfParty = @idfRootHuman
	end

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

if not exists	(
	select	*
	from	tlbGeoLocation GeoLocation
	where	GeoLocation.idfGeoLocation = @idfCurrentResidenceAddress
			and GeoLocation.idfsGeoLocationType = 10036001		-- Address
			and GeoLocation.intRowStatus = 0
				)
begin
	set @idfCurrentResidenceAddress = null
end

if not exists	(
	select	*
	from	tlbGeoLocation GeoLocation
	where	GeoLocation.idfGeoLocation = @idfEmployerAddress
			and GeoLocation.idfsGeoLocationType = 10036001		-- Address
			and GeoLocation.intRowStatus = 0
				)
begin
	set @idfEmployerAddress = null
end

if not exists	(
	select	*
	from	tlbGeoLocation GeoLocation
	where	GeoLocation.idfGeoLocation = @idfRegistrationAddress
			and GeoLocation.idfsGeoLocationType = 10036001		-- Address
			and GeoLocation.intRowStatus = 0
				)
begin
	set @idfRegistrationAddress = null
end

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

-- Post root tlbHuman
if @idfRootHuman is not null
begin
	declare	@idfRootCurrentResidenceAddress bigint
	declare	@idfRootEmployerAddress			bigint
	declare	@idfRootRegistrationAddress		bigint

	-- Get id for root idfCurrentResidenceAddress
	set	@idfRootCurrentResidenceAddress = null
	select		@idfRootCurrentResidenceAddress	= tlbGeoLocation.idfGeoLocation
	from		tlbHuman
	inner join	tlbGeoLocation
	on			tlbGeoLocation.idfGeoLocation = tlbHuman.idfCurrentResidenceAddress
				and tlbGeoLocation.intRowStatus = 0
	where		tlbHuman.idfHuman = @idfRootHuman

	if @idfCurrentResidenceAddress is null
		set	@idfRootCurrentResidenceAddress = null
	else if @idfRootCurrentResidenceAddress is null
		exec spsysGetNewID @idfRootCurrentResidenceAddress output

	-- Get id for root idfEmployerAddress
	set	@idfRootEmployerAddress = null
	select		@idfRootEmployerAddress	= tlbGeoLocation.idfGeoLocation
	from		tlbHuman
	inner join	tlbGeoLocation
	on			tlbGeoLocation.idfGeoLocation = tlbHuman.idfEmployerAddress
				and tlbGeoLocation.intRowStatus = 0
	where		tlbHuman.idfHuman = @idfRootHuman

	if @idfEmployerAddress is null
		set	@idfRootEmployerAddress = null
	else if @idfRootEmployerAddress is null
		exec spsysGetNewID @idfRootEmployerAddress output

	-- Get id for root idfRegistrationAddress
	set	@idfRootRegistrationAddress = null
	select		@idfRootRegistrationAddress	= tlbGeoLocation.idfGeoLocation
	from		tlbHuman
	inner join	tlbGeoLocation
	on			tlbGeoLocation.idfGeoLocation = tlbHuman.idfRegistrationAddress
				and tlbGeoLocation.intRowStatus = 0
	where		tlbHuman.idfHuman = @idfRootHuman

	if @idfRegistrationAddress is null
		set	@idfRootRegistrationAddress = null
	else if @idfRootRegistrationAddress is null
		exec spsysGetNewID @idfRootRegistrationAddress output

	-- Copy addresses for root human
	if @idfRootCurrentResidenceAddress is not null
		exec spGeoLocation_CreateCopy	
				@idfCurrentResidenceAddress,
				@idfRootCurrentResidenceAddress

	if @idfRootEmployerAddress is not null
		exec spGeoLocation_CreateCopy	
				@idfEmployerAddress,
				@idfRootEmployerAddress

	if @idfRootRegistrationAddress is not null
		exec spGeoLocation_CreateCopy	
				@idfRegistrationAddress,
				@idfRootRegistrationAddress

	if exists	(
		select	*
		from	tlbHuman
		where	idfHuman = @idfRootHuman
				)
	begin
		update	tlbHuman
		set		idfsOccupationType			=	@idfsOccupationType,
				idfsNationality				=	@idfsNationality,
				idfsHumanGender				=	@idfsHumanGender,
				idfCurrentResidenceAddress	=	@idfRootCurrentResidenceAddress,
				idfEmployerAddress			=	@idfRootEmployerAddress,
				idfRegistrationAddress		=	@idfRootRegistrationAddress,
				datDateofBirth				=	@datDateofBirth,
				datDateOfDeath				=	@datDateOfDeath,
				strLastName					=	@strLastName,
				strSecondName				=	@strSecondName,
				strFirstName				=	@strFirstName,
				strRegistrationPhone		=	@strRegistrationPhone,
				strEmployerName				=	@strEmployerName,
				strHomePhone				=	@strHomePhone,
				strWorkPhone				=	@strWorkPhone				

		where	idfHuman = @idfRootHuman
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
		(	@idfRootHuman,
			@idfsOccupationType,
			@idfsNationality,
			@idfsHumanGender,
			@idfRootCurrentResidenceAddress,
			@idfRootEmployerAddress,
			@idfRootRegistrationAddress,
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

