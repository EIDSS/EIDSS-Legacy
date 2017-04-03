/****** Object:  StoredProcedure [dbo].[spGisUpdateUserFeature]    Script Date: 07/26/2010 12:13:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP IF EXIST
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGisUpdateUserFeature]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGisUpdateUserFeature]
GO

-- =============================================
-- Author:		Nikulin, Evgeniy
-- Create date: 22.07.2010
-- Description:	Insert new user feature in the layer
-- Dependences:  
--	  Tables: dbo.gisUserFeature 
--			  dbo.gisUserLayer (inderectly)
-- =============================================


create PROCEDURE [dbo].[spGisUpdateUserFeature] 
	@FEATUREID BIGINT,			--Feature Id for update
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

	UPDATE dbo.gisUserFeature 
		SET strName=@NAME,
			strDescription=@DESC,
			dblRadius=@RADIUS, 
			blbWKBGeometry=@GEOMETRY, 
			dblEnvelopeMinX=@ENVMINX, 
			dblEnvelopeMinY=@ENVMINY, 
			dblEnvelopeMaxX=@ENVMAXX, 
			dblEnvelopeMaxY=@ENVMAXY
	WHERE
			idfFeature=@FEATUREID
END
