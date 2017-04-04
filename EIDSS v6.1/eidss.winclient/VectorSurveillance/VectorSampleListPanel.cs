using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Base;
using bv.common.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using eidss.model.Enums;
using eidss.model.Schema;
using eidss.winclient.Helpers;
using eidss.winclient.Schema;
using eidss.winclient.Core;
using System.Linq;

namespace eidss.winclient.VectorSurveillance
{
    public partial class VectorSampleListPanel : BaseGroupPanel_VectorSample
    {
        /// <summary>
        /// 
        /// </summary>
        private GridColumnCollection Columns { get { return Grid.GridView.Columns; } }
        
        private VectorSample fakeSample { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public VectorSampleListPanel()
        {
            InitializeComponent();

            SearchPanelVisible = false;
            TopPanelVisible = true;
            Grid.GridView.OptionsView.ColumnAutoWidth = false;
            AllowCustomization = true;
            Field2LookupMap = new Dictionary<string, string>
                {
                    {"idfsVectorType", "VectorTypeLookup"},
                    {"idfsSampleType", "VectorType2SampleTypeLookup"},
                    {"idfSendToOffice", "SendToOfficeLookup"},
                    {"idfFieldCollectedByOffice", "FieldCollectedByOfficeLookup"}
                };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dummyObjectWithLookups"></param>
        public override void InitGridBehavior(IObject dummyObjectWithLookups, DbManagerProxy manager)
        {
            base.InitGridBehavior(dummyObjectWithLookups, manager);

            fakeSample = dummyObjectWithLookups as VectorSample;
            if (fakeSample == null) return;
            
            var column = Grid.GridView.Columns.ColumnByName("strFieldBarcode");
            if (column != null) column.Width = 80;

            //Vector Type
            column = Grid.GridView.Columns.ColumnByName("idfsVectorType");
            if (column != null)
            {
                var lookup = BaseReference.Accessor.Instance(null).rftVectorType_SelectList(manager);
                LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), lookup);
                column.Width = 80;
            }

            //SampleType / Sample Type
            column = Grid.GridView.Columns.ColumnByName("idfsSampleType");
            if (column != null)
            {
                var le = column.SetLookupEditor();
                var lookup = VectorType2SampleTypeLookup.Accessor.Instance(null).SelectLookupList(manager);
                LookupBinder.BindVectorType2SampleTypeRepository(le, lookup);
                column.Width = 80;
                le.QueryPopUp += OnLookupSampleTypeQueryPopUp;
            }

            //Collection Date
            column = Grid.GridView.Columns.ColumnByName("datFieldCollectionDate");
            if (column != null)
            {
                column.Width = 90;
            }

            //Send to Organization
            column = Grid.GridView.Columns.ColumnByName("idfSendToOffice");
            if (column != null)
            {
                var lookup = OrganizationLookup.Accessor.Instance(null).SelectLookupList(manager, null, null);
                LookupBinder.BindOrganizationRepositoryLookup(column.SetLookupEditor(), lookup, HACode.Vector);
                column.Width = 220;
            }

            //Collected By Office
            column = Grid.GridView.Columns.ColumnByName("idfFieldCollectedByOffice");
            if (column != null)
            {
                var lookup = OrganizationLookup.Accessor.Instance(null).SelectLookupList(manager, null, null);
                LookupBinder.BindOrganizationRepositoryLookup(column.SetLookupEditor(), lookup, HACode.Vector);
                column.Width = 220;
            }

            //Accession Date
            column = Grid.GridView.Columns.ColumnByName("datAccession");
            if (column != null)
            {
                column.Width = 120;
            }

            //AccessionCondition
            column = Grid.GridView.Columns.ColumnByName("idfsAccessionCondition");
            if (column != null)
            {
                LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), fakeSample.AccessionConditionLookup);
                column.Width = 120;
            }

            //устанавливаем видимость столбцов
            if (WorkMode == PanelWorkModes.VectorDetailMode)
            {
                Columns.HideColumn("idfVector");
                Columns.HideColumn("idfsVectorType");
                Columns.HideColumn("strVectorID");
                Columns.HideColumn("strVectorSubTypeName");
            }
            
            //скрываем столбцы, которые видны только в веб-версии
            Columns.HideColumn("strVectorType");
            Columns.HideColumn("strSampleType");
            Columns.HideColumn("strFieldCollectedByOffice");
            Columns.HideColumn("strAccessionCondition");
            Columns.HideColumn("strSendToOffice");

            var editable = (WorkMode == PanelWorkModes.VectorDetailMode) && !BusinessObject.Environment.ReadOnly;
            Grid.GridView.OptionsBehavior.Editable = editable;
            Grid.GridView.OptionsBehavior.ReadOnly = !editable;

            foreach (GridColumn clmn in Grid.GridView.Columns)
            {
                GridHelper.SetColumnState(clmn, !editable);
            }

            InlineMode = editable ? InlineMode.UseNewRow : InlineMode.None;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            if (BusinessObject != null)
            {
                var meta = (IObjectMeta) BusinessObject.GetAccessor();
                var delete = meta.Actions.FirstOrDefault(a => a.Name == "Delete");
                var view = meta.Actions.FirstOrDefault(a => a.Name == "ViewOnDetailForm");
                var isSession = WorkMode == PanelWorkModes.SessionDetailMode;
                if (delete != null) delete.AddVisiblePredicate((arg1, arg2, arg3, arg4) => !isSession);
                if (view != null) view.AddVisiblePredicate((arg1, arg2, arg3, arg4) => isSession);
            }

            base.DefineBinding();

            var layout = GetLayout();
            layout.OnAfterActionExecuted += OnAfterActionExecuted;
            //layout.OnBeforeActionExecuting += OnBeforeActionExecuting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="action"></param>
        /// <param name="bo"></param>
        void OnAfterActionExecuted(IBasePanel panel, ActionMetaItem action, IObject bo)
        {
            var sample = bo as VectorSample;
            if (sample == null) return;

            if (action.ActionType.Equals(ActionTypes.Delete))
            {
                DeleteTempObjects(bo);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLookupSampleTypeQueryPopUp(object sender, CancelEventArgs e)
        {
            var sample = Grid.GridView.GetFocusedRow() as VectorSample;
            if (sample == null) return;
            if (sample.isPool)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Текущий режим работы
        /// </summary>
        public static PanelWorkModes WorkMode { get; set; }
        
        private bool m_IsPoolVectorType;

        /// <summary>
        /// 
        /// </summary>
        public bool IsPoolVectorType
        {
            get { return m_IsPoolVectorType; }
            set { 
                m_IsPoolVectorType = value; 
                SetColumnsReadonly();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetColumnsReadonly()
        {
            //TODO
            Columns.SetColumnState("strBarcode", true);

            Columns.SetColumnState("idfsVectorType", true);
            Columns.SetColumnState("strVectorSubTypeName", true);
            Columns.SetColumnState("datFieldCollectionDate", IsPoolVectorType);
            Columns.SetColumnState("idfFieldCollectedByOffice", IsPoolVectorType);
            Columns.SetColumnState("datAccession", true);
            Columns.SetColumnState("idfsAccessionCondition", true);
            Columns.SetColumnState("strNote", true);

            //для пулов редактировать нельзя (IsPoolVectorType == readonly)
            if (IsPoolVectorType)
            {
                var sample = FocusedItem as VectorSample;
                if (sample == null) return;
                var cnt = sample.VectorType2SampleTypeLookup.Count(s => s.idfsVectorType == sample.idfsVectorType);
                Columns.SetColumnState("idfsSampleType", cnt <= 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        public override void DeleteTempObjects(IObject o)
        {
            base.DeleteTempObjects(o);
            var sample = o as VectorSample;
            if (sample == null) return;
            if (!sample.IsNew || !sample.IsMarkedToDelete) return;
            //любой из векторов указывает на общую коллекцию семплов в сессии
            if (sample.Samples == null) return;
            sample.Samples.Remove(sample);
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
                var sample = Grid.GridView.GetFocusedRow() as VectorSample;
                if ((sample != null) && (sample.ParentVector != null))
                {
                    var index = sample.Vectors.IndexOf(sample.ParentVector);
                    var handle = VectorsPanel.Grid.GridView.GetRowHandle(index);
                    VectorsPanel.Grid.GridView.FocusedRowHandle = handle;
                    VectorsPanel.Grid.GridView.ClearSelection();
                    VectorsPanel.Grid.GridView.SelectRow(handle);

                    //VectorsPanel.BusinessObject = sample.ParentVector;
                    sample.ParentVector.openMode = 1;
                    VectorsPanel.PerformAction("Edit");
                    sample.ParentVector.openMode = 0;
                }
                
            }
            return true;
        }

        internal VectorListPanel VectorsPanel { get; set; }
        internal VectorDetail VectorDetail { get; set; }

        protected override void AfterChangeRow(RowObjectEventArgs e)
        {
            base.AfterChangeRow(e);
            if (VectorDetail != null) VectorDetail.SetControlsState(DataSource.Count == 0);
        }
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
