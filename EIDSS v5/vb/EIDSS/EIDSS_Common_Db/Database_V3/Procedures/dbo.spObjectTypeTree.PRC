SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spObjectTypeTree]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spObjectTypeTree]
GO

/*
exec spObjectTypeTree 'en'
*/

CREATE PROCEDURE dbo.spObjectTypeTree(
@LanguageID  nvarchar(50)
)
AS

SELECT     
		ObjectTypeToObjectType.idfsParentObjectType,
		ObjectTypeToObjectType.idfsRelatedObjectType,
		ObjectTypeToObjectType.idfsStatus,
		parent.[Name] AS ParentName, 
		child.[Name] AS ChildName
FROM         
		trtObjectTypeToObjectType ObjectTypeToObjectType
INNER JOIN
		fnReference(@LanguageID, 19000060 /*'rftObjectType'*/) parent
ON		ObjectTypeToObjectType.idfsParentObjectType = parent.idfsReference
INNER JOIN
		fnReference(@LanguageID, 19000060 /*'rftObjectType'*/) child
ON		ObjectTypeToObjectType.idfsRelatedObjectType = child.idfsReference
INNER JOIN
		trtBaseReference
ON		trtBaseReference.idfsBaseReference=ObjectTypeToObjectType.idfsStatus AND
		trtBaseReference.idfsReferenceType=19000109 AND
		trtBaseReference.intRowStatus=0
WHERE   
		ObjectTypeToObjectType.intRowStatus = 0

--BEGIN relation values
/*
SELECT
		idfsReference,Name
FROM
		fnReference(@LanguageID,19000109)
*/
--WHERE
--		idfsReference in ('brrObjectTypeYES','brrObjectTypeNO')
--END relation values

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

