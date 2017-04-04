using System.Web.Mvc;
using BLToolkit.EditableObjects;
using eidss.model.Schema;
using eidss.webui.Areas.FlexForms.Models;
using eidss.webui.Areas.FlexForms.Helpers;
using eidss.webui.Utils;

namespace eidss.webui.Areas.FlexForms.Controllers
{
    public class FFPresenterController : Controller
    {
        //
        // GET: /FFPresenter/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="idfsFormTemplate"></param>
        ///// <returns></returns>
        
        //public ActionResult ShowFlexibleForm(long idfsFormTemplate)
        //{
        //    return ShowFlexibleForm2(idfsFormTemplate, null);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="idfsFormTemplate"></param>
        ///// <param name="activityParameters"></param>
        ///// <returns></returns>
        
        //public ActionResult ShowFlexibleForm2(long idfsFormTemplate, EditableList<ActivityParameter> activityParameters)
        //{
        //    Template template;

        //    DbManagerFactory.SetSqlFactory(Config.AppSetting("EidssConnectionString", ""));
        //    using (var manager = DbManagerFactory.Factory.Create())
        //    {
        //        var acc = Template.Accessor.Instance(null);
        //        template = acc.SelectByKey(manager, idfsFormTemplate, null);
        //    }

        //    return ShowFlexibleForm3(template, activityParameters);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowFlexibleForm(long root, Template template, long? idfObservation, EditableList<ActivityParameter> activityParameters)
        {
            //определяем, есть ли такая модель в хранилище
            //var key = CommonHelper.FFModelKey(template.idfsFormTemplate, idfObservation);
            
            //var model = (FFPresenterModel)Session[key];
            var key = idfObservation.HasValue ? idfObservation.Value : -1;
            var model = ModelStorage.Get(Session.SessionID, key) as FFPresenterModel;
            //var model = (FFPresenterModel)Session[key];
            if (model == null)
            {
                model = new FFPresenterModel();
                model.SetProperties(template, idfObservation, activityParameters);
                ModelStorage.Put(Session.SessionID, root, key, model);
                //Session[key] = model;
                //ViewData[key] = model;
            }

            //return View(model););
            //return model.TemplateFlexNode.Count > 0 
            //    ? PartialView(model) 
            //    : PartialView(); //на пустом шаблоне ничего не рендерим
            return PartialView(model);
        }

        //[HttpPost]
        //public ActionResult ShowFlexibleForm(FormCollection form)
        //{
        //    var model = (FFPresenterModel)Session[form.FFModelKey()];
        //    //var model = (FFPresenterModel)ViewData[form.FFModelKey()];

        //    //производим считывание данных с формы и помещаем их в модель
        //    //model.PutDataIntoModel(form);
        //    //сохраняем данные
        //    //model.SaveActivityParameters();

        //    return PartialView(model);
        //}

    }
}
