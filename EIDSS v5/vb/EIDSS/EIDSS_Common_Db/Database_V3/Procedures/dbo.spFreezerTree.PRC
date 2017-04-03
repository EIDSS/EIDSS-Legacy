SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFreezerTree]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spFreezerTree]
GO

/*
exec spFreezerTree

*/

CREATE    PROCEDURE [dbo].[spFreezerTree]
as

	select		Locations.*,
				isnull(Usage.intUsed,0) as intUsed
	from		dbo.fn_RepositorySchema(null,null,null) Locations
	left join	(
				select idfSubdivision, count(*) as intUsed
				from	tlbContainer
				where	tlbContainer.idfsSite=dbo.fnSiteID()
				group by idfSubdivision
				)Usage
	on			Usage.idfSubdivision=Locations.idfSubdivision




