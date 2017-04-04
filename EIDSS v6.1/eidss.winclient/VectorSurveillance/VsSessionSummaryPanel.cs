using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using bv.winclient.Layout;
using eidss.model.Schema;
using eidss.winclient.Core;
using eidss.winclient.Helpers;
using eidss.winclient.Location;
using eidss.winclient.Schema;
using bv.common.Enums;

namespace eidss.winclient.VectorSurveillance
{
    public partial class VsSessionSummaryPanel : BaseGroupPanel_VsSessionSummary
    {
        protected override void AfterChangeRow(RowObjectEventArgs e)
        {
            base.AfterChangeRow(e);
            //это для того, чтобы Vectors перерисовалось (перерасчиталось поле)
            var session = BusinessObject.Parent as VsSession;
            if (session == null) return;
            session.strFieldSessionID = session.strFieldSessionID;
        }

        private GridColumnCollection Columns { get { return Grid.GridView.Columns; } }

        /// <summary>
        /// 
        /// </summary>
        public VsSessionSummaryPanel()
        {
            InitializeComponent();
            EditByDoubleClick = true;
            TopPanelVisible = true;
            SearchPanelVisible = false;
            AllowCustomization = true;
            Field2LookupMap = new Dictionary<string, string>
                {
                    {"idfsVectorType", "VectorTypeLookup"},
                    {"idfsVectorSubType", "VectorSubTypeLookup"}
                };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override string GetDetailFormName(IObject o)
        {
            return "VsSessionSummaryPanel";
        }

        private VsSessionSummary fakeSessionSummary { get; set; }
        private RepositoryItemPopupContainerEdit DiagnosesPopupContainer { get; set; }
        internal VsSessionSummaryDiagnosisPanel DiagnosisPanel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dummyObjectWithLookups"></param>
        /// <param name="manager"></param>
        public override void InitGridBehavior(IObject dummyObjectWithLookups, DbManagerProxy manager)
        {
            base.InitGridBehavior(dummyObjectWithLookups, manager);

            fakeSessionSummary = dummyObjectWithLookups as VsSessionSummary;
            if (fakeSessionSummary == null) return;

            //Record ID
            var column = Grid.GridView.Columns.ColumnByName("strVSSessionSummaryID");
            if (column != null) GridHelper.SetColumnState(column, true);

            //Location
            column = Grid.GridView.Columns.ColumnByName("strLocation");
            if (column != null)
            {
                var editor = new LocationRepositoryLookup(column, GetCurrentLocation);
                column.ColumnEdit = editor;
            }

            //Vector Type
            column = Grid.GridView.Columns.ColumnByName("idfsVectorType");
            if (column != null)
            {
                var lookup = VectorTypeLookup.Accessor.Instance(null).SelectLookupList(manager);
                LookupBinder.BindVectorTypesRepositoryLookup(column.SetLookupEditor(),
                                                             lookup);
                column.Width = 80;
            }

            //Vector sub type
            column = Grid.GridView.Columns.ColumnByName("idfsVectorSubType");
            if (column != null)
            {
                var le = column.SetLookupEditor();
                var lookup = VectorSubTypeLookup.Accessor.Instance(null).SelectLookupList(manager, null, null);
                LookupBinder.BindVectorSubTypeRepositoryLookup(le, lookup);
                le.QueryPopUp += OnVectorSubTypeQueryPopUp;
                column.Width = 80;
            }

            //sex
            column = Grid.GridView.Columns.ColumnByName("idfsSex");
            if (column != null)
            {
                LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), fakeSessionSummary.AnimalGenderLookup);
                column.Width = 80;
            }

            //intQuantity
            column = Grid.GridView.Columns.ColumnByName("intQuantity");
            if (column != null)
            {
                LookupBinder.BindRepositorySpinEdit(column.SetSpinEditor(), 0, Int32.MaxValue);
                column.Width = 80;
            }

            //диагнозы
            column = Grid.GridView.Columns.ColumnByName("strDiagnosesSummary");
            if (column != null)
            {
                DiagnosisPanel = new VsSessionSummaryDiagnosisPanel();
                var layout = (LayoutGroup)DiagnosisPanel.GetLayout();
                DiagnosesContainer.Controls.Add(layout);
                layout.Dock = DockStyle.Fill;

                //добавляем таблицу диагнозов в попап-контрол
                DiagnosesPopupContainer = new /*RepositoryItemCustomPopupContainerEdit*/RepositoryItemPopupContainerEdit
                    {
                        PopupControl = DiagnosesContainer,
                        ReadOnly = false,
                        TextEditStyle = TextEditStyles.DisableTextEditor,
                        CloseOnOuterMouseClick = false,

                    };

                DiagnosesPopupContainer.QueryPopUp += DiagnosesPopupContainer_QueryPopUp;
                DiagnosesPopupContainer.CloseUp += DiagnosesPopupContainer_CloseUp;
                Grid.GridView.ShownEditor += DiagnosesPopupContainer_ShownEditor;

                column.ColumnEdit = DiagnosesPopupContainer;
                column.Width = 80;
            }


            //скрываем столбцы, которые должны быть видны только в веб-варианте
            Columns.HideColumn("strVectorType");
            Columns.HideColumn("strVectorSubType");
            Columns.HideColumn("strSex");


            var editable = !BusinessObject.Environment.ReadOnly;
            Grid.GridView.OptionsBehavior.Editable = editable;
            Grid.GridView.OptionsBehavior.ReadOnly = !editable;

            foreach (GridColumn clmn in Grid.GridView.Columns)
            {
                if (clmn.FieldName == "strVSSessionSummaryID")
                    continue;
                GridHelper.SetColumnState(clmn, !editable);
            }

            InlineMode = editable ? InlineMode.UseNewRow : InlineMode.None;
        }

        private bool m_ShowPopup;
        private void DiagnosesPopupContainer_ShownEditor(object sender, EventArgs e)
        {
            if (Grid.GridView.FocusedColumn.FieldName == "strDiagnosesSummary" && m_ShowPopup)
                ((PopupContainerEdit)Grid.GridView.ActiveEditor).ShowPopup();
            m_ShowPopup = false;
        }


        void DiagnosesPopupContainer_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (!DiagnosisPanel.ValidateRow())
            {
                if (Grid.GridView.ActiveEditor == null)
                {
                    m_ShowPopup = true;
                    Grid.GridView.ShowEditor();
                }
                else
                    ((PopupContainerEdit) Grid.GridView.ActiveEditor).ShowPopup();
            }

        }

        private IObject GetCurrentLocation()
        {
            var summary = Grid.GridView.GetFocusedRow() as VsSessionSummary;
            return summary != null ? summary.Location : null;
        }

        private void DiagnosesPopupContainer_QueryPopUp(object sender, CancelEventArgs e)
        {
            var summary = Grid.GridView.GetFocusedRow() as VsSessionSummary;
            if ((summary == null) || (summary.idfsVectorType == 0) || (summary.idfsVectorSubType == 0))
            {
                e.Cancel = true;
                return;
            }
            DiagnosisPanel.SetDataSource(summary, summary.DiagnosisList);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnVectorSubTypeQueryPopUp(object sender, CancelEventArgs e)
        {
            var summary = Grid.GridView.GetFocusedRow() as VsSessionSummary;
            if (summary == null) return;
            if (summary.idfsVectorType <= 0)
            {
                e.Cancel = true;
            }
        }
    }
}
