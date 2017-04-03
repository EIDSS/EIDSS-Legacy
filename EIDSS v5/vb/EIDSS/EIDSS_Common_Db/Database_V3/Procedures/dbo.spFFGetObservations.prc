set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetObservations]')) Drop Procedure [dbo].[spFFGetObservations]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFGetObservations 
(
	@observationList Nvarchar(max)	
)
As
Begin
   Select idfObservation, idfsFormTemplate From dbo.tlbObservation
   Where idfObservation In (Select Cast([Value] As Bigint) From [dbo].[fnsysSplitList](@observationList, null, null))
				And intRowStatus = 0;
End
Go
