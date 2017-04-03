set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetParameterTemplate]')) DROP PROCEDURE [dbo].[spFFGetParameterTemplate]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 14.09.09
-- Description
-- =============================================
CREATE PROCEDURE dbo.spFFGetParameterTemplate
(	
	@idfsParameter Bigint = Null
	,@idfsFormTemplate Bigint = Null
	,@LangID  Nvarchar(50) = Null
)	
AS
BEGIN	
	Set Nocount On;
	
	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);	
	
	Select 
		PT.[idfsParameter]
      ,P.[idfsSection]
      ,P.[idfsFormType]
      ,P.[intHACode]
      ,PT.[idfsFormTemplate]
      ,PT.[idfsEditMode]
      ,P.[idfsEditor]
      ,P.[idfsParameterType]
      ,PDO.[intLeft]
      ,PDO.[intTop]
      ,PDO.[intWidth]
      ,PDO.[intHeight]
      ,PDO.[intScheme]
      ,PDO.[intLabelSize]
      ,PDO.[intOrder]
      ,B.[strDefault] AS [DefaultName]      
	  ,IsNull(SNT.[strTextString], B.[strDefault]) AS [NationalName]
	  ,@LangID As [langid]
	  ,IsNull(PT.blnFreeze,0) As [blnFreeze]
	  -- относится ли полученная структура действительно к запрошенному языку или получена по умолчанию
	  ,Cast(Case When dbo.fnFFGetDesignLanguageForParameter(@LangID, PT.[idfsParameter], @idfsFormTemplate) = @LangID_int Then 1 Else 0 End As Bit) As [blnIsRealStruct] 
  From [dbo].[ffParameterForTemplate] PT
  Inner Join dbo.ffParameterDesignOption PDO On PT.idfsParameter = PDO.idfsParameter And PT.idfsFormTemplate = PDO.idfsFormTemplate And PDO.idfsLanguage = dbo.fnFFGetDesignLanguageForParameter(@LangID, PT.[idfsParameter], @idfsFormTemplate)  And PDO.[intRowStatus] = 0
  Inner Join dbo.ffParameter P On PT.idfsParameter = P.idfsParameter And P.[intRowStatus] = 0
  Inner Join dbo.trtBaseReference B  ON B.[idfsBaseReference] = P.idfsParameter And B.[intRowStatus] = 0
  Left Join dbo.trtStringNameTranslation SNT On SNT.[idfsBaseReference] = P.idfsParameterCaption And SNT.idfsLanguage = @LangID_int And SNT.[intRowStatus] = 0
  Where	
	((PT.[idfsFormTemplate] = @idfsFormTemplate ) OR (@idfsFormTemplate Is Null))
	And	
	((PT.[idfsParameter] = @idfsParameter OR @idfsParameter Is Null))
	And
	(PT.intRowStatus = 0)	

	ORDER BY [NationalName]

End
Go