set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetRules]')) DROP PROCEDURE [dbo].[spFFGetRules]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFGetRules 
(
	@LangID Nvarchar(50) = NULL	
	,@idfsFormTemplate Bigint = NULL
)	
AS
BEGIN	
	Set Nocount On;

	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);
	
	SELECT 
		[idfsRule]
		,[idfsFormTemplate]
		,[idfsRuleMessage]
		,R.[idfsRuleFunction] As [idfsRuleFunction]
		,RF.intNumberOfParameters
		,[idfsCheckPoint]
		,Case When [idfsCheckPoint] = 10028001 Then 'onload'
				When [idfsCheckPoint] = 10028002 Then 'onsave'
				When [idfsCheckPoint] = 10028003 Then 'onvaluechanged'
		End As [idfsCheckPointDescr]
		,Null As [intRowStatus]
		,R.[rowguid]
		,B1.[strDefault] as [DefaultName]
		,IsNull(SNT1.[strTextString], B1.[strDefault]) AS [NationalName]
		,B2.[strDefault] as [MessageText]		
		,IsNull(SNT2.[strTextString], B2.[strDefault]) AS [MessageNationalText]
		,@LangID As [langid]
		,[blnNot]
  From [dbo].[ffRule] R
  Inner Join dbo.trtBaseReference B1  On B1.[idfsBaseReference] = R.[idfsRule] And B1.[intRowStatus] = 0
  Inner Join dbo.ffRuleFunction RF On R.idfsRuleFunction = RF.idfsRuleFunction And RF.[intRowStatus] = 0
  Left Join dbo.trtBaseReference B2  On B2.[idfsBaseReference] = R.[idfsRuleMessage] And B2.[intRowStatus] = 0
  Left Join dbo.trtStringNameTranslation SNT1 On SNT1.[idfsBaseReference] = R.[idfsRule]  AND SNT1.[idfsLanguage] = @LangID_int And SNT1.[intRowStatus] = 0
  Left Join dbo.trtStringNameTranslation SNT2 On SNT2.[idfsBaseReference] = R.[idfsRuleMessage] AND SNT2.[idfsLanguage] = @LangID_int And SNT2.[intRowStatus] = 0
  WHERE
	(R.[idfsFormTemplate] = @idfsFormTemplate Or @idfsFormTemplate Is Null)
	 And R.[intRowStatus] = 0
   
End
Go
