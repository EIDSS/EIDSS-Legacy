-- =============================================
-- =============================================
-- Author:		Vasilyev I.
-- Create date: 25.06.2013
-- Description:	returns binary header of query cache record
-- =============================================

/*
--Example of procedure call:

exec spAsQueryCacheGetHeader 1, true, true


*/

	
CREATE PROCEDURE spAsQueryCacheGetHeader
 	  @idfQueryCache		bigint
	 ,@blnSchedulerCall		bit
	 ,@blnUseArchivedData	bit
AS
BEGIN

	update QueryCache 
	set datQueryCacheRequest = GETDATE()  
	where idfQueryCache = @idfQueryCache

	if @blnSchedulerCall <> 1 begin
		update QueryCache 
		set datUserQueryCacheRequest = GETDATE() 
		where idfQueryCache = @idfQueryCache
	end
	
	select top 1 
		blbQuerySchema, 
		intQueryColumnCount, 
		(	
			select count (*) from QueryCachePacket 
			where idfQueryCache = @idfQueryCache
			and (@blnUseArchivedData=1 or blnArchivedData=0)
		) AS intPacketCount
	from QueryCache 
	where idfQueryCache = @idfQueryCache
	
END
