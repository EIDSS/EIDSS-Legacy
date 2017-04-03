set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFSaveRuleParameterForAction]')) DROP PROCEDURE [dbo].[spFFSaveRuleParameterForAction]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFSaveRuleParameterForAction 
(		
	@idfParameterForAction Bigint Output
	,@idfsRule Bigint
    ,@idfsFormTemplate Bigint
	,@idfsParameter Bigint
    ,@idfsRuleAction Bigint
)	
AS
BEGIN	
	Set Nocount On;	
	
	-- если id < 0, значит, это временный id и нужно заменить его на настоящий
	If (@idfParameterForAction < 0) Exec dbo.[spsysGetNewID] @idfParameterForAction Output
	
	If Not Exists (Select Top 1 1 From dbo.ffParameterForAction Where [idfParameterForAction] = @idfParameterForAction) BEGIN
		 
		 Insert Into [dbo].[ffParameterForAction]
			   (
		   			[idfParameterForAction]
					,[idfsRule]
					,[idfsFormTemplate]
					,[idfsParameter]
					,[idfsRuleAction]
			   )
		 Values
			   (
			   		@idfParameterForAction
					,@idfsRule
					,@idfsFormTemplate
					,@idfsParameter
					,@idfsRuleAction
			   )
	End Else BEGIN
	         	Update [dbo].[ffParameterForAction]
				   Set 
						[idfsRuleAction] = @idfsRuleAction
						,[intRowStatus] = 0
					Where [idfParameterForAction] = @idfParameterForAction
	End
   
End
Go
