SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDepartment_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spDepartment_SelectLookup]
GO




CREATE  procedure dbo.spDepartment_SelectLookup
	@LanguageID as nvarchar(50),
	@OrganizationID as bigint = null,
	@ID as bigint = NULL

as
select	idfDepartment, idfInstitution, [Name]
from	dbo.fnDepartment(@LanguageID) 
where	(@OrganizationID is null 
		or idfInstitution = @OrganizationID)
		and (@ID IS NULL OR @ID = idfDepartment)

order by [Name]




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

