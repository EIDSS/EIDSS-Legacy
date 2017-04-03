set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spEIDSSUpdate_GetRunningApps')) DROP PROCEDURE [dbo].spEIDSSUpdate_GetRunningApps
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spEIDSSUpdate_GetRunningApps
AS
BEGIN
	Set Nocount On;
	
	-- очистим аварийно завершившиеся приложения
	Exec dbo.spEIDSSUpdate_RemoveApplications
	
	-- TODO переделать правильно
	Select [strClientID]
				,[strApplication]
				,[datDateLastUpdate]
	From dbo.updRunningApps
	Where [strApplication] <> 'ns'
	
END