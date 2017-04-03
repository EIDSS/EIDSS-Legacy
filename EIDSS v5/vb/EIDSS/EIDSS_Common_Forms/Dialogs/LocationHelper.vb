
Imports bv.winclient.Core
Imports EIDSS.model.Resources
Imports bv.common.Resources

Namespace Dialogs
    Public Class LocationHelper
        ReadOnly m_GeoLocationTable As DataTable
        ReadOnly m_eventManager As DataEventManager

        Public Sub New(ByVal geoLocationTable As DataTable, ByVal eventManager As DataEventManager)
            Utils.CheckNotNull(geoLocationTable, "geoLocationTable")
            m_GeoLocationTable = geoLocationTable
            m_eventManager = eventManager
        End Sub

        Public Sub SetCaseLocation(ByVal longitude As Decimal, ByVal latitude As Decimal)
            'GISPanel.Case_Location(seLongitude.Value, seLatitude.Value, AddressOf GetCoordinates)
            Dim idfsCountry As Long = 0
            Dim idfsRegion As Long = 0
            Dim idfsRayon As Long = 0
            Dim idfsSettlement As Long = 0

            If m_GeoLocationTable.Rows.Count > 0 Then
                Dim row As DataRow = m_GeoLocationTable.Rows(0)

                If (TypeOf row("idfsCountry") Is Long) Then
                    idfsCountry = CLng(row("idfsCountry"))
                End If
                If (TypeOf row("idfsRegion") Is Long) Then
                    idfsRegion = CLng(row("idfsRegion"))
                End If
                If (TypeOf row("idfsRayon") Is Long) Then
                    idfsRayon = CLng(row("idfsRayon"))
                End If
                If (TypeOf row("idfsSettlement") Is Long) Then
                    idfsSettlement = CLng(row("idfsSettlement"))
                End If

            End If

            gis.GisInterface.SetCaseLocation(idfsCountry, idfsRegion, idfsRayon, idfsSettlement, _
                                        longitude, latitude, AddressOf GetCoordinates)

        End Sub

        Private Sub GetCoordinates(ByVal X As Nullable(Of Double), ByVal Y As Nullable(Of Double))
            If m_GeoLocationTable.Rows.Count > 0 Then
                Dim row As DataRow = m_GeoLocationTable.Rows(0)
                row.BeginEdit()
                If (X.HasValue) Then
                    row("dblLongitude") = CType(X, Decimal)
                Else
                    row("dblLongitude") = 0
                End If
                If (Y.HasValue) Then
                    row("dblLatitude") = CType(Y, Decimal)
                Else
                    row("dblLatitude") = 0
                End If
                row.EndEdit()
            End If
        End Sub
        Public Function ValidateLocationCoordinates(latitude As Object, longitude As Object) As Boolean
            If (Utils.IsEmpty(latitude) AndAlso Utils.IsEmpty(longitude)) Then
                Return True
            End If

            Dim idfsCountry As Nullable(Of Long) = 0
            Dim idfsRegion As Nullable(Of Long) = 0
            Dim idfsRayon As Nullable(Of Long) = 0
            If Utils.IsEmpty(longitude) OrElse Utils.IsEmpty(latitude) Then
                MessageForm.Show(EidssMessages.Get("msgCoordinatesAreNotDefined", "The Longitude and Latitude field shall be both either filled or blank."))
                Return False
            End If
            If Utils.IsEmpty(longitude) AndAlso Utils.IsEmpty(latitude) Then
                Return True
            End If
            If gis.common.CoordinatesUtils.CoordToAdm(idfsCountry, idfsRegion, idfsRayon, ConnectionManager.DefaultInstance.ConnectionString, _
                                         CDbl(latitude), CDbl(longitude)) = False Then
                Return True
            End If
            If m_GeoLocationTable.Rows.Count > 0 Then
                Dim row As DataRow = m_GeoLocationTable.Rows(0)
                If Not Utils.IsEmpty(row("idfsCountry")) Then
                    If Not idfsCountry.HasValue OrElse Not row("idfsCountry").Equals(idfsCountry) Then
                        ErrorForm.ShowWarningDirect(EidssMessages.Get("msgCoordinatesOutOfCountryGeoLocation", "Location coordinates are beyond the country. Location must be selected within the country."))
                        Return False
                    End If
                End If
                'Such situation is possible because of unideal map data
                'Let's consider such coordinates as correct
                If Not idfsRegion.HasValue OrElse Not idfsRayon.HasValue Then
                    Return True
                End If
                If (Not row("idfsRayon").Equals(idfsRayon)) _
                    OrElse (Not row("idfsRegion").Equals(idfsRegion)) Then
                    If WinUtils.ConfirmMessage(EidssMessages.Get("msgCoordinatesAutoCorrection", "Region and Rayon will be filled in accordance with location coordinates automatically!"), BvMessages.Get("Warning")) Then
                        row("idfsRegion") = idfsRegion
                        m_eventManager.Cascade(String.Format("{0}.idfsRegion", m_GeoLocationTable.TableName))
                        Application.DoEvents()
                        row("idfsRayon") = idfsRayon
                        m_eventManager.Cascade(String.Format("{0}.idfsRayon", m_GeoLocationTable.TableName))
                        row.EndEdit()
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
            Return True
        End Function
        Public Function ValidateAddressCoordinates(latitude As Object, longitude As Object) As Boolean
            If (Utils.IsEmpty(latitude) AndAlso Utils.IsEmpty(longitude)) Then
                Return True
            End If

            Dim idfsCountry As Nullable(Of Long) = 0
            Dim idfsRegion As Nullable(Of Long) = 0
            Dim idfsRayon As Nullable(Of Long) = 0
            If Utils.IsEmpty(longitude) OrElse Utils.IsEmpty(latitude) Then
                MessageForm.Show(EidssMessages.Get("msgCoordinatesAreNotDefined", "The Longitude and Latitude field shall be both either filled or blank."))
                Return False
            End If
            If Utils.IsEmpty(longitude) AndAlso Utils.IsEmpty(latitude) Then
                Return True
            End If
            If gis.common.CoordinatesUtils.CoordToAdm(idfsCountry, idfsRegion, idfsRayon, ConnectionManager.DefaultInstance.ConnectionString, _
                                         CDbl(latitude), CDbl(longitude)) = False Then
                Return True
            End If
            If m_GeoLocationTable.Rows.Count > 0 Then
                Dim row As DataRow = m_GeoLocationTable.Rows(0)
                'Such situation is possible because of unideal map data
                'Let's consider such coordinates as correct
                If idfsCountry.HasValue AndAlso (Not idfsRegion.HasValue OrElse Not idfsRayon.HasValue) Then
                    Return True
                End If
                If Not Utils.IsEmpty(row("idfsRayon")) Then
                    If Not row("idfsRayon").Equals(idfsRayon) Then
                        If (Not WinUtils.ConfirmMessage(EidssMessages.Get("msgCoordinatesOutOfRayon"))) Then
                            Return False
                        End If
                    End If
                End If
                If Utils.IsEmpty(row("idfsRayon")) AndAlso Not Utils.IsEmpty(row("idfsRegion")) Then
                    If Not row("idfsRegion").Equals(idfsRegion) Then
                        If (Not WinUtils.ConfirmMessage(EidssMessages.Get("msgCoordinatesOutOfRegion"))) Then
                            Return False
                        End If
                    End If
                End If
                If Utils.IsEmpty(row("idfsRegion")) AndAlso Not Utils.IsEmpty(row("idfsCountry")) Then
                    If Not idfsCountry.HasValue OrElse Not row("idfsCountry").Equals(idfsCountry) Then
                        If (Not WinUtils.ConfirmMessage(EidssMessages.Get("msgCoordinatesOutOfCountry"))) Then
                            Return False
                        End If
                    End If
                End If
            End If
            Return True
        End Function

    End Class

End Namespace
