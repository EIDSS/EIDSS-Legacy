using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using SharpMap.Geometries;
using eidss.gis.Properties;

namespace eidss.gis.Data
{
    public static class TableCreator
    {
        //deprecated!!!
        public static void CreateOtherWkbTable(string connStr, SqlTransaction trans, string tableName, List<DataColumn> additionalFields)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                //get fields - WKB+Additional fields
                List<DataColumn> columns = GetWkbReqFields();
                columns.AddRange(additionalFields);

                //create table
                CreateSqlServerTable(conn, tableName, columns);

                //add index on Envelope
                CreateWkbIndexes(conn, tableName);

                //add default value for rowguid
                AddRowguidDefValue(conn, tableName);

                //add pkey
                CreatePrimaryIndex(conn, tableName, WkbfieldsIdfsGeoObject);

                //add fkey !!!
                //AddForeignKey(conn, tableName, "idfsGeoObject", "gisOtherBaseReference");

                conn.Close();
            }

        }

        public static void CreateGeomTable(SqlConnection conn, string tableName, List<DataColumn> additionalFields, string schemaName = "dbo")
        {
           //get fields - Geom+Additional fields
           List<DataColumn> columns = GetGeomTableReqFields();
           columns.AddRange(additionalFields);

           //create table
           CreateSqlServerTable(conn, tableName, columns, schemaName);
                
           //add pkey
           CreatePrimaryIndex(conn, tableName, GeomfieldsIdfsGeoObject, schemaName);

           //create index for geomShape
        }

        //private static void CreateAutoincrement(SqlConnection conn, string tableName, string geomfieldsIdfsGeoObject)
        //{
        //    Server srv = new Server(new ServerConnection(conn));
        //    Database db = srv.Databases[conn.Database];
        //    Table tbl = db.Tables[tableName];

        //    // Add primary key index to the table
        //    tbl.Columns[geomfieldsIdfsGeoObject].Identity = true;
        //    tbl.Columns[geomfieldsIdfsGeoObject].IdentitySeed = 1;
        //    tbl.Columns[geomfieldsIdfsGeoObject].IdentityIncrement = 1;
        //    tbl.Columns[geomfieldsIdfsGeoObject].Alter();
        //    tbl.Alter();
        //}

        public static void DropTable(SqlConnection conn, string tableName, string schemaName = "dbo")
        {
            var srv = new Server(new ServerConnection(conn.ConnectionString));
            var db = srv.Databases[conn.Database];
            db.Tables[tableName, schemaName].Drop();
        }

        /// <summary>
        /// Check existence table with table
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static bool CheckTableExistsing(string connString, string tableName, string schemaName = "dbo")
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = string.Format(
                    "select count(*) from dbo.sysobjects where id = object_id(N'[{1}].{0}')", tableName, schemaName);

                var count = (int)SqlExecHelper.SqlExecScalar(conn, query);
                conn.Close();
                return count != 0;
            }


        }

        /// <summary>
        /// Create physical table in DB
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tableName"></param>
        /// <param name="tableColumns"></param>
        public static void CreateSqlServerTable(SqlConnection conn, string tableName, List<DataColumn> tableColumns, string tableSchema = "dbo")
        {
            Server srv = new Server(new ServerConnection(conn));
            
            Database db = srv.Databases[conn.Database];
            Table tbl = new Table(db, tableName, tableSchema);
            foreach (DataColumn column in tableColumns)
            {
                Column newColumn = new Column(tbl, column.ColumnName);
                newColumn.Nullable = column.AllowDBNull;
                newColumn.DataType = SystemType2SmoType(column.DataType);
                newColumn.Identity = column.AutoIncrement;
                newColumn.IdentitySeed = column.AutoIncrementSeed;
                newColumn.IdentityIncrement = column.AutoIncrementStep;
                if (column.DefaultValue != null && !string.IsNullOrEmpty(column.DefaultValue.ToString()))
                    newColumn.AddDefaultConstraint().Text = column.DefaultValue.ToString();
                tbl.Columns.Add(newColumn);
            }
            tbl.Create();
        }

        /// <summary>
        /// Add fields to existed table in db
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tableName"></param>
        /// <param name="tableColumns"></param>
        public static void AddFieldsToTable(SqlConnection conn, string tableName, List<DataColumn> tableColumns, string schemaName = "dbo")
        {
            Server srv = new Server(new ServerConnection(new SqlConnection((conn.ConnectionString))));
            Database db = srv.Databases[conn.Database];
            Table tbl = db.Tables[tableName, schemaName];

            foreach (DataColumn column in tableColumns)
            {
                Column newColumn = new Column(tbl, column.ColumnName);
                newColumn.Nullable = column.AllowDBNull;
                newColumn.DataType = SystemType2SmoType(column.DataType);
                tbl.Columns.Add(newColumn);
            }
            tbl.Alter();
        }


        /// <summary>
        /// Drop fields from existed table in db
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tableName"></param>
        /// <param name="tableColumns"></param>
        public static void DropFieldsFromTable(SqlConnection conn, string tableName, List<DataColumn> tableColumns, string schemaName = "dbo")
        {

            List<string> strList = new List<string>();
            foreach (DataColumn column in tableColumns)
            {
                strList.Add(column.ColumnName);
            }

            DropFieldsFromTable(conn, tableName, strList, schemaName);
        }


        /// <summary>
        /// Drop fields from existed table in db
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tableName"></param>
        /// <param name="tableColumnNames"></param>
        public static void DropFieldsFromTable(SqlConnection conn, string tableName, List<string> tableColumnNames, string schemaName = "dbo")
        {
            Server srv = new Server(new ServerConnection(new SqlConnection((conn.ConnectionString))));
            Database db = srv.Databases[conn.Database];
            Table tbl = db.Tables[tableName, schemaName];

            foreach (string columnNames in tableColumnNames)
            {
                tbl.Columns[columnNames].Drop();
            }
            tbl.Alter();
        }



        /// <summary>
        /// Create indexes for WKB table DEPRECATED!!!!!
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tableName"></param>
        public static void CreateWkbIndexes(SqlConnection conn, string tableName)
        {
            Server srv = new Server(new ServerConnection(new SqlConnection((conn.ConnectionString))));
            Database db = srv.Databases[conn.Database];
            Table tbl = db.Tables[tableName];

            var envelopeFields = new[] { WkbfieldsDblEnvelopeMinX, WkbfieldsDblEnvelopeMinY, WkbfieldsDblEnvelopeMaxX, WkbfieldsDblEnvelopeMaxY };

            foreach (string envelopeField in envelopeFields)
            {
                Index idx = new Index(tbl, "IDX_" + envelopeField);
                IndexedColumn indCol = new IndexedColumn(idx, envelopeField);
                idx.IndexedColumns.Add(indCol);
                idx.IndexKeyType = IndexKeyType.None;
                idx.IsClustered = false;
                idx.FillFactor = 50;
                idx.Create();
                idx.Alter();
            }
        }

        /// <summary>
        /// Create primary index
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tableName"></param>
        /// <param name="primColumn"> </param>
        public static void CreatePrimaryIndex(SqlConnection conn, string tableName, string primColumn, string schemaName = "dbo")
        {
            Server srv = new Server(new ServerConnection(conn));
            Database db = srv.Databases[conn.Database];
            Table tbl = db.Tables[tableName, schemaName];

            // Add primary key index to the table
            Index primaryKeyIndex = new Index(tbl, "XPK" + tableName);
            primaryKeyIndex.IndexKeyType = IndexKeyType.DriPrimaryKey;
            primaryKeyIndex.IndexedColumns.Add(new IndexedColumn(primaryKeyIndex, primColumn));
            tbl.Indexes.Add(primaryKeyIndex);
            tbl.Alter();
        }

        /// <summary>
        /// Add ForeignKey to table
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tableName"></param>
        /// <param name="keyField"> </param>
        /// <param name="masterTable"> </param>
        public static void AddForeignKey(SqlConnection conn, string tableName, string keyField, string masterTable, string schemaName = "dbo", string masterSchemaName = "dbo")
        {
            Server srv = new Server(new ServerConnection(new SqlConnection((conn.ConnectionString))));
            Database db = srv.Databases[conn.Database];
            Table tbl = db.Tables[tableName, schemaName];

            ForeignKey fk = new ForeignKey(tbl, string.Format("FK_{0}_{1}", tableName, masterTable));
            fk.ReferencedTable = masterTable;
            fk.ReferencedTableSchema = masterSchemaName;
            new ForeignKeyColumn();
            fk.Columns.Add(new ForeignKeyColumn(fk, keyField, keyField));
            fk.Create();
        }



        /// <summary>
        /// Create indexes for WKB table
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="tableName"></param>
        public static void AddRowguidDefValue(SqlConnection conn, string tableName, string schemaName = "dbo")
        {
            Server srv = new Server(new ServerConnection(new SqlConnection((conn.ConnectionString))));
            Database db = srv.Databases[conn.Database];
            Table tbl = db.Tables[tableName, schemaName];

            Column column = tbl.Columns[WkbfieldsRowguid];
            column.AddDefaultConstraint();
            column.DefaultConstraint.Text = "NEWID()";
            column.Alter();
        }



        /// <summary>
        /// Requerement fields for any WKB table
        /// </summary>
        /// <returns></returns>
        public static List<DataColumn> GetWkbReqFields()
        {
            List<DataColumn> reqFeelds = new List<DataColumn>(8); //turbo speed :)
            reqFeelds.Add(new DataColumn(WkbfieldsIdfsGeoObject, typeof(long)));
            reqFeelds[0].AllowDBNull = false;
            reqFeelds.Add(new DataColumn(WkbfieldsBlbWkbGeometry, typeof(byte[])));
            reqFeelds.Add(new DataColumn(WkbfieldsDblEnvelopeMinX, typeof(float)));
            reqFeelds.Add(new DataColumn(WkbfieldsDblEnvelopeMinY, typeof(float)));
            reqFeelds.Add(new DataColumn(WkbfieldsDblEnvelopeMaxX, typeof(float)));
            reqFeelds.Add(new DataColumn(WkbfieldsDblEnvelopeMaxY, typeof(float)));
            reqFeelds.Add(new DataColumn(WkbfieldsRowguid, typeof(Guid)));
            reqFeelds.Add(new DataColumn(WkbfieldsStrCode, typeof(string)));
            return reqFeelds;
        }


        // --- WKB FIELDS NAME CONSTS 
        public const string WkbfieldsIdfsGeoObject = "idfsGeoObject";
        public const string WkbfieldsBlbWkbGeometry = "blbWKBGeometry";
        public const string WkbfieldsDblEnvelopeMinX = "dblEnvelopeMinX";
        public const string WkbfieldsDblEnvelopeMinY = "dblEnvelopeMinY";
        public const string WkbfieldsDblEnvelopeMaxX = "dblEnvelopeMaxX";
        public const string WkbfieldsDblEnvelopeMaxY = "dblEnvelopeMaxY";
        public const string WkbfieldsRowguid = "rowguid";
        public const string WkbfieldsStrCode = "strCode";

        // --- GeomProvider FIELDS NAME CONSTS
        public const string GeomfieldsIdfsGeoObject = "idfsGeoObject";
        public const string GeomfieldsGeomShape = "geomShape";

        /// <summary>
        /// Requerement fields for any WKB table
        /// </summary>
        /// <returns></returns>
        public static List<DataColumn> GetGeomTableReqFields()
        {
            List<DataColumn> reqFeelds = new List<DataColumn>(8); //turbo speed :)
            reqFeelds.Add(new DataColumn(GeomfieldsIdfsGeoObject, typeof(long)));
            reqFeelds[0].AllowDBNull = false;
            reqFeelds[0].AutoIncrement = true;
            reqFeelds[0].AutoIncrementSeed = 1;
            reqFeelds[0].AutoIncrementStep = 1;
            reqFeelds.Add(new DataColumn(GeomfieldsGeomShape, typeof(Geometry)));
            return reqFeelds;
        }





        /// <summary>
        /// Returns the name of the SqlServer datatype based on a .NET datatype
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static SqlDbType SystemType2SqlType(Type t)
        {
            switch (t.ToString())
            {
                case "System.Guid": return SqlDbType.UniqueIdentifier;
                case "System.Boolean": return SqlDbType.Bit;
                case "System.Single": return SqlDbType.Real;
                case "System.Double": return SqlDbType.Float;
                case "System.Int16": return SqlDbType.SmallInt;
                case "System.Int32": return SqlDbType.Int;
                case "System.Int64": return SqlDbType.BigInt;
                case "System.DateTime": return SqlDbType.DateTime;
                case "System.Byte[]": return SqlDbType.Image;
                case "System.String": return SqlDbType.NVarChar;// VarChar;
                default:
                    throw (new NotSupportedException(Resources.gis_TableCreator_SysToSqlType1 + t.Name + Resources.gis_TableCreator_SysToSqlType2));
            }
        }

        /// <summary>
        /// Returns the name of the SMO SqlServer datatype based on a .NET datatype
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static DataType SystemType2SmoType(Type t)
        {
            switch (t.ToString())
            {
                case "System.Guid": return DataType.UniqueIdentifier;
                case "System.Boolean": return DataType.Bit;
                case "System.Single": return DataType.Real;
                case "System.Double": return DataType.Float;
                case "System.Int16": return DataType.SmallInt;
                case "System.Int32": return DataType.Int;
                case "System.Int64": return DataType.BigInt;
                case "System.DateTime": return DataType.DateTime;
                case "System.Byte[]": return DataType.Image;
                case "System.String": return DataType.NVarCharMax;
                case "SharpMap.Geometries.Geometry": return DataType.Geometry;
                default:
                    throw (new NotSupportedException(Resources.gis_TableCreator_SysToSqlType1 + t.Name + Resources.gis_TableCreator_SysToSqlType2));
            }
        }
    }
}

