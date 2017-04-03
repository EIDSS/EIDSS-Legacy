SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAsQuerySearchField_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAsQuerySearchField_Post]
GO


--##SUMMARY This procedure saves changes of specified query search field 
--##SUMMARY (including creation and deletion (in case of incorrect parameters) of the object).

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 20.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

declare	@idfQuerySearchField	bigint
declare	@idfQuerySearchObject	bigint
declare	@idfsSearchField		bigint
declare	@blnShow				bit
declare	@idfsParameter			bigint

execute	spAsQuerySearchField_Post
		 @idfQuerySearchField output
		,@idfQuerySearchObject
		,@idfsSearchField
		,@blnShow
		,@idfsParameter

*/ 


create procedure	spAsQuerySearchField_Post
(
	@idfQuerySearchField	bigint output,
	@idfQuerySearchObject	bigint,
	@idfsSearchField		bigint,
	@blnShow				bit = null,
	@idfsParameter			bigint = null
)
as

if	not exists	(
		select	*
		from	tasQuerySearchObject
		where	idfQuerySearchObject = @idfQuerySearchObject
				)
	or not exists	(
			select		*
			from		tasSearchField sf
			inner join	trtBaseReference br_sf
			on			br_sf.idfsBaseReference = sf.idfsSearchField
						and br_sf.intRowStatus = 0
			where		sf.idfsSearchField = @idfsSearchField
					)
	or	(	@idfsParameter is not null 
			and not exists	(
						select		*
						from		ffParameter p
						inner join	trtBaseReference br_p
						on			br_p.idfsBaseReference = p.idfsParameter
									and br_p.intRowStatus = 0
						where		p.idfsParameter = @idfsParameter
									and p.intRowStatus = 0
							)
		)
begin
	delete from	tasQuerySearchFieldCondition
	where		idfQuerySearchField = @idfQuerySearchField

	delete from	tasLayoutSearchFieldAggregation
	where		idfDenominatorQuerySearchField = @idfQuerySearchField

	delete from	tasLayoutSearchFieldAggregation
	where		idfUnitQuerySearchField = @idfQuerySearchField

	delete from	tasLayoutSearchFieldAggregation
	where		idfQuerySearchField = @idfQuerySearchField

	delete from	tasQuerySearchField
	where		idfQuerySearchField = @idfQuerySearchField

	set	@idfQuerySearchField = -1
end
else begin
	if	@idfsParameter is not null 
		and exists	(
				select	*
				from	tasQuerySearchField
				where	idfQuerySearchObject = @idfQuerySearchObject
						and	idfsSearchField = @idfsSearchField
						and idfsParameter = @idfsParameter
					)
	begin
		select	@idfQuerySearchField = idfQuerySearchField
		from	tasQuerySearchField
		where	idfQuerySearchObject = @idfQuerySearchObject
				and	idfsSearchField = @idfsSearchField
				and idfsParameter = @idfsParameter
	end

	if exists	(
		select	*
		from	tasQuerySearchField
		where	idfQuerySearchField = @idfQuerySearchField
				)
	begin
		update	tasQuerySearchField
		set		idfQuerySearchObject = @idfQuerySearchObject,
				idfsSearchField = @idfsSearchField,
				blnShow = @blnShow,
				idfsParameter = @idfsParameter
		where	idfQuerySearchField = @idfQuerySearchField
	end
	else begin
		execute spsysGetNewID	@idfQuerySearchField output

		insert into	tasQuerySearchField
		(
			idfQuerySearchField,
			idfQuerySearchObject,
			idfsSearchField,
			blnShow,
			idfsParameter
		)
		values
		(
			@idfQuerySearchField,
			@idfQuerySearchObject,
			@idfsSearchField,
			@blnShow,
			@idfsParameter
		)
	end
end

return 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

