SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAsQuerySearchObject_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAsQuerySearchObject_Post]
GO

--##SUMMARY This procedure saves changes of specified query search object 
--##SUMMARY (including creation and deletion (in case of incorrect parameters) of the object).

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 20.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

declare	@idfQuerySearchObject		bigint
declare	@idflQuery					bigint
declare	@idfsSearchObject			bigint
declare	@intOrder					int
declare	@idfParentQuerySearchObject	bigint

execute	spAsQuerySearchObject_Post
		 @idfQuerySearchObject output
		,@idflQuery
		,@idfsSearchObject
		,@intOrder,
		,@idfParentQuerySearchObject

*/ 


create procedure	spAsQuerySearchObject_Post
(
	@idfQuerySearchObject		bigint output,
	@idflQuery					bigint,
	@idfsSearchObject			bigint,
	@intOrder					int,
	@idfParentQuerySearchObject	bigint = null
	)
as

if	not exists	(
		select	*
		from	tasQuery
		where	idflQuery = @idflQuery
				)
	or not exists	(
			select		*
			from		tasSearchObject sob
			inner join	trtBaseReference br_sob
			on			br_sob.idfsBaseReference = sob.idfsSearchObject
						and br_sob.intRowStatus = 0
			where		sob.idfsSearchObject = @idfsSearchObject
					)
	or	(	@idfParentQuerySearchObject is not null 
			and not exists	(
						select	*
						from	tasQuerySearchObject
						where	idfQuerySearchObject = @idfParentQuerySearchObject
							)
		)
	or	(	@idfParentQuerySearchObject is null 
			and exists	(
						select	*
						from	tasQuerySearchObject
						where	idfParentQuerySearchObject is null
								and idflQuery = @idflQuery
								and idfQuerySearchObject <> @idfQuerySearchObject
						)
		)
	or @intOrder is null
begin

	select	cast(idfQuerySearchObject as bigint) as idfQuerySearchObject into #DelQSO
	from	tasQuerySearchObject
	where	idfQuerySearchObject = @idfQuerySearchObject

	declare @GoOn int
	set @GoOn = 1

	while @GoOn > 0
	begin
		insert into		#DelQSO
		select distinct	qso.idfQuerySearchObject
		from			tasQuerySearchObject qso
		inner join		#DelQSO qso_parent
		on				qso_parent.idfQuerySearchObject = qso.idfParentQuerySearchObject
		left join		#DelQSO qso_ex
		on				qso_ex.idfQuerySearchObject = qso.idfQuerySearchObject
		where			qso_ex.idfQuerySearchObject is null

		set @GoOn = @@rowcount
	end


	select		cast(idfQueryConditionGroup as bigint) as idfQueryConditionGroup into #DelQCG
	from		tasQueryConditionGroup qcg
	inner join	#DelQSO qso_del
	on			qso_del.idfQuerySearchObject = qcg.idfQuerySearchObject

	set @GoOn = 1
	while @GoOn > 0
	begin
		insert into		#DelQCG
		select distinct	qcg.idfQueryConditionGroup
		from			tasQueryConditionGroup qcg
		inner join		#DelQCG qcg_parent
		on				qcg_parent.idfQueryConditionGroup = qcg.idfParentQueryConditionGroup
		left join		#DelQCG qcg_ex
		on				qcg_ex.idfQueryConditionGroup = qcg.idfQueryConditionGroup
		where			qcg_ex.idfQueryConditionGroup is null

		set @GoOn = @@rowcount
	end

	delete		qsfc
	from		tasQuerySearchFieldCondition qsfc
	inner join	#DelQCG qcg_del
	on			qcg_del.idfQueryConditionGroup = qsfc.idfQueryConditionGroup

	delete		qcg
	from		tasQueryConditionGroup qcg
	inner join	#DelQCG qcg_del
	on			qcg_del.idfQueryConditionGroup = qcg.idfQueryConditionGroup

	drop table	#DelQCG

	delete		qsfc
	from		tasQuerySearchFieldCondition qsfc
	inner join	tasQuerySearchField qsf
	on			qsf.idfQuerySearchField = qsfc.idfQuerySearchField
	inner join	#DelQSO qso_del
	on			qso_del.idfQuerySearchObject = qsf.idfQuerySearchObject

	delete		lsfa
	from		tasLayoutSearchFieldAggregation lsfa
	inner join	tasQuerySearchField qsf
	on			qsf.idfQuerySearchField = lsfa.idfDenominatorQuerySearchField
	inner join	#DelQSO qso_del
	on			qso_del.idfQuerySearchObject = qsf.idfQuerySearchObject

	delete		lsfa
	from		tasLayoutSearchFieldAggregation lsfa
	inner join	tasQuerySearchField qsf
	on			qsf.idfQuerySearchField = lsfa.idfUnitQuerySearchField
	inner join	#DelQSO qso_del
	on			qso_del.idfQuerySearchObject = qsf.idfQuerySearchObject

	delete		lsfa
	from		tasLayoutSearchFieldAggregation lsfa
	inner join	tasQuerySearchField qsf
	on			qsf.idfQuerySearchField = lsfa.idfQuerySearchField
	inner join	#DelQSO qso_del
	on			qso_del.idfQuerySearchObject = qsf.idfQuerySearchObject

	delete		qsf
	from		tasQuerySearchField qsf
	inner join	#DelQSO qso_del
	on			qso_del.idfQuerySearchObject = qsf.idfQuerySearchObject

	delete		qso
	from		tasQuerySearchObject qso
	inner join	#DelQSO qso_del
	on			qso_del.idfQuerySearchObject = qso.idfQuerySearchObject

	drop table	#DelQSO

	set	@idfQuerySearchObject = -1
end
else begin
	if exists	(
		select	*
		from	tasQuerySearchObject
		where	idfQuerySearchObject = @idfQuerySearchObject
				)
	begin
		update	tasQuerySearchObject
		set		idflQuery = @idflQuery,
				idfsSearchObject = @idfsSearchObject,
				intOrder = @intOrder,
				idfParentQuerySearchObject = @idfParentQuerySearchObject
		where	idfQuerySearchObject = @idfQuerySearchObject
	end
	else begin
		execute	spsysGetNewID	@idfQuerySearchObject output

		insert into	tasQuerySearchObject
		(
			idfQuerySearchObject,
			idflQuery,
			idfsSearchObject,
			intOrder,
			idfParentQuerySearchObject
		)
		values
		(
			@idfQuerySearchObject,
			@idflQuery,
			@idfsSearchObject,
			@intOrder,
			@idfParentQuerySearchObject
		)
	end
end

return 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

