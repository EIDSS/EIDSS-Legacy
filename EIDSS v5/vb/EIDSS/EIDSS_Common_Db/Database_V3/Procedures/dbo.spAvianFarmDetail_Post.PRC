SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAvianFarmDetail_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAvianFarmDetail_Post]
GO






--##SUMMARY Posts AvianFarmDetail control data.
--##SUMMARY The main posting is performed in spFarmPanel_Post procedure that is called before this one,
--##SUMMARY so it just updates several fields that belongs to AvianFarmDetail control only.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 30.11.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:

DECLARE @idfFarm bigint
DECLARE @intBuidings int
DECLARE @intBirdsPerBuilding int

EXECUTE spAvianFarmDetail_Post
   @idfFarm
  ,@intBuidings
  ,@intBirdsPerBuilding

*/



CREATE             PROCEDURE dbo.spAvianFarmDetail_Post
	@idfFarm bigint,			--##PARAM @idfFarm - farm ID
	@intBuidings int,			--##PARAM @intBuidings - number of farm buildings
	@intBirdsPerBuilding int	--##PARAM @intBirdsPerBuilding - number of birds per building


AS

	UPDATE tlbFarm
	SET
		intBuidings=@intBuidings,
		intBirdsPerBuilding=@intBirdsPerBuilding
	WHERE 
		idfFarm=@idfFarm

	DECLARE @RootFarmID BIGINT
	SELECT @RootFarmID = idfRootParty FROM tlbParty where idfParty=@idfFarm
	IF NOT @RootFarmID IS NULL
	BEGIN
		UPDATE tlbFarm
		SET
			intBuidings=@intBuidings,
			intBirdsPerBuilding=@intBirdsPerBuilding
		WHERE 
			idfFarm=@RootFarmID
	END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

