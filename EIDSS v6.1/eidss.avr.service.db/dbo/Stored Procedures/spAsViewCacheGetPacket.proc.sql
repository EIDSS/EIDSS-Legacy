-- =============================================
-- Author:		Vasilyev I.
-- Create date: 10.05.2016
-- Description:	returns binary packet of View cache record
-- =============================================

/*
--Example of procedure call:

exec spAsViewCacheGetPacket 1, 0

*/

CREATE PROCEDURE spAsViewCacheGetPacket
 	 @idfViewCache					bigint,
 	 @intViewCachePacketNumber		int
AS
BEGIN

	select top 1 p.blbViewCachePacket, p.intTableRowCount
	from		ViewCachePacket p
	inner join	ViewCache c
	on		p.idfViewCache = c.idfViewCache
	where	p.idfViewCache = @idfViewCache
	and		p.intViewCachePacketNumber = @intViewCachePacketNumber
	
END