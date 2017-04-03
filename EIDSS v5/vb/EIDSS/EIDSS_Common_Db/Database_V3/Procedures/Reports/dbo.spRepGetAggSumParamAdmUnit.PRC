SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepGetAggSumParamAdmUnit]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepGetAggSumParamAdmUnit]

GO

--##SUMMARY Select Date and admin unit list for aggregate report.

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 03.12.2009

--##RETURNS Doesn't use


/*
--Example of a call of procedure:

exec spRepGetAggSumParamAdmUnit 
'<?xml version="1.0" encoding="UTF-16"?><ROOT><AdminLevel AreaType="satCountry"><AdminUnit AdminUnitID="170000000" /></AdminLevel><TimeInterval PeriodType="sptYear"><TimeIntervalUnit StartDate="2009-01-01" FinishDate="2009-12-31" /><TimeIntervalUnit StartDate="2008-01-01" FinishDate="2008-12-31" /></TimeInterval></ROOT>', 
'ru'

*/

CREATE  Procedure [dbo].[spRepGetAggSumParamAdmUnit]
	(
	    @AggrXml nvarchar(4000),
	    @LangID NVARCHAR(36)
	)
AS	
	declare @idoc int
	exec sp_xml_preparedocument @idoc OUTPUT, @AggrXml

	 SELECT
	 (	
		ISNULL(rfCountry.[Name],'') + ISNULL(rfRegion.[Name],'') +
		ISNULL(rfRayon.[NAME],'') + ISNULL(rfSettlement.[Name],'')
	 )	AS AdmUnitName
	 FROM		OPENXML (@idoc, '/ROOT/AdminLevel/AdminUnit', 1)
				WITH	(AdminUnitID  bigint)
 	 left join	fnGisReference(@LangID, 19000001 /*'rftCountry'*/) rfCountry 
			on	rfCountry.idfsReference = AdminUnitID
	 left join	fnGisReference(@LangID, 19000003 /*'rftRegion'*/)  rfRegion 
			on	rfRegion.idfsReference = AdminUnitID
	 left join	fnGisReference(@LangID, 19000002 /*'rftRayon'*/)   rfRayon 
			on	rfRayon.idfsReference = AdminUnitID
	 left join	fnGisReference(@LangID, 19000004 /*'rftSettlement'*/) rfSettlement
			on	rfSettlement.idfsReference = AdminUnitID

	exec sp_xml_removedocument @idoc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

