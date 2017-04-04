-- =============================================
-- Author:		Vasilyev I.
-- Create date: 10.05.2016
-- Description:	returns binary header of view cache record
-- =============================================

/*
--Example of procedure call:

exec spAsViewCacheGetHeader 1,  true


*/

	
CREATE PROCEDURE spAsViewCacheGetHeader
 	  @idfViewCache		bigint
	 ,@blnSchedulerCall	bit
	 
AS
BEGIN

	update ViewCache 
	set datViewCacheRequest = GETDATE()  
	where idfViewCache = @idfViewCache

	if @blnSchedulerCall <> 1 begin
		update ViewCache 
		set datUserViewCacheRequest = GETDATE() 
		where idfViewCache = @idfViewCache
	end
	
	select top 1 
		blbViewSchema,
		blbViewHeader,
		intViewColumnCount, 
		(	
			select count (*) from ViewCachePacket 
			where idfViewCache = @idfViewCache
		) as intPacketCount
	from ViewCache 
	where idfViewCache = @idfViewCache
	
END
