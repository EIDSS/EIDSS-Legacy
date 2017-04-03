SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEventLog_IsSubscribed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEventLog_IsSubscribed]
GO


--##SUMMARY Checks if client application subscribed to at least one event receiving.
--##SUMMARY Returned recordset contains the number of events to which client application is subscribed.
--##SUMMARY Can be called by by EIDSS, EIDSS Client Agent or by EIDSS Notification Service.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
EXEC spEventLog_IsSubscribed  '12345'
*/


CREATE            procedure dbo.spEventLog_IsSubscribed(
	@idfClientID as nvarchar(50) --##PARAM @idfClientID - client application ID, defined in application configuration file. If client ID is not defined there, client PC MAC addres is used as client ID.
)
as
Select Count(idfsEventTypeID) From tstEventSubscription 
WHERE strClient = @idfClientID
	

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

