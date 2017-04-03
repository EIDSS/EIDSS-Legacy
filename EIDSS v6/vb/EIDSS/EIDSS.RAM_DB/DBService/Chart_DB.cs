using System.Data;
using bv.common.db.Core;
using bv.model.Model.Core;

namespace eidss.avr.db.DBService
{
    public class Chart_DB : BaseAvrDbService
    {
        public Chart_DB()
        {
            ObjectName = @"AsLayout";
        }

        public override DataSet GetDetail(object id)
        {
            //теперь напрямую загрузки из БД нет. 
            /*
            var dataSet = new DataSet();

            if (ConnectionManager.DefaultInstance.Connection.State != ConnectionState.Open)
            {
                ConnectionManager.DefaultInstance.Connection.Open();
            }
            using (var cmd = CreateSPCommand("spAsChartSettingsSelectDetail", ConnectionManager.DefaultInstance.Connection))
            {
                AddAndCheckParam(cmd, "@LangID", ModelUserContext.CurrentLanguage);
                AddAndCheckParam(cmd, "@idfView", id);
                object result = cmd.ExecuteScalar();

                var datatable = new DataTable("ChartSettings");
                var dc = new DataColumn("idfView", typeof (long));
                datatable.Columns.Add(dc);
                datatable.Columns.Add("blbChartLocalSettings", typeof (byte[]));
                datatable.PrimaryKey = new[] {dc};
                datatable.Rows.Add(new[] {id, result});
                dataSet.Tables.Add(datatable);
            }

            AcceptChanges(dataSet);
            return dataSet;
             */
            return base.GetDetail(id);
        }

        public override bool PostDetail(DataSet dataSet, int postType, IDbTransaction transaction = null)
        {
            //теперь напрямую сохранения в БД нет. Сохраняется в составе родительского объекта

            /*
            Utils.CheckNotNull(dataSet, "dataSet");

            DataTableCollection tables = dataSet.Tables;
            if (tables.Count > 0)
            {
                DataTable table = tables[0];
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    using (IDbCommand cmd = CreateSPCommand("spAsChartSettingsPost", transaction))
                    {
                        AddAndCheckParam(cmd, "@LangID", ModelUserContext.CurrentLanguage);
                        AddAndCheckParam(cmd, "@idfView", row["idfView"]);
                        AddAndCheckParam(cmd, "@blbChartLocalSettings", row["blbChartLocalSettings"]);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            */
            return true;
        }
    }
}