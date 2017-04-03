SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepVetAvianCase]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepVetAvianCase]


GO

--##SUMMARY Select data for Avian Test report.
--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 20.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:

exec dbo.spRepVetAvianCase @LangID=N'ru',@ObjID=25970000002

*/

CREATE  Procedure [dbo].[spRepVetAvianCase]
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
		rfTypeOfFarmName.[Name]			as TypeOfFarm,
		rfProductionName.[Name]			as ProductionType,
		rfIntendedUseName.[Name]		as IntendedUse,
		fnVetCase.strFarmAddress		as FarmAddress

	from		dbo.fnRepGetVetCaseProperties(@LangID) as fnVetCase
	-- Get Farm
	 left join	dbo.tlbFarm		as tFarm
			on	fnVetCase.idfFarm = tFarm.idfFarm
	-- Get Avian farm parameters
	 left join	fnReference(@LangID, 19000008 /*'rftAvianFarmType'*/)		as rfTypeOfFarmName 
			on	rfTypeOfFarmName.idfsReference = tFarm.idfsAvianFarmType
	 left join	fnReference(@LangID, 19000009 /*'rftAvianProductionType'*/) as rfProductionName 
			on	rfProductionName.idfsReference = tFarm.idfsAvianProductionType
	 left join	fnReference(@LangID, 19000026 /*'rftFarmIntendedUse'*/)		as rfIntendedUseName 
			on	rfIntendedUseName.idfsReference = tFarm.idfsIntendedUse
	     where  fnVetCase.idfCase = @ObjID
	     
			
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

