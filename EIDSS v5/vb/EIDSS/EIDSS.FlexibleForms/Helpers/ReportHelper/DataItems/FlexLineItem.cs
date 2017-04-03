using System.Drawing;
using EIDSS.FlexibleForms.DataBase;

namespace EIDSS.FlexibleForms.Helpers.ReportHelper.DataItems
{
    /// <summary>
    /// item represents LinesRow 
    /// </summary>
    public class FlexLineItem : FlexItem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        internal FlexLineItem(FlexibleFormsDS.LinesRow row)
        {
            Orientation = row.IsblnOrientationNull() ? false : row.blnOrientation;
            Color = row.IsColorNull() ? Color.Black : row.Color;
            Height = row.IsintHeightNull() ? 0 : row.intHeight;
            Width = row.IsintWidthNull() ? 0 : row.intWidth;
            Top = row.IsintTopNull() ? 0 : row.intTop;
            Left = row.IsintLeftNull() ? 0 : row.intLeft;
            LinkedObject = row;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Orientation{get; private set;}
        
    }
}