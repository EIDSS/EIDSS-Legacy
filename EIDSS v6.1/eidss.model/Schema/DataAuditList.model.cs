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
    public abstract partial class DataAuditListItem : 
        EditableObject<DataAuditListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfDataAuditEvent), NonUpdatable, PrimaryKey]
        public abstract Int64 idfDataAuditEvent { get; set; }
                
        [LocalizedDisplayName(_str_idfsObjectType)]
        [MapField(_str_idfsObjectType)]
        public abstract Int64? idfsObjectType { get; set; }
        protected Int64? idfsObjectType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsObjectType).OriginalValue; } }
        protected Int64? idfsObjectType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsObjectType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strObjectType)]
        [MapField(_str_strObjectType)]
        public abstract String strObjectType { get; set; }
        protected String strObjectType_Original { get { return ((EditableValue<String>)((dynamic)this)._strObjectType).OriginalValue; } }
        protected String strObjectType_Previous { get { return ((EditableValue<String>)((dynamic)this)._strObjectType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsActionName)]
        [MapField(_str_idfsActionName)]
        public abstract Int64? idfsActionName { get; set; }
        protected Int64? idfsActionName_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsActionName).OriginalValue; } }
        protected Int64? idfsActionName_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsActionName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strActionName)]
        [MapField(_str_strActionName)]
        public abstract String strActionName { get; set; }
        protected String strActionName_Original { get { return ((EditableValue<String>)((dynamic)this)._strActionName).OriginalValue; } }
        protected String strActionName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strActionName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64 idfsSite { get; set; }
        protected Int64 idfsSite_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64 idfsSite_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfOffice)]
        [MapField(_str_idfOffice)]
        public abstract Int64? idfOffice { get; set; }
        protected Int64? idfOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOffice).OriginalValue; } }
        protected Int64? idfOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfOffice).PreviousValue; } }
                
        [LocalizedDisplayName("idfsSite")]
        [MapField(_str_strSiteID)]
        public abstract String strSiteID { get; set; }
        protected String strSiteID_Original { get { return ((EditableValue<String>)((dynamic)this)._strSiteID).OriginalValue; } }
        protected String strSiteID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSiteID).PreviousValue; } }
                
        [LocalizedDisplayName("datTransactionDate")]
        [MapField(_str_datEnteringDate)]
        public abstract DateTime? datEnteringDate { get; set; }
        protected DateTime? datEnteringDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteringDate).OriginalValue; } }
        protected DateTime? datEnteringDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteringDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMainObject)]
        [MapField(_str_idfMainObject)]
        public abstract Int64? idfMainObject { get; set; }
        protected Int64? idfMainObject_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMainObject).OriginalValue; } }
        protected Int64? idfMainObject_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMainObject).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfMainObjectTable)]
        [MapField(_str_idfMainObjectTable)]
        public abstract Int64? idfMainObjectTable { get; set; }
        protected Int64? idfMainObjectTable_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMainObjectTable).OriginalValue; } }
        protected Int64? idfMainObjectTable_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfMainObjectTable).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPerson)]
        [MapField(_str_idfPerson)]
        public abstract Int64? idfPerson { get; set; }
        protected Int64? idfPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerson).OriginalValue; } }
        protected Int64? idfPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPersonName)]
        [MapField(_str_strPersonName)]
        public abstract String strPersonName { get; set; }
        protected String strPersonName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPersonName).OriginalValue; } }
        protected String strPersonName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPersonName).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<DataAuditListItem, object> _get_func;
            internal Action<DataAuditListItem, string> _set_func;
            internal Action<DataAuditListItem, DataAuditListItem, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfDataAuditEvent = "idfDataAuditEvent";
        internal const string _str_idfsObjectType = "idfsObjectType";
        internal const string _str_strObjectType = "strObjectType";
        internal const string _str_idfsActionName = "idfsActionName";
        internal const string _str_strActionName = "strActionName";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_idfOffice = "idfOffice";
        internal const string _str_strSiteID = "strSiteID";
        internal const string _str_datEnteringDate = "datEnteringDate";
        internal const string _str_idfMainObject = "idfMainObject";
        internal const string _str_idfMainObjectTable = "idfMainObjectTable";
        internal const string _str_idfPerson = "idfPerson";
        internal const string _str_strPersonName = "strPersonName";
        internal const string _str_AuditObjectType = "AuditObjectType";
        internal const string _str_AuditEventType = "AuditEventType";
        internal const string _str_Site = "Site";
        internal const string _str_Person = "Person";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfDataAuditEvent, _formname = _str_idfDataAuditEvent, _type = "Int64",
              _get_func = o => o.idfDataAuditEvent,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfDataAuditEvent != newval) o.idfDataAuditEvent = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfDataAuditEvent != c.idfDataAuditEvent || o.IsRIRPropChanged(_str_idfDataAuditEvent, c)) 
                  m.Add(_str_idfDataAuditEvent, o.ObjectIdent + _str_idfDataAuditEvent, o.ObjectIdent2 + _str_idfDataAuditEvent, o.ObjectIdent3 + _str_idfDataAuditEvent, "Int64", 
                    o.idfDataAuditEvent == null ? "" : o.idfDataAuditEvent.ToString(),                  
                  o.IsReadOnly(_str_idfDataAuditEvent), o.IsInvisible(_str_idfDataAuditEvent), o.IsRequired(_str_idfDataAuditEvent)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsObjectType, _formname = _str_idfsObjectType, _type = "Int64?",
              _get_func = o => o.idfsObjectType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsObjectType != newval) 
                  o.AuditObjectType = o.AuditObjectTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsObjectType != newval) o.idfsObjectType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsObjectType != c.idfsObjectType || o.IsRIRPropChanged(_str_idfsObjectType, c)) 
                  m.Add(_str_idfsObjectType, o.ObjectIdent + _str_idfsObjectType, o.ObjectIdent2 + _str_idfsObjectType, o.ObjectIdent3 + _str_idfsObjectType, "Int64?", 
                    o.idfsObjectType == null ? "" : o.idfsObjectType.ToString(),                  
                  o.IsReadOnly(_str_idfsObjectType), o.IsInvisible(_str_idfsObjectType), o.IsRequired(_str_idfsObjectType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strObjectType, _formname = _str_strObjectType, _type = "String",
              _get_func = o => o.strObjectType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strObjectType != newval) o.strObjectType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strObjectType != c.strObjectType || o.IsRIRPropChanged(_str_strObjectType, c)) 
                  m.Add(_str_strObjectType, o.ObjectIdent + _str_strObjectType, o.ObjectIdent2 + _str_strObjectType, o.ObjectIdent3 + _str_strObjectType, "String", 
                    o.strObjectType == null ? "" : o.strObjectType.ToString(),                  
                  o.IsReadOnly(_str_strObjectType), o.IsInvisible(_str_strObjectType), o.IsRequired(_str_strObjectType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsActionName, _formname = _str_idfsActionName, _type = "Int64?",
              _get_func = o => o.idfsActionName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsActionName != newval) 
                  o.AuditEventType = o.AuditEventTypeLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsActionName != newval) o.idfsActionName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsActionName != c.idfsActionName || o.IsRIRPropChanged(_str_idfsActionName, c)) 
                  m.Add(_str_idfsActionName, o.ObjectIdent + _str_idfsActionName, o.ObjectIdent2 + _str_idfsActionName, o.ObjectIdent3 + _str_idfsActionName, "Int64?", 
                    o.idfsActionName == null ? "" : o.idfsActionName.ToString(),                  
                  o.IsReadOnly(_str_idfsActionName), o.IsInvisible(_str_idfsActionName), o.IsRequired(_str_idfsActionName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strActionName, _formname = _str_strActionName, _type = "String",
              _get_func = o => o.strActionName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strActionName != newval) o.strActionName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strActionName != c.strActionName || o.IsRIRPropChanged(_str_strActionName, c)) 
                  m.Add(_str_strActionName, o.ObjectIdent + _str_strActionName, o.ObjectIdent2 + _str_strActionName, o.ObjectIdent3 + _str_strActionName, "String", 
                    o.strActionName == null ? "" : o.strActionName.ToString(),                  
                  o.IsReadOnly(_str_strActionName), o.IsInvisible(_str_strActionName), o.IsRequired(_str_strActionName)); 
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
              _name = _str_idfOffice, _formname = _str_idfOffice, _type = "Int64?",
              _get_func = o => o.idfOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfOffice != newval) o.idfOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfOffice != c.idfOffice || o.IsRIRPropChanged(_str_idfOffice, c)) 
                  m.Add(_str_idfOffice, o.ObjectIdent + _str_idfOffice, o.ObjectIdent2 + _str_idfOffice, o.ObjectIdent3 + _str_idfOffice, "Int64?", 
                    o.idfOffice == null ? "" : o.idfOffice.ToString(),                  
                  o.IsReadOnly(_str_idfOffice), o.IsInvisible(_str_idfOffice), o.IsRequired(_str_idfOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSiteID, _formname = _str_strSiteID, _type = "String",
              _get_func = o => o.strSiteID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSiteID != newval) o.strSiteID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSiteID != c.strSiteID || o.IsRIRPropChanged(_str_strSiteID, c)) 
                  m.Add(_str_strSiteID, o.ObjectIdent + _str_strSiteID, o.ObjectIdent2 + _str_strSiteID, o.ObjectIdent3 + _str_strSiteID, "String", 
                    o.strSiteID == null ? "" : o.strSiteID.ToString(),                  
                  o.IsReadOnly(_str_strSiteID), o.IsInvisible(_str_strSiteID), o.IsRequired(_str_strSiteID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datEnteringDate, _formname = _str_datEnteringDate, _type = "DateTime?",
              _get_func = o => o.datEnteringDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datEnteringDate != newval) o.datEnteringDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datEnteringDate != c.datEnteringDate || o.IsRIRPropChanged(_str_datEnteringDate, c)) 
                  m.Add(_str_datEnteringDate, o.ObjectIdent + _str_datEnteringDate, o.ObjectIdent2 + _str_datEnteringDate, o.ObjectIdent3 + _str_datEnteringDate, "DateTime?", 
                    o.datEnteringDate == null ? "" : o.datEnteringDate.ToString(),                  
                  o.IsReadOnly(_str_datEnteringDate), o.IsInvisible(_str_datEnteringDate), o.IsRequired(_str_datEnteringDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMainObject, _formname = _str_idfMainObject, _type = "Int64?",
              _get_func = o => o.idfMainObject,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfMainObject != newval) o.idfMainObject = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfMainObject != c.idfMainObject || o.IsRIRPropChanged(_str_idfMainObject, c)) 
                  m.Add(_str_idfMainObject, o.ObjectIdent + _str_idfMainObject, o.ObjectIdent2 + _str_idfMainObject, o.ObjectIdent3 + _str_idfMainObject, "Int64?", 
                    o.idfMainObject == null ? "" : o.idfMainObject.ToString(),                  
                  o.IsReadOnly(_str_idfMainObject), o.IsInvisible(_str_idfMainObject), o.IsRequired(_str_idfMainObject)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfMainObjectTable, _formname = _str_idfMainObjectTable, _type = "Int64?",
              _get_func = o => o.idfMainObjectTable,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfMainObjectTable != newval) o.idfMainObjectTable = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfMainObjectTable != c.idfMainObjectTable || o.IsRIRPropChanged(_str_idfMainObjectTable, c)) 
                  m.Add(_str_idfMainObjectTable, o.ObjectIdent + _str_idfMainObjectTable, o.ObjectIdent2 + _str_idfMainObjectTable, o.ObjectIdent3 + _str_idfMainObjectTable, "Int64?", 
                    o.idfMainObjectTable == null ? "" : o.idfMainObjectTable.ToString(),                  
                  o.IsReadOnly(_str_idfMainObjectTable), o.IsInvisible(_str_idfMainObjectTable), o.IsRequired(_str_idfMainObjectTable)); 
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
              _name = _str_strPersonName, _formname = _str_strPersonName, _type = "String",
              _get_func = o => o.strPersonName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPersonName != newval) o.strPersonName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strPersonName != c.strPersonName || o.IsRIRPropChanged(_str_strPersonName, c)) 
                  m.Add(_str_strPersonName, o.ObjectIdent + _str_strPersonName, o.ObjectIdent2 + _str_strPersonName, o.ObjectIdent3 + _str_strPersonName, "String", 
                    o.strPersonName == null ? "" : o.strPersonName.ToString(),                  
                  o.IsReadOnly(_str_strPersonName), o.IsInvisible(_str_strPersonName), o.IsRequired(_str_strPersonName)); 
                  }
              }, 
        
            new field_info {
              _name = _str_AuditObjectType, _formname = _str_AuditObjectType, _type = "Lookup",
              _get_func = o => { if (o.AuditObjectType == null) return null; return o.AuditObjectType.idfsBaseReference; },
              _set_func = (o, val) => { o.AuditObjectType = o.AuditObjectTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AuditObjectType, c);
                if (o.idfsObjectType != c.idfsObjectType || o.IsRIRPropChanged(_str_AuditObjectType, c) || bChangeLookupContent) {
                  m.Add(_str_AuditObjectType, o.ObjectIdent + _str_AuditObjectType, o.ObjectIdent2 + _str_AuditObjectType, o.ObjectIdent3 + _str_AuditObjectType, "Lookup", o.idfsObjectType == null ? "" : o.idfsObjectType.ToString(), o.IsReadOnly(_str_AuditObjectType), o.IsInvisible(_str_AuditObjectType), o.IsRequired(_str_AuditObjectType),
                  bChangeLookupContent ? o.AuditObjectTypeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AuditObjectType + "Lookup", _formname = _str_AuditObjectType + "Lookup", _type = "LookupContent",
              _get_func = o => o.AuditObjectTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_AuditEventType, _formname = _str_AuditEventType, _type = "Lookup",
              _get_func = o => { if (o.AuditEventType == null) return null; return o.AuditEventType.idfsBaseReference; },
              _set_func = (o, val) => { o.AuditEventType = o.AuditEventTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_AuditEventType, c);
                if (o.idfsActionName != c.idfsActionName || o.IsRIRPropChanged(_str_AuditEventType, c) || bChangeLookupContent) {
                  m.Add(_str_AuditEventType, o.ObjectIdent + _str_AuditEventType, o.ObjectIdent2 + _str_AuditEventType, o.ObjectIdent3 + _str_AuditEventType, "Lookup", o.idfsActionName == null ? "" : o.idfsActionName.ToString(), o.IsReadOnly(_str_AuditEventType), o.IsInvisible(_str_AuditEventType), o.IsRequired(_str_AuditEventType),
                  bChangeLookupContent ? o.AuditEventTypeLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_AuditEventType + "Lookup", _formname = _str_AuditEventType + "Lookup", _type = "LookupContent",
              _get_func = o => o.AuditEventTypeLookup,
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
            DataAuditListItem obj = (DataAuditListItem)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_AuditObjectType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsObjectType)]
        public BaseReference AuditObjectType
        {
            get { return _AuditObjectType == null ? null : ((long)_AuditObjectType.Key == 0 ? null : _AuditObjectType); }
            set 
            { 
                var oldVal = _AuditObjectType;
                _AuditObjectType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AuditObjectType != oldVal)
                {
                    if (idfsObjectType != (_AuditObjectType == null
                            ? new Int64?()
                            : (Int64?)_AuditObjectType.idfsBaseReference))
                        idfsObjectType = _AuditObjectType == null 
                            ? new Int64?()
                            : (Int64?)_AuditObjectType.idfsBaseReference; 
                    OnPropertyChanged(_str_AuditObjectType); 
                }
            }
        }
        private BaseReference _AuditObjectType;

        
        public BaseReferenceList AuditObjectTypeLookup
        {
            get { return _AuditObjectTypeLookup; }
        }
        private BaseReferenceList _AuditObjectTypeLookup = new BaseReferenceList("rftDataAuditObjectType");
            
        [LocalizedDisplayName(_str_AuditEventType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsActionName)]
        public BaseReference AuditEventType
        {
            get { return _AuditEventType == null ? null : ((long)_AuditEventType.Key == 0 ? null : _AuditEventType); }
            set 
            { 
                var oldVal = _AuditEventType;
                _AuditEventType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_AuditEventType != oldVal)
                {
                    if (idfsActionName != (_AuditEventType == null
                            ? new Int64?()
                            : (Int64?)_AuditEventType.idfsBaseReference))
                        idfsActionName = _AuditEventType == null 
                            ? new Int64?()
                            : (Int64?)_AuditEventType.idfsBaseReference; 
                    OnPropertyChanged(_str_AuditEventType); 
                }
            }
        }
        private BaseReference _AuditEventType;

        
        public BaseReferenceList AuditEventTypeLookup
        {
            get { return _AuditEventTypeLookup; }
        }
        private BaseReferenceList _AuditEventTypeLookup = new BaseReferenceList("rftDataAuditEventType");
            
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
            
                case _str_AuditObjectType:
                    return new BvSelectList(AuditObjectTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AuditObjectType, _str_idfsObjectType);
            
                case _str_AuditEventType:
                    return new BvSelectList(AuditEventTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, AuditEventType, _str_idfsActionName);
            
                case _str_Site:
                    return new BvSelectList(SiteLookup, eidss.model.Schema.SiteLookup._str_idfsSite, null, Site, _str_idfsSite);
            
                case _str_Person:
                    return new BvSelectList(PersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, Person, _str_idfPerson);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "DataAuditListItem";

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
            var ret = base.Clone() as DataAuditListItem;
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
            var ret = base.Clone() as DataAuditListItem;
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
        public DataAuditListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as DataAuditListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfDataAuditEvent; } }
        public string KeyName { get { return "idfDataAuditEvent"; } }
        public object KeyLookup { get { return idfDataAuditEvent; } }
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
        
            var _prev_idfsObjectType_AuditObjectType = idfsObjectType;
            var _prev_idfsActionName_AuditEventType = idfsActionName;
            var _prev_idfsSite_Site = idfsSite;
            var _prev_idfPerson_Person = idfPerson;
            base.RejectChanges();
        
            if (_prev_idfsObjectType_AuditObjectType != idfsObjectType)
            {
                _AuditObjectType = _AuditObjectTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsObjectType);
            }
            if (_prev_idfsActionName_AuditEventType != idfsActionName)
            {
                _AuditEventType = _AuditEventTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsActionName);
            }
            if (_prev_idfsSite_Site != idfsSite)
            {
                _Site = _SiteLookup.FirstOrDefault(c => c.idfsSite == idfsSite);
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

        private bool IsRIRPropChanged(string fld, DataAuditListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, DataAuditListItem c)
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
        

      

        public DataAuditListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(DataAuditListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(DataAuditListItem_PropertyChanged);
        }
        private void DataAuditListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as DataAuditListItem).Changed(e.PropertyName);
            
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
            DataAuditListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            DataAuditListItem obj = this;
            
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

    
        private static string[] readonly_names1 = "strObjectName".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<DataAuditListItem, bool>(c => c.AuditObjectType == null ||
                        !((c.AuditObjectType != null && c.AuditObjectType.idfsBaseReference == (long)eidss.model.Enums.EIDSSAuditObject.daoHumanCase)
                        || (c.AuditObjectType != null && c.AuditObjectType.idfsBaseReference == (long)eidss.model.Enums.EIDSSAuditObject.daoOutbreak)
                        || (c.AuditObjectType != null && c.AuditObjectType.idfsBaseReference == (long)eidss.model.Enums.EIDSSAuditObject.daoVetCase)
                        || (c.AuditObjectType != null && c.AuditObjectType.idfsBaseReference == (long)eidss.model.Enums.EIDSSAuditObject.daoCampaign)
                        || (c.AuditObjectType != null && c.AuditObjectType.idfsBaseReference == (long)eidss.model.Enums.EIDSSAuditObject.daoMonitoringSession)
                        || (c.AuditObjectType != null && c.AuditObjectType.idfsBaseReference == (long)eidss.model.Enums.EIDSSAuditObject.daoAgregateHumanCase)
                        || (c.AuditObjectType != null && c.AuditObjectType.idfsBaseReference == (long)eidss.model.Enums.EIDSSAuditObject.daoAggregateVetCase)
                        || (c.AuditObjectType != null && c.AuditObjectType.idfsBaseReference == (long)eidss.model.Enums.EIDSSAuditObject.daoAggregateVetAction)
                        || (c.AuditObjectType != null && c.AuditObjectType.idfsBaseReference == (long)eidss.model.Enums.EIDSSAuditObject.daoVectorSurveillanceSession)
                        || (c.AuditObjectType != null && c.AuditObjectType.idfsBaseReference == (long)eidss.model.Enums.EIDSSAuditObject.daoBssForm)
                        || (c.AuditObjectType != null && c.AuditObjectType.idfsBaseReference == (long)eidss.model.Enums.EIDSSAuditObject.daoBssAggregateForm)
                        ))(this);
            
            return ReadOnly || new Func<DataAuditListItem, bool>(c => false)(this);
                
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


        internal Dictionary<string, Func<DataAuditListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<DataAuditListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<DataAuditListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<DataAuditListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<DataAuditListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<DataAuditListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<DataAuditListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~DataAuditListItem()
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
                
                LookupManager.RemoveObject("rftDataAuditObjectType", this);
                
                LookupManager.RemoveObject("rftDataAuditEventType", this);
                
                LookupManager.RemoveObject("SiteLookup", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftDataAuditObjectType")
                _getAccessor().LoadLookup_AuditObjectType(manager, this);
            
            if (lookup_object == "rftDataAuditEventType")
                _getAccessor().LoadLookup_AuditEventType(manager, this);
            
            if (lookup_object == "SiteLookup")
                _getAccessor().LoadLookup_Site(manager, this);
            
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
        public class DataAuditListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfDataAuditEvent { get; set; }
        
            public DateTimeWrapG datEnteringDate { get; set; }
        
            public String strObjectType { get; set; }
        
            public String strActionName { get; set; }
        
            public String strPersonName { get; set; }
        
            public String strSiteID { get; set; }
        
        }
        public partial class DataAuditListItemGridModelList : List<DataAuditListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public DataAuditListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<DataAuditListItem>, errMes);
            }
            public DataAuditListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<DataAuditListItem>, errMes);
            }
            public DataAuditListItemGridModelList(long key, IEnumerable<DataAuditListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public DataAuditListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<DataAuditListItem>(), null);
            }
            partial void filter(List<DataAuditListItem> items);
            private void LoadGridModelList(long key, IEnumerable<DataAuditListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_datEnteringDate,_str_strObjectType,_str_strActionName,_str_strPersonName,_str_strSiteID};
                    
                Hiddens = new List<string> {_str_idfDataAuditEvent};
                Keys = new List<string> {_str_idfDataAuditEvent};
                Labels = new Dictionary<string, string> {{_str_datEnteringDate, "datTransactionDate"},{_str_strObjectType, _str_strObjectType},{_str_strActionName, _str_strActionName},{_str_strPersonName, _str_strPersonName},{_str_strSiteID, "idfsSite"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                DataAuditListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<DataAuditListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new DataAuditListItemGridModel()
                {
                    ItemKey=c.idfDataAuditEvent,datEnteringDate=c.datEnteringDate,strObjectType=c.strObjectType,strActionName=c.strActionName,strPersonName=c.strPersonName,strSiteID=c.strSiteID
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
        : DataAccessor<DataAuditListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<DataAuditListItem>
            
            , IObjectSelectList
            , IObjectSelectList<DataAuditListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfDataAuditEvent"; } }
            #endregion
        
            public delegate void on_action(DataAuditListItem obj);
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
            private BaseReference.Accessor AuditObjectTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor AuditEventTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private SiteLookup.Accessor SiteAccessor { get { return eidss.model.Schema.SiteLookup.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor PersonAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            
            public virtual List<DataAuditListItem> SelectListT(DbManagerProxy manager
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
            
            protected virtual List<DataAuditListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_DataAudit_SelectList.* from dbo.fn_DataAudit_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("strObjectName"))
                {
                    
                    sql.Append(" " + @"
            JOIN		tauTable
            ON			tauTable.idfTable = fn_DataAudit_SelectList.idfMainObjectTable
            LEFT JOIN	tlbHumanCase
            ON			tlbHumanCase.idfHumanCase = fn_DataAudit_SelectList.idfMainObject
            LEFT JOIN	tlbVetCase
            ON			tlbVetCase.idfVetCase = fn_DataAudit_SelectList.idfMainObject
            LEFT JOIN	tlbOutbreak
            ON			tlbOutbreak.idfOutbreak = fn_DataAudit_SelectList.idfMainObject
            LEFT JOIN	tlbCampaign
            ON			tlbCampaign.idfCampaign = fn_DataAudit_SelectList.idfMainObject
            LEFT JOIN	tlbMonitoringSession
            ON			tlbMonitoringSession.idfMonitoringSession = fn_DataAudit_SelectList.idfMainObject
            LEFT JOIN	tlbAggrCase
            ON			tlbAggrCase.idfAggrCase = fn_DataAudit_SelectList.idfMainObject
            LEFT JOIN	tlbVectorSurveillanceSession
            ON			tlbVectorSurveillanceSession.idfVectorSurveillanceSession = fn_DataAudit_SelectList.idfMainObject
            LEFT JOIN	tlbBasicSyndromicSurveillance
            ON			tlbBasicSyndromicSurveillance.idfBasicSyndromicSurveillance = fn_DataAudit_SelectList.idfMainObject
            LEFT JOIN	tlbBasicSyndromicSurveillanceAggregateHeader
            ON			tlbBasicSyndromicSurveillanceAggregateHeader.idfAggregateHeader = fn_DataAudit_SelectList.idfMainObject
          ");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (EidssSiteContext.Instance.SiteType == SiteType.TLVL)
                {
                    sql.Append(@" and exists (select * from  tflDataAuditEventFiltered f inner join tflSiteToSiteGroup on tflSiteToSiteGroup.idfSiteGroup = f.idfSiteGroup and tflSiteToSiteGroup.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString() + " where f.idfDataAuditEvent = fn_DataAudit_SelectList.idfDataAuditEvent)");
                }
                
                if (filters.Contains("strObjectName"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strObjectName") == 1)
                    {
                        sql.AppendFormat("CASE tauTable.strName	WHEN 'tlbVetCase' THEN tlbVetCase.strCaseID	WHEN 'tlbHumanCase'	THEN tlbHumanCase.strCaseID	WHEN 'tlbOutbreak'	THEN tlbOutbreak.strOutbreakID	WHEN 'tlbCampaign'	THEN tlbCampaign.strCampaignID WHEN 'tlbMonitoringSession'	THEN tlbMonitoringSession.strMonitoringSessionID  WHEN 'tlbVectorSurveillanceSession'	THEN tlbVectorSurveillanceSession.strSessionID WHEN 'tlbAggrCase'	THEN tlbAggrCase.strCaseID WHEN 'tlbBasicSyndromicSurveillance'	THEN tlbBasicSyndromicSurveillance.strFormID WHEN 'tlbBasicSyndromicSurveillanceAggregateHeader'	THEN tlbBasicSyndromicSurveillanceAggregateHeader.strFormID END  {0} @strObjectName", filters.Operation("strObjectName"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strObjectName"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strObjectName") ? " or " : " and ");
                            sql.AppendFormat("CASE tauTable.strName	WHEN 'tlbVetCase' THEN tlbVetCase.strCaseID	WHEN 'tlbHumanCase'	THEN tlbHumanCase.strCaseID	WHEN 'tlbOutbreak'	THEN tlbOutbreak.strOutbreakID	WHEN 'tlbCampaign'	THEN tlbCampaign.strCampaignID WHEN 'tlbMonitoringSession'	THEN tlbMonitoringSession.strMonitoringSessionID  WHEN 'tlbVectorSurveillanceSession'	THEN tlbVectorSurveillanceSession.strSessionID WHEN 'tlbAggrCase'	THEN tlbAggrCase.strCaseID WHEN 'tlbBasicSyndromicSurveillance'	THEN tlbBasicSyndromicSurveillance.strFormID WHEN 'tlbBasicSyndromicSurveillanceAggregateHeader'	THEN tlbBasicSyndromicSurveillanceAggregateHeader.strFormID END  {0} @strObjectName_{1}", filters.Operation("strObjectName", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfDataAuditEvent"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfDataAuditEvent"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfDataAuditEvent") ? " or " : " and ");
                        
                        if (filters.Operation("idfDataAuditEvent", i) == "&")
                          sql.AppendFormat("(isnull(fn_DataAudit_SelectList.idfDataAuditEvent,0) {0} @idfDataAuditEvent_{1} = @idfDataAuditEvent_{1})", filters.Operation("idfDataAuditEvent", i), i);
                        else
                          sql.AppendFormat("isnull(fn_DataAudit_SelectList.idfDataAuditEvent,0) {0} @idfDataAuditEvent_{1}", filters.Operation("idfDataAuditEvent", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsObjectType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsObjectType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsObjectType") ? " or " : " and ");
                        
                        if (filters.Operation("idfsObjectType", i) == "&")
                          sql.AppendFormat("(isnull(fn_DataAudit_SelectList.idfsObjectType,0) {0} @idfsObjectType_{1} = @idfsObjectType_{1})", filters.Operation("idfsObjectType", i), i);
                        else
                          sql.AppendFormat("isnull(fn_DataAudit_SelectList.idfsObjectType,0) {0} @idfsObjectType_{1}", filters.Operation("idfsObjectType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strObjectType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strObjectType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strObjectType") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_DataAudit_SelectList.strObjectType {0} @strObjectType_{1}", filters.Operation("strObjectType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsActionName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsActionName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsActionName") ? " or " : " and ");
                        
                        if (filters.Operation("idfsActionName", i) == "&")
                          sql.AppendFormat("(isnull(fn_DataAudit_SelectList.idfsActionName,0) {0} @idfsActionName_{1} = @idfsActionName_{1})", filters.Operation("idfsActionName", i), i);
                        else
                          sql.AppendFormat("isnull(fn_DataAudit_SelectList.idfsActionName,0) {0} @idfsActionName_{1}", filters.Operation("idfsActionName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strActionName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strActionName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strActionName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_DataAudit_SelectList.strActionName {0} @strActionName_{1}", filters.Operation("strActionName", i), i);
                            
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
                          sql.AppendFormat("(isnull(fn_DataAudit_SelectList.idfsSite,0) {0} @idfsSite_{1} = @idfsSite_{1})", filters.Operation("idfsSite", i), i);
                        else
                          sql.AppendFormat("isnull(fn_DataAudit_SelectList.idfsSite,0) {0} @idfsSite_{1}", filters.Operation("idfsSite", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfOffice") ? " or " : " and ");
                        
                        if (filters.Operation("idfOffice", i) == "&")
                          sql.AppendFormat("(isnull(fn_DataAudit_SelectList.idfOffice,0) {0} @idfOffice_{1} = @idfOffice_{1})", filters.Operation("idfOffice", i), i);
                        else
                          sql.AppendFormat("isnull(fn_DataAudit_SelectList.idfOffice,0) {0} @idfOffice_{1}", filters.Operation("idfOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSiteID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSiteID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSiteID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_DataAudit_SelectList.strSiteID {0} @strSiteID_{1}", filters.Operation("strSiteID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datEnteringDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datEnteringDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datEnteringDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_DataAudit_SelectList.datEnteringDate, 112) {0} CONVERT(NVARCHAR(8), @datEnteringDate_{1}, 112)", filters.Operation("datEnteringDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfMainObject"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfMainObject"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfMainObject") ? " or " : " and ");
                        
                        if (filters.Operation("idfMainObject", i) == "&")
                          sql.AppendFormat("(isnull(fn_DataAudit_SelectList.idfMainObject,0) {0} @idfMainObject_{1} = @idfMainObject_{1})", filters.Operation("idfMainObject", i), i);
                        else
                          sql.AppendFormat("isnull(fn_DataAudit_SelectList.idfMainObject,0) {0} @idfMainObject_{1}", filters.Operation("idfMainObject", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfMainObjectTable"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfMainObjectTable"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfMainObjectTable") ? " or " : " and ");
                        
                        if (filters.Operation("idfMainObjectTable", i) == "&")
                          sql.AppendFormat("(isnull(fn_DataAudit_SelectList.idfMainObjectTable,0) {0} @idfMainObjectTable_{1} = @idfMainObjectTable_{1})", filters.Operation("idfMainObjectTable", i), i);
                        else
                          sql.AppendFormat("isnull(fn_DataAudit_SelectList.idfMainObjectTable,0) {0} @idfMainObjectTable_{1}", filters.Operation("idfMainObjectTable", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfPerson"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfPerson"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfPerson") ? " or " : " and ");
                        
                        if (filters.Operation("idfPerson", i) == "&")
                          sql.AppendFormat("(isnull(fn_DataAudit_SelectList.idfPerson,0) {0} @idfPerson_{1} = @idfPerson_{1})", filters.Operation("idfPerson", i), i);
                        else
                          sql.AppendFormat("isnull(fn_DataAudit_SelectList.idfPerson,0) {0} @idfPerson_{1}", filters.Operation("idfPerson", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strPersonName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strPersonName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strPersonName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_DataAudit_SelectList.strPersonName {0} @strPersonName_{1}", filters.Operation("strPersonName", i), i);
                            
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
                    
                    if (filters.Contains("strObjectName"))
                        
                        if (filters.Count("strObjectName") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strObjectName", ParsingHelper.CorrectLikeValue(filters.Operation("strObjectName"), filters.Value("strObjectName"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strObjectName"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strObjectName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strObjectName", i), filters.Value("strObjectName", i))));
                        }
                            
                    if (filters.Contains("idfDataAuditEvent"))
                        for (int i = 0; i < filters.Count("idfDataAuditEvent"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfDataAuditEvent_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfDataAuditEvent", i), filters.Value("idfDataAuditEvent", i))));
                      
                    if (filters.Contains("idfsObjectType"))
                        for (int i = 0; i < filters.Count("idfsObjectType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsObjectType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsObjectType", i), filters.Value("idfsObjectType", i))));
                      
                    if (filters.Contains("strObjectType"))
                        for (int i = 0; i < filters.Count("strObjectType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strObjectType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strObjectType", i), filters.Value("strObjectType", i))));
                      
                    if (filters.Contains("idfsActionName"))
                        for (int i = 0; i < filters.Count("idfsActionName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsActionName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsActionName", i), filters.Value("idfsActionName", i))));
                      
                    if (filters.Contains("strActionName"))
                        for (int i = 0; i < filters.Count("strActionName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strActionName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strActionName", i), filters.Value("strActionName", i))));
                      
                    if (filters.Contains("idfsSite"))
                        for (int i = 0; i < filters.Count("idfsSite"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsSite_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsSite", i), filters.Value("idfsSite", i))));
                      
                    if (filters.Contains("idfOffice"))
                        for (int i = 0; i < filters.Count("idfOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfOffice", i), filters.Value("idfOffice", i))));
                      
                    if (filters.Contains("strSiteID"))
                        for (int i = 0; i < filters.Count("strSiteID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSiteID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSiteID", i), filters.Value("strSiteID", i))));
                      
                    if (filters.Contains("datEnteringDate"))
                        for (int i = 0; i < filters.Count("datEnteringDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datEnteringDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datEnteringDate", i), filters.Value("datEnteringDate", i))));
                      
                    if (filters.Contains("idfMainObject"))
                        for (int i = 0; i < filters.Count("idfMainObject"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMainObject_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMainObject", i), filters.Value("idfMainObject", i))));
                      
                    if (filters.Contains("idfMainObjectTable"))
                        for (int i = 0; i < filters.Count("idfMainObjectTable"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMainObjectTable_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMainObjectTable", i), filters.Value("idfMainObjectTable", i))));
                      
                    if (filters.Contains("idfPerson"))
                        for (int i = 0; i < filters.Count("idfPerson"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfPerson_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfPerson", i), filters.Value("idfPerson", i))));
                      
                    if (filters.Contains("strPersonName"))
                        for (int i = 0; i < filters.Count("strPersonName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strPersonName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strPersonName", i), filters.Value("strPersonName", i))));
                      
                    List<DataAuditListItem> objs = manager.ExecuteList<DataAuditListItem>();
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
            partial void ListSelected(DbManagerProxy manager, List<DataAuditListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spDataAudit_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, DataAuditListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, DataAuditListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private DataAuditListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                DataAuditListItem obj = null;
                try
                {
                    obj = DataAuditListItem.CreateInstance();
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

            
            public DataAuditListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public DataAuditListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public DataAuditListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult Restore(DbManagerProxy manager, DataAuditListItem obj, List<object> pars)
            {
                
                return Restore(manager, obj
                    );
            }
            public ActResult Restore(DbManagerProxy manager, DataAuditListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("Restore"))
                    throw new PermissionException("AccessToDataAudit", "Restore");
                
              manager.SetSpCommand("dbo.spDataAudit_Restore"
                , manager.Parameter("idfDataAuditEvent", obj.idfDataAuditEvent)
                ).ExecuteNonQuery();
              return true;
            
            }
            
      
            private void _SetupChildHandlers(DataAuditListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(DataAuditListItem obj)
            {
                
            }
    
            public void LoadLookup_AuditObjectType(DbManagerProxy manager, DataAuditListItem obj)
            {
                
                obj.AuditObjectTypeLookup.Clear();
                
                obj.AuditObjectTypeLookup.Add(AuditObjectTypeAccessor.CreateNewT(manager, null));
                
                obj.AuditObjectTypeLookup.AddRange(AuditObjectTypeAccessor.rftDataAuditObjectType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsObjectType))
                    
                    .ToList());
                
                if (obj.idfsObjectType != null && obj.idfsObjectType != 0)
                {
                    obj.AuditObjectType = obj.AuditObjectTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsObjectType);
                    
                }
              
                LookupManager.AddObject("rftDataAuditObjectType", obj, AuditObjectTypeAccessor.GetType(), "rftDataAuditObjectType_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_AuditEventType(DbManagerProxy manager, DataAuditListItem obj)
            {
                
                obj.AuditEventTypeLookup.Clear();
                
                obj.AuditEventTypeLookup.Add(AuditEventTypeAccessor.CreateNewT(manager, null));
                
                obj.AuditEventTypeLookup.AddRange(AuditEventTypeAccessor.rftDataAuditEventType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsActionName))
                    
                    .ToList());
                
                if (obj.idfsActionName != null && obj.idfsActionName != 0)
                {
                    obj.AuditEventType = obj.AuditEventTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsActionName);
                    
                }
              
                LookupManager.AddObject("rftDataAuditEventType", obj, AuditEventTypeAccessor.GetType(), "rftDataAuditEventType_SelectList", "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Site(DbManagerProxy manager, DataAuditListItem obj)
            {
                
                obj.SiteLookup.Clear();
                
                obj.SiteLookup.Add(SiteAccessor.CreateNewT(manager, null));
                
                obj.SiteLookup.AddRange(SiteAccessor.SelectLookupList(manager
                    
                    )
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
            
            public void LoadLookup_Person(DbManagerProxy manager, DataAuditListItem obj)
            {
                
                obj.PersonLookup.Clear();
                
                obj.PersonLookup.Add(PersonAccessor.CreateNewT(manager, null));
                
                obj.PersonLookup.AddRange(PersonAccessor.SelectLookupList(manager
                    
                    , new Func<DataAuditListItem, long>(c => {
                                                                var siteLookups = c.SiteLookup.Where(s => s.idfsSite == c.idfsSite);
                                                                var item = siteLookups.SingleOrDefault();
                                                                if (item == null)
                                                                {
                                                                    return 0;
                                                                }
                                                                else
                                                                {
                                                                    return item.idfOffice ?? 0;
                                                                }
                                                                
                                                            })(obj)
                            
                    , null
                    , true
                    , null
                    )
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
            

            internal void _LoadLookups(DbManagerProxy manager, DataAuditListItem obj)
            {
                
                LoadLookup_AuditObjectType(manager, obj);
                
                LoadLookup_AuditEventType(manager, obj);
                
                LoadLookup_Site(manager, obj);
                
                LoadLookup_Person(manager, obj);
                
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
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        DataAuditListItem bo = obj as DataAuditListItem;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            if (!CanDelete)
                                throw new PermissionException("AccessToDataAudit", "Delete");
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            if (!CanInsert)
                                throw new PermissionException("AccessToDataAudit", "Insert");
                        }
                        else if (!bo.IsMarkedToDelete && bo.HasChanges) // update
                        {
                            if (!CanUpdate)
                                throw new PermissionException("AccessToDataAudit", "Update");
                        }
                        
                        long mainObject = bo.idfDataAuditEvent;
                        
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
                            
                            if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                            {
                                
                            }
                            else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                            {
                                
                            }
                            else if (!bo.IsMarkedToDelete) // update
                            {
                                
                            }
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as DataAuditListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, DataAuditListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfDataAuditEvent
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
            
            public bool ValidateCanDelete(DataAuditListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, DataAuditListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfDataAuditEvent
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, ValidationEventType.Error, obj);
                        }
                     }
                }
                catch(ValidationModelException ex)
                {
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                    else
                        obj.m_IsForcedToDelete = true;
                }
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(DataAuditListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(DataAuditListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as DataAuditListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, DataAuditListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToDataAudit.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToDataAudit.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToDataAudit.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToDataAudit.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(DataAuditListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(DataAuditListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as DataAuditListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as DataAuditListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "DataAuditListItemDetail"; } }
            public string HelpIdWin { get { return "Data_Audit_Management"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private DataAuditListItem m_obj;
            internal Permissions(DataAuditListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToDataAudit.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToDataAudit.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToDataAudit.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToDataAudit.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_DataAudit_SelectList";
            public static string spCount = "spDataAudit_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spReadOnlyObject_Delete";
            public static string spCanDelete = "spReadOnlyObject_CanDelete";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<DataAuditListItem, bool>> RequiredByField = new Dictionary<string, Func<DataAuditListItem, bool>>();
            public static Dictionary<string, Func<DataAuditListItem, bool>> RequiredByProperty = new Dictionary<string, Func<DataAuditListItem, bool>>();
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
                
                Sizes.Add(_str_strObjectType, 2000);
                Sizes.Add(_str_strActionName, 2000);
                Sizes.Add(_str_strSiteID, 36);
                Sizes.Add(_str_strPersonName, 400);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datEnteringDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "datTransactionDate",
                    c => DateTime.Today.AddDays(-EidssUserContext.User.Options.Prefs.DefaultDays), null, c => true, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsSite",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfsSite",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "SiteLookup", typeof(SiteLookup), (o) => { var c = (SiteLookup)o; return c.idfsSite; }, (o) => { var c = (SiteLookup)o; return c.strSiteName; }, new List<Tuple<string, string>>(){new Tuple<string, string>("strSiteName", eidss.model.Resources.EidssFields.Get("strSiteName")),new Tuple<string, string>("strSiteID", eidss.model.Resources.EidssFields.Get("strSiteID")),},false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfPerson",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strPersonName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "PersonLookup", typeof(PersonLookup), (o) => { var c = (PersonLookup)o; return c.idfPerson; }, (o) => { var c = (PersonLookup)o; return c.FullName; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsActionName",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strActionName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "AuditEventTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsObjectType",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strObjectType",
                    null, null, c => false, false, SearchPanelLocation.Main, false, "strObjectName", "AuditObjectTypeLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strObjectName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "idfObjectID",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, null, null, null, null, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfDataAuditEvent,
                    _str_idfDataAuditEvent, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datEnteringDate,
                    "datTransactionDate", "G", false, true, true, true, true, ListSortDirection.Descending
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strObjectType,
                    _str_strObjectType, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strActionName,
                    _str_strActionName, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPersonName,
                    _str_strPersonName, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSiteID,
                    "idfsSite", null, false, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "View",
                    ActionTypes.Edit,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"strView_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
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
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Restore",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).Restore(manager, (DataAuditListItem)c, pars),
                        
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
	