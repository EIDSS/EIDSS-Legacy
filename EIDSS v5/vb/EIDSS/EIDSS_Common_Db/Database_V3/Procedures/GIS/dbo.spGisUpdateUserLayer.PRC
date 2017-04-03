/****** Object:  StoredProcedure [dbo].[spGisUpdateUserLayer]    Script Date: 07/26/2010 12:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP IF EXIST
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGisUpdateUserLayer]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGisUpdateUserLayer]
GO

-- =============================================
-- Author:		Nikulin, Evgeniy
-- Create date: 26.07.2010
-- Description:	update user db layer properties
-- Dependences:  
--	  Tables: dbo.gisUserLayer 
-- =============================================


CREATE PROCEDURE [dbo].[spGisUpdateUserLayer] 
	@LAYERID BIGINT,		--LAYER ID for update
	@NAME  NVARCHAR(256),	--Layer Name
	@USERID BIGINT,			--User Id
	@DESC	NVARCHAR(500),	--Layer description
	@STYLE	XML				--Layer style
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE	dbo.gisUserLayer 
		SET strName=@NAME, 
			datLastUpdate=GETDATE(), 
			idfAuthor=@USERID,
			strDescription=@DESC, 
			xmlLayerStyle=@STYLE
	WHERE	idfLayer=@LAYERID
END
