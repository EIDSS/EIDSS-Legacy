using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BLToolkit.EditableObjects;
using BLToolkit.Mapping;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Helpers;

namespace eidss.model.Schema
{
    public enum LabNewModeEnum
    {
        None = 0,
        CreateAliquot = 1,
        CreateDerivative = 2,
        CreateSample = 3,
        Accept = 4,
        GroupAccessionIn = 5,
        TransferOutSample = 6,
        AssignTest = 7,
        AmendTestResult = 8,
    }

    public partial class LaboratorySectionItem
    {
        protected static void CustomValidations(LaboratorySectionItem obj)
        {
            var acc = FFPresenterModel.Accessor.Instance(null);
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                acc.Validate(manager, obj.FFPresenter, true, false, true);
            }
        }

        [Relation(typeof(LaboratorySectionItem), "ID", "ID")]
        public BindingList<LaboratorySectionItem> Details
        {
            get
            {
                return m_list ?? (m_list = new BindingList<LaboratorySectionItem>() { this });
            }
            set
            {
                m_list = value;
            }
        }

        public long? OriginalSampleStatus
        {
            get { return idfsSampleStatusOriginal; }
        }
        public long? GetOriginalTestResult()
        {
            return idfsTestResultOriginal;
        }

        public LaboratorySectionItem GetWithOriginal(LaboratorySectionItem o)
        {
            idfsSampleStatusOriginalIsSaved = true;
            idfsSampleStatusOriginalSaved = o.idfsSampleStatus_Original;
            idfsTestStatusOriginalIsSaved = true;
            idfsTestStatusOriginalSaved = o.idfsTestStatus_Original;
            idfsTestResultOriginalIsSaved = true;
            idfsTestResultOriginalSaved = o.idfsTestResult_Original;
            idfsAccessionConditionOriginalIsSaved = true;
            idfsAccessionConditionOriginalSaved = o.idfsAccessionCondition_Original;
            idfSendToOfficeOutOriginalIsSaved = true;
            idfSendToOfficeOutOriginalSaved = o.idfSendToOfficeOut_Original;
            strBarcodeOriginalIsSaved = true;
            strBarcodeOriginalSaved = o.strBarcode_Original;
            idfsTestNamePreviousIsSaved = true;
            idfsTestNamePreviousSaved = o.idfsTestName_Previous;
            blnExternalTestPreviousIsSaved = true;
            blnExternalTestPreviousSaved = o.blnExternalTest_Previous;

            return this;
        }

        private BindingList<LaboratorySectionItem> m_list = null;
        private bool m_bSetupLoaded;
        public LaboratorySectionItem SetupLoad(DbManagerProxy manager)
        {
            if (!m_bSetupLoaded)
            {
                m_bSetupLoaded = true;
                Accessor.Instance(null)._SetupLoad(manager, this);
                DeepAcceptChanges();
            }
            return this;
        }

        public class SampleTypeForDiagnosisLookupComparator : EqualityComparer<SampleTypeForDiagnosisLookup>
        {
            public override bool Equals(SampleTypeForDiagnosisLookup x, SampleTypeForDiagnosisLookup y)
            {
                return x.idfsReference.Equals(y.idfsReference);
            }

            public override int GetHashCode(SampleTypeForDiagnosisLookup obj)
            {
                return (obj == null) ? base.GetHashCode() : obj.idfsReference.GetHashCode();
            }
        }

        public class LaboratorySectionItemSamplesComparator : EqualityComparer<LaboratorySectionItem>
        {
            public override bool Equals(LaboratorySectionItem x, LaboratorySectionItem y)
            {
                return x.idfMaterial.Equals(y.idfMaterial);
            }

            public override int GetHashCode(LaboratorySectionItem obj)
            {
                return (obj == null) ? base.GetHashCode() : obj.idfMaterial.GetHashCode();
            }
        }

        public static void CheckSamplesForGroupAccesionInExists(DbManagerProxy manager, LaboratorySectionItem obj)
        {
            if (obj.intNewMode == LabNewModeEnum.GroupAccessionIn)
            {
                var pop = manager.SetSpCommand("dbo.spLaboratorySection_GetByFieldBarcode", obj.strFieldBarcode, ModelUserContext.CurrentLanguage).ExecuteList<LaboratorySectionItem>();
                if (pop.Count == 0)
                {
                    throw new ValidationModelException("msgSamplesForGroupAccesionInNotFound", "", "", new object[] { }, null, false, obj);
                }
                
            }
        }

        public partial class Accessor
        {
            partial void ListSelected(DbManagerProxy manager, List<LaboratorySectionItem> objs)
            {
                var lookupDiagnosis = DiagnosisAccessor.SelectLookupList(manager);
                var lookupSampleStatus = SampleStatusFullAccessor.rftSampleStatus_SelectList(manager);
                var lookupSampleType = SampleTypeAccessor.rftSampleType_SelectList(manager);
                var lookupAccessionCondition = AccessionConditionAccessor.rftAccessionCondition_SelectList(manager);
                var lookupTestName = TestNameRefAccessor.SelectLookupList(manager);
                var lookupTestStatus = TestStatusFullAccessor.rftTestStatus_SelectList(manager);
                var lookupTestResult = TestResultRefAccessor.SelectLookupList(manager);
                var lookupTestCategory = TestCategoryRefAccessor.rftTestCategory_SelectList(manager);
                var lookupRegion = eidss.model.Schema.RegionLookup.Accessor.Instance(m_CS).SelectLookupList(manager, null, null);
                var lookupRayon = eidss.model.Schema.RayonLookup.Accessor.Instance(m_CS).SelectLookupList(manager, null, null);
                objs.ForEach(o =>
                    {
                        o.strDiagnosisName = !o.idfsDiagnosis.HasValue || o.idfsDiagnosis.Value == 0 ? "" : lookupDiagnosis.FirstOrDefault(i => i.idfsDiagnosis == o.idfsDiagnosis, i => i.name);
                        o.strSampleStatus = o.idfsSampleStatus == -1 ? eidss.model.Resources.EidssFields.Get("Unaccessioned") : (o.idfsSampleStatus == 0 ? "" : lookupSampleStatus.FirstOrDefault(i => i.idfsBaseReference == o.idfsSampleStatus, i => i.name));
                        o.strSampleName = o.idfsSampleType == 0 ? "" : lookupSampleType.FirstOrDefault(i => i.idfsBaseReference == o.idfsSampleType, i => i.name);
                        o.strSampleConditionReceivedStatus = !o.idfsAccessionCondition.HasValue || o.idfsAccessionCondition.Value == 0 ? "" : lookupAccessionCondition.FirstOrDefault(i => i.idfsBaseReference == o.idfsAccessionCondition, i => i.name);
                        o.strTestName = !o.idfsTestName.HasValue || o.idfsTestName.Value == 0 ? "" : lookupTestName.FirstOrDefault(i => i.idfsReference == o.idfsTestName, i => i.name);
                        o.strTestStatus = o.idfsTestStatus == -1 ? eidss.model.Resources.EidssFields.Get("Deleted") : (!o.idfsTestStatus.HasValue || o.idfsTestStatus.Value == 0 ? "" : lookupTestStatus.FirstOrDefault(i => i.idfsBaseReference == o.idfsTestStatus, i => i.name));
                        o.strTestResult = !o.idfsTestResult.HasValue || o.idfsTestResult.Value == 0 ? "" : lookupTestResult.FirstOrDefault(i => i.idfsReference == o.idfsTestResult, i => i.name);
                        o.strTestCategory = !o.idfsTestCategory.HasValue || o.idfsTestCategory.Value == 0 ? "" : lookupTestCategory.FirstOrDefault(i => i.idfsBaseReference == o.idfsTestCategory, i => i.name);
                        o.strRegion = !o.idfsRegion.HasValue || o.idfsRegion.Value == 0 ? "" : lookupRegion.FirstOrDefault(i => i.idfsRegion == o.idfsRegion, i => i.strRegionName);
                        o.strRayon = !o.idfsRayon.HasValue || o.idfsRayon.Value == 0 ? "" : lookupRayon.FirstOrDefault(i => i.idfsRayon == o.idfsRayon, i => i.strRayonName);
                        o.AcceptChanges();
                    });
            }
        }

    }
}
