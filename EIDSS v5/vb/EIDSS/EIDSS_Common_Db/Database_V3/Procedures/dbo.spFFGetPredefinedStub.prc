set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetPredefinedStub]')) DROP PROCEDURE [dbo].[spFFGetPredefinedStub]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 29.09.09
-- Description:	Return list of Parameter Editors
-- =============================================
CREATE PROCEDURE dbo.spFFGetPredefinedStub
(
	@MatrixID Bigint
	,@VersionList Varchar(600) -- перечень версий боковиков
	,@LangID Nvarchar(50) = Null	
	
	/*    
    VetCase = 71090000000
    DiagnosticAction = 71460000000
    ProphylacticAction = 71300000000
    HumanCase = 71190000000
    SanitaryAction = 71260000000
    FormN1= 82350000000 Боковик как у HumanCase
    */
)	
AS
BEGIN	
	Set Nocount On;	
	
	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);	

	Declare @idfVersion Bigint

	If (Len(@VersionList) = 0) Begin		
		Select Top 1 @idfVersion = [idfVersion] From dbo.tlbAggrMatrixVersionHeader Where [idfsAggrCaseSection] = @MatrixID And [blnIsActive]= 1 ORDER BY CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) DESC, datStartDate DESC

		Set @VersionList = Cast(@idfVersion As Varchar(600));
	End;	

	Declare @StubTable As Table 
	(	
		idfVersion Bigint	
		,idfRow Bigint
		,idfsParameter Bigint
		,strDefaultParameterName Nvarchar(400)
		,idfsParameterValue Sql_variant
		,NumRow Int
		,[strNameValue] Nvarchar(200)
		,[idfsSection] Bigint		
	)
	
	Declare @idfRow Bigint
				,@idfsParameter Bigint
				,@strDefaultParameterName Nvarchar(600)
				,@idfsParameterValue Sql_variant
				,@strNameValue Nvarchar(600)
				,@idfRowCurrent Bigint -- для счетчика строк
				,@NumRowCurrent Int -- для счетчика строк	
				,@NumRowTemp Int -- для счетчика строк	
				,@currentVersion Bigint
	
	Declare @VersionTable Table (
		[idfVersion] Bigint
	)
	
	Insert into @VersionTable
	(
		[idfVersion]
	)
	Select Cast([Value] As Bigint) From [dbo].[fnsysSplitList](@VersionList, null, null)
	
	-- если версия не задана, то определим её. Версия будет выводиться только в случае переданной извне или вычисленной одной версии.
	-- если передано несколько версий в процедуру, то наружу будет выведен null в версии, чтобы не вносить путаницы
	If (@idfVersion Is Null) Begin
		If Exists(Select Top 1 1 From @VersionTable Having Count([idfVersion]) = 1) Select Top 1 @idfVersion = [idfVersion] From @VersionTable
	End
	
	Declare curs Cursor For	
			Select
				  AMV.[idfRow]
				  ,AMV.[idfsParameter]
				  ,Isnull(R1.[Name], R1.[strDefault])
				  ,AMV.[varValue]
				  ,Isnull(SNT.[strTextString], BR1.[strDefault])
				  ,AMV.idfVersion
			From dbo.tlbAggrMatrixVersion AMV
					Inner Join dbo.fnReference(@LangID, 19000066) R1 On AMV.idfsParameter = R1.idfsReference	
					Left Join dbo.trtBaseReference BR1 On AMV.varValue = BR1.idfsBaseReference And BR1.intRowStatus = 0	
					Left Join dbo.trtStringNameTranslation SNT On SNT.idfsBaseReference = BR1.idfsBaseReference And SNT.idfsLanguage = @LangID_int And SNT.intRowStatus = 0	 					
			Where AMV.idfVersion In (Select [idfVersion] From @VersionTable) And AMV.intRowStatus = 0						 
			Order By AMV.intNumRow, AMV.idfRow, AMV.idfVersion, AMV.intColumnOrder
			
	Open curs
	Fetch Next From curs Into @idfRow,@idfsParameter,@strDefaultParameterName,@idfsParameterValue,@strNameValue, @currentVersion
	
	Set @idfRowCurrent = @idfRow;	
	While (@@FETCH_STATUS = 0) Begin
		-- одна строчка может быть добавлена в выходную матрицу только один раз.
		-- строчки идут по возможности именно в том порядке, как они размещены в своих матрицах
		
		-- попробуем найти номер по коду строки
		-- если его найти не удалось, то присвоим номер		
		Set @NumRowTemp = Null;		
		Select Distinct @NumRowTemp = [NumRow] From @StubTable Where [idfRow] = @idfRow
		If (@NumRowTemp Is Null) begin 
			--Set  @NumRowCurrent =  @NumRowCurrent + 1 
			Select  @NumRowCurrent =  Isnull(Max([NumRow]), -1) + 1 From @StubTable	-- -1, чтобы отсчёт номеров строк был с нуля		
		End else begin 
			Set  @NumRowCurrent = @NumRowTemp;
		End;
		
		If Not Exists(Select Top 1 1 From @StubTable 
								Where idfRow = @idfRow And idfsParameter = @idfsParameter) Begin
			Insert into @StubTable
			(
				idfVersion
				,idfRow
				,idfsParameter
				,strDefaultParameterName
				,idfsParameterValue
				,strNameValue
				,NumRow				
			)	
			Values
			(
				@currentVersion
				,@idfRow
				,@idfsParameter
				,@strDefaultParameterName
				,@idfsParameterValue
				,Isnull(@strNameValue, Cast(@idfsParameterValue As Nvarchar(600)))
				,@NumRowCurrent
			)			
			
		End
		
		Fetch Next From curs Into @idfRow,@idfsParameter,@strDefaultParameterName,@idfsParameterValue,@strNameValue, @currentVersion--,@intColumnOrder
		
	End
	
	Close curs
	Deallocate curs	
	
	Select
		idfVersion
		,idfRow
		,idfsParameter
		,strDefaultParameterName
		,idfsParameterValue
		,NumRow
		,[strNameValue]		
		,@MatrixID As [idfsSection]
		,@LangID As [langid]
	From @StubTable
End
Go
