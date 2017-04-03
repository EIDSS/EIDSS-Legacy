-- заполняет таблицу ffParameterFixedPresetValues (FlexForms)
-- EIDSS db version 2
-- EIDSS db version 3
Set Nocount On;

Begin Transaction

declare 
		@NewReferenceType Int
		,@OldReferenceType Varchar(36)		
		,@ParameterType Bigint	
		
--Select @NewReferenceType = 19000069, @OldReferenceType = 'rftParametersFixedPresetValue'

Delete from EIDSS.dbo.ffParameterFixedPresetValue

Declare @NewBaseReferenceID Bigint		
			,@idfsBaseReference Varchar(36)		
				
Declare cursBaseReference Cursor For
	Select [idfsBaseReference] From EIDSS.dbo.BaseReference Where idfsReference_Type = 'rftParametersFixedPresetValue'

-- перепишем данные по BaseReference
Open cursBaseReference
	Fetch Next From cursBaseReference Into @idfsBaseReference
	While (@@FETCH_STATUS = 0) Begin	
		 --
		 Select @NewBaseReferenceID = idfsBaseReference From EIDSS.dbo.trtBaseReference
					Where strBaseReferenceCode = @idfsBaseReference	 
		
		-- 
		 Select @ParameterType = idfsBaseReference From EIDSS.dbo.trtBaseReference Where strBaseReferenceCode In  
			(
				Select idfsParameterType From EIDSS.dbo.ffParameterFixedPresetValue Where EIDSS.dbo.ffParameterFixedPresetValue.idfsParameterFixedPresetValue = @idfsBaseReference						
			)		
	
		Print @NewBaseReferenceID
		Print @ParameterType
		Print '-----------'
	
		 -- переписываем данные по секциям
		 Insert into EIDSS.dbo.ffParameterFixedPresetValue
			(
				   [idfsParameterFixedPresetValue]
					,[idfsParameterType]
					,[intRowStatus]           
			)
			Select					
					@NewBaseReferenceID
					,@ParameterType
					,[intRowStatus]
			From EIDSS.dbo.ffParameterFixedPresetValue Where idfsParameterFixedPresetValue = @idfsBaseReference 
			
		 Fetch Next From cursBaseReference Into @idfsBaseReference
	End
Close cursBaseReference
Deallocate cursBaseReference

Commit Transaction

	