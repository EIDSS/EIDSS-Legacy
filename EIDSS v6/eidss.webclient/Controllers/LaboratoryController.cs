using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using BLToolkit.EditableObjects;
using Kendo.Mvc.UI;
using bv.common.Core;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Resources;
using eidss.model.Schema;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using bv.model.Model.Core;
using eidss.model.Enums;
using System.Collections.Generic;
using System.Collections;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true, Duration = 0, VaryByParam = "*")]
    public class LaboratoryController : BvController
    {
        public ActionResult Details(long? id)
        {
            return DetailsInternal<LaboratorySectionMaster.Accessor, LaboratorySectionMaster>(id, eidss.model.Schema.LaboratorySectionMaster.Accessor.Instance(null), null, null, null, null,
                c => { c.bIsMyPref = false; c.DeepAcceptChanges(); }
                );
        }

        public ActionResult DetailsMyPref(long? id)
        {
            ViewBag.StaticFilter = new FilterParams().Add("MyPref", "=", true);
            return DetailsInternal<LaboratorySectionMaster.Accessor, LaboratorySectionMaster>(id, eidss.model.Schema.LaboratorySectionMaster.Accessor.Instance(null), null, null, null, null,
                c => { c.bIsMyPref = true; c.DeepAcceptChanges(); }
                );
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            return DetailsInternalAjax<LaboratorySectionMaster.Accessor, LaboratorySectionMaster>(form, eidss.model.Schema.LaboratorySectionMaster.Accessor.Instance(null), null, null, null, null,
                bCloneWithSetup: false);
        }

        [HttpPost]
        public ActionResult DetailsMyPref(FormCollection form)
        {
            return DetailsInternalAjax<LaboratorySectionMaster.Accessor, LaboratorySectionMaster>(form, eidss.model.Schema.LaboratorySectionMaster.Accessor.Instance(null), null, null, null, null,
                bCloneWithSetup: false);
        }

        public ActionResult IndexAjaxNotMy([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            long id = Int64.Parse(form["ObjectAdditional"]);
            var bIgnoreChanges = (form["SearchIgnoreChanges"] != null && form["SearchIgnoreChanges"] == "true");
            var bSearchClick = (form["bSearchClick"] != null && form["bSearchClick"] == "1");

            bool bFilterChanged = false;
            var checkCol = new FormCollection();
            form.AllKeys.Where(i => i != "sort" && i != "page" && i != "SearchIgnoreChanges").ToList().ForEach(i => checkCol.Add(i, form[i]));
            if (Session["IndexAjaxNotMy"] is FormCollection)
            {
                var oldCheckCol = Session["IndexAjaxNotMy"] as FormCollection;
                foreach (string key in checkCol.AllKeys)
                {
                    if (checkCol[key] != oldCheckCol[key])
                    {
                        bFilterChanged = true;
                        break;
                    }
                }
            }
            Session["IndexAjaxNotMy"] = checkCol;

            var master = (LaboratorySectionMaster)ModelStorage.Get(Session.SessionID, id, null);
            return IndexInternalAjax<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionItem.LaboratorySectionItemGridModelList>
                (form, LaboratorySectionItem.Accessor.Instance(null), AutoGridRoots.LabSampleBook, request, 
                () =>
                    {
                        if ((!bFilterChanged || master.HasChanges) && !bIgnoreChanges && !bSearchClick)
                        {
                            master.LaboratorySectionItems.ForEach(c => c.Parent = master);
                            return master.LaboratorySectionItems.ToList();
                        }
                        return null;
                    },
                list =>
                    {
                        if ((bFilterChanged && !master.HasChanges) || bIgnoreChanges || bSearchClick)
                        {
                            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                            {
                                master.LaboratorySectionItems.Clear();
                                //master.LaboratorySectionItems.AddRange(list.Select(i => i.SetupLoad(manager)).ToList());
                                master.LaboratorySectionItems.AddRange(list);
                                master.LaboratorySectionItems.ForEach(c =>
                                    {
                                        c.Parent = master;
                                        ModelStorage.Put(Session.SessionID, master.idfsLaboratorySection, c.ID, "_" + master.idfsLaboratorySection, c);
                                    }
                                    );
                                master.DeepAcceptChanges();
                            }
                        }
                    },
                true
                );
        }
        public ActionResult IndexAjaxMy([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            long id = Int64.Parse(form["ObjectAdditional"]);
            var bIgnoreChanges = (form["SearchIgnoreChanges"] != null && form["SearchIgnoreChanges"] == "true");
            var bSearchClick = (form["bSearchClick"] != null && form["bSearchClick"] == "1");

            bool bFilterChanged = false;
            var checkCol = new FormCollection();
            form.AllKeys.Where(i => i != "sort" && i != "page" && i != "SearchIgnoreChanges").ToList().ForEach(i => checkCol.Add(i, form[i]));
            if (Session["IndexAjaxMy"] is FormCollection)
            {
                var oldCheckCol = Session["IndexAjaxMy"] as FormCollection;
                foreach (string key in checkCol.AllKeys)
                {
                    if (checkCol[key] != oldCheckCol[key])
                    {
                        bFilterChanged = true;
                        break;
                    }
                }
            }
            Session["IndexAjaxMy"] = checkCol;

            var master = (LaboratorySectionMaster)ModelStorage.Get(Session.SessionID, id, null);
            return IndexInternalAjax<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionItem.LaboratorySectionItemGridModelList>
                (form, LaboratorySectionItem.Accessor.Instance(null), AutoGridRoots.LabSampleBookPreference, request,
                () =>
                    {
                        if ((!bFilterChanged || master.HasChanges) && !bIgnoreChanges && !bSearchClick)
                        {
                            master.LaboratorySectionMyPrefItems.ForEach(c => c.Parent = master);
                            return master.LaboratorySectionMyPrefItems.ToList();
                        }
                        return null;
                    },
                list =>
                    {
                        if ((bFilterChanged && !master.HasChanges) || bIgnoreChanges || bSearchClick)
                        {
                            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                            {
                                master.LaboratorySectionMyPrefItems.Clear();
                                //master.LaboratorySectionMyPrefItems.AddRange(list.Select(i => i.SetupLoad(manager)).ToList());
                                master.LaboratorySectionItems.AddRange(list);
                                master.LaboratorySectionMyPrefItems.ForEach(c =>
                                    {
                                        c.bIsMyPref = true;
                                        c.Parent = master;
                                        ModelStorage.Put(Session.SessionID, master.idfsLaboratorySection, c.ID, "_" + master.idfsLaboratorySection, c);
                                    }
                                    );
                                master.DeepAcceptChanges();
                            }
                        }
                    },
                true
                );
        }

        private List<LaboratorySectionItem> PreprocessGetAll(long root, string ids)
        {
            var ret = new List<LaboratorySectionItem>();
            var master = ModelStorage.Get(Session.SessionID, root, null) as LaboratorySectionMaster;
            ViewBag.Root = root;
            if (ids != null)
            {
                string[] idents = ids.Split(new[] {','});
                idents.Select(c => Int64.Parse(c)).ToList().ForEach(id =>
                    {
                        var sample = master.LaboratorySectionItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
                        if (sample == null)
                            sample = master.LaboratorySectionMyPrefItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
                        if (sample != null)
                            ret.Add(sample);
                    });
                ViewBag.Idents = ids;
            }
            return ret;
        }

        private LaboratorySectionItem PreprocessGet(long root, string ids)
        {
            var master = ModelStorage.Get(Session.SessionID, root, null) as LaboratorySectionMaster;
            ViewBag.Root = root;
            if (ids != null)
            {
                string[] idents = ids.Split(new[] { ',' });
                long id = long.Parse(idents[0]);
                var sample = master.LaboratorySectionItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
                if (sample == null)
                    sample = master.LaboratorySectionMyPrefItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
                ViewBag.Idents = ids;
                return sample;
            }
            return null;
        }

        private LaboratorySectionItem PreprocessGet(long root, long id)
        {
            var master = ModelStorage.Get(Session.SessionID, root, null) as LaboratorySectionMaster;
            ViewBag.Root = root;
            var sample = master.LaboratorySectionItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
            if (sample == null)
                sample = master.LaboratorySectionMyPrefItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
            return sample;
        }

        private void PostprocessPost(FormCollection form, Action<DbManagerProxy, LaboratorySectionItem> action)
        {
            var root = long.Parse(form["Root"]);
            var master = ModelStorage.Get(Session.SessionID, root, null) as LaboratorySectionMaster;
            var ids = form["Idents"];
            var idents = ids.Split(new[] { ',' });
            foreach (var ident in idents)
            {
                var id = long.Parse(ident);
                var sample = master.LaboratorySectionItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
                if (sample == null)
                    sample = master.LaboratorySectionMyPrefItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {
                    action(manager, sample);
                }
            }
            if (master.bIsMyPref)
                master.LaboratorySectionMyPrefItems.ForEach(c => ModelStorage.Put(Session.SessionID, root, c.ID, "_" + root, c));
            else
                master.LaboratorySectionItems.ForEach(c => ModelStorage.Put(Session.SessionID, root, c.ID, "_" + root, c));
        }

        private void PostprocessPost(FormCollection form, Action<DbManagerProxy, List<IObject>, IObject> action)
        {
            var root = long.Parse(form["Root"]);
            var master = ModelStorage.Get(Session.SessionID, root, null) as LaboratorySectionMaster;
            var ids = form["Idents"];
            var idents = ids.Split(new[] { ',' });
            List<IObject> list = new List<IObject>();
            foreach (var ident in idents)
            {
                var id = long.Parse(ident);
                var sample = master.LaboratorySectionItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
                if (sample == null)
                    sample = master.LaboratorySectionMyPrefItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
                if (sample != null)
                    list.Add(sample);
            }
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                action(manager, list, master);
            }

            if (master.bIsMyPref)
                master.LaboratorySectionMyPrefItems.ForEach(c => ModelStorage.Put(Session.SessionID, root, c.ID, "_" + root, c));
            else
                master.LaboratorySectionItems.ForEach(c => ModelStorage.Put(Session.SessionID, root, c.ID, "_" + root, c));
        }

        private void PostprocessPostMaster(FormCollection form, Action<DbManagerProxy, LaboratorySectionMaster> action)
        {
            var root = long.Parse(form["Root"]);
            var master = ModelStorage.Get(Session.SessionID, root, null) as LaboratorySectionMaster;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                action(manager, master);
            }

            if (master.bIsMyPref)
                master.LaboratorySectionMyPrefItems.ForEach(c => ModelStorage.Put(Session.SessionID, root, c.ID, "_" + root, c));
            else
                master.LaboratorySectionItems.ForEach(c => ModelStorage.Put(Session.SessionID, root, c.ID, "_" + root, c));
        }


        [HttpGet]
        public ActionResult CreateAliquotPicker(long root, string ids)
        {
            var sample = PreprocessGet(root, ids);
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(root, 0, "", LaboratorySectionItem.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.CreateWithNewMode(m, p, LabNewModeEnum.CreateAliquot, sample.idfsSampleType, null, null, null, null),
                null);
        }
        
        [HttpPost]
        public ActionResult SetCreateAliquot(FormCollection form)
        {
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(form, LaboratorySectionItem.Accessor.Instance(null), 
                null,null,null,null,
                (o, p) => PostprocessPost(form, (m, s) => LaboratorySectionItem.Accessor.Instance(null).MenuCreateAliquot(m, s, o.intNewSample.Value))
                );
        }

        [HttpGet]
        public ActionResult CreateDerivativePicker(long root, string ids)
        {
            var sample = PreprocessGet(root, ids);
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(root, 0, "", LaboratorySectionItem.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.CreateWithNewMode(m, p, LabNewModeEnum.CreateDerivative, sample.idfsSampleType, null, null, null, null),
                null);
        }

        [HttpPost]
        public ActionResult SetCreateDerivative(FormCollection form)
        {
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(form, LaboratorySectionItem.Accessor.Instance(null),
                null, null, null, null,
                (o, p) => PostprocessPost(form, (m, s) => LaboratorySectionItem.Accessor.Instance(null).MenuCreateDerivative(m, s, o.intNewSample.Value, o.DerivativeType.idfsDerivativeType))
                );
        }

        [HttpGet]
        public ActionResult TransferOutSamplePicker(long root, string ids)
        {
            var sample = PreprocessGet(root, ids);
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(root, 0, "", LaboratorySectionItem.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.CreateWithNewMode(m, p, LabNewModeEnum.TransferOutSample, 0, null, null, null, null, null, DateTime.Today),
                null);
        }

        [HttpPost]
        public ActionResult SetTransferOutSample(FormCollection form)
        {
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(form, LaboratorySectionItem.Accessor.Instance(null),
                null, null, null, null,
                (o, p) => PostprocessPost(form, (m, s) => LaboratorySectionItem.Accessor.Instance(null).MenuTransferOutSample(m, s, o.idfSendToOfficeOut, o.datSendDate))
                );
        }

        [HttpGet]
        public ActionResult AccessionInPoorConditionPicker(long root, string ids)
        {
            var sample = PreprocessGet(root, ids);
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(root, 0, "", LaboratorySectionItem.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.CreateWithNewMode(m, p, LabNewModeEnum.Accept, 0, null, null, null, null),
                null);
        }

        [HttpPost]
        public ActionResult SetAccessionInPoorCondition(FormCollection form)
        {
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(form, LaboratorySectionItem.Accessor.Instance(null),
                null, null, null, null,
                (o, p) => PostprocessPost(form, (m, s) => LaboratorySectionItem.Accessor.Instance(null).MenuAccessionInPoorCondition(m, s, o.strComments))
                );
        }

        [HttpGet]
        public ActionResult AccessionInRejectedPicker(long root, string ids)
        {
            var sample = PreprocessGet(root, ids);
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(root, 0, "", LaboratorySectionItem.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.CreateWithNewMode(m, p, LabNewModeEnum.Accept, sample.idfsSampleType, null, null, null, null),
                null);
        }

        [HttpPost]
        public ActionResult SetAccessionInRejected(FormCollection form)
        {
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(form, LaboratorySectionItem.Accessor.Instance(null),
                null, null, null, null,
                (o, p) => PostprocessPost(form, (m, s) => LaboratorySectionItem.Accessor.Instance(null).MenuAccessionInRejected(m, s, o.strComments))
                );
        }

        [HttpGet]
        public ActionResult AmendTestResultPicker(long root, string ids)
        {
            var sample = PreprocessGet(root, ids);
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(root, 0, "", LaboratorySectionItem.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.CreateWithNewMode(m, p, LabNewModeEnum.AmendTestResult, 0, sample.idfsTestName.Value, null, null, null, sample.GetOriginalTestResult()),
                null);
        }

        [HttpPost]
        public ActionResult SetAmendTestResult(FormCollection form)
        {
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(form, LaboratorySectionItem.Accessor.Instance(null),
                null, null, null, null,
                (o, p) => PostprocessPost(form, (m, s) => LaboratorySectionItem.Accessor.Instance(null).MenuAmendTestResult(m, s, o.strReason, o.idfsTestResult.Value))
                );
        }

        [HttpGet]
        public ActionResult AssignTestPicker(long root, string ids)
        {
            var sample = PreprocessGet(root, ids);
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(root, 0, "", LaboratorySectionItem.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.CreateWithNewMode(m, p, LabNewModeEnum.AssignTest, sample.idfsSampleType, null, sample.idfCaseOrSession, sample.idfsCaseType, sample.intCaseHACode, null, null, sample.idfMaterial, sample.idfsShowDiagnosis),
                null);
        }

        [HttpPost]
        public ActionResult SetAssignTest(FormCollection form)
        {
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(form, LaboratorySectionItem.Accessor.Instance(null),
                null, null, null, null,
                (o, r) => PostprocessPost(form, (m, l, p) =>
                    {
                        var bIsMyPref = false;
                        if (l.Count > 0)
                            bIsMyPref = ((LaboratorySectionItem) l[0]).bIsMyPref;
                        LaboratorySectionItem.Accessor.Instance(null).ItemAssignTest(m, o, l, p, bIsMyPref);
                    })
                );
        }

        [HttpGet]
        public ActionResult CreateSamplePicker(long root)
        {
            PreprocessGet(root, null);
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(root, 0, "", LaboratorySectionItem.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.CreateWithNewMode(m, p, LabNewModeEnum.CreateSample, 0, null, null, null, null),
                null);
        }

        [HttpPost]
        public ActionResult SetCreateSample(FormCollection form)
        {
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(form, LaboratorySectionItem.Accessor.Instance(null),
                null, null, null, null,
                (o, p) => PostprocessPostMaster(form, (m, mm) => LaboratorySectionItem.Accessor.Instance(null).ItemCreate(m, o, o.intNewSample.Value, mm, o, o.idfsSampleTypeFiltered, mm.bIsMyPref))
                );
        }

        [HttpGet]
        public ActionResult GroupAccessionInPicker(long root)
        {
            PreprocessGet(root, null);
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(root, 0, "", LaboratorySectionItem.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.CreateWithNewMode(m, p, LabNewModeEnum.GroupAccessionIn, 0, null, null, null, null),
                null);
        }

        [HttpPost]
        public ActionResult SetGroupAccessionIn(FormCollection form)
        {
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(form, LaboratorySectionItem.Accessor.Instance(null),
                null, null, null, null,
                (o, p) => PostprocessPostMaster(form, (m, mm) => LaboratorySectionItem.Accessor.Instance(null).ItemGroupAccessionIn(m, o, mm, mm.bIsMyPref))
                );
        }

        [HttpGet]
        public ActionResult DetailsPicker(long root, long id)
        {
            var sample = PreprocessGet(root, id);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                sample.SetupLoad(manager);
            }
            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(root, id, "", LaboratorySectionItem.Accessor.Instance(null), null,
                (m, a, p) =>
                    {
                        var ret = (sample.CloneWithSetup(m) as LaboratorySectionItem).GetWithOriginal(sample);
                        ModelStorage.Put(Session.SessionID, id, id, (ret.idfObservation.HasValue ? ret.idfObservation.Value : 0).ToString(), ret.FFPresenter);
                        return ret;
                    },
                null,
                (m, a, o) => ModelStorage.Put(Session.SessionID, id, id, o.ObjectIdent + "AmendmentHistory", o.AmendmentHistory)
                );
        }

        private Tuple<FormCollection, ActionResult> SetOneField(LaboratorySectionItem sample, long id, FormCollection form, string field)
        {
            if (form.AllKeys.Any(c => c.EndsWith(field)))
            {
                var fieldKey = form.AllKeys.First(c => c.EndsWith(field));
                var fieldValue = form[fieldKey];
                form.Remove(fieldKey);
                var formNew = new FormCollection();
                //formNew.Add(LaboratorySectionItem.Accessor.Instance(null).KeyName, form[LaboratorySectionItem.Accessor.Instance(null).KeyName]);
                //formNew.Add("Root", form["Root"]);
                form.AllKeys.Where(c => !c.StartsWith("LaboratorySectionItem")).ToList().ForEach(c => formNew.Add(c, form[c]));
                formNew.Add(fieldKey, fieldValue);
                var ret = PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(formNew, LaboratorySectionItem.Accessor.Instance(null),
                    null, null, null, null, (c, p) => { }, c => sample
                    );
                if (((ret as JsonResult).Data as CompareModel).Values.Any(c => c.Key == "ErrorMessage"))
                {
                    return new Tuple<FormCollection, ActionResult>(null, ret);
                }
                if (id != sample.ID)
                {
                    formNew = new FormCollection();
                    form.AllKeys.ToList().ForEach(c =>
                    {
                        string key = c.Replace(id.ToString(), sample.ID.ToString());
                        var value = form[c];
                        formNew.Add(key, value);
                    });
                    form = formNew;
                }
            }
            return new Tuple<FormCollection, ActionResult>(form , null);
        }

        [HttpPost]
        public ActionResult SetDetails(FormCollection form)
        {
            var id = long.Parse(form[LaboratorySectionItem.Accessor.Instance(null).KeyName]);
            var root = long.Parse(form["Root"]);
            var sample = PreprocessGet(root, id);
            var ret = SetOneField(sample, id, form, "blnExternalTest");
            if (ret.Item2 != null) return ret.Item2;
            form = ret.Item1;
            ret = SetOneField(sample, id, form, "TestNameRef");
            if (ret.Item2 != null) return ret.Item2;
            form = ret.Item1;
            ret = SetOneField(sample, id, form, "DiagnosisForTest");
            if (ret.Item2 != null) return ret.Item2;
            form = ret.Item1;
            ret = SetOneField(sample, id, form, "TestStatusShort");
            if (ret.Item2 != null) return ret.Item2;
            form = ret.Item1;
            ret = SetOneField(sample, id, form, "TestResultRef");
            if (ret.Item2 != null) return ret.Item2;
            form = ret.Item1;

            if (sample.FFPresenter != null && sample.FFPresenter.CurrentObservation.HasValue)
            {
                var idfObservation = sample.FFPresenter.CurrentObservation.Value;
                var formNew = new FormCollection();
                form.AllKeys.ToList().ForEach(c =>
                {
                    var value = form[c];
                    int o = c.IndexOf("o");
                    int p = c.IndexOf("_p");
                    if (o == 0 && p > o)
                    {
                        string oldkey = c.Substring(o + 1, p - o - 1);
                        string key = c.Replace(oldkey, idfObservation.ToString());
                        formNew.Add(key, value);
                    }
                    else
                    {
                        formNew.Add(c, value);
                    }
                });
                form = formNew;
            }

            return PickerInternal<LaboratorySectionItem.Accessor, LaboratorySectionItem, LaboratorySectionMaster>(form, LaboratorySectionItem.Accessor.Instance(null),
                null, null, null, null, null, c => sample
                );
        }

        public ActionResult GetFlexForm(long root)
        {
            var item = ModelStorage.Get(Session.SessionID, root, null, false) as LaboratorySectionItem;
            if ((item != null) && (item.FFPresenter != null) && (item.FFPresenter.CurrentObservation.HasValue))
            {
                LaboratorySectionItem.Accessor accessor = LaboratorySectionItem.Accessor.Instance(null);
                item.FFPresenter.ReadOnly = accessor.IsReadOnlyForEdit || item.IsReadOnly("idfObservation");
                ModelStorage.Put(Session.SessionID, item.idfTesting.Value, item.idfTesting.Value, item.FFPresenter.CurrentObservation.Value.ToString(), item.FFPresenter);
                var ffDivContent = this.RenderPartialView("FlexForm", item);
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = ffDivContent };
            }

            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "" };
        }


        [HttpPost]
        public ActionResult Delete(long root, long id)
        {
            var sample = PreprocessGet(root, id);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                LaboratorySectionItem.Accessor.Instance(null).MenuRemove(manager, sample);
            }
            var data = new CompareModel();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }

        [HttpPost]
        public ActionResult SampleDelete(long root, string ids)
        {
            var samples = PreprocessGetAll(root, ids);
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                samples.ForEach(s => LaboratorySectionItem.Accessor.Instance(null).MenuDeleteSample(manager, s));
            }
            var data = new CompareModel();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = data };
        }


    }

    public class SampleBarcodeDTOComparator : EqualityComparer<SampleBarcodeDTO>
    {
        public override bool Equals(SampleBarcodeDTO x, SampleBarcodeDTO y)
        {
            return x.Barcode == y.Barcode
                && x.CollectionDate == y.CollectionDate
                && x.OwnerId == y.OwnerId
                && x.SpeciesCode == y.SpeciesCode
                && x.SpecimenCode == y.SpecimenCode
                ;
        }

        public override int GetHashCode(SampleBarcodeDTO obj)
        {
            return base.GetHashCode();
        }
    }

    [AuthorizeEIDSS]
    public class LaboratoryReportController : BvController
    {
        private LaboratorySectionItem PreprocessGet(long root, string ids)
        {
            var master = ModelStorage.Get(Session.SessionID, root, null) as LaboratorySectionMaster;
            ViewBag.Root = root;
            if (ids != null)
            {
                string[] idents = ids.Split(new[] { ',' });
                long id = long.Parse(idents[0]);
                var sample = master.LaboratorySectionItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
                if (sample == null)
                    sample = master.LaboratorySectionMyPrefItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
                ViewBag.Idents = ids;
                return sample;
            }
            return null;
        }

        private List<LaboratorySectionItem> PreprocessGetAll(long root, string ids)
        {
            var ret = new List<LaboratorySectionItem>();
            var master = ModelStorage.Get(Session.SessionID, root, null) as LaboratorySectionMaster;
            ViewBag.Root = root;
            if (ids != null)
            {
                string[] idents = ids.Split(new[] { ',' });
                idents.Select(c => Int64.Parse(c)).ToList().ForEach(id =>
                {
                    var sample = master.LaboratorySectionItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
                    if (sample == null)
                        sample = master.LaboratorySectionMyPrefItems.FirstOrDefault(c => c.idfMaterial == id || c.idfTesting == id);
                    if (sample != null)
                        ret.Add(sample);
                });
                ViewBag.Idents = ids;
            }
            return ret;
        }

        public ActionResult SampleReport(long id)
        {
            try
            {
                byte[] report;
                using (var wrapper = new ReportClientWrapper())
                {
                    var model = new BaseIdModel(ModelUserContext.CurrentLanguage, id, ModelUserContext.Instance.IsArchiveMode);
                    report = wrapper.Client.ExportLimSample(model);
                }
                return ReportResponse(report, "SampleReport.pdf");
            }
            catch
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
            }
        }

        public ActionResult TestResultReport(long root, string ids)
        {
            try
            {
                byte[] report;
                using (var wrapper = new ReportClientWrapper())
                {
                    var item = PreprocessGet(root, ids);
                    var model = new LimTestResultModel(ModelUserContext.CurrentLanguage, item.idfTesting ?? 0, item.idfObservation ?? 0, item.idfsTestName ?? 0, ModelUserContext.Instance.IsArchiveMode);

                    report = wrapper.Client.ExportLimTestResult(model);
                }
                return ReportResponse(report, "TestResultReport.pdf");
            }
            catch
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
            }
        }

        public ActionResult SampleDestructionReport(long id)
        {
            try
            {
                byte[] report;
                using (var wrapper = new ReportClientWrapper())
                {
                    var model = new IdListModel(ModelUserContext.CurrentLanguage, new[] { id }, ModelUserContext.Instance.IsArchiveMode);

                    report = wrapper.Client.ExportLimSampleDestruction(model);
                }
                return ReportResponse(report, "SampleDestructionReport.pdf");
            }
            catch
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
            }
        }


        public ActionResult PrintBarcode(long root, string ids)
        {
            try
            {
                byte[] report;
                using (var wrapper = new ReportClientWrapper())
                {
                    var items = PreprocessGetAll(root, ids);
                    var model = items.Select(c => new SampleBarcodeDTO()
                    {
                        Barcode = c.strBarcode,
                        CollectionDate = c.datFieldCollectionDate.HasValue ? c.datFieldCollectionDate.Value : DateTime.MinValue,
                        OwnerId = c.strCalculatedCaseID,
                        SpeciesCode = c.SpeciesVectorInfo == null ? "" : c.SpeciesVectorInfo.SpeciesOrVectorType,
                        SpecimenCode = c.SampleType == null ? "" : c.SampleType.name
                    }).Distinct(new SampleBarcodeDTOComparator()).ToArray();

                    report = wrapper.Client.ExportSampleBarcodes(model);
                }
                return ReportResponse(report, "PrintBarcode.pdf");
            }
            catch
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
            }
        }


        [HttpGet]
        public ActionResult TestsReport(long id, bool isHuman)
        {
            try
            {
                byte[] report;
                using (var wrapper = new ReportClientWrapper())
                {
                    var model = new LimTestModel(ModelUserContext.CurrentLanguage, id, isHuman, ModelUserContext.Instance.IsArchiveMode);
                    report = wrapper.Client.ExportLimTest(model);
                }
                return ReportResponse(report, "TestsReport.pdf");
            }
            catch
            {
                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
            }
        }
    }
}

