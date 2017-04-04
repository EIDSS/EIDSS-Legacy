using System;
using System.Data;

namespace eidss.avr.FilterForm
{
    public class FilterDataColumn : DataColumn
    {
        public FilterDataColumn()
        {

        }
        public FilterDataColumn(string columnName, Type type)
            : base(columnName, type)
        {

        }
        public FilterDataColumn(string columnName, Type type, string aliasName)
            : base(columnName, type)
        {
            AliasName = aliasName;
        }
        public string AliasName { get; set; }
    }
}
