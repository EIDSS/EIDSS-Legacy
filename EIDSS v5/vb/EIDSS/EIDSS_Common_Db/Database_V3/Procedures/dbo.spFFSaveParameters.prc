set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFSaveParameters')) DROP PROCEDURE [dbo].spFFSaveParameters
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 14.09.09
-- Description:
-- =============================================
Create Procedure dbo.spFFSaveParameters
(
	@idfsParameter Bigint Output
	,@idfsSection Bigint   
    ,@idfsFormType Bigint   
    ,@idfsParameterCaption Bigint Output
    ,@intScheme Int
    ,@idfsParameterType Bigint
	,@idfsEditor Bigint
	,@intHACode Int	
	,@intOrder Int = 0
	,@strNote Nvarchar(1000)
    ,@DefaultName Nvarchar(400)
    ,@NationalName Nvarchar(600) = Null
    ,@DefaultLongName Nvarchar(400) = Null
    ,@NationalLongName Nvarchar(600) = Null
    ,@LangID Nvarchar(50) = Null   
    ,@intLeft Int  
    ,@intTop Int
    ,@intWidth Int
	,@intHeight Int
	,@intLabelSize Int
)	
AS
BEGIN	
	Set Nocount On;

	-- если id < 0, значит, это временный id и нужно заменить его на настоящий
	If (@idfsParameter < 0) Exec dbo.[spsysGetNewID] @idfsParameter Output
	If (@idfsParameterCaption < 0) Exec dbo.[spsysGetNewID] @idfsParameterCaption Output
	
	-- TODO: вставить проверку значений.
	-- если параметр уже используется в шаблоне, то нельзя сменить его Scheme и Control Type
	-- или только Control Type нельзя сменить (пока не ясно)
	
	-- сохраняем названия
	-- причем отдельно для обычного имени, и отдельно для длинного имени
	Exec dbo.spBaseReference_SysPost @idfsParameter, 19000066/*'rftParameter'*/,@LangID, @DefaultLongName, @NationalLongName, 0
	Exec dbo.spBaseReference_SysPost @idfsParameterCaption, 19000070 /*'rftParameterToolTip'*/,@LangID, @DefaultName, @NationalName, 0
		
	If Not Exists (Select Top 1 1 From dbo.ffParameter Where idfsParameter = @idfsParameter) BEGIN
			 Insert into [dbo].[ffParameter]
					 (
			   				 [idfsParameter]
							,[idfsSection]
							,[idfsFormType]						
							,[idfsParameterType]
							,[idfsEditor]
							,[idfsParameterCaption]
							,[intHACode]
							,[strNote]
							,[intOrder]					
					)
			Values
					(
							@idfsParameter
							,@idfsSection
							,@idfsFormType						
							,@idfsParameterType
							,@idfsEditor
							,@idfsParameterCaption
							,@intHACode
							,@strNote
							,@intOrder
					)
	End Else BEGIN
	       Update [dbo].[ffParameter]
					   SET 						 
							[idfsSection] = @idfsSection
							,[idfsFormType] = @idfsFormType
							,[idfsParameterType] = @idfsParameterType
							,[idfsEditor] = @idfsEditor
							,[idfsParameterCaption] = @idfsParameterCaption
							,[intHACode] = @intHACode
							,[strNote] = @strNote
							,[intOrder] = @intOrder
							,[intRowStatus] = 0
					 WHERE [idfsParameter] = @idfsParameter
	End
	
	Exec dbo.[spFFSaveParameterDesignOptions] 
			@idfsParameter
			,null
			,@intLeft
			,@intTop
			,@intWidth
			,@intHeight			
			,@intScheme
			,@intLabelSize
			,@intOrder
			,@LangID
					
End
Go