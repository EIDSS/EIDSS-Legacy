using DevExpress.XtraPivotGrid;

namespace eidss.avr.db.Common
{
    public class CustomSortHandler
    {
        public void OnCustomFieldSort(object sender, PivotGridCustomFieldSortEventArgs e)
        {
            return;

            /*
            if (e.Value1 == null || e.Value2 == null)
            {
                return;
            }

            string value1 = Utils.Str(e.Value1);
            Match match1 = Regex.Match(value1, @"(?<StartAge>\d+)\D*");
            Group stratAgeGroup1 = match1.Groups["StartAge"];

            if (stratAgeGroup1.Captures.Count > 0)
            {
                int startAge1;
                if (int.TryParse(Utils.Str(stratAgeGroup1.Captures[0].Value), out startAge1))
                {
                    string value2 = Utils.Str(e.Value2);
                    Match match2 = Regex.Match(value2, @"(?<StartAge>\d+)\D*");
                    Group stratAgeGroup2 = match2.Groups["StartAge"];
                    if (stratAgeGroup2.Captures.Count > 0)
                    {
                        int startAge2;
                        if (int.TryParse(Utils.Str(stratAgeGroup2.Captures[0].Value), out startAge2))
                        {
                            e.Handled = true;
                            if (startAge1 > startAge2)
                            {
                                e.Result = 1;
                            }
                            else if (startAge1 == startAge2)
                            {
                                e.Result = Comparer<String>.Default.Compare(value1, value2);
                            }
                            else
                            {
                                e.Result = -1;
                            }
                        }
                    }
                }
            }
             * */
        }
    }
}