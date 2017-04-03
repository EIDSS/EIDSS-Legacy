set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFSaveSectionTemplate')) DROP PROCEDURE [dbo].spFFSaveSectionTemplate
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 22.09.09
-- Description:
-- =============================================
Create Procedure dbo.spFFSaveSectionTemplate
(
		@idfsSection Bigint
		,@idfsFormTemplate Bigint
		,@blnFreeze bit = Null
		,@LangID Nvarchar(50) = Null
		,@intLeft Int = Null
		,@intTop Int = Null
		,@intWidth Int = Null
		,@intHeight Int = Null
		,@intCaptionHeight Int = Null
		,@intOrder Int = Null
)
AS
BEGIN
	Set Nocount On;
	
	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);
	
	If (@blnFreeze Is Null) Set @blnFreeze = 0;
	If (@intLeft Is Null) Set @intLeft = 0;
	If (@intTop Is Null) Set @intTop = 0;
	If (@intWidth Is Null) Set @intWidth = 0;
	If (@intHeight Is Null) Set @intHeight = 0;	
	If (@intOrder Is Null) Set @intOrder = 0;
	If (@intCaptionHeight Is Null) Set @intCaptionHeight = 23; --default
	
	If Not Exists (Select Top 1 1 From [dbo].[ffSectionForTemplate] Where [idfsSection] = @idfsSection And [idfsFormTemplate] = @idfsFormTemplate) BEGIN
		 Insert Into [dbo].[ffSectionForTemplate]
           (
           		[idfsSection]
           		,[idfsFormTemplate]			  	   
				,[blnFreeze]
				,[intRowStatus]
           )
		Values
           (
           		@idfsSection
           		,@idfsFormTemplate
				,@blnFreeze
				,0
           )          
	End Else BEGIN
	       Update [dbo].[ffSectionForTemplate]
				Set 						
				 		[blnFreeze] = @blnFreeze	
				 		,[intRowStatus] = 0			
 				Where  
 						[idfsSection] = @idfsSection  
 						And 
 						[idfsFormTemplate] = @idfsFormTemplate
	End
	
	-----------------------------------
	Exec dbo.[spFFSaveSectionDesignOptions]
				@idfsSection
				,@idfsFormTemplate
           		,@intLeft
				,@intTop
				,@intWidth
				,@intHeight
				,@intCaptionHeight
           		,@LangID
           		,@intOrder
	
End
Go
