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
    public abstract partial class LabSampleTransferListItem : 
        EditableObject<LabSampleTransferListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfTransferOut), NonUpdatable, PrimaryKey]
        public abstract Int64 idfTransferOut { get; set; }
                
        [LocalizedDisplayName("LabSampleTransferListItem.strBarcode")]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        #if MONO
        protected String strBarcode_Original { get { return strBarcode; } }
        protected String strBarcode_Previous { get { return strBarcode; } }
        #else
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfSendFromOffice)]
        [MapField(_str_idfSendFromOffice)]
        public abstract Int64? idfSendFromOffice { get; set; }
        #if MONO
        protected Int64? idfSendFromOffice_Original { get { return idfSendFromOffice; } }
        protected Int64? idfSendFromOffice_Previous { get { return idfSendFromOffice; } }
        #else
        protected Int64? idfSendFromOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendFromOffice).OriginalValue; } }
        protected Int64? idfSendFromOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendFromOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfSendToOffice)]
        [MapField(_str_idfSendToOffice)]
        public abstract Int64? idfSendToOffice { get; set; }
        #if MONO
        protected Int64? idfSendToOffice_Original { get { return idfSendToOffice; } }
        protected Int64? idfSendToOffice_Previous { get { return idfSendToOffice; } }
        #else
        protected Int64? idfSendToOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).OriginalValue; } }
        protected Int64? idfSendToOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_TransferFrom)]
        [MapField(_str_TransferFrom)]
        public abstract String TransferFrom { get; set; }
        #if MONO
        protected String TransferFrom_Original { get { return TransferFrom; } }
        protected String TransferFrom_Previous { get { return TransferFrom; } }
        #else
        protected String TransferFrom_Original { get { return ((EditableValue<String>)((dynamic)this)._transferFrom).OriginalValue; } }
        protected String TransferFrom_Previous { get { return ((EditableValue<String>)((dynamic)this)._transferFrom).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_TransferTo)]
        [MapField(_str_TransferTo)]
        public abstract String TransferTo { get; set; }
        #if MONO
        protected String TransferTo_Original { get { return TransferTo; } }
        protected String TransferTo_Previous { get { return TransferTo; } }
        #else
        protected String TransferTo_Original { get { return ((EditableValue<String>)((dynamic)this)._transferTo).OriginalValue; } }
        protected String TransferTo_Previous { get { return ((EditableValue<String>)((dynamic)this)._transferTo).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabSampleTransferListItem, object> _get_func;
            internal Action<LabSampleTransferListItem, string> _set_func;
            internal Action<LabSampleTransferListItem, LabSampleTransferListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfTransferOut = "idfTransferOut";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_idfSendFromOffice = "idfSendFromOffice";
        internal const string _str_idfSendToOffice = "idfSendToOffice";
        internal const string _str_TransferFrom = "TransferFrom";
        internal const string _str_TransferTo = "TransferTo";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfTransferOut, _type = "Int64",
              _get_func = o => o.idfTransferOut,
              _set_func = (o, val) => { o.idfTransferOut = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTransferOut != c.idfTransferOut || o.IsRIRPropChanged(_str_idfTransferOut, c)) 
                  m.Add(_str_idfTransferOut, o.ObjectIdent + _str_idfTransferOut, "Int64", o.idfTransferOut == null ? "" : o.idfTransferOut.ToString(), o.IsReadOnly(_str_idfTransferOut), o.IsInvisible(_str_idfTransferOut), o.IsRequired(_str_idfTransferOut)); }
              }, 
        
            new field_info {
              _name = _str_strBarcode, _type = "String",
              _get_func = o => o.strBarcode,
              _set_func = (o, val) => { o.strBarcode = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strBarcode != c.strBarcode || o.IsRIRPropChanged(_str_strBarcode, c)) 
                  m.Add(_str_strBarcode, o.ObjectIdent + _str_strBarcode, "String", o.strBarcode == null ? "" : o.strBarcode.ToString(), o.IsReadOnly(_str_strBarcode), o.IsInvisible(_str_strBarcode), o.IsRequired(_str_strBarcode)); }
              }, 
        
            new field_info {
              _name = _str_idfSendFromOffice, _type = "Int64?",
              _get_func = o => o.idfSendFromOffice,
              _set_func = (o, val) => { o.idfSendFromOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSendFromOffice != c.idfSendFromOffice || o.IsRIRPropChanged(_str_idfSendFromOffice, c)) 
                  m.Add(_str_idfSendFromOffice, o.ObjectIdent + _str_idfSendFromOffice, "Int64?", o.idfSendFromOffice == null ? "" : o.idfSendFromOffice.ToString(), o.IsReadOnly(_str_idfSendFromOffice), o.IsInvisible(_str_idfSendFromOffice), o.IsRequired(_str_idfSendFromOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfSendToOffice, _type = "Int64?",
              _get_func = o => o.idfSendToOffice,
              _set_func = (o, val) => { o.idfSendToOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfSendToOffice != c.idfSendToOffice || o.IsRIRPropChanged(_str_idfSendToOffice, c)) 
                  m.Add(_str_idfSendToOffice, o.ObjectIdent + _str_idfSendToOffice, "Int64?", o.idfSendToOffice == null ? "" : o.idfSendToOffice.ToString(), o.IsReadOnly(_str_idfSendToOffice), o.IsInvisible(_str_idfSendToOffice), o.IsRequired(_str_idfSendToOffice)); }
              }, 
        
            new field_info {
              _name = _str_TransferFrom, _type = "String",
              _get_func = o => o.TransferFrom,
              _set_func = (o, val) => { o.TransferFrom = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.TransferFrom != c.TransferFrom || o.IsRIRPropChanged(_str_TransferFrom, c)) 
                  m.Add(_str_TransferFrom, o.ObjectIdent + _str_TransferFrom, "String", o.TransferFrom == null ? "" : o.TransferFrom.ToString(), o.IsReadOnly(_str_TransferFrom), o.IsInvisible(_str_TransferFrom), o.IsRequired(_str_TransferFrom)); }
              }, 
        
            new field_info {
              _name = _str_TransferTo, _type = "String",
              _get_func = o => o.TransferTo,
              _set_func = (o, val) => { o.TransferTo = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.TransferTo != c.TransferTo || o.IsRIRPropChanged(_str_TransferTo, c)) 
                  m.Add(_str_TransferTo, o.ObjectIdent + _str_TransferTo, "String", o.TransferTo == null ? "" : o.TransferTo.ToString(), o.IsReadOnly(_str_TransferTo), o.IsInvisible(_str_TransferTo), o.IsRequired(_str_TransferTo)); }
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
            LabSampleTransferListItem obj = (LabSampleTransferListItem)o;
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
        internal string m_ObjectName = "LabSampleTransferListItem";

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
            var ret = base.Clone() as LabSampleTransferListItem;
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
            var ret = base.Clone() as LabSampleTransferListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabSampleTransferListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabSampleTransferListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfTransferOut; } }
        public string KeyName { get { return "idfTransferOut"; } }
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

      private bool IsRIRPropChanged(string fld, LabSampleTransferListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabSampleTransferListItem()
        {
            
            m_permissions = new Permissions(this);
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabSampleTransferListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabSampleTransferListItem_PropertyChanged);
        }
        private void LabSampleTransferListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabSampleTransferListItem).Changed(e.PropertyName);
            
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
            LabSampleTransferListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabSampleTransferListItem obj = this;
            
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


        public Dictionary<string, Func<LabSampleTransferListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabSampleTransferListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabSampleTransferListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabSampleTransferListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabSampleTransferListItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<LabSampleTransferListItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabSampleTransferListItem()
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
        public class LabSampleTransferListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfTransferOut { get; set; }
        
            public String strBarcode { get; set; }
        
            public String TransferFrom { get; set; }
        
            public String TransferTo { get; set; }
        
        }
        public partial class LabSampleTransferListItemGridModelList : List<LabSampleTransferListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public LabSampleTransferListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabSampleTransferListItem>, errMes);
            }
            public LabSampleTransferListItemGridModelList(long key, IEnumerable<LabSampleTransferListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<LabSampleTransferListItem> items);
            private void LoadGridModelList(long key, IEnumerable<LabSampleTransferListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strBarcode,_str_TransferFrom,_str_TransferTo};
                    
                Hiddens = new List<string> {_str_idfTransferOut};
                Keys = new List<string> {_str_idfTransferOut};
                Labels = new Dictionary<string, string> {{_str_strBarcode, "LabSampleTransferListItem.strBarcode"},{_str_TransferFrom, _str_TransferFrom},{_str_TransferTo, _str_TransferTo}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<LabSampleTransferListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LabSampleTransferListItemGridModel()
                {
                    ItemKey=c.idfTransferOut,strBarcode=c.strBarcode,TransferFrom=c.TransferFrom,TransferTo=c.TransferTo
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
        : DataAccessor<LabSampleTransferListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
            private delegate void on_action(LabSampleTransferListItem obj);
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
            
            public virtual List<LabSampleTransferListItem> SelectListT(DbManagerProxy manager
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
            
            private List<LabSampleTransferListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_SampleTransfer_SelectList.* from dbo.fn_SampleTransfer_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfTransferOut"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfTransferOut"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfTransferOut") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_SampleTransfer_SelectList.idfTransferOut,0) {0} @idfTransferOut_{1}", filters.Operation("idfTransferOut", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strBarcode"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strBarcode"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strBarcode") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SampleTransfer_SelectList.strBarcode {0} @strBarcode_{1}", filters.Operation("strBarcode", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfSendFromOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfSendFromOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfSendFromOffice") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_SampleTransfer_SelectList.idfSendFromOffice,0) {0} @idfSendFromOffice_{1}", filters.Operation("idfSendFromOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfSendToOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfSendToOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfSendToOffice") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_SampleTransfer_SelectList.idfSendToOffice,0) {0} @idfSendToOffice_{1}", filters.Operation("idfSendToOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("TransferFrom"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("TransferFrom"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("TransferFrom") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SampleTransfer_SelectList.TransferFrom {0} @TransferFrom_{1}", filters.Operation("TransferFrom", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("TransferTo"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("TransferTo"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("TransferTo") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_SampleTransfer_SelectList.TransferTo {0} @TransferTo_{1}", filters.Operation("TransferTo", i), i);
                            
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
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("idfTransferOut"))
                        for (int i = 0; i < filters.Count("idfTransferOut"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfTransferOut_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfTransferOut", i), filters.Value("idfTransferOut", i))));
                      
                    if (filters.Contains("strBarcode"))
                        for (int i = 0; i < filters.Count("strBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strBarcode", i), filters.Value("strBarcode", i))));
                      
                    if (filters.Contains("idfSendFromOffice"))
                        for (int i = 0; i < filters.Count("idfSendFromOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSendFromOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSendFromOffice", i), filters.Value("idfSendFromOffice", i))));
                      
                    if (filters.Contains("idfSendToOffice"))
                        for (int i = 0; i < filters.Count("idfSendToOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSendToOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSendToOffice", i), filters.Value("idfSendToOffice", i))));
                      
                    if (filters.Contains("TransferFrom"))
                        for (int i = 0; i < filters.Count("TransferFrom"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TransferFrom_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TransferFrom", i), filters.Value("TransferFrom", i))));
                      
                    if (filters.Contains("TransferTo"))
                        for (int i = 0; i < filters.Count("TransferTo"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@TransferTo_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("TransferTo", i), filters.Value("TransferTo", i))));
                      
                    List<LabSampleTransferListItem> objs = manager.ExecuteList<LabSampleTransferListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                    }
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
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spLabSampleTransfer_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabSampleTransferListItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabSampleTransferListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabSampleTransferListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabSampleTransferListItem obj = LabSampleTransferListItem.CreateInstance();
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

            
            public LabSampleTransferListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public LabSampleTransferListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(LabSampleTransferListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabSampleTransferListItem obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, LabSampleTransferListItem obj)
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
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    LabSampleTransferListItem bo = obj as LabSampleTransferListItem;
                    
                    if (!bo.GetPermissions().CanExecute("SampleTransfer"))
                        throw new PermissionException("SampleTransfer", "Execute");
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfTransferOut;
                        
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoSample;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbMaterial;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as LabSampleTransferListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, LabSampleTransferListItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfTransferOut
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(LabSampleTransferListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, LabSampleTransferListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfTransferOut
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, false);
                        }
                     }
                }
                catch(ValidationModelException ex)
                {
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                        return false;
                    }
                    else
                        obj.m_IsForcedToDelete = true;
                }
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as LabSampleTransferListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabSampleTransferListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SampleTransfer.Execute"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SampleTransfer.Execute"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SampleTransfer.Execute"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SampleTransfer.Execute"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(LabSampleTransferListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabSampleTransferListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabSampleTransferListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabSampleTransferListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabSampleTransferListItemDetail"; } }
            public string HelpIdWin { get { return "SampleTransferOutForm"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private LabSampleTransferListItem m_obj;
            internal Permissions(LabSampleTransferListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SampleTransfer.Execute"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SampleTransfer.Execute"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SampleTransfer.Execute"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("SampleTransfer.Execute"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_SampleTransfer_SelectList";
            public static string spCount = "spLabSampleTransfer_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spReadOnlyObject_Delete";
            public static string spCanDelete = "spReadOnlyObject_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabSampleTransferListItem, bool>> RequiredByField = new Dictionary<string, Func<LabSampleTransferListItem, bool>>();
            public static Dictionary<string, Func<LabSampleTransferListItem, bool>> RequiredByProperty = new Dictionary<string, Func<LabSampleTransferListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_TransferFrom, 2000);
                Sizes.Add(_str_TransferTo, 2000);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strBarcode",
                    EditorType.Text,
                    false, false, 
                    "LabSampleTransferListItem.strBarcode",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "TransferFrom",
                    EditorType.Text,
                    false, false, 
                    "TransferFrom",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "TransferTo",
                    EditorType.Text,
                    false, false, 
                    "TransferTo",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfTransferOut,
                    _str_idfTransferOut, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strBarcode,
                    "LabSampleTransferListItem.strBarcode", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TransferFrom,
                    _str_TransferFrom, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_TransferTo,
                    _str_TransferTo, null, true, true, null
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<LabSampleTransfer>().SelectDetail(manager, pars[0])),
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	