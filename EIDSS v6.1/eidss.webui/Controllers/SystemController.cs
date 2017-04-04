using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bv.model.Model.Core;
using eidss.webui.Utils;

namespace eidss.webui.Controllers
{
    public class SystemController : Controller
    {
        private ValidationEventArgs m_validation = null;

        [HttpPost]
        public ActionResult Heartbeat(long id)
        {
            ModelStorage.Get(Session.SessionID, id);
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = null };
        }

        public ActionResult DeleteObject(string accessor, long id)
        {
            bool isSuccess = false;
            //ModelStorage.Get(Session.SessionID, id);
            string typename = accessor.Replace(".BLToolkitExtension.Accessor", ", eidss.model, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null");
            Type typeacc = Type.GetType(typename);
            //typeacc = typeof(eidss.model.Schema.HumanCaseListItem);
            if (typeacc != null)
            {
                IObjectMeta meta = ObjectAccessor.MetaInterface(typeacc);
                if (meta != null)
                {
                    var action = meta.Actions.Where(c => c.Name == "Delete").SingleOrDefault();
                    if (action != null)
                        isSuccess = action.RunActionFunction(null, null, new List<object> { id });
                }
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = isSuccess };
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult SetValue(string key, string value)
        {
            CompareModel data = null;
            string[] keyparts = key.Split('_');
            if (keyparts.Length == 3)
            {
                IObject obj = ModelStorage.Get(Session.SessionID, long.Parse(keyparts[1])) as IObject;
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
                            data.Add(name, key, type, valstr, obj.IsReadOnly(name));
                            data.Add("ErrorMessage", "ErrorMessage", "ErrorMessage",
                                     m_validation.MessageId + ": " + m_validation.PropertyName, false);
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
