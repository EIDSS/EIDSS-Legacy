#pragma warning disable 0472
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Xml.Serialization;
using BLToolkit.Aspects;
using BLToolkit.DataAccess;
using BLToolkit.EditableObjects;
using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using BLToolkit.Mapping;
using BLToolkit.Reflection;
using bv.common.Configuration;
using bv.common.Enums;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model;
using bv.model.Helpers;
using bv.model.Model.Extenders;
using bv.model.Model.Core;
using bv.model.Model.Handlers;
using bv.model.Model.Validators;
using eidss.model.Core;
using eidss.model.Enums;
		

namespace eidss.model.Schema
{
        
        
    [XmlType(AnonymousType = true)]
    public abstract partial class AggergateDeduplicationBaseListItem : 
        EditableObject<AggergateDeduplicationBaseListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfAggrCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfAggrCase { get; set; }
                
        [LocalizedDisplayName(_str_intDuplicateGroup)]
        [MapField(_str_intDuplicateGroup)]
        public abstract Int64? intDuplicateGroup { get; set; }
        protected Int64? intDuplicateGroup_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._intDuplicateGroup).OriginalValue; } }
        protected Int64? intDuplicateGroup_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._intDuplicateGroup).PreviousValue; } }
                
        [LocalizedDisplayName("strCaseID")]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStartDate)]
        [MapField(_str_datStartDate)]
        public abstract DateTime? datStartDate { get; set; }
        protected DateTime? datStartDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime? datStartDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).PreviousValue; } }
                
        [LocalizedDisplayName("idfsPeriodType")]
        [MapField(_str_strPeriodName)]
        public abstract String strPeriodName { get; set; }
        protected String strPeriodName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPeriodName).OriginalValue; } }
        protected String strPeriodName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPeriodName).PreviousValue; } }
                
        [LocalizedDisplayName("idfsRegion")]
        [MapField(_str_strRegion)]
        public abstract String strRegion { get; set; }
        protected String strRegion_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegion).OriginalValue; } }
        protected String strRegion_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegion).PreviousValue; } }
                
        [LocalizedDisplayName("idfsRayon")]
        [MapField(_str_strRayon)]
        public abstract String strRayon { get; set; }
        protected String strRayon_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayon).OriginalValue; } }
        protected String strRayon_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayon).PreviousValue; } }
                
        [LocalizedDisplayName("strSettlement")]
        [MapField(_str_strSettlement)]
        public abstract String strSettlement { get; set; }
        protected String strSettlement_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).OriginalValue; } }
        protected String strSettlement_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strInstitutionName)]
        [MapField(_str_strInstitutionName)]
        public abstract String strInstitutionName { get; set; }
        protected String strInstitutionName_Original { get { return ((EditableValue<String>)((dynamic)this)._strInstitutionName).OriginalValue; } }
        protected String strInstitutionName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strInstitutionName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datEnteredByDate)]
        [MapField(_str_datEnteredByDate)]
        public abstract DateTime? datEnteredByDate { get; set; }
        protected DateTime? datEnteredByDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredByDate).OriginalValue; } }
        protected DateTime? datEnteredByDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredByDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strMatrixName)]
        [MapField(_str_strMatrixName)]
        public abstract String strMatrixName { get; set; }
        protected String strMatrixName_Original { get { return ((EditableValue<String>)((dynamic)this)._strMatrixName).OriginalValue; } }
        protected String strMatrixName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMatrixName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strTemplateName)]
        [MapField(_str_strTemplateName)]
        public abstract String strTemplateName { get; set; }
        protected String strTemplateName_Original { get { return ((EditableValue<String>)((dynamic)this)._strTemplateName).OriginalValue; } }
        protected String strTemplateName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTemplateName).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<AggergateDeduplicationBaseListItem, object> _get_func;
            internal Action<AggergateDeduplicationBaseListItem, string> _set_func;
            internal Action<AggergateDeduplicationBaseListItem, AggergateDeduplicationBaseListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAggrCase = "idfAggrCase";
        internal const string _str_intDuplicateGroup = "intDuplicateGroup";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_strPeriodName = "strPeriodName";
        internal const string _str_strRegion = "strRegion";
        internal const string _str_strRayon = "strRayon";
        internal const string _str_strSettlement = "strSettlement";
        internal const string _str_strInstitutionName = "strInstitutionName";
        internal const string _str_datEnteredByDate = "datEnteredByDate";
        internal const string _str_strMatrixName = "strMatrixName";
        internal const string _str_strTemplateName = "strTemplateName";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfAggrCase, _formname = _str_idfAggrCase, _type = "Int64",
              _get_func = o => o.idfAggrCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfAggrCase != newval) o.idfAggrCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfAggrCase != c.idfAggrCase || o.IsRIRPropChanged(_str_idfAggrCase, c)) 
                  m.Add(_str_idfAggrCase, o.ObjectIdent + _str_idfAggrCase, o.ObjectIdent2 + _str_idfAggrCase, o.ObjectIdent3 + _str_idfAggrCase, "Int64", 
                    o.idfAggrCase == null ? "" : o.idfAggrCase.ToString(),                  
                  o.IsReadOnly(_str_idfAggrCase), o.IsInvisible(_str_idfAggrCase), o.IsRequired(_str_idfAggrCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intDuplicateGroup, _formname = _str_intDuplicateGroup, _type = "Int64?",
              _get_func = o => o.intDuplicateGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.intDuplicateGroup != newval) o.intDuplicateGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.intDuplicateGroup != c.intDuplicateGroup || o.IsRIRPropChanged(_str_intDuplicateGroup, c)) 
                  m.Add(_str_intDuplicateGroup, o.ObjectIdent + _str_intDuplicateGroup, o.ObjectIdent2 + _str_intDuplicateGroup, o.ObjectIdent3 + _str_intDuplicateGroup, "Int64?", 
                    o.intDuplicateGroup == null ? "" : o.intDuplicateGroup.ToString(),                  
                  o.IsReadOnly(_str_intDuplicateGroup), o.IsInvisible(_str_intDuplicateGroup), o.IsRequired(_str_intDuplicateGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCaseID, _formname = _str_strCaseID, _type = "String",
              _get_func = o => o.strCaseID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCaseID != newval) o.strCaseID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strCaseID != c.strCaseID || o.IsRIRPropChanged(_str_strCaseID, c)) 
                  m.Add(_str_strCaseID, o.ObjectIdent + _str_strCaseID, o.ObjectIdent2 + _str_strCaseID, o.ObjectIdent3 + _str_strCaseID, "String", 
                    o.strCaseID == null ? "" : o.strCaseID.ToString(),                  
                  o.IsReadOnly(_str_strCaseID), o.IsInvisible(_str_strCaseID), o.IsRequired(_str_strCaseID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datStartDate, _formname = _str_datStartDate, _type = "DateTime?",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datStartDate != newval) o.datStartDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, o.ObjectIdent2 + _str_datStartDate, o.ObjectIdent3 + _str_datStartDate, "DateTime?", 
                    o.datStartDate == null ? "" : o.datStartDate.ToString(),                  
                  o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPeriodName, _formname = _str_strPeriodName, _type = "String",
              _get_func = o => o.strPeriodName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPeriodName != newval) o.strPeriodName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPeriodName != c.strPeriodName || o.IsRIRPropChanged(_str_strPeriodName, c)) 
                  m.Add(_str_strPeriodName, o.ObjectIdent + _str_strPeriodName, o.ObjectIdent2 + _str_strPeriodName, o.ObjectIdent3 + _str_strPeriodName, "String", 
                    o.strPeriodName == null ? "" : o.strPeriodName.ToString(),                  
                  o.IsReadOnly(_str_strPeriodName), o.IsInvisible(_str_strPeriodName), o.IsRequired(_str_strPeriodName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRegion, _formname = _str_strRegion, _type = "String",
              _get_func = o => o.strRegion,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRegion != newval) o.strRegion = newval; },
              _compare_func = (o, c, m) => {
                if (o.strRegion != c.strRegion || o.IsRIRPropChanged(_str_strRegion, c)) 
                  m.Add(_str_strRegion, o.ObjectIdent + _str_strRegion, o.ObjectIdent2 + _str_strRegion, o.ObjectIdent3 + _str_strRegion, "String", 
                    o.strRegion == null ? "" : o.strRegion.ToString(),                  
                  o.IsReadOnly(_str_strRegion), o.IsInvisible(_str_strRegion), o.IsRequired(_str_strRegion)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRayon, _formname = _str_strRayon, _type = "String",
              _get_func = o => o.strRayon,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRayon != newval) o.strRayon = newval; },
              _compare_func = (o, c, m) => {
                if (o.strRayon != c.strRayon || o.IsRIRPropChanged(_str_strRayon, c)) 
                  m.Add(_str_strRayon, o.ObjectIdent + _str_strRayon, o.ObjectIdent2 + _str_strRayon, o.ObjectIdent3 + _str_strRayon, "String", 
                    o.strRayon == null ? "" : o.strRayon.ToString(),                  
                  o.IsReadOnly(_str_strRayon), o.IsInvisible(_str_strRayon), o.IsRequired(_str_strRayon)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSettlement, _formname = _str_strSettlement, _type = "String",
              _get_func = o => o.strSettlement,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSettlement != newval) o.strSettlement = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSettlement != c.strSettlement || o.IsRIRPropChanged(_str_strSettlement, c)) 
                  m.Add(_str_strSettlement, o.ObjectIdent + _str_strSettlement, o.ObjectIdent2 + _str_strSettlement, o.ObjectIdent3 + _str_strSettlement, "String", 
                    o.strSettlement == null ? "" : o.strSettlement.ToString(),                  
                  o.IsReadOnly(_str_strSettlement), o.IsInvisible(_str_strSettlement), o.IsRequired(_str_strSettlement)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strInstitutionName, _formname = _str_strInstitutionName, _type = "String",
              _get_func = o => o.strInstitutionName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strInstitutionName != newval) o.strInstitutionName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strInstitutionName != c.strInstitutionName || o.IsRIRPropChanged(_str_strInstitutionName, c)) 
                  m.Add(_str_strInstitutionName, o.ObjectIdent + _str_strInstitutionName, o.ObjectIdent2 + _str_strInstitutionName, o.ObjectIdent3 + _str_strInstitutionName, "String", 
                    o.strInstitutionName == null ? "" : o.strInstitutionName.ToString(),                  
                  o.IsReadOnly(_str_strInstitutionName), o.IsInvisible(_str_strInstitutionName), o.IsRequired(_str_strInstitutionName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datEnteredByDate, _formname = _str_datEnteredByDate, _type = "DateTime?",
              _get_func = o => o.datEnteredByDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datEnteredByDate != newval) o.datEnteredByDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datEnteredByDate != c.datEnteredByDate || o.IsRIRPropChanged(_str_datEnteredByDate, c)) 
                  m.Add(_str_datEnteredByDate, o.ObjectIdent + _str_datEnteredByDate, o.ObjectIdent2 + _str_datEnteredByDate, o.ObjectIdent3 + _str_datEnteredByDate, "DateTime?", 
                    o.datEnteredByDate == null ? "" : o.datEnteredByDate.ToString(),                  
                  o.IsReadOnly(_str_datEnteredByDate), o.IsInvisible(_str_datEnteredByDate), o.IsRequired(_str_datEnteredByDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strMatrixName, _formname = _str_strMatrixName, _type = "String",
              _get_func = o => o.strMatrixName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strMatrixName != newval) o.strMatrixName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strMatrixName != c.strMatrixName || o.IsRIRPropChanged(_str_strMatrixName, c)) 
                  m.Add(_str_strMatrixName, o.ObjectIdent + _str_strMatrixName, o.ObjectIdent2 + _str_strMatrixName, o.ObjectIdent3 + _str_strMatrixName, "String", 
                    o.strMatrixName == null ? "" : o.strMatrixName.ToString(),                  
                  o.IsReadOnly(_str_strMatrixName), o.IsInvisible(_str_strMatrixName), o.IsRequired(_str_strMatrixName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTemplateName, _formname = _str_strTemplateName, _type = "String",
              _get_func = o => o.strTemplateName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTemplateName != newval) o.strTemplateName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strTemplateName != c.strTemplateName || o.IsRIRPropChanged(_str_strTemplateName, c)) 
                  m.Add(_str_strTemplateName, o.ObjectIdent + _str_strTemplateName, o.ObjectIdent2 + _str_strTemplateName, o.ObjectIdent3 + _str_strTemplateName, "String", 
                    o.strTemplateName == null ? "" : o.strTemplateName.ToString(),                  
                  o.IsReadOnly(_str_strTemplateName), o.IsInvisible(_str_strTemplateName), o.IsRequired(_str_strTemplateName)); 
                  }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            AggergateDeduplicationBaseListItem obj = (AggergateDeduplicationBaseListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AggergateDeduplicationBaseListItem";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as AggergateDeduplicationBaseListItem;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as AggergateDeduplicationBaseListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AggergateDeduplicationBaseListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AggergateDeduplicationBaseListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfAggrCase; } }
        public string KeyName { get { return "idfAggrCase"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            base.RejectChanges();
        
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool ReadOnly { get { return _readOnly; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, AggergateDeduplicationBaseListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public AggergateDeduplicationBaseListItem()
        {
            
            m_permissions = new Permissions(this);
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AggergateDeduplicationBaseListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AggergateDeduplicationBaseListItem_PropertyChanged);
        }
        private void AggergateDeduplicationBaseListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AggergateDeduplicationBaseListItem).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            AggergateDeduplicationBaseListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AggergateDeduplicationBaseListItem obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ShouldAsk);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ShouldAsk);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly || new Func<AggergateDeduplicationBaseListItem, bool>(c => false)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
            }
        }


        internal Dictionary<string, Func<AggergateDeduplicationBaseListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AggergateDeduplicationBaseListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AggergateDeduplicationBaseListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AggergateDeduplicationBaseListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AggergateDeduplicationBaseListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<AggergateDeduplicationBaseListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<AggergateDeduplicationBaseListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AggergateDeduplicationBaseListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    
        #region Class for web grid
        public class AggergateDeduplicationBaseListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfAggrCase { get; set; }
        
            public Int64? intDuplicateGroup { get; set; }
        
            public String strCaseID { get; set; }
        
            public DateTime? datStartDate { get; set; }
        
            public String strPeriodName { get; set; }
        
            public String strRegion { get; set; }
        
            public String strRayon { get; set; }
        
            public String strSettlement { get; set; }
        
            public String strInstitutionName { get; set; }
        
            public DateTime? datEnteredByDate { get; set; }
        
            public String strMatrixName { get; set; }
        
            public String strTemplateName { get; set; }
        
        }
        public partial class AggergateDeduplicationBaseListItemGridModelList : List<AggergateDeduplicationBaseListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public AggergateDeduplicationBaseListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AggergateDeduplicationBaseListItem>, errMes);
            }
            public AggergateDeduplicationBaseListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AggergateDeduplicationBaseListItem>, errMes);
            }
            public AggergateDeduplicationBaseListItemGridModelList(long key, IEnumerable<AggergateDeduplicationBaseListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public AggergateDeduplicationBaseListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<AggergateDeduplicationBaseListItem>(), null);
            }
            partial void filter(List<AggergateDeduplicationBaseListItem> items);
            private void LoadGridModelList(long key, IEnumerable<AggergateDeduplicationBaseListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_intDuplicateGroup,_str_strCaseID,_str_datStartDate,_str_strPeriodName,_str_strRegion,_str_strRayon,_str_strSettlement,_str_strInstitutionName,_str_datEnteredByDate,_str_strMatrixName,_str_strTemplateName};
                    
                Hiddens = new List<string> {_str_idfAggrCase};
                Keys = new List<string> {_str_idfAggrCase};
                Labels = new Dictionary<string, string> {{_str_intDuplicateGroup, _str_intDuplicateGroup},{_str_strCaseID, "strCaseID"},{_str_datStartDate, _str_datStartDate},{_str_strPeriodName, "idfsPeriodType"},{_str_strRegion, "idfsRegion"},{_str_strRayon, "idfsRayon"},{_str_strSettlement, "strSettlement"},{_str_strInstitutionName, _str_strInstitutionName},{_str_datEnteredByDate, _str_datEnteredByDate},{_str_strMatrixName, _str_strMatrixName},{_str_strTemplateName, _str_strTemplateName}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strCaseID, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "ActionEditHumanAggregateCase")}};
                AggergateDeduplicationBaseListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<AggergateDeduplicationBaseListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AggergateDeduplicationBaseListItemGridModel()
                {
                    ItemKey=c.idfAggrCase,intDuplicateGroup=c.intDuplicateGroup,strCaseID=c.strCaseID,datStartDate=c.datStartDate,strPeriodName=c.strPeriodName,strRegion=c.strRegion,strRayon=c.strRayon,strSettlement=c.strSettlement,strInstitutionName=c.strInstitutionName,datEnteredByDate=c.datEnteredByDate,strMatrixName=c.strMatrixName,strTemplateName=c.strTemplateName
                }));
                if (Count > 0)
                {
                    this.Last().ErrorMessage = errMes;
                }
            }
        }
        #endregion
        

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<AggergateDeduplicationBaseListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<AggergateDeduplicationBaseListItem>
            
            , IObjectSelectList
            , IObjectSelectList<AggergateDeduplicationBaseListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfAggrCase"; } }
            #endregion
        
            private delegate void on_action(AggergateDeduplicationBaseListItem obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            
            public virtual List<AggergateDeduplicationBaseListItem> SelectListT(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                );
            }
            public virtual List<IObject> SelectList(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                ).Cast<IObject>().ToList();
            }
            
            private List<AggergateDeduplicationBaseListItem> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                , FilterParams filters
                , KeyValuePair<string, ListSortDirection>[] sorts
                , bool serverSort = false
                )
            {
                if (filters == null) filters = new FilterParams();
                
                var sql = new StringBuilder();
                string maxtop = BaseSettings.SelectTopMaxCount.ToString();
                sql.Append(@"select ");
                
                sql.Append(@"top ");
                sql.Append(maxtop);
                sql.Append(@" dbo.fn_AggregateCaseDeduplication_SelectList.* from dbo.fn_AggregateCaseDeduplication_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (ModelUserContext.IsWebContext && EidssSiteContext.Instance.SiteType == SiteType.TLVL)
                {
                    sql.Append(@" and exists (select * from  tflAggrCaseFiltered f inner join tflSiteToSiteGroup on tflSiteToSiteGroup.idfSiteGroup = f.idfSiteGroup and tflSiteToSiteGroup.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString() + " where f.idfAggrCase = fn_AggregateCaseDeduplication_SelectList.idfAggrCase)");
                }
                
                if (filters.Contains("idfAggrCase"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfAggrCase"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfAggrCase") ? " or " : " and ");
                        
                        if (filters.Operation("idfAggrCase", i) == "&")
                          sql.AppendFormat("(isnull(fn_AggregateCaseDeduplication_SelectList.idfAggrCase,0) {0} @idfAggrCase_{1} = @idfAggrCase_{1})", filters.Operation("idfAggrCase", i), i);
                        else
                          sql.AppendFormat("isnull(fn_AggregateCaseDeduplication_SelectList.idfAggrCase,0) {0} @idfAggrCase_{1}", filters.Operation("idfAggrCase", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intDuplicateGroup"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intDuplicateGroup"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intDuplicateGroup") ? " or " : " and ");
                        
                        if (filters.Operation("intDuplicateGroup", i) == "&")
                          sql.AppendFormat("(isnull(fn_AggregateCaseDeduplication_SelectList.intDuplicateGroup,0) {0} @intDuplicateGroup_{1} = @intDuplicateGroup_{1})", filters.Operation("intDuplicateGroup", i), i);
                        else
                          sql.AppendFormat("isnull(fn_AggregateCaseDeduplication_SelectList.intDuplicateGroup,0) {0} @intDuplicateGroup_{1}", filters.Operation("intDuplicateGroup", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCaseID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCaseID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCaseID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AggregateCaseDeduplication_SelectList.strCaseID {0} @strCaseID_{1}", filters.Operation("strCaseID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datStartDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datStartDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datStartDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_AggregateCaseDeduplication_SelectList.datStartDate, 112) {0} CONVERT(NVARCHAR(8), @datStartDate_{1}, 112)", filters.Operation("datStartDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strPeriodName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strPeriodName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strPeriodName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AggregateCaseDeduplication_SelectList.strPeriodName {0} @strPeriodName_{1}", filters.Operation("strPeriodName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strRegion"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strRegion"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strRegion") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AggregateCaseDeduplication_SelectList.strRegion {0} @strRegion_{1}", filters.Operation("strRegion", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strRayon"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strRayon"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strRayon") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AggregateCaseDeduplication_SelectList.strRayon {0} @strRayon_{1}", filters.Operation("strRayon", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSettlement"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSettlement"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSettlement") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AggregateCaseDeduplication_SelectList.strSettlement {0} @strSettlement_{1}", filters.Operation("strSettlement", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strInstitutionName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strInstitutionName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strInstitutionName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AggregateCaseDeduplication_SelectList.strInstitutionName {0} @strInstitutionName_{1}", filters.Operation("strInstitutionName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datEnteredByDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datEnteredByDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datEnteredByDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_AggregateCaseDeduplication_SelectList.datEnteredByDate, 112) {0} CONVERT(NVARCHAR(8), @datEnteredByDate_{1}, 112)", filters.Operation("datEnteredByDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strMatrixName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strMatrixName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strMatrixName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AggregateCaseDeduplication_SelectList.strMatrixName {0} @strMatrixName_{1}", filters.Operation("strMatrixName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strTemplateName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strTemplateName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strTemplateName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AggregateCaseDeduplication_SelectList.strTemplateName {0} @strTemplateName_{1}", filters.Operation("strTemplateName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (serverSort && sorts != null && sorts.Length > 0)
                {
                    sql.Append(" order by");
                    bool bFirst = true;
                    foreach(var sort in sorts)
                    {
                        sql.Append((bFirst ? " " : ", ") + sort.Key + " " + (sort.Value == ListSortDirection.Ascending ? "ASC" : "DESC"));
                        bFirst = false;
                    }
                }

                bool bTransactionStarted = false;
                try
                {
                    if (!manager.IsTransactionStarted)
                    {
                        bTransactionStarted = true;
                        manager.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                    }
                    
                    sql.Append(" option (OPTIMIZE FOR UNKNOWN)");
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("idfAggrCase"))
                        for (int i = 0; i < filters.Count("idfAggrCase"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfAggrCase_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfAggrCase", i), filters.Value("idfAggrCase", i))));
                      
                    if (filters.Contains("intDuplicateGroup"))
                        for (int i = 0; i < filters.Count("intDuplicateGroup"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intDuplicateGroup_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intDuplicateGroup", i), filters.Value("intDuplicateGroup", i))));
                      
                    if (filters.Contains("strCaseID"))
                        for (int i = 0; i < filters.Count("strCaseID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCaseID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCaseID", i), filters.Value("strCaseID", i))));
                      
                    if (filters.Contains("datStartDate"))
                        for (int i = 0; i < filters.Count("datStartDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datStartDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datStartDate", i), filters.Value("datStartDate", i))));
                      
                    if (filters.Contains("strPeriodName"))
                        for (int i = 0; i < filters.Count("strPeriodName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strPeriodName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strPeriodName", i), filters.Value("strPeriodName", i))));
                      
                    if (filters.Contains("strRegion"))
                        for (int i = 0; i < filters.Count("strRegion"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strRegion_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strRegion", i), filters.Value("strRegion", i))));
                      
                    if (filters.Contains("strRayon"))
                        for (int i = 0; i < filters.Count("strRayon"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strRayon_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strRayon", i), filters.Value("strRayon", i))));
                      
                    if (filters.Contains("strSettlement"))
                        for (int i = 0; i < filters.Count("strSettlement"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSettlement_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSettlement", i), filters.Value("strSettlement", i))));
                      
                    if (filters.Contains("strInstitutionName"))
                        for (int i = 0; i < filters.Count("strInstitutionName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strInstitutionName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strInstitutionName", i), filters.Value("strInstitutionName", i))));
                      
                    if (filters.Contains("datEnteredByDate"))
                        for (int i = 0; i < filters.Count("datEnteredByDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datEnteredByDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datEnteredByDate", i), filters.Value("datEnteredByDate", i))));
                      
                    if (filters.Contains("strMatrixName"))
                        for (int i = 0; i < filters.Count("strMatrixName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strMatrixName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strMatrixName", i), filters.Value("strMatrixName", i))));
                      
                    if (filters.Contains("strTemplateName"))
                        for (int i = 0; i < filters.Count("strTemplateName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strTemplateName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strTemplateName", i), filters.Value("strTemplateName", i))));
                      
                    List<AggergateDeduplicationBaseListItem> objs = manager.ExecuteList<AggergateDeduplicationBaseListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                    }
                    ListSelected(manager, objs);
                    return objs;
                }
                catch(DataException e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                    }
                    throw DbModelException.Create(e);
                }
            }
            partial void ListSelected(DbManagerProxy manager, List<AggergateDeduplicationBaseListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spHumanAggregateCase_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, AggergateDeduplicationBaseListItem obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, AggergateDeduplicationBaseListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AggergateDeduplicationBaseListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    AggergateDeduplicationBaseListItem obj = AggergateDeduplicationBaseListItem.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(e);
                }
            }

            
            public AggergateDeduplicationBaseListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AggergateDeduplicationBaseListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AggergateDeduplicationBaseListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult FindDuplicates(DbManagerProxy manager, AggergateDeduplicationBaseListItem obj, List<object> pars)
            {
                
                return FindDuplicates(manager, obj
                    );
            }
            public ActResult FindDuplicates(DbManagerProxy manager, AggergateDeduplicationBaseListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("FindDuplicates"))
                    throw new PermissionException("HumanCase", "FindDuplicates");
                
                return true;
                
            }
            
      
            public ActResult ActionEditHumanAggregateCase(DbManagerProxy manager, AggergateDeduplicationBaseListItem obj, List<object> pars)
            {
                
                return ActionEditHumanAggregateCase(manager, obj
                    );
            }
            public ActResult ActionEditHumanAggregateCase(DbManagerProxy manager, AggergateDeduplicationBaseListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ActionEditHumanAggregateCase"))
                    throw new PermissionException("HumanCase", "ActionEditHumanAggregateCase");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(AggergateDeduplicationBaseListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AggergateDeduplicationBaseListItem obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, AggergateDeduplicationBaseListItem obj)
            {
                
            }
    
            [SprocName("spHumanAggregateCase_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AggergateDeduplicationBaseListItem bo = obj as AggergateDeduplicationBaseListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("HumanCase", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("HumanCase", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("HumanCase", "Update");
                    }
                    
                    long mainObject = bo.idfAggrCase;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        
                    }

                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeDelete;
                            
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeCreate;
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeEdit;
                            
                        }
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoAgregateHumanCase;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbAggrCase;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as AggergateDeduplicationBaseListItem, bChildObject);
                    if (bTransactionStarted)
                    {
                        if (bSuccess)
                        {
                            obj.DeepAcceptChanges();
                            manager.CommitTransaction();
                            
                        }
                        else
                        {
                            manager.RollbackTransaction();
                        }
                        
                    }
                    if (bSuccess && bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        bo.m_IsNew = false;
                    }
                    if (bSuccess && bTransactionStarted)
                    {
                        bo.OnAfterPost();
                    }
                }
                catch(Exception e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                        
                    }
                    
                    if (e is DataException)
                    {
                        throw DbModelException.Create(e as DataException);
                    }
                    else 
                        throw;
                }
                return bSuccess;
            }
            private bool _PostNonTransaction(DbManagerProxy manager, AggergateDeduplicationBaseListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfAggrCase
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AggergateDeduplicationBaseListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AggergateDeduplicationBaseListItem obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(AggergateDeduplicationBaseListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(AggergateDeduplicationBaseListItem obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as AggergateDeduplicationBaseListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AggergateDeduplicationBaseListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(AggergateDeduplicationBaseListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(AggergateDeduplicationBaseListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AggergateDeduplicationBaseListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AggergateDeduplicationBaseListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AggergateDeduplicationBaseListItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private AggergateDeduplicationBaseListItem m_obj;
            internal Permissions(AggergateDeduplicationBaseListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("HumanCase.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_AggregateCaseDeduplication_SelectList";
            public static string spCount = "spHumanAggregateCase_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spHumanAggregateCase_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AggergateDeduplicationBaseListItem, bool>> RequiredByField = new Dictionary<string, Func<AggergateDeduplicationBaseListItem, bool>>();
            public static Dictionary<string, Func<AggergateDeduplicationBaseListItem, bool>> RequiredByProperty = new Dictionary<string, Func<AggergateDeduplicationBaseListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                Sizes.Add(_str_strCaseID, 200);
                Sizes.Add(_str_strPeriodName, 2000);
                Sizes.Add(_str_strRegion, 300);
                Sizes.Add(_str_strRayon, 300);
                Sizes.Add(_str_strSettlement, 300);
                Sizes.Add(_str_strInstitutionName, 2000);
                Sizes.Add(_str_strMatrixName, 604);
                Sizes.Add(_str_strTemplateName, 4000);
                GridMeta.Add(new GridMetaItem(
                    _str_idfAggrCase,
                    _str_idfAggrCase, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intDuplicateGroup,
                    _str_intDuplicateGroup, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseID,
                    "strCaseID", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datStartDate,
                    _str_datStartDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPeriodName,
                    "idfsPeriodType", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRegion,
                    "idfsRegion", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRayon,
                    "idfsRayon", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSettlement,
                    "strSettlement", null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strInstitutionName,
                    _str_strInstitutionName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datEnteredByDate,
                    _str_datEnteredByDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strMatrixName,
                    _str_strMatrixName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strTemplateName,
                    _str_strTemplateName, null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "FindDuplicates",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).FindDuplicates(manager, (AggergateDeduplicationBaseListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strFindDuplicates_Id",
                        "",
                        /*from BvMessages*/"strFindDuplicates_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "ActionEditHumanAggregateCase",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionEditHumanAggregateCase(manager, (AggergateDeduplicationBaseListItem)c, pars),
                        
                    null,
                    
                    null,
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "SelectAll",
                    ActionTypes.SelectAll,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelectAll_Id",
                        "selectall",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Select",
                    ActionTypes.Select,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelect_Id",
                        "select",
                        /*from BvMessages*/"tooltipSelect_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelect_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Edit",
                    ActionTypes.Edit,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<HumanAggregateCase>().SelectDetail(manager, pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => 
                        {
                            if (c == null)
                            {
                                c = ObjectAccessor.CreatorInterface<AggergateDeduplicationBaseListItem>().CreateWithParams(manager, null, pars);
                                ((AggergateDeduplicationBaseListItem)c).idfAggrCase = (long)pars[0];
                                ((AggergateDeduplicationBaseListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((AggergateDeduplicationBaseListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<AggergateDeduplicationBaseListItem>().Post(manager, (AggergateDeduplicationBaseListItem)c), c);
                        }
                                            ,
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Refresh",
                    ActionTypes.Refresh,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strRefresh_Id",
                        "iconRefresh_Id",
                        /*from BvMessages*/"tooltipRefresh_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipRefresh_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Close",
                    ActionTypes.Close,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strClose_Id",
                        "Close",
                        /*from BvMessages*/"tooltipClose_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipClose_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
}
	