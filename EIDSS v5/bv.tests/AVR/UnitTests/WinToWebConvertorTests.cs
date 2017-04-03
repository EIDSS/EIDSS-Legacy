using System;
using System.Collections.Generic;
using System.IO;
using DevExpress.Web.ASPxPivotGrid;
using EIDSS.RAM;
using EIDSS.RAM.Components;
using EIDSS.RAM_DB.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Core;
using bv.common.win;
using eidss.ram.web.Components;
using ReflectionHelper = EIDSS.RAM_DB.Common.ReflectionHelper;

namespace bv.tests.AVR.UnitTests
{
    /// <summary>
    ///   Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class WinToWebConvertorTests 
    {
        #region Layout XML

        private const string LayoutXml =
            @"<XtraSerializer version=""1.0"" application=""PivotGrid"">
  <property name=""#LayoutVersion"" />
  <property name=""OptionsMenu"" isnull=""true"" iskey=""true"">
    <property name=""EnableHeaderAreaMenu"">false</property>
    <property name=""EnableHeaderMenu"">false</property>
  </property>
  <property name=""OptionsPrint"" isnull=""true"" iskey=""true"">
    <property name=""RowFieldValueSeparator"">0</property>
    <property name=""ColumnFieldValueSeparator"">0</property>
    <property name=""UsePrintAppearance"">true</property>
    <property name=""MergeColumnFieldValues"">true</property>
    <property name=""PageSettings"" isnull=""true"" iskey=""true"">
      <property name=""Landscape"">false</property>
      <property name=""Margins"">100, 100, 100, 100</property>
      <property name=""PaperHeight"">0</property>
      <property name=""PaperKind"">Letter</property>
      <property name=""PaperWidth"">0</property>
    </property>
    <property name=""PrintUnusedFilterFields"">true</property>
    <property name=""MergeRowFieldValues"">true</property>
    <property name=""PrintHeadersOnEveryPage"">false</property>
    <property name=""PrintVertLines"">Default</property>
    <property name=""PrintHorzLines"">Default</property>
    <property name=""VerticalContentSplitting"">Smart</property>
    <property name=""PrintDataHeaders"">Default</property>
    <property name=""PrintRowHeaders"">Default</property>
    <property name=""PrintColumnHeaders"">Default</property>
    <property name=""PrintFilterHeaders"">Default</property>
  </property>
  <property name=""OptionsView"" isnull=""true"" iskey=""true"">
    <property name=""ShowColumnTotals"">false</property>
    <property name=""ShowRowTotals"">false</property>
  </property>
  <property name=""AppearancePrint"" isnull=""true"" iskey=""true"">
    <property name=""TotalCell"" iskey=""true"" value=""TotalCell"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""FieldValue"" iskey=""true"" value=""FieldValue"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""GrandTotalCell"" iskey=""true"" value=""GrandTotalCell"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""HeaderGroupLine"" iskey=""true"" value=""HeaderGroupLine"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""Cell"" iskey=""true"" value=""Cell"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""FieldValueTotal"" iskey=""true"" value=""FieldValueTotal"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""CustomTotalCell"" iskey=""true"" value=""CustomTotalCell"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""FieldValueGrandTotal"" iskey=""true"" value=""FieldValueGrandTotal"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""Lines"" iskey=""true"" value=""Lines"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""FilterSeparator"" iskey=""true"" value=""FilterSeparator"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""FieldHeader"" iskey=""true"" value=""FieldHeader"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
  </property>
  <property name=""Fields"" iskey=""true"" value=""66"">
    <property name=""Item1"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">0</property>
      <property name=""Caption"">Antibiotics Administrated for Human Case</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_AntimicrobialTherapy</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_AntimicrobialTherapy</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""AreaIndex"">0</property>
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item2"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">1</property>
      <property name=""Caption"">Date Last Saved Human Case</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_ModificationDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_ModificationDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item3"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">2</property>
      <property name=""Caption"">Date of Completion of Paper form</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_CompletionPaperFormDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_CompletionPaperFormDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item4"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">3</property>
      <property name=""Caption"">Date of Human Case Exposure</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_ExposureDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_ExposureDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item5"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">4</property>
      <property name=""Caption"">Date of Last Patient Presence at Work</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_FacilityLastVisitDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_FacilityLastVisitDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item6"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">5</property>
      <property name=""Caption"">Date of Onset of Patient Symptoms</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_SymptomOnsetDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_SymptomOnsetDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item7"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">6</property>
      <property name=""Caption"">Date of Patient Birth</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientDOB</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientDOB</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item8"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">7</property>
      <property name=""Caption"">Date of Patient Death</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientDeathDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientDeathDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item9"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">8</property>
      <property name=""Caption"">Date of Patient Discharge</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientDischargeDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientDischargeDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item10"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">9</property>
      <property name=""Caption"">Date of Patient Hospitalization</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientHospitalizationDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientHospitalizationDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item11"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">10</property>
      <property name=""Caption"">Date Patient First Sought Care</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientFirstSoughtCareDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientFirstSoughtCareDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item12"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">11</property>
      <property name=""Caption"">Days After Human Case Notification</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_DaysAfterNotification</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_DaysAfterNotification</property>
      <property name=""ImageIndex"">2</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item13"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">12</property>
      <property name=""Caption"">Final Human Case Classification</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_FinalCaseClassification</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_FinalCaseClassification</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item14"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">13</property>
      <property name=""Caption"">Human Case Changed Diagnosis</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_ChangedDiagnosis</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_ChangedDiagnosis</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item15"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">14</property>
      <property name=""Caption"">Human Case Changed Diagnosis Code</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_ChangedDiagnosisCode</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_ChangedDiagnosisCode</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item16"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">15</property>
      <property name=""Caption"">Human Case Changed Diagnosis Date</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_ChangedDiagnosisDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_ChangedDiagnosisDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item17"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">16</property>
      <property name=""Caption"">Human Case Classification</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Area"">ColumnArea</property>
      <property name=""Name"">fieldsflHC_CaseClassification</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_CaseClassification</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""AreaIndex"">0</property>
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""SortOrder"">Descending</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item18"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">17</property>
      <property name=""Caption"">Human Case Diagnosis</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_Diagnosis</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_Diagnosis</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item19"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">18</property>
      <property name=""Caption"">Human Case Diagnosis Code</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_DiagnosisCode</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_DiagnosisCode</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item20"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">19</property>
      <property name=""Caption"">Human Case Diagnosis Date</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_DiagnosisDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_DiagnosisDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item21"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">20</property>
      <property name=""Caption"">Human Case Entered Date</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_EnteredDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_EnteredDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item22"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Custom</property>
      <property name=""Index"">21</property>
      <property name=""Caption"">Human Case Final Diagnosis</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Area"">RowArea</property>
      <property name=""Name"">fieldsflHC_FinalDiagnosis</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_FinalDiagnosis</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""AreaIndex"">0</property>
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Width"">457</property>
    </property>
    <property name=""Item23"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">22</property>
      <property name=""Caption"">Human Case Final Diagnosis Code</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_FinalDiagnosisCode</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_FinalDiagnosisCode</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item24"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">23</property>
      <property name=""Caption"">Human Case Final Diagnosis Date</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_FinalDiagnosisDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_FinalDiagnosisDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item25"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">24</property>
      <property name=""Caption"">Human Case ID</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Area"">DataArea</property>
      <property name=""Name"">fieldsflHC_CaseID</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_CaseID</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""AreaIndex"">0</property>
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Width"">145</property>
    </property>
    <property name=""Item26"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">25</property>
      <property name=""Caption"">Human Case Local Identifier</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_LocalID</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_LocalID</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item27"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">26</property>
      <property name=""UnboundFieldName"">fieldsflHC_NotificationDate</property>
      <property name=""Caption"">Human Case Notification Date</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Area"">ColumnArea</property>
      <property name=""Name"">fieldsflHC_NotificationDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_NotificationDate</property>
      <property name=""GroupInterval"">DateMonth</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""AreaIndex"">0</property>
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Width"">78</property>
    </property>
    <property name=""Item28"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">27</property>
      <property name=""Caption"">Human Case Notification Received By Facility</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_ReceivedByOffice</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_ReceivedByOffice</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item29"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">28</property>
      <property name=""Caption"">Human Case Notification Received By Officer</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_ReceivedByPerson</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_ReceivedByPerson</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item30"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">29</property>
      <property name=""Caption"">Human Case Notification Sent By Facility</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_SentByOffice</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_SentByOffice</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item31"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">30</property>
      <property name=""Caption"">Human Case Notification Sent By Officer</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_SentByPerson</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_SentByPerson</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item32"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">31</property>
      <property name=""Caption"">Human Case Outcome</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_Outcome</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_Outcome</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item33"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">32</property>
      <property name=""Caption"">Human Case Patient Age Group</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Area"">ColumnArea</property>
      <property name=""Name"">fieldsflHC_PatientAgeGroup</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientAgeGroup</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""AreaIndex"">0</property>
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item34"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">33</property>
      <property name=""Caption"">Human Case Related to Outbreak</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_RelatedToOutbreak</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_RelatedToOutbreak</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item35"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">34</property>
      <property name=""Caption"">Human Case Starting Investigation Date</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""CellFormat"" isnull=""true"" iskey=""true"">
        <property name=""FormatString"" />
        <property name=""FormatType"">DateTime</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_InvestigationStartDate</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_InvestigationStartDate</property>
      <property name=""ImageIndex"">7</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item36"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">35</property>
      <property name=""Caption"">Human Case Status</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_CaseProgressStatus</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_CaseProgressStatus</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item37"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">36</property>
      <property name=""Caption"">Initial Human Case Classification</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_InitialCaseClassification</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_InitialCaseClassification</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item38"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">37</property>
      <property name=""Caption"">Location of Human Case Exposure - Coordinates</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_LocationCoordinates</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_LocationCoordinates</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item39"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">38</property>
      <property name=""Caption"">Location of Human Case Exposure - Rayon</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_LocationRayon</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_LocationRayon</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item40"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">39</property>
      <property name=""Caption"">Location of Human Case Exposure - Region</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_LocationRegion</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_LocationRegion</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item41"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">40</property>
      <property name=""Caption"">Location of Human Case Exposure - Settlement</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_LocationSettlement</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_LocationSettlement</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item42"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">41</property>
      <property name=""Caption"">Name of Patient Location at Time of Notification</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_CurrentLocation</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_CurrentLocation</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item43"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">42</property>
      <property name=""Caption"">Organization Conducting Human Case Investigation</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_InvestigatedByOffice</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_InvestigatedByOffice</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item44"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">43</property>
      <property name=""Caption"">Outbreak ID of Human Case</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_OutbreakID</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_OutbreakID</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item45"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">44</property>
      <property name=""Caption"">Patient Age</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientAge</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientAge</property>
      <property name=""ImageIndex"">2</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item46"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">45</property>
      <property name=""Caption"">Patient Age Type</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientAgeType</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientAgeType</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item47"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">46</property>
      <property name=""Caption"">Patient Current Residence - Address</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientCRAddress</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientCRAddress</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item48"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">47</property>
      <property name=""Caption"">Patient Current Residence - Rayon</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Area"">RowArea</property>
      <property name=""Name"">fieldsflHC_PatientCRRayon</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientCRRayon</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""AreaIndex"">0</property>
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Width"">222</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item49"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">48</property>
      <property name=""Caption"">Patient Current Residence - Region</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Area"">RowArea</property>
      <property name=""Name"">fieldsflHC_PatientCRRegion</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientCRRegion</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""AreaIndex"">1</property>
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Width"">224</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item50"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">49</property>
      <property name=""Caption"">Patient Current Residence - Settlement</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientCRSettlement</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientCRSettlement</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item51"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">50</property>
      <property name=""Caption"">Patient Employer - Address</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientEmpAddress</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientEmpAddress</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item52"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">51</property>
      <property name=""Caption"">Patient Employer - Rayon</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientEmpRayon</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientEmpRayon</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item53"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">52</property>
      <property name=""Caption"">Patient Employer - Region</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientEmpRegion</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientEmpRegion</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item54"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">53</property>
      <property name=""Caption"">Patient Employer - Settlement</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientEmpSettlement</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientEmpSettlement</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item55"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">54</property>
      <property name=""Caption"">Patient Employer Name</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientEmployer</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientEmployer</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item56"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">55</property>
      <property name=""Caption"">Patient Employer Phone Number</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientPhone</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientPhone</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item57"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">56</property>
      <property name=""Caption"">Patient Employer Phone Number</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientEmployerPhone</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientEmployerPhone</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item58"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">57</property>
      <property name=""Caption"">Patient Hospitalization</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_Hospitalization</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_Hospitalization</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item59"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">58</property>
      <property name=""Caption"">Patient Location at Time of Notification</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_HospitalizationStatus</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_HospitalizationStatus</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item60"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">59</property>
      <property name=""Caption"">Patient Name</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientName</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientName</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item61"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">60</property>
      <property name=""Caption"">Patient Nationality/Citizenship</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientNationality</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientNationality</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item62"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">61</property>
      <property name=""Caption"">Patient Occupation</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientOccupation</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientOccupation</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item63"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">62</property>
      <property name=""Caption"">Patient Sex</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Area"">ColumnArea</property>
      <property name=""Name"">fieldsflHC_PatientSex</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientSex</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""AreaIndex"">0</property>
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Width"">73</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item64"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">63</property>
      <property name=""Caption"">Patient Status at Time of Notification</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_PatientNotificationStatus</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_PatientNotificationStatus</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item65"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">64</property>
      <property name=""Caption"">Place of Patient Hospitalization</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_HospitalizationPlace</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_HospitalizationPlace</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
    <property name=""Item66"" isnull=""true"" iskey=""true"">
      <property name=""SortBySummaryInfo"" isnull=""true"" iskey=""true"">
        <property name=""FieldComponentName"" />
        <property name=""Conditions"" iskey=""true"" value=""0"" />
      </property>
      <property name=""SummaryType"">Count</property>
      <property name=""Index"">65</property>
      <property name=""Caption"">Samples Collected for Human Case</property>
      <property name=""FilterValues"" isnull=""true"" iskey=""true"">
        <property name=""Values"">~Xtra#Array0, </property>
        <property name=""ShowBlanks"">true</property>
        <property name=""FilterType"">Excluded</property>
      </property>
      <property name=""FieldEditName"" />
      <property name=""ToolTips"" isnull=""true"" iskey=""true"">
        <property name=""ValueText"" />
        <property name=""HeaderText"" />
      </property>
      <property name=""Name"">fieldsflHC_SamplesCollected</property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""ShowButtonMode"">Default</property>
        <property name=""ShowUnboundExpressionMenu"">false</property>
        <property name=""ReadOnly"">false</property>
        <property name=""AllowEdit"">true</property>
      </property>
      <property name=""FieldName"">sflHC_SamplesCollected</property>
      <property name=""ImageIndex"">0</property>
      <property name=""CustomTotals"" iskey=""true"" value=""0"" />
      <property name=""ActualSortMode"">Default</property>
      <property name=""SummaryVariation"">None</property>
      <property name=""Visible"">false</property>
    </property>
  </property>
  <property name=""BorderStyle"">NoBorder</property>
  <property name=""Prefilter"" isnull=""true"" iskey=""true"">
    <property name=""Enabled"">true</property>
    <property name=""Criteria"">~Xtra#Base64AAEAAAD/////AQAAAAAAAAAMAgAAAFlEZXZFeHByZXNzLkRhdGEudjEwLjEsIFZlcnNpb249MTAuMS40LjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjg4ZDE3NTRkNzAwZTQ5YQUBAAAAJ0RldkV4cHJlc3MuRGF0YS5GaWx0ZXJpbmcuR3JvdXBPcGVyYXRvcgIAAAAIb3BlcmFuZHMMT3BlcmF0b3JUeXBlBAQ0RGV2RXhwcmVzcy5EYXRhLkZpbHRlcmluZy5Dcml0ZXJpYU9wZXJhdG9yQ29sbGVjdGlvbgIAAAArRGV2RXhwcmVzcy5EYXRhLkZpbHRlcmluZy5Hcm91cE9wZXJhdG9yVHlwZQIAAAACAAAACQMAAAAF/P///ytEZXZFeHByZXNzLkRhdGEuRmlsdGVyaW5nLkdyb3VwT3BlcmF0b3JUeXBlAQAAAAd2YWx1ZV9fAAgCAAAAAAAAAAUDAAAANERldkV4cHJlc3MuRGF0YS5GaWx0ZXJpbmcuQ3JpdGVyaWFPcGVyYXRvckNvbGxlY3Rpb24DAAAADUxpc3RgMStfaXRlbXMMTGlzdGAxK19zaXplD0xpc3RgMStfdmVyc2lvbgQAACxEZXZFeHByZXNzLkRhdGEuRmlsdGVyaW5nLkNyaXRlcmlhT3BlcmF0b3JbXQIAAAAICAIAAAAJBQAAAAIAAAABAAAABwUAAAAAAQAAAAQAAAAEKkRldkV4cHJlc3MuRGF0YS5GaWx0ZXJpbmcuQ3JpdGVyaWFPcGVyYXRvcgIAAAAJBgAAAAkHAAAADQIFBgAAACdEZXZFeHByZXNzLkRhdGEuRmlsdGVyaW5nLlVuYXJ5T3BlcmF0b3ICAAAAB09wZXJhbmQMT3BlcmF0b3JUeXBlBAQnRGV2RXhwcmVzcy5EYXRhLkZpbHRlcmluZy5VbmFyeU9wZXJhdG9yAgAAACtEZXZFeHByZXNzLkRhdGEuRmlsdGVyaW5nLlVuYXJ5T3BlcmF0b3JUeXBlAgAAAAIAAAAJCAAAAAX3////K0RldkV4cHJlc3MuRGF0YS5GaWx0ZXJpbmcuVW5hcnlPcGVyYXRvclR5cGUBAAAAB3ZhbHVlX18ACAIAAAADAAAABQcAAAAqRGV2RXhwcmVzcy5EYXRhLkZpbHRlcmluZy5GdW5jdGlvbk9wZXJhdG9yAgAAAAhvcGVyYW5kcwxPcGVyYXRvclR5cGUEBDREZXZFeHByZXNzLkRhdGEuRmlsdGVyaW5nLkNyaXRlcmlhT3BlcmF0b3JDb2xsZWN0aW9uAgAAAC5EZXZFeHByZXNzLkRhdGEuRmlsdGVyaW5nLkZ1bmN0aW9uT3BlcmF0b3JUeXBlAgAAAAIAAAAJCgAAAAX1////LkRldkV4cHJlc3MuRGF0YS5GaWx0ZXJpbmcuRnVuY3Rpb25PcGVyYXRvclR5cGUBAAAAB3ZhbHVlX18ACAIAAABGAAAAAQgAAAAGAAAACQwAAAAB8/////f///8EAAAAAQoAAAADAAAACQ4AAAABAAAAAQAAAAUMAAAAKURldkV4cHJlc3MuRGF0YS5GaWx0ZXJpbmcuT3BlcmFuZFByb3BlcnR5AQAAAAxwcm9wZXJ0eU5hbWUBAgAAAAYPAAAADHNmbEhDX0Nhc2VJRAcOAAAAAAEAAAAEAAAABCpEZXZFeHByZXNzLkRhdGEuRmlsdGVyaW5nLkNyaXRlcmlhT3BlcmF0b3ICAAAACRAAAAANAwEQAAAADAAAAAYRAAAAFnNmbEhDX05vdGlmaWNhdGlvbkRhdGUL</property>
  </property>
  <property name=""OptionsCustomization"" isnull=""true"" iskey=""true"">
    <property name=""AllowPrefilter"">false</property>
  </property>
  <property name=""Appearance"" isnull=""true"" iskey=""true"">
    <property name=""FieldHeader"" iskey=""true"" value=""FieldHeader"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""HeaderGroupLine"" iskey=""true"" value=""HeaderGroupLine"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""HeaderArea"" iskey=""true"" value=""HeaderArea"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""FieldValue"" iskey=""true"" value=""FieldValue"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""TotalCell"" iskey=""true"" value=""TotalCell"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""CustomTotalCell"" iskey=""true"" value=""CustomTotalCell"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""FilterSeparator"" iskey=""true"" value=""FilterSeparator"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""FieldValueTotal"" iskey=""true"" value=""FieldValueTotal"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""SelectedCell"" iskey=""true"" value=""SelectedCell"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""DataHeaderArea"" iskey=""true"" value=""DataHeaderArea"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""Cell"" iskey=""true"" value=""Cell"">
      <property name=""TextOptions"" isnull=""true"" iskey=""true"">
        <property name=""HAlignment"">Near</property>
        <property name=""WordWrap"">Wrap</property>
      </property>
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
        <property name=""UseTextOptions"">true</property>
      </property>
    </property>
    <property name=""FieldValueGrandTotal"" iskey=""true"" value=""FieldValueGrandTotal"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""HeaderFilterButtonActive"" iskey=""true"" value=""HeaderFilterButtonActive"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""ExpandButton"" iskey=""true"" value=""ExpandButton"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""ColumnHeaderArea"" iskey=""true"" value=""ColumnHeaderArea"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""Empty"" iskey=""true"" value=""Empty"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""HeaderFilterButton"" iskey=""true"" value=""HeaderFilterButton"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""FocusedCell"" iskey=""true"" value=""FocusedCell"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""Lines"" iskey=""true"" value=""Lines"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""FilterPanel"" iskey=""true"" value=""FilterPanel"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""FilterHeaderArea"" iskey=""true"" value=""FilterHeaderArea"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""GrandTotalCell"" iskey=""true"" value=""GrandTotalCell"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
    <property name=""RowHeaderArea"" iskey=""true"" value=""RowHeaderArea"">
      <property name=""Options"" isnull=""true"" iskey=""true"">
        <property name=""UseFont"">true</property>
      </property>
    </property>
  </property>
  <property name=""OptionsDataField"" isnull=""true"" iskey=""true"">
    <property name=""RowHeaderWidth"">100</property>
    <property name=""RowValueLineCount"">1</property>
    <property name=""Caption"" />
    <property name=""ColumnValueLineCount"">1</property>
    <property name=""FieldNaming"">FieldName</property>
    <property name=""Area"">None</property>
    <property name=""AreaIndex"">-1</property>
  </property>
  <property name=""Groups"" iskey=""true"" value=""0"" />
  <property name=""FormatConditions"" iskey=""true"" value=""0"" />
</XtraSerializer>";

        #endregion

        [TestInitialize]
        public void MyTestInitialize()
        {
            PresenterFactory.Init(new BaseForm());
            PresenterFactory.SharedPresenter.SharedModel.ResetReportDataCallback = () => { };
        }

        [TestMethod]
        public void TestReflection()
        {
            using (var pivotGrid = new RamPivotGrid())
            {
                using (var webPivotGrid = new WebPivotGrid())
                {
                    using (var stream = new MemoryStream())
                    {
                        using (var streamWriter = new StreamWriter(stream))
                        {
                            streamWriter.Write(LayoutXml);
                            streamWriter.Flush();
                            stream.Position = 0;
                            pivotGrid.RestoreLayoutFromStream(stream);
                        }
                    }

                    using (webPivotGrid.BeginTransaction())
                    {
                        webPivotGrid.DataSource = null;
                        webPivotGrid.Fields.ClearAndDispose();

                        var fieldList = new List<WinPivotGridField>();
                        try
                        {
                            foreach (WinPivotGridField field in pivotGrid.Fields)
                            {
                                var newField = new PivotGridField();
                                ReflectionHelper.CopyCommonProperties(field, newField);
                                fieldList.Add(field);

//                        WinPivotGridField newField = ReflectionHelper.CreateAndCopyProperties(field);
//                        webPivotGrid.Fields.Add(newField);
                            }
                            // datasource of report is set equal to datasource of pivot while copy properties
                            ReflectionHelper.CopyCommonProperties(pivotGrid, webPivotGrid,
                                                                  new List<string> {"DataSource", "Fields"});

                            ReflectionHelper.CopyCommonProperties(pivotGrid.OptionsView, webPivotGrid.OptionsView);
                            ReflectionHelper.CopyCommonProperties(pivotGrid.OptionsData, webPivotGrid.OptionsData);
                            ReflectionHelper.CopyCommonProperties(pivotGrid.OptionsDataField, webPivotGrid.OptionsDataField);
                            ReflectionHelper.CopyCommonProperties(pivotGrid.OptionsLayout, webPivotGrid.OptionsLayout);
                        }
                        catch (Exception ex)
                        {
                            throw new RamException("Cannot import source from pivotGrid to report", ex);
                        }

                        webPivotGrid.CriteriaString = pivotGrid.CriteriaString;
                        //webPivotGrid.Appearance.Cell.TextOptions.HAlignment = HorzAlignment.Near;
                        fieldList.Sort((x, y) => Comparer<int>.Default.Compare(x.AreaIndex, y.AreaIndex));
                        foreach (WinPivotGridField field in fieldList)
                        {
                            PivotGridField reportField = webPivotGrid.Fields[field.FieldName];
                            reportField.AreaIndex = field.AreaIndex;
                        }
                    }
                }
            }
        }
    }
}