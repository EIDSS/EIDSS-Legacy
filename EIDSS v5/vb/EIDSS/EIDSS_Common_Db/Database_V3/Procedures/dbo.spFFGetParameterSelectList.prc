set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetParameterSelectList]')) DROP PROCEDURE [dbo].[spFFGetParameterSelectList]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 
-- Description: получает список значений выбора для параметра
-- =============================================
CREATE PROCEDURE dbo.spFFGetParameterSelectList
(
	@LangID Nvarchar(50) = Null	
	,@idfsParameter Bigint
	,@idfsParameterType Bigint = Null
	,@intHACode Bigint = Null
)	
AS
BEGIN	
	Set Nocount On;

	--If ((@intHACode Is Not Null) And (@intHACode & 1 > 0)) Set @intHACode = @intHACode - 1;

	If (@LangID Is Null) Set @LangID = 'en';

	Declare @ResultTable Table 
	(
		[idfsParameter] Bigint
		,[idfsParameterType] Bigint
		,[idfsReferenceType] Bigint
		,[idfsValue] Bigint -- значение элемента списка
		,[strValueCaption] Nvarchar(300) -- заголовок элемента списка	
		,[intOrder] Int
		,[intHACode] Int
	)
    
    Declare @idfsReferenceType Bigint
    
    If (@idfsParameterType Is Null) begin
		Select Top 1 @idfsParameterType = P.idfsParameterType
			From dbo.ffParameter P
			Inner Join dbo.ffParameterType PT On P.idfsParameterType = PT.idfsParameterType And PT.[intRowStatus] = 0    
			Where [idfsParameter] = @idfsParameter And P.[intRowStatus] = 0
	End
	
	Select Top 1 @idfsReferenceType = [idfsReferenceType]
		From dbo.ffParameterType
		Where [idfsParameterType] = @idfsParameterType And [intRowStatus] = 0
		
    
    If (@idfsReferenceType = 19000069 /*'rftParametersFixedPresetValue'*/) BEGIN
        -- если это предустановленные наборы значений
        Insert into @ResultTable
			(
				[idfsParameter]
				,[idfsParameterType]
				,[idfsReferenceType]
				,[idfsValue]
				,[strValueCaption]
				,[intOrder]
				,[intHACode]
			)
			Select 
				idfsParameter 
				,P.idfsParameterType			
				,19000069/*'rftParametersFixedPresetValue'*/
				,FPV.idfsParameterFixedPresetValue
				,FR.LongName
				,FR.intOrder
				,FR.intHACode
			From dbo.ffParameter P
			Inner Join dbo.ffParameterFixedPresetValue FPV On P.idfsParameterType = FPV.idfsParameterType And FPV.[intRowStatus] = 0
			Inner Join dbo.fnReference(@LangID, 19000069 /*'rftParametersFixedPresetValue'*/) FR On FPV.idfsParameterFixedPresetValue = FR.idfsReference
			Where P.idfsParameter = @idfsParameter And P.[intRowStatus] = 0
    
    End Else If (@idfsReferenceType Is Not Null) Begin
          -- если это подмножества из BaseReference
          Insert into @ResultTable
			(
				[idfsReferenceType]
				,[idfsValue]
				,[strValueCaption]
				,[intOrder]
				,[intHACode]
			)
			Select 
				@idfsReferenceType
				,idfsReference
				,[Name]
				,intOrder
				,intHACode
			From dbo.fnReferenceLookup(@LangID, @idfsReferenceType, @intHACode)		
			
		Update 	@ResultTable
			Set 
				[idfsParameter] = @idfsParameter
				,[idfsParameterType] = @idfsParameterType				
    END
    
    Select 
		[idfsParameter]
		,[idfsParameterType]
		,[idfsReferenceType]
		,[idfsValue]
		,[strValueCaption]
		,@LangID As [langid]
		,[intOrder]
		,[intHACode]
    From @ResultTable
    Order By [intOrder] Asc, [strValueCaption] Asc
    
End
Go
