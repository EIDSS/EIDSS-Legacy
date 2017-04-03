SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[spLabMaterialOnSite]    Script Date: 12/28/2009 09:43:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSampleOnSite]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSampleOnSite]
GO

--##SUMMARY Marks material as located on current site.
--##SUMMARY This information used to disallow material modifications.

--##REMARKS Author: Kletkin.

--##RETURNS Nothing


CREATE PROCEDURE spLabSampleOnSite
	@idfMaterial bigint
AS
BEGIN
	declare @site bigint
	
	set @site=dbo.fnSiteID()
	
	update tlbMaterialOnSite
	set idfMaterial=@idfMaterial,idfsSite=@site,intRowStatus=0
	where idfMaterial=@idfMaterial and idfsSite=@site
	
	if( @@ROWCOUNT=0 )
	begin
		insert into tlbMaterialOnSite(idfMaterial,idfsSite)
		values(@idfMaterial,@site)
	end
END
GO

