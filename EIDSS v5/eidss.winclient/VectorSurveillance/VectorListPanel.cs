using System;
using bv.common.Core;
using bv.model.Model.Core;
using bv.winclient.SearchPanel;
using eidss.model.Schema;
using eidss.winclient.Schema;

namespace eidss.winclient.VectorSurveillance
{
    public partial class VectorListPanel : BaseGroupPanel_Vector
    {
        /// <summary>
        /// 
        /// </summary>
        public VectorListPanel()
        {
            InitializeComponent();
            TopPanelVisible = true;
            Grid.GridView.OptionsView.ColumnAutoWidth = false;
            EditByDoubleClick = true;
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
                Refresh();//Refresh(DataSource, GetFilter());
                ((VectorSearchPanel)SearchPanel).CurrentObject.SetValue("idfsVectorType",Utils.Str(value));
                 ((VectorSearchPanel)SearchPanel).BindField("idfsVectorSubType", null);
            }
        }

        /// <summary>
        /// Является ли тип вектора пулом
        /// </summary>
        public bool IsPoolVectorType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string GetFilter()
        {
            var baseFilter = base.GetFilter();
            var filter = m_IdfsVectorType.HasValue
                       ? String.Format("idfsVectorType={0}", m_IdfsVectorType)
                       : String.Empty;
            return !String.IsNullOrEmpty(baseFilter) ? String.Format("({0}) and ({1})", filter, baseFilter) : filter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override string GetDetailFormName(IObject o)
        {
            return "VectorDetail";
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DeleteTempObjects(IObject o)
        {
            base.DeleteTempObjects(o);
            var vector = o as Vector;
            if (vector == null) return;
            if (vector.Samples == null) return;
            var samples = vector.SamplesForThisVector;
            if (samples.Count == 0) return;
            foreach (var sample in samples)
            {
                //if (sample.IsNew && sample.IsMarkedToDelete) vector.Samples.Remove(sample);
                if (sample.IsNew && sample.isJustCreated) vector.Samples.Remove(sample);
            }
        }

        public override void SetObjects(IObject o)
        {
            base.SetObjects(o);
            var vector = o as Vector;
            if (vector == null) return;
            if (vector.Samples == null) return;
            var samples = vector.SamplesForThisVector;
            if (samples.Count == 0) return;
            foreach (var sample in samples)
            {
                if (sample.IsNew && sample.isJustCreated) sample.isJustCreated = false;
            }
        }

        protected override ISearchPanel CreateSearchPanel()
        {
            //return new BaseSearchPanel();
            return new VectorSearchPanel(typeof(Vector), false, null);
        }

        private class VectorSearchPanel : BaseSearchPanel
        {
            public VectorSearchPanel(Type objectType, bool isListSearchPanel, FilterParams initialSearchFilter):base(objectType,isListSearchPanel,initialSearchFilter)
            {

            }
            public override bool IsFieldReadonly(IObject bo, string fieldName)
            {
                if (fieldName.StartsWith("str"))
                    return false;
                return base.IsFieldReadonly(bo, fieldName);
            }
        }
    }
}
