using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using bv.common.Configuration;
using bv.common.Core;
using bv.common.db;
using bv.common.db.Core;
using bv.common.Diagnostics;
using bv.common.Resources;
using bv.winclient.Core;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;
using EIDSS;
using eidss.avr.QueryBuilder;
using EIDSS.Core;
using EIDSS.Enums;
using eidss.model.AVR.Db;

namespace eidss.avr.FilterForm
{
    public class FilterControlBase : FilterControl
    {
        protected readonly Dictionary<string, FilterFieldInfo> m_FieldInfo = new Dictionary<string, FilterFieldInfo>();
        //protected readonly Dictionary<string, string> m_FieldCaption2Alias = new Dictionary<string, string>();

        protected static DataView m_SearchFieldsLookupView;
        public event FilterChangedEventHandler OnFilterChanged;
        private static RepositoryItemDateEdit m_DateEdit;

        protected static RepositoryItemDateEdit DefaultDateEditor
        {
            get
            {
                if (m_DateEdit == null)
                {
                    m_DateEdit = new RepositoryItemDateEdit { EditMask = "d" };

                    m_DateEdit.DisplayFormat.Format = CultureInfo.CurrentCulture.DateTimeFormat;
                    m_DateEdit.DisplayFormat.FormatString = "d";
                    m_DateEdit.EditFormat.Format = CultureInfo.CurrentCulture.DateTimeFormat;
                    m_DateEdit.EditFormat.FormatString = "d";
                    m_DateEdit.Mask.UseMaskAsDisplayFormat = true;
                }
                return m_DateEdit;
            }
        }

        protected static readonly RepositoryItemSpinEdit m_DefaultIntEditor = new RepositoryItemSpinEdit();
        protected static readonly RepositoryItemSpinEdit m_DefaultDoubleEditor = new RepositoryItemSpinEdit();
        protected static readonly RepositoryItemCheckEdit m_DefaultCheckEditor = new RepositoryItemCheckEdit();
        protected static readonly RepositoryItemTextEdit m_DefaultStringEditor = new RepositoryItemTextEdit();

        protected static RepositoryItem GetDefaultEditor(SearchFieldType fieldType)
        {
            switch (fieldType)
            {
                case SearchFieldType.Date:
                    return DefaultDateEditor;
                case SearchFieldType.ID:
                    return m_DefaultStringEditor;
                case SearchFieldType.Bit:
                    return m_DefaultCheckEditor;
                case SearchFieldType.Float:
                    return m_DefaultDoubleEditor;
                case SearchFieldType.Integer:
                    return m_DefaultIntEditor;
                default:
                    return m_DefaultStringEditor;
            }
        }

        protected void RaiseFilterChangedEvent(object sender, FilterChangedEventArgs e)
        {
            if (OnFilterChanged != null)
            {
                OnFilterChanged(sender, e);
            }
            HasChanges = true;
        }

        protected virtual void FilterChangedHandler(object sender, FilterChangedEventArgs e)
        {
            bool shouldRefresh = false;
            if (e.Action == FilterChangedAction.AddNode && e.CurrentNode is ClauseNode) //AddConditionNode
            {
                if (e.CurrentNode != null)
                {
                    ((ClauseNode)e.CurrentNode).Operation = ClauseType.Equals;
                    shouldRefresh = true;
                }
            }
            if (e.Action == FilterChangedAction.FieldNameChange)
            {
                if (e.CurrentNode != null)
                {
                    foreach (CriteriaOperator op in ((ClauseNode)e.CurrentNode).AdditionalOperands)
                    {
                        var operandValue = op as OperandValue;
                        if (!ReferenceEquals(operandValue, null))
                        {
                            (operandValue).Value = null;
                        }
                    }
                    //TODO(mike): find how to correct this
                    //if(!((ClauseNode)e.CurrentNode).Model.IsValidClause(((ClauseNode)e.CurrentNode).Operation,  ((ClauseNode)e.CurrentNode).) )
                    //    ((ClauseNode)e.CurrentNode).Operation = ClauseType.Equals;
                    shouldRefresh = true;
                }
            }
            if (e.Action == FilterChangedAction.ValueChanged)
            {
                if (e.CurrentNode != null)
                {
                    foreach (CriteriaOperator op in ((ClauseNode)e.CurrentNode).AdditionalOperands)
                    {
                        if (op is OperandValue && ((OperandValue)op).Value != null
                            && Utils.Str(((OperandValue)op).Value) == "")
                        {
                            ((OperandValue)op).Value = null;
                        }
                    }
                    shouldRefresh = true;
                }
            }

            if (shouldRefresh)
            {
                //TODO (Mike): is it needed here now?
                ((FilterControl)sender).Model.RebuildElements(); // RefreshNodes();
            }
            RaiseFilterChangedEvent(sender, e);
        }

        protected override void Dispose(bool disposing)
        {
            if (MenuManager != null)
            {
                VisibleChanged -= FilterControlVisibleChanged;
            }
            var menuManager = MenuManager as BarManager;
            FilterCriteria = null;
            MenuManager = null;
            SourceControl = null;
            if (menuManager != null)
            {
                if (menuManager.Controller != null)
                {
                    menuManager.Controller.Dispose();
                }
                menuManager.Form = null;
                menuManager.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitMenuManager()
        {
            InitSearchFieldsLookupView();
            var menuManager = new BarManager();
            VisibleChanged += FilterControlVisibleChanged;
            Form form = FindForm();
            if (form != null)
            {
                menuManager.Form = FindForm();
                menuManager.Controller = new BarAndDockingController();
                menuManager.Controller.AppearancesBar.ItemsFont = WinClientContext.CurrentFont;
            }
            MenuManager = menuManager;
        }

        public void Init()
        {
            InitMenuManager();
        }

        private void FilterControlVisibleChanged(object sender, EventArgs e)
        {
        }

        private static void InitSearchFieldsLookupView()
        {
            m_SearchFieldsLookupView = QueryHelper.CreateSearchFieldsLookupView(LookupCache.Get(LookupTables.SearchField));
        }

        #region Public Properties

        //public string FilterString
        //{
        //    get { return GetFilterText(FilterCriteria, null, " "); }
        //    // (m_FilterControl == null) ? "" : m_FilterControl.FilterString;
        //}

        public string[] FilterLines
        {
            get
            {
                CriteriaOperator op = FilterCriteria;
                string s = GetFilterText(op, null, "\r");
                if (s != null)
                {
                    return s.Split('\r');
                }
                return new string[] { };
            }
            // (m_FilterControl == null) ? "" : m_FilterControl.FilterString;
        }

        public bool HasChanges { get; set; }

        private HACode m_ObjectHaCode = HACode.None;

        public virtual HACode ObjectHACode
        {
            get { return m_ObjectHaCode; }
            set { m_ObjectHaCode = value; }
        }

        #endregion

        public string GetFilterText(CriteriaOperator op, CriteriaOperator fieldOp, string conditionSeparator)
        {
            if (ReferenceEquals(op, null))
            {
                return "";
            }
            switch (op.GetType().Name)
            {
                case "GroupOperator":
                    var groupOp = (GroupOperator)op;
                    string groupText = "";
                    foreach (CriteriaOperator childOp in groupOp.Operands)
                    {
                        if (groupText == "")
                        {
                            groupText = string.Format("{0}", GetFilterText(childOp, null, conditionSeparator));
                        }
                        else
                        {
                            string groupOperatorText = "StringId." + (groupOp.OperatorType == GroupOperatorType.And
                                ? StringId.FilterGroupAnd.ToString()
                                : StringId.FilterGroupOr.ToString());

                            groupText = string.Format("{0} {1}{2}{3}", groupText,
                                XtraStrings.Get(groupOperatorText, groupOperatorText),
                                conditionSeparator,
                                GetFilterText(childOp, null, conditionSeparator));
                        }
                    }
                    return groupOp.Operands.Count == 1 ? groupText : string.Format("({0})", groupText);
                case "UnaryOperator":
                    var unaryOp = (UnaryOperator)op;
                    string unaryOpType =
                        XtraStrings.Get("StringId.FilterCriteriaToStringUnaryOperator" + unaryOp.OperatorType, null);
                    return unaryOp.OperatorType == UnaryOperatorType.IsNull
                        ? string.Format("{1} {0}", unaryOpType,
                            GetFilterText(unaryOp.Operand, null, conditionSeparator))
                        : string.Format("{0} {1}", unaryOpType,
                            GetFilterText(unaryOp.Operand, null, conditionSeparator));
                case "BinaryOperator":
                    var binaryOp = (BinaryOperator)op;
                    string opType =
                        XtraStrings.Get("StringId.FilterCriteriaToStringBinaryOperator" + binaryOp.OperatorType, null);
                    return string.Format("{0} {1} {2}", GetFilterText(binaryOp.LeftOperand, null, conditionSeparator),
                        opType,
                        GetFilterText(binaryOp.RightOperand, binaryOp.LeftOperand, conditionSeparator));
                case "OperandProperty":
                    var opField = (OperandProperty)op;
                    return GetOperandPropertyText(opField);
                case "OperandValue":
                case "ConstantValue":
                    return GetOperandValueText(fieldOp, (OperandValue)op);
                case "AggregateOperand":
                    var aggrOp = (AggregateOperand)op;
                    string existText =
                        XtraStrings.Get("StringId.FilterAggregateExists", null);
                    return string.Format("{0} {1} {2} ({3})", aggrOp.CollectionProperty.PropertyName,
                        existText, BvMessages.Get("WhereCondition"), GetFilterText(aggrOp.Condition, null, conditionSeparator));
                default:
                    var @operator = op as FunctionOperator;
                    if (!ReferenceEquals(@operator, null))
                    {
                        FunctionOperator functionOp = @operator;
                        string functionOpType =
                            functionOp.OperatorType == FunctionOperatorType.Contains
                                ? XtraStrings.Get("StringId.FilterClauseContains", null)
                                : XtraStrings.Get("StringId.FilterCriteriaToStringFunction" + functionOp.OperatorType, null);
                        if (functionOp.Operands.Count == 2)
                        {
                            return string.Format("{0} {1} {2}", GetOperandPropertyText((OperandProperty)functionOp.Operands[0]),
                                functionOpType, functionOp.Operands[1]);
                        }
                        return string.Format("{0} {1}", GetOperandPropertyText((OperandProperty)functionOp.Operands[0]),
                            functionOpType);
                    }
                    Dbg.Fail("unexpected criteria operator {0}", op.GetType().Name);
                    break;
            }
            return "";
        }

        protected virtual string GetOperandPropertyText(OperandProperty op)
        {
            return null;
        }

        private string GetOperandValueText(CriteriaOperator opField, OperandValue opValue)
        {
            if (!ReferenceEquals(opField, null))
            {
                var opFieldName = opField as OperandProperty;
                if (!ReferenceEquals(opFieldName, null))
                {
                    RepositoryItemLookUpEditBase editor = GetFieldLookupEditor(opFieldName.PropertyName);
                    if (editor != null)
                    {
                        string displayMember = editor.DisplayMember;
                        string valueMember = editor.ValueMember;
                        var dv = editor.DataSource as DataView;
                        if (dv == null)
                        {
                            return "";
                        }
                        long value = -1;
                        if (!Utils.IsEmpty(opValue.Value))
                        {
                            value = (long)Convert.ChangeType(opValue.Value, typeof(long));
                        }
                        DataRow[] rows = dv.Table.Select(string.Format("{0}={1}", valueMember,
                            value));
                        if (rows.Length == 1)
                        {
                            return string.Format("'{0}'", Utils.Str(rows[0][displayMember]));
                        }

                        return string.Format("'{0}'", Utils.Str(opValue.Value));
                        //string savedFilter = dv.RowFilter;
                        //dv.RowFilter = string.Format("{0}={1}", valueMember,
                        //                             value);
                        //string val = Utils.Str(opValue.Value);
                        //if (dv.Count == 1)
                        //{
                        //    val = Utils.Str(dv[0][displayMember]);
                        //}
                        //dv.RowFilter = savedFilter;
                        //return string.Format("'{0}'", val);
                    }
                }
            }
            //if (m_DataSourceType == DataSourceType.PivotGrid)
            //    return string.Format("'{0}'", GetPivotFieldTextValue(((OperandProperty)opField).PropertyName, opValue.Value));
            if (opValue.Value is string)
            {
                return string.Format("'{0}'", opValue.Value);
            }
            if (opValue.Value is DateTime)
            {
                return ((DateTime)opValue.Value).ToString("d");
            }
            return opValue.LegacyToString();
        }

        public virtual RepositoryItemLookUpEditBase GetFieldLookupEditor(string fieldNameAlias)
        {
            return null;
        }

        protected static SearchFieldType ParamType2FieldType(object paramType)
        {
            if (paramType == DBNull.Value)
            {
                return SearchFieldType.String;
            }
            switch ((long)paramType)
            {
                case (long)ParameterType.Boolean:
                    return SearchFieldType.Bit;
                case (long)ParameterType.Date:
                case (long)ParameterType.DateTime:
                    return SearchFieldType.Date;
                case (long)ParameterType.Numeric:
                    return SearchFieldType.Float;
                case (long)ParameterType.NumericInteger:
                case (long)ParameterType.NumericNatural:
                case (long)ParameterType.NumericPositive:
                    return SearchFieldType.Integer;
                default:
                    return SearchFieldType.String;
            }
        }

        protected static void LookupEditor_Enter(object sender, EventArgs e)
        {
            ((PopupBaseEdit)sender).Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        protected void BindFFFixedValueLookup(RepositoryItemLookUpEdit cb, object paramType, string valueMember)
        {
            Dbg.Assert(paramType != DBNull.Value, "parameter type is not defined for FF field");
            LookupBinder.BindParametersFixedPresetValueRepositoryLookup(cb, false);
            cb.ValueMember = valueMember;
            var dvValue = (LookupCacheDataView)cb.DataSource;
            dvValue.DefaultFilter = string.Format("idfsParameterType = {0} and idfsParameterFixedPresetValue <> {1} ",
                paramType, LookupCache.EmptyLineKey);
            dvValue.RowFilter = dvValue.DefaultFilter;
            dvValue.Sort = valueMember;
        }

        protected void BindBaseValueLookup(RepositoryItemLookUpEdit cb, long refType, HACode haCode, string valueMember)
        {
            //Dbg.Assert(refType != DBNull.Value, "reference type is not defined for lookup field");
            LookupBinder.BindBaseRepositoryLookup(cb, (BaseReferenceType)refType, haCode, false);
            cb.ValueMember = valueMember;
            var dvValue = (DataView)cb.DataSource;
            dvValue.Sort = "name";
        }

        protected RepositoryItem GetLookupEditor(DataRow searchFieldRow, string valueMember)
        {
            object referenceType = LookupCache.GetLookupValue(searchFieldRow["idfsSearchField"],
                LookupTables.SearchField, "idfsReferenceType");
            object gisReferenceType = LookupCache.GetLookupValue(searchFieldRow["idfsSearchField"],
                LookupTables.SearchField, "idfsGISReferenceType");
            object lookupType = LookupCache.GetLookupValue(searchFieldRow["idfsSearchField"], LookupTables.SearchField,
                "strLookupTable");
            RepositoryItem cb;
            if (IsTreeListLookup(Utils.Str(lookupType)))
            {
                cb = new RepositoryItemTreeListLookUpEdit();
            }
            else
            {
                cb = new RepositoryItemLookUpEdit();
            }
            cb.Enter += LookupEditor_Enter;
            if (IsTreeListLookup(Utils.Str(lookupType)))
            {
                BindTreeListLookup(cb as RepositoryItemTreeListLookUpEdit, Utils.Str(lookupType));
            }
            else if (!Utils.IsEmpty(lookupType) && !Utils.Str(lookupType).StartsWith("rft"))
            {
                BindSpecialLookup(cb as RepositoryItemLookUpEdit, lookupType.ToString());
            }
            else if (!Utils.IsEmpty(referenceType))
            {
                BindBaseValueLookup(cb as RepositoryItemLookUpEdit, Convert.ToInt64(referenceType), ObjectHACode, valueMember);
            }
            else if (!Utils.IsEmpty(gisReferenceType))
            {
                BindBaseValueLookup(cb as RepositoryItemLookUpEdit, Convert.ToInt64(gisReferenceType), ObjectHACode, valueMember);
            }
            return cb;
        }

        private void BindTreeListLookup(RepositoryItemTreeListLookUpEdit cb, string lookupType)
        {
            string valueMember = GetValueMemberForSpecialLookup(lookupType);
            switch (lookupType)
            {
                case "DiagnosesAndGroups":
                    LookupBinder.BindDiagnosisTreeRepositoryLookup(cb, Parent);
                    cb.ValueMember = valueMember;
                    break;
            }
        }

        private bool IsTreeListLookup(string lookupType)
        {
            return LookupTables.DiagnosesAndGroups.ToString().Equals(lookupType);
        }

        private static readonly FilterValueHash m_ValueHash = new FilterValueHash();

        public static FilterValueHash ValueHash
        {
            get { return m_ValueHash; }
        }

        protected virtual string GetValueMemberForSpecialLookup(string type)
        {
            return "idfsReference";
        }

        protected void BindSpecialLookup(RepositoryItemLookUpEdit cb, string type)
        {
            string valueMember = GetValueMemberForSpecialLookup(type);
            switch (type)
            {
                case "Country":
                    if (m_ValueHash[GisRefereneceType.Country] == null)
                    {
                        m_ValueHash[GisRefereneceType.Country] = LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Country,
                            valueMember);
                    }
                    else
                    {
                        LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Country, valueMember,
                            m_ValueHash[GisRefereneceType.Country]);
                    }
                    break;
                case "Region":
                    if (m_ValueHash[GisRefereneceType.Region] == null)
                    {
                        m_ValueHash[GisRefereneceType.Region] = LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Region,
                            valueMember);
                    }
                    else
                    {
                        LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Region, valueMember,
                            m_ValueHash[GisRefereneceType.Region]);
                    }

                    break;
                case "Rayon":
                    if (m_ValueHash[GisRefereneceType.Rayon] == null)
                    {
                        m_ValueHash[GisRefereneceType.Rayon] = LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Rayon,
                            valueMember);
                    }
                    else
                    {
                        LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Rayon, valueMember,
                            m_ValueHash[GisRefereneceType.Rayon]);
                    }
                    break;
                case "Settlement":
                    if (m_ValueHash[GisRefereneceType.Settlement] == null)
                    {
                        m_ValueHash[GisRefereneceType.Settlement] = LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Settlement,
                            valueMember);
                    }
                    else
                    {
                        LookupBinder.BindAVRGisRepositoryLookup(cb, GisRefereneceType.Settlement, valueMember,
                            m_ValueHash[GisRefereneceType.Settlement]);
                    }
                    break;
                case "Organization":
                    LookupBinder.BindOrganizationRepositoryLookup(cb, valueMember, ObjectHACode);
                    cb.ValueMember = valueMember; // "idfsOffice_Name";
                    break;
                case "Site":
                    LookupBinder.BindSiteRepositoryLookup(cb);
                    cb.ValueMember = valueMember; // "idfsOfficeAbbreviation";
                    break;
                case "AnimalAgeList":
                    LookupBinder.BindAnimalAgeRepositoryLookup(cb, false);
                    cb.ValueMember = valueMember;
                    break;
                case "HumanStandardDiagnosis":
                    LookupBinder.BindDiagnosisHACodeRepositoryLookup(cb, LookupTables.HumanStandardDiagnosis, true, false);
                    cb.ValueMember = valueMember;
                    break;
                case "HumanVetDiagnoses":
                    LookupBinder.BindDiagnosisHACodeRepositoryLookup(cb, LookupTables.HumanVetDiagnoses, true, false);
                    cb.ValueMember = valueMember;
                    break;
                case "VetStandardDiagnosis":
                    LookupBinder.BindDiagnosisHACodeRepositoryLookup(cb, LookupTables.VetStandardDiagnosis, true, false);
                    cb.ValueMember = valueMember;
                    break;
                case "PensideTestType":
                    LookupBinder.BindBaseRepositoryLookup(cb, BaseReferenceType.rftPensideTestType, false);
                    cb.ValueMember = valueMember;
                    break;
                case "TestResult":
                    LookupBinder.BindBaseRepositoryLookup(cb, BaseReferenceType.rftTestResult, false);
                    cb.ValueMember = valueMember;
                    break;
                case "CaseType":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.CaseType, false);
                    cb.ValueMember = valueMember;
                    break;
                case "FinalCaseClassification":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.FinalCaseClassification, false);
                    cb.ValueMember = valueMember;
                    break;

                case "InitialCaseClassification":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.InitialCaseClassification, false);
                    cb.ValueMember = valueMember;
                    break;
                case "ZoonoticDiagnosis":
                    LookupBinder.BindDiagnosisHACodeRepositoryLookup(cb, LookupTables.ZoonoticDiagnosis, true, false);
                    cb.ValueMember = valueMember;
                    break;
                case "CDCAgeGroup":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.CDCAgeGroup, false);
                    cb.ValueMember = valueMember;
                    break;
                case "WHOAgeGroup":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.WHOAgeGroup, false);
                    cb.ValueMember = valueMember;
                    break;
                case "DiagnosisAgeGroup":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.DiagnosisAgeGroup, false);
                    cb.ValueMember = valueMember;
                    break;
                case "DiagnosesAndGroups":
                    LookupBinder.BindDiagnosisAndGroupsRepositoryLookup(cb, false);
                    cb.ValueMember = valueMember;
                    break;
                case "AccessoryCode":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.AccessoryCode, false, valueMember);
                    //LookupBinder.BindRepositoryAvrFarmTypeLookup(cb);
                    break;
                case "HumanAggregateCaseParameter":
                    LookupBinder.BindStandardRepositoryLookup(cb, LookupTables.HumanAggregateCaseParameter, false, valueMember);
                    break;
                case "VectorSubType":
                    LookupBinder.BindBaseRepositoryLookup(cb, BaseReferenceType.rftVectorSubType, false);
                    break;
                case "HumanAggregatedDiagnosis":
                    LookupBinder.BindDiagnosisHACodeRepositoryLookup(cb, LookupTables.HumanAggregatedDiagnosis, true, false);
                    cb.ValueMember = valueMember;
                    break;
                case "VectorDiagnosis":
                    LookupBinder.BindDiagnosisHACodeRepositoryLookup(cb, LookupTables.VectorDiagnosis, true, false);
                    cb.ValueMember = valueMember;
                    break;
                default:
                    Dbg.Fail("unsupported lookup type ({0}) for filter editor", type);
                    break;
            }

            if (cb != null)
            {
                RemoveAdditionalButtons(cb);
            }
        }

        protected static void RemoveAdditionalButtons(RepositoryItemButtonEdit cb)
        {
            for (int i = cb.Buttons.Count - 1; i >= 0; i--)
            {
                if (cb.Buttons[i].Kind == ButtonPredefines.Plus)
                {
                    cb.Buttons.RemoveAt(i);
                    break;
                }
            }
        }

        protected FilterFieldInfo GetFieldInfoByFieldAliasName(string fieldAliasName)
        {
            if (m_FieldInfo.ContainsKey((fieldAliasName)))
            {
                return m_FieldInfo[fieldAliasName];
            }
            return null;
        }

        public virtual void RefreshNodes()
        {
            DeleteNodesWithAbsentFields();
        }

        private readonly Dictionary<CriteriaOperator, GroupOperator> m_NodesToDelete =
            new Dictionary<CriteriaOperator, GroupOperator>();

        protected void DeleteNodesWithAbsentFields()
        {
            m_NodesToDelete.Clear();
            CriteriaOperator opreatorsCopy = FilterCriteria;
            FindInvalidNodes(opreatorsCopy);

            while (m_NodesToDelete.Count > 0)
            {
                foreach (CriteriaOperator op in m_NodesToDelete.Keys)
                {
                    if (ReferenceEquals(m_NodesToDelete[op], null))
                    {
                        opreatorsCopy = null;
                    }
                    else
                    {
                        m_NodesToDelete[op].Operands.Remove(op);
                    }
                }
                FilterCriteria = opreatorsCopy;
                RaiseFilterChangedEvent(this, new FilterChangedEventArgs(FilterChangedAction.RemoveNode, null));

                m_NodesToDelete.Clear();
                opreatorsCopy = FilterCriteria;
                FindInvalidNodes(opreatorsCopy);
            }
        }

        protected void FindInvalidNodes(CriteriaOperator op)
        {
            if (ReferenceEquals(op, null))
            {
                return;
            }
            if (op is UnaryOperator && ((UnaryOperator)op).OperatorType == UnaryOperatorType.Not &&
                (((UnaryOperator)op).Operand is GroupOperator || ((UnaryOperator)op).Operand is AggregateOperand))
            {
                op = ((UnaryOperator)op).Operand;
            }

            //Now operator can be of 3 types: Aggregate, Group and Binary (with usual field condition)

            //We can get this condition for child node of group operator
            //Fields related with aggregate operand are always persented in search object
            //So we ignore ranch of aggregate operand nodes here and return from recursive method call
            if (op is AggregateOperand)
            {
                return;
            }
            //Usual field shall be validated
            if (!(op is GroupOperator))
            {
                if ((!IsNodeValid(op)) && (!m_NodesToDelete.ContainsKey(op)))
                {
                    m_NodesToDelete.Add(op, null);
                }
                return;
            }
            //Only group operator can exist here
            var parentGroupOp = (GroupOperator)op;
            foreach (CriteriaOperator child in parentGroupOp.Operands)
            {
                if (child is UnaryOperator && ((UnaryOperator)child).OperatorType == UnaryOperatorType.Not &&
                    (((UnaryOperator)child).Operand is GroupOperator || ((UnaryOperator)child).Operand is AggregateOperand))
                {
                    FindInvalidNodes(child);
                    continue;
                }
                var groupOp = child as GroupOperator;
                if (ReferenceEquals(groupOp, null))
                {
                    if ((!IsNodeValid(child)) && (!m_NodesToDelete.ContainsKey(child)))
                    {
                        m_NodesToDelete.Add(child, parentGroupOp);
                    }
                }
                else
                {
                    FindInvalidNodes(groupOp);
                }
            }
        }

        protected virtual bool IsNodeValid(CriteriaOperator node)
        {
            return true;
        }

        protected RepositoryItem GetFFFieldEditor(DataRow paramRow, DataRow searchFieldRow, out SearchFieldType fieldType)
        {
            object paramType = paramRow["idfsParameterType"];
            object referenceType = paramRow["idfsReferenceType"];
            bool isLookupField = false;
            if (!Utils.IsEmpty(referenceType))
            {
                isLookupField = true;
                fieldType = SearchFieldType.ID;
            }
            else
            {
                fieldType = ParamType2FieldType(paramType);
            }

            RepositoryItem cb = null;
            if (isLookupField)
            {
                cb = new RepositoryItemLookUpEdit();
                cb.Enter += LookupEditor_Enter;
                string valueMember;
                if (referenceType.Equals((long)model.Enums.BaseReferenceType.rftParametersFixedPresetValue))
                {
                    valueMember = GetValueMemberForFFFixedPresetValue();
                    BindFFFixedValueLookup((RepositoryItemLookUpEdit)cb, paramType, valueMember);
                }
                else
                {
                    valueMember = GetValueMemberForBaseLookup();
                    BindBaseValueLookup((RepositoryItemLookUpEdit)cb, (long)referenceType, ObjectHACode,
                        valueMember);
                }
            }
            return cb;
        }

        protected virtual string GetValueMemberForBaseLookup()
        {
            return "";
        }

        protected virtual string GetValueMemberForFFFixedPresetValue()
        {
            return "";
        }

        protected static bool IsLookupField(DataRow searchFieldRow, bool isFlexibleFormField = false)
        {
            if (isFlexibleFormField)
            {
                return (!Utils.IsEmpty(searchFieldRow["idfsReferenceType"]));
            }
            return !Utils.IsEmpty(searchFieldRow["idfsReferenceType"]) |
                   !Utils.IsEmpty(searchFieldRow["idfsGISReferenceType"]) |
                   !Utils.IsEmpty(searchFieldRow["strLookupTable"]);
        }

        public bool Validate(bool showErrorForm = true)
        {
            PropertyInfo pi = typeof(FilterControl).GetProperty("FocusInfo",
                BindingFlags.Instance |
                BindingFlags.NonPublic);
            var focus = (FilterControlFocusInfo)pi.GetValue(this, null);
            if (focus.Node == null)
            {
                return true;
            }
            INode rootNode = focus.Node;
            while (rootNode.ParentNode != null)
            {
                rootNode = (Node)rootNode.ParentNode;
            }
            var groupNode = rootNode as GroupNode;
            if (groupNode != null)
            {
                rootNode = groupNode.RootNode;
            }
            return ValidateNode((Node)rootNode, showErrorForm);
        }

        private bool ValidateNode(Node node, bool showErrorMessage)
        {
            var aggrNode = node as AggregateNode;
            if (aggrNode != null)
            {
                if (Utils.IsEmpty(aggrNode.Property.DisplayName))
                {
                    const string err = @"Filter criteria field name can't be empty";
                    if (BaseSettings.ThrowExceptionOnError)
                    {
                        throw new AvrException(err);
                    }

                    ErrorForm.ShowError("ErrUndefinedFilterField", err);
                    PropertyInfo pi = typeof(FilterControl).GetProperty("FocusInfo",
                        BindingFlags.Instance |
                        BindingFlags.NonPublic);
                    pi.SetValue(this, new FilterControlFocusInfo(node, 1), null);
                    return false;
                }
                IEnumerable<Node> nodes = (aggrNode).GetChildren().Cast<Node>();
                return nodes.All(child => ValidateNode(child, showErrorMessage));
            }
            var clauseNode = node as ClauseNode;
            if (clauseNode != null)
            {
                if (Utils.IsEmpty(clauseNode.FirstOperand.PropertyName))
                {
                    const string err = @"Filter criteria field name can't be empty";
                    if (BaseSettings.ThrowExceptionOnError)
                    {
                        throw new AvrException(err);
                    }

                    ErrorForm.ShowError("ErrUndefinedFilterField", err);
                    PropertyInfo pi = typeof(FilterControl).GetProperty("FocusInfo",
                        BindingFlags.Instance |
                        BindingFlags.NonPublic);
                    pi.SetValue(this, new FilterControlFocusInfo(node, 1), null);
                    return false;
                }
                foreach (CriteriaOperator op in clauseNode.AdditionalOperands)
                {
                    if (ValidateOperator(op) == false)
                    {
                        if (showErrorMessage)
                        {
                            string fieldCaption = GetFieldInfoByFieldAliasName(clauseNode.FirstOperand.PropertyName).Caption;
                            string err = string.Format("Filter criteria value for [{0}] field can't be empty",
                                fieldCaption);
                            if (BaseSettings.ThrowExceptionOnError)
                            {
                                throw new AvrException(err);
                            }

                            ErrorForm.ShowWarningFormat("ErrFilterValidatioError", "Filter criteria value for [{0}] field can't be empty",
                                fieldCaption);

                            PropertyInfo pi = typeof(FilterControl).GetProperty("FocusInfo",
                                BindingFlags.Instance |
                                BindingFlags.NonPublic);
                            pi.SetValue(this, new FilterControlFocusInfo(node, 2), null);
                        }
                        return false;
                    }
                }
                return true;
            }
            var groupNode = node as GroupNode;
            if (groupNode != null)
            {
                IEnumerable<Node> nodes = (groupNode).SubNodes.Cast<Node>();
                return nodes.All(child => ValidateNode(child, showErrorMessage));
            }
            return true;
        }

        private static bool ValidateOperator(CriteriaOperator op)
        {
            var @operator = op as GroupOperator;
            if (!ReferenceEquals(@operator, null))
            {
                CriteriaOperatorCollection operands = @operator.Operands;
                return operands.All(ValidateOperator);
            }
            var unaryOperator = op as UnaryOperator;
            if (!ReferenceEquals(unaryOperator, null))
            {
                return ValidateOperator(unaryOperator.Operand);
            }
            var binaryOperator = op as BinaryOperator;
            if (!ReferenceEquals(binaryOperator, null))
            {
                return ValidateOperator(binaryOperator.RightOperand);
            }
            var value = op as OperandValue;
            if (!ReferenceEquals(value, null))
            {
                return !Utils.IsEmpty(value.Value);
            }
            var operand = op as AggregateOperand;
            if (!ReferenceEquals(operand, null))
            {
                if (Utils.IsEmpty(operand.CollectionProperty.PropertyName))
                {
                    return false;
                }
                return ValidateOperator(operand.Condition);
            }
            return true;
        }
    }
}