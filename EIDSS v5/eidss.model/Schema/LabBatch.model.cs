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
    public abstract partial class LabBatch : 
        EditableObject<LabBatch>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfBatchTest), NonUpdatable, PrimaryKey]
        public abstract Int64 idfBatchTest { get; set; }
                
        [LocalizedDisplayName(_str_strBarcode)]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        #if MONO
        protected String strBarcode_Original { get { return strBarcode; } }
        protected String strBarcode_Previous { get { return strBarcode; } }
        #else
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsBatchStatus)]
        [MapField(_str_idfsBatchStatus)]
        public abstract Int64? idfsBatchStatus { get; set; }
        #if MONO
        protected Int64? idfsBatchStatus_Original { get { return idfsBatchStatus; } }
        protected Int64? idfsBatchStatus_Previous { get { return idfsBatchStatus; } }
        #else
        protected Int64? idfsBatchStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBatchStatus).OriginalValue; } }
        protected Int64? idfsBatchStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsBatchStatus).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsTestType)]
        [MapField(_str_idfsTestType)]
        public abstract Int64? idfsTestType { get; set; }
        #if MONO
        protected Int64? idfsTestType_Original { get { return idfsTestType; } }
        protected Int64? idfsTestType_Previous { get { return idfsTestType; } }
        #else
        protected Int64? idfsTestType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestType).OriginalValue; } }
        protected Int64? idfsTestType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsTestType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_TestName)]
        [MapField(_str_TestName)]
        public abstract String TestName { get; set; }
        #if MONO
        protected String TestName_Original { get { return TestName; } }
        protected String TestName_Previous { get { return TestName; } }
        #else
        protected String TestName_Original { get { return ((EditableValue<String>)((dynamic)this)._testName).OriginalValue; } }
        protected String TestName_Previous { get { return ((EditableValue<String>)((dynamic)this)._testName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datPerformedDate)]
        [MapField(_str_datPerformedDate)]
        public abstract DateTime? datPerformedDate { get; set; }
        #if MONO
        protected DateTime? datPerformedDate_Original { get { return datPerformedDate; } }
        protected DateTime? datPerformedDate_Previous { get { return datPerformedDate; } }
        #else
        protected DateTime? datPerformedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).OriginalValue; } }
        protected DateTime? datPerformedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datPerformedDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datValidatedDate)]
        [MapField(_str_datValidatedDate)]
        public abstract DateTime? datValidatedDate { get; set; }
        #if MONO
        protected DateTime? datValidatedDate_Original { get { return datValidatedDate; } }
        protected DateTime? datValidatedDate_Previous { get { return datValidatedDate; } }
        #else
        protected DateTime? datValidatedDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datValidatedDate).OriginalValue; } }
        protected DateTime? datValidatedDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datValidatedDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfPerformedByOffice)]
        [MapField(_str_idfPerformedByOffice)]
        public abstract Int64? idfPerformedByOffice { get; set; }
        #if MONO
        protected Int64? idfPerformedByOffice_Original { get { return idfPerformedByOffice; } }
        protected Int64? idfPerformedByOffice_Previous { get { return idfPerformedByOffice; } }
        #else
        protected Int64? idfPerformedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerformedByOffice).OriginalValue; } }
        protected Int64? idfPerformedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerformedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfPerformedByPerson)]
        [MapField(_str_idfPerformedByPerson)]
        public abstract Int64? idfPerformedByPerson { get; set; }
        #if MONO
        protected Int64? idfPerformedByPerson_Original { get { return idfPerformedByPerson; } }
        protected Int64? idfPerformedByPerson_Previous { get { return idfPerformedByPerson; } }
        #else
        protected Int64? idfPerformedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerformedByPerson).OriginalValue; } }
        protected Int64? idfPerformedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerformedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfValidatedByOffice)]
        [MapField(_str_idfValidatedByOffice)]
        public abstract Int64? idfValidatedByOffice { get; set; }
        #if MONO
        protected Int64? idfValidatedByOffice_Original { get { return idfValidatedByOffice; } }
        protected Int64? idfValidatedByOffice_Previous { get { return idfValidatedByOffice; } }
        #else
        protected Int64? idfValidatedByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByOffice).OriginalValue; } }
        protected Int64? idfValidatedByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfValidatedByPerson)]
        [MapField(_str_idfValidatedByPerson)]
        public abstract Int64? idfValidatedByPerson { get; set; }
        #if MONO
        protected Int64? idfValidatedByPerson_Original { get { return idfValidatedByPerson; } }
        protected Int64? idfValidatedByPerson_Previous { get { return idfValidatedByPerson; } }
        #else
        protected Int64? idfValidatedByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByPerson).OriginalValue; } }
        protected Int64? idfValidatedByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfValidatedByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfResultEnteredByOffice)]
        [MapField(_str_idfResultEnteredByOffice)]
        public abstract Int64? idfResultEnteredByOffice { get; set; }
        #if MONO
        protected Int64? idfResultEnteredByOffice_Original { get { return idfResultEnteredByOffice; } }
        protected Int64? idfResultEnteredByOffice_Previous { get { return idfResultEnteredByOffice; } }
        #else
        protected Int64? idfResultEnteredByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfResultEnteredByOffice).OriginalValue; } }
        protected Int64? idfResultEnteredByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfResultEnteredByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfResultEnteredByPerson)]
        [MapField(_str_idfResultEnteredByPerson)]
        public abstract Int64? idfResultEnteredByPerson { get; set; }
        #if MONO
        protected Int64? idfResultEnteredByPerson_Original { get { return idfResultEnteredByPerson; } }
        protected Int64? idfResultEnteredByPerson_Previous { get { return idfResultEnteredByPerson; } }
        #else
        protected Int64? idfResultEnteredByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfResultEnteredByPerson).OriginalValue; } }
        protected Int64? idfResultEnteredByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfResultEnteredByPerson).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfObservation)]
        [MapField(_str_idfObservation)]
        public abstract Int64 idfObservation { get; set; }
        #if MONO
        protected Int64 idfObservation_Original { get { return idfObservation; } }
        protected Int64 idfObservation_Previous { get { return idfObservation; } }
        #else
        protected Int64 idfObservation_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfObservation).OriginalValue; } }
        protected Int64 idfObservation_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfObservation).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64? idfsFormTemplate { get; set; }
        #if MONO
        protected Int64? idfsFormTemplate_Original { get { return idfsFormTemplate; } }
        protected Int64? idfsFormTemplate_Previous { get { return idfsFormTemplate; } }
        #else
        protected Int64? idfsFormTemplate_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64? idfsFormTemplate_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabBatch, object> _get_func;
            internal Action<LabBatch, string> _set_func;
            internal Action<LabBatch, LabBatch, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfBatchTest = "idfBatchTest";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_idfsBatchStatus = "idfsBatchStatus";
        internal const string _str_idfsTestType = "idfsTestType";
        internal const string _str_TestName = "TestName";
        internal const string _str_datPerformedDate = "datPerformedDate";
        internal const string _str_datValidatedDate = "datValidatedDate";
        internal const string _str_idfPerformedByOffice = "idfPerformedByOffice";
        internal const string _str_idfPerformedByPerson = "idfPerformedByPerson";
        internal const string _str_idfValidatedByOffice = "idfValidatedByOffice";
        internal const string _str_idfValidatedByPerson = "idfValidatedByPerson";
        internal const string _str_idfResultEnteredByOffice = "idfResultEnteredByOffice";
        internal const string _str_idfResultEnteredByPerson = "idfResultEnteredByPerson";
        internal const string _str_idfObservation = "idfObservation";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfBatchTest, _type = "Int64",
              _get_func = o => o.idfBatchTest,
              _set_func = (o, val) => { o.idfBatchTest = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfBatchTest != c.idfBatchTest || o.IsRIRPropChanged(_str_idfBatchTest, c)) 
                  m.Add(_str_idfBatchTest, o.ObjectIdent + _str_idfBatchTest, "Int64", o.idfBatchTest == null ? "" : o.idfBatchTest.ToString(), o.IsReadOnly(_str_idfBatchTest), o.IsInvisible(_str_idfBatchTest), o.IsRequired(_str_idfBatchTest)); }
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
              _name = _str_idfsBatchStatus, _type = "Int64?",
              _get_func = o => o.idfsBatchStatus,
              _set_func = (o, val) => { o.idfsBatchStatus = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsBatchStatus != c.idfsBatchStatus || o.IsRIRPropChanged(_str_idfsBatchStatus, c)) 
                  m.Add(_str_idfsBatchStatus, o.ObjectIdent + _str_idfsBatchStatus, "Int64?", o.idfsBatchStatus == null ? "" : o.idfsBatchStatus.ToString(), o.IsReadOnly(_str_idfsBatchStatus), o.IsInvisible(_str_idfsBatchStatus), o.IsRequired(_str_idfsBatchStatus)); }
              }, 
        
            new field_info {
              _name = _str_idfsTestType, _type = "Int64?",
              _get_func = o => o.idfsTestType,
              _set_func = (o, val) => { o.idfsTestType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsTestType != c.idfsTestType || o.IsRIRPropChanged(_str_idfsTestType, c)) 
                  m.Add(_str_idfsTestType, o.ObjectIdent + _str_idfsTestType, "Int64?", o.idfsTestType == null ? "" : o.idfsTestType.ToString(), o.IsReadOnly(_str_idfsTestType), o.IsInvisible(_str_idfsTestType), o.IsRequired(_str_idfsTestType)); }
              }, 
        
            new field_info {
              _name = _str_TestName, _type = "String",
              _get_func = o => o.TestName,
              _set_func = (o, val) => { o.TestName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.TestName != c.TestName || o.IsRIRPropChanged(_str_TestName, c)) 
                  m.Add(_str_TestName, o.ObjectIdent + _str_TestName, "String", o.TestName == null ? "" : o.TestName.ToString(), o.IsReadOnly(_str_TestName), o.IsInvisible(_str_TestName), o.IsRequired(_str_TestName)); }
              }, 
        
            new field_info {
              _name = _str_datPerformedDate, _type = "DateTime?",
              _get_func = o => o.datPerformedDate,
              _set_func = (o, val) => { o.datPerformedDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datPerformedDate != c.datPerformedDate || o.IsRIRPropChanged(_str_datPerformedDate, c)) 
                  m.Add(_str_datPerformedDate, o.ObjectIdent + _str_datPerformedDate, "DateTime?", o.datPerformedDate == null ? "" : o.datPerformedDate.ToString(), o.IsReadOnly(_str_datPerformedDate), o.IsInvisible(_str_datPerformedDate), o.IsRequired(_str_datPerformedDate)); }
              }, 
        
            new field_info {
              _name = _str_datValidatedDate, _type = "DateTime?",
              _get_func = o => o.datValidatedDate,
              _set_func = (o, val) => { o.datValidatedDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datValidatedDate != c.datValidatedDate || o.IsRIRPropChanged(_str_datValidatedDate, c)) 
                  m.Add(_str_datValidatedDate, o.ObjectIdent + _str_datValidatedDate, "DateTime?", o.datValidatedDate == null ? "" : o.datValidatedDate.ToString(), o.IsReadOnly(_str_datValidatedDate), o.IsInvisible(_str_datValidatedDate), o.IsRequired(_str_datValidatedDate)); }
              }, 
        
            new field_info {
              _name = _str_idfPerformedByOffice, _type = "Int64?",
              _get_func = o => o.idfPerformedByOffice,
              _set_func = (o, val) => { o.idfPerformedByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfPerformedByOffice != c.idfPerformedByOffice || o.IsRIRPropChanged(_str_idfPerformedByOffice, c)) 
                  m.Add(_str_idfPerformedByOffice, o.ObjectIdent + _str_idfPerformedByOffice, "Int64?", o.idfPerformedByOffice == null ? "" : o.idfPerformedByOffice.ToString(), o.IsReadOnly(_str_idfPerformedByOffice), o.IsInvisible(_str_idfPerformedByOffice), o.IsRequired(_str_idfPerformedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfPerformedByPerson, _type = "Int64?",
              _get_func = o => o.idfPerformedByPerson,
              _set_func = (o, val) => { o.idfPerformedByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfPerformedByPerson != c.idfPerformedByPerson || o.IsRIRPropChanged(_str_idfPerformedByPerson, c)) 
                  m.Add(_str_idfPerformedByPerson, o.ObjectIdent + _str_idfPerformedByPerson, "Int64?", o.idfPerformedByPerson == null ? "" : o.idfPerformedByPerson.ToString(), o.IsReadOnly(_str_idfPerformedByPerson), o.IsInvisible(_str_idfPerformedByPerson), o.IsRequired(_str_idfPerformedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfValidatedByOffice, _type = "Int64?",
              _get_func = o => o.idfValidatedByOffice,
              _set_func = (o, val) => { o.idfValidatedByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfValidatedByOffice != c.idfValidatedByOffice || o.IsRIRPropChanged(_str_idfValidatedByOffice, c)) 
                  m.Add(_str_idfValidatedByOffice, o.ObjectIdent + _str_idfValidatedByOffice, "Int64?", o.idfValidatedByOffice == null ? "" : o.idfValidatedByOffice.ToString(), o.IsReadOnly(_str_idfValidatedByOffice), o.IsInvisible(_str_idfValidatedByOffice), o.IsRequired(_str_idfValidatedByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfValidatedByPerson, _type = "Int64?",
              _get_func = o => o.idfValidatedByPerson,
              _set_func = (o, val) => { o.idfValidatedByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfValidatedByPerson != c.idfValidatedByPerson || o.IsRIRPropChanged(_str_idfValidatedByPerson, c)) 
                  m.Add(_str_idfValidatedByPerson, o.ObjectIdent + _str_idfValidatedByPerson, "Int64?", o.idfValidatedByPerson == null ? "" : o.idfValidatedByPerson.ToString(), o.IsReadOnly(_str_idfValidatedByPerson), o.IsInvisible(_str_idfValidatedByPerson), o.IsRequired(_str_idfValidatedByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfResultEnteredByOffice, _type = "Int64?",
              _get_func = o => o.idfResultEnteredByOffice,
              _set_func = (o, val) => { o.idfResultEnteredByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfResultEnteredByOffice != c.idfResultEnteredByOffice || o.IsRIRPropChanged(_str_idfResultEnteredByOffice, c)) 
                  m.Add(_str_idfResultEnteredByOffice, o.ObjectIdent + _str_idfResultEnteredByOffice, "Int64?", o.idfResultEnteredByOffice == null ? "" : o.idfResultEnteredByOffice.ToString(), o.IsReadOnly(_str_idfResultEnteredByOffice), o.IsInvisible(_str_idfResultEnteredByOffice), o.IsRequired(_str_idfResultEnteredByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfResultEnteredByPerson, _type = "Int64?",
              _get_func = o => o.idfResultEnteredByPerson,
              _set_func = (o, val) => { o.idfResultEnteredByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfResultEnteredByPerson != c.idfResultEnteredByPerson || o.IsRIRPropChanged(_str_idfResultEnteredByPerson, c)) 
                  m.Add(_str_idfResultEnteredByPerson, o.ObjectIdent + _str_idfResultEnteredByPerson, "Int64?", o.idfResultEnteredByPerson == null ? "" : o.idfResultEnteredByPerson.ToString(), o.IsReadOnly(_str_idfResultEnteredByPerson), o.IsInvisible(_str_idfResultEnteredByPerson), o.IsRequired(_str_idfResultEnteredByPerson)); }
              }, 
        
            new field_info {
              _name = _str_idfObservation, _type = "Int64",
              _get_func = o => o.idfObservation,
              _set_func = (o, val) => { o.idfObservation = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfObservation != c.idfObservation || o.IsRIRPropChanged(_str_idfObservation, c)) 
                  m.Add(_str_idfObservation, o.ObjectIdent + _str_idfObservation, "Int64", o.idfObservation == null ? "" : o.idfObservation.ToString(), o.IsReadOnly(_str_idfObservation), o.IsInvisible(_str_idfObservation), o.IsRequired(_str_idfObservation)); }
              }, 
        
            new field_info {
              _name = _str_idfsFormTemplate, _type = "Int64?",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { o.idfsFormTemplate = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, "Int64?", o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(), o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); }
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
            LabBatch obj = (LabBatch)o;
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
        internal string m_ObjectName = "LabBatch";

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
            var ret = base.Clone() as LabBatch;
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
            var ret = base.Clone() as LabBatch;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabBatch CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabBatch;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfBatchTest; } }
        public string KeyName { get { return "idfBatchTest"; } }
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

      private bool IsRIRPropChanged(string fld, LabBatch c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabBatch()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabBatch_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabBatch_PropertyChanged);
        }
        private void LabBatch_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabBatch).Changed(e.PropertyName);
            
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
            LabBatch obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabBatch obj = this;
            
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


        public Dictionary<string, Func<LabBatch, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabBatch, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabBatch, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabBatch, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabBatch, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<LabBatch, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabBatch()
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
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<LabBatch>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(LabBatch obj);
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

            
            public virtual LabBatch SelectByKey(DbManagerProxy manager
                , Int64? idfBatchTest
                )
            {
                return _SelectByKey(manager
                    , idfBatchTest
                    , null, null
                    );
            }
            
      
            private LabBatch _SelectByKey(DbManagerProxy manager
                , Int64? idfBatchTest
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<LabBatch> objs = new List<LabBatch>();
                sets[0] = new MapResultSet(typeof(LabBatch), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spLabBatch_SelectDetail"
                            , manager.Parameter("@idfBatchTest", idfBatchTest)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    LabBatch obj = objs[0];
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabBatch obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabBatch obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabBatch _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabBatch obj = LabBatch.CreateInstance();
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

            
            public LabBatch CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public LabBatch CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(LabBatch obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabBatch obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, LabBatch obj)
            {
                
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
                return Validate(manager, obj as LabBatch, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabBatch obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(LabBatch obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabBatch obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabBatch) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabBatch) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabBatchDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spLabBatch_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabBatch, bool>> RequiredByField = new Dictionary<string, Func<LabBatch, bool>>();
            public static Dictionary<string, Func<LabBatch, bool>> RequiredByProperty = new Dictionary<string, Func<LabBatch, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strBarcode, 200);
                Sizes.Add(_str_TestName, 2000);
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
                    (manager, c, pars) => new ActResult(((LabBatch)c).MarkToDelete() && ObjectAccessor.PostInterface<LabBatch>().Post(manager, (LabBatch)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabBatch>().Post(manager, (LabBatch)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<LabBatch>().Post(manager, (LabBatch)c), c),
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
	