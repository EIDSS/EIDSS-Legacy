using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using bv.common.Enums;
using bv.model.Model.Core;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Enums;
using eidss.winclient.Core;
using eidss.winclient.FlexForms;
using eidss.model.Schema;
using bv.winclient.BasePanel;
using System.Linq;

namespace eidss.winclient.VectorSurveillance
{
    public partial class VectorDetail
    {
        private FFPresenter m_Presenter;

        private bool WasAddedVector { get; set; }

        public VectorDetail()
        {
            InitializeComponent();

            //добавляем группу Pools/Vectors (она полностью строится динамически)
            VectorSampleListPanel.WorkMode = PanelWorkModes.VectorDetailMode;
            SampleListPanel = tpSamples.AddVectorSamplePanel();
            SampleListPanel.VectorDetail = this;
            var layout = (LayoutGroup)SampleListPanel.GetLayout();
            layout.OnAfterActionExecuted += OnSamplesAfterActionExecuted;
            VectorFieldTestListPanel.WorkMode = PanelWorkModes.VectorDetailMode;
            FieldTestPanel = tpFieldTests.AddFieldTestPanel();
            VectorLabTestListPanel.WorkMode = PanelWorkModes.VectorDetailMode;
            LabTestPanel = tpLabTests.AddLabTestPanel();
        }

        void OnSamplesAfterActionExecuted(IBasePanel panel, ActionMetaItem action, IObject bo)
        {
            var vector = BusinessObject as Vector;
            if (vector != null)
            {
                SetControlsState(vector.Samples.Count(c => !c.IsMarkedToDelete) == 0);
            }
        }

        public void SetControlsState(bool enabled)
        {
            leVectorType.Enabled = leSpecies.Enabled = enabled;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="closeMode"></param>
        /// <returns></returns>
        public override bool Close(FormClosingMode closeMode)
        {
            var close = base.Close(closeMode);
            var vector = BusinessObject as Vector;
            if (close && WasAddedVector && (vector != null) && vector.Session.Vectors.Any(v => v.idfVector == vector.idfVector))
            {
                vector.Session.Vectors.Remove(vector);
                //vector.MarkToDelete();
            }
            //TODO может быть, лучшее место для этого
            VectorSampleListPanel.WorkMode = PanelWorkModes.SessionDetailMode;
            VectorFieldTestListPanel.WorkMode = PanelWorkModes.SessionDetailMode;
            VectorLabTestListPanel.WorkMode = PanelWorkModes.SessionDetailMode;
            return close;
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="action"></param>
        /// <param name="bo"></param>
        /// <param name="cancel"></param>
        private void OnSamplesPanelBeforeActionExecuting(IBasePanel panel, ActionMetaItem action, IObject bo, ref bool cancel)
        {
            //нельзя создавать Sample, если не задан тип вектора
            var vector = BusinessObject as Vector;
            if (vector == null) return;
            if (vector.idfsVectorType == 0)
            {
                MessageForm.Show(EidssMessages.Get("VS Session need vector type"));
                cancel = true;
            }
        }
        */

        /// <summary>
        /// 
        /// </summary>
        protected override void InitChildren()
        {
            base.InitChildren();

            var vector = BusinessObject as Vector;
            if ((vector != null) && (vector.Session != null))
            {
                //родитель у всех сессия
                SampleListPanel.SetDataSource(vector, vector.Samples);
                SampleListPanel.IsPoolVectorType = vector.IsPoolVectorType;
                
                FieldTestPanel.SetDataSource(vector, vector.FieldTests);

                LabTestPanel.SetDataSource(vector, vector.LabTests);

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
        private VectorFieldTestListPanel FieldTestPanel { get; set; }
        private VectorLabTestListPanel LabTestPanel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override List<object> GetParamsAction(IObject o)
        {
            var list = new List<object>();
            var vector = BusinessObject as Vector; //o здесь не используется
            if (vector != null) list = vector.GetParamsAction(o.GetType());
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DefineBinding()
        {
            var vector = BusinessObject as Vector;
            if (vector == null) return;

            if ((vector.Session != null) && vector.Session.Vectors.All(v => v.idfVector != vector.idfVector))
            {
                //приходится заранее добавлять вектор в коллекцию, чтобы он находился как ParentVector
                vector.Session.Vectors.Add(vector);
                WasAddedVector = true;
            }

            //general
            LookupBinder.BindTextEdit(txtPoolVectorID, vector, "strVectorID");
            LookupBinder.BindTextEdit(txtFieldID, vector, "strFieldVectorID");
            LookupBinder.BindTextEdit(txtSessionID, vector, "strSessionID");

            LookupBinder.BindVectorTypesLookup(leVectorType, vector, "VectorType", vector.VectorTypeLookup);
            
            LookupBinder.BindSpinEdit(seElevation, vector, "intElevation");
            LookupBinder.BindBaseLookup(leSurrounding, vector, "Surrounding", vector.SurroundingLookup);
            LookupBinder.BindTextEdit(txtGeoReference, vector, "strGEOReferenceSources");
            LookupBinder.BindOrganizationLookup(leCollectedByInstitution, vector, "CollectedByOffice", vector.CollectedByOfficeLookup, HACode.Vector);
            LookupBinder.BindPersonLookup(leCollector, vector, "Collector", vector.CollectorLookup, HACode.Vector);
            
            LookupBinder.BindDate(dtCollectionDateFrom, vector, "datCollectionDateTime");
            LookupBinder.BindBaseLookup(leCollectionTime, vector, "DayPeriod", vector.DayPeriodLookup, false);
            
            LookupBinder.BindCollectionMethodLookup(leCollectionMethod, vector, "CollectionMethod", vector.CollectionMethodLookup);
            if (!bv.common.Configuration.BaseSettings.ScanFormsMode)
                LookupBinder.BindVectorsLookup(leHostGuestReference, vector, "HostVector", vector.HostVectorLookup);

            LookupBinder.BindBaseLookup(leBasisOfRecord, vector, "BasisOfRecord", vector.BasisOfRecordLookup, false);
            LookupBinder.BindBaseLookup(leEctoparasitesCollected, vector, "EctoparasitesCollected", vector.EctoparasitesCollectedLookup, false);

            //animals data
            LookupBinder.BindSpinEdit(seQuantity, vector, "intQuantity");
            LookupBinder.BindVectorSubTypeLookup(leSpecies, vector, "VectorSubType", vector.VectorSubTypeLookup);
            LookupBinder.BindBaseLookup(leSex, vector, "AnimalGender", vector.AnimalGenderLookup, false);
            LookupBinder.BindOrganizationLookup(leIdentifiedByInstitution, vector, "IdentifiedByOffice", vector.IdentifiedByOfficeLookup, HACode.Vector);
            LookupBinder.BindPersonLookup(leIdentifiedBy, vector, "Identifier", vector.IdentifierLookup, HACode.Vector);
            
            LookupBinder.BindBaseLookup(leIdentificationMethod, vector, "IdentificationMethod", vector.IdentificationMethodLookup, false);
            LookupBinder.BindDate(dtIdentificationDate, vector, "datIdentifiedDateTime");
            LookupBinder.BindMemoEdit(memoComment, vector, "strComment");
            
            //FF
            //добавляем FF
            m_Presenter = new FFPresenter(vector.FFPresenter);
            tpVectorSpecificData.Controls.Add(m_Presenter);
            m_Presenter.Dock = DockStyle.Fill;
            m_Presenter.ShowFlexibleForm();//потому что при открытии вектора срабатывание события происходит раньше, чем его услышит форма
            m_Presenter.ReadOnly = ReadOnly;

            var layout = GetLayout();
            layout.OnBeforeActionExecuting += OnBeforeActionExecuting;

            SampleListPanel.GetLayout().OnAfterActionExecuted += OnAfterActionExecuted;

            //Host Reference нельзя задавать для индивидуальных векторов
            lblHostGuestReference.Visible = leHostGuestReference.Visible = vector.IsPoolVectorType;

            //вкладка, которую нужно открыть, если на то была команда
            switch (vector.openMode)
            {
                case 1:
                    tcMain.SelectedTabPage = tpSamples;
                    break;
                case 2:
                    tcMain.SelectedTabPage = tpFieldTests;
                    break;
                case 3:
                    tcMain.SelectedTabPage = tpLabTests;
                    break;
            }

            if (vector.openMode > 0)
            {
                OnleVectorTypeSubTypeEditValueChanged(this, EventArgs.Empty);
            }

            vector.PropertyChanged += OnVectorPropertyChanged;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnVectorPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("FFPresenter") && (m_Presenter != null)) m_Presenter.ShowFlexibleForm();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="action"></param>
        /// <param name="bo"></param>
        void OnAfterActionExecuted(IBasePanel panel, ActionMetaItem action, IObject bo)
        {
            /*
            var vector = BusinessObject as Vector;
            if (vector == null) return;

            //обновление статусов
            leVectorType.Properties.ReadOnly = vector.IsReadOnly("VectorType");
             */
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
            if (action.ActionType == ActionTypes.Cancel) return;
            var vector = bo as Vector;
            if (vector == null) return;
            if (vector.HasChanges && (action.Name == "VectorOk")) cancel = !WinUtils.ConfirmOk();
        }

        private void RefreshInputState()
        {
            var vector = BusinessObject as Vector;
            if (vector == null) return;

            var vt = leVectorType.EditValue as VectorTypeLookup;
            var vst = leSpecies.EditValue as VectorSubTypeLookup;

            //TODO почему-то нет добавления нового значения в БО после смены EditValue. Потому переусложненное условие.
            var canAddNewRow = ((vector.VectorType != null) && (vector.VectorSubType != null))
                               ||
                               ((vt != null) && (vst != null) && (vt.idfsBaseReference > 0) &&
                                (vst.idfsBaseReference > 0))
                ;

            SampleListPanel.InlineMode =
                FieldTestPanel.InlineMode = canAddNewRow ? InlineMode.UseNewRow : InlineMode.None;
            if (vt != null)
                lblHostGuestReference.Visible =
                    leHostGuestReference.Visible = vector.GetIsPoolVectorType(vt.idfsBaseReference);
        }

        private void OnleVectorTypeSubTypeEditValueChanged(object sender, EventArgs e)
        {
            RefreshInputState();
        }
    }
}
