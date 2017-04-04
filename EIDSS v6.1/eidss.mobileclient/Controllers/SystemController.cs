using System;
using System.Collections.Generic;
using System.Linq;
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
    public class SystemController : Controller
    {
        private ValidationEventArgs m_validation = null;

        [SessionExpireFilter]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SetValue(string key, string value)
        {
            CompareModel data = null;
            string[] keyparts = key.Split('_');
            if (keyparts.Length == 3)
            {
                IObject obj = ModelStorage.Get(Session.SessionID, long.Parse(keyparts[1]), null) as IObject;
                if (obj != null)
                {
                    string name = keyparts[2];
                    value = value == "null" ? null : value;
                    object oldvalue = obj.GetValue(name);
                    string stroldvalue = oldvalue == null ? null : oldvalue.ToString();
                    if (stroldvalue != value)
                    {
                        ICloneable cloneable = obj as ICloneable;
                        IObject clone = cloneable.Clone() as IObject;
                        obj.Validation += obj_Validation;
                        obj.SetValue(name, value);
                        obj.Validation -= obj_Validation;
                        data = obj.Compare(clone);
                        if (m_validation != null)
                        {
                            object val = obj.GetValue(name);
                            string type = obj.GetType(name);
                            string valstr = val == null ? "" : val.ToString();
                            data.Add(name, key, type, valstr, obj.IsReadOnly(name), obj.IsInvisible(name), obj.IsRequired(name));
                            data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                                string.Format(Translator.GetMessageString(m_validation.MessageId), m_validation.PropertyName),
                                false, false, false);
                        }
                    }
                }
            }
            var json = new JsonResult { Data = data ?? new CompareModel(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return json;
        }

        void obj_Validation(object sender, ValidationEventArgs args)
        {
            m_validation = args;
        } 
    }
}
