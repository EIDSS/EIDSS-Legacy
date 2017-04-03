IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnMasterObject_SelectList]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnMasterObject_SelectList]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnLookupTable2_SelectList]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnLookupTable2_SelectList]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spLookupTable1_SelectLookup]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spLookupTable1_SelectLookup]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spLookupTable2_SelectLookup]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spLookupTable2_SelectLookup]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spLookupTable2Param_SelectLookup]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spLookupTable2Param_SelectLookup]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spMasterObject_SelectDetail]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spMasterObject_SelectDetail]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spChildObject_SelectDetail]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spChildObject_SelectDetail]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spSiblingObject_SelectDetail]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spSiblingObject_SelectDetail]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spLinkObject_SelectDetail]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spLinkObject_SelectDetail]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spTestObject_SelectDetail]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spTestObject_SelectDetail]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spMasterObject_Post]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spMasterObject_Post]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spSiblingObject_Post]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spSiblingObject_Post]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spMasterObject_CanDelete]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spMasterObject_CanDelete]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spListPanelItem_Post]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].spListPanelItem_Post
GO


/****** Object:  Table [dbo].[MasterTable]    Script Date: 02/07/2008 11:45:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChildTable]') AND type in (N'U'))
DROP TABLE [dbo].[ChildTable]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MasterSiblingTable]') AND type in (N'U'))
DROP TABLE [dbo].[MasterSiblingTable]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MasterTable]') AND type in (N'U'))
DROP TABLE [dbo].[MasterTable]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinkTable]') AND type in (N'U'))
DROP TABLE [dbo].[LinkTable]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LookupTable2]') AND type in (N'U'))
DROP TABLE [dbo].[LookupTable2]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LookupTable1]') AND type in (N'U'))
DROP TABLE [dbo].[LookupTable1];
GO
/****** Object:  Table [dbo].[LinkTable]    Script Date: 05/27/2009 12:52:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LinkTable](
	[LinkID] [bigint] NOT NULL,
	[LinkField1] [nvarchar](50) NULL,
 CONSTRAINT [PK__LinkTable__6245878F] PRIMARY KEY NONCLUSTERED 
(
	[LinkID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LookupTable1]    Script Date: 05/27/2009 12:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupTable1](
	[Lookup1ID] [bigint] NOT NULL,
	[Lookup1Field1] [nvarchar](50) NULL,
 CONSTRAINT [PK__LookupTable1__670A3CAC] PRIMARY KEY NONCLUSTERED 
(
	[Lookup1ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LookupTable2]    Script Date: 05/27/2009 12:54:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookupTable2](
	[Lookup2ID] [bigint] NOT NULL,
	[Lookup2ParentID] [bigint] NULL,
	[Lookup2Field1] [nvarchar](50) NULL,
	[intRowStatus] [int] NOT NULL default(0)
 CONSTRAINT [PK__LookupTable2__68F2851E] PRIMARY KEY NONCLUSTERED 
(
	[Lookup2ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[LookupTable2]  WITH CHECK ADD  CONSTRAINT [FK_LookupTable2_LookupTable1] FOREIGN KEY([Lookup2ParentID])
REFERENCES [dbo].[LookupTable1] ([Lookup1ID])
GO
ALTER TABLE [dbo].[LookupTable2] CHECK CONSTRAINT [FK_LookupTable2_LookupTable1]
GO
/****** Object:  Table [dbo].[MasterTable]    Script Date: 05/27/2009 12:49:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterTable](
	[MasterID] [bigint] NOT NULL,
	[LookupField1] [bigint] NULL,
	[LookupField2] [bigint] NULL,
	[LinkField1] [bigint] NULL,
	[TextField] [nvarchar](100) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[MasterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MasterTable]  WITH CHECK ADD  CONSTRAINT [FK_MasterTable_LinkTable] FOREIGN KEY([LinkField1])
REFERENCES [dbo].[LinkTable] ([LinkID])
GO
ALTER TABLE [dbo].[MasterTable] CHECK CONSTRAINT [FK_MasterTable_LinkTable]
GO
ALTER TABLE [dbo].[MasterTable]  WITH CHECK ADD  CONSTRAINT [FK_MasterTable_LookupTable1] FOREIGN KEY([LookupField1])
REFERENCES [dbo].[LookupTable1] ([Lookup1ID])
GO
ALTER TABLE [dbo].[MasterTable] CHECK CONSTRAINT [FK_MasterTable_LookupTable1]
GO
ALTER TABLE [dbo].[MasterTable]  WITH CHECK ADD  CONSTRAINT [FK_MasterTable_LookupTable21] FOREIGN KEY([LookupField2])
REFERENCES [dbo].[LookupTable2] ([Lookup2ID])
GO
ALTER TABLE [dbo].[MasterTable] CHECK CONSTRAINT [FK_MasterTable_LookupTable21]
GO
/****** Object:  Table [dbo].[MasterSiblingTable]    Script Date: 05/27/2009 13:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterSiblingTable](
	[MasterSiblingID] [bigint] NOT NULL,
	[MasterSiblingField1] [nvarchar](50) NULL,
 CONSTRAINT [PK__MasterSiblingTab__642DD001] PRIMARY KEY NONCLUSTERED 
(
	[MasterSiblingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MasterSiblingTable]  WITH CHECK ADD  CONSTRAINT [FK_MasterSiblingTable_MasterTable] FOREIGN KEY([MasterSiblingID])
REFERENCES [dbo].[MasterTable] ([MasterID])
GO
ALTER TABLE [dbo].[MasterSiblingTable] CHECK CONSTRAINT [FK_MasterSiblingTable_MasterTable]
GO

/****** Object:  Table [dbo].[ChildTable]    Script Date: 05/27/2009 13:16:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChildTable](
	[ChildID] [bigint] NOT NULL,
	[ParentID] [bigint] NULL,
	[ChildField1] [nvarchar](50) NULL,
	[LookupField1] [nvarchar](36) NULL,
 CONSTRAINT [PK__ChildTable__5F691AE4] PRIMARY KEY NONCLUSTERED 
(
	[ChildID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ChildTable]  WITH CHECK ADD  CONSTRAINT [FK_ChildTable_MasterTable] FOREIGN KEY([ParentID])
REFERENCES [dbo].[MasterTable] ([MasterID])
GO
ALTER TABLE [dbo].[ChildTable] CHECK CONSTRAINT [FK_ChildTable_MasterTable]

GO

DECLARE @masterID as bigint;
DECLARE @linkID as bigint;
DECLARE @childID as bigint;
SET @masterID = 1000000
SET @linkID = 2000000
SET @childID = 3000000
INSERT INTO [LinkTable]
           (
           [LinkID]
           ,[LinkField1])
     VALUES
           (@linkID
           ,'LinkValue1')

INSERT INTO [LinkTable]
           (
           [LinkID]
           ,[LinkField1])
     VALUES
           ((@linkID+1)
           ,'LinkValue2')


DECLARE @I BIGINT
DECLARE @J BIGINT
SET @I=1
WHILE @I<=10
BEGIN
	INSERT INTO [LookupTable1]
			   (
			   [Lookup1ID]
			   ,[Lookup1Field1])
		 VALUES
			   (@I
			   ,'Lookup1Value'+CAST(@I AS VARCHAR(36)))
	SET @I=@I+1
END

DECLARE @K INT
SET @I=1
SET @J=1
SET @K=1
WHILE @I<=10
BEGIN
	WHILE @J<=10
	BEGIN
	INSERT INTO [LookupTable2]
			   (
			   [Lookup2ID]
			   ,[Lookup2ParentID]
			   ,[Lookup2Field1])
		 VALUES
			   (@K
				,@I
			   ,'Lookup2Value'+CAST(@K AS VARCHAR(36)))
		SET @J=@J+1
		SET @K=@K+1
	END
	SET @J=1
	SET @I=@I+1
END
           
INSERT INTO [MasterTable]
           ([MasterID]
           ,[LookupField1]
           ,[LookupField2]
           ,[LinkField1]
		   ,[TextField])
     VALUES
           (@masterID
           ,1
           ,1
           ,@linkID
		   ,'qqq')

INSERT INTO [ChildTable]
           (
		   [ChildID]		
           ,[ParentID]
           ,[ChildField1]
           ,[LookupField1]
           )
     VALUES
           (
			@childID
		   ,@masterID
           ,'ChildValue'
           ,1
           )

INSERT INTO [MasterSiblingTable]
           (
           [MasterSiblingID]
           ,[MasterSiblingField1])
     VALUES
           (@masterID
           ,'SiblingValue')
GO

CREATE      PROCEDURE [dbo].[spTestObject_SelectDetail](
	@ID as bigint, 
	@LangID As nvarchar(50)
	)
AS
SELECT  *
FROM 
	MasterTable
WHERE 
	MasterID = @ID

SELECT  *
FROM ChildTable
WHERE 
	ParentID = @ID

SELECT  *
FROM MasterSiblingTable
WHERE 
	MasterSiblingID = @ID

SELECT  LinkTable.*
FROM LinkTable
INNER JOIN MasterTable ON 
	MasterTable.LinkField1=LinkTable.LinkID
WHERE 
	MasterTable.MasterID = @ID

GO

CREATE      PROCEDURE [dbo].[spLookupTable1_SelectLookup]
	@LangID As nvarchar(50)
AS
SELECT  *, cast(0 as int) as intRowStatus
FROM 
	LookupTable1

GO

CREATE      PROCEDURE [dbo].[spLookupTable2_SelectLookup]
	@LangID As nvarchar(50)
AS
SELECT  *
FROM 
	LookupTable2

GO

CREATE      PROCEDURE [dbo].[spLookupTable2Param_SelectLookup]
	@LangID As nvarchar(50),
	@ParentID as int
AS
SELECT  *
FROM 
	LookupTable2
WHERE
	Lookup2ParentID = @ParentID

GO

CREATE      PROCEDURE [dbo].[spMasterObject_SelectDetail](
	@MasterID as bigint, 
	@LangID As nvarchar(50)
	)
AS
SELECT  *
FROM 
	MasterTable
WHERE 
	MasterID = @MasterID

GO

CREATE      PROCEDURE [dbo].[spChildObject_SelectDetail](
	@ID as bigint, 
	@LangID As nvarchar(50)
	)
AS
SELECT  *
FROM ChildTable
WHERE 
	ParentID = @ID

GO

CREATE      PROCEDURE [dbo].[spSiblingObject_SelectDetail](
	@ID as bigint, 
	@LangID As nvarchar(50)
	)
AS

SELECT  *
FROM MasterSiblingTable
WHERE 
	MasterSiblingID = @ID

GO

CREATE      PROCEDURE [dbo].[spSiblingObject_Post](
	@MasterSiblingID as bigint, 
	@MasterSiblingField1 As nvarchar(50)
	)
AS

UPDATE MasterSiblingTable
SET MasterSiblingField1 = @MasterSiblingField1
WHERE MasterSiblingID = @MasterSiblingID

GO

CREATE      PROCEDURE [dbo].[spLinkObject_SelectDetail](
	@ID as bigint, 
	@LangID As nvarchar(50)
	)
AS

SELECT  *
FROM LinkTable
WHERE 
	LinkID = @ID

GO

CREATE PROCEDURE [dbo].[spMasterObject_Post](
	@Action int,
	@MasterID as bigint, 
	@LookupField1 bigint,
	@LookupField2 bigint, 
	@LinkField1 bigint output,
	@TextField nvarchar(100) output
	)
AS

if (@Action = 4)
begin
	insert into dbo.MasterTable
	( MasterID, LookupField1, LookupField2, LinkField1, TextField)
	values
	(@MasterID, @LookupField1, @LookupField2, @LinkField1, @TextField)

	select @TextField = @TextField + 'i'

	SELECT Cast(SCOPE_IDENTITY() as bigint)
end

else if (@Action = 16)
begin
	if @TextField = 'RAISERROR'
		begin
	   		RAISERROR ('msgSpErr', 16, 1)
			return
		end

	update dbo.MasterTable
	set 
		LookupField1 = @LookupField1,
		LookupField2 = @LookupField2, 
		LinkField1 = @LinkField1, 
		TextField = @TextField
	where
		MasterID = @MasterID

	select @TextField = @TextField + 'u'
end

else if (@Action = 8)
begin
	delete from dbo.MasterTable
	where
		MasterID = @MasterID
end

GO


create	function	[dbo].[fnMasterObject_SelectList]
(
	@LangID as nvarchar(50) 
)
returns table
as
return
	SELECT  *
	FROM 
		MasterTable

GO

CREATE	function	[dbo].[fnLookupTable2_SelectList]
(
	@LangID as nvarchar(50) 
)
returns table
as
return
	SELECT  *
	FROM 
		LookupTable2
GO

CREATE PROCEDURE [dbo].[spMasterObject_CanDelete](
	@ID as bigint, 
	@Result bit output
	)
AS
	select @Result = 0


GO

CREATE PROCEDURE [dbo].spListPanelItem_Post(
	@ID as bigint
	)
AS
	
	UPDATE LookupTable2
	SET  intRowStatus = 1 
	WHERE @ID = Lookup2ID

GO


