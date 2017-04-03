SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSettlement_CanDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSettlement_CanDelete]
GO

CREATE   procedure dbo.spSettlement_CanDelete
	@ID as bigint --##PARAM
	,@Result AS BIT OUTPUT --##PARAM  @Result - 0 if case can't be deleted, 1 in other case
As

IF EXISTS (SELECT 0 from dbo.gisSettlement WHERE idfsSettlement = @ID and blnIsCustomSettlement <> 1 )
	SET @Result = 0
ELSE IF EXISTS (SELECT 0 from dbo.tlbGeoLocation WHERE idfsSettlement = @ID)
	SET @Result = 0
ELSE IF EXISTS (SELECT 0 from dbo.tlbPostalCode WHERE idfsSettlement = @ID)
	SET @Result = 0
ELSE IF EXISTS (SELECT 0 from dbo.tlbStreet WHERE idfsSettlement = @ID)
	SET @Result = 0
ELSE IF EXISTS (SELECT 0 from dbo.tlbMonitoringSession WHERE idfsSettlement = @ID)
	SET @Result = 0
ELSE	
	SET @Result = 1

Return @Result

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

