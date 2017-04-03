SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spAsSessionAction_SelectDetail') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spAsSessionAction_SelectDetail
GO



--##SUMMARY Selects monitoring session action records related with specific session.
--##SUMMARY Called by ASSessionAction panel.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 20.08.2010

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
DECLARE @idfCase bigint

EXECUTE spAsSessionAction_SelectDetail
   @idfCase

EXECUTE spAsSessionAction_SelectDetail
   NULL
*/

Create    Proc	spAsSessionAction_SelectDetail
	@idfMonitoringSession bigint --##PARAM @idfMonitoringSession - session ID for which actions are retrieved
As
SELECT idfMonitoringSessionAction
      ,idfMonitoringSession
      ,idfPersonEnteredBy
      ,idfsMonitoringSessionActionType
      ,idfsMonitoringSessionActionStatus
      ,datActionDate
      ,strComments
  FROM tlbMonitoringSessionAction
WHERE
	idfMonitoringSession = @idfMonitoringSession
	and intRowStatus = 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

