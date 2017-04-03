set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.spFFGetReferenceTypes')) DROP PROCEDURE dbo.spFFGetReferenceTypes
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 29.09.09
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFGetReferenceTypes
(
	@LangID Nvarchar(50) = Null	
)	
AS
BEGIN	
	SET NOCOUNT ON;

	If (@LangID Is Null) Set @LangID = 'en';

	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);

	Select 
			RT.idfsReferenceType
			,Br.strDefault As [DefaultName]
			,Isnull(SNT.strTextString, Br.strDefault) As [NationalName]
			,@LangID As [langid]	
	From dbo.trtReferenceType RT 
	Inner Join dbo.trtBaseReference BR On RT.idfsReferenceType = BR.idfsBaseReference
	Inner Join dbo.trtStringNameTranslation SNT On SNT.idfsBaseReference = RT.idfsReferenceType And SNT.intRowStatus = 0 And SNT.idfsLanguage = @LangID_int
	Where ((RT.intStandard & 1 > 0)  Or (BR.idfsBaseReference In (19000079, 19000074)))
				And RT.intRowStatus = 0
	Order By [NationalName]
End
Go
