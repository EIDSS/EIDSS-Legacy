using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
//using ClosedXML.Excel;

namespace eidss.model.Avr.Export
{
    public class ClosedXmlExcelWrapper : IDisposable
    {
        //public XLWorkbook Workbook { get; private set; }
        public ClosedXmlExcelWrapper()
        {
            //Workbook = new XLWorkbook();
        }
        public void Export(string fileName, DataTable data)
        {
            //if (string.IsNullOrEmpty(data.TableName))
            //    data.TableName = "Sheet";
            //Workbook.Worksheets.Add(data);
            //for (int i = 0; i < data.Columns.Count; i++)
            //{
            //    Workbook.Worksheets.Worksheet(1).Cell(1, i + 1).Style.Font.Bold = true;
            //}
            //Workbook.SaveAs(fileName);

        }
        public void Dispose()
        {
            //if (Workbook != null)
            //    Workbook.Dispose();
            //Workbook = null;
        }
    }
}
