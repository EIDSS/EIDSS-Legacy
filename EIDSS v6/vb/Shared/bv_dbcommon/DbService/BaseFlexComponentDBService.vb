Imports System.Data.Common
Imports bv.common.db.Core
Imports bv.common.Enums

Public Class BaseFlexComponentDBService
    Inherits BaseDbService

#Region "POST"

    ' Overriden Method
    Public Overrides Function PostDetail(ByVal dataSet As DataSet, ByVal postType As Integer, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Dim cont As Boolean = True
        Dim res As Boolean
        RaiseEvent SaveInitiated(cont)

        If cont Then
            res = PostAll(transaction)
        End If

        Return res
    End Function

    ' > Form/Flex
    ' Save Data for one Flexibel Form
    Public Overridable Function PostDataTable(ByRef FFObjectID As FlexibeFormObject, Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Return Nothing
    End Function

    ' Save Sata for all Flexible Forms in Hashtable
    Public Function PostAll(Optional ByVal transaction As IDbTransaction = Nothing) As Boolean
        Try
            For Each obj As Object In Me.m_ObjectsHash.Values
                Dim ffObject As FlexibeFormObject = CType(obj, FlexibeFormObject)

                If ffObject.CustomTemplateID <> "" Then
                    RemoveNonTemplateNullValues(ffObject)
                End If
                If PostDataTable(ffObject, transaction) = False Then
                    Return False
                End If
            Next
            Return True
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.PostError, ex)
            Return False
        End Try
    End Function


#End Region


#Region "FF OBJECT"
    ' Class for FF Object
    Public Class FlexibeFormObject
        Public ObjectId As String
        Public TableName As String
        Public TemplateID As String
        Public CustomTemplateID As String
        '-----
        Public Table As DataTable
        Public FlexTable As DataTable
        Public RemovedRows As ArrayList ' Array of removed rows
        Public FlexComponentType As enFlexComponentType

        Public Enum enFlexComponentType
            FlexForm = 0
            FlexGrid = 1
        End Enum

        Public Sub New(ByVal aObjectID As String, ByVal aTemplateID As String, ByVal aTableName As String, Optional ByVal aCustomTemplateID As String = "")
            ObjectId = aObjectID
            TemplateID = aTemplateID
            TableName = aTableName
            CustomTemplateID = aCustomTemplateID
            FlexComponentType = enFlexComponentType.FlexForm
            RemovedRows = New ArrayList
        End Sub

        Public Sub New(ByVal aObjectID As String, ByVal aTemplateID As String, ByVal aTableName As String, ByVal FCT As enFlexComponentType)
            ObjectId = aObjectID
            TemplateID = aTemplateID
            TableName = aTableName
            FlexComponentType = FCT
            RemovedRows = New ArrayList
        End Sub

        Public Function GetHashKey() As String
            Return ObjectId
            'Return GetHashKey(ObjectId, TemplateID, TableName)
        End Function
        'Public Shared Function GetHashKey(ByVal aObjectID As Object, ByVal aTemplateID As String, ByVal aTableName As String) As String
        '    Return Utils.Str(aObjectID) + aTemplateID + aTableName
        'End Function

    End Class
#End Region

#Region "FF RULES"

    ' Get Rule Message
    Public Function GetRuleMessage(ByVal MsgID As String) As String
        Dim err As ErrorMessage = Nothing

        Dim cmd As IDbCommand = CreateCommand("select [name] from dbo.fnReference(@Lang,'rftFFRuleMessage') where idfsReference=@MsgID", Connection)
        AddParam(cmd, "@Lang", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
        AddParam(cmd, "@MsgID", MsgID)

        Return ExecScalar(cmd, Connection, err).ToString

    End Function

    ' Table FFRule
    Public Function GetRuleTableForTemplate(ByVal TempID As String) As DataTable
        Dim dt As New DataTable("FFRule")
        Dim cmd As IDbCommand = CreateCommand("select * from FFRule where idfsFFormTemplateID=@TempID", Connection)
        AddParam(cmd, "@TempID", TempID)

        FillTable(cmd, dt)

        Return dt
    End Function

    ' Table FFRuleFunc
    Public Function GetFFRuleFuncTableForTemplate(ByVal RuleID As String) As DataTable
        Dim dt As New DataTable("FFRuleFunc")
        Dim cmd As IDbCommand = CreateSPCommand("sp_FFD_GetRuleParameters", Connection)
        AddParam(cmd, "@RuleID", RuleID)

        FillTable(cmd, dt)

        Return dt

    End Function

    ' Table FFParForAction
    Public Function GetFFRuleParForActionTableForTemplate(ByVal RuleID As String) As DataTable
        Dim dt As New DataTable("FFParForAction")
        Dim cmd As IDbCommand = CreateCommand("select * from dbo.ParameterForAction where idfsFFRuleID=@RuleID", Connection)
        AddParam(cmd, "@RuleID", RuleID)

        FillTable(cmd, dt)

        Return dt

    End Function

#End Region

#Region "EVENTS"
    Public Event SaveInitiated(ByRef [Continue] As Boolean)
#End Region

#Region "USER DATA"

    ' HashTable for several FF Objects
    Public m_ObjectsHash As New Hashtable

#End Region

#Region "PROPERTIES"

    ' Current/Active ObjectID
    Private prpCurrentFFObjectID As FlexibeFormObject
    Public Property CurrentFFObjectID() As FlexibeFormObject
        Get
            Return prpCurrentFFObjectID
        End Get
        Set(ByVal Value As FlexibeFormObject)
            prpCurrentFFObjectID = Value
        End Set
    End Property

    Private blnHashed As Boolean = False
    Public ReadOnly Property HashedTable() As Boolean
        Get
            Return blnHashed
        End Get
    End Property

#End Region

#Region "SUPPORT FUNCTIONS"

    Public Sub ReloadLookup(ByVal stParameterTypeID As String, ByVal stReference As String)
        If stReference <> "" Then
            If (stReference <> "rftParametersFixedPresetValue") Then
                LookupCache.Fill(LookupCache.LookupTables(stReference), True)
            Else
                LookupCache.Fill(LookupCache.LookupTables("ParametersFixedPresetValue"), True)
            End If
        End If
    End Sub

    Public Function GetCashedLookUp(ByVal stParameterTypeID As String, ByVal stReference As String) As DataView
        Dim dv As DataView

        If stReference <> "" Then
            If (stReference <> "rftParametersFixedPresetValue") Then
                dv = LookupCache.Get(stReference)
            Else
                dv = LookupCache.Get("ParametersFixedPresetValue")
                dv.RowFilter = "[FFParID]='" + stParameterTypeID + "'"

                If (dv.Table.Columns.Contains("intOrder") And dv.Table.Columns.Contains("Name")) Then
                    dv.Sort = "intOrder, Name"
                End If

            End If
            Return dv
        End If
        Return Nothing
    End Function


    Public Overridable Sub GetParamTypeData(ByVal Lang As String, ByVal ParID As String, ByRef dr As DataRow)

    End Sub

    Public Overridable Sub RemoveNonTemplateNullValues(ByVal FFObj As FlexibeFormObject)

    End Sub

    Public Function GetCurrentFFType() As String
        Dim stResult As String
        Dim err As ErrorMessage = Nothing
        Dim cmd As IDbCommand = CreateCommand("select * from dbo.FFormTemplate where idfsFFOrmTemplateID=@TempID", Connection)

        AddParam(cmd, "@TempID", CurrentFFObjectID.TemplateID)
        stResult = ExecScalar(cmd, Connection, err).ToString

        Return stResult
    End Function

    ' Get Empty FFTable for Certain Template
    Public Overridable Function GetNewDataTable(ByRef FFObjectID As FlexibeFormObject) As System.Data.DataTable
        Dim Table As New DataTable
        Table = New DataTable("FFormParameters")

        Try
            Dim cmd As IDbCommand = CreateSPCommand("sp_FF_GetFormByTemplate")
            If AddParam(cmd, "@TemplateID", FFObjectID.TemplateID, m_Error) Is Nothing Then Return Nothing
            If AddParam(cmd, "@Lng", bv.model.Model.Core.ModelUserContext.CurrentLanguage, m_Error) Is Nothing Then Return Nothing
            Dim Adapter As DbDataAdapter = CreateAdapter(cmd, False)
            Adapter.Fill(Table)

            Table.Columns("Value").ReadOnly = False
            Table.Columns("Value").DataType = System.Type.GetType("System.String")
            Table.Columns("Value").MaxLength = -1
            Table.Columns("Value").DefaultValue = ""
            blnHashed = False

            FFObjectID.Table = Table
            Return Table
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    ' Get Empty FlexTable
    Public Function GetNewFlexTable(ByRef FFObjectID As FlexibeFormObject) As DataTable
        Dim dt As DataTable
        Dim dr As DataRow
        Dim dc As DataColumn
        Dim i As Integer

        ' Table Name= Object ID
        dt = New DataTable(FFObjectID.ObjectId.ToString)
        dt.Columns.Add(New DataColumn("Row", System.Type.GetType("System.Int32")))
        For i = 0 To FFObjectID.Table.Rows.Count - 1
            dr = FFObjectID.Table.Rows(i)
            If dr.Item("ParameterTypeID").ToString = "fptNumeric" Then
                dc = New DataColumn(dr.Item("ParameterID").ToString, System.Type.GetType("System.Double"))
            Else
                dc = New DataColumn(dr.Item("ParameterID").ToString, System.Type.GetType("System.String"))
            End If
            ' DataColumn Name = Parameter ID
            dt.Columns.Add(dc)
        Next

        blnHashed = False
        Return dt
    End Function

    ' Return Relation Table
    Public Function GetRelationTable(ByVal FFObjectID As FlexibeFormObject) As System.Data.DataTable
        Dim Table As New DataTable

        Table = New DataTable("FFormRelationsParameters")
        Try
            Dim cmd As IDbCommand = CreateSPCommand("spFFGetParameterRelationship")
            If AddParam(cmd, "@TemplateID", FFObjectID.TemplateID, m_Error) Is Nothing Then Return Nothing
            Dim Adapter As DbDataAdapter = CreateAdapter(cmd, False)
            Adapter.Fill(Table)
            Return Table
        Catch ex As Exception
            m_Error = New ErrorMessage(StandardError.FillDatasetError, ex)
            Return Nothing
        End Try
    End Function

    Public Overridable Function GetDataTable(ByRef FFObjectID As FlexibeFormObject) As System.Data.DataTable
        Dim Table As DataTable
        Dim spName As String

        ' Set current object
        'CurrentFFObjectID = FFObjectID

        ' If already have object with objectID try to find it
        If m_ObjectsHash.Contains(FFObjectID.GetHashKey()) Then

            ' If it's the same template just show what we have
            If CType(m_ObjectsHash(FFObjectID.GetHashKey()), FlexibeFormObject).TemplateID = FFObjectID.TemplateID Then
                blnHashed = True
                Return CType(m_ObjectsHash(FFObjectID.GetHashKey()), FlexibeFormObject).Table
            Else
                ' If it's new template then delete existing table and create new table, according template
                m_ObjectsHash.Remove(FFObjectID.GetHashKey())
            End If
        End If

        ' If table doesn't exist in Hash

        ' If this is new object Create New Table   
        If (CheckIfNew(FFObjectID)) Then
            Table = GetNewDataTable(FFObjectID)

        Else
            ' If not new read existing parameters and Create Table with them
            Table = New DataTable("FFormParameters")
            spName = "sp_FF_GetFormByObjectAndTemplate"
            Dim cmd As IDbCommand = CreateSPCommand(spName)

            If AddParam(cmd, "@ObjectID", FFObjectID.ObjectId, m_Error) Is Nothing Then Return Nothing
            If AddParam(cmd, "@TemplateID", FFObjectID.TemplateID, m_Error) Is Nothing Then Return Nothing
            If AddParam(cmd, "@TableName", FFObjectID.TableName, m_Error) Is Nothing Then Return Nothing
            If AddParam(cmd, "@Lng", bv.model.Model.Core.ModelUserContext.CurrentLanguage, m_Error) Is Nothing Then Return Nothing
            If AddParam(cmd, "@CustomGroup", FFObjectID.CustomTemplateID, m_Error) Is Nothing Then Return Nothing

            Dim Adapter As DbDataAdapter = CreateAdapter(cmd, False)
            Adapter.Fill(Table)
        End If
        If Table.Columns.Contains("TabName") Then
            Table.Columns("TabName").ReadOnly = False
        End If

        ' Return Table
        'FFObjectID.Table = Table
        CurrentFFObjectID.Table = Table
        m_ObjectsHash(FFObjectID.GetHashKey()) = FFObjectID
        blnHashed = False
        Return Table
    End Function

    Public Overridable Function GetFlexTable(ByRef FFObjectID As FlexibeFormObject) As DataTable
        Dim Table As DataTable
        Dim Ftable As DataTable
        Dim spName As String
        Dim dr, drNew As DataRow

        ' Set current object
        'CurrentFFObjectID = FFObjectID

        ' If already have object with objectID try to find it
        If m_ObjectsHash.Contains(FFObjectID.GetHashKey()) Then

            ' If it's the same template just show what we have
            If CType(m_ObjectsHash(FFObjectID.GetHashKey()), FlexibeFormObject).TemplateID = FFObjectID.TemplateID Then
                blnHashed = True
                Table = CType(m_ObjectsHash(FFObjectID.GetHashKey()), FlexibeFormObject).FlexTable
                FFObjectID.FlexTable = Table
                m_ObjectsHash(FFObjectID.GetHashKey()) = FFObjectID
                Return Table
            Else
                ' If it's new template then delete existing table and create new table, according template
                m_ObjectsHash.Remove(FFObjectID.GetHashKey())
            End If
        End If

        ' If table doesn't exist in Hash

        ' If this is new object Create New Table   
        If (CheckIfNew(FFObjectID)) Then
            Table = GetNewFlexTable(FFObjectID)
        Else
            ' If not new read existing parameters and Create Table with them

            ' Get Table Structure
            Table = GetNewFlexTable(FFObjectID)
            ' Fill Table with Data

            Ftable = New DataTable("FFormParameters")
            spName = "sp_FF_GetTableByObjectAndTemplate"
            Dim cmd As IDbCommand = CreateSPCommand(spName)

            If AddParam(cmd, "@ObjectID", FFObjectID.ObjectId, m_Error) Is Nothing Then Return Nothing
            If AddParam(cmd, "@TemplateID", FFObjectID.TemplateID, m_Error) Is Nothing Then Return Nothing
            If AddParam(cmd, "@TableName", FFObjectID.TableName, m_Error) Is Nothing Then Return Nothing

            Dim Adapter As DbDataAdapter = CreateAdapter(cmd, False)
            Adapter.Fill(Ftable)

            ' Build required structure
            If Ftable.Rows.Count > 0 Then

                Dim i As Integer = 0
                Dim rn As Integer = 0
                drNew = Table.NewRow()

                For i = 0 To Ftable.Rows.Count - 1
                    dr = Ftable.Rows(i)
                    If Not dr.Item("Row") Is DBNull.Value Then
                        If CType(dr.Item("Row"), Integer) > rn Then
                            drNew.Item("Row") = rn
                            Table.Rows.Add(drNew)
                            drNew = Table.NewRow()
                            rn = rn + 1
                        End If

                        If dr.Item("ParameterTypeID").ToString = "fptNumeric" Then
                            drNew.Item(dr.Item("ParameterID").ToString) = dr.Item("ValueNum")
                        Else
                            drNew.Item(dr.Item("ParameterID").ToString) = dr.Item("ValueStr")
                        End If
                    End If
                Next

                drNew.Item("Row") = rn
                Table.Rows.Add(drNew)

            End If


        End If

        ' Return Table
        FFObjectID.FlexTable = Table
        m_ObjectsHash(FFObjectID.GetHashKey()) = FFObjectID

        blnHashed = False
        Return Table
    End Function


    ' Check if current object has FFTemplate values
    Public Overridable Function CheckIfNew(ByVal FFObjectID As FlexibeFormObject) As Boolean
        Dim cmd As IDbCommand = CreateSPCommand("sp_FF_CheckIfNew")
        'If AddParam(cmd, "@TemplateID", FFObjectID.TemplateID, m_Error) Is Nothing Then Return Nothing
        If AddParam(cmd, "@ObjectID", FFObjectID.ObjectId, m_Error) Is Nothing Then Return Nothing
        If AddParam(cmd, "@TableName", FFObjectID.TableName, m_Error) Is Nothing Then Return Nothing
        If CType(BaseDbService.ExecScalar(cmd, Me.Connection, Nothing), Integer) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region


End Class
