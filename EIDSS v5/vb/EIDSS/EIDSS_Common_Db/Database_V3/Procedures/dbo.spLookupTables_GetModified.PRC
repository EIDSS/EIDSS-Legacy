SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLookupTables_GetModified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLookupTables_GetModified]
GO


--##SUMMARY returns the list of changed tables for lookup cache.

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 17.12.2009

--##RETURNS Doesn't use

/*
--Example of procedure call:
EXECUTE spLookupTables_GetModified '1234'

*/



CREATE            procedure dbo.spLookupTables_GetModified(
	@ClientID as nvarchar(50)
)
as

begin tran T1

declare @LastEvent as bigint
declare @LastEventStr as nvarchar(200)
declare @CurrLastEvent as bigint
declare @ClientFieldName as nvarchar(200)

set @ClientFieldName = N'ReferenceChangeEvent(' + @ClientID + ')'
set @CurrLastEvent = 0

select top 1 @CurrLastEvent = intRowNum 
from		dbo.[tstEvent] 
order by	intRowNum desc

select	@LastEventStr = strValue 
from	dbo.tstLocalSiteOptions 
where	strName = @ClientFieldName

if @@ROWCOUNT = 0
begin
	print 'insert new event num ' + @ClientFieldName + ',' + convert(nvarchar(200), @CurrLastEvent)
	insert into tstLocalSiteOptions(
		[strName], [strValue]
	)
	values(
		@ClientFieldName, 
		convert(nvarchar(200), @CurrLastEvent)
	)
	commit tran T1
	return -1
end
else if @LastEventStr is null
begin
	print 'update last event num ' + @ClientFieldName + ',' + convert(nvarchar(200), @CurrLastEvent)
	update	tstLocalSiteOptions
	set		strValue = convert(nvarchar(200), @CurrLastEvent)
	where	strName = @ClientFieldName
	commit tran T1
	return -1
end
set @LastEvent = convert(bigint, @LastEventStr)

print 'update last event num 1' + @ClientFieldName + ',' + convert(nvarchar(200), @CurrLastEvent)

update	tstLocalSiteOptions
set		strValue = convert(nvarchar(200), @CurrLastEvent)
where	strName = @ClientFieldName
if @@ERROR <> 0
begin
	print 'ERROR'
	if @@TRANCOUNT < 2
		rollback tran T1
	else
		commit tran T1
	return -1
end

print 'select all events after' + convert(nvarchar(200), @LastEvent)
select		DISTINCT
			strInformationString 

from		[tstEvent]
where		
			idfsEventTypeID=10025002 --'evtLookupTableChanged'
			and intRowNum > @LastEvent
			and intRowNum <= @CurrLastEvent
			and strClient <> @ClientID


commit tran T1



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

