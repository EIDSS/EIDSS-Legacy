SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAsSearchObjectToSearchObject_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAsSearchObjectToSearchObject_SelectLookup]
GO


--##SUMMARY This procedure selects the list of search objects' relations.

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 21.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:
exec spAsSearchObjectToSearchObject_SelectLookup 'en'

*/ 

create procedure	spAsSearchObjectToSearchObject_SelectLookup
	@LanguageID	as nvarchar(50),
	@ID			as bigint = null
as


select		sobPrimary.idfsSearchObject as idfsParentSearchObject,
			sobPrimaryRef.[Name] as ParentSearchObjectName,
			sobChild.idfsSearchObject as idfsChildSearchObject,
			sobChildRef.[Name] as ChildSearchObjectName

from		tasSearchObjectToSearchObject sob_to_sob

inner join	(
	tasSearchObject sobPrimary
	inner join	fnReference(@LanguageID, 19000082) sobPrimaryRef		-- 'rftSearchObject'
	on			sobPrimaryRef.idfsReference = sobPrimary.idfsSearchObject
			)
on			sobPrimary.idfsSearchObject = sob_to_sob.idfsParentSearchObject
			and sobPrimary.blnPrimary = 1

inner join	(
	tasSearchObject sobChild
	inner join	fnReference(@LanguageID, 19000082) sobChildRef			-- 'rftSearchObject'
	on			sobChildRef.idfsReference = sobChild.idfsSearchObject
			)
on			sobChild.idfsSearchObject = sob_to_sob.idfsRelatedSearchObject

where		(@ID is null or @ID = sobPrimary.idfsSearchObject)

order by	sobPrimaryRef.[Name], sobPrimary.idfsSearchObject, 
			sobChildRef.[Name], sobChild.idfsSearchObject


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

