SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFiltered_CheckEvent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFiltered_CheckEvent]
GO
/*
declare @ID bigint
select @ID = max(idfDataAuditEvent) from dbo.tauDataAuditEvent
print @ID
exec spFiltered_CheckEvent @ID
*/
CREATE      proc spFiltered_CheckEvent (@event bigint = null)
AS



--- get current event
	if @event is null
	begin
		declare @context varchar(50)
		set @context = dbo.fnGetContext()

		if @context is not null
		begin
			select @event = idfDataAuditEvent
			from dbo.tstLocalConnectionContext
			where strConnectionContext = @context

		end
	end

	if @event is not NULL
	begin
		--- Create node table
		if Object_ID('tempdb..##NodeTable') is null
		create table ##NodeTable(
			idfNode BIGINT  NOT NULL PRIMARY KEY, 
			strNodeTable nvarchar(200) COLLATE database_default,
			intStatus int )
		else
		delete ##NodeTable
		
		--- Execute "Check" procedures in correct order
--		PRINT 'spFiltered_CheckTransferIN'
		EXEC spFiltered_CheckTransferIN @event
		--EXEC spFiltered_CheckFreezer @event
--		PRINT 'spFiltered_CheckDataAudit'
		EXEC spFiltered_CheckDataAudit @event
--		PRINT 'spFiltered_CheckAggCase'
		EXEC spFiltered_CheckAggCase @event
--		PRINT 'spFiltered_CheckTransferOut'
		EXEC spFiltered_CheckTransferOut @event
--		PRINT 'spFiltered_CheckASS'
		EXEC spFiltered_CheckASS @event
--		PRINT 'spFiltered_CheckVetCase'
		EXEC spFiltered_CheckVetCase @event
--		PRINT 'spFiltered_CheckHumanCase'
		EXEC spFiltered_CheckHumanCase @event
--		PRINT 'spFiltered_CheckOutbreak'
		EXEC spFiltered_CheckOutbreak @event
--		PRINT 'spFiltered_CheckParty'
		EXEC spFiltered_CheckParty @event
--		PRINT 'spFiltered_CheckExtBatchTest'
		EXEC spFiltered_CheckExtBatchTest @event
--		PRINT 'spFiltered_CheckBatchTest'
		EXEC spFiltered_CheckBatchTest @event
--		PRINT 'spFiltered_CheckObservation'
		EXEC spFiltered_CheckObservation @event
--		PRINT 'spFiltered_CheckGeoLocation'
		EXEC spFiltered_CheckGeoLocation @event 
--		PRINT 'spFiltered_CheckNotification'
		EXEC spFiltered_CheckNotification @event
		-- проверка результата
--		SELECT * FROM [##NodeTable] WHERE [intStatus] = 0
		
		--- Drop node table		
		drop table ##NodeTable
	end



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


