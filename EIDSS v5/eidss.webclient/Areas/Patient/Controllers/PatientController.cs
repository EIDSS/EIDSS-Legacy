using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eidss.webclient.Utils;

namespace eidss.webclient.Areas.Patient.Controllers
{
    public class PatientController : Controller
    {
        //[HttpGet]
        public ActionResult ShowPatient(long root, eidss.model.Schema.Patient patient, bool isAgeVisible = true, bool isCoordinatesFieldsVisible = false)
        {
            ModelStorage.Put(Session.SessionID, root, patient.idfHuman, null, patient);
            ViewBag.IsAgeVisible = isAgeVisible;
            ViewBag.IsCoordinatesFieldsVisible = isCoordinatesFieldsVisible;
            return PartialView(patient);
        }
    }
}
