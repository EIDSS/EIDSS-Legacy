<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt"
  exclude-result-prefixes="msxsl">

  <xsl:output method="xml" indent="yes" />

  <xsl:strip-space elements="*" />

  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()"/>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="add[@key='ConnectionSource']" />

  <xsl:template match="add[@key='AVRServiceHostURL']" />
  <xsl:template match="add[@key='AVRServiceSystemName']" />
  <xsl:template match="add[@key='AVRServiceDisplayName']" />

  <xsl:template match="add[@key='SQLConnectionString']" />
  <xsl:template match="add[@key='SQLServer']" />
  <xsl:template match="add[@key='SQLDatabase']" />
  <xsl:template match="add[@key='SQLUser']" />
  <xsl:template match="add[@key='SQLPassword']" />

  <xsl:template match="add[@key='ArchiveConnectionString']" />
  <xsl:template match="add[@key='ArchiveServer']" />
  <xsl:template match="add[@key='ArchiveDatabase']" />
  <xsl:template match="add[@key='ArchiveUser']" />
  <xsl:template match="add[@key='ArchivePassword']" />

  <xsl:template match="add[@key='AvrServiceConnectionString']" />
  <xsl:template match="add[@key='AvrServiceServer']" />
  <xsl:template match="add[@key='AvrServiceDatabase']" />
  <xsl:template match="add[@key='AvrServiceUser']" />
  <xsl:template match="add[@key='AvrServicePassword']" />
  <xsl:template match="add[@key='ConnectionSource']" />

  <xsl:template match="schedulerConfiguration" />
</xsl:stylesheet>