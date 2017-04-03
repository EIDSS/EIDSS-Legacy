set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFRemoveActivityParameters')) DROP PROCEDURE [dbo].spFFRemoveActivityParameters
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFRemoveActivityParameters
(
	@idfsParameter Bigint
	,@idfObservation Bigint
    ,@idfRow Bigint
)
AS
BEGIN
	Set Nocount On;
	Set Xact_abort On;
	
	Delete from dbo.tlbActivityParameters
				Where [idfsParameter] = @idfsParameter And [idfObservation] = @idfObservation And [idfRow] = @idfRow
End
Go