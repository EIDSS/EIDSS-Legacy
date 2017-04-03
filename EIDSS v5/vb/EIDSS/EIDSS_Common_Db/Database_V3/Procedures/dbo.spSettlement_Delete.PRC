SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSettlement_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSettlement_Delete]
GO

CREATE   Proc spSettlement_Delete
(
		@idfsSettlement Bigint
)
As Begin
	Delete from dbo.gisWKBSettlement Where idfsGeoObject = @idfsSettlement
	Delete from  dbo.gisSettlement Where [idfsSettlement] = @idfsSettlement
	Delete from dbo.gisStringNameTranslation Where idfsGISBaseReference = @idfsSettlement
	Delete from dbo.gisBaseReference Where idfsGISBaseReference = @idfsSettlement
End


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

