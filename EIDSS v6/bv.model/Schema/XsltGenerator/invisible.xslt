<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />

    <xsl:template name="invisible">
        <xsl:param name="tablename" />
        <xsl:for-each select="bv:invisible/bv:fields[@name!='*']">
        private static string[] invisible_names<xsl:value-of select="position()"/> = "<xsl:value-of select="translate(@name, ' ', '')"/>".Split(new char[] { ',' });
        </xsl:for-each>
        private bool _isInvisible(string name)
        {
            <xsl:for-each select="bv:invisible/bv:fields[@name!='*']">
            if (invisible_names<xsl:value-of select="position()"/>.Where(c => c == name).Count() > 0)
                return new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="@predicate"/>)(this);
            </xsl:for-each>
            <xsl:choose>
                <xsl:when test="bv:invisible/bv:fields[@name='*']">
            return new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="bv:invisible/bv:fields[@name='*']/@predicate"/>)(this);
                </xsl:when>
                <xsl:otherwise>
            return false;
                </xsl:otherwise>
            </xsl:choose>
        }

    </xsl:template>
    
</xsl:stylesheet>
