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

/****** Object:  Table [dbo].[AVR_HumanCaseReport]    Script Date: 06/18/2013 14:59:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AVR_HumanCaseReport]') AND type in (N'U'))
DROP TABLE [dbo].[AVR_HumanCaseReport]
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



/****** Object:  Table [dbo].[AVR_HumanCaseReport]    Script Date: 06/18/2013 12:56:31 ******/

CREATE TABLE [dbo].[AVR_HumanCaseReport](
	[sflHC_PatientDOB] [datetime] NULL,
	[sflHC_PatientAge] [int] NULL,
	[sflHC_PatientAgeType_ID] [bigint] NULL,
	[sflHC_PatientAgeType] [nvarchar](4000) NULL,
	[sflHC_PatientName] [nvarchar](1204) NULL,
	[sflHC_PatientSex_ID] [bigint] NULL,
	[sflHC_PatientSex] [nvarchar](4000) NULL,
	[sflHC_PatientDeathDate] [datetime] NULL,
	[sflHC_PatientCRRegion_ID] [bigint] NULL,
	[sflHC_PatientCRRegion] [nvarchar](730) NULL,
	[sflHC_PatientCRRayon_ID] [bigint] NULL,
	[sflHC_PatientCRRayon] [nvarchar](730) NULL,
	[sflHC_PatientCRSettlement_ID] [bigint] NULL,
	[sflHC_PatientCRSettlement] [nvarchar](730) NULL,
	[sflHC_PatientOccupation_ID] [bigint] NULL,
	[sflHC_PatientOccupation] [nvarchar](4000) NULL,
	[sflHC_PatientNationality_ID] [bigint] NULL,
	[sflHC_PatientNationality] [nvarchar](4000) NULL,
	[sflHC_CaseID] [nvarchar](400) NULL,
	[sflHC_Diagnosis_ID] [bigint] NULL,
	[sflHC_Diagnosis] [nvarchar](4000) NULL,
	[sflHC_DiagnosisDate] [datetime] NULL,
	[sflHC_ChangedDiagnosis_ID] [bigint] NULL,
	[sflHC_ChangedDiagnosis] [nvarchar](4000) NULL,
	[sflHC_ChangedDiagnosisDate] [datetime] NULL,
	[sflHC_FinalDiagnosis_ID] [bigint] NULL,
	[sflHC_FinalDiagnosis] [nvarchar](4000) NULL,
	[sflHC_FinalDiagnosisDate] [datetime] NULL,
	[sflHC_EnteredDate] [datetime] NULL,
	[sflHC_NotificationDate] [datetime] NULL,
	[sflHC_Outcome_ID] [bigint] NULL,
	[sflHC_Outcome] [nvarchar](4000) NULL,
	[sflHC_PatientAgeGroup] [nvarchar](200) NULL,
	[sflHC_RelatedToOutbreak_ID] [bigint] NULL,
	[sflHC_RelatedToOutbreak] [nvarchar](4000) NULL,
	[sflHC_CompletionPaperFormDate] [datetime] NULL,
	[sflHC_SymptomOnsetDate] [datetime] NULL,
	[sflHC_CaseClassification_ID] [bigint] NULL,
	[sflHC_CaseClassification] [nvarchar](4000) NULL,
	[sflHC_CaseProgressStatus_ID] [bigint] NULL,
	[sflHC_CaseProgressStatus] [nvarchar](4000) NULL,
	[sflHC_OutbreakID] [nvarchar](400) NULL,
	[sflHC_SamplesCollected_ID] [bigint] NULL,
	[sflHC_SamplesCollected] [nvarchar](4000) NULL,
	[sflHC_ClinicalDiagBasis_ID] [int] NULL,
	[sflHC_ClinicalDiagBasis] [nvarchar](4000) NULL,
	[sflHC_EpiDiagBasis_ID] [int] NULL,
	[sflHC_EpiDiagBasis] [nvarchar](4000) NULL,
	[sflHC_LabDiagBasis_ID] [int] NULL,
	[sflHC_LabDiagBasis] [nvarchar](4000) NULL,
	[sflHC_CS__10034010__9253110000000][sql_variant] NULL,
	[sflHC_CS__10034010__9253150000000][sql_variant] NULL,
	[sflHC_CS__10034010__9254270000000_ID][sql_variant] NULL,
	[sflHC_CS__10034010__9254270000000][sql_variant] NULL
) ON [PRIMARY]

GO

INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-01',23,1,'','xxx',123,'Male',NULL,123401,'Region',234501,'Rayon01',3421501,'sett01',null,NULL,NULL,NULL,'HC1000001',123401,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542301,'In Process',NULl,21342301,'Sample',23423401,'Smallpox',2342301,'DDD',432401,'ccc', getdate(), year(getdate()), 25460000000, 'Yes')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-02',23,1,'','xxx',123,'Male',NULL,123402,'Region',234502,'Rayon02',3421502,'sett02',null,NULL,NULL,NULL,'HC1000002',123402,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542302,'In Process',NULl,21342302,'Sample',23423402,'Smallpox',2342302,'DDD',432402,'ccc', getdate(), year(getdate()), 25460000000, 'Yes')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-03',23,1,'','xxx',123,'Male',NULL,123403,'Region',234503,'Rayon03',3421503,'sett03',null,NULL,NULL,NULL,'HC1000003',123403,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542303,'In Process',NULl,21342303,'Sample',23423403,'Smallpox',2342303,'DDD',432403,'ccc', getdate(), year(getdate()), 25460000000, 'Yes')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-04',23,1,'','xxx',123,'Male',NULL,123404,'Region',234504,'Rayon04',3421504,'sett04',null,NULL,NULL,NULL,'HC1000004',123404,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542304,'In Process',NULl,21342304,'Sample',23423404,'Smallpox',2342304,'DDD',432404,'ccc', getdate(), year(getdate()), 25460000000, 2)
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-05',23,1,'','xxx',123,'Male',NULL,123405,'Region',234505,'Rayon05',3421505,'sett05',null,NULL,NULL,NULL,'HC1000005',123405,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542305,'In Process',NULl,21342305,'Sample',23423405,'Smallpox',2342305,'DDD',432405,'ccc', getdate(), year(getdate()), 25460000000, 1)
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-06',23,1,'','xxx',123,'Male',NULL,123406,'Region',234506,'Rayon06',3421506,'sett06',null,NULL,NULL,NULL,'HC1000006',123406,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542306,'In Process',NULl,21342306,'Sample',23423406,'Smallpox',2342306,'DDD',432406,'ccc', '2010-01-01', year(getdate()), 25460000000, 'Yes')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-07',23,1,'','xxx',123,'Male',NULL,123407,'Region',234507,'Rayon07',3421507,'sett07',null,NULL,NULL,NULL,'HC1000007',123407,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542307,'In Process',NULl,21342307,'Sample',23423407,'Smallpox',2342307,'DDD',432407,'ccc', '2011-01-01', year(getdate()), 25460000000, 'Yes')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-08',23,1,'','xxx',123,'Male',NULL,123408,'Region',234508,'Rayon08',3421508,'sett08',null,NULL,NULL,NULL,'HC1000008',123408,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542308,'In Process',NULl,21342308,'Sample',23423408,'Smallpox',2342308,'DDD',432408,'ccc', getdate(), year(getdate()), 0, 'Yes')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-09',23,1,'','xxx',123,'Male',NULL,123409,'Region',234509,'Rayon09',3421509,'sett09',null,NULL,NULL,NULL,'HC1000009',123409,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542309,'In Process',NULl,21342309,'Sample',23423409,'Smallpox',2342309,'DDD',432409,'ccc', getdate(), 0, 0, 'Yes')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-10',23,1,'','xxx',123,'Male',NULL,123410,'Region',234510,'Rayon10',3421510,'sett10',null,NULL,NULL,NULL,'HC1000010',123410,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542310,'In Process',NULl,21342310,'Sample',23423410,'Smallpox',2342310,'DDD',432410,'ccc', getdate(), year(getdate()), 25460000000, 'Yes')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-11',23,1,'','xxx',123,'Male',NULL,123411,'Region',234511,'Rayon11',3421511,'sett11',null,NULL,NULL,NULL,'HC1000011',123411,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542311,'In Process',NULl,21342311,'Sample',23423411,'Smallpox',2342311,'DDD',432411,'ccc', getdate(), 1, 25460000000, 'No')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-12',23,1,'','xxx',123,'Male',NULL,123412,'Region',234512,'Rayon12',3421512,'sett12',null,NULL,NULL,NULL,'HC1000012',123412,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542312,'In Process',NULl,21342312,'Sample',23423412,'Smallpox',2342312,'DDD',432412,'ccc', getdate(), 2, 0, 'No')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-13',23,1,'','xxx',123,'Male',NULL,123413,'Region',234513,'Rayon13',3421513,'sett13',null,NULL,NULL,NULL,'HC1000013',123413,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542313,'In Process',NULl,21342313,'Sample',23423413,'Smallpox',2342313,'DDD',432413,'ccc', getdate(), 3, 1, 'Unknown')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-14',23,1,'','xxx',123,'Male',NULL,123414,'Region',234514,'Rayon14',3421514,'sett14',null,NULL,NULL,NULL,'HC1000014',123414,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542314,'In Process',NULl,21342314,'Sample',23423414,'Smallpox',2342314,'DDD',432414,'ccc', getdate(), 4, 2, 'No')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-15',23,1,'','xxx',123,'Male',NULL,123415,'Region',234515,'Rayon15',3421515,'sett15',null,NULL,NULL,NULL,'HC1000015',123415,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542315,'In Process',NULl,21342315,'Sample',23423415,'Smallpox',2342315,'DDD',432415,'ccc', getdate(), 5, 25460000000, 'No')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-16',23,1,'','xxx',123,'Male',NULL,123416,'Region',234516,'Rayon16',3421516,'sett16',null,NULL,NULL,NULL,'HC1000016',123416,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542316,'In Process',NULl,21342316,'Sample',23423416,'Smallpox',2342316,'DDD',432416,'ccc', getdate(), 1, 25460000000, 'No')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-17',23,1,'','xxx',123,'Male',NULL,123417,'Region',234517,'Rayon17',3421517,'sett17',null,NULL,NULL,NULL,'HC1000017',123417,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542317,'In Process',NULl,21342317,'Sample',23423417,'Smallpox',2342317,'DDD',432417,'ccc', getdate(), 2, 25460000000, 'No')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-18',23,1,'','xxx',123,'Male',NULL,123418,'Region',234518,'Rayon18',3421518,'sett18',null,NULL,NULL,NULL,'HC1000018',123418,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542318,'In Process',NULl,21342318,'Sample',23423418,'Smallpox',2342318,'DDD',432418,'ccc', getdate(), 3, 25460000000, 'Unknown')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-19',23,1,'','xxx',123,'Male',NULL,123419,'Region',234519,'Rayon19',3421519,'sett19',null,NULL,NULL,NULL,'HC1000019',123419,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542319,'In Process',NULl,21342319,'Sample',23423419,'Smallpox',2342319,'DDD',432419,'ccc', '2013-01-01', 4, 25460000000, 'No')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-20',23,1,'','xxx',123,'Male',NULL,123420,'Region',234520,'Rayon20',3421520,'sett20',null,NULL,NULL,NULL,'HC1000020',123420,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542320,'In Process',NULl,21342320,'Sample',23423420,'Smallpox',2342320,'DDD',432420,'ccc', getdate(), 5, 25460000000, 'No')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-21',23,1,'','xxx',123,'Male',NULL,123421,'Region',234521,'Rayon21',3421521,'sett21',null,NULL,NULL,NULL,'HC1000021',123421,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542321,'In Process',NULl,21342321,'Sample',23423421,'Smallpox',2342321,'DDD',432421,'ccc', getdate(), 1, 25460000000, 'No')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-22',23,1,'','xxx',123,'Male',NULL,123422,'Region',234522,'Rayon22',3421522,'sett22',null,NULL,NULL,NULL,'HC1000022',123422,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542322,'In Process',NULl,21342322,'Sample',23423422,'Smallpox',2342322,'DDD',432422,'ccc', getdate(), 2, 25460000000, 'No')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-23',23,1,'','xxx',123,'Male',NULL,123423,'Region',234523,'Rayon23',3421523,'sett23',null,NULL,NULL,NULL,'HC1000023',123423,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542323,'In Process',NULl,21342323,'Sample',23423423,'Smallpox',2342323,'DDD',432423,'ccc', getdate(), 3, 25460000000, 'Unknown')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-24',23,1,'','xxx',123,'Male',NULL,123424,'Region',234524,'Rayon24',3421524,'sett24',null,NULL,NULL,NULL,'HC1000024',123424,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542324,'In Process',NULl,21342324,'Sample',23423424,'Smallpox',2342324,'DDD',432424,'ccc', getdate(), 4, 25460000000, 'No')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-25',23,1,'','xxx',123,'Male',NULL,123425,'Region',234525,'Rayon25',3421525,'sett25',null,NULL,NULL,NULL,'HC1000025',123425,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542325,'In Process',NULl,21342325,'Sample',23423425,'Smallpox',2342325,'DDD',432425,'ccc', getdate(), 5, 25460000000, 'No')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-26',23,1,'','xxx',123,'Male',NULL,123426,'Region',234526,'Rayon26',3421526,'sett26',null,NULL,NULL,NULL,'HC1000026',123426,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542326,'In Process',NULl,21342326,'Sample',23423426,'Smallpox',2342326,'DDD',432426,'ccc', getdate(), year(getdate()), 25460000000, 'Yes')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-27',23,1,'','xxx',123,'Male',NULL,123427,'Region',234527,'Rayon27',3421527,'sett27',null,NULL,NULL,NULL,'HC1000027',123427,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542327,'In Process',NULl,21342327,'Sample',23423427,'Smallpox',2342327,'DDD',432427,'ccc', getdate(), year(getdate()), 25460000000, 'Yes')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-28',23,1,'','xxx',123,'Male',NULL,123428,'Region',234528,'Rayon28',3421528,'sett28',null,NULL,NULL,NULL,'HC1000028',123428,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542328,'In Process',NULl,21342328,'Sample',23423428,'Smallpox',2342328,'DDD',432428,'ccc', getdate(), year(getdate()), 25460000000, 'Yes')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-29',23,1,'','xxx',123,'Male',NULL,123429,'Region',234529,'Rayon29',3421529,'sett29',null,NULL,NULL,NULL,'HC1000029',123429,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542329,'In Process',NULl,21342329,'Sample',23423429,'Smallpox',2342329,'DDD',432429,'ccc', getdate(), year(getdate()), 25460000000, 'Yes')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-01-30',23,1,'','xxx',123,'Male',NULL,123430,'Region',234530,'Rayon30',3421530,'sett30',null,NULL,NULL,NULL,'HC1000030',123430,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542330,'In Process',NULl,21342330,'Sample',23423430,'Smallpox',2342330,'DDD',432430,'ccc', getdate(), year(getdate()), 25460000000, 'Yes')
INSERT INTO [dbo].[AVR_HumanCaseReport]VALUES     ('1990-02-01',23,1,'','xxx',123,'Male',NULL,123431,'Region',234531,'Rayon31',3421531,'sett31',null,NULL,NULL,NULL,'HC1000031',123431,'Smallpox','2010-01-01',NULL,NULL,NULL,123412,'Smallpox','2010-01-01','2010-01-02','2010-01-03',NULL,NULL,'age',NULL,NULL,'2010-01-04','2010-01-05',32451234,'Confirmed',542331,'In Process',NULl,21342331,'Sample',23423431,'Smallpox',2342331,'DDD',432431,'ccc', getdate(), year(getdate()), 25460000000, 'Yes')

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


