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
    public abstract partial class Personnel : 
        EditableObject<Personnel>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfPerson), NonUpdatable, PrimaryKey]
        public abstract Int64 idfPerson { get; set; }
                
        [LocalizedDisplayName(_str_idfsStaffPosition)]
        [MapField(_str_idfsStaffPosition)]
        public abstract Int64? idfsStaffPosition { get; set; }
        protected Int64? idfsStaffPosition_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStaffPosition).OriginalValue; } }
        protected Int64? idfsStaffPosition_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStaffPosition).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfInstitution)]
        [MapField(_str_idfInstitution)]
        public abstract Int64? idfInstitution { get; set; }
        protected Int64? idfInstitution_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInstitution).OriginalValue; } }
        protected Int64? idfInstitution_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfInstitution).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfDepartment)]
        [MapField(_str_idfDepartment)]
        public abstract Int64? idfDepartment { get; set; }
        protected Int64? idfDepartment_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDepartment).OriginalValue; } }
        protected Int64? idfDepartment_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfDepartment).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFamilyName)]
        [MapField(_str_strFamilyName)]
        public abstract String strFamilyName { get; set; }
        protected String strFamilyName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFamilyName).OriginalValue; } }
        protected String strFamilyName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFamilyName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFirstName)]
        [MapField(_str_strFirstName)]
        public abstract String strFirstName { get; set; }
        protected String strFirstName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).OriginalValue; } }
        protected String strFirstName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSecondName)]
        [MapField(_str_strSecondName)]
        public abstract String strSecondName { get; set; }
        protected String strSecondName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSecondName).OriginalValue; } }
        protected String strSecondName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSecondName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strContactPhone)]
        [MapField(_str_strContactPhone)]
        public abstract String strContactPhone { get; set; }
        protected String strContactPhone_Original { get { return ((EditableValue<String>)((dynamic)this)._strContactPhone).OriginalValue; } }
        protected String strContactPhone_Previous { get { return ((EditableValue<String>)((dynamic)this)._strContactPhone).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strBarcode)]
        [MapField(_str_strBarcode)]
        public abstract String strBarcode { get; set; }
        protected String strBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).OriginalValue; } }
        protected String strBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64 idfsSite { get; set; }
        protected Int64 idfsSite_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64 idfsSite_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<Personnel, object> _get_func;
            internal Action<Personnel, string> _set_func;
            internal Action<Personnel, Personnel, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfPerson = "idfPerson";
        internal const string _str_idfsStaffPosition = "idfsStaffPosition";
        internal const string _str_idfInstitution = "idfInstitution";
        internal const string _str_idfDepartment = "idfDepartment";
        internal const string _str_strFamilyName = "strFamilyName";
        internal const string _str_strFirstName = "strFirstName";
        internal const string _str_strSecondName = "strSecondName";
        internal const string _str_strContactPhone = "strContactPhone";
        internal const string _str_strBarcode = "strBarcode";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_strFullName = "strFullName";
        internal const string _str_idfSelectedPerson = "idfSelectedPerson";
        internal const string _str_Department = "Department";
        internal const string _str_Position = "Position";
        internal const string _str_Person = "Person";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfPerson, _formname = _str_idfPerson, _type = "Int64",
              _get_func = o => o.idfPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfPerson != newval) o.idfPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfPerson != c.idfPerson || o.IsRIRPropChanged(_str_idfPerson, c)) 
                  m.Add(_str_idfPerson, o.ObjectIdent + _str_idfPerson, o.ObjectIdent2 + _str_idfPerson, o.ObjectIdent3 + _str_idfPerson, "Int64", 
                    o.idfPerson == null ? "" : o.idfPerson.ToString(),                  
                  o.IsReadOnly(_str_idfPerson), o.IsInvisible(_str_idfPerson), o.IsRequired(_str_idfPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsStaffPosition, _formname = _str_idfsStaffPosition, _type = "Int64?",
              _get_func = o => o.idfsStaffPosition,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsStaffPosition != newval) 
                  o.Position = o.PositionLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsStaffPosition != newval) o.idfsStaffPosition = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsStaffPosition != c.idfsStaffPosition || o.IsRIRPropChanged(_str_idfsStaffPosition, c)) 
                  m.Add(_str_idfsStaffPosition, o.ObjectIdent + _str_idfsStaffPosition, o.ObjectIdent2 + _str_idfsStaffPosition, o.ObjectIdent3 + _str_idfsStaffPosition, "Int64?", 
                    o.idfsStaffPosition == null ? "" : o.idfsStaffPosition.ToString(),                  
                  o.IsReadOnly(_str_idfsStaffPosition), o.IsInvisible(_str_idfsStaffPosition), o.IsRequired(_str_idfsStaffPosition)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfInstitution, _formname = _str_idfInstitution, _type = "Int64?",
              _get_func = o => o.idfInstitution,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfInstitution != newval) o.idfInstitution = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfInstitution != c.idfInstitution || o.IsRIRPropChanged(_str_idfInstitution, c)) 
                  m.Add(_str_idfInstitution, o.ObjectIdent + _str_idfInstitution, o.ObjectIdent2 + _str_idfInstitution, o.ObjectIdent3 + _str_idfInstitution, "Int64?", 
                    o.idfInstitution == null ? "" : o.idfInstitution.ToString(),                  
                  o.IsReadOnly(_str_idfInstitution), o.IsInvisible(_str_idfInstitution), o.IsRequired(_str_idfInstitution)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfDepartment, _formname = _str_idfDepartment, _type = "Int64?",
              _get_func = o => o.idfDepartment,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfDepartment != newval) 
                  o.Department = o.DepartmentLookup.FirstOrDefault(c => c.idfDepartment == newval);
                if (o.idfDepartment != newval) o.idfDepartment = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfDepartment != c.idfDepartment || o.IsRIRPropChanged(_str_idfDepartment, c)) 
                  m.Add(_str_idfDepartment, o.ObjectIdent + _str_idfDepartment, o.ObjectIdent2 + _str_idfDepartment, o.ObjectIdent3 + _str_idfDepartment, "Int64?", 
                    o.idfDepartment == null ? "" : o.idfDepartment.ToString(),                  
                  o.IsReadOnly(_str_idfDepartment), o.IsInvisible(_str_idfDepartment), o.IsRequired(_str_idfDepartment)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFamilyName, _formname = _str_strFamilyName, _type = "String",
              _get_func = o => o.strFamilyName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFamilyName != newval) o.strFamilyName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFamilyName != c.strFamilyName || o.IsRIRPropChanged(_str_strFamilyName, c)) 
                  m.Add(_str_strFamilyName, o.ObjectIdent + _str_strFamilyName, o.ObjectIdent2 + _str_strFamilyName, o.ObjectIdent3 + _str_strFamilyName, "String", 
                    o.strFamilyName == null ? "" : o.strFamilyName.ToString(),                  
                  o.IsReadOnly(_str_strFamilyName), o.IsInvisible(_str_strFamilyName), o.IsRequired(_str_strFamilyName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFirstName, _formname = _str_strFirstName, _type = "String",
              _get_func = o => o.strFirstName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFirstName != newval) o.strFirstName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFirstName != c.strFirstName || o.IsRIRPropChanged(_str_strFirstName, c)) 
                  m.Add(_str_strFirstName, o.ObjectIdent + _str_strFirstName, o.ObjectIdent2 + _str_strFirstName, o.ObjectIdent3 + _str_strFirstName, "String", 
                    o.strFirstName == null ? "" : o.strFirstName.ToString(),                  
                  o.IsReadOnly(_str_strFirstName), o.IsInvisible(_str_strFirstName), o.IsRequired(_str_strFirstName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSecondName, _formname = _str_strSecondName, _type = "String",
              _get_func = o => o.strSecondName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSecondName != newval) o.strSecondName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strSecondName != c.strSecondName || o.IsRIRPropChanged(_str_strSecondName, c)) 
                  m.Add(_str_strSecondName, o.ObjectIdent + _str_strSecondName, o.ObjectIdent2 + _str_strSecondName, o.ObjectIdent3 + _str_strSecondName, "String", 
                    o.strSecondName == null ? "" : o.strSecondName.ToString(),                  
                  o.IsReadOnly(_str_strSecondName), o.IsInvisible(_str_strSecondName), o.IsRequired(_str_strSecondName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strContactPhone, _formname = _str_strContactPhone, _type = "String",
              _get_func = o => o.strContactPhone,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strContactPhone != newval) o.strContactPhone = newval; },
              _compare_func = (o, c, m) => {
                if (o.strContactPhone != c.strContactPhone || o.IsRIRPropChanged(_str_strContactPhone, c)) 
                  m.Add(_str_strContactPhone, o.ObjectIdent + _str_strContactPhone, o.ObjectIdent2 + _str_strContactPhone, o.ObjectIdent3 + _str_strContactPhone, "String", 
                    o.strContactPhone == null ? "" : o.strContactPhone.ToString(),                  
                  o.IsReadOnly(_str_strContactPhone), o.IsInvisible(_str_strContactPhone), o.IsRequired(_str_strContactPhone)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strBarcode, _formname = _str_strBarcode, _type = "String",
              _get_func = o => o.strBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strBarcode != newval) o.strBarcode = newval; },
              _compare_func = (o, c, m) => {
                if (o.strBarcode != c.strBarcode || o.IsRIRPropChanged(_str_strBarcode, c)) 
                  m.Add(_str_strBarcode, o.ObjectIdent + _str_strBarcode, o.ObjectIdent2 + _str_strBarcode, o.ObjectIdent3 + _str_strBarcode, "String", 
                    o.strBarcode == null ? "" : o.strBarcode.ToString(),                  
                  o.IsReadOnly(_str_strBarcode), o.IsInvisible(_str_strBarcode), o.IsRequired(_str_strBarcode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsSite, _formname = _str_idfsSite, _type = "Int64",
              _get_func = o => o.idfsSite,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsSite != newval) o.idfsSite = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsSite != c.idfsSite || o.IsRIRPropChanged(_str_idfsSite, c)) 
                  m.Add(_str_idfsSite, o.ObjectIdent + _str_idfsSite, o.ObjectIdent2 + _str_idfsSite, o.ObjectIdent3 + _str_idfsSite, "Int64", 
                    o.idfsSite == null ? "" : o.idfsSite.ToString(),                  
                  o.IsReadOnly(_str_idfsSite), o.IsInvisible(_str_idfsSite), o.IsRequired(_str_idfsSite)); 
                  }
              }, 
        
            new field_info {
              _name = _str_idfSelectedPerson, _formname = _str_idfSelectedPerson, _type = "long?",
              _get_func = o => o.idfSelectedPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfSelectedPerson != newval) o.idfSelectedPerson = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfSelectedPerson != c.idfSelectedPerson || o.IsRIRPropChanged(_str_idfSelectedPerson, c)) {
                  m.Add(_str_idfSelectedPerson, o.ObjectIdent + _str_idfSelectedPerson, o.ObjectIdent2 + _str_idfSelectedPerson, o.ObjectIdent3 + _str_idfSelectedPerson,  "long?", 
                    o.idfSelectedPerson == null ? "" : o.idfSelectedPerson.ToString(),                  
                    o.IsReadOnly(_str_idfSelectedPerson), o.IsInvisible(_str_idfSelectedPerson), o.IsRequired(_str_idfSelectedPerson));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_strFullName, _formname = _str_strFullName, _type = "string",
              _get_func = o => o.strFullName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strFullName != c.strFullName || o.IsRIRPropChanged(_str_strFullName, c)) {
                  m.Add(_str_strFullName, o.ObjectIdent + _str_strFullName, o.ObjectIdent2 + _str_strFullName, o.ObjectIdent3 + _str_strFullName, "string", o.strFullName == null ? "" : o.strFullName.ToString(), o.IsReadOnly(_str_strFullName), o.IsInvisible(_str_strFullName), o.IsRequired(_str_strFullName));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Department, _formname = _str_Department, _type = "Lookup",
              _get_func = o => { if (o.Department == null) return null; return o.Department.idfDepartment; },
              _set_func = (o, val) => { o.Department = o.DepartmentLookup.Where(c => c.idfDepartment.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfDepartment != c.idfDepartment || o.IsRIRPropChanged(_str_Department, c)) {
                  m.Add(_str_Department, o.ObjectIdent + _str_Department, o.ObjectIdent2 + _str_Department, o.ObjectIdent3 + _str_Department, "Lookup", o.idfDepartment == null ? "" : o.idfDepartment.ToString(), o.IsReadOnly(_str_Department), o.IsInvisible(_str_Department), o.IsRequired(_str_Department)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Department + "Lookup", _formname = _str_Department + "Lookup", _type = "LookupContent",
              _get_func = o => o.DepartmentLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Position, _formname = _str_Position, _type = "Lookup",
              _get_func = o => { if (o.Position == null) return null; return o.Position.idfsBaseReference; },
              _set_func = (o, val) => { o.Position = o.PositionLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsStaffPosition != c.idfsStaffPosition || o.IsRIRPropChanged(_str_Position, c)) {
                  m.Add(_str_Position, o.ObjectIdent + _str_Position, o.ObjectIdent2 + _str_Position, o.ObjectIdent3 + _str_Position, "Lookup", o.idfsStaffPosition == null ? "" : o.idfsStaffPosition.ToString(), o.IsReadOnly(_str_Position), o.IsInvisible(_str_Position), o.IsRequired(_str_Position)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Position + "Lookup", _formname = _str_Position + "Lookup", _type = "LookupContent",
              _get_func = o => o.PositionLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_Person, _formname = _str_Person, _type = "Lookup",
              _get_func = o => { if (o.Person == null) return null; return o.Person.idfPerson; },
              _set_func = (o, val) => { o.Person = o.PersonLookup.Where(c => c.idfPerson.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfSelectedPerson != c.idfSelectedPerson || o.IsRIRPropChanged(_str_Person, c)) {
                  m.Add(_str_Person, o.ObjectIdent + _str_Person, o.ObjectIdent2 + _str_Person, o.ObjectIdent3 + _str_Person, "Lookup", o.idfSelectedPerson == null ? "" : o.idfSelectedPerson.ToString(), o.IsReadOnly(_str_Person), o.IsInvisible(_str_Person), o.IsRequired(_str_Person)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Person + "Lookup", _formname = _str_Person + "Lookup", _type = "LookupContent",
              _get_func = o => o.PersonLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
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
            Personnel obj = (Personnel)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Department)]
        [Relation(typeof(DepartmentLookup), eidss.model.Schema.DepartmentLookup._str_idfDepartment, _str_idfDepartment)]
        public DepartmentLookup Department
        {
            get { return _Department == null ? null : ((long)_Department.Key == 0 ? null : _Department); }
            set 
            { 
                var oldVal = _Department;
                _Department = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Department != oldVal)
                {
                    if (idfDepartment != (_Department == null
                            ? new Int64?()
                            : (Int64?)_Department.idfDepartment))
                        idfDepartment = _Department == null 
                            ? new Int64?()
                            : (Int64?)_Department.idfDepartment; 
                    OnPropertyChanged(_str_Department); 
                }
            }
        }
        private DepartmentLookup _Department;

        
        public List<DepartmentLookup> DepartmentLookup
        {
            get { return _DepartmentLookup; }
        }
        private List<DepartmentLookup> _DepartmentLookup = new List<DepartmentLookup>();
            
        [LocalizedDisplayName(_str_Position)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsStaffPosition)]
        public BaseReference Position
        {
            get { return _Position == null ? null : ((long)_Position.Key == 0 ? null : _Position); }
            set 
            { 
                var oldVal = _Position;
                _Position = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Position != oldVal)
                {
                    if (idfsStaffPosition != (_Position == null
                            ? new Int64?()
                            : (Int64?)_Position.idfsBaseReference))
                        idfsStaffPosition = _Position == null 
                            ? new Int64?()
                            : (Int64?)_Position.idfsBaseReference; 
                    OnPropertyChanged(_str_Position); 
                }
            }
        }
        private BaseReference _Position;

        
        public BaseReferenceList PositionLookup
        {
            get { return _PositionLookup; }
        }
        private BaseReferenceList _PositionLookup = new BaseReferenceList("rftPosition");
            
        [LocalizedDisplayName(_str_Person)]
        [Relation(typeof(PersonLookup), eidss.model.Schema.PersonLookup._str_idfPerson, _str_idfSelectedPerson)]
        public PersonLookup Person
        {
            get { return _Person == null ? null : ((long)_Person.Key == 0 ? null : _Person); }
            set 
            { 
                var oldVal = _Person;
                _Person = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Person != oldVal)
                {
                    if (idfSelectedPerson != (_Person == null
                            ? new long?()
                            : _Person.idfPerson))
                        idfSelectedPerson = _Person == null 
                            ? new long?()
                            : _Person.idfPerson; 
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
            
                case _str_Department:
                    return new BvSelectList(DepartmentLookup, eidss.model.Schema.DepartmentLookup._str_idfDepartment, null, Department, _str_idfDepartment);
            
                case _str_Position:
                    return new BvSelectList(PositionLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Position, _str_idfsStaffPosition);
            
                case _str_Person:
                    return new BvSelectList(PersonLookup, eidss.model.Schema.PersonLookup._str_idfPerson, null, Person, _str_idfSelectedPerson);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_strFullName)]
        public string strFullName
        {
            get { return new Func<Personnel, string>(c => String.Format("{0} {1} {2}", c.strFamilyName, c.strFirstName, c.strSecondName))(this); }
            
        }
        
          [LocalizedDisplayName(_str_idfSelectedPerson)]
        public long? idfSelectedPerson
        {
            get { return m_idfSelectedPerson; }
            set { if (m_idfSelectedPerson != value) { m_idfSelectedPerson = value; OnPropertyChanged(_str_idfSelectedPerson); } }
        }
        private long? m_idfSelectedPerson;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Personnel";

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
            var ret = base.Clone() as Personnel;
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
            var ret = base.Clone() as Personnel;
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
        public Personnel CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Personnel;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfPerson; } }
        public string KeyName { get { return "idfPerson"; } }
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
        
            var _prev_idfDepartment_Department = idfDepartment;
            var _prev_idfsStaffPosition_Position = idfsStaffPosition;
            var _prev_idfSelectedPerson_Person = idfSelectedPerson;
            base.RejectChanges();
        
            if (_prev_idfDepartment_Department != idfDepartment)
            {
                _Department = _DepartmentLookup.FirstOrDefault(c => c.idfDepartment == idfDepartment);
            }
            if (_prev_idfsStaffPosition_Position != idfsStaffPosition)
            {
                _Position = _PositionLookup.FirstOrDefault(c => c.idfsBaseReference == idfsStaffPosition);
            }
            if (_prev_idfSelectedPerson_Person != idfSelectedPerson)
            {
                _Person = _PersonLookup.FirstOrDefault(c => c.idfPerson == idfSelectedPerson);
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

        private bool IsRIRPropChanged(string fld, Personnel c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public Personnel()
        {
            
            m_permissions = new Permissions(this);
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Personnel_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Personnel_PropertyChanged);
        }
        private void Personnel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Personnel).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_strFirstName)
                OnPropertyChanged(_str_strFullName);
                  
            if (e.PropertyName == _str_strSecondName)
                OnPropertyChanged(_str_strFullName);
                  
            if (e.PropertyName == _str_strFamilyName)
                OnPropertyChanged(_str_strFullName);
                  
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
            Personnel obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Personnel obj = this;
            
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

    
        private static string[] readonly_names1 = "strInstitutionName".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Personnel, bool>(c => true)(this);
            
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


        internal Dictionary<string, Func<Personnel, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Personnel, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Personnel, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Personnel, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Personnel, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<Personnel, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<Personnel, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~Personnel()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("DepartmentLookup", this);
                
                LookupManager.RemoveObject("rftPosition", this);
                
                LookupManager.RemoveObject("PersonLookup", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DepartmentLookup")
                _getAccessor().LoadLookup_Department(manager, this);
            
            if (lookup_object == "rftPosition")
                _getAccessor().LoadLookup_Position(manager, this);
            
            if (lookup_object == "PersonLookup")
                _getAccessor().LoadLookup_Person(manager, this);
            
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
        : DataAccessor<Personnel>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<Personnel>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<Personnel>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfPerson"; } }
            #endregion
        
            private delegate void on_action(Personnel obj);
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
            private DepartmentLookup.Accessor DepartmentAccessor { get { return eidss.model.Schema.DepartmentLookup.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor PositionAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private PersonLookup.Accessor PersonAccessor { get { return eidss.model.Schema.PersonLookup.Accessor.Instance(m_CS); } }
            

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
            public virtual Personnel SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual Personnel SelectByKey(DbManagerProxy manager
                , Int64? idfPerson
                )
            {
                return _SelectByKey(manager
                    , idfPerson
                    , null, null
                    );
            }
            
      
            private Personnel _SelectByKey(DbManagerProxy manager
                , Int64? idfPerson
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<Personnel> objs = new List<Personnel>();
                sets[0] = new MapResultSet(typeof(Personnel), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spPerson_SelectDetail"
                            , manager.Parameter("@idfPerson", idfPerson)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    Personnel obj = objs[0];
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, Personnel obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, Personnel obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private Personnel _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    Personnel obj = Personnel.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfPerson = (new GetNewIDExtender<Personnel>()).GetScalar(manager, obj, isFake);
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

            
            public Personnel CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Personnel CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public Personnel CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(Personnel obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Personnel obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_idfInstitution)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Person(manager, obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Department(DbManagerProxy manager, Personnel obj)
            {
                
                obj.DepartmentLookup.Clear();
                
                obj.DepartmentLookup.Add(DepartmentAccessor.CreateNewT(manager, null));
                
                obj.DepartmentLookup.AddRange(DepartmentAccessor.SelectLookupList(manager
                    
                    , new Func<Personnel, long>(c => c.idfInstitution ?? 0)(obj)
                            
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfDepartment == obj.idfDepartment))
                    
                    .ToList());
                
                if (obj.idfDepartment != null && obj.idfDepartment != 0)
                {
                    obj.Department = obj.DepartmentLookup
                        .SingleOrDefault(c => c.idfDepartment == obj.idfDepartment);
                    
                }
              
                
                LookupManager.AddObject("DepartmentLookup", obj, DepartmentAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_Position(DbManagerProxy manager, Personnel obj)
            {
                
                obj.PositionLookup.Clear();
                
                obj.PositionLookup.Add(PositionAccessor.CreateNewT(manager, null));
                
                obj.PositionLookup.AddRange(PositionAccessor.rftPosition_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsStaffPosition))
                    
                    .ToList());
                
                if (obj.idfsStaffPosition != null && obj.idfsStaffPosition != 0)
                {
                    obj.Position = obj.PositionLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsStaffPosition);
                    
                }
              
                
                LookupManager.AddObject("rftPosition", obj, PositionAccessor.GetType(), "rftPosition_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Person(DbManagerProxy manager, Personnel obj)
            {
                
                obj.PersonLookup.Clear();
                
                obj.PersonLookup.Add(PersonAccessor.CreateNewT(manager, null));
                
                obj.PersonLookup.AddRange(PersonAccessor.SelectLookupList(manager
                    
                    , new Func<Personnel, long>(c => c.idfInstitution ?? 0)(obj)
                            
                    , null
                    , false
                    , null
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfPerson == obj.idfSelectedPerson))
                    
                    .ToList());
                
                if (obj.idfSelectedPerson != null && obj.idfSelectedPerson != 0)
                {
                    obj.Person = obj.PersonLookup
                        .SingleOrDefault(c => c.idfPerson == obj.idfSelectedPerson);
                    
                }
              
                
                LookupManager.AddObject("PersonLookup", obj, PersonAccessor.GetType(), "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, Personnel obj)
            {
                
                LoadLookup_Department(manager, obj);
                
                LoadLookup_Position(manager, obj);
                
                LoadLookup_Person(manager, obj);
                
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
            
      
            protected ValidationModelException ChainsValidate(Personnel obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(Personnel obj, bool bRethrowException)
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
                return Validate(manager, obj as Personnel, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Personnel obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(Personnel obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(Personnel obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Personnel) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Personnel) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "PersonnelDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private Personnel m_obj;
            internal Permissions(Personnel obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Person.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spPerson_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Personnel, bool>> RequiredByField = new Dictionary<string, Func<Personnel, bool>>();
            public static Dictionary<string, Func<Personnel, bool>> RequiredByProperty = new Dictionary<string, Func<Personnel, bool>>();
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
                
                Sizes.Add(_str_strFamilyName, 200);
                Sizes.Add(_str_strFirstName, 200);
                Sizes.Add(_str_strSecondName, 200);
                Sizes.Add(_str_strContactPhone, 200);
                Sizes.Add(_str_strBarcode, 200);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Personnel>().Post(manager, (Personnel)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Personnel>().Post(manager, (Personnel)c), c),
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
                    (manager, c, pars) => new ActResult(((Personnel)c).MarkToDelete() && ObjectAccessor.PostInterface<Personnel>().Post(manager, (Personnel)c), c),
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
	