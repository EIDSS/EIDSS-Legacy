using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EIDSS.Reports.Parameterized.AberrationAnalysis.DataSets;

namespace EIDSS.Reports.AberrationAnalysis
{
    public static class AberrationAlgorithm
    {
        public static void Calculate(AberrationDataSet.AberrationDataDataTable dataTable, int Baseline, int Lag, decimal Threshold)
        {
            decimal[] sigmat = new decimal[dataTable.Rows.Count];
            IEnumerable<AberrationDataSet.AberrationDataRow> rows = dataTable.AsEnumerable();

            /*
            dataTable.Rows[0]["expected"] = dataTable.Rows[0]["observed"];
            dataTable.Rows[1]["expected"] = dataTable.Rows[0]["observed"];
            sigmat[0] = 0.5M;
            sigmat[1] = 0.5M;
            dataTable.Rows[0]["aberrations"] = Threshold / 2;
            dataTable.Rows[0]["threshold"] = Threshold;
            */

            for (int i = 0; i < Math.Min(Baseline + Lag, dataTable.Rows.Count); i++)
            {
                dataTable.Rows[i]["expected"] = 0;
                sigmat[i] = 0;
                dataTable.Rows[i]["aberrations"] = 0;
                dataTable.Rows[i]["threshold"] = 0;// Threshold;
            }

            for (int i = Baseline + Lag; i < dataTable.Rows.Count; i++)
            {
                List<AberrationDataSet.AberrationDataRow> l;
                if (i < Baseline + Lag)
                    l = rows.Where(dr => (int)dr["id"] < i).ToList();
                else
                    l = rows.Where(dr => (int)dr["id"] > i - Lag - Baseline - 1 && (int)dr["id"] < i - Lag).ToList();

                dataTable.Rows[i]["expected"] = l.Average(dr => (int)dr["observed"]);
                double sigma = l.Sum(s => Math.Pow((int)s["observed"] - (double)(decimal)dataTable.Rows[i]["expected"], 2));
                sigmat[i] = Math.Max(0.5M, (decimal)Math.Sqrt((double)sigma / (l.Count - 1)));
            }

            for (int i = Baseline + Lag; i < dataTable.Rows.Count; i++)
            {
                decimal a = (decimal)dataTable.Rows[i - 1]["aberrations"] > Threshold ? Threshold / 2 : (decimal)dataTable.Rows[i - 1]["aberrations"];
                decimal c = (int)dataTable.Rows[i]["observed"] - (decimal)dataTable.Rows[i]["expected"] - (sigmat[i] / 2);
                dataTable.Rows[i]["aberrations"] = Math.Max(0, a + c / sigmat[i]);

                dataTable.Rows[i]["threshold"] = Threshold;
                if ((decimal)dataTable.Rows[i]["aberrations"] > Threshold)
                    dataTable.Rows[i]["alert"] =  dataTable.Rows[i]["observed"];
            }

            for (int i = Baseline + Lag; i < dataTable.Rows.Count; i++)
            {
                dataTable.Rows[i]["aberrations"] = Math.Round((decimal)dataTable.Rows[i]["aberrations"], 4);
            }
        }
    }
}
