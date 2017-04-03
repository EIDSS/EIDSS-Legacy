using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bv.model.Model.Core;
using BLToolkit.EditableObjects;
using eidss.web.common.Utils;

namespace eidss.webclient.Utils
{
    public class SessionRefreshHelper
    {
        public static void RefreshObjectChildren(string sessionId, IObject obj, Dictionary<string, EditableArrayList> children)
        {
            foreach (var key in children.Keys)
            {
                ModelStorage.Put(
                    sessionId, 
                    (long)obj.Key, 
                    (long)obj.Key, 
                    key, 
                    children[key]);
            }
        }
    }
}