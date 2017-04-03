SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLivestockFarmProduction_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLivestockFarmProduction_Post]
GO





Create    Proc	spLivestockFarmProduction_Post
	@idfFarm bigint,
	@idfRootFarm bigint,
	@idfsOwnershipStructure bigint,
	@idfsLivestockProductionType bigint,
	@idfsGrazingPattern bigint,
	@idfsMovementPattern bigint
As

UPDATE tlbFarm
SET
	idfsOwnershipStructure=@idfsOwnershipStructure,
	idfsLivestockProductionType=@idfsLivestockProductionType,
	idfsGrazingPattern=@idfsGrazingPattern,
	idfsMovementPattern=@idfsMovementPattern
WHERE
	idfFarm=@idfFarm

IF NOT @idfRootFarm is NULL
UPDATE tlbFarm
SET
	idfsOwnershipStructure=@idfsOwnershipStructure,
	idfsLivestockProductionType=@idfsLivestockProductionType,
	idfsGrazingPattern=@idfsGrazingPattern,
	idfsMovementPattern=@idfsMovementPattern
WHERE
	idfFarm=@idfRootFarm



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

