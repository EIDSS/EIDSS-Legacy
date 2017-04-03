set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetRuleParameterForAction]')) DROP PROCEDURE [dbo].[spFFGetRuleParameterForAction]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFGetRuleParameterForAction 
(		
	@idfsRule Bigint
)	
AS
BEGIN	
	Set Nocount On;	
	
	Select 
		[idfParameterForAction]
		,[idfsRule]
		,[idfsRuleAction]      
		,[idfsParameter]
		,[idfsFormTemplate]	
	From [dbo].[ffParameterForAction]
	Where [idfsRule] = @idfsRule
				And [intRowStatus] = 0
   
End
Go
