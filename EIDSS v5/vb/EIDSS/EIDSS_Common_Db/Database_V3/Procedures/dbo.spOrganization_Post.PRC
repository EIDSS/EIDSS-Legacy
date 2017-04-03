SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'dbo.spOrganization_Post') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure dbo.spOrganization_Post
GO




CREATE        PROCEDURE dbo.spOrganization_Post 
	@idfOffice AS BIGINT,
	@EnglishName AS NVARCHAR(200),
	@Name AS NVARCHAR(200),
	@EnglishAbbreviation AS NVARCHAR(200),
	@Abbreviation AS NVARCHAR(200),
	@idfLocation AS BIGINT,
	@strContactPhone AS NVARCHAR(200),
	@idfsCountry  AS BIGINT,
	@LANGID As nvarchar(50)
AS
DECLARE @idfsOfficeName bigint
DECLARE @idfsOfficeAbbreviation bigint
DECLARE @NewRecord BIT
SELECT 
	@idfsOfficeName = idfsOfficeName,
	@idfsOfficeAbbreviation = idfsOfficeAbbreviation
FROM 
	tlbOffice 
WHERE 
	idfOffice=@idfOffice
IF @@ROWCOUNT=0
BEGIN
	exec spsysGetNewID @idfsOfficeName OUTPUT
	exec spsysGetNewID @idfsOfficeAbbreviation OUTPUT
	SET @NewRecord = 1
END

IF @LANGID = 'en'
BEGIN
	SET @EnglishAbbreviation = @Abbreviation
	SET @EnglishName = @Name 
END



--if not exists	(
--		select	* from dbo.fnReference(@LANGID,19000046) --'rftInstitutionName'
--		where	idfsReference = @idfsOfficeName 
--				and Name = @Name 
--				and strDefault = @EnglishName
--		)
begin
	EXEC spBaseReference_SysPost @idfsOfficeName, 19000046, @LANGID, @EnglishName, @Name, 0 --'rftInstitutionName'
end
--
--if not exists	(
--		select	* from dbo.fnReference(@LANGID,19000045) --'rftInstitutionAbbr'
--		where	idfsReference = @idfsOfficeAbbreviation 
--				and Name = @Abbreviation 
--				and strDefault = @EnglishAbbreviation
--		)
begin
	EXEC spBaseReference_SysPost @idfsOfficeAbbreviation, 19000045, @LANGID, @EnglishAbbreviation, @Abbreviation, 0 --'rftInstitutionAbbr'
end

IF @NewRecord=1
BEGIN
	IF @idfOffice IS NULL
			exec spsysGetNewID @idfOffice OUTPUT

	
INSERT INTO tlbOffice
           (
			idfOffice
           ,idfsOfficeName
           ,idfsOfficeAbbreviation
           ,idfsOfficeType
           ,idfsCountry
           ,idfParentOffice
           ,idfLocation
           ,idfsSite
           ,strContactPhone
			)
     VALUES
           (
			@idfOffice
           ,@idfsOfficeName
           ,@idfsOfficeAbbreviation
           ,10062002 --@idfsOfficeType Insitution
           ,@idfsCountry
           ,null --@idfParentOffice
           ,@idfLocation
           ,dbo.fnSiteID()
           ,@strContactPhone
           )

END
ELSE
BEGIN
	UPDATE tlbOffice
	SET 	
		strContactPhone=@strContactPhone,
		idfLocation = @idfLocation
	WHERE 
		idfOffice=@idfOffice

--TODO: Insert filtration processing
--	if 	@LocationID is not null
--		and exists	(
--				select	*
--				from	tlbOffice o
--				where	o.idfOffice = @OrganizationID
--						and o.idfAddress_GeoLocation = @LocationID
--					)
--	begin
--		INSERT INTO GeoLocationFiltered
--		(	idfGeoLocation,
--			idfsSite
--		)
--		SELECT		@LocationID,
--					s.idfsSite
--		FROM		Site s
--		INNER JOIN	Site s_cur
--		ON			s_cur.idfsCountry = s.idfsCountry
--					and s_cur.idfsSite = dbo.fnSiteID()
--		LEFT JOIN	GeoLocationFiltered glf
--		ON			glf.idfGeoLocation = @LocationID
--					and glf.idfsSite = s.idfsSite
--		WHERE		glf.idfGeoLocation is null
--	end

END











GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

