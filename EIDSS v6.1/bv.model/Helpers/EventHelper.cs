using System;
using System.Collections.Generic;
using System.Linq;
using BLToolkit.EditableObjects;
using bv.model.Model.Core;
using System.Reflection;

namespace bv.model.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class EventHelper
    {
        // http://stackoverflow.com/questions/91778/how-to-remove-all-event-handlers-from-a-control
        public static void ClearEventInvocations(this object obj, string eventName)
        {
            var fi = obj.GetType().GetEventField(eventName);
            if (fi == null) return;
            fi.SetValue(obj, null);
        }

        public static void ClearModelObjEventInvocations(this object obj)
        {
            obj.ClearEventInvocations("PropertyChanged");
        }

        public static void ClearModelListEventInvocations(this object obj)
        {
            obj.ClearEventInvocations("PropertyChanged");
            obj.ClearEventInvocations("CollectionChanged");
            obj.ClearEventInvocations("ListChanged");
        }

        private static FieldInfo GetEventField(this Type type, string eventName)
        {
            FieldInfo field = null;
            while (type != null)
            {
                /* Find events defined as field */
                field = type.GetField(eventName, BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
                if (field != null && (field.FieldType == typeof(MulticastDelegate) || field.FieldType.IsSubclassOf(typeof(MulticastDelegate))))
                    break;

                /* Find events defined as property { add; remove; } */
                field = type.GetField("EVENT_" + eventName.ToUpper(), BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
                if (field != null)
                    break;
                type = type.BaseType;
            }
            return field;
        }
    }
}

