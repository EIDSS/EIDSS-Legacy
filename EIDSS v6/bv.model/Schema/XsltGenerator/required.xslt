<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />

    <xsl:template name="required">
        <xsl:param name="tablename" />
        internal Dictionary&lt;string, Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;&gt; m_isRequired;
        private bool _isRequired(Dictionary&lt;string, Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;&gt; isRequiredDict, string name)
        {
            if (isRequiredDict != null &amp;&amp; isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
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
        <xsl:param name="table" />
            private void _SetupRequired(<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
            <xsl:for-each select="bv:validators/bv:post/bv:required_validator">
                <xsl:variable name="target">
                    <xsl:value-of select="@target"/>
                </xsl:variable>
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
                <xsl:if test="msxsl:node-set($table)/bv:lookups/bv:lookup[@source=$target]">
                  obj
                    .AddRequired("<xsl:value-of select="msxsl:node-set($table)/bv:lookups/bv:lookup[@source=$target]/@name" />", <xsl:value-of select="$func" />);
                </xsl:if>
            </xsl:for-each>
            <xsl:for-each select="bv:validators/bv:post/bv:custom_mandatory_validator">
              <xsl:variable name="name">
                <xsl:value-of select="@name"/>
              </xsl:variable>
              <xsl:variable name="predicate">
                <xsl:choose>
                  <xsl:when test="@predicate">
                    <xsl:value-of select="@predicate"/>
                  </xsl:when>
                  <xsl:otherwise>
                    <xsl:text>c => true</xsl:text>
                  </xsl:otherwise>
                </xsl:choose>
              </xsl:variable>
              if (EidssSiteContext.Instance.CustomMandatoryFields.Contains(CustomMandatoryField.<xsl:value-of select="@fieldId"/>) <xsl:if test="not(@nocheckpredicateinadd='true')"> &amp;&amp; new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="$predicate" />)(obj)</xsl:if>)
              {
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
                      .AddRequired("<xsl:value-of select="$prop2" />", <xsl:value-of select="$predicate" />);
                    </xsl:when>
                    <xsl:otherwise>
                      .AddRequired("<xsl:value-of select="$prop1" />", <xsl:value-of select="$predicate" />);
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:when>
                <xsl:otherwise>
                  .AddRequired("<xsl:value-of select="$name" />", <xsl:value-of select="$predicate" />);
                </xsl:otherwise>
              </xsl:choose>
                }
            </xsl:for-each>
            }
    </xsl:template>
    
</xsl:stylesheet>
