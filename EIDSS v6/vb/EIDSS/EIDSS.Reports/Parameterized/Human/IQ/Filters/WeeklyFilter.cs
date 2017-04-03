using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Filters;
using bv.common.Core;
using bv.winclient.Core;
using eidss.model.Core;

namespace EIDSS.Reports.Parameterized.Human.IQ.Filters
{
    public partial class WeeklyFilter : BaseLookupFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (WeeklyFilter));
        private const string StartYearColumnNumber = "intStartYear";
        private const string EndYearColumnNumber = "intEndYear";
        private const string WeekColumnNumber = "intWeekNumber";
        private const int StartYear = 2000;
        private const int EndYear = 2031;
        private const DayOfWeek FirstDayOfWeek = DayOfWeek.Monday;
        public long m_YearNumber;

        public WeeklyFilter()
        {
            InitializeComponent();
        }

        public DateTime StartDate
        {
            get
            {
                return EditValue is DateTime
                           ? (DateTime) EditValue
                           : StartDate;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long YearNumber
        {
            get { return m_YearNumber; }
            set
            {
                if (WinUtils.IsComponentInDesignMode(this))
                {
                    return;
                }
                if (m_YearNumber != value)
                {
                    m_YearNumber = value;
                    DataSource.RowFilter = string.Format("{0}={2} OR {1}={2}", StartYearColumnNumber, EndYearColumnNumber, value);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ExactFormat { get; set; }

        protected override string KeyColumnName
        {
            get { return "idfsWeek"; }
        }

        protected override string ValueColumnName
        {
            get { return "strWeekName"; }
        }

        protected override string LookupCaption
        {
            get { return lblLookupName.Text; }
        }

        public void SetCurrentDate()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return ;
            }

            DataRow foundrow = DataSource.Table.Rows.Cast<DataRow>().Where(
                row =>
                    {
                        var startDate = (DateTime) row[KeyColumnName];
                        return (startDate.AddDays(7) > DateTime.Now && startDate <= DateTime.Now);
                    }).FirstOrDefault();

            if (foundrow == null)
            {
                throw new AvrException("Week filter failed. Cannot select current date from the filter");
            }

            EditValue = foundrow[KeyColumnName];
        }

        protected override DataView CreateDataSource()
        {
            if (WinUtils.IsComponentInDesignMode(this))
            {
                return new DataView();
            }
            DataTable dataTable = CreateTableStructure();

            FillTableData(dataTable);

            return CreateView(dataTable);
        }

        private DataTable CreateTableStructure()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(KeyColumnName, typeof (DateTime));
            dataTable.Columns.Add(ValueColumnName, typeof (string));
            dataTable.Columns.Add(StartYearColumnNumber, typeof (int));
            dataTable.Columns.Add(EndYearColumnNumber, typeof (int));
            dataTable.Columns.Add(WeekColumnNumber, typeof (int));
            return dataTable;
        }

        private void FillTableData(DataTable dataTable)
        {
            foreach (WeekPeriod wp in DatePeriodHelper.GetWeeksList(StartYear))
            {
                DataRow row = dataTable.NewRow();
                row[KeyColumnName] = wp.WeekStartDate;
                DateTime endDate = wp.WeekStartDate.AddDays(6);
                row[WeekColumnNumber] = wp.WeekNumber;
                row[StartYearColumnNumber] = wp.WeekStartDate.Year;
                row[StartYearColumnNumber] = endDate.Year;
                string startDateFormat;
                string endDateFormat;
                if (Utils.IsEmpty(ExactFormat))
                {
                    startDateFormat = ReportRebinder.ToDateStringCurrentCulture(wp.WeekStartDate);
                    endDateFormat = ReportRebinder.ToDateStringCurrentCulture(endDate);
                }
                else
                {
                    startDateFormat = wp.WeekStartDate.ToString(ExactFormat);
                    endDateFormat = endDate.ToString(ExactFormat);
                }
                row[ValueColumnName] = string.Format("{0:00} ({1} - {2})", row[WeekColumnNumber], startDateFormat, endDateFormat);

                dataTable.Rows.Add(row);
            }
            dataTable.AcceptChanges();
        }

        private DataView CreateView(DataTable dataTable)
        {
            string filter = string.Format("{0}={2} OR {1}={2}", StartYearColumnNumber, EndYearColumnNumber, DateTime.Now.Year);
            var view = new DataView(dataTable, filter, KeyColumnName, DataViewRowState.OriginalRows);
            return view;
        }

        protected override void ApplyResources()
        {
            base.ApplyResources();
            m_Resources.ApplyResources(lblLookupName, "lblLookupName");
            m_Resources.ApplyResources(this, "$this");
        }
    }
}