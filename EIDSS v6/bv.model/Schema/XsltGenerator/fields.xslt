<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:bv="urn:schemas-bv:objectmodel"
	xmlns:util="urn:util">

    <xsl:import href="globals.xslt" />
    <xsl:import href="utils.xslt" />

    <xsl:template name="sp-fields">
        <xsl:param name="tablename" />
        <xsl:param name="columns" />
        <xsl:param name="tablekeys" />
        <xsl:param name="table" />
        <xsl:for-each select="$columns/column">
            <xsl:variable name="columnname" select="@name" />          
            <xsl:choose>
                <xsl:when test="msxsl:node-set($tablekeys)/keys/key[@name=$columnname]/@name">
        [MapField(_str_<xsl:value-of select="@name"/>), NonUpdatable, PrimaryKey]
        public abstract <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/> { get; set; }
                </xsl:when>
                <xsl:otherwise>
        [LocalizedDisplayName(<xsl:choose><xsl:when test="msxsl:node-set($table)/bv:labels/bv:item[@name=$columnname]">"<xsl:value-of select="msxsl:node-set($table)/bv:labels/bv:item[@name=$columnname]/@labelId" />"</xsl:when><xsl:otherwise>_str_<xsl:value-of select="@name" /></xsl:otherwise></xsl:choose>)]
        [MapField(_str_<xsl:value-of select="@name"/>)]
        public abstract <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/> { get; set; }
        protected <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/>_Original { get { return ((EditableValue&lt;<xsl:value-of select="@type"/>&gt;)((dynamic)this)._<xsl:call-template name="first-to-lower"><xsl:with-param name="name" select="@name"></xsl:with-param></xsl:call-template>).OriginalValue; } }
        protected <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/>_Previous { get { return ((EditableValue&lt;<xsl:value-of select="@type"/>&gt;)((dynamic)this)._<xsl:call-template name="first-to-lower"><xsl:with-param name="name" select="@name"></xsl:with-param></xsl:call-template>).PreviousValue; } }
                </xsl:otherwise>
            </xsl:choose>
        </xsl:for-each>
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, object&gt; _get_func;
            internal Action&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, string&gt; _set_func;
            internal Action&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, CompareModel&gt; _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        <xsl:for-each select="$columns/column">
        internal const string _str_<xsl:value-of select="@name"/> = "<xsl:value-of select="@name"/>";</xsl:for-each>
        <xsl:for-each select="bv:fields/*">
        internal const string _str_<xsl:value-of select="@name"/> = "<xsl:value-of select="@name"/>";</xsl:for-each>
        <xsl:for-each select="bv:lookups/*">
        internal const string _str_<xsl:value-of select="@name"/> = "<xsl:value-of select="@name"/>";</xsl:for-each>
        <xsl:for-each select="bv:relations/*">
        internal const string _str_<xsl:value-of select="@name"/> = "<xsl:value-of select="@name"/>";</xsl:for-each>
        private static readonly field_info[] _field_infos =
        {
        <xsl:for-each select="$columns/column">
            <xsl:variable name="columnname" select="@name" />          
            new field_info {
              _name = _str_<xsl:value-of select="@name"/>, _formname = _str_<xsl:value-of select="@name"/>, _type = "<xsl:value-of select="@type"/>",
              _get_func = o => o.<xsl:value-of select="@name"/>,
              _set_func = (o, val) => { <xsl:choose>
                <xsl:when test="@type='Double' or @type='double'">var newval = ParsingHelper.ParseDouble(val)</xsl:when>
                <xsl:when test="@type='Double?' or @type='double?'">var newval = ParsingHelper.ParseDoubleNullable(val)</xsl:when>
                <xsl:when test="@type='Int64' or @type='long'">var newval = ParsingHelper.ParseInt64(val)</xsl:when>
                <xsl:when test="@type='Int64?' or @type='long?'">var newval = ParsingHelper.ParseInt64Nullable(val)</xsl:when>
                <xsl:when test="@type='Int32' or @type='int'">var newval = ParsingHelper.ParseInt32(val)</xsl:when>
                <xsl:when test="@type='Int32?' or @type='int?'">var newval = ParsingHelper.ParseInt32Nullable(val)</xsl:when>
                <xsl:when test="@type='Int16' or @type='short'">var newval = ParsingHelper.ParseInt16(val)</xsl:when>
                <xsl:when test="@type='Int16?' or @type='short?'">var newval = ParsingHelper.ParseInt16Nullable(val)</xsl:when>
                <xsl:when test="@type='Boolean' or @type='bool'">var newval = ParsingHelper.ParseBoolean(val)</xsl:when>
                <xsl:when test="@type='Boolean?' or @type='bool?'">var newval = ParsingHelper.ParseBooleanNullable(val)</xsl:when>
                <xsl:when test="@type='String' or @type='string'">var newval = ParsingHelper.ParseString(val)</xsl:when>
                <xsl:when test="@type='DateTime'">var newval = ParsingHelper.ParseDateTime(val)</xsl:when>
                <xsl:when test="@type='DateTime?'">var newval = ParsingHelper.ParseDateTimeNullable(val)</xsl:when>
                <xsl:otherwise>var newval = o.<xsl:value-of select="@name"/></xsl:otherwise>
            </xsl:choose>; <xsl:if test="msxsl:node-set($table)/bv:lookups/bv:lookup[@source=$columnname]/@name">
                if (o.<xsl:value-of select="@name"/> != newval) 
                  o.<xsl:value-of select="msxsl:node-set($table)/bv:lookups/bv:lookup[@source=$columnname]/@name"/> = o.<xsl:value-of select="msxsl:node-set($table)/bv:lookups/bv:lookup[@source=$columnname]/@name"/>Lookup.FirstOrDefault(c => c.<xsl:value-of select="msxsl:node-set($table)/bv:lookups/bv:lookup[@source=$columnname]/@target"/> == newval);
                </xsl:if>if (o.<xsl:value-of select="@name"/> != newval) o.<xsl:value-of select="@name"/> = newval; },
              _compare_func = (o, c, m) => {
                if (o.<xsl:value-of select="@name" /> != c.<xsl:value-of select="@name" /> || o.IsRIRPropChanged(_str_<xsl:value-of select="@name" />, c)) 
                  m.Add(_str_<xsl:value-of select="@name" />, o.ObjectIdent + _str_<xsl:value-of select="@name" />, o.ObjectIdent2 + _str_<xsl:value-of select="@name" />, o.ObjectIdent3 + _str_<xsl:value-of select="@name" />, "<xsl:value-of select="@type" />", 
                    <xsl:choose>
                        <xsl:when test="@type='Double?' or @type='double?'">o.<xsl:value-of select="@name" /> == null ? "" : o.<xsl:value-of select="@name" />.Value.ToString(new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator = "" }),</xsl:when>
                        <xsl:otherwise>o.<xsl:value-of select="@name" /> == null ? "" : o.<xsl:value-of select="@name" />.ToString(),</xsl:otherwise>
                    </xsl:choose>                  
                  o.IsReadOnly(_str_<xsl:value-of select="@name" />), o.IsInvisible(_str_<xsl:value-of select="@name" />), o.IsRequired(_str_<xsl:value-of select="@name" />)); 
                  }
              }, 
        </xsl:for-each>
        <xsl:for-each select="bv:fields/bv:storage">
            new field_info {
              _name = _str_<xsl:value-of select="@name"/>, _formname = _str_<xsl:value-of select="@name"/>, _type = "<xsl:value-of select="@type"/>",
              _get_func = o => o.<xsl:value-of select="@name"/>,
              _set_func = (o, val) => { <xsl:choose>
                <xsl:when test="@type='Double' or @type='double'">var newval = ParsingHelper.ParseDouble(val)</xsl:when>
                <xsl:when test="@type='Double?' or @type='double?'">var newval = ParsingHelper.ParseDoubleNullable(val)</xsl:when>
                <xsl:when test="@type='Int64' or @type='long'">var newval = ParsingHelper.ParseInt64(val)</xsl:when>
                <xsl:when test="@type='Int64?' or @type='long?'">var newval = ParsingHelper.ParseInt64Nullable(val)</xsl:when>
                <xsl:when test="@type='Int32' or @type='int'">var newval = ParsingHelper.ParseInt32(val)</xsl:when>
                <xsl:when test="@type='Int32?' or @type='int?'">var newval = ParsingHelper.ParseInt32Nullable(val)</xsl:when>
                <xsl:when test="@type='Int16' or @type='short'">var newval = ParsingHelper.ParseInt16(val)</xsl:when>
                <xsl:when test="@type='Int16?' or @type='short?'">var newval = ParsingHelper.ParseInt16Nullable(val)</xsl:when>
                <xsl:when test="@type='Boolean' or @type='bool'">var newval = ParsingHelper.ParseBoolean(val)</xsl:when>
                <xsl:when test="@type='Boolean?' or @type='bool?'">var newval = ParsingHelper.ParseBooleanNullable(val)</xsl:when>
                <xsl:when test="@type='String' or @type='string'">var newval = ParsingHelper.ParseString(val)</xsl:when>
                <xsl:when test="@type='DateTime'">var newval = ParsingHelper.ParseDateTime(val)</xsl:when>
                <xsl:when test="@type='DateTime?'">var newval = ParsingHelper.ParseDateTimeNullable(val)</xsl:when>
                <xsl:otherwise>var newval = o.<xsl:value-of select="@name"/></xsl:otherwise>
            </xsl:choose>; if (o.<xsl:value-of select="@name"/> != newval) o.<xsl:value-of select="@name"/> = newval; },
              _compare_func = (o, c, m) => {
              <xsl:if test="@type='Double' or @type='double' or 
                            @type='Double?' or @type='double?' or 
                            @type='Int64' or @type='long' or 
                            @type='Int64?' or @type='long?' or 
                            @type='Int32' or @type='int' or 
                            @type='Int32?' or @type='int?' or 
                            @type='Int16' or @type='short' or 
                            @type='Int16?' or @type='short?' or 
                            @type='Boolean' or @type='bool' or 
                            @type='Boolean?' or @type='bool?' or 
                            @type='String' or @type='string' or 
                            @type='DateTime' or @type='DateTime?'">
                if (o.<xsl:value-of select="@name" /> != c.<xsl:value-of select="@name" /> || o.IsRIRPropChanged(_str_<xsl:value-of select="@name" />, c)) {
                  m.Add(_str_<xsl:value-of select="@name" />, o.ObjectIdent + _str_<xsl:value-of select="@name" />, o.ObjectIdent2 + _str_<xsl:value-of select="@name" />, o.ObjectIdent3 + _str_<xsl:value-of select="@name" />,  "<xsl:value-of select="@type" />", 
                    <xsl:choose>
                        <xsl:when test="@type='Double?' or @type='double?'">o.<xsl:value-of select="@name" /> == null ? "" : o.<xsl:value-of select="@name" />.Value.ToString(new System.Globalization.NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator = "" }),</xsl:when>
                        <xsl:otherwise>o.<xsl:value-of select="@name" /> == null ? "" : o.<xsl:value-of select="@name" />.ToString(),</xsl:otherwise>
                    </xsl:choose>                  
                    o.IsReadOnly(_str_<xsl:value-of select="@name" />), o.IsInvisible(_str_<xsl:value-of select="@name" />), o.IsRequired(_str_<xsl:value-of select="@name" />));
                  }
                </xsl:if> }
              }, 
        </xsl:for-each>
        <xsl:for-each select="bv:fields/bv:calculated">
            new field_info {
              _name = _str_<xsl:value-of select="@name"/>, _formname = _str_<xsl:value-of select="@name"/>, _type = "<xsl:value-of select="@type"/>",
              _get_func = o => o.<xsl:value-of select="@name"/>,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => { 
              <xsl:if test="@type='Double' or @type='double' or 
                            @type='Double?' or @type='double?' or 
                            @type='Int64' or @type='long' or 
                            @type='Int64?' or @type='long?' or 
                            @type='Int32' or @type='int' or 
                            @type='Int32?' or @type='int?' or 
                            @type='Int16' or @type='short' or 
                            @type='Int16?' or @type='short?' or 
                            @type='Boolean' or @type='bool' or 
                            @type='Boolean?' or @type='bool?' or 
                            @type='String' or @type='string' or 
                            @type='DateTime' or @type='DateTime?'">
                if (o.<xsl:value-of select="@name" /> != c.<xsl:value-of select="@name" /> || o.IsRIRPropChanged(_str_<xsl:value-of select="@name" />, c)) {
                  m.Add(_str_<xsl:value-of select="@name" />, o.ObjectIdent + _str_<xsl:value-of select="@name" />, o.ObjectIdent2 + _str_<xsl:value-of select="@name" />, o.ObjectIdent3 + _str_<xsl:value-of select="@name" />, "<xsl:value-of select="@type" />", o.<xsl:value-of select="@name" /> == null ? "" : o.<xsl:value-of select="@name" />.ToString(), o.IsReadOnly(_str_<xsl:value-of select="@name" />), o.IsInvisible(_str_<xsl:value-of select="@name" />), o.IsRequired(_str_<xsl:value-of select="@name" />));
                  }
                </xsl:if>
                <xsl:if test="@forList='true'">
                if (o.<xsl:value-of select="@name" />.Count != c.<xsl:value-of select="@name" />.Count || o.IsReadOnly(_str_<xsl:value-of select="@name" />) != c.IsReadOnly(_str_<xsl:value-of select="@name" />) || o.IsInvisible(_str_<xsl:value-of select="@name" />) != c.IsInvisible(_str_<xsl:value-of select="@name" />) || o.IsRequired(_str_<xsl:value-of select="@name" />) != c._isRequired(o.m_isRequired, _str_<xsl:value-of select="@name" />)) {
                  m.Add(_str_<xsl:value-of select="@name" />, o.ObjectIdent + _str_<xsl:value-of select="@name" />, o.ObjectIdent2 + _str_<xsl:value-of select="@name" />, o.ObjectIdent3 + _str_<xsl:value-of select="@name" />, "Child", "", o.IsReadOnly(_str_<xsl:value-of select="@name" />), o.IsInvisible(_str_<xsl:value-of select="@name" />), o.IsRequired(_str_<xsl:value-of select="@name" />)); 
                  }
                </xsl:if>
                }
              }, 
        </xsl:for-each>
        <xsl:for-each select="bv:lookups/bv:lookup[not(@hintonly)]">
            new field_info {
              _name = _str_<xsl:value-of select="@name"/>, _formname = _str_<xsl:value-of select="@name"/>, _type = "Lookup",
              _get_func = o => { if (o.<xsl:value-of select="@name"/> == null) return null; return o.<xsl:value-of select="@name"/>.<xsl:value-of select="@target" />; },
              _set_func = (o, val) => { o.<xsl:value-of select="@name"/> = o.<xsl:value-of select="@name" />Lookup.Where(c => c.<xsl:value-of select="@target" />.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.<xsl:value-of select="@source" /> != c.<xsl:value-of select="@source" /> || o.IsRIRPropChanged(_str_<xsl:value-of select="@name" />, c)) {
                  m.Add(_str_<xsl:value-of select="@name" />, o.ObjectIdent + _str_<xsl:value-of select="@name" />, o.ObjectIdent2 + _str_<xsl:value-of select="@name" />, o.ObjectIdent3 + _str_<xsl:value-of select="@name" />, "Lookup", o.<xsl:value-of select="@source" /> == null ? "" : o.<xsl:value-of select="@source" />.ToString(), o.IsReadOnly(_str_<xsl:value-of select="@name" />), o.IsInvisible(_str_<xsl:value-of select="@name" />), o.IsRequired(_str_<xsl:value-of select="@name" />)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_<xsl:value-of select="@name"/> + "Lookup", _formname = _str_<xsl:value-of select="@name"/> + "Lookup", _type = "LookupContent",
              _get_func = o => o.<xsl:value-of select="@name" />Lookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        </xsl:for-each>
        <xsl:for-each select="bv:lookups/bv:lookup[@hintonly='true']">
            new field_info {
              _name = _str_<xsl:value-of select="@name"/>, _formname = _str_<xsl:value-of select="@name"/> + "_input", _type = "Lookup",
              _get_func = o => o.<xsl:value-of select="@source"/>,
              _set_func = (o, val) => { o.<xsl:value-of select="@source" /> = val; },
              _compare_func = (o, c, m) => {
                if (o.<xsl:value-of select="@source" /> != c.<xsl:value-of select="@source" /> || o.IsRIRPropChanged(_str_<xsl:value-of select="@name" />, c)) {
                  m.Add(_str_<xsl:value-of select="@name" />, o.ObjectIdent + _str_<xsl:value-of select="@name" />, o.ObjectIdent2 + _str_<xsl:value-of select="@name" />, o.ObjectIdent3 + _str_<xsl:value-of select="@name" />, "Lookup", o.<xsl:value-of select="@source" /> == null ? "" : o.<xsl:value-of select="@source" />.ToString(), o.IsReadOnly(_str_<xsl:value-of select="@name" />), o.IsInvisible(_str_<xsl:value-of select="@name" />), o.IsRequired(_str_<xsl:value-of select="@name" />)); 
                  }
                }
              },
        </xsl:for-each>
        <xsl:for-each select="bv:relations/bv:relation[@type='child']">
            new field_info {
              _name = _str_<xsl:value-of select="@name"/>, _formname = _str_<xsl:value-of select="@name"/>, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.<xsl:value-of select="@name" />.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.<xsl:value-of select="@name" />.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.<xsl:value-of select="@name" />.Count != c.<xsl:value-of select="@name" />.Count || o.IsReadOnly(_str_<xsl:value-of select="@name" />) != c.IsReadOnly(_str_<xsl:value-of select="@name" />) || o.IsInvisible(_str_<xsl:value-of select="@name" />) != c.IsInvisible(_str_<xsl:value-of select="@name" />) || o.IsRequired(_str_<xsl:value-of select="@name" />) != c._isRequired(o.m_isRequired, _str_<xsl:value-of select="@name" />)) {
                  m.Add(_str_<xsl:value-of select="@name" />, o.ObjectIdent + _str_<xsl:value-of select="@name" />, o.ObjectIdent2 + _str_<xsl:value-of select="@name" />, o.ObjectIdent3 + _str_<xsl:value-of select="@name" />, "Child", o.<xsl:value-of select="@source" /> == null ? "" : o.<xsl:value-of select="@source" />.ToString(), o.IsReadOnly(_str_<xsl:value-of select="@name" />), o.IsInvisible(_str_<xsl:value-of select="@name" />), o.IsRequired(_str_<xsl:value-of select="@name" />)); 
                  }
                }
              }, 
        </xsl:for-each>
        <xsl:for-each select="bv:relations/bv:relation[@type!='child']">
            new field_info {
              _name = _str_<xsl:value-of select="@name"/>, _formname = _str_<xsl:value-of select="@name"/>, _type = "Relation",
              _get_func = o => null,
              _set_func = (o, val) => {},
              _compare_func = (o, c, m) => {
                if (o.<xsl:value-of select="@name" /> != null) o.<xsl:value-of select="@name" />._compare(c.<xsl:value-of select="@name" />, m); }
              }, 
        </xsl:for-each>
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
            <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj = (<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)o;
            foreach (var i in _field_infos)
                if (i != null &amp;&amp; i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    </xsl:template>

    <xsl:template name="cust-fields">
        <xsl:param name="tablename" />
        <xsl:param name="table" />
        <!--xsl:for-each select="bv:fields/bv:parent">
        [XmlIgnore]
        public <xsl:value-of select="@type" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />
        {
            get { return m_<xsl:value-of select="@name" />; }
            set { m_<xsl:value-of select="@name" /> = value; OnPropertyChanged(_str_<xsl:value-of select="@name" />); }
        }
        private <xsl:value-of select="@type" /><xsl:text>&#32;m_</xsl:text><xsl:value-of select="@name" />;
        </xsl:for-each-->
        <xsl:for-each select="bv:fields/bv:calculated">
            <xsl:variable name="columnname" select="@name" />
          [XmlIgnore]
          [LocalizedDisplayName(<xsl:choose><xsl:when test="msxsl:node-set($table)/bv:labels/bv:item[@name=$columnname]">"<xsl:value-of select="msxsl:node-set($table)/bv:labels/bv:item[@name=$columnname]/@labelId" />"</xsl:when><xsl:otherwise>_str_<xsl:value-of select="@name" /></xsl:otherwise></xsl:choose>)]
        public <xsl:value-of select="@type" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />
        {
            get { return new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, <xsl:value-of select="@type" />&gt;(<xsl:value-of select="@lambda" />)(this); }
            <xsl:if test="@setter">
            set { <xsl:value-of select="@setter" />; OnPropertyChanged(_str_<xsl:value-of select="@name" />); }
            </xsl:if>
        }
        </xsl:for-each>
        <xsl:for-each select="bv:fields/bv:storage">
            <xsl:variable name="columnname" select="@name" />
          [LocalizedDisplayName(<xsl:choose><xsl:when test="msxsl:node-set($table)/bv:labels/bv:item[@name=$columnname]">"<xsl:value-of select="msxsl:node-set($table)/bv:labels/bv:item[@name=$columnname]/@labelId" />"</xsl:when><xsl:otherwise>_str_<xsl:value-of select="@name" /></xsl:otherwise></xsl:choose>)]
        public <xsl:value-of select="@type" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />
        {
            get { return m_<xsl:value-of select="@name" />; }
            set { if (m_<xsl:value-of select="@name" /> != value) { m_<xsl:value-of select="@name" /> = value; OnPropertyChanged(_str_<xsl:value-of select="@name" />); } }
        }
        private <xsl:value-of select="@type" /><xsl:text>&#32;m_</xsl:text><xsl:value-of select="@name" />;
        </xsl:for-each>
    </xsl:template>
    
</xsl:stylesheet>
