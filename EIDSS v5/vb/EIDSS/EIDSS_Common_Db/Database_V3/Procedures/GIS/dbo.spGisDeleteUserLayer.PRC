/****** Object:  StoredProcedure [dbo].[spGisDeleteUserLayer]    Script Date: 07/26/2010 12:38:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- DROP IF EXIST
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGisDeleteUserLayer]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGisDeleteUserLayer]
GO
-- =============================================
-- Author:		Nikulin, Evgeniy
-- Create date: 26.07.2010
-- Description:	Delete user db layer with all its features
-- Dependences:  
--	  Tables: dbo.gisUserLayer
--			  dbo.gisUserFeature 
-- =============================================


CREATE PROCEDURE [dbo].[spGisDeleteUserLayer] 
	@LAYERID BIGINT		--ID of LAYER for DELETE
AS
BEGIN
	BEGIN TRAN
		DELETE FROM dbo.gisUserFeature
		WHERE idfLayer=@LAYERID;

		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			RETURN @@ERROR
		END	

		DELETE FROM dbo.gisUserLayer 
		WHERE	idfLayer=@LAYERID;

		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRAN
			RETURN @@ERROR
		END
	COMMIT TRAN
END
