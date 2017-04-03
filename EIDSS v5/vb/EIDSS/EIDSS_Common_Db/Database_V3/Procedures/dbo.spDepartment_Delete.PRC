SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDepartment_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spDepartment_Delete]
GO



--##SUMMARY Deletes department Record. Called from OrganizationDetail form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use

/*
--Example of procedure call:

DECLARE @ID as bigint
EXEC spDepartment_Delete @ID

*/

CREATE      procedure dbo.spDepartment_Delete( 
	@ID as bigint
)
as
exec spOrganization_Delete @ID




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

