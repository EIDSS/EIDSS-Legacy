Imports System.Text

Public Class EIDSS_DbUtils

    Public Shared Function GetAddressString(ByVal Country As String, ByVal Region As String, ByVal Rayon As String, ByVal PostCode As String, ByVal SettlementType As String, ByVal Settlement As String, ByVal Street As String, ByVal House As String, ByVal Building As String, ByVal Appartment As String, blnForeignAddress As Boolean, strForeignAddress As String) As String
        If (Utils.Str(Region) <> "" OrElse Utils.Str(Rayon) <> "" OrElse Utils.Str(Settlement) <> "") OrElse (blnForeignAddress AndAlso Utils.Str(Country) <> "") Then
            Dim cmd As IDbCommand = BaseDbService.CreateCommand("SELECT dbo.fnCreateAddressString(@Country, @Region, @Rayon, @PostCode,@SettlementType,@Settlement, @Street, @House, @Building, @Apartment, @blnForeignAddress,@strForeignAddress)", Nothing, Nothing)
            BaseDbService.AddParam(cmd, "@Country", Country)
            BaseDbService.AddParam(cmd, "@Region", Region)
            BaseDbService.AddParam(cmd, "@Rayon", Rayon)
            BaseDbService.AddParam(cmd, "@PostCode", PostCode)
            BaseDbService.AddParam(cmd, "@SettlementType", SettlementType)
            BaseDbService.AddParam(cmd, "@Settlement", Settlement)
            BaseDbService.AddParam(cmd, "@Street", Street)
            BaseDbService.AddParam(cmd, "@House", House)
            BaseDbService.AddParam(cmd, "@Building", Building)
            BaseDbService.AddParam(cmd, "@Apartment", Appartment)
            BaseDbService.AddParam(cmd, "@blnForeignAddress", blnForeignAddress)
            BaseDbService.AddParam(cmd, "@strForeignAddress", strForeignAddress)
            Dim address As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
            Return Utils.Str(address)
        End If
        Return ""
    End Function
    Private Const Precisioin As Double = 0.00000001
    Public Shared Function GetRelatedLocaionString(ByVal distance As Double, _
            ByVal aligment As Double, ByVal groundType As String, _
            ByVal country As String, ByVal region As String, _
            ByVal rayon As String, ByVal settlementType As String, ByVal settlement As String) As String
        Dim cmd As IDbCommand = BaseDbService.CreateCommand("SELECT dbo.fnCreateRelativePointString(@LangID,@Country,@Region, @Rayon, @SettlementType, @Settlement, @Alignment,	@Distance)", Nothing, Nothing)
        If (Math.Abs(distance - 0.0) > Precisioin) OrElse (Math.Abs(aligment - 0) > Precisioin) OrElse _
           Utils.Str(country, model.Core.EidssSiteContext.Instance.CountryName) <> model.Core.EidssSiteContext.Instance.CountryName OrElse _
           Utils.Str(region) <> "" OrElse Utils.Str(rayon) <> "" OrElse Utils.Str(settlement) <> "" Then
            BaseDbService.AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            BaseDbService.AddParam(cmd, "@Country", country)
            BaseDbService.AddParam(cmd, "@Region", region)
            BaseDbService.AddParam(cmd, "@Rayon", rayon)
            BaseDbService.AddParam(cmd, "@SettlementType", settlementType)
            BaseDbService.AddParam(cmd, "@Settlement", settlement)
            BaseDbService.AddParam(cmd, "@Alignment", aligment)
            BaseDbService.AddParam(cmd, "@Distance", distance)
            Dim address As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
            Return Utils.Str(address)
        End If
        Return ""
    End Function
    Public Shared Function GetExactLocaionString(ByVal latitude As Double, _
            ByVal longitude As Double, _
            ByVal country As String, ByVal region As String, _
            ByVal rayon As String, settlementType As Object, settlement As String) As String
        If (Math.Abs(latitude - 0) > Precisioin OrElse Math.Abs(longitude - 0) > Precisioin) OrElse _
           Utils.Str(country, model.Core.EidssSiteContext.Instance.CountryName) <> model.Core.EidssSiteContext.Instance.CountryName OrElse _
           Utils.Str(region) <> "" OrElse Utils.Str(rayon) <> "" Then
            Dim cmd As IDbCommand = BaseDbService.CreateCommand("SELECT dbo.fnCreateExactPointString(@Country,@Region,@Rayon,@SettlementType,@Settlement,@Latitude,@Longitude)", Nothing, Nothing)
            BaseDbService.AddParam(cmd, "@Country", country)
            BaseDbService.AddParam(cmd, "@Region", region)
            BaseDbService.AddParam(cmd, "@Rayon", rayon)
            BaseDbService.AddParam(cmd, "@SettlementType", settlementType)
            BaseDbService.AddParam(cmd, "@Settlement", settlement)
            BaseDbService.AddParam(cmd, "@Latitude", latitude)
            BaseDbService.AddParam(cmd, "@Longitude", longitude)
            Dim address As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
            Return Utils.Str(address)
        End If
        Return ""
    End Function

    Public Shared Function GetGeoLocaionString(ByVal idfLocation As Object) As String
        If Utils.IsEmpty(idfLocation) Then
            Return ""
        End If
        Dim cmd As IDbCommand = BaseDbService.CreateCommand("SELECT dbo.fnGeoLocationString(@LangID,@GeoLocation, NULL)", Nothing, Nothing)
        BaseDbService.AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
        BaseDbService.AddParam(cmd, "@GeoLocation", idfLocation)
        Dim text As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
        Return Utils.Str(text)
    End Function
    Public Shared Function GetAddressString(ByVal idfAddress As Object) As String
        If Utils.IsEmpty(idfAddress) Then
            Return ""
        End If
        Dim cmd As IDbCommand = BaseDbService.CreateCommand("SELECT dbo.fnAddressString(@LangID,@GeoLocation)", Nothing, Nothing)
        BaseDbService.AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
        BaseDbService.AddParam(cmd, "@GeoLocation", idfAddress)
        Dim text As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
        Return Utils.Str(text)
    End Function
    Public Shared Function GetPersonalDataAddressString(ByVal idfGeoLocation As Object, showSettlement As Boolean) As String
        If Utils.IsEmpty(idfGeoLocation) Then
            Return ""
        End If
        Dim cmd As IDbCommand = BaseDbService.CreateSPCommand("spGetPersonalDataAddress", ConnectionManager.DefaultInstance.Connection)
        BaseDbService.AddParam(cmd, "@idfGeoLocation", idfGeoLocation)
        BaseDbService.AddParam(cmd, "@blnShowSettlement", showSettlement)
        BaseDbService.AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
        Dim text As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
        Return Utils.Str(text)
    End Function

    Public Shared Function ToInFilter(table As DataTable, fieldName As String) As String
        Dim values As New StringBuilder
        For Each row As DataRow In table.Rows
            If Utils.IsEmpty(row(fieldName)) Then
                Continue For
            End If
            If (values.Length > 0) Then
                values.Append(",")
            End If
            values.Append(Utils.Str(row(fieldName)))
        Next
        If values.Length > 0 Then
            values.Insert(0, "(")
            values.Append(")")
        End If
        Return values.ToString()
    End Function
End Class
