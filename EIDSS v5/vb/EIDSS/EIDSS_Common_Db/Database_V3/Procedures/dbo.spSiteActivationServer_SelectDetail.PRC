SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSiteActivationServer_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSiteActivationServer_SelectDetail]
GO





--##SUMMARY Selects data for SiteActivationServerDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 24.02.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:
DECLARE @SiteID bigint
SET @SiteID = 2
EXECUTE spSiteActivationServer_SelectDetail
   @SiteID
  ,'en'


*/


CREATE          PROCEDURE dbo.spSiteActivationServer_SelectDetail (
	@SiteID AS BIGINT,--##PARAM @SiteID  - site ID
	@LangID AS NVARCHAR(50)--##PARAM @LANGID  - language ID
)

AS
--0 tstSite
SELECT 
	idfsSite, 
	strSiteID,
	strSiteName, 
	strServerName,
	idfsSiteType, 
	idfsCountry, 
	idfOffice
FROM tstSite
WHERE 
	idfsSite = @SiteID
	AND intRowStatus=0
/*
Parent/child relation processing is commented until clear requirements on this part

--1 Parent_Site_Relation
SELECT
	tstSiteRelation.idfSiteRelation,
	tstSiteRelation.idfsParentSite,
	tstSiteRelation.idfsRelativeSite,
	tstSiteRelation.idfsSiteRelationType
FROM	tstSiteRelation
	left outer join tstSite
	  on tstSite.idfsSite = tstSiteRelation.idfsParentSite
	     and tstSite.intRowStatus = 0
	left outer join fnInstitution(@LangID) Inst 
	  on Inst.idfOffice = tstSite.idfOffice
WHERE
	tstSiteRelation.idfsRelativeSite = @SiteID
	and tstSiteRelation.idfsSiteRelationType = 10084002 --'srtSubordinated'
	and tstSiteRelation.intRowStatus = 0

--2 Child_Site_Relation
SELECT
	tstSiteRelation.idfSiteRelation,
	tstSiteRelation.idfsParentSite,
	tstSiteRelation.idfsRelativeSite,
	tstSiteRelation.idfsSiteRelationType,
	tstSite.idfsSiteType,
	Inst.[Name] As OfficeName, 
        Inst.[Abbreviation] As OfficeAbbreviation
FROM	tstSiteRelation
	left outer join tstSite
	  on tstSite.idfsSite = tstSiteRelation.idfsRelativeSite
	     and tstSite.intRowStatus = 0
	left outer join fnInstitution(@LangID) Inst 
	  on Inst.idfOffice = tstSite.idfOffice
WHERE
	tstSiteRelation.idfsParentSite = @SiteID
	and tstSiteRelation.idfsSiteRelationType = 10084002 --'srtSubordinated'
	and tstSiteRelation.intRowStatus = 0

--3 NotificationTo
SELECT
	tstSiteRelation.idfSiteRelation,
	tstSiteRelation.idfsParentSite,
	tstSiteRelation.idfsRelativeSite,
	tstSiteRelation.idfsSiteRelationType,
	tstSite.idfsSiteType,
	Inst.[Name] As OfficeName, 
        Inst.[Abbreviation] As OfficeAbbreviation
FROM	tstSiteRelation
	left outer join tstSite
	  on tstSite.idfsSite = tstSiteRelation.idfsRelativeSite
	     and tstSite.intRowStatus = 0
	left outer join fnInstitution(@LangID) Inst 
	  on Inst.idfOffice = tstSite.idfOffice
WHERE
	tstSiteRelation.idfsParentSite = @SiteID
	and tstSiteRelation.idfsSiteRelationType = 10084001 --'srtNotificationTo'
	and tstSiteRelation.intRowStatus = 0

--4 NotificationFrom
SELECT
	tstSiteRelation.idfSiteRelation,
	tstSiteRelation.idfsParentSite,
	tstSiteRelation.idfsRelativeSite,
	tstSiteRelation.idfsSiteRelationType,
	tstSite.idfsSiteType,
	Inst.[Name] As OfficeName, 
        Inst.[Abbreviation] As OfficeAbbreviation
FROM	tstSiteRelation
	left outer join tstSite
	  on tstSite.idfsSite = tstSiteRelation.idfsParentSite
	left outer join fnInstitution(@LangID) Inst 
	  on Inst.idfOffice = tstSite.idfOffice
WHERE
	tstSiteRelation.idfsRelativeSite = @SiteID
	and tstSiteRelation.idfsSiteRelationType = 10084001--'srtNotificationTo'
	and tstSiteRelation.intRowStatus = 0
*/




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

