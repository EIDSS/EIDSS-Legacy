
-- =============================================
-- Author:		Vasilyev I.
-- Create date: 25.06.2013
-- Description:	insert binary header of View cache record
-- =============================================

/*
--Example of procedure call:

exec spAsQueryCachePostHeader 49539640000000, 49539650000000, 'en', 0x000102030405060708090A0B0C0D0E0F

*/

create PROCEDURE spAsViewCachePostHeader
 	 @idfQueryCache			bigint,
	 @idfLayout				bigint,
 	 @blbViewSchema			image,
 	 @blbViewHeader			image,
	 @intViewColumnCount	int
AS
BEGIN
   
    declare @ident bigint
	
    INSERT INTO ViewCache
		([idfQueryCache]
		,[idfLayout]
		,[blbViewSchema]
		,[blbViewHeader]
		,[intViewColumnCount]
		,[datViewCacheRequest]) 
    VALUES 
		(@idfQueryCache
		,@idfLayout
		,@blbViewSchema
		,@blbViewHeader
		,@intViewColumnCount
		,GETDATE()) 
	
	set @ident = SCOPE_IDENTITY()
	
	update	ViewCache 
	set		blnActualViewCache = 0
	where	idfQueryCache = @idfQueryCache
	and		idfLayout = @idfLayout
	and		idfViewCache <> @ident
	

	select @ident
	
END