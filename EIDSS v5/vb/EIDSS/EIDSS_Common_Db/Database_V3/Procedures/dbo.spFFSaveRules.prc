set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFSaveRules]')) DROP PROCEDURE [dbo].[spFFSaveRules]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFSaveRules 
(	
	@idfsRule Bigint Output	
	,@idfsFormTemplate Bigint
    ,@idfsRuleMessage Bigint Output    
	,@idfsCheckPoint Bigint
    ,@idfsRuleFunction Bigint = Null
    ,@DefaultName NVarchar(200)
    ,@NationalName Nvarchar(300)
    ,@MessageText NVarchar(200)
    ,@MessageNationalText NVarchar(300)   
    ,@blnNot Bit
    ,@LangID Nvarchar(50) = Null
)	
AS
BEGIN	
	Set Nocount On;

	-- если не задана функция для правила, то не сохраняем это правило
	if (@idfsRuleFunction Is Null) Return;
	
	If (@LangID Is Null) Set @LangID = 'en';
	
	-- если id < 0, значит, это временный id и нужно заменить его на настоящий
	If (@idfsRule < 0) Exec dbo.[spsysGetNewID] @idfsRule Output
	If (@idfsRuleMessage < 0) Exec dbo.[spsysGetNewID] @idfsRuleMessage Output	
	
	-- сохраняем названия
	Exec dbo.spBaseReference_SysPost @idfsRule,19000029 /*'rftFFRule'*/,@LangID, @DefaultName, @NationalName, 0
	-- и сообщение тоже
	Exec dbo.spBaseReference_SysPost @idfsRuleMessage, 19000032 /*'rftFFRuleMessage'*/,@LangID, @MessageText, @MessageNationalText, 0
			
	If Not Exists (Select Top 1 1 From dbo.ffRule Where [idfsRule] = @idfsRule) BEGIN
		 Insert Into [dbo].[ffRule]
			   (
			   		[idfsRule]
					,[idfsRuleMessage]
					,[idfsFormTemplate]
					,[idfsCheckPoint]
					,[idfsRuleFunction]
					,[intRowStatus]
					,[blnNot]					
			   )
		 VALUES
			   (
			   		@idfsRule
				   ,@idfsRuleMessage
				   ,@idfsFormTemplate
				   ,@idfsCheckPoint	
				   ,@idfsRuleFunction
				   ,0
				   ,@blnNot
			   )
	End Else BEGIN
	         	Update [dbo].[ffRule]
				   Set 
						[idfsRuleMessage]	 = 	@idfsRuleMessage			
						,[idfsFormTemplate] = @idfsFormTemplate 				
						,[idfsCheckPoint] = @idfsCheckPoint
						,[idfsRuleFunction] = @idfsRuleFunction
						,[blnNot] = @blnNot
						,[intRowStatus] = 0
					Where [idfsRule] = @idfsRule
	End
   
End
Go
