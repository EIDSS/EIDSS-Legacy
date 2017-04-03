/****** Object:  StoredProcedure [dbo].[spGisInsertUserFeature]    Script Date: 07/26/2010 12:12:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP IF EXIST
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGisInsertUserFeature]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGisInsertUserFeature]
GO

-- =============================================
-- Author:		Nikulin, Evgeniy
-- Create date: 22.07.2010
-- Description:	Insert new user feature in the layer
-- Dependences:  
--	  Tables: dbo.gisUserFeature 
--			  dbo.gisUserLayer (inderectly)
-- =============================================


CREATE PROCEDURE [dbo].[spGisInsertUserFeature] 
	@LAYERID BIGINT,			--User Layer Id
	@NAME  NVARCHAR(256),		--Feature Name
	@DESC	NVARCHAR(500),		--Feature description
	@RADIUS	REAL,				--Feature radius
	@GEOMETRY IMAGE,			--Feature geometry
	@ENVMINX  REAL,				--Envelope coord...
	@ENVMINY REAL,
	@ENVMAXX REAL,
	@ENVMAXY REAL	
AS
BEGIN
	SET NOCOUNT ON;

	--get new id
	declare @ID bigint
	exec dbo.[spgisGetNewID] @ID output

	--insert new feature
	INSERT INTO dbo.gisUserFeature 
		(idfFeature, idfLayer, strName, strDescription, dblRadius, blbWKBGeometry, dblEnvelopeMinX, dblEnvelopeMinY, dblEnvelopeMaxX, dblEnvelopeMaxY)
		VALUES (@ID, @LAYERID, @NAME, @DESC, @RADIUS, @GEOMETRY, @ENVMINX, @ENVMINY, @ENVMAXX, @ENVMAXY);
END
