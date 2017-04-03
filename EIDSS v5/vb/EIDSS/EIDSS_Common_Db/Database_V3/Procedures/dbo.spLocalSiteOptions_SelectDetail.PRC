SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLocalSiteOptions_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spLocalSiteOptions_SelectDetail]
GO





CREATE     PROCEDURE dbo.spLocalSiteOptions_SelectDetail 
AS
SELECT 
	 strName
	,strValue 
FROM tstLocalSiteOptions

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

