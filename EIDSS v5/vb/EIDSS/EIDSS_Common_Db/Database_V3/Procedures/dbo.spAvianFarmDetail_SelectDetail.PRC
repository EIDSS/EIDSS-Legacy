SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAvianFarmDetail_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAvianFarmDetail_SelectDetail]
GO







--##SUMMARY Selects data for AvianFarmDetail control data.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 30.11.2009

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @idfFarm bigint
EXECUTE spAvianFarmDetail_SelectDetail 
	@idfFarm

*/


CREATE           PROCEDURE dbo.spAvianFarmDetail_SelectDetail
	@idfFarm AS bigint --##PARAM @idfFarm - farm ID
AS

Select  
	idfFarm, 
	intBuidings,
	intBirdsPerBuilding
FROM tlbFarm
Where 
	idfFarm=@idfFarm









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

