SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASSessionFarms_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASSessionFarms_Post]
GO

--##SUMMARY Posts Active Surveillance Monitoring Session farms list

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 28.06.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:

*/


CREATE         PROCEDURE dbo.spASSessionFarms_Post(
			@Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
           ,@idfFarm bigint OUTPUT
           ,@idfRootFarm bigint
           ,@idfMonitoringSession bigint
)
AS
--Print '@idfFarm='+CAST(ISNULL(@idfFarm,'NULL') AS VARCHAR)+'@idfRootFarm='+CAST(ISNULL(@idfRootFarm,'NULL') AS VARCHAR)+'@idfMonitoringSession='+CAST(ISNULL(@idfMonitoringSession,'NULL') AS VARCHAR)
if @Action = 8
BEGIN
	EXEC spFarm_Delete @idfFarm
	RETURN 0
END
IF ISNULL(@idfFarm, -1)<0 OR NOT EXISTS(SELECT * FROM tlbParty WHERE idfParty = @idfFarm and intRowStatus = 0)
BEGIN

	EXECUTE spFarm_CreateRootCopy 
		   @idfRootFarm
		  ,@idfFarm OUTPUT --@idfTargetFarm
		  ,NULL--@idfCase
		  ,@idfMonitoringSession	

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

