using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using bv.model.BLToolkit.RemoteProvider.Client;

namespace BLToolkit.Data.DataProvider
{
    public class RemoteSqlDataProvider : DataProviderBase
    {
        public override Type ConnectionType
        {
            get { return typeof(RemoteSqlConnection); }
        }

        public override string Name
        {
            get { return "RemoteSql"; }
        }

        public override IDbConnection CreateConnectionObject()
        {
            return new RemoteSqlConnection();
        }

        public override bool DeriveParameters(IDbCommand command)
        {
            if (command is RemoteSqlCommand)
            {
                ((RemoteSqlCommand)command).DeriveParameters();
                return true;
            }

            return false;
        }

        public override DbDataAdapter CreateDataAdapterObject()
        {
            return new RemoteSqlDataAdapter();
        }

        public override object Convert(object value, ConvertType convertType)
        {
            switch (convertType)
            {
                case ConvertType.NameToQueryParameter:
                case ConvertType.NameToCommandParameter:
                case ConvertType.NameToSprocParameter:
                    return "@" + value;

                case ConvertType.NameToQueryField:
                case ConvertType.NameToQueryFieldAlias:
                case ConvertType.NameToQueryTableAlias:
                    {
                        string name = value.ToString();

                        if (name.Length > 0 && name[0] == '[')
                            return value;
                    }

                    return "[" + value + "]";

                case ConvertType.NameToDatabase:
                case ConvertType.NameToOwner:
                case ConvertType.NameToQueryTable:
                    {
                        string name = value.ToString();

                        if (name.Length > 0 && name[0] == '[')
                            return value;

                        if (name.IndexOf('.') > 0)
                            value = string.Join("].[", name.Split('.'));
                    }

                    return "[" + value + "]";

                case ConvertType.SprocParameterToName:
                    if (value != null)
                    {
                        string str = value.ToString();
                        return str.Length > 0 && str[0] == '@' ? str.Substring(1) : str;
                    }
                    break;

                case ConvertType.ExceptionToErrorNumber:
                    if (value is SqlException)
                        return ((SqlException)value).Number;
                    break;
            }

            return value;
        }

        public override void PrepareCommand(ref CommandType commandType, ref string commandText, ref IDbDataParameter[] commandParameters)
        {
            base.PrepareCommand(ref commandType, ref commandText, ref commandParameters);

            if (commandParameters == null)
                return;

            foreach (IDbDataParameter p in commandParameters)
            {
                object val = p.Value;

                if (val == null || !val.GetType().IsArray || val is byte[] || val is char[])
                    continue;

                DataTable dt = new DataTable();

                dt.Columns.Add("column_value", val.GetType().GetElementType());

                dt.BeginLoadData();

                foreach (object o in (Array)val)
                {
                    DataRow row = dt.NewRow();
                    row[0] = o;
                    dt.Rows.Add(row);
                }

                dt.EndLoadData();

                p.Value = dt;
            }
        }

    }

}
