<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet
  version="2.0"
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

  <xsl:template match="//wix:File">
    <xsl:variable name="dll" select="'dll'" />
    <xsl:variable name="exe" select="'exe'" />
    <xsl:variable name="extension" select="substring(@Source, string-length(@Source) - string-length($dll) + 1)" />
                  
    <xsl:copy>
      <xsl:if test="$extension = $dll or $extension = $exe">
        <xsl:attribute name="Checksum">
          <xsl:text>yes</xsl:text>
        </xsl:attribute>
      </xsl:if>
      <xsl:copy-of select="@*" />
      <xsl:apply-templates select="node()" />
    </xsl:copy>
  </xsl:template>
</xsl:stylesheet>
