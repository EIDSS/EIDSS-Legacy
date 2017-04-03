SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASCampaign_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASCampaign_Delete]
GO



--##SUMMARY Deletes Active Surveillance Campaign object.
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 11.06.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @ID bigint
EXECUTE spASCampaign_Delete 
	@ID

*/




CREATE                                   proc	spASCampaign_Delete
	@ID AS BIGINT --#PARAM @ID - aggregate case ID
as

DELETE FROM  dbo.tlbCampaignToDiagnosis WHERE idfCampaign = @ID
DELETE FROM  dbo.tlbCampaign WHERE idfCampaign = @ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

