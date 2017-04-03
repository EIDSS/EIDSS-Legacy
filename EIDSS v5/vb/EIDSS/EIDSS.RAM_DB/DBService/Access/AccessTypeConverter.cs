using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using bv.common.Core;

namespace EIDSS.RAM_DB.DBService.Access
{
    public static class AccessTypeConverter
    {
        private const int MaxNameSize = 64;
        private static readonly Dictionary<string, OleDbType> m_Types;

        static AccessTypeConverter()
        {
            m_Types = new Dictionary<string, OleDbType>
                          {
                              {"VARCHAR", OleDbType.VarWChar},
                              {"DATETIME", OleDbType.Date},
                              {"BIT", OleDbType.Boolean},
                              {"LONG", OleDbType.Integer},
                              {"DOUBLE", OleDbType.Double}
                          };
        }

        public static string CovertName(string oldName)
        {
            string newName = Regex.Replace(oldName, "[^\\p{L}0-9]", "_");
            newName = newName.Substring(0, Math.Min(MaxNameSize, newName.Length));
            return newName;
        }

        internal static string ConvertTypeToDbName(DataColumn column)
        {
            Utils.CheckNotNull(column, "column");

            string dataTypeName = "VARCHAR";
            if (column.DataType == typeof (DateTime))
            {
                dataTypeName = "DATETIME";
            }
            if (column.DataType == typeof (bool))
            {
                dataTypeName = "BIT";
            }
            else if (column.DataType == typeof (int) ||
                     column.DataType == typeof (uint) ||
                     column.DataType == typeof (byte) ||
                     column.DataType == typeof (sbyte) ||
                     column.DataType == typeof (short) ||
                     column.DataType == typeof (ushort))
            {
                dataTypeName = "LONG";
            }
            else if (column.DataType == typeof (double) ||
                     column.DataType == typeof (float) ||
                     column.DataType == typeof (long) ||
                     column.DataType == typeof (ulong))
            {
                dataTypeName = "DOUBLE";
            }
            return dataTypeName;
        }

        internal static OleDbType ConverTypeToDb(DataColumn column)
        {
            string dbName = ConvertTypeToDbName(column);
            return m_Types[dbName];
        }
    }
}