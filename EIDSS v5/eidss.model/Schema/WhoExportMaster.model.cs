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
    public abstract partial class WhoExportMaster : 
        EditableObject<WhoExportMaster>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsReferenceType), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsReferenceType { get; set; }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<WhoExportMaster, object> _get_func;
            internal Action<WhoExportMaster, string> _set_func;
            internal Action<WhoExportMaster, WhoExportMaster, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsReferenceType = "idfsReferenceType";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_datEndDate = "datEndDate";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_DiagnosisList = "DiagnosisList";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_WhoExportItems = "WhoExportItems";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfsReferenceType, _type = "Int64",
              _get_func = o => o.idfsReferenceType,
              _set_func = (o, val) => { o.idfsReferenceType = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsReferenceType != c.idfsReferenceType || o.IsRIRPropChanged(_str_idfsReferenceType, c)) 
                  m.Add(_str_idfsReferenceType, o.ObjectIdent + _str_idfsReferenceType, "Int64", o.idfsReferenceType == null ? "" : o.idfsReferenceType.ToString(), o.IsReadOnly(_str_idfsReferenceType), o.IsInvisible(_str_idfsReferenceType), o.IsRequired(_str_idfsReferenceType)); }
              }, 
        
            new field_info {
              _name = _str_datStartDate, _type = "DateTime",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { o.datStartDate = ParsingHelper.ParseDateTime(val); },
              _compare_func = (o, c, m) => {
              
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, "DateTime", o.datStartDate == null ? "" : o.datStartDate.ToString(), o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate));
                 }
              }, 
        
            new field_info {
              _name = _str_datEndDate, _type = "DateTime",
              _get_func = o => o.datEndDate,
              _set_func = (o, val) => { o.datEndDate = ParsingHelper.ParseDateTime(val); },
              _compare_func = (o, c, m) => {
              
                if (o.datEndDate != c.datEndDate || o.IsRIRPropChanged(_str_datEndDate, c)) 
                  m.Add(_str_datEndDate, o.ObjectIdent + _str_datEndDate, "DateTime", o.datEndDate == null ? "" : o.datEndDate.ToString(), o.IsReadOnly(_str_datEndDate), o.IsInvisible(_str_datEndDate), o.IsRequired(_str_datEndDate));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosis, _type = "long?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { o.idfsDiagnosis = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
              
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, "long?", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis));
                 }
              }, 
        
            new field_info {
              _name = _str_DiagnosisList, _type = "List<long>",
              _get_func = o => o.DiagnosisList,
              _set_func = (o, val) => { ; },
              _compare_func = (o, c, m) => {
               }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c)) 
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); }
              }, 
        
            new field_info {
              _name = _str_WhoExportItems, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.WhoExportItems.Count != c.WhoExportItems.Count || o.IsReadOnly(_str_WhoExportItems) != c.IsReadOnly(_str_WhoExportItems) || o.IsInvisible(_str_WhoExportItems) != c.IsInvisible(_str_WhoExportItems) || o.IsRequired(_str_WhoExportItems) != c.IsRequired(_str_WhoExportItems)) 
                  m.Add(_str_WhoExportItems, o.ObjectIdent + _str_WhoExportItems, "Child", o.idfsReferenceType == null ? "" : o.idfsReferenceType.ToString(), o.IsReadOnly(_str_WhoExportItems), o.IsInvisible(_str_WhoExportItems), o.IsRequired(_str_WhoExportItems)); }
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
            WhoExportMaster obj = (WhoExportMaster)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(WhoExport), eidss.model.Schema.WhoExport._str_idfCase, _str_idfsReferenceType)]
        public EditableList<WhoExport> WhoExportItems
        {
            get 
            {   
                return _WhoExportItems; 
            }
            set 
            {
                _WhoExportItems = value;
            }
        }
        protected EditableList<WhoExport> _WhoExportItems = new EditableList<WhoExport>();
                    
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis; }
            set 
            { 
                _Diagnosis = value;
                idfsDiagnosis = _Diagnosis == null 
                    ? new long?()
                    : _Diagnosis.idfsDiagnosis; 
                OnPropertyChanged(_str_Diagnosis); 
            }
        }
        private DiagnosisLookup _Diagnosis;

        
        public List<DiagnosisLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<DiagnosisLookup> _DiagnosisLookup = new List<DiagnosisLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_datStartDate)]
        public DateTime datStartDate
        {
            get { return m_datStartDate; }
            set { if (m_datStartDate != value) { m_datStartDate = value; OnPropertyChanged(_str_datStartDate); } }
        }
        private DateTime m_datStartDate;
        
          [LocalizedDisplayName(_str_datEndDate)]
        public DateTime datEndDate
        {
            get { return m_datEndDate; }
            set { if (m_datEndDate != value) { m_datEndDate = value; OnPropertyChanged(_str_datEndDate); } }
        }
        private DateTime m_datEndDate;
        
          [LocalizedDisplayName(_str_idfsDiagnosis)]
        public long? idfsDiagnosis
        {
            get { return m_idfsDiagnosis; }
            set { if (m_idfsDiagnosis != value) { m_idfsDiagnosis = value; OnPropertyChanged(_str_idfsDiagnosis); } }
        }
        private long? m_idfsDiagnosis;
        
          [LocalizedDisplayName(_str_DiagnosisList)]
        public List<long> DiagnosisList
        {
            get { return m_DiagnosisList; }
            set { if (m_DiagnosisList != value) { m_DiagnosisList = value; OnPropertyChanged(_str_DiagnosisList); } }
        }
        private List<long> m_DiagnosisList;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "WhoExportMaster";

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
        WhoExportItems.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as WhoExportMaster;
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
            var ret = base.Clone() as WhoExportMaster;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public WhoExportMaster CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as WhoExportMaster;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsReferenceType; } }
        public string KeyName { get { return "idfsReferenceType"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || WhoExportItems.IsDirty
                    || WhoExportItems.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        WhoExportItems.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        WhoExportItems.AcceptChanges();
                
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
        WhoExportItems.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, WhoExportMaster c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public WhoExportMaster()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(WhoExportMaster_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(WhoExportMaster_PropertyChanged);
        }
        private void WhoExportMaster_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as WhoExportMaster).Changed(e.PropertyName);
            
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
            WhoExportMaster obj = this;
            
        }
        private void _DeletedExtenders()
        {
            WhoExportMaster obj = this;
            
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
        
                foreach(var o in _WhoExportItems)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<WhoExportMaster, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<WhoExportMaster, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<WhoExportMaster, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<WhoExportMaster, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<WhoExportMaster, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<WhoExportMaster, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~WhoExportMaster()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
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
        
            if (_WhoExportItems != null) _WhoExportItems.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<WhoExportMaster>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(WhoExportMaster obj);
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
            private WhoExport.Accessor WhoExportItemsAccessor { get { return eidss.model.Schema.WhoExport.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , null, null
                        );
                }
            }

            
            public virtual WhoExportMaster SelectByKey(DbManagerProxy manager
                )
            {
                return _SelectByKey(manager
                    , null, null
                    );
            }
            
      
            private WhoExportMaster _SelectByKey(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<WhoExportMaster> objs = new List<WhoExportMaster>();
                sets[0] = new MapResultSet(typeof(WhoExportMaster), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spWhoExportMaster_SelectDetail"
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    WhoExportMaster obj = objs[0];
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
    
            private void _SetupAddChildHandlerWhoExportItems(WhoExportMaster obj)
            {
                obj.WhoExportItems.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadWhoExportItems(WhoExportMaster obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadWhoExportItems(manager, obj);
                }
            }
            internal void _LoadWhoExportItems(DbManagerProxy manager, WhoExportMaster obj)
            {
                
                obj.WhoExportItems.Clear();
                obj.WhoExportItems.AddRange(WhoExportItemsAccessor.SelectList(manager
                    
                    , new Func<WhoExportMaster, DateTime?>(c => c.datStartDate)(obj)
                    
                    , new Func<WhoExportMaster, DateTime?>(c => c.datEndDate)(obj)
                    
                    , new Func<WhoExportMaster, long?>(c => c.idfsDiagnosis)(obj)
                    
                    ));
                obj.WhoExportItems.ForEach(c => c.m_ObjectName = _str_WhoExportItems);
                obj.WhoExportItems.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, WhoExportMaster obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj.datEndDate = new Func<WhoExportMaster, DateTime>(c => DateTime.Today.AddDays(-DateTime.Today.Day+1).AddMonths(1).AddDays(-1))(obj);
                obj.datStartDate = new Func<WhoExportMaster, DateTime>(c => c.datEndDate.AddDays(1).AddMonths(-1-EidssSiteContext.Instance.GetGlobalSiteOptionAsInt("WhoReportPeriod", 6)))(obj);
                obj.DiagnosisList = manager.SetCommand(@"
select d.idfsDiagnosis
   from trtDiagnosis d
     inner join dbo.trtDiagnosisToGroupForReportType dgrt
     on dgrt.idfsDiagnosis = d.idfsDiagnosis
     and dgrt.idfsSummaryReportType = 10290027
     
     inner join dbo.trtDiagnosisGroup dg
     on dgrt.idfsDiagnosisGroup = dg.idfsDiagnosisGroup
     and dg.intRowStatus = 0 and dg.strDiagnosisGroupAlias in ('DG_Measles', 'DG_Rubella')
    where d.intRowStatus = 0"
                    ).ExecuteScalarList<long>();
              LoadLookup_Diagnosis(manager, obj);
            
                obj.Diagnosis = new Func<WhoExportMaster, DiagnosisLookup>(c => c.DiagnosisLookup.FirstOrDefault())(obj);
                // loading extenters - end
                
                _LoadWhoExportItems(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerWhoExportItems(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, WhoExportMaster obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.WhoExportItems.ForEach(c => WhoExportItemsAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private WhoExportMaster _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    WhoExportMaster obj = WhoExportMaster.CreateInstance();
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
                    
                    _SetupAddChildHandlerWhoExportItems(obj);
                    
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

            
            public WhoExportMaster CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public WhoExportMaster CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult Export(DbManagerProxy manager, WhoExportMaster obj, List<object> pars)
            {
                
                return Export(manager, obj
                    );
            }
            public ActResult Export(DbManagerProxy manager, WhoExportMaster obj
                )
            {
                
                return true;
                
            }
            
            public ActResult Edit(DbManagerProxy manager, WhoExportMaster obj, List<object> pars)
            {
                
                return Edit(manager, obj
                    );
            }
            public ActResult Edit(DbManagerProxy manager, WhoExportMaster obj
                )
            {
                
                return true;
                
            }
            
            public ActResult Refresh(DbManagerProxy manager, WhoExportMaster obj, List<object> pars)
            {
                
                return Refresh(manager, obj
                    );
            }
            public ActResult Refresh(DbManagerProxy manager, WhoExportMaster obj
                )
            {
                
              _LoadWhoExportItems(manager, obj);
              return true;
            
            }
            
            private void _SetupChildHandlers(WhoExportMaster obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(WhoExportMaster obj)
            {
                
            }
    
            public void LoadLookup_Diagnosis(DbManagerProxy manager, WhoExportMaster obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => obj.DiagnosisList.Contains(c.idfsDiagnosis))
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != null && obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .Where(c => c.idfsDiagnosis == obj.idfsDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, WhoExportMaster obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as WhoExportMaster, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, WhoExportMaster obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(WhoExportMaster obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(WhoExportMaster obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as WhoExportMaster) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as WhoExportMaster) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "WhoExportMasterDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spWhoExportMaster_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<WhoExportMaster, bool>> RequiredByField = new Dictionary<string, Func<WhoExportMaster, bool>>();
            public static Dictionary<string, Func<WhoExportMaster, bool>> RequiredByProperty = new Dictionary<string, Func<WhoExportMaster, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Actions.Add(new ActionMetaItem(
                    "Export",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).Export(manager, (WhoExportMaster)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"titleExport",
                        "Save",
                        /*from BvMessages*/"titleExport",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
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
                
                Actions.Add(new ActionMetaItem(
                    "Edit",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).Edit(manager, (WhoExportMaster)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
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
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "Refresh",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).Refresh(manager, (WhoExportMaster)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strRefresh_Id",
                        "iconRefresh_Id",
                        /*from BvMessages*/"tooltipRefresh_Id",
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
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<WhoExportMaster>().Post(manager, (WhoExportMaster)c), c),
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
	