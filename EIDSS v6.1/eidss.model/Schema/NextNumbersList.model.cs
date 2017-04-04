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
		

namespace eidss.model.Schema
{
        
        
    [XmlType(AnonymousType = true)]
    public abstract partial class NextNumbersListItem : 
        EditableObject<NextNumbersListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsNumberName), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsNumberName { get; set; }
                
        [LocalizedDisplayName(_str_strPrefix)]
        [MapField(_str_strPrefix)]
        public abstract String strPrefix { get; set; }
        protected String strPrefix_Original { get { return ((EditableValue<String>)((dynamic)this)._strPrefix).OriginalValue; } }
        protected String strPrefix_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPrefix).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intNumberValue)]
        [MapField(_str_intNumberValue)]
        public abstract String intNumberValue { get; set; }
        protected String intNumberValue_Original { get { return ((EditableValue<String>)((dynamic)this)._intNumberValue).OriginalValue; } }
        protected String intNumberValue_Previous { get { return ((EditableValue<String>)((dynamic)this)._intNumberValue).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intMinNumberLength)]
        [MapField(_str_intMinNumberLength)]
        public abstract Int32? intMinNumberLength { get; set; }
        protected Int32? intMinNumberLength_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intMinNumberLength).OriginalValue; } }
        protected Int32? intMinNumberLength_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intMinNumberLength).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strObjectName)]
        [MapField(_str_strObjectName)]
        public abstract String strObjectName { get; set; }
        protected String strObjectName_Original { get { return ((EditableValue<String>)((dynamic)this)._strObjectName).OriginalValue; } }
        protected String strObjectName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strObjectName).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<NextNumbersListItem, object> _get_func;
            internal Action<NextNumbersListItem, string> _set_func;
            internal Action<NextNumbersListItem, NextNumbersListItem, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsNumberName = "idfsNumberName";
        internal const string _str_strPrefix = "strPrefix";
        internal const string _str_intNumberValue = "intNumberValue";
        internal const string _str_intMinNumberLength = "intMinNumberLength";
        internal const string _str_strObjectName = "strObjectName";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsNumberName, _formname = _str_idfsNumberName, _type = "Int64",
              _get_func = o => o.idfsNumberName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsNumberName != newval) o.idfsNumberName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsNumberName != c.idfsNumberName || o.IsRIRPropChanged(_str_idfsNumberName, c)) 
                  m.Add(_str_idfsNumberName, o.ObjectIdent + _str_idfsNumberName, o.ObjectIdent2 + _str_idfsNumberName, o.ObjectIdent3 + _str_idfsNumberName, "Int64", 
                    o.idfsNumberName == null ? "" : o.idfsNumberName.ToString(),                  
                  o.IsReadOnly(_str_idfsNumberName), o.IsInvisible(_str_idfsNumberName), o.IsRequired(_str_idfsNumberName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPrefix, _formname = _str_strPrefix, _type = "String",
              _get_func = o => o.strPrefix,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPrefix != newval) o.strPrefix = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strPrefix != c.strPrefix || o.IsRIRPropChanged(_str_strPrefix, c)) 
                  m.Add(_str_strPrefix, o.ObjectIdent + _str_strPrefix, o.ObjectIdent2 + _str_strPrefix, o.ObjectIdent3 + _str_strPrefix, "String", 
                    o.strPrefix == null ? "" : o.strPrefix.ToString(),                  
                  o.IsReadOnly(_str_strPrefix), o.IsInvisible(_str_strPrefix), o.IsRequired(_str_strPrefix)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intNumberValue, _formname = _str_intNumberValue, _type = "String",
              _get_func = o => o.intNumberValue,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.intNumberValue != newval) o.intNumberValue = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intNumberValue != c.intNumberValue || o.IsRIRPropChanged(_str_intNumberValue, c)) 
                  m.Add(_str_intNumberValue, o.ObjectIdent + _str_intNumberValue, o.ObjectIdent2 + _str_intNumberValue, o.ObjectIdent3 + _str_intNumberValue, "String", 
                    o.intNumberValue == null ? "" : o.intNumberValue.ToString(),                  
                  o.IsReadOnly(_str_intNumberValue), o.IsInvisible(_str_intNumberValue), o.IsRequired(_str_intNumberValue)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intMinNumberLength, _formname = _str_intMinNumberLength, _type = "Int32?",
              _get_func = o => o.intMinNumberLength,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intMinNumberLength != newval) o.intMinNumberLength = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intMinNumberLength != c.intMinNumberLength || o.IsRIRPropChanged(_str_intMinNumberLength, c)) 
                  m.Add(_str_intMinNumberLength, o.ObjectIdent + _str_intMinNumberLength, o.ObjectIdent2 + _str_intMinNumberLength, o.ObjectIdent3 + _str_intMinNumberLength, "Int32?", 
                    o.intMinNumberLength == null ? "" : o.intMinNumberLength.ToString(),                  
                  o.IsReadOnly(_str_intMinNumberLength), o.IsInvisible(_str_intMinNumberLength), o.IsRequired(_str_intMinNumberLength)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strObjectName, _formname = _str_strObjectName, _type = "String",
              _get_func = o => o.strObjectName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strObjectName != newval) o.strObjectName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strObjectName != c.strObjectName || o.IsRIRPropChanged(_str_strObjectName, c)) 
                  m.Add(_str_strObjectName, o.ObjectIdent + _str_strObjectName, o.ObjectIdent2 + _str_strObjectName, o.ObjectIdent3 + _str_strObjectName, "String", 
                    o.strObjectName == null ? "" : o.strObjectName.ToString(),                  
                  o.IsReadOnly(_str_strObjectName), o.IsInvisible(_str_strObjectName), o.IsRequired(_str_strObjectName)); 
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
            NextNumbersListItem obj = (NextNumbersListItem)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
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
        internal string m_ObjectName = "NextNumbersListItem";

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
            var ret = base.Clone() as NextNumbersListItem;
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
            var ret = base.Clone() as NextNumbersListItem;
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
        public NextNumbersListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as NextNumbersListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsNumberName; } }
        public string KeyName { get { return "idfsNumberName"; } }
        public object KeyLookup { get { return idfsNumberName; } }
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

        private bool IsRIRPropChanged(string fld, NextNumbersListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, NextNumbersListItem c)
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
        

      

        public NextNumbersListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(NextNumbersListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(NextNumbersListItem_PropertyChanged);
        }
        private void NextNumbersListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as NextNumbersListItem).Changed(e.PropertyName);
            
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
            NextNumbersListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            NextNumbersListItem obj = this;
            
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


        internal Dictionary<string, Func<NextNumbersListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<NextNumbersListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<NextNumbersListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<NextNumbersListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<NextNumbersListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<NextNumbersListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<NextNumbersListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~NextNumbersListItem()
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
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
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
        public class NextNumbersListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfsNumberName { get; set; }
        
            public String strObjectName { get; set; }
        
            public String strPrefix { get; set; }
        
            public String intNumberValue { get; set; }
        
            public Int32? intMinNumberLength { get; set; }
        
        }
        public partial class NextNumbersListItemGridModelList : List<NextNumbersListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public NextNumbersListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<NextNumbersListItem>, errMes);
            }
            public NextNumbersListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<NextNumbersListItem>, errMes);
            }
            public NextNumbersListItemGridModelList(long key, IEnumerable<NextNumbersListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public NextNumbersListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<NextNumbersListItem>(), null);
            }
            partial void filter(List<NextNumbersListItem> items);
            private void LoadGridModelList(long key, IEnumerable<NextNumbersListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strObjectName,_str_strPrefix,_str_intNumberValue,_str_intMinNumberLength};
                    
                Hiddens = new List<string> {_str_idfsNumberName};
                Keys = new List<string> {_str_idfsNumberName};
                Labels = new Dictionary<string, string> {{_str_strObjectName, _str_strObjectName},{_str_strPrefix, _str_strPrefix},{_str_intNumberValue, _str_intNumberValue},{_str_intMinNumberLength, _str_intMinNumberLength}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                NextNumbersListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<NextNumbersListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new NextNumbersListItemGridModel()
                {
                    ItemKey=c.idfsNumberName,strObjectName=c.strObjectName,strPrefix=c.strPrefix,intNumberValue=c.intNumberValue,intMinNumberLength=c.intMinNumberLength
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
        : DataAccessor<NextNumbersListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<NextNumbersListItem>
            
            , IObjectSelectList
            , IObjectSelectList<NextNumbersListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsNumberName"; } }
            #endregion
        
            public delegate void on_action(NextNumbersListItem obj);
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
            
            public virtual List<NextNumbersListItem> SelectListT(DbManagerProxy manager
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
            
            protected virtual List<NextNumbersListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_NextNumbers_SelectList.* from dbo.fn_NextNumbers_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfsNumberName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsNumberName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsNumberName") ? " or " : " and ");
                        
                        if (filters.Operation("idfsNumberName", i) == "&")
                          sql.AppendFormat("(isnull(fn_NextNumbers_SelectList.idfsNumberName,0) {0} @idfsNumberName_{1} = @idfsNumberName_{1})", filters.Operation("idfsNumberName", i), i);
                        else
                          sql.AppendFormat("isnull(fn_NextNumbers_SelectList.idfsNumberName,0) {0} @idfsNumberName_{1}", filters.Operation("idfsNumberName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strPrefix"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strPrefix"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strPrefix") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_NextNumbers_SelectList.strPrefix {0} @strPrefix_{1}", filters.Operation("strPrefix", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intNumberValue"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intNumberValue"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intNumberValue") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_NextNumbers_SelectList.intNumberValue {0} @intNumberValue_{1}", filters.Operation("intNumberValue", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intMinNumberLength"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intMinNumberLength"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intMinNumberLength") ? " or " : " and ");
                        
                        if (filters.Operation("intMinNumberLength", i) == "&")
                          sql.AppendFormat("(isnull(fn_NextNumbers_SelectList.intMinNumberLength,0) {0} @intMinNumberLength_{1} = @intMinNumberLength_{1})", filters.Operation("intMinNumberLength", i), i);
                        else
                          sql.AppendFormat("isnull(fn_NextNumbers_SelectList.intMinNumberLength,0) {0} @intMinNumberLength_{1}", filters.Operation("intMinNumberLength", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strObjectName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strObjectName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strObjectName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_NextNumbers_SelectList.strObjectName {0} @strObjectName_{1}", filters.Operation("strObjectName", i), i);
                            
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
                    
                    if (filters.Contains("idfsNumberName"))
                        for (int i = 0; i < filters.Count("idfsNumberName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsNumberName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsNumberName", i), filters.Value("idfsNumberName", i))));
                      
                    if (filters.Contains("strPrefix"))
                        for (int i = 0; i < filters.Count("strPrefix"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strPrefix_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strPrefix", i), filters.Value("strPrefix", i))));
                      
                    if (filters.Contains("intNumberValue"))
                        for (int i = 0; i < filters.Count("intNumberValue"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intNumberValue_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intNumberValue", i), filters.Value("intNumberValue", i))));
                      
                    if (filters.Contains("intMinNumberLength"))
                        for (int i = 0; i < filters.Count("intMinNumberLength"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intMinNumberLength_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intMinNumberLength", i), filters.Value("intMinNumberLength", i))));
                      
                    if (filters.Contains("strObjectName"))
                        for (int i = 0; i < filters.Count("strObjectName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strObjectName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strObjectName", i), filters.Value("strObjectName", i))));
                      
                    List<NextNumbersListItem> objs = manager.ExecuteList<NextNumbersListItem>();
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
            partial void ListSelected(DbManagerProxy manager, List<NextNumbersListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spNextNumbers_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, NextNumbersListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, NextNumbersListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private NextNumbersListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                NextNumbersListItem obj = null;
                try
                {
                    obj = NextNumbersListItem.CreateInstance();
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

            
            public NextNumbersListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public NextNumbersListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public NextNumbersListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult PrintBarcode(DbManagerProxy manager, NextNumbersListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("id", typeof(long));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return PrintBarcode(manager, obj
                    , (long)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult PrintBarcode(DbManagerProxy manager, NextNumbersListItem obj
                , long id
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("PrintBarcode"))
                    throw new PermissionException("DocumentNumbering", "PrintBarcode");
                
              const string className = "BarcodeFactory";
              var loadedObject = bv.common.Core.ClassLoader.LoadClass(className);
              bv.common.Diagnostics.Dbg.Assert(loadedObject != null, "class {0} can't be loaded", className);
              bv.common.Diagnostics.Dbg.Assert(loadedObject is IBarcodeFactory, "{0} doesn't implement IBarcodeFactory interface", className);
              IBarcodeFactory factory = (IBarcodeFactory)loadedObject;
              factory.ShowPreview(id);
              return true;
            
            }
            
      
            private void _SetupChildHandlers(NextNumbersListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(NextNumbersListItem obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, NextNumbersListItem obj)
            {
                
            }
    
            [SprocName("spReadOnlyObject_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spReadOnlyObject_Delete")]
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
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        NextNumbersListItem bo = obj as NextNumbersListItem;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            if (!CanDelete)
                                throw new PermissionException("DocumentNumbering", "Delete");
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            if (!CanInsert)
                                throw new PermissionException("DocumentNumbering", "Insert");
                        }
                        else if (!bo.IsMarkedToDelete && bo.HasChanges) // update
                        {
                            if (!CanUpdate)
                                throw new PermissionException("DocumentNumbering", "Update");
                        }
                        
                        long mainObject = bo.idfsNumberName;
                        
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
                            
                            eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoDocumentNumbering;
                            eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tstNextNumbers;
                            manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as NextNumbersListItem, bChildObject);
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
                        
                        break;
                    }
                    catch(Exception e)
                    {
                        if (bTransactionStarted)
                        {
                            manager.RollbackTransaction();
                            
                            if (DbModelException.IsDeadlockException(e))
                            {
                                System.Threading.Thread.Sleep(BaseSettings.DeadlockDelay);
                                continue;
                            }
                        }
                    
                        if (e is DataException)
                        {
                            throw DbModelException.Create(obj, e as DataException);
                        }
                        if (e is System.Data.SqlClient.SqlException)
                        {
                            throw DbModelException.Create(obj, e as System.Data.SqlClient.SqlException);
                        }
                        else 
                            throw;
                    }
                }
                return bSuccess;
            }
            private bool _PostNonTransaction(DbManagerProxy manager, NextNumbersListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfsNumberName
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
            
            public bool ValidateCanDelete(NextNumbersListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, NextNumbersListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfsNumberName
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, ValidationEventType.Error, obj);
                        }
                     }
                }
                catch(ValidationModelException ex)
                {
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                    else
                        obj.m_IsForcedToDelete = true;
                }
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(NextNumbersListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(NextNumbersListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as NextNumbersListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, NextNumbersListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("DocumentNumbering.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("DocumentNumbering.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("DocumentNumbering.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("DocumentNumbering.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(NextNumbersListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(NextNumbersListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as NextNumbersListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as NextNumbersListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "NextNumbersListItemDetail"; } }
            public string HelpIdWin { get { return "Unique_Numbering_Schema"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private NextNumbersListItem m_obj;
            internal Permissions(NextNumbersListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("DocumentNumbering.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("DocumentNumbering.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("DocumentNumbering.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("DocumentNumbering.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_NextNumbers_SelectList";
            public static string spCount = "spNextNumbers_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spReadOnlyObject_Delete";
            public static string spCanDelete = "spReadOnlyObject_CanDelete";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<NextNumbersListItem, bool>> RequiredByField = new Dictionary<string, Func<NextNumbersListItem, bool>>();
            public static Dictionary<string, Func<NextNumbersListItem, bool>> RequiredByProperty = new Dictionary<string, Func<NextNumbersListItem, bool>>();
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
                
                Sizes.Add(_str_strPrefix, 50);
                Sizes.Add(_str_intNumberValue, 100);
                Sizes.Add(_str_strObjectName, 2000);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strObjectName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strObjectName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strPrefix",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strPrefix",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "intNumberValue",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "intNumberValue",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "intMinNumberLength",
                    EditorType.Numeric,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "intMinNumberLength",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsNumberName,
                    _str_idfsNumberName, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strObjectName,
                    _str_strObjectName, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPrefix,
                    _str_strPrefix, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intNumberValue,
                    _str_intNumberValue, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intMinNumberLength,
                    _str_intMinNumberLength, null, false, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "PrintBarcode",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).PrintBarcode(manager, (NextNumbersListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strPrintNumbers_Id",
                        "",
                        /*from BvMessages*/"strPrintNumbers_Id",
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<NextNumbers>().SelectDetail(manager, pars[0])),
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
	