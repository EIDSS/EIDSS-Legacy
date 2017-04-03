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
    public abstract partial class Line : 
        EditableObject<Line>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [LocalizedDisplayName(_str_idfDecorElement)]
        [MapField(_str_idfDecorElement)]
        public abstract Int64 idfDecorElement { get; set; }
        protected Int64 idfDecorElement_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfDecorElement).OriginalValue; } }
        protected Int64 idfDecorElement_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfDecorElement).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsDecorElementType)]
        [MapField(_str_idfsDecorElementType)]
        public abstract Int64 idfsDecorElementType { get; set; }
        protected Int64 idfsDecorElementType_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDecorElementType).OriginalValue; } }
        protected Int64 idfsDecorElementType_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDecorElementType).PreviousValue; } }
                
        [MapField(_str_langid), NonUpdatable, PrimaryKey]
        public abstract String langid { get; set; }
                
        [MapField(_str_idfsFormTemplate), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsFormTemplate { get; set; }
                
        [LocalizedDisplayName(_str_idfsSection)]
        [MapField(_str_idfsSection)]
        public abstract Int64? idfsSection { get; set; }
        protected Int64? idfsSection_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSection).OriginalValue; } }
        protected Int64? idfsSection_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSection).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intLeft)]
        [MapField(_str_intLeft)]
        public abstract Int32 intLeft { get; set; }
        protected Int32 intLeft_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intLeft).OriginalValue; } }
        protected Int32 intLeft_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intLeft).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intTop)]
        [MapField(_str_intTop)]
        public abstract Int32 intTop { get; set; }
        protected Int32 intTop_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intTop).OriginalValue; } }
        protected Int32 intTop_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intTop).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intWidth)]
        [MapField(_str_intWidth)]
        public abstract Int32? intWidth { get; set; }
        protected Int32? intWidth_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intWidth).OriginalValue; } }
        protected Int32? intWidth_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intWidth).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intHeight)]
        [MapField(_str_intHeight)]
        public abstract Int32? intHeight { get; set; }
        protected Int32? intHeight_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intHeight).OriginalValue; } }
        protected Int32? intHeight_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intHeight).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intColor)]
        [MapField(_str_intColor)]
        public abstract Int32? intColor { get; set; }
        protected Int32? intColor_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intColor).OriginalValue; } }
        protected Int32? intColor_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intColor).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnOrientation)]
        [MapField(_str_blnOrientation)]
        public abstract Boolean? blnOrientation { get; set; }
        protected Boolean? blnOrientation_Original { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnOrientation).OriginalValue; } }
        protected Boolean? blnOrientation_Previous { get { return ((EditableValue<Boolean?>)((dynamic)this)._blnOrientation).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<Line, object> _get_func;
            internal Action<Line, string> _set_func;
            internal Action<Line, Line, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfDecorElement = "idfDecorElement";
        internal const string _str_idfsDecorElementType = "idfsDecorElementType";
        internal const string _str_langid = "langid";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_idfsSection = "idfsSection";
        internal const string _str_intLeft = "intLeft";
        internal const string _str_intTop = "intTop";
        internal const string _str_intWidth = "intWidth";
        internal const string _str_intHeight = "intHeight";
        internal const string _str_intColor = "intColor";
        internal const string _str_blnOrientation = "blnOrientation";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfDecorElement, _formname = _str_idfDecorElement, _type = "Int64",
              _get_func = o => o.idfDecorElement,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfDecorElement != newval) o.idfDecorElement = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfDecorElement != c.idfDecorElement || o.IsRIRPropChanged(_str_idfDecorElement, c)) 
                  m.Add(_str_idfDecorElement, o.ObjectIdent + _str_idfDecorElement, o.ObjectIdent2 + _str_idfDecorElement, o.ObjectIdent3 + _str_idfDecorElement, "Int64", 
                    o.idfDecorElement == null ? "" : o.idfDecorElement.ToString(),                  
                  o.IsReadOnly(_str_idfDecorElement), o.IsInvisible(_str_idfDecorElement), o.IsRequired(_str_idfDecorElement)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDecorElementType, _formname = _str_idfsDecorElementType, _type = "Int64",
              _get_func = o => o.idfsDecorElementType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsDecorElementType != newval) o.idfsDecorElementType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDecorElementType != c.idfsDecorElementType || o.IsRIRPropChanged(_str_idfsDecorElementType, c)) 
                  m.Add(_str_idfsDecorElementType, o.ObjectIdent + _str_idfsDecorElementType, o.ObjectIdent2 + _str_idfsDecorElementType, o.ObjectIdent3 + _str_idfsDecorElementType, "Int64", 
                    o.idfsDecorElementType == null ? "" : o.idfsDecorElementType.ToString(),                  
                  o.IsReadOnly(_str_idfsDecorElementType), o.IsInvisible(_str_idfsDecorElementType), o.IsRequired(_str_idfsDecorElementType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_langid, _formname = _str_langid, _type = "String",
              _get_func = o => o.langid,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.langid != newval) o.langid = newval; },
              _compare_func = (o, c, m) => {
                if (o.langid != c.langid || o.IsRIRPropChanged(_str_langid, c)) 
                  m.Add(_str_langid, o.ObjectIdent + _str_langid, o.ObjectIdent2 + _str_langid, o.ObjectIdent3 + _str_langid, "String", 
                    o.langid == null ? "" : o.langid.ToString(),                  
                  o.IsReadOnly(_str_langid), o.IsInvisible(_str_langid), o.IsRequired(_str_langid)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsFormTemplate, _formname = _str_idfsFormTemplate, _type = "Int64",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsFormTemplate != newval) o.idfsFormTemplate = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, o.ObjectIdent2 + _str_idfsFormTemplate, o.ObjectIdent3 + _str_idfsFormTemplate, "Int64", 
                    o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSection, _formname = _str_idfsSection, _type = "Int64?",
              _get_func = o => o.idfsSection,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSection != newval) o.idfsSection = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSection != c.idfsSection || o.IsRIRPropChanged(_str_idfsSection, c)) 
                  m.Add(_str_idfsSection, o.ObjectIdent + _str_idfsSection, o.ObjectIdent2 + _str_idfsSection, o.ObjectIdent3 + _str_idfsSection, "Int64?", 
                    o.idfsSection == null ? "" : o.idfsSection.ToString(),                  
                  o.IsReadOnly(_str_idfsSection), o.IsInvisible(_str_idfsSection), o.IsRequired(_str_idfsSection)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intLeft, _formname = _str_intLeft, _type = "Int32",
              _get_func = o => o.intLeft,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intLeft != newval) o.intLeft = newval; },
              _compare_func = (o, c, m) => {
                if (o.intLeft != c.intLeft || o.IsRIRPropChanged(_str_intLeft, c)) 
                  m.Add(_str_intLeft, o.ObjectIdent + _str_intLeft, o.ObjectIdent2 + _str_intLeft, o.ObjectIdent3 + _str_intLeft, "Int32", 
                    o.intLeft == null ? "" : o.intLeft.ToString(),                  
                  o.IsReadOnly(_str_intLeft), o.IsInvisible(_str_intLeft), o.IsRequired(_str_intLeft)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intTop, _formname = _str_intTop, _type = "Int32",
              _get_func = o => o.intTop,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intTop != newval) o.intTop = newval; },
              _compare_func = (o, c, m) => {
                if (o.intTop != c.intTop || o.IsRIRPropChanged(_str_intTop, c)) 
                  m.Add(_str_intTop, o.ObjectIdent + _str_intTop, o.ObjectIdent2 + _str_intTop, o.ObjectIdent3 + _str_intTop, "Int32", 
                    o.intTop == null ? "" : o.intTop.ToString(),                  
                  o.IsReadOnly(_str_intTop), o.IsInvisible(_str_intTop), o.IsRequired(_str_intTop)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intWidth, _formname = _str_intWidth, _type = "Int32?",
              _get_func = o => o.intWidth,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intWidth != newval) o.intWidth = newval; },
              _compare_func = (o, c, m) => {
                if (o.intWidth != c.intWidth || o.IsRIRPropChanged(_str_intWidth, c)) 
                  m.Add(_str_intWidth, o.ObjectIdent + _str_intWidth, o.ObjectIdent2 + _str_intWidth, o.ObjectIdent3 + _str_intWidth, "Int32?", 
                    o.intWidth == null ? "" : o.intWidth.ToString(),                  
                  o.IsReadOnly(_str_intWidth), o.IsInvisible(_str_intWidth), o.IsRequired(_str_intWidth)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intHeight, _formname = _str_intHeight, _type = "Int32?",
              _get_func = o => o.intHeight,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intHeight != newval) o.intHeight = newval; },
              _compare_func = (o, c, m) => {
                if (o.intHeight != c.intHeight || o.IsRIRPropChanged(_str_intHeight, c)) 
                  m.Add(_str_intHeight, o.ObjectIdent + _str_intHeight, o.ObjectIdent2 + _str_intHeight, o.ObjectIdent3 + _str_intHeight, "Int32?", 
                    o.intHeight == null ? "" : o.intHeight.ToString(),                  
                  o.IsReadOnly(_str_intHeight), o.IsInvisible(_str_intHeight), o.IsRequired(_str_intHeight)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intColor, _formname = _str_intColor, _type = "Int32?",
              _get_func = o => o.intColor,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intColor != newval) o.intColor = newval; },
              _compare_func = (o, c, m) => {
                if (o.intColor != c.intColor || o.IsRIRPropChanged(_str_intColor, c)) 
                  m.Add(_str_intColor, o.ObjectIdent + _str_intColor, o.ObjectIdent2 + _str_intColor, o.ObjectIdent3 + _str_intColor, "Int32?", 
                    o.intColor == null ? "" : o.intColor.ToString(),                  
                  o.IsReadOnly(_str_intColor), o.IsInvisible(_str_intColor), o.IsRequired(_str_intColor)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnOrientation, _formname = _str_blnOrientation, _type = "Boolean?",
              _get_func = o => o.blnOrientation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBooleanNullable(val); if (o.blnOrientation != newval) o.blnOrientation = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnOrientation != c.blnOrientation || o.IsRIRPropChanged(_str_blnOrientation, c)) 
                  m.Add(_str_blnOrientation, o.ObjectIdent + _str_blnOrientation, o.ObjectIdent2 + _str_blnOrientation, o.ObjectIdent3 + _str_blnOrientation, "Boolean?", 
                    o.blnOrientation == null ? "" : o.blnOrientation.ToString(),                  
                  o.IsReadOnly(_str_blnOrientation), o.IsInvisible(_str_blnOrientation), o.IsRequired(_str_blnOrientation)); 
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
            Line obj = (Line)o;
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
        internal string m_ObjectName = "Line";

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
            var ret = base.Clone() as Line;
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
            var ret = base.Clone() as Line;
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
        public Line CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Line;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsFormTemplate; } }
        public string KeyName { get { return "idfsFormTemplate"; } }
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

        private bool IsRIRPropChanged(string fld, Line c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public Line()
        {
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Line_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Line_PropertyChanged);
        }
        private void Line_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Line).Changed(e.PropertyName);
            
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
            Line obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Line obj = this;
            
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
        
            }
        }


        internal Dictionary<string, Func<Line, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Line, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Line, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Line, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Line, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<Line, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<Line, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~Line()
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
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<Line>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<Line>
            
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsFormTemplate"; } }
            #endregion
        
            private delegate void on_action(Line obj);
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
            
            public virtual List<Line> SelectList(DbManagerProxy manager
                , Int64? idfsFormTemplate
                )
            {
                return _SelectList(manager
                    , idfsFormTemplate
                    , delegate(Line obj)
                        {
                        }
                    , delegate(Line obj)
                        {
                        }
                    );
            }

            
            public List<Line> SelectDetailListT(DbManagerProxy manager, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                
                if (!(pars[0] is Int64?)) 
                    throw new TypeMismatchException("idfsFormTemplate", typeof(Int64?));
                
                return SelectDetailList(manager
                    
                    , (Int64?)pars[0]
                    
                    );
            }
            public List<Line> SelectDetailList(DbManagerProxy manager, List<object> pars)
            {
                return SelectDetailListT(manager, pars);
            }
            
            public virtual List<Line> SelectDetailList(DbManagerProxy manager
                , Int64? idfsFormTemplate
                )
            {
                return _SelectList(manager
                    , idfsFormTemplate
                    , delegate(Line obj)
                        {
                
                        }
                    , delegate(Line obj)
                        {
                
                        }
                    );
            }
            
            private List<Line> _SelectList(DbManagerProxy manager
                , Int64? idfsFormTemplate
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<Line> objs = new List<Line>();
                    sets[0] = new MapResultSet(typeof(Line), objs);
                    
                    manager
                        .SetSpCommand("spFFGetLines"
                            , manager.Parameter("@idfsFormTemplate", idfsFormTemplate)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
                        obj.m_CS = m_CS;
                        
                        if (loading != null)
                            loading(obj);
                        _SetupLoad(manager, obj);
                        
                        if (loaded != null)
                            loaded(obj);
                    }
                    
                    return objs;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(e);
                }
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, Line obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, Line obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private Line _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    Line obj = Line.CreateInstance();
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

            
            public Line CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Line CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public Line CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(Line obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Line obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, Line obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(Line obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(Line obj, bool bRethrowException)
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
                return Validate(manager, obj as Line, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Line obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(Line obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(Line obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Line) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Line) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LineDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFFGetLines";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Line, bool>> RequiredByField = new Dictionary<string, Func<Line, bool>>();
            public static Dictionary<string, Func<Line, bool>> RequiredByProperty = new Dictionary<string, Func<Line, bool>>();
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
                
                Sizes.Add(_str_langid, 50);
                Actions.Add(new ActionMetaItem(
                    "SelectDetailList",
                    ActionTypes.Loadlist,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    null,
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
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
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
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Line>().Post(manager, (Line)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Line>().Post(manager, (Line)c), c),
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
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((Line)c).MarkToDelete() && ObjectAccessor.PostInterface<Line>().Post(manager, (Line)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
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
	