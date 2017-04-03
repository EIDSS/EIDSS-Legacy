set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFRemoveTemplate')) DROP PROCEDURE [dbo].spFFRemoveTemplate
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveTemplate
(
	@idfsFormTemplate Bigint
)
AS
BEGIN
	Set Nocount On;	
	Set Xact_abort On;
	
	declare	@ErrorMessage nvarchar(400)
	
	Begin Try
		Select @ErrorMessage = [ErrorMessage] From dbo.fnFFCheckForRemoveTemplate(@ErrorMessage);
	
		If (@ErrorMessage Is Not Null) Exec dbo.spThrowException @ErrorMessage
		
		-- получаем полный перечень языков
		-- удаление языковых настроек
--		Declare cursLang Cursor For 
--			Select Distinct idfsLanguage From dbo.ffSectionDesignOption
--			Union
--			Select Distinct idfsLanguage From dbo.ffParameterDesignOption
--			Union
--			Select Distinct idfsLanguage From dbo.ffDecorElement
--		---
--		Declare @idfsLanguage Bigint
--		Open cursLang;
--			Fetch Next From cursLang Into @idfsLanguage
--			While (@@FETCH_STATUS = 0) BEGIN
		Exec dbo.spFFRemoveTemplateDesignOptions @idfsFormTemplate--, @idfsLanguage		                           
--					 Fetch Next From cursLang Into @idfsLanguage                  	
--			 End   
--	   Close cursLang;
--	   Deallocate cursLang;
	   
	   Declare @id Bigint
	   
	   -- удаляем данные по самому шаблону  
	   
	   -- удаляем правила
	   Declare curs Cursor Local Forward_only Static
			For Select distinct [idfsRule] From dbo.ffRule Where idfsFormTemplate = @idfsFormTemplate  --And [intRowStatus] = 0
		Open curs
		Fetch Next From curs into @id

		While @@FETCH_STATUS = 0 Begin
			Exec dbo.spFFRemoveRule @id
			Fetch Next From curs into @id
		End

		Close curs
		Deallocate curs 
	   
		-- удаляем параметры в шаблоне	
		Declare curs Cursor Local Forward_only Static
			For Select distinct [idfsParameter] From dbo.ffParameterForTemplate Where idfsFormTemplate = @idfsFormTemplate  --And [intRowStatus] = 0
		Open curs
		Fetch Next From curs into @id

		While @@FETCH_STATUS = 0 Begin
			Exec dbo.spFFRemoveParameterTemplate @id, @idfsFormTemplate, 'en' -- 'en', чтобы удалилось всё!
			Fetch Next From curs into @id
		End

		Close curs
		Deallocate curs	
	   
	   -- удаляем секции в шаблоне
	   Declare curs Cursor Local Forward_only Static
			For Select distinct [idfsSection] From dbo.ffSectionForTemplate Where idfsFormTemplate = @idfsFormTemplate -- And [intRowStatus] = 0
		Open curs
		Fetch Next From curs into @id

		While @@FETCH_STATUS = 0 Begin
			Exec dbo.spFFRemoveSectionTemplate @id, @idfsFormTemplate, 'en' -- 'en', чтобы удалилось всё!
			Fetch Next From curs into @id
		End

		Close curs
		Deallocate curs
	   
	   -- удаляем лейблы	  
	   Declare curs Cursor Local Forward_only Static
			For Select distinct DET.[idfDecorElement] From dbo.ffDecorElementText DET
						Inner Join dbo.ffDecorElement DE On DE.idfDecorElement = DET.idfDecorElement
							Where idfsFormTemplate = @idfsFormTemplate
--										 And DET.[intRowStatus] = 0
--										  And DE.[intRowStatus] = 0
		Open curs
		Fetch Next From curs into @id

		While @@FETCH_STATUS = 0 Begin
			Exec dbo.spFFRemoveLabel @id
			Fetch Next From curs into @id
		End

		Close curs
		Deallocate curs
	   
	   -- удаляем линии
	   Declare curs Cursor Local Forward_only Static
			For Select distinct DEL.[idfDecorElement] From dbo.ffDecorElementLine DEL
						Inner Join dbo.ffDecorElement DE On DE.idfDecorElement = DEL.idfDecorElement
							Where idfsFormTemplate = @idfsFormTemplate
--										 And DEL.[intRowStatus] = 0
--										  And DE.[intRowStatus] = 0
		Open curs
		Fetch Next From curs into @id

		While @@FETCH_STATUS = 0 Begin
			Exec dbo.spFFRemoveLine @id
			Fetch Next From curs into @id
		End

		Close curs
		Deallocate curs
			
		-- удаляем детерминанты
	   Declare curs Cursor Local Forward_only Static
			For Select distinct idfDeterminantValue From dbo.ffDeterminantValue						
							Where idfsFormTemplate = @idfsFormTemplate --And [intRowStatus] = 0
		Open curs
		Fetch Next From curs into @id

		While @@FETCH_STATUS = 0 Begin
			Exec dbo.spFFRemoveTemplateDeterminantValues @id
			Fetch Next From curs into @id
		End

		Close curs
		Deallocate curs
		
		--- удаляем сам шаблон
		Delete from dbo.ffFormTemplate
		Where 
			idfsFormTemplate = @idfsFormTemplate

		Exec dbo.spsysBaseReference_Delete @idfsFormTemplate

	End try
	begin catch		
		select @ErrorMessage = error_message()
		raiserror(@ErrorMessage, 16, 1);
	end catch
End
Go