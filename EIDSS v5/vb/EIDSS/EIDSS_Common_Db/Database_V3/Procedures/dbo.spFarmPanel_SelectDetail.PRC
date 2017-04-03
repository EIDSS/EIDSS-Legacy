SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFarmPanel_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFarmPanel_SelectDetail]
GO

--##SUMMARY Returns data for FarmPanel control.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 011.11.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

exec spFarmPanel_SelectDetail 88490000000

*/

CREATE          PROCEDURE dbo.spFarmPanel_SelectDetail
	@idfFarm AS bigint			--##PARAM @idfFarm - farm ID
AS

--1 Farm
Select  
	idfFarm, 
	tlbParty.idfRootParty as idfRootFarm,
	tlbParty.idfCase,
	tlbParty.idfMonitoringSession,
	strContactPhone, 
	strInternationalName, 
	strNationalName, 
	strFarmCode,
	strFax,
	strEmail,
	idfFarmLocation,
	idfFarmAddress,
	blnIsLivestock,
	blnIsAvian,
	tlbFarm.idfHuman AS idfOwner,
	ownerParty.idfRootParty as idfRootOwner,
	RTRIM(ISNULL(tlbHuman.strLastName +N' ',N'') +ISNULL(tlbHuman.strFirstName +N' ',N'') + ISNULL(tlbHuman.strSecondName,N'')) as strFullName,
	tlbHuman.strLastName AS strOwnerLastName,
	tlbHuman.strFirstName AS strOwnerFirstName,
	tlbHuman.strSecondName as strOwnerMiddleName

FROM tlbFarm
INNER JOIN tlbParty ON
	tlbFarm.idfFarm = tlbParty.idfParty 
LEFT OUTER JOIN tlbHuman 
	on tlbHuman.idfHuman=tlbFarm.idfHuman 
LEFT OUTER JOIN tlbParty ownerParty 
	on ownerParty.idfParty=tlbHuman.idfHuman 
Where 
	idfFarm=@idfFarm


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

