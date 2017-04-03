GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsSearchFieldSelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsSearchFieldSelectLookup]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY Select the list of search fields.

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 16.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:
exec spAsSearchFieldSelectLookup 'en'

*/ 
 
create procedure	spAsSearchFieldSelectLookup
	@LanguageID	as nvarchar(50),
	@ObjectID	as bigint = null,
	@ID			as bigint = null
as


select		sf.idfsSearchField,
			sf.strSearchFieldAlias,
			sf_ref.[Name] as FieldCaption,
			sf.strFieldText,
			sf.strConditionText,
			sf.idfSearchTable,
			sf.idfsSearchObject,
			sf.idfsSearchFieldType,
			sf.idfsReferenceType,
			sf.idfsGISReferenceType,
			sf.strLookupTable,
			sf.intMapDisplayOrder,
			case	IsNull(sf.idfsSearchFieldType, -1)
				when	10081006	-- Integer
					then	1
				when	10081004	-- Float
					then	1
				when	10081002	-- Date
					then	7
				when	10081001	-- Bit
					then	8
				else		0		-- String
			end as TypeImageIndex

from		tasSearchField sf
inner join	fnReference(@LanguageID, 19000080) sf_ref	-- 'rftSearchField'
on			sf_ref.idfsReference = sf.idfsSearchField
where		(@ObjectID is null or @ObjectID = sf.idfsSearchObject)
			and (@ID is null or @ID = sf.idfsSearchField)
order by	sf.idfsSearchObject, sf_ref.[Name]



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
