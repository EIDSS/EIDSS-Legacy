-- скрипт добавляет в БД FF шаблон Avian Flu

Set Nocount On

--Begin Transaction

-- проверим наличие секций в BR
--If Not Exists(Select Top 1 1 From trtBaseReference Where idfsBaseReference=19000101 And strBaseReferenceCode = 'rftSection') BEGIN
--      Insert into [dbo].[trtBaseReference]
--           (
--           	[idfsBaseReference]
--           ,[idfsReferenceType]
--           ,[strBaseReferenceCode]
--           ,[strDefault]
--           ,[intHACode]
--           ,[intOrder]
--           ,[intRowStatus]           
--           )
--     Values
--           (
--           		19000101
--           		,19000076
--           		,'rftSection'
--           		,'Flexible Form Section'
--           		,0
--           		,0
--           		,0           		
--           )                                                                                                               	
--End

-- введем данные о параметрах, участвующих в шаблоне
-- Number of barns/buildings ID = 18630000000
--Insert into dbo.ffParameter
--	(
--			[idfsParameter]          
--           ,[idfsParameterCaption]
--           ,[idfsFormType]
--           ,[idfsParameterType]
--           ,[idfsEditor]          
--           ,[intOrder]          
--           ,[intRowStatus]           
--	)
--	Values
--	(
--			18630000000	
--			,32510000000
--			,50030000000
--			,10071007
--			,10067008
--			,0
--			,0
--	)
---- Number of birds per barns/buildings ID = 18640000000
--Insert into dbo.ffParameter
--	(
--			[idfsParameter]          
--           ,[idfsParameterCaption]
--           ,[idfsFormType]
--           ,[idfsParameterType]
--           ,[idfsEditor]          
--           ,[intOrder]          
--           ,[intRowStatus]           
--	)
--	Values
--	(
--			18640000000	
--			,32520000000
--			,50030000000
--			,10071007
--			,10067008
--			,0
--			,0
--	)
--	
-- внесем описание параметров для конкретного шаблона и дефолтных
----	Number of barns/buildings ID = 18630000000
--Insert into [dbo].[ffParameterDesignOption]
--	(
--			[idfParameterDesignOption]
--           ,[idfsParameter]
--           ,[idfsLanguage]
--           ,[idfsFormTemplate]
--           ,[intLeft]
--           ,[intTop]
--           ,[intWidth]
--           ,[intHeight]
--           ,[intScheme]
--           ,[intLabelSize]
--           ,[intOrder]
--           ,[intRowStatus]           
--	)
--	Values
--	(
--		75900000000
--		,18630000000
--		,10049003
--		,Null
--		,0
--		,0
--		,150
--		,100
--		,0
--		,75
--		,0
--		,0
--	)
--	-- для конкретного шаблона
	
--	Number of birds per barns/buildings ID = 18640000000
--Insert into [dbo].[ffParameterDesignOption]
--	(
--			[idfParameterDesignOption]
--           ,[idfsParameter]
--           ,[idfsLanguage]
--           ,[idfsFormTemplate]
--           ,[intLeft]
--           ,[intTop]
--           ,[intWidth]
--           ,[intHeight]
--           ,[intScheme]
--           ,[intLabelSize]
--           ,[intOrder]
--           ,[intRowStatus]           
--	)
--	Values
--	(
--		75940000000
--		,18640000000
--		,10049003
--		,Null
--		,0
--		,0
--		,100
--		,100
--		,0
--		,50
--		,0
--		,0
--	)
	-- для конкретного шаблона	

-- формируем структуру шаблона
-- мета-данные шаблона
DECLARE @i BIGINT 

EXEC dbo.[spsysGetNewID]
	@i OUTPUT


Insert into [dbo].[trtBaseReference]
           (
           		[idfsBaseReference]
			   ,[idfsReferenceType]           
			   ,[strDefault]
			   ,[intHACode]        
			   ,[intRowStatus]           
           )
     Values
           (
           		@i
           		,19000033           		
           		,'Avian Flu'
           		,0           		
           		,0           		
           ) 
           
Insert into dbo.trtStringNameTranslation
		(
			[idfsBaseReference]
           ,[idfsLanguage]
           ,[strTextString]
           ,[intRowStatus]
		)
		Values
		(
			@i
			,10049003
			,'Avian Flu'
			,0
		)
		
--SELECT * FROM [trtBaseReference]
--WHERE [idfsReferenceType] = 19000034

Insert into dbo.ffFormTemplate
		(
			[idfsFormTemplate]
           ,[idfsFormType]
           ,[blnUNI]    
           ,[strNote]     
           ,[intRowStatus]
		)
		Values
		(
			@i
			,10034009
			,0
			,'This is test template for Avian Flu'
			,0
		)
		
-- размещаем строки в шаблоне
--	Number of barns/buildings ID = 18630000000
Insert into [dbo].[ffParameterForTemplate]
	(
			[idfsParameter]
           ,[idfsFormTemplate]
           ,[idfsEditMode]
           ,[intRowStatus]
	)
	Values
	(
		18630000000
		,@i
		,10068001	
		,0
	)
	
--	Number of birds per barns/buildings ID = 18640000000
Insert into [dbo].[ffParameterForTemplate]
	(
			[idfsParameter]
           ,[idfsFormTemplate]
           ,[idfsEditMode]
           ,[intRowStatus]
	)
	Values
	(
		18640000000
		,@i
		,10068001	
		,0
	)
	
-- создаём тестовый Observation
Insert into dbo.tlbObservation
	(
		[idfObservation]
		,[idfsFormTemplate]
		--,[strNote]
		,[intRowStatus]	
	)
	Values
	(
		81050000000
		,@i
		--,'тестовый Observation'
		,0
	)	


Insert into [dbo].[ffParameterDesignOption]
	(
			[idfParameterDesignOption]
           ,[idfsParameter]
           ,[idfsLanguage]
           ,[idfsFormTemplate]
           ,[intLeft]
           ,[intTop]
           ,[intWidth]
           ,[intHeight]
           ,[intScheme]
           ,[intLabelSize]
           ,[intOrder]
           ,[intRowStatus]           
	)
	Values
	(
		81040000000
		,18630000000
		,10049003
		,@i
		,13
		,8
		,213
		,39
		,0
		,137
		,0
		,0
	)	

Insert into [dbo].[ffParameterDesignOption]
	(
			[idfParameterDesignOption]
           ,[idfsParameter]
           ,[idfsLanguage]
           ,[idfsFormTemplate]
           ,[intLeft]
           ,[intTop]
           ,[intWidth]
           ,[intHeight]
           ,[intScheme]
           ,[intLabelSize]
           ,[intOrder]
           ,[intRowStatus]           
	)
	Values
	(
		81030000000
		,18640000000
		,10049003
		,@i
		,13
		,50
		,213
		,43
		,0
		,137
		,0
		,0
	)


--Commit Transaction
