SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPerson_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spPerson_SelectDetail]
GO


--##SUMMARY Selects data for PersonDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 13.12.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:

DECLARE @idfPerson BIGINT 
exec spPerson_SelectDetail @idfPerson, 'en'

*/


CREATE        PROCEDURE dbo.spPerson_SelectDetail
( 
	@idfPerson AS BIGINT  --##PARAM @idfPerson - person ID
	,@LanguageID nvarchar(50) --##PARAM @LanguageID - language ID

)
	
AS
SELECT idfPerson
      ,idfsStaffPosition
      ,idfInstitution
      ,idfDepartment
      ,strFamilyName
      ,strFirstName
      ,strSecondName
      ,strContactPhone
      ,strBarcode
  FROM tlbPerson
INNER JOIN 
	tlbEmployee ON
	tlbPerson.idfPerson=tlbEmployee.idfEmployee
WHERE 
	tlbEmployee.idfEmployee=@idfPerson
	AND tlbEmployee.intRowStatus=0 
	AND tlbEmployee.idfsEmployeeType=10023002 --Person 

--1, User Table
SELECT	 tstUserTable.idfUserID
		,tstUserTable.idfPerson
		,tstUserTable.idfsSite
		,tstUserTable.strAccountName
		--,tstUserTable.strPassword
		,cast(null as nvarchar(max)) as strPassword
		--,tstUserTable.intExpirationPeriod
		--,cast(0 AS BIT) AS MustChangePassword
		--,tstSite.strSiteID
		--,tstSite.strSiteName
		--,ISNULL(dbo.fnReference.Name,dbo.fnReference.strDefault) AS strSiteType
FROM tstUserTable
/*INNER JOIN tstSite ON
	tstSite.idfsSite = tstUserTable.idfsSite
INNER JOIN dbo.fnReference(@LanguageID, 19000085/*Site Type*/) ON
	tstSite.idfsSiteType = dbo.fnReference.idfsReference*/
WHERE
	tstUserTable.idfPerson=@idfPerson
	AND tstUserTable.intRowStatus=0 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

