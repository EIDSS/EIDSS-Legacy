using System;
using System.Data;
using eidss.gis.Data.Providers;
using eidss.gis.Utils;
using eidss.model.Core;
using SharpMap.Data.Providers;

namespace eidss.gis.Layers
{
    public class EidssSystemLabelLayer:EidssLabelLayer
    {
        /// <summary>
        /// Dataset for related string names translation
        /// </summary>
        private DataTable m_TranslationDataTable;



        public EidssSystemLabelLayer(string layername)
                : base(layername)
            {
                LabelStringDelegate = GetLocalizedLabelMethod;
            }

        public EidssSystemLabelLayer(string layername, Guid initGuid)
                : base(layername, initGuid)
        {
            LabelStringDelegate = GetLocalizedLabelMethod;
        }


        override public IProvider DataSource
        {
            get { return base.DataSource; }
            set
            {
                if (value == null)
                    return;

                base.DataSource = value;
                
                //load translation table
                var tableName = ((EidssSqlServer2008) DataSource).Table;
                var cs = ((EidssSqlServer2008)DataSource).ConnectionString;

                var refType = (long)SystemLayerNames.ToGisDbType(tableName);
                m_TranslationDataTable = TranslationCache.GetTranslation(cs, refType, EidssUserContext.CurrentLanguage);
            }
        }

        
        

        string GetLocalizedLabelMethod(SharpMap.Data.FeatureDataRow fdr)
        {
            if (m_TranslationDataTable.Rows.Count != 0)
            {
                DataRow foundRow =
                    m_TranslationDataTable.Rows.Find(fdr["idfsGeoObject"]);

                if (foundRow != null)
                    return foundRow["Name"].ToString();
                else
                    return string.Empty;
            }
            var idfsGeoObject = fdr["idfsGeoObject"].ToString();
            return idfsGeoObject;
        }
    }
}
