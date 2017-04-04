using System;
using System.Drawing;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Helpers;
using bv.model.Model.Core;
using eidss.model.Enums;
using eidss.model.FlexibleForms.Helpers;
using eidss.model.Model.FlexibleForms.FlexNodes;
using eidss.model.Schema;

namespace eidss.model.Model.Report
{
    public class FlexLabelItem : FlexItem
    {
        internal FlexLabelItem(Label row) : base(row)
        {
            Color = Color.FromArgb(row.Color);
            Height = row.Height;
            Width = row.Width;
            Top = row.intTop;
            Left = row.intLeft;

            Text = string.IsNullOrEmpty(row.NationalText) ? row.DefaultText : row.NationalText;
            FontSize = row.FontSize;
            FontStyle = row.FontStyle;
        }

        internal FlexLabelItem(ParameterTemplate row, bool isParameterInSection)
            : base(row)
        {
            Height = row.intHeight;
            Width = isParameterInSection
                        ? row.intWidth
                        : row.intLabelSize;
            if (Width == 0) Width = row.intWidth;
            Top = row.intTop;
            Left = row.intLeft;
            Order = row.intOrder;

            FontSize = ReportSettings.DefaultFontSize;
            Text = string.IsNullOrEmpty(row.NationalName) ? row.DefaultName : row.NationalName;
        }

        internal FlexLabelItem(PredefinedStub row)
            : base(row)
        {
            Order = row.intOrder;
            FontSize = ReportSettings.DefaultFontSize;
            Text = row.strNameValue;
        }

        internal FlexLabelItem(ParametersDeletedFromTemplate row, bool isParameterInSection)
            : base(row)
        {
            Height = row.intHeight;
            Width = isParameterInSection ? row.intWidth : row.intLabelSize;
            Top = row.intTop;
            Left = row.intLeft;
            Order = row.intOrder;

            FontSize = ReportSettings.DefaultFontSize;
            Text = !Utils.IsEmpty(row.NationalLongName)
                       ? row.NationalLongName
                       : !Utils.IsEmpty(row.NationalName) ? row.NationalName : row.DefaultName;
        }

        internal FlexLabelItem
            (ParameterTemplate parentRow, ActivityParameter row)
            : base(row)
        {
            if (parentRow.intScheme.Equals((int)FFParameterScheme.Left) ||
                parentRow.intScheme.Equals((int)FFParameterScheme.Right))
            {
                Width = parentRow.intWidth - parentRow.intLabelSize;
                Height = parentRow.intHeight;
            }
            else
            {
                Width = parentRow.intWidth;
                Height = parentRow.intHeight - parentRow.intLabelSize;
            }
            Top = parentRow.intTop;
            Left = parentRow.intLeft;
           
            switch (parentRow.intScheme)
            {
                case (int)FFParameterScheme.Left:
                    Left += parentRow.intLabelSize;
                    break;
                case (int)FFParameterScheme.Right:
                    Left -= parentRow.intLabelSize;
                    break;
                case (int)FFParameterScheme.Top:
                    Top += parentRow.intLabelSize;
                    break;
                case (int)FFParameterScheme.Bottom:
                    Top -= parentRow.intLabelSize;
                    break;
            }

            FontSize = ReportSettings.DefaultFontSize;

            if (row == null)
            {
                Text = string.Empty;
            }
            else if (ParameterControlTypeHelper.ConvertToParameterControlType(parentRow.idfsEditor).Equals(FFParameterEditors.CheckBox))
            {
                long val = (bool)row.varValue ? 10100001 : 10100002; //Yes/No
                using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    Text = BaseReference.Accessor.Instance(null).rftYesNoValue_SelectList(manager).FirstOrDefault(c => c.idfsBaseReference == val, c => String.Empty);
                }
            }
            else if (!string.IsNullOrEmpty(row.strNameValue))
            {
                Text = row.strNameValue;
            }
            else if (row.varValue != null)
            {
                var str = row.varValue.ToString();
                if (parentRow.idfsParameterType.Equals((long)FFParameterTypes.Date))
                {
                    var itms = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (itms.Length > 0) Text = itms[0];
                }
                else
                {
                    Text = str;
                }
            }
        }

        internal FlexLabelItem(ParametersDeletedFromTemplate rowParameter, ActivityParameter row)
            : base(row)
        {
            if (rowParameter.intScheme.Equals((int)FFParameterScheme.Left) ||
                rowParameter.intScheme.Equals((int)FFParameterScheme.Right))
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
                case (int)FFParameterScheme.Left:
                    Left += rowParameter.intLabelSize;
                    break;
                case (int)FFParameterScheme.Right:
                    Left -= rowParameter.intLabelSize;
                    break;
                case (int)FFParameterScheme.Top:
                    Top += rowParameter.intLabelSize;
                    break;
                case (int)FFParameterScheme.Bottom:
                    Top -= rowParameter.intLabelSize;
                    break;
            }

            FontSize = ReportSettings.DefaultFontSize;
            Text = row != null ? string.IsNullOrEmpty(row.strNameValue) ? row.varValue.ToString() : row.strNameValue : string.Empty;
        }

        internal FlexLabelItem(SectionDeletedFromTemplate row)
            : base(row)
        {
            Height = row.Height;
            Width = row.Width;
            Top = row.Top;
            Left = row.Left;
            Order = row.Order;

            FontSize = ReportSettings.DefaultFontSize;
            Text = row.DefaultName;
        }
        internal FlexLabelItem(SectionTemplate row)
            : base(row)
        {
            Height = row.Height;
            Width = row.Width;
            Top = row.Top;
            Left = row.Left;
            Order = row.Order;

            FontSize = ReportSettings.DefaultFontSize;
            Text = Utils.IsEmpty(row.NationalName) ? row.DefaultName : row.NationalName;
        }

        internal FlexLabelItem(string caption, Size size, object linkedItem = null)
            : base(caption)
        {
            /*
            var sizeString = TextRenderer.MeasureText(caption, WinClientContext.CurrentFont);
            Height = sizeString.Height;
            Width = sizeString.Width;
            */
            Height = size.Height;
            Width = size.Width;
            Top = 0;
            Left = 0;
            Order = 0;
            LinkedObject = linkedItem;

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
