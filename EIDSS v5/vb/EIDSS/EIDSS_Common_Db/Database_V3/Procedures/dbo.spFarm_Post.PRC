SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFarm_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFarm_Post]
GO






--##SUMMARY Posts FarmDetail control data.
--##SUMMARY The main posting is performed in spFarmPanel_Post procedure that is called before this one,
--##SUMMARY so it just updates several fields that belongs to FarmDetail control only.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 15.11.2009

--##RETURNS Doesn't use





CREATE             PROCEDURE dbo.spFarm_Post
	@idfFarm bigint,		--##PARAM @idfFarm - farm ID
	@blnIsLivestock bit,	--##PARAM @blnIsLivestock - set to 1 for livestock farm
	@blnIsAvian bit			--##PARAM @blnIsAvian - set to 1 for avian farm


AS

UPDATE tlbFarm
SET
	blnIsLivestock=@blnIsLivestock,
	blnIsAvian=@blnIsAvian
WHERE 
	idfFarm=@idfFarm



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

