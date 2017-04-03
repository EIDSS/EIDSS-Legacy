using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Import
{
    public class CsvError
    {
        public long LineNumber {get;set;}
        public int FieldNumber { get; set; }
        public int Position { get; set; }
        public string MessageID { get; set; }
        public string BadValue { get; set; }
        public string LineValue { get; set; }
        public bool FormattedError { get; set; }
        public CsvError(long lineNumber, int fieldNumber, int position, string msgId, string badValue, string lineValue, bool formattedError = true)
        {
            LineNumber = lineNumber;
            FieldNumber = fieldNumber;
            Position = position;
            MessageID = msgId;
            BadValue = badValue;
            LineValue = lineValue;
            FormattedError = formattedError;
        }
    }
}
