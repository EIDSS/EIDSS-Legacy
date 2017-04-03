using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Layout;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using eidss.model.Core;
using eidss.model.Model;
using eidss.model.Schema;
using eidss.winclient.Helpers;

namespace eidss.winclient.VectorSurveillance
{
    public static class VectorSurveillanceHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerControl"></param>
        public static VectorListPanel AddPoolsVectorsPanel(this Control ownerControl)
        {
            var panel = new VectorListPanel();
            var layout = (LayoutGroup)panel.GetLayout();
            ownerControl.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
            layout.SearchPanelVisible = false;
            return panel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerControl"></param>
        public static VsSessionSummaryPanel AddVsSessionSummaryPanel(this Control ownerControl)
        {
            var panel = new VsSessionSummaryPanel();
            var layout = (LayoutGroup)panel.GetLayout();
            ownerControl.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
            layout.SearchPanelVisible = false;
            return panel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerControl"></param>
        public static VectorSampleListPanel AddVectorSamplePanel(this Control ownerControl)
        {
            var panel = new VectorSampleListPanel();

            var layoutGroup = (LayoutGroup)panel.GetLayout();
            var layout = (Control)layoutGroup;
            ownerControl.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
            return panel;
        }

        /// <summary>
        /// Добавление панели Field Test
        /// </summary>
        /// <param name="ownerControl"></param>
        /// <returns></returns>
        public static VectorFieldTestListPanel AddFieldTestPanel(this Control ownerControl)
        {
            var panel = new VectorFieldTestListPanel();
            var layoutGroup = (LayoutGroup)panel.GetLayout();
            var layout = (Control)layoutGroup;
            ownerControl.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
            return panel;
        }

        /// <summary>
        /// Добавление панели Lab Test
        /// </summary>
        /// <param name="ownerControl"></param>
        /// <returns></returns>
        public static VectorLabTestListPanel AddLabTestPanel(this Control ownerControl)
        {
            var panel = new VectorLabTestListPanel();
            var layoutGroup = (LayoutGroup)panel.GetLayout();
            var layout = (Control)layoutGroup;
            ownerControl.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
            return panel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public static void ShowControlOnForm(Control control)
        {
            control.Dock = DockStyle.Fill;
            var frm = new Form
            {
                Size = new Size(800, 600),
                StartPosition = FormStartPosition.CenterScreen,
            };
            frm.Controls.Add(control);
            frm.ShowDialog();
        }

        /// <summary>
        /// На основе страниц суммирования наполняет интерфейс визуальными таблицами
        /// </summary>
        /// <param name="navBarControl"></param>
        /// <param name="summaryTables"></param>
        public static void FillTestSummary(this NavBarControl navBarControl, List<SummaryTable> summaryTables)
        {
            navBarControl.Groups.Clear(); //TODO надо ли как-то их из памяти вычищать?
            foreach (var summaryTable in summaryTables)
            {
                //navBarControlContainer
                var navBarControlContainer = new NavBarGroupControlContainer();
                navBarControl.Controls.Add(navBarControlContainer);

                //navBarGroup
                var navBarGroup = new NavBarGroup(summaryTable.TestName)
                                      {
                                          ControlContainer = navBarControlContainer,
                                          Expanded = true,
                                          GroupStyle = NavBarGroupStyle.ControlContainer,
                                          Name = String.Format("navBarGroup_{0}", summaryTable.TestName),
                                          GroupClientHeight = 115
                                      };

                navBarControl.Groups.Add(navBarGroup);

                #region Создание грида в группе

                var gridControl = new GridControl();
                var gridView = new GridView();
                gridControl.MainView = gridView;
                gridControl.Name = String.Format("gridControl_{0}", summaryTable.TestName);
                gridControl.ViewCollection.AddRange(new BaseView[] { gridView });
                gridView.OptionsBehavior.Editable = false;
                gridView.OptionsBehavior.ReadOnly = true;
                gridView.OptionsView.ColumnAutoWidth = true;
                gridView.OptionsView.ShowGroupPanel = false;
                gridControl.DataSource = summaryTable.DataSource;
                navBarControlContainer.Controls.Add(gridControl);
                gridControl.Dock = DockStyle.Fill;

                //проходим по всем столбцам и выставляем им запрет на редактирование
                foreach (GridColumn column in gridView.Columns)
                {
                    GridHelper.SetColumnState(column, true);
                }

                #endregion

                //
                //navBarControlContainer.Dock = DockStyle.Fill;
            }
            if (navBarControl.Groups.Count > 0) navBarControl.ActiveGroup = navBarControl.Groups[0];
        }

        /// <summary>
        /// 
        /// </summary>
        public static CopyDialogWindow ShowCopyDialogWindow()
        {
            var panel = new CopyDialogWindow();
            var acc = CopyDialogWindowItem.Accessor.Instance(null);
            IObject bo;
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                bo = acc.CreateNew(manager, null);
                panel.BusinessObject = bo;
            }
            BaseFormManager.ShowModal(panel, bo);
            return panel;
        }
    }
}
