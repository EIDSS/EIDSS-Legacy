CREATE TABLE [dbo].[tstLocalSiteOptions] (
    [strName]  NVARCHAR (200) NOT NULL,
    [strValue] NVARCHAR (200) NULL,
    CONSTRAINT [XPKtstLocalSiteOptions] PRIMARY KEY CLUSTERED ([strName] ASC)
);

