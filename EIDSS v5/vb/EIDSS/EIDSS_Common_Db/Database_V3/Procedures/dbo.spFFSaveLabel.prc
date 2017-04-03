set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFSaveLabel')) DROP PROCEDURE [dbo].spFFSaveLabel
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFSaveLabel
(
	@idfDecorElement Bigint Output
	,@idfsBaseReference Bigint Output
   ,@LangID Nvarchar(50) = Null
   ,@idfsFormTemplate Bigint
   ,@idfsSection Bigint
   ,@intLeft int
   ,@intTop int
   ,@intWidth int
   ,@intHeight Int
   ,@intFontStyle Int
   ,@intFontSize Int	
   ,@intColor Int
   ,@DefaultText Varchar(200)
   ,@NationalText Nvarchar(400)
)
AS
BEGIN
	Set Nocount On;
	
	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);
	
	-- если id < 0, значит, это временный id и нужно заменить его на настоящий
	If (@idfDecorElement < 0) Begin
			Exec dbo.[spsysGetNewID] @idfDecorElement Output
			Exec dbo.[spsysGetNewID] @idfsBaseReference Output
	End --Else Begin
			--Select @idfsBaseReference = [idfsBaseReference] From dbo.[ffDecorElementText] Where idfDecorElement = @idfDecorElement
	--End
	
	-- сохраняем названия
	Exec dbo.spBaseReference_SysPost @idfsBaseReference, 19000131, @LangID, @DefaultText, @NationalText, 0
	
	If Not Exists (Select Top 1 1 From dbo.ffDecorElement Where [idfDecorElement] = @idfDecorElement) BEGIN
		 Insert into [dbo].[ffDecorElement]
           (
           		[idfDecorElement]
				,[idfsDecorElementType]
				,[idfsLanguage]
				,[idfsFormTemplate]
				,[idfsSection]
           )
		Values
           (
           		@idfDecorElement
			   ,10106001
			   ,@LangID_int
			   ,@idfsFormTemplate
			   ,@idfsSection
           )
           
           Insert into [dbo].[ffDecorElementText]
           (
           		[idfDecorElement]
           		,[idfsBaseReference]
				,[intFontSize]
				,[intFontStyle]
				,[intColor]
				,[intLeft]
				,[intTop]
				,[intWidth]
				,[intHeight]
           )
           Values
           (
           		@idfDecorElement
           		,@idfsBaseReference
           		,@intFontSize
				,@intFontStyle
				,@intColor
           		,@intLeft
			    ,@intTop
				,@intWidth
				,@intHeight
           )          
           
	End Else BEGIN
		  Update [dbo].[ffDecorElementText]
           Set
            	[intFontSize] = @intFontSize
				,[intFontStyle] = @intFontStyle
				,[intColor] = @intColor
				,[intLeft] = @intLeft
				,[intTop] = @intTop
				,[intWidth] = @intWidth
				,[intHeight] = @intHeight
				,[intRowStatus] = 0
			Where
				[idfDecorElement] = @idfDecorElement            
	End
	
END