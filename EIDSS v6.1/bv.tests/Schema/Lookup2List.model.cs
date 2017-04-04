#pragma warning disable 0472,0414
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
		

namespace bv.tests.Schema
{
        
        
    [XmlType(AnonymousType = true)]
    public abstract partial class Lookup2ListItem : 
        EditableObject<Lookup2ListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_Lookup2ID), NonUpdatable, PrimaryKey]
        public abstract Int64 Lookup2ID { get; set; }
                
        [LocalizedDisplayName(_str_Lookup2ParentID)]
        [MapField(_str_Lookup2ParentID)]
        public abstract Int64? Lookup2ParentID { get; set; }
        protected Int64? Lookup2ParentID_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._lookup2ParentID).OriginalValue; } }
        protected Int64? Lookup2ParentID_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._lookup2ParentID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Lookup2Field1)]
        [MapField(_str_Lookup2Field1)]
        public abstract String Lookup2Field1 { get; set; }
        protected String Lookup2Field1_Original { get { return ((EditableValue<String>)((dynamic)this)._lookup2Field1).OriginalValue; } }
        protected String Lookup2Field1_Previous { get { return ((EditableValue<String>)((dynamic)this)._lookup2Field1).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32 intRowStatus { get; set; }
        protected Int32 intRowStatus_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32 intRowStatus_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intRowStatus).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<Lookup2ListItem, object> _get_func;
            internal Action<Lookup2ListItem, string> _set_func;
            internal Action<Lookup2ListItem, Lookup2ListItem, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_Lookup2ID = "Lookup2ID";
        internal const string _str_Lookup2ParentID = "Lookup2ParentID";
        internal const string _str_Lookup2Field1 = "Lookup2Field1";
        internal const string _str_intRowStatus = "intRowStatus";
        internal const string _str_ParentLookup = "ParentLookup";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_Lookup2ID, _formname = _str_Lookup2ID, _type = "Int64",
              _get_func = o => o.Lookup2ID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.Lookup2ID != newval) o.Lookup2ID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.Lookup2ID != c.Lookup2ID || o.IsRIRPropChanged(_str_Lookup2ID, c)) 
                  m.Add(_str_Lookup2ID, o.ObjectIdent + _str_Lookup2ID, o.ObjectIdent2 + _str_Lookup2ID, o.ObjectIdent3 + _str_Lookup2ID, "Int64", 
                    o.Lookup2ID == null ? "" : o.Lookup2ID.ToString(),                  
                  o.IsReadOnly(_str_Lookup2ID), o.IsInvisible(_str_Lookup2ID), o.IsRequired(_str_Lookup2ID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Lookup2ParentID, _formname = _str_Lookup2ParentID, _type = "Int64?",
              _get_func = o => o.Lookup2ParentID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.Lookup2ParentID != newval) 
                  o.ParentLookup = o.ParentLookupLookup.FirstOrDefault(c => c.Lookup1ID == newval);
                if (o.Lookup2ParentID != newval) o.Lookup2ParentID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.Lookup2ParentID != c.Lookup2ParentID || o.IsRIRPropChanged(_str_Lookup2ParentID, c)) 
                  m.Add(_str_Lookup2ParentID, o.ObjectIdent + _str_Lookup2ParentID, o.ObjectIdent2 + _str_Lookup2ParentID, o.ObjectIdent3 + _str_Lookup2ParentID, "Int64?", 
                    o.Lookup2ParentID == null ? "" : o.Lookup2ParentID.ToString(),                  
                  o.IsReadOnly(_str_Lookup2ParentID), o.IsInvisible(_str_Lookup2ParentID), o.IsRequired(_str_Lookup2ParentID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Lookup2Field1, _formname = _str_Lookup2Field1, _type = "String",
              _get_func = o => o.Lookup2Field1,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.Lookup2Field1 != newval) o.Lookup2Field1 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.Lookup2Field1 != c.Lookup2Field1 || o.IsRIRPropChanged(_str_Lookup2Field1, c)) 
                  m.Add(_str_Lookup2Field1, o.ObjectIdent + _str_Lookup2Field1, o.ObjectIdent2 + _str_Lookup2Field1, o.ObjectIdent3 + _str_Lookup2Field1, "String", 
                    o.Lookup2Field1 == null ? "" : o.Lookup2Field1.ToString(),                  
                  o.IsReadOnly(_str_Lookup2Field1), o.IsInvisible(_str_Lookup2Field1), o.IsRequired(_str_Lookup2Field1)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRowStatus, _formname = _str_intRowStatus, _type = "Int32",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intRowStatus != newval) o.intRowStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, o.ObjectIdent2 + _str_intRowStatus, o.ObjectIdent3 + _str_intRowStatus, "Int32", 
                    o.intRowStatus == null ? "" : o.intRowStatus.ToString(),                  
                  o.IsReadOnly(_str_intRowStatus), o.IsInvisible(_str_intRowStatus), o.IsRequired(_str_intRowStatus)); 
                  }
              }, 
        
            new field_info {
              _name = _str_ParentLookup, _formname = _str_ParentLookup, _type = "Lookup",
              _get_func = o => { if (o.ParentLookup == null) return null; return o.ParentLookup.Lookup1ID; },
              _set_func = (o, val) => { o.ParentLookup = o.ParentLookupLookup.Where(c => c.Lookup1ID.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_ParentLookup, c);
                if (o.Lookup2ParentID != c.Lookup2ParentID || o.IsRIRPropChanged(_str_ParentLookup, c) || bChangeLookupContent) {
                  m.Add(_str_ParentLookup, o.ObjectIdent + _str_ParentLookup, o.ObjectIdent2 + _str_ParentLookup, o.ObjectIdent3 + _str_ParentLookup, "Lookup", o.Lookup2ParentID == null ? "" : o.Lookup2ParentID.ToString(), o.IsReadOnly(_str_ParentLookup), o.IsInvisible(_str_ParentLookup), o.IsRequired(_str_ParentLookup),
                  bChangeLookupContent ? o.ParentLookupLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_ParentLookup + "Lookup", _formname = _str_ParentLookup + "Lookup", _type = "LookupContent",
              _get_func = o => o.ParentLookupLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
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
            Lookup2ListItem obj = (Lookup2ListItem)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_ParentLookup)]
        [Relation(typeof(Lookup1Table), bv.tests.Schema.Lookup1Table._str_Lookup1ID, _str_Lookup2ParentID)]
        public Lookup1Table ParentLookup
        {
            get { return _ParentLookup == null ? null : ((long)_ParentLookup.Key == 0 ? null : _ParentLookup); }
            set 
            { 
                var oldVal = _ParentLookup;
                _ParentLookup = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_ParentLookup != oldVal)
                {
                    if (Lookup2ParentID != (_ParentLookup == null
                            ? new Int64?()
                            : (Int64?)_ParentLookup.Lookup1ID))
                        Lookup2ParentID = _ParentLookup == null 
                            ? new Int64?()
                            : (Int64?)_ParentLookup.Lookup1ID; 
                    OnPropertyChanged(_str_ParentLookup); 
                }
            }
        }
        private Lookup1Table _ParentLookup;

        
        public List<Lookup1Table> ParentLookupLookup
        {
            get { return _ParentLookupLookup; }
        }
        private List<Lookup1Table> _ParentLookupLookup = new List<Lookup1Table>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_ParentLookup:
                    return new BvSelectList(ParentLookupLookup, bv.tests.Schema.Lookup1Table._str_Lookup1ID, null, ParentLookup, _str_Lookup2ParentID);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Lookup2ListItem";

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
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as Lookup2ListItem;
            ret.bIsClone = true;
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
            var ret = base.Clone() as Lookup2ListItem;
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
        public Lookup2ListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Lookup2ListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return Lookup2ID; } }
        public string KeyName { get { return "Lookup2ID"; } }
        public object KeyLookup { get { return Lookup2ID; } }
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
        
            var _prev_Lookup2ParentID_ParentLookup = Lookup2ParentID;
            base.RejectChanges();
        
            if (_prev_Lookup2ParentID_ParentLookup != Lookup2ParentID)
            {
                _ParentLookup = _ParentLookupLookup.FirstOrDefault(c => c.Lookup1ID == Lookup2ParentID);
            }
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
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
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

        private bool IsRIRPropChanged(string fld, Lookup2ListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, Lookup2ListItem c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public Lookup2ListItem()
        {
            
            m_permissions = new Permissions(this);
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Lookup2ListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Lookup2ListItem_PropertyChanged);
        }
        private void Lookup2ListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Lookup2ListItem).Changed(e.PropertyName);
            
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
            Lookup2ListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Lookup2ListItem obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
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

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
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


        internal Dictionary<string, Func<Lookup2ListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Lookup2ListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Lookup2ListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Lookup2ListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Lookup2ListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<Lookup2ListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<Lookup2ListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~Lookup2ListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("Lookup1Table", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "Lookup1Table")
                _getAccessor().LoadLookup_ParentLookup(manager, this);
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
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
        public class Lookup2ListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 Lookup2ID { get; set; }
        
            public String Lookup2Field1 { get; set; }
        
        }
        public partial class Lookup2ListItemGridModelList : List<Lookup2ListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public Lookup2ListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<Lookup2ListItem>, errMes);
            }
            public Lookup2ListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<Lookup2ListItem>, errMes);
            }
            public Lookup2ListItemGridModelList(long key, IEnumerable<Lookup2ListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public Lookup2ListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<Lookup2ListItem>(), null);
            }
            partial void filter(List<Lookup2ListItem> items);
            private void LoadGridModelList(long key, IEnumerable<Lookup2ListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_Lookup2ID,_str_Lookup2Field1};
                    
                Hiddens = new List<string> {};
                Keys = new List<string> {_str_Lookup2ID};
                Labels = new Dictionary<string, string> {{_str_Lookup2ID, _str_Lookup2ID},{_str_Lookup2Field1, _str_Lookup2Field1}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                Lookup2ListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<Lookup2ListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new Lookup2ListItemGridModel()
                {
                    ItemKey=c.Lookup2ID,Lookup2Field1=c.Lookup2Field1
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
        : DataAccessor<Lookup2ListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<Lookup2ListItem>
            
            , IObjectSelectList
            , IObjectSelectList<Lookup2ListItem>
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "Lookup2ID"; } }
            #endregion
        
            public delegate void on_action(Lookup2ListItem obj);
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
            private Lookup1Table.Accessor ParentLookupAccessor { get { return bv.tests.Schema.Lookup1Table.Accessor.Instance(m_CS); } }
            
            public virtual List<Lookup2ListItem> SelectListT(DbManagerProxy manager
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
            
            protected virtual List<Lookup2ListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fnLookupTable2_SelectList.* from dbo.fnLookupTable2_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("par11"))
                {
                    
                    sql.Append(" " + @"inner join dbo.LookupTable1 t1 on t1.Lookup1ID = Lookup2ParentID");
                      
                }
                
                if (filters.Contains("par21") || filters.Contains("par22"))
                {
                    
                    sql.Append(" " + @"inner join dbo.LookupTable1 t2 on t2.Lookup1ID = Lookup2ParentID");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("par11"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("par11") == 1)
                    {
                        sql.AppendFormat("t1.Lookup1Field1 {0} @par11", filters.Operation("par11"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("par11"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("par11") ? " or " : " and ");
                            sql.AppendFormat("t1.Lookup1Field1 {0} @par11_{1}", filters.Operation("par11", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("par21"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("par21") == 1)
                    {
                        sql.AppendFormat("t2.Lookup1ID {0} @par21", filters.Operation("par21"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("par21"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("par21") ? " or " : " and ");
                            sql.AppendFormat("t2.Lookup1ID {0} @par21_{1}", filters.Operation("par21", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("par22"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("par22") == 1)
                    {
                        sql.AppendFormat("t2.Lookup1ID {0} @par22", filters.Operation("par22"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("par22"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("par22") ? " or " : " and ");
                            sql.AppendFormat("t2.Lookup1ID {0} @par22_{1}", filters.Operation("par22", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("Lookup2ID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("Lookup2ID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("Lookup2ID") ? " or " : " and ");
                        
                        if (filters.Operation("Lookup2ID", i) == "&")
                          sql.AppendFormat("(isnull(fnLookupTable2_SelectList.Lookup2ID,0) {0} @Lookup2ID_{1} = @Lookup2ID_{1})", filters.Operation("Lookup2ID", i), i);
                        else
                          sql.AppendFormat("isnull(fnLookupTable2_SelectList.Lookup2ID,0) {0} @Lookup2ID_{1}", filters.Operation("Lookup2ID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("Lookup2ParentID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("Lookup2ParentID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("Lookup2ParentID") ? " or " : " and ");
                        
                        if (filters.Operation("Lookup2ParentID", i) == "&")
                          sql.AppendFormat("(isnull(fnLookupTable2_SelectList.Lookup2ParentID,0) {0} @Lookup2ParentID_{1} = @Lookup2ParentID_{1})", filters.Operation("Lookup2ParentID", i), i);
                        else
                          sql.AppendFormat("isnull(fnLookupTable2_SelectList.Lookup2ParentID,0) {0} @Lookup2ParentID_{1}", filters.Operation("Lookup2ParentID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("Lookup2Field1"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("Lookup2Field1"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("Lookup2Field1") ? " or " : " and ");
                        
                        sql.AppendFormat("fnLookupTable2_SelectList.Lookup2Field1 {0} @Lookup2Field1_{1}", filters.Operation("Lookup2Field1", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intRowStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intRowStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intRowStatus") ? " or " : " and ");
                        
                        if (filters.Operation("intRowStatus", i) == "&")
                          sql.AppendFormat("(isnull(fnLookupTable2_SelectList.intRowStatus,0) {0} @intRowStatus_{1} = @intRowStatus_{1})", filters.Operation("intRowStatus", i), i);
                        else
                          sql.AppendFormat("isnull(fnLookupTable2_SelectList.intRowStatus,0) {0} @intRowStatus_{1}", filters.Operation("intRowStatus", i), i);
                            
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
                    
                    if (filters.Contains("par21"))
                        
                        if (filters.Count("par21") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@par21", ParsingHelper.CorrectLikeValue(filters.Operation("par21"), filters.Value("par21"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("par21"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@par21_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("par21", i), filters.Value("par21", i))));
                        }
                            
                    if (filters.Contains("par22"))
                        
                        if (filters.Count("par22") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@par22", ParsingHelper.CorrectLikeValue(filters.Operation("par22"), filters.Value("par22"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("par22"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@par22_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("par22", i), filters.Value("par22", i))));
                        }
                            
                    if (filters.Contains("par11"))
                        
                        if (filters.Count("par11") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@par11", ParsingHelper.CorrectLikeValue(filters.Operation("par11"), filters.Value("par11"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("par11"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@par11_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("par11", i), filters.Value("par11", i))));
                        }
                            
                    if (filters.Contains("Lookup2ID"))
                        for (int i = 0; i < filters.Count("Lookup2ID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@Lookup2ID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("Lookup2ID", i), filters.Value("Lookup2ID", i))));
                      
                    if (filters.Contains("Lookup2ParentID"))
                        for (int i = 0; i < filters.Count("Lookup2ParentID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@Lookup2ParentID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("Lookup2ParentID", i), filters.Value("Lookup2ParentID", i))));
                      
                    if (filters.Contains("Lookup2Field1"))
                        for (int i = 0; i < filters.Count("Lookup2Field1"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@Lookup2Field1_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("Lookup2Field1", i), filters.Value("Lookup2Field1", i))));
                      
                    if (filters.Contains("intRowStatus"))
                        for (int i = 0; i < filters.Count("intRowStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intRowStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intRowStatus", i), filters.Value("intRowStatus", i))));
                      
                    List<Lookup2ListItem> objs = manager.ExecuteList<Lookup2ListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                        
                        // restore default isolation level for pool connection
                        manager.BeginTransaction();
                        manager.TestConnection();
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
                        
                        // restore default isolation level for pool connection
                        manager.BeginTransaction();
                        manager.TestConnection();
                        manager.RollbackTransaction();
                    }
                    throw DbModelException.Create(null, e);
                }
            }
            partial void ListSelected(DbManagerProxy manager, List<Lookup2ListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return null;
                    
            }
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, Lookup2ListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, Lookup2ListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private Lookup2ListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                Lookup2ListItem obj = null;
                try
                {
                    obj = Lookup2ListItem.CreateInstance();
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
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public Lookup2ListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Lookup2ListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public Lookup2ListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(Lookup2ListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Lookup2ListItem obj)
            {
                
            }
    
            public void LoadLookup_ParentLookup(DbManagerProxy manager, Lookup2ListItem obj)
            {
                
                obj.ParentLookupLookup.Clear();
                
                obj.ParentLookupLookup.Add(ParentLookupAccessor.CreateNewT(manager, null));
                
                obj.ParentLookupLookup.AddRange(ParentLookupAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.Lookup1ID == obj.Lookup2ParentID))
                    
                    .ToList());
                
                if (obj.Lookup2ParentID != null && obj.Lookup2ParentID != 0)
                {
                    obj.ParentLookup = obj.ParentLookupLookup
                        .SingleOrDefault(c => c.Lookup1ID == obj.Lookup2ParentID);
                    
                }
              
                LookupManager.AddObject("Lookup1Table", obj, ParentLookupAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, Lookup2ListItem obj)
            {
                
                LoadLookup_ParentLookup(manager, obj);
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(Lookup2ListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(Lookup2ListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as Lookup2ListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Lookup2ListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(Lookup2ListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(Lookup2ListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Lookup2ListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Lookup2ListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "Lookup2ListItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private Lookup2ListItem m_obj;
            internal Permissions(Lookup2ListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Test.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fnLookupTable2_SelectList";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Lookup2ListItem, bool>> RequiredByField = new Dictionary<string, Func<Lookup2ListItem, bool>>();
            public static Dictionary<string, Func<Lookup2ListItem, bool>> RequiredByProperty = new Dictionary<string, Func<Lookup2ListItem, bool>>();
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
                
                Sizes.Add(_str_Lookup2Field1, 50);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "par21",
                    EditorType.Numeric,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "par21_TtlId",
                    null, ">=", c => false, false, SearchPanelLocation.Additional, true, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "par22",
                    EditorType.Numeric,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "par22_TtlId",
                    null, "<=", c => false, false, SearchPanelLocation.Additional, true, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "Lookup2Field1",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "lblID",
                    c => DateTime.Now.ToString(), null, c => true, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "par11",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "par11_TtlId",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "Lookup2ParentID",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "lblIDLookup",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "ParentLookupLookup", typeof(Lookup1Table), (o) => { var c = (Lookup1Table)o; return c.Lookup1ID; }, (o) => { var c = (Lookup1Table)o; return c.Lookup1ID.ToString() + " - " + c.Lookup1Field1; }, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Lookup2ID,
                    _str_Lookup2ID, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_Lookup2Field1,
                    _str_Lookup2Field1, null, false, true, true, true, true, ListSortDirection.Descending
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
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<Lookup2Table>().CreateNew(manager, c, pars == null ? null : (int?)pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<Lookup2Table>().SelectDetail(manager, pars[0])),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.DeleteInterface<Lookup2Table>().DeleteObject(manager, c == null ? pars[0] : c.Key), c),
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
                    
                Actions.Add(new ActionMetaItem(
                    "Report",
                    ActionTypes.Report,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strReport_Id",
                        "Report",
                        /*from BvMessages*/"tooltipReport_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipReport_Id",
                        ActionsAlignment.Left,
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
	