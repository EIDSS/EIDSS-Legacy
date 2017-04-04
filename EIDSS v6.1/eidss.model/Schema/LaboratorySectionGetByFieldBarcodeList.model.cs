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
    public abstract partial class LaboratorySectionGetByFieldBarcodeListItem : 
        EditableObject<LaboratorySectionGetByFieldBarcodeListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfMaterial), NonUpdatable, PrimaryKey]
        public abstract Int64 idfMaterial { get; set; }
                
        [LocalizedDisplayName(_str_strFieldBarcode)]
        [MapField(_str_strFieldBarcode)]
        public abstract String strFieldBarcode { get; set; }
        protected String strFieldBarcode_Original { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).OriginalValue; } }
        protected String strFieldBarcode_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFieldBarcode).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datFieldCollectionDate)]
        [MapField(_str_datFieldCollectionDate)]
        public abstract DateTime? datFieldCollectionDate { get; set; }
        protected DateTime? datFieldCollectionDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).OriginalValue; } }
        protected DateTime? datFieldCollectionDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datFieldCollectionDate).PreviousValue; } }
                
        [LocalizedDisplayName("strCaseIDSessionID")]
        [MapField(_str_strCalculatedCaseID)]
        public abstract String strCalculatedCaseID { get; set; }
        protected String strCalculatedCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCalculatedCaseID).OriginalValue; } }
        protected String strCalculatedCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCalculatedCaseID).PreviousValue; } }
                
        [LocalizedDisplayName("HumanName")]
        [MapField(_str_strCalculatedHumanName)]
        public abstract String strCalculatedHumanName { get; set; }
        protected String strCalculatedHumanName_Original { get { return ((EditableValue<String>)((dynamic)this)._strCalculatedHumanName).OriginalValue; } }
        protected String strCalculatedHumanName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCalculatedHumanName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfSendToOffice)]
        [MapField(_str_idfSendToOffice)]
        public abstract Int64? idfSendToOffice { get; set; }
        protected Int64? idfSendToOffice_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).OriginalValue; } }
        protected Int64? idfSendToOffice_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfSendToOffice).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSendToOrganization)]
        [MapField(_str_strSendToOrganization)]
        public abstract String strSendToOrganization { get; set; }
        protected String strSendToOrganization_Original { get { return ((EditableValue<String>)((dynamic)this)._strSendToOrganization).OriginalValue; } }
        protected String strSendToOrganization_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSendToOrganization).PreviousValue; } }
                
        [LocalizedDisplayName("idfsSampleType")]
        [MapField(_str_strSampleName)]
        public abstract String strSampleName { get; set; }
        protected String strSampleName_Original { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).OriginalValue; } }
        protected String strSampleName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSampleName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_HumanName)]
        [MapField(_str_HumanName)]
        public abstract String HumanName { get; set; }
        protected String HumanName_Original { get { return ((EditableValue<String>)((dynamic)this)._humanName).OriginalValue; } }
        protected String HumanName_Previous { get { return ((EditableValue<String>)((dynamic)this)._humanName).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<LaboratorySectionGetByFieldBarcodeListItem, object> _get_func;
            internal Action<LaboratorySectionGetByFieldBarcodeListItem, string> _set_func;
            internal Action<LaboratorySectionGetByFieldBarcodeListItem, LaboratorySectionGetByFieldBarcodeListItem, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfMaterial = "idfMaterial";
        internal const string _str_strFieldBarcode = "strFieldBarcode";
        internal const string _str_datFieldCollectionDate = "datFieldCollectionDate";
        internal const string _str_strCalculatedCaseID = "strCalculatedCaseID";
        internal const string _str_strCalculatedHumanName = "strCalculatedHumanName";
        internal const string _str_idfSendToOffice = "idfSendToOffice";
        internal const string _str_strSendToOrganization = "strSendToOrganization";
        internal const string _str_strSampleName = "strSampleName";
        internal const string _str_HumanName = "HumanName";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfMaterial, _formname = _str_idfMaterial, _type = "Int64",
              _get_func = o => o.idfMaterial,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfMaterial != newval) o.idfMaterial = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfMaterial != c.idfMaterial || o.IsRIRPropChanged(_str_idfMaterial, c)) 
                  m.Add(_str_idfMaterial, o.ObjectIdent + _str_idfMaterial, o.ObjectIdent2 + _str_idfMaterial, o.ObjectIdent3 + _str_idfMaterial, "Int64", 
                    o.idfMaterial == null ? "" : o.idfMaterial.ToString(),                  
                  o.IsReadOnly(_str_idfMaterial), o.IsInvisible(_str_idfMaterial), o.IsRequired(_str_idfMaterial)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strFieldBarcode, _formname = _str_strFieldBarcode, _type = "String",
              _get_func = o => o.strFieldBarcode,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strFieldBarcode != newval) o.strFieldBarcode = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strFieldBarcode != c.strFieldBarcode || o.IsRIRPropChanged(_str_strFieldBarcode, c)) 
                  m.Add(_str_strFieldBarcode, o.ObjectIdent + _str_strFieldBarcode, o.ObjectIdent2 + _str_strFieldBarcode, o.ObjectIdent3 + _str_strFieldBarcode, "String", 
                    o.strFieldBarcode == null ? "" : o.strFieldBarcode.ToString(),                  
                  o.IsReadOnly(_str_strFieldBarcode), o.IsInvisible(_str_strFieldBarcode), o.IsRequired(_str_strFieldBarcode)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datFieldCollectionDate, _formname = _str_datFieldCollectionDate, _type = "DateTime?",
              _get_func = o => o.datFieldCollectionDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datFieldCollectionDate != newval) o.datFieldCollectionDate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datFieldCollectionDate != c.datFieldCollectionDate || o.IsRIRPropChanged(_str_datFieldCollectionDate, c)) 
                  m.Add(_str_datFieldCollectionDate, o.ObjectIdent + _str_datFieldCollectionDate, o.ObjectIdent2 + _str_datFieldCollectionDate, o.ObjectIdent3 + _str_datFieldCollectionDate, "DateTime?", 
                    o.datFieldCollectionDate == null ? "" : o.datFieldCollectionDate.ToString(),                  
                  o.IsReadOnly(_str_datFieldCollectionDate), o.IsInvisible(_str_datFieldCollectionDate), o.IsRequired(_str_datFieldCollectionDate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCalculatedCaseID, _formname = _str_strCalculatedCaseID, _type = "String",
              _get_func = o => o.strCalculatedCaseID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCalculatedCaseID != newval) o.strCalculatedCaseID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCalculatedCaseID != c.strCalculatedCaseID || o.IsRIRPropChanged(_str_strCalculatedCaseID, c)) 
                  m.Add(_str_strCalculatedCaseID, o.ObjectIdent + _str_strCalculatedCaseID, o.ObjectIdent2 + _str_strCalculatedCaseID, o.ObjectIdent3 + _str_strCalculatedCaseID, "String", 
                    o.strCalculatedCaseID == null ? "" : o.strCalculatedCaseID.ToString(),                  
                  o.IsReadOnly(_str_strCalculatedCaseID), o.IsInvisible(_str_strCalculatedCaseID), o.IsRequired(_str_strCalculatedCaseID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCalculatedHumanName, _formname = _str_strCalculatedHumanName, _type = "String",
              _get_func = o => o.strCalculatedHumanName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCalculatedHumanName != newval) o.strCalculatedHumanName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCalculatedHumanName != c.strCalculatedHumanName || o.IsRIRPropChanged(_str_strCalculatedHumanName, c)) 
                  m.Add(_str_strCalculatedHumanName, o.ObjectIdent + _str_strCalculatedHumanName, o.ObjectIdent2 + _str_strCalculatedHumanName, o.ObjectIdent3 + _str_strCalculatedHumanName, "String", 
                    o.strCalculatedHumanName == null ? "" : o.strCalculatedHumanName.ToString(),                  
                  o.IsReadOnly(_str_strCalculatedHumanName), o.IsInvisible(_str_strCalculatedHumanName), o.IsRequired(_str_strCalculatedHumanName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfSendToOffice, _formname = _str_idfSendToOffice, _type = "Int64?",
              _get_func = o => o.idfSendToOffice,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfSendToOffice != newval) o.idfSendToOffice = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfSendToOffice != c.idfSendToOffice || o.IsRIRPropChanged(_str_idfSendToOffice, c)) 
                  m.Add(_str_idfSendToOffice, o.ObjectIdent + _str_idfSendToOffice, o.ObjectIdent2 + _str_idfSendToOffice, o.ObjectIdent3 + _str_idfSendToOffice, "Int64?", 
                    o.idfSendToOffice == null ? "" : o.idfSendToOffice.ToString(),                  
                  o.IsReadOnly(_str_idfSendToOffice), o.IsInvisible(_str_idfSendToOffice), o.IsRequired(_str_idfSendToOffice)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSendToOrganization, _formname = _str_strSendToOrganization, _type = "String",
              _get_func = o => o.strSendToOrganization,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSendToOrganization != newval) o.strSendToOrganization = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSendToOrganization != c.strSendToOrganization || o.IsRIRPropChanged(_str_strSendToOrganization, c)) 
                  m.Add(_str_strSendToOrganization, o.ObjectIdent + _str_strSendToOrganization, o.ObjectIdent2 + _str_strSendToOrganization, o.ObjectIdent3 + _str_strSendToOrganization, "String", 
                    o.strSendToOrganization == null ? "" : o.strSendToOrganization.ToString(),                  
                  o.IsReadOnly(_str_strSendToOrganization), o.IsInvisible(_str_strSendToOrganization), o.IsRequired(_str_strSendToOrganization)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSampleName, _formname = _str_strSampleName, _type = "String",
              _get_func = o => o.strSampleName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSampleName != newval) o.strSampleName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSampleName != c.strSampleName || o.IsRIRPropChanged(_str_strSampleName, c)) 
                  m.Add(_str_strSampleName, o.ObjectIdent + _str_strSampleName, o.ObjectIdent2 + _str_strSampleName, o.ObjectIdent3 + _str_strSampleName, "String", 
                    o.strSampleName == null ? "" : o.strSampleName.ToString(),                  
                  o.IsReadOnly(_str_strSampleName), o.IsInvisible(_str_strSampleName), o.IsRequired(_str_strSampleName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_HumanName, _formname = _str_HumanName, _type = "String",
              _get_func = o => o.HumanName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.HumanName != newval) o.HumanName = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.HumanName != c.HumanName || o.IsRIRPropChanged(_str_HumanName, c)) 
                  m.Add(_str_HumanName, o.ObjectIdent + _str_HumanName, o.ObjectIdent2 + _str_HumanName, o.ObjectIdent3 + _str_HumanName, "String", 
                    o.HumanName == null ? "" : o.HumanName.ToString(),                  
                  o.IsReadOnly(_str_HumanName), o.IsInvisible(_str_HumanName), o.IsRequired(_str_HumanName)); 
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
            LaboratorySectionGetByFieldBarcodeListItem obj = (LaboratorySectionGetByFieldBarcodeListItem)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
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
        internal string m_ObjectName = "LaboratorySectionGetByFieldBarcodeListItem";

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
            var ret = base.Clone() as LaboratorySectionGetByFieldBarcodeListItem;
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
            var ret = base.Clone() as LaboratorySectionGetByFieldBarcodeListItem;
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
        public LaboratorySectionGetByFieldBarcodeListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as LaboratorySectionGetByFieldBarcodeListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfMaterial; } }
        public string KeyName { get { return "idfMaterial"; } }
        public object KeyLookup { get { return idfMaterial; } }
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

        private bool IsRIRPropChanged(string fld, LaboratorySectionGetByFieldBarcodeListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, LaboratorySectionGetByFieldBarcodeListItem c)
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
        

      

        public LaboratorySectionGetByFieldBarcodeListItem()
        {
            
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(LaboratorySectionGetByFieldBarcodeListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(LaboratorySectionGetByFieldBarcodeListItem_PropertyChanged);
        }
        private void LaboratorySectionGetByFieldBarcodeListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as LaboratorySectionGetByFieldBarcodeListItem).Changed(e.PropertyName);
            
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
            LaboratorySectionGetByFieldBarcodeListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            LaboratorySectionGetByFieldBarcodeListItem obj = this;
            
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

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
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


        internal Dictionary<string, Func<LaboratorySectionGetByFieldBarcodeListItem, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<LaboratorySectionGetByFieldBarcodeListItem, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<LaboratorySectionGetByFieldBarcodeListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<LaboratorySectionGetByFieldBarcodeListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<LaboratorySectionGetByFieldBarcodeListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<LaboratorySectionGetByFieldBarcodeListItem, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<LaboratorySectionGetByFieldBarcodeListItem, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~LaboratorySectionGetByFieldBarcodeListItem()
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
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
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
        public class LaboratorySectionGetByFieldBarcodeListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfMaterial { get; set; }
        
            public String strSampleName { get; set; }
        
            public DateTimeWrap datFieldCollectionDate { get; set; }
        
            public String strCalculatedCaseID { get; set; }
        
            public String strSendToOrganization { get; set; }
        
            public String strCalculatedHumanName { get; set; }
        
        }
        public partial class LaboratorySectionGetByFieldBarcodeListItemGridModelList : List<LaboratorySectionGetByFieldBarcodeListItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public LaboratorySectionGetByFieldBarcodeListItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LaboratorySectionGetByFieldBarcodeListItem>, errMes);
            }
            public LaboratorySectionGetByFieldBarcodeListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<LaboratorySectionGetByFieldBarcodeListItem>, errMes);
            }
            public LaboratorySectionGetByFieldBarcodeListItemGridModelList(long key, IEnumerable<LaboratorySectionGetByFieldBarcodeListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            public LaboratorySectionGetByFieldBarcodeListItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<LaboratorySectionGetByFieldBarcodeListItem>(), null);
            }
            partial void filter(List<LaboratorySectionGetByFieldBarcodeListItem> items);
            private void LoadGridModelList(long key, IEnumerable<LaboratorySectionGetByFieldBarcodeListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strSampleName,_str_datFieldCollectionDate,_str_strCalculatedCaseID,_str_strSendToOrganization,_str_strCalculatedHumanName};
                    
                Hiddens = new List<string> {_str_idfMaterial};
                Keys = new List<string> {_str_idfMaterial};
                Labels = new Dictionary<string, string> {{_str_strSampleName, "idfsSampleType"},{_str_datFieldCollectionDate, _str_datFieldCollectionDate},{_str_strCalculatedCaseID, "strCaseIDSessionID"},{_str_strSendToOrganization, _str_strSendToOrganization},{_str_strCalculatedHumanName, "HumanName"}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                LaboratorySectionGetByFieldBarcodeListItem.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<LaboratorySectionGetByFieldBarcodeListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new LaboratorySectionGetByFieldBarcodeListItemGridModel()
                {
                    ItemKey=c.idfMaterial,strSampleName=c.strSampleName,datFieldCollectionDate=c.datFieldCollectionDate,strCalculatedCaseID=c.strCalculatedCaseID,strSendToOrganization=c.strSendToOrganization,strCalculatedHumanName=c.strCalculatedHumanName
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
        : DataAccessor<LaboratorySectionGetByFieldBarcodeListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<LaboratorySectionGetByFieldBarcodeListItem>
            
            , IObjectSelectList
            , IObjectSelectList<LaboratorySectionGetByFieldBarcodeListItem>
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfMaterial"; } }
            #endregion
        
            public delegate void on_action(LaboratorySectionGetByFieldBarcodeListItem obj);
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
            
            public virtual List<LaboratorySectionGetByFieldBarcodeListItem> SelectListT(DbManagerProxy manager
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
            
            protected virtual List<LaboratorySectionGetByFieldBarcodeListItem> _SelectList(DbManagerProxy manager
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
                sql.Append(@" dbo.fn_LaboratorySectionGetByFieldBarcode_SelectList.* from dbo.fn_LaboratorySectionGetByFieldBarcode_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfMaterial"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfMaterial"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfMaterial") ? " or " : " and ");
                        
                        if (filters.Operation("idfMaterial", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySectionGetByFieldBarcode_SelectList.idfMaterial,0) {0} @idfMaterial_{1} = @idfMaterial_{1})", filters.Operation("idfMaterial", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySectionGetByFieldBarcode_SelectList.idfMaterial,0) {0} @idfMaterial_{1}", filters.Operation("idfMaterial", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFieldBarcode"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFieldBarcode"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFieldBarcode") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySectionGetByFieldBarcode_SelectList.strFieldBarcode {0} @strFieldBarcode_{1}", filters.Operation("strFieldBarcode", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("datFieldCollectionDate"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("datFieldCollectionDate"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("datFieldCollectionDate") ? " or " : " and ");
                        
                        sql.AppendFormat("CONVERT(NVARCHAR(8), fn_LaboratorySectionGetByFieldBarcode_SelectList.datFieldCollectionDate, 112) {0} CONVERT(NVARCHAR(8), @datFieldCollectionDate_{1}, 112)", filters.Operation("datFieldCollectionDate", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCalculatedCaseID"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCalculatedCaseID"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCalculatedCaseID") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySectionGetByFieldBarcode_SelectList.strCalculatedCaseID {0} @strCalculatedCaseID_{1}", filters.Operation("strCalculatedCaseID", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strCalculatedHumanName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strCalculatedHumanName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strCalculatedHumanName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySectionGetByFieldBarcode_SelectList.strCalculatedHumanName {0} @strCalculatedHumanName_{1}", filters.Operation("strCalculatedHumanName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfSendToOffice"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfSendToOffice"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfSendToOffice") ? " or " : " and ");
                        
                        if (filters.Operation("idfSendToOffice", i) == "&")
                          sql.AppendFormat("(isnull(fn_LaboratorySectionGetByFieldBarcode_SelectList.idfSendToOffice,0) {0} @idfSendToOffice_{1} = @idfSendToOffice_{1})", filters.Operation("idfSendToOffice", i), i);
                        else
                          sql.AppendFormat("isnull(fn_LaboratorySectionGetByFieldBarcode_SelectList.idfSendToOffice,0) {0} @idfSendToOffice_{1}", filters.Operation("idfSendToOffice", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSendToOrganization"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSendToOrganization"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSendToOrganization") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySectionGetByFieldBarcode_SelectList.strSendToOrganization {0} @strSendToOrganization_{1}", filters.Operation("strSendToOrganization", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strSampleName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strSampleName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strSampleName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySectionGetByFieldBarcode_SelectList.strSampleName {0} @strSampleName_{1}", filters.Operation("strSampleName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("HumanName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("HumanName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("HumanName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_LaboratorySectionGetByFieldBarcode_SelectList.HumanName {0} @HumanName_{1}", filters.Operation("HumanName", i), i);
                            
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
                    
                    if (filters.Contains("idfMaterial"))
                        for (int i = 0; i < filters.Count("idfMaterial"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfMaterial_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfMaterial", i), filters.Value("idfMaterial", i))));
                      
                    if (filters.Contains("strFieldBarcode"))
                        for (int i = 0; i < filters.Count("strFieldBarcode"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFieldBarcode_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFieldBarcode", i), filters.Value("strFieldBarcode", i))));
                      
                    if (filters.Contains("datFieldCollectionDate"))
                        for (int i = 0; i < filters.Count("datFieldCollectionDate"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@datFieldCollectionDate_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("datFieldCollectionDate", i), filters.Value("datFieldCollectionDate", i))));
                      
                    if (filters.Contains("strCalculatedCaseID"))
                        for (int i = 0; i < filters.Count("strCalculatedCaseID"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCalculatedCaseID_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCalculatedCaseID", i), filters.Value("strCalculatedCaseID", i))));
                      
                    if (filters.Contains("strCalculatedHumanName"))
                        for (int i = 0; i < filters.Count("strCalculatedHumanName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strCalculatedHumanName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strCalculatedHumanName", i), filters.Value("strCalculatedHumanName", i))));
                      
                    if (filters.Contains("idfSendToOffice"))
                        for (int i = 0; i < filters.Count("idfSendToOffice"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfSendToOffice_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfSendToOffice", i), filters.Value("idfSendToOffice", i))));
                      
                    if (filters.Contains("strSendToOrganization"))
                        for (int i = 0; i < filters.Count("strSendToOrganization"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSendToOrganization_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSendToOrganization", i), filters.Value("strSendToOrganization", i))));
                      
                    if (filters.Contains("strSampleName"))
                        for (int i = 0; i < filters.Count("strSampleName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strSampleName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strSampleName", i), filters.Value("strSampleName", i))));
                      
                    if (filters.Contains("HumanName"))
                        for (int i = 0; i < filters.Count("HumanName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@HumanName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("HumanName", i), filters.Value("HumanName", i))));
                      
                    List<LaboratorySectionGetByFieldBarcodeListItem> objs = manager.ExecuteList<LaboratorySectionGetByFieldBarcodeListItem>();
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
            partial void ListSelected(DbManagerProxy manager, List<LaboratorySectionGetByFieldBarcodeListItem> objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return null;
                    
            }
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, LaboratorySectionGetByFieldBarcodeListItem obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, LaboratorySectionGetByFieldBarcodeListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private LaboratorySectionGetByFieldBarcodeListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                LaboratorySectionGetByFieldBarcodeListItem obj = null;
                try
                {
                    obj = LaboratorySectionGetByFieldBarcodeListItem.CreateInstance();
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

            
            public LaboratorySectionGetByFieldBarcodeListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public LaboratorySectionGetByFieldBarcodeListItem CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public LaboratorySectionGetByFieldBarcodeListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(LaboratorySectionGetByFieldBarcodeListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(LaboratorySectionGetByFieldBarcodeListItem obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, LaboratorySectionGetByFieldBarcodeListItem obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(LaboratorySectionGetByFieldBarcodeListItem obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(LaboratorySectionGetByFieldBarcodeListItem obj, bool bRethrowException)
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
                return Validate(manager, obj as LaboratorySectionGetByFieldBarcodeListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, LaboratorySectionGetByFieldBarcodeListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(LaboratorySectionGetByFieldBarcodeListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(LaboratorySectionGetByFieldBarcodeListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as LaboratorySectionGetByFieldBarcodeListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as LaboratorySectionGetByFieldBarcodeListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "LaboratorySectionGetByFieldBarcodeListItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_LaboratorySectionGetByFieldBarcode_SelectList";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<LaboratorySectionGetByFieldBarcodeListItem, bool>> RequiredByField = new Dictionary<string, Func<LaboratorySectionGetByFieldBarcodeListItem, bool>>();
            public static Dictionary<string, Func<LaboratorySectionGetByFieldBarcodeListItem, bool>> RequiredByProperty = new Dictionary<string, Func<LaboratorySectionGetByFieldBarcodeListItem, bool>>();
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
                
                Sizes.Add(_str_strFieldBarcode, 200);
                Sizes.Add(_str_strCalculatedCaseID, 200);
                Sizes.Add(_str_strCalculatedHumanName, 700);
                Sizes.Add(_str_strSendToOrganization, 2000);
                Sizes.Add(_str_strSampleName, 2000);
                Sizes.Add(_str_HumanName, 700);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFieldBarcode",
                    EditorType.Text,
                    EditorControlWidth.Normal, true, true, false, false, 
                    "",
                    null, null, c => false, false, SearchPanelLocation.Main, false, null, null, null, null, null, null,false
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfMaterial,
                    _str_idfMaterial, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSampleName,
                    "idfsSampleType", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datFieldCollectionDate,
                    _str_datFieldCollectionDate, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCalculatedCaseID,
                    "strCaseIDSessionID", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSendToOrganization,
                    _str_strSendToOrganization, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCalculatedHumanName,
                    "HumanName", null, false, true, true, true, true, null
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<LaboratorySectionItem>().CreateNew(manager, c, pars == null ? null : (int?)pars[0])),
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
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<LaboratorySectionItem>().SelectDetail(manager, pars[0])),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.DeleteInterface<LaboratorySectionItem>().DeleteObject(manager, c == null ? pars[0] : c.Key), c),
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
	