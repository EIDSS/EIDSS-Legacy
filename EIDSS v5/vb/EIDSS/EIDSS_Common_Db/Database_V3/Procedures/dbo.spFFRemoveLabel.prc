set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFRemoveLabel')) DROP PROCEDURE [dbo].spFFRemoveLabel
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveLabel
(
	@idfDecorElement Bigint
)
AS
BEGIN
	Set Nocount On;	
	
	-- удаляем зависимые объекты
	Delete from dbo.[ffDecorElementText] Where [idfDecorElement] = @idfDecorElement
		
	--	
	Delete from dbo.[ffDecorElement]	Where [idfDecorElement] = @idfDecorElement
		
END