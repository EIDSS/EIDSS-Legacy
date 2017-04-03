using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BLToolkit.EditableObjects;
using bv.winclient.BasePanel;
using bv.winclient.Layout;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
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
            var layout = (Control)panel.GetLayout();
            ownerControl.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
            return panel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerControl"></param>
        /// <param name="workMode"></param>
        public static VectorSampleListPanel AddVectorSamplePanel(this Control ownerControl, VectorSampleListPanel.Modes workMode)
        {
            var panel = new VectorSampleListPanel(workMode) { InlineMode = InlineMode.UseCreateButton };
            
            var layoutGroup = (LayoutGroup)panel.GetLayout();
            layoutGroup.SearchPanelVisible = false;
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
            layoutGroup.SearchPanelVisible = false;
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
        public static VectorLabTestListPanel AddLabTestPanel(this Control ownerControl)
        {
            var panel = new VectorLabTestListPanel();

            var layoutGroup = (LayoutGroup)panel.GetLayout();
            layoutGroup.SearchPanelVisible = false;
            var layout = (Control)layoutGroup;
            ownerControl.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
            return panel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vsSession"></param>
        /// <param name="sessionToVectorType"></param>
        public static void ShowSessionToVectorTypeForm(VsSession vsSession, EditableList<SessionToVectorTypeItem> sessionToVectorType)
        {
            var panel = new SessionToVectorTypeDetail();
            panel.FillList(vsSession.idfVectorSurveillanceSession, sessionToVectorType, vsSession.PoolsVectors);
            BaseFormManager.ShowSimpleFormModal(panel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vsSession"></param>
        public static void ShowSessionToVectorTypeForm(this VsSession vsSession)
        {
            ShowSessionToVectorTypeForm(vsSession, vsSession.SessionToVectorType);
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
                var navBarGroup = new NavBarGroup(summaryTable.TestTypeName)
                                      {
                                          ControlContainer = navBarControlContainer,
                                          Expanded = true,
                                          GroupStyle = NavBarGroupStyle.ControlContainer,
                                          Name = String.Format("navBarGroup_{0}", summaryTable.TestTypeName),
                                          GroupClientHeight = 115
                                      };

                navBarControl.Groups.Add(navBarGroup);

                #region Создание грида в группе
                
                var gridControl = new GridControl();
                var gridView = new GridView();
                gridControl.MainView = gridView;
                gridControl.Name = String.Format("gridControl_{0}", summaryTable.TestTypeName);
                gridControl.ViewCollection.AddRange(new BaseView[] {gridView});
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
    }
}
