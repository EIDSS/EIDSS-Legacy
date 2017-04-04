
-- =============================================
-- Author:		Vasilyev I.
-- Create date: 06.04.2016
-- Description:	insert binary packet of view cache record
-- =============================================

/*
--Example of procedure call:

exec spAsViewCachePostPacket 1, 0x000102030405060708090A0B0C0D0E0F

*/

CREATE PROCEDURE spAsViewCachePostPacket
 	 @idfViewCache			bigint,
 	 @intViewCachePacketNumber		int,
 	 @blbViewCachePacket		image,
	 @intPacketRowCount		int
 
AS
BEGIN


	INSERT INTO ViewCachePacket
			   (idfViewCache
			   ,intViewCachePacketNumber
			   ,blbViewCachePacket
			   ,intTableRowCount)
		 VALUES
			   (@idfViewCache
			   ,@intViewCachePacketNumber
			   ,@blbViewCachePacket
			   ,@intPacketRowCount)
	
END