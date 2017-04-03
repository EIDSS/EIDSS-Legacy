set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetLines]')) DROP PROCEDURE [dbo].[spFFGetLines]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFGetLines
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
		,DE.[idfsDecorElementType]
		,@LangID As [langid]
		,DE.[idfsFormTemplate]
		,DE.[idfsSection]
		,DEL.[intLeft]
		,DEL.[intTop]
		,DEL.[intWidth]
		,DEL.[intHeight]		
		,DEL.[intColor]
		,DEL.[blnOrientation]
	From [dbo].[ffDecorElement] DE   
	Inner Join [dbo].[ffDecorElementLine] DEL ON DE.[idfDecorElement] = DEL.[idfDecorElement]  And DEL.[intRowStatus] = 0
    Where
	(DE.[idfsFormTemplate] = @idfsFormTemplate  Or @idfsFormTemplate Is null)
	And
	(DE.[idfsLanguage] = @LangID_int Or @LangID_int Is Null)
	 And DE.[intRowStatus] = 0
End
Go