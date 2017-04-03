-- =============================================
-- Author:		Vasilyev I.
-- Create date: 25.06.2013
-- Description:	returns id of latest query cache record
-- =============================================
/*
--Example of procedure call:

exec spAsQueryCacheExist 49539640000000, 'en'

*/
		

create PROCEDURE spAsQueryCacheExist
	-- Add the parameters for the stored procedure here
 	 @idfQuery							bigint
	,@strLanguage						nvarchar(50)
	,@blnUseArchivedData				bit 
	,@refreshedCacheOnUserCallAfterDays int 
	,@allowSelectInvalidated			bit  
AS
BEGIN 
    declare @idfQueryCache bigint
    
   	declare @dateSplitter datetime 
	set @dateSplitter = DATEADD(day, -@refreshedCacheOnUserCallAfterDays, GETDATE())


    set @idfQueryCache = 
    (
			select top 1 idfQueryCache 
			from QueryCache 
			where (blnActualQueryCache = 1 or @allowSelectInvalidated=1)
			and idfQuery = @idfQuery
			and strLanguage = @strLanguage
			and (blnUseArchivedData=1 or @blnUseArchivedData=0)
			and (datQueryRefresh > @dateSplitter  or @allowSelectInvalidated=1)
			order by blnActualQueryCache desc, datQueryRefresh desc
	)
	
	select @idfQueryCache as idfQueryCache
	
END
