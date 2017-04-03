SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spContactedCasePerson_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spContactedCasePerson_Post]
GO

--##SUMMARY Saves information about the human case contacts.

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 23.01.2010

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
declare	@idfContactedCasePerson	bigint
declare	@idfHumanCase			bigint
declare	@idfHuman				bigint
declare	@idfsPersonContactType	bigint
declare	@datDateOfLastContact	datetime
declare	@strPlaceInfo			nvarchar(200)

exec spContactedCasePerson_Post 
		 @idfContactedCasePerson
		,@idfHumanCase
		,@idfHuman
		,@idfsPersonContactType
		,@datDateOfLastContact
		,@strPlaceInfo

*/

create	procedure	spContactedCasePerson_Post
(	 @idfContactedCasePerson	bigint			--##PARAM @idfContactedCasePerson Contact Id
	,@idfHumanCase				bigint			--##PARAM @idfHumanCase Id of the human case that includes a specified contact (reference to tlbHumanCase)
	,@idfHuman					bigint			--##PARAM @idfHuman Id of the contact human (reference to tlbHuman)
	,@idfsPersonContactType		bigint			--##PARAM @idfsPersonContactType Id of the contact type (reference to trtBaseReference with type rftContact_Type (19000014))
	,@datDateOfLastContact		datetime		--##PARAM @datDateOfLastContact Date of the last contact
	,@strPlaceInfo				nvarchar(200)	--##PARAM @strPlaceInfo Contact place
)
as

-- Update reference parameters related to tlbContactedCasePerson
if not exists	(
	select	*
	from	trtBaseReference ContactType
	where	ContactType.idfsBaseReference = @idfsPersonContactType
			and ContactType.idfsReferenceType = 19000014	-- rftContact_Type
			and ContactType.intRowStatus = 0
				)
begin
	set @idfsPersonContactType = null
end

if not exists	(
	select		*
	from		tlbHumanCase HumanCase
	inner join	tlbCase
	on			tlbCase.idfCase = HumanCase.idfHumanCase
				and tlbCase.intRowStatus = 0
	where		HumanCase.idfHumanCase = @idfHumanCase
				)
begin
	set @idfHumanCase = null
end

if not exists	(
	select		*
	from		tlbHuman Human
	inner join	tlbParty
	on			tlbParty.idfParty = Human.idfHuman
				and tlbParty.intRowStatus = 0
	where		Human.idfHuman = @idfHuman
				)
begin
	set @idfHuman = null
end

-- Post tlbContactedCasePerson
if	@idfHumanCase is not null
	and @idfHuman is not null
	and @idfsPersonContactType is not null
begin
	if	exists	(
			select	*
			from	tlbContactedCasePerson
			where	idfContactedCasePerson = @idfContactedCasePerson
				)
	begin
		update	tlbContactedCasePerson
		set		idfHumanCase			=	@idfHumanCase,
				idfHuman				=	@idfHuman,
				idfsPersonContactType	=	@idfsPersonContactType,
				datDateOfLastContact	=	@datDateOfLastContact,
				strPlaceInfo			=	@strPlaceInfo

		where	idfContactedCasePerson = @idfContactedCasePerson
	end
	else begin
		insert into	tlbContactedCasePerson
		(	idfContactedCasePerson,
			idfHumanCase,
			idfHuman,
			idfsPersonContactType,
			datDateOfLastContact,
			strPlaceInfo
		)
		values
		(	@idfContactedCasePerson,
			@idfHumanCase,
			@idfHuman,
			@idfsPersonContactType,
			@datDateOfLastContact,
			@strPlaceInfo
		)
	end
end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

