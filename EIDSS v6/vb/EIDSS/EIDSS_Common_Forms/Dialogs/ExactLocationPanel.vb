Imports System.ComponentModel
Imports bv.winclient.Core
Imports eidss.model.Core
Imports eidss.Dialogs
Imports eidss.model.Enums


Public Class ExactLocationPanel
    <CLSCompliant(False)>
    Public Property PersonalDataTypes As PersonalDataGroup()
    Private Function CalcPersonalDataType() As PersonalDataGroup
        If (PersonalDataTypes Is Nothing) Then Return PersonalDataGroup.None
        For Each group As PersonalDataGroup In PersonalDataTypes
            If EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(group) Then
                Return group
            End If
        Next
        Return PersonalDataGroup.None
    End Function

    Private m_LocationHelper As LocationHelper
    <Browsable(False), DefaultValue(PersonalDataGroup.None), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property IgnorePersonalData As Boolean

    Protected Overrides Sub DefineBinding()
        If IsDesignMode() Then Return
        Dim group As PersonalDataGroup = CalcPersonalDataType()
        If group <> PersonalDataGroup.None Then
            btnMAP.Visible = False
        End If
        btnMAP.Enabled = EIDSS.model.Core.EidssUserContext.User.HasPermission(PermissionHelper.SelectPermission(EIDSS.model.Enums.EIDSSPermissionObject.GIS))
        Core.LookupBinder.BindPersonalDataSpinEdit(seLongitude, baseDataSet, "Address.dblLongitude", group, IgnorePersonalData, -180, +180, True)
        Core.LookupBinder.BindPersonalDataSpinEdit(seLatitude, baseDataSet, "Address.dblLatitude", group, IgnorePersonalData, -89, +89, True)
    End Sub

    Private m_ID As Object = Nothing

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(True)> _
    Public Property ID() As Object
        Get
            Return m_ID
        End Get
        Set(ByVal Value As Object)
            If IsDesignMode() Or Created = False OrElse (Not Parent Is Nothing AndAlso Parent.Created = False) Then _
                Return
            If Loading Then Return
            'Pass Nothing to create new record in dataset
            If Value Is DBNull.Value Then
                Return
            End If
            If m_ID Is Nothing OrElse m_ID.Equals(Value) = False Then
                m_ID = Value
                If Me.ParentObject Is Nothing Then
                    LoadData(m_ID)
                End If
            End If
        End Set
    End Property

    Private Sub btnMAP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMAP.Click
        Try
            'ExtractLocationFromRelatedAddress()

            If (m_LocationHelper Is Nothing) Then
                m_LocationHelper = New LocationHelper(baseDataSet.Tables("Address"), eventManager, Me.btnMAP)
            End If

            m_LocationHelper.SetCaseLocation(seLongitude.Value, seLatitude.Value)

        Catch ex As Exception
            ErrorForm.ShowError(ex)
        End Try
    End Sub

    Public Sub AfterLoading(ByVal sender As Object, ByVal e As EventArgs)
        m_ID = DbService.ID
    End Sub

    Private m_RelatedAddress As AddressLookup

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(True)> _
    Public WriteOnly Property RelatedAddress() As AddressLookup
        Set(ByVal value As AddressLookup)
            m_RelatedAddress = value
        End Set
    End Property

    Private Sub BeforePost(ByVal sender As Object, ByVal e As EventArgs)
        'ExtractLocationFromRelatedAddress()
    End Sub

    Private Sub ExtractLocationFromRelatedAddress()
        'If Not m_RelatedAddress Is Nothing Then
        '    Dim row As DataRow = baseDataSet.Tables("GeoLocation").Rows(0)
        '    Dim addressRow As DataRow = m_RelatedAddress.baseDataSet.Tables("Address").Rows(0)
        '    row("idfsCountry") = addressRow("idfsCountry")
        '    row("idfsRegion") = addressRow("idfsRegion")
        '    row("idfsRayon") = addressRow("idfsRayon")
        'End If
    End Sub

End Class
