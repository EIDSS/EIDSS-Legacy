SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spHumanCaseDeduplicationMaterial_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spHumanCaseDeduplicationMaterial_SelectDetail]
GO

--##SUMMARY Selects samples data of two specified human cases (one of them is marked as survivor, 
--##SUMMARY and another case is marked as superseded).

--##REMARKS Author: Mirnaya O.
--##REMARKS Create date: 01.03.2010

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
declare	@SurvivorID		bigint
declare	@SupersededID	bigint
declare	@LangID			varchar(36)

execute	spHumanCaseDeduplicationMaterial_SelectDetail
	@SurvivorID,
	@SupersededID,
	@LangID
*/



create procedure	spHumanCaseDeduplicationMaterial_SelectDetail
(		 @SurvivorID	bigint		--##PARAM @SurvivorID Id of the survivor case
		,@SupersededID	bigint		--##PARAM @SupersededID Id of the superseded case
		,@LangID		varchar(36)	--##PARAM @LangID Language Id
)
as

-- 0 tlbMaterial
select		tlbMaterial.idfMaterial,
			case IsNull(tlbParty.idfCase, -1)
				when @SurvivorID
					then 'Survivor'
				when @SupersededID
					then 'Superseded'
				else 'None'
			end as rowType,
			tlbMaterial.strFieldBarcode,
			tlbMaterial.idfsSpecimenType,
			SampleType.[Name] as SampleType_Name,
			tlbMaterial.datFieldCollectionDate,
			tlbMaterial.datFieldSentDate,
			IsNull(Testing.TestQuantity, 0) as TestQuantity,
			case 
				when	IsNull(Testing.TestQuantity, 0) = 0 
						and IsNull(MaterialOnSite.Used, 0) = 0
					then	cast(0 as bit)
				else		cast(1 as bit)
			end as AddToSurvivorCase,
			case
				when	IsNull(MaterialOnSite.Used, 0) > 0 
					then	cast(0 as bit)
				else		cast(1 as bit)
			end as CanRemoveFromSurvivorCase
from		tlbMaterial
inner join	tlbParty
on			tlbParty.idfParty = tlbMaterial.idfParty
			and tlbParty.intRowStatus = 0
left join	fnReference(@LangID, 19000087) SampleType	-- rftSpecimenType
on			SampleType.idfsReference = tlbMaterial.idfsSpecimenType
left join	(
	select		tlbMaterialOnSite.idfMaterial, count(*) as Used
	from		tlbMaterialOnSite
	where		tlbMaterialOnSite.intRowStatus = 0
	group by	tlbMaterialOnSite.idfMaterial
			) MaterialOnSite
on			MaterialOnSite.idfMaterial = tlbMaterial.idfMaterial
left join	(
	select		tlbContainer.idfMaterial, count(*) as TestQuantity
	from		tlbTesting
	inner join	tlbContainer
	on			tlbContainer.idfContainer = tlbTesting.idfContainer
				and tlbContainer.intRowStatus = 0
	where		tlbTesting.intRowStatus = 0
	group by	tlbContainer.idfMaterial
			)	Testing
on			Testing.idfMaterial = tlbMaterial.idfMaterial
where		tlbMaterial.intRowStatus = 0
			and (	tlbParty.idfCase = @SurvivorID
					or tlbParty.idfCase = @SupersededID)



SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

