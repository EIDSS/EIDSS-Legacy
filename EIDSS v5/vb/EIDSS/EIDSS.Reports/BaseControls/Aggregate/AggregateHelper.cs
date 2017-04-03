using System.Collections.Generic;

namespace EIDSS.Reports.BaseControls.Aggregate
{
    public class AggregateHelper
    {
        internal static List<long> GetObservationList(IDictionary<string, string> parameters, string prefix)
        {
            List<long> observations = new List<long>();
            foreach (KeyValuePair<string, string> pair in parameters)
            {
                if (pair.Key.StartsWith(prefix))
                {
                    observations.Add(long.Parse(pair.Value));
                }
            }
            return observations;
        }
    }
}