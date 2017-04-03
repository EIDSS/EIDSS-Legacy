SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spNotification_Create]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spNotification_Create]
GO

--##SUMMARY Creates new notification record.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of procedure call:

DECLARE @idfNotification bigint
DECLARE @idfsNotificationType bigint
DECLARE @idfUserID bigint
DECLARE @idfNotificationObject bigint
DECLARE @idfsNotificationObjectType bigint
DECLARE @idfTargetUserID bigint
DECLARE @idfsTargetSite bigint
DECLARE @idfsTargetSiteType bigint
DECLARE @idfsSite bigint
DECLARE @datEnteringDate datetime

SET @idfsNotificationType = 10056011
SET @idfsSite = 2
SET @datEnteringDate = GetDate()
SET @idfNotificationObject = 124550000000

EXECUTE spNotification_Create
   @idfNotification OUTPUT
  ,@idfsNotificationType
  ,@idfUserID
  ,@idfNotificationObject
  ,@idfsNotificationObjectType
  ,@idfTargetUserID
  ,@idfsTargetSite
  ,@idfsTargetSiteType
  ,@idfsSite
  ,@datEnteringDate
  ,N'124550000000' 

*/


CREATE                  PROCEDURE dbo.spNotification_Create
			 @idfNotification as bigint OUTPUT --##PARAM @idfNotification - notification record ID. IF NULL is passed, new ID is assigned inside procedure and returned to calling client
			,@idfsNotificationType as bigint --##PARAM @idfsNotificationType - notification type
			,@idfUserID as bigint --##PARAM @idfUserID - ID of user that created notification
			,@idfNotificationObject as bigint --##PARAM @idfNotificationObject - ID of object related with notification
			,@idfsNotificationObjectType as bigint --##PARAM @idfNotificationObject - type of object related with notification
			,@idfTargetUserID as bigint --##PARAM @idfTargetUserID - ID of user that should receive notification. Currently is not used.
			,@idfsTargetSite as bigint --##PARAM @idfsTargetSite - ID of site that should receive notification. Currently is not used.
			,@idfsTargetSiteType as bigint --##PARAM @idfsTargetSiteType - type of site where notification should be processed. Currently is not used.
			,@idfsSite as bigint --##PARAM @idfsSite - ID of site where notification is created
			,@datEnteringDate DATETIME --##PARAM @datEnteringDate - date when notification was created first time (for notification that are transferred from intermediate sites)
			,@strPayload as text --##PARAM @strPayload - custom data related with notification

AS
if @idfNotification IS NULL
	EXEC spsysGetNewID @idfNotification OUTPUT

INSERT INTO tstNotification
           (
			idfNotification
           ,idfsNotificationObjectType
           ,idfsNotificationType
           ,idfsTargetSiteType
           ,idfUserID
           ,idfNotificationObject
           ,idfTargetUserID
           ,idfsTargetSite
           ,idfsSite
           ,datCreationDate
           ,datEnteringDate
           ,strPayload
			)
     VALUES
           (
			@idfNotification
           ,@idfsNotificationObjectType
           ,@idfsNotificationType
           ,@idfsTargetSiteType
           ,@idfUserID
           ,@idfNotificationObject
           ,@idfTargetUserID
           ,@idfsTargetSite
           ,ISNULL(@idfsSite, dbo.fnSiteID())
           ,GETDATE() --@datCreationDate 
           ,@datEnteringDate
           ,@strPayload
			)

INSERT INTO tstNotificationStatus
           (
			[idfNotification]
           ,[intProcessed]
           )
     VALUES
           (
			@idfNotification
           ,0 --intProcessed
           )


EXEC spFiltered_CheckNotificationPost @idfNotification











GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

