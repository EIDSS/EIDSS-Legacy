 SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAvianFarmProduction_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAvianFarmProduction_SelectDetail]
GO



/*
exec spAvianFarmProduction_SelectDetail 53320000000
*/


Create     Proc	spAvianFarmProduction_SelectDetail
		@idfFarm	bigint
As
Select		
	idfFarm,
	idfsAvianFarmType,
	idfsAvianProductionType,
	idfsIntendedUse,
	tlbParty.idfRootParty as idfRootFarm
From		tlbFarm
INNER JOIN tlbParty ON
	tlbFarm.idfFarm = tlbParty.idfParty 
WHERE
	idfFarm=@idfFarm



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

