SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASSession_PopulateCampaignData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASSession_PopulateCampaignData]
GO


--##SUMMARY Populates data related with specific campaign for associating Monitoring Session with campaign

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 23.06.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:
DECLARE @idfCampaign bigint
SET @idfCampaign=706800000000
EXECUTE spASSession_PopulateCampaignData 
	@idfCampaign

*/




CREATE         PROCEDURE dbo.spASSession_PopulateCampaignData(
	@idfCampaign AS bigint--##PARAM @idfCampaign - AS campaign ID
)
AS
-- 0- Campaign
SELECT 
       tlbCampaign.strCampaignID
      ,tlbCampaign.strCampaignName
      ,tlbCampaign.idfsCampaignType
      ,tlbCampaign.idfsCampaignStatus
  FROM  tlbCampaign
WHERE
	tlbCampaign.idfCampaign = @idfCampaign
--1 Diagnosis

SELECT CAST(NULL as bigint) as idfMonitoringSession 
      ,idfCampaign
      ,idfsDiagnosis
	  ,Cast (0 as BIT) as blnUsed
  FROM tlbCampaignToDiagnosis
WHERE
	idfCampaign = @idfCampaign
	and intRowStatus = 0
Order By intOrder


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

