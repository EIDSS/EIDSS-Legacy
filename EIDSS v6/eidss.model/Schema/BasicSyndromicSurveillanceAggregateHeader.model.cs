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
    public abstract partial class BasicSyndromicSurveillanceAggregateHeader : 
        EditableObject<BasicSyndromicSurveillanceAggregateHeader>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfAggregateHeader), NonUpdatable, PrimaryKey]
        public abstract Int64 idfAggregateHeader { get; set; }
                
        [LocalizedDisplayName(_str_strFormID)]
        [MapField(_str_strFormID)]
        public abstract String strFormID { get; set; }
        protected String strFormID_Original { get { return ((EditableValue<String>)((dynamic)this)._strFormID).OriginalValue; } }
        protected String strFormID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFormID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDateEntered)]
        [MapField(_str_datDateEntered)]
        public abstract DateTime datDateEntered { get; set; }
        protected DateTime datDateEntered_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datDateEntered).OriginalValue; } }
        protected DateTime datDateEntered_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datDateEntered).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDateLastSaved)]
        [MapField(_str_datDateLastSaved)]
        public abstract DateTime? datDateLastSaved { get; set; }
        protected DateTime? datDateLastSaved_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateLastSaved).OriginalValue; } }
        protected DateTime? datDateLastSaved_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateLastSaved).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfEnteredBy)]
        [MapField(_str_idfEnteredBy)]
        public abstract Int64 idfEnteredBy { get; set; }
        protected Int64 idfEnteredBy_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfEnteredBy).OriginalValue; } }
        protected Int64 idfEnteredBy_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfEnteredBy).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsSite)]
        [MapField(_str_idfsSite)]
        public abstract Int64 idfsSite { get; set; }
        protected Int64 idfsSite_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).OriginalValue; } }
        protected Int64 idfsSite_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsSite).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intYear)]
        [MapField(_str_intYear)]
        public abstract Int32 intYear { get; set; }
        protected Int32 intYear_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intYear).OriginalValue; } }
        protected Int32 intYear_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intYear).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intWeek)]
        [MapField(_str_intWeek)]
        public abstract Int32 intWeek { get; set; }
        protected Int32 intWeek_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intWeek).OriginalValue; } }
        protected Int32 intWeek_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intWeek).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datStartDate)]
        [MapField(_str_datStartDate)]
        public abstract DateTime datStartDate { get; set; }
        protected DateTime datStartDate_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datStartDate).OriginalValue; } }
        protected DateTime datStartDate_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datStartDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFinishDate)]
        [MapField(_str_datFinishDate)]
        public abstract DateTime datFinishDate { get; set; }
        protected DateTime datFinishDate_Original { get { return ((EditableValue<DateTime>)((dynamic)this)._datFinishDate).OriginalValue; } }
        protected DateTime datFinishDate_Previous { get { return ((EditableValue<DateTime>)((dynamic)this)._datFinishDate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datModificationForArchiveDate)]
        [MapField(_str_datModificationForArchiveDate)]
        public abstract DateTime? datModificationForArchiveDate { get; set; }
        protected DateTime? datModificationForArchiveDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationForArchiveDate).OriginalValue; } }
        protected DateTime? datModificationForArchiveDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datModificationForArchiveDate).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<BasicSyndromicSurveillanceAggregateHeader, object> _get_func;
            internal Action<BasicSyndromicSurveillanceAggregateHeader, string> _set_func;
            internal Action<BasicSyndromicSurveillanceAggregateHeader, BasicSyndromicSurveillanceAggregateHeader, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAggregateHeader = "idfAggregateHeader";
        internal const string _str_strFormID = "strFormID";
        internal const string _str_datDateEntered = "datDateEntered";
        internal const string _str_datDateLastSaved = "datDateLastSaved";
        internal const string _str_idfEnteredBy = "idfEnteredBy";
        internal const string _str_idfsSite = "idfsSite";
        internal const string _str_intYear = "intYear";
        internal const string _str_intWeek = "intWeek";
        internal const string _str_datStartDate = "datStartDate";
        internal const string _str_datFinishDate = "datFinishDate";
        internal const string _str_datModificationForArchiveDate = "datModificationForArchiveDate";
        internal const string _str_strSite = "strSite";
        internal const string _str_strEnteredBy = "strEnteredBy";
        internal const string _str_BSSAggregateDetail = "BSSAggregateDetail";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfAggregateHeader, _formname = _str_idfAggregateHeader, _type = "Int64",
              _get_func = o => o.idfAggregateHeader,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfAggregateHeader != newval) o.idfAggregateHeader = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfAggregateHeader != c.idfAggregateHeader || o.IsRIRPropChanged(_str_idfAggregateHeader, c)) 
                  m.Add(_str_idfAggregateHeader, o.ObjectIdent + _str_idfAggregateHeader, o.ObjectIdent2 + _str_idfAggregateHeader, o.ObjectIdent3 + _str_idfAggregateHeader, "Int64", 
                    o.idfAggregateHeader == null ? "" : o.idfAggregateHeader.ToString(),                  
                  o.IsReadOnly(_str_idfAggregateHeader), o.IsInvisible(_str_idfAggregateHeader), o.IsRequired(_str_idfAggregateHeader)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFormID, _formname = _str_strFormID, _type = "String",
              _get_func = o => o.strFormID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFormID != newval) o.strFormID = newval; },
              _compare_func = (o, c, m) => {
                if (o.strFormID != c.strFormID || o.IsRIRPropChanged(_str_strFormID, c)) 
                  m.Add(_str_strFormID, o.ObjectIdent + _str_strFormID, o.ObjectIdent2 + _str_strFormID, o.ObjectIdent3 + _str_strFormID, "String", 
                    o.strFormID == null ? "" : o.strFormID.ToString(),                  
                  o.IsReadOnly(_str_strFormID), o.IsInvisible(_str_strFormID), o.IsRequired(_str_strFormID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDateEntered, _formname = _str_datDateEntered, _type = "DateTime",
              _get_func = o => o.datDateEntered,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTime(val); if (o.datDateEntered != newval) o.datDateEntered = newval; },
              _compare_func = (o, c, m) => {
                if (o.datDateEntered != c.datDateEntered || o.IsRIRPropChanged(_str_datDateEntered, c)) 
                  m.Add(_str_datDateEntered, o.ObjectIdent + _str_datDateEntered, o.ObjectIdent2 + _str_datDateEntered, o.ObjectIdent3 + _str_datDateEntered, "DateTime", 
                    o.datDateEntered == null ? "" : o.datDateEntered.ToString(),                  
                  o.IsReadOnly(_str_datDateEntered), o.IsInvisible(_str_datDateEntered), o.IsRequired(_str_datDateEntered)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDateLastSaved, _formname = _str_datDateLastSaved, _type = "DateTime?",
              _get_func = o => o.datDateLastSaved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDateLastSaved != newval) o.datDateLastSaved = newval; },
              _compare_func = (o, c, m) => {
                if (o.datDateLastSaved != c.datDateLastSaved || o.IsRIRPropChanged(_str_datDateLastSaved, c)) 
                  m.Add(_str_datDateLastSaved, o.ObjectIdent + _str_datDateLastSaved, o.ObjectIdent2 + _str_datDateLastSaved, o.ObjectIdent3 + _str_datDateLastSaved, "DateTime?", 
                    o.datDateLastSaved == null ? "" : o.datDateLastSaved.ToString(),                  
                  o.IsReadOnly(_str_datDateLastSaved), o.IsInvisible(_str_datDateLastSaved), o.IsRequired(_str_datDateLastSaved)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfEnteredBy, _formname = _str_idfEnteredBy, _type = "Int64",
              _get_func = o => o.idfEnteredBy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfEnteredBy != newval) o.idfEnteredBy = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfEnteredBy != c.idfEnteredBy || o.IsRIRPropChanged(_str_idfEnteredBy, c)) 
                  m.Add(_str_idfEnteredBy, o.ObjectIdent + _str_idfEnteredBy, o.ObjectIdent2 + _str_idfEnteredBy, o.ObjectIdent3 + _str_idfEnteredBy, "Int64", 
                    o.idfEnteredBy == null ? "" : o.idfEnteredBy.ToString(),                  
                  o.IsReadOnly(_str_idfEnteredBy), o.IsInvisible(_str_idfEnteredBy), o.IsRequired(_str_idfEnteredBy)); 
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
              _name = _str_intYear, _formname = _str_intYear, _type = "Int32",
              _get_func = o => o.intYear,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intYear != newval) o.intYear = newval; },
              _compare_func = (o, c, m) => {
                if (o.intYear != c.intYear || o.IsRIRPropChanged(_str_intYear, c)) 
                  m.Add(_str_intYear, o.ObjectIdent + _str_intYear, o.ObjectIdent2 + _str_intYear, o.ObjectIdent3 + _str_intYear, "Int32", 
                    o.intYear == null ? "" : o.intYear.ToString(),                  
                  o.IsReadOnly(_str_intYear), o.IsInvisible(_str_intYear), o.IsRequired(_str_intYear)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intWeek, _formname = _str_intWeek, _type = "Int32",
              _get_func = o => o.intWeek,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intWeek != newval) o.intWeek = newval; },
              _compare_func = (o, c, m) => {
                if (o.intWeek != c.intWeek || o.IsRIRPropChanged(_str_intWeek, c)) 
                  m.Add(_str_intWeek, o.ObjectIdent + _str_intWeek, o.ObjectIdent2 + _str_intWeek, o.ObjectIdent3 + _str_intWeek, "Int32", 
                    o.intWeek == null ? "" : o.intWeek.ToString(),                  
                  o.IsReadOnly(_str_intWeek), o.IsInvisible(_str_intWeek), o.IsRequired(_str_intWeek)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datStartDate, _formname = _str_datStartDate, _type = "DateTime",
              _get_func = o => o.datStartDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTime(val); if (o.datStartDate != newval) o.datStartDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datStartDate != c.datStartDate || o.IsRIRPropChanged(_str_datStartDate, c)) 
                  m.Add(_str_datStartDate, o.ObjectIdent + _str_datStartDate, o.ObjectIdent2 + _str_datStartDate, o.ObjectIdent3 + _str_datStartDate, "DateTime", 
                    o.datStartDate == null ? "" : o.datStartDate.ToString(),                  
                  o.IsReadOnly(_str_datStartDate), o.IsInvisible(_str_datStartDate), o.IsRequired(_str_datStartDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datFinishDate, _formname = _str_datFinishDate, _type = "DateTime",
              _get_func = o => o.datFinishDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTime(val); if (o.datFinishDate != newval) o.datFinishDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datFinishDate != c.datFinishDate || o.IsRIRPropChanged(_str_datFinishDate, c)) 
                  m.Add(_str_datFinishDate, o.ObjectIdent + _str_datFinishDate, o.ObjectIdent2 + _str_datFinishDate, o.ObjectIdent3 + _str_datFinishDate, "DateTime", 
                    o.datFinishDate == null ? "" : o.datFinishDate.ToString(),                  
                  o.IsReadOnly(_str_datFinishDate), o.IsInvisible(_str_datFinishDate), o.IsRequired(_str_datFinishDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datModificationForArchiveDate, _formname = _str_datModificationForArchiveDate, _type = "DateTime?",
              _get_func = o => o.datModificationForArchiveDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datModificationForArchiveDate != newval) o.datModificationForArchiveDate = newval; },
              _compare_func = (o, c, m) => {
                if (o.datModificationForArchiveDate != c.datModificationForArchiveDate || o.IsRIRPropChanged(_str_datModificationForArchiveDate, c)) 
                  m.Add(_str_datModificationForArchiveDate, o.ObjectIdent + _str_datModificationForArchiveDate, o.ObjectIdent2 + _str_datModificationForArchiveDate, o.ObjectIdent3 + _str_datModificationForArchiveDate, "DateTime?", 
                    o.datModificationForArchiveDate == null ? "" : o.datModificationForArchiveDate.ToString(),                  
                  o.IsReadOnly(_str_datModificationForArchiveDate), o.IsInvisible(_str_datModificationForArchiveDate), o.IsRequired(_str_datModificationForArchiveDate)); 
                  }
              }, 
        
            new field_info {
              _name = _str_strSite, _formname = _str_strSite, _type = "string",
              _get_func = o => o.strSite,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSite != newval) o.strSite = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.strSite != c.strSite || o.IsRIRPropChanged(_str_strSite, c)) {
                  m.Add(_str_strSite, o.ObjectIdent + _str_strSite, o.ObjectIdent2 + _str_strSite, o.ObjectIdent3 + _str_strSite,  "string", 
                    o.strSite == null ? "" : o.strSite.ToString(),                  
                    o.IsReadOnly(_str_strSite), o.IsInvisible(_str_strSite), o.IsRequired(_str_strSite));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_strEnteredBy, _formname = _str_strEnteredBy, _type = "string",
              _get_func = o => o.strEnteredBy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strEnteredBy != newval) o.strEnteredBy = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.strEnteredBy != c.strEnteredBy || o.IsRIRPropChanged(_str_strEnteredBy, c)) {
                  m.Add(_str_strEnteredBy, o.ObjectIdent + _str_strEnteredBy, o.ObjectIdent2 + _str_strEnteredBy, o.ObjectIdent3 + _str_strEnteredBy,  "string", 
                    o.strEnteredBy == null ? "" : o.strEnteredBy.ToString(),                  
                    o.IsReadOnly(_str_strEnteredBy), o.IsInvisible(_str_strEnteredBy), o.IsRequired(_str_strEnteredBy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_BSSAggregateDetail, _formname = _str_BSSAggregateDetail, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.BSSAggregateDetail.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.BSSAggregateDetail.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.BSSAggregateDetail.Count != c.BSSAggregateDetail.Count || o.IsReadOnly(_str_BSSAggregateDetail) != c.IsReadOnly(_str_BSSAggregateDetail) || o.IsInvisible(_str_BSSAggregateDetail) != c.IsInvisible(_str_BSSAggregateDetail) || o.IsRequired(_str_BSSAggregateDetail) != c._isRequired(o.m_isRequired, _str_BSSAggregateDetail)) {
                  m.Add(_str_BSSAggregateDetail, o.ObjectIdent + _str_BSSAggregateDetail, o.ObjectIdent2 + _str_BSSAggregateDetail, o.ObjectIdent3 + _str_BSSAggregateDetail, "Child", o.idfAggregateHeader == null ? "" : o.idfAggregateHeader.ToString(), o.IsReadOnly(_str_BSSAggregateDetail), o.IsInvisible(_str_BSSAggregateDetail), o.IsRequired(_str_BSSAggregateDetail)); 
                  }
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
            BasicSyndromicSurveillanceAggregateHeader obj = (BasicSyndromicSurveillanceAggregateHeader)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_BSSAggregateDetail)]
        [Relation(typeof(BasicSyndromicSurveillanceAggregateDetail), eidss.model.Schema.BasicSyndromicSurveillanceAggregateDetail._str_idfAggregateHeader, _str_idfAggregateHeader)]
        public EditableList<BasicSyndromicSurveillanceAggregateDetail> BSSAggregateDetail
        {
            get 
            {   
                return _BSSAggregateDetail; 
            }
            set 
            {
                _BSSAggregateDetail = value;
            }
        }
        protected EditableList<BasicSyndromicSurveillanceAggregateDetail> _BSSAggregateDetail = new EditableList<BasicSyndromicSurveillanceAggregateDetail>();
                    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
          [LocalizedDisplayName(_str_strSite)]
        public string strSite
        {
            get { return m_strSite; }
            set { if (m_strSite != value) { m_strSite = value; OnPropertyChanged(_str_strSite); } }
        }
        private string m_strSite;
        
          [LocalizedDisplayName(_str_strEnteredBy)]
        public string strEnteredBy
        {
            get { return m_strEnteredBy; }
            set { if (m_strEnteredBy != value) { m_strEnteredBy = value; OnPropertyChanged(_str_strEnteredBy); } }
        }
        private string m_strEnteredBy;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "BasicSyndromicSurveillanceAggregateHeader";

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
        BSSAggregateDetail.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as BasicSyndromicSurveillanceAggregateHeader;
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
            var ret = base.Clone() as BasicSyndromicSurveillanceAggregateHeader;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_BSSAggregateDetail != null && _BSSAggregateDetail.Count > 0)
            {
              ret.BSSAggregateDetail.Clear();
              _BSSAggregateDetail.ForEach(c => ret.BSSAggregateDetail.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public BasicSyndromicSurveillanceAggregateHeader CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as BasicSyndromicSurveillanceAggregateHeader;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfAggregateHeader; } }
        public string KeyName { get { return "idfAggregateHeader"; } }
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
        
                    || BSSAggregateDetail.IsDirty
                    || BSSAggregateDetail.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
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
        BSSAggregateDetail.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        BSSAggregateDetail.DeepAcceptChanges();
                
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
        BSSAggregateDetail.ForEach(c => c.SetChange());
                
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

        private bool IsRIRPropChanged(string fld, BasicSyndromicSurveillanceAggregateHeader c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public BasicSyndromicSurveillanceAggregateHeader()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(BasicSyndromicSurveillanceAggregateHeader_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(BasicSyndromicSurveillanceAggregateHeader_PropertyChanged);
        }
        private void BasicSyndromicSurveillanceAggregateHeader_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as BasicSyndromicSurveillanceAggregateHeader).Changed(e.PropertyName);
            
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
            BasicSyndromicSurveillanceAggregateHeader obj = this;
            
        }
        private void _DeletedExtenders()
        {
            BasicSyndromicSurveillanceAggregateHeader obj = this;
            
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

    
        private static string[] readonly_names1 = "strFormID,datDateEntered,datDateLastSaved,idfEnteredBy,idfsSite,strSite,strEnteredBy".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<BasicSyndromicSurveillanceAggregateHeader, bool>(c => true)(this);
            
            return ReadOnly || new Func<BasicSyndromicSurveillanceAggregateHeader, bool>(c => c.ReadOnly)(this);
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _BSSAggregateDetail)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<BasicSyndromicSurveillanceAggregateHeader, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<BasicSyndromicSurveillanceAggregateHeader, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<BasicSyndromicSurveillanceAggregateHeader, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<BasicSyndromicSurveillanceAggregateHeader, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<BasicSyndromicSurveillanceAggregateHeader, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<BasicSyndromicSurveillanceAggregateHeader, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<BasicSyndromicSurveillanceAggregateHeader, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~BasicSyndromicSurveillanceAggregateHeader()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                BSSAggregateDetail.ForEach(c => c.Dispose());
                
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
        
            if (_BSSAggregateDetail != null) _BSSAggregateDetail.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<BasicSyndromicSurveillanceAggregateHeader>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            , IObjectCreator<BasicSyndromicSurveillanceAggregateHeader>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<BasicSyndromicSurveillanceAggregateHeader>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfAggregateHeader"; } }
            #endregion
        
            private delegate void on_action(BasicSyndromicSurveillanceAggregateHeader obj);
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
            private BasicSyndromicSurveillanceAggregateDetail.Accessor BSSAggregateDetailAccessor { get { return eidss.model.Schema.BasicSyndromicSurveillanceAggregateDetail.Accessor.Instance(m_CS); } }
            

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
            public virtual BasicSyndromicSurveillanceAggregateHeader SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
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

            
            public virtual BasicSyndromicSurveillanceAggregateHeader SelectByKey(DbManagerProxy manager
                , Int64? idfAggregateHeader
                )
            {
                return _SelectByKey(manager
                    , idfAggregateHeader
                    , null, null
                    );
            }
            
      
            private BasicSyndromicSurveillanceAggregateHeader _SelectByKey(DbManagerProxy manager
                , Int64? idfAggregateHeader
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<BasicSyndromicSurveillanceAggregateHeader> objs = new List<BasicSyndromicSurveillanceAggregateHeader>();
                sets[0] = new MapResultSet(typeof(BasicSyndromicSurveillanceAggregateHeader), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spBasicSyndromicSurveillanceAggregateHeader_SelectDetail"
                            , manager.Parameter("@idfAggregateHeader", idfAggregateHeader)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    BasicSyndromicSurveillanceAggregateHeader obj = objs[0];
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
    
            private void _SetupAddChildHandlerBSSAggregateDetail(BasicSyndromicSurveillanceAggregateHeader obj)
            {
                obj.BSSAggregateDetail.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadBSSAggregateDetail(BasicSyndromicSurveillanceAggregateHeader obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadBSSAggregateDetail(manager, obj);
                }
            }
            internal void _LoadBSSAggregateDetail(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateHeader obj)
            {
                
                obj.BSSAggregateDetail.Clear();
                obj.BSSAggregateDetail.AddRange(BSSAggregateDetailAccessor.SelectDetailList(manager
                    
                    , obj.idfAggregateHeader
                    ));
                obj.BSSAggregateDetail.ForEach(c => c.m_ObjectName = _str_BSSAggregateDetail);
                obj.BSSAggregateDetail.AcceptChanges();
                    
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateHeader obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj.strSite = new Func<BasicSyndromicSurveillanceAggregateHeader, string>(c => EidssSiteContext.Instance.SiteABR)(obj);
                obj.strEnteredBy = new Func<BasicSyndromicSurveillanceAggregateHeader, string>(c => EidssUserContext.User.FullName)(obj);
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadBSSAggregateDetail(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerBSSAggregateDetail(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, BasicSyndromicSurveillanceAggregateHeader obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.BSSAggregateDetail.ForEach(c => BSSAggregateDetailAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private BasicSyndromicSurveillanceAggregateHeader _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    BasicSyndromicSurveillanceAggregateHeader obj = BasicSyndromicSurveillanceAggregateHeader.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfAggregateHeader = (new GetNewIDExtender<BasicSyndromicSurveillanceAggregateHeader>()).GetScalar(manager, obj, isFake);
                obj.strFormID = new Func<BasicSyndromicSurveillanceAggregateHeader, string>(c => "(new)")(obj);
                obj.datDateEntered = new Func<BasicSyndromicSurveillanceAggregateHeader, DateTime>(c => DateTime.Now)(obj);
                obj.datDateLastSaved = new Func<BasicSyndromicSurveillanceAggregateHeader, DateTime?>(c => null)(obj);
                obj.idfEnteredBy = new Func<BasicSyndromicSurveillanceAggregateHeader, long>(c => (long)EidssUserContext.User.EmployeeID)(obj);
                obj.strEnteredBy = new Func<BasicSyndromicSurveillanceAggregateHeader, string>(c => EidssUserContext.User.FullName)(obj);
                obj.idfsSite = new Func<BasicSyndromicSurveillanceAggregateHeader, long>(c => EidssSiteContext.Instance.SiteID)(obj);
                obj.strSite = new Func<BasicSyndromicSurveillanceAggregateHeader, string>(c => EidssSiteContext.Instance.OrganizationName)(obj);
                obj.intYear = new Func<BasicSyndromicSurveillanceAggregateHeader, int>(c => DateTime.Now.Year)(obj);
                obj.intWeek = new Func<BasicSyndromicSurveillanceAggregateHeader, int>(c => 1)(obj);
                obj.datStartDate = new Func<BasicSyndromicSurveillanceAggregateHeader, DateTime>(c => eidss.model.Helpers.AggregateListHelper.GetStartDate(c.intYear, c.intWeek))(obj);
                obj.datFinishDate = new Func<BasicSyndromicSurveillanceAggregateHeader, DateTime>(c => eidss.model.Helpers.AggregateListHelper.GetFinishDate(c.intYear, c.intWeek))(obj);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerBSSAggregateDetail(obj);
                    
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

            
            public BasicSyndromicSurveillanceAggregateHeader CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public BasicSyndromicSurveillanceAggregateHeader CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public BasicSyndromicSurveillanceAggregateHeader CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(BasicSyndromicSurveillanceAggregateHeader obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(BasicSyndromicSurveillanceAggregateHeader obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_intWeek)
                        {
                    
                obj.datStartDate = new Func<BasicSyndromicSurveillanceAggregateHeader, DateTime>(c => eidss.model.Helpers.AggregateListHelper.GetStartDate(c.intYear, c.intWeek))(obj);
                        }
                    
                        if (e.PropertyName == _str_intWeek)
                        {
                    
                obj.datFinishDate = new Func<BasicSyndromicSurveillanceAggregateHeader, DateTime>(c => eidss.model.Helpers.AggregateListHelper.GetFinishDate(c.intYear, c.intWeek))(obj);
                        }
                    
                    };
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateHeader obj)
            {
                
            }
    
            [SprocName("spBasicSyndromicSurveillanceAggregateHeader_Delete")]
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
        
            [SprocName("spBasicSyndromicSurveillanceAggregateHeader_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strFormID")] BasicSyndromicSurveillanceAggregateHeader obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strFormID")] BasicSyndromicSurveillanceAggregateHeader obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    BasicSyndromicSurveillanceAggregateHeader bo = obj as BasicSyndromicSurveillanceAggregateHeader;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("AccessToBssModule", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("AccessToBssModule", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("AccessToBssModule", "Update");
                    }
                    
                    long mainObject = bo.idfAggregateHeader;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        
                            manager.SetEventParams(false, new object[] { EventType.BssAggregateFormLocal, mainObject, "" });
                        
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
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoBssAggregateForm;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbBasicSyndromicSurveillanceAggregateDetail;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as BasicSyndromicSurveillanceAggregateHeader, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateHeader obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.BSSAggregateDetail != null)
                    {
                        foreach (var i in obj.BSSAggregateDetail)
                        {
                            i.MarkToDelete();
                            if (!BSSAggregateDetailAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    
                    if (!ValidateCanDelete(manager, obj)) return false;
                                
                    _postPredicate(manager, 8, obj);
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                obj.datModificationForArchiveDate = new Func<BasicSyndromicSurveillanceAggregateHeader, DateTime?>(c => c.HasChanges ? DateTime.Now : c.datModificationForArchiveDate)(obj);
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                                    
                    if (obj.IsNew)
                    {
                        if (obj.BSSAggregateDetail != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.BSSAggregateDetail)
                                if (!BSSAggregateDetailAccessor.Post(manager, i, true))
                                    return false;
                            obj.BSSAggregateDetail.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.BSSAggregateDetail.Remove(c));
                            obj.BSSAggregateDetail.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._BSSAggregateDetail != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._BSSAggregateDetail)
                                if (!BSSAggregateDetailAccessor.Post(manager, i, true))
                                    return false;
                            obj._BSSAggregateDetail.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._BSSAggregateDetail.Remove(c));
                            obj._BSSAggregateDetail.AcceptChanges();
                        }
                    }
                                    
                    // posted extenters - begin
                obj.datDateLastSaved = new Func<BasicSyndromicSurveillanceAggregateHeader, DateTime>(c => DateTime.Now)(obj);
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(BasicSyndromicSurveillanceAggregateHeader obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateHeader obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(BasicSyndromicSurveillanceAggregateHeader obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(BasicSyndromicSurveillanceAggregateHeader obj, bool bRethrowException)
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
                return Validate(manager, obj as BasicSyndromicSurveillanceAggregateHeader, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, BasicSyndromicSurveillanceAggregateHeader obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "intYear", "intYear","",
                false
              )).Validate(c => true, obj, obj.intYear);
            
                (new RequiredValidator( "intWeek", "intWeek","",
                false
              )).Validate(c => true, obj, obj.intWeek);
            
                CustomValidations(obj);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                        if (obj.BSSAggregateDetail != null)
                            foreach (var i in obj.BSSAggregateDetail.Where(c => !c.IsMarkedToDelete && c.HasChanges))
                                BSSAggregateDetailAccessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        
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
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(BasicSyndromicSurveillanceAggregateHeader obj)
            {
            
                obj
                    .AddRequired("intYear", c => true);
                    
                obj
                    .AddRequired("intWeek", c => true);
                    
            }
    
    private void _SetupPersonalDataRestrictions(BasicSyndromicSurveillanceAggregateHeader obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as BasicSyndromicSurveillanceAggregateHeader) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as BasicSyndromicSurveillanceAggregateHeader) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "BasicSyndromicSurveillanceAggregateHeaderDetail"; } }
            public string HelpIdWin { get { return "SS_aggr_form"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private BasicSyndromicSurveillanceAggregateHeader m_obj;
            internal Permissions(BasicSyndromicSurveillanceAggregateHeader obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("AccessToBssModule.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spBasicSyndromicSurveillanceAggregateHeader_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spBasicSyndromicSurveillanceAggregateHeader_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spBasicSyndromicSurveillanceAggregateHeader_Delete";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<BasicSyndromicSurveillanceAggregateHeader, bool>> RequiredByField = new Dictionary<string, Func<BasicSyndromicSurveillanceAggregateHeader, bool>>();
            public static Dictionary<string, Func<BasicSyndromicSurveillanceAggregateHeader, bool>> RequiredByProperty = new Dictionary<string, Func<BasicSyndromicSurveillanceAggregateHeader, bool>>();
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
                
                Sizes.Add(_str_strFormID, 200);
                if (!RequiredByField.ContainsKey("intYear")) RequiredByField.Add("intYear", c => true);
                if (!RequiredByProperty.ContainsKey("intYear")) RequiredByProperty.Add("intYear", c => true);
                
                if (!RequiredByField.ContainsKey("intWeek")) RequiredByField.Add("intWeek", c => true);
                if (!RequiredByProperty.ContainsKey("intWeek")) RequiredByProperty.Add("intWeek", c => true);
                
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<BasicSyndromicSurveillanceAggregateHeader>().Post(manager, (BasicSyndromicSurveillanceAggregateHeader)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<BasicSyndromicSurveillanceAggregateHeader>().Post(manager, (BasicSyndromicSurveillanceAggregateHeader)c), c),
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
                    (manager, c, pars) => new ActResult(((BasicSyndromicSurveillanceAggregateHeader)c).MarkToDelete() && ObjectAccessor.PostInterface<BasicSyndromicSurveillanceAggregateHeader>().Post(manager, (BasicSyndromicSurveillanceAggregateHeader)c), c),
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
	