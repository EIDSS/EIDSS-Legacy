set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetRuleFunctions]')) DROP PROCEDURE [dbo].[spFFGetRuleFunctions]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFGetRuleFunctions 
(	
	@count Int = Null
	,@LangID  Nvarchar(50) = Null
)	
AS
BEGIN	
	Set Nocount On;	
	
	If (@count = -1) Set @count = Null;
	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);
	
	Select 
		[idfsRuleFunction]	
		,[strMask]
		,SNT.strTextString As [strMaskNational]
		,[intNumberOfParameters]
	From dbo.ffRuleFunction RF
	Inner Join dbo.trtStringNameTranslation SNT On RF.idfsRuleFunction = SNT.idfsBaseReference And SNT.idfsLanguage = @LangID_int
	Where ([intNumberOfParameters] = @count Or @count Is Null)
				And RF.[intRowStatus] = 0
				And SNT.[intRowStatus] = 0
   
End
Go
