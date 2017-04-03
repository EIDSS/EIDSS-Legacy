SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSample_Post]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSample_Post]
GO

CREATE PROCEDURE [dbo].[spLabSample_Post]
	@idfContainer bigint,
	@idfSubdivision bigint,
	@idfInDepartment bigint=NULL,
	@strNote nvarchar(500)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	EXEC spLabSample_Store @idfSubdivision=@idfSubdivision,@idfContainer=@idfContainer

	UPDATE	tlbContainer
	SET		--idfSubdivision=@idfSubdivision,
			idfInDepartment=@idfInDepartment,
			strNote=@strNote
	WHERE idfContainer=@idfContainer

END
GO