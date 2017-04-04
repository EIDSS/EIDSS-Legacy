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
    public abstract partial class BasicSyndromicSurveillanceAggregateList : 
        EditableObject<BasicSyndromicSurveillanceAggregateList>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfAggregateHeader), NonUpdatable, PrimaryKey]
        public abstract Int64 idfAggregateHeader { get; set; }
                
        [LocalizedDisplayName(_str_strFormID)]
        [MapField(_str_strFormID)]
        public abstract String strFormID { get; set; }
        protected String strFormID_Original { get { return ((EditableValue<String>)((dynamic)this)._strFormID).OriginalValue; } }
        protected String strFormID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFormID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intYear)]
        [MapField(_str_intYear)]
        public abstract Int32 intYear { get; set; }
        protected Int32 intYear_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intYear).OriginalValue; } }
        protected Int32 intYear_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intYear).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intWeek)]
        [MapField(_str_intWeek)]
        public abstract Int32 intWeek { get; set; }
        protected Int32 intWeek_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intWeek).OriginalValue; } }
        protected Int32 intWeek_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intWeek).PreviousValue; } }
                
        [LocalizedDisplayName("strHospital")]
        [MapField(_str_strHospitals)]
        public abstract String strHospitals { get; set; }
        protected String strHospitals_Original { get { return ((EditableValue<String>)((dynamic)this)._strHospitals).OriginalValue; } }
        protected String strHospitals_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHospitals).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64 idfsSite { get; set; }
        protected Int64 idfsSite_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64 idfsSite_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStartDate)]
        [MapField(_str_datStartDate)]
        public abstract DateTime datStartDate { get; set; }
        protected DateTime datStartDate_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime datStartDate_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datStartDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFinishDate)]
        [MapField(_str_datFinishDate)]
        public abstract DateTime datFinishDate { get; set; }
        protected DateTime datFinishDate_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datFinishDate).OriginalValue; } }
        protected DateTime datFinishDate_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datFinishDate).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<BasicSyndromicSurveillanceAggregateList, object> _get_func;
            internal Action<BasicSyndromicSurveillanceAggregateList, string> _set_func;
            internal Action<BasicSyndromicSurveillanceAggregateList, BasicSyndromicSurveillanceAggregateList, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAggregateHeader = "idfAggregateHeader";
        internal const string _str_strFormID = "strFormID";
        internal const string _str_intYear = "intYear";
        internal const string _str_intWeek = "intWeek";
        internal const string _str_strHospitals = "strHospitals";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_datFinishDate = "datFinishDate";
        internal const string _str_idfHospital = "idfHospital";
        internal const string _str_strWeek = "strWeek";
        internal const string _str_Hospital = "Hospital";
        internal const string _str_Site = "Site";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfAggregateHeader, _formname = _str_idfAggregateHeader, _type = "Int64",
              _get_func = o => o.idfAggregateHeader,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfAggregateHeader != newval) o.idfAggregateHeader = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfAggregateHeader != c.idfAggregateHeader || o.IsRIRPropChanged(_str_idfAggregateHeader, c)) 
                  m.Add(_str_idfAggregateHeader, o.ObjectIdent + _str_idfAggregateHeader, o.ObjectIdent2 + _str_idfAggregateHeader, o.ObjectIdent3 + _str_idfAggregateHeader, "Int64", 
                    o.idfAggregateHeader == null ? "" : o.idfAggregateHeader.ToString(),                  
                  o.IsReadOnly(_str_idfAggregateHeader), o.IsInvisible(_str_idfAggregateHeader), o.IsRequired(_str_idfAggregateHeader)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFormID, _formname = _str_strFormID, _type = "String",
              _get_func = o => o.strFormID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFormID != newval) o.strFormID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFormID != c.strFormID || o.IsRIRPropChanged(_str_strFormID, c)) 
                  m.Add(_str_strFormID, o.ObjectIdent + _str_strFormID, o.ObjectIdent2 + _str_strFormID, o.ObjectIdent3 + _str_strFormID, "String", 
                    o.strFormID == null ? "" : o.strFormID.ToString(),                  
                  o.IsReadOnly(_str_strFormID), o.IsInvisible(_str_strFormID), o.IsRequired(_str_strFormID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intYear, _formname = _str_intYear, _type = "Int32",
              _get_func = o => o.intYear,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intYear != newval) o.intYear = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intYear != c.intYear || o.IsRIRPropChanged(_str_intYear, c)) 
                  m.Add(_str_intYear, o.ObjectIdent + _str_intYear, o.ObjectIdent2 + _str_intYear, o.ObjectIdent3 + _str_intYear, "Int32", 
                    o.intYear == null ? "" : o.intYear.ToString(),                  
                  o.IsReadOnly(_str_intYear), o.IsInvisible(_str_intYear), o.IsRequired(_str_intYear)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intWeek, _formname = _str_intWeek, _type = "Int32",
              _get_func = o => o.intWeek,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intWeek != newval) o.intWeek = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intWeek != c.intWeek || o.IsRIRPropChanged(_str_intWeek, c)) 
                  m.Add(_str_intWeek, o.ObjectIdent + _str_intWeek, o.ObjectIdent2 + _str_intWeek, o.ObjectIdent3 + _str_intWeek, "Int32", 
                    o.intWeek == null ? "" : o.intWeek.ToString(),                  
                  o.IsReadOnly(_str_intWeek), o.IsInvisible(_str_intWeek), o.IsRequired(_str_intWeek)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHospitals, _formname = _str_strHospitals, _type = "String",
              _get_func = o => o.strHospitals,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHospitals != newval) o.strHospitals = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHospitals != c.strHospitals || o.IsRIRPropChanged(_str_strHospitals, c)) 
                  m.Add(_str_strHospitals, o.ObjectIdent + _str_strHospitals, o.ObjectIdent2 + _str_strHospitals, o.ObjectIdent3 + _str_strHospitals, "String", 
                    o.strHospitals == null ? "" : o.strHospitals.ToString(),                  
                  o.IsReadOnly(_str_strHospitals), o.IsInvisible(_str_strHospitals), o.IsRequired(_str_strHospitals)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSite, _formname = _str_idfsSite, _type = "Int64",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfsSite != newval) 
                  o.Site = o.SiteLookup.FirstOrDefault(c => c.idfsSite == newval);
                if (o.idfsSite != newval) o.idfsSite = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, o.ObjectIdent2 + _str_idfsSite, o.ObjectIdent3 + _str_idfsSite, "Int64", 
                    o.idfsSite == null ? "" : o.idfsSite.ToString(),                  
                  o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datStartDate, _formname = _str_datStartDate, _type = "DateTime",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTime(val); if (o.datStartDate != newval) o.datStartDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, o.ObjectIdent2 + _str_datStartDate, o.ObjectIdent3 + _str_datStartDate, "DateTime", 
                    o.datStartDate == null ? "" : o.datStartDate.ToString(),                  
                  o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datFinishDate, _formname = _str_datFinishDate, _type = "DateTime",
              _get_func = o => o.datFinishDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTime(val); if (o.datFinishDate != newval) o.datFinishDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datFinishDate != c.datFinishDate || o.IsRIRPropChanged(_str_datFinishDate, c)) 
                  m.Add(_str_datFinishDate, o.ObjectIdent + _str_datFinishDate, o.ObjectIdent2 + _str_datFinishDate, o.ObjectIdent3 + _str_datFinishDate, "DateTime", 
                    o.datFinishDate == null ? "" : o.datFinishDate.ToString(),                  
                  o.IsReadOnly(_str_datFinishDate), o.IsInvisible(_str_datFinishDate), o.IsRequired(_str_datFinishDate)); 
                  }
              }, 
        
            new field_info {
              _name = _str_idfHospital, _formname = _str_idfHospital, _type = "long?",
              _get_func = o => o.idfHospital,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfHospital != newval) o.idfHospital = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.idfHospital != c.idfHospital || o.IsRIRPropChanged(_str_idfHospital, c)) {
                  m.Add(_str_idfHospital, o.ObjectIdent + _str_idfHospital, o.ObjectIdent2 + _str_idfHospital, o.ObjectIdent3 + _str_idfHospital,  "long?", 
                    o.idfHospital == null ? "" : o.idfHospital.ToString(),                  
                    o.IsReadOnly(_str_idfHospital), o.IsInvisible(_str_idfHospital), o.IsRequired(_str_idfHospital));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_strWeek, _formname = _str_strWeek, _type = "string",
              _get_func = o => o.strWeek,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strWeek != c.strWeek || o.IsRIRPropChanged(_str_strWeek, c)) {
                  m.Add(_str_strWeek, o.ObjectIdent + _str_strWeek, o.ObjectIdent2 + _str_strWeek, o.ObjectIdent3 + _str_strWeek, "string", o.strWeek == null ? "" : o.strWeek.ToString(), o.IsReadOnly(_str_strWeek), o.IsInvisible(_str_strWeek), o.IsRequired(_str_strWeek));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Hospital, _formname = _str_Hospital, _type = "Lookup",
              _get_func = o => { if (o.Hospital == null) return null; return o.Hospital.idfInstitution; },
              _set_func = (o, val) => { o.Hospital = o.HospitalLookup.Where(c => c.idfInstitution.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Hospital, c);
                if (o.idfHospital != c.idfHospital || o.IsRIRPropChanged(_str_Hospital, c) || bChangeLookupContent) {
                  m.Add(_str_Hospital, o.ObjectIdent + _str_Hospital, o.ObjectIdent2 + _str_Hospital, o.ObjectIdent3 + _str_Hospital, "Lookup", o.idfHospital == null ? "" : o.idfHospital.ToString(), o.IsReadOnly(_str_Hospital), o.IsInvisible(_str_Hospital), o.IsRequired(_str_Hospital),
                  bChangeLookupContent ? o.HospitalLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Hospital + "Lookup", _formname = _str_Hospital + "Lookup", _type = "LookupContent",
              _get_func = o => o.HospitalLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Site, _formname = _str_Site, _type = "Lookup",
              _get_func = o => { if (o.Site == null) return null; return o.Site.idfsSite; },
              _set_func = (o, val) => { o.Site = o.SiteLookup.Where(c => c.idfsSite.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Site, c);
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_Site, c) || bChangeLookupContent) {
                  m.Add(_str_Site, o.ObjectIdent + _str_Site, o.ObjectIdent2 + _str_Site, o.ObjectIdent3 + _str_Site, "Lookup", o.idfsSite == null ? "" : o.idfsSite.ToString(), o.IsReadOnly(_str_Site), o.IsInvisible(_str_Site), o.IsRequired(_str_Site),
                  bChangeLookupContent ? o.SiteLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Site + "Lookup", _formname = _str_Site + "Lookup", _type = "LookupContent",
              _get_func = o => o.SiteLookup,
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
            BasicSyndromicSurveillanceAggregateList obj = (BasicSyndromicSurveillanceAggregateList)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Hospital)]
        [Relation(typeof(OrganizationLookup), eidss.model.Schema.OrganizationLookup._str_idfInstitution, _str_idfHospital)]
        public OrganizationLookup Hospital
        {
            get { return _Hospital == null ? null : ((long)_Hospital.Key == 0 ? null : _Hospital); }
            set 
            { 
                var oldVal = _Hospital;
                _Hospital = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Hospital != oldVal)
                {
                    if (idfHospital != (_Hospital == null
                            ? new long?()
                            : _Hospital.idfInstitution))
                        idfHospital = _Hospital == null 
                            ? new long?()
                            : _Hospital.idfInstitution; 
                    OnPropertyChanged(_str_Hospital); 
                }
            }
        }
        private OrganizationLookup _Hospital;

        
        public List<OrganizationLookup> HospitalLookup
        {
            get { return _HospitalLookup; }
        }
        private List<OrganizationLookup> _HospitalLookup = new List<OrganizationLookup>();
            
        [LocalizedDisplayName(_str_Site)]
        [Relation(typeof(SiteLookup), eidss.model.Schema.SiteLookup._str_idfsSite, _str_idfsSite)]
        public SiteLookup Site
        {
            get { return _Site == null ? null : ((long)_Site.Key == 0 ? null : _Site); }
            set 
            { 
                var oldVal = _Site;
                _Site = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Site != oldVal)
                {
                    if (idfsSite != (_Site == null
                            ? new Int64()
                            : (Int64)_Site.idfsSite))
                        idfsSite = _Site == null 
                            ? new Int64()
                            : (Int64)_Site.idfsSite; 
                    OnPropertyChanged(_str_Site); 
                }
            }
        }
        private SiteLookup _Site;

        
        public List<SiteLookup> SiteLookup
        {
            get { return _SiteLookup; }
        }
        private List<SiteLookup> _SiteLookup = new List<SiteLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Hospital:
                    return new BvSelectList(HospitalLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, Hospital, _str_idfHospital);
            
                case _str_Site:
                    return new BvSelectList(SiteLookup, eidss.model.Schema.SiteLookup._str_idfsSite, null, Site, _str_idfsSite);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName("WeekForAggr")]
        public string strWeek
        {
            get { return new Func<BasicSyndromicSurveillanceAggregateList, string>(c => eidss.model.Helpers.AggregateListHelper.GetWeekCaption(c.intYear, c.intWeek))(this); }
            
        }
        
          [LocalizedDisplayName(_str_idfHospital)]
        public long? idfHospital
        {
            get { return m_idfHospital; }
            set { if (m_idfHospital != value) { m_idfHospital = value; OnPropertyChanged(_str_idfHospital); } }
        }
        private long? m_idfHospital;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "BasicSyndromicSurveillanceAggregateList";

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
            var ret = base.Clone() as BasicSyndromicSurveillanceAggregateList;
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
            var ret = base.Clone() as BasicSyndromicSurveillanceAggregateList;
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
        public BasicSyndromicSurveillanceAggregateList CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as BasicSyndromicSurveillanceAggregateList;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfAggregateHeader; } }
        public string KeyName { get { return "idfAggregateHeader"; } }
        public object KeyLookup { get { return idfAggregateHeader; } }
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
        
            var _prev_idfHospital_Hospital = idfHospital;
            var _prev_idfsSite_Site = idfsSite;
            base.RejectChanges();
        
            if (_prev_idfHospital_Hospital != idfHospital)
            {
                _Hospital = _HospitalLookup.FirstOrDefault(c => c.idfInstitution == idfHospital);
            }
            if (_prev_idfsSite_Site != idfsSite)
            {
                _Site = _SiteLookup.FirstOrDefault(c => c.idfsSite == idfsSite);
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

        private bool IsRIRPropChanged(string fld, BasicSyndromicSurveillanceAggregateList c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, BasicSyndromicSurveillanceAggregateList c)
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
        

      

        public BasicSyndromicSurveillanceAggregateList()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(BasicSyndromicSurveillanceAggregateList_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(BasicSyndromicSurveillanceAggregateList_PropertyChanged);
        }
        private void BasicSyndromicSurveillanceAggregateList_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as BasicSyndromicSurveillanceAggregateList).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_intWeek)
                OnPropertyChanged(_str_strWeek);
                  
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
            BasicSyndromicSurveillanceAggregateList obj = this;
            
        }
        private void _DeletedExtenders()
        {
            BasicSyndromicSurveillanceAggregateList obj = this;
            
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
            
            return ReadOnly || new Func<BasicSyndromicSurveillanceAggregateList, bool>(c => false)(this);
                
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


        internal Dictionary<string, Func<BasicSyndromicSurveillanceAggregateList, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<BasicSyndromicSurveillanceAggregateList, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<BasicSyndromicSurveillanceAggregateList, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<BasicSyndromicSurveillanceAggregateList, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<BasicSyndromicSurveillanceAggregateList, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<BasicSyndromicSurveillanceAggregateList, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<BasicSyndromicSurveillanceAggregateList, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~BasicSyndromicSurveillanceAggregateList()
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
                
                LookupManager.RemoveObject("OrganizationLookup", this);
                
                LookupManager.RemoveObject("SiteLookup", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "OrganizationLookup")
                _getAccessor().LoadLookup_Hospital(manager, this);
            
            if (lookup_object == "SiteLookup")
                _getAccessor().LoadLookup_Site(manager, this);
            
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
        public class BasicSyndromicSurveillanceAggregateListGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfAggregateHeader { get; set; }
        
            public String strFormID { get; set; }
        
            public string strWeek { get; set; }
        
            public String strHospitals { get; set; }
        
        }
        public partial class BasicSyndromicSurveillanceAggregateListGridModelList : List<BasicSyndromicSurveillanceAggregateListGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public BasicSyndromicSurveillanceAggregateListGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<BasicSyndromicSurveillanceAggregateList>, errMes);
            }
            public BasicSyndromicSurveillanceAggregateListGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<BasicSyndromicSurveillanceAggregateList>, errMes);
            }
            public BasicSyndromicSurveillanceAggregateListGridModelList(long key, IEnumerable<BasicSyndromicSurveillanceAggregateList> items)
            {
                LoadGridModelList(key, items, null);
            }
            public BasicSyndromicSurveillanceAggregateListGridModelList(long key)
            {
                LoadGridModelList(key, new List<BasicSyndromicSurveillanceAggregateList>(), null);
            }
            partial void filter(List<BasicSyndromicSurveillanceAggregateList> items);
            private void LoadGridModelList(long key, IEnumerable<BasicSyndromicSurveillanceAggregateList> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strFormID,_str_strWeek,_str_strHospitals};
                    
                Hiddens = new List<string> {_str_idfAggregateHeader};
                Keys = new List<string> {_str_idfAggregateHeader};
                Labels = new Dictionary<string, string> {{_str_strFormID, _str_strFormID},{_str_strWeek, "WeekForAggr"},{_str_strHospitals, "strHospital"}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strFormID, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "ActionEditBSS")}};
                BasicSyndromicSurveillanceAggregateList.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<BasicSyndromicSurveillanceAggregateList>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new BasicSyndromicSurveillanceAggregateListGridModel()
                {
                    ItemKey=c.idfAggregateHeader,strFormID=c.strFormID,strWeek=c.strWeek,strHospitals=c.strHospitals
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
        : DataAccessor<BasicSyndromicSurveillanceAggregateList>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<BasicSyndromicSurveillanceAggregateList>
            
            , IObjectSelectList
            , IObjectSelectList<BasicSyndromicSurveillanceAggregateList>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfAggregateHeader"; } }
            #endregion
        
            public delegate void on_action(BasicSyndromicSurveillanceAggregateList obj);
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
            private OrganizationLookup.Accessor HospitalAccessor { get { return eidss.model.Schema.OrganizationLookup.Accessor.Instance(m_CS); } }
            private SiteLookup.Accessor SiteAccessor { get { return eidss.model.Schema.SiteLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<BasicSyndromicSurveillanceAggregateList> SelectListT(DbManagerProxy manager
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
            
            protected virtual List<BasicSyndromicSurveillanceAggregateList> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_BasicSyndromicSurveillanceAggregate_SelectList.* from dbo.fn_BasicSyndromicSurveillanceAggregate_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (EidssSiteContext.Instance.SiteType == SiteType.TLVL)
                {
                    sql.Append(@" and exists (select * from  tflBasicSyndromicSurveillanceFiltered f inner join tflSiteToSiteGroup on tflSiteToSiteGroup.idfSiteGroup = f.idfSiteGroup and tflSiteToSiteGroup.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString() + " where f.idfBasicSyndromicSurveillance = fn_BasicSyndromicSurveillanceAggregate_SelectList.idfAggregateHeader)");
                }
                
                if (filters.Contains("idfAggregateHeader"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfAggregateHeader"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfAggregateHeader") ? " or " : " and ");
                        
                        if (filters.Operation("idfAggregateHeader", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillanceAggregate_SelectList.idfAggregateHeader,0) {0} @idfAggregateHeader_{1} = @idfAggregateHeader_{1})", filters.Operation("idfAggregateHeader", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillanceAggregate_SelectList.idfAggregateHeader,0) {0} @idfAggregateHeader_{1}", filters.Operation("idfAggregateHeader", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFormID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFormID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFormID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillanceAggregate_SelectList.strFormID {0} @strFormID_{1}", filters.Operation("strFormID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intYear"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intYear"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intYear") ? " or " : " and ");
                        
                        if (filters.Operation("intYear", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillanceAggregate_SelectList.intYear,0) {0} @intYear_{1} = @intYear_{1})", filters.Operation("intYear", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillanceAggregate_SelectList.intYear,0) {0} @intYear_{1}", filters.Operation("intYear", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("intWeek"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("intWeek"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("intWeek") ? " or " : " and ");
                        
                        if (filters.Operation("intWeek", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillanceAggregate_SelectList.intWeek,0) {0} @intWeek_{1} = @intWeek_{1})", filters.Operation("intWeek", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillanceAggregate_SelectList.intWeek,0) {0} @intWeek_{1}", filters.Operation("intWeek", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strHospitals"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strHospitals"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strHospitals") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_BasicSyndromicSurveillanceAggregate_SelectList.strHospitals {0} @strHospitals_{1}", filters.Operation("strHospitals", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsSite"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsSite"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsSite") ? " or " : " and ");
                        
                        if (filters.Operation("idfsSite", i) == "&")
                          sql.AppendFormat("(isnull(fn_BasicSyndromicSurveillanceAggregate_SelectList.idfsSite,0) {0} @idfsSite_{1} = @idfsSite_{1})", filters.Operation("idfsSite", i), i);
                        else
                          sql.AppendFormat("isnull(fn_BasicSyndromicSurveillanceAggregate_SelectList.idfsSite,0) {0} @idfsSite_{1}", filters.Operation("idfsSite", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_BasicSyndromicSurveillanceAggregate_SelectList.datStartDate, 112) {0} CONVERT(NVARCHAR(8), @datStartDate_{1}, 112)", filters.Operation("datStartDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datFinishDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datFinishDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datFinishDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_BasicSyndromicSurveillanceAggregate_SelectList.datFinishDate, 112) {0} CONVERT(NVARCHAR(8), @datFinishDate_{1}, 112)", filters.Operation("datFinishDate", i), i);
                            
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
                    
                    if (filters.Contains("idfAggregateHeader"))
                        for (int i = 0; i < filters.Count("idfAggregateHeader"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfAggregateHeader_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfAggregateHeader", i), filters.Value("idfAggregateHeader", i))));
                      
                    if (filters.Contains("strFormID"))
                        for (int i = 0; i < filters.Count("strFormID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFormID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFormID", i), filters.Value("strFormID", i))));
                      
                    if (filters.Contains("intYear"))
                        for (int i = 0; i < filters.Count("intYear"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intYear_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intYear", i), filters.Value("intYear", i))));
                      
                    if (filters.Contains("intWeek"))
                        for (int i = 0; i < filters.Count("intWeek"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@intWeek_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("intWeek", i), filters.Value("intWeek", i))));
                      
                    if (filters.Contains("strHospitals"))
                        for (int i = 0; i < filters.Count("strHospitals"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strHospitals_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strHospitals", i), filters.Value("strHospitals", i))));
                      
                    if (filters.Contains("idfsSite"))
                        for (int i = 0; i < filters.Count("idfsSite"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSite_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSite", i), filters.Value("idfsSite", i))));
                      
                    if (filters.Contains("datStartDate"))
                        for (int i = 0; i < filters.Count("datStartDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datStartDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datStartDate", i), filters.Value("datStartDate", i))));
                      
                    if (filters.Contains("datFinishDate"))
                        for (int i = 0; i < filters.Count("datFinishDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datFinishDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datFinishDate", i), filters.Value("datFinishDate", i))));
                      
                    List<BasicSyndromicSurveillanceAggregateList> objs = manager.ExecuteList<BasicSyndromicSurveillanceAggregateList>();
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
            partial void ListSelected(DbManagerProxy manager, List<BasicSyndromicSurveillanceAggregateList> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return null;
                    
            }
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateList obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, BasicSyndromicSurveillanceAggregateList obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private BasicSyndromicSurveillanceAggregateList _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                BasicSyndromicSurveillanceAggregateList obj = null;
                try
                {
                    obj = BasicSyndromicSurveillanceAggregateList.CreateInstance();
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

            
            public BasicSyndromicSurveillanceAggregateList CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public BasicSyndromicSurveillanceAggregateList CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public BasicSyndromicSurveillanceAggregateList CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ActionEditBSS(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateList obj, List<object> pars)
            {
                
                return ActionEditBSS(manager, obj
                    );
            }
            public ActResult ActionEditBSS(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateList obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ActionEditBSS"))
                    throw new PermissionException("AccessToBssModule", "ActionEditBSS");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(BasicSyndromicSurveillanceAggregateList obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(BasicSyndromicSurveillanceAggregateList obj)
            {
                
            }
    
            public void LoadLookup_Hospital(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateList obj)
            {
                
                obj.HospitalLookup.Clear();
                
                obj.HospitalLookup.Add(HospitalAccessor.CreateNewT(manager, null));
                
                obj.HospitalLookup.AddRange(HospitalAccessor.SelectLookupList(manager
                    
                    , null
                    , new Func<BasicSyndromicSurveillanceAggregateList, int>(c => (int)HACode.Syndromic)(obj)
                            
                    )
                    .Where(c => (((c.intHACode??0) & (int)HACode.Syndromic) != 0) || c.idfInstitution == obj.idfHospital)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfHospital))
                    
                    .ToList());
                
                if (obj.idfHospital != null && obj.idfHospital != 0)
                {
                    obj.Hospital = obj.HospitalLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfHospital);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, HospitalAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Site(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateList obj)
            {
                
                obj.SiteLookup.Clear();
                
                obj.SiteLookup.Add(SiteAccessor.CreateNewT(manager, null));
                
                obj.SiteLookup.AddRange(SiteAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intHACode.GetValueOrDefault() & (int)HACode.Syndromic) != 0)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsSite == obj.idfsSite))
                    
                    .ToList());
                
                if (obj.idfsSite != 0)
                {
                    obj.Site = obj.SiteLookup
                        .SingleOrDefault(c => c.idfsSite == obj.idfsSite);
                    
                }
              
                LookupManager.AddObject("SiteLookup", obj, SiteAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateList obj)
            {
                
                LoadLookup_Hospital(manager, obj);
                
                LoadLookup_Site(manager, obj);
                
            }
    
            [SprocName("spBasicSyndromicSurveillanceAggregateHeader_Delete")]
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
                        BasicSyndromicSurveillanceAggregateList bo = obj as BasicSyndromicSurveillanceAggregateList;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            if (!CanDelete)
                                throw new PermissionException("AccessToBssModule", "Delete");
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            if (!CanInsert)
                                throw new PermissionException("AccessToBssModule", "Insert");
                        }
                        else if (!bo.IsMarkedToDelete && bo.HasChanges) // update
                        {
                            if (!CanUpdate)
                                throw new PermissionException("AccessToBssModule", "Update");
                        }
                        
                        long mainObject = bo.idfAggregateHeader;
                        
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
                            
                            eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoBssForm;
                            eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbBasicSyndromicSurveillance;
                            manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as BasicSyndromicSurveillanceAggregateList, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateList obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfAggregateHeader
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
            
            public bool ValidateCanDelete(BasicSyndromicSurveillanceAggregateList obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateList obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(BasicSyndromicSurveillanceAggregateList obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(BasicSyndromicSurveillanceAggregateList obj, bool bRethrowException)
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
                return Validate(manager, obj as BasicSyndromicSurveillanceAggregateList, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateList obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(BasicSyndromicSurveillanceAggregateList obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(BasicSyndromicSurveillanceAggregateList obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as BasicSyndromicSurveillanceAggregateList) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as BasicSyndromicSurveillanceAggregateList) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "BasicSyndromicSurveillanceAggregateListDetail"; } }
            public string HelpIdWin { get { return "SS_aggr_list"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private BasicSyndromicSurveillanceAggregateList m_obj;
            internal Permissions(BasicSyndromicSurveillanceAggregateList obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_BasicSyndromicSurveillanceAggregate_SelectList";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spBasicSyndromicSurveillanceAggregateHeader_Delete";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<BasicSyndromicSurveillanceAggregateList, bool>> RequiredByField = new Dictionary<string, Func<BasicSyndromicSurveillanceAggregateList, bool>>();
            public static Dictionary<string, Func<BasicSyndromicSurveillanceAggregateList, bool>> RequiredByProperty = new Dictionary<string, Func<BasicSyndromicSurveillanceAggregateList, bool>>();
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
                
                Sizes.Add(_str_strFormID, 200);
                Sizes.Add(_str_strHospitals, 1000);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFormID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strFormID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datStartDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strWeeksFrom",
                    c=>DatePeriodHelper.GetFirstWeekOfYear(DateTime.Today.Year), ">=", c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datFinishDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strWeeksTo",
                    c=>DateTime.Now, "<=", c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfHospital",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strHospital",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "HospitalLookup", typeof(OrganizationLookup), (o) => { var c = (OrganizationLookup)o; return c.idfInstitution; }, (o) => { var c = (OrganizationLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSite",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "lbDataEntrySiteID",
                    c=>(c as BasicSyndromicSurveillanceAggregateList).SiteLookup.SingleOrDefault(s=>s.idfsSite == EidssSiteContext.Instance.SiteID), null, c => false, false, SearchPanelLocation.Main, false, null, "SiteLookup", typeof(SiteLookup), (o) => { var c = (SiteLookup)o; return c.idfsSite; }, (o) => { var c = (SiteLookup)o; return c.strSiteName; }, new List<Tuple<string, string>>(){new Tuple<string, string>("strSiteName", eidss.model.Resources.EidssFields.Get("strSiteName")),new Tuple<string, string>("strSiteID", eidss.model.Resources.EidssFields.Get("strSiteID")),},false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfAggregateHeader,
                    _str_idfAggregateHeader, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFormID,
                    _str_strFormID, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strWeek,
                    "WeekForAggr", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strHospitals,
                    "strHospital", null, false, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "ActionEditBSS",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionEditBSS(manager, (BasicSyndromicSurveillanceAggregateList)c, pars),
                        
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
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<BasicSyndromicSurveillanceAggregateHeader>().CreateNew(manager, c, pars == null ? null : (int?)pars[0])),
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<BasicSyndromicSurveillanceAggregateHeader>().SelectDetail(manager, pars[0])),
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
                                c = ObjectAccessor.CreatorInterface<BasicSyndromicSurveillanceAggregateList>().CreateWithParams(manager, null, pars);
                                ((BasicSyndromicSurveillanceAggregateList)c).idfAggregateHeader = (long)pars[0];
                                ((BasicSyndromicSurveillanceAggregateList)c).m_IsNew = false;
                            }
                            return new ActResult(((BasicSyndromicSurveillanceAggregateList)c).MarkToDelete() && ObjectAccessor.PostInterface<BasicSyndromicSurveillanceAggregateList>().Post(manager, (BasicSyndromicSurveillanceAggregateList)c), c);
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
	