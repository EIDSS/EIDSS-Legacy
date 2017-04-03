set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFRemoveRuleParameterForFunction')) DROP PROCEDURE [dbo].spFFRemoveRuleParameterForFunction
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveRuleParameterForFunction
(
	@idfsRule BigInt
    ,@idfsParameter BigInt
)
AS
BEGIN
	Set Nocount On;
	
	-- удаляем специфические данные из языковых таблиц
	Delete from dbo.ffParameterForFunction
	Where 
		[idfsRule] = @idfsRule
		And
		[idfsParameter] = @idfsParameter	
	
END