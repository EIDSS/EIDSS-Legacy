<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />

    <xsl:template name="dispose">
        <xsl:param name="tablename" />
        #region IDisposable Members
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />()
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
                <xsl:for-each select="bv:lookups/bv:lookup">
                  <xsl:if test="@existinglookup and (not(@notaddempty='true') or @addthis='true')">
                if (_empty<xsl:value-of select="@name" /> != null)
                {
                    _empty<xsl:value-of select="@name" />.Dispose();
                    _empty<xsl:value-of select="@name" /> = null;
                }
                  </xsl:if>
                </xsl:for-each>
                this.ClearModelObjEventInvocations();
                <xsl:for-each select="bv:relations/bv:relation[@type!='child']">
                if (_<xsl:value-of select="@name"/> != null)
                    <xsl:value-of select="@name"/>.Dispose();
                </xsl:for-each>
                <xsl:for-each select="bv:relations/bv:relation[@type='child']">
                if (!bIsClone)
                {
                    <xsl:value-of select="@name"/>.ForEach(c => c.Dispose());
                }
                <xsl:value-of select="@name"/>.ClearModelListEventInvocations();
                </xsl:for-each>
                
                if (bNeedLookupRemove)
                {
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
            GC.SuppressFinalize(this);
        }
        #endregion
    </xsl:template>
    
</xsl:stylesheet>
