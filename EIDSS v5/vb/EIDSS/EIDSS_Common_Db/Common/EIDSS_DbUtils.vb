Public Class EIDSS_DbUtils

    Public Shared Function GetAddressString(ByVal Country As String, ByVal Region As String, ByVal Rayon As String, ByVal PostCode As String, ByVal SettlementType As String, ByVal Settlement As String, ByVal Street As String, ByVal House As String, ByVal Building As String, ByVal Appartment As String, ByVal Type As String) As String
        If Utils.Str(Region) <> "" OrElse Utils.Str(Rayon) <> "" OrElse Utils.Str(Settlement) <> "" Then
            Dim cmd As IDbCommand = BaseDbService.CreateCommand("SELECT dbo.fnCreateAddressString(@LangID, @Country, @Region, @Rayon, @PostCode,@SettlementType,@Settlement, @Street, @House, @Building, @Appartment, @ResType)", Nothing, Nothing)
            BaseDbService.AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            BaseDbService.AddParam(cmd, "@Country", Country)
            BaseDbService.AddParam(cmd, "@Region", Region)
            BaseDbService.AddParam(cmd, "@Rayon", Rayon)
            BaseDbService.AddParam(cmd, "@PostCode", PostCode)
            BaseDbService.AddParam(cmd, "@SettlementType", SettlementType)
            BaseDbService.AddParam(cmd, "@Settlement", Settlement)
            BaseDbService.AddParam(cmd, "@Street", Street)
            BaseDbService.AddParam(cmd, "@House", House)
            BaseDbService.AddParam(cmd, "@Building", Building)
            BaseDbService.AddParam(cmd, "@Appartment", Appartment)
            BaseDbService.AddParam(cmd, "@ResType", Type)
            Dim address As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
            Return Utils.Str(address)
        End If
        Return ""
    End Function

    Public Shared Function GetRelatedLocaionString(ByVal Name As String, ByVal Description As String, ByVal Distance As Double, _
            ByVal Aligment As Double, ByVal GroundType As String, _
            ByVal Country As String, ByVal Region As String, _
            ByVal Rayon As String, ByVal SettlementType As String, ByVal Settlement As String) As String
        Dim cmd As IDbCommand = BaseDbService.CreateCommand("SELECT dbo.fnCreateRelativePointString(@LangID,@Country,@Region,	@Rayon,	@SettlementType,	@Settlement,	@Aligment,	@Distance,	@Description,	@GroundType)", Nothing, Nothing)
        If Utils.Str(Name) <> "" OrElse Utils.Str(Description) <> "" OrElse _
           (Distance <> 0) OrElse (Aligment <> 0) OrElse _
           Utils.Str(Country, EIDSS.model.Core.EidssSiteContext.Instance.CountryName) <> EIDSS.model.Core.EidssSiteContext.Instance.CountryName OrElse _
           Utils.Str(Region) <> "" OrElse Utils.Str(Rayon) <> "" OrElse Utils.Str(Settlement) <> "" Then
            BaseDbService.AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            BaseDbService.AddParam(cmd, "@Country", Country)
            BaseDbService.AddParam(cmd, "@Region", Region)
            BaseDbService.AddParam(cmd, "@Rayon", Rayon)
            BaseDbService.AddParam(cmd, "@SettlementType", SettlementType)
            BaseDbService.AddParam(cmd, "@Settlement", Settlement)
            BaseDbService.AddParam(cmd, "@Aligment", Aligment)
            BaseDbService.AddParam(cmd, "@Distance", Distance)
            BaseDbService.AddParam(cmd, "@Description", Description)
            BaseDbService.AddParam(cmd, "@GroundType", GroundType)
            Dim address As Object = BaseDbService.ExecScalar(cmd, Nothing, Nothing)
            Return Utils.Str(address)
        End If
        Return ""
    End Function
    Public Shared Function GetExactLocaionString(ByVal Name As String, ByVal Description As String, ByVal Latitude As Double, _
            ByVal Longitude As Double, _
            ByVal Country As String, ByVal Region As String, _
            ByVal Rayon As String) As String
        If Utils.Str(Name) <> "" OrElse Utils.Str(Description) <> "" OrElse _
           (Latitude <> 0 OrElse Longitude <> 0) OrElse _
           Utils.Str(Country, EIDSS.model.Core.EidssSiteContext.Instance.CountryName) <> EIDSS.model.Core.EidssSiteContext.Instance.CountryName OrElse _
           Utils.Str(Region) <> "" OrElse Utils.Str(Rayon) <> "" Then
            Dim cmd As IDbCommand = BaseDbService.CreateCommand("SELECT dbo.fnCreateExactPointString(@LangID,@Country,@Region,@Rayon,@Latitude,@Longitude,@Description)", Nothing, Nothing)
            BaseDbService.AddParam(cmd, "@LangID", bv.model.Model.Core.ModelUserContext.CurrentLanguage)
            BaseDbService.AddParam(cmd, "@Country", Country)
            BaseDbService.AddParam(cmd, "@Region", Region)
            BaseDbService.AddParam(cmd, "@Rayon", Rayon)
            BaseDbService.AddParam(cmd, "@Latitude", Latitude)
            BaseDbService.AddParam(cmd, "@Longitude", Longitude)
            BaseDbService.AddParam(cmd, "@Description", Description)
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
End Class
