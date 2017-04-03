using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using bv.common.db.Core;
using EIDSS.GISControl.Common.Layers;
using EIDSS.GISControl.Common.Data.Providers;
using SharpMap.Data;
using SharpMap.Geometries;

namespace EIDSS.Tests.GIS
{
    public class GISControlTestInfo
    {
        public static DataTable GetCaseEvents_Old()
        {
            VectorLayer vectorLayer = new VectorLayer("stt_case");
            string connection = ConnectionManager.DefaultInstance.ConnectionString;
            vectorLayer.DataSource = new MsSql(connection, "gisWKBSettlement", "blbWKBGeometry",
                                               "idfsGeoObject");
            FeatureDataSet fds = new FeatureDataSet();
            BoundingBox bbox = vectorLayer.Envelope;
            ((SharpMap.Data.Providers.MsSql)vectorLayer.DataSource).ExecuteIntersectionQuery(bbox, fds);

            DataTable events = new DataTable();
            events.Columns.AddRange(new DataColumn[]
                                        {
                                            new DataColumn("x", typeof (double)),
                                            new DataColumn("y", typeof (double)),
                                            new DataColumn("caption", typeof(string)),
                                            new DataColumn("value", typeof (double))
                                        });

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            for (int i = 0; i < fds.Tables[0].Count; i++)
            {
                DataRow newRow = events.NewRow();
                newRow["x"] = fds.Tables[0][i].Geometry.GetBoundingBox().Left;
                newRow["y"] = fds.Tables[0][i].Geometry.GetBoundingBox().Bottom;
                newRow["caption"] = "info";
                newRow["value"] = rnd.Next(0, 5);
                events.Rows.Add(newRow);
            }

            return events;
        }
        public static DataTable GetCaseEvents()
        {
            VectorLayer vectorLayer = new VectorLayer("stt_case");
            string connection = ConnectionManager.DefaultInstance.ConnectionString;
            vectorLayer.DataSource = new MsSql(connection, "gisWKBSettlement", "blbWKBGeometry",
                                               "idfsGeoObject");
            FeatureDataSet fds = new FeatureDataSet();
            BoundingBox bbox = vectorLayer.Envelope;
            ((SharpMap.Data.Providers.MsSql) vectorLayer.DataSource).ExecuteIntersectionQuery(bbox, fds);
            
            DataTable events = new DataTable();
            events.Columns.AddRange(new DataColumn[]
                                        {
                                            new DataColumn("id", typeof (long)),
                                            new DataColumn("value", typeof (double)),
                                            new DataColumn("x", typeof (double)),
                                            new DataColumn("y", typeof (double)),
                                            new DataColumn("info1", typeof(string)),
                                            new DataColumn("info2",typeof(string))
                                        });
            
            Random rnd = new Random(unchecked((int) DateTime.Now.Ticks));
            Random rnd1 = new Random(~unchecked((int)DateTime.Now.Ticks));
            int k;
            for (int i = 0; i < fds.Tables[0].Count; i++)
            {
                DataRow newRow = events.NewRow();
                newRow["id"] = rnd1.Next();
                k = rnd.Next(0, 10);
                if (k < 5)
                {
                    newRow["x"] = fds.Tables[0][i].Geometry.GetBoundingBox().Left;
                    newRow["y"] = fds.Tables[0][i].Geometry.GetBoundingBox().Bottom;
                }
                newRow["value"] = rnd.Next(0, 5);
                newRow["info1"] = "info1";
                newRow["info2"] = "info2";
                if ((double)newRow["value"] != 0) events.Rows.Add(newRow);
            }
            
            return events;
        }

        public static DataTable GetRegionalEvents_Old(string connection, double minValue, double maxValue)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT idfsGeoObject FROM gisWKBRegion", connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            DataTable events = new DataTable();
            events.Columns.AddRange(new DataColumn[]
                                        {
                                            new DataColumn("id", typeof (long)),
                                            new DataColumn("caption", typeof (string)),
                                            new DataColumn("value", typeof (double))
                                        });

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            Random rnd1 = new Random(~unchecked((int)DateTime.Now.Ticks));
            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = events.NewRow();
                newRow["id"] = (long)row[0];
                double dblValue = rnd.Next((int)minValue, (int)maxValue);
                int flag = rnd1.Next(0, 5);
                if (flag == 3)
                {
                    dblValue = 0;
                }
                newRow["value"] = dblValue;
                newRow["caption"] = "region";
                events.Rows.Add(newRow);
            }

            return events;
        }
        public static DataTable GetRegionalEvents(string connection, double minValue, double maxValue)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT idfsGeoObject FROM gisWKBRegion", connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            DataTable events = new DataTable();
            events.Columns.AddRange(new DataColumn[]
                                        {
                                            new DataColumn("id", typeof (long)),
                                            new DataColumn("value", typeof (double)),
                                            new DataColumn("x", typeof (double)),
                                            new DataColumn("y", typeof (double)),
                                            new DataColumn("population", typeof (long)),
                                            new DataColumn("info", typeof (string))
                                        });

            Random rnd = new Random(unchecked((int) DateTime.Now.Ticks));
            Random rnd1 = new Random(~unchecked((int)DateTime.Now.Ticks));
            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = events.NewRow();
                newRow["id"] = (long) row[0];
                double dblValue = rnd.Next((int) minValue, (int) maxValue);
                int flag = rnd1.Next(0, 5);
                if (flag == 3)
                {
                    dblValue = 0;
                }
                
                newRow["value"] = dblValue;
                newRow["population"] = rnd.Next(0, 1000000);
                newRow["info"] = "region";
                if (dblValue != 0) events.Rows.Add(newRow);
            }
            
            return events;
        }

        public static DataTable GetDistrictEvents_Old(string connection, double minValue, double maxValue)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT idfsGeoObject FROM gisWKBRayon", connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            DataTable events = new DataTable();
            events.Columns.AddRange(new DataColumn[]
                                        {
                                            new DataColumn("id", typeof (long)),
                                            new DataColumn("caption", typeof (string)),
                                            new DataColumn("value", typeof (double))
                                        });

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            Random rnd1 = new Random(~unchecked((int)DateTime.Now.Ticks));

            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = events.NewRow();
                newRow["id"] = (long)row[0];
                double dblValue = rnd.Next((int)minValue, (int)maxValue);
                int flag = rnd1.Next(0, 15);
                if (flag == 3)
                {
                    dblValue = 0;
                }
                newRow["value"] = dblValue;
                newRow["caption"] = "district";
                events.Rows.Add(newRow);
            }

            return events;
        }
        public static DataTable GetDistrictEvents(string connection, double minValue, double maxValue)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT idfsGeoObject FROM gisWKBRayon", connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            DataTable events = new DataTable();
            events.Columns.AddRange(new DataColumn[]
                                        {
                                            new DataColumn("id", typeof (long)),
                                            new DataColumn("value", typeof (double)),
                                            new DataColumn("x", typeof (double)),
                                            new DataColumn("y", typeof (double)),
                                            new DataColumn("population", typeof (long)),
                                            new DataColumn("info", typeof (string))
                                        });

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            Random rnd1 = new Random(~unchecked((int)DateTime.Now.Ticks));

            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = events.NewRow();
                newRow["id"] = (long)row[0];
                double dblValue = rnd.Next((int)minValue, (int)maxValue);
                int flag = rnd1.Next(0, 15);
                if (flag == 3)
                {
                    dblValue = 0;
                }
                newRow["value"] = dblValue;
                newRow["population"] = rnd.Next(0, 1000000);
                newRow["info"] = "district";
                if (dblValue != 0) events.Rows.Add(newRow);
            }

            return events;
        }

        public static DataTable GetSttEvents_Old(string connection, double minValue, double maxValue)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT idfsGeoObject FROM gisWKBSettlement", connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            DataTable events = new DataTable();
            events.Columns.AddRange(new DataColumn[]
                                        {
                                            new DataColumn("id", typeof (long)),
                                            new DataColumn("caption", typeof (string)),
                                            new DataColumn("value", typeof (double))
                                        });

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            Random rnd1 = new Random(~unchecked((int)DateTime.Now.Ticks));

            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = events.NewRow();
                newRow["id"] = (long)row[0];
                double dblValue = rnd.Next((int)minValue, (int)maxValue);
                int flag = (int)rnd1.Next(0, 15);

                if (flag != 5)
                {
                    dblValue = 0;
                }
                newRow["value"] = dblValue;
                newRow["caption"] = "settlement";
                events.Rows.Add(newRow);
            }

            return events;
        }
        public static DataTable GetSttEvents(string connection, double minValue, double maxValue)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT idfsGeoObject FROM gisWKBSettlement", connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            DataTable events = new DataTable();
            events.Columns.AddRange(new DataColumn[]
                                        {
                                            new DataColumn("id", typeof (long)),
                                            new DataColumn("value", typeof (double)),
                                            new DataColumn("x", typeof (double)),
                                            new DataColumn("y", typeof (double)),
                                            new DataColumn("population", typeof (long)),
                                            new DataColumn("info", typeof (string))
                                        });

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            Random rnd1 = new Random(~unchecked((int) DateTime.Now.Ticks));

            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = events.NewRow();
                newRow["id"] = (long)row[0];
                double dblValue = rnd.Next((int)minValue, (int)maxValue);
                int flag = (int) rnd1.Next(0, 15);

                if (flag!=5)
                {
                    dblValue = 0;
                }
                newRow["value"] = dblValue;
                newRow["population"] = rnd.Next(0, 1000000);
                newRow["info"] = "settlement";
                if (dblValue != 0) events.Rows.Add(newRow);
            }

            return events;
        }

    }
}
