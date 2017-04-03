set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFRemoveParameter')) DROP PROCEDURE [dbo].spFFRemoveParameter
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveParameter
(
	@idfsParameter BigInt	
)
AS
BEGIN
	Set Nocount On;
	
	declare	@ErrorMessage nvarchar(400)
	
	begin try
		-- должны быть удалены все зависимые записи	
		Select @ErrorMessage = [ErrorMessage] From dbo.fnFFCheckForRemoveParameter(@ErrorMessage);
	
		If (@ErrorMessage Is Not Null) Exec dbo.spThrowException @ErrorMessage
		
		-- удаляем параметр из шаблонов
		If Exists(Select Top 1 1 From dbo.ffParameterForTemplate Where idfsParameter = @idfsParameter) begin
			Declare @st_id Bigint
			Declare curs Cursor Local Forward_only Static
				For Select Distinct idfsFormTemplate From dbo.ffParameterForTemplate Where idfsParameter = @idfsParameter And [intRowStatus] = 0
			Open curs
			Fetch Next From curs into @st_id
			
			While @@FETCH_STATUS = 0 Begin
				Exec dbo.spFFRemoveParameterTemplate @idfsParameter, 	@st_id		
				Fetch Next From curs into @st_id
			End
			
			Close curs
			Deallocate curs
		End
		
		Delete from dbo.ffParameterDesignOption Where idfsParameter = @idfsParameter And idfsFormTemplate Is Null
		
		Delete from dbo.ffParameter	Where	idfsParameter = @idfsParameter

		Exec dbo.spsysBaseReference_Delete @idfsParameter

	End try
	begin catch
		select @ErrorMessage = error_message()	
		raiserror(@ErrorMessage, 16, 1);	
	end catch
End
Go