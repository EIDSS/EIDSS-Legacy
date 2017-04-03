GO
/****** Object:  StoredProcedure [dbo].[spAsFolderPublish]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsFolderPublish]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsFolderPublish]

/****** Object:  StoredProcedure [dbo].[spAsFolderPublish]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY create folder for Folders for analytical module

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 12.03.2010

--##RETURNS Don't use

/*

--Example of a call of procedure:

declare @idflFolder bigint
set @idflFolder = 741140000000
declare @idfsQuery bigint
set @idfsQuery = 38850000000

--delete published folder 
delete
from dbo.trtStringNameTranslation
where idfsbasereference = @idflFolder

update	 tasglLayout
set		 idfsLayoutFolder = null
where	idfsLayoutFolder = @idflFolder	

update	 tasLayoutFolder
set		 idfsGlobalLayoutFolder = null
		,blnReadOnly = 0
where	idflLayoutFolder = @idflFolder	
			
delete from  dbo.tasglLayoutFolder
where	idfsLayoutFolder = @idflFolder
	
delete from  dbo.trtBaseReference
where	idfsbasereference = @idflFolder
	
-- check than no folder published with given id
select	*
from	tasLayoutFolder
where	idflLayoutFolder = @idflFolder

select	*
from	tasglLayoutFolder
where	idfsLayoutFolder = @idflFolder	

-- exec sp
declare @idfsFolder bigint
EXEC	[spAsFolderPublish] 	@idflFolder,	@idfsQuery, @idfsFolder output

--check that folder published
select	*
from	tasLayoutFolder
where	idflLayoutFolder = @idflFolder

select	*
from	tasglLayoutFolder
where	idfsLayoutFolder = @idflFolder	

*/ 


CREATE PROCEDURE [dbo].[spAsFolderPublish]
	@idflFolder				bigint,
	@idfsQuery				bigint,
	@idfsFolder			bigint output
AS
BEGIN
	if	not exists	(	
					select	*
					from	tasglQuery
					where	idfsQuery = @idfsQuery
					)
	begin
		Raiserror (N'Global query with ID=%I64d doesn''t exist.', 15, 1,  @idfsQuery)
		return 1
	end
	
	if	not exists	(	
					select	*
					from	tasLayoutFolder
					where	idflLayoutFolder = @idflFolder
					)
	begin
		Raiserror (N'Folder with ID=%I64d doesn''t exist.', 15, 1,  @idflFolder)
		return 1
	end
	begin try
		declare @idflParentLayoutFolder bigint
		declare @idfsParentLayoutFolder bigint
		declare @strLocalFolderName		nvarchar(2000)
		declare @strENFolderName		nvarchar(2000)
		declare @strBaseReferenceCode	varchar(36)

		select		@idfsFolder = idfsGlobalLayoutFolder,
					@strENFolderName = refENFolder.strName
		from		tasLayoutFolder				as tFolder
		inner join	dbo.fnLocalReference('en')	as refENFolder
				on	tFolder.idflLayoutFolder = refENFolder.idflBaseReference 
		where		idflLayoutFolder = @idflFolder 
		
		-- if local folder contains reference to global folder - return
		if (@idfsFolder is not null)
			return
		
		-- let global folder has the same id as local
		set @idfsFolder	= @idflFolder
		
		-- if there is global folder with given id - return
		if	 exists	(	
			select	 *
			from	tasglLayoutFolder 
			where	idfsLayoutFolder = @idfsFolder
				)
			return


		-- insert base reference and english translation
		exec spBaseReference_SysPost @idfsFolder, 19000123, 'en', @strENFolderName, @strENFolderName, null, null	
			
		-- cursor for insert all translation
		declare BaseReferencePostCursor cursor for
		select  strBaseReferenceCode
		from	fnBaseReferenceCode()
		
		open BaseReferencePostCursor
		
		fetch next from BaseReferencePostCursor into @strBaseReferenceCode
		while @@fetch_status = 0
		begin
			select		@strLocalFolderName = refLocalFolder.strName
			from		tasLayoutFolder				as tFolder
			inner join	dbo.fnLocalReference(@strBaseReferenceCode)	as refLocalFolder
					on	tFolder.idflLayoutFolder = refLocalFolder.idflBaseReference 
			where		idflLayoutFolder = @idflFolder 
			-- insert translation if language is not english
			if (@strBaseReferenceCode != 'en')
				exec spBaseReference_SysPost @idfsFolder, 19000123, @strBaseReferenceCode, @strENFolderName, @strLocalFolderName, null, null	

			fetch next from BaseReferencePostCursor into @strBaseReferenceCode
		end
		close BaseReferencePostCursor
		deallocate BaseReferencePostCursor
		
		
		--publish parent folder if needed
		select	@idflParentLayoutFolder = idflParentLayoutFolder 
		from	tasLayoutFolder
		where	idflLayoutFolder = @idflFolder
		if (@idflParentLayoutFolder is not null)
		begin
			exec spAsFolderPublish @idflParentLayoutFolder, @idfsQuery, @idfsParentLayoutFolder output
		end
		
		-- insert global folder
		insert into tasglLayoutFolder
		   (idfsLayoutFolder
		   ,idfsParentLayoutFolder
		   ,idfsQuery
		   ,blnReadOnly)
		values
		   (@idfsFolder
		   ,@idfsParentLayoutFolder
		   ,@idfsQuery
		   ,1)
           
        -- create reference from local folder to global
		update	 tasLayoutFolder
		set		 idfsGlobalLayoutFolder = @idfsFolder
				,blnReadOnly = 1
		where	idflLayoutFolder = @idflFolder	
		
	end try
	
	begin catch
		declare @error nvarchar(max)
		set @error = ERROR_PROCEDURE() +': '+ ERROR_MESSAGE()
		Raiserror (N'Error while publishing query search object: %s', 15, 1, @error)
		return 1
	end catch

end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

