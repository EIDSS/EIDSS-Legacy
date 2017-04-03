set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spFFRemoveParameterReferenceType')) DROP PROCEDURE dbo.spFFRemoveParameterReferenceType
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveParameterReferenceType
(
	@idfsParameterType Bigint
)
AS
BEGIN
	Set Nocount On;	
	
	declare	@ErrorMessage nvarchar(400)
	Select @ErrorMessage = [ErrorMessage] From dbo.fnFFCheckForRemoveParameterType(@ErrorMessage);
	If (@ErrorMessage Is Not Null) Exec dbo.spThrowException @ErrorMessage
	
	-- удаляем все содержимое справочника
	Delete from dbo.ffParameterFixedPresetValue Where idfsParameterType= @idfsParameterType
	
	Delete from dbo.ffParameterType	Where [idfsParameterType] = @idfsParameterType
		
END