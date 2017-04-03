set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFRemoveSection')) DROP PROCEDURE [dbo].spFFRemoveSection
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveSection
(
	@idfsSection BigInt	
)
AS
BEGIN
	Set Nocount On;
	Set Xact_abort On;
	
	declare	@ErrorMessage nvarchar(400)
	
	Begin try
			
		Select @ErrorMessage = [ErrorMessage] From dbo.fnFFCheckForRemoveSection(@ErrorMessage);
	
		If (@ErrorMessage Is Not Null) Exec dbo.spThrowException @ErrorMessage			
		
		-- если есть какие-то дочерние секции, которые ссылаются на эту секцию, то их надо удалить в первую очередь
		If Exists(Select Top 1 1 From dbo.ffSection Where idfsParentSection = @idfsSection) begin
			Declare @sect_id Bigint
			Declare curs Cursor Local Forward_only Static
				For Select distinct [idfsSection] From dbo.ffSection Where idfsParentSection = @idfsSection  And [intRowStatus] = 0
			Open curs
			Fetch Next From curs into @sect_id
			
			While @@FETCH_STATUS = 0 Begin
				Exec dbo.spFFRemoveSection @sect_id
				Fetch Next From curs into @sect_id
			End
			
			Close curs
			Deallocate curs
		End
		
		-- если есть какие-то дочерние параметры, которые находятся в этой секции, то их надо удалить
		If Exists(Select Top 1 1 From dbo.ffParameter Where idfsSection = @idfsSection) begin
			Declare @param_id Bigint
			Declare curs Cursor Local Forward_only Static
				For Select distinct [idfsParameter] From dbo.ffParameter Where idfsSection = @idfsSection  And [intRowStatus] = 0
			Open curs
			Fetch Next From curs into @param_id
			
			While @@FETCH_STATUS = 0 Begin
				Exec dbo.spFFRemoveParameter @param_id
				Fetch Next From curs into @param_id
			End
			
			Close curs
			Deallocate curs
		End
		
		-- если есть линии или лейблы, находящиеся в этой секции
		If Exists(Select Top 1 1 From dbo.ffParameter Where idfsSection = @idfsSection) begin
			Declare @de_id Bigint
			Declare curs Cursor Local Forward_only Static
				For Select Distinct idfDecorElement From dbo.ffDecorElement Where idfsSection = @idfsSection And [intRowStatus] = 0
			Open curs
			Fetch Next From curs into @de_id
			
			While @@FETCH_STATUS = 0 Begin
				Exec dbo.spFFRemoveLabel @de_id
				Exec dbo.spFFRemoveLine @de_id
				Fetch Next From curs into @de_id
			End
			
			Close curs
			Deallocate curs
		End
		
		-- удаляем секцию из шаблонов
		If Exists(Select Top 1 1 From dbo.ffSectionForTemplate Where idfsSection = @idfsSection) begin
			Declare @st_id Bigint
			Declare curs Cursor Local Forward_only Static
				For Select Distinct idfsFormTemplate From dbo.ffSectionForTemplate Where idfsSection = @idfsSection And [intRowStatus] = 0
			Open curs
			Fetch Next From curs into @st_id
			
			While @@FETCH_STATUS = 0 Begin
				Exec dbo.spFFRemoveSectionTemplate @idfsSection, 	@st_id		
				Fetch Next From curs into @st_id
			End
			
			Close curs
			Deallocate curs
		End
	
		Delete from dbo.ffSection	Where	idfsSection = @idfsSection

		Exec dbo.spsysBaseReference_Delete @idfsSection
		
	End try
	begin catch		
		select @ErrorMessage = error_message()	
		raiserror(@ErrorMessage, 16, 1);	
	end catch
End
Go