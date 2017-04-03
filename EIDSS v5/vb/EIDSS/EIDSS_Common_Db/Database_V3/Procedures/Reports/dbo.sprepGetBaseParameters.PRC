GO
/****** Object:  StoredProcedure [dbo].[sprepGetBaseParameters]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sprepGetBaseParameters]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sprepGetBaseParameters]

/****** Object:  StoredProcedure [dbo].[sprepGetBaseParameters]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY This procedure returns language, country and organization information related with current site.

--##REMARKS Author: Vasilyev I.
--##REMARKS Create date: 30.11.2009

--##RETURNS Don't use 

/*
--Example of a call of procedure:

exec sprepGetBaseParameters 'en'

*/ 
 
CREATE PROCEDURE [dbo].[sprepGetBaseParameters]
	@LangId varchar(36)
AS
BEGIN
	declare @Language nvarchar(200)
	declare @SiteInfo table
	(
		idfsCountry			bigint, 
		strCountryName		nvarchar(200),
		idfsRegion			bigint,
		idfsSite			bigint,
		strHASCsiteID		nvarchar(200),
		strSiteName			nvarchar(200),
		strSiteID			nvarchar(200),
		idfsSiteType		bigint,
		strSiteTypeName		nvarchar(200),
		idfOffice			bigint,
		strOrganizationName nvarchar(200)
	)
	insert into @SiteInfo
	exec		spGetSiteInfo @LANGID 

	select		@Language = rf.[Name] 
	from		dbo.fnReference(@LANGID, 19000049) rf
	where		rf.idfsReference = dbo.fnGetLanguageCode(@LANGID)
	
	

	select		@Language			as [strLanguageName], 
				strCountryName		as [strCountryName], 
				strOrganizationName as [strOrganizationName],
				idfsCountry			as [idfsCountry]
	from		@SiteInfo

END
GO
