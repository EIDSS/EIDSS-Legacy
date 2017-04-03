SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetLivestockCase]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetLivestockCase]


GO

--##SUMMARY Select data for Livestock Test report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 20.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec spRepVetLivestockCase 11930000241 , 'en'


*/

CREATE  Procedure [dbo].[spRepVetLivestockCase]
    (
        @ObjID	as bigint,
        @LangID as nvarchar(10)
    )
as
	select  
		fnVetCase.strCaseID				as CaseIdentifier,
		fnVetCase.strFieldAccessionID	as FieldAccessionID,
		fnVetCase.datInvestigationDate	as DateOfInvestigation,
		fnVetCase.datEnteredDate		as DataEntryDate,
		fnVetCase.datReportDate			as ReportedDate,
		fnVetCase.datAssignedDate		as AssignedDate,
		fnVetCase.idfSiteID				as SiteID,
		fnVetCase.strEnteredName		as EnteredName,
		fnVetCase.strInvestigationName	as InvestigationName,
		fnVetCase.strReportedName		as ReportedName,
		fnVetCase.strFarmCode			as FarmCode,
		fnVetCase.strNationalName		as FarmName,
		fnVetCase.strFarmerName			as FarmerName,
		fnVetCase.strContactPhone		as FarmPhone,
		fnVetCase.strFax				as FarmFax,
		fnVetCase.strEmail				as FarmEMail,
		fnVetCase.dblLongitude			as FarmLongitude,
		fnVetCase.dblLatitude			as FarmLatitude,
		fnVetCase.strFarmLocation		as FarmLocation,
		fnVetCase.strFarmRegion			as FarmRegion,
		fnVetCase.strFarmRayon			as FarmRayon,
		fnVetCase.strSettlement			as Settlement,
		fnVetCase.strFarmAddress		as FarmAddress,
		fnVetCase.strNote				as Comments,
		
		rfProductionStructureName.[Name]as ProductionStructure,
		rfOwnershipTypeName.[Name]		as OwnershipType,
		rfGrazingPatternName.[Name]		as GrazingPattern,
		rfMovementPatternName.[Name]	as movementPattern

	from		dbo.fnRepGetVetCaseProperties(@LangID) as fnVetCase
	-- Get Farm
	 left join	dbo.tlbFarm		as tFarm
			on	fnVetCase.idfFarm = tFarm.idfFarm
		   
	 left join	fnReference(@LangID, 19000051 /*'rftLivestockProductionType'*/)	as rfProductionStructureName 
			on	rfProductionStructureName.idfsReference = tFarm.idfsLivestockProductionType
	 left join	fnReference(@LangID, 19000065 /*'rftOwnershipType'*/)			as rfOwnershipTypeName
			on	rfOwnershipTypeName.idfsReference = tFarm.idfsOwnershipStructure
	 left join	fnReference(@LangID, 19000037 /*'rftGrazingPattern'*/)			as rfGrazingPatternName 
			on	rfGrazingPatternName.idfsReference = tFarm.idfsGrazingPattern
	 left join	fnReference(@LangID, 19000053 /*'rftMovementPattern'*/)			as rfMovementPatternName
			on	rfMovementPatternName.idfsReference = tFarm.idfsMovementPattern
		 where  fnVetCase.idfCase = @ObjID

			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

