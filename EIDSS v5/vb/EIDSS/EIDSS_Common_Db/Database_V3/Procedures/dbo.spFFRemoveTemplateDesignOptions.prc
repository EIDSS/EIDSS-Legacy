set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFRemoveTemplateDesignOptions')) DROP PROCEDURE [dbo].spFFRemoveTemplateDesignOptions
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveTemplateDesignOptions
(
	@idfsFormTemplate Bigint
    ,@LangID Bigint = null
)
AS
BEGIN
	Set Nocount On;
	
	-- удаляем специфические данные из языковых таблиц
	Delete from dbo.ffDecorElementText
		from dbo.ffDecorElementText DET
		Inner Join dbo.ffDecorElement FDE On DET.idfDecorElement = FDE.idfDecorElement
	Where 
		FDE.idfsFormTemplate = @idfsFormTemplate
		And
		(FDE.idfsLanguage = @LangID Or @LangID Is Null)
		
	---
	Delete from dbo.ffDecorElementLine
		from dbo.ffDecorElementLine DEL
		Inner Join dbo.ffDecorElement FDE On DEL.idfDecorElement = FDE.idfDecorElement
	Where 
		FDE.idfsFormTemplate = @idfsFormTemplate
		And
		(FDE.idfsLanguage = @LangID Or @LangID Is Null)
	---
	Delete from dbo.ffDecorElement
	Where 
		idfsFormTemplate = @idfsFormTemplate
		And
		(idfsLanguage = @LangID Or @LangID Is Null)	
	---
	Delete from dbo.ffSectionDesignOption
	Where 
		idfsFormTemplate = @idfsFormTemplate
		And
		(idfsLanguage = @LangID Or @LangID Is Null)
	---
	Delete from dbo.ffParameterDesignOption
	Where 
		idfsFormTemplate = @idfsFormTemplate
		And
		(idfsLanguage = @LangID Or @LangID Is Null)
	---
	Delete from dbo.trtStringNameTranslation
	Where 
		idfsBaseReference = @idfsFormTemplate
		And
		(idfsLanguage = @LangID	 Or @LangID Is Null)
End
Go