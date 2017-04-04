using System;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using eidss.model.Schema;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using bv.model.Model.Core;

namespace eidss.webclient.Controllers
{
    [AuthorizeEIDSS]
    public class OrganizationController : BvController
    {
        public ActionResult InlineOrganizationPicker(IObject obj, long objectId, string idfsOrganizationPropertyName, string strOrganizationPropertyName,
            bool showInInternalWindow = false, string idfsEmployeePropertyName = "", string strEmployeePropertyName = "", int HACode = 0)
        {
            ViewBag.IdfsOrganizationPropertyName = idfsOrganizationPropertyName;
            ViewBag.StrOrganizationPropertyName = strOrganizationPropertyName;
            ViewBag.ShowInInternalWindow = showInInternalWindow;
            ViewBag.MainDivId = string.Format("divOrgSearchPicker_{0}_{1}", objectId, idfsOrganizationPropertyName);
            ViewBag.BtnSearchPicker = string.Format("btnOrgSearchPicker_{0}_{1}", objectId, idfsOrganizationPropertyName);
            ViewBag.BtnClianPicker = string.Format("btnOrgClian_{0}_{1}", objectId, idfsOrganizationPropertyName);

            SetButtonsReadOnlyInViewBag(objectId, idfsOrganizationPropertyName);

            string onSelectItemClick = string.Format("organization.showSearchPicker(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\")",
                objectId, idfsOrganizationPropertyName, strOrganizationPropertyName, idfsEmployeePropertyName, strEmployeePropertyName, showInInternalWindow, HACode);

            ViewBag.OnSelectItemClick = onSelectItemClick;

            string onClianButtonClick = string.Format("organization.onPickerValueChanged(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"\", \"{5}\")",
                objectId, idfsOrganizationPropertyName, strOrganizationPropertyName, idfsEmployeePropertyName, strEmployeePropertyName, showInInternalWindow);

            ViewBag.OnClianButtonClick = onClianButtonClick;

            return PartialView(obj);
        }

        private void SetButtonsReadOnlyInViewBag(long objectId, string idfsOrganizationPropertyName)
        {
            //var rootObject = (IObject)ModelStorage.Get(ModelUserContext.ClientID, objectId, null);
            ObjectStorage.Using<IObject, bool>(rootObject =>
                {
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
                    return false;
                }, ModelUserContext.ClientID, objectId, null);
        }

        [CompressFilter]
        public ActionResult IndexAjax([DataSourceRequest]DataSourceRequest request, FormCollection form)
        {
            return IndexInternalAjax<OrganizationListItem.Accessor, OrganizationListItem, OrganizationListItem.OrganizationListItemGridModelList>
                (form, OrganizationListItem.Accessor.Instance(null), AutoGridRoots.OrganizationSelectList, request);
        }
    }
}
