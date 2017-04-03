SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAsQueryMakeLocal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAsQueryMakeLocal]
GO

--##SUMMARY This procedure publish of specified query

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 21.08.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

declare @idflQuery bigint
execute	spAsQueryMakeLocal 718300000000, @idflQuery output
select @idflQuery
		 
*/ 


create procedure	spAsQueryMakeLocal
(
	@idfsQuery	bigint,
	@idflQuery	bigint output
)
as

	if	not exists	(	
					select	*
					from	tasglQuery
					where	idfsQuery = @idfsQuery
					)
	begin
		Raiserror (N'Global Query with ID=%I64d doesn''t exist.', 15, 1,  @idfsQuery)
		return 1
	end
	
	if exists (
				select	*
				from	tasQuery
				where	idfsGlobalQuery = @idfsQuery
				)
	return 0
	
	begin try
		declare @idflDescription	bigint
		declare @strFunctionName	nvarchar(2000)
		declare @blnAddAllKeyFieldValues bit
		declare @strBaseReferenceCode	varchar(36)
					
		declare @strENQueryName		nvarchar(2000)
		declare @strENDescription	nvarchar(2000)
		declare @strLocalQueryName		nvarchar(2000)
		declare @strLocalDescription	nvarchar(2000)

		-- let local query has the same id as global	
		set @idflQuery	 = @idfsQuery
		
		-- if local query exists - nothing should be done
		if exists	(	
				select	*
				from	tasQuery
				where	idflQuery = @idflQuery
				)
			return 0

		select		 @strFunctionName = strFunctionName + cast(@idflQuery as nvarchar(20))
					,@blnAddAllKeyFieldValues = @blnAddAllKeyFieldValues
					,@idflDescription = tQuery.idfsDescription
					,@strENQueryName = refENQuery.Name
					,@strENDescription = refENDescription.Name	
					
		from		tasglQuery				as tQuery
		inner join	dbo.fnReference('en',19000075)	as refENQuery
				on	tQuery.idfsQuery = refENQuery.idfsReference 
		 left join	dbo.fnReference('en',19000121)	as refENDescription
				on	tQuery.idfsDescription = refENDescription.idfsReference
		where		idfsQuery = @idfsQuery 
		
		-- insert local reference and english translation
		exec spAsReferencePost  'en',  @idflQuery, @strENQueryName	
		if (@idflDescription is not null)
			exec spAsReferencePost 'en',  @idflDescription, @strENDescription
		
		-- cursor for insert all translation
		declare LocalReferencePostCursor cursor for
		select  strBaseReferenceCode
		from	fnBaseReferenceCode()
		
		open LocalReferencePostCursor
		
		fetch next from LocalReferencePostCursor into @strBaseReferenceCode
		while @@fetch_status = 0
		begin
			select	@strLocalQueryName = refLocalQuery.Name
					,@strLocalDescription = refLocalDescription.Name	
				
			from		tasglQuery				as tQuery
			inner join	dbo.fnReference(@strBaseReferenceCode,19000075)	as refLocalQuery
					on	tQuery.idfsQuery = refLocalQuery.idfsReference 
			 left join	dbo.fnReference(@strBaseReferenceCode,19000121)	as refLocalDescription
					on	tQuery.idfsDescription = refLocalDescription.idfsReference
			where		idfsQuery = @idfsQuery 
			
			-- insert translation if language is not english
			if (@strBaseReferenceCode != 'en')
			begin
				exec spAsReferencePost  @strBaseReferenceCode,  @idflQuery, @strLocalQueryName	
				if (@idflDescription is not null)
					exec spAsReferencePost @strBaseReferenceCode,  @idflDescription, @strLocalDescription
			end

			fetch next from LocalReferencePostCursor into @strBaseReferenceCode
		end
		close LocalReferencePostCursor
		deallocate LocalReferencePostCursor
		
		
		insert into tasQuery
				(idflQuery
				,idfsGlobalQuery
				,strFunctionName
				,idflDescription
				,blnReadOnly
				,blnAddAllKeyFieldValues
				)
		values	(@idflQuery
				,@idfsQuery
				,@strFunctionName
				,@idflDescription
				,1
				,@blnAddAllKeyFieldValues
				)
					

	end try
	begin catch
		declare @error nvarchar(max)
		set @error = ERROR_PROCEDURE() +': '+ ERROR_MESSAGE()
		Raiserror (N'Error while making local query: %s', 15, 1, @error)
		return 1
	end catch
	

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

