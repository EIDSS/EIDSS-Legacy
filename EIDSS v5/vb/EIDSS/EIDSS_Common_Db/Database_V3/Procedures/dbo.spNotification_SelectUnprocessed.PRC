SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spNotification_SelectUnprocessed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spNotification_SelectUnprocessed]
GO

--##SUMMARY Selects all unprocessed records from tstNotification table.
--##SUMMARY Record is considered as unprocessed if there is no correspodent record in the tstNotificationStatus table with intProcessed = 1.
--##SUMMARY tstNotificationStatus table is not replicated and is used by site notification service to mark local processed records.
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
EXEC spNotification_SelectUnprocessed 
*/


CREATE                  PROCEDURE dbo.spNotification_SelectUnprocessed
AS

-- tstNotification
Select		tstNotification.idfNotification, 
		tstNotification.idfUserID, 
		tstNotification.idfsSite, 
		tstNotification.datCreationDate, 
		tstNotification.datEnteringDate, 
		tstNotification.strPayload, 
		tstNotification.idfsNotificationType,
		ISNULL(tstNotificationStatus.intProcessed,0) AS intProcessed,
		idfsTargetSite,
		idfsTargetSiteType,
		idfTargetUserID,
		idfsNotificationObjectType,
		idfNotificationObject
From		tstNotification
LEFT OUTER Join	tstNotificationStatus ON
		tstNotificationStatus.idfNotification = tstNotification.idfNotification

Where
		tstNotification.intRowStatus = 0
		AND ISNULL(tstNotificationStatus.intProcessed,0) <> 1 





















GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

