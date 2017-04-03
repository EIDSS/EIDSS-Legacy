SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spProphilacticActionList_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spProphilacticActionList_SelectLookup]
GO


--exec dbo.spProphilacticActionList_SelectLookup 'en'


CREATE      procedure spProphilacticActionList_SelectLookup
	(@LanguageID as nvarchar(50))
as

select		b.idfsBaseReference as idfsReference, 
			IsNull(c.strTextString, b.strDefault) as [Name], 
			p.strActionCode,
			b.intOrder,
			b.intRowStatus
from		dbo.trtBaseReference as b 
inner join	dbo.trtProphilacticAction p 
on			p.idfsProphilacticAction = b.idfsBaseReference
left join	dbo.trtStringNameTranslation as c 
on			b.idfsBaseReference = c.idfsBaseReference and c.idfsLanguage = dbo.fnGetLanguageCode(@LanguageID)
			and b.idfsReferenceType = 19000074--rftProphilacticActionList
where
			(b.intHACode is null or b.intHACode & 97 > 0)
order by	IsNull(b.intOrder, 0), [Name] 



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

