SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRayon_Validate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spRayon_Validate]
GO







CREATE    PROCEDURE spRayon_Validate(
	@idfsRegion varchar(50),
	@idfsRayon varchar(50),
	@strDefaultName nvarchar(200),
	@strNationalName nvarchar(200),
	@LANGID varchar(50),
	@Result int = 0 OUTPUT
	)
as
IF ISNULL(@idfsRegion,'')=''
BEGIN
	
	SELECT 	@idfsRegion=idfsRegion
	FROM 	gisRayon
	WHERE 
		@idfsRayon = @idfsRayon
	
	IF @@ROWCOUNT=0 OR ISNULL(@idfsRegion,'')=''
	BEGIN
		SET @Result = 0
		Return 0
	END
END

IF EXISTS (
	SELECT  
		idfsRayon 
	FROM 
		gisRayon
	INNER JOIN gisRegion 
	ON 	gisRayon.idfsRegion = gisRegion.idfsRegion
	LEFT JOIN 
		fnReference('en',19000002) as enRayon --'rftRayon'
	on	enRayon.idfsReference = idfsRayon
	WHERE
		enRayon.[Name] = @strDefaultName
		AND idfsRayon <> @idfsRayon
		AND gisRegion.idfsRegion = @idfsRegion
	)

BEGIN
	SET @Result = 1
	Return 1
END	

IF @LANGID <> N'en' AND EXISTS (
	SELECT  
		idfsRayon
	FROM 
		gisRayon
	INNER JOIN gisRegion 
	ON 	gisRayon.idfsRegion = gisRegion.idfsRegion
	LEFT JOIN 
		fnGisReference(@LANGID,19000002) as natRayon --'rftRayon'
	on	natRayon.idfsReference = idfsRayon
	WHERE
		natRayon.[Name] = @strNationalName
		AND idfsRayon <> @idfsRayon
		AND gisRegion.idfsRegion = @idfsRegion
	)
BEGIN
	SET @Result = 2
	Return 2
END 

SET @Result = 0
Return 0







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

