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
    public abstract partial class OutbreakListItem : 
        EditableObject<OutbreakListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfOutbreak), NonUpdatable, PrimaryKey]
        public abstract Int64 idfOutbreak { get; set; }
                
        [LocalizedDisplayName(_str_strOutbreakID)]
        [MapField(_str_strOutbreakID)]
        public abstract String strOutbreakID { get; set; }
        protected String strOutbreakID_Original { get { return ((EditableValue<String>)((dynamic)this)._strOutbreakID).OriginalValue; } }
        protected String strOutbreakID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOutbreakID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStartDate)]
        [MapField(_str_datStartDate)]
        public abstract DateTime? datStartDate { get; set; }
        protected DateTime? datStartDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime? datStartDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFinishDate)]
        [MapField(_str_datFinishDate)]
        public abstract DateTime? datFinishDate { get; set; }
        protected DateTime? datFinishDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFinishDate).OriginalValue; } }
        protected DateTime? datFinishDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFinishDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDiagnosisOrDiagnosisGroup)]
        [MapField(_str_strDiagnosisOrDiagnosisGroup)]
        public abstract String strDiagnosisOrDiagnosisGroup { get; set; }
        protected String strDiagnosisOrDiagnosisGroup_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisOrDiagnosisGroup).OriginalValue; } }
        protected String strDiagnosisOrDiagnosisGroup_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisOrDiagnosisGroup).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsDiagnosisOrDiagnosisGroup)]
        [MapField(_str_idfsDiagnosisOrDiagnosisGroup)]
        public abstract Int64? idfsDiagnosisOrDiagnosisGroup { get; set; }
        protected Int64? idfsDiagnosisOrDiagnosisGroup_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosisOrDiagnosisGroup).OriginalValue; } }
        protected Int64? idfsDiagnosisOrDiagnosisGroup_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosisOrDiagnosisGroup).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDiagnosisGroup)]
        [MapField(_str_strDiagnosisGroup)]
        public abstract String strDiagnosisGroup { get; set; }
        protected String strDiagnosisGroup_Original { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisGroup).OriginalValue; } }
        protected String strDiagnosisGroup_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDiagnosisGroup).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsDiagnosisGroup)]
        [MapField(_str_idfsDiagnosisGroup)]
        public abstract Int64? idfsDiagnosisGroup { get; set; }
        protected Int64? idfsDiagnosisGroup_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosisGroup).OriginalValue; } }
        protected Int64? idfsDiagnosisGroup_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsDiagnosisGroup).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOutbreakStatus)]
        [MapField(_str_strOutbreakStatus)]
        public abstract String strOutbreakStatus { get; set; }
        protected String strOutbreakStatus_Original { get { return ((EditableValue<String>)((dynamic)this)._strOutbreakStatus).OriginalValue; } }
        protected String strOutbreakStatus_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOutbreakStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsOutbreakStatus)]
        [MapField(_str_idfsOutbreakStatus)]
        public abstract Int64? idfsOutbreakStatus { get; set; }
        protected Int64? idfsOutbreakStatus_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOutbreakStatus).OriginalValue; } }
        protected Int64? idfsOutbreakStatus_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsOutbreakStatus).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfGeoLocation)]
        [MapField(_str_idfGeoLocation)]
        public abstract Int64? idfGeoLocation { get; set; }
        protected Int64? idfGeoLocation_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfGeoLocation).OriginalValue; } }
        protected Int64? idfGeoLocation_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfGeoLocation).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strGeoLocationName)]
        [MapField(_str_strGeoLocationName)]
        public abstract String strGeoLocationName { get; set; }
        protected String strGeoLocationName_Original { get { return ((EditableValue<String>)((dynamic)this)._strGeoLocationName).OriginalValue; } }
        protected String strGeoLocationName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strGeoLocationName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPatientName)]
        [MapField(_str_strPatientName)]
        public abstract String strPatientName { get; set; }
        protected String strPatientName_Original { get { return ((EditableValue<String>)((dynamic)this)._strPatientName).OriginalValue; } }
        protected String strPatientName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPatientName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHumanPatientName)]
        [MapField(_str_strHumanPatientName)]
        public abstract String strHumanPatientName { get; set; }
        protected String strHumanPatientName_Original { get { return ((EditableValue<String>)((dynamic)this)._strHumanPatientName).OriginalValue; } }
        protected String strHumanPatientName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHumanPatientName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strFarmOwner)]
        [MapField(_str_strFarmOwner)]
        public abstract String strFarmOwner { get; set; }
        protected String strFarmOwner_Original { get { return ((EditableValue<String>)((dynamic)this)._strFarmOwner).OriginalValue; } }
        protected String strFarmOwner_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFarmOwner).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<OutbreakListItem, object> _get_func;
            internal Action<OutbreakListItem, string> _set_func;
            internal Action<OutbreakListItem, OutbreakListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfOutbreak = "idfOutbreak";
        internal const string _str_strOutbreakID = "strOutbreakID";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_datFinishDate = "datFinishDate";
        internal const string _str_strDiagnosisOrDiagnosisGroup = "strDiagnosisOrDiagnosisGroup";
        internal const string _str_idfsDiagnosisOrDiagnosisGroup = "idfsDiagnosisOrDiagnosisGroup";
        internal const string _str_strDiagnosisGroup = "strDiagnosisGroup";
        internal const string _str_idfsDiagnosisGroup = "idfsDiagnosisGroup";
        internal const string _str_strOutbreakStatus = "strOutbreakStatus";
        internal const string _str_idfsOutbreakStatus = "idfsOutbreakStatus";
        internal const string _str_idfGeoLocation = "idfGeoLocation";
        internal const string _str_strGeoLocationName = "strGeoLocationName";
        internal const string _str_strPatientName = "strPatientName";
        internal const string _str_strHumanPatientName = "strHumanPatientName";
        internal const string _str_strFarmOwner = "strFarmOwner";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_DiagnosisGroup = "DiagnosisGroup";
        internal const string _str_OutbreakStatus = "OutbreakStatus";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfOutbreak, _formname = _str_idfOutbreak, _type = "Int64",
              _get_func = o => o.idfOutbreak,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfOutbreak != newval) o.idfOutbreak = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfOutbreak != c.idfOutbreak || o.IsRIRPropChanged(_str_idfOutbreak, c)) 
                  m.Add(_str_idfOutbreak, o.ObjectIdent + _str_idfOutbreak, o.ObjectIdent2 + _str_idfOutbreak, o.ObjectIdent3 + _str_idfOutbreak, "Int64", 
                    o.idfOutbreak == null ? "" : o.idfOutbreak.ToString(),                  
                  o.IsReadOnly(_str_idfOutbreak), o.IsInvisible(_str_idfOutbreak), o.IsRequired(_str_idfOutbreak)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOutbreakID, _formname = _str_strOutbreakID, _type = "String",
              _get_func = o => o.strOutbreakID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOutbreakID != newval) o.strOutbreakID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strOutbreakID != c.strOutbreakID || o.IsRIRPropChanged(_str_strOutbreakID, c)) 
                  m.Add(_str_strOutbreakID, o.ObjectIdent + _str_strOutbreakID, o.ObjectIdent2 + _str_strOutbreakID, o.ObjectIdent3 + _str_strOutbreakID, "String", 
                    o.strOutbreakID == null ? "" : o.strOutbreakID.ToString(),                  
                  o.IsReadOnly(_str_strOutbreakID), o.IsInvisible(_str_strOutbreakID), o.IsRequired(_str_strOutbreakID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datStartDate, _formname = _str_datStartDate, _type = "DateTime?",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datStartDate != newval) o.datStartDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, o.ObjectIdent2 + _str_datStartDate, o.ObjectIdent3 + _str_datStartDate, "DateTime?", 
                    o.datStartDate == null ? "" : o.datStartDate.ToString(),                  
                  o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datFinishDate, _formname = _str_datFinishDate, _type = "DateTime?",
              _get_func = o => o.datFinishDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datFinishDate != newval) o.datFinishDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datFinishDate != c.datFinishDate || o.IsRIRPropChanged(_str_datFinishDate, c)) 
                  m.Add(_str_datFinishDate, o.ObjectIdent + _str_datFinishDate, o.ObjectIdent2 + _str_datFinishDate, o.ObjectIdent3 + _str_datFinishDate, "DateTime?", 
                    o.datFinishDate == null ? "" : o.datFinishDate.ToString(),                  
                  o.IsReadOnly(_str_datFinishDate), o.IsInvisible(_str_datFinishDate), o.IsRequired(_str_datFinishDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDiagnosisOrDiagnosisGroup, _formname = _str_strDiagnosisOrDiagnosisGroup, _type = "String",
              _get_func = o => o.strDiagnosisOrDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnosisOrDiagnosisGroup != newval) o.strDiagnosisOrDiagnosisGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDiagnosisOrDiagnosisGroup != c.strDiagnosisOrDiagnosisGroup || o.IsRIRPropChanged(_str_strDiagnosisOrDiagnosisGroup, c)) 
                  m.Add(_str_strDiagnosisOrDiagnosisGroup, o.ObjectIdent + _str_strDiagnosisOrDiagnosisGroup, o.ObjectIdent2 + _str_strDiagnosisOrDiagnosisGroup, o.ObjectIdent3 + _str_strDiagnosisOrDiagnosisGroup, "String", 
                    o.strDiagnosisOrDiagnosisGroup == null ? "" : o.strDiagnosisOrDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_strDiagnosisOrDiagnosisGroup), o.IsInvisible(_str_strDiagnosisOrDiagnosisGroup), o.IsRequired(_str_strDiagnosisOrDiagnosisGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosisOrDiagnosisGroup, _formname = _str_idfsDiagnosisOrDiagnosisGroup, _type = "Int64?",
              _get_func = o => o.idfsDiagnosisOrDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsDiagnosisOrDiagnosisGroup != newval) 
                  o.Diagnosis = o.DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == newval);
                if (o.idfsDiagnosisOrDiagnosisGroup != newval) o.idfsDiagnosisOrDiagnosisGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosisOrDiagnosisGroup != c.idfsDiagnosisOrDiagnosisGroup || o.IsRIRPropChanged(_str_idfsDiagnosisOrDiagnosisGroup, c)) 
                  m.Add(_str_idfsDiagnosisOrDiagnosisGroup, o.ObjectIdent + _str_idfsDiagnosisOrDiagnosisGroup, o.ObjectIdent2 + _str_idfsDiagnosisOrDiagnosisGroup, o.ObjectIdent3 + _str_idfsDiagnosisOrDiagnosisGroup, "Int64?", 
                    o.idfsDiagnosisOrDiagnosisGroup == null ? "" : o.idfsDiagnosisOrDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosisOrDiagnosisGroup), o.IsInvisible(_str_idfsDiagnosisOrDiagnosisGroup), o.IsRequired(_str_idfsDiagnosisOrDiagnosisGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDiagnosisGroup, _formname = _str_strDiagnosisGroup, _type = "String",
              _get_func = o => o.strDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDiagnosisGroup != newval) o.strDiagnosisGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDiagnosisGroup != c.strDiagnosisGroup || o.IsRIRPropChanged(_str_strDiagnosisGroup, c)) 
                  m.Add(_str_strDiagnosisGroup, o.ObjectIdent + _str_strDiagnosisGroup, o.ObjectIdent2 + _str_strDiagnosisGroup, o.ObjectIdent3 + _str_strDiagnosisGroup, "String", 
                    o.strDiagnosisGroup == null ? "" : o.strDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_strDiagnosisGroup), o.IsInvisible(_str_strDiagnosisGroup), o.IsRequired(_str_strDiagnosisGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsDiagnosisGroup, _formname = _str_idfsDiagnosisGroup, _type = "Int64?",
              _get_func = o => o.idfsDiagnosisGroup,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsDiagnosisGroup != newval) 
                  o.DiagnosisGroup = o.DiagnosisGroupLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsDiagnosisGroup != newval) o.idfsDiagnosisGroup = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosisGroup != c.idfsDiagnosisGroup || o.IsRIRPropChanged(_str_idfsDiagnosisGroup, c)) 
                  m.Add(_str_idfsDiagnosisGroup, o.ObjectIdent + _str_idfsDiagnosisGroup, o.ObjectIdent2 + _str_idfsDiagnosisGroup, o.ObjectIdent3 + _str_idfsDiagnosisGroup, "Int64?", 
                    o.idfsDiagnosisGroup == null ? "" : o.idfsDiagnosisGroup.ToString(),                  
                  o.IsReadOnly(_str_idfsDiagnosisGroup), o.IsInvisible(_str_idfsDiagnosisGroup), o.IsRequired(_str_idfsDiagnosisGroup)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOutbreakStatus, _formname = _str_strOutbreakStatus, _type = "String",
              _get_func = o => o.strOutbreakStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOutbreakStatus != newval) o.strOutbreakStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.strOutbreakStatus != c.strOutbreakStatus || o.IsRIRPropChanged(_str_strOutbreakStatus, c)) 
                  m.Add(_str_strOutbreakStatus, o.ObjectIdent + _str_strOutbreakStatus, o.ObjectIdent2 + _str_strOutbreakStatus, o.ObjectIdent3 + _str_strOutbreakStatus, "String", 
                    o.strOutbreakStatus == null ? "" : o.strOutbreakStatus.ToString(),                  
                  o.IsReadOnly(_str_strOutbreakStatus), o.IsInvisible(_str_strOutbreakStatus), o.IsRequired(_str_strOutbreakStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsOutbreakStatus, _formname = _str_idfsOutbreakStatus, _type = "Int64?",
              _get_func = o => o.idfsOutbreakStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.idfsOutbreakStatus != newval) 
                  o.OutbreakStatus = o.OutbreakStatusLookup.FirstOrDefault(c => c.idfsBaseReference == newval);
                if (o.idfsOutbreakStatus != newval) o.idfsOutbreakStatus = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsOutbreakStatus != c.idfsOutbreakStatus || o.IsRIRPropChanged(_str_idfsOutbreakStatus, c)) 
                  m.Add(_str_idfsOutbreakStatus, o.ObjectIdent + _str_idfsOutbreakStatus, o.ObjectIdent2 + _str_idfsOutbreakStatus, o.ObjectIdent3 + _str_idfsOutbreakStatus, "Int64?", 
                    o.idfsOutbreakStatus == null ? "" : o.idfsOutbreakStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsOutbreakStatus), o.IsInvisible(_str_idfsOutbreakStatus), o.IsRequired(_str_idfsOutbreakStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfGeoLocation, _formname = _str_idfGeoLocation, _type = "Int64?",
              _get_func = o => o.idfGeoLocation,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfGeoLocation != newval) o.idfGeoLocation = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfGeoLocation != c.idfGeoLocation || o.IsRIRPropChanged(_str_idfGeoLocation, c)) 
                  m.Add(_str_idfGeoLocation, o.ObjectIdent + _str_idfGeoLocation, o.ObjectIdent2 + _str_idfGeoLocation, o.ObjectIdent3 + _str_idfGeoLocation, "Int64?", 
                    o.idfGeoLocation == null ? "" : o.idfGeoLocation.ToString(),                  
                  o.IsReadOnly(_str_idfGeoLocation), o.IsInvisible(_str_idfGeoLocation), o.IsRequired(_str_idfGeoLocation)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strGeoLocationName, _formname = _str_strGeoLocationName, _type = "String",
              _get_func = o => o.strGeoLocationName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strGeoLocationName != newval) o.strGeoLocationName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strGeoLocationName != c.strGeoLocationName || o.IsRIRPropChanged(_str_strGeoLocationName, c)) 
                  m.Add(_str_strGeoLocationName, o.ObjectIdent + _str_strGeoLocationName, o.ObjectIdent2 + _str_strGeoLocationName, o.ObjectIdent3 + _str_strGeoLocationName, "String", 
                    o.strGeoLocationName == null ? "" : o.strGeoLocationName.ToString(),                  
                  o.IsReadOnly(_str_strGeoLocationName), o.IsInvisible(_str_strGeoLocationName), o.IsRequired(_str_strGeoLocationName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPatientName, _formname = _str_strPatientName, _type = "String",
              _get_func = o => o.strPatientName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPatientName != newval) o.strPatientName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strPatientName != c.strPatientName || o.IsRIRPropChanged(_str_strPatientName, c)) 
                  m.Add(_str_strPatientName, o.ObjectIdent + _str_strPatientName, o.ObjectIdent2 + _str_strPatientName, o.ObjectIdent3 + _str_strPatientName, "String", 
                    o.strPatientName == null ? "" : o.strPatientName.ToString(),                  
                  o.IsReadOnly(_str_strPatientName), o.IsInvisible(_str_strPatientName), o.IsRequired(_str_strPatientName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHumanPatientName, _formname = _str_strHumanPatientName, _type = "String",
              _get_func = o => o.strHumanPatientName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHumanPatientName != newval) o.strHumanPatientName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strHumanPatientName != c.strHumanPatientName || o.IsRIRPropChanged(_str_strHumanPatientName, c)) 
                  m.Add(_str_strHumanPatientName, o.ObjectIdent + _str_strHumanPatientName, o.ObjectIdent2 + _str_strHumanPatientName, o.ObjectIdent3 + _str_strHumanPatientName, "String", 
                    o.strHumanPatientName == null ? "" : o.strHumanPatientName.ToString(),                  
                  o.IsReadOnly(_str_strHumanPatientName), o.IsInvisible(_str_strHumanPatientName), o.IsRequired(_str_strHumanPatientName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFarmOwner, _formname = _str_strFarmOwner, _type = "String",
              _get_func = o => o.strFarmOwner,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFarmOwner != newval) o.strFarmOwner = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFarmOwner != c.strFarmOwner || o.IsRIRPropChanged(_str_strFarmOwner, c)) 
                  m.Add(_str_strFarmOwner, o.ObjectIdent + _str_strFarmOwner, o.ObjectIdent2 + _str_strFarmOwner, o.ObjectIdent3 + _str_strFarmOwner, "String", 
                    o.strFarmOwner == null ? "" : o.strFarmOwner.ToString(),                  
                  o.IsReadOnly(_str_strFarmOwner), o.IsInvisible(_str_strFarmOwner), o.IsRequired(_str_strFarmOwner)); 
                  }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _formname = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosisOrDiagnosisGroup != c.idfsDiagnosisOrDiagnosisGroup || o.IsRIRPropChanged(_str_Diagnosis, c)) {
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, o.ObjectIdent2 + _str_Diagnosis, o.ObjectIdent3 + _str_Diagnosis, "Lookup", o.idfsDiagnosisOrDiagnosisGroup == null ? "" : o.idfsDiagnosisOrDiagnosisGroup.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_Diagnosis + "Lookup", _formname = _str_Diagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_DiagnosisGroup, _formname = _str_DiagnosisGroup, _type = "Lookup",
              _get_func = o => { if (o.DiagnosisGroup == null) return null; return o.DiagnosisGroup.idfsBaseReference; },
              _set_func = (o, val) => { o.DiagnosisGroup = o.DiagnosisGroupLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsDiagnosisGroup != c.idfsDiagnosisGroup || o.IsRIRPropChanged(_str_DiagnosisGroup, c)) {
                  m.Add(_str_DiagnosisGroup, o.ObjectIdent + _str_DiagnosisGroup, o.ObjectIdent2 + _str_DiagnosisGroup, o.ObjectIdent3 + _str_DiagnosisGroup, "Lookup", o.idfsDiagnosisGroup == null ? "" : o.idfsDiagnosisGroup.ToString(), o.IsReadOnly(_str_DiagnosisGroup), o.IsInvisible(_str_DiagnosisGroup), o.IsRequired(_str_DiagnosisGroup)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_DiagnosisGroup + "Lookup", _formname = _str_DiagnosisGroup + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisGroupLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_OutbreakStatus, _formname = _str_OutbreakStatus, _type = "Lookup",
              _get_func = o => { if (o.OutbreakStatus == null) return null; return o.OutbreakStatus.idfsBaseReference; },
              _set_func = (o, val) => { o.OutbreakStatus = o.OutbreakStatusLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsOutbreakStatus != c.idfsOutbreakStatus || o.IsRIRPropChanged(_str_OutbreakStatus, c)) {
                  m.Add(_str_OutbreakStatus, o.ObjectIdent + _str_OutbreakStatus, o.ObjectIdent2 + _str_OutbreakStatus, o.ObjectIdent3 + _str_OutbreakStatus, "Lookup", o.idfsOutbreakStatus == null ? "" : o.idfsOutbreakStatus.ToString(), o.IsReadOnly(_str_OutbreakStatus), o.IsInvisible(_str_OutbreakStatus), o.IsRequired(_str_OutbreakStatus)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_OutbreakStatus + "Lookup", _formname = _str_OutbreakStatus + "Lookup", _type = "LookupContent",
              _get_func = o => o.OutbreakStatusLookup,
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
            OutbreakListItem obj = (OutbreakListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Diagnosis)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosisOrDiagnosisGroup)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                var oldVal = _Diagnosis;
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Diagnosis != oldVal)
                {
                    if (idfsDiagnosisOrDiagnosisGroup != (_Diagnosis == null
                            ? new Int64?()
                            : (Int64?)_Diagnosis.idfsDiagnosis))
                        idfsDiagnosisOrDiagnosisGroup = _Diagnosis == null 
                            ? new Int64?()
                            : (Int64?)_Diagnosis.idfsDiagnosis; 
                    OnPropertyChanged(_str_Diagnosis); 
                }
            }
        }
        private DiagnosisLookup _Diagnosis;

        
        public List<DiagnosisLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<DiagnosisLookup> _DiagnosisLookup = new List<DiagnosisLookup>();
            
        [LocalizedDisplayName(_str_DiagnosisGroup)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsDiagnosisGroup)]
        public BaseReference DiagnosisGroup
        {
            get { return _DiagnosisGroup == null ? null : ((long)_DiagnosisGroup.Key == 0 ? null : _DiagnosisGroup); }
            set 
            { 
                var oldVal = _DiagnosisGroup;
                _DiagnosisGroup = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_DiagnosisGroup != oldVal)
                {
                    if (idfsDiagnosisGroup != (_DiagnosisGroup == null
                            ? new Int64?()
                            : (Int64?)_DiagnosisGroup.idfsBaseReference))
                        idfsDiagnosisGroup = _DiagnosisGroup == null 
                            ? new Int64?()
                            : (Int64?)_DiagnosisGroup.idfsBaseReference; 
                    OnPropertyChanged(_str_DiagnosisGroup); 
                }
            }
        }
        private BaseReference _DiagnosisGroup;

        
        public BaseReferenceList DiagnosisGroupLookup
        {
            get { return _DiagnosisGroupLookup; }
        }
        private BaseReferenceList _DiagnosisGroupLookup = new BaseReferenceList("rftDiagnosisGroup");
            
        [LocalizedDisplayName(_str_OutbreakStatus)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsOutbreakStatus)]
        public BaseReference OutbreakStatus
        {
            get { return _OutbreakStatus == null ? null : ((long)_OutbreakStatus.Key == 0 ? null : _OutbreakStatus); }
            set 
            { 
                var oldVal = _OutbreakStatus;
                _OutbreakStatus = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_OutbreakStatus != oldVal)
                {
                    if (idfsOutbreakStatus != (_OutbreakStatus == null
                            ? new Int64?()
                            : (Int64?)_OutbreakStatus.idfsBaseReference))
                        idfsOutbreakStatus = _OutbreakStatus == null 
                            ? new Int64?()
                            : (Int64?)_OutbreakStatus.idfsBaseReference; 
                    OnPropertyChanged(_str_OutbreakStatus); 
                }
            }
        }
        private BaseReference _OutbreakStatus;

        
        public BaseReferenceList OutbreakStatusLookup
        {
            get { return _OutbreakStatusLookup; }
        }
        private BaseReferenceList _OutbreakStatusLookup = new BaseReferenceList("rftOutbreakStatus");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosisOrDiagnosisGroup);
            
                case _str_DiagnosisGroup:
                    return new BvSelectList(DiagnosisGroupLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, DiagnosisGroup, _str_idfsDiagnosisGroup);
            
                case _str_OutbreakStatus:
                    return new BvSelectList(OutbreakStatusLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, OutbreakStatus, _str_idfsOutbreakStatus);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "OutbreakListItem";

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
            var ret = base.Clone() as OutbreakListItem;
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
            var ret = base.Clone() as OutbreakListItem;
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
        public OutbreakListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as OutbreakListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfOutbreak; } }
        public string KeyName { get { return "idfOutbreak"; } }
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
        
            var _prev_idfsDiagnosisOrDiagnosisGroup_Diagnosis = idfsDiagnosisOrDiagnosisGroup;
            var _prev_idfsDiagnosisGroup_DiagnosisGroup = idfsDiagnosisGroup;
            var _prev_idfsOutbreakStatus_OutbreakStatus = idfsOutbreakStatus;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosisOrDiagnosisGroup_Diagnosis != idfsDiagnosisOrDiagnosisGroup)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosisOrDiagnosisGroup);
            }
            if (_prev_idfsDiagnosisGroup_DiagnosisGroup != idfsDiagnosisGroup)
            {
                _DiagnosisGroup = _DiagnosisGroupLookup.FirstOrDefault(c => c.idfsBaseReference == idfsDiagnosisGroup);
            }
            if (_prev_idfsOutbreakStatus_OutbreakStatus != idfsOutbreakStatus)
            {
                _OutbreakStatus = _OutbreakStatusLookup.FirstOrDefault(c => c.idfsBaseReference == idfsOutbreakStatus);
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

        private bool IsRIRPropChanged(string fld, OutbreakListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public OutbreakListItem()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(OutbreakListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(OutbreakListItem_PropertyChanged);
        }
        private void OutbreakListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as OutbreakListItem).Changed(e.PropertyName);
            
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
            OutbreakListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            OutbreakListItem obj = this;
            
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


        internal Dictionary<string, Func<OutbreakListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<OutbreakListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<OutbreakListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<OutbreakListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<OutbreakListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<OutbreakListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<OutbreakListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~OutbreakListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                LookupManager.RemoveObject("rftDiagnosisGroup", this);
                
                LookupManager.RemoveObject("rftOutbreakStatus", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
            if (lookup_object == "rftDiagnosisGroup")
                _getAccessor().LoadLookup_DiagnosisGroup(manager, this);
            
            if (lookup_object == "rftOutbreakStatus")
                _getAccessor().LoadLookup_OutbreakStatus(manager, this);
            
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
    
        #region Class for web grid
        public class OutbreakListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfOutbreak { get; set; }
        
            public String strOutbreakID { get; set; }
        
            public String strDiagnosisOrDiagnosisGroup { get; set; }
        
            public DateTime? datStartDate { get; set; }
        
            public DateTime? datFinishDate { get; set; }
        
            public String strGeoLocationName { get; set; }
        
            public String strOutbreakStatus { get; set; }
        
            public String strPatientName { get; set; }
        
        }
        public partial class OutbreakListItemGridModelList : List<OutbreakListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public OutbreakListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<OutbreakListItem>, errMes);
            }
            public OutbreakListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<OutbreakListItem>, errMes);
            }
            public OutbreakListItemGridModelList(long key, IEnumerable<OutbreakListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public OutbreakListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<OutbreakListItem>(), null);
            }
            partial void filter(List<OutbreakListItem> items);
            private void LoadGridModelList(long key, IEnumerable<OutbreakListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strOutbreakID,_str_strDiagnosisOrDiagnosisGroup,_str_datStartDate,_str_datFinishDate,_str_strGeoLocationName,_str_strOutbreakStatus,_str_strPatientName};
                    
                Hiddens = new List<string> {_str_idfOutbreak};
                Keys = new List<string> {_str_idfOutbreak};
                Labels = new Dictionary<string, string> {{_str_strOutbreakID, _str_strOutbreakID},{_str_strDiagnosisOrDiagnosisGroup, _str_strDiagnosisOrDiagnosisGroup},{_str_datStartDate, _str_datStartDate},{_str_datFinishDate, _str_datFinishDate},{_str_strGeoLocationName, _str_strGeoLocationName},{_str_strOutbreakStatus, _str_strOutbreakStatus},{_str_strPatientName, _str_strPatientName}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strOutbreakID, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "ActionEditOutbreak")}};
                OutbreakListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<OutbreakListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new OutbreakListItemGridModel()
                {
                    ItemKey=c.idfOutbreak,strOutbreakID=c.strOutbreakID,strDiagnosisOrDiagnosisGroup=c.strDiagnosisOrDiagnosisGroup,datStartDate=c.datStartDate,datFinishDate=c.datFinishDate,strGeoLocationName=c.strGeoLocationName,strOutbreakStatus=c.strOutbreakStatus,strPatientName=c.strPatientName
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
        : DataAccessor<OutbreakListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<OutbreakListItem>
            
            , IObjectSelectList
            , IObjectSelectList<OutbreakListItem>
                    
            , IObjectPost
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfOutbreak"; } }
            #endregion
        
            private delegate void on_action(OutbreakListItem obj);
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
            private BaseReference.Accessor DiagnosisGroupAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor OutbreakStatusAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<OutbreakListItem> SelectListT(DbManagerProxy manager
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
            
            private List<OutbreakListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_Outbreak_SelectList.* from dbo.fn_Outbreak_SelectList(@LangID
                    ) ");
                
                if (filters.Contains("strHumanPatientName1"))
                {
                    
                    sql.Append(" " + @"
            inner join
            (
            select distinct hc.idfOutbreak from tlbHumanCase hc
            inner join tlbHuman h on h.idfHuman = hc.idfHuman
            where dbo.fnConcatFullName(h.strLastName, h.strFirstName, h.strSecondName) like @strHumanPatientName1
            and hc.intRowStatus = 0
            and h.intRowStatus = 0
            ) o_hc on o_hc.idfOutbreak = dbo.fn_Outbreak_SelectList.idfOutbreak
          ");
                      
                }
                
                if (filters.Contains("strFarmOwner1"))
                {
                    
                    sql.Append(" " + @"
          inner join
			    (
			    select distinct vc.idfOutbreak from tlbVetCase vc 
				    inner join tlbFarm f on f.idfFarm = vc.idfFarm
				    inner join tlbHuman h on h.idfHuman = f.idfHuman
			    where dbo.fnConcatFullName(h.strLastName, h.strFirstName, h.strSecondName) like @strFarmOwner1
				    and vc.intRowStatus = 0 
				    and f.intRowStatus=0 
				    and h.intRowStatus = 0
			    ) o_vc on o_vc.idfOutbreak = dbo.fn_Outbreak_SelectList.idfOutbreak
          ");
                      
                }
                
                sql.Append(" where 0 = 0");
                
                if (ModelUserContext.IsWebContext && EidssSiteContext.Instance.SiteType == SiteType.TLVL)
                {
                    sql.Append(@" and exists (select * from  tflOutbreakFiltered f inner join tflSiteToSiteGroup on tflSiteToSiteGroup.idfSiteGroup = f.idfSiteGroup and tflSiteToSiteGroup.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString() + " where f.idfOutbreak = fn_Outbreak_SelectList.idfOutbreak)");
                }
                
                if (filters.Contains("strHumanPatientName1"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strHumanPatientName1") == 1)
                    {
                        sql.AppendFormat("1=1", filters.Operation("strHumanPatientName1"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strHumanPatientName1"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strHumanPatientName1") ? " or " : " and ");
                            sql.AppendFormat("@strHumanPatientName1_{1}", filters.Operation("strHumanPatientName1", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("strFarmOwner1"))
                {
                    sql.AppendFormat(" and (");
                    
                    if (filters.Count("strFarmOwner1") == 1)
                    {
                        sql.AppendFormat("1=1", filters.Operation("strFarmOwner1"));
                    }
                    else
                    {
                        for (int i = 0; i < filters.Count("strFarmOwner1"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("strFarmOwner1") ? " or " : " and ");
                            sql.AppendFormat("@strFarmOwner1_{1}", filters.Operation("strFarmOwner1", i), i);
                        }
                    }
                        
                    sql.AppendFormat(")");
                }
                            
                if (filters.Contains("idfOutbreak"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfOutbreak"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfOutbreak") ? " or " : " and ");
                        
                        if (filters.Operation("idfOutbreak", i) == "&")
                          sql.AppendFormat("(isnull(fn_Outbreak_SelectList.idfOutbreak,0) {0} @idfOutbreak_{1} = @idfOutbreak_{1})", filters.Operation("idfOutbreak", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Outbreak_SelectList.idfOutbreak,0) {0} @idfOutbreak_{1}", filters.Operation("idfOutbreak", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strOutbreakID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strOutbreakID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strOutbreakID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Outbreak_SelectList.strOutbreakID {0} @strOutbreakID_{1}", filters.Operation("strOutbreakID", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_Outbreak_SelectList.datStartDate, 112) {0} CONVERT(NVARCHAR(8), @datStartDate_{1}, 112)", filters.Operation("datStartDate", i), i);
                            
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
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_Outbreak_SelectList.datFinishDate, 112) {0} CONVERT(NVARCHAR(8), @datFinishDate_{1}, 112)", filters.Operation("datFinishDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strDiagnosisOrDiagnosisGroup"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strDiagnosisOrDiagnosisGroup"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strDiagnosisOrDiagnosisGroup") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Outbreak_SelectList.strDiagnosisOrDiagnosisGroup {0} @strDiagnosisOrDiagnosisGroup_{1}", filters.Operation("strDiagnosisOrDiagnosisGroup", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsDiagnosisOrDiagnosisGroup"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsDiagnosisOrDiagnosisGroup"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsDiagnosisOrDiagnosisGroup") ? " or " : " and ");
                        
                        if (filters.Operation("idfsDiagnosisOrDiagnosisGroup", i) == "&")
                          sql.AppendFormat("(isnull(fn_Outbreak_SelectList.idfsDiagnosisOrDiagnosisGroup,0) {0} @idfsDiagnosisOrDiagnosisGroup_{1} = @idfsDiagnosisOrDiagnosisGroup_{1})", filters.Operation("idfsDiagnosisOrDiagnosisGroup", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Outbreak_SelectList.idfsDiagnosisOrDiagnosisGroup,0) {0} @idfsDiagnosisOrDiagnosisGroup_{1}", filters.Operation("idfsDiagnosisOrDiagnosisGroup", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strDiagnosisGroup"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strDiagnosisGroup"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strDiagnosisGroup") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Outbreak_SelectList.strDiagnosisGroup {0} @strDiagnosisGroup_{1}", filters.Operation("strDiagnosisGroup", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsDiagnosisGroup"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsDiagnosisGroup"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsDiagnosisGroup") ? " or " : " and ");
                        
                        if (filters.Operation("idfsDiagnosisGroup", i) == "&")
                          sql.AppendFormat("(isnull(fn_Outbreak_SelectList.idfsDiagnosisGroup,0) {0} @idfsDiagnosisGroup_{1} = @idfsDiagnosisGroup_{1})", filters.Operation("idfsDiagnosisGroup", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Outbreak_SelectList.idfsDiagnosisGroup,0) {0} @idfsDiagnosisGroup_{1}", filters.Operation("idfsDiagnosisGroup", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strOutbreakStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strOutbreakStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strOutbreakStatus") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Outbreak_SelectList.strOutbreakStatus {0} @strOutbreakStatus_{1}", filters.Operation("strOutbreakStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsOutbreakStatus"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsOutbreakStatus"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsOutbreakStatus") ? " or " : " and ");
                        
                        if (filters.Operation("idfsOutbreakStatus", i) == "&")
                          sql.AppendFormat("(isnull(fn_Outbreak_SelectList.idfsOutbreakStatus,0) {0} @idfsOutbreakStatus_{1} = @idfsOutbreakStatus_{1})", filters.Operation("idfsOutbreakStatus", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Outbreak_SelectList.idfsOutbreakStatus,0) {0} @idfsOutbreakStatus_{1}", filters.Operation("idfsOutbreakStatus", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfGeoLocation"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfGeoLocation"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfGeoLocation") ? " or " : " and ");
                        
                        if (filters.Operation("idfGeoLocation", i) == "&")
                          sql.AppendFormat("(isnull(fn_Outbreak_SelectList.idfGeoLocation,0) {0} @idfGeoLocation_{1} = @idfGeoLocation_{1})", filters.Operation("idfGeoLocation", i), i);
                        else
                          sql.AppendFormat("isnull(fn_Outbreak_SelectList.idfGeoLocation,0) {0} @idfGeoLocation_{1}", filters.Operation("idfGeoLocation", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strGeoLocationName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strGeoLocationName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strGeoLocationName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Outbreak_SelectList.strGeoLocationName {0} @strGeoLocationName_{1}", filters.Operation("strGeoLocationName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strPatientName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strPatientName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strPatientName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Outbreak_SelectList.strPatientName {0} @strPatientName_{1}", filters.Operation("strPatientName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strHumanPatientName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strHumanPatientName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strHumanPatientName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Outbreak_SelectList.strHumanPatientName {0} @strHumanPatientName_{1}", filters.Operation("strHumanPatientName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFarmOwner"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFarmOwner"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFarmOwner") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_Outbreak_SelectList.strFarmOwner {0} @strFarmOwner_{1}", filters.Operation("strFarmOwner", i), i);
                            
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
                    
                    if (filters.Contains("idfsDiagnosisGroup"))
                        
                        if (filters.Count("idfsDiagnosisGroup") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosisGroup", ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosisGroup"), filters.Value("idfsDiagnosisGroup"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("idfsDiagnosisGroup"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosisGroup_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosisGroup", i), filters.Value("idfsDiagnosisGroup", i))));
                        }
                            
                    if (filters.Contains("strHumanPatientName1"))
                        
                        if (filters.Count("strHumanPatientName1") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strHumanPatientName1", ParsingHelper.CorrectLikeValue(filters.Operation("strHumanPatientName1"), filters.Value("strHumanPatientName1"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strHumanPatientName1"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strHumanPatientName1_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strHumanPatientName1", i), filters.Value("strHumanPatientName1", i))));
                        }
                            
                    if (filters.Contains("strFarmOwner1"))
                        
                        if (filters.Count("strFarmOwner1") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFarmOwner1", ParsingHelper.CorrectLikeValue(filters.Operation("strFarmOwner1"), filters.Value("strFarmOwner1"))));
                        }
                        else
                        {
                            for (int i = 0; i < filters.Count("strFarmOwner1"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFarmOwner1_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFarmOwner1", i), filters.Value("strFarmOwner1", i))));
                        }
                            
                    if (filters.Contains("idfOutbreak"))
                        for (int i = 0; i < filters.Count("idfOutbreak"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfOutbreak_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfOutbreak", i), filters.Value("idfOutbreak", i))));
                      
                    if (filters.Contains("strOutbreakID"))
                        for (int i = 0; i < filters.Count("strOutbreakID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strOutbreakID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strOutbreakID", i), filters.Value("strOutbreakID", i))));
                      
                    if (filters.Contains("datStartDate"))
                        for (int i = 0; i < filters.Count("datStartDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datStartDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datStartDate", i), filters.Value("datStartDate", i))));
                      
                    if (filters.Contains("datFinishDate"))
                        for (int i = 0; i < filters.Count("datFinishDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datFinishDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datFinishDate", i), filters.Value("datFinishDate", i))));
                      
                    if (filters.Contains("strDiagnosisOrDiagnosisGroup"))
                        for (int i = 0; i < filters.Count("strDiagnosisOrDiagnosisGroup"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strDiagnosisOrDiagnosisGroup_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strDiagnosisOrDiagnosisGroup", i), filters.Value("strDiagnosisOrDiagnosisGroup", i))));
                      
                    if (filters.Contains("idfsDiagnosisOrDiagnosisGroup"))
                        for (int i = 0; i < filters.Count("idfsDiagnosisOrDiagnosisGroup"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosisOrDiagnosisGroup_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosisOrDiagnosisGroup", i), filters.Value("idfsDiagnosisOrDiagnosisGroup", i))));
                      
                    if (filters.Contains("strDiagnosisGroup"))
                        for (int i = 0; i < filters.Count("strDiagnosisGroup"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strDiagnosisGroup_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strDiagnosisGroup", i), filters.Value("strDiagnosisGroup", i))));
                      
                    if (filters.Contains("idfsDiagnosisGroup"))
                        for (int i = 0; i < filters.Count("idfsDiagnosisGroup"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsDiagnosisGroup_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsDiagnosisGroup", i), filters.Value("idfsDiagnosisGroup", i))));
                      
                    if (filters.Contains("strOutbreakStatus"))
                        for (int i = 0; i < filters.Count("strOutbreakStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strOutbreakStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strOutbreakStatus", i), filters.Value("strOutbreakStatus", i))));
                      
                    if (filters.Contains("idfsOutbreakStatus"))
                        for (int i = 0; i < filters.Count("idfsOutbreakStatus"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsOutbreakStatus_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsOutbreakStatus", i), filters.Value("idfsOutbreakStatus", i))));
                      
                    if (filters.Contains("idfGeoLocation"))
                        for (int i = 0; i < filters.Count("idfGeoLocation"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfGeoLocation_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfGeoLocation", i), filters.Value("idfGeoLocation", i))));
                      
                    if (filters.Contains("strGeoLocationName"))
                        for (int i = 0; i < filters.Count("strGeoLocationName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strGeoLocationName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strGeoLocationName", i), filters.Value("strGeoLocationName", i))));
                      
                    if (filters.Contains("strPatientName"))
                        for (int i = 0; i < filters.Count("strPatientName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strPatientName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strPatientName", i), filters.Value("strPatientName", i))));
                      
                    if (filters.Contains("strHumanPatientName"))
                        for (int i = 0; i < filters.Count("strHumanPatientName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strHumanPatientName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strHumanPatientName", i), filters.Value("strHumanPatientName", i))));
                      
                    if (filters.Contains("strFarmOwner"))
                        for (int i = 0; i < filters.Count("strFarmOwner"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFarmOwner_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFarmOwner", i), filters.Value("strFarmOwner", i))));
                      
                    List<OutbreakListItem> objs = manager.ExecuteList<OutbreakListItem>();
                    if (bTransactionStarted)
                    {
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
                    }
                    throw DbModelException.Create(e);
                }
            }
            partial void ListSelected(DbManagerProxy manager, List<OutbreakListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spOutbreak_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, OutbreakListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, OutbreakListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private OutbreakListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    OutbreakListItem obj = OutbreakListItem.CreateInstance();
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

            
            public OutbreakListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public OutbreakListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public OutbreakListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ActionEditOutbreak(DbManagerProxy manager, OutbreakListItem obj, List<object> pars)
            {
                
                return ActionEditOutbreak(manager, obj
                    );
            }
            public ActResult ActionEditOutbreak(DbManagerProxy manager, OutbreakListItem obj
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("ActionEditOutbreak"))
                    throw new PermissionException("Outbreak", "ActionEditOutbreak");
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(OutbreakListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(OutbreakListItem obj)
            {
                
            }
    
            public void LoadLookup_Diagnosis(DbManagerProxy manager, OutbreakListItem obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => !EidssUserContext.User.DenyDiagnosis.ContainsKey(c.idfsDiagnosis))
                        
                    .Where(c => ((c.intHACode & (int)HACode.HumanLivestockAvianVector) != 0) || c.idfsDiagnosis == obj.idfsDiagnosisOrDiagnosisGroup)
                        
                    .Where(c => (c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase) || c.idfsDiagnosis == obj.idfsDiagnosisOrDiagnosisGroup)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosisOrDiagnosisGroup))
                    
                    .ToList());
                
                if (obj.idfsDiagnosisOrDiagnosisGroup != null && obj.idfsDiagnosisOrDiagnosisGroup != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosisOrDiagnosisGroup);
                    
                }
              
                
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "SelectLookupList");
            }
            
            public void LoadLookup_DiagnosisGroup(DbManagerProxy manager, OutbreakListItem obj)
            {
                
                obj.DiagnosisGroupLookup.Clear();
                
                obj.DiagnosisGroupLookup.Add(DiagnosisGroupAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisGroupLookup.AddRange(DiagnosisGroupAccessor.rftDiagnosisGroup_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsDiagnosisGroup))
                    
                    .ToList());
                
                if (obj.idfsDiagnosisGroup != null && obj.idfsDiagnosisGroup != 0)
                {
                    obj.DiagnosisGroup = obj.DiagnosisGroupLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsDiagnosisGroup);
                    
                }
              
                
                LookupManager.AddObject("rftDiagnosisGroup", obj, DiagnosisGroupAccessor.GetType(), "rftDiagnosisGroup_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_OutbreakStatus(DbManagerProxy manager, OutbreakListItem obj)
            {
                
                obj.OutbreakStatusLookup.Clear();
                
                obj.OutbreakStatusLookup.Add(OutbreakStatusAccessor.CreateNewT(manager, null));
                
                obj.OutbreakStatusLookup.AddRange(OutbreakStatusAccessor.rftOutbreakStatus_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsOutbreakStatus))
                    
                    .ToList());
                
                if (obj.idfsOutbreakStatus != null && obj.idfsOutbreakStatus != 0)
                {
                    obj.OutbreakStatus = obj.OutbreakStatusLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsOutbreakStatus);
                    
                }
              
                
                LookupManager.AddObject("rftOutbreakStatus", obj, OutbreakStatusAccessor.GetType(), "rftOutbreakStatus_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, OutbreakListItem obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
                LoadLookup_DiagnosisGroup(manager, obj);
                
                LoadLookup_OutbreakStatus(manager, obj);
                
            }
    
            [SprocName("spOutbreak_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spOutbreak_Delete")]
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
                    OutbreakListItem bo = obj as OutbreakListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("Outbreak", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("Outbreak", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("Outbreak", "Update");
                    }
                    
                    long mainObject = bo.idfOutbreak;
                    
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoOutbreak;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbOutbreak;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as OutbreakListItem, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, OutbreakListItem obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfOutbreak
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
            
            public bool ValidateCanDelete(OutbreakListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, OutbreakListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfOutbreak
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, false, obj);
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
        
      
            protected ValidationModelException ChainsValidate(OutbreakListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(OutbreakListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as OutbreakListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, OutbreakListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(OutbreakListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(OutbreakListItem obj)
    {
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName))
      {
      
            obj
              .AddHiddenPersonalData("strPatientName", c=>true);
            
            obj
              .AddHiddenPersonalData("strHumanPatientName", c=>true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement))
      {
      
            obj
              .AddHiddenPersonalData("strFarmOwner", c=>true);
            
            obj
              .AddHiddenPersonalData("strPatientName", c=>true);
            
      }
    
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details))
      {
      
            obj
              .AddHiddenPersonalData("strFarmOwner", c=>true);
            
            obj
              .AddHiddenPersonalData("strPatientName", c=>true);
            
      }
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as OutbreakListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as OutbreakListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "OutbreakListItemDetail"; } }
            public string HelpIdWin { get { return "OB_C10"; } }
            public string HelpIdWeb { get { return "OB_C10"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private OutbreakListItem m_obj;
            internal Permissions(OutbreakListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("Outbreak.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_Outbreak_SelectList";
            public static string spCount = "spOutbreak_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spOutbreak_Delete";
            public static string spCanDelete = "spOutbreak_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<OutbreakListItem, bool>> RequiredByField = new Dictionary<string, Func<OutbreakListItem, bool>>();
            public static Dictionary<string, Func<OutbreakListItem, bool>> RequiredByProperty = new Dictionary<string, Func<OutbreakListItem, bool>>();
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
                
                Sizes.Add(_str_strOutbreakID, 200);
                Sizes.Add(_str_strDiagnosisOrDiagnosisGroup, 2000);
                Sizes.Add(_str_strDiagnosisGroup, 2000);
                Sizes.Add(_str_strOutbreakStatus, 2000);
                Sizes.Add(_str_strGeoLocationName, 1000);
                Sizes.Add(_str_strPatientName, 400);
                Sizes.Add(_str_strHumanPatientName, 400);
                Sizes.Add(_str_strFarmOwner, 400);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strOutbreakID",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strOutbreakID",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosisOrDiagnosisGroup",
                    EditorType.Lookup,
                    EditorControlWidth.Large, true, true, false, false, 
                    "DiagnosisName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "DiagnosisLookup", typeof(DiagnosisLookup), (o) => { var c = (DiagnosisLookup)o; return c.idfsDiagnosis; }, (o) => { var c = (DiagnosisLookup)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsDiagnosisGroup",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strDiagnosisGroup",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, "DiagnosisGroupLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datStartDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "Outbreak.datStartDate",
                    c => DateTime.Today.AddDays(-bv.common.Configuration.BaseSettings.DefaultDateFilter), null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "datFinishDate",
                    EditorType.Date,
                    EditorControlWidth.Normal, true, true, true, false, 
                    "Outbreak.datFinishDate",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strGeoLocationName",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strGeoLocationName",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsOutbreakStatus",
                    EditorType.Lookup,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strOutbreakStatus",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, "OutbreakStatusLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strHumanPatientName1",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strHumanPatientName",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, null, null, null, null, null,false
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFarmOwner1",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "strFarmOwnerName",
                    null, null, c => false, false, SearchPanelLocation.Main, true, null, null, null, null, null, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfOutbreak,
                    _str_idfOutbreak, null, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strOutbreakID,
                    _str_strOutbreakID, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosisOrDiagnosisGroup,
                    _str_strDiagnosisOrDiagnosisGroup, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datStartDate,
                    _str_datStartDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFinishDate,
                    _str_datFinishDate, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strGeoLocationName,
                    _str_strGeoLocationName, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strOutbreakStatus,
                    _str_strOutbreakStatus, null, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strPatientName,
                    _str_strPatientName, null, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "ActionEditOutbreak",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionEditOutbreak(manager, (OutbreakListItem)c, pars),
                        
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<Outbreak>().CreateNew(manager, c, pars == null ? null : (int?)pars[0])),
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<Outbreak>().SelectDetail(manager, pars[0])),
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
                                c = ObjectAccessor.CreatorInterface<OutbreakListItem>().CreateWithParams(manager, null, pars);
                                ((OutbreakListItem)c).idfOutbreak = (long)pars[0];
                                ((OutbreakListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((OutbreakListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<OutbreakListItem>().Post(manager, (OutbreakListItem)c), c);
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
                    
                Actions.Add(new ActionMetaItem(
                    "Report",
                    ActionTypes.Report,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strReport_Id",
                        "Report",
                        /*from BvMessages*/"tooltipReport_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipReport_Id",
                        ActionsAlignment.Left,
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
    
        AddHiddenPersonalData("strPatientName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName));
      
        AddHiddenPersonalData("strHumanPatientName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Human_PersonName));
      
        AddHiddenPersonalData("strFarmOwner", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("strPatientName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Settlement));
      
        AddHiddenPersonalData("strFarmOwner", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      
        AddHiddenPersonalData("strPatientName", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.Vet_Farm_Details));
      

    }
  
        }
        #endregion
    

        #endregion
        }
    
}
	