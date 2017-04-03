set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFSaveParameterTemplate')) DROP PROCEDURE [dbo].spFFSaveParameterTemplate
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 22.09.09
-- Description:	Save Template
-- =============================================
Create Procedure dbo.spFFSaveParameterTemplate
(
		@idfsParameter Bigint
		  ,@idfsFormTemplate Bigint
		  ,@LangID Nvarchar(50) = Null
		  ,@idfsEditMode Bigint = Null
		  ,@intLeft Int = Null
		  ,@intTop Int = Null
		  ,@intWidth Int = Null
		  ,@intHeight Int = Null
		  ,@intScheme Int = Null
		  ,@intLabelSize Int = Null
		  ,@intOrder Int = Null
		  ,@blnFreeze Bit = Null
)
AS
BEGIN
	Set Nocount On;	
	
	If (@idfsEditMode Is Null) Set @idfsEditMode = 10068001;
	If (@intLeft Is Null) Set @intLeft = 0;
	If (@intTop Is Null) Set @intTop = 0;
	If (@intWidth Is Null) Set @intWidth = 0;
	If (@intHeight Is Null) Set @intHeight = 0;	
	If (@intScheme Is Null) Set @intScheme = 0;	
	If (@blnFreeze Is Null) Set @blnFreeze = 0;
	
	If (@intLabelSize Is Null) Begin 
		If (@intScheme = 0 Or @intScheme = 1)
			Set @intLabelSize = @intWidth / 2
		Else
			Set @intLabelSize = @intWidth;
	End;
	If (@intOrder Is Null) Set @intOrder = 0;	

	If Not Exists (Select Top 1 1 From [dbo].[ffParameterForTemplate] Where [idfsParameter] = @idfsParameter And [idfsFormTemplate] = @idfsFormTemplate) BEGIN
		 Insert Into [dbo].[ffParameterForTemplate]
           (
           		[idfsParameter]
           		,[idfsFormTemplate]			  	   
				,[idfsEditMode]		
				,[blnFreeze]		
           )
		Values
           (
           		@idfsParameter
           		,@idfsFormTemplate
				,@idfsEditMode	
				,@blnFreeze			
           )          
	End Else BEGIN
	       Update [dbo].[ffParameterForTemplate]
				Set 						
				 		[idfsEditMode] = @idfsEditMode
				 		,[blnFreeze] = @blnFreeze
				 		,[intRowStatus] = 0
 				Where  
 						[idfsParameter] = @idfsParameter
 						And 
 						[idfsFormTemplate] = @idfsFormTemplate 						
	End
	
	-----------------------------------
	Exec dbo.[spFFSaveParameterDesignOptions] 
			@idfsParameter
			,@idfsFormTemplate
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