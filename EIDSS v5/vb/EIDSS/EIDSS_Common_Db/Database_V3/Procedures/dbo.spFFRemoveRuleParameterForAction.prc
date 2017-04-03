set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFRemoveRuleParameterForAction')) DROP PROCEDURE [dbo].spFFRemoveRuleParameterForAction
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveRuleParameterForAction
(
	@idfsRule Bigint
    ,@idfsParameter Bigint
)
AS
BEGIN
	Set Nocount On;	
	
	Delete from dbo.ffParameterForAction		
	Where 
		idfsRule = @idfsRule
		And
		idfsParameter = @idfsParameter	
		
End
Go