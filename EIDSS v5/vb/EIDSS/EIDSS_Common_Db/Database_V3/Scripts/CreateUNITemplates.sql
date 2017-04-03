-- перегоняет данные по шаблонам по умолчанию (UNI шаблоны)
-- используйте Find&Replace для указания названий БД
-- EIDSS db version 2
-- EIDSS db version 3
Set Nocount On;

Declare @idfsFormTemplate Varchar(36), @idfsFormType Varchar(36), @idfsParameter Varchar(36)
			, @DefaultName Nvarchar(200), @NationalName Nvarchar(400)
			, @idfsFormTypeNew Bigint,	 @idfsFormTemplateNew Bigint, @idfsParameterNew Bigint
			, @langid Nvarchar(50)
			
-- мета-данные параметра
Declare @intTop Int, @intWidth Int, @intHeight Int, @intScheme Int, @intLabelSize Int

Set @langid = 'en'

Declare @langid_int Bigint
Set @langid_int = EIDSS.dbo.fnGetLanguageCode(@langid);

Declare curs Cursor For
	Select idfsFormTemplate,  idfsFormType From EIDSS.dbo.ffFormTemplate Where [blnUNI] = 1
	
Open curs
	Fetch Next From curs Into @idfsFormTemplate, @idfsFormType

While (@@FETCH_STATUS = 0) BEGIN
	-- определим новый тип формы
	Select @idfsFormTypeNew = [idfsBaseReference] From EIDSS.dbo.trtBaseReference 
				Where [strBaseReferenceCode] = @idfsFormType;
	-- получаем новый ID для шаблона                 
	Exec EIDSS.dbo.[spsysGetNewID] @idfsFormTemplateNew Output
	-- получаем данные шаблона
	Select @DefaultName = [strDefault] From EIDSS.dbo.BaseReference Where [idfsBaseReference] = @idfsFormTemplate;
	Select @NationalName = [strTextString] From EIDSS.dbo.StringNameTranslation Where [idfsBaseReference] = @idfsFormTemplate And [idfsLanguage] = @langid;
	-- сохраняем шаблон в новую БД
	Exec EIDSS.dbo.spFFSaveTemplate  @idfsFormTemplateNew, @idfsFormTypeNew, @DefaultName, @NationalName, null, @langid, 1
	
	-- определяем, есть ли какие-либо параметры для этого шаблона
	-- если есть, то тоже переносим
	If Exists(Select Top 1 1 From EIDSS.dbo.ffParameterForTemplate Where [idfsFormTemplate] = @idfsFormTemplate) BEGIN
		Declare cursParameters Cursor For
			Select [idfsParameter] From EIDSS.dbo.ffParameterForTemplate Where [idfsFormTemplate] = @idfsFormTemplate
		Open cursParameters
			Fetch Next From cursParameters Into @idfsParameter
		Set @intTop = 0
		While (@@FETCH_STATUS = 0) BEGIN
				-- находим новый ID этого параметра
				Select @idfsParameterNew = [idfsBaseReference] From EIDSS.dbo.trtBaseReference 
						Where [strBaseReferenceCode] = @idfsParameter;
						
				Select @intWidth = Null, @intHeight = Null, @intScheme = Null, @intLabelSize = Null
				-- получаем мета-данные по параметру
				Select @intWidth = [intWidth], @intHeight  = [intHeight], @intScheme = [intScheme], @intLabelSize = [intLabelSize]
					From EIDSS.dbo.ffParameterDesignOption 
						Where [idfsParameter] = @idfsParameterNew And [idfsLanguage] = @langid_int And [idfsFormTemplate] Is Null
				-- если не удалось определить какой-то параметр, то не переносим этот параметр (почему-то нет его дефолтного описания)
				If (@intWidth Is Not Null) And (@intHeight Is Not Null) And (@intScheme Is Not Null) And (@intLabelSize Is Not Null) BEGIN
					-- выполняем смещение
					Set @intTop = @intTop + 10	
							
					-- сохраняем EditMode = modeOrdinary, Left = 10, Top = последующий под предыдущим, дефолтная схема и размер текстового заголовка
					Exec  EIDSS.dbo.spFFSaveParameterTemplate @idfsParameterNew, @idfsFormTemplateNew, @langid, 
							10068001, 10, @intTop, @intWidth, @intHeight, @intScheme, @intLabelSize
					
					-- выполняем повторное смещение, чтобы определить положение следующего параметра (он ниже предыдущего на высоту предыдущего + зазор 10 пикселей)
					Set @intTop = @intTop + @intHeight
				End
				--
				Fetch Next From cursParameters Into @idfsParameter
		End
		Close cursParameters
		Deallocate cursParameters
	END
	
	
	Fetch Next From curs Into @idfsFormTemplate, @idfsFormType
End

Close curs
Deallocate curs
Go