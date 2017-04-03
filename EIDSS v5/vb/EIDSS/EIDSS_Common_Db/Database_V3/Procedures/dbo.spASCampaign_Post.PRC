SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASCampaign_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASCampaign_Post]
GO


CREATE         PROCEDURE dbo.spASCampaign_Post(
			@Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
           ,@idfCampaign bigint OUTPUT
           ,@idfsCampaignType bigint
           ,@idfsCampaignStatus bigint
           ,@datCampaignDateStart datetime
           ,@datCampaignDateEnd datetime
           ,@strCampaignID nvarchar(50) OUTPUT
           ,@strCampaignName nvarchar(200)
           ,@strCampaignAdministrator nvarchar(200)
           ,@strComments nvarchar(500)
           ,@strConclusion nvarchar(max)

)
AS

IF @Action = 4
BEGIN
	IF ISNULL(@idfCampaign,-1)<0
	BEGIN
		EXEC spsysGetNewID @idfCampaign OUTPUT
	END
	IF LEFT(ISNULL(@strCampaignID, '(new'),4) = '(new'
	BEGIN
		EXEC dbo.spGetNextNumber 10057027, @strCampaignID OUTPUT , NULL --N'AS Campaign'
	END
	INSERT INTO tlbCampaign
			   (idfCampaign
			   ,idfsCampaignType
			   ,idfsCampaignStatus
			   ,datCampaignDateStart
			   ,datCampaignDateEnd
			   ,strCampaignID
			   ,strCampaignName
			   ,strCampaignAdministrator
			   ,strComments
			   ,strConclusion
			   )
		 VALUES
			   (@idfCampaign
			   ,@idfsCampaignType
			   ,@idfsCampaignStatus
			   ,@datCampaignDateStart
			   ,@datCampaignDateEnd
			   ,@strCampaignID
			   ,@strCampaignName
			   ,@strCampaignAdministrator
			   ,@strComments
			   ,@strConclusion
			   )
END
ELSE IF @Action=16
BEGIN
	UPDATE tlbCampaign
	   SET 
		  idfsCampaignType = @idfsCampaignType
		  ,idfsCampaignStatus = @idfsCampaignStatus
		  ,datCampaignDateStart = @datCampaignDateStart
		  ,datCampaignDateEnd = @datCampaignDateEnd
		  ,strCampaignID = @strCampaignID
		  ,strCampaignName = @strCampaignName
		  ,strCampaignAdministrator = @strCampaignAdministrator
		  ,strComments = @strComments
		  ,strConclusion = @strConclusion
	 WHERE 
		idfCampaign=@idfCampaign
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

