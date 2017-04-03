set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spEIDSSUpdate_RemoveApplications')) DROP PROCEDURE [dbo].spEIDSSUpdate_RemoveApplications
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spEIDSSUpdate_RemoveApplications
AS
BEGIN
	Set Nocount On;
	
	-- удалим регистрацию всех приложений, которые висят без обновления более 3 минут
	Declare @minuteCount Int
	Set @minuteCount = 3;
	
	Declare @deadLineDate Datetime
	Select  @deadLineDate = Dateadd(minute,  -@minuteCount, Getdate())
	Delete from dbo.updRunningApps Where datDateLastUpdate < @deadLineDate
		
END