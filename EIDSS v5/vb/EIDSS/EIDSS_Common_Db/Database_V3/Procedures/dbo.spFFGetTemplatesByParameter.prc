set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetTemplatesByParameter]')) DROP PROCEDURE [dbo].[spFFGetTemplatesByParameter]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 30.09.09
-- Description:	Return list of Templates where Parameter used
-- =============================================
CREATE PROCEDURE dbo.[spFFGetTemplatesByParameter] 
(
	@LangID Nvarchar(50) = Null
	,@idfsParameter Bigint
)	
AS
BEGIN	
	SET NOCOUNT ON;

	If (@LangID Is Null) Set @LangID = 'en';

    SELECT 
		FT.[idfsFormTemplate]
      ,FT.[idfsFormType]   
      ,FT.[blnUNI]   
      ,FT.[rowguid]
      ,FT.[intRowStatus]
      ,FT.strNote
      ,RF.[strDefault] As [DefaultName]
      ,RF.[Name] As [NationalName]
      ,RF.[LongName] As [NationalLongName]
      ,PT.idfsEditMode
  FROM [dbo].[ffFormTemplate] FT
		Inner Join dbo.fnReference(@LangID, 19000033 /*'rftFFTemplate'*/) RF On FT.[idfsFormTemplate] = RF.idfsReference
		Inner Join dbo.ffParameterforTemplate PT On FT.[idfsFormTemplate] = PT.[idfsFormTemplate]		
    Where
	(PT.[idfsParameter] = @idfsParameter)
	And
	(PT.intRowStatus = 0)
	And
	(FT.intRowStatus = 0)
	  
	Order by [NationalName]
   
End
Go
