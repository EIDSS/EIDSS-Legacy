using System;
using DevExpress.XtraEditors;
using eidss.model.Avr.Chart;

namespace eidss.avr.ChartForm
{
    public partial class BaseChartSettings : XtraUserControl, ISettingsPanel
    {
        public BaseChartSettings()
        {
            InitializeComponent();
        }

        public BaseChartSettings(ChartDetailPanel chartDetailPanel)
        {
            InitializeComponent();
            ChartDetailPanel = chartDetailPanel;
        }

        public ChartDetailPanel ChartDetailPanel { get; set; }
        protected ChartPlaceHolder ChartPlaceHolder { get { return ChartDetailPanel.ChartPlaceHolder; } }
        protected AvrChartProperties ChartProperties { get { return ChartDetailPanel.ChartProperties; } }

        public virtual void Init(object properties)
        {
            
        }

        public virtual object ToProperties()
        {
            return null;
        }

        public virtual void FromProperties(object props)
        {
            
        }

        public Type PropertiesType { get; set; }
        public int Index { get; set; }
    }
}
