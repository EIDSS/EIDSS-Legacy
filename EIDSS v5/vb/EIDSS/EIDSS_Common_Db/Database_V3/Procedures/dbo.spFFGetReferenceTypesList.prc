set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spFFGetReferenceTypesList')) DROP PROCEDURE dbo.spFFGetReferenceTypesList
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 29.09.09
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFGetReferenceTypesList
(
	@LangID Nvarchar(50) = Null
	,@idfsReferenceType Bigint
)	
AS
BEGIN	
	SET NOCOUNT ON;

	If (@LangID Is Null) Set @LangID = 'en';

	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);

	Select 
			BR.idfsBaseReference
			,BR.idfsReferenceType
			,Br.strDefault As [DefaultName]
			,Isnull(SNT.strTextString, Br.strDefault) As [NationalName]		
			,@LangID As [langid]	
	From dbo.trtBaseReference BR
	Inner Join dbo.trtStringNameTranslation SNT On SNT.idfsBaseReference = BR.idfsBaseReference And SNT.intRowStatus = 0 And SNT.idfsLanguage = @LangID_int
	Where BR.idfsReferenceType = @idfsReferenceType And BR.intRowStatus = 0
	Order By [NationalName]
End
Go
