-- =============================================
-- Author:		Vasilyev I.
-- Create date: 25.06.2014
-- Description:	returns date of latest user request of query cache
-- =============================================
/*
--Example of procedure call:

exec spAsQueryCacheUserRefreshDate 123

*/
		

create PROCEDURE spAsQueryCacheUserRequestDate
 	 @idfQuery							bigint
AS
BEGIN 
	select top 1  datUserQueryCacheRequest
	from QueryCache 
	where idfQuery = @idfQuery
	order by datUserQueryCacheRequest desc
END



