SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRepository_SelectLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRepository_SelectLookup]
GO

CREATE PROCEDURE dbo.spRepository_SelectLookup
	@LangID nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select		idfSubdivision,
				idfFreezer,
				strFreezerName,
				idfsStorageType,
				idfParentSubdivision,
				FreezerBarcode,
				SubdivisionName,
				SubdivisionBarcode,
				[Path],
				[Level]
	from	dbo.fn_RepositorySchema(@LangID,null,null)
	where	idfSubdivision is not null
END
GO
