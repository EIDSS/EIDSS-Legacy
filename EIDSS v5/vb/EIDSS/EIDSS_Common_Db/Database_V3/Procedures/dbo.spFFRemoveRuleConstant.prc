set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFRemoveRuleConstant')) DROP PROCEDURE [dbo].spFFRemoveRuleConstant
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveRuleConstant
(
	@idfRuleConstant Bigint
)
AS
BEGIN
	Set Nocount On;	
	
	Delete from dbo.ffRuleConstant	
	Where 
		[idfRuleConstant] = @idfRuleConstant
		
END