-- =============================================
-- Author:		Vasilyev I.
-- Create date: 25.06.2013
-- Description:	Make current Cache of given view invalid
-- =============================================

/*
--Example of procedure call:

exec spAsViewCacheInvalidate 49539640000000, 'en'

*/

create PROCEDURE spAsViewCacheInvalidate
 	 @idfLayout			bigint
AS
BEGIN
   	update	v 
	set		blnActualViewCache = 0
	from	ViewCache v
	where	v.idfLayout = @idfLayout
	and		v.blnActualViewCache = 1
	
END