SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASSession_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASSession_SelectDetail]
GO


--##SUMMARY Selects data for Active Surveillance Monitoring Session form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.06.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:
DECLARE @idfMonitoringSession bigint
SET @idfMonitoringSession=706800000000
EXECUTE spASSession_SelectDetail 
	@idfMonitoringSession

*/




CREATE         PROCEDURE dbo.spASSession_SelectDetail(
	@idfMonitoringSession AS bigint--##PARAM @iidfMonitoringSession - AS session ID
	--,@LangID AS nvarchar(50)--##PARAM @LangID - language ID
)
AS
-- 0- Session
SELECT idfMonitoringSession
      ,tlbMonitoringSession.idfsMonitoringSessionStatus
      ,tlbMonitoringSession.idfsCountry
      ,tlbMonitoringSession.idfsRegion
      ,tlbMonitoringSession.idfsRayon
      ,tlbMonitoringSession.idfsSettlement
      ,tlbMonitoringSession.idfPersonEnteredBy
      ,tlbMonitoringSession.idfCampaign
      ,tlbMonitoringSession.idfsSite
      ,tlbMonitoringSession.datEnteredDate
      ,tlbMonitoringSession.strMonitoringSessionID
      ,tlbCampaign.strCampaignID
      ,tlbCampaign.strCampaignName
      ,tlbCampaign.idfsCampaignType
	
  FROM tlbMonitoringSession
LEFT JOIN tlbCampaign
	ON tlbCampaign.idfCampaign = tlbMonitoringSession.idfCampaign
WHERE
	tlbMonitoringSession.idfMonitoringSession = @idfMonitoringSession
	and tlbMonitoringSession.intRowStatus = 0

--1 Diagnosis

SELECT 
       idfMonitoringSessionToDiagnosis 
	  ,idfMonitoringSession
      ,idfsDiagnosis 
      ,intOrder
  FROM tlbMonitoringSessionToDiagnosis
WHERE
	idfMonitoringSession = @idfMonitoringSession
	and intRowStatus = 0
Order By intOrder

--2 Farms
SELECT idfFarm
	  ,tlbParty.idfRootParty as idfRootFarm
      ,strFarmCode
      ,strNationalName
	  ,RTRIM(ISNULL(tlbHuman.strLastName +N' ',N'') +ISNULL(tlbHuman.strFirstName +N' ',N'') + ISNULL(tlbHuman.strSecondName,N'')) as strOwnerName
      ,idfsOwnershipStructure
      ,idfsLivestockProductionType
	  ,tlbParty.idfMonitoringSession
FROM [tlbFarm]
INNER JOIN tlbParty ON
	tlbFarm.idfFarm = tlbParty.idfParty 
LEFT OUTER JOIN tlbHuman 
	on tlbHuman.idfHuman=tlbFarm.idfHuman 
LEFT OUTER JOIN tlbParty ownerParty 
	on ownerParty.idfParty=tlbHuman.idfHuman 
WHERE
	tlbParty.idfMonitoringSession = @idfMonitoringSession
	and tlbParty.intRowStatus = 0
	
--3 Farm Tree
EXEC spASFarmTree_SelectDetail @idfMonitoringSession

--4 Animals
EXEC spASSessionAnimals_SelectDetail @idfMonitoringSession
--5 Actions
EXECUTE spAsSessionAction_SelectDetail @idfMonitoringSession

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
