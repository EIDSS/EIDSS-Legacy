set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFRemoveTemplateDeterminantValues')) DROP PROCEDURE [dbo].spFFRemoveTemplateDeterminantValues
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveTemplateDeterminantValues
(
	@idfDeterminantValue Bigint
)
AS
BEGIN
	Set Nocount On;	
	--	
	Delete from dbo.[ffDeterminantValue] Where [idfDeterminantValue] = @idfDeterminantValue
		
END