set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetParametersSearch]')) DROP PROCEDURE [dbo].[spFFGetParametersSearch]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 14.09.09
-- Description:	Return list of Parameters
-- =============================================
CREATE PROCEDURE dbo.spFFGetParametersSearch 
(
	@LangID Nvarchar(50) = Null
	,@strSearch Nvarchar(200) = Null -- строка для поиска
)	
AS
BEGIN	
	SET NOCOUNT ON;

	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);
	
	-- Таблица, куда мы поместим найденные параметры
	Declare @FindedParametersTable As Table
	(
		[idfsParameter] Bigint Not Null
		  ,[idfsSection] Bigint Null
		  ,[idfsFFormType] Bigint Not Null   
		  ,[DefaultName] Nvarchar(400) Null
		  ,[DefaultLongName] Nvarchar(400) Null
		  ,[NationalName] Nvarchar(600) Null
		  ,[NationalLongName] Nvarchar(600) Null
		  ,[FullPathStr] Nvarchar(Max) Null
		  ,[FullPathIdfs] Nvarchar(Max) Null
	)
	
	-- сформируем критерий поиска
	Declare @searchCriteria Nvarchar(100);
	Set @searchCriteria = '%' + @strSearch + '%';	
	
	Insert into @FindedParametersTable
	(
		idfsParameter
		,idfsSection
		,idfsFFormType
		,DefaultName
		,DefaultLongName	
		,NationalName
		,NationalLongName
	)
	Select
		P.[idfsParameter]
      ,P.[idfsSection]
      ,P.[idfsFormType]   
      ,B1.[strDefault] as [DefaultName]
      ,B2.[strDefault] as [DefaultLongName]
      ,IsNull(SNT1.[strTextString], B1.[strDefault]) AS [NationalName]
	  ,IsNull(SNT2.[strTextString], B2.[strDefault]) AS [NationalLongName]	 
  From [dbo].[ffParameter] P
  Inner Join dbo.trtBaseReference B1  On B1.[idfsBaseReference] = P.[idfsParameter] And B1.[intRowStatus] = 0
  Left Join dbo.trtBaseReference B2  On B2.[idfsBaseReference] = P.[idfsParameterCaption] And B2.[intRowStatus] = 0
  Left Join dbo.trtStringNameTranslation SNT1 On SNT1.[idfsBaseReference] = P.[idfsParameter] AND SNT1.[idfsLanguage] = @LangID_int And SNT1.[intRowStatus] = 0
  Left Join dbo.trtStringNameTranslation SNT2 On SNT2.[idfsBaseReference] = P.[idfsParameterCaption] AND SNT2.[idfsLanguage] = @LangID_int And SNT2.[intRowStatus] = 0
  WHERE
	(
		(P.intRowStatus = 0)
		And
		(
			B1.[strDefault] Like @searchCriteria
			Or B2.[strDefault] Like @searchCriteria
			Or SNT1.[strTextString] Like @searchCriteria
			Or SNT2.[strTextString] Like @searchCriteria
			Or Cast(P.[idfsParameter] As Nvarchar(30)) Like @searchCriteria
			Or (@strSearch Is Null)			
		)
	)	
    ORDER BY [DefaultName]
    
    -- формируем полные пути к параметрам
   Declare @fullPathStr Nvarchar(Max), @fullPathIdfs Nvarchar(Max)
   Select @fullPathStr = '', @fullPathIdfs = '';
   
   -- если у параметра есть секция, то для каждого нужно раскрыть полный путь до типа формы
   Declare @idfsParameter Varchar(36), @idfsSection Varchar(36), @idfsParentSection Varchar(36)
   Declare cursParams Cursor For 
		Select FPT.idfsParameter, FPT.idfsSection
		  From @FindedParametersTable FPT			
		Where FPT.idfsSection Is Not Null
   Open cursParams;
		Fetch Next From cursParams Into @idfsParameter, @idfsSection
		While (@@FETCH_STATUS = 0) BEGIN
		         Update @FindedParametersTable
		         SET		         	
		         	FullPathStr = SS.[FullPathStr]
		         	,FullPathIdfs = SS.[FullPathIdfs]                  	
		         From dbo.fnFFGetFullPathBySections(@LangID, @idfsSection) SS
		         Where [idfsParameter] = @idfsParameter;
		                           
		         Fetch Next From cursParams Into @idfsParameter, @idfsSection                  	
		 End
   Close cursParams;
   Deallocate cursParams;
   
    -- всем проставим тип формы (он идёт самым первым в строке пути)
    Update @FindedParametersTable
    SET    	
    	FullPathStr = Isnull(RF.[Name], RF.strDefault) + Isnull(' > ' + FPT.FullPathStr, '') + ' > ' + Isnull(FPT.NationalName, FPT.DefaultName)
    	,FullPathIDfs = Cast(idfsFFormType As Varchar(20)) + Isnull(';' + FPT.FullPathIdfs, '') + ';' + Cast(FPT.idfsParameter As Varchar(20))
    From @FindedParametersTable FPT
    Inner Join dbo.fnReference(@LangID,  19000034/*'rftFFType'*/) RF   
    ON FPT.idfsFFormType = RF.idfsReference   
    
    -- выводим результаты
    Select
			idfsParameter
			,idfsSection
			,idfsFFormType
			,DefaultName
			,DefaultLongName
			,NationalName
			, NationalLongName
			,FullPathStr
			,FullPathIDfs
      From @FindedParametersTable
	  Order By [FullPathStr] Asc
End
Go
