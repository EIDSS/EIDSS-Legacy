Imports bv.common.win
Imports EIDSS.model.Core
Imports EIDSS
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports bv.winclient.BasePanel
Imports EIDSS.model.Enums


Public Class LabUtils
    <CLSCompliantAttribute(False)>
    Public Shared Function ShowCase(ByRef parent As Control, ByRef id As Object, ByVal type As Object, ByVal sessionType As SessionType) As Boolean
        If (Utils.IsEmpty(id) Or type Is Nothing) Then Exit Function
        Dim detail As IApplicationForm = Nothing

        If (sessionType = sessionType.AsSession) Then
            detail = CType(ClassLoader.LoadClass("AsSessionDetail"), IApplicationForm)
        ElseIf (sessionType = sessionType.VsSession) Then
            detail = CType(ClassLoader.LoadClass("VsSessionDetail"), IApplicationForm)
        Else
            Dim typeString As String = type.ToString()
            If typeString = CType(CaseType.Livestock, Integer).ToString() Then
                detail = CType(ClassLoader.LoadClass("VetCaseLiveStockDetail"), IApplicationForm)
            End If
            If typeString = CType(CaseType.Avian, Integer).ToString() Then
                detail = CType(ClassLoader.LoadClass("VetCaseAvianDetail"), IApplicationForm)
            End If
            If typeString = CType(CaseType.Human, Integer).ToString() Then
                detail = CType(ClassLoader.LoadClass("HumanCaseDetail"), IApplicationForm)
                ReflectionHelper.SetProperty(detail, "ShowNavigators", False)
            End If
        End If
        If detail Is Nothing Then Exit Function
        Return BaseFormManager.ShowModal(detail, parent, id, Nothing, Nothing)
    End Function

    Public Shared Sub ShowCase(ByRef parent As Control, ByRef row As DataRow, ByVal surveillanceMode As Boolean)
        Dim id As Object
        If row Is Nothing Then Exit Sub
        If Not row("idfMonitoringSession") Is DBNull.Value AndAlso surveillanceMode Then
            id = row("idfMonitoringSession")
            ShowCase(parent, id, True, SessionType.AsSession)
        ElseIf Not row("idfVectorSurveillanceSession") Is DBNull.Value AndAlso surveillanceMode Then
            id = row("idfVectorSurveillanceSession")
            ShowCase(parent, id, True, SessionType.VsSession)
        ElseIf Not row("idfCase") Is DBNull.Value AndAlso Not surveillanceMode Then
            id = row("idfCase")
            ShowCase(parent, id, row("idfsCaseType"), SessionType.None)
        End If
    End Sub

    Public Shared Function GetPatientInfo(ByRef row As DataRow) As String
        Dim ret As String = Utils.Str(row("SpeciesName"))
        If ret.Length > 0 Then
            ret = ret + " "
        End If
        ret = ret + Utils.Str(row("strAnimalCode"))
        If Utils.Str(row("idfsCaseType")) <> CType(CaseType.Human, Integer).ToString() Then
            Return ret
        End If
        If EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName) Then
            Return "*"
        End If
        Return Utils.Str(row("HumanName")).ToString()
    End Function

    'Public Shared Function ChangeLocation(ByRef parent As Form, ByRef row As DataRow) As Object
    '    Dim selected As DataRow() = Nothing
    '    Dim FreezerTree As BaseForm = New EIDSS.FreezerTree()
    '    selected = BaseForm.ShowForMultiSelection(FreezerTree, parent, Nothing, parent)
    '    If Not selected Is Nothing Then
    '        'Dim table As DataTable = Me.baseDataSet.Tables(Sample_DB.TableSample)
    '        'If table.Rows.Count = 0 Then table.Rows.Add(table.NewRow)
    '        'table.Rows(0)("Path") = selected(0)("Path")
    '        'table.Rows(0)("idfsSubdivision") = selected(0)("idfsSubdivision")
    '        row("Path") = selected(0)("Path")
    '        row("idfSubdivision") = selected(0)("idfSubdivision")
    '    End If
    '    Return row("Path")
    'End Function

    Public Shared Sub ShowFF(ByRef ctrl As EIDSS.FlexibleForms.FFPresenter, ByRef Determinant As Object, ByRef row As DataRow, ByVal type As EIDSS.FFType)
        If (Utils.IsEmpty(Determinant) OrElse Utils.IsEmpty(row) OrElse Not (TypeOf (row("idfObservation")) Is Long)) Then
            ctrl.Visible = False
        Else
            ctrl.ShowFlexibleFormByDeterminant(CType(Determinant, Long), CType(row("idfObservation"), Long), type)
            Dim template As Object = DBNull.Value
            If ctrl.TemplateID.HasValue Then
                template = ctrl.TemplateID.Value
            End If
            If Utils.Str(template) <> Utils.Str(row("idfsFormTemplate")) Then
                row("idfsFormTemplate") = template
            End If
            ctrl.Visible = True
        End If
        ctrl.ReadOnly = ctrl.ReadOnly
    End Sub

    Public Shared Sub BindFreezerLocation(ByVal ctrl As RepositoryItemLookUpEdit)
        ctrl.Buttons.Clear()

        ctrl.Buttons.Add(New EditorButton(ButtonPredefines.Combo))
        ctrl.Buttons(0).Visible = False
        ctrl.Buttons.Add(New EditorButton(ButtonPredefines.Ellipsis))
        Core.LookupBinder.AddClearButton(ctrl, True)

        ctrl.DataSource = LookupCache.Get(LookupTables.Repository.ToString)
        ctrl.DisplayMember = "Path"
        ctrl.ValueMember = "idfSubdivision"
        ctrl.NullText = Nothing
        ctrl.ShowDropDown = ShowDropDown.Never
        ctrl.UseCtrlScroll = False

        RemoveHandler ctrl.ButtonPressed, AddressOf ButtonPressed
        AddHandler ctrl.ButtonPressed, AddressOf ButtonPressed
    End Sub

    Public Shared Sub BindFreezerLocation(ByVal ctrl As LookUpEdit, ByVal ds As DataSet, Optional ByVal BindField As String = Nothing)
        BindFreezerLocation(ctrl.Properties)
        Core.LookupBinder.AddBinding(ctrl, ds, BindField)
    End Sub

    Protected Shared Sub ButtonPressed(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
        Dim ctrl As BaseEdit = CType(sender, BaseEdit)
        If e.Button.Kind = ButtonPredefines.Ellipsis Then
            Dim selected As DataRow() = Nothing
            Try
                Dim FreezerTree As BaseForm = CType(ClassLoader.LoadClass("FreezerTree"), BaseForm)
                If Not FreezerTree.CanViewObject() Then
                    Return
                End If
                FreezerTree.State = BusinessObjectState.SelectObject
                FreezerTree.MultiSelect = True
                Dim id As Object = ctrl.EditValue
                If BaseFormManager.ShowModal(FreezerTree, ctrl.FindForm(), id, Nothing, Nothing) Then
                    selected = FreezerTree.GetSelectedRows
                End If
            Catch ex As Exception
            End Try
            If Not selected Is Nothing Then
                ctrl.EditValue = selected(0)("idfSubdivision")

                If (TypeOf (ctrl.Parent) Is DevExpress.XtraGrid.GridControl) Then
                    CType(ctrl.Parent, DevExpress.XtraGrid.GridControl).MainView.PostEditor()
                    Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(CType(ctrl.Parent, DevExpress.XtraGrid.GridControl).MainView, DevExpress.XtraGrid.Views.Grid.GridView)
                    Dim row As DataRow = view.GetDataRow(view.FocusedRowHandle)
                    If row.Table.Columns.Contains("idfSubdivision") Then
                        row("idfSubdivision") = selected(0)("idfSubdivision")
                        row.EndEdit()
                    End If
                End If
            End If
        End If
    End Sub

End Class
