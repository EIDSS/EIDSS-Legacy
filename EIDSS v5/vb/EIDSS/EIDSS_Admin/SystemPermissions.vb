Imports BV.winclient.BasePanel
Imports BV.winclient.Core

Public Class SystemPermissions

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Service = New SystemPermissions_DB
        Me.PermissionObject = eidss.model.Enums.EIDSSPermissionObject.SystemFunction
        Me.DbService = Service
    End Sub

    Private Shared m_Parent As Control
    Private Service As SystemPermissions_DB
    Public Shared Sub Register(ByVal ParentControl As System.Windows.Forms.Control)
        If (BaseFormManager.ArchiveMode) Then
            Return
        End If
        m_Parent = ParentControl
        Dim ma As MenuAction = New MenuAction(AddressOf ShowMe, MenuActionManager.Instance, MenuActionManager.Instance.Security, "MenuSystemFunction", 1015, False, model.Enums.MenuIconsSmall.SystemFunctions, -1)
        ma.SelectPermission = PermissionHelper.SelectPermission(eidss.model.Enums.EIDSSPermissionObject.SystemFunction)
    End Sub

    Public Shared Sub ShowMe()
        BaseFormManager.ShowClient(New SystemPermissions, m_Parent, Nothing)
    End Sub

    Protected Overrides Sub DefineBinding()
        ''Me.GridView1.d.DataSource = Me.baseDataSet.Tables(0)
        Me.GridControl1.DataSource = Me.baseDataSet.Tables(0)
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click

        If Me.GridView1.SelectedRowsCount <> 1 Then Exit Sub
        If LockHandler() Then
            Try
                Dim handle As Integer
                handle = Me.GridView1.FocusedRowHandle
                If Me.GridView1.IsValidRowHandle(handle) <> True Then Exit Sub
                Dim row As DataRowView = CType(Me.GridView1.GetRow(handle), DataRowView)
                Dim type As ObjectType = CType(row("idfsObjectType"), ObjectType)
                Dim id As Object = row("idfsSystemFunction")

                Dim dlg As BaseDetailForm = Nothing
                Dim dummy As Object = ClassLoader.LoadClass("ObjectAccessDetail")
                If (Not dummy Is Nothing) Then
                    dlg = CType(dummy, BaseDetailForm)
                End If
                'Set required property "ObjectType"
                If Not dlg Is Nothing Then
                    Dim pi As System.Reflection.PropertyInfo
                    pi = dlg.GetType().GetProperty("ObjectType")
                    pi.SetValue(dlg, type, Nothing)
                    'pi = dlg.GetType().GetProperty("ObjectID")
                    'pi.SetValue(dlg, id, Nothing)
                    BaseFormManager.ShowModal(dlg, FindForm, id, Nothing, Nothing)
                End If

            Finally
                UnlockHandler()
            End Try

        End If
    End Sub

    Private Sub GridControl1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick
        If SimpleButton2.Enabled = False Then Exit Sub
        SimpleButton2_Click(sender, e)
    End Sub
End Class