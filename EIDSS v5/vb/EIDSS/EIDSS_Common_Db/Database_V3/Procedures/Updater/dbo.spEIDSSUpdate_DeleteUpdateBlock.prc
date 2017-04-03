set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spEIDSSUpdate_DeleteUpdateBlock')) DROP PROCEDURE [dbo].spEIDSSUpdate_DeleteUpdateBlock
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spEIDSSUpdate_DeleteUpdateBlock
AS
BEGIN
	Set Nocount On;	
	
	 Delete from dbo.updUpdateBlock
	
END