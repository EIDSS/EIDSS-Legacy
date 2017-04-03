using System;
using System.ComponentModel;
using BLToolkit.EditableObjects;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.BasePanel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
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

        private readonly VectorSample m_VectorSample;
        private readonly GridColumn m_ColumnSampleType;
        private readonly RepositoryItemLookUpEdit m_LookupSampleType;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workMode"></param>
        public VectorSampleListPanel(Modes workMode)
        {
            InitializeComponent();

            WorkMode = workMode;
            NeedFilterByVectorType = false;
            TopPanelVisible = true;

            //Columns.HideColumn("idfsVectorType");
            //устанавливаем видимость столбцов
            if (WorkMode == Modes.VectorDetailMode)
            {
                Columns.HideColumn("idfVector");
                Columns.HideColumn("idfsVectorType");
                Grid.GridView.OptionsView.ColumnAutoWidth = false;
            }

            #region Установка редакторов для столбцов
          
            var acc = VectorSample.Accessor.Instance(null);

            using (var manager = CreateDbManagerProxy())
            {
                m_VectorSample = acc.CreateNewT(manager, null);

                var column = Grid.GridView.Columns.ColumnByName("strFieldBarcode");
                if (column != null) column.Width = 80;
                
                //Vector Type
                column = Grid.GridView.Columns.ColumnByName("idfsVectorType");
                if (column != null)
                {
                    LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), m_VectorSample.VectorTypeLookup);
                    column.Width = 80;
                }
                
                //SampleType / Speciment Type
                m_ColumnSampleType = Grid.GridView.Columns.ColumnByName("idfsSpecimenType");
                if (m_ColumnSampleType != null)
                {
                    m_LookupSampleType = m_ColumnSampleType.SetLookupEditor();
                    LookupBinder.BindVectorType2SampleTypeRepository(m_LookupSampleType, m_VectorSample.SampleTypesMatrix);
                    m_ColumnSampleType.Width = 80;
                    m_LookupSampleType.QueryPopUp += OnLookupSampleTypeQueryPopUp;
                    m_LookupSampleType.QueryCloseUp += OnLookupSampleTypeQueryCloseUp;
                }

                //Collection Date
                column = Grid.GridView.Columns.ColumnByName("datFieldCollectionDate");
                if (column != null) column.Width = 90;

                //Collected By Office
                column = Grid.GridView.Columns.ColumnByName("idfFieldCollectedByOffice");
                if (column != null)
                {
                    LookupBinder.BindOrganizationRepositoryLookup(column.SetLookupEditor(),
                                                                  m_VectorSample.FieldCollectedByOfficeLookup);
                    column.Width = 220;
                }

                //Accession Date
                column = Grid.GridView.Columns.ColumnByName("datAccession");
                if (column != null) column.Width = 120;

                //AccessionCondition
                column = Grid.GridView.Columns.ColumnByName("idfsAccessionCondition");
                if (column != null)
                {
                    LookupBinder.BindBaseRepositoryLookup(column.SetLookupEditor(), m_VectorSample.AccessionConditionLookup);
                    column.Width = 120;
                }
            }

            #endregion

            Grid.GridView.RowUpdated += OnGridViewRowUpdated;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            base.DefineBinding();
            var layout = GetLayout();
            layout.OnAfterActionExecuted += OnAfterActionExecuted;
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
            else if (action.ActionType.Equals(ActionTypes.Create))
            {
                sample = FocusedItem as VectorSample;
                if (sample != null)
                {
                    
                    if (sample.idfsVectorSubType != 0)
                    {
                        var st =
                            sample.VectorSubTypeLookup.FirstOrDefault(
                                v => v.idfsBaseReference == sample.idfsVectorSubType);
                        if (st != null)
                            sample.strVectorSubTypeName = st.name;
                        var vector = sample.Vectors.FirstOrDefault(v => v.idfVector == sample.idfVector);
                        if (vector != null) sample.SetValues(vector);
                    }
                    if (WorkMode.Equals(Modes.VectorDetailMode)) sample.CanChangeParentVector = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnGridViewRowUpdated(object sender, RowObjectEventArgs e)
        {
            InvokeNeedFieldTestRefreshing();
        }

        public delegate void NeedRefreshDelegate();
        public delegate void AfterChangeVectorDelegate(VectorSample vectorSample);

        /// <summary>
        /// Событие, которое требует пересчёта полевых тестов и их сводной информации
        /// </summary>
        public event NeedRefreshDelegate NeedFieldTestRefreshing;

        /// <summary>
        /// Событие после смены родительского вектора
        /// </summary>
        public event AfterChangeVectorDelegate AfterChangeVector;

        /// <summary>
        /// 
        /// </summary>
        private void InvokeNeedFieldTestRefreshing()
        {
            if (NeedFieldTestRefreshing != null) NeedFieldTestRefreshing();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InvokeAfterChangeVector(VectorSample vectorSample)
        {
            if (AfterChangeVector != null) AfterChangeVector(vectorSample);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLookupSampleTypeQueryCloseUp(object sender, CancelEventArgs e)
        {
            var sample = FocusedItem as VectorSample;
            if (sample == null) return;
            var le = sender as LookUpEdit;
            if (le == null) return;
            le.Properties.DataSource = sample.SampleTypesMatrix.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLookupSampleTypeQueryPopUp(object sender, CancelEventArgs e)
        {
            var sample = FocusedItem as VectorSample;
            if (sample == null) return;
            var le = sender as LookUpEdit;
            if (le == null) return;
            le.Properties.DataSource = sample.SampleTypesMatrix.Where(c => c.idfsVectorType == sample.idfsVectorType).ToList();
        }

        /// <summary>
        /// Текущий режим работы
        /// </summary>
        public Modes WorkMode { get; set; }

        /// <summary>
        /// Режимы работы панели
        /// </summary>
        public enum Modes
        {
            VectorDetailMode = 0,
            SessionDetailMode = 1
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
                m_VectorSample.idfsVectorType = m_IdfsVectorType.HasValue ? m_IdfsVectorType.Value : 0;
                RefreshDataset();
            }
        }

        private bool m_NeedFilterByVectorType;

        /// <summary>
        /// Нужно ли фильтровать по типу вектора
        /// </summary>
        public bool NeedFilterByVectorType
        {
            get { return m_NeedFilterByVectorType; }
            set
            {
                m_NeedFilterByVectorType = value;
                RefreshDataset();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshDataset()
        {
            var format = String.Empty;

            if (idfsVectorType.HasValue && idfVector.HasValue)
            {
                format = String.Format("idfsVectorType={0} and idfVector={1}", idfsVectorType, idfVector);
            }
            else
            {
                if (idfsVectorType.HasValue && NeedFilterByVectorType)
                {
                    format = String.Format("idfsVectorType={0}", idfsVectorType);
                }
                else if (idfVector.HasValue)
                {
                    format = String.Format("idfVector={0}", idfVector);
                }
            }
            
            Refresh(DataSource, format);
        }

        private long? m_IdfVector;

        /// <summary>
        /// 
        /// </summary>
        public long? idfVector
        {
            get { return m_IdfVector; }
            set
            {
                m_IdfVector = value;
                RefreshDataset();
            }
        }

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

        private EditableList<Vector> m_Vectors;

        /// <summary>
        /// Ссылка на все полевые тесты сессии
        /// </summary>
        public EditableList<VectorFieldTest> FieldTests { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EditableList<Vector> Vectors
        {
            get { return m_Vectors; }
            set
            {
                m_Vectors = value;
                if (WorkMode == Modes.SessionDetailMode)
                {
                    //выбор вектора в отдельной таблице
                    var column = Grid.GridView.Columns.ColumnByName("idfVector");
                    if (column != null)
                    {
                        var ds = m_Vectors.Where(v => !v.IsMarkedToDelete).ToList();
                        var editor = column.AddEditorForColumn(ds, "idfVector", "strVectorID");
                        editor.EditValueChanged += OnCurrentVectorChanged;
                        editor.QueryPopUp += OnVectorTypeQueryPopUp;
                        column.Width = 120;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnVectorTypeQueryPopUp(object sender, CancelEventArgs e)
        {
            var sample = FocusedItem as VectorSample;
            if (sample == null) return;
            //не показываем вып. список если это уже сохранённый объект и если он был создан в детальном окне векторов
            //if (!sample.IsNew) e.Cancel = true;
            if (!sample.CanChangeParentVector) e.Cancel = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnCurrentVectorChanged(object sender, EventArgs e)
        {
            var sample = FocusedItem as VectorSample;
            if (sample == null) return;
            var gle = sender as GridLookUpEdit;
            if (gle == null) return;
            if (gle.EditValue == null) return;
            long idVector;
            if (!Int64.TryParse(gle.EditValue.ToString(), out idVector)) return; 
            var vector = Vectors.FirstOrDefault(v => v.idfVector == idVector);
            if (vector == null) return;
            var matrix = sample.SampleTypesMatrix.FirstOrDefault(c => c.idfsVectorType == vector.idfsVectorType);
            if (matrix == null) return;
            sample.ParentVector = vector;
            sample.SetValues(null);

            InvokeAfterChangeVector(sample);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetColumnsReadonly()
        {
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
                var cnt = sample.SampleTypesMatrix.Count(s => s.idfsVectorType == sample.idfsVectorType);
                Columns.SetColumnState("idfsSpecimenType", cnt <= 1);
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
            if (sample.SessionSamples == null) return;
            sample.SessionSamples.Remove(sample);
        }
    }
}
