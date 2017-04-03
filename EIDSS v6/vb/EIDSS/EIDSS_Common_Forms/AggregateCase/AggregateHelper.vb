Imports DevExpress.XtraEditors
Imports System.Reflection
Imports System.Collections.Generic
Imports DevExpress.XtraGrid.Views.Grid
Imports EIDSS.model.Resources
Imports EIDSS.model.Core

Public Class AggregateHelper
    Private m_MonthList As DataTable
    Private m_QuarterList As DataTable
    Private m_WeekList As DataTable
    Private ReadOnly m_MinYear As Integer = 1900
    Private ReadOnly m_Owner As BaseForm
    Private cbYear As ComboBoxEdit
    Private cbQuarter As LookUpEdit
    Private cbMonth As LookUpEdit
    Private datDay As DateEdit
    Private cbWeek As LookUpEdit
    Private cbCountry As LookUpEdit
    Private cbRegion As LookUpEdit
    Private cbRayon As LookUpEdit
    Private cbSettlement As LookUpEdit
    Private eventManager As DataEventManager
    Private Sub InitDataEventManager(ByVal owner As BaseForm)
        'Dim fi As FieldInfo = owner.GetType().GetField("eventManager", BindingFlags.Public Or BindingFlags.Instance)
        'eventManager = CType(fi.GetValue(owner), DataEventManager)
        eventManager = owner.eventManager
    End Sub
    Public Sub New(ByVal owner As BaseForm, ByVal acbYear As ComboBoxEdit, ByVal acbQuarter As LookUpEdit, _
                        ByVal acbMonth As LookUpEdit, ByVal adatDay As DateEdit, ByVal acbWeek As LookUpEdit, _
                        ByVal acbCountry As LookUpEdit, ByVal acbRegion As LookUpEdit, _
                        ByVal acbRayon As LookUpEdit, ByVal acbSettlement As LookUpEdit)
        m_Owner = owner
        InitDataEventManager(owner)
        Init(acbYear, acbQuarter, acbMonth, adatDay, acbWeek, acbCountry, acbRegion, acbRayon, acbSettlement)
    End Sub
    Public Sub New(ByVal owner As BaseForm, ByVal aMinYear As Integer, ByVal acbYear As ComboBoxEdit, ByVal acbQuarter As LookUpEdit, _
                        ByVal acbMonth As LookUpEdit, ByVal adatDay As DateEdit, ByVal acbWeek As LookUpEdit, _
                        ByVal acbCountry As LookUpEdit, ByVal acbRegion As LookUpEdit, _
                        ByVal acbRayon As LookUpEdit, ByVal acbSettlement As LookUpEdit)
        If aMinYear > 0 AndAlso aMinYear <= DateTime.Today.Year Then
            m_MinYear = aMinYear
        End If
        m_Owner = owner
        InitDataEventManager(owner)
        Init(acbYear, acbQuarter, acbMonth, adatDay, acbWeek, acbCountry, acbRegion, acbRayon, acbSettlement)
    End Sub
    Private Sub Init(ByVal acbYear As ComboBoxEdit, ByVal acbQuarter As LookUpEdit, _
                        ByVal acbMonth As LookUpEdit, ByVal adatDay As DateEdit, ByVal acbWeek As LookUpEdit, _
                        ByVal acbCountry As LookUpEdit, ByVal acbRegion As LookUpEdit, _
                        ByVal acbRayon As LookUpEdit, ByVal acbSettlement As LookUpEdit)
        cbYear = acbYear
        cbQuarter = acbQuarter
        cbMonth = acbMonth
        datDay = adatDay
        cbWeek = acbWeek
        cbCountry = acbCountry
        cbRegion = acbRegion
        cbRayon = acbRayon
        cbSettlement = acbSettlement
        m_WeekList = CreatePeriodTable()
        m_MonthList = CreatePeriodTable()
        m_QuarterList = CreatePeriodTable()
    End Sub
    Public Sub BindPeriodFileds()
        eventManager.RemoveDataHandler(AggregateHeader_DB.TableAggregateHeader + ".YearForAggr")
        eventManager.RemoveDataHandler(AggregateHeader_DB.TableAggregateHeader + ".QuarterForAggr")
        eventManager.RemoveDataHandler(AggregateHeader_DB.TableAggregateHeader + ".MonthForAggr")
        eventManager.RemoveDataHandler(AggregateHeader_DB.TableAggregateHeader + ".WeekForAggr")
        eventManager.RemoveDataHandler(AggregateHeader_DB.TableAggregateHeader + ".DayForAggr")
        cbYear.DataBindings.Clear()
        cbYear.DataBindings.Add("EditValue", baseDataset, AggregateHeader_DB.TableAggregateHeader + ".YearForAggr", True, DataSourceUpdateMode.OnPropertyChanged)
        Core.LookupBinder.AddBinding(cbQuarter, baseDataset, AggregateHeader_DB.TableAggregateHeader + ".QuarterForAggr", False)
        Core.LookupBinder.AddBinding(cbMonth, baseDataset, AggregateHeader_DB.TableAggregateHeader + ".MonthForAggr", False)
        Core.LookupBinder.AddBinding(cbWeek, baseDataset, AggregateHeader_DB.TableAggregateHeader + ".WeekForAggr", False)
        Core.LookupBinder.BindDateEdit(datDay, baseDataset, AggregateHeader_DB.TableAggregateHeader + ".DayForAggr")
        datDay.Properties.MaxValue = DateTime.Today

        eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".YearForAggr", AddressOf Year_Changed)
        eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".QuarterForAggr", AddressOf Quarter_Changed)
        eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".MonthForAggr", AddressOf Month_Changed)
        eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".WeekForAggr", AddressOf Week_Changed)
        eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".DayForAggr", AddressOf Day_Changed)
    End Sub
    Public Sub BindAreaFields()
        eventManager.RemoveDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfsCountry")
        eventManager.RemoveDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfsRegion")
        eventManager.RemoveDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfsRayon")
        eventManager.RemoveDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfsSettlement")
        Dim isHumanAggregateCase As Boolean = (CaseType = AggregateCaseType.AggregateCase)
        Core.LookupBinder.BindCountryLookup(cbCountry, baseDataset, AggregateHeader_DB.TableAggregateHeader + ".idfsCountry")
        Core.LookupBinder.BindRegionLookup(cbRegion, baseDataset, AggregateHeader_DB.TableAggregateHeader + ".idfsRegion", isHumanAggregateCase)
        Core.LookupBinder.BindRayonLookup(cbRayon, baseDataset, AggregateHeader_DB.TableAggregateHeader + ".idfsRayon", isHumanAggregateCase)
        Core.LookupBinder.BindSettlementLookup(cbSettlement, baseDataset, AggregateHeader_DB.TableAggregateHeader + ".idfsSettlement", isHumanAggregateCase)

        eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfsCountry", AddressOf Country_Changed)
        eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfsRegion", AddressOf Region_Changed)
        eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfsRayon", AddressOf Rayon_Changed)
        eventManager.AttachDataHandler(AggregateHeader_DB.TableAggregateHeader + ".idfsSettlement", AddressOf Settlement_Changed)
    End Sub
    Private Sub Year_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        SetQuarter()
        SetMonth()
        SetWeek()
        If CurrentYear > 0 AndAlso CurrentTimeInterval = StatisticPeriodType.Year Then
            e.Row("datStartDate") = New DateTime(CurrentYear, 1, 1)
            e.Row("datFinishDate") = New DateTime(CurrentYear, 12, 31)
            m_CurrentTimeUnit = CurrentYear
        End If
        eventManager.Cascade(AggregateHeader_DB.TableAggregateHeader + ".QuarterForAggr")
        eventManager.Cascade(AggregateHeader_DB.TableAggregateHeader + ".MonthForAggr")
        eventManager.Cascade(AggregateHeader_DB.TableAggregateHeader + ".WeekForAggr")
        eventManager.Cascade(AggregateHeader_DB.TableAggregateHeader + ".DayForAggr")
    End Sub
    Private Sub Quarter_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If CurrentTimeInterval = StatisticPeriodType.Quarter AndAlso CurrentQuarter > 0 Then
            Dim r As DataRow = FindQuarter(CurrentQuarter)
            e.Row("datStartDate") = r("StartDay")
            e.Row("datFinishDate") = r("FinishDay")
            m_CurrentTimeUnit = CurrentQuarter
        End If

    End Sub
    Private Sub Month_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        SetDay()
        If CurrentTimeInterval = StatisticPeriodType.Day Then
            If CurrentMonth > 0 Then
                Dim r As DataRow = FindMonth(CurrentMonth)
                datDay.Properties.MinValue = CDate(r("StartDay"))
                If CDate(r("FinishDay")) > DateTime.Today Then
                    datDay.Properties.MaxValue = DateTime.Today
                Else
                    datDay.Properties.MaxValue = CDate(r("FinishDay"))
                End If
                If Not Utils.IsEmpty(CurrentDay) Then
                    Dim newDay As Date = CDate(CurrentDay)
                    If newDay.CompareTo(r("StartDay")) < 0 OrElse newDay.CompareTo(r("FinishDay")) > 0 Then
                        CurrentDay = DBNull.Value
                    End If
                End If
            Else
                datDay.Properties.MinValue = Date.MinValue
                datDay.Properties.MaxValue = DateTime.Today
                CurrentDay = DBNull.Value
            End If
            If Date.Today.CompareTo(datDay.Properties.MinValue) < 0 OrElse Date.Today.CompareTo(datDay.Properties.MaxValue) > 0 Then
                datDay.Properties.ShowToday = False
            Else
                datDay.Properties.ShowToday = True
            End If
        End If
        If CurrentTimeInterval = StatisticPeriodType.Month AndAlso CurrentMonth > 0 Then
            Dim r As DataRow = FindMonth(CurrentMonth)
            e.Row("datStartDate") = r("StartDay")
            e.Row("datFinishDate") = r("FinishDay")
            m_CurrentTimeUnit = CurrentMonth
        End If
        e.Row.EndEdit()
    End Sub
    Private Sub Week_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If CurrentTimeInterval = StatisticPeriodType.Week AndAlso CurrentWeek > 0 Then
            Dim r As DataRow = FindWeek(CurrentWeek)
            If Not r Is Nothing Then
                e.Row("datStartDate") = r("StartDay")
                e.Row("datFinishDate") = r("FinishDay")
                m_CurrentTimeUnit = CurrentWeek
            End If
        End If

    End Sub
    Private Sub Day_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If CurrentTimeInterval = StatisticPeriodType.Day AndAlso Not Utils.IsEmpty(CurrentDay) Then
            e.Row("datStartDate") = CurrentDay
            e.Row("datFinishDate") = CurrentDay
            m_CurrentTimeUnit = CurrentDay
            If CurrentMonth <> CDate(CurrentDay).Month Then
                CurrentMonth = CDate(CurrentDay).Month
            End If
            If CurrentYear <> CDate(CurrentDay).Year Then
                CurrentYear = CDate(CurrentDay).Year
            End If
        End If

    End Sub
    Private Sub Country_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If e.Row("idfsCountry") Is DBNull.Value Then
            e.Row("idfsCountry") = EidssSiteContext.Instance.CountryID
        End If
        If cbCountry.Visible AndAlso Not cbRegion.Visible Then
            e.Row("idfsAdministrativeUnit") = e.Row("idfsCountry")
        End If
        If (Not Utils.IsEmpty(e.Row("idfsRegion"))) AndAlso _
            CType(cbRegion.Properties.DataSource, DataView).Table.Select(String.Format("idfsCountry = {0} and idfsRegion = {1}", e.Row("idfsCountry"), e.Row("idfsRegion"))).Length = 0 Then
            e.Row("idfsRegion") = DBNull.Value
            e.Row.EndEdit()
        End If
        If Not bv.common.Configuration.BaseSettings.ScanFormsMode Then
            Core.LookupBinder.FilterRegion(cbRegion, e.Row("idfsCountry"))
        End If
        cbRegion.Enabled = CurrentAdminLevel <> StatisticAreaType.Country AndAlso CType(cbRegion.Properties.DataSource, DataView).Count > 0
        If CurrentAdminLevel = StatisticAreaType.Country Then
            CurrentAdminUnit = e.Row("idfsCountry")
        Else
            eventManager.Cascade(AggregateHeader_DB.TableAggregateHeader + ".idfsRegion")
        End If
    End Sub

    Private Sub Region_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Dim tmpRegion As Long = -1
        If Not Utils.IsEmpty(e.Row("idfsRegion")) Then
            tmpRegion = CLng(e.Row("idfsRegion"))
        End If
        If Not Utils.IsEmpty(e.Row("idfsRayon")) AndAlso _
            CType(cbRayon.Properties.DataSource, DataView).Table.Select(String.Format("idfsRegion = {0} and idfsRayon = {1}", tmpRegion, e.Row("idfsRayon"))).Length = 0 Then
            e.Row("idfsRayon") = DBNull.Value
            e.Row.EndEdit()
        End If
        Core.LookupBinder.FilterRayon(cbRayon, tmpRegion)
        cbRayon.Enabled = (CurrentAdminLevel = StatisticAreaType.Rayon OrElse CurrentAdminLevel = StatisticAreaType.Settlement) AndAlso CType(cbRayon.Properties.DataSource, DataView).Count > 0
        If CurrentAdminLevel = StatisticAreaType.Region Then
            CurrentAdminUnit = e.Row("idfsRegion")
        Else
            eventManager.Cascade(AggregateHeader_DB.TableAggregateHeader + ".idfsRayon")
        End If

    End Sub

    Private Sub Rayon_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        Dim tmpRayon As Long = -1
        If Not Utils.IsEmpty(e.Row("idfsRayon")) Then
            tmpRayon = CLng(e.Row("idfsRayon"))
        End If
        If Not Utils.IsEmpty(e.Row("idfsSettlement")) AndAlso _
            CType(cbSettlement.Properties.DataSource, DataView).Table.Select(String.Format("idfsRayon = {0} and idfsSettlement = {1}", tmpRayon, e.Row("idfsSettlement"))).Length = 0 Then
            e.Row("idfsSettlement") = DBNull.Value
        End If
        Core.LookupBinder.FilterSettlement(cbSettlement, tmpRayon)
        cbSettlement.Enabled = CurrentAdminLevel = StatisticAreaType.Settlement AndAlso CType(cbSettlement.Properties.DataSource, DataView).Count > 0
        If CurrentAdminLevel = StatisticAreaType.Rayon Then
            CurrentAdminUnit = e.Row("idfsRayon")
        Else
            eventManager.Cascade(AggregateHeader_DB.TableAggregateHeader + ".idfsSettlement")
        End If

    End Sub
    Private Sub Settlement_Changed(ByVal sender As Object, ByVal e As DataFieldChangeEventArgs)
        If CurrentAdminLevel = StatisticAreaType.Settlement Then
            CurrentAdminUnit = e.Row("idfsSettlement")
        End If
    End Sub


    Private ReadOnly Property baseDataset() As DataSet
        Get
            Return m_Owner.baseDataSet
        End Get
    End Property

    Private Shared Sub AddMonthRow(ByVal monthTable As DataTable, ByVal year As Integer, ByVal monthNum As Integer, ByVal monthName As String)
        Dim d As Date = New DateTime(year, monthNum, 1)
        If (d.Year = DateTime.Today.Year AndAlso d > DateTime.Today) Then
            Return
        End If
        Dim m As DataRow = monthTable.NewRow
        m("PeriodName") = EidssMessages.Get(monthName)
        m("StartDay") = d
        m("PeriodNumber") = d.Month
        m("PeriodID") = year.ToString() + "_" + d.Month.ToString()
        d = d.AddMonths(1)
        m("FinishDay") = d.AddDays(-1)
        monthTable.Rows.Add(m)
    End Sub

    Private Shared Function CreatePeriodTable() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("PeriodNumber", GetType(Integer)))
        dt.Columns.Add(New DataColumn("StartDay", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("FinishDay", GetType(DateTime)))
        dt.Columns.Add(New DataColumn("PeriodName", GetType(String)))
        dt.Columns.Add(New DataColumn("PeriodID", GetType(String)))
        dt.PrimaryKey = New DataColumn() {dt.Columns("PeriodNumber")}
        Return dt
    End Function

    Private Sub BindPeriodTable(ByVal cb As LookUpEdit, ByVal dt As DataTable)
        cb.Properties.Columns.Clear()
        cb.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() { _
            New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodNumber", EidssMessages.Get("colPeriodNumber", "Period Number"), 50, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near), _
            New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PeriodName", EidssMessages.Get("colPeriodName", "Period Name"), 200, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near)} _
        )
        cb.Properties.DataSource = New DataView(dt)
        cb.Properties.DisplayMember = "PeriodName"
        cb.Properties.ValueMember = "PeriodNumber"
    End Sub



    Public Sub FillMonthList(ByVal year As Integer)
        FillMonthList(m_MonthList, year)
        BindPeriodTable(cbMonth, m_MonthList)
    End Sub

    Public Shared Sub FillMonthList(ByVal monthTable As DataTable, ByVal year As Integer)
        If monthTable Is Nothing Then
            monthTable = CreatePeriodTable()
        Else
            monthTable.Clear()
        End If
        AddMonthRow(monthTable, year, 1, "January")
        AddMonthRow(monthTable, year, 2, "February")
        AddMonthRow(monthTable, year, 3, "March")
        AddMonthRow(monthTable, year, 4, "April")
        AddMonthRow(monthTable, year, 5, "May")
        AddMonthRow(monthTable, year, 6, "June")
        AddMonthRow(monthTable, year, 7, "July")
        AddMonthRow(monthTable, year, 8, "August")
        AddMonthRow(monthTable, year, 9, "September")
        AddMonthRow(monthTable, year, 10, "October")
        AddMonthRow(monthTable, year, 11, "November")
        AddMonthRow(monthTable, year, 12, "December")
    End Sub
    Public Sub FillQuarterList(ByVal year As Integer)
        m_QuarterList.Clear()
        Dim d As Date = New DateTime(year, 1, 1)
        For i As Integer = 1 To 4
            If (year = DateTime.Today.Year AndAlso d > DateTime.Today) Then
                Exit For
            End If
            Dim q As DataRow = m_QuarterList.NewRow
            q("StartDay") = d
            q("PeriodNumber") = i
            q("PeriodID") = year.ToString() + "_" + i.ToString()
            d = d.AddMonths(3)
            d = d.AddDays(-1)
            q("FinishDay") = d
            d = d.AddDays(1)
            q("PeriodName") = q("StartDay").ToString.Substring(0, 10) + "-" + q("FinishDay").ToString.Substring(0, 10)
            m_QuarterList.Rows.Add(q)
        Next
        BindPeriodTable(cbQuarter, m_QuarterList)

    End Sub

    Public Sub FillWeekList(ByVal year As Integer)
        m_WeekList.Clear()

        For Each wp As WeekPeriod In DatePeriodHelper.GetWeeksList(year)
            If (wp.WeekStartDate.Year = DateTime.Today.Year AndAlso wp.WeekStartDate > DateTime.Today) Then
                Exit For
            End If
            Dim weekRow As DataRow = m_WeekList.NewRow
            weekRow("PeriodNumber") = wp.WeekNumber
            weekRow("StartDay") = wp.WeekStartDate
            weekRow("PeriodID") = year.ToString() + "_" + wp.WeekNumber.ToString()
            weekRow("FinishDay") = wp.WeekStartDate.AddDays(6)
            weekRow("PeriodName") = String.Format("{0:d} - {1:d}", weekRow("StartDay"), weekRow("FinishDay"))
            m_WeekList.Rows.Add(weekRow)
        Next
        BindPeriodTable(cbWeek, m_WeekList)
    End Sub

    Public Sub FillYearList()
        cbYear.Properties.Items.Clear()
        For i As Integer = Date.Today.Year To m_MinYear Step -1
            cbYear.Properties.Items.Add(i)
        Next
    End Sub

    Public Function FindQuarter(ByVal quarter As Integer) As DataRow
        Return m_QuarterList.Rows.Find(quarter)
    End Function
    Public Function FindMonth(ByVal month As Integer) As DataRow
        Return m_MonthList.Rows.Find(month)
    End Function
    Public Function FindWeek(ByVal week As Integer) As DataRow
        Return m_WeekList.Rows.Find(week)
    End Function

    Public Sub SetYear()
        FillYearList()
        SetQuarter()
        SetMonth()
        SetWeek()
    End Sub

    Public Sub SetQuarter()
        If CurrentYear > 0 Then
            FillQuarterList(CurrentYear)
        Else
            cbQuarter.EditValue = DBNull.Value
            cbQuarter.Properties.DataSource = Nothing
        End If
    End Sub

    Public Sub SetMonth()
        If CurrentYear > 0 Then
            FillMonthList(CurrentYear)
        Else
            cbMonth.EditValue = DBNull.Value
            cbMonth.Properties.DataSource = Nothing
        End If
        SetDay()
    End Sub

    Public Sub SetWeek()
        If CurrentYear > 0 Then
            FillWeekList(CurrentYear)
        Else
            cbWeek.EditValue = DBNull.Value
            cbWeek.Properties.DataSource = Nothing
        End If
    End Sub

    Public Sub SetDay()
        If CurrentMonth >= 0 AndAlso PeriodType = StatisticPeriodType.Day Then
            datDay.Enabled = True
            datDay.EditValue = DBNull.Value
        Else
            datDay.EditValue = DBNull.Value
            datDay.Enabled = False
        End If
    End Sub

    Private Function CurrentRow() As DataRow
        If baseDataset.Tables.Count > 0 AndAlso baseDataset.Tables(AggregateHeader_DB.TableAggregateHeader).Rows.Count > 0 Then
            Return baseDataset.Tables(AggregateHeader_DB.TableAggregateHeader).Rows(0)
        Else
            Return Nothing
        End If
    End Function

    Public ReadOnly Property MinYear() As Integer
        Get
            Return m_MinYear
        End Get
    End Property

    Public ReadOnly Property AreaType() As StatisticAreaType
        Get
            If baseDataset.Tables(AggregateHeader_DB.TableSettings) Is Nothing OrElse baseDataset.Tables(AggregateHeader_DB.TableSettings).Rows.Count <> 1 OrElse baseDataset.Tables(AggregateHeader_DB.TableSettings).Rows(0)("idfsStatisticAreaType") Is DBNull.Value Then
                Return StatisticAreaType.None
            End If
            Return CType(baseDataset.Tables(AggregateHeader_DB.TableSettings).Rows(0)("idfsStatisticAreaType"), StatisticAreaType)
        End Get
    End Property

    Public ReadOnly Property PeriodType() As StatisticPeriodType
        Get
            If baseDataset.Tables(AggregateHeader_DB.TableSettings) Is Nothing OrElse baseDataset.Tables(AggregateHeader_DB.TableSettings).Rows.Count <> 1 OrElse baseDataset.Tables(AggregateHeader_DB.TableSettings).Rows(0)("idfsStatisticPeriodType") Is DBNull.Value Then
                Return StatisticPeriodType.None
            End If
            Return CType(baseDataset.Tables(AggregateHeader_DB.TableSettings).Rows(0)("idfsStatisticPeriodType"), StatisticPeriodType)
        End Get
    End Property

    Public ReadOnly Property CaseType() As AggregateCaseType
        Get
            If CurrentRow("idfsAggrCaseType") Is Nothing Then
                Return AggregateCaseType.None
            Else
                Return CType(CurrentRow("idfsAggrCaseType"), AggregateCaseType)
            End If
        End Get
    End Property

    Public Property CurrentDay() As Object
        Get
            Return CurrentRow("DayForAggr")
        End Get
        Set(ByVal value As Object)
            CurrentRow("DayForAggr") = value
            CurrentRow.EndEdit()
        End Set
    End Property
    Public Property CurrentMonth() As Integer
        Get
            If CurrentRow("MonthForAggr") Is DBNull.Value Then
                Return -1
            End If
            Return CInt(CurrentRow("MonthForAggr"))
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then
                CurrentRow("MonthForAggr") = value
            Else
                CurrentRow("MonthForAggr") = DBNull.Value
            End If
            CurrentRow.EndEdit()
        End Set
    End Property
    Public Property CurrentQuarter() As Integer
        Get
            If CurrentRow("QuarterForAggr") Is DBNull.Value Then
                Return -1
            End If
            Return CInt(CurrentRow("QuarterForAggr"))
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then
                CurrentRow("QuarterForAggr") = value
            Else
                CurrentRow("QuarterForAggr") = DBNull.Value
            End If
            CurrentRow.EndEdit()
        End Set
    End Property
    Public Property CurrentWeek() As Integer
        Get
            If CurrentRow("WeekForAggr") Is DBNull.Value Then
                Return -1
            End If
            Return CInt(CurrentRow("WeekForAggr"))
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then
                CurrentRow("WeekForAggr") = value
            Else
                CurrentRow("WeekForAggr") = DBNull.Value
            End If
            CurrentRow.EndEdit()
        End Set
    End Property
    Public Property CurrentYear() As Integer
        Get
            If CurrentRow("YearForAggr") Is DBNull.Value Then
                Return -1
            End If
            Return CInt(CurrentRow("YearForAggr"))
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then
                CurrentRow("YearForAggr") = value
            Else
                CurrentRow("YearForAggr") = DBNull.Value
            End If
            CurrentRow.EndEdit()
        End Set
    End Property
    Public Property CurrentTimeInterval() As StatisticPeriodType
        Get
            If CurrentRow() Is Nothing OrElse Utils.IsEmpty(CurrentRow("CurPeriodType")) Then
                Return StatisticPeriodType.None
            End If
            Return CType(CurrentRow("CurPeriodType"), StatisticPeriodType)
        End Get
        Set(ByVal value As StatisticPeriodType)
            CurrentRow("CurPeriodType") = value
            CurrentRow.EndEdit()
        End Set
    End Property

    Public Property CurrentAdminLevel() As StatisticAreaType
        Get
            If CurrentRow() Is Nothing OrElse Utils.IsEmpty(CurrentRow("CurAreaType")) Then
                Return StatisticAreaType.None
            End If
            Return CType(CurrentRow("CurAreaType"), StatisticAreaType)
        End Get
        Set(ByVal value As StatisticAreaType)
            CurrentRow("CurAreaType") = value
            CurrentRow.EndEdit()
        End Set
    End Property
    Private m_CurrentTimeUnit As Object
    Public Property CurrentTimeUnit() As Object
        Get
            Return m_CurrentTimeUnit
        End Get
        Set(ByVal value As Object)
            m_CurrentTimeUnit = value
        End Set
    End Property
    Public Property CurrentAdminUnit() As Object
        Get
            Return CurrentRow("idfsAdministrativeUnit")
        End Get
        Set(ByVal value As Object)
            CurrentRow("idfsAdministrativeUnit") = value
            CurrentRow.EndEdit()
        End Set
    End Property
    Public Property StartDate() As Object
        Get
            Return CurrentRow("datStartDate")
        End Get
        Set(ByVal value As Object)
            CurrentRow("datStartDate") = value
            CurrentRow.EndEdit()
        End Set
    End Property
    Public Property FinishDate() As Object
        Get
            Return CurrentRow("datFinishDate")
        End Get
        Set(ByVal value As Object)
            CurrentRow("datFinishDate") = value
            CurrentRow.EndEdit()
        End Set
    End Property
    Public Property Country() As Object
        Get
            Return CurrentRow("idfsCountry")
        End Get
        Set(ByVal value As Object)
            CurrentRow("idfsCountry") = value
            CurrentRow.EndEdit()
        End Set
    End Property
    Public Property Region() As Object
        Get
            Return CurrentRow("idfsRegion")
        End Get
        Set(ByVal value As Object)
            CurrentRow("idfsRegion") = value
            CurrentRow.EndEdit()
        End Set
    End Property
    Public Property Rayon() As Object
        Get
            Return CurrentRow("idfsRayon")
        End Get
        Set(ByVal value As Object)
            CurrentRow("idfsRayon") = value
            CurrentRow.EndEdit()
        End Set
    End Property
    Public Property Settlement() As Object
        Get
            Return CurrentRow("idfsSettlement")
        End Get
        Set(ByVal value As Object)
            CurrentRow("idfsSettlement") = value
            CurrentRow.EndEdit()
        End Set
    End Property
    Private Shared Function GetMatrixStub(ByVal formType As FFType) As List(Of AggregateCaseSection)
        Dim stub As New List(Of AggregateCaseSection)
        Dim section As AggregateCaseSection
        Select Case formType
            Case FFType.HumanAggregateCase
                section = AggregateCaseSection.HumanCase
            Case FFType.VetAggregateCase
                section = AggregateCaseSection.VetCase
            Case FFType.VetEpizooticAction
                section = AggregateCaseSection.SanitaryAction
            Case FFType.VetEpizooticActionDiagnosisInv
                section = AggregateCaseSection.DiagnosticAction
            Case FFType.VetEpizooticActionTreatment
                section = AggregateCaseSection.ProphylacticAction
            Case Else
                Return Nothing
        End Select
        stub.Add(section)
        Return stub
    End Function
    Private Shared Function SetGridDockStyleToFill(ByVal ffGrid As FlexibleForms.FFPresenter) As Boolean
        Dim sectionTable As FlexibleForms.Components.SectionTable
        sectionTable = ffGrid.GetSectionTableByIndex(0)
        If Not (sectionTable Is Nothing) Then
            sectionTable.Dock = DockStyle.Fill
            'Dim gridView As GridView = CType(sectionTable.GridControlMain.MainView, GridView)
            'If Not gridView Is Nothing Then
            '    gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None
            'End If
        Else
            Return False
        End If
        Return sectionTable.IsStubLoaded()
    End Function
    Public Shared Sub ClearFlexibleForm(ByVal ffGrid As FlexibleForms.FFPresenter)
        ffGrid.ClearUserData()
    End Sub
    Public Shared Function ShowFlexibleForm(ByVal ffGrid As FlexibleForms.FFPresenter, ByVal observationID As Long, ByVal formType As FFType, ByVal templateID As Nullable(Of Long), ByVal idfVersion As Nullable(Of Long), Optional ByVal isSummary As Boolean = False) As Boolean
        'Dim stub As List(Of AggregateCaseSection) = GetMatrixStub(formType)
        'If stub Is Nothing Then
        'Return False
        'End If
        ffGrid.ShowAggregateCase(observationID, templateID, idfVersion, formType, True, isSummary)
        'ffGrid.ShowFlexibleForm(stub, observationID, formType)
        Return SetGridDockStyleToFill(ffGrid)
    End Function
    Public Shared Function ShowSummaryFlexibleForm(ByVal ffGrid As FlexibleForms.FFPresenter, ByVal observations As List(Of Long), ByVal formType As FFType) As Boolean
        If observations Is Nothing Then
            Return False
        End If
        Dim stub As List(Of AggregateCaseSection) = GetMatrixStub(formType)
        If stub Is Nothing Then
            Return False
        End If
        Dim result As Boolean = ffGrid.ShowSummary(observations, formType)
        Return SetGridDockStyleToFill(ffGrid) And result
    End Function
    Public Shared Function GetGridView(ByVal ffGrid As FlexibleForms.FFPresenter) As GridView
        Dim sectionTable As FlexibleForms.Components.SectionTable
        sectionTable = ffGrid.GetSectionTableByIndex(0)
        If Not (sectionTable Is Nothing) Then
            Return CType(sectionTable.GridControlMain.MainView, GridView)
        Else
            Return Nothing
        End If
    End Function

    Public ReadOnly Property EmptyAggregateSettingsMessage() As String
        Get
            Select Case CaseType
                Case AggregateCaseType.AggregateCase
                    Return EidssMessages.Get("mbEmptyHumanAggrSettings", "Human Aggregate settings is empty.")
                Case AggregateCaseType.VetAggregateAction
                    Return EidssMessages.Get("mbEmptyVetAggrActionSettings", "Vet Aggregate Action settings are empty.")
                Case AggregateCaseType.VetAggregateCase
                    Return EidssMessages.Get("mbEmptyVetAggrSettings", "Vet Aggregate settings are empty.")
                Case Else
                    Dbg.Fail("aggregate case type is not defined")
                    Return ""
            End Select
        End Get
    End Property

    Public ReadOnly Property NoAggregateCaseMessage() As String
        Get
            Select Case CaseType
                Case AggregateCaseType.AggregateCase
                    Return EidssMessages.Get("mbNoHumanAggregateCase", "Human Aggregate Case does not exist for current administrative unit and time interval.")
                Case AggregateCaseType.VetAggregateAction
                    Return EidssMessages.Get("mbNoVetAggregateAction", "Vet Aggregate Actions does not exist for current administrative unit and time interval.")
                Case AggregateCaseType.VetAggregateCase
                    Return EidssMessages.Get("mbNoVetAggregateCase", "Vet Aggregate Case does not exist for current administrative unit and time interval.")
                Case Else
                    Dbg.Fail("aggregate case type is not defined")
                    Return ""
            End Select
        End Get
    End Property
    Public Shared Sub DisplaySummary(ByVal ffGrid As FlexibleForms.FFPresenter, ByVal formType As FFType, ByVal observations As List(Of Long), ByVal lbNoMatrix As Control)
        If observations Is Nothing Then
            'DisplayEmptySummary(ffGrid, formType, lbNoMatrix)
            'Return
            observations = New List(Of Long)()
        End If
        Dim result As Boolean = ShowSummaryFlexibleForm(ffGrid, observations, formType)
        If Not lbNoMatrix Is Nothing Then
            lbNoMatrix.Visible = Not result
        End If
        ffGrid.Visible = result
        ffGrid.ReadOnly = True
    End Sub

    Public Shared Sub DisplayEmptySummary(ByVal ffGrid As FlexibleForms.FFPresenter, ByVal formType As FFType, ByVal lbNoMatrix As Control)
        'DisplaySummary(ffGrid, formType, Nothing, lbNoMatrix)
        'Return
        Dim matrixVersion As Nullable(Of Long)
        Dim view As DataView = LookupCache.Get(LookupTables.AggregateMatrixVersion)
        Dim matrixType As AggregateCaseSection
        Select Case formType
            Case FFType.HumanAggregateCase
                matrixType = AggregateCaseSection.HumanCase
            Case FFType.VetAggregateCase
                matrixType = AggregateCaseSection.VetCase
            Case FFType.VetEpizooticAction
                matrixType = AggregateCaseSection.SanitaryAction
            Case FFType.VetEpizooticActionDiagnosisInv
                matrixType = AggregateCaseSection.DiagnosticAction
            Case FFType.VetEpizooticActionTreatment
                matrixType = AggregateCaseSection.ProphylacticAction
        End Select
        Dim filter As String = String.Format("idfsAggrCaseSection={0} and blnIsActive=1", CLng(matrixType))
        view.RowFilter = filter
        If view.Count > 0 Then
            matrixVersion = CLng(view(0)("idfVersion"))
        End If
        Dim result As Boolean = ShowFlexibleForm(ffGrid, -5, formType, Nothing, matrixVersion, True)
        If Not lbNoMatrix Is Nothing Then
            lbNoMatrix.Visible = Not result
        End If
        ffGrid.Visible = result

        Dim gridView As GridView = GetGridView(ffGrid)
        If Not gridView Is Nothing Then
            gridView.OptionsBehavior.Editable = False
        End If
    End Sub
End Class
