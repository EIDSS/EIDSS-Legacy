set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFSectionUsed]')) DROP PROCEDURE [dbo].[spFFSectionUsed]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:	
-- =============================================
CREATE PROCEDURE dbo.spFFSectionUsed
(	
	@idfsSection Bigint	 	
)	
AS
BEGIN	
	Set Nocount On;

	Declare @result Bit
	Set @result = 0;
	
	If (Exists(Select Top 1 1 From dbo.ffSectionForTemplate Where [idfsSection] = @idfsSection And [intRowStatus] = 0)) Set @result = 1;
	
	Select @result As [idfsSection]
End
Go