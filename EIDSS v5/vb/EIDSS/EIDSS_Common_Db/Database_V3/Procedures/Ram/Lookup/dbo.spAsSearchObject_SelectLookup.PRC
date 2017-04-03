SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAsSearchObject_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAsSearchObject_SelectLookup]
GO

--##SUMMARY Selects lookup list of search objects.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 20.04.2010

--##RETURNS Doesn't use

/*
--Example of procedure call:
exec spAsSearchObject_SelectLookup 'en'

*/ 
CREATE          PROCEDURE dbo.spAsSearchObject_SelectLookup
	@LanguageID	as nvarchar(50) --##PARAM @LanguageID - language ID
as


select		tasSearchObject.idfsSearchObject,
			sobRef.[Name],
			tasSearchObject.blnPrimary,
			tasSearchObject.idfsFormType,
			sobRef.intHACode,
			tasSearchObject.idfMainSearchTable
from		tasSearchObject
inner join	fnReference(@LanguageID, 19000082) sobRef  --'rftSearchObject'
on			sobRef.idfsReference = tasSearchObject.idfsSearchObject
order by	sobRef.[Name]


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

