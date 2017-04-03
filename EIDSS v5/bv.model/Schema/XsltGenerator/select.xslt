<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:bv="urn:schemas-bv:objectmodel"
	xmlns:util="urn:util">

    <xsl:import href="globals.xslt" />
    <xsl:import href="fnlist.xslt" />
    <xsl:import href="list.xslt" />
    <xsl:import href="bykey.xslt" />
    <xsl:import href="sections.xslt" />

    <xsl:template name="select">
        <xsl:param name="langid" />
        <xsl:param name="namespace" />
        <xsl:param name="index" />
        <xsl:param name="sp_cache" />
        <xsl:param name="sp_type" />
        <xsl:param name="tablename" />
        <xsl:param name="hacodable" />
        <xsl:param name="schema_get" />
        <xsl:param name="sp_get" />
        <xsl:param name="sp_count" />
        <xsl:param name="columns" />
        <xsl:param name="filter_object" />
        <xsl:param name="tablekeys" />

        <!--xsl:if test="$index=1"-->
            <xsl:for-each select="bv:relations/bv:relation">private <xsl:choose><xsl:when test="@accessor"><xsl:value-of select="@accessor"/></xsl:when><xsl:otherwise><xsl:value-of select="@table"/></xsl:otherwise></xsl:choose><xsl:value-of select="$class_suffix" />.Accessor <xsl:value-of select="@name"/>Accessor { get { return <xsl:value-of select="$namespace"/>.<xsl:choose><xsl:when test="@accessor"><xsl:value-of select="@accessor"/></xsl:when><xsl:otherwise><xsl:value-of select="@table"/></xsl:otherwise></xsl:choose><xsl:value-of select="$class_suffix" />.Accessor.Instance(m_CS); } }
            </xsl:for-each>
            <xsl:for-each select="bv:lookups/bv:lookup">private <xsl:value-of select="@table"/><xsl:value-of select="$class_suffix" />.Accessor <xsl:value-of select="@name"/>Accessor { get { return <xsl:value-of select="$namespace"/>.<xsl:value-of select="@table"/><xsl:value-of select="$class_suffix" />.Accessor.Instance(m_CS); } }
            </xsl:for-each>
            <xsl:if test="$sp_cache='true'">[InstanceCache(typeof(BvCacheAspect))]</xsl:if>
            <xsl:choose>
                <xsl:when test="contains($sp_type,'fnlist')">
                    <xsl:call-template name="fnlist">
                      <xsl:with-param name="langid" select="$langid" />
                      <xsl:with-param name="tablename" select="$tablename" />
                      <xsl:with-param name="hacodable" select="$hacodable" />
                      <xsl:with-param name="schema_get" select="$schema_get" />
                      <xsl:with-param name="sp_get" select="$sp_get" />
                      <xsl:with-param name="sp_count" select="$sp_count" />
                      <xsl:with-param name="columns" select="$columns" />
                      <xsl:with-param name="filter_object" select="$filter_object" />
                      <xsl:with-param name="tablekeys" select="$tablekeys" />
                      <xsl:with-param name="sp_cache" select="$sp_cache" />
                    </xsl:call-template>
                </xsl:when>
                <xsl:when test="contains($sp_type,'detaillist')">
                    <xsl:call-template name="detaillist">
                      <xsl:with-param name="langid" select="$langid" />
                      <xsl:with-param name="tablename" select="$tablename" />
                      <xsl:with-param name="hacodable" select="$hacodable" />
                      <xsl:with-param name="schema_get" select="$schema_get" />
                      <xsl:with-param name="sp_get" select="$sp_get" />
                      <xsl:with-param name="sp_cache" select="$sp_cache" />
                    </xsl:call-template>
                </xsl:when>
                <xsl:when test="contains($sp_type,'simplelist')">
                    <xsl:call-template name="list">
                      <xsl:with-param name="langid" select="$langid" />
                      <xsl:with-param name="tablename" select="$tablename" />
                      <xsl:with-param name="hacodable" select="$hacodable" />
                      <xsl:with-param name="schema_get" select="$schema_get" />
                      <xsl:with-param name="sp_get" select="$sp_get" />
                      <xsl:with-param name="sp_cache" select="$sp_cache" />
                    </xsl:call-template>
                </xsl:when>
                <xsl:when test="contains($sp_type,'lookuplist')">
                    <xsl:call-template name="lookuplist">
                      <xsl:with-param name="langid" select="$langid" />
                      <xsl:with-param name="tablename" select="$tablename" />
                      <xsl:with-param name="hacodable" select="$hacodable" />
                      <xsl:with-param name="schema_get" select="$schema_get" />
                      <xsl:with-param name="sp_get" select="$sp_get" />
                      <xsl:with-param name="sp_cache" select="$sp_cache" />
                    </xsl:call-template>
                </xsl:when>
            </xsl:choose>
            <xsl:if test="contains($sp_type,'detailone')">
                <xsl:call-template name="bykey">
                    <xsl:with-param name="langid" select="$langid" />
                    <xsl:with-param name="tablename" select="$tablename" />
                    <xsl:with-param name="index" select="$index" />
                    <xsl:with-param name="hacodable" select="$hacodable" />
                    <xsl:with-param name="schema_get" select="$schema_get" />
                    <xsl:with-param name="sp_get" select="$sp_get" />
                    <xsl:with-param name="sp_cache" select="$sp_cache" />
                </xsl:call-template>
            </xsl:if>
            <xsl:call-template name="sections">
                <xsl:with-param name="langid" select="$langid" />
                <xsl:with-param name="tablename" select="$tablename" />
                <xsl:with-param name="schema_get" select="$schema_get" />
            </xsl:call-template>
            <!--/xsl:if-->
        
            <xsl:for-each select="bv:relations/bv:relation[@type='child']">
            private void _SetupAddChildHandler<xsl:value-of select="@name" />(<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                obj.<xsl:value-of select="@name" />.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            </xsl:for-each>
            <xsl:for-each select="bv:relations/bv:relation[@internal!='true']">
            internal void _Load<xsl:value-of select="@name" />(<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _Load<xsl:value-of select="@name" />(manager, obj);
                }
            }
            internal void _Load<xsl:value-of select="@name" />(DbManagerProxy manager, <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                <xsl:choose>
                    <xsl:when test="@type='child'">
                obj.<xsl:value-of select="@name" />.Clear();
                obj.<xsl:value-of select="@name" />.AddRange(<xsl:value-of select="@name"/>Accessor.<xsl:choose><xsl:when test="@function"><xsl:value-of select="@function"/></xsl:when><xsl:otherwise>SelectDetailList</xsl:otherwise></xsl:choose>(manager
                    <xsl:if test="not(@paramsonly)">
                    , obj.<xsl:variable name="parname" select="@source" /><xsl:value-of select="$parname"/><xsl:if test="$columns/column[@name=$parname]/@nullable='true'">.HasValue ? obj.<xsl:value-of select="$parname"/>.Value : 0</xsl:if>
                    <xsl:if test="@hacodable='true'">
                        <xsl:choose>
                            <xsl:when test="$hacodable='true'">
                    , obj._HACode
                            </xsl:when>
                            <xsl:otherwise>
                    , null
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:if>
                    </xsl:if>
                    <xsl:for-each select="bv:params/bv:param">
                    , new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, <xsl:value-of select="@type" />&gt;(<xsl:value-of select="@lambda" />)(obj)
                    </xsl:for-each>
                    ));
                obj.<xsl:value-of select="@name" />.ForEach(c => c.m_ObjectName = _str_<xsl:value-of select="@name" />);
                obj.<xsl:value-of select="@name" />.AcceptChanges();
                    </xsl:when>
                    <xsl:otherwise>
                <xsl:variable name="keys" select="util:ExpandXml('source,target', string(@source), string(@target))" />
                <xsl:variable name="varname" select="@name" />
                if (obj.<xsl:value-of select="@name" /> == null &amp;&amp; <xsl:for-each select="$keys/keys/key"><xsl:if test="position() > 1"> &amp;&amp; </xsl:if><xsl:variable name="source" select="@source" /><xsl:if test="$columns/column[@name=$source]/@nullable='true'">obj.<xsl:value-of select="@source" /> != null &amp;&amp; </xsl:if>obj.<xsl:value-of select="@source" /> != 0</xsl:for-each>)
                {
                    obj.<xsl:value-of select="@name" /> = <xsl:value-of select="@name"/>Accessor.SelectByKey(manager
                        <xsl:if test="not(@paramsonly)">
                        <xsl:for-each select="$keys/keys/key">
                        , obj.<xsl:variable name="parname" select="@source" /><xsl:value-of select="$parname"/><xsl:if test="$columns/column[@name=$parname]/@nullable='true'"><xsl:text>.Value</xsl:text></xsl:if>
                        </xsl:for-each>
                        <xsl:if test="@hacodable='true'">
                            <xsl:choose>
                                <xsl:when test="$hacodable='true'">
                        , obj._HACode
                                </xsl:when>
                                <xsl:otherwise>
                        , null
                                </xsl:otherwise>
                            </xsl:choose>
                        </xsl:if>
                        </xsl:if>
                        <xsl:for-each select="bv:params/bv:param">
                        , new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, <xsl:value-of select="@type" />&gt;(<xsl:value-of select="@lambda" />)(obj)
                        </xsl:for-each>
                        );
                    if (obj.<xsl:value-of select="@name" /> != null)
                    {
                        obj.<xsl:value-of select="@name" />.m_ObjectName = _str_<xsl:value-of select="@name" />;
                    }
                }
                    </xsl:otherwise>
                </xsl:choose>
            }
            </xsl:for-each>
        
        
            internal void _SetupLoad(DbManagerProxy manager, <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin<xsl:for-each select="bv:extenders/bv:loading/*">
                    <xsl:call-template name="generate-extender">
                        <xsl:with-param name="tablename" select="$tablename" />
                        <xsl:with-param name="hacodable" select="$hacodable" />
                    </xsl:call-template>
                </xsl:for-each>
                // loading extenters - end
                <xsl:for-each select="bv:relations/bv:relation[@internal!='true']">
                    <xsl:if test="@lazy='false'">
                _Load<xsl:value-of select="@name" />(manager, obj);</xsl:if>
                </xsl:for-each>
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin<xsl:for-each select="bv:extenders/bv:loaded/*">
                    <xsl:call-template name="generate-extender">
                        <xsl:with-param name="tablename" select="$tablename" />
                        <xsl:with-param name="hacodable" select="$hacodable" />
                    </xsl:call-template>
                </xsl:for-each>
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                <xsl:for-each select="bv:relations/bv:relation[@type='child']">
                _SetupAddChildHandler<xsl:value-of select="@name" />(obj);
                </xsl:for-each>
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    <xsl:for-each select="bv:relations/bv:relation[@type!='child']">
                        <xsl:value-of select="@name" />Accessor._SetPermitions(obj._permissions, obj.<xsl:value-of select="@name" />);
                    </xsl:for-each>
                    <xsl:for-each select="bv:relations/bv:relation[@type='child']">
                        obj.<xsl:value-of select="@name" />.ForEach(c => <xsl:value-of select="@name" />Accessor._SetPermitions(obj._permissions, c));
                    </xsl:for-each>
                    }
                }
            }

    </xsl:template>
    
</xsl:stylesheet>
