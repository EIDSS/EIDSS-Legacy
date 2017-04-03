-- =============================================
-- Author:		Vasilyev I.
-- Create date: 25.06.2013
-- Description:	returns binary header of query cache record
-- =============================================

/*
--Example of procedure call:

exec spAsQueryCacheGetRefreshDateTime 49539640000000, 'en'

*/
CREATE PROCEDURE spAsQueryCacheGetRefreshDateTime
 	  @idfQuery		bigint
 	 ,@strLanguage				nvarchar(50)
AS
BEGIN

	declare @idfQueryCache bigint
    
    set @idfQueryCache = 
    (
			select top 1 idfQueryCache 
			from	QueryCache 
			where 	idfQuery = @idfQuery
			and		strLanguage = @strLanguage
			order by blnActualQueryCache desc, datQueryRefresh desc
	)
	select 
			 idfQueryCache
			,idfQuery
			,datQueryRefresh
			,datQueryCacheRequest
	from	QueryCache 
	where	idfQueryCache = @idfQueryCache
	
END
