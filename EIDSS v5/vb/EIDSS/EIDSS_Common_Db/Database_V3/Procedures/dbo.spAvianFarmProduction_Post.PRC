SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAvianFarmProduction_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAvianFarmProduction_Post]
GO




--##SUMMARY Posts Avian farm properties.
--##SUMMARY The main posting is performed in spFarmPanel_Post procedure that is called before this one,
--##SUMMARY so it just updates several fields that belongs to AvianFarmDetail control only.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 30.11.2009

--##RETURNS Doesn't use


/*
--Example of procedure call:

DECLARE @idfFarm bigint
DECLARE @idfRootFarm bigint
DECLARE @idfsAvianFarmType bigint
DECLARE @idfsAvianProductionType bigint
DECLARE @idfsIntendedUse bigint

EXECUTE spAvianFarmDetail_Post
	@idfFarm 
	@idfRootFarm,
	@idfsAvianFarmType,
	@idfsAvianProductionType,
	@idfsIntendedUse 

*/


Create    proc	spAvianFarmProduction_Post
	@idfFarm bigint,
	@idfRootFarm bigint,
	@idfsAvianFarmType bigint,
	@idfsAvianProductionType bigint,
	@idfsIntendedUse bigint
as

update	tlbFarm
set		
	idfsAvianFarmType = @idfsAvianFarmType,
	idfsAvianProductionType = @idfsAvianProductionType,
	idfsIntendedUse = @idfsIntendedUse
	
where	idfFarm = @idfFarm

if not @idfRootFarm is null
update	tlbFarm
set		
	idfsAvianFarmType = @idfsAvianFarmType,
	idfsAvianProductionType = @idfsAvianProductionType,
	idfsIntendedUse = @idfsIntendedUse
	
where	idfFarm = @idfRootFarm


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

