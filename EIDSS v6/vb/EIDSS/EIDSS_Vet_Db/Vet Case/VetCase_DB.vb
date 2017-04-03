Imports System.Data
Imports System.Data.Common
Imports bv.common.Core
Imports bv.common.Diagnostics
Imports bv.model.Model.Core
Imports eidss.Enums
Imports EIDSS.model.Enums
Imports bv.common.Enums

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
                r("idfPersonEnteredBy") = model.Core.EidssUserContext.User.EmployeeID
                r("idfsSite") = model.Core.EidssSiteContext.Instance.SiteID
                r("idfsCaseType") = CaseType
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
            ds.Tables(TableVetCase).Columns("idfsShowDiagnosis").ReadOnly = False
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
    Public Overrides Function PostDetail(ByVal ds As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        If ds Is Nothing Then Return True
        Try
            Dim row As DataRow = ds.Tables(TableVetCase).Rows(0)
            If Utils.Str(row("strCaseID")) = "" OrElse Utils.Str(row("strCaseID")) = "(new)" Then
                row("strCaseID") = NumberingService.GetNextNumber(NumberingObject.VetCase, Connection, m_Error, transaction)
            End If
            If (postType = bv.common.Enums.PostType.FinalPosting) Then
                If IsNewObject Then
                    m_IsNewObject = False
                    AddEvent(EventType.VetCaseCreatedLocal)
                Else
                    If row.HasVersion(DataRowVersion.Original) Then
                        If Utils.Str(row("idfsShowDiagnosis")) <> Utils.Str(row("idfsShowDiagnosis", DataRowVersion.Original)) Then
                            AddEvent(EventType.VetCaseDiagnosisChangedLocal)
                        End If
                        If Utils.Str(row("idfsCaseClassification")) <> Utils.Str(row("idfsCaseClassification", DataRowVersion.Original)) Then
                            AddEvent(EventType.VetCaseClassificationChangedLocal)
                        End If
                        If (Not row("idfOutbreak") Is DBNull.Value AndAlso Not row("idfOutbreak").Equals(row("idfOutbreak", DataRowVersion.Original))) Then
                            AddEvent(EventType.NewVetCaseAddedToOutbreakLocal)
                        End If
                        If CLng(CaseStatusEnum.Closed).Equals(row("idfsCaseProgressStatus", DataRowVersion.Original)) AndAlso CLng(CaseStatusEnum.InProgress).Equals(row("idfsCaseProgressStatus")) Then
                            AddEvent(EventType.ClosedVetCaseReopenedLocal)
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

    Dim m_CaseType As CaseType = CaseType.Livestock
    Public Property CaseType() As CaseType
        Get
            Return m_CaseType
        End Get
        Set(ByVal value As CaseType)
            m_CaseType = value
        End Set
    End Property


    Public Function CheckOutbreakDiagnosis(ByVal idfCase As Object, ByVal idfOutbreak As Object) As Long
        Dim err As ErrorMessage = Nothing
        Try
            Dim cmd As IDbCommand = BaseDbService.CreateCommand("select dbo.fnIsCaseSessionDiagnosesInGroupOutbreak(@idfCase, @idfOutbreak)", Connection)
            AddParam(cmd, "@idfCase", idfCase)
            AddParam(cmd, "@idfOutbreak", idfOutbreak)
            Return CLng(BaseDbService.ExecScalar(cmd, Connection, err, , True))
        Catch ex As Exception
            Dbg.Debug("error during fnIsCaseSessionDiagnosesInGroupOutbreak call: {0}", ex)
            Return CLng(0)
        End Try
    End Function

    Public Sub ChangeOutbreakDiagnosis(ByVal idfOutbreak As Object, ByVal idfsDiagnosisGroup As Object)
        Try
            Dim cmd As IDbCommand = BaseDbService.CreateSPCommandWithParams("spOutbreak_Diagnosis_Update", Connection)
            AddParam(cmd, "@idfOutbreak", idfOutbreak)
            AddParam(cmd, "@idfsDiagnosisGroup", idfsDiagnosisGroup)
            BaseDbService.ExecCommand(cmd, Connection)
        Catch ex As Exception
            Dbg.Debug("error during spOutbreak_Diagnosis_Update call: {0}", ex)
        End Try
    End Sub

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
