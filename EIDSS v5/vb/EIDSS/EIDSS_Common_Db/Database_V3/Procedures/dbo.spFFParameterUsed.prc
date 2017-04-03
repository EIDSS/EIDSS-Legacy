set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFParameterUsed]')) DROP PROCEDURE [dbo].[spFFParameterUsed]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:	
-- =============================================
CREATE PROCEDURE dbo.spFFParameterUsed
(	
	@idfsParameter Bigint	 	
)	
AS
BEGIN	
	Set Nocount On;

	Declare @result Bit
	Set @result = 0;
	
	If (Exists(Select Top 1 1 From dbo.ffParameterForTemplate Where [idfsParameter] = @idfsParameter And [intRowStatus] = 0)) Set @result = 1;
	
	Select @result As [idfsParameter]
End
Go