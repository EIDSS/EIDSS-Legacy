SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASSession_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASSession_Post]
GO

--##SUMMARY Posts data from Active Surveillance Monitoring Session form

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.06.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:
DECLARE @Action int
DECLARE @idfMonitoringSession bigint
DECLARE @idfsMonitoringSessionStatus bigint
DECLARE @idfsCountry bigint
DECLARE @idfsRegion bigint
DECLARE @idfsRayon bigint
DECLARE @idfsSettlement bigint
DECLARE @idfPersonEnteredBy bigint
DECLARE @idfCampaign bigint
DECLARE @idfsSite bigint
DECLARE @datEnteredDate datetime
DECLARE @strMonitoringSessionID nvarchar(50)


EXECUTE [spASSession_Post] 
   @Action
  ,@idfMonitoringSession OUTPUT
  ,@idfsMonitoringSessionStatus
  ,@idfsCountry
  ,@idfsRegion
  ,@idfsRayon
  ,@idfsSettlement
  ,@idfPersonEnteredBy
  ,@idfCampaign
  ,@idfsSite
  ,@datEnteredDate
  ,@strMonitoringSessionID OUTPUT

*/


CREATE         PROCEDURE dbo.spASSession_Post(
			@Action INT  --##PARAM @Action - posting action,  4 - add record, 8 - delete record, 16 - modify record
           ,@idfMonitoringSession bigint OUTPUT
           ,@idfsMonitoringSessionStatus bigint
           ,@idfsCountry bigint
           ,@idfsRegion bigint
           ,@idfsRayon bigint
           ,@idfsSettlement bigint
           ,@idfPersonEnteredBy bigint
           ,@idfCampaign bigint
           ,@idfsSite bigint
           ,@datEnteredDate datetime
           ,@strMonitoringSessionID nvarchar(50) OUTPUT

)
AS

IF @Action = 4
BEGIN
	IF ISNULL(@idfMonitoringSession,-1)<0
	BEGIN
		EXEC spsysGetNewID @idfMonitoringSession OUTPUT
	END
	IF LEFT(ISNULL(@strMonitoringSessionID, '(new'),4) = '(new'
	BEGIN
		EXEC dbo.spGetNextNumber 10057028, @strMonitoringSessionID OUTPUT , NULL --N'AS Session'
	END
	INSERT INTO tlbMonitoringSession
			   (idfMonitoringSession
			   ,idfsMonitoringSessionStatus
			   ,idfsCountry
			   ,idfsRegion
			   ,idfsRayon
			   ,idfsSettlement
			   ,idfPersonEnteredBy
			   ,idfCampaign
			   ,idfsSite
			   ,datEnteredDate
			   ,strMonitoringSessionID
			   )
		 VALUES
			   (@idfMonitoringSession
			   ,@idfsMonitoringSessionStatus
			   ,@idfsCountry
			   ,@idfsRegion
			   ,@idfsRayon
			   ,@idfsSettlement
			   ,@idfPersonEnteredBy
			   ,@idfCampaign
			   ,@idfsSite
			   ,@datEnteredDate
			   ,@strMonitoringSessionID
			   )

END
ELSE IF @Action=16
BEGIN
	UPDATE tlbMonitoringSession
	   SET 
		  idfsMonitoringSessionStatus = @idfsMonitoringSessionStatus
		  ,idfsCountry = @idfsCountry
		  ,idfsRegion = @idfsRegion
		  ,idfsRayon = @idfsRayon
		  ,idfsSettlement = @idfsSettlement
		  ,idfPersonEnteredBy = @idfPersonEnteredBy
		  ,idfCampaign = @idfCampaign
		  ,idfsSite = @idfsSite
		  ,datEnteredDate = @datEnteredDate
		  ,strMonitoringSessionID = @strMonitoringSessionID
	 WHERE 
		idfMonitoringSession = @idfMonitoringSession

--	DELETE FROM dbo.tlbMonitoringSessionToDiagnosis
--	WHERE idfMonitoringSession = @idfMonitoringSession
--			AND	idfCampaign<>@idfCampaign
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
