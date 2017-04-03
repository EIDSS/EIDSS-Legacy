GO
/****** Object:  StoredProcedure [dbo].[spAsLayoutSelectLookup]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsLayoutSelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsLayoutSelectLookup]

/****** Object:  StoredProcedure [dbo].[spAsLayoutSelectLookup]    Script Date: 11/30/2009 17:11:49 ******/
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

exec spAsLayoutSelectLookup 'en'
exec spAsLayoutSelectLookup 'en', 147490000000


*/ 
 
CREATE PROCEDURE [dbo].[spAsLayoutSelectLookup]
	@LanguageID	as nvarchar(50),
	@LayoutID	as bigint = null,
	@QueryID	as bigint = null
AS
BEGIN

		select	tLayout.idflLayout			as idflLayout,
				tLayout.idflLayoutFolder	as idflFolder,
				refLayout.strEnglishName	as strDefaultLayoutName,
				refLayout.strName			as strLayoutName,
				refDescription.strName		as strDescription,
				tLayout.idflQuery			as idflQuery,
				tLayout.idfUserID			as idfUserID,
				tLayout.blnReadOnly			as blnReadOnly,
				tLayout.blnShareLayout		as blnShareLayout,
				isnull(brLayout.intOrder,0)	as intOrder
				
		  from	dbo.tasLayout			as tLayout
	inner join	dbo.fnLocalReference(@LanguageID)	as refLayout
			on	tLayout.idflLayout = refLayout.idflBaseReference
	 left join	dbo.fnLocalReference(@LanguageID)	as refDescription
			on	tLayout.idflDescription = refDescription.idflBaseReference			
	 left join	trtBaseReference brLayout
			on	brLayout.idfsBaseReference = tLayout.idfsGlobalLayout
		 where	(@QueryID  is null or @QueryID  = tLayout.idflQuery)
		   and	(@LayoutID is null or @LayoutID = tLayout.idflLayout)
	  order by	tLayout.idflQuery, intOrder, refLayout.strName 

END
GO
