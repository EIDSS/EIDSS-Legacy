using System;
using System.Collections.Generic;
using DevExpress.XtraCharts;

namespace EIDSS.Reports.BaseControls
{
    public static class ChartHelper
    {
        public static void DesignAxisY(XYDiagram diagram, double maxValue)
        {
            if (diagram != null)
            {
                diagram.AxisY.WholeRange.MinValue = 0;
                if (Math.Abs(maxValue) < 1.0 / Int32.MaxValue)
                {
                    maxValue = 1;
                }

                bool growh = maxValue >= 1;
                var oldScale = new KeyValuePair<double, int>(10, 10);
                foreach (KeyValuePair<double, int> scale in GetScales(growh))
                {
                    if (growh && maxValue <= scale.Key)
                    {
                        AddCustomLabels(diagram, scale.Key, scale.Value);
                        break;
                    }
                    if (!growh && maxValue >= scale.Key)
                    {
                        AddCustomLabels(diagram, oldScale.Key, oldScale.Value);
                        break;
                    }
                    oldScale = scale;
                }
            }
        }

        private static IEnumerable<KeyValuePair<double, int>> GetScales(bool growth)
        {
            double mult = 0.1;
            var scaleList = new List<KeyValuePair<int, int>>
            {
                new KeyValuePair<int, int>(10, 10),
                new KeyValuePair<int, int>(12, 6),
                new KeyValuePair<int, int>(14, 7),
                new KeyValuePair<int, int>(15, 5),
                new KeyValuePair<int, int>(16, 8),
                new KeyValuePair<int, int>(18, 9),
                new KeyValuePair<int, int>(20, 10),
                new KeyValuePair<int, int>(21, 7),
                new KeyValuePair<int, int>(24, 8),
                new KeyValuePair<int, int>(25, 5),
                new KeyValuePair<int, int>(27, 9),
                new KeyValuePair<int, int>(30, 10),
                new KeyValuePair<int, int>(32, 8),
                new KeyValuePair<int, int>(35, 7),
                new KeyValuePair<int, int>(40, 10),
                new KeyValuePair<int, int>(45, 9),
                new KeyValuePair<int, int>(50, 10),
                new KeyValuePair<int, int>(60, 6),
                new KeyValuePair<int, int>(70, 7),
                new KeyValuePair<int, int>(80, 8),
                new KeyValuePair<int, int>(90, 9)
            };
            if (!growth)
            {
                scaleList.Reverse();
            }

            while (mult < Int32.MaxValue && mult > 1.0 / Int32.MaxValue)
            {
                foreach (KeyValuePair<int, int> pair in scaleList)
                {
                    yield return new KeyValuePair<double, int>(mult * pair.Key, pair.Value);
                }
                if (growth)
                {
                    mult *= 10;
                }
                else
                {
                    mult /= 10;
                }
            }
        }

        private static void AddCustomLabels(XYDiagram diagram, double value, int steps)
        {
            diagram.AxisY.WholeRange.MaxValue = value;
            var labels = new CustomAxisLabel[steps + 1];
            double delta = value / steps;
            for (int i = 0; i < steps + 1; i++)
            {
                string axisValue = (i * delta).ToString();
                labels[i] = new CustomAxisLabel {AxisValueSerializable = axisValue, Name = axisValue};
            }

            diagram.AxisY.CustomLabels.AddRange(labels);
        }
    }
}