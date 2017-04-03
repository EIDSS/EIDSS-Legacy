using System;
using System.Collections.Generic;

namespace eidss.model.Reports.Common
{
    public class QuartersModel
    {
        public QuartersModel() : this(false, false, false, false)
        {
        }

        public QuartersModel(bool firstQuarter, bool secondQuarter, bool thirdQuarter, bool fourthQuarter)
        {
            int mask = 0;
            if (firstQuarter)
            {
                mask ++;
            }
            mask = mask << 1;
            if (secondQuarter)
            {
                mask++;
            }
            mask = mask << 1;
            if (thirdQuarter)
            {
                mask++;
            }
            mask = mask << 1;
            if (fourthQuarter)
            {
                mask++;
            }

            switch (mask)
            {
                case 0x0:
                case 0xF:
                    MinQuarter1 = 1;
                    MaxQuarter1 = 4;
                    break;
                case 0x1:
                    MinQuarter1 = 4;
                    MaxQuarter1 = 4;
                    break;
                case 0x2:
                    MinQuarter1 = 3;
                    MaxQuarter1 = 3;
                    break;
                case 0x3:
                    MinQuarter1 = 3;
                    MaxQuarter1 = 4;
                    break;
                case 0x4:
                    MinQuarter1 = 2;
                    MaxQuarter1 = 2;
                    break;
                case 0x5:
                    MinQuarter1 = 2;
                    MaxQuarter1 = 2;
                    MinQuarter2 = 4;
                    MaxQuarter2 = 4;
                    break;
                case 0x6:
                    MinQuarter1 = 2;
                    MaxQuarter1 = 3;
                    break;
                case 0x7:
                    MinQuarter1 = 2;
                    MaxQuarter1 = 4;
                    break;
                case 0x8:
                    MinQuarter1 = 1;
                    MaxQuarter1 = 1;
                    break;
                case 0x9:
                    MinQuarter1 = 1;
                    MaxQuarter1 = 1;
                    MinQuarter2 = 4;
                    MaxQuarter2 = 4;
                    break;
                case 0xA:
                    MinQuarter1 = 1;
                    MaxQuarter1 = 1;
                    MinQuarter2 = 3;
                    MaxQuarter2 = 3;
                    break;
                case 0xB:
                    MinQuarter1 = 1;
                    MaxQuarter1 = 1;
                    MinQuarter2 = 3;
                    MaxQuarter2 = 4;
                    break;
                case 0xC:
                    MinQuarter1 = 1;
                    MaxQuarter1 = 2;
                    break;
                case 0xD:
                    MinQuarter1 = 1;
                    MaxQuarter1 = 2;
                    MinQuarter2 = 4;
                    MaxQuarter2 = 4;
                    break;
                case 0xE:
                    MinQuarter1 = 1;
                    MaxQuarter1 = 3;
                    break;
            }
        }

        public int MinQuarter1 { get; set; }
        public int MaxQuarter1 { get; set; }
        public int? MinQuarter2 { get; set; }
        public int? MaxQuarter2 { get; set; }

        public DateTime GetStartDate1(int year)
        {
            return new DateTime(year, 1, 1).AddMonths(3 * (MinQuarter1 - 1));
        }

        public DateTime GetEndDate1(int year)
        {
            return new DateTime(year, 1, 1).AddMonths(3 * MaxQuarter1).AddDays(-1);
        }

        public DateTime? GetStartDate2(int year)
        {
            return MinQuarter2.HasValue
                ? (DateTime?) new DateTime(year, 1, 1).AddMonths(3 * (MinQuarter2.Value - 1))
                : null;
        }

        public DateTime? GetEndDate2(int year)
        {
            return MaxQuarter2.HasValue
                ? (DateTime?) new DateTime(year, 1, 1).AddMonths(3 * MaxQuarter2.Value).AddDays(-1)
                : null;
        }

        public string QuarterName
        {
            get
            {
                string result = QuarterNumbers[MinQuarter1 - 1];
                for (int quarter = MinQuarter1 + 1; quarter <= MaxQuarter1; quarter++)
                {
                    result += ", " + QuarterNumbers[quarter - 1];
                }
                if (MinQuarter2.HasValue && MaxQuarter2.HasValue)
                {
                    result += ", " + QuarterNumbers[MinQuarter2.Value - 1];
                    for (int quarter = MinQuarter2.Value + 1; quarter <= MaxQuarter2.Value; quarter++)
                    {
                        result += ", " + QuarterNumbers[quarter - 1];
                    }
                }
                return result;
            }
        }

        public static List<string> QuarterNumbers
        {
            get { return new List<string> {"I", "II", "III", "IV"}; }
        }

        public static List<string> QuartersFormat
        {
            get
            {
                return new List<string>
                {
                    "I (01.01.{0} – 31.03.{0})",
                    "II (01.04.{0} – 30.06.{0}) ",
                    "III (01.07.{0} – 30.09.{0})",
                    "IV (01.10.{0} – 31.12.{0})",
                };
            }
        }
    }
}