SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASCampaign_CanClose]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASCampaign_CanClose]
GO


--##SUMMARY Checks if campaign can be closed.
--##SUMMARY This procedure is called from AS Campaigns Detail form.
--##SUMMARY We consider that campaign can be closed if all monitoring sessions related with this campaign has status Closed.


--##REMARKS Author: Zurin M.
--##REMARKS Create date: 11.06.2010

--##RETURNS 0 if campaign can't be closed
--##RETURNS 1 if campaign can be closed

/*
Example of procedure call:

DECLARE @ID bigint
DECLARE @Result BIT
EXEC spASCampaign_CanClose @ID, @Result OUTPUT

Print @Result

*/


CREATE   procedure dbo.spASCampaign_CanClose
	@idfCampaign as bigint --##PARAM @idfCampaign - campaign ID
	,@Result AS BIT OUTPUT --##PARAM  @Result - 0 if campaign can't be closed, 1 in other case
as

IF EXISTS(SELECT *  from  tlbMonitoringSession where idfCampaign = @idfCampaign and idfsMonitoringSessionStatus <> 10160001/*Closed*/ and intRowStatus = 0)
	SET @Result = 0
ELSE
	SET @Result = 1

Return @Result

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

