set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFSaveParameterDesignOptions]')) DROP PROCEDURE [dbo].[spFFSaveParameterDesignOptions]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.[spFFSaveParameterDesignOptions] 
(	
	@idfsParameter Bigint
	,@idfsFormTemplate Bigint
	,@intLeft Int
	,@intTop Int
    ,@intWidth Int
    ,@intHeight Int    
    ,@intScheme Int
    ,@intLabelSize Int
    ,@intOrder Int
    ,@LangID Nvarchar(50)   
)	
AS
BEGIN	
	Set Nocount On;
	
	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint, @LangID_intEn Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);
	Set @LangID_intEn = dbo.fnGetLanguageCode('en');
	
	Declare @idfParameterDesignOption Bigint
	
	If (@idfsFormTemplate Is Null) BEGIN
		Select @idfParameterDesignOption = [idfParameterDesignOption] From dbo.ffParameterDesignOption Where 
								[idfsParameter] = @idfsParameter And idfsFormTemplate Is Null And [idfsLanguage] = @LangID_int And [intRowStatus] = 0
	End Else BEGIN	         	
	    Select @idfParameterDesignOption = [idfParameterDesignOption] From dbo.ffParameterDesignOption Where 
								[idfsParameter] = @idfsParameter And [idfsFormTemplate] = @idfsFormTemplate And [idfsLanguage] = @LangID_int And [intRowStatus] = 0    	
	END
		 
	If (@idfParameterDesignOption Is Null) BEGIN
	         Exec dbo.[spsysGetNewID] @idfParameterDesignOption Output
	         Insert [dbo].[ffParameterDesignOption]
				   (
				   		[idfParameterDesignOption]
					   ,[intLeft]
					   ,[intTop]
					   ,[intWidth]
					   ,[intHeight]					   
					   ,[intScheme]
					   ,[intLabelSize]					 
					   ,[idfsParameter]
					   ,[idfsLanguage]
					   ,[idfsFormTemplate]
					   ,[intOrder]
				   )
			 VALUES
				   (
				   		@idfParameterDesignOption
						,@intLeft
						,@intTop
					   ,@intWidth
					   ,@intHeight					   
					   ,@intScheme
					   ,@intLabelSize					  
					   ,@idfsParameter
					   ,@LangID_int
					   ,@idfsFormTemplate
					   ,@intOrder
				   )
			-- если вставлялась запись не для дефолтного языка, то создадим её для дефолтного
			If (@LangID <> 'en') Begin
				Declare @idfParameterDesignOptionEN Bigint 
				
				If (@idfsFormTemplate Is Null) BEGIN
					Select @idfParameterDesignOptionEN = [idfParameterDesignOption] From dbo.ffParameterDesignOption Where 
										[idfsParameter] = @idfsParameter And idfsFormTemplate Is Null And [idfsLanguage] = @LangID_intEN  And intRowStatus = 0
				End Else BEGIN	         	
					Select @idfParameterDesignOptionEN = [idfParameterDesignOption] From dbo.ffParameterDesignOption Where 
										[idfsParameter] = @idfsParameter And [idfsFormTemplate] = @idfsFormTemplate And [idfsLanguage] = @LangID_intEN  And intRowStatus = 0  	
				END
							
				-- если не удалось найти английский язык, то нужно создать его описание
				-- если описание уже есть, то не трогаем его
				If (@idfParameterDesignOptionEN Is Null)	Begin
						Exec dbo.[spsysGetNewID] @idfParameterDesignOptionEN Output
						Insert [dbo].[ffParameterDesignOption]
						   (
				   				[idfParameterDesignOption]
							   ,[intLeft]
							   ,[intTop]
								,[intWidth]
							   ,[intHeight]					  
							   ,[intScheme]
							   ,[intLabelSize]						 
							   ,[idfsParameter]
							   ,[idfsLanguage]
							   ,[idfsFormTemplate]
							   ,[intOrder]
						   )
					 Values
						   (
				   				@idfParameterDesignOptionEN
								,@intLeft
								,@intTop
								,@intWidth
								,@intHeight					   
							   ,@intScheme
							   ,@intLabelSize					 
							   ,@idfsParameter
							   ,@LangID_intEn
							   ,@idfsFormTemplate
							   ,@intOrder
						   )			                     	
				End
			End
	End Else BEGIN
	         	Update [dbo].[ffParameterDesignOption]
					   Set 
					   		[intLeft] = @intLeft				
						   ,[intTop] = @intTop
						   ,[intWidth] = @intWidth
						   ,[intHeight] = @intHeight						  
						   ,[intScheme] = @intScheme
						   ,[intLabelSize] = @intLabelSize
						   ,[intOrder] = @intOrder
						   ,[intRowStatus] = 0							
					 Where 
							[idfParameterDesignOption] = @idfParameterDesignOption
	 END	
   
End
Go
