set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

-- DROP IF EXIST
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGisSetWKBSettlement]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGisSetWKBSettlement]
GO

-- =============================================
-- Author:		<Timur Kobilov>
-- Create date: <18.08.2010>
-- Description:	<Create geometry in gisWKBSettlement on the basis of coordinates from gisSettlement>
-- =============================================
CREATE PROCEDURE [dbo].[spGisSetWKBSettlement] 
	@idfsGeoObject BIGINT	
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @byteOrder TINYINT
	DECLARE @geomType INT
	DECLARE @dblX FLOAT
	DECLARE @dblY FLOAT

	DECLARE @binOrder BINARY(1)
	DECLARE @binType BINARY(4)
	DECLARE @binX BINARY(8)
	DECLARE @binY BINARY(8)

	DECLARE @binResult BINARY(21)
	
	SET @byteOrder = 1	
	SET @geomType = 1
		
	SELECT	 @dblX = dblLongitude 
			,@dblY = dblLatitude
	FROM gisSettlement
	WHERE (idfsSettlement = @idfsGeoObject)

	SET @binOrder = @byteOrder
	SET @binType = @geomType
	SET @binX = @dblX 
	SET @binY = @dblY 
		
	SET @binType = cast(reverse(@binType) AS BINARY(4))
	SET @binX = cast(reverse(@binX) AS BINARY(8))
	SET @binY = cast(reverse(@binY) AS BINARY(8))
	
	SET @binResult = @binOrder+@binType+@binX+@binY

	IF EXISTS(SELECT * FROM gisWKBSettlement WHERE idfsGeoObject=@idfsGeoObject)
		UPDATE gisWKBSettlement
			SET blbWKBGeometry = @binResult,  	
				dblEnvelopeMinX = @dblX,
				dblEnvelopeMinY = @dblY,
				dblEnvelopeMaxX = @dblX,
				dblEnvelopeMaxY = @dblY
			WHERE  idfsGeoObject=@idfsGeoObject
	ELSE
		INSERT INTO gisWKBSettlement (idfsGeoObject, blbWKBGeometry, dblEnvelopeMinX, dblEnvelopeMinY, dblEnvelopeMaxX, dblEnvelopeMaxY, rowguid)
		VALUES (@idfsGeoObject, @binResult, @dblX, @dblY, @dblX, @dblY, DEFAULT)

END

