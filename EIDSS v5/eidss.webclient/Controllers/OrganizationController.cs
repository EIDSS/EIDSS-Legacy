using System;
using System.Web.Mvc;
using eidss.webclient.Utils;
using bv.model.Model.Core;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class OrganizationController : Controller
    {
        public ActionResult InlineOrganizationPicker(IObject obj, long objectId, string idfsOrganizationPropertyName, string strOrganizationPropertyName,
            bool showInInternalWindow = false, string idfsEmployeePropertyName = "", string strEmployeePropertyName = "")
        {
            ViewBag.IdfsOrganizationPropertyName = idfsOrganizationPropertyName;
            ViewBag.StrOrganizationPropertyName = strOrganizationPropertyName;
            ViewBag.MainDivId = string.Format("divOrgSearchPicker_{0}_{1}", objectId, idfsOrganizationPropertyName);
            ViewBag.BtnSearchPicker = string.Format("btnOrgSearchPicker_{0}_{1}", objectId, idfsOrganizationPropertyName);
            ViewBag.BtnClianPicker = string.Format("btnOrgClian_{0}_{1}", objectId, idfsOrganizationPropertyName);

            SetButtonsReadOnlyInViewBag(objectId, idfsOrganizationPropertyName);

            string language = Cultures.GetSiteLanguage(Request);
            string onSelectItemClick = string.Format("ShowOrganizationSearchPicker(\"/{0}/System/OrganizationPicker?objectId={1}&" +
                "idfsOrganizationPropertyName={2}&strOrganizationPropertyName={3}&idfsEmployeePropertyName={4}&strEmployeePropertyName={5}&" +
                "showInInternalWindow={6}\", \"{6}\")",
                language, objectId, idfsOrganizationPropertyName, strOrganizationPropertyName, idfsEmployeePropertyName, strEmployeePropertyName, showInInternalWindow);

            ViewBag.OnSelectItemClick = onSelectItemClick;

            string onClianButtonClick = string.Format("onOrganizationPickerValueChanged(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"\", \"{5}\")",
                objectId, idfsOrganizationPropertyName, strOrganizationPropertyName, idfsEmployeePropertyName, strEmployeePropertyName, showInInternalWindow);

            ViewBag.OnClianButtonClick = onClianButtonClick;

            return PartialView(obj);
        }

        private void SetButtonsReadOnlyInViewBag(long objectId, string idfsOrganizationPropertyName)
        {
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, objectId, null);

            IObjectPermissions permission = rootObject.GetPermissions();
            bool isRootReadOnly = permission == null ? false : permission.IsReadOnlyForEdit;

            bool isControlReadOnly = rootObject.IsReadOnly(idfsOrganizationPropertyName) || isRootReadOnly;
            ViewBag.IsSearchButtonReadOnly = isControlReadOnly;

            object organization = rootObject.GetValue(idfsOrganizationPropertyName);
            Int64 organizationId = 0;
            if (organization != null)
            {
                Int64.TryParse(organization.ToString(), out organizationId);
            }
            ViewBag.IsClianButtonReadOnly = isControlReadOnly || organizationId == 0;
        }
    }
}
