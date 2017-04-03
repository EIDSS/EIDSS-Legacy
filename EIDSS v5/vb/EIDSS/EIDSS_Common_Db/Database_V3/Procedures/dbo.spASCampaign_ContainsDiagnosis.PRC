SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASCampaign_ContainsDiagnosis]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASCampaign_ContainsDiagnosis]
GO


--##SUMMARY Checks if campaign contains the specific diagnosis.
--##SUMMARY This procedure is called from AS Session Detail form
--##SUMMARY to prevent session have the diagnosis not included to associated campaign


--##REMARKS Author: Zurin M.
--##REMARKS Create date: 12.10.2010

--##RETURNS 0 if campaign doesn't contain diagnosis
--##RETURNS 1 if campaign contains diagnosis

/*
Example of procedure call:
DECLARE @RC int
DECLARE @idfCampaign bigint
DECLARE @idfsDiagnosis bigint

EXECUTE @RC = spASCampaign_ContainsDiagnosis
   @idfCampaign
  ,@idfsDiagnosis
Print @RC

*/


CREATE   procedure dbo.spASCampaign_ContainsDiagnosis
	@idfCampaign as bigint --##PARAM @idfCampaign - campaign ID
	,@idfsDiagnosis as bigint --##PARAM @idfsDiagnosis -  Diagnosis ID
as
If @idfCampaign is NULL or @idfsDiagnosis is null
	return 1
IF EXISTS(SELECT *  from  tlbCampaignToDiagnosis 
		where tlbCampaignToDiagnosis.idfCampaign = @idfCampaign 
		and idfsDiagnosis = @idfsDiagnosis 
		and tlbCampaignToDiagnosis.intRowStatus = 0)
	return 1
ELSE
	return 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

