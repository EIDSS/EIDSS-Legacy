SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUserGroup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUserGroup]
GO


CREATE PROCEDURE dbo.spUserGroup(
		@ID bigint = NULL, 
		@LanguageID nvarchar(50) = N'en'
		)
AS

	select	tlbEmployeeGroup.idfEmployeeGroup,
			tlbEmployeeGroup.idfsEmployeeGroupName,
			tlbEmployeeGroup.strName,
			GroupName.Name as strNationalName, 
			tlbEmployeeGroup.strDescription
	from	tlbEmployeeGroup
	left join	fnReference(@LanguageID, 19000022) GroupName -- translated group name
	on			GroupName.idfsReference = tlbEmployeeGroup.idfsEmployeeGroupName	
	where	tlbEmployeeGroup.idfEmployeeGroup=@ID

/*
	SELECT 	EG.*, EE.idfsEmployee_Type
	FROM 	EmployeeGroup EG,
			Employee EE
	WHERE EE.idfEmployee = EG.idfEmployee
	AND EE.intRowStatus = 0 
	AND EG.idfEmployee = @ID
*/


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

