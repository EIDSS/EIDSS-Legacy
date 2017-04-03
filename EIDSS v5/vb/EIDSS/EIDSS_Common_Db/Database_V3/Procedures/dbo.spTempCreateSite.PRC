IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spTempCreateSite]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spTempCreateSite]
GO
/*
--    tstSite,      
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tstSite ADD
	strSiteID varchar(50) NULL
GO
COMMIT
*/

/*
exec dbo.spTempCreateSite 
	'AZ0000',	
	'www',	
	'sitEMS',	
	'AZIMWWW',	
	'Imishli ZZZ',	
	'Imishli Test Site ZZZ',	
	'AZIMWWW'

*/



/****** Object:  Stored Procedure dbo.spTempCreateSite    Script Date: 23.03.2006 13:30:41 ******/

/****** Changed E.Vorobyev 30.12.2010 ******/

CREATE PROC [dbo].[spTempCreateSite](
	@CountryID nvarchar(50),
	@SiteID nvarchar(50),
	@SiteType nvarchar(50),
	@ServerName nvarchar(200),
	@Abbreviation nvarchar(100),
	@Name nvarchar(300),
	@HASCsiteID nvarchar(50) = NULL,
	@Lang BIGINT = NULL,
	@AbbreviationNN NVARCHAR(50) = NULL,
	@NameNN NVARCHAR(300) = NULL,
	@Lang2 BIGINT = NULL,
	@AbbreviationNN2 NVARCHAR(50) = NULL,
	@NameNN2 NVARCHAR(300) = NULL,
	@Region NVARCHAR(300) = NULL,
	@Rayon NVARCHAR(300) = NULL,
	@Settlement NVARCHAR(300) = NULL,
	@intFlags INT = 0
	)
as

begin tran
declare @AbbrID BIGINT 
declare @NameID BIGINT
declare @OfficeID BIGINT
DECLARE @OfficeAddrID BIGINT 
DECLARE @intSiteID BIGINT
DECLARE @intCountryID BIGINT
DECLARE @intSiteType BIGINT
DECLARE @intRegion BIGINT
DECLARE @intRayon BIGINT
DECLARE @intSettlement BIGINT
 
 SELECT 
	@intCountryID = [idfsGISBaseReference]
 FROM [gisBaseReference]
 WHERE [strBaseReferenceCode] = @CountryID

 SELECT 
	@intSiteType = [idfsBaseReference]
 FROM [trtBaseReference]
 WHERE [strBaseReferenceCode] = @SiteType 
 
 
SET @intRegion = 
				(
					SELECT 
						gr.idfsRegion
					FROM dbo.gisRegion gr
					JOIN gisBaseReference gbr ON
						gbr.idfsGISBaseReference = gr.idfsRegion
						AND gbr.strDefault = LTRIM(RTRIM(@Region))
						AND gbr.intRowStatus = 0
					WHERE gr.idfsCountry = @intCountryID
						AND gr.intRowStatus = 0
				)


SET @intRayon = 
				(
					SELECT 
						gr.idfsRayon
					FROM dbo.gisRayon gr
					JOIN gisBaseReference gbr ON
						gbr.idfsGISBaseReference = gr.idfsRayon
						AND gbr.strDefault = LTRIM(RTRIM(@Rayon))
						AND gbr.intRowStatus = 0
					WHERE gr.idfsCountry = @intCountryID
						AND gr.idfsRegion = @intRegion
						AND gr.intRowStatus = 0
				)
 
SET @intSettlement =
				(
					SELECT TOP 1
						gr.idfsSettlement
					FROM dbo.gisSettlement gr
					JOIN gisBaseReference gbr ON
						gbr.idfsGISBaseReference = gr.idfsSettlement
						AND gbr.strDefault = LTRIM(RTRIM(@Settlement))
						AND gbr.intRowStatus = 0
					WHERE gr.idfsCountry = @intCountryID
						AND gr.idfsRegion = @intRegion
						AND gr.idfsRayon = @intRayon
						AND gr.intRowStatus = 0
				) 
 
 
 
SET @OfficeID = NULL

-- Select office by Site 
SELECT 
	@OfficeID = idfOffice
FROM dbo.tstSite 
WHERE strSiteID = @SiteID 
	AND idfOffice IS NOT NULL

-- Or select office by the same abbreviation
IF @OfficeID IS NULL 
	SELECT 
		@OfficeID = idfOffice
	FROM dbo.tlbOffice AS a
	INNER JOIN dbo.trtBaseReference AS b
		ON a.idfsOfficeAbbreviation = b.idfsBaseReference
		AND (b.intRowStatus = 0)
	WHERE b.strDefault = @Abbreviation
		AND (a.intRowStatus=0)

IF @OfficeID IS NULL
BEGIN 
	EXEC [spsysGetNewID] @AbbrID OUTPUT

	EXEC [spsysGetNewID] @NameID OUTPUT

	insert into dbo.trtBaseReference (idfsBaseReference,idfsReferenceType,strDefault)
	values (@AbbrID, 19000045 /*'rftInstitutionAbbr'*/, @Abbreviation)

	insert into dbo.trtBaseReference (idfsBaseReference,idfsReferenceType,strDefault)
	values (@NameID, 19000046/*'rftInstitutionName'*/, @Name)
	
	
	IF NOT EXISTS (
					SELECT
						*
					FROM [trtStringNameTranslation]
					WHERE [idfsBaseReference] = @AbbrID
						AND [idfsLanguage] = 10049003 --'en'
				)		
	INSERT INTO [trtStringNameTranslation] ([idfsBaseReference], [idfsLanguage], [strTextString]) 
	VALUES (@AbbrID, 10049003, @Abbreviation)
			
	
	IF NOT EXISTS (
					SELECT
						*
					FROM [trtStringNameTranslation]
					WHERE [idfsBaseReference] = @NameID
						AND [idfsLanguage] = 10049003 --'en'
				)		
	INSERT INTO [trtStringNameTranslation] ([idfsBaseReference], [idfsLanguage], [strTextString]) 
	VALUES (@NameID, 10049003, @Name)		



	IF (@Lang IS NOT NULL)
	BEGIN 
		IF (ISNULL(RTRIM(@AbbreviationNN),'')<>'')
		INSERT INTO [trtStringNameTranslation] ([idfsBaseReference],[idfsLanguage],[strTextString]) 
		VALUES ( @AbbrID,@Lang,@AbbreviationNN) 
		
		IF (ISNULL(RTRIM(@NameNN),'')<>'')
		INSERT INTO [trtStringNameTranslation] ([idfsBaseReference],[idfsLanguage],[strTextString]) 
		VALUES ( @NameID,@Lang,@NameNN) 
	END 
	
	IF (@Lang2 IS NOT NULL)
	BEGIN
		IF (ISNULL(RTRIM(@AbbreviationNN2),'')<>'')
		INSERT INTO [trtStringNameTranslation] ([idfsBaseReference],[idfsLanguage],[strTextString]) 
		VALUES ( @AbbrID,@Lang2,@AbbreviationNN2) 
		
		IF (ISNULL(RTRIM(@NameNN2),'')<>'')
		INSERT INTO [trtStringNameTranslation] ([idfsBaseReference],[idfsLanguage],[strTextString]) 
		VALUES ( @NameID,@Lang2,@NameNN2) 
	END 
	


	EXEC  [spsysGetNewID] @OfficeAddrID OUTPUT 
	
	INSERT INTO [tlbGeoLocation] (
		[idfGeoLocation],
		[idfsGeoLocationType],
		[idfsCountry],
		[idfsRegion],
		[idfsRayon],
		[idfsSettlement],
		[strDescription]
	) 
	VALUES
	(
		@OfficeAddrID,
		10036001, --lctAddress
		@intCountryID,
		@intRegion,
		@intRayon,
		@intSettlement,
		@ServerName
	)
		
		
	EXEC [spsysGetNewID] @OfficeID OUTPUT 

	insert into dbo.tlbOffice(idfOffice, idfsOfficeType, idfsOfficeName, idfsOfficeAbbreviation,  idfsCountry, [idfLocation])
	values (@OfficeID, 10062002 /*'oftInstitution'*/, @NameID, @AbbrID, @intCountryID, @OfficeAddrID )

END
ELSE
BEGIN
	select @AbbrID = idfsOfficeAbbreviation, @NameID =  idfsOfficeName, @OfficeAddrID = idfLocation
	from dbo.tlbOffice where idfOffice = @OfficeID

	update dbo.tlbOffice 
	set intRowStatus = 0
	where idfOffice = @OfficeID

	update dbo.trtBaseReference
	set strDefault = @Name, intRowStatus = 0
	where idfsBaseReference = @NameID

	update dbo.trtBaseReference
	set strDefault = @Abbreviation, intRowStatus = 0
	where idfsBaseReference = @AbbrID




	IF NOT EXISTS (
					SELECT
						*
					FROM [trtStringNameTranslation]
					WHERE [idfsBaseReference] = @AbbrID
						AND [idfsLanguage] = 10049003 --'en'
				)		
		INSERT INTO [trtStringNameTranslation] ([idfsBaseReference], [idfsLanguage], [strTextString]) 
		VALUES (@AbbrID, 10049003, @Abbreviation)
	ELSE
		UPDATE dbo.trtStringNameTranslation
		SET strTextString = @Abbreviation
		WHERE idfsBaseReference = @AbbrID
			AND idfsLanguage = 10049003 --'en'
			
	
	IF NOT EXISTS (
					SELECT
						*
					FROM [trtStringNameTranslation]
					WHERE [idfsBaseReference] = @NameID
						AND [idfsLanguage] = 10049003 --'en'
				)		
		INSERT INTO [trtStringNameTranslation] ([idfsBaseReference], [idfsLanguage], [strTextString]) 
		VALUES (@NameID, 10049003, @Name)
	ELSE
		UPDATE trtStringNameTranslation	
		SET strTextString = @Name
		WHERE idfsBaseReference = @NameID
			AND idfsLanguage = 10049003 --'en'



	
	IF (@Lang IS NOT NULL)
	BEGIN 
		IF (ISNULL(RTRIM(@AbbreviationNN),'')<>'')
		BEGIN 
			IF NOT EXISTS(SELECT * FROM [trtStringNameTranslation] WHERE [idfsBaseReference] = @AbbrID AND [idfsLanguage] = @Lang)
			INSERT INTO [trtStringNameTranslation] ([idfsBaseReference],[idfsLanguage],[strTextString]) 
			VALUES ( @AbbrID,@Lang,@AbbreviationNN) 
			ELSE 
			UPDATE [trtStringNameTranslation] SET [strTextString] = @AbbreviationNN
			WHERE [idfsBaseReference] = @AbbrID AND [idfsLanguage] = @Lang
		END 
		
		IF (ISNULL(RTRIM(@NameNN),'')<>'')
		BEGIN 
			IF NOT EXISTS(SELECT * FROM [trtStringNameTranslation] WHERE [idfsBaseReference] = @NameID AND [idfsLanguage] = @Lang)
			INSERT INTO [trtStringNameTranslation] ([idfsBaseReference],[idfsLanguage],[strTextString]) 
			VALUES ( @NameID,@Lang,@NameNN) 
			ELSE 
			UPDATE [trtStringNameTranslation] SET [strTextString] = @NameNN
			WHERE [idfsBaseReference] = @NameID AND [idfsLanguage] = @Lang
		END 
	END 
	
	IF (@Lang2 IS NOT NULL)
	BEGIN 
		IF (ISNULL(RTRIM(@AbbreviationNN2),'')<>'')
		BEGIN 
			IF NOT EXISTS(SELECT * FROM [trtStringNameTranslation] WHERE [idfsBaseReference] = @AbbrID AND [idfsLanguage] = @Lang2)
			INSERT INTO [trtStringNameTranslation] ([idfsBaseReference],[idfsLanguage],[strTextString]) 
			VALUES ( @AbbrID,@Lang2,@AbbreviationNN2) 
			ELSE 
			UPDATE [trtStringNameTranslation] SET [strTextString] = @AbbreviationNN2
			WHERE [idfsBaseReference] = @AbbrID AND [idfsLanguage] = @Lang2
		END 
		
		IF (ISNULL(RTRIM(@NameNN2),'')<>'')
		BEGIN 
			IF NOT EXISTS(SELECT * FROM [trtStringNameTranslation] WHERE [idfsBaseReference] = @NameID AND [idfsLanguage] = @Lang2)
			INSERT INTO [trtStringNameTranslation] ([idfsBaseReference],[idfsLanguage],[strTextString]) 
			VALUES ( @NameID,@Lang2,@NameNN2) 
			ELSE 
			UPDATE [trtStringNameTranslation] SET [strTextString] = @NameNN2
			WHERE [idfsBaseReference] = @NameID AND [idfsLanguage] = @Lang2
		END 
	END
	
	
	
	IF @OfficeAddrID IS NOT NULL
		
		UPDATE tlbGeoLocation
		SET
			idfsGeoLocationType = 10036001,
			idfsCountry = @intCountryID,
			idfsRegion = @intRegion,
			idfsRayon = @intRayon,
			idfsSettlement = @intSettlement,
			intRowStatus = 0
		WHERE idfGeoLocation = @OfficeAddrID
		
	ELSE
	BEGIN
		
		EXEC  [spsysGetNewID] @OfficeAddrID OUTPUT 
		
		INSERT INTO [tlbGeoLocation] (
			[idfGeoLocation],
			[idfsGeoLocationType],
			[idfsCountry],
			[idfsRegion],
			[idfsRayon],
			[idfsSettlement],
			[strDescription]
		) 
		VALUES
		(
			@OfficeAddrID,
			10036001, --lctAddress
			@intCountryID,
			@intRegion,
			@intRayon,
			@intSettlement,
			@ServerName
		)
			
	END
		

END








SET @intSiteID = NULL

SELECT 
	@intSiteID = ts.idfsSite
FROM dbo.tstSite ts
WHERE [strSiteID] = @SiteID

IF @intSiteID IS NULL
	BEGIN 
		SELECT @intSiteID = MAX([idfsSite])+1
		FROM [tstSite]
		
		insert into dbo.tstSite(idfsSite, idfsSiteType, idfsCountry, idfOffice, strSiteName, strServerName, strHASCsiteID, strSiteID, intFlags)
		values(@intSiteID,@intSiteType,@intCountryID,@OfficeID,@Abbreviation,@ServerName,@HASCsiteID,@SiteID, @intFlags)		
	END 
ELSE
	UPDATE dbo.tstSite
	set strSiteName = @Abbreviation,
	idfsSiteType = @intSiteType,
	idfsCountry = @intCountryID,
	idfOffice = @OfficeID,
	strServerName =@ServerName,
	strHASCsiteID = @HASCsiteID,
	intFlags = @intFlags
	where [strSiteID] = @SiteID
	
	
----------выдача прав дефолтной группы пользователей-----------------------------------------------------

	DECLARE @LastOA BIGINT
	SET @LastOA = (SELECT ISNULL(MAX(oa.idfObjectAccess), 0) FROM dbo.tstObjectAccess oa)

	UPDATE toa
	SET toa.intRowStatus = 1
	FROM tstObjectAccess toa
	WHERE toa.idfsOnSite = @intSiteID
		AND toa.idfActor = -1
		AND NOT EXISTS (
							SELECT 
								*
							FROM trtSystemFunction tsf
							JOIN trtObjectTypeToObjectOperation tottoo ON
								tottoo.idfsObjectType = tsf.idfsObjectType
								AND tottoo.intRowStatus = 0
							WHERE tsf.intRowStatus = 0
								AND tsf.idfsSystemFunction = toa.idfsObjectID
								AND tottoo.idfsObjectOperation = toa.idfsObjectOperation
						)
		
	UPDATE toa
	SET toa.intPermission = 1
		, toa.intRowStatus = 0
	FROM tstObjectAccess toa
	WHERE toa.idfsOnSite = @intSiteID
		AND toa.idfActor = -1
		AND EXISTS (
						SELECT 
							*
						FROM trtSystemFunction tsf
						JOIN trtObjectTypeToObjectOperation tottoo ON
							tottoo.idfsObjectType = tsf.idfsObjectType
							AND tottoo.intRowStatus = 0
						WHERE tsf.intRowStatus = 0
							AND tsf.idfsSystemFunction = toa.idfsObjectID
							AND tottoo.idfsObjectOperation = toa.idfsObjectOperation
					)

	INSERT INTO dbo.tstObjectAccess 
	(
		idfObjectAccess
		, idfsObjectOperation
		, idfsObjectType
		, idfsObjectID
		, idfActor
		, idfsOnSite
		, intPermission
	)
	SELECT
		ROW_NUMBER() OVER (ORDER BY tottoo.idfsObjectOperation) + @LastOA
		, tottoo.idfsObjectOperation
		, tottoo.idfsObjectType
		, tsf.idfsSystemFunction	
		, -1
		, @intSiteID
		, 1
	FROM trtSystemFunction tsf
	JOIN trtObjectTypeToObjectOperation tottoo ON
		tottoo.idfsObjectType = tsf.idfsObjectType
		AND tottoo.intRowStatus = 0
	LEFT JOIN tstObjectAccess toa ON
		toa.idfsObjectOperation = tottoo.idfsObjectOperation
		AND toa.idfsObjectType = tottoo.idfsObjectType
		AND toa.idfsObjectID = tsf.idfsSystemFunction
		AND toa.idfActor = -1
		AND toa.idfsOnSite = @intSiteID
	WHERE tsf.intRowStatus = 0
		AND toa.idfObjectAccess IS NULL
---------------------------------------------------------------------------------------------------	
	
	
	
	
	
	
	
commit tran