set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFSaveSectionDesignOptions]')) DROP PROCEDURE [dbo].[spFFSaveSectionDesignOptions]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.[spFFSaveSectionDesignOptions] 
(	
	@idfsSection Bigint
	,@idfsFormTemplate Bigint
	,@intLeft Int
	,@intTop Int    
    ,@intWidth Int  
    ,@intHeight Int
    ,@intCaptionHeight Int
    ,@LangID Nvarchar(50)
    ,@intOrder Int
)	
AS
BEGIN	
	Set Nocount On;
	
	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint, @LangID_intEn Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);
	Set @LangID_intEn = dbo.fnGetLanguageCode('en');
	
	Declare @idfSectionDesignOption Bigint
	
	If (@idfsFormTemplate Is Null) BEGIN
		Select @idfSectionDesignOption = [idfSectionDesignOption] From dbo.ffSectionDesignOption Where 
								[idfsSection] = @idfsSection And idfsFormTemplate Is Null And [idfsLanguage] = @LangID_int And intRowStatus = 0
	End Else BEGIN	         	
	    Select @idfSectionDesignOption = [idfSectionDesignOption] From dbo.ffSectionDesignOption Where 
								[idfsSection] = @idfsSection And [idfsFormTemplate] = @idfsFormTemplate And [idfsLanguage] = @LangID_int And intRowStatus = 0     	
	END
		 
	If (@idfSectionDesignOption Is Null) BEGIN
	         Exec dbo.[spsysGetNewID] @idfSectionDesignOption Output
	         Insert [dbo].[ffSectionDesignOption]
				   (
				   		[idfSectionDesignOption]
					   ,[intLeft]
					   ,[intTop]					   
					   ,[intWidth]
					   ,[intHeight]
					   ,[intCaptionHeight]
					   ,[idfsSection]
					   ,[idfsLanguage]
					   ,[idfsFormTemplate]
					   ,[intOrder]
				   )
			 VALUES
				   (
				   		@idfSectionDesignOption
						,@intLeft
						,@intTop					   
					   ,@intWidth
					   ,@intHeight			
					   ,@intCaptionHeight		   					 			  
					   ,@idfsSection
					   ,@LangID_int
					   ,@idfsFormTemplate
					   ,@intOrder
				   )
			-- если вставлялась запись не для дефолтного языка, то создадим её для дефолтного
			If (@LangID <> 'en') Begin
				Declare @idfSectionDesignOptionEN Bigint 
				
				If (@idfsFormTemplate Is Null) BEGIN
					Select @idfSectionDesignOptionEN = [idfSectionDesignOption] From dbo.ffSectionDesignOption Where 
										[idfsSection] = @idfsSection And idfsFormTemplate Is Null And [idfsLanguage] = @LangID_intEN And intRowStatus = 0
				End Else BEGIN	         	
					Select @idfSectionDesignOptionEN = [idfSectionDesignOption] From dbo.ffSectionDesignOption Where 
										[idfsSection] = @idfsSection And [idfsFormTemplate] = @idfsFormTemplate And [idfsLanguage] = @LangID_intEN And intRowStatus = 0  	
				END
							
				-- если не удалось найти английский язык, то нужно создать его описание
				-- если есть, то не трогаем
				If (@idfSectionDesignOptionEN Is Null) Begin
						Exec dbo.[spsysGetNewID] @idfSectionDesignOptionEN Output
						Insert [dbo].[ffSectionDesignOption]
						   (
				   				[idfSectionDesignOption]
							   ,[intLeft]
							   ,[intTop]					   
							   ,[intWidth]	
							   ,[intHeight]
							   ,[intCaptionHeight]
							   ,[idfsSection]
							   ,[idfsLanguage]
							   ,[idfsFormTemplate]
							   ,[intOrder]
						   )
					   Values
						   (
				   				@idfSectionDesignOptionEN
								,@intLeft
								,@intTop					   
							   ,@intWidth
							   ,@intHeight		
							   ,@intCaptionHeight			   					  			 
							   ,@idfsSection
							   ,@LangID_intEn
							   ,@idfsFormTemplate
							   ,@intOrder
						   )			                     	
					   End
				End
	End Else BEGIN
	         	Update [dbo].[ffSectionDesignOption]
					   Set
							[intLeft] = @intLeft 						
						   ,[intTop] = @intTop
						   ,[intWidth] = @intWidth						  
						   ,[intHeight] = @intHeight
						   ,[intCaptionHeight] = @intCaptionHeight
						   ,[intOrder] = @intOrder
						   ,[intRowStatus] = 0
					 Where 
							[idfSectionDesignOption] = @idfSectionDesignOption
	 END	
   
End
Go
