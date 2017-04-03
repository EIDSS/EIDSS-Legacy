GO
/****** Object:  StoredProcedure [dbo].[spRepHumInfectiousAddressHeader]    Script Date: 10/20/2009 16:47:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRepHumInfectiousAddressHeader]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRepHumInfectiousAddressHeader]

/****** Object:  StoredProcedure [dbo].[spRepHumInfectiousAddressHeader]    Script Date: 11/30/2009 17:11:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--##SUMMARY This procedure returns Header for Human Disease Intermediate reports

--##REMARKS Author: 
--##REMARKS Create date: 

--##RETURNS Don't use 

/*
--Example of a call of procedure:

exec spRepHumInfectiousAddressHeader 'en', 37020000000, 3260000000

*/ 
 
CREATE PROCEDURE [dbo].[spRepHumInfectiousAddressHeader]
	@LangId			as varchar(36),
	@RegionID		as bigint = null,
	@RayonID		as bigint = null
AS
BEGIN
	DECLARE @CountryID BIGINT
	SELECT		@CountryID = s.idfsCountry
	FROM		tstSite s
	INNER JOIN	tstLocalSiteOptions lso
	ON			lso.strName = N'SiteID'
	AND			lso.strValue = cast(s.idfsSite as nvarchar(20))

	SELECT   
		ISNULL((SELECT [NAME] FROM fnGisReference(@LangID, 19000001 /*rftCountry*/) WHERE idfsReference = @CountryID),'') +
		CASE WHEN @RegionID IS NOT NULL
			THEN ', '
			ELSE ''
		END +
		ISNULL((SELECT [NAME] FROM fnGisReference(@LangID, 19000003 /*rftRegion*/) WHERE idfsReference = @RegionID),'')+
		CASE WHEN @RayonID IS NOT NULL
			THEN ', '
			ELSE ''
		END +
		ISNULL((SELECT [NAME] FROM fnGisReference(@LangID, 19000002 /*rftRayon*/) WHERE idfsReference = @RayonID),'')
	AS strLocation		
END
GO
