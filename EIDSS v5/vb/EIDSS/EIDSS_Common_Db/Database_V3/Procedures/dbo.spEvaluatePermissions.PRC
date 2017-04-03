/****** Object:  StoredProcedure [dbo].[spEvaluatePermissions]    Script Date: 05/06/2008 15:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/****** Object:  StoredProcedure [dbo].[spEvaluatePermissions]    Script Date: 05/06/2008 15:39:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spEvaluatePermissions]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spEvaluatePermissions]

GO
-- =============================================
-- Author:		Kletkin
-- Create date: 14.01.2010
-- Description:	Returns list of all system functions with permissions specified for specific user
-- =============================================
/*
exec spEvaluatePermissions 0 70980000000
*/

CREATE PROCEDURE [dbo].[spEvaluatePermissions](
	@idfEmployee bigint
)
AS
BEGIN

select * from fnEvaluatePermissions(@idfEmployee)
/*
select		trtSystemFunction.idfsSystemFunction,
			trtBaseReference.strBaseReferenceCode,
			trtObjectTypeToObjectOperation.idfsObjectOperation,
			ISNULL(
				min(InstanceUser.intPermission),
				ISNULL(
					min(InstanceDefault.intPermission),
					ISNULL(
						min(TypeUser.intPermission),
						ISNULL(min(TypeDefault.intPermission),2)
					)
				)
			) as intPermission
from		trtSystemFunction
inner join	trtBaseReference
on			trtBaseReference.idfsBaseREference=trtSystemFunction.idfsSystemFunction
inner join	trtObjectTypeToObjectOperation
on			trtSystemFunction.idfsObjectType=trtObjectTypeToObjectOperation.idfsObjectType
--user rights on instance
left join
(
			select		tstObjectAccess.idfsObjectID,
						tstObjectAccess.idfsObjectOperation,
						tstObjectAccess.intPermission
			from		tstObjectAccess
			inner join	fn_ObjectActorRelations(@idfEmployee) Groups
			on			tstObjectAccess.idfActor=Groups.idfEmployee and
						tstObjectAccess.intRowStatus=0 and
						tstObjectAccess.idfsOnSite=dbo.fnSiteID()
)InstanceUser
on			trtSystemFunction.idfsSystemFunction=InstanceUser.idfsObjectID and
			trtObjectTypeToObjectOperation.idfsObjectOperation=InstanceUser.idfsObjectOperation
--default rights on instance
left join
(
			select		tstObjectAccess.idfsObjectID,
						tstObjectAccess.idfsObjectOperation,
						tstObjectAccess.intPermission
			from		tstObjectAccess
			where		tstObjectAccess.idfActor=-1 and
						tstObjectAccess.intRowStatus=0 and
						tstObjectAccess.idfsOnSite=dbo.fnSiteID()
)InstanceDefault
on			trtSystemFunction.idfsSystemFunction=InstanceDefault.idfsObjectID and
			trtObjectTypeToObjectOperation.idfsObjectOperation=InstanceDefault.idfsObjectOperation
--user rights on type
left join
(
			select		tstObjectAccess.idfsObjectOperation,
						tstObjectAccess.idfsObjectType,
						tstObjectAccess.intPermission
			from		tstObjectAccess
			inner join	fn_ObjectActorRelations(@idfEmployee) Groups
			on			tstObjectAccess.idfActor=Groups.idfEmployee and
						tstObjectAccess.intRowStatus=0 and
						tstObjectAccess.idfsObjectID is null and
						tstObjectAccess.idfsOnSite=dbo.fnSiteID()

)TypeUser
on			trtSystemFunction.idfsObjectType=TypeUser.idfsObjectType and
			trtObjectTypeToObjectOperation.idfsObjectOperation=TypeUser.idfsObjectOperation
--default rights on type
left join
(
			select		tstObjectAccess.idfsObjectOperation,
						tstObjectAccess.idfsObjectType,
						tstObjectAccess.intPermission
			from		tstObjectAccess
			inner join	fn_ObjectActorRelations(@idfEmployee) Groups
			on			tstObjectAccess.idfActor=Groups.idfEmployee and
						tstObjectAccess.intRowStatus=0 and
						tstObjectAccess.idfsObjectID is null and
						tstObjectAccess.idfsOnSite=dbo.fnSiteID()
)TypeDefault 
on			trtSystemFunction.idfsObjectType=TypeDefault.idfsObjectType and
			trtObjectTypeToObjectOperation.idfsObjectOperation=TypeDefault.idfsObjectOperation

where		trtSystemFunction.intRowStatus=0 and
			trtBaseReference.intRowStatus=0 and
			trtObjectTypeToObjectOperation.intRowStatus=0

group by	trtSystemFunction.idfsSystemFunction,
			trtBaseReference.strBaseReferenceCode,
			trtObjectTypeToObjectOperation.idfsObjectOperation
*/
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

