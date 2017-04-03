using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.Core;
using eidss.winclient.Core;
using eidss.winclient.FlexForms;
using eidss.winclient.Schema;
using eidss.model.Schema;
using bv.winclient.BasePanel;

namespace eidss.winclient.VectorSurveillance
{
    public partial class VectorDetail : BaseDetailPanel_Vector
    {
        private FFPresenter m_Presenter;
        public VectorDetail()
        {
            InitializeComponent();

            //добавляем группу Pools/Vectors (она полностью строится динамически)
            SampleListPanel = tpSamples.AddVectorSamplePanel(VectorSampleListPanel.Modes.VectorDetailMode);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void InitChildren()
        {
            base.InitChildren();

            var vector = BusinessObject as Vector;
            if (vector != null)
            {
                SampleListPanel.SetDataSource(vector, vector.Samples);
                SampleListPanel.idfVector = vector.idfVector;
                SampleListPanel.idfsVectorType = vector.idfsVectorType;
                SampleListPanel.IsPoolVectorType = vector.IsPoolVectorType;
                SampleListPanel.Vectors = vector.Vectors;
                bppLocation.PopupControl.BusinessObject = vector.Location;
            }
            else
            {
                bppLocation.PopupControl.BusinessObject = null;
            }
        }
        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;
                SampleListPanel.ReadOnly = value;
                ((IBasePanel)bppLocation.PopupControl).ReadOnly = value;
                if (m_Presenter != null)
                    m_Presenter.ReadOnly = value;
            }
        }

        private VectorSampleListPanel SampleListPanel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="list"></param>
        internal static void FillParamsAction(Vector vector, ref List<object> list)
        {
            list.Add(vector);
            long? idfsSpecimenType = 0;
            if (vector.IsPoolVectorType)
            {
                var matr = vector.SampleTypesMatrix.FirstOrDefault(m => m.idfsVectorType == vector.idfsVectorType);
                if (matr != null) idfsSpecimenType = matr.idfsSampleType;
            }
            list.Add(idfsSpecimenType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override List<object> GetParamsAction(IObject o)
        {
            var list = new List<object>();
            var vector = BusinessObject as Vector; //o здесь не используется
            if (vector != null) FillParamsAction(vector, ref list);
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            var vector = BusinessObject as Vector;
            if (vector == null) return;

            //general
            LookupBinder.BindTextEdit(txtPoolVectorID, vector, "strVectorID");
            LookupBinder.BindTextEdit(txtFieldID, vector, "strFieldVectorID");
            LookupBinder.BindTextEdit(txtSessionID, vector, "strSessionID");
            LookupBinder.BindTextEdit(txtVectorType, vector, "strVectorType");
            LookupBinder.BindSpinEdit(seElevation, vector, "intElevation");
            LookupBinder.BindBaseLookup(leSurrounding, vector, "VsSurrounding", vector.VsSurroundingLookup);
            LookupBinder.BindTextEdit(txtGeoReference, vector, "strGEOReferenceSources");
            LookupBinder.BindOrganizationLookup(leCollectedByInstitution, vector, "CollectedByOffice", vector.CollectedByOfficeLookup);
            LookupBinder.BindPersonLookup(leCollector, vector, "Collector", vector.CollectorLookup);
            LookupBinder.BindDate(dtCollectionDateFrom, vector, "datCollectionDateTime");
            LookupBinder.BindBaseLookup(leCollectionTime, vector, "DayPeriod", vector.DayPeriodLookup, false);
            //LookupBinder.BindSpinEdit(seCollectionEffort, vector, "intCollectionEffort");
            
            LookupBinder.BindCollectionMethodLookup(leCollectionMethod, vector, "CollectionMethod", vector.CollectionMethodLookup);
            LookupBinder.BindVectorsLookup(leHostGuestReference, vector, "HostVector", vector.VectorsWithoutThisVector());

            LookupBinder.BindBaseLookup(leBasisOfRecord, vector, "BasisOfRecord", vector.BasisOfRecordLookup, false);
            LookupBinder.BindBaseLookup(leEctoparasitesCollected, vector, "EctoparasitesCollected", vector.EctoparasitesCollectedLookup, false);

            //animals data
            LookupBinder.BindSpinEdit(seQuantity, vector, "intQuantity");
            LookupBinder.BindVectorSubTypeLookup(leSpecie, vector, "VsVectorSubType", vector.VsVectorSubTypeLookup);
            LookupBinder.BindBaseLookup(leSex, vector, "AnimalGender", vector.AnimalGenderLookup, false);
            LookupBinder.BindOrganizationLookup(leIdentifiedByInstitution, vector, "IdentifiedByOffice", vector.IdentifiedByOfficeLookup);
            LookupBinder.BindPersonLookup(leIdentifiedBy, vector, "Identifier", vector.IdentifierLookup);
            LookupBinder.BindBaseLookup(leIdentificationMethod, vector, "IdentificationMethod", vector.IdentificationMethodLookup, false);
            LookupBinder.BindDate(dtIdentificationDate, vector, "datIdentifiedDateTime");
            LookupBinder.BindMemoEdit(memoComment, vector, "strComment");
            leSpecie.Properties.DataSource = vector.VsVectorSubTypeLookup.Where(c => c.idfsVectorType == vector.idfsVectorType).ToList();

            //FF
            //добавляем FF
            m_Presenter = new FFPresenter(vector.FFPresenter);
            tpVectorSpecificData.Controls.Add(m_Presenter);
            m_Presenter.Dock = DockStyle.Fill;
            m_Presenter.ShowFlexibleForm();
            m_Presenter.ReadOnly = ReadOnly;

            var layout = GetLayout();
            layout.OnBeforeActionExecuting += OnBeforeActionExecuting;

            //Host Reference нельзя задавать для индивидуальных векторов
            lblHostGuestReference.Visible = leHostGuestReference.Visible = vector.IsPoolVectorType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="action"></param>
        /// <param name="bo"></param>
        /// <param name="cancel"></param>
        void OnBeforeActionExecuting(IBasePanel panel, ActionMetaItem action, IObject bo, ref bool cancel)
        {
            //TODO проверить
            if (action.ActionType == ActionTypes.Cancel)
                return;
            var vector = bo as Vector;
            if (vector == null) return;
            if (vector.HasChanges)
            {
                if (action.Name == "VectorOk")
                {
                    cancel = !WinUtils.ConfirmOk();
                    if (cancel)
                        return;
                }
            }
            foreach (var sample in vector.SamplesForThisVector)
            {
                sample.SetValues(vector);
            }
        }




    }
}
