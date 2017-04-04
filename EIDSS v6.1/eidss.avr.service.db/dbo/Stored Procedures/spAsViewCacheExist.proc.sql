-- =============================================
-- Author:		Vasilyev I.
-- Create date: 10.05.2016
-- Description:	returns id of latest view cache record
-- =============================================
/*
--Example of procedure call:

exec spAsViewCacheExist 49539640000000, 1, 7, 1

*/
		

create PROCEDURE spAsViewCacheExist
	-- Add the parameters for the stored procedure here
 	 @idfQueryCache						bigint
	,@idfLayout							bigint
	,@refreshedCacheOnUserCallAfterDays int 
	,@allowSelectInvalidated			bit  
AS
BEGIN 
    declare @idfViewCache bigint
    
   	declare @dateSplitter datetime 
	set @dateSplitter = DATEADD(day, -@refreshedCacheOnUserCallAfterDays, GETDATE())


    set @idfViewCache = 
    (
			select top 1 idfViewCache 
			from ViewCache 
			where (blnActualViewCache = 1 or @allowSelectInvalidated=1)
			and idfQueryCache = @idfQueryCache
			and idfLayout = @idfLayout
			and (datViewRefresh > @dateSplitter  or @allowSelectInvalidated=1)
			order by blnActualViewCache desc, datViewRefresh desc
	)
	
	select @idfViewCache as idfViewCache
	
END
