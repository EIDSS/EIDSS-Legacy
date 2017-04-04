<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template name="first-to-lower">
        <xsl:param name="name" />
        <xsl:value-of select="concat(translate(substring($name, 1, 1), 'QWERTYUIOPASDFGHJKLZXCVBNM', 'qwertyuiopasdfghjklzxcvbnm'), substring($name, 2))"/>
    </xsl:template>
    
</xsl:stylesheet>
