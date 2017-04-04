<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:wix="http://schemas.microsoft.com/wix/2006/wi">

  <xsl:output method="xml" indent="yes" />

  <xsl:strip-space elements="*" />
  <xsl:preserve-space elements="*"/>

  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()"/>
    </xsl:copy>
  </xsl:template>
  
  <xsl:variable name="packages.config">
    <xsl:value-of select="//wix:Component[wix:File/@Source = '$(var.OpenAPIPath)\packages.config']/@Id" />
  </xsl:variable>
  <xsl:variable name="web.config">
    <xsl:value-of select="//wix:Component[wix:File/@Source = '$(var.OpenAPIPath)\Web.config']/@Id" />
  </xsl:variable>
  <xsl:variable name="mainAssembly">
    <xsl:value-of select="//wix:Component[wix:File/@Source = '$(var.OpenAPIPath)\bin\eidss.openapi.web.dll']/@Id" />
  </xsl:variable>
  <xsl:variable name="default.map">
    <xsl:value-of select="//wix:Component[wix:File/@Source = '$(var.AVRPath)\bin\Default.map']/@Id" />
  </xsl:variable>
  <xsl:variable name="default.kz.map">
    <xsl:value-of select="//wix:Component[wix:File/@Source = '$(var.AVRPath)\bin\Default.KZ.map']/@Id" />
  </xsl:variable>
  <xsl:variable name="default.th.map">
    <xsl:value-of select="//wix:Component[wix:File/@Source = '$(var.AVRPath)\bin\Default.TH.map']/@Id" />
  </xsl:variable>
  <xsl:template match="//wix:ComponentRef">
    <xsl:for-each select="self::node()[@Id != $packages.config
      and @Id != $web.config
      and @Id != $mainAssembly
      and @Id != $default.map
      and @Id != $default.kz.map
      and @Id != $default.th.map]">
      <xsl:copy>
        <xsl:apply-templates select="@*|node()" />
      </xsl:copy>
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="//wix:Component[wix:File/@Source = '$(var.OpenAPIPath)\packages.config']" />
  <xsl:template match="//wix:Component[wix:File/@Source = '$(var.OpenAPIPath)\Web.config']" />
  <xsl:template match="//wix:Component[wix:File/@Source = '$(var.OpenAPIPath)\bin\eidss.openapi.web.dll']" />
  <xsl:template match="//wix:Component[wix:File/@Source = '$(var.AVRPath)\bin\Default.map']" />
  <xsl:template match="//wix:Component[wix:File/@Source = '$(var.AVRPath)\bin\Default.KZ.map']" />
  <xsl:template match="//wix:Component[wix:File/@Source = '$(var.AVRPath)\bin\Default.TH.map']" />
</xsl:stylesheet>
