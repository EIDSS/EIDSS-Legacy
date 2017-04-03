set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spFFSaveSectionTemplateRecursive')) DROP PROCEDURE dbo.spFFSaveSectionTemplateRecursive
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 22.09.09
-- Description:
-- =============================================
Create Procedure dbo.spFFSaveSectionTemplateRecursive
(
		@idfsSection Bigint
		,@idfsFormTemplate Bigint
		,@blnFreeze bit = Null
		,@LangID Nvarchar(50) = Null
		,@intLeft Int = Null
		,@intTop Int = Null
		,@intWidth Int = Null
		,@intHeight Int = Null
		,@intOrder Int = Null
)
AS
BEGIN
	Set Nocount On;
	
	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);
	
	Exec dbo.spFFSaveSectionTemplate @idfsSection,@idfsFormTemplate,@blnFreeze,@LangID,@intLeft	,@intTop,@intWidth,@intHeight,@intOrder
	
	-- если есть родитель у секции, то и её занесём
	Declare @idfsParentSection Bigint					
	Select @idfsParentSection = [idfsParentSection]	 From dbo.ffSection Where idfsSection =@idfsSection	
	
	If (@idfsParentSection Is Not null) BEGIN
		Exec dbo.spFFSaveSectionTemplateRecursive @idfsParentSection, @idfsFormTemplate, @blnFreeze, @LangID, @intLeft, @intTop, @intWidth, @intHeight, @intOrder    
	END	
End
Go
