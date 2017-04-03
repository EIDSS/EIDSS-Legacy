SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepositoryScheme_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepositoryScheme_Delete]
GO

CREATE  PROCEDURE dbo.spRepositoryScheme_Delete
	@ID as bigint
 AS
--dbo.tlbContainer
declare @VialsCount as int
--set @VialsCount = (
	select @VialsCount=count(*)
	from		tlbContainer
	inner join	tlbFreezerSubdivision
	on			tlbFreezerSubdivision.idfSubdivision=tlbContainer.idfSubdivision and
				tlbFreezerSubdivision.idfFreezer=@ID and
				tlbContainer.idfsContainerStatus=10015007 and--accessioned
				tlbContainer.intRowStatus=0 and
				tlbFreezerSubdivision.intRowStatus=0
--)
if (@VialsCount <> 0) begin
	raiserror ('OperFailed nonzero vials amount', 16, 1)
	rollback transaction
	return
end
--select idfsSubdivisionID into #table from FreezerSubdivision where idfsFreezerID = @ID

--update tlbFreezerSubdivision set idfsParentSubdivision = NULL 
--	where FreezerSubdivision.idfsFreezerID = @ID

DELETE FROM tlbFreezerSubdivision
WHERE idfFreezer = @ID

DELETE FROM tlbFreezer
WHERE idfFreezer = @ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

