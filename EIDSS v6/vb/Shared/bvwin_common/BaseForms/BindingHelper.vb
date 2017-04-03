' An internal helper class that makes data bindings behave
' as we want them to. What it does: 
' 1. Pulls data from combo boxes and feeds
'    it to bindings immediatelly after user selects a value. The default
'    behavior is to pull data after focus leaves the combo box.
' 2. Provides parses/formatters for DateTime and Currency (Decimal) fields.
Imports System.Globalization
Imports bv.winclient.Core

Class BindingHelper

    Private m_dataEventManager As DataEventManager
    Private m_Bindings As New Hashtable

    Private Sub ComboBoxSelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim combo As ComboBox
        Try
            combo = CType(sender, ComboBox)
        Catch ex As Exception
            Trace.WriteLine(ex)
            Return
        End Try

        Dim fieldName As String = combo.ValueMember
        Dim b As Binding
        For Each b In combo.DataBindings
            m_dataEventManager.NeedBindingManagerUpdate(b.BindingManagerBase)
        Next
    End Sub

    Public Shared Sub BindingParse(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If Not TypeOf (sender) Is Binding Then
            Return
        End If
        If cevent.Value Is DBNull.Value OrElse cevent.Value Is Nothing Then Return
        Dim binding As Binding = CType(sender, Binding)
        Try
            If cevent.DesiredType Is GetType(Decimal) Then
                CurrencyStringToDecimal(sender, cevent)
            ElseIf cevent.DesiredType Is GetType(DateTime) Then
                If Not binding.Control.Tag Is Nothing AndAlso TypeOf (binding.Control.Tag) Is String AndAlso CType(binding.Control.Tag, String) = "Time" Then
                    TimeStringToDateTime(sender, cevent)
                ElseIf Not binding.Control.Tag Is Nothing AndAlso TypeOf (binding.Control.Tag) Is String AndAlso CType(binding.Control.Tag, String) = "Year" Then
                    YearStringToDateTime(sender, cevent)
                Else
                    DateStringToDateTime(sender, cevent)
                End If
            ElseIf Not cevent.DesiredType Is GetType(DataViewManager) AndAlso Not cevent.DesiredType Is GetType(DataView) Then
                Convert.ChangeType(cevent.Value, cevent.DesiredType)
            End If
        Catch ex As Exception
            MessageForm.Show(String.Format("Invalid input string format for field {0}", binding.BindingMemberInfo.BindingField))
            binding.Control.Select()
            binding.Control.Focus()
        End Try
    End Sub

    Public Shared Sub BindingFormat(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If Not TypeOf (sender) Is Binding Then
            Return
        End If
        'Dim e As System.ComponentModel.EventHandlerList
        Dim binding As Binding = CType(sender, Binding)
        If TypeOf binding.Control Is CheckBox Then
            DataToCheckBox(sender, cevent)
        ElseIf TypeOf (cevent.Value) Is Decimal Then
            DecimalToCurrencyString(sender, cevent)
        ElseIf TypeOf (cevent.Value) Is DateTime Then
            If Not binding.Control.Tag Is Nothing AndAlso TypeOf (binding.Control.Tag) Is String AndAlso CType(binding.Control.Tag, String) = "Time" Then
                DateTimeToTimeString(sender, cevent)
            ElseIf Not binding.Control.Tag Is Nothing AndAlso TypeOf (binding.Control.Tag) Is String AndAlso CType(binding.Control.Tag, String) = "Year" Then
                DateTimeToYearString(sender, cevent)
            Else
                DateTimeToDateString(sender, cevent)
            End If
        ElseIf cevent.Value Is DBNull.Value AndAlso TypeOf (binding.Control) Is DateTimePicker Then
            If TypeOf (binding.BindingManagerBase.Current) Is DataRowView Then
                Dim row As DataRow = CType(binding.BindingManagerBase.Current, DataRowView).Row
                row.BeginEdit()
                row(binding.BindingMemberInfo.BindingField) = CType(binding.Control, DateTimePicker).Value
                row.EndEdit()
            End If
        End If
    End Sub

    Public Sub Attach(ByVal ctl As Control)
        Dim b As Binding = Nothing
        For Each b In ctl.DataBindings
            If Not m_dataEventManager.IsCustomBinding(b) Then
                If m_Bindings(b) Is Nothing Then
                    AddHandler b.Parse, AddressOf BindingParse
                    AddHandler b.Format, AddressOf BindingFormat
                    m_Bindings(b) = 1
                End If
            End If
        Next
        If TypeOf ctl Is ComboBox Then
            Dim combo As ComboBox = CType(ctl, ComboBox)
            For Each b In ctl.DataBindings
                If Not m_dataEventManager.IsCustomBinding(b) Then
                    If m_Bindings(b) Is Nothing Then
                        AddHandler combo.SelectedValueChanged, AddressOf ComboBoxSelectedValueChanged
                        m_Bindings(b) = 1
                    End If
                End If
            Next
        ElseIf TypeOf ctl Is DevExpress.XtraEditors.LookUpEdit Then
            For Each b In ctl.DataBindings
                If b.DataSourceUpdateMode <> DataSourceUpdateMode.OnPropertyChanged Then
                    b.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
                End If
            Next
        Else
            Dim child As Control
            For Each child In ctl.Controls
                Attach(child)
            Next
        End If
    End Sub

    Public Sub New(ByVal manager As DataEventManager)
        m_dataEventManager = manager
    End Sub

    Public Shared Function ParseCurrency(ByVal text As String) As Decimal
        If text Is Nothing OrElse text.Trim = "" Then Return 0
        text = text.Trim()
        ' can't use NumberStyles.AllowCurrency because it doesn't allow currency symbol for some reason (?)
        ' can't use NumberStyles.AllowCurrencySymbol because it has problems when value part is represented by single '0'
        text = text.Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, "")
        text = text.Replace(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        Return CType(Double.Parse(text, NumberStyles.AllowThousands Or Globalization.NumberStyles.AllowDecimalPoint Or NumberStyles.AllowLeadingSign Or NumberStyles.AllowTrailingWhite Or NumberStyles.AllowLeadingWhite), Decimal)
    End Function

    'CheckBox.Bindings("Checked").Format event - allows binding of DBNull.Value value
    Public Shared Sub DataToCheckBox(ByVal Sender As Object, ByVal cevent As ConvertEventArgs)
        If cevent.DesiredType.Name <> "Boolean" Then Exit Sub
        If cevent.Value Is DBNull.Value Then
            cevent.Value = False
        End If
    End Sub
    Public Shared Function FormatCurrency(ByVal val As Object) As String
        Try
            Return String.Format("{0:n}", val)
        Catch ex As Exception
            Trace.WriteLine(ex)
            If val Is Nothing OrElse val Is DBNull.Value Then Return ""
            Return Convert.ToString(val)
        End Try
    End Function
    'TextBox.Bindings("Text").Format event for Currency data type
    Public Shared Sub DecimalToCurrencyString(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If Not cevent.DesiredType Is GetType(String) Then Exit Sub
        cevent.Value = FormatCurrency(cevent.Value)
    End Sub

    'TextBox.Bindings("Text").Parse event for Currency data type
    Public Shared Sub CurrencyStringToDecimal(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If Not cevent.DesiredType Is GetType(Decimal) Then Exit Sub
        If cevent.Value Is DBNull.Value Then Return
        If cevent.Value Is Nothing Or CType(cevent.Value, String) = "" Then
            cevent.Value = DBNull.Value
        Else
            cevent.Value = ParseCurrency(cevent.Value.ToString())
        End If
    End Sub

    'TextBox.Bindings("Text").Format event for Date data type
    Public Shared Sub DateTimeToDateString(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If Not cevent.DesiredType Is GetType(String) Then Exit Sub
        If cevent.Value Is Nothing Or cevent.Value Is DBNull.Value Then Exit Sub
        cevent.Value = CType(cevent.Value, DateTime).ToShortDateString()
    End Sub

    'TextBox.Bindings("Text").Format event for Date data type
    Public Shared Sub DateTimeToYearString(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If Not cevent.DesiredType Is GetType(String) Then Exit Sub
        If cevent.Value Is Nothing Or cevent.Value Is DBNull.Value Then Exit Sub
        cevent.Value = CType(cevent.Value, DateTime).Year.ToString()
    End Sub


    'TextBox.Bindings("Text").Parse event for Date data type
    Public Shared Sub DateStringToDateTime(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If Not cevent.DesiredType Is GetType(DateTime) Then Exit Sub
        If (cevent.Value Is Nothing) Or (cevent.Value Is DBNull.Value) Or (CType(cevent.Value, String) = "") Then
            cevent.Value = DBNull.Value
            Exit Sub
        End If
        If TypeOf (CType(sender, Binding).Control) Is DateTimePicker Then
            Dim dt As DateTimePicker = CType(CType(sender, Binding).Control, DateTimePicker)
            cevent.Value = dt.Value
        Else
            cevent.Value = DateTime.Parse(cevent.Value.ToString())
        End If
    End Sub
    'TextBox.Bindings("Text").Parse event for Date data type
    Public Shared Sub YearStringToDateTime(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If Not cevent.DesiredType Is GetType(DateTime) Then Exit Sub
        If (cevent.Value Is Nothing) Or (cevent.Value Is DBNull.Value) Or (CType(cevent.Value, String) = "") Then
            cevent.Value = DBNull.Value
            Exit Sub
        End If
        If TypeOf (CType(sender, Binding).Control) Is DateTimePicker Then
            Dim dt As DateTimePicker = CType(CType(sender, Binding).Control, DateTimePicker)
            cevent.Value = dt.Value
        Else
            Dim Year As Integer = Convert.ToInt32(cevent.Value)
            cevent.Value = New DateTime(Year, 1, 1)
        End If
    End Sub

    'TextBox.Bindings("Text").Format event for Time data type
    Public Shared Sub DateTimeToTimeString(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If Not cevent.DesiredType Is GetType(String) Then Exit Sub
        If cevent.Value Is Nothing Or cevent.Value Is DBNull.Value Then Exit Sub
        cevent.Value = CType(cevent.Value, DateTime).ToShortTimeString()
    End Sub

    'TextBox.Bindings("Text").Parse event for Time data type
    Public Shared Sub TimeStringToDateTime(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
        If Not cevent.DesiredType Is GetType(DateTime) Then Exit Sub
        If (cevent.Value Is Nothing) Or (cevent.Value Is DBNull.Value) Or (CType(cevent.Value, String) = "") Then
            cevent.Value = DBNull.Value
            Exit Sub
        End If
        If CType(sender, Binding).Control.GetType().ToString() = "DateTimePicker" Then
            Dim dt As DateTimePicker = CType(CType(sender, Binding).Control, DateTimePicker)
            cevent.Value = dt.Value
        Else
            cevent.Value = DateTime.Parse(cevent.Value.ToString())
        End If
    End Sub

End Class
