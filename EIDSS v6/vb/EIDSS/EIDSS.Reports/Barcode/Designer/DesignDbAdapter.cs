using System;
using System.Data;
using System.Data.SqlClient;
using bv.common;
using bv.model.BLToolkit;
using bv.model.Model.Core;

namespace EIDSS.Reports.Barcode.Designer
{
    public class DesignDbAdapter
    {
        private readonly long m_NumberingObjectIndex;

        public DesignDbAdapter(long numberingObjectIndex)
        {
            m_NumberingObjectIndex = numberingObjectIndex;
        }

        public string GetBarcodeLayout()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                string result = string.Empty;
                using (var adapter = new SqlDataAdapter())
                {
                    SqlCommand command = GetCommand("spRepGetBarcodeLayout", (SqlConnection) manager.Connection);
                    adapter.SelectCommand = command;
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    DataTable dataTable = dataSet.Tables[0];
                    if (dataTable.Rows.Count > 0)
                    {
                        object objLayout = dataTable.Rows[0]["strBarcodeLayout"];
                        if (!(objLayout is DBNull))
                        {
                            result = objLayout.ToString();
                        }
                    }
                }

                return string.IsNullOrEmpty(result)
                           ? string.Empty
                           : Cryptor.Decrypt(result);
            }
        }

        public void DeleteBarcodeLayout()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                SqlCommand command = GetCommand("spRepDeleteBarcodeLayout", (SqlConnection) manager.Connection);
                command.ExecuteNonQuery();
            }
        }

        public void SaveBarcodeLayout(string layout)
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                SqlCommand command = GetCommand("spRepPostBarcodeLayout", (SqlConnection) manager.Connection);
                command.Parameters.Add(new SqlParameter("@strBarcodeLayout", Cryptor.Encrypt(layout)));
                command.ExecuteNonQuery();
            }
        }

        private SqlCommand GetCommand(string spName, SqlConnection connection)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = spName;
            command.Parameters.Add(new SqlParameter("@idfsNumberName", m_NumberingObjectIndex));
            return command;
        }
    }
}