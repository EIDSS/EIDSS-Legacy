set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetParameters]')) DROP PROCEDURE [dbo].[spFFGetParameters]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 14.09.09
-- Description:	Return list of Parameters
-- =============================================
CREATE PROCEDURE dbo.spFFGetParameters 
(
	@LangID Nvarchar(50) = Null
	,@idfsSection Bigint = Null
	,@idfsFormType Bigint = Null
)	
AS
BEGIN	
	SET NOCOUNT ON;

	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);	

    Select 
		P.[idfsParameter]
      ,P.[idfsSection]
      ,P.[idfsFormType]
      ,FPRO.[intScheme]
      ,P.[idfsParameterType]
      ,Isnull(FR1.[Name],FR1.[strDefault]) As [ParameterTypeName]     
      ,P.[idfsEditor] --,P.[intControlType]
      ,P.[idfsParameterCaption]
      ,P.[intOrder]
      ,P.[strNote]
      ,Isnull(P.[intHACode], -1) As [intHACode]
      ,FPRO.[intLabelSize]
      ,FPRO.[intTop]
      ,FPRO.[intLeft]
      ,FPRO.[intWidth]
      ,FPRO.[intHeight]
      ,FPRO.[idfsFormTemplate]     
      ,P.[intRowStatus]
      ,B2.[strDefault] as [DefaultName]
      ,B1.[strDefault] as [DefaultLongName]
      ,IsNull(SNT2.[strTextString], B2.[strDefault]) AS [NationalName]
	  ,IsNull(SNT1.[strTextString], B1.[strDefault]) AS [NationalLongName]
	  ,@LangID As [langid]
  From [dbo].[ffParameter] P
  Inner Join dbo.trtBaseReference B1  On B1.[idfsBaseReference] = P.[idfsParameter] And B1.[intRowStatus] = 0
  Inner Join dbo.ffParameterDesignOption FPRO On P.[idfsParameter] = FPRO.[idfsParameter] And FPRO.idfsLanguage = dbo.fnFFGetDesignLanguageForParameter(@LangID, P.[idfsParameter], null) And FPRO.[intRowStatus] = 0
  Left Join dbo.trtBaseReference B2  On B2.[idfsBaseReference] = P.[idfsParameterCaption] And B2.[intRowStatus] = 0
  Left Join dbo.fnReference(@LangID, 19000071 /*'rftParameterType'*/) FR1 On FR1.[idfsReference] = P.[idfsParameterType]
  Left Join dbo.trtStringNameTranslation SNT1 On (SNT1.[idfsBaseReference] = P.[idfsParameter] AND SNT1.[idfsLanguage] = @LangID_int) And SNT1.[intRowStatus] = 0
  Left Join dbo.trtStringNameTranslation SNT2 On (SNT2.[idfsBaseReference] = P.[idfsParameterCaption] AND SNT2.[idfsLanguage] = @LangID_int) And SNT2.[intRowStatus] = 0
  WHERE
	(P.idfsSection = @idfsSection OR @idfsSection Is Null)
	and	(P.idfsFormType = @idfsFormType OR @idfsFormType Is Null)
	 --выводим только дефолтное отображение параметра
	And (FPRO.idfsFormTemplate Is Null)	
	And (P.intRowStatus = 0)
    ORDER By [NationalName], P.[intOrder]
End
Go
