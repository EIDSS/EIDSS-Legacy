SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRepositoryScheme_CanDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRepositoryScheme_CanDelete]
GO

CREATE PROCEDURE spRepositoryScheme_CanDelete
	@ID AS bigint,
	@Result AS BIT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	set @Result=1

	declare @VialsCount as int
	select @VialsCount=count(*)
	from		tlbContainer
	inner join	tlbFreezerSubdivision
	on			tlbFreezerSubdivision.idfSubdivision=tlbContainer.idfSubdivision and
				tlbFreezerSubdivision.idfFreezer=@ID and
				tlbContainer.idfsContainerStatus in (10015007,10015003,10015002) and--accessioned or marked
				tlbContainer.intRowStatus=0 and
				tlbFreezerSubdivision.intRowStatus=0

	if (@VialsCount <> 0) begin
		set @Result=0
	end

END
GO

