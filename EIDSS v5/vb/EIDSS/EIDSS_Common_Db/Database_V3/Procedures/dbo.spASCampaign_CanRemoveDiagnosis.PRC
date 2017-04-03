SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASCampaign_CanRemoveDiagnosis]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASCampaign_CanRemoveDiagnosis]
GO


--##SUMMARY Checks if diagnosis can be deleted from campaign.
--##SUMMARY This procedure is called from AS Campaigns Detail form.
--##SUMMARY We consider that diagnosis can be deleted from campaign if there no monitoring sessions related with this campaign and used this diagnosis.


--##REMARKS Author: Zurin M.
--##REMARKS Create date: 11.06.2010

--##RETURNS 0 if diagnosis can't be deleted 
--##RETURNS 1 if diagnosis can be deleted 

/*
Example of procedure call:

DECLARE @ID bigint
DECLARE @Result BIT
EXEC spASCampaign_CanRemoveDiagnosis @ID, @Result OUTPUT

Print @Result

*/


CREATE   procedure dbo.spASCampaign_CanRemoveDiagnosis
	@idfCampaign as bigint --##PARAM @idfCampaign - campaign ID
	,@idfsDiagnosis as bigint --##PARAM @idfsDiagnosis -  Diagnosis ID
	,@Result AS BIT OUTPUT --##PARAM  @Result - 0 if diagnosis can't be deleted, 1 in other case
as

IF EXISTS(SELECT *  from  tlbMonitoringSessionToDiagnosis 
		INNER JOIN tlbMonitoringSession ON
		tlbMonitoringSession.idfMonitoringSession = tlbMonitoringSessionToDiagnosis.idfMonitoringSession
		and tlbMonitoringSession.intRowStatus = 0
		where tlbMonitoringSession.idfCampaign = @idfCampaign 
		and idfsDiagnosis = @idfsDiagnosis 
		and tlbMonitoringSessionToDiagnosis.intRowStatus = 0)
	SET @Result = 0
ELSE
	SET @Result = 1

Return @Result

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

