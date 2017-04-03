#region Using

using System;
using bv.common;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.win;
using DevExpress.XtraCharts;
using DevExpress.XtraNavBar;
using DevExpress.XtraPrinting;
using EIDSS.RAM.Components;
using EIDSS.RAM.Presenters;
using EIDSS.RAM.Presenters.Base;
using EIDSS.RAM_DB.Common.EventHandlers;
using EIDSS.RAM_DB.DBService;
using EIDSS.RAM_DB.DBService.Enumerations;
using EIDSS.RAM_DB.Views;

#endregion

namespace EIDSS.RAM.Layout
{
    public sealed partial class ChartForm : BaseLayoutForm, IChartView
    {
        public event ChangeOrientationEventHandler ChangeOrientation;

        private readonly BaseRamDbService m_ChartFormService;
        private readonly ChartPresenter m_ChartPresenter;
        private readonly ChartControlMediator m_ChartControlMediator;
        

        public ChartForm()
        {
            try
            {
                Trace.WriteLine(Trace.Kind.Info, "ChartForm creating...");
                if (IsDesignMode())
                    return;

                m_ChartPresenter = (ChartPresenter) SharedPresenter[this];

                InitializeComponent();

                m_ChartControlMediator = new ChartControlMediator(grcChartMain);

                m_ChartFormService = new BaseRamDbService();
                DbService = m_ChartFormService;
            }
            catch (Exception ex)
            {
                if (BaseSettings.ThrowExceptionOnError)
                    throw;
                ErrorForm.ShowError(ex);
            }
        }

        public string FilterText
        {
            get
            {
                if (IsDesignMode())
                    return "";
                return memFilter.Text;
            }
            set
            {
                if (IsDesignMode())
                    return;
                memFilter.Text = value;
            }
        }
        public string ChartName
        {
            get
            {
                if (IsDesignMode())
                    return "";
                return tbChartName.Text;
            }
            set
            {
                if (IsDesignMode())
                    return;
                tbChartName.Text = value;
            }
        }

        

        /// <summary>
        /// Data source for chart control
        /// </summary>
        public object DataSource
        {
            get { return ChartControl.DataSource; }
            set
            {
                if (IsDesignMode())
                    return;
                ChartControl.DataSource = value;
            }
        }

        public ChartControl ChartControl
        {
            get
            {
                if (IsDesignMode())
                    return new ChartControl();
                return m_ChartControlMediator.ChartControl;
            }
        }

        public PrintingSystem PrintingSystem
        {
            get { return printingSystem; }
        }

        private PivotChartTitle Title { get; set; }

        protected override void DefineBinding()
        {
            Trace.WriteLine(Trace.Kind.Undefine, "ChartForm.DefineBinding() call");
            using (SharedPresenter.ContextKeeper.CreateNewContext("DefineBinding"))
            {
                m_ChartPresenter.BindChartName(tbChartName);

                m_ChartPresenter.BindChartType(cbChart);

                m_ChartPresenter.BindShowXLabels(checkShowXAxesLabels);
                checkShowXAxesLabels_CheckedChanged(this, new EventArgs());

                m_ChartPresenter.BindShowPointLabels(checkPointLabels);
                checkPointLabels_CheckedChanged(this, new EventArgs());

                m_ChartPresenter.BindPivotAxis(checkPivotAxes);
                checkPivotAxes_CheckedChanged(this, new EventArgs());
            }
        }

        #region Chart run-time layout

        public void SetChartTitles(PivotChartTitle title)
        {
            m_ChartControlMediator.ChartName = tbChartName.Text;
            m_ChartControlMediator.ChartFilter = FilterText;
            Title = title;
            UpdateAxisTitles();
        }

        private void tbMapName_EditValueChanged(object sender, EventArgs e)
        {
            m_ChartControlMediator.ChartName = tbChartName.Text;
        }

        private void memFilter_EditValueChanged(object sender, EventArgs e)
        {
            m_ChartControlMediator.ChartFilter = FilterText;
        }

        private void cbChart_EditValueChanged(object sender, EventArgs e)
        {
            // workaround for prevent of set empty value
            if (Utils.IsEmpty(cbChart.EditValue))
            {
                cbChart.EditValue = (long) DBChartType.chrBar;
                return;
            }

            ViewType chartType = ChartPresenter.GetChartType(cbChart.EditValue);
            ChartControl.SeriesTemplate.ChangeView(chartType);
            if (ChartControl.Diagram is Diagram3D)
            {
                var diagram = (Diagram3D) ChartControl.Diagram;
                diagram.RuntimeRotation = true;
                diagram.RuntimeZooming = true;
                diagram.RuntimeScrolling = true;
                diagram.ZoomPercent = ((chartType == ViewType.Doughnut3D) || (chartType == ViewType.Pie3D)) ? 100 : 150;
            }
            else if (ChartControl.Diagram is XYDiagram)
            {
                var diagram  = (XYDiagram) ChartControl.Diagram;
                diagram.AxisX.Range.SideMarginsEnabled = (chartType == ViewType.Bar);

                diagram.AxisX.Title.Visible = true;
                diagram.AxisY.Title.Visible = true;
            }
            checkShowXAxesLabels.Enabled = (!(ChartControl.Diagram is SimpleDiagram) &&
                                            !(ChartControl.Diagram is SimpleDiagram3D));
            checkShowXAxesLabels_CheckedChanged(sender, e);
        }

      
      

        private void checkPointLabels_CheckedChanged(object sender, EventArgs e)
        {
            ChartControl.SeriesTemplate.Label.Visible = checkPointLabels.Checked;
        }

        private void checkShowXAxesLabels_CheckedChanged(object sender, EventArgs e)
        {
            if (ChartControl.Diagram is XYDiagram)
            {
                ((XYDiagram) ChartControl.Diagram).AxisX.Label.Visible = checkShowXAxesLabels.Checked;
            }
            else if (ChartControl.Diagram is XYDiagram3D)
            {
                ((XYDiagram3D) ChartControl.Diagram).AxisX.Label.Visible = checkShowXAxesLabels.Checked;
            }
            else if (ChartControl.Diagram is RadarDiagram)
            {
                ((RadarDiagram) ChartControl.Diagram).AxisX.Label.Visible = checkShowXAxesLabels.Checked;
            }
        }

        private void checkPivotAxes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAxisTitles();

            ChangeOrientationEventHandler eventHandler = ChangeOrientation;
            if (eventHandler != null)
            {
                eventHandler(new ChartChangeOrientationEventArgs(!checkPivotAxes.Checked));
            }
        }

        private void UpdateAxisTitles()
        {
            if (Title != null)
            {
                m_ChartControlMediator.AxisXTitle = checkPivotAxes.Checked ? Title.ColumnTitle : Title.RowTitle;
                m_ChartControlMediator.AxisYTitle = Title.DataTitle;
            }
        }
        #endregion

        #region Nav Bar Layout

        private void nbControlChart_GroupExpanded(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group == nbGroupSettings)
            {
                nbControlChart.Height = nbGroupSettings.ControlContainer.Height +
                                        BaseRamPresenter.NavBarGroupHeaderHeight;
            }
        }

        private void nbControlChart_GroupCollapsed(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group == nbGroupSettings)
            {
                nbControlChart.Height = BaseRamPresenter.NavBarGroupHeaderHeight;
//                nbControlChart.View = (DevExpress.XtraNavBar.ViewInfo.BaseViewInfoRegistrator)nbControlChart.AvailableNavBarViews.ToArray()[21];
  //              nbControlChart.ResetStyles();
            }
        }

        #endregion
    }
}