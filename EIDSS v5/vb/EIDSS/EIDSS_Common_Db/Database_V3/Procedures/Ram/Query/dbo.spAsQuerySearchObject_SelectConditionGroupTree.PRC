GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAsQuerySearchObject_SelectConditionGroupTree]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAsQuerySearchObject_SelectConditionGroupTree]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY This procedure selects the tree of query condition groups 
--##SUMMARY related to specified query search object.

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 20.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

declare	@ID	bigint
exec spAsQuerySearchObject_SelectConditionGroupTree @ID, 'en'
*/ 
 
create procedure	spAsQuerySearchObject_SelectConditionGroupTree
	@ID			bigint,
	@LangID		nvarchar(50)
as

-- tasQueryConditionGroup
select		
			ROW_NUMBER() OVER (ORDER BY qcg.idfParentQueryConditionGroup, qcg.intOrder, qcg.idfQueryConditionGroup )as idfCondition ,
			qcg.idfParentQueryConditionGroup,
			qcg.idfQueryConditionGroup,
			qcg.intOrder,
			qcg.idfQuerySearchObject,
			qcg.blnJoinByOr,
			qcg.blnUseNot,
			qsfc.idfQuerySearchFieldCondition,
			'' as SearchFieldConditionText,
			qsfc.strOperator,
			qsfc.intOperatorType,
			qsfc.idfQuerySearchField,
			qsfc.blnUseNot as blnFieldConditionUseNot,
			qsfc.varValue
from		tasQueryConditionGroup qcg
left join	(
	tasQuerySearchFieldCondition qsfc
	inner join	(
		tasQuerySearchField qsf
		left join	fnReference(@LangID, 19000080) sf_ref		-- 'rftSearchField'
		on			sf_ref.idfsReference = qsf.idfsSearchField
				)
	on			qsf.idfQuerySearchField = qsfc.idfQuerySearchField
			)
on			qsfc.idfQueryConditionGroup = qcg.idfQueryConditionGroup
			and qsf.idfQuerySearchObject = qcg.idfQuerySearchObject
where		qcg.idfQuerySearchObject = @ID
order by	qcg.idfParentQueryConditionGroup, qcg.intOrder, qcg.idfQueryConditionGroup
			

GO
