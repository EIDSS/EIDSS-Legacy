SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSample_Store]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSample_Store]
GO

CREATE PROCEDURE [dbo].[spLabSample_Store]
	@idfContainer bigint,
	@idfSubdivision bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	exec spFreezerSubdivision_Validate @idfSubdivision=@idfSubdivision, @idfContainer=@idfContainer
	
	UPDATE	tlbContainer
	SET		idfSubdivision=@idfSubdivision WHERE idfContainer=@idfContainer
/*
	UPDATE Lab_Location SET idfContainer = NULL WHERE idfContainer = @idfContainer

	IF @idfsSubdivisionID IS NOT NULL
	BEGIN
	--store in freezer
		SELECT TOP 1 @idfLocation = idfLocationID FROM Lab_Location WHERE idfsSubdivisionID = @idfsSubdivisionID AND idfContainer IS NULL
		IF @idfLocation IS NULL
		BEGIN
		   --RAISERROR ('No free places on location %s', 16, 1, @idfsSubdivisionID)
		   RAISERROR ('No free places',16,1)
		   --ROLLBACK TRANSACTION
		END
		UPDATE Lab_Location SET idfContainer = @idfContainer WHERE idfLocationID = @idfLocation
	END
*/
END
GO