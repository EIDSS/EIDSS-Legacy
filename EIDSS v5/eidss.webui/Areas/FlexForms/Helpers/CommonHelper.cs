using System;
using System.Web.Mvc;
using eidss.webui.Areas.FlexForms.Models;

namespace eidss.webui.Areas.FlexForms.Helpers
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
    }
}