set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFRemoveRule')) DROP PROCEDURE [dbo].spFFRemoveRule
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveRule
(
	@idfsRule Bigint
)
AS
BEGIN
	Set Nocount On;	
	
	-- удаляем зависимые объекты
	Delete from dbo.ffRuleConstant	Where [idfsRule] = @idfsRule
	Delete from dbo.ffParameterForAction	Where [idfsRule] = @idfsRule
	Delete from dbo.ffParameterForFunction	Where [idfsRule] = @idfsRule
		
	--	
	Delete from dbo.ffRule	Where [idfsRule] = @idfsRule
		
END