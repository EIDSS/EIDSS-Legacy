<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />

    <xsl:template name="readonly">
        <xsl:param name="tablename" />
        <xsl:for-each select="bv:readonly/bv:fields[@name!='*']">
        private static string[] readonly_names<xsl:value-of select="position()"/> = "<xsl:value-of select="translate(@name, ' ', '')"/>".Split(new char[] { ',' });
        </xsl:for-each>
        private bool _isReadOnly(string name)
        {
            <xsl:for-each select="bv:readonly/bv:fields[@name!='*']">
            if (readonly_names<xsl:value-of select="position()"/>.Where(c => c == name).Count() > 0)
                return <xsl:if test="not(@ignoreReadOnly='true')">ReadOnly ||</xsl:if> new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="@predicate"/>)(this);
            </xsl:for-each>
            <xsl:choose>
                <xsl:when test="bv:readonly/bv:fields[@name='*']">
            return <xsl:if test="not(@ignoreReadOnly='true')">ReadOnly ||</xsl:if> new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="bv:readonly/bv:fields[@name='*']/@predicate"/>)(this);
                </xsl:when>
                <xsl:otherwise>
            return ReadOnly;
                </xsl:otherwise>
            </xsl:choose>
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        <xsl:for-each select="bv:relations/bv:relation">
            <xsl:choose>
                <xsl:when test="@type='child'">
                foreach(var o in _<xsl:value-of select="@name" />)
                    o.ReadOnly = value;
                </xsl:when>
                <xsl:when test="@type='link'">
                if (_<xsl:value-of select="@name" /> != null)
                    _<xsl:value-of select="@name" />.ReadOnly = value;
                </xsl:when>
                <xsl:when test="@type='sibling'">
                if (_<xsl:value-of select="@name" /> != null)
                    _<xsl:value-of select="@name" />.ReadOnly = value;
                </xsl:when>
            </xsl:choose>            
        </xsl:for-each>
        <!--
                IObject i = null;            
        <xsl:for-each select="bv:fields/bv:storage[@type!='bool' and @type!='long' and @type!='long?' and @type!='string' and @type!='double']">
                i = <xsl:value-of select="@name" /> as IObject;
                if (i != null)
                    i.ReadOnly = value;
        </xsl:for-each>
        -->
            }
        }

<!--
        public bool IsActionEnabled(string name)
        {
        <xsl:for-each select="bv:actions/bv:action[@predicate]">
            if (name == "<xsl:value-of select="@name"/>")
                return new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="@predicate"/>)(this);
            </xsl:for-each>
            return true;
        }
-->
    </xsl:template>
    
</xsl:stylesheet>
