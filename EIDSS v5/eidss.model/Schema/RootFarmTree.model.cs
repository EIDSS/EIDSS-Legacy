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
    public abstract partial class RootFarmTree : 
        EditableObject<RootFarmTree>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfParty), NonUpdatable, PrimaryKey]
        public abstract Int64 idfParty { get; set; }
                
        [LocalizedDisplayName(_str_idfsPartyType)]
        [MapField(_str_idfsPartyType)]
        public abstract Int32 idfsPartyType { get; set; }
        #if MONO
        protected Int32 idfsPartyType_Original { get { return idfsPartyType; } }
        protected Int32 idfsPartyType_Previous { get { return idfsPartyType; } }
        #else
        protected Int32 idfsPartyType_Original { get { return ((EditableValue<Int32>)((dynamic)this)._idfsPartyType).OriginalValue; } }
        protected Int32 idfsPartyType_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._idfsPartyType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strName)]
        [MapField(_str_strName)]
        public abstract String strName { get; set; }
        #if MONO
        protected String strName_Original { get { return strName; } }
        protected String strName_Previous { get { return strName; } }
        #else
        protected String strName_Original { get { return ((EditableValue<String>)((dynamic)this)._strName).OriginalValue; } }
        protected String strName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfParentParty)]
        [MapField(_str_idfParentParty)]
        public abstract Int64? idfParentParty { get; set; }
        #if MONO
        protected Int64? idfParentParty_Original { get { return idfParentParty; } }
        protected Int64? idfParentParty_Previous { get { return idfParentParty; } }
        #else
        protected Int64? idfParentParty_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentParty).OriginalValue; } }
        protected Int64? idfParentParty_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfParentParty).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intTotalAnimalQty)]
        [MapField(_str_intTotalAnimalQty)]
        public abstract Int32? intTotalAnimalQty { get; set; }
        #if MONO
        protected Int32? intTotalAnimalQty_Original { get { return intTotalAnimalQty; } }
        protected Int32? intTotalAnimalQty_Previous { get { return intTotalAnimalQty; } }
        #else
        protected Int32? intTotalAnimalQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intTotalAnimalQty).OriginalValue; } }
        protected Int32? intTotalAnimalQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intTotalAnimalQty).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intSickAnimalQty)]
        [MapField(_str_intSickAnimalQty)]
        public abstract Int32? intSickAnimalQty { get; set; }
        #if MONO
        protected Int32? intSickAnimalQty_Original { get { return intSickAnimalQty; } }
        protected Int32? intSickAnimalQty_Previous { get { return intSickAnimalQty; } }
        #else
        protected Int32? intSickAnimalQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intSickAnimalQty).OriginalValue; } }
        protected Int32? intSickAnimalQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intSickAnimalQty).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intDeadAnimalQty)]
        [MapField(_str_intDeadAnimalQty)]
        public abstract Int32? intDeadAnimalQty { get; set; }
        #if MONO
        protected Int32? intDeadAnimalQty_Original { get { return intDeadAnimalQty; } }
        protected Int32? intDeadAnimalQty_Previous { get { return intDeadAnimalQty; } }
        #else
        protected Int32? intDeadAnimalQty_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intDeadAnimalQty).OriginalValue; } }
        protected Int32? intDeadAnimalQty_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intDeadAnimalQty).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_strAverageAge)]
        [MapField(_str_strAverageAge)]
        public abstract Int32? strAverageAge { get; set; }
        #if MONO
        protected Int32? strAverageAge_Original { get { return strAverageAge; } }
        protected Int32? strAverageAge_Previous { get { return strAverageAge; } }
        #else
        protected Int32? strAverageAge_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._strAverageAge).OriginalValue; } }
        protected Int32? strAverageAge_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._strAverageAge).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_datStartOfSignsDate)]
        [MapField(_str_datStartOfSignsDate)]
        public abstract DateTime? datStartOfSignsDate { get; set; }
        #if MONO
        protected DateTime? datStartOfSignsDate_Original { get { return datStartOfSignsDate; } }
        protected DateTime? datStartOfSignsDate_Previous { get { return datStartOfSignsDate; } }
        #else
        protected DateTime? datStartOfSignsDate_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartOfSignsDate).OriginalValue; } }
        protected DateTime? datStartOfSignsDate_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datStartOfSignsDate).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("VetFarmTree.strNote")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        #if MONO
        protected String strNote_Original { get { return strNote; } }
        protected String strNote_Previous { get { return strNote; } }
        #else
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_HACode)]
        [MapField(_str_HACode)]
        public abstract Int32? HACode { get; set; }
        #if MONO
        protected Int32? HACode_Original { get { return HACode; } }
        protected Int32? HACode_Previous { get { return HACode; } }
        #else
        protected Int32? HACode_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._hACode).OriginalValue; } }
        protected Int32? HACode_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._hACode).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_intOrder)]
        [MapField(_str_intOrder)]
        public abstract Int32 intOrder { get; set; }
        #if MONO
        protected Int32 intOrder_Original { get { return intOrder; } }
        protected Int32 intOrder_Previous { get { return intOrder; } }
        #else
        protected Int32 intOrder_Original { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).OriginalValue; } }
        protected Int32 intOrder_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._intOrder).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<RootFarmTree, object> _get_func;
            internal Action<RootFarmTree, string> _set_func;
            internal Action<RootFarmTree, RootFarmTree, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfParty = "idfParty";
        internal const string _str_idfsPartyType = "idfsPartyType";
        internal const string _str_strName = "strName";
        internal const string _str_idfParentParty = "idfParentParty";
        internal const string _str_intTotalAnimalQty = "intTotalAnimalQty";
        internal const string _str_intSickAnimalQty = "intSickAnimalQty";
        internal const string _str_intDeadAnimalQty = "intDeadAnimalQty";
        internal const string _str_strAverageAge = "strAverageAge";
        internal const string _str_datStartOfSignsDate = "datStartOfSignsDate";
        internal const string _str_strNote = "strNote";
        internal const string _str_HACode = "HACode";
        internal const string _str_intOrder = "intOrder";
        internal const string _str_idfsSpeciesTypeReference = "idfsSpeciesTypeReference";
        internal const string _str_lOrderingSequence = "lOrderingSequence";
        internal const string _str_strSpeciesName = "strSpeciesName";
        internal const string _str_strHerdName = "strHerdName";
        internal const string _str_SpeciesType = "SpeciesType";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfParty, _type = "Int64",
              _get_func = o => o.idfParty,
              _set_func = (o, val) => { o.idfParty = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfParty != c.idfParty || o.IsRIRPropChanged(_str_idfParty, c)) 
                  m.Add(_str_idfParty, o.ObjectIdent + _str_idfParty, "Int64", o.idfParty == null ? "" : o.idfParty.ToString(), o.IsReadOnly(_str_idfParty), o.IsInvisible(_str_idfParty), o.IsRequired(_str_idfParty)); }
              }, 
        
            new field_info {
              _name = _str_idfsPartyType, _type = "Int32",
              _get_func = o => o.idfsPartyType,
              _set_func = (o, val) => { o.idfsPartyType = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsPartyType != c.idfsPartyType || o.IsRIRPropChanged(_str_idfsPartyType, c)) 
                  m.Add(_str_idfsPartyType, o.ObjectIdent + _str_idfsPartyType, "Int32", o.idfsPartyType == null ? "" : o.idfsPartyType.ToString(), o.IsReadOnly(_str_idfsPartyType), o.IsInvisible(_str_idfsPartyType), o.IsRequired(_str_idfsPartyType)); }
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
              _name = _str_idfParentParty, _type = "Int64?",
              _get_func = o => o.idfParentParty,
              _set_func = (o, val) => { o.idfParentParty = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfParentParty != c.idfParentParty || o.IsRIRPropChanged(_str_idfParentParty, c)) 
                  m.Add(_str_idfParentParty, o.ObjectIdent + _str_idfParentParty, "Int64?", o.idfParentParty == null ? "" : o.idfParentParty.ToString(), o.IsReadOnly(_str_idfParentParty), o.IsInvisible(_str_idfParentParty), o.IsRequired(_str_idfParentParty)); }
              }, 
        
            new field_info {
              _name = _str_intTotalAnimalQty, _type = "Int32?",
              _get_func = o => o.intTotalAnimalQty,
              _set_func = (o, val) => { o.intTotalAnimalQty = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intTotalAnimalQty != c.intTotalAnimalQty || o.IsRIRPropChanged(_str_intTotalAnimalQty, c)) 
                  m.Add(_str_intTotalAnimalQty, o.ObjectIdent + _str_intTotalAnimalQty, "Int32?", o.intTotalAnimalQty == null ? "" : o.intTotalAnimalQty.ToString(), o.IsReadOnly(_str_intTotalAnimalQty), o.IsInvisible(_str_intTotalAnimalQty), o.IsRequired(_str_intTotalAnimalQty)); }
              }, 
        
            new field_info {
              _name = _str_intSickAnimalQty, _type = "Int32?",
              _get_func = o => o.intSickAnimalQty,
              _set_func = (o, val) => { o.intSickAnimalQty = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intSickAnimalQty != c.intSickAnimalQty || o.IsRIRPropChanged(_str_intSickAnimalQty, c)) 
                  m.Add(_str_intSickAnimalQty, o.ObjectIdent + _str_intSickAnimalQty, "Int32?", o.intSickAnimalQty == null ? "" : o.intSickAnimalQty.ToString(), o.IsReadOnly(_str_intSickAnimalQty), o.IsInvisible(_str_intSickAnimalQty), o.IsRequired(_str_intSickAnimalQty)); }
              }, 
        
            new field_info {
              _name = _str_intDeadAnimalQty, _type = "Int32?",
              _get_func = o => o.intDeadAnimalQty,
              _set_func = (o, val) => { o.intDeadAnimalQty = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.intDeadAnimalQty != c.intDeadAnimalQty || o.IsRIRPropChanged(_str_intDeadAnimalQty, c)) 
                  m.Add(_str_intDeadAnimalQty, o.ObjectIdent + _str_intDeadAnimalQty, "Int32?", o.intDeadAnimalQty == null ? "" : o.intDeadAnimalQty.ToString(), o.IsReadOnly(_str_intDeadAnimalQty), o.IsInvisible(_str_intDeadAnimalQty), o.IsRequired(_str_intDeadAnimalQty)); }
              }, 
        
            new field_info {
              _name = _str_strAverageAge, _type = "Int32?",
              _get_func = o => o.strAverageAge,
              _set_func = (o, val) => { o.strAverageAge = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.strAverageAge != c.strAverageAge || o.IsRIRPropChanged(_str_strAverageAge, c)) 
                  m.Add(_str_strAverageAge, o.ObjectIdent + _str_strAverageAge, "Int32?", o.strAverageAge == null ? "" : o.strAverageAge.ToString(), o.IsReadOnly(_str_strAverageAge), o.IsInvisible(_str_strAverageAge), o.IsRequired(_str_strAverageAge)); }
              }, 
        
            new field_info {
              _name = _str_datStartOfSignsDate, _type = "DateTime?",
              _get_func = o => o.datStartOfSignsDate,
              _set_func = (o, val) => { o.datStartOfSignsDate = ParsingHelper.ParseDateTimeNullable(val); },
              _compare_func = (o, c, m) => {
                if (o.datStartOfSignsDate != c.datStartOfSignsDate || o.IsRIRPropChanged(_str_datStartOfSignsDate, c)) 
                  m.Add(_str_datStartOfSignsDate, o.ObjectIdent + _str_datStartOfSignsDate, "DateTime?", o.datStartOfSignsDate == null ? "" : o.datStartOfSignsDate.ToString(), o.IsReadOnly(_str_datStartOfSignsDate), o.IsInvisible(_str_datStartOfSignsDate), o.IsRequired(_str_datStartOfSignsDate)); }
              }, 
        
            new field_info {
              _name = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { o.strNote = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, "String", o.strNote == null ? "" : o.strNote.ToString(), o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); }
              }, 
        
            new field_info {
              _name = _str_HACode, _type = "Int32?",
              _get_func = o => o.HACode,
              _set_func = (o, val) => { o.HACode = ParsingHelper.ParseInt32Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.HACode != c.HACode || o.IsRIRPropChanged(_str_HACode, c)) 
                  m.Add(_str_HACode, o.ObjectIdent + _str_HACode, "Int32?", o.HACode == null ? "" : o.HACode.ToString(), o.IsReadOnly(_str_HACode), o.IsInvisible(_str_HACode), o.IsRequired(_str_HACode)); }
              }, 
        
            new field_info {
              _name = _str_intOrder, _type = "Int32",
              _get_func = o => o.intOrder,
              _set_func = (o, val) => { o.intOrder = ParsingHelper.ParseInt32(val); },
              _compare_func = (o, c, m) => {
                if (o.intOrder != c.intOrder || o.IsRIRPropChanged(_str_intOrder, c)) 
                  m.Add(_str_intOrder, o.ObjectIdent + _str_intOrder, "Int32", o.intOrder == null ? "" : o.intOrder.ToString(), o.IsReadOnly(_str_intOrder), o.IsInvisible(_str_intOrder), o.IsRequired(_str_intOrder)); }
              }, 
        
            new field_info {
              _name = _str_strHerdName, _type = "string",
              _get_func = o => o.strHerdName,
              _set_func = (o, val) => { o.strHerdName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
              
                if (o.strHerdName != c.strHerdName || o.IsRIRPropChanged(_str_strHerdName, c)) 
                  m.Add(_str_strHerdName, o.ObjectIdent + _str_strHerdName, "string", o.strHerdName == null ? "" : o.strHerdName.ToString(), o.IsReadOnly(_str_strHerdName), o.IsInvisible(_str_strHerdName), o.IsRequired(_str_strHerdName));
                 }
              }, 
        
            new field_info {
              _name = _str_idfsSpeciesTypeReference, _type = "long?",
              _get_func = o => o.idfsSpeciesTypeReference,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.idfsSpeciesTypeReference != c.idfsSpeciesTypeReference || o.IsRIRPropChanged(_str_idfsSpeciesTypeReference, c)) 
                  m.Add(_str_idfsSpeciesTypeReference, o.ObjectIdent + _str_idfsSpeciesTypeReference, "long?", o.idfsSpeciesTypeReference == null ? "" : o.idfsSpeciesTypeReference.ToString(), o.IsReadOnly(_str_idfsSpeciesTypeReference), o.IsInvisible(_str_idfsSpeciesTypeReference), o.IsRequired(_str_idfsSpeciesTypeReference));
                 }
              }, 
        
            new field_info {
              _name = _str_lOrderingSequence, _type = "long?",
              _get_func = o => o.lOrderingSequence,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.lOrderingSequence != c.lOrderingSequence || o.IsRIRPropChanged(_str_lOrderingSequence, c)) 
                  m.Add(_str_lOrderingSequence, o.ObjectIdent + _str_lOrderingSequence, "long?", o.lOrderingSequence == null ? "" : o.lOrderingSequence.ToString(), o.IsReadOnly(_str_lOrderingSequence), o.IsInvisible(_str_lOrderingSequence), o.IsRequired(_str_lOrderingSequence));
                 }
              }, 
        
            new field_info {
              _name = _str_strSpeciesName, _type = "string",
              _get_func = o => o.strSpeciesName,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              
                if (o.strSpeciesName != c.strSpeciesName || o.IsRIRPropChanged(_str_strSpeciesName, c)) 
                  m.Add(_str_strSpeciesName, o.ObjectIdent + _str_strSpeciesName, "string", o.strSpeciesName == null ? "" : o.strSpeciesName.ToString(), o.IsReadOnly(_str_strSpeciesName), o.IsInvisible(_str_strSpeciesName), o.IsRequired(_str_strSpeciesName));
                 }
              }, 
        
            new field_info {
              _name = _str_SpeciesType, _type = "Lookup",
              _get_func = o => { if (o.SpeciesType == null) return null; return o.SpeciesType.idfsBaseReference; },
              _set_func = (o, val) => { o.SpeciesType = o.SpeciesTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsSpeciesTypeReference != c.idfsSpeciesTypeReference || o.IsRIRPropChanged(_str_SpeciesType, c)) 
                  m.Add(_str_SpeciesType, o.ObjectIdent + _str_SpeciesType, "Lookup", o.idfsSpeciesTypeReference == null ? "" : o.idfsSpeciesTypeReference.ToString(), o.IsReadOnly(_str_SpeciesType), o.IsInvisible(_str_SpeciesType), o.IsRequired(_str_SpeciesType)); }
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
            RootFarmTree obj = (RootFarmTree)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsSpeciesTypeReference)]
        public BaseReference SpeciesType
        {
            get { return _SpeciesType == null ? null : ((long)_SpeciesType.Key == 0 ? null : _SpeciesType); }
            set 
            { 
                _SpeciesType = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsSpeciesTypeReference = _SpeciesType == null 
                    ? new long?()
                    : _SpeciesType.idfsBaseReference; 
                OnPropertyChanged(_str_SpeciesType); 
            }
        }
        private BaseReference _SpeciesType;

        
        public BaseReferenceList SpeciesTypeLookup
        {
            get { return _SpeciesTypeLookup; }
        }
        private BaseReferenceList _SpeciesTypeLookup = new BaseReferenceList("rftSpeciesList");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_SpeciesType:
                    return new BvSelectList(SpeciesTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, SpeciesType, _str_idfsSpeciesTypeReference);
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsSpeciesTypeReference)]
        public long? idfsSpeciesTypeReference
        {
            get { return new Func<RootFarmTree, long?>(c => ExprUtils.LongFromString(c.strName))(this); }
            
            set { strName = ExprUtils.StringFromObject(value); OnPropertyChanged(_str_idfsSpeciesTypeReference); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_lOrderingSequence)]
        public long? lOrderingSequence
        {
            get { return new Func<RootFarmTree, long?>(c=>c.idfsPartyType == (long)PartyTypeEnum.Species ? c.idfParentParty : c.idfParty)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strSpeciesName)]
        public string strSpeciesName
        {
            get { return new Func<RootFarmTree, string>(c=>c.idfsPartyType == (long)PartyTypeEnum.Species ? SpeciesType.name : "")(this); }
            
        }
        
          [LocalizedDisplayName(_str_strHerdName)]
        public string strHerdName
        {
            get { return m_strHerdName; }
            set { if (m_strHerdName != value) { m_strHerdName = value; OnPropertyChanged(_str_strHerdName); } }
        }
        private string m_strHerdName;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "RootFarmTree";

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
            var ret = base.Clone() as RootFarmTree;
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
            var ret = base.Clone() as RootFarmTree;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public RootFarmTree CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as RootFarmTree;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfParty; } }
        public string KeyName { get { return "idfParty"; } }
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
        
            var _prev_idfsSpeciesTypeReference_SpeciesType = idfsSpeciesTypeReference;
            base.RejectChanges();
        
            if (_prev_idfsSpeciesTypeReference_SpeciesType != idfsSpeciesTypeReference)
            {
                _SpeciesType = _SpeciesTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsSpeciesTypeReference);
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

      private bool IsRIRPropChanged(string fld, RootFarmTree c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      
        public override string ToString()
        {
            return new Func<RootFarmTree, string>(c => c.strSpeciesName)(this);
        }
        

        public RootFarmTree()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();

        
        private int? m_HACode;
        public int? _HACode { get { return m_HACode; } set { m_HACode = value; } }
        

        private bool m_IsForcedToDelete;
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(RootFarmTree_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(RootFarmTree_PropertyChanged);
        }
        private void RootFarmTree_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as RootFarmTree).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_strName)
                OnPropertyChanged(_str_idfsSpeciesTypeReference);
                  
            if (e.PropertyName == _str_idfParentParty)
                OnPropertyChanged(_str_lOrderingSequence);
                  
            if (e.PropertyName == _str_idfsPartyType)
                OnPropertyChanged(_str_strSpeciesName);
                  
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
            RootFarmTree obj = this;
            
        }
        private void _DeletedExtenders()
        {
            RootFarmTree obj = this;
            
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


        public Dictionary<string, Func<RootFarmTree, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<RootFarmTree, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<RootFarmTree, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<RootFarmTree, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<RootFarmTree, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<RootFarmTree, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~RootFarmTree()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftSpeciesList", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftSpeciesList")
                _getAccessor().LoadLookup_SpeciesType(manager, this);
            
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
        public class RootFarmTreeGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfParty { get; set; }
        
            public string strHerdName { get; set; }
        
            public string strSpeciesName { get; set; }
        
            public int? intTotalAnimalQty { get; set; }
        
            public int? intSickAnimalQty { get; set; }
        
            public int? intDeadAnimalQty { get; set; }
        
            public string strNote { get; set; }
        
            public DateTime? datStartOfSignsDate { get; set; }
        
            public long? idfsPartyType { get; set; }
        
        }
        public partial class RootFarmTreeGridModelList : List<RootFarmTreeGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public RootFarmTreeGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<RootFarmTree>, errMes);
            }
            public RootFarmTreeGridModelList(long key, IEnumerable<RootFarmTree> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<RootFarmTree> items);
            private void LoadGridModelList(long key, IEnumerable<RootFarmTree> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strHerdName,_str_strSpeciesName,_str_intTotalAnimalQty,_str_intSickAnimalQty,_str_intDeadAnimalQty,_str_strNote,_str_datStartOfSignsDate};
                    
                Hiddens = new List<string> {_str_idfParty,_str_idfsPartyType};
                Keys = new List<string> {_str_idfParty};
                Labels = new Dictionary<string, string> {{_str_strHerdName, _str_strHerdName},{_str_strSpeciesName, _str_strSpeciesName},{_str_intTotalAnimalQty, _str_intTotalAnimalQty},{_str_intSickAnimalQty, _str_intSickAnimalQty},{_str_intDeadAnimalQty, _str_intDeadAnimalQty},{_str_strNote, "VetFarmTree.strNote"},{_str_datStartOfSignsDate, _str_datStartOfSignsDate}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<RootFarmTree>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new RootFarmTreeGridModel()
                {
                    ItemKey=c.idfParty,strHerdName=c.strHerdName,strSpeciesName=c.strSpeciesName,intTotalAnimalQty=c.intTotalAnimalQty,intSickAnimalQty=c.intSickAnimalQty,intDeadAnimalQty=c.intDeadAnimalQty,strNote=c.strNote,datStartOfSignsDate=c.datStartOfSignsDate,idfsPartyType=c.idfsPartyType
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
        : DataAccessor<RootFarmTree>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            private delegate void on_action(RootFarmTree obj);
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
            private BaseReference.Accessor SpeciesTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , (Int64?)ident
                        
                    , HACode
                    
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<RootFarmTree> SelectList(DbManagerProxy manager
                , Int64? idfFarm
                , int? HACode
                
                )
            {
                return _SelectList(manager
                    , idfFarm
                    , HACode
                    
                    , delegate(RootFarmTree obj)
                        {
                        }
                    , delegate(RootFarmTree obj)
                        {
                        }
                    );
            }

            
            private List<RootFarmTree> _SelectList(DbManagerProxy manager
                , Int64? idfFarm
                , int? HACode
                
                , on_action loading, on_action loaded
                )
            {
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<RootFarmTree> objs = new List<RootFarmTree>();
                    sets[0] = new MapResultSet(typeof(RootFarmTree), objs);
                    
                    manager
                        .SetSpCommand("spRootFarmTree_SelectDetail"
                            , manager.Parameter("@idfFarm", idfFarm)
                            , manager.Parameter("@HACode", HACode)
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
                        obj.m_CS = m_CS;
                        
                        obj._HACode = HACode;
                        
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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, RootFarmTree obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                obj.strHerdName = new Func<RootFarmTree, string>(c => c.GetHerdName())(obj);
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, RootFarmTree obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private RootFarmTree _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    RootFarmTree obj = RootFarmTree.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    obj._HACode = HACode;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.strName = new Func<RootFarmTree, DbManagerProxy, string>((c,m) => 
                        c.strName != "(new herd)" 
                        ? c.strName 
                        : m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.AnimalGroup, DBNull.Value, DBNull.Value)
                        .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue"))(obj, manager);
                obj.strHerdName = new Func<RootFarmTree, string>(c => c.GetHerdName())(obj);
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

            
            public RootFarmTree CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public RootFarmTree CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public RootFarmTree CreateFarmT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is FarmRootPanel)) 
                    throw new TypeMismatchException("farm", typeof(FarmRootPanel));
                if (pars[1] != null && !(pars[1] is int?)) 
                    throw new TypeMismatchException("hacode", typeof(int?));
                
                return CreateFarm(manager, Parent
                    , (FarmRootPanel)pars[0]
                    , (int?)pars[1]
                    );
            }
            public IObject CreateFarm(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateFarmT(manager, Parent, pars);
            }
            public RootFarmTree CreateFarm(DbManagerProxy manager, IObject Parent
                , FarmRootPanel farm
                , int? hacode
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj._HACode = new Func<RootFarmTree, int?>(c => hacode)(obj);
                obj.idfParty = new Func<RootFarmTree, long>(c => farm.idfFarm)(obj);
                obj.strName = new Func<RootFarmTree, string>(c => farm.strFarmCode)(obj);
                obj.idfsPartyType = (int)PartyTypeEnum.Farm;
                }
                    , obj =>
                {
                }
                );
            }
            
            public RootFarmTree CreateHerdT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is RootFarmTree)) 
                    throw new TypeMismatchException("parent", typeof(RootFarmTree));
                
                return CreateHerd(manager, Parent
                    , (RootFarmTree)pars[0]
                    );
            }
            public IObject CreateHerd(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateHerdT(manager, Parent, pars);
            }
            public RootFarmTree CreateHerd(DbManagerProxy manager, IObject Parent
                , RootFarmTree parent
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj._HACode = new Func<RootFarmTree, int?>(c => parent._HACode)(obj);
                obj.idfParty = (new GetNewIDExtender<RootFarmTree>()).GetScalar(manager, obj);
                obj.idfParentParty = new Func<RootFarmTree, long?>(c => parent.idfParty)(obj);
                obj.idfsPartyType = (int)PartyTypeEnum.Herd;
                obj.strName = new Func<RootFarmTree, string>(c => "(new herd)")(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            public RootFarmTree CreateSpeciesT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != 1) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is RootFarmTree)) 
                    throw new TypeMismatchException("parent", typeof(RootFarmTree));
                
                return CreateSpecies(manager, Parent
                    , (RootFarmTree)pars[0]
                    );
            }
            public IObject CreateSpecies(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return CreateSpeciesT(manager, Parent, pars);
            }
            public RootFarmTree CreateSpecies(DbManagerProxy manager, IObject Parent
                , RootFarmTree parent
                )
            {
                return _CreateNew(manager, Parent
                
                    , null
                    
                    , obj =>
                {
                obj._HACode = new Func<RootFarmTree, int?>(c => parent._HACode)(obj);
                obj.idfParty = (new GetNewIDExtender<RootFarmTree>()).GetScalar(manager, obj);
                obj.idfParentParty = new Func<RootFarmTree, long?>(c => parent.idfParty)(obj);
                obj.idfsPartyType = (int)PartyTypeEnum.Species;
                obj.strName = new Func<RootFarmTree, string>(c => "947220000000")(obj);
                }
                    , obj =>
                {
                }
                );
            }
            
            private void _SetupChildHandlers(RootFarmTree obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(RootFarmTree obj)
            {
                
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    
                        if (e.PropertyName == _str_intDeadAnimalQty)
                        {
                            try
                            {
                            
                TotalQuantityRule(obj);
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intDeadAnimalQty);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_intSickAnimalQty)
                        {
                            try
                            {
                            
                TotalQuantityRule(obj);
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intSickAnimalQty);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                        if (e.PropertyName == _str_intTotalAnimalQty)
                        {
                            try
                            {
                            
                TotalQuantityRule(obj);
            
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_intTotalAnimalQty);
                                    obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                                    obj.UnlockNotifyChanges();
                                }
                            }
                        }
                    
                    };
                
            }
    
            public void LoadLookup_SpeciesType(DbManagerProxy manager, RootFarmTree obj)
            {
                
                obj.SpeciesTypeLookup.Clear();
                
                obj.SpeciesTypeLookup.Add(SpeciesTypeAccessor.CreateNewT(manager, null));
                
                obj.SpeciesTypeLookup.AddRange(SpeciesTypeAccessor.rftSpeciesList_SelectList(manager
                    
                    )
                    .Where(c => (c.intHACode.GetValueOrDefault() & obj._HACode.GetValueOrDefault()) != 0 || c.idfsBaseReference == obj.idfsSpeciesTypeReference)
                        
                    .Where(c => obj.idfsPartyType == (long)PartyTypeEnum.Species)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsSpeciesTypeReference))
                    
                    .ToList());
                
                if (obj.idfsSpeciesTypeReference != null && obj.idfsSpeciesTypeReference != 0)
                {
                    obj.SpeciesType = obj.SpeciesTypeLookup
                        .Where(c => c.idfsBaseReference == obj.idfsSpeciesTypeReference)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftSpeciesList", obj, SpeciesTypeAccessor.GetType(), "rftSpeciesList_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, RootFarmTree obj)
            {
                
                LoadLookup_SpeciesType(manager, obj);
                
            }
    
            [SprocName("spRootFarmTree_Post")]
            protected abstract void _post(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strName")] RootFarmTree obj);
            protected void _postPredicate(DbManagerProxy manager, int Action, 
                [Direction.InputOutput("strName")] RootFarmTree obj)
            {
                
                _post(manager, Action, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    RootFarmTree bo = obj as RootFarmTree;
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as RootFarmTree, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, RootFarmTree obj, bool bChildObject) 
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
                    // posting extenters - end
            
                    if (obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 4, obj);
                    else if (!obj.IsNew && !obj.IsMarkedToDelete && obj.HasChanges)
                        _postPredicate(manager, 16, obj);
                                    
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(RootFarmTree obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, RootFarmTree obj)
            {
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as RootFarmTree, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, RootFarmTree obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                try
                {
                    if (bPostValidation)
                    {
                
                  
                    }

                    if (bChangeValidation)
                    {
                
                TotalQuantityRule(obj);
            
                TotalQuantityRule(obj);
            
                TotalQuantityRule(obj);
            
                    }
                    
                    if (bDeepValidation)
                    {
                
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
           
    
            private void _SetupRequired(RootFarmTree obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(RootFarmTree obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as RootFarmTree) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as RootFarmTree) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "RootFarmTreeDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spRootFarmTree_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spRootFarmTree_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<RootFarmTree, bool>> RequiredByField = new Dictionary<string, Func<RootFarmTree, bool>>();
            public static Dictionary<string, Func<RootFarmTree, bool>> RequiredByProperty = new Dictionary<string, Func<RootFarmTree, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strName, 200);
                Sizes.Add(_str_strNote, 2000);
                GridMeta.Add(new GridMetaItem(
                    _str_idfParty,
                    _str_idfParty, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strHerdName,
                    _str_strHerdName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strSpeciesName,
                    _str_strSpeciesName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intTotalAnimalQty,
                    _str_intTotalAnimalQty, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intSickAnimalQty,
                    _str_intSickAnimalQty, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_intDeadAnimalQty,
                    _str_intDeadAnimalQty, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNote,
                    "VetFarmTree.strNote", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datStartOfSignsDate,
                    _str_datStartOfSignsDate, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfsPartyType,
                    _str_idfsPartyType, null, false, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "CreateFarm",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateFarm(manager, c, pars)),
                        
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
                    "CreateHerd",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateHerd(manager, c, pars)),
                        
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
                    "CreateSpecies",
                    ActionTypes.Create,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateSpecies(manager, c, pars)),
                        
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
                        ActionsPanelType.Group,
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
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
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
                    (manager, c, pars) => ((RootFarmTree)c).MarkToDelete(),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
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
	