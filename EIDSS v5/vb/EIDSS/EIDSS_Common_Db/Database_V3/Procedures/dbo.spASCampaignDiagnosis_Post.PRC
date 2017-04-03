SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASCampaignDiagnosis_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASCampaignDiagnosis_Post]
GO

--##SUMMARY Posts list of diagnosis related with specific AS campaign.
--##SUMMARY Called by ASCampaignDetail form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 10.06.2010

--##RETURNS Doesn't use

/*
--Example of procedure call:

DECLARE @Action int
DECLARE @idfCampaign bigint
DECLARE @idfsDiagnosis bigint
DECLARE @intOrder int

-- TODO: Set parameter values here.

EXECUTE spASCampaignDiagnosis_Post
   @Action
  ,@idfCampaign
  ,@idfsDiagnosis
  ,@intOrder
*/




CREATE         PROCEDURE dbo.spASCampaignDiagnosis_Post(
			@Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
           ,@idfCampaignToDiagnosis bigint OUTPUT
           ,@idfCampaign bigint
           ,@idfsDiagnosis bigint
           ,@intOrder int
)
AS
IF @Action = 8
BEGIN
	DELETE FROM tlbCampaignToDiagnosis
    WHERE 
	idfCampaignToDiagnosis = @idfCampaignToDiagnosis
END

ELSE IF @Action = 16
BEGIN
	UPDATE tlbCampaignToDiagnosis
	SET	
		 intOrder = @intOrder
		,idfsDiagnosis = @idfsDiagnosis
		,idfCampaign = @idfCampaign
	WHERE 
		idfCampaignToDiagnosis = @idfCampaignToDiagnosis
END
ELSE IF @Action = 4
BEGIN
	EXEC spsysGetNewID @idfCampaignToDiagnosis OUTPUT
	INSERT INTO tlbCampaignToDiagnosis
		   (
			idfCampaignToDiagnosis
			,idfCampaign
		   ,idfsDiagnosis
		   ,intOrder
		   )
	 VALUES
		   (
			@idfCampaignToDiagnosis
			,@idfCampaign
		   ,@idfsDiagnosis
		   ,@intOrder
		   )
END

RETURN 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

