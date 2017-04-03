<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />

    <xsl:template name="required">
        <xsl:param name="tablename" />
        public Dictionary&lt;string, Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;&gt; m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null &amp;&amp; m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt; func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary&lt;string, Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;&gt;();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    </xsl:template>
    
    <xsl:template name="setup-required">
        <xsl:param name="tablename" />
            private void _SetupRequired(<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
            <xsl:for-each select="bv:validators/bv:post/bv:required_validator">
                <xsl:variable name="property">
                    <xsl:choose>
                        <xsl:when test="@property">
                            <xsl:value-of select="@property"/>
                        </xsl:when>
                        <xsl:otherwise>
                            <xsl:value-of select="@target"/>
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
                <xsl:variable name="func">
                    <xsl:choose>
                        <xsl:when test="@predicate">
                            <xsl:value-of select="@predicate"/>
                        </xsl:when>
                        <xsl:otherwise>
                            <xsl:value-of select="'c => true'"/>
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
                obj<xsl:choose>
                    <xsl:when test="contains($property, '.')">
                        <xsl:variable name="obj1"><xsl:value-of select="substring-before($property, '.')"/></xsl:variable>
                        <xsl:variable name="prop1"><xsl:value-of select="substring-after($property, '.')"/></xsl:variable>
                    .<xsl:value-of select="$obj1" />
                    <xsl:choose>
                        <xsl:when test="contains($prop1, '.')">
                            <xsl:variable name="obj2"><xsl:value-of select="substring-before($prop1, '.')"/></xsl:variable>
                            <xsl:variable name="prop2"><xsl:value-of select="substring-after($prop1, '.')"/></xsl:variable>
                        .<xsl:value-of select="$obj2" />
                        .AddRequired("<xsl:value-of select="$prop2" />", <xsl:value-of select="$func" />);
                        </xsl:when>
                        <xsl:otherwise>
                        .AddRequired("<xsl:value-of select="$prop1" />", <xsl:value-of select="$func" />);
                        </xsl:otherwise>
                    </xsl:choose>
                    </xsl:when>
                    <xsl:otherwise>
                    .AddRequired("<xsl:value-of select="$property" />", <xsl:value-of select="$func" />);
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:for-each>
            <xsl:for-each select="bv:validators/bv:post/bv:custom_mandatory_validator">
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.<xsl:value-of select="@fieldId"/>))
              {
              <xsl:variable name="name">
                    <xsl:value-of select="@name"/>
              </xsl:variable>
              obj<xsl:choose>
                <xsl:when test="contains($name, '.')">
                  <xsl:variable name="obj1">
                    <xsl:value-of select="substring-before($name, '.')"/>
                  </xsl:variable>
                  <xsl:variable name="prop1">
                    <xsl:value-of select="substring-after($name, '.')"/>
                  </xsl:variable>
                  .<xsl:value-of select="$obj1" />
                  <xsl:choose>
                    <xsl:when test="contains($prop1, '.')">
                      <xsl:variable name="obj2">
                        <xsl:value-of select="substring-before($prop1, '.')"/>
                      </xsl:variable>
                      <xsl:variable name="prop2">
                        <xsl:value-of select="substring-after($prop1, '.')"/>
                      </xsl:variable>
                      .<xsl:value-of select="$obj2" />
                      .AddRequired("<xsl:value-of select="$prop2" />", c=>true);
                    </xsl:when>
                    <xsl:otherwise>
                      .AddRequired("<xsl:value-of select="$prop1" />", c=>true);
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:when>
                <xsl:otherwise>
                  .AddRequired("<xsl:value-of select="$name" />", c=>true);
                </xsl:otherwise>
              </xsl:choose>
                }
            </xsl:for-each>
            }
    </xsl:template>
    
</xsl:stylesheet>
