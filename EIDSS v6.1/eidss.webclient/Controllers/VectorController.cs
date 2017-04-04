using System;
using System.Linq;
using System.Web.Mvc;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class VectorController : BvController
    { 
        [HttpGet]
        public ActionResult Details(long key, string name, long id, int? deleteWhenCancel)
        {
            //сохраняем режим открытия. Он нужен для кнопки отмены в детальной форме вектора.
            ViewBag.deleteWhenCancel = deleteWhenCancel.HasValue ? deleteWhenCancel.Value : 0;
            ViewBag.id = id;
            ViewBag.listKey = key;
            ViewBag.name = name;
            return PickerInternal<Vector.Accessor, Vector, VsSession>(key, id, name, Vector.Accessor.Instance(null),
                null
                , null
                , (manager, accessor, vector) =>
                {
                    //var session = ModelStorage.GetRoot(ModelUserContext.ClientID, key, String.Empty) as VsSession;
                    return ObjectStorage.UsingRoot<VsSession, Vector>(session =>
                        {
                            if (session == null) return null;
                            var acc = Vector.Accessor.Instance(null);
                            return acc.Create(manager, session, session.idfVectorSurveillanceSession
                                              , session.datStartDate, session.strSessionID, session.Location);
                        }, ModelUserContext.ClientID, key, String.Empty);
                }
                ,
                null);
        }

        [HttpPost]
        public ActionResult StoreInSession(FormCollection form)
        {
            var key = long.Parse(form["idfVector"]);
            //var vector = (Vector)ModelStorage.Get(ModelUserContext.ClientID, key, null);
            return ObjectStorage.Using<Vector, ActionResult>(vector =>
                {
                    vector.ParseFormCollection(form);
                    return new JsonResult { Data = String.Empty, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }, ModelUserContext.ClientID, key, null);
        }

        [HttpPost]
        public ActionResult Details(FormCollection form)
        {
            var result = PickerInternal<Vector.Accessor, Vector, VsSession>(form, Vector.Accessor.Instance(null), null,
                p => p.Vectors,
                (i, o) => i.idfVector == o.idfVector
                , (to, from) =>
                {
                    to.Samples.Clear();
                    to.Samples.AddRange(from.Samples);
                    to.Samples.ForEach(i => i.SetChange());

                    to.FieldTests.Clear();
                    to.FieldTests.AddRange(from.FieldTests);
                    to.FieldTests.ForEach(i => i.SetChange());

                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        to.Location = to.Location.CopyFrom(manager, from.Location);
                    }
                }
                , (v, vs, cl) =>
                    {
                        if (vs != null)
                        {
                            var vector = vs.Vectors.FirstOrDefault(c => c.idfVector == v.idfVector);
                            if (vector != null) vector.blnIgnoreValidation = false;
                        }
                        return null;
                    }
                );
            ObjectStorage.Put(ModelUserContext.ClientID, 0, 0, "SelectedIndex", 0);
            return result;
        }

        [HttpPost]
        public ActionResult SetVectorSample(FormCollection form)
        {
            return PickerInternal<VectorSample.Accessor, VectorSample, Vector>(form, VectorSample.Accessor.Instance(null), null,
                p => p.Samples,
                (i, o) => i.idfMaterial == o.idfMaterial,
                null);
        }

        [HttpGet]
        public ActionResult VectorSamplePicker(long key, string name, long id)
        {
            return PickerInternal<VectorSample.Accessor, VectorSample, Vector>(key, id, name, VectorSample.Accessor.Instance(null),
                null
                , null
                , (manager, accessor, vector) => accessor.Create(manager, vector)
                , null);
        }

        [HttpPost]
        public ActionResult SetCopyVector(FormCollection form)
        {
            var idSession = long.Parse(form["idfVectorSurveillanceSession"]);
            var idVector = long.Parse(form["idfVector"]);
            long idVectorNew = 0;
            //var session = ModelStorage.GetRoot(ModelUserContext.ClientID, idSession, String.Empty) as VsSession;
            return ObjectStorage.UsingRoot<VsSession, ActionResult>(session =>
                {
                    if (session != null)
                    {
                        //новый вектор ещё не добавлен в сессию, но тогда должен иметь самостоятельную ссылку в хранилище
                        //var vector = session.Vectors.FirstOrDefault(v => v.idfVector == idVector) 
                        //    ??
                        //    ModelStorage.Get(ModelUserContext.ClientID, idVector, String.Empty) as Vector;
                        ObjectStorage.UsingAlternative<Vector, bool>(
                            () => session.Vectors.FirstOrDefault(v => v.idfVector == idVector),
                            vector =>
                            {
                                if (vector != null)
                                {
                                    var needCopyFF = bool.Parse(form["CopyDialogWindowItem_0_blnNeedCopyFF"] ?? "false");
                                    var needCopySamples = bool.Parse(form["CopyDialogWindowItem_0_blnNeedCopySamples"] ?? "false");
                                    var needCopyFT = bool.Parse(form["CopyDialogWindowItem_0_blnNeedCopyFT"] ?? "false");
                                    using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                                    {
                                        var vectorNew = vector.CopyVector(manager, needCopyFF, needCopySamples, needCopyFT);
                                        session.Vectors.Add(vectorNew);
                                        idVectorNew = vectorNew.idfVector;
                                    }
                                }
                                return false;
                            }, ModelUserContext.ClientID, idVector, String.Empty);
                    }

                    var model = new CompareModel();
                    model.Add("idVectorNew", String.Empty, "long", idVectorNew.ToString(), false, false, false);

                    return new JsonResult
                        {
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            ,
                            Data = model
                        };
                }, ModelUserContext.ClientID, idSession, String.Empty);
        }

        [HttpGet]
        public ActionResult CopyVectorPicker(long key, string name, long id)
        {
            return PickerInternal<CopyDialogWindowItem.Accessor, CopyDialogWindowItem, VsSession>(key, 0/*id*/, "-"/*name*/
                , CopyDialogWindowItem.Accessor.Instance(null)
                , null
                , null
                , (manager, accessor, session) =>
                {
                    var c = (CopyDialogWindowItem)accessor.CreateNew(manager, session);
                    c.idfVectorSurveillanceSession = session.idfVectorSurveillanceSession;
                    c.idfVector = id;
                    return c;
                }
                , null
                , false);
        }

        [HttpGet]
        public ActionResult VectorFieldTestPicker(long key, string name, long id)
        {
            return PickerInternal<VectorFieldTest.Accessor, VectorFieldTest, Vector>(key, id, name, VectorFieldTest.Accessor.Instance(null),
                null
                , null
                , (manager, accessor, vector) => accessor.CreateNewT(manager, vector),
                null);
        }

        [HttpGet]
        public ActionResult VectorLabTestPicker(long key, string name, long id)
        {
            return PickerInternal<VectorLabTest.Accessor, VectorLabTest, Vector>(key, id, name, VectorLabTest.Accessor.Instance(null),
                null
                , null
                , (manager, accessor, vector) => accessor.CreateNewT(manager, vector)
                , (manager, accessor, labTest) => ObjectStorage.Put(ModelUserContext.ClientID, labTest.idfTesting, labTest.idfTesting, labTest.ObjectIdent + "AmendmentHistory", labTest.AmendmentHistory)
                );
        }

        [HttpPost]
        public ActionResult SetVectorFieldTest(FormCollection form)
        {
            return PickerInternal<VectorFieldTest.Accessor, VectorFieldTest, Vector>(form, VectorFieldTest.Accessor.Instance(null), null,
                p => p.FieldTests,
                (i, o) => i.idfPensideTest == o.idfPensideTest,
                null);
        }

        [HttpGet]
        [CompressFilter]
        public ActionResult GetFlexForm(long root, long additional)
        {
            var idSession = root;
            var idVector = additional;
            //var session = ModelStorage.GetRoot(ModelUserContext.ClientID, idSession, String.Empty) as VsSession;
            return ObjectStorage.UsingRoot<VsSession, ActionResult>(session =>
                {
                    if (session == null) return null;

                    //var vector = ModelStorage.Get(ModelUserContext.ClientID, idVector, String.Empty) as Vector;
                    return ObjectStorage.Using<Vector, ActionResult>(vector =>
                        {
                            if (vector == null) return null;

                            if ((vector.FFPresenter != null) && (vector.FFPresenter.CurrentObservation.HasValue))
                            {
                                var acc = Vector.Accessor.Instance(null);
                                vector.FFPresenter.ReadOnly = acc.IsReadOnlyForEdit || session.IsClosed;
                                ObjectStorage.Put(ModelUserContext.ClientID, idVector, idVector, vector.FFPresenter.CurrentObservation.Value.ToString(), vector.FFPresenter);
                                var ffDivContent = this.RenderPartialView("FlexForm", vector);
                                return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = ffDivContent };
                            }

                            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = Translator.GetMessageString("msgNowTemplate") };
                        }, ModelUserContext.ClientID, idVector, String.Empty);
                }, ModelUserContext.ClientID, idSession, String.Empty);
        }

        [HttpGet]
        public ActionResult GetIsPoolVectorType(long idVector)
        {
            //var vector = ModelStorage.Get(ModelUserContext.ClientID, idVector, String.Empty) as Vector;
            return ObjectStorage.Using<Vector, ActionResult>(vector =>
                {
                    var result = vector != null && vector.GetIsPoolVectorType(vector.idfsVectorType);
                    return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }, ModelUserContext.ClientID, idVector, String.Empty);
        }
    }
}
