CREATE TABLE [dbo].[QueryCachePacket] (
    [idfQueryCachePacket]       BIGINT IDENTITY(1,1) NOT NULL,
    [idfQueryCache]             BIGINT NOT NULL,
    [intQueryCachePacketNumber] INT    CONSTRAINT [QueryCachePacket_intQueryCachePacketNumber] DEFAULT ((0)) NOT NULL,
    [blbQueryCachePacket]       IMAGE  NULL,
    [intTableRowCount]          INT    CONSTRAINT [QueryCachePacket_intTableRowCount] DEFAULT ((0)) NOT NULL,
    [blnArchivedData]           BIT    CONSTRAINT [QueryCachePacket_blnArchivedData] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [XPKQueryCachePacket] PRIMARY KEY CLUSTERED ([idfQueryCachePacket] ASC),
    CONSTRAINT [FK_QueryCachePacket_QueryCache__idfQueryCache] FOREIGN KEY ([idfQueryCache]) REFERENCES [dbo].[QueryCache] ([idfQueryCache]) NOT FOR REPLICATION
);

