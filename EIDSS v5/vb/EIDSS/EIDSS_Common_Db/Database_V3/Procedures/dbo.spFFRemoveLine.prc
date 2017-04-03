set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFRemoveLine')) DROP PROCEDURE [dbo].spFFRemoveLine
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveLine
(
	@idfDecorElement Bigint
)
AS
BEGIN
	Set Nocount On;	
	
	-- удаляем зависимые объекты
	Delete from dbo.[ffDecorElementLine] Where [idfDecorElement] = @idfDecorElement
		
	--	
	Delete from dbo.[ffDecorElement]	Where [idfDecorElement] = @idfDecorElement
		
END