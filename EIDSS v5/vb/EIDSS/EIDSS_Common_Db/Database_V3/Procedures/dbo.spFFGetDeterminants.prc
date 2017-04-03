set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetDeterminants]')) DROP PROCEDURE [dbo].[spFFGetDeterminants]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
CREATE PROCEDURE dbo.spFFGetDeterminants 
(
	@LangID Nvarchar(50) = Null
)	
AS
BEGIN	
	Set Nocount On;

	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);
	
	Declare @table As Table 
	(
		[idfsBaseReference] Bigint
		,[idfsReferenceType] Bigint
		,[DefaultName] Nvarchar(200)
		,[NationalName] Nvarchar(400)
		,[DefaultTypeName] Nvarchar(200)
		,[NationalTypeName] Nvarchar(400)	
	)
	
	-- Страны, диагнозы, тесты
	Insert into @table
	(	
		[idfsBaseReference]
		,[idfsReferenceType]
		,[DefaultName]
		,[NationalName]
	)	
	Select GBR.[idfsGISBaseReference]
			   ,GBR.[idfsGISReferenceType]
			   ,GBR.[strDefault]
			   ,Isnull(GSNT.strTextString, GBR.[strDefault])
		From dbo.gisBaseReference GBR
		Left Join dbo.gisStringNameTranslation GSNT On GBR.idfsGISBaseReference = GSNT.idfsGISBaseReference And GSNT.idfsLanguage = @LangID_int And GSNT.[intRowStatus] = 0
		Where GBR.idfsGISReferenceType = 19000001 -- Country
					 And GBR.[intRowStatus] = 0
	
	Insert into @table
	(	
		[idfsBaseReference]
		,[idfsReferenceType]
		,[DefaultName]
		,[NationalName]
	)	
	Select BR.[idfsBaseReference]
			   ,BR.[idfsReferenceType]
			   ,BR.[strDefault]
			   ,Isnull(SNT.strTextString, BR.[strDefault])
		From dbo.trtBaseReference BR 
		Left Join dbo.trtStringNameTranslation SNT On BR.idfsBaseReference = SNT.idfsBaseReference And SNT.idfsLanguage = @LangID_int And SNT.[intRowStatus] = 0
		Where BR.idfsReferenceType = 19000019 -- Diagnosis
					 And BR.[intRowStatus] = 0
		
   Insert into @table
	(	
		[idfsBaseReference]
		,[idfsReferenceType]
		,[DefaultName]
		,[NationalName]
	)	
	Select BR.[idfsBaseReference]
			   ,BR.[idfsReferenceType]
			   ,BR.[strDefault]
			   ,Isnull(SNT.strTextString, BR.[strDefault])
		From dbo.trtBaseReference BR 
		Left Join dbo.trtStringNameTranslation SNT On BR.idfsBaseReference = SNT.idfsBaseReference And SNT.idfsLanguage = @LangID_int And SNT.[intRowStatus] = 0
		Where BR.idfsReferenceType = 19000097 -- Tests
					 And BR.[intRowStatus] = 0
	
   Declare @DefaultTypeName Nvarchar(200), @NationalTypeName Nvarchar(400)
   
   -- заполняем заголовки типа
   -- Country
   Select  @DefaultTypeName = strGISReferenceTypeName From dbo.gisReferenceType Where idfsGISReferenceType = 19000001 And [intRowStatus] = 0 
   -- тут различается id не 19000001, а 10003001
   Select  @NationalTypeName = strTextString From dbo.trtStringNameTranslation Where idfsBaseReference = 10003001 And idfsLanguage = @LangID_int And [intRowStatus] = 0
   Update @table
   Set  
   		DefaultTypeName = @DefaultTypeName
   		,NationalTypeName = Isnull(@NationalTypeName, @DefaultTypeName)
   Where 
		[idfsReferenceType] = 19000001
   --------------------------------------------
   Select  @DefaultTypeName = strReferenceTypeName From dbo.trtReferenceType Where idfsReferenceType = 19000097 And [intRowStatus] = 0 
   Select  @NationalTypeName = strTextString From dbo.trtStringNameTranslation Where idfsBaseReference = 19000097 And idfsLanguage = @LangID_int And [intRowStatus] = 0
   Update @table
   Set  
   		DefaultTypeName = @DefaultTypeName
   		,NationalTypeName = Isnull(@NationalTypeName, @DefaultTypeName)
   Where 
		[idfsReferenceType] = 19000097
	 --------------------------------------------
   Select  @DefaultTypeName = strReferenceTypeName From dbo.trtReferenceType Where idfsReferenceType = 19000019 And [intRowStatus] = 0 
   Select  @NationalTypeName = strTextString From dbo.trtStringNameTranslation Where idfsBaseReference = 19000019 And idfsLanguage = @LangID_int And [intRowStatus] = 0
   Update @table
   Set  
   		DefaultTypeName = @DefaultTypeName
   		,NationalTypeName = Isnull(@NationalTypeName, @DefaultTypeName)
   Where 
		[idfsReferenceType] = 19000019	
   
   
   -- Показываем результаты
   Select
		[idfsBaseReference]
		,[idfsReferenceType]
		,[DefaultName]
		,[NationalName]
		,[DefaultTypeName]
		,[NationalTypeName]
   From @table
   Order By 
		[idfsReferenceType]
		,[NationalName]
		,[DefaultName]
End
Go
