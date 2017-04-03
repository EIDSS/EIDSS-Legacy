SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASSession_PopulateFarmData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASSession_PopulateFarmData]
GO


--##SUMMARY Returns table with farm data for Active Surveillance Monitoring Session form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 28.07.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:
DECLARE @idfMonitoringSession bigint
SET @idfMonitoringSession=706800000000
EXECUTE spASSession_PopulateFarmData 
	@idfMonitoringSession

*/




CREATE         PROCEDURE dbo.spASSession_PopulateFarmData(
	@idfFarm AS bigint--##PARAM @idfFarm - farm ID
)
AS

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
	tlbParty.idfParty = @idfFarm
	and tlbParty.intRowStatus = 0
	

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

