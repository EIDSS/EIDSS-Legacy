using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using eidss.webclient.Utils;
using Telerik.Web.Mvc.UI;
using eidss.model.Core;
using eidss.model.Enums;

namespace eidss.webclient.Areas.ContactedPerson.Controllers
{
    public class ContactedPersonController : Controller
    {
        public ActionResult ShowHumanContactedPerson(long root, string name, EditableList<ContactedCasePerson> personList, bool isReadOnly)
        {
            ViewData["ContactedCasePersonGridName"] = name;
            ViewData["IsReadOnly"] = isReadOnly;
            var parent = (HumanCase)((HumanCase)ModelStorage.GetRoot(Session.SessionID, root, "")).Clone();
            if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Contact_Settlement)
                || EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Contact_Details))
            {
                ViewData["IsReadOnly"] = true;
                parent.AddHiddenPersonalData("GeoLocationNameWithHiddenPersonalData", c => true);
                parent.AddHiddenPersonalData("strFullName", c => true);
                if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_Contact_Details))
                {
                    parent.AddHiddenPersonalData("Settlement", c => true);
                }
                ViewData["ExcludeColumns"] = "strRegistrationAddress";
                AddressStringHelper.RearrangeAddressDisplayString(parent, personList);
            }
            else
            {
                ViewData["ExcludeColumns"] = "GeoLocationNameWithHiddenPersonalData";
            }
            
            ViewData["Parent"] = parent;
            ModelStorage.Put(Session.SessionID, root, root, name, personList);
            var model = new ContactedCasePerson.ContactedCasePersonGridModelList(root, personList);
            return PartialView(model);
        }
    }
}
