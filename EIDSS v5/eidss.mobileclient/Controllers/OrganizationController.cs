using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.mobileclient.Attributes;
using eidss.mobileclient.Utils;
using eidss.model.Core;
using eidss.model.Schema;

namespace eidss.mobileclient.Controllers
{
    [Authorize]
    public class OrganizationController : Controller
    {
        public ActionResult InlineOrganizationPicker(IObject obj, long objectId, string idfsOrganizationPropertyName,
            string strOrganizationPropertyName, string returnUrl, string currentControllerName)
        {
            ViewBag.ObjectId = objectId;
            ViewBag.IdfsOrganizationPropertyName = idfsOrganizationPropertyName;
            ViewBag.StrOrganizationPropertyName = strOrganizationPropertyName;
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.CurrentControllerName = currentControllerName;

            ViewBag.MainDivId = string.Format("divOrgSearchPicker_{0}_{1}", objectId, idfsOrganizationPropertyName);
            ViewBag.BtnSearchPicker = string.Format("btnOrgSearchPicker_{0}_{1}", objectId, idfsOrganizationPropertyName);
            ViewBag.BtnClianPicker = string.Format("btnOrgClian_{0}_{1}", objectId, idfsOrganizationPropertyName);

            SetButtonsReadOnlyInViewBag(objectId, idfsOrganizationPropertyName, strOrganizationPropertyName);
            
            return PartialView(obj);
        }

        private void SetButtonsReadOnlyInViewBag(long objectId, string idfsOrganizationPropertyName, string strOrganizationPropertyName)
        {
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, objectId, null);

            IObjectPermissions permission = rootObject.GetPermissions();
            bool isRootReadOnly = permission == null ? false : permission.IsReadOnlyForEdit;
            bool isControlReadOnly = rootObject.IsReadOnly(idfsOrganizationPropertyName) ||
                                     rootObject.IsHiddenPersonalData(strOrganizationPropertyName) || isRootReadOnly;

            ViewBag.IsSearchButtonReadOnly = isControlReadOnly;

            object organization = rootObject.GetValue(idfsOrganizationPropertyName);
            Int64 organizationId = 0;
            if (organization != null)
            {
                Int64.TryParse(organization.ToString(), out organizationId);
            }
            ViewBag.IsClianButtonReadOnly = isControlReadOnly || organizationId == 0;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [SessionExpireFilter]
        public ActionResult ClianOrganizationPicker(string objectId, string idfsOrganizationPropertyName, string strOrganizationPropertyName)
        {
            long key = long.Parse(objectId);
            var rootObject = (IObject)ModelStorage.Get(Session.SessionID, key, null);
            CompareModel data;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
            {
                IObject cloneObject = rootObject.CloneWithSetup(manager);
                rootObject.SetValue(idfsOrganizationPropertyName, null);
                string organizationName = string.Empty;
                rootObject.SetValue(strOrganizationPropertyName, organizationName);
                data = rootObject.Compare(cloneObject);
            }
            return new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        
        [HttpGet]
        [SessionExpireFilter]
        public ActionResult Facility(long rootId, string idfsOrganizationPropertyName, string strOrganizationPropertyName, string returnUrl)
        {
            //TODO: save data in previous form
            Session["RootId"] = rootId;
            Session["IdfsOrganizationPropertyName"] = idfsOrganizationPropertyName;
            Session["StrOrganizationPropertyName"] = strOrganizationPropertyName;
            Session["ReturnUrl"] = returnUrl;
            
            return View();
        }

        [HttpPost]
        [SessionExpireFilter]
        public ActionResult Facility(FormCollection form)
        {
            string textForSearch = form["tbSearch"];
            ViewBag.TextForSearch = textForSearch;
            List<OrganizationListItem> organizations = GetOrganizationsList(textForSearch);
            ViewBag.ItemsCount = organizations == null ? 0 : organizations.Count;
            List<OrganizationListItem> resultList = organizations == null ? organizations : organizations.Take(100).ToList();
            return View(resultList);
        }

        [HttpGet]
        [SessionExpireFilter]
        public ActionResult SetFacility(long organizationId)
        {
            SetOrganizationInRootObject(organizationId);
            string returnUrl = Session["ReturnUrl"].ToString();
            string language = Cultures.GetSiteLanguage(Request);
            string url = "/" + language + returnUrl;
            CleanSession();
            return Redirect(url);
        }

        private void SetOrganizationInRootObject(long organizationId)
        {
            var rootId = (Int64)Session["RootId"];
            var root = (IObject)ModelStorage.Get(Session.SessionID, rootId, null);
            string idfsOrganizationPropertyName = Session["IdfsOrganizationPropertyName"].ToString();
            root.SetValue(idfsOrganizationPropertyName, organizationId.ToString());
            string strOrganizationPropertyName = Session["StrOrganizationPropertyName"].ToString();
            List<OrganizationListItem> organizations = GetOrganizationsList();
            string organizationName = organizations.Where(x => x.idfInstitution == organizationId).FirstOrDefault().name;
            root.SetValue(strOrganizationPropertyName, organizationName);
        }

        private List<OrganizationListItem> GetOrganizationsList()
        {
            var accessor = OrganizationListItem.Accessor.Instance(null);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<OrganizationListItem> organizations = accessor.SelectListT(dbmanager);
                return organizations;
            }
        }

        private List<OrganizationListItem> GetOrganizationsList(string textForSearch)
        {
            var accessor = OrganizationListItem.Accessor.Instance(null);
            var filter = new FilterParams();
            string searchPattern = GetSearchPattern(textForSearch);
            filter.Add("name", "LIKE", searchPattern);
            using (var dbmanager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                List<OrganizationListItem> organizations = accessor.SelectListT(dbmanager, filter);
                return organizations;
            }
        }

        private string GetSearchPattern(string textForSearch)
        {
            var searchPattern = new StringBuilder();
            searchPattern.Append(textForSearch.Replace('*', '%'));
            if(!searchPattern.ToString().EndsWith("%"))
            {
                searchPattern.Append("%");
            }
            return searchPattern.ToString();
        }

        private void CleanSession()
        {
            Session.Remove("RootId");
            Session.Remove("IdfsOrganizationPropertyName");
            Session.Remove("StrOrganizationPropertyName");
            Session.Remove("ReturnUrl");
        }
    }
}
