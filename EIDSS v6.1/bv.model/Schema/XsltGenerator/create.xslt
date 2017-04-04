<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:bv="urn:schemas-bv:objectmodel"
	xmlns:util="urn:util">

    <xsl:import href="globals.xslt" />
    <xsl:import href="extenders.xslt" />

    <xsl:template name="create">
        <xsl:param name="tablename" />
        <xsl:param name="hacodable" />

            private <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj = null;
                try
                {
                    obj = <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    <xsl:if test="$hacodable='true'">
                    obj._HACode = HACode;
                    </xsl:if>
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin<xsl:for-each select="bv:extenders/bv:creating/*">
                        <xsl:call-template name="generate-extender">
                            <xsl:with-param name="tablename" select="$tablename" />
                            <xsl:with-param name="hacodable" select="$hacodable" />
                        </xsl:call-template>
                    </xsl:for-each>
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    <xsl:for-each select="bv:relations/bv:relation[@type='child']">
                    _SetupAddChildHandler<xsl:value-of select="@name" />(obj);
                    </xsl:for-each>
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin<xsl:for-each select="bv:extenders/bv:created/*">
                        <xsl:call-template name="generate-extender">
                            <xsl:with-param name="tablename" select="$tablename" />
                            <xsl:with-param name="hacodable" select="$hacodable" />
                        </xsl:call-template>
                    </xsl:for-each>
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(obj, e);
                }
            }

            <!--xsl:if test="not(bv:actions/bv:action[@type='Create'][@name='CreateNew'])"-->
            public <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            <!--/xsl:if-->
            <!--xsl:if test="not(bv:actions/bv:action[@type='Create'][@name='CreateWithParams'])"-->
            public <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> CreateWithParamsT(DbManagerProxy manager, IObject Parent, List&lt;object&gt; pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List&lt;object&gt; pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            <!--/xsl:if-->

            <xsl:for-each select="bv:actions/bv:action[@type='Create']">
            public <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />T(DbManagerProxy manager, IObject Parent, List&lt;object&gt; pars)
            {
                <xsl:if test="count(bv:run/bv:params/bv:param) > 0">
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != <xsl:value-of select="count(bv:run/bv:params/bv:param)" />) 
                    throw new ParamsCountException();
                <xsl:for-each select="bv:run/bv:params/bv:param">if (pars[<xsl:value-of select="position()-1"/>] != null &amp;&amp; !(pars[<xsl:value-of select="position()-1"/>] is <xsl:value-of select="@type" />)) 
                    throw new TypeMismatchException("<xsl:value-of select="@name" />", typeof(<xsl:value-of select="@type" />));
                </xsl:for-each>
                </xsl:if>
                return <xsl:value-of select="@name" />(manager, Parent<xsl:for-each select="bv:run/bv:params/bv:param">
                    , (<xsl:value-of select="@type" />)pars[<xsl:value-of select="position()-1"/>]</xsl:for-each>
                    );
            }
            public IObject <xsl:value-of select="@name" />(DbManagerProxy manager, IObject Parent, List&lt;object&gt; pars)
            {
                return <xsl:value-of select="@name" />T(manager, Parent, pars);
            }
            public <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />(DbManagerProxy manager, IObject Parent<xsl:for-each select="bv:run/bv:params/bv:param">
                , <xsl:value-of select="@type" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" /><xsl:if test="@default"> = <xsl:value-of select="@default"/></xsl:if>
                </xsl:for-each>
                )
            {
                return _CreateNew(manager, Parent
                <xsl:choose>
                    <xsl:when test="bv:run/bv:params/bv:param[@name='HACode'][@type='int?']">
                    , HACode
                    </xsl:when>
                    <xsl:otherwise>
                    , null
                    </xsl:otherwise>
                </xsl:choose>
                    , obj =>
                {<xsl:for-each select="bv:run/bv:creating/*">
                    <xsl:call-template name="generate-extender">
                        <xsl:with-param name="tablename" select="$tablename" />
                        <xsl:with-param name="hacodable" select="$hacodable" />
                    </xsl:call-template>
                </xsl:for-each>
                }
                    , obj =>
                {<xsl:for-each select="bv:run/bv:created/*">
                    <xsl:call-template name="generate-extender">
                        <xsl:with-param name="tablename" select="$tablename" />
                        <xsl:with-param name="hacodable" select="$hacodable" />
                    </xsl:call-template>
                </xsl:for-each>
                }
                );
            }
            </xsl:for-each>

            <xsl:variable name="permission" select="bv:properties/@permissionObject" />
            <xsl:apply-templates select="bv:actions" mode="action">
              <xsl:with-param name="tablename" select="$tablename" />
              <xsl:with-param name="permission" select="$permission" />
            </xsl:apply-templates>
<!--
            <xsl:for-each select="bv:actions/bv:action[@type='Action']">
            public ActResult<xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />(DbManagerProxy manager, <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj, List&lt;object&gt; pars)
            {
                <xsl:if test="count(bv:run/bv:params/bv:param) > 0">
                if (pars.Count != <xsl:value-of select="count(bv:run/bv:params/bv:param)" />) 
                    throw new ParamsCountException();
                <xsl:for-each select="bv:run/bv:params/bv:param">if (pars[<xsl:value-of select="position()-1"/>] != null &amp;&amp; !(pars[<xsl:value-of select="position()-1"/>] is <xsl:value-of select="@type" />)) 
                    throw new TypeMismatchException("<xsl:value-of select="@name" />", typeof(<xsl:value-of select="@type" />));
                </xsl:for-each>
                </xsl:if>
                return <xsl:value-of select="@name" />(manager, obj<xsl:for-each select="bv:run/bv:params/bv:param">
                    , (<xsl:value-of select="@type" />)pars[<xsl:value-of select="position()-1"/>]</xsl:for-each>
                    );
            }
            public ActResult<xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />(DbManagerProxy manager, <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj<xsl:for-each select="bv:run/bv:params/bv:param">
                , <xsl:value-of select="@type" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />
                </xsl:for-each>
                )
            {
                <xsl:if test="$permission">
                if (obj != null &amp;&amp; !obj.GetPermissions().CanExecute("<xsl:value-of select="@name" />"))
                    throw new PermissionException("<xsl:value-of select="$permission" />", "<xsl:value-of select="@name" />");
                </xsl:if>
              <xsl:choose>
                <xsl:when test="bv:run/bv:preText">
                <xsl:value-of select="bv:run/bv:preText"/>
                </xsl:when>
                <xsl:otherwise>
                return true;
                </xsl:otherwise>
              </xsl:choose>
            }
            </xsl:for-each>
            -->
    </xsl:template>
    
  <xsl:template match="bv:actions" mode="action">
    <xsl:param name="tablename" />
    <xsl:param name="permission" />

    <xsl:for-each select="bv:action[@type='Action']">
            public ActResult<xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />(DbManagerProxy manager, <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj, List&lt;object&gt; pars)
            {
                <xsl:if test="count(bv:run/bv:params/bv:param) > 0">
                if (pars.Count != <xsl:value-of select="count(bv:run/bv:params/bv:param)" />) 
                    throw new ParamsCountException();
                <xsl:for-each select="bv:run/bv:params/bv:param">if (pars[<xsl:value-of select="position()-1"/>] != null &amp;&amp; !(pars[<xsl:value-of select="position()-1"/>] is <xsl:value-of select="@type" />)) 
                    throw new TypeMismatchException("<xsl:value-of select="@name" />", typeof(<xsl:value-of select="@type" />));
                </xsl:for-each>
                </xsl:if>
                return <xsl:value-of select="@name" />(manager, obj<xsl:for-each select="bv:run/bv:params/bv:param">
                    , (<xsl:value-of select="@type" />)pars[<xsl:value-of select="position()-1"/>]</xsl:for-each>
                    );
            }
            public ActResult<xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />(DbManagerProxy manager, <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj<xsl:for-each select="bv:run/bv:params/bv:param">
                , <xsl:value-of select="@type" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />
                </xsl:for-each>
                )
            {
                <xsl:if test="$permission">
                if (obj != null &amp;&amp; !obj.GetPermissions().CanExecute("<xsl:value-of select="@name" />"))
                    throw new PermissionException("<xsl:value-of select="$permission" />", "<xsl:value-of select="@name" />");
                </xsl:if>
              <xsl:choose>
                <xsl:when test="bv:run/bv:preText">
                <xsl:value-of select="bv:run/bv:preText"/>
                </xsl:when>
                <xsl:otherwise>
                return true;
                </xsl:otherwise>
              </xsl:choose>
            }
            
      <xsl:apply-templates select="bv:actions" mode="action">
        <xsl:with-param name="tablename" select="$tablename" />
        <xsl:with-param name="permission" select="$permission" />
      </xsl:apply-templates>
            
    </xsl:for-each>
  </xsl:template>
  
</xsl:stylesheet>
