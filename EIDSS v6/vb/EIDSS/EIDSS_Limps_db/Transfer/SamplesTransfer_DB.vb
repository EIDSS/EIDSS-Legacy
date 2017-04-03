Imports bv.common.Core
Imports bv.model.Model.Core
Imports eidss.model.Enums
Imports System.Data.Common
Imports bv.common.db.Core
Imports System.Collections.Generic
Imports bv.common.Resources

Public Class SamplesTransfer_DB
    Inherits bv.common.db.BaseDbService

    Public Sub New()
        Me.ObjectName = "SampleTransfer"
    End Sub


    Public Shared Sub CopyObject(ByRef dest As DataRow, ByRef src As IObject)
        Dim columns As String() = {"idfMaterial", "strSampleName", "strBarcode"} ', "strFieldBarcode"}
        For Each col As String In columns
            dest(col) = IIf(src.GetValue(col) Is Nothing, DBNull.Value, src.GetValue(col))
        Next
    End Sub

    Public Shared Sub CopyObjects(ByRef targetTable As DataTable, sourceRows As IEnumerable(Of IObject))
        If sourceRows Is Nothing Then Exit Sub
        For Each row As IObject In sourceRows
            If Not targetTable.Rows.Find(row.Key) Is Nothing Then
                Continue For
            End If
            Dim copy As DataRow = targetTable.NewRow
            CopyObject(copy, row)
            targetTable.Rows.Add(copy)
        Next
    End Sub
    Public Overrides Function GetDetail(ByVal ID As Object) As System.Data.DataSet

        m_ID = ID

        'We can call this method in 2 situations:
        '1. Editing of existing transfer out record. In this case ID is long
        '2. Creating new transfer out from selected samples. In this case ID contains list of sample records

        Dim ds As DataSet = New DataSet()

        Dim cmd As IDbCommand = CreateSPCommand("spLabSampleTransfer_SelectDetail")
        If (TypeOf (ID) Is Long) Then
            AddParam(cmd, "@idfTransferOut", CLng(ID))
        Else
            AddParam(cmd, "@idfTransferOut", -1) 'pass fake id to get empty tables
        End If
        AddParam(cmd, "@LangID", ModelUserContext.CurrentLanguage)
        CreateAdapter(cmd).Fill(ds)
        CorrectTable(ds.Tables(0), "Transfer")
        CorrectTable(ds.Tables(1), "Containers")
        Dim transfer As DataTable = ds.Tables(0)
        Dim container As DataTable = ds.Tables(1)
        'Now add selected samples to list of trasferred samples if form was called for new transfer out creation
        If (TypeOf (ID) Is IEnumerable(Of IObject)) Then
            Dim rows As IEnumerable(Of IObject) = CType(ID, IEnumerable(Of IObject))
            CopyObjects(container, rows)
        End If
        For Each col As DataColumn In transfer.Columns
            col.AllowDBNull = True
        Next
        If transfer.Rows.Count = 0 Then
            Me.m_IsNewObject = True
            m_ID = NewIntID()
            Dim start As DataRow = transfer.NewRow
            start("idfTransferOut") = m_ID
            start("idfsTransferStatus") = TestStatus.NotStarted
            start("idfSendFromOffice") = model.Core.EidssSiteContext.Instance.OrganizationID
            start("strBarcode") = NumberingService.GetNextNumber(NumberingObject.SampleTransfer, Connection, Nothing)
            transfer.Rows.Add(start)
        End If

        Return ds
    End Function

    Protected Shared Function GetErrorText(ByRef message As String, ByVal ParamArray args() As Object) As String
        Return String.Format(BvMessages.Get(message), args)
    End Function

    Public Property ErrorList As String

    Public Overrides Function PostDetail(ByVal ds As System.Data.DataSet, ByVal PostType As Integer, Optional ByVal transaction As System.Data.IDbTransaction = Nothing) As Boolean
        Dim transferBarcode As String = ""
        Try
            ErrorList = ""
            Dim transfer As DataRow = ds.Tables("Transfer").Rows(0)
            Dim transferOut As Boolean = False
            If transfer("idfsTransferStatus").ToString = CType(TestStatus.InProcess, Long).ToString() Then
                If (transfer.RowState = DataRowState.Added) Then
                    transferOut = True
                Else
                    If transfer("idfsTransferStatus", DataRowVersion.Original).ToString = CType(TestStatus.NotStarted, Long).ToString() Then transferOut = True
                End If
            End If

            ExecPostProcedure("spLabSampleTransfer_Post", transfer, Connection, transaction)
            Dim activity As Object = transfer("idfTransferOut")
            Dim sendToOffice As Object = transfer("idfSendToOffice")
            Dim cmd As IDbCommand

            Dim container As DataTable = ds.Tables("Containers")

            For Each row As DataRow In container.Rows
                If PostType = bv.common.Enums.PostType.PerformAdditionalPosting OrElse _
                    ( _
                        transferOut And _
                        (row.RowState = DataRowState.Unchanged Or row.RowState = DataRowState.Added Or row.RowState = DataRowState.Modified) _
                    ) Then
                    Try
                        cmd = CreateSPCommand("spLabSampleTransfer_Send", transaction)
                        AddParam(cmd, "@idfMaterial", row("idfMaterial"))
                        AddParam(cmd, "@idfSendToOffice", sendToOffice)
                        AddParam(cmd, "@datSendDate", transfer("datSendDate"))
                        cmd.ExecuteNonQuery()
                    Catch e As System.Data.SqlClient.SqlException
                        Utils.AppendLine(ErrorList, HandleError.ErrorMessage(e).Text, Environment.NewLine)
                        'If e.Number = 50000 And e.Class = 16 Then
                        '    Utils.AppendLine(ErrorList, GetErrorText("errContainerTransfer", Utils.Str(row("strBarcode"))), Environment.NewLine)
                        'End If
                    End Try
                End If
                cmd = CreateSPCommand("spLabSampleTransfer_Manage", transaction)
                AddParam(cmd, "@idfTransferOut", activity)
                If row.RowState = DataRowState.Added Then
                    AddParam(cmd, "@idfMaterial", row("idfMaterial"))
                    AddParam(cmd, "@add", 1)
                    Try
                        cmd.ExecuteNonQuery()
                        AddEvent(EventType.NewSampleTransferInLocal, activity)
                    Catch e As System.Data.SqlClient.SqlException
                        Utils.AppendLine(ErrorList, HandleError.ErrorMessage(e).Text, Environment.NewLine)
                        m_Error = HandleError.ErrorMessage(e)
                        'If e.Number = 50000 And e.Class = 16 Then
                        '    Utils.AppendLine(ErrorList, GetErrorText("errSampleInTransfer", Utils.Str(row("strBarcode")), Utils.Str(e.Message)), Environment.NewLine)
                        'End If
                    End Try
                End If
                If row.RowState = DataRowState.Deleted Then
                    AddParam(cmd, "@idfMaterial", row("idfMaterial", DataRowVersion.Original))
                    AddParam(cmd, "@add", 0)
                    cmd.ExecuteNonQuery()
                End If
                If (row.RowState = DataRowState.Added Or row.RowState = DataRowState.Modified) Then
                    'transferred in material is replicated, was not accessioned at the moment af data loading
                    'and has not empty datAccession (was accessioned during this session)
                    If Not Utils.IsEmpty(row("idfMaterialForTransferIn")) AndAlso Not True.Equals(row("blnAccessioned")) AndAlso Not Utils.IsEmpty(row("datAccession")) Then
                        cmd = CreateSPCommand("spLabSampleReceive_PostDetail", transaction)
                        StoredProcParamsCache.CreateParameters(cmd)
                        SetParam(cmd, "@idfMaterial", row("idfMaterialForTransferIn"))
                        SetParam(cmd, "@strBarcode", row("strBarcodeNew"))
                        SetParam(cmd, "@datAccession", row("datAccession"))
                        SetParam(cmd, "@strCondition", row("strCondition"))
                        SetParam(cmd, "@idfsAccessionCondition", row("idfsAccessionCondition"))
                        SetParam(cmd, "@idfSubdivision", row("idfSubdivision"))
                        SetParam(cmd, "@idfDepartment", row("idfInDepartment"))
                        SetParam(cmd, "@idfAccesionByPerson", row("idfAccesionByPerson"))
                        cmd.ExecuteNonQuery()
                    End If
                End If
            Next
            If ErrorList.Length > 0 Then
                Return False
            End If
            If PostType <> bv.common.Enums.PostType.PerformAdditionalPosting Then Me.m_IsNewObject = False
            Return True
        Catch ex As Exception
            m_Error = HandleError.ErrorMessage(ex, transferBarcode)
            Return False
        End Try
    End Function

End Class
