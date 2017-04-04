using System.Collections.Generic;
using System.Linq;

namespace eidss.model.Schema
{
    public partial class CustomReportRowsMaster
    {
        private bool RecalculateNow { get; set; }

        public void RecalculateRowNumber(CustomReportRow item)
        {
            if (RecalculateNow) return;
            RecalculateNow = true;
            //все номера в таблице, которые больше этого N, изменяются как N+1
            var rows = CustomReportRows.Where(c => (c.idfsCustomReportType == item.idfsCustomReportType) && (c.intRowOrder >= item.intRowOrder) && (c.idfReportRows != item.idfReportRows)).ToList();
            rows.Sort(new CompareRows());
            for (var i = 0; i < rows.Count; i++)
            {
                rows[i].intRowOrder = item.intRowOrder + i + 1;
            }

            RecalculateNow = false;

            /* старый алгоритм
             * 
             * Паша сказал переделать на нынешний 13 марта 2014 года в рамках исправления бага 9068
             * 
            //пересчет всех номеров строк вниз от этой строки (порядок строк жестко сортирован по возрастанию и не меняется пользователем)
            var list = CustomReportRows.Where(c => c.idfsSummaryReportType == item.idfsSummaryReportType).ToList();
            var index = list.IndexOf(item);
            if (index < 0) return;
            RecalculateNow = true;
            var numRow = item.intRowOrder;
            for (var i = index + 1; i < list.Count; i++)
            {
                list[i].intRowOrder = numRow + (i - index);
            }
            */
        }

        public int GetNewRowNumber()
        {
            if (RecalculateNow) return 0;
            var list = CustomReportRows.Where(c => c.idfsCustomReportType == idfsSummaryReportType).ToList();
            var max = 0;
            if (list.Count > 0) max = list.Max(c => c.intRowOrder);
            return max + 1;
        }
    }

    class CompareRows : IComparer<CustomReportRow>
    {
        public int Compare(CustomReportRow x, CustomReportRow y)
        {
            return x.intRowOrder - y.intRowOrder;
        }
    }
}
