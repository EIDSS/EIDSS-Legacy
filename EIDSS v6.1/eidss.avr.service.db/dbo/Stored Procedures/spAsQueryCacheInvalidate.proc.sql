-- =============================================
-- Author:		Vasilyev I.
-- Create date: 25.06.2013
-- Description:	Make current Cache of given query and language invalid
-- =============================================

/*
--Example of procedure call:

exec spAsQueryCacheInvalidate 49539640000000, 'en'

*/

create PROCEDURE spAsQueryCacheInvalidate
 	 @idfQuery			bigint,
 	 @strLanguage		nvarchar(50) = null
AS
BEGIN
   
	update	v 
	set		blnActualViewCache = 0
	from	ViewCache v
	inner join QueryCache q
	on		v.idfQueryCache = q.idfQueryCache
	and		q.idfQuery = @idfQuery
	and		((@strLanguage is null) OR (q.strLanguage = @strLanguage))
	and		(v.blnActualViewCache = 1)
	
	update	QueryCache 
	set		blnActualQueryCache = 0
	where	idfQuery = @idfQuery
	and		((@strLanguage is null) OR (strLanguage = @strLanguage))
	and		(blnActualQueryCache = 1)

	
	
END