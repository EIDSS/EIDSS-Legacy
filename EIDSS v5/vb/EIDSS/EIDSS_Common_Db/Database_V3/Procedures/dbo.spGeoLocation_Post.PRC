SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGeoLocation_Post]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGeoLocation_Post]
GO
--##SUMMARY Saves geolocation data for ExactPoint and RelativePoint geolocation types.
--##SUMMARY It doesn't delete geolocation record because it is assumed that it should be deleted with parent object only
--##SUMMARY Used by LocationLookup and ExactGeolocationLookup controls to post data
--##SUMMARY All parameter names in this procedure must coincide with column names returned by spGeoLocation_SelectLookup procedure
--##SUMMARY for automatic posting from bv framework

--##REMARKS Author: Zurin M.
--##REMARKS Create date: 07.11.2009

--##RETURNS Doesn't use


/*
--Example of a call of procedure:
DECLARE @idfGeoLocation bigint
DECLARE @idfsGroundType bigint
DECLARE @idfsGeoLocationType bigint
DECLARE @idfsCountry bigint
DECLARE @idfsRegion bigint
DECLARE @idfsRayon bigint
DECLARE @idfsSettlement bigint
DECLARE @strDescription nvarchar(200)
DECLARE @dblDistance float
DECLARE @dblLatitude float
DECLARE @dblLongitude float
DECLARE @dblAccuracy float
DECLARE @dblAlignment float

-- TODO: Set parameter values here.

EXECUTE dbo.spGeoLocation_Post
   @idfGeoLocation
  ,@idfsGroundType
  ,@idfsGeoLocationType
  ,@idfsCountry
  ,@idfsRegion
  ,@idfsRayon
  ,@idfsSettlement
  ,@strDescription
  ,@dblDistance
  ,@dblLatitude
  ,@dblLongitude
  ,@dblAccuracy
  ,@dblAlignment
*/


CREATE         PROCEDURE dbo.spGeoLocation_Post(
	   @idfGeoLocation as bigint --##PARAM idfGeoLocation - ID of geolocation record
      ,@idfsGroundType as bigint --##PARAM idfsGroundType - ID of ground type for relative location
      ,@idfsGeoLocationType as bigint --##PARAM idfsGeoLocationType - ID geolocation type (can point to ExactPoint or Relative geolocation type
      ,@idfsCountry as bigint --##PARAM idfsCountry - ID of country
      ,@idfsRegion as bigint --##PARAM idfsRegion - ID of region
      ,@idfsRayon as bigint --##PARAM idfsRayon - ID rayon
      ,@idfsSettlement as bigint --##PARAM idfsSettlement - ID of settlement (for Relative location only)
      ,@strDescription as nvarchar(200) --##PARAM strDescription - free text description of reolocation record
      ,@dblLatitude as float --##PARAM dblLatitude - Latitude (for ExactPoint location only)
      ,@dblLongitude as float --##PARAM dblLongitude  - Longitude (for ExactPoint location only)
      ,@dblRelLatitude as float --##PARAM dblRelLatitude - calcualted Latitude (for RelativePoint location only)
      ,@dblRelLongitude as float --##PARAM dblRelLongitude  - calcualted Longitude (for RelativePoint location only)
      ,@dblAccuracy as float --##PARAM dblAccuracy - Accuracy of all other numeric data in the geolocation record
      ,@dblDistance as float --##PARAM dblDistance - distance (in kilometers) from settlement to relative point (for Relative location only)
      ,@dblAlignment as float --##PARAM dblAlignment - azimuth (in degrees) of direction from settlement to relative point(for Relative location only)
)
AS

IF EXISTS(SELECT * FROM dbo.tlbGeoLocation WHERE idfGeoLocation = @idfGeoLocation)

UPDATE [dbo].[tlbGeoLocation]
   SET 
       [idfsGroundType] = @idfsGroundType
      ,[idfsGeoLocationType] = @idfsGeoLocationType
      ,[idfsCountry] = @idfsCountry
      ,[idfsRegion] = @idfsRegion
      ,[idfsRayon] = @idfsRayon
      ,[idfsSettlement] = @idfsSettlement
      ,[strDescription] = @strDescription
      ,[dblDistance] = @dblDistance
      ,[dblLatitude] = CASE WHEN @idfsGeoLocationType = 10036003 THEN @dblLatitude ELSE @dblRelLatitude END
      ,[dblLongitude] = CASE WHEN @idfsGeoLocationType = 10036003 THEN @dblLongitude ELSE @dblRelLongitude END
      ,[dblAccuracy] = @dblAccuracy
      ,[dblAlignment] = @dblAlignment
 	 WHERE 
		idfGeoLocation = @idfGeoLocation
ELSE
	INSERT INTO tlbGeoLocation
			   (
				   idfGeoLocation
				  ,idfsGroundType
				  ,idfsGeoLocationType
				  ,idfsCountry
				  ,idfsRegion
				  ,idfsRayon
				  ,idfsSettlement
				  ,strDescription
				  ,dblDistance
				  ,dblLatitude
				  ,dblLongitude
				  ,dblAccuracy
				  ,dblAlignment
			   )
		 VALUES
			   (
				   @idfGeoLocation
				  ,@idfsGroundType
				  ,@idfsGeoLocationType
				  ,@idfsCountry
				  ,@idfsRegion
				  ,@idfsRayon
				  ,@idfsSettlement
				  ,@strDescription
				  ,@dblDistance
				  ,CASE WHEN @idfsGeoLocationType = 10036003 THEN @dblLatitude ELSE @dblRelLatitude END
				  ,CASE WHEN @idfsGeoLocationType = 10036003 THEN @dblLongitude ELSE @dblRelLongitude END
				  ,@dblAccuracy
				  ,@dblAlignment
				)







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

