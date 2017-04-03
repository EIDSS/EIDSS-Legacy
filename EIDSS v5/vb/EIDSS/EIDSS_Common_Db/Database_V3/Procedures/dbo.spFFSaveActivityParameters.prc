set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].spFFSaveActivityParameters')) DROP PROCEDURE [dbo].spFFSaveActivityParameters
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 
-- Description:
-- =============================================
Create Procedure dbo.spFFSaveActivityParameters
(
	@idfsParameter Bigint
	,@idfObservation Bigint  
	,@idfsFormTemplate Bigint   
    ,@varValue Sql_variant
    ,@idfRow Bigint Output
    ,@IsDynamicParameter Bit = 0
)	
AS
BEGIN	
	Set Nocount On;	

	-- определим, нужно ли сохранять данные по этому параметру
	-- данные можно сохранять если только этот параметр принадлежит шаблону
	If (@IsDynamicParameter = 0) Begin
		If Not Exists(
					Select Top 1 1 From dbo.ffParameterForTemplate Where idfsParameter = @idfsParameter And idfsFormTemplate = @idfsFormTemplate And intRowStatus = 0
						
		) Return;
	End;
	
	-- если нет observation, то выходим (он мог быть создан и удалён носителем FFPresenter во время сеанса)
	If Not Exists (Select Top 1 1 From dbo.tlbObservation Where idfObservation = @idfObservation) Return;

	-- если id < 0, значит, это временный id и нужно заменить его на настоящий
	If (@idfRow < 0) Exec dbo.[spsysGetNewID] @idfRow Output

	-- если переданное значение пустое, то надо удалить эту строку
	If ((@varValue Is Null) Or (Len(cast(@varValue As Varchar(Max))) = 0)) Begin
			Exec dbo.spFFRemoveActivityParameters @idfsParameter, @idfObservation, @idfRow                                                  	
	End Else BEGIN	
			If Not Exists (Select Top 1 1 From dbo.tlbActivityParameters Where [idfsParameter] = @idfsParameter And [idfObservation] = @idfObservation And [idfRow] = @idfRow) BEGIN
					 Insert into [dbo].[tlbActivityParameters]
							 (
			   						[idfsParameter]
									,[idfObservation]
									,[varValue]
									,[idfRow]		
							)
					VALUES
							(
									@idfsParameter
									,@idfObservation
									,@varValue
									,@idfRow
							)
			End Else BEGIN
				   Update [dbo].[tlbActivityParameters]
							   SET 								
									[varValue] = @varValue
									,[intRowStatus] = 0									
								WHERE [idfsParameter] = @idfsParameter And [idfObservation] = @idfObservation And [idfRow] = @idfRow
			End
	 END		
End
Go