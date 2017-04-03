SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASFarmTree_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASFarmTree_SelectDetail]
GO


 

--##SUMMARY Selects farm tree data. These data includes info about farm and its child herds/species
--##SUMMARY These data are accessible only for farms related with monitoring session  

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 08.07.2010

--##RETURNS Doesn't use
/*
--Example of a call of procedure:
DECLARE @idfMonitoringSession bigint

EXECUTE spASFarmTree_SelectDetail 
	@idfMonitoringSession

*/

CREATE            Proc	spASFarmTree_SelectDetail
		@idfMonitoringSession	bigint--##PARAM @idfMonitoringSession - ID of monitoring session to which farm belongs
As

--0 The Farm tree structure

Select		
	tlbParty.idfParty,
	tlbParty.idfMonitoringSession,  
	tlbParty.idfsPartyType,
	tlbFarm.strFarmCode As strName,
	CAST(NULL as bigint) as idfParentParty,
	tlbFarm.intLivestockTotalAnimalQty as intTotalAnimalQty,
	strNote, 
	idfParty AS idfFarm
From		tlbParty
INNER JOIN tlbFarm ON
	tlbParty.idfParty = tlbFarm.idfFarm
Where	    
	tlbParty.idfMonitoringSession = @idfMonitoringSession
	AND tlbParty.intRowStatus = 0
	AND NOT @idfMonitoringSession IS NULL
--SELECT Herds info related with case/case farm
UNION

Select		
	tlbParty.idfParty,
	tlbParty.idfMonitoringSession,  
	tlbParty.idfsPartyType,
	tlbHerd.strHerdCode As strName,
	tlbHerd.idfFarm as idfParentParty,
	tlbHerd.intTotalAnimalQty,
	tlbHerd.strNote,
	tlbHerd.idfFarm AS idfFarm

From		tlbParty
INNER JOIN tlbHerd ON
	tlbParty.idfParty = tlbHerd.idfHerd
INNER JOIN tlbFarm ON
	tlbHerd.idfFarm = tlbFarm.idfFarm
Where	    
	tlbParty.idfMonitoringSession = @idfMonitoringSession
	AND tlbParty.intRowStatus = 0
	AND NOT @idfMonitoringSession IS NULL


--SELECT Herds spieces info related with case/case herd
UNION
Select		
	tlbParty.idfParty,
	tlbParty.idfMonitoringSession,  
	tlbParty.idfsPartyType,
	CAST(idfsSpeciesType AS NVARCHAR) As strName,
	tlbHerd.idfHerd as idfParentParty,
	tlbSpecies.intTotalAnimalQty,
	tlbSpecies.strNote,
	tlbHerd.idfFarm AS idfFarm
From		tlbParty
INNER JOIN tlbSpecies ON
	tlbParty.idfParty = tlbSpecies.idfSpecies
INNER JOIN tlbHerd ON
	tlbHerd.idfHerd = tlbSpecies.idfHerd
Where	    
	tlbParty.idfMonitoringSession = @idfMonitoringSession
	AND tlbParty.intRowStatus = 0
	AND NOT @idfMonitoringSession IS NULL




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

