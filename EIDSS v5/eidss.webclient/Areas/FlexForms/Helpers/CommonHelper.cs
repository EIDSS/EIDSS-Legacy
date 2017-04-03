using System;
using System.Web.Mvc;
using eidss.model.Schema;

namespace eidss.webclient.Areas.FlexForms.Helpers
{
    public static class CommonHelper
    {
        private const string FFKeyMask = "FFPresenterModel_idfsFormTemplate_{0}_idfObservation_{1}";

        public static string FFModelKey(this FFPresenterModel model)
        {
            return String.Format(FFKeyMask
                                 , model.CurrentTemplate.idfsFormTemplate
                                 , model.CurrentObservation.HasValue ? model.CurrentObservation.Value : 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idfsFormTemplate"></param>
        /// <param name="idfObservation"></param>
        /// <returns></returns>
        public static string FFModelKey(long idfsFormTemplate, long? idfObservation)
        {
            return String.Format(FFKeyMask
                                 , idfsFormTemplate
                                 , idfObservation.HasValue ? idfObservation.Value : 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static string FFModelKey(this FormCollection form)
        {
            var idfsFormTemplate = Convert.ToInt64(form["idfsFormTemplate"]);
            var idObs = form["idfObservation"];
            long? idfObservation = idObs != null ? idObs.Length > 0 ? Convert.ToInt64(idObs) : 0 : 0;
            return FFModelKey(idfsFormTemplate, idfObservation);
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="activityParameters"></param>
        /// <param name="form"></param>
        /// <param name="template"></param>
        /// <param name="idfObservation"></param>
        public static void ExtractFromCollection(this EditableList<ActivityParameter> activityParameters
                    , FormCollection form
                    , Template template
                    , long idfObservation)
        {

            //отберём те контролы с формы, которые относятся к нужному ключу
            string ffKey = DataHelper.GetFFParameterKey(template.idfsFormTemplate, idfObservation);
            const string idparam = "idfsParameter_";
            int keyPartLength = idparam.Length;
            foreach (string key in form.Keys)
            {
                if (key.Contains(ffKey) && key.Contains(idparam))
                {
                    int index = key.IndexOf(idparam);
                    var idfsParameter = Convert.ToInt64(key.Substring(index + keyPartLength, key.Length - index - keyPartLength));
                    activityParameters.SetActivityParameterValue(template, idfObservation, idfsParameter, form[key]);
                }
            }
        }
        */
    }
}