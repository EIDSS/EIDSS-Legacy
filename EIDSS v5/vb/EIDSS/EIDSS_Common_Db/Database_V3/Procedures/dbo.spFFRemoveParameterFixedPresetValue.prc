set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spFFRemoveParameterFixedPresetValue')) DROP PROCEDURE dbo.spFFRemoveParameterFixedPresetValue
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveParameterFixedPresetValue
(
	@idfsParameterFixedPresetValue Bigint
)
AS
BEGIN
	Set Nocount On;	
	
	declare	@ErrorMessage nvarchar(400)
	Select @ErrorMessage = [ErrorMessage] From dbo.fnFFCheckForRemoveParameterFixedPresetValue(@ErrorMessage);
	If (@ErrorMessage Is Not Null) Exec dbo.spThrowException @ErrorMessage	

	Delete from dbo.ffParameterFixedPresetValue Where [idfsParameterFixedPresetValue] = @idfsParameterFixedPresetValue
		
END