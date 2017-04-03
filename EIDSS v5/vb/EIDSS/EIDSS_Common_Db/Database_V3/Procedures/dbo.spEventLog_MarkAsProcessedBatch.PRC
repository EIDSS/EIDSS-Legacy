SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEventLog_MarkAsProcessedBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEventLog_MarkAsProcessedBatch]
GO

--##SUMMARY Marks all event log record of specific type as processed. Processed records are not selected during new client events selection.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
DECLARE @idfsEventTypeID BIGINT
EXEC spEventLog_MarkAsProcessedBatch @idfsEventTypeID
*/


CREATE         procedure dbo.spEventLog_MarkAsProcessedBatch( 
	@idfsEventTypeID as bigint --##PARAM @idfsEventTypeID - event record type
)
as

update	tstEvent
set		intProcessed = 1 
where	idfsEventTypeID = @idfsEventTypeID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

