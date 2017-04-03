CREATE TABLE [dbo].[QueryCache] (
    [idfQueryCache]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [idfQuery]                 BIGINT        NOT NULL,
    [strLanguage]              NVARCHAR (50) CONSTRAINT [QueryCache_strLanguage] DEFAULT ('en') NOT NULL,
    [blbQuerySchema]           IMAGE         NULL,
    [intQueryColumnCount]      INT           NOT NULL,
    [datQueryRefresh]          DATETIME      CONSTRAINT [QueryCache_datQueryRefresh] DEFAULT (getdate()) NOT NULL,
    [datQueryCacheRequest]     DATETIME      NULL,
    [blnUseArchivedData]       BIT           CONSTRAINT [QueryCache_blnUseArchivedData] DEFAULT ((0)) NOT NULL,
    [blnActualQueryCache]      BIT           CONSTRAINT [QueryCache_blnActualQueryCache] DEFAULT ((1)) NOT NULL,
    [datUserQueryCacheRequest] DATETIME      NULL,
    CONSTRAINT [XPKQueryCache] PRIMARY KEY CLUSTERED ([idfQueryCache] ASC)
);



