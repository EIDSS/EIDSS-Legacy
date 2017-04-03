set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetActivityParameters]')) DROP PROCEDURE [dbo].[spFFGetActivityParameters]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE dbo.spFFGetActivityParameters
(	
	@observationList Nvarchar(max)		
	,@LangID Nvarchar(50) = Null	
)	
AS
BEGIN	
	Set Nocount On;
	
	Declare @ResultTable Table (
		[idfObservation] Bigint
		,[idfsFormTemplate] Bigint
		,[idfsParameter] Bigint
		,[idfRow] Bigint
		,[intNumRow] Int
		,[Type] Bigint -- 0 - простой параметр в обычной секции или без неЄ
							-- 1 - параметр в табличной секции, т.с. без боковика. “акже может быть таблична€ секци€ в другой табличной секции с боковиком
							-- id section -- параметр находитс€ в табличной секции, котора€ имеет боковик. —юда помещаетс€ idsection, где находитс€ параметр
		,[varValue]	Sql_variant
		,[strNameValue] Nvarchar(200)
		,[numRow] Int
	)	
	
	If (@LangID Is Null) Set @LangID = 'en';
	Declare @LangID_int Bigint
	Set @LangID_int = dbo.fnGetLanguageCode(@LangID);
	
	Declare @observationsTable Table
	(
		[idfObservation] Bigint
		,[idfVersion] Bigint
		,[intRowNumber] Int
	)
	
	Insert into @observationsTable([idfObservation], [intRowNumber])
	Select Cast([Value] As Bigint), Row_number() Over (Order By [Value]) 
		From [dbo].[fnsysSplitList](@observationList, null, null)
		
	Insert into @ResultTable
	(
		idfObservation
		,idfsFormTemplate
		,idfsParameter
		,idfRow
		,varValue
		,[Type]
		,[numRow]
	)	
	Select
		AP.idfObservation
		,O.idfsFormTemplate
		,AP.idfsParameter
		,AP.idfRow
		,AP.varValue
		,dbo.fnFFGetTypeActivityParameters(AP.	idfsParameter)
		,Row_number() Over (Partition By AP.[idfObservation] Order By AP.[idfRow])
	 From dbo.tlbActivityParameters AP
		Inner Join dbo.tlbObservation O On AP.idfObservation = O.idfObservation
		Where AP.idfObservation In
		(Select [idfObservation] From @observationsTable)
		 And AP.[intRowStatus] = 0 And O.[intRowStatus] = 0
	Order By AP.[idfObservation], AP.idfRow
	
	Declare @MatrixInfo As Table 
	(
		[idfVersion] Bigint
		,[idfsAggrCaseType] Bigint
		,[idfAggregateCaseSection] Bigint
	)
	
	Declare @matrixTable As Table 
	(
		idfVersion Bigint
		,idfRow Bigint
		,idfsParameter Bigint
		,strDefaultParameterName Nvarchar(400)
		,idfsParameterValue Sql_variant
		,NumRow Int
		,[strNameValue] Nvarchar(200)
		,[idfsSection] Bigint
		,[langid] Nvarchar(20)	
	)
	
	Declare @rowCount Int, @currentRow Int, @currentObservation Bigint, @idfVersion Bigint
	,@NumRow Int, @IdfRow Bigint, @CurrentIdfRow Bigint, @Type Bigint
	,@innerCurrentRow Int, @innerRowCount Int
	
	Select @rowCount = Max([intRowNumber]) From @observationsTable
	
	Set @currentRow = 1;	
	While(@currentRow <= @rowCount) Begin
			Select @currentObservation = [idfObservation] From @observationsTable Where intRowNumber = @currentRow;
			Delete from @MatrixInfo
			Insert into @MatrixInfo Exec dbo.spAggregateObservation_GetMatrixVersion @currentObservation
			Select Top 1 @idfVersion = [idfVersion] From @MatrixInfo
			-- если не удалось определить версию, то возьмЄм по умолчанию
			If (@idfVersion Is Null) Begin
				Select Top 1 @idfVersion = [idfVersion] From dbo.tlbAggrMatrixVersionHeader Where [idfsAggrCaseSection] in (Select Top 1 [idfAggregateCaseSection] From @MatrixInfo) And [blnIsActive]= 1 ORDER BY CAST(ISNULL(blnIsDefault,0) AS INT)+CAST(ISNULL(blnIsActive,0) AS INT) DESC, datStartDate DESC
			End;
			Update @observationsTable
				Set [idfVersion] = @idfVersion Where intRowNumber = @currentRow;
			
			-- теперь обработаем строки таблиц без боковика (там пустые строки не учитываютс€)
			-- рассчитываем номера строк последовательно по idfRow			
			
			Select @innerRowCount = Null
			Select @innerRowCount = Max([numRow]) From @ResultTable Where [Type] = 1 And [idfObservation] = @currentObservation
			
			If (@innerRowCount > 0) Begin									
					Select @NumRow = -1, @CurrentIdfRow = 0, @innerCurrentRow = 1;
					
--					While(@innerCurrentRow <= @innerRowCount) Begin
--						Select @idfRow = [idfRow] From @ResultTable 
--							Where [Type] = 1 And [idfObservation] = @currentObservation And [numRow] = @innerCurrentRow;
--						If (@CurrentIdfRow <> @idfRow) BEGIN
--							Set @CurrentIdfRow = @idfRow;                                          	
--							Set @NumRow = @NumRow + 1;
--						    
--							Update @ResultTable
--							Set			    	
--		    					[intNumRow] = @NumRow
--							Where
--								[idfRow] = @idfRow
--								And [idfObservation] = @currentObservation							    	
--						End
--						
--						Set @innerCurrentRow = @innerCurrentRow + 1;	
--					end	
					
					Declare curs Cursor Local Forward_only Static For
						Select [idfRow] From @ResultTable Where [Type] = 1 And [idfObservation] = @currentObservation
						
					Open curs
						Fetch Next From curs into @idfRow
						
						While @@FETCH_STATUS = 0 Begin
							If (@CurrentIdfRow <> @idfRow) BEGIN
								Set @CurrentIdfRow = @idfRow;                                          	
								Set @NumRow = @NumRow + 1;
							    
								Update @ResultTable
								Set			    	
			    					[intNumRow] = @NumRow
								Where
									[idfRow] = @idfRow
									And [idfObservation] = @currentObservation							    	
							End
							
							Fetch Next From curs into @idfRow
						End
					
					Close curs
					Deallocate curs
			End
			
			-- теперь обработаем строки таблиц c боковиком (там пустые строки учитываютс€)
			-- нужно рассчитать номера строк по боковику (по матрице боковика)
			
			Select @innerRowCount = Null
			Select @innerRowCount = Max([numRow]) From @ResultTable Where [Type] > 1 And [idfObservation] = @currentObservation
					
			If (@innerRowCount > 0) Begin
				Select @NumRow = Null, @IdfRow = Null, @innerCurrentRow = 1;
--				
--				While(@innerCurrentRow <= @innerRowCount) Begin
--					Select @idfRow = [idfRow], @Type = [Type] From @ResultTable 
--						Where [Type] > 1 And [idfObservation] = @currentObservation And [numRow] = @innerCurrentRow;
--
--					Delete from @matrixTable
--					Insert into @matrixTable Exec dbo.spFFGetPredefinedStub @Type, @idfVersion, @LangID_int		
--					
--					Set  @NumRow = Null   
--					Select @NumRow = [NumRow] From @matrixTable Where [idfRow] = @idfRow
--					
--					Update @ResultTable
--					Set			    	
--    					[intNumRow] = @NumRow
--					Where
--						[idfRow] = @idfRow
--						And [idfObservation] = @currentObservation;					
--					
--					Set @innerCurrentRow = @innerCurrentRow + 1;	
--				end
				
				Declare curs Cursor Local Forward_only Static For
						Select [idfRow], [Type] From @ResultTable Where [Type] > 1 And [idfObservation] = @currentObservation
					
				Open curs
					Fetch Next From curs into @idfRow, @Type
					
					While @@FETCH_STATUS = 0 Begin
						Delete from @matrixTable
						Insert into @matrixTable Exec dbo.spFFGetPredefinedStub @Type, @idfVersion, @LangID_int		
						
						Set  @NumRow = Null   
						Select @NumRow = [NumRow] From @matrixTable Where [idfRow] = @idfRow
						
						Update @ResultTable
						Set			    	
	    					[intNumRow] = @NumRow
						Where
							[idfRow] = @idfRow
							And [idfObservation] = @currentObservation;
							
						Fetch Next From curs into @idfRow, @Type
					End
				
				Close curs
				Deallocate curs
			
			End
				
			Set @currentRow = @currentRow + 1;
	End
	
	-- обычные параметры.
	-- они вообще не имеют секции или их секци€ не таблична€
	Update @ResultTable
	Set [intNumRow] = 0
	Where [Type] = 0
	
	-- заполн€ем пол€ дешифрованными значени€ми параметров, где это нужно
	Update @ResultTable
		Set RT.[strNameValue] = IsNull(SNT.[strTextString], BR.[strDefault])	
		From @ResultTable As RT
		Inner Join dbo.ffParameter P On RT.idfsParameter = P.idfsParameter And P.idfsEditor = 10067002 And P.[intRowStatus] = 0
		Inner Join dbo.trtBaseReference BR On BR.idfsBaseReference = RT.varValue And BR.[intRowStatus] = 0
		Left Join dbo.trtStringNameTranslation SNT On SNT.idfsBaseReference = RT.varValue And SNT.idfsLanguage = @LangID_int And SNT.[intRowStatus] = 0
	
	Select
		[idfObservation]
		,[idfsFormTemplate]
		,[idfsParameter]
		,[idfRow]
		,[intNumRow]
		,[Type]
		,[varValue]	
		,[strNameValue]	
		,[numRow] -- нумераци€ строк внутри каждого [idfObservation]
	From @ResultTable
	Order By
		[idfObservation], [idfsParameter], [idfRow]
	
End
Go