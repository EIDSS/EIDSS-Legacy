Imports bv.winclient.Core
Imports System.Linq
Imports System.Collections.Generic
Imports System.ComponentModel
Imports EIDSS.model.Resources
Imports DevExpress.XtraGrid

Namespace ActiveSurveillance
    Public Class AsSamplesPanel

        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()
            If WinUtils.IsComponentInDesignMode(Me) Then
                Return
            End If
            DbService = New AsSessionSamples_DB
            ' Add any initialization after the InitializeComponent() call. 
            Me.colSampleCondition.Visible = False
            Me.colAnimal.Visible = False
            Me.colSpecies.Visible = False
            Me.colAccessionedDate.Visible = False
            Me.colConditionReceived.Visible = False
            Me.colVectorID.Visible = False
            Me.colVectorType.Visible = False
            SamplesView.OptionsView.ColumnAutoWidth = True
            Me.SamplesGrid.Width = SamplesGrid.Parent.ClientSize.Width - SamplesGrid.Left - 4
            Me.SamplesGrid.Height = SamplesGrid.Parent.ClientSize.Height - SamplesGrid.Top - 4
            DefaultPartyID = Nothing
        End Sub

        Public Function CanDeleteParty(ByVal partyID As Object) As Boolean
            If Utils.IsEmpty(partyID) Then
                Return True
            End If
            If baseDataSet.Tables(CaseSamples_Db.TableSamples).Select(String.Format("idfParty = {0} and Used = 1", partyID.ToString)).Length > 0 Then
                Return False
            End If
            Return True
        End Function


        Public Property SupressRowValidation As Boolean
        Overrides Function IsCurrentSpecimenRowValid(Optional ByVal index As Integer = -1, Optional ByVal showError As Boolean = True) As Boolean
            If SupressRowValidation Then
                SupressRowValidation = False
                Return True
            End If
            Dim row As DataRow
            If index = -1 Then
                row = SamplesGridView.GetFocusedDataRow()
            Else
                row = SamplesGridView.GetDataRow(index)
            End If
            If Not MyBase.IsCurrentSpecimenRowValid(index, showError) Then
                InvalidSample = row
                Return False
            End If
            If (index = GridControl.InvalidRowHandle) Then
                Return True
            End If
            If Not row Is Nothing Then

                If HasDuplicates(row) Then
                    If showError Then
                        MessageForm.Show(EidssMessages.Get("AsSession.DetailsTableView.DuplicateSample"))
                    End If
                    InvalidSample = row
                    Return False
                End If
                Dim errMsg As String = String.Empty
                If Not AsSession.ValidateCollectionDate(row("datFieldCollectionDate"), errMsg, showError) Then
                    InvalidSample = row
                    Return False
                End If
            End If
            Return True
        End Function
        Public Property InvalidSample As DataRow
        Private Function HasDuplicates(ByVal samples As IEnumerable(Of DataRow)) As Boolean
            Dim hash As New HashSet(Of DataRow)(New SampleComparer())
            For Each sample As DataRow In samples
                If Not hash.Add(sample) Then
                    InvalidSample = sample
                    Return True
                End If
            Next
            Return False
        End Function
        Private Function HasDuplicates(ByVal sampleRow As DataRow) As Boolean
            If sampleRow Is Nothing OrElse sampleRow.RowState = DataRowState.Deleted OrElse sampleRow.RowState = DataRowState.Detached Then
                Return False
            End If

            If Utils.IsEmpty(sampleRow("strFieldBarcode")) Then
                Return False
            End If
            If baseDataSet.Tables(CaseSamples_Db.TableSamples).Select( _
                String.Format("idfParty = {0} and idfsSampleType={1} and strFieldBarcode = '{2}' and idfMaterial<> {3} ", _
                            sampleRow("idfParty"), sampleRow("idfsSampleType"), sampleRow("strFieldBarcode"), sampleRow("idfMaterial"))).Length > 0 Then
                InvalidSample = sampleRow
                Return True
            End If
            Return False
        End Function
        Public Overrides Function ValidateData() As Boolean
            If MyBase.ValidateData() = False Then
                Return False
            End If
            If HasDuplicates(baseDataSet.Tables(CaseSamples_Db.TableSamples).AsEnumerable()) Then
                MessageForm.Show(EidssMessages.Get("AsSession.DetailsTableView.DuplicateSample"))
                Return False
            End If
            Return True
        End Function
        Protected Overrides Function ShowEditor(ByVal row As DataRow) As Boolean
            If (SamplesGridView.FocusedColumn.Name = Me.colSampleCondition.Name) Then
                Return False
            End If
            Return MyBase.ShowEditor(row)
        End Function
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Public Overrides Property DefaultPartyID() As Object
            Get
                Return MyBase.DefaultPartyID
            End Get
            Set(ByVal Value As Object)
                MyBase.DefaultPartyID = Value
                UpdateButtons()
                btnNewSpecimen.Enabled = Not [ReadOnly] AndAlso Not Utils.IsEmpty(Value)
            End Set
        End Property
        Public Overrides Sub UpdateButtons()
            Dim specimenSelected As Boolean = Not SamplesGridView.GetDataRow(SamplesGridView.FocusedRowHandle) Is Nothing
            btnDeleteSpecimen.Enabled = Not [ReadOnly] AndAlso specimenSelected
            EnableSampleAdding(Not [ReadOnly] AndAlso Not Utils.IsEmpty(DefaultPartyID) AndAlso IsCurrentSpecimenRowValid(, False))
        End Sub
        Private ReadOnly Property AsSession As AsSessionDetail
            Get
                Return CType(BaseForm.FindBaseForm(Me), AsSessionDetail)
            End Get
        End Property

        Protected Overrides Sub UpdatePartyInfo(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
            MyBase.UpdatePartyInfo(sender, e)
            Dim materialRow As DataRow = e.Row
            Dim animalRow As DataRow = FindRow(CType(cbAnimalLookup.DataSource, DataView).Table, materialRow("idfParty"), "idfAnimal")
            If Not animalRow Is Nothing Then
                materialRow("strFarmCode") = animalRow("strFarmCode")
            End If
        End Sub

        Public Class SampleComparer
            Implements IEqualityComparer(Of DataRow)

            Public Overloads Function Equals(
                ByVal x As DataRow,
                ByVal y As DataRow
                ) As Boolean Implements IEqualityComparer(Of DataRow).Equals

                ' Check whether the compared objects reference the same data.
                If x Is y Then Return True
                If x.RowState = DataRowState.Deleted OrElse x.RowState = DataRowState.Detached OrElse y.RowState = DataRowState.Deleted OrElse y.RowState = DataRowState.Detached Then
                    Return False
                End If

                'Check whether any of the compared objects is null.
                If x Is Nothing OrElse y Is Nothing Then Return False
                If Utils.IsEmpty(x("strFieldBarcode")) OrElse Utils.IsEmpty(x("strFieldBarcode")) Then Return False

                ' Check whether the products' properties are equal.
                Return x("idfParty").Equals(y("idfParty")) AndAlso x("idfsSampleType").Equals(y("idfsSampleType")) AndAlso x("strFieldBarcode").Equals(y("strFieldBarcode"))
            End Function

            Public Overloads Function GetHashCode(ByVal sample As DataRow) As Integer Implements IEqualityComparer(Of DataRow).GetHashCode
                ' Check whether the object is null.
                If sample Is Nothing Then Return 0
                If sample.RowState = DataRowState.Deleted OrElse sample.RowState = DataRowState.Detached Then
                    Return 0
                End If
                ' Get hash code for the Name field if it is not null.
                Return sample("idfParty").GetHashCode() Xor sample("idfsSampleType").GetHashCode() Xor sample("strFieldBarcode").GetHashCode()
            End Function



        End Class



    End Class
End Namespace
