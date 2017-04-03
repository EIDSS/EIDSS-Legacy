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
    public abstract partial class AvrLayoutLookup : 
        EditableObject<AvrLayoutLookup>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idflLayout), NonUpdatable, PrimaryKey]
        public abstract Int64 idflLayout { get; set; }
                
        [LocalizedDisplayName(_str_idflFolder)]
        [MapField(_str_idflFolder)]
        public abstract Int64? idflFolder { get; set; }
        protected Int64? idflFolder_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idflFolder).OriginalValue; } }
        protected Int64? idflFolder_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idflFolder).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsGlobalLayout)]
        [MapField(_str_idfsGlobalLayout)]
        public abstract Int64? idfsGlobalLayout { get; set; }
        protected Int64? idfsGlobalLayout_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGlobalLayout).OriginalValue; } }
        protected Int64? idfsGlobalLayout_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsGlobalLayout).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDefaultLayoutName)]
        [MapField(_str_strDefaultLayoutName)]
        public abstract String strDefaultLayoutName { get; set; }
        protected String strDefaultLayoutName_Original { get { return ((EditableValue<String>)((dynamic)this)._strDefaultLayoutName).OriginalValue; } }
        protected String strDefaultLayoutName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDefaultLayoutName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strLayoutName)]
        [MapField(_str_strLayoutName)]
        public abstract String strLayoutName { get; set; }
        protected String strLayoutName_Original { get { return ((EditableValue<String>)((dynamic)this)._strLayoutName).OriginalValue; } }
        protected String strLayoutName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strLayoutName).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idflDescription)]
        [MapField(_str_idflDescription)]
        public abstract Int64 idflDescription { get; set; }
        protected Int64 idflDescription_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idflDescription).OriginalValue; } }
        protected Int64 idflDescription_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idflDescription).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idflDescriptionNational)]
        [MapField(_str_idflDescriptionNational)]
        public abstract Int32 idflDescriptionNational { get; set; }
        protected Int32 idflDescriptionNational_Original { get { return ((EditableValue<Int32>)((dynamic)this)._idflDescriptionNational).OriginalValue; } }
        protected Int32 idflDescriptionNational_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._idflDescriptionNational).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDescription)]
        [MapField(_str_strDescription)]
        public abstract String strDescription { get; set; }
        protected String strDescription_Original { get { return ((EditableValue<String>)((dynamic)this)._strDescription).OriginalValue; } }
        protected String strDescription_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDescription).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strDescriptionEnglish)]
        [MapField(_str_strDescriptionEnglish)]
        public abstract String strDescriptionEnglish { get; set; }
        protected String strDescriptionEnglish_Original { get { return ((EditableValue<String>)((dynamic)this)._strDescriptionEnglish).OriginalValue; } }
        protected String strDescriptionEnglish_Previous { get { return ((EditableValue<String>)((dynamic)this)._strDescriptionEnglish).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idflQuery)]
        [MapField(_str_idflQuery)]
        public abstract Int64 idflQuery { get; set; }
        protected Int64 idflQuery_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idflQuery).OriginalValue; } }
        protected Int64 idflQuery_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idflQuery).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfPerson)]
        [MapField(_str_idfPerson)]
        public abstract Int64? idfPerson { get; set; }
        protected Int64? idfPerson_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerson).OriginalValue; } }
        protected Int64? idfPerson_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPerson).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnReadOnly)]
        [MapField(_str_blnReadOnly)]
        public abstract Boolean blnReadOnly { get; set; }
        protected Boolean blnReadOnly_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnReadOnly).OriginalValue; } }
        protected Boolean blnReadOnly_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnReadOnly).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnShareLayout)]
        [MapField(_str_blnShareLayout)]
        public abstract Boolean blnShareLayout { get; set; }
        protected Boolean blnShareLayout_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnShareLayout).OriginalValue; } }
        protected Boolean blnShareLayout_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnShareLayout).PreviousValue; } }
                
        [LocalizedDisplayName(_str_blnUseArchivedData)]
        [MapField(_str_blnUseArchivedData)]
        public abstract Boolean blnUseArchivedData { get; set; }
        protected Boolean blnUseArchivedData_Original { get { return ((EditableValue<Boolean>)((dynamic)this)._blnUseArchivedData).OriginalValue; } }
        protected Boolean blnUseArchivedData_Previous { get { return ((EditableValue<Boolean>)((dynamic)this)._blnUseArchivedData).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32 intOrder { get; set; }
        protected Int32 intOrder_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32 intOrder_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<AvrLayoutLookup, object> _get_func;
            internal Action<AvrLayoutLookup, string> _set_func;
            internal Action<AvrLayoutLookup, AvrLayoutLookup, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idflLayout = "idflLayout";
        internal const string _str_idflFolder = "idflFolder";
        internal const string _str_idfsGlobalLayout = "idfsGlobalLayout";
        internal const string _str_strDefaultLayoutName = "strDefaultLayoutName";
        internal const string _str_strLayoutName = "strLayoutName";
        internal const string _str_idflDescription = "idflDescription";
        internal const string _str_idflDescriptionNational = "idflDescriptionNational";
        internal const string _str_strDescription = "strDescription";
        internal const string _str_strDescriptionEnglish = "strDescriptionEnglish";
        internal const string _str_idflQuery = "idflQuery";
        internal const string _str_idfPerson = "idfPerson";
        internal const string _str_blnReadOnly = "blnReadOnly";
        internal const string _str_blnShareLayout = "blnShareLayout";
        internal const string _str_blnUseArchivedData = "blnUseArchivedData";
        internal const string _str_intOrder = "intOrder";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idflLayout, _formname = _str_idflLayout, _type = "Int64",
              _get_func = o => o.idflLayout,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idflLayout != newval) o.idflLayout = newval; },
              _compare_func = (o, c, m) => {
                if (o.idflLayout != c.idflLayout || o.IsRIRPropChanged(_str_idflLayout, c)) 
                  m.Add(_str_idflLayout, o.ObjectIdent + _str_idflLayout, o.ObjectIdent2 + _str_idflLayout, o.ObjectIdent3 + _str_idflLayout, "Int64", 
                    o.idflLayout == null ? "" : o.idflLayout.ToString(),                  
                  o.IsReadOnly(_str_idflLayout), o.IsInvisible(_str_idflLayout), o.IsRequired(_str_idflLayout)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idflFolder, _formname = _str_idflFolder, _type = "Int64?",
              _get_func = o => o.idflFolder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idflFolder != newval) o.idflFolder = newval; },
              _compare_func = (o, c, m) => {
                if (o.idflFolder != c.idflFolder || o.IsRIRPropChanged(_str_idflFolder, c)) 
                  m.Add(_str_idflFolder, o.ObjectIdent + _str_idflFolder, o.ObjectIdent2 + _str_idflFolder, o.ObjectIdent3 + _str_idflFolder, "Int64?", 
                    o.idflFolder == null ? "" : o.idflFolder.ToString(),                  
                  o.IsReadOnly(_str_idflFolder), o.IsInvisible(_str_idflFolder), o.IsRequired(_str_idflFolder)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsGlobalLayout, _formname = _str_idfsGlobalLayout, _type = "Int64?",
              _get_func = o => o.idfsGlobalLayout,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsGlobalLayout != newval) o.idfsGlobalLayout = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfsGlobalLayout != c.idfsGlobalLayout || o.IsRIRPropChanged(_str_idfsGlobalLayout, c)) 
                  m.Add(_str_idfsGlobalLayout, o.ObjectIdent + _str_idfsGlobalLayout, o.ObjectIdent2 + _str_idfsGlobalLayout, o.ObjectIdent3 + _str_idfsGlobalLayout, "Int64?", 
                    o.idfsGlobalLayout == null ? "" : o.idfsGlobalLayout.ToString(),                  
                  o.IsReadOnly(_str_idfsGlobalLayout), o.IsInvisible(_str_idfsGlobalLayout), o.IsRequired(_str_idfsGlobalLayout)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDefaultLayoutName, _formname = _str_strDefaultLayoutName, _type = "String",
              _get_func = o => o.strDefaultLayoutName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDefaultLayoutName != newval) o.strDefaultLayoutName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDefaultLayoutName != c.strDefaultLayoutName || o.IsRIRPropChanged(_str_strDefaultLayoutName, c)) 
                  m.Add(_str_strDefaultLayoutName, o.ObjectIdent + _str_strDefaultLayoutName, o.ObjectIdent2 + _str_strDefaultLayoutName, o.ObjectIdent3 + _str_strDefaultLayoutName, "String", 
                    o.strDefaultLayoutName == null ? "" : o.strDefaultLayoutName.ToString(),                  
                  o.IsReadOnly(_str_strDefaultLayoutName), o.IsInvisible(_str_strDefaultLayoutName), o.IsRequired(_str_strDefaultLayoutName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strLayoutName, _formname = _str_strLayoutName, _type = "String",
              _get_func = o => o.strLayoutName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strLayoutName != newval) o.strLayoutName = newval; },
              _compare_func = (o, c, m) => {
                if (o.strLayoutName != c.strLayoutName || o.IsRIRPropChanged(_str_strLayoutName, c)) 
                  m.Add(_str_strLayoutName, o.ObjectIdent + _str_strLayoutName, o.ObjectIdent2 + _str_strLayoutName, o.ObjectIdent3 + _str_strLayoutName, "String", 
                    o.strLayoutName == null ? "" : o.strLayoutName.ToString(),                  
                  o.IsReadOnly(_str_strLayoutName), o.IsInvisible(_str_strLayoutName), o.IsRequired(_str_strLayoutName)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idflDescription, _formname = _str_idflDescription, _type = "Int64",
              _get_func = o => o.idflDescription,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idflDescription != newval) o.idflDescription = newval; },
              _compare_func = (o, c, m) => {
                if (o.idflDescription != c.idflDescription || o.IsRIRPropChanged(_str_idflDescription, c)) 
                  m.Add(_str_idflDescription, o.ObjectIdent + _str_idflDescription, o.ObjectIdent2 + _str_idflDescription, o.ObjectIdent3 + _str_idflDescription, "Int64", 
                    o.idflDescription == null ? "" : o.idflDescription.ToString(),                  
                  o.IsReadOnly(_str_idflDescription), o.IsInvisible(_str_idflDescription), o.IsRequired(_str_idflDescription)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idflDescriptionNational, _formname = _str_idflDescriptionNational, _type = "Int32",
              _get_func = o => o.idflDescriptionNational,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.idflDescriptionNational != newval) o.idflDescriptionNational = newval; },
              _compare_func = (o, c, m) => {
                if (o.idflDescriptionNational != c.idflDescriptionNational || o.IsRIRPropChanged(_str_idflDescriptionNational, c)) 
                  m.Add(_str_idflDescriptionNational, o.ObjectIdent + _str_idflDescriptionNational, o.ObjectIdent2 + _str_idflDescriptionNational, o.ObjectIdent3 + _str_idflDescriptionNational, "Int32", 
                    o.idflDescriptionNational == null ? "" : o.idflDescriptionNational.ToString(),                  
                  o.IsReadOnly(_str_idflDescriptionNational), o.IsInvisible(_str_idflDescriptionNational), o.IsRequired(_str_idflDescriptionNational)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDescription, _formname = _str_strDescription, _type = "String",
              _get_func = o => o.strDescription,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDescription != newval) o.strDescription = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDescription != c.strDescription || o.IsRIRPropChanged(_str_strDescription, c)) 
                  m.Add(_str_strDescription, o.ObjectIdent + _str_strDescription, o.ObjectIdent2 + _str_strDescription, o.ObjectIdent3 + _str_strDescription, "String", 
                    o.strDescription == null ? "" : o.strDescription.ToString(),                  
                  o.IsReadOnly(_str_strDescription), o.IsInvisible(_str_strDescription), o.IsRequired(_str_strDescription)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strDescriptionEnglish, _formname = _str_strDescriptionEnglish, _type = "String",
              _get_func = o => o.strDescriptionEnglish,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strDescriptionEnglish != newval) o.strDescriptionEnglish = newval; },
              _compare_func = (o, c, m) => {
                if (o.strDescriptionEnglish != c.strDescriptionEnglish || o.IsRIRPropChanged(_str_strDescriptionEnglish, c)) 
                  m.Add(_str_strDescriptionEnglish, o.ObjectIdent + _str_strDescriptionEnglish, o.ObjectIdent2 + _str_strDescriptionEnglish, o.ObjectIdent3 + _str_strDescriptionEnglish, "String", 
                    o.strDescriptionEnglish == null ? "" : o.strDescriptionEnglish.ToString(),                  
                  o.IsReadOnly(_str_strDescriptionEnglish), o.IsInvisible(_str_strDescriptionEnglish), o.IsRequired(_str_strDescriptionEnglish)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idflQuery, _formname = _str_idflQuery, _type = "Int64",
              _get_func = o => o.idflQuery,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idflQuery != newval) o.idflQuery = newval; },
              _compare_func = (o, c, m) => {
                if (o.idflQuery != c.idflQuery || o.IsRIRPropChanged(_str_idflQuery, c)) 
                  m.Add(_str_idflQuery, o.ObjectIdent + _str_idflQuery, o.ObjectIdent2 + _str_idflQuery, o.ObjectIdent3 + _str_idflQuery, "Int64", 
                    o.idflQuery == null ? "" : o.idflQuery.ToString(),                  
                  o.IsReadOnly(_str_idflQuery), o.IsInvisible(_str_idflQuery), o.IsRequired(_str_idflQuery)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPerson, _formname = _str_idfPerson, _type = "Int64?",
              _get_func = o => o.idfPerson,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfPerson != newval) o.idfPerson = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfPerson != c.idfPerson || o.IsRIRPropChanged(_str_idfPerson, c)) 
                  m.Add(_str_idfPerson, o.ObjectIdent + _str_idfPerson, o.ObjectIdent2 + _str_idfPerson, o.ObjectIdent3 + _str_idfPerson, "Int64?", 
                    o.idfPerson == null ? "" : o.idfPerson.ToString(),                  
                  o.IsReadOnly(_str_idfPerson), o.IsInvisible(_str_idfPerson), o.IsRequired(_str_idfPerson)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnReadOnly, _formname = _str_blnReadOnly, _type = "Boolean",
              _get_func = o => o.blnReadOnly,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnReadOnly != newval) o.blnReadOnly = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnReadOnly != c.blnReadOnly || o.IsRIRPropChanged(_str_blnReadOnly, c)) 
                  m.Add(_str_blnReadOnly, o.ObjectIdent + _str_blnReadOnly, o.ObjectIdent2 + _str_blnReadOnly, o.ObjectIdent3 + _str_blnReadOnly, "Boolean", 
                    o.blnReadOnly == null ? "" : o.blnReadOnly.ToString(),                  
                  o.IsReadOnly(_str_blnReadOnly), o.IsInvisible(_str_blnReadOnly), o.IsRequired(_str_blnReadOnly)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnShareLayout, _formname = _str_blnShareLayout, _type = "Boolean",
              _get_func = o => o.blnShareLayout,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnShareLayout != newval) o.blnShareLayout = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnShareLayout != c.blnShareLayout || o.IsRIRPropChanged(_str_blnShareLayout, c)) 
                  m.Add(_str_blnShareLayout, o.ObjectIdent + _str_blnShareLayout, o.ObjectIdent2 + _str_blnShareLayout, o.ObjectIdent3 + _str_blnShareLayout, "Boolean", 
                    o.blnShareLayout == null ? "" : o.blnShareLayout.ToString(),                  
                  o.IsReadOnly(_str_blnShareLayout), o.IsInvisible(_str_blnShareLayout), o.IsRequired(_str_blnShareLayout)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_blnUseArchivedData, _formname = _str_blnUseArchivedData, _type = "Boolean",
              _get_func = o => o.blnUseArchivedData,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.blnUseArchivedData != newval) o.blnUseArchivedData = newval; },
              _compare_func = (o, c, m) => {
                if (o.blnUseArchivedData != c.blnUseArchivedData || o.IsRIRPropChanged(_str_blnUseArchivedData, c)) 
                  m.Add(_str_blnUseArchivedData, o.ObjectIdent + _str_blnUseArchivedData, o.ObjectIdent2 + _str_blnUseArchivedData, o.ObjectIdent3 + _str_blnUseArchivedData, "Boolean", 
                    o.blnUseArchivedData == null ? "" : o.blnUseArchivedData.ToString(),                  
                  o.IsReadOnly(_str_blnUseArchivedData), o.IsInvisible(_str_blnUseArchivedData), o.IsRequired(_str_blnUseArchivedData)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intOrder, _formname = _str_intOrder, _type = "Int32",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intOrder != newval) o.intOrder = newval; },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, o.ObjectIdent2 + _str_intOrder, o.ObjectIdent3 + _str_intOrder, "Int32", 
                    o.intOrder == null ? "" : o.intOrder.ToString(),                  
                  o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); 
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
            AvrLayoutLookup obj = (AvrLayoutLookup)o;
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
        internal string m_ObjectName = "AvrLayoutLookup";

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
            var ret = base.Clone() as AvrLayoutLookup;
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
            var ret = base.Clone() as AvrLayoutLookup;
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
        public AvrLayoutLookup CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as AvrLayoutLookup;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idflLayout; } }
        public string KeyName { get { return "idflLayout"; } }
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

        private bool IsRIRPropChanged(string fld, AvrLayoutLookup c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      
        public override string ToString()
        {
            return new Func<AvrLayoutLookup, string>(c => c.strDefaultLayoutName)(this);
        }
        

        public AvrLayoutLookup()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(AvrLayoutLookup_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(AvrLayoutLookup_PropertyChanged);
        }
        private void AvrLayoutLookup_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as AvrLayoutLookup).Changed(e.PropertyName);
            
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
            AvrLayoutLookup obj = this;
            
        }
        private void _DeletedExtenders()
        {
            AvrLayoutLookup obj = this;
            
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


        internal Dictionary<string, Func<AvrLayoutLookup, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<AvrLayoutLookup, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<AvrLayoutLookup, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<AvrLayoutLookup, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<AvrLayoutLookup, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<AvrLayoutLookup, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<AvrLayoutLookup, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~AvrLayoutLookup()
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
        : DataAccessor<AvrLayoutLookup>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<AvrLayoutLookup>
            
        {
            #region IObjectAccessor
            public string KeyName { get { return "idflLayout"; } }
            #endregion
        
            private delegate void on_action(AvrLayoutLookup obj);
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
            [InstanceCache(typeof(BvCacheAspect))]
            public virtual List<AvrLayoutLookup> SelectLookupList(DbManagerProxy manager
                , Int64? LayoutID
                , Int64? QueryID
                )
            {
                return _SelectList(manager
                    , LayoutID
                    , QueryID
                    , null, null
                    );
            }
            
            public static string GetLookupTableName(string method)
            {
                return "Layout";
            }
            
            public virtual List<AvrLayoutLookup> SelectList(DbManagerProxy manager
                , Int64? LayoutID
                , Int64? QueryID
                )
            {
                return _SelectList(manager
                    , LayoutID
                    , QueryID
                    , delegate(AvrLayoutLookup obj)
                        {
                        }
                    , delegate(AvrLayoutLookup obj)
                        {
                        }
                    );
            }

            
            private List<AvrLayoutLookup> _SelectList(DbManagerProxy manager
                , Int64? LayoutID
                , Int64? QueryID
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<AvrLayoutLookup> objs = new List<AvrLayoutLookup>();
                    sets[0] = new MapResultSet(typeof(AvrLayoutLookup), objs);
                    
                    manager
                        .SetSpCommand("spAsLayoutSelectLookup"
                            , manager.Parameter("@LayoutID", LayoutID)
                            , manager.Parameter("@QueryID", QueryID)
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, AvrLayoutLookup obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, AvrLayoutLookup obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private AvrLayoutLookup _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    AvrLayoutLookup obj = AvrLayoutLookup.CreateInstance();
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

            
            public AvrLayoutLookup CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public AvrLayoutLookup CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public AvrLayoutLookup CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(AvrLayoutLookup obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(AvrLayoutLookup obj)
            {
                
            }
    

            private void _LoadLookups(DbManagerProxy manager, AvrLayoutLookup obj)
            {
                
            }
    
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(AvrLayoutLookup obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(AvrLayoutLookup obj, bool bRethrowException)
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
                return Validate(manager, obj as AvrLayoutLookup, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, AvrLayoutLookup obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(AvrLayoutLookup obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(AvrLayoutLookup obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as AvrLayoutLookup) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as AvrLayoutLookup) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "AvrLayoutLookupDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spAsLayoutSelectLookup";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<AvrLayoutLookup, bool>> RequiredByField = new Dictionary<string, Func<AvrLayoutLookup, bool>>();
            public static Dictionary<string, Func<AvrLayoutLookup, bool>> RequiredByProperty = new Dictionary<string, Func<AvrLayoutLookup, bool>>();
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
                
                Sizes.Add(_str_strDefaultLayoutName, 2000);
                Sizes.Add(_str_strLayoutName, 2000);
                Sizes.Add(_str_strDescription, 2000);
                Sizes.Add(_str_strDescriptionEnglish, 2000);
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AvrLayoutLookup>().Post(manager, (AvrLayoutLookup)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<AvrLayoutLookup>().Post(manager, (AvrLayoutLookup)c), c),
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
                    (manager, c, pars) => new ActResult(((AvrLayoutLookup)c).MarkToDelete() && ObjectAccessor.PostInterface<AvrLayoutLookup>().Post(manager, (AvrLayoutLookup)c), c),
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
	