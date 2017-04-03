using System;
using System.Globalization;
using System.Xml;
using bv.common;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;

namespace EIDSS.Reports.BaseControls.Aggregate
{
    public sealed partial class TimeUnitReport : XtraReport
    {
        public TimeUnitReport()
        {
            InitializeComponent();
        }

        internal void SetParameters(DbManagerProxy manager, string lang, string xml)
        {
            Utils.CheckNotNullOrEmpty(lang, "lang");
            Utils.CheckNotNullOrEmpty(xml, "xml");

            this.RebindDateAndFont(lang);
            this.RebindAccessRigths();

            timeUnitDataSet1.sp_Rep_GetAggSumParam_TimeUnit.Clear();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            foreach (XmlElement element in xmlDoc.GetElementsByTagName("TimeIntervalUnit"))
            {
                XmlAttribute startAttribute = element.Attributes["StartDate"];
                XmlAttribute finishAttribute = element.Attributes["FinishDate"];
                DateTime startDate = DateTime.Parse(startAttribute.Value, CultureInfo.InvariantCulture);
                DateTime finishDate = DateTime.Parse(finishAttribute.Value, CultureInfo.InvariantCulture);
                timeUnitDataSet1.sp_Rep_GetAggSumParam_TimeUnit.Addsp_Rep_GetAggSumParam_TimeUnitRow(startDate, finishDate);
            }
        }
    }
}