SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spNotificationSubscription_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spNotificationSubscription_Post]
GO

--##SUMMARY Posts record from NotificationSubscription form.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of procedure call:
DECLARE @idfsEventTypeID bigint
DECLARE @strClient nvarchar(36)
DECLARE @Subscription int

EXECUTE spNotificationSubscription_Post
   @idfsEventTypeID
  ,@strClient
  ,@Subscription

*/
CREATE   PROCEDURE dbo.spNotificationSubscription_Post( 
	@idfsEventTypeID bigint,--##PARAM @idfsEventTypeID - event type for subscription
	@strClient NVARCHAR(36),--##PARAM @strClient - client ID of application that is subscribed for notification receiving
	@Subscription as Integer--##PARAM @Subscription - 0 removes subscription for @idfsEventTypeID, any other value subscribes application for @idfsEventTypeID events receiving
	)
AS
if ISNULL(@Subscription,0) = 0 
	DELETE FROM tstEventSubscription
	WHERE idfsEventTypeID=@idfsEventTypeID AND strClient=@strClient
ELSE IF NOT EXISTS(SELECT idfsEventTypeID from tstEventSubscription WHERE idfsEventTypeID=@idfsEventTypeID AND strClient=@strClient)
	INSERT INTO tstEventSubscription(
		idfsEventTypeID, 
		strClient
	)
	VALUES(
		@idfsEventTypeID,
		@strClient)
	


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

