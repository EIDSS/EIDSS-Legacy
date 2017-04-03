<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />
    <xsl:import href="extenders.xslt" />

    <xsl:template name="bykey">
        <xsl:param name="langid" />
        <xsl:param name="tablename" />
        <xsl:param name="index" />
        <xsl:param name="hacodable" />
        <xsl:param name="schema_get" />
        <xsl:param name="sp_get" />
        <xsl:param name="sp_cache" />

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                        <xsl:choose>
                            <xsl:when test="position()=1">
                        , (<xsl:value-of select="@type"/>)ident
                            </xsl:when>
                            <xsl:otherwise>
                        , null
                            </xsl:otherwise>
                        </xsl:choose>
                        </xsl:for-each>
                        <xsl:if test="$hacodable='true'">
                        , HACode
                        </xsl:if>
                        , null, null
                        );
                }
            }

            <!--xsl:if test="not(bv:actions/bv:action[@type='Load'][@name='SelectByKey'])"-->
            <xsl:if test="$sp_cache='true'">[InstanceCache(typeof(BvCacheAspect))]</xsl:if>
            public virtual <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> SelectByKey(DbManagerProxy manager<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                , <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/>
                </xsl:for-each>
                <xsl:if test="$hacodable='true'">
                , int? HACode = null
                </xsl:if>
                )
            {
                return _SelectByKey(manager<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                    , <xsl:value-of select="@name"/>
                    </xsl:for-each>
                    <xsl:if test="$hacodable='true'">
                    , HACode
                    </xsl:if>
                    , null, null
                    );
            }
            <!--/xsl:if-->
            
            <xsl:for-each select="bv:actions/bv:action[@type='Load']">
            public <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />T(DbManagerProxy manager, List&lt;object&gt; pars)
            {
                <xsl:if test="count(bv:run/bv:params/bv:param) + count($schema_get/schema/params/param[@name!=$langid]) > 0">
                if (pars == null) throw new ParamsCountException();
                if (pars.Count != <xsl:value-of select="count(bv:run/bv:params/bv:param) + count($schema_get/schema/params/param[@name!=$langid])" />) 
                    throw new ParamsCountException();
                <xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                if (!(pars[<xsl:value-of select="position()-1"/>] is <xsl:value-of select="@type" />)) 
                    throw new TypeMismatchException("<xsl:value-of select="@name" />", typeof(<xsl:value-of select="@type" />));
                </xsl:for-each>
                <xsl:for-each select="bv:run/bv:params/bv:param">
                if (!(pars[<xsl:value-of select="position()+count($schema_get/schema/params/param[@name!=$langid])-1"/>] is <xsl:value-of select="@type" />)) 
                    throw new TypeMismatchException("<xsl:value-of select="@name" />", typeof(<xsl:value-of select="@type" />));
                </xsl:for-each>
                </xsl:if>
                return <xsl:value-of select="@name" />(manager
                    <xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                    , (<xsl:value-of select="@type" />)pars[<xsl:value-of select="position()-1"/>]
                    </xsl:for-each>
                    <xsl:for-each select="bv:run/bv:params/bv:param">
                    , (<xsl:value-of select="@type" />)pars[<xsl:value-of select="position()+count($schema_get/schema/params/param[@name!=$langid])-1"/>]
                    </xsl:for-each>
                    );
            }
            public IObject <xsl:value-of select="@name" />(DbManagerProxy manager, List&lt;object&gt; pars)
            {
                return <xsl:value-of select="@name" />T(manager, pars);
            }
            <xsl:if test="$sp_cache='true'">[InstanceCache(typeof(BvCacheAspect))]</xsl:if>
            public virtual <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />(DbManagerProxy manager<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                , <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/>
                </xsl:for-each>
                <xsl:for-each select="bv:run/bv:params/bv:param">
                , <xsl:value-of select="@type" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />
                </xsl:for-each>
                )
            {
                return _SelectByKey(manager<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                    , <xsl:value-of select="@name"/>
                    </xsl:for-each>
                    <xsl:if test="$hacodable='true'">
                    , null
                    </xsl:if>
                    , obj =>
                {<xsl:for-each select="bv:run/bv:loading/*">
                    <xsl:call-template name="generate-extender">
                        <xsl:with-param name="tablename" select="$tablename" />
                        <xsl:with-param name="hacodable" select="$hacodable" />
                    </xsl:call-template>
                </xsl:for-each>
                }
                    , obj =>
                {<xsl:for-each select="bv:run/bv:loaded/*">
                    <xsl:call-template name="generate-extender">
                        <xsl:with-param name="tablename" select="$tablename" />
                        <xsl:with-param name="hacodable" select="$hacodable" />
                    </xsl:call-template>
                </xsl:for-each>
                }
                );
            }
            </xsl:for-each>
      
            private <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> _SelectByKey(DbManagerProxy manager<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                , <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/>
                </xsl:for-each>
                <xsl:if test="$hacodable='true'">
                , int? HACode
                </xsl:if>
                , on_action loading, on_action loaded
                )
            {
            <xsl:choose>
                <xsl:when test="$index=1">
                MapResultSet[] sets = new MapResultSet[<xsl:value-of select="count(bv:relations/bv:relation[@internal='true'])+1" />];
                List&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt; objs = new List&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;();
                sets[0] = new MapResultSet(typeof(<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />), objs);
                <xsl:for-each select="bv:relations/bv:relation[@internal='true']">
                List&lt;<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />&gt; objs_<xsl:value-of select="@table" /> = new List&lt;<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />&gt;();
                sets[<xsl:value-of select="position()" />] = new MapResultSet(typeof(<xsl:value-of select="@table"/><xsl:value-of select="$class_suffix" />), objs_<xsl:value-of select="@table" />);
                </xsl:for-each>
        
                try
                {
                    manager
                        .SetSpCommand("<xsl:value-of select="$sp_get" />"<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                            , manager.Parameter("@<xsl:value-of select="@name"/>", <xsl:value-of select="@name"/>)</xsl:for-each>
                            <xsl:if test="$schema_get/schema/params/param[@name=$langid]">
                            , manager.Parameter("@<xsl:value-of select="$langid"/>", ModelUserContext.CurrentLanguage)
                            </xsl:if>
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj = objs[0];
                    obj.m_CS = m_CS;
                    <xsl:if test="$hacodable='true'">
                    obj._HACode = HACode;
                    </xsl:if>
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    <xsl:for-each select="bv:relations/bv:relation[@internal='true']">
                        <xsl:choose>
                            <xsl:when test="@type='child'">
                    obj.<xsl:value-of select="@name"/>.ForEach(c => <xsl:value-of select="@name"/>Accessor._SetupLoad(manager, c));
                        </xsl:when>
                            <xsl:otherwise>
                    <xsl:value-of select="@name"/>Accessor._SetupLoad(manager, obj.<xsl:value-of select="@name"/>);
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:for-each>
                    //obj._setParent();
                    if (loaded != null)
                        loaded(obj);
                    obj.Loaded(manager);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(e);
                }
                </xsl:when>
                <xsl:otherwise>
                throw new NotImplementedException();
                </xsl:otherwise>
            </xsl:choose>
            }
    </xsl:template>
    
</xsl:stylesheet>
