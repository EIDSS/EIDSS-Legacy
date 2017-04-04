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
		

namespace bv.tests.Schema
{
        
        
    [XmlType(AnonymousType = true)]
    public abstract partial class MasterTable : 
        EditableObject<MasterTable>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_MasterID), NonUpdatable, PrimaryKey]
        public abstract Int64 MasterID { get; set; }
                
        [LocalizedDisplayName(_str_LookupField1)]
        [MapField(_str_LookupField1)]
        public abstract Int64? LookupField1 { get; set; }
        protected Int64? LookupField1_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._lookupField1).OriginalValue; } }
        protected Int64? LookupField1_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._lookupField1).PreviousValue; } }
                
        [LocalizedDisplayName(_str_LookupField2)]
        [MapField(_str_LookupField2)]
        public abstract Int64? LookupField2 { get; set; }
        protected Int64? LookupField2_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._lookupField2).OriginalValue; } }
        protected Int64? LookupField2_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._lookupField2).PreviousValue; } }
                
        [LocalizedDisplayName(_str_LinkField1)]
        [MapField(_str_LinkField1)]
        public abstract Int64? LinkField1 { get; set; }
        protected Int64? LinkField1_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._linkField1).OriginalValue; } }
        protected Int64? LinkField1_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._linkField1).PreviousValue; } }
                
        [LocalizedDisplayName(_str_TextField)]
        [MapField(_str_TextField)]
        public abstract String TextField { get; set; }
        protected String TextField_Original { get { return ((EditableValue<String>)((dynamic)this)._textField).OriginalValue; } }
        protected String TextField_Previous { get { return ((EditableValue<String>)((dynamic)this)._textField).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<MasterTable, object> _get_func;
            internal Action<MasterTable, string> _set_func;
            internal Action<MasterTable, MasterTable, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_MasterID = "MasterID";
        internal const string _str_LookupField1 = "LookupField1";
        internal const string _str_LookupField2 = "LookupField2";
        internal const string _str_LinkField1 = "LinkField1";
        internal const string _str_TextField = "TextField";
        internal const string _str_InnerDate = "InnerDate";
        internal const string _str_ChildrenCount = "ChildrenCount";
        internal const string _str_TestString = "TestString";
        internal const string _str_Lookup1 = "Lookup1";
        internal const string _str_Lookup2 = "Lookup2";
        internal const string _str_Lookup2Param = "Lookup2Param";
        internal const string _str_Children = "Children";
        internal const string _str_Sibling = "Sibling";
        internal const string _str_Link = "Link";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_MasterID, _formname = _str_MasterID, _type = "Int64",
              _get_func = o => o.MasterID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.MasterID != newval) o.MasterID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.MasterID != c.MasterID || o.IsRIRPropChanged(_str_MasterID, c)) 
                  m.Add(_str_MasterID, o.ObjectIdent + _str_MasterID, o.ObjectIdent2 + _str_MasterID, o.ObjectIdent3 + _str_MasterID, "Int64", 
                    o.MasterID == null ? "" : o.MasterID.ToString(),                  
                  o.IsReadOnly(_str_MasterID), o.IsInvisible(_str_MasterID), o.IsRequired(_str_MasterID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_LookupField1, _formname = _str_LookupField1, _type = "Int64?",
              _get_func = o => o.LookupField1,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.LookupField1 != newval) 
                  o.Lookup1 = o.Lookup1Lookup.FirstOrDefault(c => c.Lookup1ID == newval);
                if (o.LookupField1 != newval) o.LookupField1 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.LookupField1 != c.LookupField1 || o.IsRIRPropChanged(_str_LookupField1, c)) 
                  m.Add(_str_LookupField1, o.ObjectIdent + _str_LookupField1, o.ObjectIdent2 + _str_LookupField1, o.ObjectIdent3 + _str_LookupField1, "Int64?", 
                    o.LookupField1 == null ? "" : o.LookupField1.ToString(),                  
                  o.IsReadOnly(_str_LookupField1), o.IsInvisible(_str_LookupField1), o.IsRequired(_str_LookupField1)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_LookupField2, _formname = _str_LookupField2, _type = "Int64?",
              _get_func = o => o.LookupField2,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); 
                if (o.LookupField2 != newval) 
                  o.Lookup2 = o.Lookup2Lookup.FirstOrDefault(c => c.Lookup2ID == newval);
                if (o.LookupField2 != newval) o.LookupField2 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.LookupField2 != c.LookupField2 || o.IsRIRPropChanged(_str_LookupField2, c)) 
                  m.Add(_str_LookupField2, o.ObjectIdent + _str_LookupField2, o.ObjectIdent2 + _str_LookupField2, o.ObjectIdent3 + _str_LookupField2, "Int64?", 
                    o.LookupField2 == null ? "" : o.LookupField2.ToString(),                  
                  o.IsReadOnly(_str_LookupField2), o.IsInvisible(_str_LookupField2), o.IsRequired(_str_LookupField2)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_LinkField1, _formname = _str_LinkField1, _type = "Int64?",
              _get_func = o => o.LinkField1,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.LinkField1 != newval) o.LinkField1 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.LinkField1 != c.LinkField1 || o.IsRIRPropChanged(_str_LinkField1, c)) 
                  m.Add(_str_LinkField1, o.ObjectIdent + _str_LinkField1, o.ObjectIdent2 + _str_LinkField1, o.ObjectIdent3 + _str_LinkField1, "Int64?", 
                    o.LinkField1 == null ? "" : o.LinkField1.ToString(),                  
                  o.IsReadOnly(_str_LinkField1), o.IsInvisible(_str_LinkField1), o.IsRequired(_str_LinkField1)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_TextField, _formname = _str_TextField, _type = "String",
              _get_func = o => o.TextField,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.TextField != newval) o.TextField = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.TextField != c.TextField || o.IsRIRPropChanged(_str_TextField, c)) 
                  m.Add(_str_TextField, o.ObjectIdent + _str_TextField, o.ObjectIdent2 + _str_TextField, o.ObjectIdent3 + _str_TextField, "String", 
                    o.TextField == null ? "" : o.TextField.ToString(),                  
                  o.IsReadOnly(_str_TextField), o.IsInvisible(_str_TextField), o.IsRequired(_str_TextField)); 
                  }
              }, 
        
            new field_info {
              _name = _str_InnerDate, _formname = _str_InnerDate, _type = "DateTime?",
              _get_func = o => o.InnerDate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.InnerDate != newval) o.InnerDate = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.InnerDate != c.InnerDate || o.IsRIRPropChanged(_str_InnerDate, c)) {
                  m.Add(_str_InnerDate, o.ObjectIdent + _str_InnerDate, o.ObjectIdent2 + _str_InnerDate, o.ObjectIdent3 + _str_InnerDate,  "DateTime?", 
                    o.InnerDate == null ? "" : o.InnerDate.ToString(),                  
                    o.IsReadOnly(_str_InnerDate), o.IsInvisible(_str_InnerDate), o.IsRequired(_str_InnerDate));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_ChildrenCount, _formname = _str_ChildrenCount, _type = "int",
              _get_func = o => o.ChildrenCount,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.ChildrenCount != newval) o.ChildrenCount = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.ChildrenCount != c.ChildrenCount || o.IsRIRPropChanged(_str_ChildrenCount, c)) {
                  m.Add(_str_ChildrenCount, o.ObjectIdent + _str_ChildrenCount, o.ObjectIdent2 + _str_ChildrenCount, o.ObjectIdent3 + _str_ChildrenCount,  "int", 
                    o.ChildrenCount == null ? "" : o.ChildrenCount.ToString(),                  
                    o.IsReadOnly(_str_ChildrenCount), o.IsInvisible(_str_ChildrenCount), o.IsRequired(_str_ChildrenCount));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_TestString, _formname = _str_TestString, _type = "string",
              _get_func = o => o.TestString,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.TestString != newval) o.TestString = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.TestString != c.TestString || o.IsRIRPropChanged(_str_TestString, c)) {
                  m.Add(_str_TestString, o.ObjectIdent + _str_TestString, o.ObjectIdent2 + _str_TestString, o.ObjectIdent3 + _str_TestString,  "string", 
                    o.TestString == null ? "" : o.TestString.ToString(),                  
                    o.IsReadOnly(_str_TestString), o.IsInvisible(_str_TestString), o.IsRequired(_str_TestString));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_Lookup1, _formname = _str_Lookup1, _type = "Lookup",
              _get_func = o => { if (o.Lookup1 == null) return null; return o.Lookup1.Lookup1ID; },
              _set_func = (o, val) => { o.Lookup1 = o.Lookup1Lookup.Where(c => c.Lookup1ID.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Lookup1, c);
                if (o.LookupField1 != c.LookupField1 || o.IsRIRPropChanged(_str_Lookup1, c) || bChangeLookupContent) {
                  m.Add(_str_Lookup1, o.ObjectIdent + _str_Lookup1, o.ObjectIdent2 + _str_Lookup1, o.ObjectIdent3 + _str_Lookup1, "Lookup", o.LookupField1 == null ? "" : o.LookupField1.ToString(), o.IsReadOnly(_str_Lookup1), o.IsInvisible(_str_Lookup1), o.IsRequired(_str_Lookup1),
                  bChangeLookupContent ? o.Lookup1Lookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Lookup1 + "Lookup", _formname = _str_Lookup1 + "Lookup", _type = "LookupContent",
              _get_func = o => o.Lookup1Lookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Lookup2, _formname = _str_Lookup2, _type = "Lookup",
              _get_func = o => { if (o.Lookup2 == null) return null; return o.Lookup2.Lookup2ID; },
              _set_func = (o, val) => { o.Lookup2 = o.Lookup2Lookup.Where(c => c.Lookup2ID.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Lookup2, c);
                if (o.LookupField2 != c.LookupField2 || o.IsRIRPropChanged(_str_Lookup2, c) || bChangeLookupContent) {
                  m.Add(_str_Lookup2, o.ObjectIdent + _str_Lookup2, o.ObjectIdent2 + _str_Lookup2, o.ObjectIdent3 + _str_Lookup2, "Lookup", o.LookupField2 == null ? "" : o.LookupField2.ToString(), o.IsReadOnly(_str_Lookup2), o.IsInvisible(_str_Lookup2), o.IsRequired(_str_Lookup2),
                  bChangeLookupContent ? o.Lookup2Lookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Lookup2 + "Lookup", _formname = _str_Lookup2 + "Lookup", _type = "LookupContent",
              _get_func = o => o.Lookup2Lookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Lookup2Param, _formname = _str_Lookup2Param, _type = "Lookup",
              _get_func = o => { if (o.Lookup2Param == null) return null; return o.Lookup2Param.Lookup2ID; },
              _set_func = (o, val) => { o.Lookup2Param = o.Lookup2ParamLookup.Where(c => c.Lookup2ID.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Lookup2Param, c);
                if (o.LookupField2 != c.LookupField2 || o.IsRIRPropChanged(_str_Lookup2Param, c) || bChangeLookupContent) {
                  m.Add(_str_Lookup2Param, o.ObjectIdent + _str_Lookup2Param, o.ObjectIdent2 + _str_Lookup2Param, o.ObjectIdent3 + _str_Lookup2Param, "Lookup", o.LookupField2 == null ? "" : o.LookupField2.ToString(), o.IsReadOnly(_str_Lookup2Param), o.IsInvisible(_str_Lookup2Param), o.IsRequired(_str_Lookup2Param),
                  bChangeLookupContent ? o.Lookup2ParamLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Lookup2Param + "Lookup", _formname = _str_Lookup2Param + "Lookup", _type = "LookupContent",
              _get_func = o => o.Lookup2ParamLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Children, _formname = _str_Children, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Children.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Children.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.Children.Count != c.Children.Count || o.IsReadOnly(_str_Children) != c.IsReadOnly(_str_Children) || o.IsInvisible(_str_Children) != c.IsInvisible(_str_Children) || o.IsRequired(_str_Children) != c._isRequired(o.m_isRequired, _str_Children)) {
                  m.Add(_str_Children, o.ObjectIdent + _str_Children, o.ObjectIdent2 + _str_Children, o.ObjectIdent3 + _str_Children, "Child", o.MasterID == null ? "" : o.MasterID.ToString(), o.IsReadOnly(_str_Children), o.IsInvisible(_str_Children), o.IsRequired(_str_Children)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Sibling, _formname = _str_Sibling, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.Sibling != null) o.Sibling._compare(c.Sibling, m); }
              }, 
        
            new field_info {
              _name = _str_Link, _formname = _str_Link, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m, g) => {
                if (o.Link != null) o.Link._compare(c.Link, m); }
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
            MasterTable obj = (MasterTable)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Children)]
        [Relation(typeof(ChildObject), bv.tests.Schema.ChildObject._str_ParentID, _str_MasterID)]
        public EditableList<ChildObject> Children
        {
            get 
            {   
                if (!_ChildrenLoaded)
                {
                    _ChildrenLoaded = true;
                    _getAccessor()._LoadChildren(this);
                    _Children.ForEach(c => { c.Parent = this; });
                }
                return _Children; 
            }
            set 
            {
                _Children = value;
            }
        }
        protected EditableList<ChildObject> _Children = new EditableList<ChildObject>();
                    
        private bool _ChildrenLoaded = false;
                    
        [LocalizedDisplayName(_str_Sibling)]
        [Relation(typeof(SiblingObject), bv.tests.Schema.SiblingObject._str_MasterSiblingID, _str_MasterID)]
        public SiblingObject Sibling
        {
            get 
            {   
                if (!_SiblingLoaded)
                {
                    _SiblingLoaded = true;
                    _getAccessor()._LoadSibling(this);
                    if (_Sibling != null) 
                        _Sibling.Parent = this;
                }
                return _Sibling; 
            }
            set 
            {   
                if (!_SiblingLoaded) { _SiblingLoaded = true; }
                _Sibling = value; 
                if (_Sibling != null) 
                { 
                    _Sibling.m_ObjectName = _str_Sibling;
                    _Sibling.Parent = this;
                }
            }
        }
        protected SiblingObject _Sibling;
                    
        private bool _SiblingLoaded = false;
                    
        [LocalizedDisplayName(_str_Link)]
        [Relation(typeof(LinkObject), bv.tests.Schema.LinkObject._str_LinkID, _str_LinkField1)]
        public LinkObject Link
        {
            get 
            {   
                return _Link; 
            }
            set 
            {   
                _Link = value;
                if (_Link != null) 
                { 
                    _Link.m_ObjectName = _str_Link;
                    _Link.Parent = this;
                }
                LinkField1 = _Link == null 
                        ? new Int64?()
                        : _Link.LinkID;
                
            }
        }
        protected LinkObject _Link;
                    
        [LocalizedDisplayName(_str_Lookup1)]
        [Relation(typeof(Lookup1Table), bv.tests.Schema.Lookup1Table._str_Lookup1ID, _str_LookupField1)]
        public Lookup1Table Lookup1
        {
            get { return _Lookup1 == null ? null : ((long)_Lookup1.Key == 0 ? null : _Lookup1); }
            set 
            { 
                var oldVal = _Lookup1;
                _Lookup1 = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Lookup1 != oldVal)
                {
                    if (LookupField1 != (_Lookup1 == null
                            ? new Int64?()
                            : (Int64?)_Lookup1.Lookup1ID))
                        LookupField1 = _Lookup1 == null 
                            ? new Int64?()
                            : (Int64?)_Lookup1.Lookup1ID; 
                    OnPropertyChanged(_str_Lookup1); 
                }
            }
        }
        private Lookup1Table _Lookup1;

        
        public List<Lookup1Table> Lookup1Lookup
        {
            get { return _Lookup1Lookup; }
        }
        private List<Lookup1Table> _Lookup1Lookup = new List<Lookup1Table>();
            
        [LocalizedDisplayName(_str_Lookup2)]
        [Relation(typeof(Lookup2Table), bv.tests.Schema.Lookup2Table._str_Lookup2ID, _str_LookupField2)]
        public Lookup2Table Lookup2
        {
            get { return _Lookup2 == null ? null : ((long)_Lookup2.Key == 0 ? null : _Lookup2); }
            set 
            { 
                var oldVal = _Lookup2;
                _Lookup2 = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Lookup2 != oldVal)
                {
                    if (LookupField2 != (_Lookup2 == null
                            ? new Int64?()
                            : (Int64?)_Lookup2.Lookup2ID))
                        LookupField2 = _Lookup2 == null 
                            ? new Int64?()
                            : (Int64?)_Lookup2.Lookup2ID; 
                    OnPropertyChanged(_str_Lookup2); 
                }
            }
        }
        private Lookup2Table _Lookup2;

        
        public List<Lookup2Table> Lookup2Lookup
        {
            get { return _Lookup2Lookup; }
        }
        private List<Lookup2Table> _Lookup2Lookup = new List<Lookup2Table>();
            
        [LocalizedDisplayName(_str_Lookup2Param)]
        [Relation(typeof(Lookup2ParamTable), bv.tests.Schema.Lookup2ParamTable._str_Lookup2ID, _str_LookupField2)]
        public Lookup2ParamTable Lookup2Param
        {
            get { return _Lookup2Param == null ? null : ((long)_Lookup2Param.Key == 0 ? null : _Lookup2Param); }
            set 
            { 
                var oldVal = _Lookup2Param;
                _Lookup2Param = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Lookup2Param != oldVal)
                {
                    if (LookupField2 != (_Lookup2Param == null
                            ? new Int64?()
                            : (Int64?)_Lookup2Param.Lookup2ID))
                        LookupField2 = _Lookup2Param == null 
                            ? new Int64?()
                            : (Int64?)_Lookup2Param.Lookup2ID; 
                    OnPropertyChanged(_str_Lookup2Param); 
                }
            }
        }
        private Lookup2ParamTable _Lookup2Param;

        
        public List<Lookup2ParamTable> Lookup2ParamLookup
        {
            get { return _Lookup2ParamLookup; }
        }
        private List<Lookup2ParamTable> _Lookup2ParamLookup = new List<Lookup2ParamTable>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Lookup1:
                    return new BvSelectList(Lookup1Lookup, bv.tests.Schema.Lookup1Table._str_Lookup1ID, null, Lookup1, _str_LookupField1);
            
                case _str_Lookup2:
                    return new BvSelectList(Lookup2Lookup, bv.tests.Schema.Lookup2Table._str_Lookup2ID, null, Lookup2, _str_LookupField2);
            
                case _str_Lookup2Param:
                    return new BvSelectList(Lookup2ParamLookup, bv.tests.Schema.Lookup2ParamTable._str_Lookup2ID, null, Lookup2Param, _str_LookupField2);
            
                case _str_Children:
                    return new BvSelectList(Children, "", "", null, "");
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_InnerDate)]
        public DateTime? InnerDate
        {
            get { return m_InnerDate; }
            set { if (m_InnerDate != value) { m_InnerDate = value; OnPropertyChanged(_str_InnerDate); } }
        }
        private DateTime? m_InnerDate;
        
          [LocalizedDisplayName(_str_ChildrenCount)]
        public int ChildrenCount
        {
            get { return m_ChildrenCount; }
            set { if (m_ChildrenCount != value) { m_ChildrenCount = value; OnPropertyChanged(_str_ChildrenCount); } }
        }
        private int m_ChildrenCount;
        
          [LocalizedDisplayName(_str_TestString)]
        public string TestString
        {
            get { return m_TestString; }
            set { if (m_TestString != value) { m_TestString = value; OnPropertyChanged(_str_TestString); } }
        }
        private string m_TestString;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "MasterTable";

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
        Children.ForEach(c => { c.Parent = this; });
                
            if (_Sibling != null) { _Sibling.Parent = this; }
                
            if (_Link != null) { _Link.Parent = this; }
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as MasterTable;
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
            var ret = base.Clone() as MasterTable;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Children != null && _Children.Count > 0)
            {
              ret.Children.Clear();
              _Children.ForEach(c => ret.Children.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_Sibling != null)
              ret.Sibling = _Sibling.CloneWithSetup(manager, bRestricted) as SiblingObject;
                
            if (_Link != null)
              ret.Link = _Link.CloneWithSetup(manager, bRestricted) as LinkObject;
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public MasterTable CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as MasterTable;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return MasterID; } }
        public string KeyName { get { return "MasterID"; } }
        public object KeyLookup { get { return MasterID; } }
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
        
                    || Children.IsDirty
                    || Children.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || (_Sibling != null && _Sibling.HasChanges)
                
                    || (_Link != null && _Link.HasChanges)
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_LookupField1_Lookup1 = LookupField1;
            var _prev_LookupField2_Lookup2 = LookupField2;
            var _prev_LookupField2_Lookup2Param = LookupField2;
            base.RejectChanges();
        
            if (_prev_LookupField1_Lookup1 != LookupField1)
            {
                _Lookup1 = _Lookup1Lookup.FirstOrDefault(c => c.Lookup1ID == LookupField1);
            }
            if (_prev_LookupField2_Lookup2 != LookupField2)
            {
                _Lookup2 = _Lookup2Lookup.FirstOrDefault(c => c.Lookup2ID == LookupField2);
            }
            if (_prev_LookupField2_Lookup2Param != LookupField2)
            {
                _Lookup2Param = _Lookup2ParamLookup.FirstOrDefault(c => c.Lookup2ID == LookupField2);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        Children.DeepRejectChanges();
                
            if (Sibling != null) Sibling.DeepRejectChanges();
                
            if (Link != null) Link.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        Children.DeepAcceptChanges();
                
            if (_Sibling != null) _Sibling.DeepAcceptChanges();
                
            if (_Link != null) _Link.DeepAcceptChanges();
                
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
        Children.ForEach(c => c.SetChange());
                
            if (_Sibling != null) _Sibling.SetChange();
                
            if (_Link != null) _Link.SetChange();
                
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

        private bool IsRIRPropChanged(string fld, MasterTable c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, MasterTable c)
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
        

      

        public MasterTable()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(MasterTable_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(MasterTable_PropertyChanged);
        }
        private void MasterTable_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as MasterTable).Changed(e.PropertyName);
            
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
            MasterTable obj = this;
            try
            {
            
                (new RequiredValidator( "TestString", "TestString","",
                ValidationEventType.Error
              )).Validate(c => true, obj, obj.TestString);
            
            }
            catch(ValidationModelException ex)
            {
                if (bReport && !OnValidation(ex))
                {
                    OnValidationEnd(ex);
                }
                
                return false;
            }
            
            return Accessor.Instance(null).ValidateCanDelete(this);
              
        }
        private void _DeletingExtenders()
        {
            MasterTable obj = this;
            
        }
        private void _DeletedExtenders()
        {
            MasterTable obj = this;
            
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
        
                foreach(var o in _Children)
                    o._isValid &= value;
                
                if (_Sibling != null)
                    _Sibling._isValid &= value;
                
                if (_Link != null)
                    _Link._isValid &= value;
                
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _Children)
                    o.ReadOnly |= value;
                
                if (_Sibling != null)
                    _Sibling.ReadOnly |= value;
                
                if (_Link != null)
                    _Link.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<MasterTable, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<MasterTable, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<MasterTable, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<MasterTable, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<MasterTable, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<MasterTable, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<MasterTable, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~MasterTable()
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
                
                if (_Sibling != null)
                    Sibling.Dispose();
                
                if (_Link != null)
                    Link.Dispose();
                
                if (!bIsClone)
                {
                    Children.ForEach(c => c.Dispose());
                }
                Children.ClearModelListEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("Lookup1Table", this);
                
                LookupManager.RemoveObject("Lookup2Table", this);
                
                LookupManager.RemoveObject("Lookup2ParamTable", this);
                
                }
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "Lookup1Table")
                _getAccessor().LoadLookup_Lookup1(manager, this);
            
            if (lookup_object == "Lookup2Table")
                _getAccessor().LoadLookup_Lookup2(manager, this);
            
            if (lookup_object == "Lookup2ParamTable")
                _getAccessor().LoadLookup_Lookup2Param(manager, this);
            
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
        
            if (_Children != null) _Children.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Sibling != null) _Sibling.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            if (_Link != null) _Link.ParseFormCollection(form, bParseLookups, bParseRelations);
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<MasterTable>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<MasterTable>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<MasterTable>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "MasterID"; } }
            #endregion
        
            public delegate void on_action(MasterTable obj);
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
            private ChildObject.Accessor ChildrenAccessor { get { return bv.tests.Schema.ChildObject.Accessor.Instance(m_CS); } }
            private SiblingObject.Accessor SiblingAccessor { get { return bv.tests.Schema.SiblingObject.Accessor.Instance(m_CS); } }
            private LinkObject.Accessor LinkAccessor { get { return bv.tests.Schema.LinkObject.Accessor.Instance(m_CS); } }
            private Lookup1Table.Accessor Lookup1Accessor { get { return bv.tests.Schema.Lookup1Table.Accessor.Instance(m_CS); } }
            private Lookup2Table.Accessor Lookup2Accessor { get { return bv.tests.Schema.Lookup2Table.Accessor.Instance(m_CS); } }
            private Lookup2ParamTable.Accessor Lookup2ParamAccessor { get { return bv.tests.Schema.Lookup2ParamTable.Accessor.Instance(m_CS); } }
            

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
            public virtual MasterTable SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
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

            
            public virtual MasterTable SelectByKey(DbManagerProxy manager
                , Int64? MasterID
                )
            {
                return _SelectByKey(manager
                    , MasterID
                    , null, null
                    );
            }
            
            public MasterTable GetT(DbManagerProxy manager, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                
                if (!(pars[0] is Int64?)) 
                    throw new TypeMismatchException("MasterID", typeof(Int64?));
                
                return Get(manager
                    
                    , (Int64?)pars[0]
                    
                    );
            }
            public IObject Get(DbManagerProxy manager, List<object> pars)
            {
                return GetT(manager, pars);
            }
            
            public virtual MasterTable Get(DbManagerProxy manager
                , Int64? MasterID
                )
            {
                return _SelectByKey(manager
                    , MasterID
                    , obj =>
                {
                obj.TextField = new Func<MasterTable, string>(c => "load")(obj);
                }
                    , obj =>
                {
                obj.ChildrenCount = new Func<MasterTable, int>(c => c.Children.Count)(obj);
                }
                );
            }
            

            private MasterTable _SelectByKey(DbManagerProxy manager
                , Int64? MasterID
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , MasterID
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual MasterTable _SelectByKeyInternal(DbManagerProxy manager
                , Int64? MasterID
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<MasterTable> objs = new List<MasterTable>();
                sets[0] = new MapResultSet(typeof(MasterTable), objs);
                MasterTable obj = null;
                try
                {
                    manager
                        .SetSpCommand("spMasterObject_SelectDetail"
                            , manager.Parameter("@MasterID", MasterID)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    obj = objs[0];
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
                    throw DbModelException.Create(obj, e);
                  }
                
            }
    
            private void _SetupAddChildHandlerChildren(MasterTable obj)
            {
                obj.Children.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
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
            
            internal void _LoadChildren(MasterTable obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadChildren(manager, obj);
                }
            }
            internal void _LoadChildren(DbManagerProxy manager, MasterTable obj)
            {
              
                obj.Children.Clear();
                obj.Children.AddRange(ChildrenAccessor.SelectDetailList(manager
                    
                    , obj.MasterID
                    ));
                obj.Children.ForEach(c => c.m_ObjectName = _str_Children);
                obj.Children.AcceptChanges();
                    
              }
            
            internal void _LoadSibling(MasterTable obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadSibling(manager, obj);
                }
            }
            internal void _LoadSibling(DbManagerProxy manager, MasterTable obj)
            {
              
                if (obj.Sibling == null && obj.MasterID != 0)
                {
                    obj.Sibling = SiblingAccessor.SelectByKey(manager
                        
                        , obj.MasterID
                        );
                    if (obj.Sibling != null)
                    {
                        obj.Sibling.m_ObjectName = _str_Sibling;
                    }
                }
                    
              }
            
            internal void _LoadLink(MasterTable obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadLink(manager, obj);
                }
            }
            internal void _LoadLink(DbManagerProxy manager, MasterTable obj)
            {
              
                if (obj.Link == null && obj.LinkField1 != null && obj.LinkField1 != 0)
                {
                    obj.Link = LinkAccessor.SelectByKey(manager
                        
                        , obj.LinkField1.Value
                        );
                    if (obj.Link != null)
                    {
                        obj.Link.m_ObjectName = _str_Link;
                    }
                }
                    
              }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, MasterTable obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                obj.InnerDate = (new GetDateTimeNowExtender<MasterTable>()).GetScalar(manager, obj);
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadLink(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.Children.Add(new Func<MasterTable, ChildObject>(c => ChildrenAccessor.Create(manager, c, c.MasterID))(obj));
                obj.Children.ForEach(t => { t.TextFieldFromMaster = new Func<MasterTable, string>(c => c.TextField + "0")(obj); } );
                obj.Children[0].TextFieldFromMaster = obj.TextField;
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerChildren(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, MasterTable obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    SiblingAccessor._SetPermitions(obj._permissions, obj.Sibling);
                    LinkAccessor._SetPermitions(obj._permissions, obj.Link);
                    
                        obj.Children.ForEach(c => ChildrenAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private MasterTable _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                MasterTable obj = null;
                try
                {
                    obj = MasterTable.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.MasterID = 1000001;
                obj.Sibling = new Func<MasterTable, SiblingObject>(c => SiblingAccessor.Create(manager, c, c.MasterID))(obj);
                obj.Link = (new ObjectCreateExtender<LinkObject.Accessor, LinkObject>()).Create(manager, obj
                
                        , null);
                    
                obj.InnerDate = (new GetDateTimeNowExtender<MasterTable>()).GetScalar(manager, obj, isFake);
                obj.Children.Add(new Func<MasterTable, ChildObject>(c => ChildrenAccessor.Create(manager, c, c.MasterID))(obj));
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerChildren(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                obj.Children.Add(ChildrenAccessor.Create(manager, obj, obj.MasterID));
                obj.Children.ForEach(t => { t.TextFieldFromMaster = new Func<MasterTable, string>(c => c.TextField + "0")(obj); } );
                obj.Children[0].TextFieldFromMaster = obj.TextField;
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

            
            public MasterTable CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public MasterTable CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public MasterTable CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public MasterTable CreateT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is int?)) 
                    throw new TypeMismatchException("HACode", typeof(int?));
                
                return Create(manager, Parent
                    , (int?)pars[0]
                    );
            }
            public IObject Create(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateT(manager, Parent, pars);
            }
            public MasterTable Create(DbManagerProxy manager, IObject Parent
                , int? HACode
                )
            {
                return _CreateNew(manager, Parent
                
                    , HACode
                    
                    , obj =>
                {
                obj.TextField = new Func<MasterTable, string>(c => "create")(obj);
                }
                    , obj =>
                {
                obj.ChildrenCount = new Func<MasterTable, int>(c => c.Children.Count)(obj);
                }
                );
            }
            
            private void _SetupChildHandlers(MasterTable obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(MasterTable obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_LookupField1)
                        {
                    
                obj.Lookup2 = null;
                        }
                    
                        if (e.PropertyName == _str_LookupField1)
                        {
                    
                obj.Lookup2Param = new Func<MasterTable, Lookup2ParamTable>(c => null)(obj);
                        }
                    
                        if (e.PropertyName == _str_LookupField1)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Lookup2(manager, obj);
                        }
                    
                        if (e.PropertyName == _str_LookupField1)
                        {
                    
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_Lookup2Param(manager, obj);
                        }
                    
                    };
                
            }
    
            public void LoadLookup_Lookup1(DbManagerProxy manager, MasterTable obj)
            {
                
                obj.Lookup1Lookup.Clear();
                
                obj.Lookup1Lookup.Add(Lookup1Accessor.CreateNewT(manager, null));
                
                obj.Lookup1Lookup.AddRange(Lookup1Accessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.Lookup1ID == obj.LookupField1))
                    
                    .ToList());
                
                if (obj.LookupField1 != null && obj.LookupField1 != 0)
                {
                    obj.Lookup1 = obj.Lookup1Lookup
                        .SingleOrDefault(c => c.Lookup1ID == obj.LookupField1);
                    
                }
              
                LookupManager.AddObject("Lookup1Table", obj, Lookup1Accessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Lookup2(DbManagerProxy manager, MasterTable obj)
            {
                
                obj.Lookup2Lookup.Clear();
                
                obj.Lookup2Lookup.Add(Lookup2Accessor.CreateNewT(manager, null));
                
                obj.Lookup2Lookup.AddRange(Lookup2Accessor.SelectLookupList(manager
                    
                    )
                    .Where(c => c.Lookup2ParentID == obj.LookupField1)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.Lookup2ID == obj.LookupField2))
                    
                    .ToList());
                
                if (obj.LookupField2 != null && obj.LookupField2 != 0)
                {
                    obj.Lookup2 = obj.Lookup2Lookup
                        .SingleOrDefault(c => c.Lookup2ID == obj.LookupField2);
                    
                }
              
                LookupManager.AddObject("Lookup2Table", obj, Lookup2Accessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            
            public void LoadLookup_Lookup2Param(DbManagerProxy manager, MasterTable obj)
            {
                
                obj.Lookup2ParamLookup.Clear();
                
                obj.Lookup2ParamLookup.Add(Lookup2ParamAccessor.CreateNewT(manager, null));
                
                obj.Lookup2ParamLookup.AddRange(Lookup2ParamAccessor.SelectLookupList(manager
                    
                    , new Func<MasterTable, int>(c => (int?)c.LookupField1 ?? 0)(obj)
                            
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.Lookup2ID == obj.LookupField2))
                    
                    .ToList());
                
                if (obj.LookupField2 != null && obj.LookupField2 != 0)
                {
                    obj.Lookup2Param = obj.Lookup2ParamLookup
                        .SingleOrDefault(c => c.Lookup2ID == obj.LookupField2);
                    
                }
              
                LookupManager.AddObject("Lookup2ParamTable", obj, Lookup2ParamAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, MasterTable obj)
            {
                
                LoadLookup_Lookup1(manager, obj);
                
                LoadLookup_Lookup2(manager, obj);
                
                LoadLookup_Lookup2Param(manager, obj);
                
            }
    
            [SprocName("spMasterObject_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spMasterObject_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("LinkField1", "TextField")] MasterTable obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("LinkField1", "TextField")] MasterTable obj)
            {
                
                if (new Func<MasterTable, bool>(c => true)(obj))
                {
                
                _post(manager, Action, obj);
                
                }
                
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
                        MasterTable bo = obj as MasterTable;
                        
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
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as MasterTable, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, MasterTable obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                                
                    _postPredicate(manager, 8, obj);
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                obj.TextField = new Func<MasterTable, string>(c => c.TextField == "RAISERROR" ? c.TextField : "post")(obj);
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                                    
                    if (obj.IsNew)
                    {
                        if (obj.Sibling != null) // forced load potential lazy subobject for new object
                            if (!SiblingAccessor.Post(manager, obj.Sibling, true))
                                return false;
                    }
                    else
                    {
                        if (obj._Sibling != null) // do not load lazy subobject for existing object
                            if (!SiblingAccessor.Post(manager, obj.Sibling, true))
                                return false;
                    }
                                    
                    // posted extenters - begin
                obj.Children.Add(new Func<MasterTable, ChildObject>(c => ChildrenAccessor.Create(manager, c, c.MasterID))(obj));
                obj.ChildrenCount = new Func<MasterTable, int>(c => c.Children.Where(i => !i.IsMarkedToDelete).Count())(obj);
                obj.Children.ForEach(t => { t.TextFieldFromMaster = new Func<MasterTable, string>(c => c.TextField + "0")(obj); } );
                obj.Children[0].TextFieldFromMaster = new Func<MasterTable, string>(c => c.TextField)(obj);
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(MasterTable obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, MasterTable obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.MasterID
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
        
      
            protected ValidationModelException ChainsValidate(MasterTable obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(MasterTable obj, bool bRethrowException)
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
                return Validate(manager, obj as MasterTable, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, MasterTable obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(MasterTable obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(MasterTable obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as MasterTable) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as MasterTable) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "MasterTableDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spMasterObject_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spMasterObject_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "spMasterObject_CanDelete";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<MasterTable, bool>> RequiredByField = new Dictionary<string, Func<MasterTable, bool>>();
            public static Dictionary<string, Func<MasterTable, bool>> RequiredByProperty = new Dictionary<string, Func<MasterTable, bool>>();
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
                
                Sizes.Add(_str_TextField, 100);
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
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Get",
                    ActionTypes.Load,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, c),
                        
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<MasterTable>().Post(manager, (MasterTable)c), c),
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
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<MasterTable>().Post(manager, (MasterTable)c), c),
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
                    (manager, c, pars) => new ActResult(((MasterTable)c).MarkToDelete() && ObjectAccessor.PostInterface<MasterTable>().Post(manager, (MasterTable)c), c),
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
	