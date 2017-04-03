
-- =============================================
-- Author:		Vasilyev I.
-- Create date: 25.06.2013
-- Description:	insert binary packet of query cache record
-- =============================================

/*
--Example of procedure call:

exec spAsQueryCachePostPacket 1, 0, 0x000102030405060708090A0B0C0D0E0F

*/

CREATE PROCEDURE spAsQueryCachePostPacket
 	 @idfQueryCache			bigint,
 	 @intQueryCachePacketNumber		int,
 	 @blbQueryCachePacket		image,
	 @intPacketRowCount		int,
	 @blnArchivedData		bit
AS
BEGIN


	INSERT INTO QueryCachePacket
			   (idfQueryCache
			   ,intQueryCachePacketNumber
			   ,blbQueryCachePacket
			   ,intTableRowCount
			   ,blnArchivedData)
		 VALUES
			   (@idfQueryCache
			   ,@intQueryCachePacketNumber
			   ,@blbQueryCachePacket
			   ,@intPacketRowCount
			   ,@blnArchivedData)
	
END