-- заполняет таблицу ffParameter (FlexForms)
-- EIDSS db version 2
-- [EIDSS_version3] db version 3
Set Nocount On;

--Begin Transaction

declare 
		@NewReferenceType Int
		,@OldReferenceType Varchar(36)
		,@FormType Bigint
		,@MessageID Bigint
		,@ParameterType Bigint
		,@Editor Bigint
		
Select @NewReferenceType = 19000066, @OldReferenceType = 'rftParameter'

Delete from [EIDSS_version3].dbo.ffParameterDesignOption
Delete from [EIDSS_version3].dbo.ffParameter -- не проверяются записи в связанных таблицах

Declare @NewBaseReferenceID Bigint		
			,@idfsBaseReference Varchar(36)		
			,@idfParameterDesignOption  Uniqueidentifier
			,@NewIdfParameterDesignOption Bigint
				
Declare cursBaseReference Cursor For
	Select [idfsBaseReference] From [EIDSS_version2].dbo.BaseReference Where idfsReference_Type = @OldReferenceType


-- перепишем данные по BaseReference
Open cursBaseReference
	Fetch Next From cursBaseReference Into @idfsBaseReference
	While (@@FETCH_STATUS = 0) Begin	
		 -- вынимаем ID параметра из trtBaseRef, где про него уже есть запись
		 Select @NewBaseReferenceID = idfsBaseReference From [EIDSS_version3].dbo.trtBaseReference
			Where strBaseReferenceCode = @idfsBaseReference	 
		
		-- получим тип формы для этой секции
		 Select @FormType = idfsBaseReference From [EIDSS_version3].dbo.trtBaseReference Where /*strBaseReferenceCode='rftFFType' And*/  strDefault In  
			(
				Select strDefault From [EIDSS_version2].dbo.BaseReference Where idfsBaseReference In
							(
								Select idfsFFormTemplateID From [EIDSS_version2].dbo.[ParameterforTemplate] fs Where idfsParameterID=@idfsBaseReference
							)
			)
		
		-- определим ID заголовка параметра		
		Select @MessageID = idfsBaseReference From [EIDSS_version3].dbo.trtBaseReference Where strBaseReferenceCode In
		(	
			Select idfsParameterID From [EIDSS_version2].dbo.Parameter Where idfsParameterID = @idfsBaseReference
		)
		
		-- определим тип параметра
		Select @ParameterType = idfsBaseReference From [EIDSS_version3].dbo.trtBaseReference Where strBaseReferenceCode In
		(	
			Select idfsParameterTypeID From [EIDSS_version2].dbo.Parameter Where idfsParameterID = @idfsBaseReference
		)
		
		-- определим тип редактора
		Select @Editor = idfsBaseReference From [EIDSS_version3].dbo.trtBaseReference Where strBaseReferenceCode In
		(	
			Select [idfsEditorID] From [EIDSS_version2].dbo.Parameter Where idfsParameterID = @idfsBaseReference
		)
		
		 -- переписываем данные по секциям
		 Insert into [EIDSS_version3].dbo.ffParameter
			(
				   [idfsParameter]
				  ,[idfsSection]
				  ,[idfsParameterCaption]
				  ,[idfsFormType]
				  ,[idfsParameterType]
				  ,[idfsEditor]				  
				  ,[strNote]
				  ,[intOrder]
				  ,[intHACode]
				  ,[intRowStatus]
				  ,[rowguid]            
			)
			Select					
					@NewBaseReferenceID
					,Null -- не помещаем ни в какую секцию
					,@MessageID
					,@FormType
					,@ParameterType
				    ,@Editor		  
				    ,''
				    ,0
				    ,0
				    ,[intRowStatus]
				    ,[rowguid]
			From [EIDSS_version2].dbo.Parameter Where idfsParameterID = @idfsBaseReference --And idfsSection = Null
		  
			-- перегоняем дефолтные образы параметров (те, что не принадлежат никакому шаблону)
--			Declare cursParameterDesignOption Cursor For
--				Select [idfParameterDesignOption] From [EIDSS_version2].dbo.ffParameterDesignOption Where idfsParameter = @idfsBaseReference
--
--			Open cursParameterDesignOption
--				Fetch Next From cursParameterDesignOption Into @idfParameterDesignOption
--				While (@@FETCH_STATUS = 0) Begin					
--						Exec [EIDSS_version3].dbo.[spsysGetNewID] @NewIdfParameterDesignOption Output
--						Insert into [EIDSS_version3].[dbo].[ffParameterDesignOption]
--						   (
--					   			[idfParameterDesignOption]
--							   ,[idfsParameter]
--							   ,[idfsLanguage]
--							   ,[idfsFormTemplate]
--							   ,[intLeft]
--							   ,[intTop]
--							   ,[intWidth]
--							   ,[intHeight]
--							   ,[intScheme]
--							   ,[intLabelSize]
--							   ,[intOrder]
--							   ,[intRowStatus]								
--						   )
--					  Select 					  
--								@NewIdfParameterDesignOption
--								,@NewBaseReferenceID
--								,10049003
--								,null
--								,[intLeft]
--								,[intTop]
--								,[intWidth]
--								,[intHeight]
--								,[intScheme]
--								,[intLabelSize]					  
--								,[intOrder]
--								,0								
--						From [EIDSS_version2].dbo.ffParameterDesignOption 
--					   Where 
--								idfParameterDesignOption =@idfParameterDesignOption 
--								And [idfsFormTemplate] Is Null
--						
--						Fetch Next From cursParameterDesignOption Into @idfParameterDesignOption	
--				End
--			Close cursParameterDesignOption
--			Deallocate cursParameterDesignOption
		 Fetch Next From cursBaseReference Into @idfsBaseReference
	End
Close cursBaseReference
Deallocate cursBaseReference

--Commit Transaction
--
--- 0,0
--- 150,100
--- 0
--- 75
--- 0
--- 0

DECLARE @i BIGINT

EXEC [EIDSS_version3].dbo.[spsysGetNewID] @i OUTPUT

IF @i IS NULL 
SELECT @i = MAX([idfParameterDesignOption])
FROM [EIDSS_version3].dbo.[ffParameterDesignOption]

INSERT INTO [EIDSS_version3].dbo.[ffParameterDesignOption] (
	[idfParameterDesignOption],
	[idfsParameter],
	[idfsLanguage],
	[idfsFormTemplate],
	[intLeft],[intTop],
	[intWidth],[intHeight],
	[intScheme],
	[intLabelSize],
	[intOrder]
) 	
SELECT 
	@i + (ROW_NUMBER() OVER(ORDER BY a.[idfsParameter]))*10000000,
	a.[idfsParameter],
	10049003, -- en 
	NULL,
	0,0,
	150,100,
	0,
	75,
	0
FROM [EIDSS_version3].dbo.[ffParameter] AS a
LEFT JOIN [EIDSS_version3].dbo.[ffParameterDesignOption] AS b
ON a.[idfsParameter] = b.[idfsParameter] AND b.[idfsFormTemplate] IS NULL 
WHERE b.[idfParameterDesignOption] IS NULL 

/*
SELECT * FROM [EIDSS_version3].dbo.[trtBaseReference] 
WHERE [strBaseReferenceCode] = 'en'
*/

SELECT @i = MAX([idfParameterDesignOption])
FROM [EIDSS_version3].dbo.[ffParameterDesignOption]

SET IDENTITY_INSERT [EIDSS_version3].dbo.tstNewID ON 
INSERT INTO [EIDSS_version3].dbo.tstNewID(NewID, strA)
VALUES (@i, '')
SET IDENTITY_INSERT [EIDSS_version3].dbo.tstNewID OFF 
DELETE [EIDSS_version3].dbo.tstNewID WHERE NEWID = @i

