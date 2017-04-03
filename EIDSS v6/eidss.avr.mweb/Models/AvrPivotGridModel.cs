using System.Data;
using DevExpress.Web.Mvc;
using eidss.avr.db.Common;

namespace eidss.avr.mweb.Models
{
    public class AvrPivotGridModel : AvrPivotGridData
    {
        public AvrPivotGridModel(AvrPivotSettings pivotSettings, DataTable realPivotData) : base(realPivotData)
        {
            bv.common.Core.Utils.CheckNotNull(pivotSettings, "pivotSettings");

            PivotSettings = pivotSettings;
            ControlPivotGridSettings = null;
        }

        public DataTable PivotData
        {
            get { return PivotSettings.ShowDataInPivot ? RealPivotData : ClonedPivotData; }
            set { RealPivotData = value; }
        }

        public AvrPivotSettings PivotSettings { get; set; }
        public PivotGridSettings ControlPivotGridSettings { get; set; }
        public DropDownEditSettings ControlTotalsSettings { get; set; }

        public bool IsFirstLoad { get; set; }
        public bool ShowPrefilter { get; set; }

        public object GetAvailableMapFieldView()
        {
            if (PivotSettings.LayoutDataset != null)
            {
                return new DataView(PivotSettings.LayoutDataset.LayoutSearchField);
            }
            return null;
        }
    }
}