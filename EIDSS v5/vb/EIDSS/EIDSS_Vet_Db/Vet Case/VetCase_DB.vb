Imports System.Data
Imports System.Data.Common
Imports bv.common.Core
Imports EIDSS.Enums

Public Class VetCase_DB
    Inherits BaseDbService
    Public Sub New()
        ObjectName = "VetCase"
    End Sub

    Public Const TableVetCase As String = "VetCase"
    Public Overrides Function GetDetail(ByVal ID As Object) As DataSet
        Dim ds As New DataSet
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spVetCase_SelectDetail")
            AddParam(cmd, "@idfCase", ID)
            AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)

            Dim da As DbDataAdapter = CreateAdapter(cmd)
            da.Fill(ds)
            CorrectTable(ds.Tables(0), TableVetCase)

            ds.EnforceConstraints = False
            If ID Is Nothing Then
                ID = NewIntID()
            End If
            If ds.Tables(0).Rows.Count = 0 Then
                m_IsNewObject = True
                Dim r As DataRow = ds.Tables(TableVetCase).NewRow
                r("idfCase") = ID
                r("strCaseID") = "(new)"
                r("idfFarm") = NewIntID()
                r("datEnteredDate") = DateTime.Now
                r("idfPersonEnteredBy") = EIDSS.model.Core.EidssUserContext.User.EmployeeID
                r("idfsSite") = EIDSS.model.Core.EidssSiteContext.Instance.SiteID
                r("idfsCaseType") = Me.CaseType
                r("idfsCaseProgressStatus") = CLng(CaseStatus.InProgress)
                r("idfObservation") = NewIntID()
                r("blnEnableTestsConducted") = True
                ds.Tables(TableVetCase).Rows.Add(r)
            End If
            ds.Tables(TableVetCase).Columns("strFinalDiagnosisOIECode").ReadOnly = False
            ds.Tables(TableVetCase).Columns("strTentativeDiagnosisOIECode").ReadOnly = False
            ds.Tables(TableVetCase).Columns("strTentativeDiagnosis1OIECode").ReadOnly = False
            ds.Tables(TableVetCase).Columns("strTentativeDiagnosis2OIECode").ReadOnly = False
            ds.Tables(TableVetCase).Columns("idfsFormTemplate").ReadOnly = False
            If ds.Tables(TableVetCase).Rows(0)("idfFarm") Is DBNull.Value Then
                ds.Tables(TableVetCase).Rows(0)("idfFarm") = NewIntID()
            End If
            m_ID = ID
            Return ds
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function
    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal post_Type As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            Dim row As DataRow = ds.Tables(TableVetCase).Rows(0)
            If Utils.Str(row("strCaseID")) = "" OrElse Utils.Str(row("strCaseID")) = "(new)" Then
                row("strCaseID") = NumberingService.GetNextNumber(NumberingObject.VetCase, Connection, m_Error, transaction)
            End If
            If (post_Type = PostType.FinalPosting) Then
                If IsNewObject Then
                    m_IsNewObject = False
                    AddEvent(EventType.NewVetCase)
                Else
                    If row.HasVersion(DataRowVersion.Original) Then
                        If Utils.Str(row("idfsShowDiagnosis")) <> Utils.Str(row("idfsShowDiagnosis", DataRowVersion.Original)) Then
                            AddEvent(EventType.CaseDiseaseChange)
                        End If
                        If Utils.Str(row("idfsCaseStatus")) <> Utils.Str(row("idfsCaseStatus", DataRowVersion.Original)) Then
                            AddEvent(EventType.CaseStatusChange)
                        End If
                    End If
                End If
            End If

            ExecPostProcedure("spVetCase_Post", ds.Tables(TableVetCase), Connection, transaction)
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
        Return True
    End Function

    Dim m_CaseType As CaseType = EIDSS.CaseType.Livestock
    Public Property CaseType() As CaseType
        Get
            Return m_CaseType
        End Get
        Set(ByVal Value As CaseType)
            m_CaseType = Value
        End Set
    End Property
#Region "Flex Form Support"


    Public Function GetFFTemplate(ByVal strFFormTypeID As String, ByVal strDeterminantsList As String) As String
        Dim dt As New DataTable
        Dim cmd As IDbCommand

        cmd = CreateSPCommand("dbo.sp_FF_GetFFTemplate", Connection)
        AddParam(cmd, "@FFTypeID", strFFormTypeID)
        AddParam(cmd, "@strDeterminant", strDeterminantsList)
        AddParam(cmd, "@strUniRefTypes", "")

        ' EXACTLY Template
        dt.Clear()
        FillTable(cmd, dt)
        If Not dt.Rows.Count = 0 Then
            If Not dt.Rows(0).Item(0) Is DBNull.Value Then
                Return dt.Rows(0).Item(0).ToString
            End If
        End If

        ' UNI BY DIAGNOSIS
        dt.Clear()
        SetParam(cmd, "@strUniRefTypes", "rftDiagnosis")
        FillTable(cmd, dt)
        If Not dt.Rows.Count = 0 Then
            If Not dt.Rows(0).Item(0) Is DBNull.Value Then
                Return dt.Rows(0).Item(0).ToString
            End If
        End If

        ' UNI BY Country
        dt.Clear()
        SetParam(cmd, "@strUniRefTypes", "rftCountry")
        FillTable(cmd, dt)
        If Not dt.Rows.Count = 0 Then
            If Not dt.Rows(0).Item(0) Is DBNull.Value Then
                Return dt.Rows(0).Item(0).ToString
            End If
        End If

        ' UNI BY ALL

        cmd = CreateSPCommand("dbo.sp_FF_GetFFTemplateUni", Connection)
        AddParam(cmd, "@FFTypeID", strFFormTypeID)

        dt.Clear()
        FillTable(cmd, dt)
        If Not dt.Rows.Count = 0 Then
            If Not dt.Rows(0).Item(0) Is DBNull.Value Then
                Return dt.Rows(0).Item(0).ToString
            Else
                Return ""
            End If
        End If

        Return ""
    End Function


#End Region

End Class
