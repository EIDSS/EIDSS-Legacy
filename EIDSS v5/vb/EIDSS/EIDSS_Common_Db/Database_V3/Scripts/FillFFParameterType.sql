-- заполняет таблицу ParameterType (FlexForms)
-- EIDSS db version 2
-- [EIDSS_version3] db version 3
Set Nocount On;

Begin Transaction

Delete From [EIDSS_version3].[dbo].[ffParameterType] -- не проверяются связанные таблицы

declare 		
		@idfsParameterTypeOld Varchar(36)
		,@idfsParameterTypeNew Bigint
		,@idfsReferenceType Varchar(36)
				
Declare cursReference Cursor For
	Select Distinct [idfsParameterTypeID] From [EIDSS_version2].dbo.[ParameterType]
	
Open cursReference
	Fetch Next From cursReference Into @idfsParameterTypeOld
	While (@@FETCH_STATUS = 0) Begin	
		 -- вынимаем ID типа параметра из trtBaseRef
		 Select @idfsParameterTypeNew = idfsBaseReference From [EIDSS_version3].dbo.trtBaseReference 	Where strBaseReferenceCode = @idfsParameterTypeOld	 
				
		-- вынем новый reference type
		 Select @idfsReferenceType = idfsReferenceType From [EIDSS_version3].dbo.trtReferenceType Where strReferenceTypeCode In  
			(			
					Select idfsReference_Type From [EIDSS_version2].dbo.ParameterType fs Where idfsParameterTypeID =  @idfsParameterTypeOld
			)
		
		Insert into [EIDSS_version3].[dbo].[ffParameterType]
           (
           		[idfsParameterType]
			   ,[idfsReferenceType]
			   ,[intRowStatus]			   
           )
		Values
           (
           		@idfsParameterTypeNew
           		,@idfsReferenceType
           		,0
           )		
		  
		 Fetch Next From cursReference Into @idfsParameterTypeOld
	End
Close cursReference
Deallocate cursReference

Commit Transaction

	