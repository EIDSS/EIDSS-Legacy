<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt"
  xmlns:wix="http://schemas.microsoft.com/wix/2006/wi"
  exclude-result-prefixes="msxsl">

  <xsl:output method="xml" indent="yes" />

  <xsl:strip-space elements="*" />
  <xsl:preserve-space elements="*"/>

  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()"/>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="//wix:Component">
    <xsl:copy>
      <xsl:apply-templates select="@*" />
      <xsl:attribute name="MultiInstance">
        <xsl:text>yes</xsl:text>
      </xsl:attribute>
      <xsl:apply-templates select="node()" />
    </xsl:copy>
  </xsl:template>
</xsl:stylesheet>
