<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

  <xsl:import href="globals.xslt" />

  <xsl:template name="personal">
    <xsl:param name="tablename" />
    internal Dictionary&lt;string, Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;&gt; m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null &amp;&amp; m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt; func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary&lt;string, Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;&gt;();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  </xsl:template>

  <xsl:template name="personal-static">
    <xsl:param name="tablename" />
    private static Dictionary&lt;string, List&lt;Func&lt;bool&gt;&gt;&gt; m_isHiddenPersonalData = new Dictionary&lt;string, List&lt;Func&lt;bool&gt;&gt;&gt;();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func&lt;bool&gt; func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List&lt;Func&lt;bool&gt;&gt;());
      m_isHiddenPersonalData[name].Add(func);
    }
  </xsl:template>

  <xsl:template name="personal-data">
    <xsl:param name="tablename" />
    private void _SetupPersonalDataRestrictions(<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
    {
    <xsl:for-each select="bv:personaldata/bv:group">
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
      if (EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.<xsl:value-of select="@name"/>))
      {
      <xsl:for-each select="bv:item">
        <xsl:variable name="name">
          <xsl:value-of select="@name"/>
        </xsl:variable>

        <xsl:choose>
          <xsl:when test="@islist" > <!-- if property is a list -->
            <xsl:variable name="islist">
              <xsl:value-of select="@islist"/>
            </xsl:variable>
            <xsl:choose>
              <xsl:when test="contains($name, '.')">
                <xsl:variable name="obj1">
                  <xsl:value-of select="substring-before($name, '.')"/>
                </xsl:variable>
                <xsl:variable name="prop1">
                  <xsl:value-of select="substring-after($name, '.')"/>
                </xsl:variable>
                foreach(var o in obj.<xsl:value-of select="$obj1" />)
              {
              o
               <xsl:choose>
                  <xsl:when test="contains($prop1, '.')">
                    <xsl:variable name="obj2">
                      <xsl:value-of select="substring-before($prop1, '.')"/>
                    </xsl:variable>
                    <xsl:variable name="prop2">
                      <xsl:value-of select="substring-after($prop1, '.')"/>
                    </xsl:variable>
                    .<xsl:value-of select="$obj2" />
                    <xsl:choose>
                      <xsl:when test="contains($prop2, '.')">
                        <xsl:variable name="obj3">
                          <xsl:value-of select="substring-before($prop2, '.')"/>
                        </xsl:variable>
                        <xsl:variable name="prop3">
                          <xsl:value-of select="substring-after($prop2, '.')"/>
                        </xsl:variable>
                        .<xsl:value-of select="$obj3" />
                          .AddHiddenPersonalData("<xsl:value-of select="$prop3" />", <xsl:value-of select="$predicate" />);
                      </xsl:when>
                      <xsl:otherwise>
                        .AddHiddenPersonalData("<xsl:value-of select="$prop2" />", <xsl:value-of select="$predicate" />);
                      </xsl:otherwise>  
                    </xsl:choose>                    
                  </xsl:when>
                  <xsl:otherwise>
                    .AddHiddenPersonalData("<xsl:value-of select="$prop1" />", <xsl:value-of select="$predicate" />);
                  </xsl:otherwise>
                </xsl:choose>
                }
              </xsl:when>
            </xsl:choose>
          </xsl:when>
          
          <xsl:otherwise>            <!-- if property is simple-->
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
                  .AddHiddenPersonalData("<xsl:value-of select="$prop2" />", <xsl:value-of select="$predicate" />);
                </xsl:when>
                <xsl:otherwise>
                  .AddHiddenPersonalData("<xsl:value-of select="$prop1" />", <xsl:value-of select="$predicate" />);
                </xsl:otherwise>
              </xsl:choose>
            </xsl:when>
            <xsl:otherwise>
              .AddHiddenPersonalData("<xsl:value-of select="$name" />", <xsl:value-of select="$predicate" />);
            </xsl:otherwise>
          </xsl:choose>
          </xsl:otherwise>
        </xsl:choose>
    </xsl:for-each>
      }
    </xsl:for-each>
    
    }
  </xsl:template>

  <xsl:template name="personal-data-static">
    <xsl:param name="tablename" />
    private static void _SetupPersonalDataRestrictions()
    {
    <xsl:for-each select="bv:personaldata/bv:group">
      <xsl:variable name="groupname" select="@name" />
      <xsl:for-each select="bv:item">
        <xsl:variable name="name" select="@name" />
        AddHiddenPersonalData("<xsl:value-of select="$name" />", () => EidssUserContext.User.ForbiddenPersonalDataGroups.Contains(PersonalDataGroup.<xsl:value-of select="$groupname"/>));
      </xsl:for-each>
    </xsl:for-each>

    }
  </xsl:template>

</xsl:stylesheet>
