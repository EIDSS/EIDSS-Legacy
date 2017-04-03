-- ���������� ������ �� �������� �� ��������� (UNI �������)
-- ����������� Find&Replace ��� �������� �������� ��
-- EIDSS db version 2
-- EIDSS db version 3
Set Nocount On;

Declare @idfsFormTemplate Varchar(36), @idfsFormType Varchar(36), @idfsParameter Varchar(36)
			, @DefaultName Nvarchar(200), @NationalName Nvarchar(400)
			, @idfsFormTypeNew Bigint,	 @idfsFormTemplateNew Bigint, @idfsParameterNew Bigint
			, @langid Nvarchar(50)
			
-- ����-������ ���������
Declare @intTop Int, @intWidth Int, @intHeight Int, @intScheme Int, @intLabelSize Int

Set @langid = 'en'

Declare @langid_int Bigint
Set @langid_int = EIDSS.dbo.fnGetLanguageCode(@langid);

Declare curs Cursor For
	Select idfsFormTemplate,  idfsFormType From EIDSS.dbo.ffFormTemplate Where [blnUNI] = 1
	
Open curs
	Fetch Next From curs Into @idfsFormTemplate, @idfsFormType

While (@@FETCH_STATUS = 0) BEGIN
	-- ��������� ����� ��� �����
	Select @idfsFormTypeNew = [idfsBaseReference] From EIDSS.dbo.trtBaseReference 
				Where [strBaseReferenceCode] = @idfsFormType;
	-- �������� ����� ID ��� �������                 
	Exec EIDSS.dbo.[spsysGetNewID] @idfsFormTemplateNew Output
	-- �������� ������ �������
	Select @DefaultName = [strDefault] From EIDSS.dbo.BaseReference Where [idfsBaseReference] = @idfsFormTemplate;
	Select @NationalName = [strTextString] From EIDSS.dbo.StringNameTranslation Where [idfsBaseReference] = @idfsFormTemplate And [idfsLanguage] = @langid;
	-- ��������� ������ � ����� ��
	Exec EIDSS.dbo.spFFSaveTemplate  @idfsFormTemplateNew, @idfsFormTypeNew, @DefaultName, @NationalName, null, @langid, 1
	
	-- ����������, ���� �� �����-���� ��������� ��� ����� �������
	-- ���� ����, �� ���� ���������
	If Exists(Select Top 1 1 From EIDSS.dbo.ffParameterForTemplate Where [idfsFormTemplate] = @idfsFormTemplate) BEGIN
		Declare cursParameters Cursor For
			Select [idfsParameter] From EIDSS.dbo.ffParameterForTemplate Where [idfsFormTemplate] = @idfsFormTemplate
		Open cursParameters
			Fetch Next From cursParameters Into @idfsParameter
		Set @intTop = 0
		While (@@FETCH_STATUS = 0) BEGIN
				-- ������� ����� ID ����� ���������
				Select @idfsParameterNew = [idfsBaseReference] From EIDSS.dbo.trtBaseReference 
						Where [strBaseReferenceCode] = @idfsParameter;
						
				Select @intWidth = Null, @intHeight = Null, @intScheme = Null, @intLabelSize = Null
				-- �������� ����-������ �� ���������
				Select @intWidth = [intWidth], @intHeight  = [intHeight], @intScheme = [intScheme], @intLabelSize = [intLabelSize]
					From EIDSS.dbo.ffParameterDesignOption 
						Where [idfsParameter] = @idfsParameterNew And [idfsLanguage] = @langid_int And [idfsFormTemplate] Is Null
				-- ���� �� ������� ���������� �����-�� ��������, �� �� ��������� ���� �������� (������-�� ��� ��� ���������� ��������)
				If (@intWidth Is Not Null) And (@intHeight Is Not Null) And (@intScheme Is Not Null) And (@intLabelSize Is Not Null) BEGIN
					-- ��������� ��������
					Set @intTop = @intTop + 10	
							
					-- ��������� EditMode = modeOrdinary, Left = 10, Top = ����������� ��� ����������, ��������� ����� � ������ ���������� ���������
					Exec  EIDSS.dbo.spFFSaveParameterTemplate @idfsParameterNew, @idfsFormTemplateNew, @langid, 
							10068001, 10, @intTop, @intWidth, @intHeight, @intScheme, @intLabelSize
					
					-- ��������� ��������� ��������, ����� ���������� ��������� ���������� ��������� (�� ���� ����������� �� ������ ����������� + ����� 10 ��������)
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