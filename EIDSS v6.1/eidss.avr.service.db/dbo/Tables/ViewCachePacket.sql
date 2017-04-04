CREATE TABLE [dbo].[ViewCachePacket](
	[idfViewCachePacket] [bigint] IDENTITY(1,1) NOT NULL,
	[idfViewCache] [bigint] NOT NULL,
	[intViewCachePacketNumber] [int]CONSTRAINT [ViewCachePacket_intViewCachePacketNumber]  DEFAULT ((0)) NOT NULL,
	[blbViewCachePacket] [image] NULL,
	[intTableRowCount] [int] CONSTRAINT [ViewCachePacket_intTableRowCount]  DEFAULT ((0))NOT NULL,
    CONSTRAINT [XPKViewCachePacket] PRIMARY KEY CLUSTERED (	[idfViewCachePacket] ASC),
	CONSTRAINT [FK_ViewCachePacket_ViewCache__idfViewCache] FOREIGN KEY([idfViewCache])REFERENCES [dbo].[ViewCache] ([idfViewCache])NOT FOR REPLICATION ,
) ;


