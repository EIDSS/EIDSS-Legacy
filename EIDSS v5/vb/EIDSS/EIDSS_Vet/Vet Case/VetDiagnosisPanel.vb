Imports System.ComponentModel
Imports EIDSS.model.Enums

Public Class VetDiagnosisPanel
    Public VetDiagnosisDbService As VetCase_DB
    Private Sub InitCustomMandatoryFields()
        MandatoryFieldHelper.SetCustomMandatoryField(dtTentativeDiagnosis1Date, CustomMandatoryField.VetCase_TentativeDiagnosisDate)
        MandatoryFieldHelper.SetCustomMandatoryField(dtTentativeDiagnosis2Date, CustomMandatoryField.VetCase_TentativeDiagnosis1Date)
        MandatoryFieldHelper.SetCustomMandatoryField(dtTentativeDiagnosis3Date, CustomMandatoryField.VetCase_TentativeDiagnosis2Date)
        MandatoryFieldHelper.SetCustomMandatoryField(dtFinalDiagnosisDate, CustomMandatoryField.VetCase_FinalDiagnosisDate)
        MandatoryFieldHelper.SetCustomMandatoryField(cbTentativeDiagnosis1, CustomMandatoryField.VetCase_TentativeDiagnosisDate)
        MandatoryFieldHelper.SetCustomMandatoryField(cbTentativeDiagnosis2, CustomMandatoryField.VetCase_TentativeDiagnosis1Date)
        MandatoryFieldHelper.SetCustomMandatoryField(cbTentativeDiagnosis3, CustomMandatoryField.VetCase_TentativeDiagnosis2Date)
        MandatoryFieldHelper.SetCustomMandatoryField(cbFinalDiagnosis, CustomMandatoryField.VetCase_FinalDiagnosisDate)
        MandatoryFieldHelper.SetCustomMandatoryField(cbFinalDiagnosis, CustomMandatoryField.VetCase_FinalDiagnosis)
        MandatoryFieldHelper.SetCustomMandatoryField(cbTentativeDiagnosis1, CustomMandatoryField.VetCase_TentativeDiagnosis)
        MandatoryFieldHelper.SetCustomMandatoryField(cbTentativeDiagnosis2, CustomMandatoryField.VetCase_Tentative1Diagnosis)
        MandatoryFieldHelper.SetCustomMandatoryField(cbTentativeDiagnosis3, CustomMandatoryField.VetCase_Tentative2Diagnosis)
        MandatoryFieldHelper.SetCustomMandatoryField(cbFinalDiagnosis, CustomMandatoryField.VetCase_FinalDiagnosis)

    End Sub

    Protected Overrides Sub DefineBinding()
        Dim LookupID As LookupTables
        If Me.CaseKind = CaseType.Avian Then
            LookupID = LookupTables.AvianStandardDiagnosis
        Else
            LookupID = LookupTables.LivestockStandardDiagnosis
        End If
        Core.LookupBinder.BindDiagnosisHACodeLookup(cbTentativeDiagnosis1, baseDataSet, LookupID, VetCase_DB.TableVetCase + ".idfsTentativeDiagnosis", True, True)
        Core.LookupBinder.BindDiagnosisHACodeLookup(cbTentativeDiagnosis2, baseDataSet, LookupID, VetCase_DB.TableVetCase + ".idfsTentativeDiagnosis1", True, True)
        Core.LookupBinder.BindDiagnosisHACodeLookup(cbTentativeDiagnosis3, baseDataSet, LookupID, VetCase_DB.TableVetCase + ".idfsTentativeDiagnosis2", True, True)
        Core.LookupBinder.BindDiagnosisHACodeLookup(cbFinalDiagnosis, baseDataSet, LookupID, VetCase_DB.TableVetCase + ".idfsFinalDiagnosis", True, True)

        Core.LookupBinder.BindTextEdit(txtTentativeDiagnosis1OIECode, baseDataSet, VetCase_DB.TableVetCase + ".strTentativeDiagnosisOIECode")
        Core.LookupBinder.BindTextEdit(txtTentativeDiagnosis2OIECode, baseDataSet, VetCase_DB.TableVetCase + ".strTentativeDiagnosis1OIECode")
        Core.LookupBinder.BindTextEdit(txtTentativeDiagnosis3OIECode, baseDataSet, VetCase_DB.TableVetCase + ".strTentativeDiagnosis2OIECode")
        Core.LookupBinder.BindTextEdit(txtFinalDiagnosisOIECode, baseDataSet, VetCase_DB.TableVetCase + ".strFinalDiagnosisOIECode")

        Core.LookupBinder.BindDateEdit(dtTentativeDiagnosis1Date, baseDataSet, VetCase_DB.TableVetCase + ".datTentativeDiagnosisDate")
        Core.LookupBinder.BindDateEdit(dtTentativeDiagnosis2Date, baseDataSet, VetCase_DB.TableVetCase + ".datTentativeDiagnosis1Date")
        Core.LookupBinder.BindDateEdit(dtTentativeDiagnosis3Date, baseDataSet, VetCase_DB.TableVetCase + ".datTentativeDiagnosis2Date")
        Core.LookupBinder.BindDateEdit(dtFinalDiagnosisDate, baseDataSet, VetCase_DB.TableVetCase + ".datFinalDiagnosisDate")


        ResetCurrentDiagnoses()
        eventManager.AttachDataHandler(VetCase_DB.TableVetCase + ".idfsTentativeDiagnosis", AddressOf Diagnoses_Changed)
        eventManager.AttachDataHandler(VetCase_DB.TableVetCase + ".idfsTentativeDiagnosis1", AddressOf Diagnoses_Changed)
        eventManager.AttachDataHandler(VetCase_DB.TableVetCase + ".idfsTentativeDiagnosis2", AddressOf Diagnoses_Changed)
        eventManager.AttachDataHandler(VetCase_DB.TableVetCase + ".idfsFinalDiagnosis", AddressOf Diagnoses_Changed)
        eventManager.AttachDataHandler(VetCase_DB.TableVetCase + ".datTentativeDiagnosisDate", AddressOf Diagnoses_Changed)
        eventManager.AttachDataHandler(VetCase_DB.TableVetCase + ".datTentativeDiagnosis1Date", AddressOf Diagnoses_Changed)
        eventManager.AttachDataHandler(VetCase_DB.TableVetCase + ".datTentativeDiagnosis2Date", AddressOf Diagnoses_Changed)
        eventManager.AttachDataHandler(VetCase_DB.TableVetCase + ".datFinalDiagnosisDate", AddressOf Diagnoses_Changed)
    End Sub
    Public Event DiagnosisChanged()
    Private m_CurrentDiagnosesID As Long = -1
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property CurrentDiagnosesID() As Long
        Get
            Return m_CurrentDiagnosesID
        End Get
    End Property

    Private m_CurrentDiseaseCode As String = ""
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property CurrentDiseaseCode() As String
        Get
            Return m_CurrentDiseaseCode
        End Get
    End Property

    Private m_CurrentDiagnosesName As String = ""
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property CurrentDiagnosesName() As String
        Get
            Return m_CurrentDiagnosesName
        End Get
    End Property
    Public Sub Diagnoses_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Dim codeFieldName As String = ""
        Dim dateFieldName As String = ""

        Select Case e.Column.ColumnName
            Case "idfsFinalDiagnosis"
                codeFieldName = "strFinalDiagnosisOIECode"
                dateFieldName = "datFinalDiagnosisDate"
            Case "idfsTentativeDiagnosis"
                codeFieldName = "strTentativeDiagnosisOIECode"
                dateFieldName = "datTentativeDiagnosisDate"
            Case "idfsTentativeDiagnosis1"
                codeFieldName = "strTentativeDiagnosis1OIECode"
                dateFieldName = "datTentativeDiagnosis1Date"
            Case "idfsTentativeDiagnosis2"
                codeFieldName = "strTentativeDiagnosis2OIECode"
                dateFieldName = "datTentativeDiagnosis2Date"
        End Select
        If codeFieldName = "" Then
            Return
        End If
        Dim DiagnosesName As String = Nothing
        CurrentRow(codeFieldName) = GetDiseaseCode(e.Value, DiagnosesName)
        If e.Value Is DBNull.Value Then
            CurrentRow(dateFieldName) = DBNull.Value
        ElseIf CurrentRow(dateFieldName) Is DBNull.Value Then
            CurrentRow(dateFieldName) = DefaultDiagnosisDate
        End If
        ResetCurrentDiagnoses()
        CurrentRow.EndEdit()
    End Sub

    Private m_AllDiagnoses As String
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property AllDiagnoses() As String
        Get
            m_AllDiagnoses = ""
            CheckDiagnosisName(CurrentRow("idfsFinalDiagnosis"))

            Dim DiagList As New ArrayList
            Dim LastDiagnosisDate As DateTime = DateTime.MinValue
            Dim PrevDiagnosisDate As DateTime = DateTime.MinValue
            Dim CurDiagnosisDate As DateTime = DateTime.MinValue

            If Not CurrentRow("idfsTentativeDiagnosis2") Is DBNull.Value Then
                DiagList.Add(CurrentRow("idfsTentativeDiagnosis2"))
                If Not CurrentRow("datTentativeDiagnosis2Date") Is DBNull.Value Then
                    LastDiagnosisDate = CType(CurrentRow("datTentativeDiagnosis2Date"), DateTime).Date
                End If
            End If
            If Not CurrentRow("idfsTentativeDiagnosis1") Is DBNull.Value Then
                If Not CurrentRow("datTentativeDiagnosis1Date") Is DBNull.Value Then
                    CurDiagnosisDate = CType(CurrentRow("datTentativeDiagnosis1Date"), DateTime).Date
                End If
                If CurDiagnosisDate > LastDiagnosisDate Then
                    DiagList.Insert(0, CurrentRow("idfsTentativeDiagnosis1"))
                    PrevDiagnosisDate = LastDiagnosisDate
                    LastDiagnosisDate = CurDiagnosisDate
                Else
                    DiagList.Add(CurrentRow("idfsTentativeDiagnosis1"))
                    PrevDiagnosisDate = CurDiagnosisDate
                End If
            End If
            If Not CurrentRow("idfsTentativeDiagnosis") Is DBNull.Value Then
                If Not CurrentRow("datTentativeDiagnosisDate") Is DBNull.Value Then
                    CurDiagnosisDate = CType(CurrentRow("datTentativeDiagnosisDate"), DateTime).Date
                Else
                    CurDiagnosisDate = DateTime.MinValue
                End If
                If CurDiagnosisDate > LastDiagnosisDate Then
                    DiagList.Insert(0, CurrentRow("idfsTentativeDiagnosis"))
                ElseIf CurDiagnosisDate > PrevDiagnosisDate Then
                    DiagList.Insert(1, CurrentRow("idfsTentativeDiagnosis"))
                Else
                    DiagList.Add(CurrentRow("idfsTentativeDiagnosis"))
                End If
            End If

            For Each it As Long In DiagList
                CheckDiagnosisName(it)
            Next
            
            Return m_AllDiagnoses
        End Get
    End Property

    Private Sub CheckDiagnosisName(ByVal diagnosisId As Object)
        If Utils.IsEmpty(diagnosisId) Then
            Return
        End If
        Dim DiseaseName As String = ""
        GetDiseaseCode(CLng(diagnosisId), DiseaseName)

        If Utils.IsEmpty(DiseaseName) Then
            Return
        End If
        If m_AllDiagnoses = "" Then
            m_AllDiagnoses = DiseaseName
        Else
            m_AllDiagnoses += ", " + DiseaseName
        End If

    End Sub

    Private m_DiagnosesList As New ArrayList
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property DiagnosisList() As Long()
        Get
            m_DiagnosesList.Clear()
            If Not CurrentRow("idfsFinalDiagnosis") Is DBNull.Value Then
                m_DiagnosesList.Add(CurrentRow("idfsFinalDiagnosis"))
            End If
            If Not CurrentRow("idfsTentativeDiagnosis2") Is DBNull.Value Then
                m_DiagnosesList.Add(CurrentRow("idfsTentativeDiagnosis2"))
            End If
            If Not CurrentRow("idfsTentativeDiagnosis1") Is DBNull.Value Then
                m_DiagnosesList.Add(CurrentRow("idfsTentativeDiagnosis1"))
            End If
            If Not CurrentRow("idfsTentativeDiagnosis") Is DBNull.Value Then
                m_DiagnosesList.Add(CurrentRow("idfsTentativeDiagnosis"))
            End If
            Return CType(m_DiagnosesList.ToArray(GetType(Long)), Long())
        End Get
    End Property
    Private Sub CheckCurrentDiagnosis(ByVal diagnosisFieldName As String, ByVal dateFieldName As String, ByRef currentDate As DateTime)
        If Not CurrentRow(diagnosisFieldName) Is DBNull.Value Then
            If (m_CurrentDiagnosesID = -1) OrElse _
                (Not CurrentRow(dateFieldName) Is DBNull.Value AndAlso _
                CType(CurrentRow(dateFieldName), DateTime) >= currentDate) Then
                m_CurrentDiagnosesID = CLng(CurrentRow(diagnosisFieldName))
                If Not CurrentRow(dateFieldName) Is DBNull.Value Then
                    currentDate = CType(CurrentRow(dateFieldName), DateTime)
                End If
            End If
        End If
    End Sub
    Public Function ResetCurrentDiagnoses() As Long
        Dim m_OldDiagnosis As Long = m_CurrentDiagnosesID
        m_CurrentDiagnosesID = -1
        If Not CurrentRow("idfsFinalDiagnosis") Is DBNull.Value Then
            m_CurrentDiagnosesID = CLng(CurrentRow("idfsFinalDiagnosis"))
        Else
            Dim curDate As DateTime = DateTime.MinValue
            CheckCurrentDiagnosis("idfsTentativeDiagnosis2", "datTentativeDiagnosis2Date", curDate)
            CheckCurrentDiagnosis("idfsTentativeDiagnosis1", "datTentativeDiagnosis1Date", curDate)
            CheckCurrentDiagnosis("idfsTentativeDiagnosis", "datTentativeDiagnosisDate", curDate)
        End If
        If m_CurrentDiagnosesID <> m_OldDiagnosis Then
            m_CurrentDiseaseCode = GetDiseaseCode(m_CurrentDiagnosesID, m_CurrentDiagnosesName)
        End If
        If m_CurrentDiagnosesID <> -1 Then
            CurrentRow("idfsShowDiagnosis") = m_CurrentDiagnosesID
        Else
            CurrentRow("idfsShowDiagnosis") = DBNull.Value
        End If
        RaiseEvent DiagnosisChanged()
        Return m_CurrentDiagnosesID
    End Function
    Private Function GetDiseaseCode(ByVal diagnosesID As Object, ByRef DiagnosesName As String) As String
        If diagnosesID Is DBNull.Value Then
            DiagnosesName = ""
            Return ""
        End If
        If Me.CaseKind = CaseType.Avian Then
            DiagnosesName = LookupCache.GetLookupValue(diagnosesID, LookupTables.AvianStandardDiagnosis.ToString, "Name")
            Return LookupCache.GetLookupValue(diagnosesID, LookupTables.AvianStandardDiagnosis.ToString, "strOIECode")
        Else
            DiagnosesName = LookupCache.GetLookupValue(diagnosesID, LookupTables.LivestockStandardDiagnosis.ToString, "Name")
            Return LookupCache.GetLookupValue(diagnosesID, LookupTables.LivestockStandardDiagnosis.ToString, "strOIECode")
        End If
    End Function
    Private m_CaseKind As CaseType = CaseType.Livestock
    Property CaseKind() As CaseType
        Get
            Return m_CaseKind
        End Get
        Set(ByVal Value As CaseType)
            m_CaseKind = Value
        End Set
    End Property
    Private m_DefaultDiagnosisDate As DateTime = DateTime.MinValue
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property DefaultDiagnosisDate() As DateTime
        Get
            If m_DefaultDiagnosisDate = DateTime.MinValue Then
                Return DateTime.Now
            Else
                Return m_DefaultDiagnosisDate
            End If
        End Get
        Set(ByVal value As DateTime)
            m_DefaultDiagnosisDate = value
        End Set
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Private ReadOnly Property CurrentRow() As DataRow
        Get
            Return baseDataSet.Tables(VetCase_DB.TableVetCase).Rows(0)
        End Get
    End Property
    Public Overrides Function ValidateData() As Boolean
        If Not bv.winclient.Core.WinUtils.CompareDates(CurrentRow("datTentativeDiagnosisDate"), DateTime.Today, "datTentativeDiagnosisDate_CurrentDate_msgId") Then
            dtTentativeDiagnosis1Date.Focus()
            Return False
        End If
        If Not bv.winclient.Core.WinUtils.CompareDates(CurrentRow("datTentativeDiagnosis1Date"), DateTime.Today, "datTentativeDiagnosis1Date_CurrentDate_msgId") Then
            dtTentativeDiagnosis2Date.Focus()
            Return False
        End If
        If Not bv.winclient.Core.WinUtils.CompareDates(CurrentRow("datTentativeDiagnosis2Date"), DateTime.Today, "datTentativeDiagnosis2Date_CurrentDate_msgId") Then
            dtTentativeDiagnosis3Date.Focus()
            Return False
        End If
        If Not bv.winclient.Core.WinUtils.CompareDates(CurrentRow("datTentativeDiagnosis1Date"), CurrentRow("datTentativeDiagnosis2Date"), "datTentativeDiagnosis2Date_datTentativeDiagnosis1Date_msgId") Then
            dtTentativeDiagnosis3Date.Focus()
            Return False
        End If
        If Not bv.winclient.Core.WinUtils.CompareDates(CurrentRow("datTentativeDiagnosisDate"), CurrentRow("datTentativeDiagnosis2Date"), "datTentativeDiagnosisDate_datTentativeDiagnosis2Date_msgId") Then
            dtTentativeDiagnosis3Date.Focus()
            Return False
        End If
        If Not bv.winclient.Core.WinUtils.CompareDates(CurrentRow("datTentativeDiagnosisDate"), CurrentRow("datTentativeDiagnosis1Date"), "datTentativeDiagnosisDate_datTentativeDiagnosis2Date_msgId") Then
            dtTentativeDiagnosis2Date.Focus()
            Return False
        End If

        Return MyBase.ValidateData()
    End Function
    <System.ComponentModel.Browsable(False), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property ValidationDate As Object
        Get
            If (CurrentRow Is Nothing) Then
                Return DBNull.Value
            End If

            If Not CurrentRow("datTentativeDiagnosisDate") Is DBNull.Value Then
                Return CurrentRow("datTentativeDiagnosisDate")
            End If
            If Not CurrentRow("datTentativeDiagnosis1Date") Is DBNull.Value Then
                Return CurrentRow("datTentativeDiagnosis1Date")
            End If
            If Not CurrentRow("datTentativeDiagnosis2Date") Is DBNull.Value Then
                Return CurrentRow("datTentativeDiagnosis2Date")
            End If
            Return DBNull.Value
        End Get
    End Property
    <System.ComponentModel.Browsable(False), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property DateForValidationType As ValidationDateType
        Get
            If (CurrentRow Is Nothing) Then
                Return ValidationDateType.None
            End If

            If Not CurrentRow("datTentativeDiagnosisDate") Is DBNull.Value Then
                Return ValidationDateType.TentantiveDiagnosis1
            End If
            If Not CurrentRow("datTentativeDiagnosis1Date") Is DBNull.Value Then
                Return ValidationDateType.TentantiveDiagnosis2
            End If
            If Not CurrentRow("datTentativeDiagnosis2Date") Is DBNull.Value Then
                Return ValidationDateType.TentantiveDiagnosis3
            End If

            Return ValidationDateType.None
        End Get
    End Property

End Class
