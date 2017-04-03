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
    public abstract partial class AsCampaignListItem : 
        EditableObject<AsCampaignListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCampaign), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCampaign { get; set; }
                
        [LocalizedDisplayName(_str_strCampaignType)]
        [MapField(_str_strCampaignType)]
        public abstract String strCampaignType { get; set; }
        #if MONO
        protected String strCampaignType_Original { get { return strCampaignType; } }
        protected String strCampaignType_Previous { get { return strCampaignType; } }
        #else
        protected String strCampaignType_Original { get { return ((EditableValue<String>)((dynamic)this)._strCampaignType).OriginalValue; } }
        protected String strCampaignType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCampaignType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCampaignType)]
        [MapField(_str_idfsCampaignType)]
        public abstract Int64? idfsCampaignType { get; set; }
        #if MONO
        protected Int64? idfsCampaignType_Original { get { return idfsCampaignType; } }
        protected Int64? idfsCampaignType_Previous { get { return idfsCampaignType; } }
        #else
        protected Int64? idfsCampaignType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCampaignType).OriginalValue; } }
        protected Int64? idfsCampaignType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCampaignType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCampaignStatus)]
        [MapField(_str_strCampaignStatus)]
        public abstract String strCampaignStatus { get; set; }
        #if MONO
        protected String strCampaignStatus_Original { get { return strCampaignStatus; } }
        protected String strCampaignStatus_Previous { get { return strCampaignStatus; } }
        #else
        protected String strCampaignStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._strCampaignStatus).OriginalValue; } }
        protected String strCampaignStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCampaignStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsCampaignStatus)]
        [MapField(_str_idfsCampaignStatus)]
        public abstract Int64? idfsCampaignStatus { get; set; }
        #if MONO
        protected Int64? idfsCampaignStatus_Original { get { return idfsCampaignStatus; } }
        protected Int64? idfsCampaignStatus_Previous { get { return idfsCampaignStatus; } }
        #else
        protected Int64? idfsCampaignStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCampaignStatus).OriginalValue; } }
        protected Int64? idfsCampaignStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsCampaignStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("datStartDate")]
        [MapField(_str_datCampaignDateStart)]
        public abstract DateTime? datCampaignDateStart { get; set; }
        #if MONO
        protected DateTime? datCampaignDateStart_Original { get { return datCampaignDateStart; } }
        protected DateTime? datCampaignDateStart_Previous { get { return datCampaignDateStart; } }
        #else
        protected DateTime? datCampaignDateStart_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateStart).OriginalValue; } }
        protected DateTime? datCampaignDateStart_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateStart).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("datFinishDate")]
        [MapField(_str_datCampaignDateEnd)]
        public abstract DateTime? datCampaignDateEnd { get; set; }
        #if MONO
        protected DateTime? datCampaignDateEnd_Original { get { return datCampaignDateEnd; } }
        protected DateTime? datCampaignDateEnd_Previous { get { return datCampaignDateEnd; } }
        #else
        protected DateTime? datCampaignDateEnd_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateEnd).OriginalValue; } }
        protected DateTime? datCampaignDateEnd_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateEnd).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCampaignID)]
        [MapField(_str_strCampaignID)]
        public abstract String strCampaignID { get; set; }
        #if MONO
        protected String strCampaignID_Original { get { return strCampaignID; } }
        protected String strCampaignID_Previous { get { return strCampaignID; } }
        #else
        protected String strCampaignID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCampaignID).OriginalValue; } }
        protected String strCampaignID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCampaignID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strCampaignName)]
        [MapField(_str_strCampaignName)]
        public abstract String strCampaignName { get; set; }
        #if MONO
        protected String strCampaignName_Original { get { return strCampaignName; } }
        protected String strCampaignName_Previous { get { return strCampaignName; } }
        #else
        protected String strCampaignName_Original { get { return ((EditableValue<String>)((dynamic)this)._strCampaignName).OriginalValue; } }
        protected String strCampaignName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCampaignName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strASAdministrator")]
        [MapField(_str_strCampaignAdministrator)]
        public abstract String strCampaignAdministrator { get; set; }
        #if MONO
        protected String strCampaignAdministrator_Original { get { return strCampaignAdministrator; } }
        protected String strCampaignAdministrator_Previous { get { return strCampaignAdministrator; } }
        #else
        protected String strCampaignAdministrator_Original { get { return ((EditableValue<String>)((dynamic)this)._strCampaignAdministrator).OriginalValue; } }
        protected String strCampaignAdministrator_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCampaignAdministrator).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<AsCampaignListItem, object> _get_func;
            internal Action<AsCampaignListItem, string> _set_func;
            internal Action<AsCampaignListItem, AsCampaignListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCampaign = "idfCampaign";
        internal const string _str_strCampaignType = "strCampaignType";
        internal const string _str_idfsCampaignType = "idfsCampaignType";
        internal const string _str_strCampaignStatus = "strCampaignStatus";
        internal const string _str_idfsCampaignStatus = "idfsCampaignStatus";
        internal const string _str_datCampaignDateStart = "datCampaignDateStart";
        internal const string _str_datCampaignDateEnd = "datCampaignDateEnd";
        internal const string _str_strCampaignID = "strCampaignID";
        internal const string _str_strCampaignName = "strCampaignName";
        internal const string _str_strCampaignAdministrator = "strCampaignAdministrator";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_AsCampaignType = "AsCampaignType";
        internal const string _str_AsCampaignStatus = "AsCampaignStatus";
        internal const string _str_Diagnosis = "Diagnosis";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfCampaign, _type = "Int64",
              _get_func = o => o.idfCampaign,
              _set_func = (o, val) => { o.idfCampaign = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCampaign != c.idfCampaign || o.IsRIRPropChanged(_str_idfCampaign, c)) 
                  m.Add(_str_idfCampaign, o.ObjectIdent + _str_idfCampaign, "Int64", o.idfCampaign == null ? "" : o.idfCampaign.ToString(), o.IsReadOnly(_str_idfCampaign), o.IsInvisible(_str_idfCampaign), o.IsRequired(_str_idfCampaign)); }
              }, 
        
            new field_info {
              _name = _str_strCampaignType, _type = "String",
              _get_func = o => o.strCampaignType,
              _set_func = (o, val) => { o.strCampaignType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCampaignType != c.strCampaignType || o.IsRIRPropChanged(_str_strCampaignType, c)) 
                  m.Add(_str_strCampaignType, o.ObjectIdent + _str_strCampaignType, "String", o.strCampaignType == null ? "" : o.strCampaignType.ToString(), o.IsReadOnly(_str_strCampaignType), o.IsInvisible(_str_strCampaignType), o.IsRequired(_str_strCampaignType)); }
              }, 
        
            new field_info {
              _name = _str_idfsCampaignType, _type = "Int64?",
              _get_func = o => o.idfsCampaignType,
              _set_func = (o, val) => { o.idfsCampaignType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCampaignType != c.idfsCampaignType || o.IsRIRPropChanged(_str_idfsCampaignType, c)) 
                  m.Add(_str_idfsCampaignType, o.ObjectIdent + _str_idfsCampaignType, "Int64?", o.idfsCampaignType == null ? "" : o.idfsCampaignType.ToString(), o.IsReadOnly(_str_idfsCampaignType), o.IsInvisible(_str_idfsCampaignType), o.IsRequired(_str_idfsCampaignType)); }
              }, 
        
            new field_info {
              _name = _str_strCampaignStatus, _type = "String",
              _get_func = o => o.strCampaignStatus,
              _set_func = (o, val) => { o.strCampaignStatus = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCampaignStatus != c.strCampaignStatus || o.IsRIRPropChanged(_str_strCampaignStatus, c)) 
                  m.Add(_str_strCampaignStatus, o.ObjectIdent + _str_strCampaignStatus, "String", o.strCampaignStatus == null ? "" : o.strCampaignStatus.ToString(), o.IsReadOnly(_str_strCampaignStatus), o.IsInvisible(_str_strCampaignStatus), o.IsRequired(_str_strCampaignStatus)); }
              }, 
        
            new field_info {
              _name = _str_idfsCampaignStatus, _type = "Int64?",
              _get_func = o => o.idfsCampaignStatus,
              _set_func = (o, val) => { o.idfsCampaignStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCampaignStatus != c.idfsCampaignStatus || o.IsRIRPropChanged(_str_idfsCampaignStatus, c)) 
                  m.Add(_str_idfsCampaignStatus, o.ObjectIdent + _str_idfsCampaignStatus, "Int64?", o.idfsCampaignStatus == null ? "" : o.idfsCampaignStatus.ToString(), o.IsReadOnly(_str_idfsCampaignStatus), o.IsInvisible(_str_idfsCampaignStatus), o.IsRequired(_str_idfsCampaignStatus)); }
              }, 
        
            new field_info {
              _name = _str_datCampaignDateStart, _type = "DateTime?",
              _get_func = o => o.datCampaignDateStart,
              _set_func = (o, val) => { o.datCampaignDateStart = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCampaignDateStart != c.datCampaignDateStart || o.IsRIRPropChanged(_str_datCampaignDateStart, c)) 
                  m.Add(_str_datCampaignDateStart, o.ObjectIdent + _str_datCampaignDateStart, "DateTime?", o.datCampaignDateStart == null ? "" : o.datCampaignDateStart.ToString(), o.IsReadOnly(_str_datCampaignDateStart), o.IsInvisible(_str_datCampaignDateStart), o.IsRequired(_str_datCampaignDateStart)); }
              }, 
        
            new field_info {
              _name = _str_datCampaignDateEnd, _type = "DateTime?",
              _get_func = o => o.datCampaignDateEnd,
              _set_func = (o, val) => { o.datCampaignDateEnd = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datCampaignDateEnd != c.datCampaignDateEnd || o.IsRIRPropChanged(_str_datCampaignDateEnd, c)) 
                  m.Add(_str_datCampaignDateEnd, o.ObjectIdent + _str_datCampaignDateEnd, "DateTime?", o.datCampaignDateEnd == null ? "" : o.datCampaignDateEnd.ToString(), o.IsReadOnly(_str_datCampaignDateEnd), o.IsInvisible(_str_datCampaignDateEnd), o.IsRequired(_str_datCampaignDateEnd)); }
              }, 
        
            new field_info {
              _name = _str_strCampaignID, _type = "String",
              _get_func = o => o.strCampaignID,
              _set_func = (o, val) => { o.strCampaignID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCampaignID != c.strCampaignID || o.IsRIRPropChanged(_str_strCampaignID, c)) 
                  m.Add(_str_strCampaignID, o.ObjectIdent + _str_strCampaignID, "String", o.strCampaignID == null ? "" : o.strCampaignID.ToString(), o.IsReadOnly(_str_strCampaignID), o.IsInvisible(_str_strCampaignID), o.IsRequired(_str_strCampaignID)); }
              }, 
        
            new field_info {
              _name = _str_strCampaignName, _type = "String",
              _get_func = o => o.strCampaignName,
              _set_func = (o, val) => { o.strCampaignName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCampaignName != c.strCampaignName || o.IsRIRPropChanged(_str_strCampaignName, c)) 
                  m.Add(_str_strCampaignName, o.ObjectIdent + _str_strCampaignName, "String", o.strCampaignName == null ? "" : o.strCampaignName.ToString(), o.IsReadOnly(_str_strCampaignName), o.IsInvisible(_str_strCampaignName), o.IsRequired(_str_strCampaignName)); }
              }, 
        
            new field_info {
              _name = _str_strCampaignAdministrator, _type = "String",
              _get_func = o => o.strCampaignAdministrator,
              _set_func = (o, val) => { o.strCampaignAdministrator = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strCampaignAdministrator != c.strCampaignAdministrator || o.IsRIRPropChanged(_str_strCampaignAdministrator, c)) 
                  m.Add(_str_strCampaignAdministrator, o.ObjectIdent + _str_strCampaignAdministrator, "String", o.strCampaignAdministrator == null ? "" : o.strCampaignAdministrator.ToString(), o.IsReadOnly(_str_strCampaignAdministrator), o.IsInvisible(_str_strCampaignAdministrator), o.IsRequired(_str_strCampaignAdministrator)); }
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
              _name = _str_AsCampaignType, _type = "Lookup",
              _get_func = o => { if (o.AsCampaignType == null) return null; return o.AsCampaignType.idfsBaseReference; },
              _set_func = (o, val) => { o.AsCampaignType = o.AsCampaignTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCampaignType != c.idfsCampaignType || o.IsRIRPropChanged(_str_AsCampaignType, c)) 
                  m.Add(_str_AsCampaignType, o.ObjectIdent + _str_AsCampaignType, "Lookup", o.idfsCampaignType == null ? "" : o.idfsCampaignType.ToString(), o.IsReadOnly(_str_AsCampaignType), o.IsInvisible(_str_AsCampaignType), o.IsRequired(_str_AsCampaignType)); }
              }, 
        
            new field_info {
              _name = _str_AsCampaignStatus, _type = "Lookup",
              _get_func = o => { if (o.AsCampaignStatus == null) return null; return o.AsCampaignStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.AsCampaignStatus = o.AsCampaignStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCampaignStatus != c.idfsCampaignStatus || o.IsRIRPropChanged(_str_AsCampaignStatus, c)) 
                  m.Add(_str_AsCampaignStatus, o.ObjectIdent + _str_AsCampaignStatus, "Lookup", o.idfsCampaignStatus == null ? "" : o.idfsCampaignStatus.ToString(), o.IsReadOnly(_str_AsCampaignStatus), o.IsInvisible(_str_AsCampaignStatus), o.IsRequired(_str_AsCampaignStatus)); }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c)) 
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); }
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
            AsCampaignListItem obj = (AsCampaignListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCampaignType)]
        public BaseReference AsCampaignType
        {
            get { return _AsCampaignType == null ? null : ((long)_AsCampaignType.Key == 0 ? null : _AsCampaignType); }
            set 
            { 
                _AsCampaignType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCampaignType = _AsCampaignType == null 
                    ? new Int64?()
                    : _AsCampaignType.idfsBaseReference; 
                OnPropertyChanged(_str_AsCampaignType); 
            }
        }
        private BaseReference _AsCampaignType;

        
        public BaseReferenceList AsCampaignTypeLookup
        {
            get { return _AsCampaignTypeLookup; }
        }
        private BaseReferenceList _AsCampaignTypeLookup = new BaseReferenceList("rftCampaignType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCampaignStatus)]
        public BaseReference AsCampaignStatus
        {
            get { return _AsCampaignStatus == null ? null : ((long)_AsCampaignStatus.Key == 0 ? null : _AsCampaignStatus); }
            set 
            { 
                _AsCampaignStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCampaignStatus = _AsCampaignStatus == null 
                    ? new Int64?()
                    : _AsCampaignStatus.idfsBaseReference; 
                OnPropertyChanged(_str_AsCampaignStatus); 
            }
        }
        private BaseReference _AsCampaignStatus;

        
        public BaseReferenceList AsCampaignStatusLookup
        {
            get { return _AsCampaignStatusLookup; }
        }
        private BaseReferenceList _AsCampaignStatusLookup = new BaseReferenceList("rftCampaignStatus");
            
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
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
            
                case _str_AsCampaignType:
                    return new BvSelectList(AsCampaignTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AsCampaignType, _str_idfsCampaignType);
            
                case _str_AsCampaignStatus:
                    return new BvSelectList(AsCampaignStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AsCampaignStatus, _str_idfsCampaignStatus);
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_idfsDiagnosis)]
        public long? idfsDiagnosis
        {
            get { return m_idfsDiagnosis; }
            set { if (m_idfsDiagnosis != value) { m_idfsDiagnosis = value; OnPropertyChanged(_str_idfsDiagnosis); } }
        }
        private long? m_idfsDiagnosis;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AsCampaignListItem";

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
            var ret = base.Clone() as AsCampaignListItem;
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
            var ret = base.Clone() as AsCampaignListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AsCampaignListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsCampaignListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfCampaign; } }
        public string KeyName { get { return "idfCampaign"; } }
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
        
            var _prev_idfsCampaignType_AsCampaignType = idfsCampaignType;
            var _prev_idfsCampaignStatus_AsCampaignStatus = idfsCampaignStatus;
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            base.RejectChanges();
        
            if (_prev_idfsCampaignType_AsCampaignType != idfsCampaignType)
            {
                _AsCampaignType = _AsCampaignTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCampaignType);
            }
            if (_prev_idfsCampaignStatus_AsCampaignStatus != idfsCampaignStatus)
            {
                _AsCampaignStatus = _AsCampaignStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCampaignStatus);
            }
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
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

      private bool IsRIRPropChanged(string fld, AsCampaignListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public AsCampaignListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsCampaignListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsCampaignListItem_PropertyChanged);
        }
        private void AsCampaignListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsCampaignListItem).Changed(e.PropertyName);
            
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
            AsCampaignListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsCampaignListItem obj = this;
            
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


        public Dictionary<string, Func<AsCampaignListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsCampaignListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsCampaignListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<AsCampaignListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsCampaignListItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<AsCampaignListItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AsCampaignListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftCampaignType", this);
                
                LookupManager.RemoveObject("rftCampaignStatus", this);
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftCampaignType")
                _getAccessor().LoadLookup_AsCampaignType(manager, this);
            
            if (lookup_object == "rftCampaignStatus")
                _getAccessor().LoadLookup_AsCampaignStatus(manager, this);
            
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
        
            }
        }
    
        #region Class for web grid
        public class AsCampaignListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfCampaign { get; set; }
        
            public String strCampaignID { get; set; }
        
            public String strCampaignName { get; set; }
        
            public String strCampaignType { get; set; }
        
            public String strCampaignStatus { get; set; }
        
            public DateTime? datCampaignDateStart { get; set; }
        
            public DateTime? datCampaignDateEnd { get; set; }
        
            public String strCampaignAdministrator { get; set; }
        
        }
        public partial class AsCampaignListItemGridModelList : List<AsCampaignListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public AsCampaignListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsCampaignListItem>, errMes);
            }
            public AsCampaignListItemGridModelList(long key, IEnumerable<AsCampaignListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<AsCampaignListItem> items);
            private void LoadGridModelList(long key, IEnumerable<AsCampaignListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strCampaignID,_str_strCampaignName,_str_strCampaignType,_str_strCampaignStatus,_str_datCampaignDateStart,_str_datCampaignDateEnd,_str_strCampaignAdministrator};
                    
                Hiddens = new List<string> {_str_idfCampaign};
                Keys = new List<string> {_str_idfCampaign};
                Labels = new Dictionary<string, string> {{_str_strCampaignID, _str_strCampaignID},{_str_strCampaignName, _str_strCampaignName},{_str_strCampaignType, _str_strCampaignType},{_str_strCampaignStatus, _str_strCampaignStatus},{_str_datCampaignDateStart, "datStartDate"},{_str_datCampaignDateEnd, "datFinishDate"},{_str_strCampaignAdministrator, "strASAdministrator"}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strCampaignID, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "ActionEditAsCampaign")}};
                var list = new List<AsCampaignListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AsCampaignListItemGridModel()
                {
                    ItemKey=c.idfCampaign,strCampaignID=c.strCampaignID,strCampaignName=c.strCampaignName,strCampaignType=c.strCampaignType,strCampaignStatus=c.strCampaignStatus,datCampaignDateStart=c.datCampaignDateStart,datCampaignDateEnd=c.datCampaignDateEnd,strCampaignAdministrator=c.strCampaignAdministrator
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
        : DataAccessor<AsCampaignListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
            private delegate void on_action(AsCampaignListItem obj);
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
            private BaseReference.Accessor AsCampaignTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AsCampaignStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<AsCampaignListItem> SelectListT(DbManagerProxy manager
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
            
            private List<AsCampaignListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_AsCampaign_SelectList.* from dbo.fn_AsCampaign_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("idfsDiagnosis"))
                {
                    
                    sql.Append(" " + @"
            LEFT JOIN( select distinct d1.idfCampaign, d1.idfsDiagnosis from tlbCampaignToDiagnosis d1
            where d1.intRowStatus = 0) as d
            ON			fn_AsCampaign_SelectList.idfCampaign = d.idfCampaign
          ");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfsDiagnosis"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("idfsDiagnosis") == 1)
                    {
                        sql.AppendFormat("d.idfsDiagnosis {0} @idfsDiagnosis", filters.Operation("idfsDiagnosis"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("idfsDiagnosis") ? " or " : " and ");
                            sql.AppendFormat("d.idfsDiagnosis {0} @idfsDiagnosis_{1}", filters.Operation("idfsDiagnosis", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfCampaign"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfCampaign"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfCampaign") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_AsCampaign_SelectList.idfCampaign,0) {0} @idfCampaign_{1}", filters.Operation("idfCampaign", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCampaignType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCampaignType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCampaignType") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AsCampaign_SelectList.strCampaignType {0} @strCampaignType_{1}", filters.Operation("strCampaignType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCampaignType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCampaignType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCampaignType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_AsCampaign_SelectList.idfsCampaignType,0) {0} @idfsCampaignType_{1}", filters.Operation("idfsCampaignType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCampaignStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCampaignStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCampaignStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AsCampaign_SelectList.strCampaignStatus {0} @strCampaignStatus_{1}", filters.Operation("strCampaignStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsCampaignStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsCampaignStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsCampaignStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_AsCampaign_SelectList.idfsCampaignStatus,0) {0} @idfsCampaignStatus_{1}", filters.Operation("idfsCampaignStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datCampaignDateStart"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datCampaignDateStart"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datCampaignDateStart") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_AsCampaign_SelectList.datCampaignDateStart, 112) {0} CONVERT(NVARCHAR(8), @datCampaignDateStart_{1}, 112)", filters.Operation("datCampaignDateStart", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datCampaignDateEnd"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datCampaignDateEnd"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datCampaignDateEnd") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_AsCampaign_SelectList.datCampaignDateEnd, 112) {0} CONVERT(NVARCHAR(8), @datCampaignDateEnd_{1}, 112)", filters.Operation("datCampaignDateEnd", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCampaignID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCampaignID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCampaignID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AsCampaign_SelectList.strCampaignID {0} @strCampaignID_{1}", filters.Operation("strCampaignID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCampaignName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCampaignName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCampaignName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AsCampaign_SelectList.strCampaignName {0} @strCampaignName_{1}", filters.Operation("strCampaignName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCampaignAdministrator"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCampaignAdministrator"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCampaignAdministrator") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_AsCampaign_SelectList.strCampaignAdministrator {0} @strCampaignAdministrator_{1}", filters.Operation("strCampaignAdministrator", i), i);
                            
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
                    
                    if (filters.Contains("idfsDiagnosis"))
                        
                        if (filters.Count("idfsDiagnosis") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosis", ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosis"), filters.Value("idfsDiagnosis"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsDiagnosis"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosis_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosis", i), filters.Value("idfsDiagnosis", i))));
                        }
                            
                    if (filters.Contains("idfCampaign"))
                        for (int i = 0; i < filters.Count("idfCampaign"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfCampaign_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfCampaign", i), filters.Value("idfCampaign", i))));
                      
                    if (filters.Contains("strCampaignType"))
                        for (int i = 0; i < filters.Count("strCampaignType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCampaignType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCampaignType", i), filters.Value("strCampaignType", i))));
                      
                    if (filters.Contains("idfsCampaignType"))
                        for (int i = 0; i < filters.Count("idfsCampaignType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCampaignType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCampaignType", i), filters.Value("idfsCampaignType", i))));
                      
                    if (filters.Contains("strCampaignStatus"))
                        for (int i = 0; i < filters.Count("strCampaignStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCampaignStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCampaignStatus", i), filters.Value("strCampaignStatus", i))));
                      
                    if (filters.Contains("idfsCampaignStatus"))
                        for (int i = 0; i < filters.Count("idfsCampaignStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsCampaignStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsCampaignStatus", i), filters.Value("idfsCampaignStatus", i))));
                      
                    if (filters.Contains("datCampaignDateStart"))
                        for (int i = 0; i < filters.Count("datCampaignDateStart"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datCampaignDateStart_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datCampaignDateStart", i), filters.Value("datCampaignDateStart", i))));
                      
                    if (filters.Contains("datCampaignDateEnd"))
                        for (int i = 0; i < filters.Count("datCampaignDateEnd"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datCampaignDateEnd_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datCampaignDateEnd", i), filters.Value("datCampaignDateEnd", i))));
                      
                    if (filters.Contains("strCampaignID"))
                        for (int i = 0; i < filters.Count("strCampaignID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCampaignID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCampaignID", i), filters.Value("strCampaignID", i))));
                      
                    if (filters.Contains("strCampaignName"))
                        for (int i = 0; i < filters.Count("strCampaignName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCampaignName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCampaignName", i), filters.Value("strCampaignName", i))));
                      
                    if (filters.Contains("strCampaignAdministrator"))
                        for (int i = 0; i < filters.Count("strCampaignAdministrator"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCampaignAdministrator_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCampaignAdministrator", i), filters.Value("strCampaignAdministrator", i))));
                      
                    List<AsCampaignListItem> objs = manager.ExecuteList<AsCampaignListItem>();
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
        
            [SprocName("spASCampaign_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsCampaignListItem obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AsCampaignListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AsCampaignListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    AsCampaignListItem obj = AsCampaignListItem.CreateInstance();
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

            
            public AsCampaignListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public AsCampaignListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ActionEditAsCampaign(DbManagerProxy manager, AsCampaignListItem obj, List<object> pars)
            {
                
                return ActionEditAsCampaign(manager, obj
                    );
            }
            public ActResult ActionEditAsCampaign(DbManagerProxy manager, AsCampaignListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ActionEditAsCampaign"))
                    throw new PermissionException("Campaign", "ActionEditAsCampaign");
                
                return true;
                
            }
            
            private void _SetupChildHandlers(AsCampaignListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AsCampaignListItem obj)
            {
                
            }
    
            public void LoadLookup_AsCampaignType(DbManagerProxy manager, AsCampaignListItem obj)
            {
                
                obj.AsCampaignTypeLookup.Clear();
                
                obj.AsCampaignTypeLookup.Add(AsCampaignTypeAccessor.CreateNewT(manager, null));
                
                obj.AsCampaignTypeLookup.AddRange(AsCampaignTypeAccessor.rftCampaignType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCampaignType))
                    
                    .ToList());
                
                if (obj.idfsCampaignType != null && obj.idfsCampaignType != 0)
                {
                    obj.AsCampaignType = obj.AsCampaignTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsCampaignType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCampaignType", obj, AsCampaignTypeAccessor.GetType(), "rftCampaignType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_AsCampaignStatus(DbManagerProxy manager, AsCampaignListItem obj)
            {
                
                obj.AsCampaignStatusLookup.Clear();
                
                obj.AsCampaignStatusLookup.Add(AsCampaignStatusAccessor.CreateNewT(manager, null));
                
                obj.AsCampaignStatusLookup.AddRange(AsCampaignStatusAccessor.rftCampaignStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCampaignStatus))
                    
                    .ToList());
                
                if (obj.idfsCampaignStatus != null && obj.idfsCampaignStatus != 0)
                {
                    obj.AsCampaignStatus = obj.AsCampaignStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsCampaignStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCampaignStatus", obj, AsCampaignStatusAccessor.GetType(), "rftCampaignStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Diagnosis(DbManagerProxy manager, AsCampaignListItem obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Livestock) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
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
            

            private void _LoadLookups(DbManagerProxy manager, AsCampaignListItem obj)
            {
                
                LoadLookup_AsCampaignType(manager, obj);
                
                LoadLookup_AsCampaignStatus(manager, obj);
                
                LoadLookup_Diagnosis(manager, obj);
                
            }
    
            [SprocName("spAsCampaign_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spAsCampaign_Delete")]
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
                    AsCampaignListItem bo = obj as AsCampaignListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("Campaign", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("Campaign", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("Campaign", "Update");
                    }
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfCampaign;
                        
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoCampaign;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbCampaign;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as AsCampaignListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsCampaignListItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfCampaign
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
            
            public bool ValidateCanDelete(AsCampaignListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AsCampaignListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfCampaign
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
                return Validate(manager, obj as AsCampaignListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsCampaignListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Campaign.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Campaign.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Campaign.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Campaign.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(AsCampaignListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(AsCampaignListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsCampaignListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsCampaignListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsCampaignListItemDetail"; } }
            public string HelpIdWin { get { return "AS_campaigns_list"; } }
            public string HelpIdWeb { get { return "web_as_campaigns_list"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private AsCampaignListItem m_obj;
            internal Permissions(AsCampaignListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Campaign.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Campaign.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Campaign.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Campaign.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_AsCampaign_SelectList";
            public static string spCount = "spASCampaign_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spAsCampaign_Delete";
            public static string spCanDelete = "spAsCampaign_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsCampaignListItem, bool>> RequiredByField = new Dictionary<string, Func<AsCampaignListItem, bool>>();
            public static Dictionary<string, Func<AsCampaignListItem, bool>> RequiredByProperty = new Dictionary<string, Func<AsCampaignListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strCampaignType, 2000);
                Sizes.Add(_str_strCampaignStatus, 2000);
                Sizes.Add(_str_strCampaignID, 50);
                Sizes.Add(_str_strCampaignName, 200);
                Sizes.Add(_str_strCampaignAdministrator, 200);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCampaignID",
                    EditorType.Text,
                    false, false, 
                    "strCampaignID",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCampaignName",
                    EditorType.Text,
                    false, false, 
                    "strCampaignName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCampaignType",
                    EditorType.Lookup,
                    false, false, 
                    "strCampaignType",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "AsCampaignTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsCampaignStatus",
                    EditorType.Lookup,
                    false, false, 
                    "strCampaignStatus",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "AsCampaignStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosis",
                    EditorType.Lookup,
                    false, false, 
                    "AsCampaignListItem.idfsDiagnosis",
                    null, null, false, false, SearchPanelLocation.Main, true, null, "DiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strCampaignAdministrator",
                    EditorType.Text,
                    false, false, 
                    "strCampaignAdministrator",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datCampaignDateStart",
                    EditorType.Date,
                    true, true, 
                    "datStartDate",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datCampaignDateEnd",
                    EditorType.Date,
                    true, false, 
                    "datFinishDate",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfCampaign,
                    _str_idfCampaign, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCampaignID,
                    _str_strCampaignID, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCampaignName,
                    _str_strCampaignName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCampaignType,
                    _str_strCampaignType, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCampaignStatus,
                    _str_strCampaignStatus, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datCampaignDateStart,
                    "datStartDate", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datCampaignDateEnd,
                    "datFinishDate", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCampaignAdministrator,
                    "strASAdministrator", null, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "ActionEditAsCampaign",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionEditAsCampaign(manager, (AsCampaignListItem)c, pars),
                        
                    null,
                    
                    null,
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<AsCampaign>().CreateNew(manager, null, pars == null ? null : (int?)pars[0])),
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<AsCampaign>().SelectDetail(manager, pars[0])),
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
                                c = ObjectAccessor.CreatorInterface<AsCampaignListItem>().CreateWithParams(manager, null, pars);
                                ((AsCampaignListItem)c).idfCampaign = (long)pars[0];
                                ((AsCampaignListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((AsCampaignListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<AsCampaignListItem>().Post(manager, (AsCampaignListItem)c), c);
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	