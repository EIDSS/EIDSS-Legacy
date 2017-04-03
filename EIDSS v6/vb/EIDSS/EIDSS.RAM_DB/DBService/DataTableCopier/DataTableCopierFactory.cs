using System.Data;
using bv.common.Configuration;
using bv.common.Core;

namespace eidss.avr.db.DBService.DataTableCopier
{
    public static class DataTableCopierFactory
    {
        public static IDataTableCopier CreateDataTableCopier(DataTable sourceTable)
        {
            Utils.CheckNotNull(sourceTable, "sourceTable");

            return BaseSettings.AvrMemoryEconomyMode
                ? (IDataTableCopier) new DataTableCopierSingleThread(sourceTable)
                : new DataTableCopierMultiThread(sourceTable);
        }

        public static IDataTableCopier CreateEmptyDataTableCopier()
        {
            return new DataTableCopierSingleThread(new DataTable());
        }
    }
}