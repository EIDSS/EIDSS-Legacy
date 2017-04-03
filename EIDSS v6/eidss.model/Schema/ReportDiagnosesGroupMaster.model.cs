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
    public abstract partial class ReportDiagnosesGroupMaster : 
        EditableObject<ReportDiagnosesGroupMaster>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsReportDiagnosesGroup), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsReportDiagnosesGroup { get; set; }
                
        [LocalizedDisplayName(_str_strName)]
        [MapField(_str_strName)]
        public abstract String strName { get; set; }
        protected String strName_Original { get { return ((EditableValue<String>)((dynamic)this)._strName).OriginalValue; } }
        protected String strName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strTranslatedName)]
        [MapField(_str_strTranslatedName)]
        public abstract String strTranslatedName { get; set; }
        protected String strTranslatedName_Original { get { return ((EditableValue<String>)((dynamic)this)._strTranslatedName).OriginalValue; } }
        protected String strTranslatedName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTranslatedName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Code)]
        [MapField(_str_Code)]
        public abstract String Code { get; set; }
        protected String Code_Original { get { return ((EditableValue<String>)((dynamic)this)._code).OriginalValue; } }
        protected String Code_Previous { get { return ((EditableValue<String>)((dynamic)this)._code).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<ReportDiagnosesGroupMaster, object> _get_func;
            internal Action<ReportDiagnosesGroupMaster, string> _set_func;
            internal Action<ReportDiagnosesGroupMaster, ReportDiagnosesGroupMaster, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsReportDiagnosesGroup = "idfsReportDiagnosesGroup";
        internal const string _str_strName = "strName";
        internal const string _str_strTranslatedName = "strTranslatedName";
        internal const string _str_Code = "Code";
        internal const string _str_ReportDiagnosesGroups = "ReportDiagnosesGroups";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsReportDiagnosesGroup, _formname = _str_idfsReportDiagnosesGroup, _type = "Int64",
              _get_func = o => o.idfsReportDiagnosesGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsReportDiagnosesGroup != newval) o.idfsReportDiagnosesGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsReportDiagnosesGroup != c.idfsReportDiagnosesGroup || o.IsRIRPropChanged(_str_idfsReportDiagnosesGroup, c)) 
                  m.Add(_str_idfsReportDiagnosesGroup, o.ObjectIdent + _str_idfsReportDiagnosesGroup, o.ObjectIdent2 + _str_idfsReportDiagnosesGroup, o.ObjectIdent3 + _str_idfsReportDiagnosesGroup, "Int64", 
                    o.idfsReportDiagnosesGroup == null ? "" : o.idfsReportDiagnosesGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsReportDiagnosesGroup), o.IsInvisible(_str_idfsReportDiagnosesGroup), o.IsRequired(_str_idfsReportDiagnosesGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strName, _formname = _str_strName, _type = "String",
              _get_func = o => o.strName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strName != newval) o.strName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strName != c.strName || o.IsRIRPropChanged(_str_strName, c)) 
                  m.Add(_str_strName, o.ObjectIdent + _str_strName, o.ObjectIdent2 + _str_strName, o.ObjectIdent3 + _str_strName, "String", 
                    o.strName == null ? "" : o.strName.ToString(),                  
                  o.IsReadOnly(_str_strName), o.IsInvisible(_str_strName), o.IsRequired(_str_strName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTranslatedName, _formname = _str_strTranslatedName, _type = "String",
              _get_func = o => o.strTranslatedName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTranslatedName != newval) o.strTranslatedName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strTranslatedName != c.strTranslatedName || o.IsRIRPropChanged(_str_strTranslatedName, c)) 
                  m.Add(_str_strTranslatedName, o.ObjectIdent + _str_strTranslatedName, o.ObjectIdent2 + _str_strTranslatedName, o.ObjectIdent3 + _str_strTranslatedName, "String", 
                    o.strTranslatedName == null ? "" : o.strTranslatedName.ToString(),                  
                  o.IsReadOnly(_str_strTranslatedName), o.IsInvisible(_str_strTranslatedName), o.IsRequired(_str_strTranslatedName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Code, _formname = _str_Code, _type = "String",
              _get_func = o => o.Code,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.Code != newval) o.Code = newval; },
              _compare_func = (o, c, m) => {
                if (o.Code != c.Code || o.IsRIRPropChanged(_str_Code, c)) 
                  m.Add(_str_Code, o.ObjectIdent + _str_Code, o.ObjectIdent2 + _str_Code, o.ObjectIdent3 + _str_Code, "String", 
                    o.Code == null ? "" : o.Code.ToString(),                  
                  o.IsReadOnly(_str_Code), o.IsInvisible(_str_Code), o.IsRequired(_str_Code)); 
                  }
              }, 
        
            new field_info {
              _name = _str_ReportDiagnosesGroups, _formname = _str_ReportDiagnosesGroups, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.ReportDiagnosesGroups.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.ReportDiagnosesGroups.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.ReportDiagnosesGroups.Count != c.ReportDiagnosesGroups.Count || o.IsReadOnly(_str_ReportDiagnosesGroups) != c.IsReadOnly(_str_ReportDiagnosesGroups) || o.IsInvisible(_str_ReportDiagnosesGroups) != c.IsInvisible(_str_ReportDiagnosesGroups) || o.IsRequired(_str_ReportDiagnosesGroups) != c._isRequired(o.m_isRequired, _str_ReportDiagnosesGroups)) {
                  m.Add(_str_ReportDiagnosesGroups, o.ObjectIdent + _str_ReportDiagnosesGroups, o.ObjectIdent2 + _str_ReportDiagnosesGroups, o.ObjectIdent3 + _str_ReportDiagnosesGroups, "Child", o.idfsReportDiagnosesGroup == null ? "" : o.idfsReportDiagnosesGroup.ToString(), o.IsReadOnly(_str_ReportDiagnosesGroups), o.IsInvisible(_str_ReportDiagnosesGroups), o.IsRequired(_str_ReportDiagnosesGroups)); 
                  }
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
            ReportDiagnosesGroupMaster obj = (ReportDiagnosesGroupMaster)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_ReportDiagnosesGroups)]
        [Relation(typeof(ReportDiagnosesGroup), eidss.model.Schema.ReportDiagnosesGroup._str_idfsReportDiagnosesGroup, _str_idfsReportDiagnosesGroup)]
        public EditableList<ReportDiagnosesGroup> ReportDiagnosesGroups
        {
            get 
            {   
                return _ReportDiagnosesGroups; 
            }
            set 
            {
                _ReportDiagnosesGroups = value;
            }
        }
        protected EditableList<ReportDiagnosesGroup> _ReportDiagnosesGroups = new EditableList<ReportDiagnosesGroup>();
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "ReportDiagnosesGroupMaster";

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
        ReportDiagnosesGroups.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as ReportDiagnosesGroupMaster;
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
            var ret = base.Clone() as ReportDiagnosesGroupMaster;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_ReportDiagnosesGroups != null && _ReportDiagnosesGroups.Count > 0)
            {
              ret.ReportDiagnosesGroups.Clear();
              _ReportDiagnosesGroups.ForEach(c => ret.ReportDiagnosesGroups.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public ReportDiagnosesGroupMaster CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as ReportDiagnosesGroupMaster;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsReportDiagnosesGroup; } }
        public string KeyName { get { return "idfsReportDiagnosesGroup"; } }
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
        
                    || ReportDiagnosesGroups.IsDirty
                    || ReportDiagnosesGroups.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
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
        ReportDiagnosesGroups.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        ReportDiagnosesGroups.DeepAcceptChanges();
                
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
        ReportDiagnosesGroups.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, ReportDiagnosesGroupMaster c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public ReportDiagnosesGroupMaster()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(ReportDiagnosesGroupMaster_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(ReportDiagnosesGroupMaster_PropertyChanged);
        }
        private void ReportDiagnosesGroupMaster_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as ReportDiagnosesGroupMaster).Changed(e.PropertyName);
            
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
            
            return Accessor.Instance(null).ValidateCanDelete(this);
              
        }
        private void _DeletingExtenders()
        {
            ReportDiagnosesGroupMaster obj = this;
            
        }
        private void _DeletedExtenders()
        {
            ReportDiagnosesGroupMaster obj = this;
            
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
            
            return ReadOnly;
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _ReportDiagnosesGroups)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<ReportDiagnosesGroupMaster, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<ReportDiagnosesGroupMaster, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<ReportDiagnosesGroupMaster, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<ReportDiagnosesGroupMaster, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<ReportDiagnosesGroupMaster, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<ReportDiagnosesGroupMaster, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<ReportDiagnosesGroupMaster, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~ReportDiagnosesGroupMaster()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                ReportDiagnosesGroups.ForEach(c => c.Dispose());
                
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
        
            if (_ReportDiagnosesGroups != null) _ReportDiagnosesGroups.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<ReportDiagnosesGroupMaster>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<ReportDiagnosesGroupMaster>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<ReportDiagnosesGroupMaster>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsReportDiagnosesGroup"; } }
            #endregion
        
            private delegate void on_action(ReportDiagnosesGroupMaster obj);
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
            private ReportDiagnosesGroup.Accessor ReportDiagnosesGroupsAccessor { get { return eidss.model.Schema.ReportDiagnosesGroup.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual ReportDiagnosesGroupMaster SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual ReportDiagnosesGroupMaster SelectByKey(DbManagerProxy manager
                , Int64? idfsReportDiagnosesGroup
                )
            {
                return _SelectByKey(manager
                    , idfsReportDiagnosesGroup
                    , null, null
                    );
            }
            
      
            private ReportDiagnosesGroupMaster _SelectByKey(DbManagerProxy manager
                , Int64? idfsReportDiagnosesGroup
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<ReportDiagnosesGroupMaster> objs = new List<ReportDiagnosesGroupMaster>();
                sets[0] = new MapResultSet(typeof(ReportDiagnosesGroupMaster), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spReportDiagnosesGroup_SelectDetail"
                            , manager.Parameter("@idfsReportDiagnosesGroup", idfsReportDiagnosesGroup)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    ReportDiagnosesGroupMaster obj = objs[0];
                    obj.m_CS = m_CS;
                    
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    
                    //obj._setParent();
                    if (loaded != null)
                        loaded(obj);
                    obj.Loaded(manager);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(e);
                }
                
            }
    
            private void _SetupAddChildHandlerReportDiagnosesGroups(ReportDiagnosesGroupMaster obj)
            {
                obj.ReportDiagnosesGroups.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            internal void _LoadReportDiagnosesGroups(ReportDiagnosesGroupMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadReportDiagnosesGroups(manager, obj);
                }
            }
            internal void _LoadReportDiagnosesGroups(DbManagerProxy manager, ReportDiagnosesGroupMaster obj)
            {
                
                obj.ReportDiagnosesGroups.Clear();
                obj.ReportDiagnosesGroups.AddRange(ReportDiagnosesGroupsAccessor.SelectDetailList(manager
                    
                    , obj.idfsReportDiagnosesGroup
                    ));
                obj.ReportDiagnosesGroups.ForEach(c => c.m_ObjectName = _str_ReportDiagnosesGroups);
                obj.ReportDiagnosesGroups.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, ReportDiagnosesGroupMaster obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadReportDiagnosesGroups(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerReportDiagnosesGroups(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, ReportDiagnosesGroupMaster obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.ReportDiagnosesGroups.ForEach(c => ReportDiagnosesGroupsAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private ReportDiagnosesGroupMaster _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    ReportDiagnosesGroupMaster obj = ReportDiagnosesGroupMaster.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
              obj.m_IsNew = false;
              var accMaster = ReportDiagnosesGroupMaster.Accessor.Instance(null);
              accMaster._LoadReportDiagnosesGroups(manager, obj);
            
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerReportDiagnosesGroups(obj);
                    
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

            
            public ReportDiagnosesGroupMaster CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public ReportDiagnosesGroupMaster CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public ReportDiagnosesGroupMaster CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult DeleteGroup(DbManagerProxy manager, ReportDiagnosesGroupMaster obj, List<object> pars)
            {
                
                return DeleteGroup(manager, obj
                    );
            }
            public ActResult DeleteGroup(DbManagerProxy manager, ReportDiagnosesGroupMaster obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("DeleteGroup"))
                    throw new PermissionException("Reference", "DeleteGroup");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(ReportDiagnosesGroupMaster obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(ReportDiagnosesGroupMaster obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, ReportDiagnosesGroupMaster obj)
            {
                
            }
    
            [SprocName("spReportDiagnosesGroupMaster_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                )
            {
                
                _postDelete(manager);
                
            }
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spDummy_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] ReportDiagnosesGroupMaster obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] ReportDiagnosesGroupMaster obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    ReportDiagnosesGroupMaster bo = obj as ReportDiagnosesGroupMaster;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("Reference", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("Reference", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("Reference", "Update");
                    }
                    
                    long mainObject = bo.idfsReportDiagnosesGroup;
                    
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
                        
                          eidss.model.Enums.EventType eventType = eidss.model.Enums.EventType.RaiseReferenceCacheChange;
                          
                          manager.SetEventParams(false, "rftReportDiagnosisGroup", new object[] { eventType, null, "rftReportDiagnosisGroup" });
                          
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoReference;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.trtDiagnosisAgeGroup;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as ReportDiagnosesGroupMaster, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, ReportDiagnosesGroupMaster obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.ReportDiagnosesGroups != null)
                    {
                        foreach (var i in obj.ReportDiagnosesGroups)
                        {
                            i.MarkToDelete();
                            if (!ReportDiagnosesGroupsAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (obj.IsNew)
                    {
                        if (obj.ReportDiagnosesGroups != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.ReportDiagnosesGroups)
                                if (!ReportDiagnosesGroupsAccessor.Post(manager, i, true))
                                    return false;
                            obj.ReportDiagnosesGroups.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.ReportDiagnosesGroups.Remove(c));
                            obj.ReportDiagnosesGroups.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._ReportDiagnosesGroups != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._ReportDiagnosesGroups)
                                if (!ReportDiagnosesGroupsAccessor.Post(manager, i, true))
                                    return false;
                            obj._ReportDiagnosesGroups.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._ReportDiagnosesGroups.Remove(c));
                            obj._ReportDiagnosesGroups.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(ReportDiagnosesGroupMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, ReportDiagnosesGroupMaster obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(ReportDiagnosesGroupMaster obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(ReportDiagnosesGroupMaster obj, bool bRethrowException)
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
                return Validate(manager, obj as ReportDiagnosesGroupMaster, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, ReportDiagnosesGroupMaster obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(ReportDiagnosesGroupMaster obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(ReportDiagnosesGroupMaster obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as ReportDiagnosesGroupMaster) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as ReportDiagnosesGroupMaster) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "ReportDiagnosesGroupMasterDetail"; } }
            public string HelpIdWin { get { return "Age_Groups_Editor"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private ReportDiagnosesGroupMaster m_obj;
            internal Permissions(ReportDiagnosesGroupMaster obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Reference.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spReportDiagnosesGroup_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spDummy_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spReportDiagnosesGroupMaster_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<ReportDiagnosesGroupMaster, bool>> RequiredByField = new Dictionary<string, Func<ReportDiagnosesGroupMaster, bool>>();
            public static Dictionary<string, Func<ReportDiagnosesGroupMaster, bool>> RequiredByProperty = new Dictionary<string, Func<ReportDiagnosesGroupMaster, bool>>();
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
                
                Sizes.Add(_str_strName, 2000);
                Sizes.Add(_str_strTranslatedName, 2000);
                Sizes.Add(_str_Code, 200);
                Actions.Add(new ActionMetaItem(
                    "DeleteGroup",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).DeleteGroup(manager, (ReportDiagnosesGroupMaster)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    ActionMetaItem.DefaultDeleteGroupItemVisiblePredicate,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<ReportDiagnosesGroupMaster>().Post(manager, (ReportDiagnosesGroupMaster)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
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
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<ReportDiagnosesGroupMaster>().Post(manager, (ReportDiagnosesGroupMaster)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
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
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
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
	