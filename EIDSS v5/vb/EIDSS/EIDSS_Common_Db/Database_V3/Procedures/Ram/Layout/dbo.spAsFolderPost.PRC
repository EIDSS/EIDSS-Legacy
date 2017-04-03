GO
/****** Object:  StoredProcedure [dbo].[spAsFolderPost]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsFolderPost]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsFolderPost]

/****** Object:  StoredProcedure [dbo].[spAsFolderPost]    Script Date: 11/30/2009 17:11:49 ******/
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

declare @idflQuery bigint
select top 1 @idflQuery = idflQuery from tasQuery

EXEC	[dbo].[spAsFolderPost]
		 @strLanguage			= 'en'				
		,@idflFolder			= 9110000002			
		,@idflParentFolder			= null	
		,@strFolderName			= 'some name'			
		,@strDefaultFolderName	= 'default name'	
		,@idflQuery				= @idflQuery		
		

*/ 

CREATE PROCEDURE [dbo].[spAsFolderPost]
	 @strLanguage				nvarchar(50)
	,@idflFolder				bigint
	,@idflParentFolder			bigint
	,@strFolderName				nvarchar(2000)
	,@strDefaultFolderName		nvarchar(2000)
	,@idflQuery					bigint		
AS
BEGIN
	if	not exists	(	
					select	*
					from	tasQuery
					where	idflQuery = @idflQuery
					)
	begin
		Raiserror (N'Query with ID=%I64d doesnt exist.', 15, 1,  @idflQuery)
		return 1
	end

	-- inserting or updating references	
	if (@strLanguage <> 'en')
	begin
		exec spAsReferencePost @strLanguage, @idflFolder,	@strFolderName
	end
	exec spAsReferencePost 'en',			 @idflFolder,	@strDefaultFolderName
	
	-- inserting into Folder
	if not exists	(
					select	* 
					  from	tasLayoutFolder
					 where	idflLayoutFolder = @idflFolder
					)
	begin
        insert into tasLayoutFolder
           (idflLayoutFolder, idflParentLayoutFolder, idflQuery, blnReadOnly)
		values
           (@idflFolder, @idflParentFolder, @idflQuery, 0)
	end
	
	

	return 0

END

GO
