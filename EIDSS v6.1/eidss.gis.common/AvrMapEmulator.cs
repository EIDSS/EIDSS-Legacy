using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eidss.gis.common
{
    public static class AvrMapEmulator
    {
        public static DataTable GetAvrMapTable(bool isSingle, bool isAdmin, bool isPoint)
        {
            var data = new DataTable();

            data.Columns.Add("id", typeof(long));
            data.Columns.Add("x", typeof(double));
            data.Columns.Add("y", typeof(double));
            data.Columns.Add("type", typeof(int));
            data.Columns.Add("value", typeof(double));
            data.Columns.Add("info", typeof(string));

            if (isSingle)
            {
                //single case type data table
                if (isAdmin)
                {
                    //admin unit based data table
                    if (isPoint)
                    {
                        data.Rows.Add(54850000000, null, null, 1, 50, "3260000000: 50");
                        data.Rows.Add(54850000000, null, null, 4, 50, "3260000000: 50");
                        data.Rows.Add(54860000000, null, null, 2, 20, "37080000000: 20");
                    }
                    else
                    {
                        data.Rows.Add(3260000000, null, null, null, 50, "3260000000: 50");
                        data.Rows.Add(3270000000, null, null, null, 20, "37080000000: 20");
                        data.Rows.Add(3280000000, null, null, null, 10, "37090000000: 10");
                        data.Rows.Add(3290000000, null, null, null, 100, "37100000000: 100");
                        data.Rows.Add(3300000000, null, null, null, 50, "37110000000: 50");
                    }
                }
                else
                {
                    //(x,y)-based data table
                    data.Rows.Add(null, 42.1, 42.5, null, 50, "");
                    data.Rows.Add(null, 41.6, 42.8, null, 10, "");
                    data.Rows.Add(null, 46.2, 41.4, null, 100, "");
                }
            }
            else
            {
                //multiple gis type data table
                if (isAdmin)
                {
                    //admin unit based data table
                    if (isPoint)
                    {
                        data.Rows.Add(54850000000, null, null, 1, 50, "3260000000: 50");
                        data.Rows.Add(54990000000, null, null, 1, 50, "37110000000: 50");
                        data.Rows.Add(54850000000, null, null, 4, 50, "3260000000: 50");
                        data.Rows.Add(54860000000, null, null, 2, 20, "37080000000: 20");
                        data.Rows.Add(54960000000, null, null, 2, 100, "37100000000: 100");
                        data.Rows.Add(54950000000, null, null, 4, 10, "37090000000: 10");
                        data.Rows.Add(54960000000, null, null, 1, 100, "37100000000: 100");
                        data.Rows.Add(54850000000, null, null, 2, 50, "3260000000: 50");
                    }
                    else
                    {
                        data.Rows.Add(3260000000, null, null, 1, 50, "3260000000: 50");
                        data.Rows.Add(3300000000, null, null, 1, 50, "37110000000: 40");
                        data.Rows.Add(3260000000, null, null, 4, 20, "3260000000: 20");
                        data.Rows.Add(3270000000, null, null, 2, 20, "37080000000: 20");
                        data.Rows.Add(3290000000, null, null, 2, 100, "37100000000: 100");
                        data.Rows.Add(3280000000, null, null, 4, 10, "37090000000: 10");
                        data.Rows.Add(3290000000, null, null, 1, 80, "37100000000: 80");
                        data.Rows.Add(3260000000, null, null, 2, 30, "3260000000: 50");
                    }
                }
                else
                {
                    //(x,y)-based data table
                    data.Rows.Add(null, 40.66, 43.28, 1, 50, "3260000000: 50");
                    data.Rows.Add(null, 42.23, 43.15, 1, 50, "37110000000: 40");
                    data.Rows.Add(null, 40.66, 43.28, 4, 20, "3260000000: 20");
                    data.Rows.Add(null, 41.85, 42.16, 2, 20, "37080000000: 20");
                    data.Rows.Add(null, 43.42, 42.54, 2, 100, "37100000000: 100");
                    data.Rows.Add(null, 45.19, 41.75, 4, 10, "37090000000: 10");
                    data.Rows.Add(null, 43.42, 42.54, 1, 80, "37100000000: 80");
                    data.Rows.Add(null, 40.66, 43.28, 2, 30, "3260000000: 50");
                }
            }

            return data;
        }
    }
}
