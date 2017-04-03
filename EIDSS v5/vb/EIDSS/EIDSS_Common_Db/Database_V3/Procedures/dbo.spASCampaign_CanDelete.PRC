SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASCampaign_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASCampaign_CanDelete]
GO


--##SUMMARY Checks if Campaign object can be deleted.
--##SUMMARY This procedure is called from AS Campaigns list.
--##SUMMARY We consider that campaign can be deleted if there no monitoring sessions related with this campaign.


--##REMARKS Author: Zurin M.
--##REMARKS Create date: 11.06.2010

--##RETURNS 0 if campaign can't be deleted 
--##RETURNS 1 if campaign can be deleted 

/*
Example of procedure call:

DECLARE @ID bigint
DECLARE @Result BIT
EXEC spASCampaign_CanDelete @ID, @Result OUTPUT

Print @Result

*/


CREATE   procedure dbo.spASCampaign_CanDelete
	@ID as bigint --##PARAM @ID - farm ID
	,@Result AS BIT OUTPUT --##PARAM  @Result - 0 if case can't be deleted, 1 in other case
as

IF EXISTS(SELECT idfMonitoringSession from  tlbMonitoringSession where idfCampaign = @ID and intRowStatus = 0)
	SET @Result = 0
ELSE
	SET @Result = 1

Return @Result

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

