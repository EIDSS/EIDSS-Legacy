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
    public abstract partial class Patient : 
        EditableObject<Patient>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfHuman), NonUpdatable, PrimaryKey]
        public abstract Int64 idfHuman { get; set; }
                
        [LocalizedDisplayName(_str_idfRootHuman)]
        [MapField(_str_idfRootHuman)]
        public abstract Int64? idfRootHuman { get; set; }
        #if MONO
        protected Int64? idfRootHuman_Original { get { return idfRootHuman; } }
        protected Int64? idfRootHuman_Previous { get { return idfRootHuman; } }
        #else
        protected Int64? idfRootHuman_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootHuman).OriginalValue; } }
        protected Int64? idfRootHuman_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRootHuman).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64? idfCase { get; set; }
        #if MONO
        protected Int64? idfCase_Original { get { return idfCase; } }
        protected Int64? idfCase_Previous { get { return idfCase; } }
        #else
        protected Int64? idfCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64? idfCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCase).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intPatientAgeFromCase)]
        [MapField(_str_intPatientAgeFromCase)]
        public abstract Int32? intPatientAgeFromCase { get; set; }
        #if MONO
        protected Int32? intPatientAgeFromCase_Original { get { return intPatientAgeFromCase; } }
        protected Int32? intPatientAgeFromCase_Previous { get { return intPatientAgeFromCase; } }
        #else
        protected Int32? intPatientAgeFromCase_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intPatientAgeFromCase).OriginalValue; } }
        protected Int32? intPatientAgeFromCase_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intPatientAgeFromCase).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsHumanAgeTypeFromCase)]
        [MapField(_str_idfsHumanAgeTypeFromCase)]
        public abstract Int64? idfsHumanAgeTypeFromCase { get; set; }
        #if MONO
        protected Int64? idfsHumanAgeTypeFromCase_Original { get { return idfsHumanAgeTypeFromCase; } }
        protected Int64? idfsHumanAgeTypeFromCase_Previous { get { return idfsHumanAgeTypeFromCase; } }
        #else
        protected Int64? idfsHumanAgeTypeFromCase_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanAgeTypeFromCase).OriginalValue; } }
        protected Int64? idfsHumanAgeTypeFromCase_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanAgeTypeFromCase).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsOccupationType)]
        [MapField(_str_idfsOccupationType)]
        public abstract Int64? idfsOccupationType { get; set; }
        #if MONO
        protected Int64? idfsOccupationType_Original { get { return idfsOccupationType; } }
        protected Int64? idfsOccupationType_Previous { get { return idfsOccupationType; } }
        #else
        protected Int64? idfsOccupationType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOccupationType).OriginalValue; } }
        protected Int64? idfsOccupationType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOccupationType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsNationality)]
        [MapField(_str_idfsNationality)]
        public abstract Int64? idfsNationality { get; set; }
        #if MONO
        protected Int64? idfsNationality_Original { get { return idfsNationality; } }
        protected Int64? idfsNationality_Previous { get { return idfsNationality; } }
        #else
        protected Int64? idfsNationality_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsNationality).OriginalValue; } }
        protected Int64? idfsNationality_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsNationality).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsHumanGender)]
        [MapField(_str_idfsHumanGender)]
        public abstract Int64? idfsHumanGender { get; set; }
        #if MONO
        protected Int64? idfsHumanGender_Original { get { return idfsHumanGender; } }
        protected Int64? idfsHumanGender_Previous { get { return idfsHumanGender; } }
        #else
        protected Int64? idfsHumanGender_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanGender).OriginalValue; } }
        protected Int64? idfsHumanGender_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsHumanGender).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfCurrentResidenceAddress)]
        [MapField(_str_idfCurrentResidenceAddress)]
        public abstract Int64? idfCurrentResidenceAddress { get; set; }
        #if MONO
        protected Int64? idfCurrentResidenceAddress_Original { get { return idfCurrentResidenceAddress; } }
        protected Int64? idfCurrentResidenceAddress_Previous { get { return idfCurrentResidenceAddress; } }
        #else
        protected Int64? idfCurrentResidenceAddress_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCurrentResidenceAddress).OriginalValue; } }
        protected Int64? idfCurrentResidenceAddress_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfCurrentResidenceAddress).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfEmployerAddress)]
        [MapField(_str_idfEmployerAddress)]
        public abstract Int64? idfEmployerAddress { get; set; }
        #if MONO
        protected Int64? idfEmployerAddress_Original { get { return idfEmployerAddress; } }
        protected Int64? idfEmployerAddress_Previous { get { return idfEmployerAddress; } }
        #else
        protected Int64? idfEmployerAddress_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfEmployerAddress).OriginalValue; } }
        protected Int64? idfEmployerAddress_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfEmployerAddress).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfRegistrationAddress)]
        [MapField(_str_idfRegistrationAddress)]
        public abstract Int64? idfRegistrationAddress { get; set; }
        #if MONO
        protected Int64? idfRegistrationAddress_Original { get { return idfRegistrationAddress; } }
        protected Int64? idfRegistrationAddress_Previous { get { return idfRegistrationAddress; } }
        #else
        protected Int64? idfRegistrationAddress_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRegistrationAddress).OriginalValue; } }
        protected Int64? idfRegistrationAddress_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfRegistrationAddress).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datDateofBirth)]
        [MapField(_str_datDateofBirth)]
        public abstract DateTime? datDateofBirth { get; set; }
        #if MONO
        protected DateTime? datDateofBirth_Original { get { return datDateofBirth; } }
        protected DateTime? datDateofBirth_Previous { get { return datDateofBirth; } }
        #else
        protected DateTime? datDateofBirth_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateofBirth).OriginalValue; } }
        protected DateTime? datDateofBirth_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateofBirth).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datDateOfDeath)]
        [MapField(_str_datDateOfDeath)]
        public abstract DateTime? datDateOfDeath { get; set; }
        #if MONO
        protected DateTime? datDateOfDeath_Original { get { return datDateOfDeath; } }
        protected DateTime? datDateOfDeath_Previous { get { return datDateOfDeath; } }
        #else
        protected DateTime? datDateOfDeath_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateOfDeath).OriginalValue; } }
        protected DateTime? datDateOfDeath_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateOfDeath).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strLastName)]
        [MapField(_str_strLastName)]
        public abstract String strLastName { get; set; }
        #if MONO
        protected String strLastName_Original { get { return strLastName; } }
        protected String strLastName_Previous { get { return strLastName; } }
        #else
        protected String strLastName_Original { get { return ((EditableValue<String>)((dynamic)this)._strLastName).OriginalValue; } }
        protected String strLastName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strLastName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strSecondName)]
        [MapField(_str_strSecondName)]
        public abstract String strSecondName { get; set; }
        #if MONO
        protected String strSecondName_Original { get { return strSecondName; } }
        protected String strSecondName_Previous { get { return strSecondName; } }
        #else
        protected String strSecondName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSecondName).OriginalValue; } }
        protected String strSecondName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSecondName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strFirstName)]
        [MapField(_str_strFirstName)]
        public abstract String strFirstName { get; set; }
        #if MONO
        protected String strFirstName_Original { get { return strFirstName; } }
        protected String strFirstName_Previous { get { return strFirstName; } }
        #else
        protected String strFirstName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).OriginalValue; } }
        protected String strFirstName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFirstName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strRegistrationPhone)]
        [MapField(_str_strRegistrationPhone)]
        public abstract String strRegistrationPhone { get; set; }
        #if MONO
        protected String strRegistrationPhone_Original { get { return strRegistrationPhone; } }
        protected String strRegistrationPhone_Previous { get { return strRegistrationPhone; } }
        #else
        protected String strRegistrationPhone_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegistrationPhone).OriginalValue; } }
        protected String strRegistrationPhone_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegistrationPhone).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strEmployerName)]
        [MapField(_str_strEmployerName)]
        public abstract String strEmployerName { get; set; }
        #if MONO
        protected String strEmployerName_Original { get { return strEmployerName; } }
        protected String strEmployerName_Previous { get { return strEmployerName; } }
        #else
        protected String strEmployerName_Original { get { return ((EditableValue<String>)((dynamic)this)._strEmployerName).OriginalValue; } }
        protected String strEmployerName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEmployerName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strHomePhone)]
        [MapField(_str_strHomePhone)]
        public abstract String strHomePhone { get; set; }
        #if MONO
        protected String strHomePhone_Original { get { return strHomePhone; } }
        protected String strHomePhone_Previous { get { return strHomePhone; } }
        #else
        protected String strHomePhone_Original { get { return ((EditableValue<String>)((dynamic)this)._strHomePhone).OriginalValue; } }
        protected String strHomePhone_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHomePhone).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strWorkPhone)]
        [MapField(_str_strWorkPhone)]
        public abstract String strWorkPhone { get; set; }
        #if MONO
        protected String strWorkPhone_Original { get { return strWorkPhone; } }
        protected String strWorkPhone_Previous { get { return strWorkPhone; } }
        #else
        protected String strWorkPhone_Original { get { return ((EditableValue<String>)((dynamic)this)._strWorkPhone).OriginalValue; } }
        protected String strWorkPhone_Previous { get { return ((EditableValue<String>)((dynamic)this)._strWorkPhone).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<Patient, object> _get_func;
            internal Action<Patient, string> _set_func;
            internal Action<Patient, Patient, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfHuman = "idfHuman";
        internal const string _str_idfRootHuman = "idfRootHuman";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_intPatientAgeFromCase = "intPatientAgeFromCase";
        internal const string _str_idfsHumanAgeTypeFromCase = "idfsHumanAgeTypeFromCase";
        internal const string _str_idfsOccupationType = "idfsOccupationType";
        internal const string _str_idfsNationality = "idfsNationality";
        internal const string _str_idfsHumanGender = "idfsHumanGender";
        internal const string _str_idfCurrentResidenceAddress = "idfCurrentResidenceAddress";
        internal const string _str_idfEmployerAddress = "idfEmployerAddress";
        internal const string _str_idfRegistrationAddress = "idfRegistrationAddress";
        internal const string _str_datDateofBirth = "datDateofBirth";
        internal const string _str_datDateOfDeath = "datDateOfDeath";
        internal const string _str_strLastName = "strLastName";
        internal const string _str_strSecondName = "strSecondName";
        internal const string _str_strFirstName = "strFirstName";
        internal const string _str_strRegistrationPhone = "strRegistrationPhone";
        internal const string _str_strEmployerName = "strEmployerName";
        internal const string _str_strHomePhone = "strHomePhone";
        internal const string _str_strWorkPhone = "strWorkPhone";
        internal const string _str_HCase = "HCase";
        internal const string _str_strName = "strName";
        internal const string _str_IsReadOnlyParent = "IsReadOnlyParent";
        internal const string _str_strReadOnlyLastName = "strReadOnlyLastName";
        internal const string _str_strReadOnlyFirstName = "strReadOnlyFirstName";
        internal const string _str_strReadOnlySecondName = "strReadOnlySecondName";
        internal const string _str_strReadOnlyDateofBirth = "strReadOnlyDateofBirth";
        internal const string _str_strReadOnlyHumanGender = "strReadOnlyHumanGender";
        internal const string _str_strReadOnlyNationality = "strReadOnlyNationality";
        internal const string _str_strReadOnlyEmployerName = "strReadOnlyEmployerName";
        internal const string _str_OccupationType = "OccupationType";
        internal const string _str_Nationality = "Nationality";
        internal const string _str_Gender = "Gender";
        internal const string _str_HumanAgeType = "HumanAgeType";
        internal const string _str_CurrentResidenceAddress = "CurrentResidenceAddress";
        internal const string _str_EmployerAddress = "EmployerAddress";
        internal const string _str_RegistrationAddress = "RegistrationAddress";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfHuman, _type = "Int64",
              _get_func = o => o.idfHuman,
              _set_func = (o, val) => { o.idfHuman = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfHuman != c.idfHuman || o.IsRIRPropChanged(_str_idfHuman, c)) 
                  m.Add(_str_idfHuman, o.ObjectIdent + _str_idfHuman, "Int64", o.idfHuman == null ? "" : o.idfHuman.ToString(), o.IsReadOnly(_str_idfHuman), o.IsInvisible(_str_idfHuman), o.IsRequired(_str_idfHuman)); }
              }, 
        
            new field_info {
              _name = _str_idfRootHuman, _type = "Int64?",
              _get_func = o => o.idfRootHuman,
              _set_func = (o, val) => { o.idfRootHuman = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfRootHuman != c.idfRootHuman || o.IsRIRPropChanged(_str_idfRootHuman, c)) 
                  m.Add(_str_idfRootHuman, o.ObjectIdent + _str_idfRootHuman, "Int64?", o.idfRootHuman == null ? "" : o.idfRootHuman.ToString(), o.IsReadOnly(_str_idfRootHuman), o.IsInvisible(_str_idfRootHuman), o.IsRequired(_str_idfRootHuman)); }
              }, 
        
            new field_info {
              _name = _str_idfCase, _type = "Int64?",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { o.idfCase = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, "Int64?", o.idfCase == null ? "" : o.idfCase.ToString(), o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); }
              }, 
        
            new field_info {
              _name = _str_intPatientAgeFromCase, _type = "Int32?",
              _get_func = o => o.intPatientAgeFromCase,
              _set_func = (o, val) => { o.intPatientAgeFromCase = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intPatientAgeFromCase != c.intPatientAgeFromCase || o.IsRIRPropChanged(_str_intPatientAgeFromCase, c)) 
                  m.Add(_str_intPatientAgeFromCase, o.ObjectIdent + _str_intPatientAgeFromCase, "Int32?", o.intPatientAgeFromCase == null ? "" : o.intPatientAgeFromCase.ToString(), o.IsReadOnly(_str_intPatientAgeFromCase), o.IsInvisible(_str_intPatientAgeFromCase), o.IsRequired(_str_intPatientAgeFromCase)); }
              }, 
        
            new field_info {
              _name = _str_idfsHumanAgeTypeFromCase, _type = "Int64?",
              _get_func = o => o.idfsHumanAgeTypeFromCase,
              _set_func = (o, val) => { o.idfsHumanAgeTypeFromCase = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsHumanAgeTypeFromCase != c.idfsHumanAgeTypeFromCase || o.IsRIRPropChanged(_str_idfsHumanAgeTypeFromCase, c)) 
                  m.Add(_str_idfsHumanAgeTypeFromCase, o.ObjectIdent + _str_idfsHumanAgeTypeFromCase, "Int64?", o.idfsHumanAgeTypeFromCase == null ? "" : o.idfsHumanAgeTypeFromCase.ToString(), o.IsReadOnly(_str_idfsHumanAgeTypeFromCase), o.IsInvisible(_str_idfsHumanAgeTypeFromCase), o.IsRequired(_str_idfsHumanAgeTypeFromCase)); }
              }, 
        
            new field_info {
              _name = _str_idfsOccupationType, _type = "Int64?",
              _get_func = o => o.idfsOccupationType,
              _set_func = (o, val) => { o.idfsOccupationType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsOccupationType != c.idfsOccupationType || o.IsRIRPropChanged(_str_idfsOccupationType, c)) 
                  m.Add(_str_idfsOccupationType, o.ObjectIdent + _str_idfsOccupationType, "Int64?", o.idfsOccupationType == null ? "" : o.idfsOccupationType.ToString(), o.IsReadOnly(_str_idfsOccupationType), o.IsInvisible(_str_idfsOccupationType), o.IsRequired(_str_idfsOccupationType)); }
              }, 
        
            new field_info {
              _name = _str_idfsNationality, _type = "Int64?",
              _get_func = o => o.idfsNationality,
              _set_func = (o, val) => { o.idfsNationality = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsNationality != c.idfsNationality || o.IsRIRPropChanged(_str_idfsNationality, c)) 
                  m.Add(_str_idfsNationality, o.ObjectIdent + _str_idfsNationality, "Int64?", o.idfsNationality == null ? "" : o.idfsNationality.ToString(), o.IsReadOnly(_str_idfsNationality), o.IsInvisible(_str_idfsNationality), o.IsRequired(_str_idfsNationality)); }
              }, 
        
            new field_info {
              _name = _str_idfsHumanGender, _type = "Int64?",
              _get_func = o => o.idfsHumanGender,
              _set_func = (o, val) => { o.idfsHumanGender = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsHumanGender != c.idfsHumanGender || o.IsRIRPropChanged(_str_idfsHumanGender, c)) 
                  m.Add(_str_idfsHumanGender, o.ObjectIdent + _str_idfsHumanGender, "Int64?", o.idfsHumanGender == null ? "" : o.idfsHumanGender.ToString(), o.IsReadOnly(_str_idfsHumanGender), o.IsInvisible(_str_idfsHumanGender), o.IsRequired(_str_idfsHumanGender)); }
              }, 
        
            new field_info {
              _name = _str_idfCurrentResidenceAddress, _type = "Int64?",
              _get_func = o => o.idfCurrentResidenceAddress,
              _set_func = (o, val) => { o.idfCurrentResidenceAddress = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfCurrentResidenceAddress != c.idfCurrentResidenceAddress || o.IsRIRPropChanged(_str_idfCurrentResidenceAddress, c)) 
                  m.Add(_str_idfCurrentResidenceAddress, o.ObjectIdent + _str_idfCurrentResidenceAddress, "Int64?", o.idfCurrentResidenceAddress == null ? "" : o.idfCurrentResidenceAddress.ToString(), o.IsReadOnly(_str_idfCurrentResidenceAddress), o.IsInvisible(_str_idfCurrentResidenceAddress), o.IsRequired(_str_idfCurrentResidenceAddress)); }
              }, 
        
            new field_info {
              _name = _str_idfEmployerAddress, _type = "Int64?",
              _get_func = o => o.idfEmployerAddress,
              _set_func = (o, val) => { o.idfEmployerAddress = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfEmployerAddress != c.idfEmployerAddress || o.IsRIRPropChanged(_str_idfEmployerAddress, c)) 
                  m.Add(_str_idfEmployerAddress, o.ObjectIdent + _str_idfEmployerAddress, "Int64?", o.idfEmployerAddress == null ? "" : o.idfEmployerAddress.ToString(), o.IsReadOnly(_str_idfEmployerAddress), o.IsInvisible(_str_idfEmployerAddress), o.IsRequired(_str_idfEmployerAddress)); }
              }, 
        
            new field_info {
              _name = _str_idfRegistrationAddress, _type = "Int64?",
              _get_func = o => o.idfRegistrationAddress,
              _set_func = (o, val) => { o.idfRegistrationAddress = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfRegistrationAddress != c.idfRegistrationAddress || o.IsRIRPropChanged(_str_idfRegistrationAddress, c)) 
                  m.Add(_str_idfRegistrationAddress, o.ObjectIdent + _str_idfRegistrationAddress, "Int64?", o.idfRegistrationAddress == null ? "" : o.idfRegistrationAddress.ToString(), o.IsReadOnly(_str_idfRegistrationAddress), o.IsInvisible(_str_idfRegistrationAddress), o.IsRequired(_str_idfRegistrationAddress)); }
              }, 
        
            new field_info {
              _name = _str_datDateofBirth, _type = "DateTime?",
              _get_func = o => o.datDateofBirth,
              _set_func = (o, val) => { o.datDateofBirth = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datDateofBirth != c.datDateofBirth || o.IsRIRPropChanged(_str_datDateofBirth, c)) 
                  m.Add(_str_datDateofBirth, o.ObjectIdent + _str_datDateofBirth, "DateTime?", o.datDateofBirth == null ? "" : o.datDateofBirth.ToString(), o.IsReadOnly(_str_datDateofBirth), o.IsInvisible(_str_datDateofBirth), o.IsRequired(_str_datDateofBirth)); }
              }, 
        
            new field_info {
              _name = _str_datDateOfDeath, _type = "DateTime?",
              _get_func = o => o.datDateOfDeath,
              _set_func = (o, val) => { o.datDateOfDeath = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datDateOfDeath != c.datDateOfDeath || o.IsRIRPropChanged(_str_datDateOfDeath, c)) 
                  m.Add(_str_datDateOfDeath, o.ObjectIdent + _str_datDateOfDeath, "DateTime?", o.datDateOfDeath == null ? "" : o.datDateOfDeath.ToString(), o.IsReadOnly(_str_datDateOfDeath), o.IsInvisible(_str_datDateOfDeath), o.IsRequired(_str_datDateOfDeath)); }
              }, 
        
            new field_info {
              _name = _str_strLastName, _type = "String",
              _get_func = o => o.strLastName,
              _set_func = (o, val) => { o.strLastName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strLastName != c.strLastName || o.IsRIRPropChanged(_str_strLastName, c)) 
                  m.Add(_str_strLastName, o.ObjectIdent + _str_strLastName, "String", o.strLastName == null ? "" : o.strLastName.ToString(), o.IsReadOnly(_str_strLastName), o.IsInvisible(_str_strLastName), o.IsRequired(_str_strLastName)); }
              }, 
        
            new field_info {
              _name = _str_strSecondName, _type = "String",
              _get_func = o => o.strSecondName,
              _set_func = (o, val) => { o.strSecondName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strSecondName != c.strSecondName || o.IsRIRPropChanged(_str_strSecondName, c)) 
                  m.Add(_str_strSecondName, o.ObjectIdent + _str_strSecondName, "String", o.strSecondName == null ? "" : o.strSecondName.ToString(), o.IsReadOnly(_str_strSecondName), o.IsInvisible(_str_strSecondName), o.IsRequired(_str_strSecondName)); }
              }, 
        
            new field_info {
              _name = _str_strFirstName, _type = "String",
              _get_func = o => o.strFirstName,
              _set_func = (o, val) => { o.strFirstName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFirstName != c.strFirstName || o.IsRIRPropChanged(_str_strFirstName, c)) 
                  m.Add(_str_strFirstName, o.ObjectIdent + _str_strFirstName, "String", o.strFirstName == null ? "" : o.strFirstName.ToString(), o.IsReadOnly(_str_strFirstName), o.IsInvisible(_str_strFirstName), o.IsRequired(_str_strFirstName)); }
              }, 
        
            new field_info {
              _name = _str_strRegistrationPhone, _type = "String",
              _get_func = o => o.strRegistrationPhone,
              _set_func = (o, val) => { o.strRegistrationPhone = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strRegistrationPhone != c.strRegistrationPhone || o.IsRIRPropChanged(_str_strRegistrationPhone, c)) 
                  m.Add(_str_strRegistrationPhone, o.ObjectIdent + _str_strRegistrationPhone, "String", o.strRegistrationPhone == null ? "" : o.strRegistrationPhone.ToString(), o.IsReadOnly(_str_strRegistrationPhone), o.IsInvisible(_str_strRegistrationPhone), o.IsRequired(_str_strRegistrationPhone)); }
              }, 
        
            new field_info {
              _name = _str_strEmployerName, _type = "String",
              _get_func = o => o.strEmployerName,
              _set_func = (o, val) => { o.strEmployerName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strEmployerName != c.strEmployerName || o.IsRIRPropChanged(_str_strEmployerName, c)) 
                  m.Add(_str_strEmployerName, o.ObjectIdent + _str_strEmployerName, "String", o.strEmployerName == null ? "" : o.strEmployerName.ToString(), o.IsReadOnly(_str_strEmployerName), o.IsInvisible(_str_strEmployerName), o.IsRequired(_str_strEmployerName)); }
              }, 
        
            new field_info {
              _name = _str_strHomePhone, _type = "String",
              _get_func = o => o.strHomePhone,
              _set_func = (o, val) => { o.strHomePhone = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strHomePhone != c.strHomePhone || o.IsRIRPropChanged(_str_strHomePhone, c)) 
                  m.Add(_str_strHomePhone, o.ObjectIdent + _str_strHomePhone, "String", o.strHomePhone == null ? "" : o.strHomePhone.ToString(), o.IsReadOnly(_str_strHomePhone), o.IsInvisible(_str_strHomePhone), o.IsRequired(_str_strHomePhone)); }
              }, 
        
            new field_info {
              _name = _str_strWorkPhone, _type = "String",
              _get_func = o => o.strWorkPhone,
              _set_func = (o, val) => { o.strWorkPhone = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strWorkPhone != c.strWorkPhone || o.IsRIRPropChanged(_str_strWorkPhone, c)) 
                  m.Add(_str_strWorkPhone, o.ObjectIdent + _str_strWorkPhone, "String", o.strWorkPhone == null ? "" : o.strWorkPhone.ToString(), o.IsReadOnly(_str_strWorkPhone), o.IsInvisible(_str_strWorkPhone), o.IsRequired(_str_strWorkPhone)); }
              }, 
        
            new field_info {
              _name = _str_HCase, _type = "HumanCase",
              _get_func = o => o.HCase,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
               }
              }, 
        
            new field_info {
              _name = _str_strName, _type = "string",
              _get_func = o => o.strName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strName != c.strName || o.IsRIRPropChanged(_str_strName, c)) 
                  m.Add(_str_strName, o.ObjectIdent + _str_strName, "string", o.strName == null ? "" : o.strName.ToString(), o.IsReadOnly(_str_strName), o.IsInvisible(_str_strName), o.IsRequired(_str_strName));
                 }
              }, 
        
            new field_info {
              _name = _str_IsReadOnlyParent, _type = "bool",
              _get_func = o => o.IsReadOnlyParent,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.IsReadOnlyParent != c.IsReadOnlyParent || o.IsRIRPropChanged(_str_IsReadOnlyParent, c)) 
                  m.Add(_str_IsReadOnlyParent, o.ObjectIdent + _str_IsReadOnlyParent, "bool", o.IsReadOnlyParent == null ? "" : o.IsReadOnlyParent.ToString(), o.IsReadOnly(_str_IsReadOnlyParent), o.IsInvisible(_str_IsReadOnlyParent), o.IsRequired(_str_IsReadOnlyParent));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyLastName, _type = "string",
              _get_func = o => o.strReadOnlyLastName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyLastName != c.strReadOnlyLastName || o.IsRIRPropChanged(_str_strReadOnlyLastName, c)) 
                  m.Add(_str_strReadOnlyLastName, o.ObjectIdent + _str_strReadOnlyLastName, "string", o.strReadOnlyLastName == null ? "" : o.strReadOnlyLastName.ToString(), o.IsReadOnly(_str_strReadOnlyLastName), o.IsInvisible(_str_strReadOnlyLastName), o.IsRequired(_str_strReadOnlyLastName));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyFirstName, _type = "string",
              _get_func = o => o.strReadOnlyFirstName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyFirstName != c.strReadOnlyFirstName || o.IsRIRPropChanged(_str_strReadOnlyFirstName, c)) 
                  m.Add(_str_strReadOnlyFirstName, o.ObjectIdent + _str_strReadOnlyFirstName, "string", o.strReadOnlyFirstName == null ? "" : o.strReadOnlyFirstName.ToString(), o.IsReadOnly(_str_strReadOnlyFirstName), o.IsInvisible(_str_strReadOnlyFirstName), o.IsRequired(_str_strReadOnlyFirstName));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlySecondName, _type = "string",
              _get_func = o => o.strReadOnlySecondName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlySecondName != c.strReadOnlySecondName || o.IsRIRPropChanged(_str_strReadOnlySecondName, c)) 
                  m.Add(_str_strReadOnlySecondName, o.ObjectIdent + _str_strReadOnlySecondName, "string", o.strReadOnlySecondName == null ? "" : o.strReadOnlySecondName.ToString(), o.IsReadOnly(_str_strReadOnlySecondName), o.IsInvisible(_str_strReadOnlySecondName), o.IsRequired(_str_strReadOnlySecondName));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyDateofBirth, _type = "string",
              _get_func = o => o.strReadOnlyDateofBirth,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyDateofBirth != c.strReadOnlyDateofBirth || o.IsRIRPropChanged(_str_strReadOnlyDateofBirth, c)) 
                  m.Add(_str_strReadOnlyDateofBirth, o.ObjectIdent + _str_strReadOnlyDateofBirth, "string", o.strReadOnlyDateofBirth == null ? "" : o.strReadOnlyDateofBirth.ToString(), o.IsReadOnly(_str_strReadOnlyDateofBirth), o.IsInvisible(_str_strReadOnlyDateofBirth), o.IsRequired(_str_strReadOnlyDateofBirth));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyHumanGender, _type = "string",
              _get_func = o => o.strReadOnlyHumanGender,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyHumanGender != c.strReadOnlyHumanGender || o.IsRIRPropChanged(_str_strReadOnlyHumanGender, c)) 
                  m.Add(_str_strReadOnlyHumanGender, o.ObjectIdent + _str_strReadOnlyHumanGender, "string", o.strReadOnlyHumanGender == null ? "" : o.strReadOnlyHumanGender.ToString(), o.IsReadOnly(_str_strReadOnlyHumanGender), o.IsInvisible(_str_strReadOnlyHumanGender), o.IsRequired(_str_strReadOnlyHumanGender));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyNationality, _type = "string",
              _get_func = o => o.strReadOnlyNationality,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyNationality != c.strReadOnlyNationality || o.IsRIRPropChanged(_str_strReadOnlyNationality, c)) 
                  m.Add(_str_strReadOnlyNationality, o.ObjectIdent + _str_strReadOnlyNationality, "string", o.strReadOnlyNationality == null ? "" : o.strReadOnlyNationality.ToString(), o.IsReadOnly(_str_strReadOnlyNationality), o.IsInvisible(_str_strReadOnlyNationality), o.IsRequired(_str_strReadOnlyNationality));
                 }
              }, 
        
            new field_info {
              _name = _str_strReadOnlyEmployerName, _type = "string",
              _get_func = o => o.strReadOnlyEmployerName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strReadOnlyEmployerName != c.strReadOnlyEmployerName || o.IsRIRPropChanged(_str_strReadOnlyEmployerName, c)) 
                  m.Add(_str_strReadOnlyEmployerName, o.ObjectIdent + _str_strReadOnlyEmployerName, "string", o.strReadOnlyEmployerName == null ? "" : o.strReadOnlyEmployerName.ToString(), o.IsReadOnly(_str_strReadOnlyEmployerName), o.IsInvisible(_str_strReadOnlyEmployerName), o.IsRequired(_str_strReadOnlyEmployerName));
                 }
              }, 
        
            new field_info {
              _name = _str_OccupationType, _type = "Lookup",
              _get_func = o => { if (o.OccupationType == null) return null; return o.OccupationType.idfsBaseReference; },
              _set_func = (o, val) => { o.OccupationType = o.OccupationTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsOccupationType != c.idfsOccupationType || o.IsRIRPropChanged(_str_OccupationType, c)) 
                  m.Add(_str_OccupationType, o.ObjectIdent + _str_OccupationType, "Lookup", o.idfsOccupationType == null ? "" : o.idfsOccupationType.ToString(), o.IsReadOnly(_str_OccupationType), o.IsInvisible(_str_OccupationType), o.IsRequired(_str_OccupationType)); }
              }, 
        
            new field_info {
              _name = _str_Nationality, _type = "Lookup",
              _get_func = o => { if (o.Nationality == null) return null; return o.Nationality.idfsBaseReference; },
              _set_func = (o, val) => { o.Nationality = o.NationalityLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsNationality != c.idfsNationality || o.IsRIRPropChanged(_str_Nationality, c)) 
                  m.Add(_str_Nationality, o.ObjectIdent + _str_Nationality, "Lookup", o.idfsNationality == null ? "" : o.idfsNationality.ToString(), o.IsReadOnly(_str_Nationality), o.IsInvisible(_str_Nationality), o.IsRequired(_str_Nationality)); }
              }, 
        
            new field_info {
              _name = _str_Gender, _type = "Lookup",
              _get_func = o => { if (o.Gender == null) return null; return o.Gender.idfsBaseReference; },
              _set_func = (o, val) => { o.Gender = o.GenderLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsHumanGender != c.idfsHumanGender || o.IsRIRPropChanged(_str_Gender, c)) 
                  m.Add(_str_Gender, o.ObjectIdent + _str_Gender, "Lookup", o.idfsHumanGender == null ? "" : o.idfsHumanGender.ToString(), o.IsReadOnly(_str_Gender), o.IsInvisible(_str_Gender), o.IsRequired(_str_Gender)); }
              }, 
        
            new field_info {
              _name = _str_HumanAgeType, _type = "Lookup",
              _get_func = o => { if (o.HumanAgeType == null) return null; return o.HumanAgeType.idfsBaseReference; },
              _set_func = (o, val) => { o.HumanAgeType = o.HumanAgeTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsHumanAgeTypeFromCase != c.idfsHumanAgeTypeFromCase || o.IsRIRPropChanged(_str_HumanAgeType, c)) 
                  m.Add(_str_HumanAgeType, o.ObjectIdent + _str_HumanAgeType, "Lookup", o.idfsHumanAgeTypeFromCase == null ? "" : o.idfsHumanAgeTypeFromCase.ToString(), o.IsReadOnly(_str_HumanAgeType), o.IsInvisible(_str_HumanAgeType), o.IsRequired(_str_HumanAgeType)); }
              }, 
        
            new field_info {
              _name = _str_CurrentResidenceAddress, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.CurrentResidenceAddress != null) o.CurrentResidenceAddress._compare(c.CurrentResidenceAddress, m); }
              }, 
        
            new field_info {
              _name = _str_EmployerAddress, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.EmployerAddress != null) o.EmployerAddress._compare(c.EmployerAddress, m); }
              }, 
        
            new field_info {
              _name = _str_RegistrationAddress, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.RegistrationAddress != null) o.RegistrationAddress._compare(c.RegistrationAddress, m); }
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
            Patient obj = (Patient)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(Address), eidss.model.Schema.Address._str_idfGeoLocation, _str_idfCurrentResidenceAddress)]
        public Address CurrentResidenceAddress
        {
            get 
            {   
                return _CurrentResidenceAddress; 
            }
            set 
            {   
                _CurrentResidenceAddress = value;
                if (_CurrentResidenceAddress != null) 
                { 
                    _CurrentResidenceAddress.m_ObjectName = _str_CurrentResidenceAddress;
                    _CurrentResidenceAddress.Parent = this;
                }
                idfCurrentResidenceAddress = _CurrentResidenceAddress == null 
                        ? new Int64?()
                        : _CurrentResidenceAddress.idfGeoLocation;
                
            }
        }
        protected Address _CurrentResidenceAddress;
                    
        [Relation(typeof(Address), eidss.model.Schema.Address._str_idfGeoLocation, _str_idfEmployerAddress)]
        public Address EmployerAddress
        {
            get 
            {   
                return _EmployerAddress; 
            }
            set 
            {   
                _EmployerAddress = value;
                if (_EmployerAddress != null) 
                { 
                    _EmployerAddress.m_ObjectName = _str_EmployerAddress;
                    _EmployerAddress.Parent = this;
                }
                idfEmployerAddress = _EmployerAddress == null 
                        ? new Int64?()
                        : _EmployerAddress.idfGeoLocation;
                
            }
        }
        protected Address _EmployerAddress;
                    
        [Relation(typeof(Address), eidss.model.Schema.Address._str_idfGeoLocation, _str_idfRegistrationAddress)]
        public Address RegistrationAddress
        {
            get 
            {   
                return _RegistrationAddress; 
            }
            set 
            {   
                _RegistrationAddress = value;
                if (_RegistrationAddress != null) 
                { 
                    _RegistrationAddress.m_ObjectName = _str_RegistrationAddress;
                    _RegistrationAddress.Parent = this;
                }
                idfRegistrationAddress = _RegistrationAddress == null 
                        ? new Int64?()
                        : _RegistrationAddress.idfGeoLocation;
                
            }
        }
        protected Address _RegistrationAddress;
                    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsOccupationType)]
        public BaseReference OccupationType
        {
            get { return _OccupationType == null ? null : ((long)_OccupationType.Key == 0 ? null : _OccupationType); }
            set 
            { 
                _OccupationType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsOccupationType = _OccupationType == null 
                    ? new Int64?()
                    : _OccupationType.idfsBaseReference; 
                OnPropertyChanged(_str_OccupationType); 
            }
        }
        private BaseReference _OccupationType;

        
        public BaseReferenceList OccupationTypeLookup
        {
            get { return _OccupationTypeLookup; }
        }
        private BaseReferenceList _OccupationTypeLookup = new BaseReferenceList("rftOccupationType");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsNationality)]
        public BaseReference Nationality
        {
            get { return _Nationality == null ? null : ((long)_Nationality.Key == 0 ? null : _Nationality); }
            set 
            { 
                _Nationality = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsNationality = _Nationality == null 
                    ? new Int64?()
                    : _Nationality.idfsBaseReference; 
                OnPropertyChanged(_str_Nationality); 
            }
        }
        private BaseReference _Nationality;

        
        public BaseReferenceList NationalityLookup
        {
            get { return _NationalityLookup; }
        }
        private BaseReferenceList _NationalityLookup = new BaseReferenceList("rftNationality");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsHumanGender)]
        public BaseReference Gender
        {
            get { return _Gender == null ? null : ((long)_Gender.Key == 0 ? null : _Gender); }
            set 
            { 
                _Gender = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsHumanGender = _Gender == null 
                    ? new Int64?()
                    : _Gender.idfsBaseReference; 
                OnPropertyChanged(_str_Gender); 
            }
        }
        private BaseReference _Gender;

        
        public BaseReferenceList GenderLookup
        {
            get { return _GenderLookup; }
        }
        private BaseReferenceList _GenderLookup = new BaseReferenceList("rftHumanGender");
            
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsHumanAgeTypeFromCase)]
        public BaseReference HumanAgeType
        {
            get { return _HumanAgeType == null ? null : ((long)_HumanAgeType.Key == 0 ? null : _HumanAgeType); }
            set 
            { 
                _HumanAgeType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsHumanAgeTypeFromCase = _HumanAgeType == null 
                    ? new Int64?()
                    : _HumanAgeType.idfsBaseReference; 
                OnPropertyChanged(_str_HumanAgeType); 
            }
        }
        private BaseReference _HumanAgeType;

        
        public BaseReferenceList HumanAgeTypeLookup
        {
            get { return _HumanAgeTypeLookup; }
        }
        private BaseReferenceList _HumanAgeTypeLookup = new BaseReferenceList("rftHumanAgeType");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_OccupationType:
                    return new BvSelectList(OccupationTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, OccupationType, _str_idfsOccupationType);
            
                case _str_Nationality:
                    return new BvSelectList(NationalityLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Nationality, _str_idfsNationality);
            
                case _str_Gender:
                    return new BvSelectList(GenderLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Gender, _str_idfsHumanGender);
            
                case _str_HumanAgeType:
                    return new BvSelectList(HumanAgeTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, HumanAgeType, _str_idfsHumanAgeTypeFromCase);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_HCase)]
        public HumanCase HCase
        {
            get { return new Func<Patient, HumanCase>(c => c.Parent as HumanCase)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strName)]
        public string strName
        {
            get { return new Func<Patient, string>(c => c.strLastName + " " + c.strFirstName + " " + c.strSecondName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_IsReadOnlyParent)]
        public bool IsReadOnlyParent
        {
            get { return new Func<Patient, bool>(c => c.HCase == null ? false : c.HCase.IsClosed || c.HCase.ReadOnly)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyLastName)]
        public string strReadOnlyLastName
        {
            get { return new Func<Patient, string>(c => c.strLastName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyFirstName)]
        public string strReadOnlyFirstName
        {
            get { return new Func<Patient, string>(c => c.strFirstName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlySecondName)]
        public string strReadOnlySecondName
        {
            get { return new Func<Patient, string>(c => c.strSecondName)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyDateofBirth)]
        public string strReadOnlyDateofBirth
        {
            get { return new Func<Patient, string>(c => c.datDateofBirth == null ? (string)null : c.datDateofBirth.Value.ToString())(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyHumanGender)]
        public string strReadOnlyHumanGender
        {
            get { return new Func<Patient, string>(c => c.idfsHumanGender == null ? (string)null : c.Gender.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyNationality)]
        public string strReadOnlyNationality
        {
            get { return new Func<Patient, string>(c => c.idfsNationality == null ? (string)null : c.Nationality.name)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strReadOnlyEmployerName)]
        public string strReadOnlyEmployerName
        {
            get { return new Func<Patient, string>(c => c.strEmployerName)(this); }
            
        }
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Patient";

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
        
            if (_CurrentResidenceAddress != null) { _CurrentResidenceAddress.Parent = this; }
                
            if (_EmployerAddress != null) { _EmployerAddress.Parent = this; }
                
            if (_RegistrationAddress != null) { _RegistrationAddress.Parent = this; }
                
        }
        public override object Clone()
        {
            var ret = base.Clone() as Patient;
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
            var ret = base.Clone() as Patient;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_CurrentResidenceAddress != null)
              ret.CurrentResidenceAddress = _CurrentResidenceAddress.CloneWithSetup(manager) as Address;
                
            if (_EmployerAddress != null)
              ret.EmployerAddress = _EmployerAddress.CloneWithSetup(manager) as Address;
                
            if (_RegistrationAddress != null)
              ret.RegistrationAddress = _RegistrationAddress.CloneWithSetup(manager) as Address;
                
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public Patient CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Patient;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfHuman; } }
        public string KeyName { get { return "idfHuman"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || (_CurrentResidenceAddress != null && _CurrentResidenceAddress.HasChanges)
                
                    || (_EmployerAddress != null && _EmployerAddress.HasChanges)
                
                    || (_RegistrationAddress != null && _RegistrationAddress.HasChanges)
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsOccupationType_OccupationType = idfsOccupationType;
            var _prev_idfsNationality_Nationality = idfsNationality;
            var _prev_idfsHumanGender_Gender = idfsHumanGender;
            var _prev_idfsHumanAgeTypeFromCase_HumanAgeType = idfsHumanAgeTypeFromCase;
            base.RejectChanges();
        
            if (_prev_idfsOccupationType_OccupationType != idfsOccupationType)
            {
                _OccupationType = _OccupationTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsOccupationType);
            }
            if (_prev_idfsNationality_Nationality != idfsNationality)
            {
                _Nationality = _NationalityLookup.FirstOrDefault(c => c.idfsBaseReference == idfsNationality);
            }
            if (_prev_idfsHumanGender_Gender != idfsHumanGender)
            {
                _Gender = _GenderLookup.FirstOrDefault(c => c.idfsBaseReference == idfsHumanGender);
            }
            if (_prev_idfsHumanAgeTypeFromCase_HumanAgeType != idfsHumanAgeTypeFromCase)
            {
                _HumanAgeType = _HumanAgeTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsHumanAgeTypeFromCase);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
            if (CurrentResidenceAddress != null) CurrentResidenceAddress.RejectChanges();
                
            if (EmployerAddress != null) EmployerAddress.RejectChanges();
                
            if (RegistrationAddress != null) RegistrationAddress.RejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
            if (_CurrentResidenceAddress != null) _CurrentResidenceAddress.AcceptChanges();
                
            if (_EmployerAddress != null) _EmployerAddress.AcceptChanges();
                
            if (_RegistrationAddress != null) _RegistrationAddress.AcceptChanges();
                
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
        
            if (_CurrentResidenceAddress != null) _CurrentResidenceAddress.SetChange();
                
            if (_EmployerAddress != null) _EmployerAddress.SetChange();
                
            if (_RegistrationAddress != null) _RegistrationAddress.SetChange();
                
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

      private bool IsRIRPropChanged(string fld, Patient c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public Patient()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Patient_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Patient_PropertyChanged);
        }
        private void Patient_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Patient).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_HCase);
                  
            if (e.PropertyName == _str_strFirstName)
                OnPropertyChanged(_str_strName);
                  
            if (e.PropertyName == _str_strSecondName)
                OnPropertyChanged(_str_strName);
                  
            if (e.PropertyName == _str_strLastName)
                OnPropertyChanged(_str_strName);
                  
            if (e.PropertyName == _str_HCase)
                OnPropertyChanged(_str_IsReadOnlyParent);
                  
            if (e.PropertyName == _str_strLastName)
                OnPropertyChanged(_str_strReadOnlyLastName);
                  
            if (e.PropertyName == _str_strFirstName)
                OnPropertyChanged(_str_strReadOnlyFirstName);
                  
            if (e.PropertyName == _str_strSecondName)
                OnPropertyChanged(_str_strReadOnlySecondName);
                  
            if (e.PropertyName == _str_datDateofBirth)
                OnPropertyChanged(_str_strReadOnlyDateofBirth);
                  
            if (e.PropertyName == _str_idfsHumanGender)
                OnPropertyChanged(_str_strReadOnlyHumanGender);
                  
            if (e.PropertyName == _str_idfsNationality)
                OnPropertyChanged(_str_strReadOnlyNationality);
                  
            if (e.PropertyName == _str_strEmployerName)
                OnPropertyChanged(_str_strReadOnlyEmployerName);
                  
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
            Patient obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Patient obj = this;
            
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

    
        private static string[] readonly_names1 = "strName".Split(new char[] { ',' });
        
        private static string[] readonly_names2 = "strReadOnlyLastName,strReadOnlyFirstName,strReadOnlySecondName,strReadOnlyEmployerName".Split(new char[] { ',' });
        
        private static string[] readonly_names3 = "strReadOnlyDateofBirth,strReadOnlyHumanGender,strReadOnlyNationality".Split(new char[] { ',' });
        
        private static string[] readonly_names4 = "intPatientAgeFromCase,idfsHumanAgeTypeFromCase,HumanAgeType".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Patient, bool>(c => true)(this);
            
            if (readonly_names2.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Patient, bool>(c => true)(this);
            
            if (readonly_names3.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Patient, bool>(c => true)(this);
            
            if (readonly_names4.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Patient, bool>(c => c.IsReadOnlyParent || c.datDateofBirth != null)(this);
            
            return ReadOnly || new Func<Patient, bool>(c => c.IsReadOnlyParent)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                if (_CurrentResidenceAddress != null)
                    _CurrentResidenceAddress.ReadOnly = value;
                
                if (_EmployerAddress != null)
                    _EmployerAddress.ReadOnly = value;
                
                if (_RegistrationAddress != null)
                    _RegistrationAddress.ReadOnly = value;
                
            }
        }


        public Dictionary<string, Func<Patient, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Patient, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Patient, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<Patient, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<Patient, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<Patient, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~Patient()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftOccupationType", this);
                
                LookupManager.RemoveObject("rftNationality", this);
                
                LookupManager.RemoveObject("rftHumanGender", this);
                
                LookupManager.RemoveObject("rftHumanAgeType", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftOccupationType")
                _getAccessor().LoadLookup_OccupationType(manager, this);
            
            if (lookup_object == "rftNationality")
                _getAccessor().LoadLookup_Nationality(manager, this);
            
            if (lookup_object == "rftHumanGender")
                _getAccessor().LoadLookup_Gender(manager, this);
            
            if (lookup_object == "rftHumanAgeType")
                _getAccessor().LoadLookup_HumanAgeType(manager, this);
            
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
        
            if (_CurrentResidenceAddress != null) _CurrentResidenceAddress.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_EmployerAddress != null) _EmployerAddress.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_RegistrationAddress != null) _RegistrationAddress.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<Patient>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    
        {
            private delegate void on_action(Patient obj);
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
            private Address.Accessor CurrentResidenceAddressAccessor { get { return eidss.model.Schema.Address.Accessor.Instance(m_CS); } }
            private Address.Accessor EmployerAddressAccessor { get { return eidss.model.Schema.Address.Accessor.Instance(m_CS); } }
            private Address.Accessor RegistrationAddressAccessor { get { return eidss.model.Schema.Address.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor OccupationTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor NationalityAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor GenderAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor HumanAgeTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            

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

            
            public virtual Patient SelectByKey(DbManagerProxy manager
                , Int64? idfHuman
                )
            {
                return _SelectByKey(manager
                    , idfHuman
                    , null, null
                    );
            }
            
      
            private Patient _SelectByKey(DbManagerProxy manager
                , Int64? idfHuman
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<Patient> objs = new List<Patient>();
                sets[0] = new MapResultSet(typeof(Patient), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spPatient_SelectDetail"
                            , manager.Parameter("@idfHuman", idfHuman)
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    Patient obj = objs[0];
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
    
            internal void _LoadCurrentResidenceAddress(Patient obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadCurrentResidenceAddress(manager, obj);
                }
            }
            internal void _LoadCurrentResidenceAddress(DbManagerProxy manager, Patient obj)
            {
                
                if (obj.CurrentResidenceAddress == null && obj.idfCurrentResidenceAddress != null && obj.idfCurrentResidenceAddress != 0)
                {
                    obj.CurrentResidenceAddress = CurrentResidenceAddressAccessor.SelectByKey(manager
                        
                        , obj.idfCurrentResidenceAddress.Value
                        );
                    if (obj.CurrentResidenceAddress != null)
                    {
                        obj.CurrentResidenceAddress.m_ObjectName = _str_CurrentResidenceAddress;
                    }
                }
                    
            }
            
            internal void _LoadEmployerAddress(Patient obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadEmployerAddress(manager, obj);
                }
            }
            internal void _LoadEmployerAddress(DbManagerProxy manager, Patient obj)
            {
                
                if (obj.EmployerAddress == null && obj.idfEmployerAddress != null && obj.idfEmployerAddress != 0)
                {
                    obj.EmployerAddress = EmployerAddressAccessor.SelectByKey(manager
                        
                        , obj.idfEmployerAddress.Value
                        );
                    if (obj.EmployerAddress != null)
                    {
                        obj.EmployerAddress.m_ObjectName = _str_EmployerAddress;
                    }
                }
                    
            }
            
            internal void _LoadRegistrationAddress(Patient obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadRegistrationAddress(manager, obj);
                }
            }
            internal void _LoadRegistrationAddress(DbManagerProxy manager, Patient obj)
            {
                
                if (obj.RegistrationAddress == null && obj.idfRegistrationAddress != null && obj.idfRegistrationAddress != 0)
                {
                    obj.RegistrationAddress = RegistrationAddressAccessor.SelectByKey(manager
                        
                        , obj.idfRegistrationAddress.Value
                        );
                    if (obj.RegistrationAddress != null)
                    {
                        obj.RegistrationAddress.m_ObjectName = _str_RegistrationAddress;
                    }
                }
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, Patient obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadCurrentResidenceAddress(manager, obj);
                _LoadEmployerAddress(manager, obj);
                _LoadRegistrationAddress(manager, obj);
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.CurrentResidenceAddress = new Func<Patient, Address>(c => c.CurrentResidenceAddress == null ? CurrentResidenceAddressAccessor.CreateNewT(manager, c) : c.CurrentResidenceAddress)(obj);
                obj.EmployerAddress = new Func<Patient, Address>(c => c.EmployerAddress == null ? EmployerAddressAccessor.CreateNewT(manager, c) : c.EmployerAddress)(obj);
                obj.RegistrationAddress = new Func<Patient, Address>(c => c.RegistrationAddress == null ? RegistrationAddressAccessor.CreateNewT(manager, c) : c.RegistrationAddress)(obj);
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, Patient obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    CurrentResidenceAddressAccessor._SetPermitions(obj._permissions, obj.CurrentResidenceAddress);
                    EmployerAddressAccessor._SetPermitions(obj._permissions, obj.EmployerAddress);
                    RegistrationAddressAccessor._SetPermitions(obj._permissions, obj.RegistrationAddress);
                    
                    }
                }
            }

    

            private Patient _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    Patient obj = Patient.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfHuman = (new GetNewIDExtender<Patient>()).GetScalar(manager, obj);
                obj.idfRootHuman = (new GetNewIDExtender<Patient>()).GetScalar(manager, obj);
                obj.CurrentResidenceAddress = new Func<Patient, Address>(c => CurrentResidenceAddressAccessor.CreateNewT(manager, c))(obj);
                obj.CurrentResidenceAddress.Region = new Func<Patient, RegionLookup>(c => c.CurrentResidenceAddress.RegionLookup.Where(l => l.idfsRegion == eidss.model.Core.EidssSiteContext.Instance.RegionID).FirstOrDefault())(obj);
                obj.EmployerAddress = new Func<Patient, Address>(c => EmployerAddressAccessor.CreateNewT(manager, c))(obj);
                obj.EmployerAddress.Region = new Func<Patient, RegionLookup>(c => c.EmployerAddress.RegionLookup.Where(l => l.idfsRegion == eidss.model.Core.EidssSiteContext.Instance.RegionID).FirstOrDefault())(obj);
                obj.EmployerAddress.blnNeedForeignAddressStr = new Func<Patient, bool>(c => false)(obj);
                obj.RegistrationAddress = new Func<Patient, Address>(c => RegistrationAddressAccessor.CreateNewT(manager, c))(obj);
                obj.RegistrationAddress.Region = new Func<Patient, RegionLookup>(c => c.RegistrationAddress.RegionLookup.Where(l => l.idfsRegion == eidss.model.Core.EidssSiteContext.Instance.RegionID).FirstOrDefault())(obj);
                obj.RegistrationAddress.blnNeedForeignAddressStr = new Func<Patient, bool>(c => true)(obj);
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

            
            public Patient CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public Patient CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public Patient CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("idfCase", typeof(long));
                
                return Create(manager, Parent
                    , (long)pars[0]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public Patient Create(DbManagerProxy manager, IObject Parent
                , long idfCase
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj.idfCase = new Func<Patient, long>(c => idfCase)(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(Patient obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Patient obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_intPatientAgeFromCase)
                        {
                            try
                            {
                            
                (new PredicateValidator("mbAgeShallNotExceed", "intPatientAgeFromCase", "intPatientAgeFromCase", "intPatientAgeFromCase",
              new object[] {
              },
                        false
                    )).Validate(obj, i => i.idfsHumanAgeTypeFromCase == null || i.intPatientAgeFromCase == null
                                            || (i.idfsHumanAgeTypeFromCase == (long)HumanAgeTypeEnum.Years && i.intPatientAgeFromCase <= 200)
                                            || (i.idfsHumanAgeTypeFromCase == (long)HumanAgeTypeEnum.Month && i.intPatientAgeFromCase <= 60)
                                            || (i.idfsHumanAgeTypeFromCase == (long)HumanAgeTypeEnum.Days && i.intPatientAgeFromCase <= 31)
                                            
                    );
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intPatientAgeFromCase);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                    };
                
            }
    
            public void LoadLookup_OccupationType(DbManagerProxy manager, Patient obj)
            {
                
                obj.OccupationTypeLookup.Clear();
                
                obj.OccupationTypeLookup.Add(OccupationTypeAccessor.CreateNewT(manager, null));
                
                obj.OccupationTypeLookup.AddRange(OccupationTypeAccessor.rftOccupationType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsOccupationType))
                    
                    .ToList());
                
                if (obj.idfsOccupationType != null && obj.idfsOccupationType != 0)
                {
                    obj.OccupationType = obj.OccupationTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsOccupationType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftOccupationType", obj, OccupationTypeAccessor.GetType(), "rftOccupationType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Nationality(DbManagerProxy manager, Patient obj)
            {
                
                obj.NationalityLookup.Clear();
                
                obj.NationalityLookup.Add(NationalityAccessor.CreateNewT(manager, null));
                
                obj.NationalityLookup.AddRange(NationalityAccessor.rftNationality_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsNationality))
                    
                    .ToList());
                
                if (obj.idfsNationality != null && obj.idfsNationality != 0)
                {
                    obj.Nationality = obj.NationalityLookup
                        .Where(c => c.idfsBaseReference == obj.idfsNationality)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftNationality", obj, NationalityAccessor.GetType(), "rftNationality_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_Gender(DbManagerProxy manager, Patient obj)
            {
                
                obj.GenderLookup.Clear();
                
                obj.GenderLookup.Add(GenderAccessor.CreateNewT(manager, null));
                
                obj.GenderLookup.AddRange(GenderAccessor.rftHumanGender_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsHumanGender))
                    
                    .ToList());
                
                if (obj.idfsHumanGender != null && obj.idfsHumanGender != 0)
                {
                    obj.Gender = obj.GenderLookup
                        .Where(c => c.idfsBaseReference == obj.idfsHumanGender)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftHumanGender", obj, GenderAccessor.GetType(), "rftHumanGender_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_HumanAgeType(DbManagerProxy manager, Patient obj)
            {
                
                obj.HumanAgeTypeLookup.Clear();
                
                obj.HumanAgeTypeLookup.Add(HumanAgeTypeAccessor.CreateNewT(manager, null));
                
                obj.HumanAgeTypeLookup.AddRange(HumanAgeTypeAccessor.rftHumanAgeType_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode.GetValueOrDefault() & (int)HACode.Human) != 0)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsHumanAgeTypeFromCase))
                    
                    .ToList());
                
                if (obj.idfsHumanAgeTypeFromCase != null && obj.idfsHumanAgeTypeFromCase != 0)
                {
                    obj.HumanAgeType = obj.HumanAgeTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsHumanAgeTypeFromCase)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftHumanAgeType", obj, HumanAgeTypeAccessor.GetType(), "rftHumanAgeType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, Patient obj)
            {
                
                LoadLookup_OccupationType(manager, obj);
                
                LoadLookup_Nationality(manager, obj);
                
                LoadLookup_Gender(manager, obj);
                
                LoadLookup_HumanAgeType(manager, obj);
                
            }
    
            [SprocName("spPatientActual_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spPatientActual_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spPatient_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] Patient obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] Patient obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    Patient bo = obj as Patient;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as Patient, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, Patient obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.CurrentResidenceAddress != null)
                    {
                        obj.CurrentResidenceAddress.MarkToDelete();
                        if (!CurrentResidenceAddressAccessor.Post(manager, obj.CurrentResidenceAddress, true))
                            return false;
                    }
                                    
                    if (obj.EmployerAddress != null)
                    {
                        obj.EmployerAddress.MarkToDelete();
                        if (!EmployerAddressAccessor.Post(manager, obj.EmployerAddress, true))
                            return false;
                    }
                                    
                    if (obj.RegistrationAddress != null)
                    {
                        obj.RegistrationAddress.MarkToDelete();
                        if (!RegistrationAddressAccessor.Post(manager, obj.RegistrationAddress, true))
                            return false;
                    }
                                    
                    if (!ValidateCanDelete(manager, obj)) return false;
                                
                    _postDeletePredicate(manager
                        , obj.idfHuman
                        );
                                        
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                    // posting extenters - end
            
                    if (obj.IsNew)
                    {
                        if (obj.CurrentResidenceAddress != null) // forced load potential lazy subobject for new object
                            if (!CurrentResidenceAddressAccessor.Post(manager, obj.CurrentResidenceAddress, true))
                                return false;
                    }
                    else
                    {
                        if (obj._CurrentResidenceAddress != null) // do not load lazy subobject for existing object
                            if (!CurrentResidenceAddressAccessor.Post(manager, obj.CurrentResidenceAddress, true))
                                return false;
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.EmployerAddress != null) // forced load potential lazy subobject for new object
                            if (!EmployerAddressAccessor.Post(manager, obj.EmployerAddress, true))
                                return false;
                    }
                    else
                    {
                        if (obj._EmployerAddress != null) // do not load lazy subobject for existing object
                            if (!EmployerAddressAccessor.Post(manager, obj.EmployerAddress, true))
                                return false;
                    }
                                    
                    if (obj.IsNew)
                    {
                        if (obj.RegistrationAddress != null) // forced load potential lazy subobject for new object
                            if (!RegistrationAddressAccessor.Post(manager, obj.RegistrationAddress, true))
                                return false;
                    }
                    else
                    {
                        if (obj._RegistrationAddress != null) // do not load lazy subobject for existing object
                            if (!RegistrationAddressAccessor.Post(manager, obj.RegistrationAddress, true))
                                return false;
                    }
                                    
                    if (!obj.IsMarkedToDelete && bHasChanges)
                        _postPredicate(manager, obj);
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(Patient obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, Patient obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfHuman
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
                return Validate(manager, obj as Patient, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Patient obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "strLastName", "strLastName","",
                false
              )).Validate(c => true, obj, obj.strLastName);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                (new PredicateValidator("mbAgeShallNotExceed", "intPatientAgeFromCase", "intPatientAgeFromCase", "intPatientAgeFromCase",
              new object[] {
              },
                        false
                    )).Validate(obj, i => i.idfsHumanAgeTypeFromCase == null || i.intPatientAgeFromCase == null
                                            || (i.idfsHumanAgeTypeFromCase == (long)HumanAgeTypeEnum.Years && i.intPatientAgeFromCase <= 200)
                                            || (i.idfsHumanAgeTypeFromCase == (long)HumanAgeTypeEnum.Month && i.intPatientAgeFromCase <= 60)
                                            || (i.idfsHumanAgeTypeFromCase == (long)HumanAgeTypeEnum.Days && i.intPatientAgeFromCase <= 31)
                                            
                    );
            
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.CurrentResidenceAddress != null)
                            CurrentResidenceAddressAccessor.Validate(manager, obj.CurrentResidenceAddress, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.EmployerAddress != null)
                            EmployerAddressAccessor.Validate(manager, obj.EmployerAddress, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
                        if (obj.RegistrationAddress != null)
                            RegistrationAddressAccessor.Validate(manager, obj.RegistrationAddress, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            private void _SetupRequired(Patient obj)
            {
            
                obj
                    .AddRequired("strLastName", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(Patient obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Patient) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Patient) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "PatientDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spPatient_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spPatient_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spPatientActual_Delete";
            public static string spCanDelete = "spPatientActual_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Patient, bool>> RequiredByField = new Dictionary<string, Func<Patient, bool>>();
            public static Dictionary<string, Func<Patient, bool>> RequiredByProperty = new Dictionary<string, Func<Patient, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strLastName, 200);
                Sizes.Add(_str_strSecondName, 200);
                Sizes.Add(_str_strFirstName, 200);
                Sizes.Add(_str_strRegistrationPhone, 200);
                Sizes.Add(_str_strEmployerName, 200);
                Sizes.Add(_str_strHomePhone, 200);
                Sizes.Add(_str_strWorkPhone, 200);
                if (!RequiredByField.ContainsKey("strLastName")) RequiredByField.Add("strLastName", c => true);
                if (!RequiredByProperty.ContainsKey("strLastName")) RequiredByProperty.Add("strLastName", c => true);
                
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).Create(manager, c, pars)),
                        
                    null,
                    
                    null,
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
                    (manager, c, pars) => new ActResult(((Patient)c).MarkToDelete() && ObjectAccessor.PostInterface<Patient>().Post(manager, (Patient)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Patient>().Post(manager, (Patient)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<Patient>().Post(manager, (Patient)c), c),
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
	