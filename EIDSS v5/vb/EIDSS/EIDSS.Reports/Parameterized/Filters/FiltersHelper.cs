using System;
using System.Data;
using System.Data.SqlClient;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.OperationContext;
using bv.common.Core;
using bv.model.BLToolkit;

namespace EIDSS.Reports.Parameterized.Filters
{
    public static class FiltersHelper
    {
        public static void SetDefaultFiltes(DbManagerProxy manager, IContextKeeper context, RegionFilter regionFilter, RayonFilter rayonFilter)
        {
            if (context.ContainsContext(ContextValue.ReportFilterResetting))
                return;

            using (context.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                using (var adapter = new SqlDataAdapter())
                {
                    SqlCommand command = ((SqlConnection)manager.Connection).CreateCommand();
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
                            regionFilter.RegionId = (long)dataRow["idfsRegion"];
                        }
                        if (!(dataRow["idfsRayon"] is DBNull) && rayonFilter.RayonId < 0)
                        {
                            rayonFilter.RayonId = (long)dataRow["idfsRayon"];
                        }
                    }
                }
            }
        }

        public static void RegionFilterValueChanged(BaseReportKeeper keeper, RegionFilter regionFilter,
                                                    RayonFilter rayonFilter, SingleFilterEventArgs e)
        {
            long oldRayon = rayonFilter.RayonId;
            if ((regionFilter.RegionId == -1) || (regionFilter.RegionId != rayonFilter.RegionId))
            {
                rayonFilter.RayonId = -1;
            }
            rayonFilter.RegionId = regionFilter.RegionId;

            if ((oldRayon != rayonFilter.RayonId) || (rayonFilter.RayonId == -1))
            {
                keeper.ReloadReportIfFormLoaded(regionFilter);
            }
        }

        public static void RayonFilterValueChanged(BaseReportKeeper keeper, RegionFilter regionFilter,
                                                   RayonFilter rayonFilter, SingleFilterEventArgs e)
        {
            rayonFilter.RegionId = rayonFilter.RegionId;
            if ((rayonFilter.RegionId != -1) && (regionFilter.RegionId != rayonFilter.RegionId))
            {
                regionFilter.RegionId = rayonFilter.RegionId;
            }

            keeper.ReloadReportIfFormLoaded(rayonFilter);
        }
    }
}