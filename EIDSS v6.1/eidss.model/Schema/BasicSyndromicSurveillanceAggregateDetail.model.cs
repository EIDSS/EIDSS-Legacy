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
    public abstract partial class BasicSyndromicSurveillanceAggregateDetail : 
        EditableObject<BasicSyndromicSurveillanceAggregateDetail>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfAggregateDetail), NonUpdatable, PrimaryKey]
        public abstract Int64 idfAggregateDetail { get; set; }
                
        [LocalizedDisplayName(_str_idfAggregateHeader)]
        [MapField(_str_idfAggregateHeader)]
        public abstract Int64 idfAggregateHeader { get; set; }
        protected Int64 idfAggregateHeader_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfAggregateHeader).OriginalValue; } }
        protected Int64 idfAggregateHeader_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfAggregateHeader).PreviousValue; } }
                
        [LocalizedDisplayName("strHospital")]
        [MapField(_str_idfHospital)]
        public abstract Int64 idfHospital { get; set; }
        protected Int64 idfHospital_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfHospital).OriginalValue; } }
        protected Int64 idfHospital_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfHospital).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intAge0_4)]
        [MapField(_str_intAge0_4)]
        public abstract Int32? intAge0_4 { get; set; }
        protected Int32? intAge0_4_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intAge0_4).OriginalValue; } }
        protected Int32? intAge0_4_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intAge0_4).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intAge5_14)]
        [MapField(_str_intAge5_14)]
        public abstract Int32? intAge5_14 { get; set; }
        protected Int32? intAge5_14_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intAge5_14).OriginalValue; } }
        protected Int32? intAge5_14_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intAge5_14).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intAge15_29)]
        [MapField(_str_intAge15_29)]
        public abstract Int32? intAge15_29 { get; set; }
        protected Int32? intAge15_29_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intAge15_29).OriginalValue; } }
        protected Int32? intAge15_29_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intAge15_29).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intAge30_64)]
        [MapField(_str_intAge30_64)]
        public abstract Int32? intAge30_64 { get; set; }
        protected Int32? intAge30_64_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intAge30_64).OriginalValue; } }
        protected Int32? intAge30_64_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intAge30_64).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intAge65)]
        [MapField(_str_intAge65)]
        public abstract Int32? intAge65 { get; set; }
        protected Int32? intAge65_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intAge65).OriginalValue; } }
        protected Int32? intAge65_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intAge65).PreviousValue; } }
                
        [LocalizedDisplayName(_str_inTotalILI)]
        [MapField(_str_inTotalILI)]
        public abstract Int32? inTotalILI { get; set; }
        protected Int32? inTotalILI_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._inTotalILI).OriginalValue; } }
        protected Int32? inTotalILI_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._inTotalILI).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intTotalAdmissions)]
        [MapField(_str_intTotalAdmissions)]
        public abstract Int32? intTotalAdmissions { get; set; }
        protected Int32? intTotalAdmissions_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intTotalAdmissions).OriginalValue; } }
        protected Int32? intTotalAdmissions_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intTotalAdmissions).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intILISamples)]
        [MapField(_str_intILISamples)]
        public abstract Int32? intILISamples { get; set; }
        protected Int32? intILISamples_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intILISamples).OriginalValue; } }
        protected Int32? intILISamples_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intILISamples).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<BasicSyndromicSurveillanceAggregateDetail, object> _get_func;
            internal Action<BasicSyndromicSurveillanceAggregateDetail, string> _set_func;
            internal Action<BasicSyndromicSurveillanceAggregateDetail, BasicSyndromicSurveillanceAggregateDetail, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAggregateDetail = "idfAggregateDetail";
        internal const string _str_idfAggregateHeader = "idfAggregateHeader";
        internal const string _str_idfHospital = "idfHospital";
        internal const string _str_intAge0_4 = "intAge0_4";
        internal const string _str_intAge5_14 = "intAge5_14";
        internal const string _str_intAge15_29 = "intAge15_29";
        internal const string _str_intAge30_64 = "intAge30_64";
        internal const string _str_intAge65 = "intAge65";
        internal const string _str_inTotalILI = "inTotalILI";
        internal const string _str_intTotalAdmissions = "intTotalAdmissions";
        internal const string _str_intILISamples = "intILISamples";
        internal const string _str_Hospital = "Hospital";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfAggregateDetail, _formname = _str_idfAggregateDetail, _type = "Int64",
              _get_func = o => o.idfAggregateDetail,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfAggregateDetail != newval) o.idfAggregateDetail = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfAggregateDetail != c.idfAggregateDetail || o.IsRIRPropChanged(_str_idfAggregateDetail, c)) 
                  m.Add(_str_idfAggregateDetail, o.ObjectIdent + _str_idfAggregateDetail, o.ObjectIdent2 + _str_idfAggregateDetail, o.ObjectIdent3 + _str_idfAggregateDetail, "Int64", 
                    o.idfAggregateDetail == null ? "" : o.idfAggregateDetail.ToString(),                  
                  o.IsReadOnly(_str_idfAggregateDetail), o.IsInvisible(_str_idfAggregateDetail), o.IsRequired(_str_idfAggregateDetail)); 
                  }
              }, 
                  
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
              _name = _str_idfHospital, _formname = _str_idfHospital, _type = "Int64",
              _get_func = o => o.idfHospital,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); 
                if (o.idfHospital != newval) 
                  o.Hospital = o.HospitalLookup.FirstOrDefault(c => c.idfInstitution == newval);
                if (o.idfHospital != newval) o.idfHospital = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfHospital != c.idfHospital || o.IsRIRPropChanged(_str_idfHospital, c)) 
                  m.Add(_str_idfHospital, o.ObjectIdent + _str_idfHospital, o.ObjectIdent2 + _str_idfHospital, o.ObjectIdent3 + _str_idfHospital, "Int64", 
                    o.idfHospital == null ? "" : o.idfHospital.ToString(),                  
                  o.IsReadOnly(_str_idfHospital), o.IsInvisible(_str_idfHospital), o.IsRequired(_str_idfHospital)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intAge0_4, _formname = _str_intAge0_4, _type = "Int32?",
              _get_func = o => o.intAge0_4,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intAge0_4 != newval) o.intAge0_4 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intAge0_4 != c.intAge0_4 || o.IsRIRPropChanged(_str_intAge0_4, c)) 
                  m.Add(_str_intAge0_4, o.ObjectIdent + _str_intAge0_4, o.ObjectIdent2 + _str_intAge0_4, o.ObjectIdent3 + _str_intAge0_4, "Int32?", 
                    o.intAge0_4 == null ? "" : o.intAge0_4.ToString(),                  
                  o.IsReadOnly(_str_intAge0_4), o.IsInvisible(_str_intAge0_4), o.IsRequired(_str_intAge0_4)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intAge5_14, _formname = _str_intAge5_14, _type = "Int32?",
              _get_func = o => o.intAge5_14,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intAge5_14 != newval) o.intAge5_14 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intAge5_14 != c.intAge5_14 || o.IsRIRPropChanged(_str_intAge5_14, c)) 
                  m.Add(_str_intAge5_14, o.ObjectIdent + _str_intAge5_14, o.ObjectIdent2 + _str_intAge5_14, o.ObjectIdent3 + _str_intAge5_14, "Int32?", 
                    o.intAge5_14 == null ? "" : o.intAge5_14.ToString(),                  
                  o.IsReadOnly(_str_intAge5_14), o.IsInvisible(_str_intAge5_14), o.IsRequired(_str_intAge5_14)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intAge15_29, _formname = _str_intAge15_29, _type = "Int32?",
              _get_func = o => o.intAge15_29,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intAge15_29 != newval) o.intAge15_29 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intAge15_29 != c.intAge15_29 || o.IsRIRPropChanged(_str_intAge15_29, c)) 
                  m.Add(_str_intAge15_29, o.ObjectIdent + _str_intAge15_29, o.ObjectIdent2 + _str_intAge15_29, o.ObjectIdent3 + _str_intAge15_29, "Int32?", 
                    o.intAge15_29 == null ? "" : o.intAge15_29.ToString(),                  
                  o.IsReadOnly(_str_intAge15_29), o.IsInvisible(_str_intAge15_29), o.IsRequired(_str_intAge15_29)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intAge30_64, _formname = _str_intAge30_64, _type = "Int32?",
              _get_func = o => o.intAge30_64,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intAge30_64 != newval) o.intAge30_64 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intAge30_64 != c.intAge30_64 || o.IsRIRPropChanged(_str_intAge30_64, c)) 
                  m.Add(_str_intAge30_64, o.ObjectIdent + _str_intAge30_64, o.ObjectIdent2 + _str_intAge30_64, o.ObjectIdent3 + _str_intAge30_64, "Int32?", 
                    o.intAge30_64 == null ? "" : o.intAge30_64.ToString(),                  
                  o.IsReadOnly(_str_intAge30_64), o.IsInvisible(_str_intAge30_64), o.IsRequired(_str_intAge30_64)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intAge65, _formname = _str_intAge65, _type = "Int32?",
              _get_func = o => o.intAge65,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intAge65 != newval) o.intAge65 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intAge65 != c.intAge65 || o.IsRIRPropChanged(_str_intAge65, c)) 
                  m.Add(_str_intAge65, o.ObjectIdent + _str_intAge65, o.ObjectIdent2 + _str_intAge65, o.ObjectIdent3 + _str_intAge65, "Int32?", 
                    o.intAge65 == null ? "" : o.intAge65.ToString(),                  
                  o.IsReadOnly(_str_intAge65), o.IsInvisible(_str_intAge65), o.IsRequired(_str_intAge65)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_inTotalILI, _formname = _str_inTotalILI, _type = "Int32?",
              _get_func = o => o.inTotalILI,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.inTotalILI != newval) o.inTotalILI = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.inTotalILI != c.inTotalILI || o.IsRIRPropChanged(_str_inTotalILI, c)) 
                  m.Add(_str_inTotalILI, o.ObjectIdent + _str_inTotalILI, o.ObjectIdent2 + _str_inTotalILI, o.ObjectIdent3 + _str_inTotalILI, "Int32?", 
                    o.inTotalILI == null ? "" : o.inTotalILI.ToString(),                  
                  o.IsReadOnly(_str_inTotalILI), o.IsInvisible(_str_inTotalILI), o.IsRequired(_str_inTotalILI)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intTotalAdmissions, _formname = _str_intTotalAdmissions, _type = "Int32?",
              _get_func = o => o.intTotalAdmissions,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intTotalAdmissions != newval) o.intTotalAdmissions = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intTotalAdmissions != c.intTotalAdmissions || o.IsRIRPropChanged(_str_intTotalAdmissions, c)) 
                  m.Add(_str_intTotalAdmissions, o.ObjectIdent + _str_intTotalAdmissions, o.ObjectIdent2 + _str_intTotalAdmissions, o.ObjectIdent3 + _str_intTotalAdmissions, "Int32?", 
                    o.intTotalAdmissions == null ? "" : o.intTotalAdmissions.ToString(),                  
                  o.IsReadOnly(_str_intTotalAdmissions), o.IsInvisible(_str_intTotalAdmissions), o.IsRequired(_str_intTotalAdmissions)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intILISamples, _formname = _str_intILISamples, _type = "Int32?",
              _get_func = o => o.intILISamples,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intILISamples != newval) o.intILISamples = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intILISamples != c.intILISamples || o.IsRIRPropChanged(_str_intILISamples, c)) 
                  m.Add(_str_intILISamples, o.ObjectIdent + _str_intILISamples, o.ObjectIdent2 + _str_intILISamples, o.ObjectIdent3 + _str_intILISamples, "Int32?", 
                    o.intILISamples == null ? "" : o.intILISamples.ToString(),                  
                  o.IsReadOnly(_str_intILISamples), o.IsInvisible(_str_intILISamples), o.IsRequired(_str_intILISamples)); 
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
            BasicSyndromicSurveillanceAggregateDetail obj = (BasicSyndromicSurveillanceAggregateDetail)o;
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
                            ? new Int64()
                            : (Int64)_Hospital.idfInstitution))
                        idfHospital = _Hospital == null 
                            ? new Int64()
                            : (Int64)_Hospital.idfInstitution; 
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
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Hospital:
                    return new BvSelectList(HospitalLookup, eidss.model.Schema.OrganizationLookup._str_idfInstitution, null, Hospital, _str_idfHospital);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "BasicSyndromicSurveillanceAggregateDetail";

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
            var ret = base.Clone() as BasicSyndromicSurveillanceAggregateDetail;
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
            var ret = base.Clone() as BasicSyndromicSurveillanceAggregateDetail;
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
        public BasicSyndromicSurveillanceAggregateDetail CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as BasicSyndromicSurveillanceAggregateDetail;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfAggregateDetail; } }
        public string KeyName { get { return "idfAggregateDetail"; } }
        public object KeyLookup { get { return idfAggregateDetail; } }
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
            base.RejectChanges();
        
            if (_prev_idfHospital_Hospital != idfHospital)
            {
                _Hospital = _HospitalLookup.FirstOrDefault(c => c.idfInstitution == idfHospital);
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

        private bool IsRIRPropChanged(string fld, BasicSyndromicSurveillanceAggregateDetail c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, BasicSyndromicSurveillanceAggregateDetail c)
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
        

      

        public BasicSyndromicSurveillanceAggregateDetail()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(BasicSyndromicSurveillanceAggregateDetail_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(BasicSyndromicSurveillanceAggregateDetail_PropertyChanged);
        }
        private void BasicSyndromicSurveillanceAggregateDetail_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as BasicSyndromicSurveillanceAggregateDetail).Changed(e.PropertyName);
            
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
            BasicSyndromicSurveillanceAggregateDetail obj = this;
            
        }
        private void _DeletedExtenders()
        {
            BasicSyndromicSurveillanceAggregateDetail obj = this;
            
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
            
            return ReadOnly || new Func<BasicSyndromicSurveillanceAggregateDetail, bool>(c => c.ReadOnly)(this);
                
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


        internal Dictionary<string, Func<BasicSyndromicSurveillanceAggregateDetail, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<BasicSyndromicSurveillanceAggregateDetail, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<BasicSyndromicSurveillanceAggregateDetail, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<BasicSyndromicSurveillanceAggregateDetail, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<BasicSyndromicSurveillanceAggregateDetail, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<BasicSyndromicSurveillanceAggregateDetail, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<BasicSyndromicSurveillanceAggregateDetail, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~BasicSyndromicSurveillanceAggregateDetail()
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
        public class BasicSyndromicSurveillanceAggregateDetailGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfAggregateDetail { get; set; }
        
            public Int64 idfHospital { get; set; }
        
            public Int32? intAge0_4 { get; set; }
        
            public Int32? intAge5_14 { get; set; }
        
            public Int32? intAge15_29 { get; set; }
        
            public Int32? intAge30_64 { get; set; }
        
            public Int32? intAge65 { get; set; }
        
            public Int32? inTotalILI { get; set; }
        
            public Int32? intTotalAdmissions { get; set; }
        
            public Int32? intILISamples { get; set; }
        
        }
        public partial class BasicSyndromicSurveillanceAggregateDetailGridModelList : List<BasicSyndromicSurveillanceAggregateDetailGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public BasicSyndromicSurveillanceAggregateDetailGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<BasicSyndromicSurveillanceAggregateDetail>, errMes);
            }
            public BasicSyndromicSurveillanceAggregateDetailGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<BasicSyndromicSurveillanceAggregateDetail>, errMes);
            }
            public BasicSyndromicSurveillanceAggregateDetailGridModelList(long key, IEnumerable<BasicSyndromicSurveillanceAggregateDetail> items)
            {
                LoadGridModelList(key, items, null);
            }
            public BasicSyndromicSurveillanceAggregateDetailGridModelList(long key)
            {
                LoadGridModelList(key, new List<BasicSyndromicSurveillanceAggregateDetail>(), null);
            }
            partial void filter(List<BasicSyndromicSurveillanceAggregateDetail> items);
            private void LoadGridModelList(long key, IEnumerable<BasicSyndromicSurveillanceAggregateDetail> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_idfHospital,_str_intAge0_4,_str_intAge5_14,_str_intAge15_29,_str_intAge30_64,_str_intAge65,_str_inTotalILI,_str_intTotalAdmissions,_str_intILISamples};
                    
                Hiddens = new List<string> {_str_idfAggregateDetail};
                Keys = new List<string> {_str_idfAggregateDetail};
                Labels = new Dictionary<string, string> {{_str_idfHospital, "strHospital"},{_str_intAge0_4, _str_intAge0_4},{_str_intAge5_14, _str_intAge5_14},{_str_intAge15_29, _str_intAge15_29},{_str_intAge30_64, _str_intAge30_64},{_str_intAge65, _str_intAge65},{_str_inTotalILI, _str_inTotalILI},{_str_intTotalAdmissions, _str_intTotalAdmissions},{_str_intILISamples, _str_intILISamples}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                BasicSyndromicSurveillanceAggregateDetail.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<BasicSyndromicSurveillanceAggregateDetail>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new BasicSyndromicSurveillanceAggregateDetailGridModel()
                {
                    ItemKey=c.idfAggregateDetail,idfHospital=c.idfHospital,intAge0_4=c.intAge0_4,intAge5_14=c.intAge5_14,intAge15_29=c.intAge15_29,intAge30_64=c.intAge30_64,intAge65=c.intAge65,inTotalILI=c.inTotalILI,intTotalAdmissions=c.intTotalAdmissions,intILISamples=c.intILISamples
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
        : DataAccessor<BasicSyndromicSurveillanceAggregateDetail>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<BasicSyndromicSurveillanceAggregateDetail>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfAggregateDetail"; } }
            #endregion
        
            public delegate void on_action(BasicSyndromicSurveillanceAggregateDetail obj);
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
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<BasicSyndromicSurveillanceAggregateDetail> SelectList(DbManagerProxy manager
                , Int64? idfAggregateHeader
                )
            {
                return _SelectList(manager
                    , idfAggregateHeader
                    , delegate(BasicSyndromicSurveillanceAggregateDetail obj)
                        {
                        }
                    , delegate(BasicSyndromicSurveillanceAggregateDetail obj)
                        {
                        }
                    );
            }

            

            public List<BasicSyndromicSurveillanceAggregateDetail> _SelectList(DbManagerProxy manager
                , Int64? idfAggregateHeader
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfAggregateHeader
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<BasicSyndromicSurveillanceAggregateDetail> _SelectListInternal(DbManagerProxy manager
                , Int64? idfAggregateHeader
                , on_action loading, on_action loaded
                )
            {
                BasicSyndromicSurveillanceAggregateDetail _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<BasicSyndromicSurveillanceAggregateDetail> objs = new List<BasicSyndromicSurveillanceAggregateDetail>();
                    sets[0] = new MapResultSet(typeof(BasicSyndromicSurveillanceAggregateDetail), objs);
                    
                    manager
                        .SetSpCommand("spBasicSyndromicSurveillanceAggregateDetail_SelectDetail"
                            , manager.Parameter("@idfAggregateHeader", idfAggregateHeader)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateDetail obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, BasicSyndromicSurveillanceAggregateDetail obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private BasicSyndromicSurveillanceAggregateDetail _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                BasicSyndromicSurveillanceAggregateDetail obj = null;
                try
                {
                    obj = BasicSyndromicSurveillanceAggregateDetail.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfAggregateDetail = (new GetNewIDExtender<BasicSyndromicSurveillanceAggregateDetail>()).GetScalar(manager, obj, isFake);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.idfAggregateHeader = new Func<BasicSyndromicSurveillanceAggregateDetail, long>(c => c.Parent != null ? (c.Parent as BasicSyndromicSurveillanceAggregateHeader).idfAggregateHeader : 0)(obj);
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

            
            public BasicSyndromicSurveillanceAggregateDetail CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public BasicSyndromicSurveillanceAggregateDetail CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public BasicSyndromicSurveillanceAggregateDetail CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public BasicSyndromicSurveillanceAggregateDetail CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                return Create(manager, Parent
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public BasicSyndromicSurveillanceAggregateDetail Create(DbManagerProxy manager, IObject Parent
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(BasicSyndromicSurveillanceAggregateDetail obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(BasicSyndromicSurveillanceAggregateDetail obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_intAge0_4)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intAge0_4);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_intAge5_14)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intAge5_14);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_intAge15_29)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intAge15_29);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_intAge30_64)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intAge30_64);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_intAge65)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intAge65);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_inTotalILI)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_inTotalILI);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_intTotalAdmissions)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intTotalAdmissions);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                        if (e.PropertyName == _str_intILISamples)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null && !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intILISamples);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Hospital(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateDetail obj)
            {
                
                obj.HospitalLookup.Clear();
                
                obj.HospitalLookup.Add(HospitalAccessor.CreateNewT(manager, null));
                
                obj.HospitalLookup.AddRange(HospitalAccessor.SelectLookupList(manager
                    
                    , null
                    , null
                    )
                    .Where(c => (((c.intHACode??0) & (int)HACode.Syndromic) != 0) || c.idfInstitution == obj.idfHospital)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfInstitution == obj.idfHospital))
                    
                    .ToList());
                
                if (obj.idfHospital != 0)
                {
                    obj.Hospital = obj.HospitalLookup
                        .SingleOrDefault(c => c.idfInstitution == obj.idfHospital);
                    
                }
              
                LookupManager.AddObject("OrganizationLookup", obj, HospitalAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateDetail obj)
            {
                
                LoadLookup_Hospital(manager, obj);
                
            }
    
            [SprocName("spBasicSyndromicSurveillanceAggregateDetail_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            [SprocName("spBasicSyndromicSurveillanceAggregateDetail_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] BasicSyndromicSurveillanceAggregateDetail obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput()] BasicSyndromicSurveillanceAggregateDetail obj)
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
                        BasicSyndromicSurveillanceAggregateDetail bo = obj as BasicSyndromicSurveillanceAggregateDetail;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as BasicSyndromicSurveillanceAggregateDetail, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateDetail obj, bool bChildObject) 
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
            
            public bool ValidateCanDelete(BasicSyndromicSurveillanceAggregateDetail obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateDetail obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(BasicSyndromicSurveillanceAggregateDetail obj)
            {
                
                try
                {
                  
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceAggregateDetail>(obj, "MinValue", c => true, 
      1,
      null,
      false, listMinValue => {
    listMinValue.Add(
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceAggregateDetail>(obj, "intAge0_4", c => true, 
      obj.intAge0_4,
      obj.GetType(),
      false, listintAge0_4 => {
    
    }));
  listMinValue.Add(
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceAggregateDetail>(obj, "intAge5_14", c => true, 
      obj.intAge5_14,
      obj.GetType(),
      false, listintAge5_14 => {
    
    }));
  listMinValue.Add(
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceAggregateDetail>(obj, "intAge15_29", c => true, 
      obj.intAge15_29,
      obj.GetType(),
      false, listintAge15_29 => {
    
    }));
  listMinValue.Add(
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceAggregateDetail>(obj, "intAge30_64", c => true, 
      obj.intAge30_64,
      obj.GetType(),
      false, listintAge30_64 => {
    
    }));
  listMinValue.Add(
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceAggregateDetail>(obj, "intAge65", c => true, 
      obj.intAge65,
      obj.GetType(),
      false, listintAge65 => {
    
    }));
  listMinValue.Add(
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceAggregateDetail>(obj, "inTotalILI", c => true, 
      obj.inTotalILI,
      obj.GetType(),
      false, listinTotalILI => {
    
    }));
  listMinValue.Add(
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceAggregateDetail>(obj, "intTotalAdmissions", c => true, 
      obj.intTotalAdmissions,
      obj.GetType(),
      false, listintTotalAdmissions => {
    
    }));
  listMinValue.Add(
    new ChainsValidatorNullableInt<BasicSyndromicSurveillanceAggregateDetail>(obj, "intILISamples", c => true, 
      obj.intILISamples,
      obj.GetType(),
      false, listintILISamples => {
    
    }));
  
    }).Process();
  
                }
                catch(ValidationModelException ex)
                {
                    return ex;
                }
                
                return null;
            }
            protected bool ChainsValidate(BasicSyndromicSurveillanceAggregateDetail obj, bool bRethrowException)
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
                return Validate(manager, obj as BasicSyndromicSurveillanceAggregateDetail, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateDetail obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfHospital", "Hospital","BSS.Hospital",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.idfHospital);
            
                  
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
           
    
            private void _SetupRequired(BasicSyndromicSurveillanceAggregateDetail obj)
            {
            
                obj
                    .AddRequired("Hospital", c => true);
                    
                  obj
                    .AddRequired("Hospital", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(BasicSyndromicSurveillanceAggregateDetail obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as BasicSyndromicSurveillanceAggregateDetail) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as BasicSyndromicSurveillanceAggregateDetail) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "BasicSyndromicSurveillanceAggregateDetailDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spBasicSyndromicSurveillanceAggregateDetail_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spBasicSyndromicSurveillanceAggregateDetail_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spBasicSyndromicSurveillanceAggregateDetail_Delete";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<BasicSyndromicSurveillanceAggregateDetail, bool>> RequiredByField = new Dictionary<string, Func<BasicSyndromicSurveillanceAggregateDetail, bool>>();
            public static Dictionary<string, Func<BasicSyndromicSurveillanceAggregateDetail, bool>> RequiredByProperty = new Dictionary<string, Func<BasicSyndromicSurveillanceAggregateDetail, bool>>();
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
                
                if (!RequiredByField.ContainsKey("idfHospital")) RequiredByField.Add("idfHospital", c => true);
                if (!RequiredByProperty.ContainsKey("Hospital")) RequiredByProperty.Add("Hospital", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfAggregateDetail,
                    _str_idfAggregateDetail, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfHospital,
                    "strHospital", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intAge0_4,
                    _str_intAge0_4, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intAge5_14,
                    _str_intAge5_14, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intAge15_29,
                    _str_intAge15_29, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intAge30_64,
                    _str_intAge30_64, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intAge65,
                    _str_intAge65, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_inTotalILI,
                    _str_inTotalILI, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intTotalAdmissions,
                    _str_intTotalAdmissions, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intILISamples,
                    _str_intILISamples, null, false, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).Create(manager, c, pars)),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c, a, b, p) => false,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Edit",
                    ActionTypes.Edit,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Left,
                        ActionsPanelType.Group,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    null,
                    null,
                    (c, a, b, p) => false,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => ((BasicSyndromicSurveillanceAggregateDetail)c).MarkToDelete(),
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
	