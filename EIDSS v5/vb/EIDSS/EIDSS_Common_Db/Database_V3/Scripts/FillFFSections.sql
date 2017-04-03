-- перегон€ет данные по секци€м (FlexForms)
-- EIDSS db version 2
-- [EIDSS_version3] db version 3
Set Nocount On;

--Begin Transaction

declare 
		@NewReferenceType Int
		,@OldReferenceType Varchar(36)
		
Select @NewReferenceType = 19000101, @OldReferenceType = 'rftSection'

--Delete from [EIDSS_version3].dbo.ffSection -- не провер€ютс€ записи в св€занных таблицах
--Delete From [EIDSS_version3].dbo.trtStringNameTranslation
--	Where idfsBaseReference In 
--		(Select idfsBaseReference From [EIDSS_version3].dbo.trtBaseReference Where idfsReferenceType = @NewReferenceType)
--Delete from [EIDSS_version3].dbo.trtBaseReference 
--	Where idfsReferenceType = @NewReferenceType

Declare @NewBaseReferenceID Bigint		
			,@idfsBaseReference Varchar(36)
			,@FormType Bigint
				
--Declare cursBaseReference Cursor For
--	Select [idfsBaseReference] From [EIDSS_version2].dbo.BaseReference Where idfsReference_Type = @OldReferenceType

-- проверим наличие записи о типе "секци€"
If Not Exists(Select Top 1 1 From [EIDSS_version3].dbo.trtBaseReference 
	Where strBaseReferenceCode = @OldReferenceType
	OR [idfsBaseReference] = @NewReferenceType ) 
BEGIN
     Declare @section_reference_id Bigint
     Exec [EIDSS_version3].dbo.[spsysGetNewID] @section_reference_id Output
         
         Insert into [EIDSS_version3].dbo.trtBaseReference
			(
				idfsBaseReference
				,idfsReferenceType
				,strBaseReferenceCode
				,strDefault
				,intHACode
				,intOrder
				,intRowStatus				  
			)
			Values
			( 
				@section_reference_id
				,@NewReferenceType
				,null
				,'Flexible Form Section'
				,0
				,0
				,0
			)	
END
	
	
	
-- перепишем данные по BaseReference
--Open cursBaseReference
--	Fetch Next From cursBaseReference Into @idfsBaseReference
--	While (@@FETCH_STATUS = 0) Begin
--		 Exec [EIDSS_version3].dbo.[spsysGetNewID] @NewBaseReferenceID Output
--		 Insert INTO [EIDSS_version3].dbo.trtBaseReference
--			 (
--		 		idfsBaseReference
--		 		,idfsReferenceType
--		 		,strBaseReferenceCode
--		 		,strDefault
--		 		,intHACode
--		 		,intOrder
--		 		,intRowStatus
--		 		,rowguid
--			 )
--		 Select 
--				@NewBaseReferenceID
--				,@NewReferenceType
--				,@OldReferenceType
--				,[strDefault]
--				,[intHA_Code]
--				,[intOrder]		
--				,[intRowStatus] 				
--				,[rowguid]						
--		 From [EIDSS_version2].dbo.BaseReference Where idfsBaseReference = @idfsBaseReference	
--		
--		 -- перетащим все переводы по этой сущности
--		 Insert into [EIDSS_version3].dbo.trtStringNameTranslation
--			(
--				idfsBaseReference
--				,idfsLanguage
--				,strTextString
--				,intRowStatus
--				,rowguid
--			)
--			Select 
--				@NewBaseReferenceID
--				,dbo.fnGetLanguageCode([idfsLanguage])
--				,[strTextString]
--				,0
--				,[rowguid]
--			From [EIDSS_version2].dbo.StringNameTranslation Where idfsBaseReference= @idfsBaseReference 	
--		 
--		 -- получим тип формы дл€ этой секции
--		 Select @FormType = idfsBaseReference From [EIDSS_version3].dbo.trtBaseReference Where strBaseReferenceCode='rftFFType' And  strDefault In  
--			(
--				Select strDefault From [EIDSS_version2].dbo.BaseReference Where idfsBaseReference In
--							(
--								Select idfsFormType From [EIDSS_version2].dbo.ffSection fs Where idfsSection=@idfsBaseReference
--							)
--			)
--
--		 -- переписываем данные по секци€м
--		 Insert into [EIDSS_version3].dbo.ffSection
--			(
--				   [idfsSection]
--				  ,[idfsParentSection]
--				  ,[idfsFormType]
--				  ,[intOrder]
--				  ,[blnGrid]
--				  ,[blnFixedRowSet]
--				  ,[intRowStatus]
--				  ,[rowguid]	               
--			)
--			Select 
--					@NewBaseReferenceID
--					,Null
--					,@FormType
--					,[intOrder]
--					,[blnGrid]
--					,[blnFixedRowSet]
--					,[intRowStatus]
--					,[rowguid]	     
--			From [EIDSS_version2].dbo.ffSection Where idfsParentSection Is Null And idfsSection = @idfsBaseReference
--		  
--		 Fetch Next From cursBaseReference Into @idfsBaseReference
--	End
--Close cursBaseReference
--Deallocate cursBaseReference

--Commit Transaction

	