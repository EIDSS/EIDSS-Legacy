SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spNotification_Process]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spNotification_Process]
GO



--##SUMMARY Marks notification record as processed.
--##SUMMARY Processed notification records are ignored by EIDSS Notification Service.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
DECLARE @idfNotification bigint
EXEC spNotification_Process @idfNotification
*/

CREATE             PROCEDURE dbo.spNotification_Process( 
		@idfNotification AS bigint --##PARAM @idfNotification - notification record ID
)
AS

Update 
	tstNotificationStatus 
Set intProcessed = 1 
Where 
	idfNotification = @idfNotification
IF @@ROWCOUNT = 0 
	INSERT INTO tstNotificationStatus(
		idfNotification, intProcessed
	)
	VALUES(
		@idfNotification, 
		1
	)







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

