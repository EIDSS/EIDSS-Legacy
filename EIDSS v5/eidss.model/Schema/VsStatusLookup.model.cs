#pragma warning disable 0472
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
using bv.model.BLToolkit;
using bv.model.Model;
using bv.model.Model.Extenders;
using bv.model.Model.Core;
using bv.model.Model.Handlers;
using bv.model.Model.Validators;
using eidss.model.Core;
		

namespace eidss.model.Schema
{
        
        
    [XmlType(AnonymousType = true)]
    
    public abstract partial class VSStatusLookup : 
        EditableObject<VSStatusLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField("idfsStatus"), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsStatus { get; set; }
                
        [LocalizedDisplayName("strStatusName")]
        [MapField("strStatusName")]
        public abstract String strStatusName { get; set; }
        protected String strStatusName_Original { get { return ((EditableValue<String>)((dynamic)this)._strStatusName).OriginalValue; } }
        protected String strStatusName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strStatusName).PreviousValue; } }
                
        #region Set/Get values
        private string _getType(string name)
        {
            switch(name)
            {
        
                case "idfsStatus":
                    return "Int64";
        
                case "strStatusName":
                    return "String";
        
            }
            return null;
        }
        private object _getValue(string name)
        {
            switch(name)
            {
        
                case "idfsStatus":
                    return idfsStatus;
        
                case "strStatusName":
                    return strStatusName;
        
            }
            return null;
        }
        private void _setValue(string name, string val)
        {
            switch(name)
            {
        
                case "idfsStatus":
            idfsStatus = string.IsNullOrEmpty(val) ? default(Int64) : Int64.Parse(val);
                
                    break;
        
                case "strStatusName":
            strStatusName = string.IsNullOrEmpty(val) ? default(String) : val;
                
                    break;
        
            }
        }
        private void _setValues(IObject o)
        {
            VSStatusLookup obj = (VSStatusLookup)o;
        idfsStatus = obj.idfsStatus;
        strStatusName = obj.strStatusName;
        
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            VSStatusLookup obj = (VSStatusLookup)o;
        
            if (idfsStatus != obj.idfsStatus || IsReadOnly("idfsStatus") != obj.IsReadOnly("idfsStatus")) 
                ret.Add("idfsStatus", ObjectIdent + "idfsStatus", "Int64", idfsStatus == null ? "" : idfsStatus.ToString(), IsReadOnly("idfsStatus"));
        
            if (strStatusName != obj.strStatusName || IsReadOnly("strStatusName") != obj.IsReadOnly("strStatusName")) 
                ret.Add("strStatusName", ObjectIdent + "strStatusName", "String", strStatusName == null ? "" : strStatusName.ToString(), IsReadOnly("strStatusName"));
        
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
        private void _matchLookups()
        {
        
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        internal string m_ObjectName = "VSStatusLookup";

        #region IObject implementation
        public object Key { get { return idfsStatus; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public bool ReadOnly { get; set; }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsRequired(string name) { return _isRequired(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public void SetValues(IObject o) { _setValues(o); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public void MatchLookups() { _matchLookups(); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        #endregion

        
        public override string ToString()
        {
            return new Func<VSStatusLookup, string>(c => c.strStatusName)(this);
        }
        

        public VSStatusLookup()
        {
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Deleted();

        

        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }

        private bool m_IsForcedToDelete;
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VSStatusLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VSStatusLookup_PropertyChanged);
        }
        private void VSStatusLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VSStatusLookup).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete()
        {
            
            return true;
        }
        
        public bool OnValidation(string msgId, string fldName, string prpName, object[] pars, Type type)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(msgId, fldName, prpName, pars, type);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(string msgId, string fldName, string prpName, object[] pars, Type type)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(msgId, fldName, prpName, pars, type);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }
        private void _ChildValidation(object sender, ValidationEventArgs args)
        {
            if (Validation != null)
            {
                Validation(this, args);
            }
        }

    
        private bool _isReadOnly(string name)
        {
            if( ReadOnly )
              return true;
            
            return false;
                
        }

        public bool IsActionEnabled(string name)
        {
            
            return true;
        }

    
        private Dictionary<string, bool> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return true;
            return false;
        }
        
        public void AddRequired(string name)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, bool>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, true);
        }
    
        #region IDisposable Members
        public void Dispose()
        {
            
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form)
        {
        
            if (!string.IsNullOrEmpty(form[ObjectIdent + "strStatusName"])) strStatusName = form[ObjectIdent + "strStatusName"];
                
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<VSStatusLookup>
            , IObjectAccessor
            , IObjectMeta
            
            , IObjectCreator
            
        {
            private delegate void on_action(VSStatusLookup obj);
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
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<VSStatusLookup> SelectLookupList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , null, null
                    );
            }
            
        
            private List<VSStatusLookup> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VSStatusLookup> objs = new List<VSStatusLookup>();
                    sets[0] = new MapResultSet(typeof(VSStatusLookup), objs);
                    
                    manager
                        .SetSpCommand("spVSStatus_SelectLookup"
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VSStatusLookup obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadLookups(manager, obj);
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupRequired(obj);
                obj._SetupMainHandler();
            }

    

            private VSStatusLookup _CreateNew(DbManagerProxy manager, int? HACode, on_action creating, on_action created)
            {
                VSStatusLookup obj = VSStatusLookup.CreateInstance();
                obj.m_CS = m_CS;
                obj.m_IsNew = true;
                
                if (creating != null)
                    creating(obj);
                
                // creating extenters - begin
                // creating extenters - end
                
                _LoadLookups(manager, obj);
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                obj._SetupMainHandler();
                
                // created extenters - begin
                // created extenters - end
        
                if (created != null)
                    created(obj);
                obj.Created(manager);
                _SetupRequired(obj);
                return obj;
            }

            
            public VSStatusLookup CreateNewT(DbManagerProxy manager, int? HACode = null)
            {
                return _CreateNew(manager, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, int? HACode = null)
            {
                return _CreateNew(manager, HACode, null, null);
            }
            
            public VSStatusLookup CreateWithParamsT(DbManagerProxy manager, List<object> pars)
            {
                return _CreateNew(manager, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, List<object> pars)
            {
                return _CreateNew(manager, null, null, null);
            }
            
            private void _SetupChildHandlers(VSStatusLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VSStatusLookup obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, VSStatusLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj) 
            {
                throw new NotImplementedException();
            }
        
            private void _SetupRequired(VSStatusLookup obj)
            {
            
            }
    
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name] : false; }
            public bool RequiredByProperty(string name) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name] : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VSStatusLookupDetail"; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, bool> RequiredByField = new Dictionary<string, bool>();
            public static Dictionary<string, bool> RequiredByProperty = new Dictionary<string, bool>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add("strStatusName", 1000);
                      
                 Actions.Add(new ActionMetaItem(
                      "Create",
                      "strCreate_Id",
                      "add",
                      "tooltipCreate_Id",
                      ActionsAlignment.Right,
                      ActionsPanelType.Main,
                      false,
                      true,
                      false,
                      (manager, c, pars) => ObjectAccessor.PostInterface<VSStatusLookup>().Post(manager ?? DbManagerFactory.Factory.Create(), (VSStatusLookup)c),
                      null,
                      null,
                      ActionTypes.Create,
                      String.Empty
                      ));

                  Actions.Add(new ActionMetaItem(
                      "Delete",
                      "strDelete_Id",
                      "Delete_Remove",
                      "tooltipDelete_Id",
                      ActionsAlignment.Right,
                      ActionsPanelType.Main,
                      false,
                      true,
                      true,
                      (manager, c, pars) => { ((VSStatusLookup)c).MarkToDelete(); return ObjectAccessor.PostInterface<VSStatusLookup>().Post(manager ?? DbManagerFactory.Factory.Create(), (VSStatusLookup)c); },
                      null,
                      null,
                      ActionTypes.Delete,
                      String.Empty
                      ));
                   
                   Actions.Add(new ActionMetaItem(
                      "Save",
                      "strSave_Id",
                      "Save",
                      "tooltipSave_Id",
                      ActionsAlignment.Right,
                      ActionsPanelType.Main,
                      false,
                      true,
                      false,
                      (manager, c, pars) => ObjectAccessor.PostInterface<VSStatusLookup>().Post(manager ?? DbManagerFactory.Factory.Create(), (VSStatusLookup)c),
                      null,
                      null,
                      ActionTypes.Save,
                      String.Empty
                      ));
                   
                   Actions.Add(new ActionMetaItem(
                      "OK",
                      "strOK_Id",
                      "",
                      "tooltipOK_Id",
                      ActionsAlignment.Right,
                      ActionsPanelType.Main,
                      false,
                      true,
                      true,
                      (manager, c, pars) => ObjectAccessor.PostInterface<VSStatusLookup>().Post(manager ?? DbManagerFactory.Factory.Create(), (VSStatusLookup)c),
                      null,
                      null,
                      ActionTypes.Ok,
                      String.Empty
                      ));

                  Actions.Add(new ActionMetaItem(
                      "Cancel",
                      "strCancel_Id",
                      "",
                      "tooltipCancel_Id",
                      ActionsAlignment.Right,
                      ActionsPanelType.Main,
                      false,
                      true,
                      true,
                      (manager, c, pars) => true,
                      null,
                      (c)=>true,
                      ActionTypes.Cancel,
                      String.Empty
                      ));
                      
                      
                    
            }
        }
        #endregion
    

        #endregion
        }
    
}
	