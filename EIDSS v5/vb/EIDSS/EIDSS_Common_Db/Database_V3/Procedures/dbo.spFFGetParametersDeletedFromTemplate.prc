set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetParametersDeletedFromTemplate]')) DROP PROCEDURE [dbo].[spFFGetParametersDeletedFromTemplate]
GO

-- =============================================
-- Author:		Leonov E.N.
-- 
-- 
-- =============================================
CREATE PROCEDURE dbo.spFFGetParametersDeletedFromTemplate 
(	
	@idfsObservation Bigint
	,@LangID Nvarchar(50)
)	
AS
BEGIN	
	Set Nocount On;
	
	Declare @idfsFormTemplate Bigint
	Select @idfsFormTemplate = idfsFormTemplate From dbo.tlbObservation Where idfObservation = @idfsObservation
	
	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);
	
    Select distinct 
			AP.idfsParameter
			, O.idfsFormTemplate
			, AP.idfObservation
			,B2.[strDefault] as [DefaultName]
			,B1.[strDefault] as [DefaultLongName]
			,IsNull(SNT2.[strTextString], B2.[strDefault]) AS [NationalName]
			,IsNull(SNT1.[strTextString], B1.[strDefault]) AS [NationalLongName]
			, P.idfsEditor
			, PDO.intLeft
			, PDO.intTop
			, PDO.intWidth
			, PDO.intHeight
			, PDO.intLabelSize
			, PDO.intScheme
			, PDO.intOrder
			,@LangID As [langid]
    From dbo.tlbActivityParameters AP 
		Left Join dbo.ffParameterForTemplate PT On PT.idfsParameter = AP.idfsParameter And PT.idfsFormTemplate = @idfsFormTemplate And PT.intRowStatus = 0
		Inner Join dbo.tlbObservation O On AP.idfObservation = O.idfObservation And O.intRowStatus = 0
		Inner Join dbo.ffParameter P On P.idfsParameter =AP.idfsParameter And P.intRowStatus = 0
		Inner Join dbo.ffParameterDesignOption PDO On (AP.idfsParameter = PDO.idfsParameter) And (PDO.idfsFormTemplate Is Null) And (PDO.idfsLanguage = @LangID_int) And (PDO.intRowStatus = 0)
		Inner Join dbo.trtBaseReference B1  On B1.[idfsBaseReference] = P.[idfsParameter] And B1.[intRowStatus] = 0
		Left Join dbo.trtBaseReference B2  On B2.[idfsBaseReference] = P.[idfsParameterCaption] And B2.[intRowStatus] = 0
		Left Join dbo.trtStringNameTranslation SNT1 On (SNT1.[idfsBaseReference] = P.[idfsParameter] AND SNT1.[idfsLanguage] = @LangID_int) And SNT1.[intRowStatus] = 0
		Left Join dbo.trtStringNameTranslation SNT2 On (SNT2.[idfsBaseReference] = P.[idfsParameterCaption] AND SNT2.[idfsLanguage] = @LangID_int) And SNT2.[intRowStatus] = 0
   
	Where AP.intRowStatus = 0 
					And PT.idfsParameter Is Null
					And (AP.idfObservation = @idfsObservation)
End
Go
