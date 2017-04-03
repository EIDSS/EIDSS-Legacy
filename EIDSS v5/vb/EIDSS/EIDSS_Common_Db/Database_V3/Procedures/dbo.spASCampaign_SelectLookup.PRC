SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASCampaign_SelectLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASCampaign_SelectLookup]
GO


--##SUMMARY Selects data for Active Surveillance Campaign form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 10.06.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:
EXECUTE spASCampaign_SelectLookup 
	'en'

*/




CREATE         PROCEDURE dbo.spASCampaign_SelectLookup(
	@LangID AS nvarchar(50)--##PARAM @LangID - language ID
)
AS
-- 0- Campaign
SELECT tlbCampaign.idfCampaign
      ,tlbCampaign.strCampaignID
      ,tlbCampaign.idfsCampaignType
      ,tlbCampaign.strCampaignName
      ,fnReference.Name as strCampaignType
FROM tlbCampaign
Inner Join fnReference(@LangID,19000116) --Campaign Type
	ON fnReference.idfsReference=tlbCampaign.idfsCampaignType
WHERE
	tlbCampaign.intRowStatus = 0
	and tlbCampaign.idfsCampaignStatus = 10140001 --Open


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

