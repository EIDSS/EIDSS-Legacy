SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spspecGetFromTranslation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spspecGetFromTranslation]
GO


/*
EXEC spspecGetFromTranslation 'ru'
*/


CREATE     proc spspecGetFromTranslation(@LanguageCode nvarchar(50) = NULL )
as

SET NOCOUNT ON 

update a
set a.strTextString = b.strReference_Text
from dbo.[trtStringNameTranslation] as a
inner join EIDSS_Trans.dbo.tlkpReference as b
on a.idfsBaseReference = b.idfReference
and a.idfsLanguage = dbo.fnGetLanguageCode(CASE b.idfLanguage WHEN 'en-EN' THEN 'en' ELSE b.idfLanguage END)
where (b.idfLanguage = @LanguageCode or @LanguageCode is null)
AND b.idfLanguage <> 'en'
and b.strReference_Text <> ''
AND NOT a.strTextString = b.strReference_Text
PRINT 'Update translation: ' + CAST(@@ROWCOUNT AS VARCHAR(200))

insert into dbo.trtStringNameTranslation
(idfsLanguage, idfsBaseReference, strTextString)
select
dbo.fnGetLanguageCode(b.idfLanguage), b.idfReference, b.strReference_Text
from EIDSS_Trans.dbo.tlkpReference as b
left join dbo.[trtStringNameTranslation] as a
	on a.idfsBaseReference = b.idfReference
	and a.idfsLanguage = dbo.fnGetLanguageCode(b.idfLanguage)
inner join dbo.trtBaseReference as c
	on (c.intRowStatus = 0 or c.intRowStatus is null)
	and c.idfsBaseReference = b.idfReference
where a.idfsBaseReference is null
and ( b.idfLanguage = @LanguageCode or @LanguageCode is null)
PRINT 'Get new translation: ' + CAST(@@ROWCOUNT AS VARCHAR(200))

SET NOCOUNT OFF 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

