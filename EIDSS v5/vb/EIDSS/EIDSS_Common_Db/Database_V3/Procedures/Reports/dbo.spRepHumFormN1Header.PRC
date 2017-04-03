GO
/****** Object:  StoredProcedure [dbo].[spRepHumFormN1Header]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRepHumFormN1Header]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRepHumFormN1Header]

/****** Object:  StoredProcedure [dbo].[spRepHumFormN1Header]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY This procedure returns Header (Page 1) for Form N1

--##REMARKS Author: 
--##REMARKS Create date: 

--##RETURNS Don't use 

/*
--Example of a call of procedure:

exec spRepHumFormN1Header 'en', 2011, 1, 1344350000000, 1345100000000

*/ 
 
CREATE PROCEDURE [dbo].[spRepHumFormN1Header]
	@LangId			as varchar(36),
	@Year			as int, 
	@Month			as int = null,
	@RegionID		as bigint = null,
	@RayonID		as bigint = null
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
	exec		spGetSiteInfo @LangId 

  DECLARE @MonthTranslation NVARCHAR(300)
  DECLARE @CountryID BIGINT
  DECLARE @Address NVARCHAR(1000)
  DECLARE @RayonName NVARCHAR(300)
  DECLARE @Region NVARCHAR(300)
  DECLARE @strParameters NVARCHAR(1000)
  DECLARE @strOrganizationName  NVARCHAR(1000)

	if @Month is not null
	begin
		select		@MonthTranslation = IsNull(snt.strTextString, br.strDefault)
		from		trtBaseReference br
		left join	trtStringNameTranslation snt
		on			snt.idfsBaseReference = br.idfsBaseReference
					and snt.idfsLanguage = dbo.fnGetLanguageCode(@LangId)
					and snt.intRowStatus = 0
		where		br.idfsReferenceType = 19000132	-- Report Additional Text
					and br.intRowStatus = 0
					and br.intOrder = @Month
	end

	SELECT		@CountryID = s.idfsCountry
	FROM		tstSite s
	INNER JOIN	tstLocalSiteOptions lso
	ON			lso.strName = N'SiteID'
				and lso.strValue = cast(s.idfsSite as nvarchar(20))

  SET @strParameters = 	ISNULL((SELECT [NAME] FROM fnGisReference(@LangID, 19000002 /*rftRayon*/) WHERE idfsReference = @RayonID),'') 
                       +
                       CASE WHEN @RayonID IS NOT NULL AND @RegionID IS NOT NULL AND @RegionID <> 1344340000000 -- Other rayons
                        THEN
                            ', '
                        ELSE ''
                       END
                       +
                       CASE WHEN @RegionID IS NOT NULL AND (@RayonID IS NULL OR @RegionID <> 1344340000000) -- Other rayons
                        THEN
                            ISNULL((SELECT [NAME] FROM fnGisReference(@LangID, 19000003 /*rftRegion*/) WHERE idfsReference = @RegionID),'') 
                        ELSE ''
                       END
						+
                       CASE WHEN @RayonID IS NULL AND @RegionID IS NULL
                        THEN
                            ISNULL((SELECT [NAME] FROM fnGisReference(@LangID, 19000001 /*rftCountry*/) WHERE idfsReference = @CountryID),'') 
                        ELSE ''
                       END
                       + '; ' +
                       ISNULL(@MonthTranslation + ', ', '') + 
                       CAST(@Year AS VARCHAR(4))
					
  SELECT 
      @Address = dbo.fnAddressString(@LangId, o.idfLocation),
      @strOrganizationName = strOrganizationName
  FROM tlbOffice o
      INNER JOIN @SiteInfo si
      ON si.idfOffice = o.idfOffice
    
	SELECT
	    @strParameters AS strParameters,
	    @strOrganizationName AS strOrganizationName,
	    @Address AS strOrganizationAddress

END
GO
