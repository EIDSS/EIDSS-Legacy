using System;
using System.Data;
using System.Data.SqlClient;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.OperationContext;

namespace EIDSS.Reports.BaseControls.Filters
{
    public static class LocationHelper
    {
        public static void SetDefaultFilters
            (DbManagerProxy manager, IContextKeeper context, RegionFilter regionFilter, RayonFilter rayonFilter)
        {
            if (context.ContainsContext(ContextValue.ReportFilterResetting))
            {
                return;
            }

            using (context.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                using (var adapter = new SqlDataAdapter())
                {
                    SqlCommand command = ((SqlConnection) manager.Connection).CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spRepHumFormN1Location";
                    command.Parameters.Add(new SqlParameter("@LangID", Localizer.lngEn));

                    var filtersDataSet = new DataSet();
                    adapter.SelectCommand = command;
                    adapter.Fill(filtersDataSet);
                    if (filtersDataSet.Tables.Count == 0)
                    {
                        throw new ApplicationException(String.Format("{0} returns no tables.", command.CommandText));
                    }
                    if (filtersDataSet.Tables[0].Rows.Count != 0)
                    {
                        DataRow dataRow = filtersDataSet.Tables[0].Rows[0];
                        if (!(dataRow["idfsRegion"] is DBNull) && regionFilter.RegionId < 0)
                        {
                            regionFilter.RegionId = (long) dataRow["idfsRegion"];
                        }
                        if (!(dataRow["idfsRayon"] is DBNull) && rayonFilter.RayonId < 0)
                        {
                            rayonFilter.RayonId = (long) dataRow["idfsRayon"];
                        }
                    }
                }
            }
        }

        public static void RegionFilterValueChanged(RegionFilter regionFilter, RayonFilter rayonFilter, SingleFilterEventArgs e)
        {
            if ((regionFilter.RegionId == -1) || (regionFilter.RegionId != rayonFilter.RegionId))
            {
                rayonFilter.RayonId = -1;
            }
            rayonFilter.RegionId = regionFilter.RegionId;
        }

        public static void RayonFilterValueChanged(RegionFilter regionFilter, RayonFilter rayonFilter, SingleFilterEventArgs e)
        {
            rayonFilter.RegionId = rayonFilter.RegionId;
            if ((rayonFilter.RegionId != -1) && (regionFilter.RegionId != rayonFilter.RegionId))
            {
                regionFilter.RegionId = rayonFilter.RegionId;
            }
        }
    }
}