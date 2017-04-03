set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetDeterminantTypes]')) DROP PROCEDURE [dbo].[spFFGetDeterminantTypes]
GO

-- =============================================
-- Author:		Leonov E.N.
-- =============================================
CREATE PROCEDURE dbo.spFFGetDeterminantTypes
(
	@idfsFormType Bigint = Null
	,@LangID Nvarchar(50) = Null
)	
AS
BEGIN	
	Set Nocount On;

	If (@LangID Is Null) Set @LangID = 'en';
	
	Select [idfDeterminantType]
			  ,[idfsReferenceType]
			  ,[idfsGISReferenceType]
			  ,[idfsFormType]
			  ,[intOrder]
			  ,[intRowStatus]			  
	From [dbo].[ffDeterminantType]	
	Where 
	(([idfsFormType] = @idfsFormType) Or (@idfsFormType Is Null))
	and [intRowStatus] = 0   

End

Go