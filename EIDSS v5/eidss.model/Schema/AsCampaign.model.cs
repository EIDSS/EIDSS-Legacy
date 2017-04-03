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
    public abstract partial class AsCampaign : 
        EditableObject<AsCampaign>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCampaign), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCampaign { get; set; }
                
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
                
        [LocalizedDisplayName(_str_datCampaignDateStart)]
        [MapField(_str_datCampaignDateStart)]
        public abstract DateTime? datCampaignDateStart { get; set; }
        #if MONO
        protected DateTime? datCampaignDateStart_Original { get { return datCampaignDateStart; } }
        protected DateTime? datCampaignDateStart_Previous { get { return datCampaignDateStart; } }
        #else
        protected DateTime? datCampaignDateStart_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateStart).OriginalValue; } }
        protected DateTime? datCampaignDateStart_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datCampaignDateStart).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datCampaignDateEnd)]
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
                
        [LocalizedDisplayName(_str_strCampaignAdministrator)]
        [MapField(_str_strCampaignAdministrator)]
        public abstract String strCampaignAdministrator { get; set; }
        #if MONO
        protected String strCampaignAdministrator_Original { get { return strCampaignAdministrator; } }
        protected String strCampaignAdministrator_Previous { get { return strCampaignAdministrator; } }
        #else
        protected String strCampaignAdministrator_Original { get { return ((EditableValue<String>)((dynamic)this)._strCampaignAdministrator).OriginalValue; } }
        protected String strCampaignAdministrator_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCampaignAdministrator).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("AsCampaign.strComments")]
        [MapField(_str_strComments)]
        public abstract String strComments { get; set; }
        #if MONO
        protected String strComments_Original { get { return strComments; } }
        protected String strComments_Previous { get { return strComments; } }
        #else
        protected String strComments_Original { get { return ((EditableValue<String>)((dynamic)this)._strComments).OriginalValue; } }
        protected String strComments_Previous { get { return ((EditableValue<String>)((dynamic)this)._strComments).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strConclusion)]
        [MapField(_str_strConclusion)]
        public abstract String strConclusion { get; set; }
        #if MONO
        protected String strConclusion_Original { get { return strConclusion; } }
        protected String strConclusion_Previous { get { return strConclusion; } }
        #else
        protected String strConclusion_Original { get { return ((EditableValue<String>)((dynamic)this)._strConclusion).OriginalValue; } }
        protected String strConclusion_Previous { get { return ((EditableValue<String>)((dynamic)this)._strConclusion).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<AsCampaign, object> _get_func;
            internal Action<AsCampaign, string> _set_func;
            internal Action<AsCampaign, AsCampaign, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCampaign = "idfCampaign";
        internal const string _str_idfsCampaignType = "idfsCampaignType";
        internal const string _str_idfsCampaignStatus = "idfsCampaignStatus";
        internal const string _str_datCampaignDateStart = "datCampaignDateStart";
        internal const string _str_datCampaignDateEnd = "datCampaignDateEnd";
        internal const string _str_strCampaignID = "strCampaignID";
        internal const string _str_strCampaignName = "strCampaignName";
        internal const string _str_strCampaignAdministrator = "strCampaignAdministrator";
        internal const string _str_strComments = "strComments";
        internal const string _str_strConclusion = "strConclusion";
        internal const string _str_CampaignStatus = "CampaignStatus";
        internal const string _str_CampaignType = "CampaignType";
        internal const string _str_Diseases = "Diseases";
        internal const string _str_Sessions = "Sessions";
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
              _name = _str_idfsCampaignType, _type = "Int64?",
              _get_func = o => o.idfsCampaignType,
              _set_func = (o, val) => { o.idfsCampaignType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsCampaignType != c.idfsCampaignType || o.IsRIRPropChanged(_str_idfsCampaignType, c)) 
                  m.Add(_str_idfsCampaignType, o.ObjectIdent + _str_idfsCampaignType, "Int64?", o.idfsCampaignType == null ? "" : o.idfsCampaignType.ToString(), o.IsReadOnly(_str_idfsCampaignType), o.IsInvisible(_str_idfsCampaignType), o.IsRequired(_str_idfsCampaignType)); }
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
              _name = _str_strComments, _type = "String",
              _get_func = o => o.strComments,
              _set_func = (o, val) => { o.strComments = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strComments != c.strComments || o.IsRIRPropChanged(_str_strComments, c)) 
                  m.Add(_str_strComments, o.ObjectIdent + _str_strComments, "String", o.strComments == null ? "" : o.strComments.ToString(), o.IsReadOnly(_str_strComments), o.IsInvisible(_str_strComments), o.IsRequired(_str_strComments)); }
              }, 
        
            new field_info {
              _name = _str_strConclusion, _type = "String",
              _get_func = o => o.strConclusion,
              _set_func = (o, val) => { o.strConclusion = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strConclusion != c.strConclusion || o.IsRIRPropChanged(_str_strConclusion, c)) 
                  m.Add(_str_strConclusion, o.ObjectIdent + _str_strConclusion, "String", o.strConclusion == null ? "" : o.strConclusion.ToString(), o.IsReadOnly(_str_strConclusion), o.IsInvisible(_str_strConclusion), o.IsRequired(_str_strConclusion)); }
              }, 
        
            new field_info {
              _name = _str_CampaignStatus, _type = "Lookup",
              _get_func = o => { if (o.CampaignStatus == null) return null; return o.CampaignStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.CampaignStatus = o.CampaignStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCampaignStatus != c.idfsCampaignStatus || o.IsRIRPropChanged(_str_CampaignStatus, c)) 
                  m.Add(_str_CampaignStatus, o.ObjectIdent + _str_CampaignStatus, "Lookup", o.idfsCampaignStatus == null ? "" : o.idfsCampaignStatus.ToString(), o.IsReadOnly(_str_CampaignStatus), o.IsInvisible(_str_CampaignStatus), o.IsRequired(_str_CampaignStatus)); }
              }, 
        
            new field_info {
              _name = _str_CampaignType, _type = "Lookup",
              _get_func = o => { if (o.CampaignType == null) return null; return o.CampaignType.idfsBaseReference; },
              _set_func = (o, val) => { o.CampaignType = o.CampaignTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsCampaignType != c.idfsCampaignType || o.IsRIRPropChanged(_str_CampaignType, c)) 
                  m.Add(_str_CampaignType, o.ObjectIdent + _str_CampaignType, "Lookup", o.idfsCampaignType == null ? "" : o.idfsCampaignType.ToString(), o.IsReadOnly(_str_CampaignType), o.IsInvisible(_str_CampaignType), o.IsRequired(_str_CampaignType)); }
              }, 
        
            new field_info {
              _name = _str_Diseases, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Diseases.Count != c.Diseases.Count || o.IsReadOnly(_str_Diseases) != c.IsReadOnly(_str_Diseases) || o.IsInvisible(_str_Diseases) != c.IsInvisible(_str_Diseases) || o.IsRequired(_str_Diseases) != c.IsRequired(_str_Diseases)) 
                  m.Add(_str_Diseases, o.ObjectIdent + _str_Diseases, "Child", o.idfCampaign == null ? "" : o.idfCampaign.ToString(), o.IsReadOnly(_str_Diseases), o.IsInvisible(_str_Diseases), o.IsRequired(_str_Diseases)); }
              }, 
        
            new field_info {
              _name = _str_Sessions, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.Sessions.Count != c.Sessions.Count || o.IsReadOnly(_str_Sessions) != c.IsReadOnly(_str_Sessions) || o.IsInvisible(_str_Sessions) != c.IsInvisible(_str_Sessions) || o.IsRequired(_str_Sessions) != c.IsRequired(_str_Sessions)) 
                  m.Add(_str_Sessions, o.ObjectIdent + _str_Sessions, "Child", o.idfCampaign == null ? "" : o.idfCampaign.ToString(), o.IsReadOnly(_str_Sessions), o.IsInvisible(_str_Sessions), o.IsRequired(_str_Sessions)); }
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
            AsCampaign obj = (AsCampaign)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(AsDisease), eidss.model.Schema.AsDisease._str_idfCampaign, _str_idfCampaign)]
        public EditableList<AsDisease> Diseases
        {
            get 
            {   
                return _Diseases; 
            }
            set 
            {
                _Diseases = value;
            }
        }
        protected EditableList<AsDisease> _Diseases = new EditableList<AsDisease>();
                    
        [Relation(typeof(AsMonitoringSession), eidss.model.Schema.AsMonitoringSession._str_idfCampaign, _str_idfCampaign)]
        public EditableList<AsMonitoringSession> Sessions
        {
            get 
            {   
                return _Sessions; 
            }
            set 
            {
                _Sessions = value;
            }
        }
        protected EditableList<AsMonitoringSession> _Sessions = new EditableList<AsMonitoringSession>();
                    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCampaignStatus)]
        public BaseReference CampaignStatus
        {
            get { return _CampaignStatus; }
            set 
            { 
                _CampaignStatus = value;
                idfsCampaignStatus = _CampaignStatus == null 
                    ? new Int64?()
                    : _CampaignStatus.idfsBaseReference; 
                OnPropertyChanged(_str_CampaignStatus); 
            }
        }
        private BaseReference _CampaignStatus;

        
        public BaseReferenceList CampaignStatusLookup
        {
            get { return _CampaignStatusLookup; }
        }
        private BaseReferenceList _CampaignStatusLookup = new BaseReferenceList("rftCampaignStatus");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsCampaignType)]
        public BaseReference CampaignType
        {
            get { return _CampaignType == null ? null : ((long)_CampaignType.Key == 0 ? null : _CampaignType); }
            set 
            { 
                _CampaignType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsCampaignType = _CampaignType == null 
                    ? new Int64?()
                    : _CampaignType.idfsBaseReference; 
                OnPropertyChanged(_str_CampaignType); 
            }
        }
        private BaseReference _CampaignType;

        
        public BaseReferenceList CampaignTypeLookup
        {
            get { return _CampaignTypeLookup; }
        }
        private BaseReferenceList _CampaignTypeLookup = new BaseReferenceList("rftCampaignType");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_CampaignStatus:
                    return new BvSelectList(CampaignStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CampaignStatus, _str_idfsCampaignStatus);
            
                case _str_CampaignType:
                    return new BvSelectList(CampaignTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, CampaignType, _str_idfsCampaignType);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AsCampaign";

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
        Diseases.ForEach(c => { c.Parent = this; });
                Sessions.ForEach(c => { c.Parent = this; });
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as AsCampaign;
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
            var ret = base.Clone() as AsCampaign;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AsCampaign CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsCampaign;
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
        
                    || Diseases.IsDirty
                    || Diseases.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Sessions.IsDirty
                    || Sessions.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsCampaignStatus_CampaignStatus = idfsCampaignStatus;
            var _prev_idfsCampaignType_CampaignType = idfsCampaignType;
            base.RejectChanges();
        
            if (_prev_idfsCampaignStatus_CampaignStatus != idfsCampaignStatus)
            {
                _CampaignStatus = _CampaignStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCampaignStatus);
            }
            if (_prev_idfsCampaignType_CampaignType != idfsCampaignType)
            {
                _CampaignType = _CampaignTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsCampaignType);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        Diseases.RejectChanges();
                Sessions.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        Diseases.AcceptChanges();
                Sessions.AcceptChanges();
                
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
        Diseases.ForEach(c => c.SetChange());
                Sessions.ForEach(c => c.SetChange());
                
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

      private bool IsRIRPropChanged(string fld, AsCampaign c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public AsCampaign()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsCampaign_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsCampaign_PropertyChanged);
        }
        private void AsCampaign_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsCampaign).Changed(e.PropertyName);
            
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
            AsCampaign obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsCampaign obj = this;
            
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

    
        private static string[] readonly_names1 = "strCampaignID".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "idfsCampaignStatus,CampaignStatus".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsCampaign, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsCampaign, bool>(c => false)(this);
            
            return ReadOnly || new Func<AsCampaign, bool>(c => c.idfsCampaignStatus == (long)AsCampaignStatus.Closed)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _Diseases)
                    o.ReadOnly = value;
                
                foreach(var o in _Sessions)
                    o.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<AsCampaign, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsCampaign, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsCampaign, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<AsCampaign, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsCampaign, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<AsCampaign, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AsCampaign()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftCampaignStatus", this);
                
                LookupManager.RemoveObject("rftCampaignType", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftCampaignStatus")
                _getAccessor().LoadLookup_CampaignStatus(manager, this);
            
            if (lookup_object == "rftCampaignType")
                _getAccessor().LoadLookup_CampaignType(manager, this);
            
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
        
            if (_Diseases != null) _Diseases.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Sessions != null) _Sessions.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<AsCampaign>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(AsCampaign obj);
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
            private AsDisease.Accessor DiseasesAccessor { get { return eidss.model.Schema.AsDisease.Accessor.Instance(m_CS); } }
            private AsMonitoringSession.Accessor SessionsAccessor { get { return eidss.model.Schema.AsMonitoringSession.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CampaignStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor CampaignTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual AsCampaign SelectByKey(DbManagerProxy manager
                , Int64? idfCampaign
                )
            {
                return _SelectByKey(manager
                    , idfCampaign
                    , null, null
                    );
            }
            
      
            private AsCampaign _SelectByKey(DbManagerProxy manager
                , Int64? idfCampaign
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[3];
                List<AsCampaign> objs = new List<AsCampaign>();
                sets[0] = new MapResultSet(typeof(AsCampaign), objs);
                
                List<AsDisease> objs_AsDisease = new List<AsDisease>();
                sets[1] = new MapResultSet(typeof(AsDisease), objs_AsDisease);
                
                List<AsMonitoringSession> objs_AsMonitoringSession = new List<AsMonitoringSession>();
                sets[2] = new MapResultSet(typeof(AsMonitoringSession), objs_AsMonitoringSession);
                
        
                try
                {
                    manager
                        .SetSpCommand("spASCampaign_SelectDetail"
                            , manager.Parameter("@idfCampaign", idfCampaign)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    AsCampaign obj = objs[0];
                    obj.m_CS = m_CS;
                    
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    
                    obj.Diseases.ForEach(c => DiseasesAccessor._SetupLoad(manager, c));
                        
                    obj.Sessions.ForEach(c => SessionsAccessor._SetupLoad(manager, c));
                        
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
    
            private void _SetupAddChildHandlerDiseases(AsCampaign obj)
            {
                obj.Diseases.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            private void _SetupAddChildHandlerSessions(AsCampaign obj)
            {
                obj.Sessions.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsCampaign obj)
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
                
                _SetupAddChildHandlerDiseases(obj);
                
                _SetupAddChildHandlerSessions(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, AsCampaign obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.Diseases.ForEach(c => DiseasesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Sessions.ForEach(c => SessionsAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private AsCampaign _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    AsCampaign obj = AsCampaign.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfCampaign = (new GetNewIDExtender<AsCampaign>()).GetScalar(manager, obj);
                obj.strCampaignID = new Func<AsCampaign, string>(c=>"(new campaign)")(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerDiseases(obj);
                    
                    _SetupAddChildHandlerSessions(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.CampaignStatus = (new SelectLookupExtender<BaseReference>()).Select(obj.CampaignStatusLookup, c => c.idfsBaseReference == (long)AsCampaignStatus.New);
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

            
            public AsCampaign CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public AsCampaign CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(AsCampaign obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AsCampaign obj)
            {
                
                obj.Diseases.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    if (e.ListChangedType == ListChangedType.ItemAdded)
                    {
                        try
                        {
                            var item = obj.Diseases[e.NewIndex];
                      
                (new PredicateValidator("", "Diseases", "Diseases", "Diseases",
              new object[] {
              },
                        false
                    )).Validate(obj, item, (c,i) => NewDiseaseValidation(c,i)
                    );
            
                        }
                        catch (ValidationModelException ex)
                        {
                            if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                            {
                                obj.Diseases.RemoveAt(e.NewIndex);
                                obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                            }
                        }
                    }
                };
                    
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfsCampaignStatus)
                        {
                            try
                            {
                            
                (new PredicateValidator("AsCampaign_CantChangeStatusToNew", "idfsCampaignStatus", "CampaignStatus", "idfsCampaignStatus",
              new object[] {
              },
                        false
                    )).Validate(obj, c=>(c.idfsCampaignStatus == (long)AsCampaignStatus.New && c.Sessions.Count(s=>!s.IsMarkedToDelete) == 0) || c.idfsCampaignStatus != (long)AsCampaignStatus.New
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_idfsCampaignStatus);
                                    obj._CampaignStatus = obj.CampaignStatusLookup.Where(a => a.idfsBaseReference == obj.idfsCampaignStatus).SingleOrDefault();
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datCampaignDateStart)
                        {
                            try
                            {
                            
                (new PredicateValidator("datCampaignDateStart_datCampaignDateEnd_msgId", "datCampaignDateStart", "datCampaignDateStart", "datCampaignDateStart",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datCampaignDateStart, c.datCampaignDateEnd)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datCampaignDateStart);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_datCampaignDateEnd)
                        {
                            try
                            {
                            
                (new PredicateValidator("datCampaignDateStart_datCampaignDateEnd_msgId", "datCampaignDateEnd", "datCampaignDateEnd", "datCampaignDateEnd",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datCampaignDateStart, c.datCampaignDateEnd)
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_datCampaignDateEnd);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                    };
                
            }
    
            public void LoadLookup_CampaignStatus(DbManagerProxy manager, AsCampaign obj)
            {
                
                obj.CampaignStatusLookup.Clear();
                
                obj.CampaignStatusLookup.AddRange(CampaignStatusAccessor.rftCampaignStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCampaignStatus))
                    
                    .ToList());
                
                if (obj.idfsCampaignStatus != null && obj.idfsCampaignStatus != 0)
                {
                    obj.CampaignStatus = obj.CampaignStatusLookup
                        .Where(c => c.idfsBaseReference == obj.idfsCampaignStatus)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCampaignStatus", obj, CampaignStatusAccessor.GetType(), "rftCampaignStatus_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_CampaignType(DbManagerProxy manager, AsCampaign obj)
            {
                
                obj.CampaignTypeLookup.Clear();
                
                obj.CampaignTypeLookup.Add(CampaignTypeAccessor.CreateNewT(manager, null));
                
                obj.CampaignTypeLookup.AddRange(CampaignTypeAccessor.rftCampaignType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsCampaignType))
                    
                    .ToList());
                
                if (obj.idfsCampaignType != null && obj.idfsCampaignType != 0)
                {
                    obj.CampaignType = obj.CampaignTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsCampaignType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftCampaignType", obj, CampaignTypeAccessor.GetType(), "rftCampaignType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, AsCampaign obj)
            {
                
                LoadLookup_CampaignStatus(manager, obj);
                
                LoadLookup_CampaignType(manager, obj);
                
            }
    
            [SprocName("spAsCampaign_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spASCampaign_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfCampaign", "strCampaignID")] AsCampaign obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfCampaign", "strCampaignID")] AsCampaign obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AsCampaign bo = obj as AsCampaign;
                    
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
                    bSuccess = _PostNonTransaction(manager, obj as AsCampaign, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsCampaign obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                                        
                    _postPredicate(manager, 8, obj);
                                            
                    if (obj.Diseases != null)
                    {
                        foreach (var i in obj.Diseases)
                        {
                            i.MarkToDelete();
                            if (!DiseasesAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            
                    if (obj.Sessions != null)
                    {
                        foreach (var i in obj.Sessions)
                        {
                            i.MarkToDelete();
                            if (!SessionsAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                obj.strCampaignID = new Func<AsCampaign, DbManagerProxy, string>((c,m) => 
                        c.strCampaignID != "(new campaign)" 
                        ? c.strCampaignID 
                        : m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.ASCampaign, DBNull.Value, DBNull.Value)
                        .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue"))(obj, manager);
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                                    
                    if (obj.IsNew)
                    {
                        if (obj.Diseases != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Diseases)
                                if (!DiseasesAccessor.Post(manager, i, true))
                                    return false;
                            obj.Diseases.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Diseases.Remove(c));
                            obj.Diseases.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Diseases != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Diseases)
                                if (!DiseasesAccessor.Post(manager, i, true))
                                    return false;
                            obj._Diseases.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Diseases.Remove(c));
                            obj._Diseases.AcceptChanges();
                        }
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.Sessions != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Sessions)
                                if (!SessionsAccessor.Post(manager, i, true))
                                    return false;
                            obj.Sessions.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Sessions.Remove(c));
                            obj.Sessions.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Sessions != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Sessions)
                                if (!SessionsAccessor.Post(manager, i, true))
                                    return false;
                            obj._Sessions.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Sessions.Remove(c));
                            obj._Sessions.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AsCampaign obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AsCampaign obj)
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
                return Validate(manager, obj as AsCampaign, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsCampaign obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "strCampaignName", "strCampaignName","",
                false
              )).Validate(c => true, obj, obj.strCampaignName);
            
                (new RequiredValidator( "idfsCampaignType", "CampaignType","",
                false
              )).Validate(c => true, obj, obj.idfsCampaignType);
            
                (new RequiredValidator( "idfsCampaignStatus", "CampaignStatus","",
                false
              )).Validate(c => true, obj, obj.idfsCampaignStatus);
            
            (new CustomMandatoryFieldValidator("datCampaignDateStart", "datCampaignDateStart", "",
            false
            )).Validate(obj, obj.datCampaignDateStart, CustomMandatoryField.ASCampaign_StartDate);

          
            (new CustomMandatoryFieldValidator("datCampaignDateEnd", "datCampaignDateEnd", "",
            false
            )).Validate(obj, obj.datCampaignDateEnd, CustomMandatoryField.ASCampaign_EndDate);

          
                  
                    }

                    if (bChangeValidation)
                    {
                
                (new PredicateValidator("AsCampaign_CantChangeStatusToNew", "idfsCampaignStatus", "CampaignStatus", "idfsCampaignStatus",
              new object[] {
              },
                        false
                    )).Validate(obj, c=>(c.idfsCampaignStatus == (long)AsCampaignStatus.New && c.Sessions.Count(s=>!s.IsMarkedToDelete) == 0) || c.idfsCampaignStatus != (long)AsCampaignStatus.New
                    );
            
                (new PredicateValidator("datCampaignDateStart_datCampaignDateEnd_msgId", "datCampaignDateStart", "datCampaignDateStart", "datCampaignDateStart",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datCampaignDateStart, c.datCampaignDateEnd)
                    );
            
                (new PredicateValidator("datCampaignDateStart_datCampaignDateEnd_msgId", "datCampaignDateEnd", "datCampaignDateEnd", "datCampaignDateEnd",
              new object[] {
              },
                        false
                    )).Validate(obj, c => PredicateValidator.CompareDates(c.datCampaignDateStart, c.datCampaignDateEnd)
                    );
            
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.Diseases != null)
                            foreach (var i in obj.Diseases.Where(c => !c.IsMarkedToDelete))
                                DiseasesAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.Sessions != null)
                            foreach (var i in obj.Sessions.Where(c => !c.IsMarkedToDelete))
                                SessionsAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Campaign.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Campaign.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Campaign.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Campaign.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(AsCampaign obj)
            {
            
                obj
                    .AddRequired("strCampaignName", c => true);
                    
                obj
                    .AddRequired("CampaignType", c => true);
                    
                obj
                    .AddRequired("CampaignStatus", c => true);
                    
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.ASCampaign_StartDate))
              {
              
              obj
                  .AddRequired("datCampaignDateStart", c=>true);
                
                }
            
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.ASCampaign_EndDate))
              {
              
              obj
                  .AddRequired("datCampaignDateEnd", c=>true);
                
                }
            
            }
    
    private void _SetupPersonalDataRestrictions(AsCampaign obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsCampaign) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsCampaign) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsCampaignDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return "web_as_campaign_form"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private AsCampaign m_obj;
            internal Permissions(AsCampaign obj)
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
            public static string spSelect = "spASCampaign_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spASCampaign_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "spAsCampaign_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsCampaign, bool>> RequiredByField = new Dictionary<string, Func<AsCampaign, bool>>();
            public static Dictionary<string, Func<AsCampaign, bool>> RequiredByProperty = new Dictionary<string, Func<AsCampaign, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strCampaignID, 50);
                Sizes.Add(_str_strCampaignName, 200);
                Sizes.Add(_str_strCampaignAdministrator, 200);
                Sizes.Add(_str_strComments, 500);
                Sizes.Add(_str_strConclusion, 2147483647);
                if (!RequiredByField.ContainsKey("strCampaignName")) RequiredByField.Add("strCampaignName", c => true);
                if (!RequiredByProperty.ContainsKey("strCampaignName")) RequiredByProperty.Add("strCampaignName", c => true);
                
                if (!RequiredByField.ContainsKey("idfsCampaignType")) RequiredByField.Add("idfsCampaignType", c => true);
                if (!RequiredByProperty.ContainsKey("CampaignType")) RequiredByProperty.Add("CampaignType", c => true);
                
                if (!RequiredByField.ContainsKey("idfsCampaignStatus")) RequiredByField.Add("idfsCampaignStatus", c => true);
                if (!RequiredByProperty.ContainsKey("CampaignStatus")) RequiredByProperty.Add("CampaignStatus", c => true);
                
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
                    (manager, c, pars) => new ActResult(((AsCampaign)c).MarkToDelete() && ObjectAccessor.PostInterface<AsCampaign>().Post(manager, (AsCampaign)c), c),
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
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AsCampaign>().Post(manager, (AsCampaign)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AsCampaign>().Post(manager, (AsCampaign)c), c),
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
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class AsDisease : 
        EditableObject<AsDisease>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCampaignToDiagnosis), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCampaignToDiagnosis { get; set; }
                
        [LocalizedDisplayName(_str_idfCampaign)]
        [MapField(_str_idfCampaign)]
        public abstract Int64 idfCampaign { get; set; }
        #if MONO
        protected Int64 idfCampaign_Original { get { return idfCampaign; } }
        protected Int64 idfCampaign_Previous { get { return idfCampaign; } }
        #else
        protected Int64 idfCampaign_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfCampaign).OriginalValue; } }
        protected Int64 idfCampaign_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfCampaign).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsDiagnosis)]
        [MapField(_str_idfsDiagnosis)]
        public abstract Int64 idfsDiagnosis { get; set; }
        #if MONO
        protected Int64 idfsDiagnosis_Original { get { return idfsDiagnosis; } }
        protected Int64 idfsDiagnosis_Previous { get { return idfsDiagnosis; } }
        #else
        protected Int64 idfsDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).OriginalValue; } }
        protected Int64 idfsDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsDiagnosis).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32 intOrder { get; set; }
        #if MONO
        protected Int32 intOrder_Original { get { return intOrder; } }
        protected Int32 intOrder_Previous { get { return intOrder; } }
        #else
        protected Int32 intOrder_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32 intOrder_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsSpeciesType)]
        [MapField(_str_idfsSpeciesType)]
        public abstract Int64? idfsSpeciesType { get; set; }
        #if MONO
        protected Int64? idfsSpeciesType_Original { get { return idfsSpeciesType; } }
        protected Int64? idfsSpeciesType_Previous { get { return idfsSpeciesType; } }
        #else
        protected Int64? idfsSpeciesType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).OriginalValue; } }
        protected Int64? idfsSpeciesType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSpeciesType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intPlannedNumber)]
        [MapField(_str_intPlannedNumber)]
        public abstract Int32? intPlannedNumber { get; set; }
        #if MONO
        protected Int32? intPlannedNumber_Original { get { return intPlannedNumber; } }
        protected Int32? intPlannedNumber_Previous { get { return intPlannedNumber; } }
        #else
        protected Int32? intPlannedNumber_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intPlannedNumber).OriginalValue; } }
        protected Int32? intPlannedNumber_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intPlannedNumber).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<AsDisease, object> _get_func;
            internal Action<AsDisease, string> _set_func;
            internal Action<AsDisease, AsDisease, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCampaignToDiagnosis = "idfCampaignToDiagnosis";
        internal const string _str_idfCampaign = "idfCampaign";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_idfsSpeciesType = "idfsSpeciesType";
        internal const string _str_intPlannedNumber = "intPlannedNumber";
        internal const string _str_strDiagnosis = "strDiagnosis";
        internal const string _str_strSpecies = "strSpecies";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_SpeciesType = "SpeciesType";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfCampaignToDiagnosis, _type = "Int64",
              _get_func = o => o.idfCampaignToDiagnosis,
              _set_func = (o, val) => { o.idfCampaignToDiagnosis = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCampaignToDiagnosis != c.idfCampaignToDiagnosis || o.IsRIRPropChanged(_str_idfCampaignToDiagnosis, c)) 
                  m.Add(_str_idfCampaignToDiagnosis, o.ObjectIdent + _str_idfCampaignToDiagnosis, "Int64", o.idfCampaignToDiagnosis == null ? "" : o.idfCampaignToDiagnosis.ToString(), o.IsReadOnly(_str_idfCampaignToDiagnosis), o.IsInvisible(_str_idfCampaignToDiagnosis), o.IsRequired(_str_idfCampaignToDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_idfCampaign, _type = "Int64",
              _get_func = o => o.idfCampaign,
              _set_func = (o, val) => { o.idfCampaign = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCampaign != c.idfCampaign || o.IsRIRPropChanged(_str_idfCampaign, c)) 
                  m.Add(_str_idfCampaign, o.ObjectIdent + _str_idfCampaign, "Int64", o.idfCampaign == null ? "" : o.idfCampaign.ToString(), o.IsReadOnly(_str_idfCampaign), o.IsInvisible(_str_idfCampaign), o.IsRequired(_str_idfCampaign)); }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosis, _type = "Int64",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { o.idfsDiagnosis = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) 
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, "Int64", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis)); }
              }, 
        
            new field_info {
              _name = _str_intOrder, _type = "Int32",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { o.intOrder = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, "Int32", o.intOrder == null ? "" : o.intOrder.ToString(), o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); }
              }, 
        
            new field_info {
              _name = _str_idfsSpeciesType, _type = "Int64?",
              _get_func = o => o.idfsSpeciesType,
              _set_func = (o, val) => { o.idfsSpeciesType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_idfsSpeciesType, c)) 
                  m.Add(_str_idfsSpeciesType, o.ObjectIdent + _str_idfsSpeciesType, "Int64?", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_idfsSpeciesType), o.IsInvisible(_str_idfsSpeciesType), o.IsRequired(_str_idfsSpeciesType)); }
              }, 
        
            new field_info {
              _name = _str_intPlannedNumber, _type = "Int32?",
              _get_func = o => o.intPlannedNumber,
              _set_func = (o, val) => { o.intPlannedNumber = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intPlannedNumber != c.intPlannedNumber || o.IsRIRPropChanged(_str_intPlannedNumber, c)) 
                  m.Add(_str_intPlannedNumber, o.ObjectIdent + _str_intPlannedNumber, "Int32?", o.intPlannedNumber == null ? "" : o.intPlannedNumber.ToString(), o.IsReadOnly(_str_intPlannedNumber), o.IsInvisible(_str_intPlannedNumber), o.IsRequired(_str_intPlannedNumber)); }
              }, 
        
            new field_info {
              _name = _str_strDiagnosis, _type = "string",
              _get_func = o => o.strDiagnosis,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strDiagnosis != c.strDiagnosis || o.IsRIRPropChanged(_str_strDiagnosis, c)) 
                  m.Add(_str_strDiagnosis, o.ObjectIdent + _str_strDiagnosis, "string", o.strDiagnosis == null ? "" : o.strDiagnosis.ToString(), o.IsReadOnly(_str_strDiagnosis), o.IsInvisible(_str_strDiagnosis), o.IsRequired(_str_strDiagnosis));
                 }
              }, 
        
            new field_info {
              _name = _str_strSpecies, _type = "string",
              _get_func = o => o.strSpecies,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strSpecies != c.strSpecies || o.IsRIRPropChanged(_str_strSpecies, c)) 
                  m.Add(_str_strSpecies, o.ObjectIdent + _str_strSpecies, "string", o.strSpecies == null ? "" : o.strSpecies.ToString(), o.IsReadOnly(_str_strSpecies), o.IsInvisible(_str_strSpecies), o.IsRequired(_str_strSpecies));
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
              _name = _str_SpeciesType, _type = "Lookup",
              _get_func = o => { if (o.SpeciesType == null) return null; return o.SpeciesType.idfsBaseReference; },
              _set_func = (o, val) => { o.SpeciesType = o.SpeciesTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesType != c.idfsSpeciesType || o.IsRIRPropChanged(_str_SpeciesType, c)) 
                  m.Add(_str_SpeciesType, o.ObjectIdent + _str_SpeciesType, "Lookup", o.idfsSpeciesType == null ? "" : o.idfsSpeciesType.ToString(), o.IsReadOnly(_str_SpeciesType), o.IsInvisible(_str_SpeciesType), o.IsRequired(_str_SpeciesType)); }
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
            AsDisease obj = (AsDisease)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsDiagnosis = _Diagnosis == null 
                    ? new Int64()
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
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSpeciesType)]
        public BaseReference SpeciesType
        {
            get { return _SpeciesType == null ? null : ((long)_SpeciesType.Key == 0 ? null : _SpeciesType); }
            set 
            { 
                _SpeciesType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSpeciesType = _SpeciesType == null 
                    ? new Int64?()
                    : _SpeciesType.idfsBaseReference; 
                OnPropertyChanged(_str_SpeciesType); 
            }
        }
        private BaseReference _SpeciesType;

        
        public BaseReferenceList SpeciesTypeLookup
        {
            get { return _SpeciesTypeLookup; }
        }
        private BaseReferenceList _SpeciesTypeLookup = new BaseReferenceList("rftSpeciesList");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_SpeciesType:
                    return new BvSelectList(SpeciesTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SpeciesType, _str_idfsSpeciesType);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strDiagnosis)]
        public string strDiagnosis
        {
            get { return new Func<AsDisease, string>(c=> c.Diagnosis == null ? "" : c.Diagnosis.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strSpecies)]
        public string strSpecies
        {
            get { return new Func<AsDisease, string>(c=>c.SpeciesType == null ? "" : c.SpeciesType.name)(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AsDisease";

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
            var ret = base.Clone() as AsDisease;
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
            var ret = base.Clone() as AsDisease;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AsDisease CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsDisease;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfCampaignToDiagnosis; } }
        public string KeyName { get { return "idfCampaignToDiagnosis"; } }
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
        
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            var _prev_idfsSpeciesType_SpeciesType = idfsSpeciesType;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
            if (_prev_idfsSpeciesType_SpeciesType != idfsSpeciesType)
            {
                _SpeciesType = _SpeciesTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSpeciesType);
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

      private bool IsRIRPropChanged(string fld, AsDisease c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public AsDisease()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsDisease_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsDisease_PropertyChanged);
        }
        private void AsDisease_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsDisease).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_idfsDiagnosis)
                OnPropertyChanged(_str_strDiagnosis);
                  
            if (e.PropertyName == _str_idfsSpeciesType)
                OnPropertyChanged(_str_strSpecies);
                  
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
            AsDisease obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsDisease obj = this;
            
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

    
        private static string[] readonly_names1 = "idfsSpeciesType,SpeciesType".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<AsDisease, bool>(c=>(c.idfsDiagnosis == 0))(this);
            
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


        public Dictionary<string, Func<AsDisease, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsDisease, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsDisease, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<AsDisease, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsDisease, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<AsDisease, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AsDisease()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftSpeciesList", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftSpeciesList")
                _getAccessor().LoadLookup_SpeciesType(manager, this);
            
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
        public class AsDiseaseGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public long idfCampaignToDiagnosis { get; set; }
        
            public string strDiagnosis { get; set; }
        
            public string strSpecies { get; set; }
        
            public int? intPlannedNumber { get; set; }
        
            public Int32 intOrder { get; set; }
        
        }
        public partial class AsDiseaseGridModelList : List<AsDiseaseGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public AsDiseaseGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsDisease>, errMes);
            }
            public AsDiseaseGridModelList(long key, IEnumerable<AsDisease> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<AsDisease> items);
            private void LoadGridModelList(long key, IEnumerable<AsDisease> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strDiagnosis,_str_strSpecies,_str_intPlannedNumber};
                    
                Hiddens = new List<string> {_str_idfCampaignToDiagnosis,_str_intOrder};
                Keys = new List<string> {_str_idfCampaignToDiagnosis};
                Labels = new Dictionary<string, string> {{_str_strDiagnosis, _str_strDiagnosis},{_str_strSpecies, _str_strSpecies},{_str_intPlannedNumber, _str_intPlannedNumber}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<AsDisease>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AsDiseaseGridModel()
                {
                    ItemKey=c.idfCampaignToDiagnosis,strDiagnosis=c.strDiagnosis,strSpecies=c.strSpecies,intPlannedNumber=c.intPlannedNumber,intOrder=c.intOrder
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
        : DataAccessor<AsDisease>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(AsDisease obj);
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
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor SpeciesTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual AsDisease SelectByKey(DbManagerProxy manager
                , Int64? idfCampaign
                )
            {
                return _SelectByKey(manager
                    , idfCampaign
                    , null, null
                    );
            }
            
      
            private AsDisease _SelectByKey(DbManagerProxy manager
                , Int64? idfCampaign
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsDisease obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AsDisease obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AsDisease _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    AsDisease obj = AsDisease.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfCampaignToDiagnosis = (new GetNewIDExtender<AsDisease>()).GetScalar(manager, obj);
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

            
            public AsDisease CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public AsDisease CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(AsDisease obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AsDisease obj)
            {
                
            }
    
            public void LoadLookup_Diagnosis(DbManagerProxy manager, AsDisease obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => ((c.intHACode & (int)HACode.Livestock) != 0) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsDiagnosis)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .Where(c => c.idfsDiagnosis == obj.idfsDiagnosis)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_SpeciesType(DbManagerProxy manager, AsDisease obj)
            {
                
                obj.SpeciesTypeLookup.Clear();
                
                obj.SpeciesTypeLookup.Add(SpeciesTypeAccessor.CreateNewT(manager, null));
                
                obj.SpeciesTypeLookup.AddRange(SpeciesTypeAccessor.rftSpeciesList_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode.GetValueOrDefault() & ((int?)HACode.Livestock).GetValueOrDefault()) != 0 || c.idfsBaseReference == obj.idfsSpeciesType)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSpeciesType))
                    
                    .ToList());
                
                if (obj.idfsSpeciesType != null && obj.idfsSpeciesType != 0)
                {
                    obj.SpeciesType = obj.SpeciesTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsSpeciesType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftSpeciesList", obj, SpeciesTypeAccessor.GetType(), "rftSpeciesList_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, AsDisease obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_SpeciesType(manager, obj);
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spASCampaignDiagnosis_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfCampaignToDiagnosis")] AsDisease obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("idfCampaignToDiagnosis")] AsDisease obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AsDisease bo = obj as AsDisease;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as AsDisease, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsDisease obj, bool bChildObject) 
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
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AsDisease obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AsDisease obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as AsDisease, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsDisease obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsDiagnosis", "idfsDiagnosis","idfsDiagnosis",
                false
              )).Validate(c => true, obj, obj.idfsDiagnosis);
            
                  
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
           
    
            private void _SetupRequired(AsDisease obj)
            {
            
                obj
                    .AddRequired("idfsDiagnosis", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(AsDisease obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsDisease) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsDisease) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsDiseaseDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spASCampaign_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spASCampaignDiagnosis_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsDisease, bool>> RequiredByField = new Dictionary<string, Func<AsDisease, bool>>();
            public static Dictionary<string, Func<AsDisease, bool>> RequiredByProperty = new Dictionary<string, Func<AsDisease, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                if (!RequiredByField.ContainsKey("idfsDiagnosis")) RequiredByField.Add("idfsDiagnosis", c => true);
                if (!RequiredByProperty.ContainsKey("idfsDiagnosis")) RequiredByProperty.Add("idfsDiagnosis", c => true);
                
                GridMeta.Add(new GridMetaItem(
                    _str_idfCampaignToDiagnosis,
                    _str_idfCampaignToDiagnosis, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosis,
                    _str_strDiagnosis, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpecies,
                    _str_strSpecies, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intPlannedNumber,
                    _str_intPlannedNumber, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intOrder,
                    _str_intOrder, null, false, true, null
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
                    (manager, c, pars) => new ActResult(((AsDisease)c).MarkToDelete() && ObjectAccessor.PostInterface<AsDisease>().Post(manager, (AsDisease)c), c),
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
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AsDisease>().Post(manager, (AsDisease)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AsDisease>().Post(manager, (AsDisease)c), c),
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
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class AsMonitoringSession : 
        EditableObject<AsMonitoringSession>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfMonitoringSession), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMonitoringSession { get; set; }
                
        [LocalizedDisplayName("AsSession.Status")]
        [MapField(_str_strStatus)]
        public abstract String strStatus { get; set; }
        #if MONO
        protected String strStatus_Original { get { return strStatus; } }
        protected String strStatus_Previous { get { return strStatus; } }
        #else
        protected String strStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._strStatus).OriginalValue; } }
        protected String strStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._strStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsRegion")]
        [MapField(_str_strRegion)]
        public abstract String strRegion { get; set; }
        #if MONO
        protected String strRegion_Original { get { return strRegion; } }
        protected String strRegion_Previous { get { return strRegion; } }
        #else
        protected String strRegion_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegion).OriginalValue; } }
        protected String strRegion_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegion).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("idfsRayon")]
        [MapField(_str_strRayon)]
        public abstract String strRayon { get; set; }
        #if MONO
        protected String strRayon_Original { get { return strRayon; } }
        protected String strRayon_Previous { get { return strRayon; } }
        #else
        protected String strRayon_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayon).OriginalValue; } }
        protected String strRayon_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayon).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("AsSession.strSettlement")]
        [MapField(_str_strSettlement)]
        public abstract String strSettlement { get; set; }
        #if MONO
        protected String strSettlement_Original { get { return strSettlement; } }
        protected String strSettlement_Previous { get { return strSettlement; } }
        #else
        protected String strSettlement_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).OriginalValue; } }
        protected String strSettlement_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlement).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datEnteredDate)]
        [MapField(_str_datEnteredDate)]
        public abstract DateTime? datEnteredDate { get; set; }
        #if MONO
        protected DateTime? datEnteredDate_Original { get { return datEnteredDate; } }
        protected DateTime? datEnteredDate_Previous { get { return datEnteredDate; } }
        #else
        protected DateTime? datEnteredDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).OriginalValue; } }
        protected DateTime? datEnteredDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strMonitoringSessionID)]
        [MapField(_str_strMonitoringSessionID)]
        public abstract String strMonitoringSessionID { get; set; }
        #if MONO
        protected String strMonitoringSessionID_Original { get { return strMonitoringSessionID; } }
        protected String strMonitoringSessionID_Previous { get { return strMonitoringSessionID; } }
        #else
        protected String strMonitoringSessionID_Original { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).OriginalValue; } }
        protected String strMonitoringSessionID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMonitoringSessionID).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("AsSession.datStartDate")]
        [MapField(_str_datStartDate)]
        public abstract DateTime? datStartDate { get; set; }
        #if MONO
        protected DateTime? datStartDate_Original { get { return datStartDate; } }
        protected DateTime? datStartDate_Previous { get { return datStartDate; } }
        #else
        protected DateTime? datStartDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime? datStartDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("AsSession.datEndDate")]
        [MapField(_str_datEndDate)]
        public abstract DateTime? datEndDate { get; set; }
        #if MONO
        protected DateTime? datEndDate_Original { get { return datEndDate; } }
        protected DateTime? datEndDate_Previous { get { return datEndDate; } }
        #else
        protected DateTime? datEndDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEndDate).OriginalValue; } }
        protected DateTime? datEndDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEndDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strDisease)]
        [MapField(_str_strDisease)]
        public abstract String strDisease { get; set; }
        #if MONO
        protected String strDisease_Original { get { return strDisease; } }
        protected String strDisease_Previous { get { return strDisease; } }
        #else
        protected String strDisease_Original { get { return ((EditableValue<String>)((dynamic)this)._strDisease).OriginalValue; } }
        protected String strDisease_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDisease).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfCampaign)]
        [MapField(_str_idfCampaign)]
        public abstract Int64? idfCampaign { get; set; }
        #if MONO
        protected Int64? idfCampaign_Original { get { return idfCampaign; } }
        protected Int64? idfCampaign_Previous { get { return idfCampaign; } }
        #else
        protected Int64? idfCampaign_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCampaign).OriginalValue; } }
        protected Int64? idfCampaign_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCampaign).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<AsMonitoringSession, object> _get_func;
            internal Action<AsMonitoringSession, string> _set_func;
            internal Action<AsMonitoringSession, AsMonitoringSession, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMonitoringSession = "idfMonitoringSession";
        internal const string _str_strStatus = "strStatus";
        internal const string _str_strRegion = "strRegion";
        internal const string _str_strRayon = "strRayon";
        internal const string _str_strSettlement = "strSettlement";
        internal const string _str_datEnteredDate = "datEnteredDate";
        internal const string _str_strMonitoringSessionID = "strMonitoringSessionID";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_datEndDate = "datEndDate";
        internal const string _str_strDisease = "strDisease";
        internal const string _str_idfCampaign = "idfCampaign";
        internal const string _str_FullSession = "FullSession";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfMonitoringSession, _type = "Int64",
              _get_func = o => o.idfMonitoringSession,
              _set_func = (o, val) => { o.idfMonitoringSession = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfMonitoringSession != c.idfMonitoringSession || o.IsRIRPropChanged(_str_idfMonitoringSession, c)) 
                  m.Add(_str_idfMonitoringSession, o.ObjectIdent + _str_idfMonitoringSession, "Int64", o.idfMonitoringSession == null ? "" : o.idfMonitoringSession.ToString(), o.IsReadOnly(_str_idfMonitoringSession), o.IsInvisible(_str_idfMonitoringSession), o.IsRequired(_str_idfMonitoringSession)); }
              }, 
        
            new field_info {
              _name = _str_strStatus, _type = "String",
              _get_func = o => o.strStatus,
              _set_func = (o, val) => { o.strStatus = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strStatus != c.strStatus || o.IsRIRPropChanged(_str_strStatus, c)) 
                  m.Add(_str_strStatus, o.ObjectIdent + _str_strStatus, "String", o.strStatus == null ? "" : o.strStatus.ToString(), o.IsReadOnly(_str_strStatus), o.IsInvisible(_str_strStatus), o.IsRequired(_str_strStatus)); }
              }, 
        
            new field_info {
              _name = _str_strRegion, _type = "String",
              _get_func = o => o.strRegion,
              _set_func = (o, val) => { o.strRegion = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strRegion != c.strRegion || o.IsRIRPropChanged(_str_strRegion, c)) 
                  m.Add(_str_strRegion, o.ObjectIdent + _str_strRegion, "String", o.strRegion == null ? "" : o.strRegion.ToString(), o.IsReadOnly(_str_strRegion), o.IsInvisible(_str_strRegion), o.IsRequired(_str_strRegion)); }
              }, 
        
            new field_info {
              _name = _str_strRayon, _type = "String",
              _get_func = o => o.strRayon,
              _set_func = (o, val) => { o.strRayon = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strRayon != c.strRayon || o.IsRIRPropChanged(_str_strRayon, c)) 
                  m.Add(_str_strRayon, o.ObjectIdent + _str_strRayon, "String", o.strRayon == null ? "" : o.strRayon.ToString(), o.IsReadOnly(_str_strRayon), o.IsInvisible(_str_strRayon), o.IsRequired(_str_strRayon)); }
              }, 
        
            new field_info {
              _name = _str_strSettlement, _type = "String",
              _get_func = o => o.strSettlement,
              _set_func = (o, val) => { o.strSettlement = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSettlement != c.strSettlement || o.IsRIRPropChanged(_str_strSettlement, c)) 
                  m.Add(_str_strSettlement, o.ObjectIdent + _str_strSettlement, "String", o.strSettlement == null ? "" : o.strSettlement.ToString(), o.IsReadOnly(_str_strSettlement), o.IsInvisible(_str_strSettlement), o.IsRequired(_str_strSettlement)); }
              }, 
        
            new field_info {
              _name = _str_datEnteredDate, _type = "DateTime?",
              _get_func = o => o.datEnteredDate,
              _set_func = (o, val) => { o.datEnteredDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datEnteredDate != c.datEnteredDate || o.IsRIRPropChanged(_str_datEnteredDate, c)) 
                  m.Add(_str_datEnteredDate, o.ObjectIdent + _str_datEnteredDate, "DateTime?", o.datEnteredDate == null ? "" : o.datEnteredDate.ToString(), o.IsReadOnly(_str_datEnteredDate), o.IsInvisible(_str_datEnteredDate), o.IsRequired(_str_datEnteredDate)); }
              }, 
        
            new field_info {
              _name = _str_strMonitoringSessionID, _type = "String",
              _get_func = o => o.strMonitoringSessionID,
              _set_func = (o, val) => { o.strMonitoringSessionID = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strMonitoringSessionID != c.strMonitoringSessionID || o.IsRIRPropChanged(_str_strMonitoringSessionID, c)) 
                  m.Add(_str_strMonitoringSessionID, o.ObjectIdent + _str_strMonitoringSessionID, "String", o.strMonitoringSessionID == null ? "" : o.strMonitoringSessionID.ToString(), o.IsReadOnly(_str_strMonitoringSessionID), o.IsInvisible(_str_strMonitoringSessionID), o.IsRequired(_str_strMonitoringSessionID)); }
              }, 
        
            new field_info {
              _name = _str_datStartDate, _type = "DateTime?",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { o.datStartDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, "DateTime?", o.datStartDate == null ? "" : o.datStartDate.ToString(), o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); }
              }, 
        
            new field_info {
              _name = _str_datEndDate, _type = "DateTime?",
              _get_func = o => o.datEndDate,
              _set_func = (o, val) => { o.datEndDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datEndDate != c.datEndDate || o.IsRIRPropChanged(_str_datEndDate, c)) 
                  m.Add(_str_datEndDate, o.ObjectIdent + _str_datEndDate, "DateTime?", o.datEndDate == null ? "" : o.datEndDate.ToString(), o.IsReadOnly(_str_datEndDate), o.IsInvisible(_str_datEndDate), o.IsRequired(_str_datEndDate)); }
              }, 
        
            new field_info {
              _name = _str_strDisease, _type = "String",
              _get_func = o => o.strDisease,
              _set_func = (o, val) => { o.strDisease = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strDisease != c.strDisease || o.IsRIRPropChanged(_str_strDisease, c)) 
                  m.Add(_str_strDisease, o.ObjectIdent + _str_strDisease, "String", o.strDisease == null ? "" : o.strDisease.ToString(), o.IsReadOnly(_str_strDisease), o.IsInvisible(_str_strDisease), o.IsRequired(_str_strDisease)); }
              }, 
        
            new field_info {
              _name = _str_idfCampaign, _type = "Int64?",
              _get_func = o => o.idfCampaign,
              _set_func = (o, val) => { o.idfCampaign = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCampaign != c.idfCampaign || o.IsRIRPropChanged(_str_idfCampaign, c)) 
                  m.Add(_str_idfCampaign, o.ObjectIdent + _str_idfCampaign, "Int64?", o.idfCampaign == null ? "" : o.idfCampaign.ToString(), o.IsReadOnly(_str_idfCampaign), o.IsInvisible(_str_idfCampaign), o.IsRequired(_str_idfCampaign)); }
              }, 
        
            new field_info {
              _name = _str_FullSession, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.FullSession != null) o.FullSession._compare(c.FullSession, m); }
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
            AsMonitoringSession obj = (AsMonitoringSession)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(AsSession), eidss.model.Schema.AsSession._str_idfMonitoringSession, _str_idfMonitoringSession)]
        public AsSession FullSession
        {
            get 
            {   
                if (!_FullSessionLoaded)
                {
                    _FullSessionLoaded = true;
                    _getAccessor()._LoadFullSession(this);
                    if (_FullSession != null) 
                        _FullSession.Parent = this;
                }
                return _FullSession; 
            }
            set 
            {   
                if (!_FullSessionLoaded) { _FullSessionLoaded = true; }
                _FullSession = value;
                if (_FullSession != null) 
                { 
                    _FullSession.m_ObjectName = _str_FullSession;
                    _FullSession.Parent = this;
                }
                idfMonitoringSession = _FullSession == null 
                        ? new Int64()
                        : _FullSession.idfMonitoringSession;
                
            }
        }
        protected AsSession _FullSession;
                    
        private bool _FullSessionLoaded = false;
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "AsMonitoringSession";

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
        
            if (_FullSession != null) { _FullSession.Parent = this; }
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as AsMonitoringSession;
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
            var ret = base.Clone() as AsMonitoringSession;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_FullSession != null)
              ret.FullSession = _FullSession.CloneWithSetup(manager) as AsSession;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public AsMonitoringSession CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AsMonitoringSession;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfMonitoringSession; } }
        public string KeyName { get { return "idfMonitoringSession"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || (_FullSession != null && _FullSession.HasChanges)
                
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
        
            if (FullSession != null) FullSession.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_FullSession != null) _FullSession.AcceptChanges();
                
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
        
            if (_FullSession != null) _FullSession.SetChange();
                
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

      private bool IsRIRPropChanged(string fld, AsMonitoringSession c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public AsMonitoringSession()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AsMonitoringSession_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AsMonitoringSession_PropertyChanged);
        }
        private void AsMonitoringSession_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AsMonitoringSession).Changed(e.PropertyName);
            
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
            AsMonitoringSession obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AsMonitoringSession obj = this;
            
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
        
                if (_FullSession != null)
                    _FullSession.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<AsMonitoringSession, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AsMonitoringSession, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AsMonitoringSession, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<AsMonitoringSession, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<AsMonitoringSession, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<AsMonitoringSession, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AsMonitoringSession()
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
        
            if (_FullSession != null) _FullSession.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
        }
    
        #region Class for web grid
        public class AsMonitoringSessionGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfMonitoringSession { get; set; }
        
            public string strMonitoringSessionID { get; set; }
        
            public string strRegion { get; set; }
        
            public string strRayon { get; set; }
        
            public string strSettlement { get; set; }
        
            public DateTime? datStartDate { get; set; }
        
            public DateTime? datEndDate { get; set; }
        
            public string strStatus { get; set; }
        
        }
        public partial class AsMonitoringSessionGridModelList : List<AsMonitoringSessionGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public AsMonitoringSessionGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<AsMonitoringSession>, errMes);
            }
            public AsMonitoringSessionGridModelList(long key, IEnumerable<AsMonitoringSession> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<AsMonitoringSession> items);
            private void LoadGridModelList(long key, IEnumerable<AsMonitoringSession> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strMonitoringSessionID,_str_strRegion,_str_strRayon,_str_strSettlement,_str_datStartDate,_str_datEndDate,_str_strStatus};
                    
                Hiddens = new List<string> {_str_idfMonitoringSession};
                Keys = new List<string> {_str_idfMonitoringSession};
                Labels = new Dictionary<string, string> {{_str_strMonitoringSessionID, _str_strMonitoringSessionID},{_str_strRegion, "idfsRegion"},{_str_strRayon, "idfsRayon"},{_str_strSettlement, "AsSession.strSettlement"},{_str_datStartDate, "AsSession.datStartDate"},{_str_datEndDate, "AsSession.datEndDate"},{_str_strStatus, "AsSession.Status"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<AsMonitoringSession>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new AsMonitoringSessionGridModel()
                {
                    ItemKey=c.idfMonitoringSession,strMonitoringSessionID=c.strMonitoringSessionID,strRegion=c.strRegion,strRayon=c.strRayon,strSettlement=c.strSettlement,datStartDate=c.datStartDate,datEndDate=c.datEndDate,strStatus=c.strStatus
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
        : DataAccessor<AsMonitoringSession>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(AsMonitoringSession obj);
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
            private AsSession.Accessor FullSessionAccessor { get { return eidss.model.Schema.AsSession.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual AsMonitoringSession SelectByKey(DbManagerProxy manager
                , Int64? idfCampaign
                )
            {
                return _SelectByKey(manager
                    , idfCampaign
                    , null, null
                    );
            }
            
      
            private AsMonitoringSession _SelectByKey(DbManagerProxy manager
                , Int64? idfCampaign
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
            internal void _LoadFullSession(AsMonitoringSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadFullSession(manager, obj);
                }
            }
            internal void _LoadFullSession(DbManagerProxy manager, AsMonitoringSession obj)
            {
                
                if (obj.FullSession == null && obj.idfMonitoringSession != 0)
                {
                    obj.FullSession = FullSessionAccessor.SelectByKey(manager
                        
                        , obj.idfMonitoringSession
                        );
                    if (obj.FullSession != null)
                    {
                        obj.FullSession.m_ObjectName = _str_FullSession;
                    }
                }
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, AsMonitoringSession obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AsMonitoringSession obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    FullSessionAccessor._SetPermitions(obj._permissions, obj.FullSession);
                    
                    }
                }
            }

    

            private AsMonitoringSession _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    AsMonitoringSession obj = AsMonitoringSession.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.FullSession = new Func<AsMonitoringSession, AsSession>(c => FullSessionAccessor.CreateNewT(manager, c))(obj);
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

            
            public AsMonitoringSession CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public AsMonitoringSession CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(AsMonitoringSession obj, object newobj)
            {
                
                    if (newobj == null)
                    {
                        var o = obj.FullSession;
                            
                        var item = o;
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "idfsRegion")
                            {
                            
                obj.strRegion = new Func<AsMonitoringSession, string>(c=>c.FullSession.Region == null ? "" : c.FullSession.Region.ToString())(obj);
                            }
                        };
                        
                    }
                            
                    if (newobj == null)
                    {
                        var o = obj.FullSession;
                            
                        var item = o;
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "idfsRayon")
                            {
                            
                obj.strRayon = new Func<AsMonitoringSession, string>(c=>c.FullSession.Rayon == null ? "" : c.FullSession.Rayon.ToString())(obj);
                            }
                        };
                        
                    }
                            
                    if (newobj == null)
                    {
                        var o = obj.FullSession;
                            
                        var item = o;
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "idfsSettlement")
                            {
                            
                obj.strSettlement = new Func<AsMonitoringSession, string>(c=>c.FullSession.Settlement == null ? "" : c.FullSession.Settlement.ToString())(obj);
                            }
                        };
                        
                    }
                            
                    if (newobj == null)
                    {
                        var o = obj.FullSession;
                            
                        var item = o;
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "strMonitoringSessionID")
                            {
                            
                obj.strMonitoringSessionID = new Func<AsMonitoringSession, string>(c=>c.FullSession.strMonitoringSessionID)(obj);
                            }
                        };
                        
                    }
                            
            }
            
            private void _SetupHandlers(AsMonitoringSession obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, AsMonitoringSession obj)
            {
                
            }
    
            [SprocName("spAsSession_RemoveLinkToCampaign")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? idfMonitoringSession
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? idfMonitoringSession
                )
            {
                
                _postDelete(manager, idfMonitoringSession);
                
            }
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spAsSession_CampaignPost")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] AsMonitoringSession obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] AsMonitoringSession obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    AsMonitoringSession bo = obj as AsMonitoringSession;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as AsMonitoringSession, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, AsMonitoringSession obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                                
                    _postDeletePredicate(manager
                        , obj.idfMonitoringSession
                        );
                                        
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (!obj.IsMarkedToDelete && bHasChanges)
                        _postPredicate(manager, obj);
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(AsMonitoringSession obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, AsMonitoringSession obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as AsMonitoringSession, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AsMonitoringSession obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(AsMonitoringSession obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(AsMonitoringSession obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AsMonitoringSession) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AsMonitoringSession) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AsMonitoringSessionDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spASCampaign_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spAsSession_CampaignPost";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spAsSession_RemoveLinkToCampaign";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AsMonitoringSession, bool>> RequiredByField = new Dictionary<string, Func<AsMonitoringSession, bool>>();
            public static Dictionary<string, Func<AsMonitoringSession, bool>> RequiredByProperty = new Dictionary<string, Func<AsMonitoringSession, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strStatus, 2000);
                Sizes.Add(_str_strRegion, 300);
                Sizes.Add(_str_strRayon, 300);
                Sizes.Add(_str_strSettlement, 300);
                Sizes.Add(_str_strMonitoringSessionID, 50);
                Sizes.Add(_str_strDisease, 2147483647);
                GridMeta.Add(new GridMetaItem(
                    _str_idfMonitoringSession,
                    _str_idfMonitoringSession, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strMonitoringSessionID,
                    _str_strMonitoringSessionID, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRegion,
                    "idfsRegion", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strRayon,
                    "idfsRayon", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSettlement,
                    "AsSession.strSettlement", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datStartDate,
                    "AsSession.datStartDate", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datEndDate,
                    "AsSession.datEndDate", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strStatus,
                    "AsSession.Status", null, true, true, null
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
                    (manager, c, pars) => new ActResult(((AsMonitoringSession)c).MarkToDelete() && ObjectAccessor.PostInterface<AsMonitoringSession>().Post(manager, (AsMonitoringSession)c), c),
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
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AsMonitoringSession>().Post(manager, (AsMonitoringSession)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AsMonitoringSession>().Post(manager, (AsMonitoringSession)c), c),
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
	