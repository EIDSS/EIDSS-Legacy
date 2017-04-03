
-- =============================================
-- Author:		Vasilyev I.
-- Create date: 25.06.2013
-- Description:	insert binary header of query cache record
-- =============================================

/*
--Example of procedure call:

exec spAsQueryCachePostHeader 49539640000000, 'en', 0x000102030405060708090A0B0C0D0E0F

*/

create PROCEDURE spAsQueryCachePostHeader
 	 @idfQuery			bigint,
 	 @strLanguage		nvarchar(50),
 	 @blbQuerySchema	image,
	 @intQueryColumnCount int,
	 @blnUseArchivedData	bit
AS
BEGIN
   
    declare @ident bigint
	
    INSERT INTO QueryCache
		([idfQuery]
		,[strLanguage]
		,[blbQuerySchema]
		,[intQueryColumnCount]
		,[datQueryCacheRequest]
		,[blnUseArchivedData]) 
    VALUES 
		(@idfQuery
		,@strLanguage
		,@blbQuerySchema
		,@intQueryColumnCount
		,GETDATE()
		,@blnUseArchivedData) 
	
	set @ident = SCOPE_IDENTITY()
	
	update	QueryCache 
	set		blnActualQueryCache = 0
	where	idfQuery = @idfQuery
	and     strLanguage = @strLanguage
	and		idfQueryCache <> @ident

	select @ident
	
END