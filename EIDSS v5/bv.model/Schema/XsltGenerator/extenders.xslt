<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />

    <xsl:template name="generate-extender">
        <xsl:param name="tablename" />
        <xsl:param name="hacodable" />
        <xsl:choose>
            <xsl:when test="name()='scalar_extender'">
                obj.<xsl:value-of select="@target"/> = (new <xsl:value-of select="@class"/>&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;()).GetScalar(manager, obj);</xsl:when>
            <xsl:when test="name()='create_extender'">
                obj.<xsl:value-of select="@target"/> = (new <xsl:value-of select="@class"/>&lt;<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />.Accessor, <xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />&gt;()).Create(manager, obj
                <xsl:choose>
                    <xsl:when test="$hacodable='true'">
                        , obj._HACode);
                    </xsl:when>
                    <xsl:otherwise>
                        , null);
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:when>
            <xsl:when test="name()='add_extender'">
                obj.<xsl:value-of select="@target"/>.Add(new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, <xsl:value-of select="@type" />&gt;(<xsl:value-of select="@lambda" />)(obj));</xsl:when>
            <xsl:when test="name()='insert_extender'">
                obj.<xsl:value-of select="@target"/>.Insert(<xsl:value-of select="@index" />, new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, <xsl:value-of select="@type" />&gt;(<xsl:value-of select="@lambda" />)(obj));</xsl:when>
            <xsl:when test="name()='select_extender'">
                obj.<xsl:value-of select="@target"/> = (new <xsl:value-of select="@class"/>&lt;<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />&gt;()).Select(obj.<xsl:value-of select="@source" />, <xsl:value-of select="@lambda" />);</xsl:when>
            <xsl:when test="name()='copy_extender'">
                obj.<xsl:value-of select="@target"/> = obj.<xsl:value-of select="@source"/>;</xsl:when>
            <xsl:when test="name()='value_extender'">
                obj.<xsl:value-of select="@target"/> = <xsl:value-of select="@value"/>;</xsl:when>
            <xsl:when test="name()='lambda_extender'">
                obj.<xsl:value-of select="@target"/> = new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, <xsl:value-of select="@type" />&gt;(<xsl:value-of select="@lambda" />)(obj);</xsl:when>
            <xsl:when test="name()='lambda_list_extender'">
                obj.<xsl:value-of select="@list"/>.ForEach(t => { t.<xsl:value-of select="@target"/> = new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, <xsl:value-of select="@type" />&gt;(<xsl:value-of select="@lambda" />)(obj); } );</xsl:when>
            <xsl:when test="name()='db_lambda_extender'">
                obj.<xsl:value-of select="@target"/> = new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, DbManagerProxy, <xsl:value-of select="@type" />&gt;(<xsl:value-of select="@lambda" />)(obj, manager);</xsl:when>
            <xsl:when test="name()='custom_extender'"><xsl:value-of select="bv:text"/><xsl:if test="@method"><xsl:value-of select="@method"/>(obj);</xsl:if></xsl:when>
        </xsl:choose>
    </xsl:template>

</xsl:stylesheet>
