SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLivestockFarmProduction_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLivestockFarmProduction_SelectDetail]
GO






Create    Proc	spLivestockFarmProduction_SelectDetail
		@idfFarm	bigint
As
Select		
	idfFarm,
	idfsOwnershipStructure,
	idfsLivestockProductionType,
	idfsGrazingPattern,
	idfsMovementPattern,
	tlbParty.idfRootParty as idfRootFarm
From		tlbFarm
INNER JOIN tlbParty ON
	tlbFarm.idfFarm = tlbParty.idfParty 
WHERE idfFarm=@idfFarm


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

