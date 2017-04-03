SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spNotification_GetCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spNotification_GetCount]
GO



--##SUMMARY Returns record with count of unprocessed notifications that was not created on the current site.
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
DECLARE @idfsSite AS bigint
EXEC spNotification_GetCount @idfsSite
*/



CREATE              PROCEDURE dbo.spNotification_GetCount( 
		@idfsSite AS bigint  --##PARAM @idfsSite - site ID
)
AS

Select Count(tstNotification.idfNotification) From tstNotification
LEFT OUTER Join tstNotificationStatus
	ON tstNotificationStatus.idfNotification = tstNotification.idfNotification
Where 
	tstNotification.idfsSite <> @idfsSite 
	AND ISNULL(tstNotificationStatus.intProcessed,0) <> 1 








GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

