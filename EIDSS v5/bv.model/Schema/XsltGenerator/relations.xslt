<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:bv="urn:schemas-bv:objectmodel"
	xmlns:util="urn:util">

    <xsl:import href="globals.xslt" />

    <xsl:template name="relation-fields">
        <xsl:param name="tablename" />
        <xsl:param name="columns" />
        <xsl:param name="namespace" />
      
        <xsl:for-each select="bv:relations/bv:relation">
        [Relation(typeof(<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />), <xsl:choose><xsl:when test="@target != '' and not(contains(@target,'?'))"><xsl:value-of select="$namespace" />.<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />._str_<xsl:value-of select="@target" /></xsl:when><xsl:otherwise>""</xsl:otherwise></xsl:choose>, _str_<xsl:value-of select="@source" />)]<xsl:choose>
                <xsl:when test="@type='child'">
        public EditableList&lt;<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />&gt; <xsl:value-of select="@name" />
        {
            get 
            {   <xsl:if test="not(@lazy='false')">
                if (!_<xsl:value-of select="@name" />Loaded)
                {
                    _<xsl:value-of select="@name" />Loaded = true;
                    _getAccessor()._Load<xsl:value-of select="@name" />(this);
                    _<xsl:value-of select="@name" />.ForEach(c => { c.Parent = this; });
                }</xsl:if>
                return _<xsl:value-of select="@name" />; 
            }
            set 
            {
                _<xsl:value-of select="@name" /> = value;
            }
        }
        protected EditableList&lt;<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />&gt; _<xsl:value-of select="@name" /> = new EditableList&lt;<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />&gt;();
                    <xsl:if test="not(@lazy='false')">
        private bool _<xsl:value-of select="@name" />Loaded = false;
                    </xsl:if>
                </xsl:when>
                <xsl:when test="@type='link'">
        public <xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />
        {
            get 
            {   <xsl:if test="not(@lazy='false')">
                if (!_<xsl:value-of select="@name" />Loaded)
                {
                    _<xsl:value-of select="@name" />Loaded = true;
                    _getAccessor()._Load<xsl:value-of select="@name" />(this);
                    if (_<xsl:value-of select="@name" /> != null) 
                        _<xsl:value-of select="@name" />.Parent = this;
                }</xsl:if>
                return _<xsl:value-of select="@name" />; 
            }
            set 
            {   <xsl:if test="not(@lazy='false')">
                if (!_<xsl:value-of select="@name" />Loaded) { _<xsl:value-of select="@name" />Loaded = true; }</xsl:if>
                _<xsl:value-of select="@name" /> = value;
                if (_<xsl:value-of select="@name" /> != null) 
                { 
                    _<xsl:value-of select="@name" />.m_ObjectName = _str_<xsl:value-of select="@name" />;
                    _<xsl:value-of select="@name" />.Parent = this;
                }
                <xsl:variable name="keys" select="util:ExpandXml('source,target', string(@source), string(@target))" />
                <xsl:variable name="varname" select="@name" />
                <xsl:for-each select="$keys/keys/key">
                    <xsl:variable name="parname" select="@source" />
                    <xsl:value-of select="@source" /> = _<xsl:value-of select="$varname" /> == null 
                        ? new <xsl:choose>
                            <xsl:when test="$columns/column[@name=$parname]/@type"><xsl:value-of select="$columns/column[@name=$parname]/@type" />()</xsl:when>
                            <xsl:otherwise>long?()</xsl:otherwise>
                        </xsl:choose>
                        : _<xsl:value-of select="$varname" />.<xsl:value-of select="@target" />;
                </xsl:for-each>
            }
        }
        protected <xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" /> _<xsl:value-of select="@name" />;
                    <xsl:if test="not(@lazy='false')">
        private bool _<xsl:value-of select="@name" />Loaded = false;
                    </xsl:if>
                </xsl:when>
                <xsl:when test="@type='sibling'">
        public <xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />
        {
            get 
            {   <xsl:if test="not(@lazy='false')">
                if (!_<xsl:value-of select="@name" />Loaded)
                {
                    _<xsl:value-of select="@name" />Loaded = true;
                    _getAccessor()._Load<xsl:value-of select="@name" />(this);
                    if (_<xsl:value-of select="@name" /> != null) 
                        _<xsl:value-of select="@name" />.Parent = this;
                }</xsl:if>
                return _<xsl:value-of select="@name" />; 
            }
            set 
            {   <xsl:if test="not(@lazy='false')">
                if (!_<xsl:value-of select="@name" />Loaded) { _<xsl:value-of select="@name" />Loaded = true; }</xsl:if>
                _<xsl:value-of select="@name" /> = value; 
                if (_<xsl:value-of select="@name" /> != null) 
                { 
                    _<xsl:value-of select="@name" />.m_ObjectName = _str_<xsl:value-of select="@name" />;
                    _<xsl:value-of select="@name" />.Parent = this;
                }
            }
        }
        protected <xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" /> _<xsl:value-of select="@name" />;
                    <xsl:if test="not(@lazy='false')">
        private bool _<xsl:value-of select="@name" />Loaded = false;
                    </xsl:if>
                </xsl:when>
                <xsl:otherwise>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:for-each>
    </xsl:template>
    
</xsl:stylesheet>
