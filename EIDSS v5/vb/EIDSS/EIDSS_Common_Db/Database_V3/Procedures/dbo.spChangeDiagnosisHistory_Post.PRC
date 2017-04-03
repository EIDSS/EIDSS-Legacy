SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spChangeDiagnosisHistory_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spChangeDiagnosisHistory_Post]
GO

--##SUMMARY Saves information about change of diagnosis.

--##REMARKS Author: Mirnaya O.
--##REMARKS Update date: 19.08.2010

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
declare	@idfChangeDiagnosisHistory	bigint
declare	@idfHumanCase				bigint
declare	@idfUserID					bigint
declare	@idfsPreviousDiagnosis		bigint
declare	@idfsCurrentDiagnosis		bigint
declare	@datChangedDate				datetime
declare	@strReason					nvarchar(2000)

exec spChangeDiagnosisHistory_Post 
		 @idfContactedCasePerson
		,@idfHumanCase
		,@idfUserID
		,@idfsPreviousDiagnosis
		,@idfsCurrentDiagnosis
		,@datChangedDate
		,@strReason

*/

create	procedure	spChangeDiagnosisHistory_Post
(	 @idfChangeDiagnosisHistory	bigint			--##PARAM @idfChangeDiagnosisHistory Diagnosis change Id
	,@idfHumanCase				bigint			--##PARAM @idfHumanCase Id of the human case with changed diagnosis (reference to tlbHumanCase)
	,@idfUserID					bigint			--##PARAM @idfUserID Id of user who changed diagnosi (reference to tstUserTable)
	,@idfsPreviousDiagnosis		bigint			--##PARAM @idfsPreviousDiagnosis Id of previous diagnosis (reference to trtDiagnosis -> trtBaseReference with type rftDiagnosis (19000019))
	,@idfsCurrentDiagnosis		bigint			--##PARAM @idfsCurrentDiagnosis Id of new diagnosis (reference to trtDiagnosis -> trtBaseReference with type rftDiagnosis (19000019))
	,@datChangedDate			datetime		--##PARAM @datChangedDate Date of diagnosis change
	,@strReason					nvarchar(2000)	--##PARAM @strReason Reason for diagnosis change
)
as

-- Update reference parameters related to tlbChangeDiagnosisHistory
if not exists	(
	select		*
	from		trtBaseReference
	inner join	trtDiagnosis
	on			trtDiagnosis.idfsDiagnosis = trtBaseReference.idfsBaseReference
	where		trtBaseReference.idfsBaseReference = @idfsPreviousDiagnosis
				and trtBaseReference.idfsReferenceType = 19000019	-- rftDiagnosis
				and trtBaseReference.intRowStatus = 0
				)
begin
	set @idfsPreviousDiagnosis = null
end

if not exists	(
	select		*
	from		trtBaseReference
	inner join	trtDiagnosis
	on			trtDiagnosis.idfsDiagnosis = trtBaseReference.idfsBaseReference
	where		trtBaseReference.idfsBaseReference = @idfsCurrentDiagnosis
				and trtBaseReference.idfsReferenceType = 19000019	-- rftDiagnosis
				and trtBaseReference.intRowStatus = 0
				)
begin
	set @idfsCurrentDiagnosis = null
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
	from		tstUserTable
	where		tstUserTable.idfUserID = @idfUserID
				and tstUserTable.intRowStatus = 0
				)
begin
	set @idfUserID = null
end

-- Post tlbChangeDiagnosisHistory
if	@idfHumanCase is not null
	and @idfUserID is not null
	and @datChangedDate is not null
	and @strReason is not null
begin
	if	exists	(
			select	*
			from	tlbChangeDiagnosisHistory
			where	idfChangeDiagnosisHistory = @idfChangeDiagnosisHistory
				)
	begin
		update	tlbChangeDiagnosisHistory
		set		idfHumanCase			=	@idfHumanCase,
				idfUserID				=	@idfUserID,
				idfsPreviousDiagnosis	=	@idfsPreviousDiagnosis,
				idfsCurrentDiagnosis	=	@idfsCurrentDiagnosis,
				datChangedDate			=	@datChangedDate,
				strReason				=	@strReason

		where	idfChangeDiagnosisHistory = @idfChangeDiagnosisHistory
	end
	else begin
		insert into	tlbChangeDiagnosisHistory
		(	idfChangeDiagnosisHistory,
			idfHumanCase,
			idfUserID,
			idfsPreviousDiagnosis,
			idfsCurrentDiagnosis,
			datChangedDate,
			strReason
		)
		values
		(	@idfChangeDiagnosisHistory,
			@idfHumanCase,
			@idfUserID,
			@idfsPreviousDiagnosis,
			@idfsCurrentDiagnosis,
			@datChangedDate,
			@strReason
		)
	end
end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

