SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSanitaryActionList_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSanitaryActionList_SelectLookup]
GO



--exec dbo.spSanitaryActionList_SelectLookup 'en'


CREATE      procedure dbo.spSanitaryActionList_SelectLookup
	(@LanguageID as nvarchar(50))
as

select		b.idfsBaseReference as idfsReference, 
			IsNull(c.strTextString, b.strDefault) as [Name], 
			s.strActionCode,
			b.intOrder,
			b.intRowStatus
from		dbo.trtBaseReference as b 
inner join	trtSanitaryAction s 
on			s.idfsSanitaryAction = b.idfsBaseReference 
left join	dbo.trtStringNameTranslation as c 
on			b.idfsBaseReference = c.idfsBaseReference and c.idfsLanguage = dbo.fnGetLanguageCode(@LanguageID)
			and b.idfsReferenceType = 19000079--rftSanitaryActionList
where
			(b.intHACode is null or b.intHACode & 97 > 0)

order by	IsNull(b.intOrder, 0), [Name] 



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

