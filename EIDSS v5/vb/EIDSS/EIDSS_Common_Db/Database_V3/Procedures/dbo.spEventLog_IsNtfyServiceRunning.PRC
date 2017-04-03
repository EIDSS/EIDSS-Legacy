SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEventLog_IsNtfyServiceRunning]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEventLog_IsNtfyServiceRunning]
GO

--##SUMMARY Checks if EIDSS Notification Service is running.
--##SUMMARY When running, EIDSS Notification Service writes current DateTime to tstLocalSiteOptions table.
--##SUMMARY This procedure checks if this record exists and calculates difference betwen current time and time of last 
--##SUMMARY last EIDSS Notification Service activity. If this difference exceeds 20 sec, EIDSS Notification Service is considered as inactive
--##SUMMARY and new event of evtNotificationServiceNotRunning type is written to event log table

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
EXEC spEventLog_IsNtfyServiceRunning '12345'
*/




CREATE         procedure dbo.spEventLog_IsNtfyServiceRunning( 
		@idfsClient VARCHAR(36) --##PARAM @idfsClient - client application ID, defined in application configuration file. If client ID is not defined there, client PC MAC addres is used as client ID.
)
as
DECLARE @LastNotificationDate as DATETIME
DECLARE @LastEventDate as DATETIME
DECLARE @EventID AS BIGINT

SELECT	@LastNotificationDate = CONVERT(DATETIME,ISNULL(strValue,'1800-01-01 00:00:00'),120) 
FROM	tstLocalSiteOptions
WHERE	strName = 'LastNotificationEvent'

SELECT  @LastEventDate = getDate()

if  @LastNotificationDate IS NULL  OR DateDIFF(second,@LastNotificationDate, @LastEventDate)>200
	EXEC	spEventLog_CreateNewEvent
				@idfsEventTypeID = 10025004, --'evtNotificationServiceNotRunning',
				@idfObjectID = NULL,
				@strInformationString = NULL,
				@strNote = NULL,
				@ClientID = @idfsClient, 
				@datEventDatatime = NULL,
				@EventID = @EventID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

