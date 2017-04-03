set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFFGetParameterEditors]')) DROP PROCEDURE [dbo].[spFFGetParameterEditors]
GO

-- =============================================
-- Author:		Leonov E.N.
-- Create date: 29.09.09
-- Description:	Return list of Parameter Editors
-- =============================================
CREATE PROCEDURE dbo.spFFGetParameterEditors
(
	@LangID Nvarchar(50) = null	
)	
AS
BEGIN	
	Set Nocount On;

	If (@LangID Is Null) Set @LangID = 'en';

    Select 
		idfsReference as [idfsEditor]
		,Isnull(FR.[name], FR.[strDefault]) As [Name]
		,Case idfsReference
			When 10067008/*'editText'*/ Then 0
			When 10067002/*'editCombo'*/ Then 1
			When 10067001/*'editCheck'*/ Then 2
			When 10067003/*'editDate'*/ Then 3
			When 10067004/*'editDateTime'*/ Then 4
			When 10067006/*'editMemo'*/ Then 5
			When 10067009/*'editUpDown'*/ Then 6
		End As [intEditor]
	From fnReference(@LangID, 19000067 /*'rftParameterEditorType'*/) as FR	
    
	-- ненужные отсекаем
    --Where
    --idfsEditorID In ('editText', 'editCombo',	'editCheck', 'editDate', 'editDateTime','editMemo','editTextIntOnly')
End
Go
