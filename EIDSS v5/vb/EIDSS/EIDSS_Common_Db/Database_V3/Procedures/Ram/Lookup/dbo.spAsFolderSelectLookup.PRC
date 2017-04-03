GO
/****** Object:  StoredProcedure [dbo].[spAsFolderSelectLookup]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsFolderSelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsFolderSelectLookup]

/****** Object:  StoredProcedure [dbo].[spAsFolderSelectLookup]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY select layouts for analytical module

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 12.01.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

exec spAsFolderSelectLookup 'en'
exec spAsFolderSelectLookup 'en', 147490000000


*/ 
 
CREATE PROCEDURE [dbo].[spAsFolderSelectLookup]
	@LanguageID	as nvarchar(50),
	@FolderID	as bigint = null,
	@QueryID	as bigint = null
AS
BEGIN
		select	tFolder.idflLayoutFolder		as idflFolder,
				tFolder.idflParentLayoutFolder	as idflParentFolder,
				refFolder.strEnglishName		as strDefaultFolderName,
				refFolder.strName				as strFolderName,
				tFolder.idflQuery				as idflQuery,
				tFolder.blnReadOnly				as blnReadOnly,
				isnull(brFolder.intOrder,0)		as intOrder
				
		  from	dbo.tasLayoutFolder					as tFolder
	inner join	dbo.fnLocalReference(@LanguageID)	as refFolder
			on	tFolder.idflLayoutFolder = refFolder.idflBaseReference
	 left join	trtBaseReference brFolder
			on	brFolder.idfsBaseReference = tFolder.idfsGlobalLayoutFolder
		 where	(@QueryID  is null or @QueryID  = tFolder.idflQuery)
		   and	(@FolderID is null or @FolderID = tFolder.idflLayoutFolder)
	 order by	tFolder.idflQuery, intOrder, refFolder.strName 
	  
	 --  order by tFolder.idflLayoutFolder 
	  

END
GO
