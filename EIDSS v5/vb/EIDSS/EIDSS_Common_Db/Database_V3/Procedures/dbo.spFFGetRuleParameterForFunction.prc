set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetRuleParameterForFunction]')) DROP PROCEDURE [dbo].[spFFGetRuleParameterForFunction]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFGetRuleParameterForFunction 
(		
	@idfRule Bigint
)	
AS
BEGIN	
	Set Nocount On;	
	
	Select 
		PF.[idfParameterForFunction]
		,PF.[idfsParameter]
		,PF.[idfsFormTemplate]
		,PF.[idfsRule]
		,PF.[intOrder]
		,PF.[rowguid]
		,P.[idfsParameterType]
	From [dbo].[ffParameterForFunction] PF
	Inner Join [dbo].[ffParameter] P On PF.idfsParameter = P.idfsParameter And P.[intRowStatus] = 0
	Where 	PF.[idfsRule] = @idfRule
	 And PF.[intRowStatus] = 0
   
End
Go
