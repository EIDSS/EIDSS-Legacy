set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetSections]')) DROP PROCEDURE [dbo].[spFFGetSections]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 14.09.09
-- Description:	Return list of Sections
-- =============================================
CREATE PROCEDURE dbo.spFFGetSections
(
	@LangID Nvarchar(50) = null 
	,@idfsFormType Bigint = NULL
	,@idfsSection Bigint = NULL
	,@idfsParentSection Bigint = NULL		
)	
AS
BEGIN	
	Set Nocount On;
	
	If (@LangID Is Null) Set @LangID = 'en';
	
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);
	
	Select 
		S.[idfsSection]
      ,S.[idfsParentSection]
      ,S.[idfsFormType]     
      ,S.[rowguid]
      ,S.[intRowStatus]
      ,B.[strDefault] As [DefaultName]	
	  ,IsNull(SNT.[strTextString], B.[strDefault]) As [NationalName]	 
	  ,Case When Count(P.[idfsParameter]) > 0 Then 1 Else 0 End As [HasParameters]
	  ,Case When Count(S2.[idfsSection]) > 0  Then 1 Else 0 End As [HasNestedSections]	
	  ,S.blnGrid
	  ,S.blnFixedRowset
	  ,S.intOrder
	  ,@LangID As [langid]
  FROM [dbo].[ffSection] S
  Inner Join dbo.trtBaseReference B  ON B.[idfsBaseReference] = S.[idfsSection] And B.[intRowStatus] = 0  
  Left Join dbo.ffParameter P ON P.idfsSection = S.[idfsSection] And P.[intRowStatus] = 0
  Left Join dbo.ffSection S2 ON S.[idfsSection] = S2.[idfsParentSection]  And S2.[intRowStatus] = 0
  Left Join dbo.trtStringNameTranslation SNT ON SNT.[idfsBaseReference] = S.[idfsSection] And SNT.idfsLanguage = @LangID_int And SNT.[intRowStatus] = 0
  WHERE
	((S.idfsFormType = @idfsFormType ) Or (@idfsFormType Is Null))
	and	
	((S.idfsSection = @idfsSection) Or (@idfsSection Is Null))
	and	
	((S.idfsParentSection = @idfsParentSection) Or (@idfsParentSection Is Null))
	 And S.[intRowStatus] = 0
	GROUP BY 
		S.[idfsSection]
      ,S.[idfsParentSection]
      ,S.[idfsFormType]     
      ,S.[rowguid]
      ,S.[intRowStatus]
      ,B.[strDefault]
	  ,SNT.[strTextString]	  
	  ,S.blnGrid
	  ,S.blnFixedRowset
	  ,S.intOrder	 
	ORDER BY [NationalName], S.[intOrder]

End
Go