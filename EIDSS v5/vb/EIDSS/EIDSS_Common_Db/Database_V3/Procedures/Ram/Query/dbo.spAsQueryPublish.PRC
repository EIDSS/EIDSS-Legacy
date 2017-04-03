SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAsQueryPublish]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAsQueryPublish]
GO

--##SUMMARY This procedure publish of specified query

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 21.08.2010

--##RETURNS Don't use


/*
--Example of a call of procedure:

declare @idflQuery bigint
set @idflQuery = 38850000000
declare @idfsQuery bigint
execute	spAsQueryPublish @idflQuery, @idfsQuery output
select @idfsQuery
	 
*/ 


create procedure	spAsQueryPublish
(
	@idflQuery	bigint,
	@idfsQuery	bigint output
)
as

	if	not exists	(	
					select	*
					from	tasQuery
					where	idflQuery = @idflQuery
					)
	begin
		Raiserror (N'Query with ID=%I64d doesn''t exist.', 15, 1,  @idflQuery)
		return 1
	end
	begin try
		declare @idfsDescription	bigint
		declare @strFunctionName	nvarchar(2000)
		declare @blnAddAllKeyFieldValues bit
					
		declare @strENQueryName		nvarchar(2000)
		declare @strLocalQueryName		nvarchar(2000)
		declare @strENDescription	nvarchar(2000)
		declare @strLocalDescription	nvarchar(2000)
		declare @strBaseReferenceCode	varchar(36)


		select		 @idfsQuery = idfsGlobalQuery
					,@strFunctionName = strFunctionName
					,@idfsDescription = idflDescription
					,@blnAddAllKeyFieldValues = @blnAddAllKeyFieldValues
					,@strENQueryName = refENQuery.strName
					,@strENDescription = refENDescription.strName	
					
		from		tasQuery				as tQuery
		inner join	dbo.fnLocalReference('en')	as refENQuery
				on	tQuery.idflQuery = refENQuery.idflBaseReference 
		 left join	dbo.fnLocalReference('en')	as refENDescription
				on	tQuery.idflDescription = refENDescription.idflBaseReference
		where		idflQuery = @idflQuery 
		
			
		-- if local query contains reference to global query - return
		if (@idfsQuery is not null)
			return
			
		-- let global query has the same id as local
		set @idfsQuery	= @idflQuery
			
		--if (@idfsDescription is null)
		--	exec	spsysGetNewID	 @idfsDescription	output
			
		-- if there is global query with given id - return
		if	 exists	(	
			select	 *
			from	tasglQuery 
			where	idfsQuery = @idfsQuery
				)
			return
			
		-- insert base reference and english translation
		exec spBaseReference_SysPost @idfsQuery, 19000075, 'en', @strENQueryName, @strENQueryName, null, null	
		if (@idfsDescription is not null)
			exec spBaseReference_SysPost @idfsDescription, 19000121, 'en', @strENDescription, @strENDescription, null, null	
		
		-- cursor for insert all translation
		declare BaseReferencePostCursor cursor for
		select  strBaseReferenceCode
		from	fnBaseReferenceCode()
		
		open BaseReferencePostCursor
		
		fetch next from BaseReferencePostCursor into @strBaseReferenceCode
		while @@fetch_status = 0
		begin
			select		 @strLocalQueryName = refENQuery.strName
						,@strLocalDescription = refENDescription.strName	
			from		tasQuery				as tQuery
			inner join	dbo.fnLocalReference(@strBaseReferenceCode)	as refENQuery
					on	tQuery.idflQuery = refENQuery.idflBaseReference 
			 left join	dbo.fnLocalReference(@strBaseReferenceCode)	as refENDescription
					on	tQuery.idflDescription = refENDescription.idflBaseReference
			where		idflQuery = @idflQuery 
		
			-- insert translation if language is not english
			if (@strBaseReferenceCode != 'en')
			begin
				exec spBaseReference_SysPost @idfsQuery, 19000075, @strBaseReferenceCode, @strENQueryName, @strLocalQueryName, null, null	
				if (@idfsDescription is not null)
					exec spBaseReference_SysPost @idfsDescription, 19000121, @strBaseReferenceCode, @strENDescription, @strLocalDescription, null, null	
			end

			fetch next from BaseReferencePostCursor into @strBaseReferenceCode
		end
		close BaseReferencePostCursor
		deallocate BaseReferencePostCursor
		
		
		insert into tasglQuery
				(idfsQuery
				,strFunctionName
				,idfsDescription
				,blnReadOnly
				,blnAddAllKeyFieldValues
				)
		values	(@idfsQuery
				,@strFunctionName
				,@idfsDescription
				,1
				,@blnAddAllKeyFieldValues
				)
				

		update	tasQuery
		set		 idfsGlobalQuery = @idfsQuery
				,blnReadOnly = 1
		where	idflQuery = @idflQuery	
		
	end try
	begin catch
		declare @error nvarchar(max)
		set @error = ERROR_PROCEDURE() +': '+ ERROR_MESSAGE()
		Raiserror (N'Error while publishing query: %s', 15, 1, @error)
		return 1
	end catch

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

