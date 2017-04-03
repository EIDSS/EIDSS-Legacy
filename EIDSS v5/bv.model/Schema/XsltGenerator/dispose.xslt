﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />

    <xsl:template name="dispose">
        <xsl:param name="tablename" />
        #region IDisposable Members
        private bool bIsDisposed;
        ~<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                <xsl:for-each select="bv:lookups/bv:lookup">
                    <xsl:variable name="lookupname">
                        <xsl:choose>
                            <xsl:when test="@section"><xsl:value-of select="@section"/></xsl:when>
                            <xsl:otherwise><xsl:value-of select="@table"/></xsl:otherwise>
                        </xsl:choose>
                    </xsl:variable>
                LookupManager.RemoveObject("<xsl:value-of select="$lookupname" />", this);
                </xsl:for-each>
            }
        }
        #endregion
    </xsl:template>
    
</xsl:stylesheet>
