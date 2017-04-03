set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spEIDSSUpdate_DeleteRunningApps')) DROP PROCEDURE [dbo].spEIDSSUpdate_DeleteRunningApps
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spEIDSSUpdate_DeleteRunningApps
(
	@ClientID Nvarchar(50) 
   ,@Application Nvarchar(50)  
)
AS
BEGIN
	Set Nocount On;
	
	Delete from dbo.updRunningApps Where [strClientID] = @ClientID And [strApplication] = @Application
	
END