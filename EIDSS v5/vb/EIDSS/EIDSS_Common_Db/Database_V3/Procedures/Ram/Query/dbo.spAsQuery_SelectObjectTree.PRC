SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAsQuery_SelectObjectTree]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAsQuery_SelectObjectTree]
GO

--##SUMMARY This procedure selects the tree of related query search objects.

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 21.04.2010

--##RETURNS Don't use

/*
--Example of a call of procedure:

declare	@ID	bigint
exec spAsQuery_SelectObjectTree @ID, 'en'
*/ 


create procedure	spAsQuery_SelectObjectTree
	@ID	bigint,
	@LangID		nvarchar(50)
as

select		rootObj.idflQuery,
			case
				when	childObj.idfQuerySearchObject = rootObj.idfQuerySearchObject
					then	null
				else		rootObj.idfQuerySearchObject
			end as idfParentQuerySearchObject,
			childObj.idfQuerySearchObject,
			childObj.idfsSearchObject,
			childObj.intOrder

from		tasQuerySearchObject rootObj

inner join	(
	tasSearchObject rootSOB
	inner join	trtBaseReference rootBR_SOB
	on			rootBR_SOB.idfsBaseReference = rootSOB.idfsSearchObject
				and rootBR_SOB.intRowStatus = 0
			)
on			rootSOB.idfsSearchObject = rootObj.idfsSearchObject
			and rootSOB.blnPrimary = 1
 
inner join	tasQuerySearchObject childObj
on			(	(childObj.idfParentQuerySearchObject = rootObj.idfQuerySearchObject)
				or (childObj.idfQuerySearchObject = rootObj.idfQuerySearchObject))
			and childObj.idflQuery = rootObj.idflQuery

where		rootObj.idflQuery = @ID
			and rootObj.idfParentQuerySearchObject is null

order by	idfParentQuerySearchObject, childObj.intOrder, childObj.idfsSearchObject


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

