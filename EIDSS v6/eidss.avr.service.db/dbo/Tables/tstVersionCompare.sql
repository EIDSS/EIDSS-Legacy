CREATE TABLE [dbo].[tstVersionCompare] (
    [strModuleName]      VARCHAR (50)     NOT NULL,
    [strModuleVersion]   VARCHAR (50)     NOT NULL,
    [strDatabaseVersion] VARCHAR (50)     NOT NULL,
    [rowguid]            UNIQUEIDENTIFIER CONSTRAINT [tstVersionCompare_newid] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    CONSTRAINT [XPKtstVersionCompare] PRIMARY KEY CLUSTERED ([strModuleName] ASC, [strModuleVersion] ASC, [strDatabaseVersion] ASC)
);

