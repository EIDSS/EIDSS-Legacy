SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAsQuery_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAsQuery_Post]
GO

--##SUMMARY This procedure saves changes of specified query
--##SUMMARY (including creation and deletion (in case of incorrect parameters) of the query).

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 21.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

declare	@idflQuery					bigint
declare	@strFunctionName			nvarchar(200)
declare	@idflDescription			bigint
declare	@DefQueryName				nvarchar(2000)
declare	@QueryName					nvarchar(2000)
declare	@DefQueryDescription		nvarchar(2000)
declare	@QueryDescription			nvarchar(2000)
declare	@blnAddAllKeyFieldValues	bit
declare	@LangID						nvarchar(50)

execute	spAsQuery_Post
		 @idflQuery output
		,@strFunctionName output
		,@idflDescription output
		,@DefQueryName,
		,@QueryName
		,@DefQueryDescription,
		,@QueryDescription
		,@blnAddAllKeyFieldValues
		,@LangID

*/ 


create procedure	spAsQuery_Post
(
	@idflQuery					bigint output,
	@strFunctionName			nvarchar(200) = null output,
	@idflDescription			bigint output,
	@DefQueryName				nvarchar(2000),
	@QueryName					nvarchar(2000),
	@DefQueryDescription		nvarchar(2000),
	@QueryDescription			nvarchar(2000),
	@blnAddAllKeyFieldValues	bit,
	@LangID						nvarchar(50)
)
as

declare	@DefFunctionNamePrefix varchar(50)
declare	@FunctionNameIndex int
declare @NewFunctionName varchar(200)

if	@DefQueryName is null
begin
	-- Delete query
	execute spQuery_Delete	@idflQuery
	set	@idflQuery = -1
	set	@idflDescription = -1
	set	@strFunctionName = null
end
else begin
	if	not exists	(
				select	*
				from	tasQuery q
				where	q.idflQuery = @idflQuery
					)
	begin
		-- Generate new IDs for query and its description
		execute	spsysGetNewID	@idflQuery output
		execute	spsysGetNewID	@idflDescription output

		-- Save local BR related to description
		insert into	locBaseReference
		(	idflBaseReference
		)
		values
		(	@idflDescription
		)

		-- Add translation for description
		if @QueryDescription is not null and len(rtrim(ltrim(@QueryDescription))) > 0
		begin
			execute spAsReferencePost @LangID, @idflDescription, @QueryDescription
		end

		-- Save local BR related to query and its English translation
		insert into	locBaseReference
		(	idflBaseReference
		)
		values
		(	@idflQuery
		)

		if @DefQueryName is not null and len(rtrim(ltrim(@DefQueryName))) > 0
		begin
			execute spAsReferencePost 'en', @idflQuery, @DefQueryName
		end

		-- Add translation for query
		if @QueryName is not null and (len(rtrim(ltrim(@QueryName))) > 0) and (@LangID <> N'en')
		begin
			execute spAsReferencePost @LangID, @idflQuery, @QueryName
		end

		-- Generate unique name of the query function
		select top 1	@DefFunctionNamePrefix = 'fn' + s.strSiteID + 'SearchQuery__' + cast(@idflQuery as varchar(30))
		from			tstSite s
		inner join		tstLocalSiteOptions lso
		on				lso.strName = N'SiteID'
						and lso.strValue = cast(s.idfsSite as nvarchar(200))
		where			s.intRowStatus = 0

		set @FunctionNameIndex = 0
		set @NewFunctionName = @DefFunctionNamePrefix

		while	exists
				(	select	*
					from	dbo.sysobjects
					where	xtype in ('IF','FN','TF')
							and category = 0
							and [name] = @NewFunctionName
				)
				or exists
					(	select	*
						from	tasQuery
						where	strFunctionName = @NewFunctionName
					)
		begin
			set @FunctionNameIndex = @FunctionNameIndex + 1
			set @NewFunctionName = @DefFunctionNamePrefix + '__' + cast(@FunctionNameIndex as varchar(100))
		end

		set	@strFunctionName = @NewFunctionName

		-- Create query
		insert into	tasQuery
		(	idflQuery,
			strFunctionName,
			idflDescription,
			blnReadOnly,
			blnAddAllKeyFieldValues
		)
		values
		(	@idflQuery,
			@strFunctionName,
			@idflDescription,
			0,
			@blnAddAllKeyFieldValues
		)
		
	end
	else begin
		if	not exists	(
					select	*
					from	locBaseReference lbr
					where	lbr.idflBaseReference = @idflDescription
						)
		begin
			-- Generate new ID for query description
			execute	spsysGetNewID	@idflDescription output

			-- Save local BR related to description
			insert into	locBaseReference
			(	idflBaseReference
			)
			values
			(	@idflDescription
			)
		end

		-- Add or delete translation for query description
		if @QueryDescription is not null and len(rtrim(ltrim(@QueryDescription))) > 0
		begin
			execute spAsReferencePost @LangID, @idflDescription, @QueryDescription
		end
		else begin
			delete	lsnt
			from	locStringNameTranslation lsnt
			where	lsnt.idflBaseReference = @idflDescription
					and lsnt.idfsLanguage = dbo.fnGetLanguageCode(@LangID)
		end

		-- Save English translation for query
		execute spAsReferencePost 'en', @idflQuery, @DefQueryName

		-- Add or delete translation for query
		if @LangID<>'en' 
		begin
			if @QueryName is not null and len(rtrim(ltrim(@QueryName))) > 0
			begin
				execute spAsReferencePost @LangID, @idflQuery, @QueryName
			end
			else begin
				delete	lsnt
				from	locStringNameTranslation lsnt
				where	lsnt.idflBaseReference = @idflQuery
						and lsnt.idfsLanguage = dbo.fnGetLanguageCode(@LangID)
			end
		end
		-- Update query
		update	q
		set		q.idflDescription			= @idflDescription,
				q.blnAddAllKeyFieldValues	= @blnAddAllKeyFieldValues
		from	tasQuery q
		where	q.idflQuery = @idflQuery

		-- Select query function name
		select	@strFunctionName = q.strFunctionName
		from	tasQuery q
		where	q.idflQuery = @idflQuery

	end
end


return 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

