SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRepUniEventLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRepUniEventLog]

GO

--##SUMMARY Select event log records.

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 03.12.2009

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
exec spRepUniEventLog 'en','01/01/00','01/01/10'

*/

CREATE  Procedure [dbo].[spRepUniEventLog]
	(@LANGID As nvarchar(50),
	 @SD as nvarchar(20), 
	 @ED as nvarchar(20))
AS	

	declare @SDDate as datetime
	declare @EDDate as datetime

	set @SDDate=dbo.fn_SetMinMaxTime(CAST(@SD as datetime),0)
	set @EDDate=dbo.fn_SetMinMaxTime(CAST(@ED as datetime),1)

	select		* 
	from		dbo.fn_Event_SelectList (@LANGID) as a
	where		datEventDatatime between @SDDate and @EDDate
	order by	datEventDataTime

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

