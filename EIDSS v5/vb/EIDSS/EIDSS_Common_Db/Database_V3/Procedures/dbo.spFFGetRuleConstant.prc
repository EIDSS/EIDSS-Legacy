set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetRuleConstant]')) DROP PROCEDURE [dbo].[spFFGetRuleConstant]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFGetRuleConstant 
(	
	@idfsRule Bigint
)	
AS
BEGIN	
	Set Nocount On;	
	
	Select 
		[idfRuleConstant]
		,[idfsRule]		
		,[varConstant]
	From [dbo].[ffRuleConstant] 
	Where [idfsRule] = @idfsRule
				 And [intRowStatus] = 0
   
End
Go
