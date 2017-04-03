set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetLabels]')) DROP PROCEDURE [dbo].[spFFGetLabels]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFGetLabels
(
	@LangID Nvarchar(50) = Null
	,@idfsFormTemplate Bigint = Null	 	
)	
AS
BEGIN	
	Set Nocount On;

	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);

    Select 
		DE.[idfDecorElement]
		,DEL.idfsBaseReference
		,DE.[idfsDecorElementType]
		,@LangID As [langid]
		,DE.[idfsFormTemplate]
		,DE.[idfsSection]
		,DEL.[intLeft]
		,DEL.[intTop]
		,DEL.[intWidth]
		,DEL.[intHeight]
		,DEL.[intFontStyle]
		,DEL.[intFontSize]
		,DEL.[intColor]
		,BR.strDefault As [DefaultText]
		,Isnull(SNT.strTextString, BR.strDefault) As [NationalText]
	From [dbo].[ffDecorElement] DE   
	Inner Join [dbo].[ffDecorElementText] DEL ON DE.[idfDecorElement] = DEL.[idfDecorElement]  And DEL.[intRowStatus] = 0
    Inner Join dbo.trtBaseReference BR On DEL.idfsBaseReference = BR.idfsBaseReference
    Left Join dbo.trtStringNameTranslation SNT On DEL.idfsBaseReference = SNT.idfsBaseReference And SNT.idfsLanguage = @LangID_int
    Where
	(DE.[idfsFormTemplate] = @idfsFormTemplate  Or @idfsFormTemplate Is null)
	And
	(DE.[idfsLanguage] = dbo.fnFFGetDesignLanguageForLabel(@LangID, DE.[idfDecorElement]) Or @LangID_int Is Null)
	 And DE.[intRowStatus] = 0
End
Go