/****** Object:  StoredProcedure [dbo].[spGisInsertUserLayer]    Script Date: 07/26/2010 12:05:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP IF EXIST
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGisInsertUserLayer]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGisInsertUserLayer]
GO


-- =============================================
-- Author:		Nikulin, Evgeniy
-- Create date: 26.07.2010
-- Description:	Insert new user layer
-- Dependences:  
--	  Tables: dbo.gisUserLayer 
-- =============================================


CREATE PROCEDURE [dbo].[spGisInsertUserLayer]
	@NAME  NVARCHAR(256),		--Layer Name
	@USERID BIGINT,				--User Id
	@DESC	NVARCHAR(500),		--Layer description
	@STYLE	XML,				--Layer style
	@GEOMTYPE NVARCHAR(256),	--Type of layer geom
	@PIVOTALLAYER NVARCHAR(256) --Base layer
AS
BEGIN
	SET NOCOUNT ON;
	
	--get new id
	declare @ID bigint
	exec dbo.[spgisGetNewID] @ID output

	--insert new layer
	INSERT INTO dbo.gisUserLayer 
		(idfLayer, strName, datLastUpdate, idfAuthor, strDescription, xmlLayerStyle, strGeomType, strPivotalLayer)
		VALUES (@ID, @NAME, GETDATE(), @USERID, @DESC, @STYLE, @GEOMTYPE, @PIVOTALLAYER);
END
