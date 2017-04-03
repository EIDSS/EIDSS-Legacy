using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using eidss.gis.Data;

namespace eidss.gis.Utils
{
    public class KeyValuePairWrapper
    {
        public KeyValuePairWrapper(Guid key, string value)
        {
            Key = key;
            Value = value;
        }

        public Guid Key { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }

        public KeyValuePair<Guid, string> ToKeyValuePair()
        {
            var result = new KeyValuePair<Guid, string>(Key, Value);
            return result;
        }
    }

    public static class ZoneLayerStorage
    {
        static ZoneLayerStorage()
        {
            UserDbLayersManager.UserLayersListChanged += UserDbLayersManager_UserLayersListChanged;
            UpdateZoneLayerDict();
        }

        static void UserDbLayersManager_UserLayersListChanged(object sender, EventArgs e)
        {
            UpdateZoneLayerDict();
        }
        
        private static Collection<KeyValuePairWrapper> m_ZoneLayerDict = new Collection<KeyValuePairWrapper>(); //Dictionary<Guid, string> m_ZoneLayerDict = new Dictionary<Guid, string>();

        public static event EventHandler ZoneLayerDictUpdated;

        public static Collection<KeyValuePairWrapper> ZoneLayerDict
            //public static Dictionary<Guid, string> ZoneLayerDict
        {
            get { return m_ZoneLayerDict; }
        }
        
        public static void UpdateZoneLayerDict()
        {
            m_ZoneLayerDict.Clear();
            var dict = (Dictionary<Guid, string>) UserDbLayersManager.GetLayersNames(UserDbLayerType.BuffZones);
            foreach (var item in dict)
            {
                m_ZoneLayerDict.Add(new KeyValuePairWrapper(item.Key, item.Value));
            }
            //m_ZoneLayerDict =  
            
            if (ZoneLayerDictUpdated!=null)
            {
                ZoneLayerDictUpdated(null, EventArgs.Empty);
            }
        }
    }
}
