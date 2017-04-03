using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using bv.common.Configuration;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using eidss.model.Schema;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;

namespace eidss.winclient.VectorSurveillance
{
    public partial class VectorLabTestListPanel : BaseGroupPanel_VectorLabTest
    {
        /// <summary>
        /// 
        /// </summary>
        private GridColumnCollection Columns { get { return Grid.GridView.Columns; } }

        /// <summary>
        /// Текущий режим работы
        /// </summary>
        public static PanelWorkModes WorkMode { get; set; }

        public VectorLabTestListPanel()
        {
            InitializeComponent();
            
            if (BaseSettings.ScanFormsMode) return;

            EditByDoubleClick = false;
            //таблица не редактируется
            Grid.GridView.OptionsBehavior.Editable = false;
            //Grid.GridView.OptionsBehavior.ReadOnly = true;
            TopPanelVisible = true;
            SearchPanelVisible = false;

            //устанавливаем видимость столбцов
            if (WorkMode == PanelWorkModes.VectorDetailMode)
            {
                Columns.HideColumn("strVectorID");
                Columns.HideColumn("strVectorTypeName");
                Columns.HideColumn("strVectorSubTypeName");
            }
            Columns.HideColumn("strAmendmentHistory");

            /*
            //группировать по полю strTestName
            var column = Grid.GridView.Columns.ColumnByName("strTestName");
            if (column != null)
            {
                Grid.GridView.GroupCount = 1;
                Grid.GridView.SortInfo.AddRange(new[] { new GridColumnSortInfo(column, ColumnSortOrder.Ascending) });
                Grid.GridView.OptionsView.ShowGroupPanel = false;
            }
             */
        }

        public override void InitGridBehavior(IObject dummyObjectWithLookups)
        {
            base.InitGridBehavior(dummyObjectWithLookups);

            //Amendment History
            var column = Grid.GridView.Columns.ColumnByName("HasAmendmentHistory");
            if (column != null)
            {
                var chkHasAmendment = new RepositoryItemCheckEdit
                    {
                        CheckStyle = CheckStyles.UserDefined,
                        ImageIndexChecked = 0,
                        Images = ImageList1,
                        Name = "chkHasAmendment",
                        ValueChecked = true,
                        ValueUnchecked = false
                    };
                column.ColumnEdit = chkHasAmendment;
                column.Width = 80;
            }
            Grid.GridView.MouseUp += Grid_MouseUp;
            Grid.GridView.MouseMove += Grid_MouseMove;
        }

        void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            var row = GetAmendedRowUnderMouse(e);
            Cursor = row != null ? Cursors.Hand : Cursors.Default;
        }

        private VectorLabTest GetAmendedRowUnderMouse(MouseEventArgs e)
        {
            const string fieldName = "HasAmendmentHistory";
            var hi = Grid.GridView.CalcHitInfo(e.Location);
            if (hi.InRowCell && (hi.Column.FieldName == fieldName))
            {
                var labTest = Grid.GridView.GetRow(hi.RowHandle) as VectorLabTest;
                if ((labTest != null) && labTest.HasAmendmentHistory)
                {
                    return labTest;
                }
            }
            return null;
        }

        void Grid_MouseUp(object sender, MouseEventArgs e)
        {
            //по клику на панели с историей показываем отдельное окно
            var labTest = GetAmendedRowUnderMouse(e);
            if (labTest == null) return;
            var form = ClassLoader.LoadClass("LabTestAmendmentHistoryPanel") as IApplicationForm;
            if (form == null) return;
            object id = labTest.idfTesting;
            BaseFormManager.ShowModal(form, FindForm(), ref id, null, null, 900, 500);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshDataset()
        {
            var format = String.Empty;

            if (idfsVectorType.HasValue)
            {
                format = String.Format("idfsVectorType={0}", idfsVectorType);
            }

            Refresh(DataSource, format);
        }

        private long? m_IdfsVectorType;

        /// <summary>
        /// 
        /// </summary>
        public long? idfsVectorType
        {
            get { return m_IdfsVectorType; }
            set
            {
                m_IdfsVectorType = value;
                RefreshDataset();
            }
        }

        public override void DefineBinding()
        {
            if (BusinessObject != null)
            {
                var meta = (IObjectMeta)BusinessObject.GetAccessor();
                var delete = meta.Actions.FirstOrDefault(a => a.Name == "Delete");
                var view = meta.Actions.FirstOrDefault(a => a.Name == "ViewOnDetailForm");
                var isSession = WorkMode == PanelWorkModes.SessionDetailMode;
                if (delete != null) delete.AddVisiblePredicate((arg1, arg2, arg3, arg4) => !isSession);
                if (view != null) view.AddVisiblePredicate((arg1, arg2, arg3, arg4) => isSession);
            }
            base.DefineBinding();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actions"></param>
        public override void SetCustomActions(List<ActionMetaItem> actions)
        {
            base.SetCustomActions(actions);
            SetActionFunction(actions, "ViewOnDetailForm", ViewOnDetailForm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="bo"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private ActResult ViewOnDetailForm(DbManagerProxy manager, IObject bo, List<object> parameters)
        {
            if ((VectorsPanel != null) && (VectorsPanel.BusinessObject != null))
            {
                var lt = Grid.GridView.GetFocusedRow() as VectorLabTest;
                if ((lt != null) && (lt.ParentVector != null))
                {
                    var index = lt.Vectors.IndexOf(lt.ParentVector);
                    var handle = VectorsPanel.Grid.GridView.GetRowHandle(index);
                    VectorsPanel.Grid.GridView.FocusedRowHandle = handle;
                    VectorsPanel.Grid.GridView.ClearSelection();
                    VectorsPanel.Grid.GridView.SelectRow(handle);

                    //VectorsPanel.BusinessObject = sample.ParentVector;
                    lt.ParentVector.openMode = 3;
                    VectorsPanel.PerformAction("Edit");
                    lt.ParentVector.openMode = 0;
                }
            }
            return true;
        }

        internal VectorListPanel VectorsPanel { get; set; }
        public override bool ReadOnly
        {
            get
            {
                var vsSessionPanel = ParentBasePanel as VsSessionDetail;
                if (vsSessionPanel != null && ((VsSession)vsSessionPanel.BusinessObject).IsClosed)
                    return true;
                return base.ReadOnly;
            }
            set
            {
                base.ReadOnly = value;
            }
        }

    }
}
