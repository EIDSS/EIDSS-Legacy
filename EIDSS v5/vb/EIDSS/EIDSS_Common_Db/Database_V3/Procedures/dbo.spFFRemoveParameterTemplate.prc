set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFRemoveParameterTemplate')) DROP PROCEDURE [dbo].spFFRemoveParameterTemplate
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveParameterTemplate
(
	@idfsParameter Bigint
	,@idfsFormTemplate Bigint
	,@LangID  Nvarchar(50) = null
)
AS
BEGIN
	Set Nocount On;
	
	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);
	
	-- удаляем специфические данные из языковых таблиц
	Delete from dbo.ffParameterDesignOption
	Where
		idfsParameter = @idfsParameter 
		And
		idfsFormTemplate = @idfsFormTemplate
		And
		idfsLanguage = @LangID_int
		
	If (@LangID = 'en') Begin	                    	
	        -- удаляем все языковые настройки
	        Delete from dbo.ffParameterDesignOption
			Where
				idfsParameter = @idfsParameter 
				And
				idfsFormTemplate = @idfsFormTemplate
	        --
			Delete from dbo.ffParameterForTemplate
			Where
				idfsParameter = @idfsParameter 
				And
				idfsFormTemplate = @idfsFormTemplate
	end	
End
Go