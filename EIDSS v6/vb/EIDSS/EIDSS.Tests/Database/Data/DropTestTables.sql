IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spLookupTable1_SelectLookup]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spLookupTable1_SelectLookup]
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spLookupTable2_SelectLookup]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spLookupTable2_SelectLookup]
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[fn_LookupTable2_SelectList]') AND xtype in (N'FN', N'IF', N'TF'))
DROP FUNCTION [dbo].[fn_LookupTable2_SelectList]
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
DROP TABLE [dbo].[LookupTable2]
