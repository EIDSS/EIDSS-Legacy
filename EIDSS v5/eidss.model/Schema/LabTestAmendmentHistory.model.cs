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
    public abstract partial class LabTestAmendment : 
        EditableObject<LabTestAmendment>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfTestAmendmentHistory), NonUpdatable, PrimaryKey]
        public abstract Int64 idfTestAmendmentHistory { get; set; }
                
        [LocalizedDisplayName(_str_datAmendmentDate)]
        [MapField(_str_datAmendmentDate)]
        public abstract DateTime datAmendmentDate { get; set; }
        #if MONO
        protected DateTime datAmendmentDate_Original { get { return datAmendmentDate; } }
        protected DateTime datAmendmentDate_Previous { get { return datAmendmentDate; } }
        #else
        protected DateTime datAmendmentDate_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datAmendmentDate).OriginalValue; } }
        protected DateTime datAmendmentDate_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datAmendmentDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strAmendByPerson")]
        [MapField(_str_strName)]
        public abstract String strName { get; set; }
        #if MONO
        protected String strName_Original { get { return strName; } }
        protected String strName_Previous { get { return strName; } }
        #else
        protected String strName_Original { get { return ((EditableValue<String>)((dynamic)this)._strName).OriginalValue; } }
        protected String strName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("strOfficeAmendedBy")]
        [MapField(_str_strOffice)]
        public abstract String strOffice { get; set; }
        #if MONO
        protected String strOffice_Original { get { return strOffice; } }
        protected String strOffice_Previous { get { return strOffice; } }
        #else
        protected String strOffice_Original { get { return ((EditableValue<String>)((dynamic)this)._strOffice).OriginalValue; } }
        protected String strOffice_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strOldTestResult)]
        [MapField(_str_strOldTestResult)]
        public abstract String strOldTestResult { get; set; }
        #if MONO
        protected String strOldTestResult_Original { get { return strOldTestResult; } }
        protected String strOldTestResult_Previous { get { return strOldTestResult; } }
        #else
        protected String strOldTestResult_Original { get { return ((EditableValue<String>)((dynamic)this)._strOldTestResult).OriginalValue; } }
        protected String strOldTestResult_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOldTestResult).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strNewTestResult)]
        [MapField(_str_strNewTestResult)]
        public abstract String strNewTestResult { get; set; }
        #if MONO
        protected String strNewTestResult_Original { get { return strNewTestResult; } }
        protected String strNewTestResult_Previous { get { return strNewTestResult; } }
        #else
        protected String strNewTestResult_Original { get { return ((EditableValue<String>)((dynamic)this)._strNewTestResult).OriginalValue; } }
        protected String strNewTestResult_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNewTestResult).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsOldTestResult)]
        [MapField(_str_idfsOldTestResult)]
        public abstract Int64? idfsOldTestResult { get; set; }
        #if MONO
        protected Int64? idfsOldTestResult_Original { get { return idfsOldTestResult; } }
        protected Int64? idfsOldTestResult_Previous { get { return idfsOldTestResult; } }
        #else
        protected Int64? idfsOldTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOldTestResult).OriginalValue; } }
        protected Int64? idfsOldTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOldTestResult).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsNewTestResult)]
        [MapField(_str_idfsNewTestResult)]
        public abstract Int64? idfsNewTestResult { get; set; }
        #if MONO
        protected Int64? idfsNewTestResult_Original { get { return idfsNewTestResult; } }
        protected Int64? idfsNewTestResult_Previous { get { return idfsNewTestResult; } }
        #else
        protected Int64? idfsNewTestResult_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsNewTestResult).OriginalValue; } }
        protected Int64? idfsNewTestResult_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsNewTestResult).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strOldNote)]
        [MapField(_str_strOldNote)]
        public abstract String strOldNote { get; set; }
        #if MONO
        protected String strOldNote_Original { get { return strOldNote; } }
        protected String strOldNote_Previous { get { return strOldNote; } }
        #else
        protected String strOldNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strOldNote).OriginalValue; } }
        protected String strOldNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOldNote).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strNewNote)]
        [MapField(_str_strNewNote)]
        public abstract String strNewNote { get; set; }
        #if MONO
        protected String strNewNote_Original { get { return strNewNote; } }
        protected String strNewNote_Previous { get { return strNewNote; } }
        #else
        protected String strNewNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNewNote).OriginalValue; } }
        protected String strNewNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNewNote).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strReason)]
        [MapField(_str_strReason)]
        public abstract String strReason { get; set; }
        #if MONO
        protected String strReason_Original { get { return strReason; } }
        protected String strReason_Previous { get { return strReason; } }
        #else
        protected String strReason_Original { get { return ((EditableValue<String>)((dynamic)this)._strReason).OriginalValue; } }
        protected String strReason_Previous { get { return ((EditableValue<String>)((dynamic)this)._strReason).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfTesting)]
        [MapField(_str_idfTesting)]
        public abstract Int64 idfTesting { get; set; }
        #if MONO
        protected Int64 idfTesting_Original { get { return idfTesting; } }
        protected Int64 idfTesting_Previous { get { return idfTesting; } }
        #else
        protected Int64 idfTesting_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfTesting).OriginalValue; } }
        protected Int64 idfTesting_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfTesting).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfAmendByOffice)]
        [MapField(_str_idfAmendByOffice)]
        public abstract Int64? idfAmendByOffice { get; set; }
        #if MONO
        protected Int64? idfAmendByOffice_Original { get { return idfAmendByOffice; } }
        protected Int64? idfAmendByOffice_Previous { get { return idfAmendByOffice; } }
        #else
        protected Int64? idfAmendByOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAmendByOffice).OriginalValue; } }
        protected Int64? idfAmendByOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAmendByOffice).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfAmendByPerson)]
        [MapField(_str_idfAmendByPerson)]
        public abstract Int64? idfAmendByPerson { get; set; }
        #if MONO
        protected Int64? idfAmendByPerson_Original { get { return idfAmendByPerson; } }
        protected Int64? idfAmendByPerson_Previous { get { return idfAmendByPerson; } }
        #else
        protected Int64? idfAmendByPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAmendByPerson).OriginalValue; } }
        protected Int64? idfAmendByPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfAmendByPerson).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<LabTestAmendment, object> _get_func;
            internal Action<LabTestAmendment, string> _set_func;
            internal Action<LabTestAmendment, LabTestAmendment, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfTestAmendmentHistory = "idfTestAmendmentHistory";
        internal const string _str_datAmendmentDate = "datAmendmentDate";
        internal const string _str_strName = "strName";
        internal const string _str_strOffice = "strOffice";
        internal const string _str_strOldTestResult = "strOldTestResult";
        internal const string _str_strNewTestResult = "strNewTestResult";
        internal const string _str_idfsOldTestResult = "idfsOldTestResult";
        internal const string _str_idfsNewTestResult = "idfsNewTestResult";
        internal const string _str_strOldNote = "strOldNote";
        internal const string _str_strNewNote = "strNewNote";
        internal const string _str_strReason = "strReason";
        internal const string _str_idfTesting = "idfTesting";
        internal const string _str_idfAmendByOffice = "idfAmendByOffice";
        internal const string _str_idfAmendByPerson = "idfAmendByPerson";
        internal const string _str_OldTestResult = "OldTestResult";
        internal const string _str_NewTestResult = "NewTestResult";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfTestAmendmentHistory, _type = "Int64",
              _get_func = o => o.idfTestAmendmentHistory,
              _set_func = (o, val) => { o.idfTestAmendmentHistory = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTestAmendmentHistory != c.idfTestAmendmentHistory || o.IsRIRPropChanged(_str_idfTestAmendmentHistory, c)) 
                  m.Add(_str_idfTestAmendmentHistory, o.ObjectIdent + _str_idfTestAmendmentHistory, "Int64", o.idfTestAmendmentHistory == null ? "" : o.idfTestAmendmentHistory.ToString(), o.IsReadOnly(_str_idfTestAmendmentHistory), o.IsInvisible(_str_idfTestAmendmentHistory), o.IsRequired(_str_idfTestAmendmentHistory)); }
              }, 
        
            new field_info {
              _name = _str_datAmendmentDate, _type = "DateTime",
              _get_func = o => o.datAmendmentDate,
              _set_func = (o, val) => { o.datAmendmentDate = ParsingHelper.ParseDateTime(val); },
              _compare_func = (o, c, m) => {
                if (o.datAmendmentDate != c.datAmendmentDate || o.IsRIRPropChanged(_str_datAmendmentDate, c)) 
                  m.Add(_str_datAmendmentDate, o.ObjectIdent + _str_datAmendmentDate, "DateTime", o.datAmendmentDate == null ? "" : o.datAmendmentDate.ToString(), o.IsReadOnly(_str_datAmendmentDate), o.IsInvisible(_str_datAmendmentDate), o.IsRequired(_str_datAmendmentDate)); }
              }, 
        
            new field_info {
              _name = _str_strName, _type = "String",
              _get_func = o => o.strName,
              _set_func = (o, val) => { o.strName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strName != c.strName || o.IsRIRPropChanged(_str_strName, c)) 
                  m.Add(_str_strName, o.ObjectIdent + _str_strName, "String", o.strName == null ? "" : o.strName.ToString(), o.IsReadOnly(_str_strName), o.IsInvisible(_str_strName), o.IsRequired(_str_strName)); }
              }, 
        
            new field_info {
              _name = _str_strOffice, _type = "String",
              _get_func = o => o.strOffice,
              _set_func = (o, val) => { o.strOffice = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strOffice != c.strOffice || o.IsRIRPropChanged(_str_strOffice, c)) 
                  m.Add(_str_strOffice, o.ObjectIdent + _str_strOffice, "String", o.strOffice == null ? "" : o.strOffice.ToString(), o.IsReadOnly(_str_strOffice), o.IsInvisible(_str_strOffice), o.IsRequired(_str_strOffice)); }
              }, 
        
            new field_info {
              _name = _str_strOldTestResult, _type = "String",
              _get_func = o => o.strOldTestResult,
              _set_func = (o, val) => { o.strOldTestResult = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strOldTestResult != c.strOldTestResult || o.IsRIRPropChanged(_str_strOldTestResult, c)) 
                  m.Add(_str_strOldTestResult, o.ObjectIdent + _str_strOldTestResult, "String", o.strOldTestResult == null ? "" : o.strOldTestResult.ToString(), o.IsReadOnly(_str_strOldTestResult), o.IsInvisible(_str_strOldTestResult), o.IsRequired(_str_strOldTestResult)); }
              }, 
        
            new field_info {
              _name = _str_strNewTestResult, _type = "String",
              _get_func = o => o.strNewTestResult,
              _set_func = (o, val) => { o.strNewTestResult = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNewTestResult != c.strNewTestResult || o.IsRIRPropChanged(_str_strNewTestResult, c)) 
                  m.Add(_str_strNewTestResult, o.ObjectIdent + _str_strNewTestResult, "String", o.strNewTestResult == null ? "" : o.strNewTestResult.ToString(), o.IsReadOnly(_str_strNewTestResult), o.IsInvisible(_str_strNewTestResult), o.IsRequired(_str_strNewTestResult)); }
              }, 
        
            new field_info {
              _name = _str_idfsOldTestResult, _type = "Int64?",
              _get_func = o => o.idfsOldTestResult,
              _set_func = (o, val) => { o.idfsOldTestResult = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsOldTestResult != c.idfsOldTestResult || o.IsRIRPropChanged(_str_idfsOldTestResult, c)) 
                  m.Add(_str_idfsOldTestResult, o.ObjectIdent + _str_idfsOldTestResult, "Int64?", o.idfsOldTestResult == null ? "" : o.idfsOldTestResult.ToString(), o.IsReadOnly(_str_idfsOldTestResult), o.IsInvisible(_str_idfsOldTestResult), o.IsRequired(_str_idfsOldTestResult)); }
              }, 
        
            new field_info {
              _name = _str_idfsNewTestResult, _type = "Int64?",
              _get_func = o => o.idfsNewTestResult,
              _set_func = (o, val) => { o.idfsNewTestResult = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsNewTestResult != c.idfsNewTestResult || o.IsRIRPropChanged(_str_idfsNewTestResult, c)) 
                  m.Add(_str_idfsNewTestResult, o.ObjectIdent + _str_idfsNewTestResult, "Int64?", o.idfsNewTestResult == null ? "" : o.idfsNewTestResult.ToString(), o.IsReadOnly(_str_idfsNewTestResult), o.IsInvisible(_str_idfsNewTestResult), o.IsRequired(_str_idfsNewTestResult)); }
              }, 
        
            new field_info {
              _name = _str_strOldNote, _type = "String",
              _get_func = o => o.strOldNote,
              _set_func = (o, val) => { o.strOldNote = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strOldNote != c.strOldNote || o.IsRIRPropChanged(_str_strOldNote, c)) 
                  m.Add(_str_strOldNote, o.ObjectIdent + _str_strOldNote, "String", o.strOldNote == null ? "" : o.strOldNote.ToString(), o.IsReadOnly(_str_strOldNote), o.IsInvisible(_str_strOldNote), o.IsRequired(_str_strOldNote)); }
              }, 
        
            new field_info {
              _name = _str_strNewNote, _type = "String",
              _get_func = o => o.strNewNote,
              _set_func = (o, val) => { o.strNewNote = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNewNote != c.strNewNote || o.IsRIRPropChanged(_str_strNewNote, c)) 
                  m.Add(_str_strNewNote, o.ObjectIdent + _str_strNewNote, "String", o.strNewNote == null ? "" : o.strNewNote.ToString(), o.IsReadOnly(_str_strNewNote), o.IsInvisible(_str_strNewNote), o.IsRequired(_str_strNewNote)); }
              }, 
        
            new field_info {
              _name = _str_strReason, _type = "String",
              _get_func = o => o.strReason,
              _set_func = (o, val) => { o.strReason = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strReason != c.strReason || o.IsRIRPropChanged(_str_strReason, c)) 
                  m.Add(_str_strReason, o.ObjectIdent + _str_strReason, "String", o.strReason == null ? "" : o.strReason.ToString(), o.IsReadOnly(_str_strReason), o.IsInvisible(_str_strReason), o.IsRequired(_str_strReason)); }
              }, 
        
            new field_info {
              _name = _str_idfTesting, _type = "Int64",
              _get_func = o => o.idfTesting,
              _set_func = (o, val) => { o.idfTesting = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfTesting != c.idfTesting || o.IsRIRPropChanged(_str_idfTesting, c)) 
                  m.Add(_str_idfTesting, o.ObjectIdent + _str_idfTesting, "Int64", o.idfTesting == null ? "" : o.idfTesting.ToString(), o.IsReadOnly(_str_idfTesting), o.IsInvisible(_str_idfTesting), o.IsRequired(_str_idfTesting)); }
              }, 
        
            new field_info {
              _name = _str_idfAmendByOffice, _type = "Int64?",
              _get_func = o => o.idfAmendByOffice,
              _set_func = (o, val) => { o.idfAmendByOffice = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAmendByOffice != c.idfAmendByOffice || o.IsRIRPropChanged(_str_idfAmendByOffice, c)) 
                  m.Add(_str_idfAmendByOffice, o.ObjectIdent + _str_idfAmendByOffice, "Int64?", o.idfAmendByOffice == null ? "" : o.idfAmendByOffice.ToString(), o.IsReadOnly(_str_idfAmendByOffice), o.IsInvisible(_str_idfAmendByOffice), o.IsRequired(_str_idfAmendByOffice)); }
              }, 
        
            new field_info {
              _name = _str_idfAmendByPerson, _type = "Int64?",
              _get_func = o => o.idfAmendByPerson,
              _set_func = (o, val) => { o.idfAmendByPerson = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfAmendByPerson != c.idfAmendByPerson || o.IsRIRPropChanged(_str_idfAmendByPerson, c)) 
                  m.Add(_str_idfAmendByPerson, o.ObjectIdent + _str_idfAmendByPerson, "Int64?", o.idfAmendByPerson == null ? "" : o.idfAmendByPerson.ToString(), o.IsReadOnly(_str_idfAmendByPerson), o.IsInvisible(_str_idfAmendByPerson), o.IsRequired(_str_idfAmendByPerson)); }
              }, 
        
            new field_info {
              _name = _str_OldTestResult, _type = "Lookup",
              _get_func = o => { if (o.OldTestResult == null) return null; return o.OldTestResult.idfsBaseReference; },
              _set_func = (o, val) => { o.OldTestResult = o.OldTestResultLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsOldTestResult != c.idfsOldTestResult || o.IsRIRPropChanged(_str_OldTestResult, c)) 
                  m.Add(_str_OldTestResult, o.ObjectIdent + _str_OldTestResult, "Lookup", o.idfsOldTestResult == null ? "" : o.idfsOldTestResult.ToString(), o.IsReadOnly(_str_OldTestResult), o.IsInvisible(_str_OldTestResult), o.IsRequired(_str_OldTestResult)); }
              }, 
        
            new field_info {
              _name = _str_NewTestResult, _type = "Lookup",
              _get_func = o => { if (o.NewTestResult == null) return null; return o.NewTestResult.idfsBaseReference; },
              _set_func = (o, val) => { o.NewTestResult = o.NewTestResultLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsNewTestResult != c.idfsNewTestResult || o.IsRIRPropChanged(_str_NewTestResult, c)) 
                  m.Add(_str_NewTestResult, o.ObjectIdent + _str_NewTestResult, "Lookup", o.idfsNewTestResult == null ? "" : o.idfsNewTestResult.ToString(), o.IsReadOnly(_str_NewTestResult), o.IsInvisible(_str_NewTestResult), o.IsRequired(_str_NewTestResult)); }
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
            LabTestAmendment obj = (LabTestAmendment)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsOldTestResult)]
        public BaseReference OldTestResult
        {
            get { return _OldTestResult == null ? null : ((long)_OldTestResult.Key == 0 ? null : _OldTestResult); }
            set 
            { 
                _OldTestResult = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsOldTestResult = _OldTestResult == null 
                    ? new Int64?()
                    : _OldTestResult.idfsBaseReference; 
                OnPropertyChanged(_str_OldTestResult); 
            }
        }
        private BaseReference _OldTestResult;

        
        public BaseReferenceList OldTestResultLookup
        {
            get { return _OldTestResultLookup; }
        }
        private BaseReferenceList _OldTestResultLookup = new BaseReferenceList("rftTestResult");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsNewTestResult)]
        public BaseReference NewTestResult
        {
            get { return _NewTestResult == null ? null : ((long)_NewTestResult.Key == 0 ? null : _NewTestResult); }
            set 
            { 
                _NewTestResult = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsNewTestResult = _NewTestResult == null 
                    ? new Int64?()
                    : _NewTestResult.idfsBaseReference; 
                OnPropertyChanged(_str_NewTestResult); 
            }
        }
        private BaseReference _NewTestResult;

        
        public BaseReferenceList NewTestResultLookup
        {
            get { return _NewTestResultLookup; }
        }
        private BaseReferenceList _NewTestResultLookup = new BaseReferenceList("rftTestResult");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_OldTestResult:
                    return new BvSelectList(OldTestResultLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, OldTestResult, _str_idfsOldTestResult);
            
                case _str_NewTestResult:
                    return new BvSelectList(NewTestResultLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, NewTestResult, _str_idfsNewTestResult);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "LabTestAmendment";

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
            var ret = base.Clone() as LabTestAmendment;
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
            var ret = base.Clone() as LabTestAmendment;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public LabTestAmendment CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LabTestAmendment;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfTestAmendmentHistory; } }
        public string KeyName { get { return "idfTestAmendmentHistory"; } }
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
        
            var _prev_idfsOldTestResult_OldTestResult = idfsOldTestResult;
            var _prev_idfsNewTestResult_NewTestResult = idfsNewTestResult;
            base.RejectChanges();
        
            if (_prev_idfsOldTestResult_OldTestResult != idfsOldTestResult)
            {
                _OldTestResult = _OldTestResultLookup.FirstOrDefault(c => c.idfsBaseReference == idfsOldTestResult);
            }
            if (_prev_idfsNewTestResult_NewTestResult != idfsNewTestResult)
            {
                _NewTestResult = _NewTestResultLookup.FirstOrDefault(c => c.idfsBaseReference == idfsNewTestResult);
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

      private bool IsRIRPropChanged(string fld, LabTestAmendment c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public LabTestAmendment()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LabTestAmendment_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LabTestAmendment_PropertyChanged);
        }
        private void LabTestAmendment_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LabTestAmendment).Changed(e.PropertyName);
            
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
            LabTestAmendment obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LabTestAmendment obj = this;
            
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
            
            return ReadOnly || new Func<LabTestAmendment, bool>(c => true)(this);
                
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


        public Dictionary<string, Func<LabTestAmendment, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LabTestAmendment, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LabTestAmendment, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<LabTestAmendment, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<LabTestAmendment, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<LabTestAmendment, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~LabTestAmendment()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftTestResult", this);
                
                LookupManager.RemoveObject("rftTestResult", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftTestResult")
                _getAccessor().LoadLookup_OldTestResult(manager, this);
            
            if (lookup_object == "rftTestResult")
                _getAccessor().LoadLookup_NewTestResult(manager, this);
            
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
        public class LabTestAmendmentGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfTestAmendmentHistory { get; set; }
        
            public DateTime datAmendmentDate { get; set; }
        
            public string strName { get; set; }
        
            public string strOffice { get; set; }
        
            public string strNewTestResult { get; set; }
        
            public string strReason { get; set; }
        
        }
        public partial class LabTestAmendmentGridModelList : List<LabTestAmendmentGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public LabTestAmendmentGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LabTestAmendment>, errMes);
            }
            public LabTestAmendmentGridModelList(long key, IEnumerable<LabTestAmendment> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<LabTestAmendment> items);
            private void LoadGridModelList(long key, IEnumerable<LabTestAmendment> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_datAmendmentDate,_str_strName,_str_strOffice,_str_strNewTestResult,_str_strReason};
                    
                Hiddens = new List<string> {_str_idfTestAmendmentHistory};
                Keys = new List<string> {_str_idfTestAmendmentHistory};
                Labels = new Dictionary<string, string> {{_str_datAmendmentDate, _str_datAmendmentDate},{_str_strName, "strAmendByPerson"},{_str_strOffice, "strOfficeAmendedBy"},{_str_strNewTestResult, _str_strNewTestResult},{_str_strReason, _str_strReason}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<LabTestAmendment>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LabTestAmendmentGridModel()
                {
                    ItemKey=c.idfTestAmendmentHistory,datAmendmentDate=c.datAmendmentDate,strName=c.strName,strOffice=c.strOffice,strNewTestResult=c.strNewTestResult,strReason=c.strReason
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
        : DataAccessor<LabTestAmendment>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(LabTestAmendment obj);
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
            private BaseReference.Accessor OldTestResultAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor NewTestResultAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<LabTestAmendment> SelectList(DbManagerProxy manager
                , Int64? idfTesting
                )
            {
                return _SelectList(manager
                    , idfTesting
                    , delegate(LabTestAmendment obj)
                        {
                        }
                    , delegate(LabTestAmendment obj)
                        {
                        }
                    );
            }

            
            private List<LabTestAmendment> _SelectList(DbManagerProxy manager
                , Int64? idfTesting
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<LabTestAmendment> objs = new List<LabTestAmendment>();
                    sets[0] = new MapResultSet(typeof(LabTestAmendment), objs);
                    
                    manager
                        .SetSpCommand("spLabTestAmendmentHistory_SelectDetail"
                            , manager.Parameter("@idfTesting", idfTesting)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, LabTestAmendment obj)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LabTestAmendment obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LabTestAmendment _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    LabTestAmendment obj = LabTestAmendment.CreateInstance();
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

            
            public LabTestAmendment CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public LabTestAmendment CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(LabTestAmendment obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LabTestAmendment obj)
            {
                
            }
    
            public void LoadLookup_OldTestResult(DbManagerProxy manager, LabTestAmendment obj)
            {
                
                obj.OldTestResultLookup.Clear();
                
                obj.OldTestResultLookup.Add(OldTestResultAccessor.CreateNewT(manager, null));
                
                obj.OldTestResultLookup.AddRange(OldTestResultAccessor.rftTestResult_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsOldTestResult))
                    
                    .ToList());
                
                if (obj.idfsOldTestResult != null && obj.idfsOldTestResult != 0)
                {
                    obj.OldTestResult = obj.OldTestResultLookup
                        .Where(c => c.idfsBaseReference == obj.idfsOldTestResult)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftTestResult", obj, OldTestResultAccessor.GetType(), "rftTestResult_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_NewTestResult(DbManagerProxy manager, LabTestAmendment obj)
            {
                
                obj.NewTestResultLookup.Clear();
                
                obj.NewTestResultLookup.Add(NewTestResultAccessor.CreateNewT(manager, null));
                
                obj.NewTestResultLookup.AddRange(NewTestResultAccessor.rftTestResult_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsNewTestResult))
                    
                    .ToList());
                
                if (obj.idfsNewTestResult != null && obj.idfsNewTestResult != 0)
                {
                    obj.NewTestResult = obj.NewTestResultLookup
                        .Where(c => c.idfsBaseReference == obj.idfsNewTestResult)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftTestResult", obj, NewTestResultAccessor.GetType(), "rftTestResult_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, LabTestAmendment obj)
            {
                
                LoadLookup_OldTestResult(manager, obj);
                
                LoadLookup_NewTestResult(manager, obj);
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as LabTestAmendment, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LabTestAmendment obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            private void _SetupRequired(LabTestAmendment obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LabTestAmendment obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LabTestAmendment) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LabTestAmendment) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LabTestAmendmentDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spLabTestAmendmentHistory_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LabTestAmendment, bool>> RequiredByField = new Dictionary<string, Func<LabTestAmendment, bool>>();
            public static Dictionary<string, Func<LabTestAmendment, bool>> RequiredByProperty = new Dictionary<string, Func<LabTestAmendment, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strName, 602);
                Sizes.Add(_str_strOffice, 2000);
                Sizes.Add(_str_strOldTestResult, 2000);
                Sizes.Add(_str_strNewTestResult, 2000);
                Sizes.Add(_str_strOldNote, 500);
                Sizes.Add(_str_strNewNote, 500);
                Sizes.Add(_str_strReason, 500);
                GridMeta.Add(new GridMetaItem(
                    _str_idfTestAmendmentHistory,
                    _str_idfTestAmendmentHistory, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datAmendmentDate,
                    _str_datAmendmentDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strName,
                    "strAmendByPerson", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strOffice,
                    "strOfficeAmendedBy", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNewTestResult,
                    _str_strNewTestResult, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strReason,
                    _str_strReason, null, true, true, null
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
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	