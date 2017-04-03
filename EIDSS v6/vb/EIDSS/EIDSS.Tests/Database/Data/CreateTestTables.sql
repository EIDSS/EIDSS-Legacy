/****** Object:  Table [dbo].[MasterTable]    Script Date: 02/07/2008 11:45:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MasterTable]') AND type in (N'U'))
DROP TABLE [dbo].[MasterTable]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChildTable]') AND type in (N'U'))
DROP TABLE [dbo].[ChildTable]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinkTable]') AND type in (N'U'))
DROP TABLE [dbo].[LinkTable]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SiblingTable]') AND type in (N'U'))
DROP TABLE [dbo].[SiblingTable]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LookupTable1]') AND type in (N'U'))
DROP TABLE [dbo].[LookupTable1]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LookupTable2]') AND type in (N'U'))
DROP TABLE [dbo].[LookupTable2];

CREATE TABLE [dbo].[MasterTable](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_MasterTable_ID]  DEFAULT (newid()),
	[LookupField1] [nvarchar](36) NULL,
	[LookupFiled2] [nvarchar](36) NULL,
	[LinkField1] [nvarchar](36) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[ChildTable](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_ChildTable_ID]  DEFAULT (newid()),
	[ParentID] [uniqueidentifier] NULL,
	[Field1] [varchar](36) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[LinkTable](
	[ID] NVARCHAR(36) NOT NULL,
	[Field1] [varchar](36) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[SiblingTable](
	[ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL CONSTRAINT [DF_SiblingTable_ID]  DEFAULT (newid()),
	[Field1] [varchar](36) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[LookupTable1](
	[ID]  NVARCHAR(36) NOT NULL,
	[Field1] [varchar](36) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[LookupTable2](
	[ID]  NVARCHAR(36) NOT NULL,
	[Field1] [varchar](36) NULL,
	[Field2] [varchar](36) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];




DECLARE @masterID as UniqueIdentifier;
SET @masterID = newid()

INSERT INTO [MasterTable]
           ([ID]
           ,[LookupField1]
           ,[LookupFiled2]
           ,[LinkField1])
     VALUES
           (@masterID
           ,'Lookup1Id1'
           ,'Lookup2Id2'
           ,'LinkID1')

INSERT INTO [ChildTable]
           (
           [ParentID]
           ,[Field1])
     VALUES
           (@masterID
           ,'ChildValue')

INSERT INTO [SiblingTable]
           (
           [ID]
           ,[Field1])
     VALUES
           (@masterID
           ,'SiblingValue')

INSERT INTO [LinkTable]
           (
           [ID]
           ,[Field1])
     VALUES
           ('LinkID1'
           ,'LinkValue1')

INSERT INTO [LinkTable]
           (
           [ID]
           ,[Field1])
     VALUES
           ('LinkID2'
           ,'LinkValue2')

DECLARE @I INT
SET @I=1
WHILE @I<=1000
BEGIN
	INSERT INTO [LookupTable1]
			   (
			   [ID]
			   ,[Field1])
		 VALUES
			   ('Lookup1Id'+CAST(@I AS NVARCHAR(36))
			   ,'Lookup1Value'+CAST(@I AS VARCHAR(36)))
	SET @I=@I+1
END

SET @I=1
WHILE @I<=1000
BEGIN
	INSERT INTO [LookupTable2]
			   (
			   [ID]
			   ,[Field1]
			   ,[Field2])
		 VALUES
			   ('Lookup2Id'+CAST(@I AS NVARCHAR(36))
				,'Lookup1Value'+CAST(@I AS VARCHAR(36))
			   ,'Lookup2Value'+CAST(@I AS VARCHAR(36)))
	SET @I=@I+1
END
           
GO

CREATE      PROCEDURE [dbo].[spLookupTable1_SelectLookup]
	@LanguageID As nvarchar(50)
AS
SELECT  ID, Field1
FROM 
	LookupTable1

GO

CREATE      PROCEDURE [dbo].[spLookupTable2_SelectLookup]
	@LanguageID As nvarchar(50)
AS
SELECT  ID, Field1, Field2
FROM 
	LookupTable2

GO



CREATE   FUNCTION [dbo].[fn_LookupTable2_SelectList](@LANGID as nvarchar(50))
returns table 
as
return
SELECT  ID, Field1, Field2
FROM 
	LookupTable2



GO
