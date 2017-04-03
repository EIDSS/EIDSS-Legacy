SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spVetFarmTree_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spVetFarmTree_SelectDetail]
GO


 

--##SUMMARY Selects farm tree data. These data includes info about farm and its child herds/species
--##SUMMARY These data are accessible only for case related farms

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.11.2009

--##RETURNS Doesn't use
/*
--Example of a call of procedure:
DECLARE @idfCase bigint

EXECUTE spVetFarmTree_SelectDetail 
	@idfCase
	,710130000000

*/

CREATE            Proc	spVetFarmTree_SelectDetail
		@idfCase	bigint--##PARAM @idfCase - ID of case to which farm belongs
As

DECLARE @CaseType AS BIGINT 
Select 
	@CaseType = idfsCaseType
FROM tlbCase
Where 
	idfCase=@idfCase
	and introwstatus=0

--0 The Farm tree structure

Select		
	tlbParty.idfParty,
	tlbParty.idfCase,  
	tlbParty.idfsPartyType,
	tlbFarm.strFarmCode As strName,
	CAST(NULL as bigint) as idfParentParty,
	tlbFarm.idfObservation,
	tlbObservation.idfsFormTemplate,
	CASE WHEN @CaseType = 10012004/*avian*/ THEN tlbFarm.intAvianTotalAnimalQty ELSE tlbFarm.intLivestockTotalAnimalQty END AS intTotalAnimalQty,
	CASE WHEN @CaseType = 10012004/*avian*/ THEN tlbFarm.intAvianSickAnimalQty ELSE tlbFarm.intLivestockSickAnimalQty END AS intSickAnimalQty,
	CASE WHEN @CaseType = 10012004/*avian*/ THEN tlbFarm.intAvianDeadAnimalQty ELSE tlbFarm.intLivestockDeadAnimalQty END AS intDeadAnimalQty,
	CAST(NULL as int) AS  strAverageAge,
	CAST(NULL AS DATETIME) AS  datStartOfSignsDate,
	strNote
From		tlbParty
INNER JOIN tlbFarm ON
	tlbParty.idfParty = tlbFarm.idfFarm
LEFT OUTER JOIN tlbObservation ON
	tlbObservation.idfObservation = tlbFarm.idfObservation
	AND tlbObservation.intRowStatus = 0
Where	    
	tlbParty.idfCase = @idfCase
	AND tlbParty.intRowStatus = 0

--SELECT Herds info related with case/case farm
UNION

Select		
	tlbParty.idfParty,
	tlbParty.idfCase,  
	tlbParty.idfsPartyType,
	tlbHerd.strHerdCode As strName,
	tlbHerd.idfFarm as idfParentParty,
	CAST(NULL AS bigint) as idfObservation,
	CAST(NULL AS bigint) as idfsFormTemplate,
	tlbHerd.intTotalAnimalQty,
	tlbHerd.intSickAnimalQty,
	tlbHerd.intDeadAnimalQty,
	CAST(NULL as int) AS  strAverageAge,
	CAST(NULL AS DATETIME) AS  datStartOfSignsDate,
	tlbHerd.strNote
From		tlbParty
INNER JOIN tlbHerd ON
	tlbParty.idfParty = tlbHerd.idfHerd
INNER JOIN tlbFarm ON
	tlbHerd.idfFarm = tlbFarm.idfFarm
Where	    
	idfCase = @idfCase
	AND tlbParty.intRowStatus = 0


--SELECT Herds spieces info related with case/case herd
UNION
Select		
	tlbParty.idfParty,
	tlbParty.idfCase,  
	tlbParty.idfsPartyType,
	CAST(idfsSpeciesType AS NVARCHAR) As strName,
	tlbHerd.idfHerd as idfParentParty,
	tlbSpecies.idfObservation,
	tlbObservation.idfsFormTemplate,
	tlbSpecies.intTotalAnimalQty,
	tlbSpecies.intSickAnimalQty,
	tlbSpecies.intDeadAnimalQty,
	tlbSpecies.strAverageAge,
	tlbSpecies.datStartOfSignsDate,
	tlbSpecies.strNote
From		tlbParty
INNER JOIN tlbSpecies ON
	tlbParty.idfParty = tlbSpecies.idfSpecies
INNER JOIN tlbHerd ON
	tlbHerd.idfHerd = tlbSpecies.idfHerd
LEFT OUTER JOIN tlbObservation ON
	tlbObservation.idfObservation = tlbSpecies.idfObservation
	AND tlbObservation.intRowStatus = 0
Where	    
	tlbParty.idfCase = @idfCase
	AND tlbParty.intRowStatus = 0



--EXEC dbo.spVetFarmTree_SelectDetail 'C6BF9591-E727-42C8-807B-179097EE60CA', 'en'






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

