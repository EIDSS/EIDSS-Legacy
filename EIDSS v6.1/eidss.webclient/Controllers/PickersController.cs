using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.web.common.Controllers;
using eidss.webclient.Utils;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Enums;
using eidss.web.common.Utils;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class PickersController : BvController
    {

        [HttpGet]
        public ActionResult PensideTestPicker(long key, string name, long id)
        {
            return PickerInternal<PensideTest.Accessor, PensideTest, VetCase>(key, id, name, PensideTest.Accessor.Instance(null), null,
                null, null, null);
        }

        [HttpPost]
        public ActionResult PensideTestPicker(FormCollection form)
        {
            return PickerInternal<PensideTest.Accessor, PensideTest, VetCase>(form, PensideTest.Accessor.Instance(null), null, 
                p => p.PensideTests,
                (i, o) => i.idfPensideTest == o.idfPensideTest,
                null);
        }


        [HttpGet]
        public ActionResult VetCaseLogPicker(long key, string name, long id)
        {
            return PickerInternal<VetCaseLog.Accessor, VetCaseLog, VetCase>(key, id, name, VetCaseLog.Accessor.Instance(null), null,
                null, null, null);
        }

        [HttpPost]
        public ActionResult VetCaseLogPicker(FormCollection form)
        {
            return PickerInternal<VetCaseLog.Accessor, VetCaseLog, VetCase>(form, VetCaseLog.Accessor.Instance(null), null,
                p => p.Logs,
                (i, o) => i.idfVetCaseLog == o.idfVetCaseLog,
                null);
        }


        public ActionResult VaccinationPicker(long key, string name, long id)
        {
            return PickerInternal<VaccinationListItem.Accessor, VaccinationListItem, VetCase>(key, id, name, VaccinationListItem.Accessor.Instance(null), null,
                null, 
                (m, a, p) => a.Create(m, p), 
                (m, a, o) =>
                    {
                        ViewBag.HerdsAndSpecies = StorageItemsExtractor.CurrentHerdAndSpeciesOfCase(ModelUserContext.ClientID, key);
                    }
                );
        }


        [HttpPost]
        public ActionResult VaccinationPicker(FormCollection form)
        {
            return PickerInternal<VaccinationListItem.Accessor, VaccinationListItem, VetCase>(form, VaccinationListItem.Accessor.Instance(null), null, 
                p => p.Vaccination,
                (i, o) => i.idfVaccination == o.idfVaccination,
                null);
        }



        public ActionResult AnimalPicker(long key, string name, long id)
        {
            return PickerInternal<AnimalListItem.Accessor, AnimalListItem, VetCase>(key, id, name, AnimalListItem.Accessor.Instance(null), null,
                null,
                (m, a, p) => a.CreateAnimal(m, p, p.idfsDiagnosis),
                (m, a, o) =>
                {
                    ViewBag.SpeciesSelection = StorageItemsExtractor.CurrentHerdAndSpeciesOfCase(ModelUserContext.ClientID, key);
                }
                );
        }

        [HttpPost]
        public ActionResult AnimalPicker(FormCollection form)
        {
            return PickerInternal<AnimalListItem.Accessor, AnimalListItem, VetCase>(form, AnimalListItem.Accessor.Instance(null), null,
                p => p.AnimalList,
                (i, o) => i.idfAnimal == o.idfAnimal,
                null
                );
        }

    }
}
