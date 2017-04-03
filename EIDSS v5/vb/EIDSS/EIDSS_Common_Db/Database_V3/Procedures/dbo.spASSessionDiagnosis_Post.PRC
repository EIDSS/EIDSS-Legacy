SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASSessionDiagnosis_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASSessionDiagnosis_Post]
GO

--##SUMMARY Posts Active Surveillance Monitoring Session diagnosis

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.06.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:

*/


CREATE         PROCEDURE dbo.spASSessionDiagnosis_Post(
			@Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
           ,@idfMonitoringSessionToDiagnosis bigint OUTPUT
           ,@idfMonitoringSession bigint
           ,@idfsDiagnosis bigint
           ,@intOrder int
			

)
AS

IF @Action = 8
BEGIN
	DELETE FROM tlbMonitoringSessionToDiagnosis
    WHERE 
	idfMonitoringSessionToDiagnosis = @idfMonitoringSessionToDiagnosis
	AND idfsDiagnosis = @idfsDiagnosis
END

ELSE IF @Action = 16
BEGIN
	BEGIN
		UPDATE tlbMonitoringSessionToDiagnosis
		   SET idfsDiagnosis = @idfsDiagnosis
			  ,idfMonitoringSession = @idfMonitoringSession
			  ,intOrder = @intOrder
		 WHERE 
			idfMonitoringSessionToDiagnosis = @idfMonitoringSessionToDiagnosis			
	END
END
ELSE IF @Action = 4
BEGIN
	BEGIN
		EXEC spsysGetNewID @idfMonitoringSessionToDiagnosis OUTPUT
		INSERT INTO tlbMonitoringSessionToDiagnosis
			   (
				idfMonitoringSessionToDiagnosis
			   ,idfMonitoringSession
			   ,idfsDiagnosis
			   ,intOrder
			   )
		 VALUES
			   (@idfMonitoringSessionToDiagnosis
				,@idfMonitoringSession
			   ,@idfsDiagnosis
			   ,@intOrder
			   )
	END
END

RETURN 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
