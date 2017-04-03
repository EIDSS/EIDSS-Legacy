GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsParameterSelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsParameterSelectLookup]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY Select the list of parameters related to corresponding search fields.

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 19.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:
exec spAsParameterSelectLookup 'en'

*/ 
 
create procedure	spAsParameterSelectLookup
	@LanguageID	as nvarchar(50),
	@FormType	as bigint = null,
	@ID			as bigint = null
as

select		sf.strSearchFieldAlias + '__' + 
			cast(p.idfsFormType as varchar(20)) + '__' + 
			cast(p.idfsParameter as varchar(20)) as FieldAlias,
			p.idfsFormType,
			ft_ref.[Name] as FormTypeName,
			sob.idfsSearchObject,
			sf.idfsSearchField,
			sf.strSearchFieldAlias,
			p.idfsParameter,
			p_ref.[Name] as ParameterName,
			p.idfsSection,
			p.idfsParameterCaption,
			p.idfsParameterType,
			pt.idfsReferenceType,
			p.idfsEditor,
			p.strNote,
			p.intOrder,
			p.intHACode,
			case	IsNull(p.idfsParameterType, -1)
				when	10071007	-- Numeric
					then	1
				when	10071061	-- Numeric Integer
					then	1
				when	10071059	-- Numeric Natural
					then	1
				when	10071060	-- Numeric Positive
					then	1
				when	10071029	-- Date
					then	7
				when	10071030	-- DateTime
					then	7
				when	10071025	-- Boolean
					then	8
				else		0		-- String
			end as TypeImageIndex

from		(
	ffParameter p
	inner join	fnReference(@LanguageID, 19000066) p_ref		-- 'rftParameter'
	on			p_ref.idfsReference = p.idfsParameter
			)
Inner Join	ffParameterType pt 
	on			p.idfsParameterType = pt.idfsParameterType
				and PT.[intRowStatus] = 0    
inner join	(
	tasSearchObject sob
	inner join	trtBaseReference br_sob
	on			br_sob.idfsBaseReference = sob.idfsSearchObject
				and br_sob.intRowStatus = 0
	inner join	tasSearchField sf
	on			sf.idfsSearchObject = sob.idfsSearchObject
				and sf.idfsSearchFieldType = 10081003			-- FF Field
	inner join	trtBaseReference br_sf
	on			br_sf.idfsBaseReference = sf.idfsSearchField
				and br_sf.intRowStatus = 0
			)
on			sob.idfsFormType = p.idfsFormType
inner join	fnReference(@LanguageID, 19000034) ft_ref			-- 'rftFFType'
on			ft_ref.idfsReference = p.idfsFormType
where		p.intRowStatus = 0
			and (@FormType is null or p.idfsFormType = @FormType)
			and (@ID is null or p.idfsParameter = @ID)
order by	ft_ref.[Name], p.idfsFormType, p.intOrder, p_ref.[Name], p.idfsParameter



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
