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
    public abstract partial class FreezerTreeLookup : 
        EditableObject<FreezerTreeLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_ID), NonUpdatable, PrimaryKey]
        public abstract Int64 ID { get; set; }
                
        [LocalizedDisplayName(_str_idfFreezer)]
        [MapField(_str_idfFreezer)]
        public abstract Int64? idfFreezer { get; set; }
        protected Int64? idfFreezer_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFreezer).OriginalValue; } }
        protected Int64? idfFreezer_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfFreezer).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFreezerName)]
        [MapField(_str_strFreezerName)]
        public abstract String strFreezerName { get; set; }
        protected String strFreezerName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFreezerName).OriginalValue; } }
        protected String strFreezerName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFreezerName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsStorageType)]
        [MapField(_str_idfsStorageType)]
        public abstract Int64? idfsStorageType { get; set; }
        protected Int64? idfsStorageType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStorageType).OriginalValue; } }
        protected Int64? idfsStorageType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStorageType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSubdivisionType)]
        [MapField(_str_idfsSubdivisionType)]
        public abstract Int64? idfsSubdivisionType { get; set; }
        protected Int64? idfsSubdivisionType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSubdivisionType).OriginalValue; } }
        protected Int64? idfsSubdivisionType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsSubdivisionType).PreviousValue; } }
                
        [LocalizedDisplayName(_str_FreezerBarcode)]
        [MapField(_str_FreezerBarcode)]
        public abstract String FreezerBarcode { get; set; }
        protected String FreezerBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._freezerBarcode).OriginalValue; } }
        protected String FreezerBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._freezerBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSubdivision)]
        [MapField(_str_idfSubdivision)]
        public abstract Int64? idfSubdivision { get; set; }
        protected Int64? idfSubdivision_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSubdivision).OriginalValue; } }
        protected Int64? idfSubdivision_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSubdivision).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfParentSubdivision)]
        [MapField(_str_idfParentSubdivision)]
        public abstract Int64? idfParentSubdivision { get; set; }
        protected Int64? idfParentSubdivision_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentSubdivision).OriginalValue; } }
        protected Int64? idfParentSubdivision_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentSubdivision).PreviousValue; } }
                
        [LocalizedDisplayName(_str_SubdivisionBarcode)]
        [MapField(_str_SubdivisionBarcode)]
        public abstract String SubdivisionBarcode { get; set; }
        protected String SubdivisionBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._subdivisionBarcode).OriginalValue; } }
        protected String SubdivisionBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._subdivisionBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_SubdivisionName)]
        [MapField(_str_SubdivisionName)]
        public abstract String SubdivisionName { get; set; }
        protected String SubdivisionName_Original { get { return ((EditableValue<String>)((dynamic)this)._subdivisionName).OriginalValue; } }
        protected String SubdivisionName_Previous { get { return ((EditableValue<String>)((dynamic)this)._subdivisionName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_FreezerNote)]
        [MapField(_str_FreezerNote)]
        public abstract String FreezerNote { get; set; }
        protected String FreezerNote_Original { get { return ((EditableValue<String>)((dynamic)this)._freezerNote).OriginalValue; } }
        protected String FreezerNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._freezerNote).PreviousValue; } }
                
        [LocalizedDisplayName(_str_SubdivisionNote)]
        [MapField(_str_SubdivisionNote)]
        public abstract String SubdivisionNote { get; set; }
        protected String SubdivisionNote_Original { get { return ((EditableValue<String>)((dynamic)this)._subdivisionNote).OriginalValue; } }
        protected String SubdivisionNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._subdivisionNote).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Path)]
        [MapField(_str_Path)]
        public abstract String Path { get; set; }
        protected String Path_Original { get { return ((EditableValue<String>)((dynamic)this)._path).OriginalValue; } }
        protected String Path_Previous { get { return ((EditableValue<String>)((dynamic)this)._path).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Level)]
        [MapField(_str_Level)]
        public abstract Int32? Level { get; set; }
        protected Int32? Level_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._level).OriginalValue; } }
        protected Int32? Level_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._level).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intCapacity)]
        [MapField(_str_intCapacity)]
        public abstract Int32? intCapacity { get; set; }
        protected Int32? intCapacity_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intCapacity).OriginalValue; } }
        protected Int32? intCapacity_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intCapacity).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intUsed)]
        [MapField(_str_intUsed)]
        public abstract Int32 intUsed { get; set; }
        protected Int32 intUsed_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intUsed).OriginalValue; } }
        protected Int32 intUsed_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intUsed).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intRowStatus)]
        [MapField(_str_intRowStatus)]
        public abstract Int32? intRowStatus { get; set; }
        protected Int32? intRowStatus_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intRowStatus).OriginalValue; } }
        protected Int32? intRowStatus_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intRowStatus).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<FreezerTreeLookup, object> _get_func;
            internal Action<FreezerTreeLookup, string> _set_func;
            internal Action<FreezerTreeLookup, FreezerTreeLookup, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_ID = "ID";
        internal const string _str_idfFreezer = "idfFreezer";
        internal const string _str_strFreezerName = "strFreezerName";
        internal const string _str_idfsStorageType = "idfsStorageType";
        internal const string _str_idfsSubdivisionType = "idfsSubdivisionType";
        internal const string _str_FreezerBarcode = "FreezerBarcode";
        internal const string _str_idfSubdivision = "idfSubdivision";
        internal const string _str_idfParentSubdivision = "idfParentSubdivision";
        internal const string _str_SubdivisionBarcode = "SubdivisionBarcode";
        internal const string _str_SubdivisionName = "SubdivisionName";
        internal const string _str_FreezerNote = "FreezerNote";
        internal const string _str_SubdivisionNote = "SubdivisionNote";
        internal const string _str_Path = "Path";
        internal const string _str_Level = "Level";
        internal const string _str_intCapacity = "intCapacity";
        internal const string _str_intUsed = "intUsed";
        internal const string _str_intRowStatus = "intRowStatus";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_ID, _formname = _str_ID, _type = "Int64",
              _get_func = o => o.ID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.ID != newval) o.ID = newval; },
              _compare_func = (o, c, m) => {
                if (o.ID != c.ID || o.IsRIRPropChanged(_str_ID, c)) 
                  m.Add(_str_ID, o.ObjectIdent + _str_ID, o.ObjectIdent2 + _str_ID, o.ObjectIdent3 + _str_ID, "Int64", 
                    o.ID == null ? "" : o.ID.ToString(),                  
                  o.IsReadOnly(_str_ID), o.IsInvisible(_str_ID), o.IsRequired(_str_ID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfFreezer, _formname = _str_idfFreezer, _type = "Int64?",
              _get_func = o => o.idfFreezer,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfFreezer != newval) o.idfFreezer = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfFreezer != c.idfFreezer || o.IsRIRPropChanged(_str_idfFreezer, c)) 
                  m.Add(_str_idfFreezer, o.ObjectIdent + _str_idfFreezer, o.ObjectIdent2 + _str_idfFreezer, o.ObjectIdent3 + _str_idfFreezer, "Int64?", 
                    o.idfFreezer == null ? "" : o.idfFreezer.ToString(),                  
                  o.IsReadOnly(_str_idfFreezer), o.IsInvisible(_str_idfFreezer), o.IsRequired(_str_idfFreezer)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFreezerName, _formname = _str_strFreezerName, _type = "String",
              _get_func = o => o.strFreezerName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFreezerName != newval) o.strFreezerName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFreezerName != c.strFreezerName || o.IsRIRPropChanged(_str_strFreezerName, c)) 
                  m.Add(_str_strFreezerName, o.ObjectIdent + _str_strFreezerName, o.ObjectIdent2 + _str_strFreezerName, o.ObjectIdent3 + _str_strFreezerName, "String", 
                    o.strFreezerName == null ? "" : o.strFreezerName.ToString(),                  
                  o.IsReadOnly(_str_strFreezerName), o.IsInvisible(_str_strFreezerName), o.IsRequired(_str_strFreezerName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsStorageType, _formname = _str_idfsStorageType, _type = "Int64?",
              _get_func = o => o.idfsStorageType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsStorageType != newval) o.idfsStorageType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsStorageType != c.idfsStorageType || o.IsRIRPropChanged(_str_idfsStorageType, c)) 
                  m.Add(_str_idfsStorageType, o.ObjectIdent + _str_idfsStorageType, o.ObjectIdent2 + _str_idfsStorageType, o.ObjectIdent3 + _str_idfsStorageType, "Int64?", 
                    o.idfsStorageType == null ? "" : o.idfsStorageType.ToString(),                  
                  o.IsReadOnly(_str_idfsStorageType), o.IsInvisible(_str_idfsStorageType), o.IsRequired(_str_idfsStorageType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSubdivisionType, _formname = _str_idfsSubdivisionType, _type = "Int64?",
              _get_func = o => o.idfsSubdivisionType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsSubdivisionType != newval) o.idfsSubdivisionType = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSubdivisionType != c.idfsSubdivisionType || o.IsRIRPropChanged(_str_idfsSubdivisionType, c)) 
                  m.Add(_str_idfsSubdivisionType, o.ObjectIdent + _str_idfsSubdivisionType, o.ObjectIdent2 + _str_idfsSubdivisionType, o.ObjectIdent3 + _str_idfsSubdivisionType, "Int64?", 
                    o.idfsSubdivisionType == null ? "" : o.idfsSubdivisionType.ToString(),                  
                  o.IsReadOnly(_str_idfsSubdivisionType), o.IsInvisible(_str_idfsSubdivisionType), o.IsRequired(_str_idfsSubdivisionType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_FreezerBarcode, _formname = _str_FreezerBarcode, _type = "String",
              _get_func = o => o.FreezerBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.FreezerBarcode != newval) o.FreezerBarcode = newval; },
              _compare_func = (o, c, m) => {
                if (o.FreezerBarcode != c.FreezerBarcode || o.IsRIRPropChanged(_str_FreezerBarcode, c)) 
                  m.Add(_str_FreezerBarcode, o.ObjectIdent + _str_FreezerBarcode, o.ObjectIdent2 + _str_FreezerBarcode, o.ObjectIdent3 + _str_FreezerBarcode, "String", 
                    o.FreezerBarcode == null ? "" : o.FreezerBarcode.ToString(),                  
                  o.IsReadOnly(_str_FreezerBarcode), o.IsInvisible(_str_FreezerBarcode), o.IsRequired(_str_FreezerBarcode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSubdivision, _formname = _str_idfSubdivision, _type = "Int64?",
              _get_func = o => o.idfSubdivision,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfSubdivision != newval) o.idfSubdivision = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfSubdivision != c.idfSubdivision || o.IsRIRPropChanged(_str_idfSubdivision, c)) 
                  m.Add(_str_idfSubdivision, o.ObjectIdent + _str_idfSubdivision, o.ObjectIdent2 + _str_idfSubdivision, o.ObjectIdent3 + _str_idfSubdivision, "Int64?", 
                    o.idfSubdivision == null ? "" : o.idfSubdivision.ToString(),                  
                  o.IsReadOnly(_str_idfSubdivision), o.IsInvisible(_str_idfSubdivision), o.IsRequired(_str_idfSubdivision)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfParentSubdivision, _formname = _str_idfParentSubdivision, _type = "Int64?",
              _get_func = o => o.idfParentSubdivision,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfParentSubdivision != newval) o.idfParentSubdivision = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfParentSubdivision != c.idfParentSubdivision || o.IsRIRPropChanged(_str_idfParentSubdivision, c)) 
                  m.Add(_str_idfParentSubdivision, o.ObjectIdent + _str_idfParentSubdivision, o.ObjectIdent2 + _str_idfParentSubdivision, o.ObjectIdent3 + _str_idfParentSubdivision, "Int64?", 
                    o.idfParentSubdivision == null ? "" : o.idfParentSubdivision.ToString(),                  
                  o.IsReadOnly(_str_idfParentSubdivision), o.IsInvisible(_str_idfParentSubdivision), o.IsRequired(_str_idfParentSubdivision)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_SubdivisionBarcode, _formname = _str_SubdivisionBarcode, _type = "String",
              _get_func = o => o.SubdivisionBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.SubdivisionBarcode != newval) o.SubdivisionBarcode = newval; },
              _compare_func = (o, c, m) => {
                if (o.SubdivisionBarcode != c.SubdivisionBarcode || o.IsRIRPropChanged(_str_SubdivisionBarcode, c)) 
                  m.Add(_str_SubdivisionBarcode, o.ObjectIdent + _str_SubdivisionBarcode, o.ObjectIdent2 + _str_SubdivisionBarcode, o.ObjectIdent3 + _str_SubdivisionBarcode, "String", 
                    o.SubdivisionBarcode == null ? "" : o.SubdivisionBarcode.ToString(),                  
                  o.IsReadOnly(_str_SubdivisionBarcode), o.IsInvisible(_str_SubdivisionBarcode), o.IsRequired(_str_SubdivisionBarcode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_SubdivisionName, _formname = _str_SubdivisionName, _type = "String",
              _get_func = o => o.SubdivisionName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.SubdivisionName != newval) o.SubdivisionName = newval; },
              _compare_func = (o, c, m) => {
                if (o.SubdivisionName != c.SubdivisionName || o.IsRIRPropChanged(_str_SubdivisionName, c)) 
                  m.Add(_str_SubdivisionName, o.ObjectIdent + _str_SubdivisionName, o.ObjectIdent2 + _str_SubdivisionName, o.ObjectIdent3 + _str_SubdivisionName, "String", 
                    o.SubdivisionName == null ? "" : o.SubdivisionName.ToString(),                  
                  o.IsReadOnly(_str_SubdivisionName), o.IsInvisible(_str_SubdivisionName), o.IsRequired(_str_SubdivisionName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_FreezerNote, _formname = _str_FreezerNote, _type = "String",
              _get_func = o => o.FreezerNote,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.FreezerNote != newval) o.FreezerNote = newval; },
              _compare_func = (o, c, m) => {
                if (o.FreezerNote != c.FreezerNote || o.IsRIRPropChanged(_str_FreezerNote, c)) 
                  m.Add(_str_FreezerNote, o.ObjectIdent + _str_FreezerNote, o.ObjectIdent2 + _str_FreezerNote, o.ObjectIdent3 + _str_FreezerNote, "String", 
                    o.FreezerNote == null ? "" : o.FreezerNote.ToString(),                  
                  o.IsReadOnly(_str_FreezerNote), o.IsInvisible(_str_FreezerNote), o.IsRequired(_str_FreezerNote)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_SubdivisionNote, _formname = _str_SubdivisionNote, _type = "String",
              _get_func = o => o.SubdivisionNote,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.SubdivisionNote != newval) o.SubdivisionNote = newval; },
              _compare_func = (o, c, m) => {
                if (o.SubdivisionNote != c.SubdivisionNote || o.IsRIRPropChanged(_str_SubdivisionNote, c)) 
                  m.Add(_str_SubdivisionNote, o.ObjectIdent + _str_SubdivisionNote, o.ObjectIdent2 + _str_SubdivisionNote, o.ObjectIdent3 + _str_SubdivisionNote, "String", 
                    o.SubdivisionNote == null ? "" : o.SubdivisionNote.ToString(),                  
                  o.IsReadOnly(_str_SubdivisionNote), o.IsInvisible(_str_SubdivisionNote), o.IsRequired(_str_SubdivisionNote)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Path, _formname = _str_Path, _type = "String",
              _get_func = o => o.Path,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.Path != newval) o.Path = newval; },
              _compare_func = (o, c, m) => {
                if (o.Path != c.Path || o.IsRIRPropChanged(_str_Path, c)) 
                  m.Add(_str_Path, o.ObjectIdent + _str_Path, o.ObjectIdent2 + _str_Path, o.ObjectIdent3 + _str_Path, "String", 
                    o.Path == null ? "" : o.Path.ToString(),                  
                  o.IsReadOnly(_str_Path), o.IsInvisible(_str_Path), o.IsRequired(_str_Path)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Level, _formname = _str_Level, _type = "Int32?",
              _get_func = o => o.Level,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.Level != newval) o.Level = newval; },
              _compare_func = (o, c, m) => {
                if (o.Level != c.Level || o.IsRIRPropChanged(_str_Level, c)) 
                  m.Add(_str_Level, o.ObjectIdent + _str_Level, o.ObjectIdent2 + _str_Level, o.ObjectIdent3 + _str_Level, "Int32?", 
                    o.Level == null ? "" : o.Level.ToString(),                  
                  o.IsReadOnly(_str_Level), o.IsInvisible(_str_Level), o.IsRequired(_str_Level)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intCapacity, _formname = _str_intCapacity, _type = "Int32?",
              _get_func = o => o.intCapacity,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intCapacity != newval) o.intCapacity = newval; },
              _compare_func = (o, c, m) => {
                if (o.intCapacity != c.intCapacity || o.IsRIRPropChanged(_str_intCapacity, c)) 
                  m.Add(_str_intCapacity, o.ObjectIdent + _str_intCapacity, o.ObjectIdent2 + _str_intCapacity, o.ObjectIdent3 + _str_intCapacity, "Int32?", 
                    o.intCapacity == null ? "" : o.intCapacity.ToString(),                  
                  o.IsReadOnly(_str_intCapacity), o.IsInvisible(_str_intCapacity), o.IsRequired(_str_intCapacity)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intUsed, _formname = _str_intUsed, _type = "Int32",
              _get_func = o => o.intUsed,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intUsed != newval) o.intUsed = newval; },
              _compare_func = (o, c, m) => {
                if (o.intUsed != c.intUsed || o.IsRIRPropChanged(_str_intUsed, c)) 
                  m.Add(_str_intUsed, o.ObjectIdent + _str_intUsed, o.ObjectIdent2 + _str_intUsed, o.ObjectIdent3 + _str_intUsed, "Int32", 
                    o.intUsed == null ? "" : o.intUsed.ToString(),                  
                  o.IsReadOnly(_str_intUsed), o.IsInvisible(_str_intUsed), o.IsRequired(_str_intUsed)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intRowStatus, _formname = _str_intRowStatus, _type = "Int32?",
              _get_func = o => o.intRowStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intRowStatus != newval) o.intRowStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.intRowStatus != c.intRowStatus || o.IsRIRPropChanged(_str_intRowStatus, c)) 
                  m.Add(_str_intRowStatus, o.ObjectIdent + _str_intRowStatus, o.ObjectIdent2 + _str_intRowStatus, o.ObjectIdent3 + _str_intRowStatus, "Int32?", 
                    o.intRowStatus == null ? "" : o.intRowStatus.ToString(),                  
                  o.IsReadOnly(_str_intRowStatus), o.IsInvisible(_str_intRowStatus), o.IsRequired(_str_intRowStatus)); 
                  }
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
            FreezerTreeLookup obj = (FreezerTreeLookup)o;
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
        internal string m_ObjectName = "FreezerTreeLookup";

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
        public override object Clone()
        {
            var ret = base.Clone() as FreezerTreeLookup;
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
            var ret = base.Clone() as FreezerTreeLookup;
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
        public FreezerTreeLookup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as FreezerTreeLookup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return ID; } }
        public string KeyName { get { return "ID"; } }
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
        public bool ReadOnly { get { return _readOnly; } set { _readOnly = value; } }
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

        private bool IsRIRPropChanged(string fld, FreezerTreeLookup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      
        public override string ToString()
        {
            return new Func<FreezerTreeLookup, string>(c => c.Path)(this);
        }
        

        public FreezerTreeLookup()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(FreezerTreeLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(FreezerTreeLookup_PropertyChanged);
        }
        private void FreezerTreeLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as FreezerTreeLookup).Changed(e.PropertyName);
            
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
            FreezerTreeLookup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            FreezerTreeLookup obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ShouldAsk);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ShouldAsk);
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


        internal Dictionary<string, Func<FreezerTreeLookup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<FreezerTreeLookup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<FreezerTreeLookup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<FreezerTreeLookup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<FreezerTreeLookup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<FreezerTreeLookup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<FreezerTreeLookup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~FreezerTreeLookup()
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
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<FreezerTreeLookup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<FreezerTreeLookup>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "ID"; } }
            #endregion
        
            private delegate void on_action(FreezerTreeLookup obj);
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
            
            public virtual List<FreezerTreeLookup> SelectLookupList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , null, null
                    );
            }
            
            public static string GetLookupTableName(string method)
            {
                return "Freezer";
            }
            
            public virtual List<FreezerTreeLookup> SelectList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , delegate(FreezerTreeLookup obj)
                        {
                        }
                    , delegate(FreezerTreeLookup obj)
                        {
                        }
                    );
            }

            
            private List<FreezerTreeLookup> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<FreezerTreeLookup> objs = new List<FreezerTreeLookup>();
                    sets[0] = new MapResultSet(typeof(FreezerTreeLookup), objs);
                    
                    manager
                        .SetSpCommand("spFreezerTree"
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, FreezerTreeLookup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, FreezerTreeLookup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private FreezerTreeLookup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    FreezerTreeLookup obj = FreezerTreeLookup.CreateInstance();
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

            
            public FreezerTreeLookup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public FreezerTreeLookup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public FreezerTreeLookup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(FreezerTreeLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(FreezerTreeLookup obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, FreezerTreeLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(FreezerTreeLookup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(FreezerTreeLookup obj, bool bRethrowException)
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
                return Validate(manager, obj as FreezerTreeLookup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, FreezerTreeLookup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(FreezerTreeLookup obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(FreezerTreeLookup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as FreezerTreeLookup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as FreezerTreeLookup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "FreezerTreeLookupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spFreezerTree";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<FreezerTreeLookup, bool>> RequiredByField = new Dictionary<string, Func<FreezerTreeLookup, bool>>();
            public static Dictionary<string, Func<FreezerTreeLookup, bool>> RequiredByProperty = new Dictionary<string, Func<FreezerTreeLookup, bool>>();
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
                
                Sizes.Add(_str_strFreezerName, 200);
                Sizes.Add(_str_FreezerBarcode, 200);
                Sizes.Add(_str_SubdivisionBarcode, 200);
                Sizes.Add(_str_SubdivisionName, 200);
                Sizes.Add(_str_FreezerNote, 200);
                Sizes.Add(_str_SubdivisionNote, 200);
                Sizes.Add(_str_Path, 200);
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
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<FreezerTreeLookup>().Post(manager, (FreezerTreeLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<FreezerTreeLookup>().Post(manager, (FreezerTreeLookup)c), c),
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
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((FreezerTreeLookup)c).MarkToDelete() && ObjectAccessor.PostInterface<FreezerTreeLookup>().Post(manager, (FreezerTreeLookup)c), c),
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
	