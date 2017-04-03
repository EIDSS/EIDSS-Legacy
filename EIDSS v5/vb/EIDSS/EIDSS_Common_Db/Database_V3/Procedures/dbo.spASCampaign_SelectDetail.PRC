SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASCampaign_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASCampaign_SelectDetail]
GO


--##SUMMARY Selects data for Active Surveillance Campaign form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 10.06.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:
DECLARE @idfCampaign bigint
EXECUTE spASCampaign_SelectDetail 
	@idfCampaign
	,'en'

*/




CREATE         PROCEDURE dbo.spASCampaign_SelectDetail(
	@idfCampaign AS bigint--##PARAM @idfCampaign - campaign ID
	,@LangID AS nvarchar(50)--##PARAM @LangID - language ID
)
AS
-- 0- Campaign
SELECT idfCampaign
      ,idfsCampaignType
      ,idfsCampaignStatus
      ,datCampaignDateStart
      ,datCampaignDateEnd
      ,strCampaignID
      ,strCampaignName
      ,strCampaignAdministrator
      ,strComments
      ,strConclusion
FROM tlbCampaign
WHERE
	idfCampaign = @idfCampaign
	and intRowStatus = 0

--1 Diagnosis

SELECT idfCampaignToDiagnosis
      ,idfCampaign
      ,idfsDiagnosis -- this diagnosis can be changed during editing and we post is as changeable value
      ,intOrder
  FROM tlbCampaignToDiagnosis
WHERE
	idfCampaign = @idfCampaign
	and intRowStatus = 0
Order By intOrder

--2 Sessions
Declare @strDisease nvarchar(max)
select @strDisease = ''
Declare @strDiseaseOne nvarchar(200)


DECLARE crDiagnosis Cursor FOR
	SELECT 
		Diagnosis.[Name]
	FROM tlbMonitoringSessionToDiagnosis
	INNER JOIN tlbMonitoringSession
		ON tlbMonitoringSession.idfMonitoringSession = tlbMonitoringSessionToDiagnosis.idfMonitoringSession
	LEFT JOIN fnReference(@LangID,19000019) [Diagnosis]
		ON	[Diagnosis].idfsReference = tlbMonitoringSessionToDiagnosis.idfsDiagnosis
	WHERE
		idfCampaign = @idfCampaign
		and tlbMonitoringSession.intRowStatus = 0
		and tlbMonitoringSessionToDiagnosis.intRowStatus = 0
	Order By tlbMonitoringSessionToDiagnosis.intOrder

OPEN crDiagnosis
FETCH NEXT FROM crDiagnosis into @strDiseaseOne
WHILE @@FETCH_STATUS = 0 
BEGIN
	select @strDisease = @strDisease + @strDiseaseOne + ', '
	FETCH NEXT FROM crDiagnosis INTO  @strDiseaseOne
END --crDiagnosis cursor end
CLOSE crDiagnosis
DEALLOCATE crDiagnosis

if @strDisease <> ''
	Select @strDisease = substring(@strDisease, 1, len(@strDisease)-2)


SELECT idfMonitoringSession
      ,[Status].Name as strStatus
      ,Region.Name as strRegion
      ,Rayon.Name as strRayon
      ,Settlement.Name as strSettlement
      ,datEnteredDate
      ,strMonitoringSessionID
	  ,@strDisease as strDisease
  FROM tlbMonitoringSession
LEFT JOIN fnGisReference(@LangID,19000003) Region
	ON	Region.idfsReference = tlbMonitoringSession.idfsRegion
LEFT JOIN fnGisReference(@LangID,19000002) Rayon
	ON	Rayon.idfsReference = tlbMonitoringSession.idfsRayon
LEFT JOIN fnGisReference(@LangID,19000005) Settlement
	ON	Settlement.idfsReference = tlbMonitoringSession.idfsSettlement
LEFT JOIN fnReference(@LangID,19000117) [Status]
	ON	[Status].idfsReference = tlbMonitoringSession.idfsMonitoringSessionStatus
WHERE
	idfCampaign = @idfCampaign
	and intRowStatus = 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

