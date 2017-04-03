SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEventLog_EventForObjectExists]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEventLog_EventForObjectExists]
GO



--##SUMMARY Checks if event of specific type exists for specific object.
--##SUMMARY Only event types that require request to database are processed here.
--##SUMMARY All other event types are checked in client application to reduce database load.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 21.12.2009

--##RETURNS 1 if event exists, 
--##RETURNS 0 in other case

/*
--Example of a call of procedure:
DECLARE @RC INT
DECLARE @idfsEventTypeID BIGINT
DECLARE @idfObject BIGINT

EXEC @RC = spEventLog_EventForObjectExists @idfEventID, @intProcessed OUTPUT

Print ISNULL(@RC,0)
*/




CREATE          procedure dbo.spEventLog_EventForObjectExists( 
	@idfsEventTypeID as bigint,--##PARAM @idfEventID - event record ID
	@idfObject as bigint --##PARAM @intProcessed - returns flag that defined was record processed or not
	
)
as
IF	(@idfsEventTypeID = 10025005 OR --CaseDiseaseChange
	@idfsEventTypeID = 10025006 OR --CaseDiseaseChangedNotification
	@idfsEventTypeID = 10025007 OR --CaseStatusChange
	@idfsEventTypeID = 10025008 OR --CaseStatusChangedNotification
	@idfsEventTypeID = 10025010 OR --NewHumanCase
	@idfsEventTypeID = 10025014) --NewVetCase
	IF (Exists(Select * from dbo.tlbCase where idfCase = @idfObject))
		RETURN 1
	ELSE
		RETURN 0
ELSE IF(@idfsEventTypeID = 10025016) --NewOutbreak
	IF (Exists(Select * from dbo.tlbOutbreak where idfOutbreak = @idfObject))
		RETURN 1
	ELSE
		RETURN 0
ELSE IF(@idfsEventTypeID = 10025003 OR --TestResultsReceived
		@idfsEventTypeID = 10025013 OR --NewTestResult
		@idfsEventTypeID = 10025012) --NewTestRequest = 
	IF (Exists(Select * from dbo.tlbTesting where idfTesting = @idfObject))
		RETURN 1
	ELSE
		RETURN 0
ELSE 
	RETURN 1


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

