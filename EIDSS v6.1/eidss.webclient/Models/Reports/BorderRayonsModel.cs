using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Resources;
using eidss.model.Schema;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class BorderRayonsModel : BaseYearModel, IObject
    {
        public BorderRayonsModel()
        {
            Address = new AddressModel();
            MultipleDiagnosisFilter = new MultipleDiagnosisModel();
            Year = DateTime.Now.Year;
            FromMonthToMonthModel = new FromMonthToMonthModel();
            FromMonthToMonthModel.StartMonth = FromMonthToMonthModel.EndMonth = DateTime.Now.Month;
            DiagOrGroupSelected = new List<long>();

            ObjectName = ObjectIdent = "BorderRayonsModel";

            DiagOrGroupLookup = new List<DiagnosesAndGroupsLookup>();

            Counter = new MultipleCounterModel() { IsRequired = true };
        }

        public void LoadDiagnosesList()
        {
            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                var da = DiagnosesAndGroupsLookup.Accessor.Instance(null); //m_CS

                DiagOrGroupLookup.Add(da.CreateNewT(manager, null));
                DiagOrGroupLookup.Last().name = EidssFields.Get("SelectAll");
                DiagOrGroupLookup.Last().SetValue(DiagOrGroupLookup.Last().KeyName, "0");

                List<DiagnosesAndGroupsLookup> l = da.SelectLookupList(manager
                    , (int) HACode.Human
                    , null
                    , 19000156
                    )
                    .Where(c => !EidssUserContext.User.DenyDiagnosis.ContainsKey(c.idfsDiagnosisOrDiagnosisGroup))
                    .Where(
                        c =>
                            (c.intRowStatus == 0) ||
                            (c.idfsDiagnosisOrDiagnosisGroup == idfsDiagnosisOrDiagnosisGroup))
                    .ToList();

                foreach (DiagnosesAndGroupsLookup d in l.Where(c => c.blnGroup.HasValue && c.blnGroup.Value).OrderBy(c => c.name).ToList())
                {
                    // add group of diagnoses
                    DiagOrGroupLookup.Add(d);
                    // add diagnoses of the group 
                    DiagOrGroupLookup.AddRange(l.Where(c => c.idfsDiagnosisGroup == d.idfsDiagnosisOrDiagnosisGroup)
                        .OrderBy(c => c.name)
                        .ToList());
                }
                // add diagnoses without group 
                DiagOrGroupLookup.AddRange(l.Where(c => c.idfsDiagnosisGroup == 0 && (!c.blnGroup.HasValue || !c.blnGroup.Value))
                    .OrderBy(c => c.name)
                    .ToList());
            }
        }

        public string BorderRayonsModelDiagOrGroup { get; set; }

        public long idfsDiagnosisOrDiagnosisGroup { get; set; }
        public List<DiagnosesAndGroupsLookup> DiagOrGroupLookup { get; set; }

        [LocalizedDisplayName("FromMonth")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("ToMonth")]
        public int? EndMonth { get; set; }

        public AddressModel Address { get; set; }

        public MultipleDiagnosisModel MultipleDiagnosisFilter { get; set; }
        public string MultipleDiagnosisFilter_CheckedItems { get; set; }

        [LocalizedDisplayName("Counter")]
        public MultipleCounterModel Counter { get; set; }
        public string MultipleCounterFilter_CheckedItems { get; set; }

        [LocalizedDisplayName("idfsShowDiagnosis")]
        public long DiagOrGroup { get; set; }

        public List<long> DiagOrGroupSelected { get; set; }

        public static explicit operator BorderRayonsSurrogateModel(BorderRayonsModel model)
        {
            var result = new BorderRayonsSurrogateModel(model.Language,
                model.Year, model.StartMonth, model.EndMonth,
                model.Address.RegionId, model.Address.RayonId,
                model.Address.RegionName, model.Address.RayonName,
                model.MultipleDiagnosisFilter.CheckedItems,
                model.Counter.CheckedItems,
                model.OrganizationId, model.ForbiddenGroups, model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }

        public FromMonthToMonthModel FromMonthToMonthModel { get; set; }

        public List<SelectListItemSurrogate> CounterList
        {
            get { return FilterHelper.GetWebCounterList(1); }
        }

        public object Key
        {
            get { return (long) GetHashCode(); }
        }

        public bool IsNew
        {
            get { return false; }
        }

        public bool HasChanges
        {
            get { return false; }
        }

        public void RejectChanges()
        {
        }

        public void DeepRejectChanges()
        {
        }

        public void DeepAcceptChanges()
        {
        }

        public void SetChange()
        {
        }

        public void DeepSetChange()
        {
        }

        public bool MarkToDelete()
        {
            return false;
        }

        public bool IsMarkedToDelete
        {
            get { return false; }
        }

        public string ObjectName { get; private set; }
        public string ObjectIdent { get; private set; }

        public IObjectAccessor GetAccessor()
        {
            return null;
        }

        public IObjectPermissions GetPermissions()
        {
            return null;
        }

        public IObjectEnvironment Environment { get; set; }

        public bool IsValidObject
        {
            get { return true; }
        }

        public bool ReadOnly { get; set; }

        public bool IsReadOnly(string name)
        {
            return false;
        }

        public bool IsInvisible(string name)
        {
            return false;
        }

        public bool IsRequired(string name)
        {
            return false;
        }

        public bool IsHiddenPersonalData(string name)
        {
            return false;
        }

        public string GetType(string name)
        {
            return string.Empty;
        }

        public object GetValue(string name)
        {
            return null;
        }

        public void SetValue(string name, string val)
        {
        }

        public CompareModel Compare(IObject o)
        {
            return new CompareModel();
        }

        public BvSelectList GetList(string name)
        {
            return new BvSelectList(DiagOrGroupLookup, "idfsDiagnosisOrDiagnosisGroup", "name", null, null);
        }

        public string KeyName
        {
            get { return null; }
        }

        public string ToStringProp
        {
            get { return ToString(); }
        }

        public Dictionary<string, string> GetFieldTags(string name)
        {
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;

        public void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            var localHandler = PropertyChanged;
            if (localHandler != null)
            {
                localHandler(this, e);
            }
        }

        public void RaiseValidation(ValidationEventArgs e)
        {
            var localHandler = Validation;
            if (localHandler != null)
            {
                localHandler(this, e);
            }
        }

        public void RaiseValidationEnd(ValidationEventArgs e)
        {
            var localHandler = ValidationEnd;
            if (localHandler != null)
            {
                localHandler(this, e);
            }
        }

        public void RaiseAfterPost(EventArgs e)
        {
            var localHandler = AfterPost;
            if (localHandler != null)
            {
                localHandler(this, e);
            }
        }

        public IObject Parent
        {
            get { return null; }
        }

        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            return null;
        }

        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
        }

        public void Dispose()
        {
        }
    }
}