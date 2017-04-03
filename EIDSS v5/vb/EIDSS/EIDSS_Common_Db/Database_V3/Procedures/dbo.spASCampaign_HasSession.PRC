SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASCampaign_HasSession]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASCampaign_HasSession]
GO


--##SUMMARY Checks if campaign has associated monitoring sessions.
--##SUMMARY This procedure is called from AS Campaigns Detail form.


--##REMARKS Author: Zurin M.
--##REMARKS Create date: 29.07.2010

--##RETURNS 0 if campaign has no monitoring sessions
--##RETURNS 1 if campaign has at least one monitoring session

/*
Example of procedure call:

DECLARE @ID bigint
DECLARE @Result BIT
EXEC spASCampaign_HasSession @ID, @Result OUTPUT

Print @Result

*/


CREATE   procedure dbo.spASCampaign_HasSession
	@idfCampaign as bigint --##PARAM @idfCampaign - campaign ID
	,@Result AS BIT OUTPUT --##PARAM  @Result - 0 if campaign can't be closed, 1 in other case
as

IF EXISTS(SELECT *  from  tlbMonitoringSession where idfCampaign = @idfCampaign and intRowStatus = 0)
	SET @Result = 1
ELSE
	SET @Result = 0

Return @Result

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

