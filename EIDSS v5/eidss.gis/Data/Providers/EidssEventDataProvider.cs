using System.Data;
using bv.common.db.Core;
using GIS_V4.Data.Providers;

namespace eidss.gis.Data.Providers
{
    class EidssEventDataProvider:EventDataProvider
    {
        private static readonly string m_ConnectionString = ConnectionManager.DefaultInstance.ConnectionString;
        private const string m_GeomFieldName = "geomShape";
        private const string m_OidFieldName = "idfsGeoObject";

                
        public EidssEventDataProvider(string tableName)
            :base(m_ConnectionString, tableName, m_GeomFieldName, m_OidFieldName)
        {
            SRID = 3857;
        }

        public EidssEventDataProvider(string tableName, DataTable eventTable)
            : base(m_ConnectionString, tableName, m_GeomFieldName, m_OidFieldName, eventTable)
        {
            SRID = 3857;
        }
    }
}
