-- =============================================
-- Author:		Vasilyev I.
-- Create date: 25.06.2013
-- Description:	returns binary packet of query cache record
-- =============================================

/*
--Example of procedure call:

exec spAsQueryCacheGetPacket 1, 0

*/

CREATE PROCEDURE spAsQueryCacheGetPacket
 	 @idfQueryCache					bigint,
 	 @intQueryCachePacketNumber		int
AS
BEGIN

	select top 1 p.blbQueryCachePacket, p.intTableRowCount, p.blnArchivedData
	from		QueryCachePacket p
	inner join	QueryCache c
	on		p.idfQueryCache = c.idfQueryCache
	where	p.idfQueryCache = @idfQueryCache
	and		p.intQueryCachePacketNumber = @intQueryCachePacketNumber
	
END