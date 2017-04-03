/****** Object:  StoredProcedure [dbo].[spObjectAccess]    Script Date: 04/17/2008 17:08:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spObjectAccess]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spObjectAccess]
GO

/*
exec spObjectAccess 10094001,10060008,'en'
*/


CREATE   PROCEDURE [dbo].[spObjectAccess](
	@ID bigint = NULL,
	@ObjectType bigint = NULL,
	@LanguageID As nvarchar(50)
)
AS


--select permissions
	select		tstObjectAccess.idfObjectAccess,
				tstObjectAccess.idfsObjectOperation,
				tstObjectAccess.idfsObjectType,
				tstObjectAccess.idfsObjectID,
				tstObjectAccess.idfActor,
				tstObjectAccess.intPermission,
				tstObjectAccess.idfsOnSite
	from		tstObjectAccess
	where		tstObjectAccess.intRowStatus=0 and
				tstObjectAccess.idfsObjectType=@ObjectType and
				(
					(@ID is null and tstObjectAccess.idfsObjectID is null) or
					tstObjectAccess.idfsObjectID=@ID
				)

--select actors

	select		Actors.idfActor,
				Actors.idfsOnSite,
				UG.strName,
				UG.Type,
				--UG.strSiteID,
				UG.strDescription
	from
		(
		select		distinct 
					tstObjectAccess.idfActor,
					tstObjectAccess.idfsOnSite
		from		tstObjectAccess
		where		tstObjectAccess.intRowStatus=0 and
					tstObjectAccess.idfsObjectType=@ObjectType and
					(
					(@ID is null and tstObjectAccess.idfsObjectID is null) or
					tstObjectAccess.idfsObjectID=@ID
					)
		union
		select	-1,
				tstSite.idfsSite
		from	tstSite
		where	tstSite.intRowStatus=0
		)Actors
	inner join	fn_UsersAndGroups_SelectList(@LanguageID) UG
	on			Actors.idfActor=UG.idfEmployee
	--inner join	tlbEmployee
	--on			Actors.idfActor=tlbEmployee.idfEmployee


/*
	select		distinct 
				tstObjectAccess.idfActor,
				tstObjectAccess.idfsOnSite,
				UG.strName,
				UG.Type,
				UG.strSiteID,
				UG.strDescription
	from		tstObjectAccess
	inner join	fn_UsersAndGroups_SelectList(@LanguageID) UG
	on			tstObjectAccess.idfActor=UG.idfEmployee
	where		tstObjectAccess.intRowStatus=0 and
				tstObjectAccess.idfsObjectType=@ObjectType and
				tstObjectAccess.idfsObjectID=@ID
*/

/*
	select		tstObjectAccess.idfObjectAccess,
				tstObjectAccess.idfsObjectOperation,
				tstObjectAccess.idfsObjectType,
				tstObjectAccess.idfsObjectID,
				tstObjectAccess.idfActor,
				tstObjectAccess.intPermission,
				tstObjectAccess.idfsOnSite,
				UG.strName,
				UG.Type,
				UG.strSiteID,
				UG.strDescription
	from		tstObjectAccess
	inner join	fn_UsersAndGroups_SelectList(@LanguageID) UG
	on			tstObjectAccess.idfActor=UG.idfEmployee
	where		tstObjectAccess.intRowStatus=0 and
				tstObjectAccess.idfsObjectType=@ObjectType and
				tstObjectAccess.idfsObjectID=@ID
*/

	select		Operation.idfsObjectOperation,
				--Operation.idfsObjectType,
				Names.Name
	from		trtObjectTypeToObjectOperation Operation
	inner join	fnReference(@LanguageID,19000059) Names--rftObjectOperation
	on			Names.idfsReference=Operation.idfsObjectOperation
	where		Operation.intRowStatus=0 and
				Operation.idfsObjectType=@ObjectType

/*
	select	tstSite.idfsSite,
			tstSite.idfOffice,
			tstSite.strSiteName,
			tstSite.strSiteID
	from	tstSite
	where	tstSite.intRowStatus=0
*/
/*
	SELECT
		ObjectAccess.*,
		OA.idfsObjectOperation,
		OA.intPermission,
		UG.Name as ActorName,
		UG.Description as ActorDescription,
		UG.Type as ActorType,
		UG.Site as ActorSite
	FROM
	(
		SELECT
				idfObjectAccess,
				idfActorID,
				idfsActorType,
				idfsOnSite,
				idfsObjectType,
				idfsObjectID
		FROM	ObjectAccess
		WHERE
				ISNULL(ObjectAccess.idfsObjectID, '') = ISNULL(@ID, '') AND
				ObjectAccess.idfsObjectType = @ObjectType AND
				ObjectAccess.intRowStatus = 0
		UNION
				SELECT NEWID(),'{DEFA0000-0000-0000-0000-000000000000}','acrGroup',idfsSite,@ObjectType,@ID
				FROM fn_site_selectlist(@LanguageID,null)
	)ObjectAccess
	LEFT JOIN ObjectAccess OA 
			ON OA.idfObjectAccess=ObjectAccess.idfObjectAccess
	INNER JOIN
		(SELECT * FROM fn_UsersAndGroups_SelectList('en')
		UNION 
		SELECT '{DEFA0000-0000-0000-0000-000000000000}', 'emtGroup', 'Default', NULL, rf.Name, 'acrGroup',NULL
		FROM fnReference(@LanguageID, 'rftObjectActorType') as rf
		WHERE rf.idfsReference = 'acrGroup'
		) UG 
		ON ObjectAccess.idfActorID = UG.idfEmployee AND ISNULL(UG.Site,ObjectAccess.idfsOnSite)=ObjectAccess.idfsOnSite
*/
/*
	SELECT     OA.*, UG.Name AS ActorName, UG.Description AS ActorDescription, UG.Type AS ActorType, OL.Name AS OperationName, UG.Site AS ActorSite
	FROM
		ObjectAccess OA 
	INNER JOIN
		fn_ObjectOperation_SelectList(@LanguageID,@ObjectType) OL 
		ON OA.idfsObjectOperation = OL.idfsReference 
	INNER JOIN
		(SELECT * FROM fn_UsersAndGroups_SelectList(@LanguageID)
		UNION 
		SELECT '{DEFA0000-0000-0000-0000-000000000000}', 'emtGroup', 'Default', NULL, rf.Name, 'acrGroup',NULL
		FROM fnReference(@LanguageID, 'rftObjectActorType') as rf
		WHERE rf.idfsReference = 'acrGroup'
		) UG 
		ON OA.idfActorID = UG.idfEmployee AND ISNULL(UG.Site,OA.idfsOnSite)=OA.idfsOnSite
	WHERE
		ISNULL(OA.idfsObjectID, '') = ISNULL(@ID, '') AND
		OA.idfsObjectType =@ObjectType AND
		OA.intRowStatus = 0
	ORDER BY OA.idfsObjectID, OA.idfActorID,OA.idfsObjectOperation
*/
/*
	SELECT idfsReference, op.Name
	FROM BaseReferenceRelation brr 
	inner join fnReference(@LanguageID,'rftObjectOperation') op 
		on op.idfsreference=brr.idfsrelatedbasereference and brr.idfsBaseReferenceRelationType='brrObjectTypeToOperation'
	where brr.idfsparentbasereference=@ObjectType
*/