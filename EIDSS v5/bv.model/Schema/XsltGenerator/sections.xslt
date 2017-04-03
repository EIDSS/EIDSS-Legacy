<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />

    <xsl:template name="sections">
        <xsl:param name="langid" />
        <xsl:param name="tablename" />
        <xsl:param name="schema_get" />
        
            <xsl:for-each select="bv:sections/bv:section">
            <xsl:if test="@cache='true'">[InstanceCache(typeof(BvCacheAspect))]</xsl:if>
            public virtual <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />List <xsl:value-of select="@name" />_SelectList(DbManagerProxy manager<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                , <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/>
                </xsl:for-each>
                )
            {
                return SelectLookupList(manager<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                    , <xsl:value-of select="@name"/>
                    </xsl:for-each>
                    )<xsl:for-each select="bv:filters/bv:filter">
                    .Where(c => c.<xsl:value-of select="@target" /> == <xsl:value-of select="@const" />)
                    </xsl:for-each>
                    .To<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />List("<xsl:value-of select="@name" />");
            }
            </xsl:for-each>
            <xsl:if test="count(bv:sections/bv:section) != 0">
            public static string GetLookupTableName(string method)
            {
                switch(method)
                {
            <xsl:for-each select="bv:sections/bv:section">
                    case "<xsl:value-of select="@name" />_SelectList" : return "<xsl:value-of select="@lookupcachename"/>";
            </xsl:for-each>
                }
                return "<xsl:value-of select="$tablename" />";
            }
            </xsl:if>
    </xsl:template>
    
</xsl:stylesheet>
