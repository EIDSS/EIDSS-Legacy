using System;
using System.Data;
using eidss.gis.Data.Providers;
using eidss.gis.Utils;
using SharpMap.Data.Providers;

namespace eidss.gis.Layers
{
    /// <summary>
    /// Its not use now!!!! Now one row in gisOtherNameTranslation table
    /// </summary>
    public class EidssExtSystemLabelLayer:EidssLabelLayer
    {
        /// <summary>
        /// Dataset for related string names translation
        /// </summary>
        private DataTable m_TranslationDataTable;



        public EidssExtSystemLabelLayer(string layername)
                : base(layername)
            {
                LabelStringDelegate = GetLocalizedLabelMethod;
            }

        public EidssExtSystemLabelLayer(string layername, Guid initGuid)
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
                //TODO: Replace with other GetTranslationMethod!!!!
                m_TranslationDataTable = TranslationCache.GetTranslation(cs, refType, bv.model.Model.Core.ModelUserContext.CurrentLanguage);
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
            else
            {
                string idfsGeoObject = fdr["idfsGeoObject"].ToString();
                return idfsGeoObject;
            }

        }
    }
}
