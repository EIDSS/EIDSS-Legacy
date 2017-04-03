Imports System.IO
Imports bv.winclient.Core
Imports EIDSS.model.Resources
Imports bv.common.Resources

Public Class PaperFormsLoader
    Inherits BaseForm
    Const FileMask As String = "*.pdf"

    Public Shared ReadOnly Property PaperFormDirectory() As String
        Get
            Return String.Format("{0}\Paper Forms\{1}\", Application.StartupPath, bv.model.Model.Core.ModelUserContext.CurrentLanguage)
        End Get
    End Property

    Public Shared Sub Register(ByVal ParentControl As Control)

        If Directory.Exists(PaperFormDirectory) Then

            Dim files As String() = Directory.GetFiles(PaperFormDirectory, FileMask)
            If files.Length > 0 Then
                Dim permissionString As String = PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.Report)
                Dim category As MenuAction = AddCategory("MenuPaperForms")
                Dim fileName As String
                For Each fileName In files
                    AddPaperFormMenu(GetPaperFormName(fileName), GetFileName(fileName), permissionString, category)
                Next
            End If
        End If

    End Sub

    Private Shared Sub AddPaperFormMenu(ByVal formName As String, ByVal fileName As String, _
                                         ByVal permissions As String, ByVal category As MenuAction)
        Dim ma As MenuAction = New MenuAction(AddressOf PaperFormHandler, MenuActionManager.Instance, category, formName, -1)
        ma.Caption = formName
        ma.Name = "btn" + fileName
        ma.SelectPermission = permissions
    End Sub

    Private Shared Function AddCategory(ByVal categoryName As String) As MenuAction
        Utils.CheckNotNullOrEmpty(categoryName, "categoryName")

        Dim ma As MenuAction = New MenuAction(MenuActionManager.Instance, MenuActionManager.Instance.Reports, categoryName, -1)
        ma.Name = "btn" + categoryName
        Return ma
    End Function

    Private Shared Function GetPaperFormName(ByVal fileName As String) As String
        Utils.CheckNotNullOrEmpty(fileName, "fileName")

        If fileName.Contains("General Case Investigation Form") Then
            Return EidssMessages.Get("msgHumCaseForm")
        End If

        If fileName.Contains("Investigation Form For Avian Disease Outbreaks") Then
            Return EidssMessages.Get("msgAvianCaseForm")
        End If

        If fileName.Contains("Investigation Form For Livestock Disease Outbreaks") Then
            Return EidssMessages.Get("msgLivestockCaseForm")
        End If

        Dim startPosition As Integer = fileName.LastIndexOf("\")
        Dim endPosition As Integer = fileName.LastIndexOf(".")
        Dim st As String = fileName.Substring(startPosition + 1, endPosition - startPosition - 1)

        Return st

    End Function

    Private Shared Function GetFileName(ByVal fileName As String) As String
        Utils.CheckNotNullOrEmpty(fileName, "fileName")

        Dim position As Integer = fileName.LastIndexOf("\")
        Dim st As String = fileName.Substring(position + 1, fileName.Length - position - 1)
        Return st
    End Function

    Private Shared Sub PaperFormHandler(ByVal action As MenuAction)
        Utils.CheckNotNull(action, "action")

        Dim fileName As String = action.Name.Substring(3, action.Name.Length - 3)
        Try
            Process.Start(PaperFormDirectory + fileName)
        Catch ex As Exception
            bv.common.Trace.WriteLine(ex)
            win.ErrorForm.ShowError(New ErrorMessage("msgCannotShowReport", ex))
        End Try

    End Sub
End Class
