set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spFFGetParameterFixedPresetValue')) DROP PROCEDURE dbo.spFFGetParameterFixedPresetValue
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFGetParameterFixedPresetValue
(	
	@idfsParameterType Bigint = Null
	,@LangID Nvarchar(50) = Null
)	
AS
BEGIN	
	SET NOCOUNT ON;

	If (@LangID Is Null) Set @LangID = 'en';	
	
	Select 
			FPV.idfsParameterFixedPresetValue 
			,FPV.idfsParameterType
			,FR.strDefault As [DefaultName]
			,Isnull(FR.LongName, FR.strDefault) As [NationalName]
			,@LangID As [langid]
			,FR.intOrder
	From dbo.ffParameterFixedPresetValue FPV
	Inner Join dbo.fnReference(@LangID, 19000069 /*'rftParametersFixedPresetValue'*/) FR On FPV.idfsParameterFixedPresetValue = FR.idfsReference
	Where (FPV.idfsParameterType = @idfsParameterType Or @idfsParameterType Is Null) And FPV.intRowStatus = 0
	Order By [intOrder],[NationalName]
End
Go
