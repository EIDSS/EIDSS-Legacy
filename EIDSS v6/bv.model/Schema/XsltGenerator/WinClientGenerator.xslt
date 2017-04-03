<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:bv="urn:schemas-bv:clientmodel"
    >

  <xsl:strip-space elements="*" />

  <xsl:output method="text"/>
  <xsl:param name="param_namespace" select="''" />

  <xsl:variable name="namespace">
    <xsl:choose>
      <xsl:when test="$param_namespace!=''">
        <xsl:value-of select="$param_namespace" />
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="'bv.models.clients'" />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:variable>

  <xsl:template match="/">
    <xsl:apply-templates />
  </xsl:template>

  <xsl:template match="bv:client">
    using System;
    using System.Text;
    using System.IO;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Linq;
    using bv.winclient.BasePanel;
    using eidss.model.Schema;

    namespace <xsl:value-of select="$namespace" />
    {
    <xsl:for-each select="bv:panels/bv:panel">
      <xsl:variable name="classname">
        <xsl:choose>
          <xsl:when test="@classname">
            <xsl:value-of select="@classname"/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="concat(@type, '_', @object)"/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:variable>
      public partial class <xsl:value-of select="$classname"/> : <xsl:value-of select="@type"/>&lt;<xsl:value-of select="@object"/>&gt;
      {
      <xsl:if test="@type='BaseDetailPanel'">
        public <xsl:value-of select="$classname"/>() : base()
        {<xsl:if test="@relatedlists">
          m_RelatedLists = ("<xsl:value-of select="translate(@relatedlists, ' ', '')"/>").Split(',');
        </xsl:if>
        <xsl:if test="not(@relatedlists)">
          m_RelatedLists = new string[]{"<xsl:value-of select="@object"/>ListItem"};
        </xsl:if>
        <xsl:if test="@formid">
          FormID = "<xsl:value-of select="@formid"/>";
        </xsl:if>}
      </xsl:if>
      <xsl:if test="@type='BaseListPanel'">
        public <xsl:value-of select="$classname"/>() : base()
        {<xsl:if test="@formid">
          FormID = "<xsl:value-of select="@formid"/>";
        </xsl:if>}
      </xsl:if>



      <xsl:if test="@is_singletone">
        public override bool IsSingleTone {get { return <xsl:value-of select="@is_singletone"/>; }}
      </xsl:if>
      
      }
    </xsl:for-each>
    }
  </xsl:template>

</xsl:stylesheet>
