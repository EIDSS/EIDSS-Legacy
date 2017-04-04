using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.EditableObjects;
using BLToolkit.Mapping;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Helpers;
using eidss.model.Core;
using eidss.model.Enums;

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
        AcceptInGoodCondition = 9,
        StartTest = 10,
        SetTestResult = 11,
        ValidateTestResult = 12,
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

            _isValid = o._isValid;

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
                if (BaseSettings.ValidateObject)
                    _isValid = (manager.SetSpCommand("spLabSection_Validate", Key).ExecuteScalar<int>(ScalarSourceType.ReturnValue) == 0);
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

        public class LaboratorySectionItemComparator : IComparer<LaboratorySectionItem>
        {
            public int Compare(LaboratorySectionItem x, LaboratorySectionItem y)
            {
                var ret = (x.strCalculatedCaseID ?? "").CompareTo(y.strCalculatedCaseID ?? "");
                if (ret != 0) return ret;
                var idX = x.idfAnimal.HasValue ? x.idfAnimal.Value : (x.idfSpecies.HasValue ? x.idfSpecies.Value : (x.idfVector.HasValue ? x.idfVector.Value : (x.idfHuman.HasValue ? x.idfHuman.Value : 0)));
                var idY = y.idfAnimal.HasValue ? y.idfAnimal.Value : (y.idfSpecies.HasValue ? y.idfSpecies.Value : (y.idfVector.HasValue ? y.idfVector.Value : (y.idfHuman.HasValue ? y.idfHuman.Value : 0)));
                ret = idX.CompareTo(idY);
                if (ret != 0) return ret;
                ret = x.idfMaterial.CompareTo(y.idfMaterial);
                if (ret != 0) return ret;
                ret = (x.idfTesting.HasValue ? x.idfTesting.Value : 0).CompareTo(y.idfTesting.HasValue ? y.idfTesting.Value : 0);
                if (ret != 0) return ret;
                return 0;
            }
        }

        public static void CheckSamplesForGroupAccesionInExists(DbManagerProxy manager, LaboratorySectionItem obj)
        {
            if (obj.intNewMode == LabNewModeEnum.GroupAccessionIn)
            {
                var idfMaterial = manager.SetSpCommand("dbo.spLaboratorySection_GetByFieldBarcodeCount", 
                    obj.strFieldBarcode,
                    obj.bSendToCurrentOffice ? EidssSiteContext.Instance.OrganizationID : 0).ExecuteScalar<long>();
                if (idfMaterial == 0)
                {
                    throw new ValidationModelException("msgSamplesForGroupAccesionInNotFound", "", "", new object[] { }, null, ValidationEventType.Error, obj);
                }
                
            }
        }

        public bool CheckBarcodeForExist()
        {
            if (intNewMode == LabNewModeEnum.None/* && IsNew*/)
            {
                if (!string.IsNullOrEmpty(strBarcode) && strBarcode != strBarcode_Original)
                {
                    if ((Parent as LaboratorySectionMaster).LaboratorySectionItems.Any(c => !c.IsMarkedToDelete && c.strBarcode.CompareTo(this.strBarcode) == 0 && c.idfMaterial != this.idfMaterial))
                        return false;

                    if ((Parent as LaboratorySectionMaster).LaboratorySectionMyPrefItems.Any(c => !c.IsMarkedToDelete && c.strBarcode.CompareTo(this.strBarcode) == 0 && c.idfMaterial != this.idfMaterial))
                        return false;

                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        var idfMaterialDublicate = manager.SetSpCommand("dbo.spLabSample_BarcodeExists", idfMaterial, strBarcode).ExecuteScalar<long?>();
                        if (idfMaterialDublicate.HasValue && idfMaterialDublicate.Value != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public partial class Accessor
        {
            partial void ListSelected(DbManagerProxy manager, List<LaboratorySectionItem> objs)
            {
                var lookupDepartment = DepartmentAccessor.SelectLookupList(manager, eidss.model.Core.EidssSiteContext.Instance.OrganizationID, null);
                var lookupDiagnosis = DiagnosisAccessor.SelectLookupList(manager);
                var lookupSampleStatus = SampleStatusFullAccessor.rftSampleStatus_SelectList(manager);
                var lookupSampleType = SampleTypeAllAccessor.rftSampleType_SelectList(manager);
                var lookupAccessionCondition = AccessionConditionAccessor.rftAccessionCondition_SelectList(manager);
                var lookupTestName = TestNameRefAccessor.SelectLookupList(manager);
                var lookupTestStatus = TestStatusFullAccessor.rftTestStatus_SelectList(manager);
                var lookupTestResult = TestResultRefAccessor.SelectLookupList(manager);
                var lookupTestCategory = TestCategoryRefAccessor.rftTestCategory_SelectList(manager);
                var lookupRegion = eidss.model.Schema.RegionLookup.Accessor.Instance(m_CS).SelectLookupList(manager, null, null);
                var lookupRayon = eidss.model.Schema.RayonLookup.Accessor.Instance(m_CS).SelectLookupList(manager, null, null);
                objs.ForEach(o =>
                    {
                        o.strDepartmentName = !o.idfInDepartment.HasValue || o.idfInDepartment.Value == 0 ? "" : lookupDepartment.FirstOrDefault(i => i.idfDepartment == o.idfInDepartment, i => i.name);
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
                        o.HumanName = 
                            (o.idfsCaseType == (long)CaseTypeEnum.Human && EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName))
                            ||
                            (o.idfsCaseType != (long)CaseTypeEnum.Human && (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement) || EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details)))
                            ? "*******" : o.HumanName;
                        o.AcceptChanges();
                    });

                objs.Sort(new LaboratorySectionItemComparator());
            }
        }

    }
}
