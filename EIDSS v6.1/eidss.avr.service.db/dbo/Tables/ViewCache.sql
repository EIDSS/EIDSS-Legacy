
CREATE TABLE [dbo].[ViewCache](
	[idfViewCache] [bigint] IDENTITY(1,1) NOT NULL,
	[idfQueryCache] [bigint] NOT NULL,
	[idfLayout] [bigint] NOT NULL,
	[blbViewHeader] [image] NULL,
	[blbViewSchema] [image] NULL,
	[intViewColumnCount] [int] NOT NULL,
	[datViewRefresh] [datetime] CONSTRAINT [ViewCache_datViewRefresh]  DEFAULT (getdate()) NOT NULL,
	[datViewCacheRequest] [datetime] NULL,
	[blnActualViewCache] [bit] CONSTRAINT [ViewCache_blnActualViewCache]  DEFAULT ((1)) NOT NULL,
	[datUserViewCacheRequest] [datetime] NULL,
	CONSTRAINT [FK_ViewCache_QueryCache__idfQueryCache] FOREIGN KEY([idfQueryCache])REFERENCES [dbo].[QueryCache] ([idfQueryCache])NOT FOR REPLICATION ,
    CONSTRAINT [XPKViewCache] PRIMARY KEY CLUSTERED ([idfViewCache] ASC)
);




