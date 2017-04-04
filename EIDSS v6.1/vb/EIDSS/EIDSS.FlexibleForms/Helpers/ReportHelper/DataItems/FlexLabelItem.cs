using System;
using System.Drawing;
using System.Windows.Forms;
using bv.common;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using bv.model.Helpers;
using bv.winclient.Core;
using EIDSS.FlexibleForms.DataBase;

namespace EIDSS.FlexibleForms.Helpers.ReportHelper.DataItems
{
    /// <summary>
    /// item represents LabelsRow 
    /// </summary>
    public class FlexLabelItem : FlexItem
    {
        internal FlexLabelItem(FlexibleFormsDS.LabelsRow row)
        {
            if (row.IsColorNull()) row.Color = Color.FromArgb(row.intColor);

            Color = row.IsColorNull() ? Color.Black : row.Color;
            Height = row.IsintHeightNull() ? 0 : row.intHeight;
            Width = row.IsintWidthNull() ? 0 : row.intWidth;
            Top = row.intTop;
            Left = row.intLeft;
            LinkedObject = row;

            Text = Utils.IsEmpty(row.NationalText) ? row.DefaultText : row.NationalText;
            FontSize = row.intFontSize;
            FontStyle = row.intFontStyle;
        }

        internal FlexLabelItem(FlexibleFormsDS.ParameterTemplateRow row, bool isParameterInSection)
        {
            Height = row.IsintHeightNull() ? 0 : row.intHeight;
            Width = isParameterInSection
                        ? row.IsintWidthNull() ? 0 : row.intWidth
                        : row.IsintLabelSizeNull() ? 0 : row.intLabelSize;
            Top = row.IsintTopNull() ? 0 : row.intTop;
            Left = row.IsintLeftNull() ? 0 : row.intLeft;
            Order = row.IsintOrderNull() ? 0 : row.intOrder;
            LinkedObject = row;

            FontSize = ReportSettings.DefaultFontSize;
            Text = Utils.IsEmpty(row.NationalName) ? row.DefaultName : row.NationalName;
        }

        internal FlexLabelItem(FlexibleFormsDS.ParametersDeletedFromTemplateRow row, bool isParameterInSection)
        {
            Height = row.intHeight;
            Width = isParameterInSection ? row.intWidth : row.intLabelSize;
            Top = row.intTop;
            Left = row.intLeft;
            Order = row.intOrder;
            LinkedObject = row;

            FontSize = ReportSettings.DefaultFontSize;
            Text = !Utils.IsEmpty(row.NationalLongName)
                       ? row.NationalLongName
                       : !Utils.IsEmpty(row.NationalName) ? row.NationalName : row.DefaultName;
        }

        internal FlexLabelItem
            (FlexibleFormsDS.ParameterTemplateRow parentRow, FlexibleFormsDS.ActivityParametersRow row)
        {
            if (parentRow.intScheme.Equals((int) FFParameterScheme.Left) ||
                parentRow.intScheme.Equals((int) FFParameterScheme.Right))
            {
                Width = parentRow.IsintWidthNull() ? 0 : parentRow.intWidth - parentRow.intLabelSize;
                Height = parentRow.IsintHeightNull() ? 0 : parentRow.intHeight;
            }
            else
            {
                Width = parentRow.IsintWidthNull() ? 0 : parentRow.intWidth;
                Height = parentRow.IsintHeightNull() ? 0 : parentRow.intHeight - parentRow.intLabelSize;
            }
            Top = parentRow.IsintTopNull() ? 0 : parentRow.intTop;
            Left = parentRow.IsintLeftNull() ? 0 : parentRow.intLeft;
            LinkedObject = row;
            switch (parentRow.intScheme)
            {
                case (int) FFParameterScheme.Left:
                    Left += parentRow.intLabelSize;
                    break;
                case (int) FFParameterScheme.Right:
                    Left -= parentRow.intLabelSize;
                    break;
                case (int) FFParameterScheme.Top:
                    Top += parentRow.intLabelSize;
                    break;
                case (int) FFParameterScheme.Bottom:
                    Top -= parentRow.intLabelSize;
                    break;
            }

            FontSize = ReportSettings.DefaultFontSize;

            if (row == null)
            {
                Text = String.Empty;
            }
            else if (ParameterControlTypeHelper.ConvertToParameterControlType(parentRow.idfsEditor).Equals(FFParameterEditors.CheckBox))
            {
                var val = (bool)row.varValue ? 10100001 : 10100002; //Yes/No
                Text = LookupCache.GetLookupValue(val, BaseReferenceType.rftYesNoValue, "name");
            }
            else if (!row.IsstrNameValueNull())
            {
                Text = row.strNameValue;
            }
            else if (row.varValue != null)
            {
                var str = row.varValue.ToString();
                if (parentRow.idfsParameterType.Equals((long) FFParameterTypes.Date))
                {
                    var itms = str.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                    if (itms.Length > 0) Text = itms[0];
                }
                else
                {
                    Text = str;
                }
            }
        }

        internal FlexLabelItem
            (FlexibleFormsDS.ParametersDeletedFromTemplateRow rowParameter, FlexibleFormsDS.ActivityParametersRow row)
        {
            if (rowParameter.intScheme.Equals((int) FFParameterScheme.Left) ||
                rowParameter.intScheme.Equals((int) FFParameterScheme.Right))
            {
                Width = rowParameter.intWidth - rowParameter.intLabelSize;
                Height = rowParameter.intHeight;
            }
            else
            {
                Width = rowParameter.intWidth;
                Height = rowParameter.intHeight - rowParameter.intLabelSize;
            }
            Top = rowParameter.intTop;
            Left = rowParameter.intLeft;
            LinkedObject = row;
            switch (rowParameter.intScheme)
            {
                case (int) FFParameterScheme.Left:
                    Left += rowParameter.intLabelSize;
                    break;
                case (int) FFParameterScheme.Right:
                    Left -= rowParameter.intLabelSize;
                    break;
                case (int) FFParameterScheme.Top:
                    Top += rowParameter.intLabelSize;
                    break;
                case (int) FFParameterScheme.Bottom:
                    Top -= rowParameter.intLabelSize;
                    break;
            }

            FontSize = ReportSettings.DefaultFontSize;
            Text = row != null ? row.IsstrNameValueNull() ? row.varValue.ToString() : row.strNameValue : String.Empty;
        }

        internal FlexLabelItem(FlexibleFormsDS.SectionTemplateRow row)
        {
            Height = row.IsintHeightNull() ? 0 : row.intHeight;
            Width = row.IsintWidthNull() ? 0 : row.intWidth;
            Top = row.IsintTopNull() ? 0 : row.intTop;
            Left = row.IsintLeftNull() ? 0 : row.intLeft;
            Order = row.IsintOrderNull() ? 0 : row.intOrder;
            LinkedObject = row;

            FontSize = ReportSettings.DefaultFontSize;
            Text = Utils.IsEmpty(row.NationalName) ? row.DefaultName : row.NationalName;
        }

        internal FlexLabelItem(string caption)
        {
            var sizeString = TextRenderer.MeasureText(caption, WinClientContext.CurrentFont);
            Height = sizeString.Height;
            Width = sizeString.Width;
            Top = 0;
            Left = 0;
            Order = 0;
            LinkedObject = null;

            FontSize = ReportSettings.DefaultFontSize;
            Text = caption;
        }

        public string Text { get; private set; }

        public bool IsParameterValue { get; internal set; }

        public int FontSize { get; private set; }

        public int FontStyle { get; private set; }

        public override string ToString()
        {
            var text = Text ?? "<Empty>";
            var isParam = IsParameterValue ? "Param" : "Not Param";
            return string.Format("{0}, {1}, ({2},{3}) {4}x{5}", text, isParam, Left, Top, Width, Height);
        }
    }
}