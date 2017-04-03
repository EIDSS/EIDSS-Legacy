SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFarm_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFarm_SelectDetail]
GO
















--##SUMMARY Returns data for FarmDetail form.
--##SUMMARY The form itself contains only Livestock/Avian checkboxes, all other data are loaded through the child panels
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 15.11.2009

--##RETURNS Doesn't use

/*
--Example of procedure call:

exec spFarm_SelectDetail 71360000000
exec spFarm_SelectDetail NULL

*/


CREATE           PROCEDURE dbo.spFarm_SelectDetail
	@idfFarm AS bigint			--##PARAM @idfFarm - farm ID
AS

Select  
	idfFarm, 
	ISNULL(blnIsLivestock,0) as blnIsLivestock,
	ISNULL(blnIsAvian,0) as blnIsAvian
FROM tlbFarm
Where 
	idfFarm=@idfFarm









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

