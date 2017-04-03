SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEventLog_MarkAsProcessed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEventLog_MarkAsProcessed]
GO



--##SUMMARY Marks event log record as processed. Processed records are not selected during new client events selection.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
DECLARE @idfsEvent BIGINT
EXEC spEventLog_MarkAsProcessed @idfsEvent
*/


CREATE         procedure dbo.spEventLog_MarkAsProcessed( 
	@idfsEvent as bigint --##PARAM @idfsEvent - event record ID
)
as

update	tstEvent
set		intProcessed = 1 
where	idfEventID = @idfsEvent



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

