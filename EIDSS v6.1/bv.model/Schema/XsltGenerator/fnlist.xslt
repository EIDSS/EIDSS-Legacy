<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:bv="urn:schemas-bv:objectmodel"
    xmlns:util="urn:util"
    >

    <xsl:import href="globals.xslt" />

    <xsl:template name="fnlist">
        <xsl:param name="langid" />
        <xsl:param name="tablename" />
        <xsl:param name="hacodable" />
        <xsl:param name="schema_get" />
        <xsl:param name="sp_get" />
        <xsl:param name="sp_count" />
        <xsl:param name="columns" />
        <xsl:param name="filter_object" />
        <xsl:param name="tablekeys" />
        <xsl:param name="sp_cache" />

        <!--xsl:if test="not(bv:actions/bv:action[@type='Loadlist'])"-->
            public virtual List&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt; SelectListT(DbManagerProxy manager<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                , <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/>
                </xsl:for-each>
                , FilterParams filters = null
                , KeyValuePair&lt;string, ListSortDirection&gt;[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                , <xsl:value-of select="@name"/>
                </xsl:for-each>
                , null, null
                , filters
                , sorts
                , serverSort
                );
            }
            public virtual List&lt;IObject&gt; SelectList(DbManagerProxy manager<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                , <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/>
                </xsl:for-each>
                , FilterParams filters = null
                , KeyValuePair&lt;string, ListSortDirection&gt;[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                , <xsl:value-of select="@name"/>
                </xsl:for-each>
                , null, null
                , filters
                , sorts
                , serverSort
                ).Cast&lt;IObject&gt;().ToList();
            }
            <!--/xsl:if-->
            <xsl:if test="$sp_cache='true'">[InstanceCache(typeof(BvCacheAspect))]</xsl:if>
            protected virtual List&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt; _SelectList(DbManagerProxy manager<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                , <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/>
                </xsl:for-each>
                , on_action loading, on_action loaded
                , FilterParams filters
                , KeyValuePair&lt;string, ListSortDirection&gt;[] sorts
                , bool serverSort = false
                )
            {
                if (filters == null) filters = new FilterParams();
                <!--var sqlDeclare = new StringBuilder();-->
                var sql = new StringBuilder();
                string maxtop = BaseSettings.SelectTopMaxCount.ToString();
                sql.Append(@"select ");
                <xsl:if test="bv:extfilters/bv:filter[@isDistinct='true']">
                if (false
                  <xsl:for-each select="bv:extfilters/bv:filter[@isDistinct='true']">
                    <xsl:for-each select="bv:where/bv:expr">
                      || filters.Contains("<xsl:value-of select="@param" />")
                    </xsl:for-each>
                  </xsl:for-each>
                  ) sql.Append(@"distinct ");
                </xsl:if>
                sql.Append(@"top ");
                sql.Append(maxtop);
                sql.Append(@" dbo.<xsl:value-of select="$sp_get" />.* from dbo.<xsl:value-of select="$sp_get" />(<xsl:for-each select="$schema_get/schema/params/param">
                    <xsl:if test="position()>1">, </xsl:if>@<xsl:value-of select="@name"/></xsl:for-each>
                    ) ");
                <xsl:for-each select="bv:extfilters/bv:filter">
                if (<xsl:for-each select="bv:where/bv:expr">
                    <xsl:if test="position()>1"> || </xsl:if>filters.Contains("<xsl:value-of select="@param" />")</xsl:for-each>)
                {
                    <xsl:choose>
                      <xsl:when test="bv:join">
                    sql.Append(" " + @"<xsl:value-of select="bv:join" />");
                      </xsl:when>
                      <xsl:when test="bv:join2">
                        <xsl:for-each select="bv:join2">
                    if (<xsl:for-each select="bv:params/bv:param">
                          <xsl:if test="position()>1"> || </xsl:if>filters.Contains("<xsl:value-of select="@name" />")</xsl:for-each>)
                    {
                      sql.Append(" " + @"<xsl:value-of select="bv:text" />");
                    }
                        </xsl:for-each>
                      </xsl:when>
                    </xsl:choose>
                }
                </xsl:for-each>
                <!--xsl:if test="$filter_object != ''">
                if (ModelUserContext.IsWebContext &amp;&amp; EidssSiteContext.Instance.SiteType == SiteType.TLVL)
                {
                    sql.Append(" " + @"inner join tfl<xsl:value-of select="$filter_object"  />Filtered f on f.idf<xsl:value-of select="$filter_object"  /> = <xsl:value-of select="$sp_get" />.<xsl:value-of select="msxsl:node-set($tablekeys)/keys/key[1]/@name" /> and f.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString());
                }
                </xsl:if-->
                sql.Append(" where 0 = 0");
                <xsl:if test="$filter_object != ''">
                if (EidssSiteContext.Instance.SiteType == SiteType.TLVL)
                {
                    sql.Append(@" and exists (select * from  tfl<xsl:value-of select="$filter_object"  />Filtered f inner join tflSiteToSiteGroup on tflSiteToSiteGroup.idfSiteGroup = f.idfSiteGroup and tflSiteToSiteGroup.idfsSite = " + EidssSiteContext.Instance.SiteID.ToString() + " where f.idf<xsl:value-of select="$filter_object" /> = <xsl:value-of select="$sp_get" />.<xsl:value-of select="msxsl:node-set($tablekeys)/keys/key[1]/@name" />)");
                }
                </xsl:if>
                <xsl:for-each select="bv:extfilters/bv:filter">
                    <xsl:for-each select="bv:where/bv:expr">
                        <xsl:choose>
                            <xsl:when test="@lambda">
                if (filters.Contains("<xsl:value-of select="@param" />"))
                    sql.AppendFormat(" and " + new Func&lt;string&gt;(<xsl:value-of select="@lambda" />)());
                            </xsl:when>
                            <xsl:otherwise>
                if (filters.Contains("<xsl:value-of select="@param" />"))
                {
                    sql.AppendFormat(" and (");
                    <xsl:choose>
                        <xsl:when test="@range='true'">
                    for (int i = 0; i &lt; filters.Count("<xsl:value-of select="@param" />"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("<xsl:value-of select="@param" />") ? " or " : " and ");
                        sql.AppendFormat("<xsl:value-of select="@value" />_{1}", filters.Operation("<xsl:value-of select="@param" />", i), i);
                    }
                        </xsl:when>
                        <xsl:otherwise>
                    if (filters.Count("<xsl:value-of select="@param" />") == 1)
                    {
                        sql.AppendFormat("<xsl:value-of select="@value" />", filters.Operation("<xsl:value-of select="@param" />"));
                    }
                    else
                    {
                        for (int i = 0; i &lt; filters.Count("<xsl:value-of select="@param" />"); i++)
                        {
                            if (i > 0) 
                              sql.AppendFormat(filters.IsOr("<xsl:value-of select="@param" />") ? " or " : " and ");
                            sql.AppendFormat("<xsl:value-of select="substring-before(@value, concat('@', @param))" /><xsl:value-of select="concat('@', @param)" />_{1}<xsl:value-of select="substring-after(@value, concat('@', @param))" />", filters.Operation("<xsl:value-of select="@param" />", i), i);
                        }
                    }
                        </xsl:otherwise>
                    </xsl:choose>
                    sql.AppendFormat(")");
                }
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:for-each>
                </xsl:for-each>
                <xsl:variable name="searchpanel" select="bv:searchpanel" />
                <xsl:variable name="extfilters" select="bv:extfilters" />
                <xsl:for-each select="$columns/column">
                  <xsl:variable name="colname" select="@name" />
                  <xsl:if test="not($extfilters/bv:filter/bv:where/bv:expr[@param = $colname])">
                if (filters.Contains("<xsl:value-of select="@name" />"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i &lt; filters.Count("<xsl:value-of select="@name" />"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("<xsl:value-of select="@name" />") ? " or " : " and ");
                        <xsl:choose>
                            <xsl:when test="@type='DateTime' or @type='DateTime?'">
                        <!--sqlDeclare.AppendFormat("declare @<xsl:value-of select="@name" />_{1}_ datetime\r\nselect @<xsl:value-of select="@name" />_{1}_=@<xsl:value-of select="@name" />_{1}\r\n", filters.Operation("<xsl:value-of select="@name" />", i), i);-->
                        sql.AppendFormat("CONVERT(NVARCHAR(8), <xsl:value-of select="$sp_get" />.<xsl:value-of select="@name" />, 112) {0} CONVERT(NVARCHAR(8), @<xsl:value-of select="@name" />_{1}, 112)", filters.Operation("<xsl:value-of select="@name" />", i), i);
                            </xsl:when>
                            <xsl:when test="@type='long' or @type='long?' or @type='Int64' or @type='Int64?' or @type='int' or @type='int?' or @type='Int32' or @type='Int32?'">
                        <!--sqlDeclare.AppendFormat("declare @<xsl:value-of select="@name" />_{1}_ bigint\r\nselect @<xsl:value-of select="@name" />_{1}_=@<xsl:value-of select="@name" />_{1}\r\n", filters.Operation("<xsl:value-of select="@name" />", i), i);-->
                        if (filters.Operation("<xsl:value-of select="@name" />", i) == "&amp;")
                          sql.AppendFormat("(isnull(<xsl:value-of select="$sp_get" />.<xsl:value-of select="@name" />,0) {0} @<xsl:value-of select="@name" />_{1} = @<xsl:value-of select="@name" />_{1})", filters.Operation("<xsl:value-of select="@name" />", i), i);
                        else
                          sql.AppendFormat("isnull(<xsl:value-of select="$sp_get" />.<xsl:value-of select="@name" />,0) {0} @<xsl:value-of select="@name" />_{1}", filters.Operation("<xsl:value-of select="@name" />", i), i);
                            </xsl:when>
                            <xsl:otherwise>
                        <!--sqlDeclare.AppendFormat("declare @<xsl:value-of select="@name" />_{1}_ nvarchar(1024)\r\nselect @<xsl:value-of select="@name" />_{1}_=@<xsl:value-of select="@name" />_{1}\r\n", filters.Operation("<xsl:value-of select="@name" />", i), i);-->
                        sql.AppendFormat("<xsl:value-of select="$sp_get" />.<xsl:value-of select="@name" /> {0} @<xsl:value-of select="@name" />_{1}", filters.Operation("<xsl:value-of select="@name" />", i), i);
                            </xsl:otherwise>
                        </xsl:choose>
                    }
                    sql.AppendFormat(")");
                }
                  </xsl:if>
                </xsl:for-each>
                <xsl:choose>
                  <xsl:when test="bv:grid/@orderby">
                sql.Append(" order by <xsl:value-of select="bv:grid/@orderby"/> ");
                  </xsl:when>
                  <xsl:otherwise>
                if (serverSort &amp;&amp; sorts != null &amp;&amp; sorts.Length > 0)
                {
                    sql.Append(" order by");
                    bool bFirst = true;
                        foreach(var sort in sorts)
                        {
                            sql.Append((bFirst ? " " : ", ") + sort.Key + " " + (sort.Value == ListSortDirection.Ascending ? "ASC" : "DESC"));
                            bFirst = false;
                        }
                }
                  </xsl:otherwise>
                </xsl:choose>

                bool bTransactionStarted = false;
                try
                {
                    if (!manager.IsTransactionStarted)
                    {
                        bTransactionStarted = true;
                        manager.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                    }
                    <!--sql.Insert(0, sqlDeclare);-->
                    sql.Append(" option (OPTIMIZE FOR UNKNOWN)");
                    manager
                        .SetCommand(sql.ToString()<xsl:for-each select="$schema_get/schema/params/param[@name!=$langid]">
                            , manager.Parameter("@<xsl:value-of select="@name"/>", <xsl:value-of select="@name"/>)</xsl:for-each>
                            <xsl:if test="$schema_get/schema/params/param[@name=$langid]">
                            , manager.Parameter("@<xsl:value-of select="$langid"/>", ModelUserContext.CurrentLanguage)
                            </xsl:if>
                        );
                    <xsl:for-each select="bv:searchpanel/bv:item[@isParam='true']">
                    if (filters.Contains("<xsl:value-of select="@name" />"))
                        <!--xsl:choose>
                            <xsl:when test="@range='true'">
                        for (int i = 0; i &lt; filters.Count("<xsl:value-of select="@name" />"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@<xsl:value-of select="@name"/>_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("<xsl:value-of select="@name" />", i), filters.Value("<xsl:value-of select="@name" />", i))));
                            </xsl:when>
                            <xsl:otherwise-->
                        if (filters.Count("<xsl:value-of select="@name" />") == 1)
                        {
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@<xsl:value-of select="@name"/>", ParsingHelper.CorrectLikeValue(filters.Operation("<xsl:value-of select="@name" />"), filters.Value("<xsl:value-of select="@name" />"))));
                        }
                        else
                        {
                            for (int i = 0; i &lt; filters.Count("<xsl:value-of select="@name" />"); i++)
                                manager.SelectCommand.Parameters.Add(manager.InputParameter("@<xsl:value-of select="@name"/>_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("<xsl:value-of select="@name" />", i), filters.Value("<xsl:value-of select="@name" />", i))));
                        }
                            <!--/xsl:otherwise>
                        </xsl:choose-->
                    </xsl:for-each>
                    <xsl:for-each select="$columns/column">
                      <xsl:variable name="colname" select="@name" />
                      <xsl:if test="not($extfilters/bv:filter/bv:where/bv:expr[@param = $colname])">
                    if (filters.Contains("<xsl:value-of select="@name" />"))
                        for (int i = 0; i &lt; filters.Count("<xsl:value-of select="@name" />"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@<xsl:value-of select="@name"/>_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("<xsl:value-of select="@name" />", i), filters.Value("<xsl:value-of select="@name" />", i))));
                      </xsl:if>
                    </xsl:for-each>
                    List&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt; objs = manager.ExecuteList&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                        
                        // restore default isolation level for pool connection
                        manager.BeginTransaction();
                        manager.TestConnection();
                        manager.CommitTransaction();
                    }
                    ListSelected(manager, objs);
                    return objs;
                }
                catch(DataException e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                        
                        // restore default isolation level for pool connection
                        manager.BeginTransaction();
                        manager.TestConnection();
                        manager.RollbackTransaction();
                    }
                    throw DbModelException.Create(null, e);
                }
            }
            partial void ListSelected(DbManagerProxy manager, List&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt; objs);
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                <xsl:choose>
                    <xsl:when test="$sp_count!=''">
                return _selectCount(manager);
                    </xsl:when>
                    <xsl:otherwise>
                return null;
                    </xsl:otherwise>
                </xsl:choose>
            }
        <xsl:if test="$sp_count!=''">
            [SprocName("<xsl:value-of select="$sp_count" />")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        </xsl:if>
    </xsl:template>
    
</xsl:stylesheet>
