set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetActualTemplate]')) Drop Procedure [dbo].[spFFGetActualTemplate]
GO


/*
exec dbo.spFFGetActualTemplate 2340000000, 41530000000, 10034019
exec dbo.spFFGetActualTemplate 780000000, 500000000, 10034010
exec dbo.spFFGetActualTemplate 780000000, 0, 10034010
exec dbo.spFFGetActualTemplate 170000000, 0, 10034010

*/
-- =============================================
-- Author:		Leonov E.N.
-- Create date:
-- Description:
-- =============================================
Create Procedure dbo.spFFGetActualTemplate 
(
	@idfsGISBaseReference Bigint = Null
	,@idfsBaseReference Bigint = Null
	,@idfsFormType Bigint
	,@idfsFormTemplateActual Bigint = Null Out
)
As
BEGIN
  DECLARE @idfsFormTemplate BIGINT
  DECLARE @IsUNITemplate BIT   
  SET @IsUNITemplate = 0

	SELECT @idfsFormTemplate = COALESCE(fft1.[idfsFormTemplate], fft2.[idfsFormTemplate], fft3.[idfsFormTemplate], 
										fft4.[idfsFormTemplate], fft5.[idfsFormTemplate])
	FROM [ffFormTemplate] AS fft1
		INNER JOIN [ffDeterminantValue] AS dv11 
			ON fft1.[idfsFormTemplate] = dv11.[idfsFormTemplate] AND dv11.[idfsBaseReference] = @idfsBaseReference And dv11.intRowStatus = 0
		INNER JOIN [ffDeterminantValue] AS dv12	
			ON fft1.[idfsFormTemplate] = dv12.[idfsFormTemplate] AND dv12.[idfsGISBaseReference] = @idfsGISBaseReference And dv12.intRowStatus = 0
		AND (fft1.[idfsFormType] = @idfsFormType)	 And fft1.intRowStatus = 0
	FULL JOIN (
		SELECT fft2.[idfsFormTemplate] FROM [ffFormTemplate] AS fft2
		LEFT JOIN [ffDeterminantValue] AS dv21 
			ON fft2.[idfsFormTemplate] = dv21.[idfsFormTemplate] AND dv21.[idfsBaseReference] IS NOT NULL  And dv21.intRowStatus = 0
		INNER JOIN [ffDeterminantValue] AS dv22 
			ON fft2.[idfsFormTemplate] = dv22.[idfsFormTemplate] AND dv22.[idfsGISBaseReference] = @idfsGISBaseReference And dv22.intRowStatus = 0
		WHERE  (fft2.[idfsFormType] = @idfsFormType AND dv21.[idfDeterminantValue] IS NULL) And fft2.intRowStatus = 0
		) AS fft2
		ON 1=1
	FULL JOIN (
		SELECT fft3.[idfsFormTemplate] FROM [ffFormTemplate] AS fft3
		LEFT JOIN [ffDeterminantValue] AS dv32 
			ON fft3.[idfsFormTemplate] = dv32.[idfsFormTemplate] AND dv32.[idfsGISBaseReference] IS NOT NULL And dv32.intRowStatus = 0 
		INNER JOIN [ffDeterminantValue] AS dv31 
			ON fft3.[idfsFormTemplate] = dv31.[idfsFormTemplate] AND dv31.[idfsBaseReference] = @idfsBaseReference  And dv31.intRowStatus = 0
		WHERE (fft3.[idfsFormType] = @idfsFormType AND dv32.[idfDeterminantValue] IS NULL) And fft3.intRowStatus = 0
		) AS fft3
		ON 1=1
	FULL JOIN (
		SELECT fft4.[idfsFormTemplate] FROM [ffFormTemplate] AS fft4
		INNER JOIN [ffDeterminantValue] AS dv42 
			ON fft4.[idfsFormTemplate] = dv42.[idfsFormTemplate] AND dv42.[idfsGISBaseReference] = @idfsGISBaseReference And dv42.intRowStatus = 0
		WHERE  fft4.[blnUNI] = 1 AND fft4.[idfsFormType] = @idfsFormType And fft4.intRowStatus = 0
		) AS fft4
		ON 1=1
	FULL JOIN (
		SELECT fft5.[idfsFormTemplate] FROM [ffFormTemplate] AS fft5
		LEFT JOIN [ffDeterminantValue] AS dv52 
			ON fft5.[idfsFormTemplate] = dv52.[idfsFormTemplate] AND dv52.[idfsGISBaseReference] IS NOT NULL  And dv52.intRowStatus = 0
		WHERE fft5.[blnUNI] = 1 AND fft5.[idfsFormType] = @idfsFormType AND dv52.[idfDeterminantValue] IS NULL  And fft5.intRowStatus = 0
		) AS fft5
		ON 1=1

	SELECT @IsUNITemplate = [blnUNI]
	FROM [ffFormTemplate] 
	WHERE [idfsFormTemplate] = @idfsFormTemplate
		

 -- если никакой не удалось найти, то поставим -1, чтобы не было пустой строки
 IF (@idfsFormTemplate IS NULL) SET @idfsFormTemplate = -1;
 Set @idfsFormTemplateActual = @idfsFormTemplate;

 SELECT 
   @idfsFormTemplate AS [idfsFormTemplate]
   ,@IsUNITemplate AS [IsUNITemplate]   
			
END
GO
