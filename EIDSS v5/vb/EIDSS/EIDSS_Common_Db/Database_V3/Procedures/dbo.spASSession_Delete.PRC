SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spASSession_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spASSession_Delete]
GO



--##SUMMARY Deletes Monitoring Session object.
--##REMARKS Author: Zurin M.
--##REMARKS Create date: 11.06.2010

--##RETURNS Doesn't use



/*
--Example of procedure call:

DECLARE @ID bigint
EXECUTE spASSession_Delete 
	@ID

*/




CREATE                                   proc	spASSession_Delete
	@ID AS BIGINT --#PARAM @ID - session ID
as
DECLARE @idfFarm bigint
DELETE FROM  dbo.tlbMonitoringSessionToDiagnosis WHERE idfMonitoringSession = @ID
DECLARE crFarm Cursor FOR
	SELECT idfFarm FROM tlbFarm
	INNER JOIN tlbParty ON
		tlbParty.idfParty = idfFarm
	WHERE
		tlbParty.idfMonitoringSession = @ID
		and  tlbParty.idfCase IS NULL
		and tlbParty.intRowStatus = 0

OPEN crFarm
FETCH NEXT FROM crFarm into @idfFarm

WHILE @@FETCH_STATUS = 0 
BEGIN
	EXEC spFarm_Delete @idfFarm
	FETCH NEXT FROM crFarm INTO  @idfFarm
END --crAnimal cursor end

CLOSE crFarm
DEALLOCATE crFarm

DELETE FROM  dbo.tlbMonitoringSession WHERE idfMonitoringSession = @ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

