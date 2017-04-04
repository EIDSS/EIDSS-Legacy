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
    public abstract partial class VetCaseLog : 
        EditableObject<VetCaseLog>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfVetCaseLog), NonUpdatable, PrimaryKey]
        public abstract Int64 idfVetCaseLog { get; set; }
                
        [LocalizedDisplayName(_str_idfsCaseLogStatus)]
        [MapField(_str_idfsCaseLogStatus)]
        public abstract Int64? idfsCaseLogStatus { get; set; }
        protected Int64? idfsCaseLogStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseLogStatus).OriginalValue; } }
        protected Int64? idfsCaseLogStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCaseLogStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPerson)]
        [MapField(_str_idfPerson)]
        public abstract Int64? idfPerson { get; set; }
        protected Int64? idfPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerson).OriginalValue; } }
        protected Int64? idfPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datCaseLogDate)]
        [MapField(_str_datCaseLogDate)]
        public abstract DateTime? datCaseLogDate { get; set; }
        protected DateTime? datCaseLogDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCaseLogDate).OriginalValue; } }
        protected DateTime? datCaseLogDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCaseLogDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strActionRequired)]
        [MapField(_str_strActionRequired)]
        public abstract String strActionRequired { get; set; }
        protected String strActionRequired_Original { get { return ((EditableValue<String>)((dynamic)this)._strActionRequired).OriginalValue; } }
        protected String strActionRequired_Previous { get { return ((EditableValue<String>)((dynamic)this)._strActionRequired).PreviousValue; } }
                
        [LocalizedDisplayName("strComment")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfVetCase)]
        [MapField(_str_idfVetCase)]
        public abstract Int64? idfVetCase { get; set; }
        protected Int64? idfVetCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVetCase).OriginalValue; } }
        protected Int64? idfVetCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfVetCase).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<VetCaseLog, object> _get_func;
            internal Action<VetCaseLog, string> _set_func;
            internal Action<VetCaseLog, VetCaseLog, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfVetCaseLog = "idfVetCaseLog";
        internal const string _str_idfsCaseLogStatus = "idfsCaseLogStatus";
        internal const string _str_idfPerson = "idfPerson";
        internal const string _str_datCaseLogDate = "datCaseLogDate";
        internal const string _str_strActionRequired = "strActionRequired";
        internal const string _str_strNote = "strNote";
        internal const string _str_idfVetCase = "idfVetCase";
        internal const string _str_CaseObjectIdent = "CaseObjectIdent";
        internal const string _str_strCaseLogStatus = "strCaseLogStatus";
        internal const string _str_strPerson = "strPerson";
        internal const string _str_CaseLogStatus = "CaseLogStatus";
        internal const string _str_Person = "Person";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfVetCaseLog, _formname = _str_idfVetCaseLog, _type = "Int64",
              _get_func = o => o.idfVetCaseLog,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfVetCaseLog != newval) o.idfVetCaseLog = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVetCaseLog != c.idfVetCaseLog || o.IsRIRPropChanged(_str_idfVetCaseLog, c)) 
                  m.Add(_str_idfVetCaseLog, o.ObjectIdent + _str_idfVetCaseLog, o.ObjectIdent2 + _str_idfVetCaseLog, o.ObjectIdent3 + _str_idfVetCaseLog, "Int64", 
                    o.idfVetCaseLog == null ? "" : o.idfVetCaseLog.ToString(),                  
                  o.IsReadOnly(_str_idfVetCaseLog), o.IsInvisible(_str_idfVetCaseLog), o.IsRequired(_str_idfVetCaseLog)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsCaseLogStatus, _formname = _str_idfsCaseLogStatus, _type = "Int64?",
              _get_func = o => o.idfsCaseLogStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsCaseLogStatus != newval) 
                  o.CaseLogStatus = o.CaseLogStatusLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsCaseLogStatus != newval) o.idfsCaseLogStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsCaseLogStatus != c.idfsCaseLogStatus || o.IsRIRPropChanged(_str_idfsCaseLogStatus, c)) 
                  m.Add(_str_idfsCaseLogStatus, o.ObjectIdent + _str_idfsCaseLogStatus, o.ObjectIdent2 + _str_idfsCaseLogStatus, o.ObjectIdent3 + _str_idfsCaseLogStatus, "Int64?", 
                    o.idfsCaseLogStatus == null ? "" : o.idfsCaseLogStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsCaseLogStatus), o.IsInvisible(_str_idfsCaseLogStatus), o.IsRequired(_str_idfsCaseLogStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPerson, _formname = _str_idfPerson, _type = "Int64?",
              _get_func = o => o.idfPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfPerson != newval) 
                  o.Person = o.PersonLookup.FirstOrDefault(c => c.idfPerson == newval);
                if (o.idfPerson != newval) o.idfPerson = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfPerson != c.idfPerson || o.IsRIRPropChanged(_str_idfPerson, c)) 
                  m.Add(_str_idfPerson, o.ObjectIdent + _str_idfPerson, o.ObjectIdent2 + _str_idfPerson, o.ObjectIdent3 + _str_idfPerson, "Int64?", 
                    o.idfPerson == null ? "" : o.idfPerson.ToString(),                  
                  o.IsReadOnly(_str_idfPerson), o.IsInvisible(_str_idfPerson), o.IsRequired(_str_idfPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datCaseLogDate, _formname = _str_datCaseLogDate, _type = "DateTime?",
              _get_func = o => o.datCaseLogDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datCaseLogDate != newval) o.datCaseLogDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datCaseLogDate != c.datCaseLogDate || o.IsRIRPropChanged(_str_datCaseLogDate, c)) 
                  m.Add(_str_datCaseLogDate, o.ObjectIdent + _str_datCaseLogDate, o.ObjectIdent2 + _str_datCaseLogDate, o.ObjectIdent3 + _str_datCaseLogDate, "DateTime?", 
                    o.datCaseLogDate == null ? "" : o.datCaseLogDate.ToString(),                  
                  o.IsReadOnly(_str_datCaseLogDate), o.IsInvisible(_str_datCaseLogDate), o.IsRequired(_str_datCaseLogDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strActionRequired, _formname = _str_strActionRequired, _type = "String",
              _get_func = o => o.strActionRequired,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strActionRequired != newval) o.strActionRequired = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strActionRequired != c.strActionRequired || o.IsRIRPropChanged(_str_strActionRequired, c)) 
                  m.Add(_str_strActionRequired, o.ObjectIdent + _str_strActionRequired, o.ObjectIdent2 + _str_strActionRequired, o.ObjectIdent3 + _str_strActionRequired, "String", 
                    o.strActionRequired == null ? "" : o.strActionRequired.ToString(),                  
                  o.IsReadOnly(_str_strActionRequired), o.IsInvisible(_str_strActionRequired), o.IsRequired(_str_strActionRequired)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strNote, _formname = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strNote != newval) o.strNote = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, o.ObjectIdent2 + _str_strNote, o.ObjectIdent3 + _str_strNote, "String", 
                    o.strNote == null ? "" : o.strNote.ToString(),                  
                  o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfVetCase, _formname = _str_idfVetCase, _type = "Int64?",
              _get_func = o => o.idfVetCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfVetCase != newval) o.idfVetCase = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfVetCase != c.idfVetCase || o.IsRIRPropChanged(_str_idfVetCase, c)) 
                  m.Add(_str_idfVetCase, o.ObjectIdent + _str_idfVetCase, o.ObjectIdent2 + _str_idfVetCase, o.ObjectIdent3 + _str_idfVetCase, "Int64?", 
                    o.idfVetCase == null ? "" : o.idfVetCase.ToString(),                  
                  o.IsReadOnly(_str_idfVetCase), o.IsInvisible(_str_idfVetCase), o.IsRequired(_str_idfVetCase)); 
                  }
              }, 
        
            new field_info {
              _name = _str_CaseObjectIdent, _formname = _str_CaseObjectIdent, _type = "string",
              _get_func = o => o.CaseObjectIdent,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.CaseObjectIdent != c.CaseObjectIdent || o.IsRIRPropChanged(_str_CaseObjectIdent, c)) {
                  m.Add(_str_CaseObjectIdent, o.ObjectIdent + _str_CaseObjectIdent, o.ObjectIdent2 + _str_CaseObjectIdent, o.ObjectIdent3 + _str_CaseObjectIdent, "string", o.CaseObjectIdent == null ? "" : o.CaseObjectIdent.ToString(), o.IsReadOnly(_str_CaseObjectIdent), o.IsInvisible(_str_CaseObjectIdent), o.IsRequired(_str_CaseObjectIdent));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strCaseLogStatus, _formname = _str_strCaseLogStatus, _type = "string",
              _get_func = o => o.strCaseLogStatus,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strCaseLogStatus != c.strCaseLogStatus || o.IsRIRPropChanged(_str_strCaseLogStatus, c)) {
                  m.Add(_str_strCaseLogStatus, o.ObjectIdent + _str_strCaseLogStatus, o.ObjectIdent2 + _str_strCaseLogStatus, o.ObjectIdent3 + _str_strCaseLogStatus, "string", o.strCaseLogStatus == null ? "" : o.strCaseLogStatus.ToString(), o.IsReadOnly(_str_strCaseLogStatus), o.IsInvisible(_str_strCaseLogStatus), o.IsRequired(_str_strCaseLogStatus));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strPerson, _formname = _str_strPerson, _type = "string",
              _get_func = o => o.strPerson,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strPerson != c.strPerson || o.IsRIRPropChanged(_str_strPerson, c)) {
                  m.Add(_str_strPerson, o.ObjectIdent + _str_strPerson, o.ObjectIdent2 + _str_strPerson, o.ObjectIdent3 + _str_strPerson, "string", o.strPerson == null ? "" : o.strPerson.ToString(), o.IsReadOnly(_str_strPerson), o.IsInvisible(_str_strPerson), o.IsRequired(_str_strPerson));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_CaseLogStatus, _formname = _str_CaseLogStatus, _type = "Lookup",
              _get_func = o => { if (o.CaseLogStatus == null) return null; return o.CaseLogStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.CaseLogStatus = o.CaseLogStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_CaseLogStatus, c);
                if (o.idfsCaseLogStatus != c.idfsCaseLogStatus || o.IsRIRPropChanged(_str_CaseLogStatus, c) || bChangeLookupContent) {
                  m.Add(_str_CaseLogStatus, o.ObjectIdent + _str_CaseLogStatus, o.ObjectIdent2 + _str_CaseLogStatus, o.ObjectIdent3 + _str_CaseLogStatus, "Lookup", o.idfsCaseLogStatus == null ? "" : o.idfsCaseLogStatus.ToString(), o.IsReadOnly(_str_CaseLogStatus), o.IsInvisible(_str_CaseLogStatus), o.IsRequired(_str_CaseLogStatus),
                  bChangeLookupContent ? o.CaseLogStatusLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_CaseLogStatus + "Lookup", _formname = _str_CaseLogStatus + "Lookup", _type = "LookupContent",
              _get_func = o => o.CaseLogStatusLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Person, _formname = _str_Person, _type = "Lookup",
              _get_func = o => { if (o.Person == null) return null; return o.Person.idfPerson; },
              _set_func = (o, val) => { o.Person = o.PersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Person, c);
                if (o.idfPerson != c.idfPerson || o.IsRIRPropChanged(_str_Person, c) || bChangeLookupContent) {
                  m.Add(_str_Person, o.ObjectIdent + _str_Person, o.ObjectIdent2 + _str_Person, o.ObjectIdent3 + _str_Person, "Lookup", o.idfPerson == null ? "" : o.idfPerson.ToString(), o.IsReadOnly(_str_Person), o.IsInvisible(_str_Person), o.IsRequired(_str_Person),
                  bChangeLookupContent ? o.PersonLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Person + "Lookup", _formname = _str_Person + "Lookup", _type = "LookupContent",
              _get_func = o => o.PersonLookup,
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
            VetCaseLog obj = (VetCaseLog)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_CaseLogStatus)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCaseLogStatus)]
        public BaseReference CaseLogStatus
        {
            get { return _CaseLogStatus == null ? null : ((long)_CaseLogStatus.Key == 0 ? null : _CaseLogStatus); }
            set 
            { 
                var oldVal = _CaseLogStatus;
                _CaseLogStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_CaseLogStatus != oldVal)
                {
                    if (idfsCaseLogStatus != (_CaseLogStatus == null
                            ? new Int64?()
                            : (Int64?)_CaseLogStatus.idfsBaseReference))
                        idfsCaseLogStatus = _CaseLogStatus == null 
                            ? new Int64?()
                            : (Int64?)_CaseLogStatus.idfsBaseReference; 
                    OnPropertyChanged(_str_CaseLogStatus); 
                }
            }
        }
        private BaseReference _CaseLogStatus;

        
        public BaseReferenceList CaseLogStatusLookup
        {
            get { return _CaseLogStatusLookup; }
        }
        private BaseReferenceList _CaseLogStatusLookup = new BaseReferenceList("rftVetCaseLogStatus");
            
        [LocalizedDisplayName(_str_Person)]
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfPerson)]
        public PersonLookup Person
        {
            get { return _Person == null ? null : ((long)_Person.Key == 0 ? null : _Person); }
            set 
            { 
                var oldVal = _Person;
                _Person = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Person != oldVal)
                {
                    if (idfPerson != (_Person == null
                            ? new Int64?()
                            : (Int64?)_Person.idfPerson))
                        idfPerson = _Person == null 
                            ? new Int64?()
                            : (Int64?)_Person.idfPerson; 
                    OnPropertyChanged(_str_Person); 
                }
            }
        }
        private PersonLookup _Person;

        
        public List<PersonLookup> PersonLookup
        {
            get { return _PersonLookup; }
        }
        private List<PersonLookup> _PersonLookup = new List<PersonLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_CaseLogStatus:
                    return new BvSelectList(CaseLogStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CaseLogStatus, _str_idfsCaseLogStatus);
            
                case _str_Person:
                    return new BvSelectList(PersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, Person, _str_idfPerson);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_CaseObjectIdent)]
        public string CaseObjectIdent
        {
            get { return new Func<VetCaseLog, string>(c => "VetCase_" + c.idfVetCase + "_")(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strCaseLogStatus)]
        public string strCaseLogStatus
        {
            get { return new Func<VetCaseLog, string>(c => c.CaseLogStatus == null ? "" : c.CaseLogStatus.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("strPersonEnteredBy")]
        public string strPerson
        {
            get { return new Func<VetCaseLog, string>(c => c.Person == null ? "" : c.Person.FullName)(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VetCaseLog";

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
            var ret = base.Clone() as VetCaseLog;
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
            var ret = base.Clone() as VetCaseLog;
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
        public VetCaseLog CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VetCaseLog;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfVetCaseLog; } }
        public string KeyName { get { return "idfVetCaseLog"; } }
        public object KeyLookup { get { return idfVetCaseLog; } }
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
        
            var _prev_idfsCaseLogStatus_CaseLogStatus = idfsCaseLogStatus;
            var _prev_idfPerson_Person = idfPerson;
            base.RejectChanges();
        
            if (_prev_idfsCaseLogStatus_CaseLogStatus != idfsCaseLogStatus)
            {
                _CaseLogStatus = _CaseLogStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCaseLogStatus);
            }
            if (_prev_idfPerson_Person != idfPerson)
            {
                _Person = _PersonLookup.FirstOrDefault(c => c.idfPerson == idfPerson);
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

        private bool IsRIRPropChanged(string fld, VetCaseLog c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, VetCaseLog c)
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
        

      

        public VetCaseLog()
        {
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VetCaseLog_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VetCaseLog_PropertyChanged);
        }
        private void VetCaseLog_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VetCaseLog).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfVetCase)
                OnPropertyChanged(_str_CaseObjectIdent);
                  
            if (e.PropertyName == _str_idfsCaseLogStatus)
                OnPropertyChanged(_str_strCaseLogStatus);
                  
            if (e.PropertyName == _str_idfPerson)
                OnPropertyChanged(_str_strPerson);
                  
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
            VetCaseLog obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VetCaseLog obj = this;
            
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


        internal Dictionary<string, Func<VetCaseLog, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VetCaseLog, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VetCaseLog, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VetCaseLog, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VetCaseLog, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<VetCaseLog, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<VetCaseLog, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~VetCaseLog()
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
                
                LookupManager.RemoveObject("rftVetCaseLogStatus", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftVetCaseLogStatus")
                _getAccessor().LoadLookup_CaseLogStatus(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_Person(manager, this);
            
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
        public class VetCaseLogGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfVetCaseLog { get; set; }
        
            public String strActionRequired { get; set; }
        
            public DateTimeWrap datCaseLogDate { get; set; }
        
            public string strPerson { get; set; }
        
            public String strNote { get; set; }
        
            public string strCaseLogStatus { get; set; }
        
        }
        public partial class VetCaseLogGridModelList : List<VetCaseLogGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public VetCaseLogGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VetCaseLog>, errMes);
            }
            public VetCaseLogGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<VetCaseLog>, errMes);
            }
            public VetCaseLogGridModelList(long key, IEnumerable<VetCaseLog> items)
            {
                LoadGridModelList(key, items, null);
            }
            public VetCaseLogGridModelList(long key)
            {
                LoadGridModelList(key, new List<VetCaseLog>(), null);
            }
            partial void filter(List<VetCaseLog> items);
            private void LoadGridModelList(long key, IEnumerable<VetCaseLog> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strActionRequired,_str_datCaseLogDate,_str_strPerson,_str_strNote,_str_strCaseLogStatus};
                    
                Hiddens = new List<string> {_str_idfVetCaseLog};
                Keys = new List<string> {_str_idfVetCaseLog};
                Labels = new Dictionary<string, string> {{_str_strActionRequired, _str_strActionRequired},{_str_datCaseLogDate, _str_datCaseLogDate},{_str_strPerson, "strPersonEnteredBy"},{_str_strNote, "strComment"},{_str_strCaseLogStatus, _str_strCaseLogStatus}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                VetCaseLog.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<VetCaseLog>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new VetCaseLogGridModel()
                {
                    ItemKey=c.idfVetCaseLog,strActionRequired=c.strActionRequired,datCaseLogDate=c.datCaseLogDate,strPerson=c.strPerson,strNote=c.strNote,strCaseLogStatus=c.strCaseLogStatus
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
        : DataAccessor<VetCaseLog>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<VetCaseLog>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfVetCaseLog"; } }
            #endregion
        
            public delegate void on_action(VetCaseLog obj);
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
            private BaseReference.Accessor CaseLogStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor PersonAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<VetCaseLog> SelectList(DbManagerProxy manager
                , Int64? idfCase
                )
            {
                return _SelectList(manager
                    , idfCase
                    , delegate(VetCaseLog obj)
                        {
                        }
                    , delegate(VetCaseLog obj)
                        {
                        }
                    );
            }

            

            public List<VetCaseLog> _SelectList(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfCase
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<VetCaseLog> _SelectListInternal(DbManagerProxy manager
                , Int64? idfCase
                , on_action loading, on_action loaded
                )
            {
                VetCaseLog _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<VetCaseLog> objs = new List<VetCaseLog>();
                    sets[0] = new MapResultSet(typeof(VetCaseLog), objs);
                    
                    manager
                        .SetSpCommand("spVetCaseLog_SelectDetail"
                            , manager.Parameter("@idfCase", idfCase)
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
                        _obj = obj;
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
                    throw DbModelException.Create(_obj, e);
                }
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, VetCaseLog obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, VetCaseLog obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private VetCaseLog _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                VetCaseLog obj = null;
                try
                {
                    obj = VetCaseLog.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfVetCaseLog = (new GetNewIDExtender<VetCaseLog>()).GetScalar(manager, obj, isFake);
                obj.idfVetCase = new Func<VetCaseLog, long>(c => (c.Parent as VetCase).idfCase)(obj);
                obj.datCaseLogDate = new Func<VetCaseLog, DateTime?>(c => DateTime.Today)(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.Person = new Func<VetCaseLog, PersonLookup>(c => c.PersonLookup.FirstOrDefault(i => i.idfPerson == (long)ModelUserContext.Instance.CurrentUser.EmployeeID))(obj);
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

            
            public VetCaseLog CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VetCaseLog CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public VetCaseLog CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(VetCaseLog obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VetCaseLog obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_datCaseLogDate)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datCaseLogDate);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
            }
    
            public void LoadLookup_CaseLogStatus(DbManagerProxy manager, VetCaseLog obj)
            {
                
                obj.CaseLogStatusLookup.Clear();
                
                obj.CaseLogStatusLookup.Add(CaseLogStatusAccessor.CreateNewT(manager, null));
                
                obj.CaseLogStatusLookup.AddRange(CaseLogStatusAccessor.rftVetCaseLogStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCaseLogStatus))
                    
                    .ToList());
                
                if (obj.idfsCaseLogStatus != null && obj.idfsCaseLogStatus != 0)
                {
                    obj.CaseLogStatus = obj.CaseLogStatusLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsCaseLogStatus);
                    
                }
              
                LookupManager.AddObject("rftVetCaseLogStatus", obj, CaseLogStatusAccessor.GetType(), "rftVetCaseLogStatus_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Person(DbManagerProxy manager, VetCaseLog obj)
            {
                
                obj.PersonLookup.Clear();
                
                obj.PersonLookup.Add(PersonAccessor.CreateNewT(manager, null));
                
                obj.PersonLookup.AddRange(PersonAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    , false
                    , (int)HACode.LivestockAvian
                    )
                    .Where(c => c.blnVet == true)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfPerson))
                    
                    .ToList());
                
                if (obj.idfPerson != null && obj.idfPerson != 0)
                {
                    obj.Person = obj.PersonLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfPerson);
                    
                }
              
                LookupManager.AddObject("PersonLookup", obj, PersonAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, VetCaseLog obj)
            {
                
                LoadLookup_CaseLogStatus(manager, obj);
                
                LoadLookup_Person(manager, obj);
                
            }
    
            [SprocName("spVetCaseLog_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] VetCaseLog obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] VetCaseLog obj)
            {
                
                _post(manager, Action, obj);
                
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
                        VetCaseLog bo = obj as VetCaseLog;
                        
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
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as VetCaseLog, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, VetCaseLog obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postPredicate(manager, 8, obj);
                                
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(VetCaseLog obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, VetCaseLog obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(VetCaseLog obj)
            {
                
                try
                {
                  
    new ChainsValidatorDateTime<VetCaseLog>(obj, "datCaseLogDate", c => true, 
      obj.datCaseLogDate,
      obj.GetType(),
      false, listdatCaseLogDate => {
    listdatCaseLogDate.Add(
    new ChainsValidatorDateTime<VetCaseLog>(obj, "CurrentDate", c => true, 
      DateTime.Now,
      null,
      false, listCurrentDate => {
    
    }));
  
    }).Process();
  
                }
                catch(ValidationModelException ex)
                {
                    return ex;
                }
                
                return null;
            }
            protected bool ChainsValidate(VetCaseLog obj, bool bRethrowException)
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
                return Validate(manager, obj as VetCaseLog, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VetCaseLog obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfPerson", "Person","strPersonEnteredBy",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfPerson);
            
                (new RequiredValidator( "datCaseLogDate", "datCaseLogDate","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.datCaseLogDate);
            
                  
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
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                
                return true;
            }
           
    
            private void _SetupRequired(VetCaseLog obj)
            {
            
                obj
                    .AddRequired("Person", c => true);
                    
                  obj
                    .AddRequired("Person", c => true);
                
                obj
                    .AddRequired("datCaseLogDate", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(VetCaseLog obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VetCaseLog) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VetCaseLog) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VetCaseLogDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spVetCaseLog_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spVetCaseLog_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VetCaseLog, bool>> RequiredByField = new Dictionary<string, Func<VetCaseLog, bool>>();
            public static Dictionary<string, Func<VetCaseLog, bool>> RequiredByProperty = new Dictionary<string, Func<VetCaseLog, bool>>();
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
                
                Sizes.Add(_str_strActionRequired, 200);
                Sizes.Add(_str_strNote, 1000);
                if (!RequiredByField.ContainsKey("idfPerson")) RequiredByField.Add("idfPerson", c => true);
                if (!RequiredByProperty.ContainsKey("Person")) RequiredByProperty.Add("Person", c => true);
                
                if (!RequiredByField.ContainsKey("datCaseLogDate")) RequiredByField.Add("datCaseLogDate", c => true);
                if (!RequiredByProperty.ContainsKey("datCaseLogDate")) RequiredByProperty.Add("datCaseLogDate", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfVetCaseLog,
                    _str_idfVetCaseLog, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strActionRequired,
                    _str_strActionRequired, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datCaseLogDate,
                    _str_datCaseLogDate, null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPerson,
                    "strPersonEnteredBy", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNote,
                    "strComment", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseLogStatus,
                    _str_strCaseLogStatus, null, false, true, true, true, true, null
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
                    (manager, c, pars) => ((VetCaseLog)c).MarkToDelete(),
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
	