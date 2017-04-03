SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spEventLog_CheckProcessed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spEventLog_CheckProcessed]
GO



--##SUMMARY Checks if event log record was processed already. Processed records are not selected during new client events selection.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of a call of procedure:
DECLARE @idfEventID BIGINT
DECLARE @intProcessed BIT

EXEC spEventLog_CheckProcessed @idfEventID, @intProcessed OUTPUT

Print ISNULL(@intProcessed,0)
*/




CREATE          procedure dbo.spEventLog_CheckProcessed( 
	@idfEventID as bigint,--##PARAM @idfEventID - event record ID
	@intProcessed as int output --##PARAM @intProcessed - returns flag that defined was record processed or not
	
)
as

select	@intProcessed = IsNull(intProcessed, 0) 
from	tstEvent 
where	idfEventID = @idfEventID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

