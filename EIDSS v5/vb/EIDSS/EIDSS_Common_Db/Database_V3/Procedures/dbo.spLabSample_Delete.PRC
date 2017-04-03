SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spLabSample_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spLabSample_Delete]
GO

CREATE PROCEDURE [dbo].[spLabSample_Delete] 
	@idfMaterial bigint
AS
BEGIN

delete	tlbMaterial
where	idfMaterial=@idfMaterial

END

GO