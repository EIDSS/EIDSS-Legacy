SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSettlement_Validate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSettlement_Validate]
GO







CREATE    PROCEDURE spSettlement_Validate(
	@idfsRayon bigint,
	@idfsSettlement bigint,
	@strDefaultName nvarchar(200),
	@strNationalName nvarchar(200),
	@strSettlementCode nvarchar(200),
	@LANGID varchar(50),
	@idfsSettlementType bigint = null,
	@Result int = 0 OUTPUT
	)
as

IF ISNULL(@idfsRayon,'') = ''
BEGIN
	SELECT 	@idfsRayon=idfsRayon
	FROM 	gisSettlement
	WHERE 
		idfsSettlement = @idfsSettlement

	IF @@ROWCOUNT=0 OR ISNULL(@idfsRayon,'') IS NULL
	BEGIN
		SET @Result = 0
		Return 0
	END
END

IF EXISTS (
	SELECT  
		idfsSettlement 
	FROM 
		gisSettlement
	INNER JOIN gisRayon 
	ON 	gisSettlement.idfsRayon = gisRayon.idfsRayon
	LEFT JOIN 
		fnGisReference('en',19000004) as enSettlement --'rftSettlement'
	on	enSettlement.idfsReference = idfsSettlement
	WHERE
		enSettlement.[Name] = @strDefaultName
		AND (@idfsSettlementType IS NULL OR idfsSettlementType = @idfsSettlementType)
		AND idfsSettlement <> @idfsSettlement
		AND gisRayon.idfsRayon = @idfsRayon)
BEGIN
	SET @Result = 1
	Return 1
END	

IF @LANGID <> N'en' AND EXISTS (
	SELECT  
		idfsSettlement 
	FROM 
		gisSettlement
	INNER JOIN gisRayon 
	ON 	gisSettlement.idfsRayon = gisRayon.idfsRayon
	LEFT JOIN 
		fnGisReference(@LANGID,19000004) as natSettlement --'rftSettlement'
	on	natSettlement.idfsReference = idfsSettlement
	WHERE
		natSettlement.[Name] = @strNationalName
		AND idfsSettlement <> @idfsSettlement
		AND (@idfsSettlementType IS NULL OR idfsSettlementType = @idfsSettlementType)
		AND gisRayon.idfsRayon = @idfsRayon)
BEGIN
	SET @Result = 2
	Return 2
END 
--TODO:(Mike) - commented to GAT period only
--We should think more about settlement validation and get final decision on it

--IF EXISTS (	SELECT  
--		idfsSettlement 
--	FROM 
--		gisSettlement 
--	WHERE 
--		strSettlementCode = @strSettlementCode
--		AND idfsSettlement <> @idfsSettlement)
--BEGIN
--	SET @Result = 3
--	Return 3
--END

SET @Result = 0
Return 0







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

