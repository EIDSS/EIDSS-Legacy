set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spEIDSSUpdate_GetCurrentLanguage')) DROP PROCEDURE [dbo].spEIDSSUpdate_GetCurrentLanguage
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spEIDSSUpdate_GetCurrentLanguage
(
	@ClientID Nvarchar(50)	
)
AS
BEGIN
	Set Nocount On;
	
	-- определяем событие, произошедшее позже
	-- старт EIDSS или смена языка в конфиге
	-- если смена языка в конфиге, то возвращаем этот язык, иначе пустую строку, чтобы можно было
	-- взять стартовый язык в конфиге
	
	Declare 
		@dtEvent Datetime
		,@dtSecurityAudit Datetime
		,@Language Nvarchar(255)
	
	Select Top 1 @dtEvent = [datEventDatatime], @Language = strInformationString  From dbo.tstEvent 
				Where idfsEventTypeID = 10025001 
						And strClient = @ClientID
				Order By [datEventDatatime] Desc
				
	Select Top 1 @dtSecurityAudit = [datActionDate] From dbo.tstSecurityAudit 
				Where idfsAction = 10110002
						And idfsProcessType = 10130000
						And idfsResult = 10120000
						And strProcessID = @ClientID						
				Order By [datActionDate] Desc
	
	Select
		@dtEvent As [Event]
		,@dtSecurityAudit As [SecurityAudit]
		,@Language As [Language]
	
	
END