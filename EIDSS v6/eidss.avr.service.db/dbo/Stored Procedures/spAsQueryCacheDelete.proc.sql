
-- =============================================
-- Author:		Vasilyev I.
-- Create date: 25.06.2013
-- Description:	Deletes Cache for given query and language 
-- =============================================

/*
--Example of procedure call:

exec spAsQueryCacheDelete 49540070000000, 'en', 1
exec spAsQueryCacheDelete 1, 'en', 1

*/ 

 
create PROCEDURE spAsQueryCacheDelete
 	 @idfQuery				bigint,
 	 @strLanguage			nvarchar(50),
	 @blnLeaveLastRecord	bit
AS
BEGIN
	declare @dateSplitter datetime 
	set @dateSplitter = DATEADD(hour, -1, GETDATE())
    declare @idfQueryCache bigint
    declare @idTable TABLE (res bigint)
    
	if (@blnLeaveLastRecord = 1)
	begin
		insert into @idTable 
		exec  spAsQueryCacheExist @idfQuery, @strLanguage, 0, 7, 1
    
		select @idfQueryCache = res 
		from @idTable
	end
    if (@idfQueryCache is null) set @idfQueryCache = -1
    
    declare @datMaxUserDate datetime
    select	@datMaxUserDate = MAX (QueryCache.datUserQueryCacheRequest)
    from	QueryCache
    where	idfQuery = @idfQuery
	and		strLanguage =@strLanguage
    
	update QueryCache 
	set datUserQueryCacheRequest = @datMaxUserDate
	where idfQueryCache = @idfQueryCache

   -- select @idfQueryCache
	delete	p
	from	QueryCachePacket p
	inner join	QueryCache c
	on		p.idfQueryCache = c.idfQueryCache
	where	c.idfQuery = @idfQuery
	and		c.strLanguage = @strLanguage
	and		c.idfQueryCache <> @idfQueryCache
	and		c.datQueryCacheRequest < @dateSplitter
	
	delete	
	from	QueryCache
	where	idfQuery = @idfQuery
	and		strLanguage =@strLanguage
	and		idfQueryCache <>@idfQueryCache
	and		datQueryCacheRequest < @dateSplitter
	
	SELECT @@ROWCOUNT 
	
END