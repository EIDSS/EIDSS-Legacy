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
    public abstract partial class AntimicrobialTherapy : 
        EditableObject<AntimicrobialTherapy>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfAntimicrobialTherapy), NonUpdatable, PrimaryKey]
        public abstract Int64 idfAntimicrobialTherapy { get; set; }
                
        [LocalizedDisplayName(_str_idfHumanCase)]
        [MapField(_str_idfHumanCase)]
        public abstract Int64 idfHumanCase { get; set; }
        #if MONO
        protected Int64 idfHumanCase_Original { get { return idfHumanCase; } }
        protected Int64 idfHumanCase_Previous { get { return idfHumanCase; } }
        #else
        protected Int64 idfHumanCase_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfHumanCase).OriginalValue; } }
        protected Int64 idfHumanCase_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfHumanCase).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datFirstAdministeredDate)]
        [MapField(_str_datFirstAdministeredDate)]
        public abstract DateTime? datFirstAdministeredDate { get; set; }
        #if MONO
        protected DateTime? datFirstAdministeredDate_Original { get { return datFirstAdministeredDate; } }
        protected DateTime? datFirstAdministeredDate_Previous { get { return datFirstAdministeredDate; } }
        #else
        protected DateTime? datFirstAdministeredDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFirstAdministeredDate).OriginalValue; } }
        protected DateTime? datFirstAdministeredDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFirstAdministeredDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strAntimicrobialTherapyName)]
        [MapField(_str_strAntimicrobialTherapyName)]
        public abstract String strAntimicrobialTherapyName { get; set; }
        #if MONO
        protected String strAntimicrobialTherapyName_Original { get { return strAntimicrobialTherapyName; } }
        protected String strAntimicrobialTherapyName_Previous { get { return strAntimicrobialTherapyName; } }
        #else
        protected String strAntimicrobialTherapyName_Original { get { return ((EditableValue<String>)((dynamic)this)._strAntimicrobialTherapyName).OriginalValue; } }
        protected String strAntimicrobialTherapyName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAntimicrobialTherapyName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strDosage)]
        [MapField(_str_strDosage)]
        public abstract String strDosage { get; set; }
        #if MONO
        protected String strDosage_Original { get { return strDosage; } }
        protected String strDosage_Previous { get { return strDosage; } }
        #else
        protected String strDosage_Original { get { return ((EditableValue<String>)((dynamic)this)._strDosage).OriginalValue; } }
        protected String strDosage_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDosage).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<AntimicrobialTherapy, object> _get_func;
            internal Action<AntimicrobialTherapy, string> _set_func;
            internal Action<AntimicrobialTherapy, AntimicrobialTherapy, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAntimicrobialTherapy = "idfAntimicrobialTherapy";
        internal const string _str_idfHumanCase = "idfHumanCase";
        internal const string _str_datFirstAdministeredDate = "datFirstAdministeredDate";
        internal const string _str_strAntimicrobialTherapyName = "strAntimicrobialTherapyName";
        internal const string _str_strDosage = "strDosage";
        internal const string _str_NewObject = "NewObject";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfAntimicrobialTherapy, _type = "Int64",
              _get_func = o => o.idfAntimicrobialTherapy,
              _set_func = (o, val) => { o.idfAntimicrobialTherapy = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAntimicrobialTherapy != c.idfAntimicrobialTherapy || o.IsRIRPropChanged(_str_idfAntimicrobialTherapy, c)) 
                  m.Add(_str_idfAntimicrobialTherapy, o.ObjectIdent + _str_idfAntimicrobialTherapy, "Int64", o.idfAntimicrobialTherapy == null ? "" : o.idfAntimicrobialTherapy.ToString(), o.IsReadOnly(_str_idfAntimicrobialTherapy), o.IsInvisible(_str_idfAntimicrobialTherapy), o.IsRequired(_str_idfAntimicrobialTherapy)); }
              }, 
        
            new field_info {
              _name = _str_idfHumanCase, _type = "Int64",
              _get_func = o => o.idfHumanCase,
              _set_func = (o, val) => { o.idfHumanCase = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfHumanCase != c.idfHumanCase || o.IsRIRPropChanged(_str_idfHumanCase, c)) 
                  m.Add(_str_idfHumanCase, o.ObjectIdent + _str_idfHumanCase, "Int64", o.idfHumanCase == null ? "" : o.idfHumanCase.ToString(), o.IsReadOnly(_str_idfHumanCase), o.IsInvisible(_str_idfHumanCase), o.IsRequired(_str_idfHumanCase)); }
              }, 
        
            new field_info {
              _name = _str_datFirstAdministeredDate, _type = "DateTime?",
              _get_func = o => o.datFirstAdministeredDate,
              _set_func = (o, val) => { o.datFirstAdministeredDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datFirstAdministeredDate != c.datFirstAdministeredDate || o.IsRIRPropChanged(_str_datFirstAdministeredDate, c)) 
                  m.Add(_str_datFirstAdministeredDate, o.ObjectIdent + _str_datFirstAdministeredDate, "DateTime?", o.datFirstAdministeredDate == null ? "" : o.datFirstAdministeredDate.ToString(), o.IsReadOnly(_str_datFirstAdministeredDate), o.IsInvisible(_str_datFirstAdministeredDate), o.IsRequired(_str_datFirstAdministeredDate)); }
              }, 
        
            new field_info {
              _name = _str_strAntimicrobialTherapyName, _type = "String",
              _get_func = o => o.strAntimicrobialTherapyName,
              _set_func = (o, val) => { o.strAntimicrobialTherapyName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strAntimicrobialTherapyName != c.strAntimicrobialTherapyName || o.IsRIRPropChanged(_str_strAntimicrobialTherapyName, c)) 
                  m.Add(_str_strAntimicrobialTherapyName, o.ObjectIdent + _str_strAntimicrobialTherapyName, "String", o.strAntimicrobialTherapyName == null ? "" : o.strAntimicrobialTherapyName.ToString(), o.IsReadOnly(_str_strAntimicrobialTherapyName), o.IsInvisible(_str_strAntimicrobialTherapyName), o.IsRequired(_str_strAntimicrobialTherapyName)); }
              }, 
        
            new field_info {
              _name = _str_strDosage, _type = "String",
              _get_func = o => o.strDosage,
              _set_func = (o, val) => { o.strDosage = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strDosage != c.strDosage || o.IsRIRPropChanged(_str_strDosage, c)) 
                  m.Add(_str_strDosage, o.ObjectIdent + _str_strDosage, "String", o.strDosage == null ? "" : o.strDosage.ToString(), o.IsReadOnly(_str_strDosage), o.IsInvisible(_str_strDosage), o.IsRequired(_str_strDosage)); }
              }, 
        
            new field_info {
              _name = _str_NewObject, _type = "bool",
              _get_func = o => o.NewObject,
              _set_func = (o, val) => { o.NewObject = ParsingHelper.ParseBoolean(val); },
              _compare_func = (o, c, m) => {
              
                if (o.NewObject != c.NewObject || o.IsRIRPropChanged(_str_NewObject, c)) 
                  m.Add(_str_NewObject, o.ObjectIdent + _str_NewObject, "bool", o.NewObject == null ? "" : o.NewObject.ToString(), o.IsReadOnly(_str_NewObject), o.IsInvisible(_str_NewObject), o.IsRequired(_str_NewObject));
                 }
              }, 
        
            new field_info {
              _name = _str_CaseObjectIdent, _type = "string",
              _get_func = o => o.CaseObjectIdent,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.CaseObjectIdent != c.CaseObjectIdent || o.IsRIRPropChanged(_str_CaseObjectIdent, c)) 
                  m.Add(_str_CaseObjectIdent, o.ObjectIdent + _str_CaseObjectIdent, "string", o.CaseObjectIdent == null ? "" : o.CaseObjectIdent.ToString(), o.IsReadOnly(_str_CaseObjectIdent), o.IsInvisible(_str_CaseObjectIdent), o.IsRequired(_str_CaseObjectIdent));
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
            AntimicrobialTherapy obj = (AntimicrobialTherapy)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<AntimicrobialTherapy, string>(c => "HumanCase_" + c.idfHumanCase + "_")(this); }
            
        }
        
          [LocalizedDisplayName(_str_NewObject)]
        public bool NewObject
        {
            get { return m_NewObject; }
            set { if (m_NewObject != value) { m_NewObject = value; OnPropertyChanged(_str_NewObject); } }
        }
        private bool m_NewObject;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AntimicrobialTherapy";

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
        public override object Clone()
        {
            var ret = base.Clone() as AntimicrobialTherapy;
            ret.m_Parent = this.Parent;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager)
        {
            var ret = base.Clone() as AntimicrobialTherapy;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AntimicrobialTherapy CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AntimicrobialTherapy;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfAntimicrobialTherapy; } }
        public string KeyName { get { return "idfAntimicrobialTherapy"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
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
      public IObjectAccessor GetAccessor() { return _getAccessor(); }
      public IObjectPermissions GetPermissions() { return _permissions; }
      public bool ReadOnly { get { return _readOnly; } set { _readOnly = value; } }
      public bool IsReadOnly(string name) { return _isReadOnly(name); }
      public bool IsInvisible(string name) { return _isInvisible(name); }
      public bool IsRequired(string name) { return _isRequired(name); }
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

      private bool IsRIRPropChanged(string fld, AntimicrobialTherapy c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public AntimicrobialTherapy()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();

        

        private bool m_IsForcedToDelete;
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AntimicrobialTherapy_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AntimicrobialTherapy_PropertyChanged);
        }
        private void AntimicrobialTherapy_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AntimicrobialTherapy).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfHumanCase)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
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
            AntimicrobialTherapy obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AntimicrobialTherapy obj = this;
            
        }
        
        public bool OnValidation(string msgId, string fldName, string prpName, object[] pars, Type type, bool shouldAsk)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(msgId, fldName, prpName, pars, type, this, shouldAsk);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(string msgId, string fldName, string prpName, object[] pars, Type type, bool shouldAsk)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(msgId, fldName, prpName, pars, type, this, shouldAsk);
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


        public Dictionary<string, Func<AntimicrobialTherapy, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AntimicrobialTherapy, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AntimicrobialTherapy, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<AntimicrobialTherapy, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<AntimicrobialTherapy, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<AntimicrobialTherapy, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AntimicrobialTherapy()
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
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._name] != null) a._set_func(this, form[ObjectIdent + a._name]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._name)) a._set_func(this, form[ObjectIdent + a._name]);} );
      
            if (bParseRelations)
            {
        
            }
        }
    
        #region Class for web grid
        public class AntimicrobialTherapyGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfAntimicrobialTherapy { get; set; }
        
            public String strAntimicrobialTherapyName { get; set; }
        
            public String strDosage { get; set; }
        
            public DateTime? datFirstAdministeredDate { get; set; }
        
        }
        public partial class AntimicrobialTherapyGridModelList : List<AntimicrobialTherapyGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public AntimicrobialTherapyGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AntimicrobialTherapy>, errMes);
            }
            public AntimicrobialTherapyGridModelList(long key, IEnumerable<AntimicrobialTherapy> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<AntimicrobialTherapy> items);
            private void LoadGridModelList(long key, IEnumerable<AntimicrobialTherapy> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strAntimicrobialTherapyName,_str_strDosage,_str_datFirstAdministeredDate};
                    
                Hiddens = new List<string> {_str_idfAntimicrobialTherapy};
                Keys = new List<string> {_str_idfAntimicrobialTherapy};
                Labels = new Dictionary<string, string> {{_str_strAntimicrobialTherapyName, _str_strAntimicrobialTherapyName},{_str_strDosage, _str_strDosage},{_str_datFirstAdministeredDate, _str_datFirstAdministeredDate}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<AntimicrobialTherapy>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AntimicrobialTherapyGridModel()
                {
                    ItemKey=c.idfAntimicrobialTherapy,strAntimicrobialTherapyName=c.strAntimicrobialTherapyName,strDosage=c.strDosage,datFirstAdministeredDate=c.datFirstAdministeredDate
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
        : DataAccessor<AntimicrobialTherapy>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(AntimicrobialTherapy obj);
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
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<AntimicrobialTherapy> SelectList(DbManagerProxy manager
                , Int64? idfCase
                )
            {
                return _SelectList(manager
                    , idfCase
                    , delegate(AntimicrobialTherapy obj)
                        {
                        }
                    , delegate(AntimicrobialTherapy obj)
                        {
                        }
                    );
            }

            
            private List<AntimicrobialTherapy> _SelectList(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AntimicrobialTherapy> objs = new List<AntimicrobialTherapy>();
                    sets[0] = new MapResultSet(typeof(AntimicrobialTherapy), objs);
                    
                    manager
                        .SetSpCommand("spAntimicrobialTherapy_SelectDetail"
                            , manager.Parameter("@idfCase", idfCase)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AntimicrobialTherapy obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AntimicrobialTherapy obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AntimicrobialTherapy _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    AntimicrobialTherapy obj = AntimicrobialTherapy.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfAntimicrobialTherapy = (new GetNewIDExtender<AntimicrobialTherapy>()).GetScalar(manager, obj);
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

            
            public AntimicrobialTherapy CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public AntimicrobialTherapy CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public AntimicrobialTherapy CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfHumanCase", typeof(long));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public AntimicrobialTherapy Create(DbManagerProxy manager, IObject Parent
                , long idfHumanCase
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfHumanCase = new Func<AntimicrobialTherapy, long>(c => idfHumanCase)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(AntimicrobialTherapy obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AntimicrobialTherapy obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, AntimicrobialTherapy obj)
            {
                
            }
    
            [SprocName("spAntimicrobialTherapy_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            [SprocName("spAntimicrobialTherapy_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] AntimicrobialTherapy obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] AntimicrobialTherapy obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AntimicrobialTherapy bo = obj as AntimicrobialTherapy;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as AntimicrobialTherapy, bChildObject);
                    if (bTransactionStarted)
                    {
                        if (bSuccess)
                        {
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
            private bool _PostNonTransaction(DbManagerProxy manager, AntimicrobialTherapy obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfAntimicrobialTherapy
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (!obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AntimicrobialTherapy obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AntimicrobialTherapy obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as AntimicrobialTherapy, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AntimicrobialTherapy obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "strAntimicrobialTherapyName", "strAntimicrobialTherapyName","",
                false
              )).Validate(c => true, obj, obj.strAntimicrobialTherapyName);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                    }
                }
                catch(ValidationModelException ex)
                {
                    if (bRethrowException)
                        throw;
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                        return false;
                    }
                }
                
                return true;
            }
           
    
            private void _SetupRequired(AntimicrobialTherapy obj)
            {
            
                obj
                    .AddRequired("strAntimicrobialTherapyName", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(AntimicrobialTherapy obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AntimicrobialTherapy) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AntimicrobialTherapy) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AntimicrobialTherapyDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spAntimicrobialTherapy_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spAntimicrobialTherapy_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spAntimicrobialTherapy_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AntimicrobialTherapy, bool>> RequiredByField = new Dictionary<string, Func<AntimicrobialTherapy, bool>>();
            public static Dictionary<string, Func<AntimicrobialTherapy, bool>> RequiredByProperty = new Dictionary<string, Func<AntimicrobialTherapy, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strAntimicrobialTherapyName, 200);
                Sizes.Add(_str_strDosage, 200);
                if (!RequiredByField.ContainsKey("strAntimicrobialTherapyName")) RequiredByField.Add("strAntimicrobialTherapyName", c => true);
                if (!RequiredByProperty.ContainsKey("strAntimicrobialTherapyName")) RequiredByProperty.Add("strAntimicrobialTherapyName", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfAntimicrobialTherapy,
                    _str_idfAntimicrobialTherapy, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strAntimicrobialTherapyName,
                    _str_strAntimicrobialTherapyName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDosage,
                    _str_strDosage, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFirstAdministeredDate,
                    _str_datFirstAdministeredDate, null, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).Create(manager, c, pars)),
                        
                    null,
                    
                    null,
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
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, null, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
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
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
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
                    (manager, c, pars) => ((AntimicrobialTherapy)c).MarkToDelete(),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
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
                    (manager, c, pars) => new ActResult(true, c),
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	