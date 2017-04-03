SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRootFarmTree_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRootFarmTree_SelectDetail]
GO


 

--##SUMMARY Selects farm tree data. These data includes info about farm and its child herds/species
--##SUMMARY These data are accessible only for case related farms

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use
/*
--Example of a call of procedure:
DECLARE @idfCase bigint

EXECUTE spRootFarmTree_SelectDetail 
	@idfCase

*/

CREATE            Proc	spRootFarmTree_SelectDetail
		@idfFarm	bigint--##PARAM @idfFarm - ID of farm
		,@HACode	int--##PARAM @HACode - HA code of posted tree node (livetock or animal)
As

--0 The Farm tree structure

Select		
	tlbParty.idfParty,
	tlbParty.idfsPartyType,
	tlbFarm.strFarmCode As strName,
	CAST(NULL as bigint) as idfParentParty,
	CASE WHEN (@HACode & 64)<>0/*avian*/ THEN tlbFarm.intAvianTotalAnimalQty ELSE tlbFarm.intLivestockTotalAnimalQty END AS intTotalAnimalQty,
	CASE WHEN (@HACode & 64)<>0/*avian*/ THEN tlbFarm.intAvianSickAnimalQty ELSE tlbFarm.intLivestockSickAnimalQty END AS intSickAnimalQty,
	CASE WHEN (@HACode & 64)<>0/*avian*/ THEN tlbFarm.intAvianDeadAnimalQty ELSE tlbFarm.intLivestockDeadAnimalQty END AS intDeadAnimalQty,
	CAST(NULL as int) AS  strAverageAge,
	CAST(NULL AS DATETIME) AS  datStartOfSignsDate,
	strNote,
	@HACode as HACode
From		tlbParty
INNER JOIN tlbFarm ON
	tlbParty.idfParty = tlbFarm.idfFarm
Where	    
	tlbParty.idfParty = @idfFarm
	AND tlbParty.intRowStatus = 0

--SELECT Herds info related with case/case farm
UNION

Select		
	tlbParty.idfParty,
	tlbParty.idfsPartyType,
	tlbHerd.strHerdCode As strName,
	tlbHerd.idfFarm as idfParentParty,
	tlbHerd.intTotalAnimalQty,
	tlbHerd.intSickAnimalQty,
	tlbHerd.intDeadAnimalQty,
	CAST(NULL as int) AS  strAverageAge,
	CAST(NULL AS DATETIME) AS  datStartOfSignsDate,
	tlbHerd.strNote,
	@HACode as HACode
From		tlbParty
INNER JOIN tlbHerd ON
	tlbParty.idfParty = tlbHerd.idfHerd
INNER JOIN tlbFarm ON
	tlbHerd.idfFarm = tlbFarm.idfFarm
INNER JOIN tlbSpecies ON
	tlbHerd.idfHerd = tlbSpecies.idfHerd
INNER JOIN trtBaseReference ON
	tlbSpecies.idfsSpeciesType = trtBaseReference.idfsBaseReference
	and trtBaseReference.intRowStatus = 0
	and (trtBaseReference.intHACode & @HACode)<>0
Where	    
	tlbHerd.idfFarm = @idfFarm
	AND tlbParty.intRowStatus = 0


--SELECT Herds spieces info related with case/case herd
UNION
Select		
	tlbParty.idfParty,
	tlbParty.idfsPartyType,
	CAST(idfsSpeciesType AS NVARCHAR) As strName,
	tlbHerd.idfHerd as idfParentParty,
	tlbSpecies.intTotalAnimalQty,
	tlbSpecies.intSickAnimalQty,
	tlbSpecies.intDeadAnimalQty,
	tlbSpecies.strAverageAge,
	tlbSpecies.datStartOfSignsDate,
	tlbSpecies.strNote,
	@HACode as HACode
From		tlbParty
INNER JOIN tlbSpecies ON
	tlbParty.idfParty = tlbSpecies.idfSpecies
INNER JOIN trtBaseReference ON
	tlbSpecies.idfsSpeciesType = trtBaseReference.idfsBaseReference
	and trtBaseReference.intRowStatus = 0
	and (trtBaseReference.intHACode & @HACode)<>0
INNER JOIN tlbHerd ON
	tlbHerd.idfHerd = tlbSpecies.idfHerd
Where	    
	tlbHerd.idfFarm = @idfFarm
	AND tlbParty.intRowStatus = 0









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

