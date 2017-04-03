using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eidss.webui.Utils;

namespace eidss.webui.Areas.Patient.Controllers
{
    public class PatientController : Controller
    {
        //[HttpGet]
        public ActionResult ShowPatient(long root, eidss.model.Schema.Patient patient)
        {
            ModelStorage.Put(Session.SessionID, root, patient.idfHuman, patient);
            return PartialView(patient);
        }
    }
}
