SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGeoLocation_SelectDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGeoLocation_SelectDetail]
GO




CREATE         PROCEDURE dbo.spGeoLocation_SelectDetail(
	@idfGeoLocation AS bigint
)
AS
SELECT [idfGeoLocation]
      ,[idfsResidentType]
      ,[idfsGroundType]
      ,[idfsGeoLocationType]
      ,[idfsCountry]
      ,[idfsRegion]
      ,[idfsRayon]
      ,[idfsSettlement]
      ,[idfsSite]
      ,[strPostCode]
      ,[strStreetName]
      ,[strHouse]
      ,[strBuilding]
      ,[strApartment]
      ,[strDescription]
      ,[dblDistance]
      ,[dblLatitude]
      ,[dblLongitude]
      ,CASE WHEN [idfsGeoLocationType] = 10036003 THEN NULL ELSE dblLatitude END AS dblRelLatitude
      ,CASE WHEN [idfsGeoLocationType] = 10036003 THEN NULL ELSE [dblLongitude] END AS dblRelLongitude
      ,[dblLongitude]
      ,[dblAccuracy]
      ,[dblAlignment]
  FROM tlbGeoLocation
  WHERE [idfGeoLocation] = @idfGeoLocation
		AND intRowStatus = 0
	




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

