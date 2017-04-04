<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:bv="urn:schemas-bv:objectmodel"
	xmlns:util="urn:util">

    <xsl:import href="globals.xslt" />
    <xsl:import href="utils.xslt" />
    <xsl:import href="extenders.xslt" />
    <xsl:import href="validators.xslt" />

    <xsl:template name="can-delete">
        <xsl:param name="tablename" />
        <xsl:param name="sp_candelete" />
        <xsl:if test="$sp_candelete!=''">
            <xsl:variable name="schema_candelete" select="util:SchemaXml(string($sp_candelete))" />
            <xsl:variable name="params_candelete" select="$schema_candelete/schema/params" />
            [SprocName("<xsl:value-of select="$sp_candelete" />")]
            protected abstract void _canDelete(DbManagerProxy manager<xsl:for-each select="$schema_candelete/schema/params/param">
                <xsl:choose>
                    <xsl:when test="@direction='In'">, <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/></xsl:when>
                    <xsl:otherwise>, out <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/></xsl:otherwise>
                </xsl:choose>
            </xsl:for-each>
                );
        </xsl:if>
    </xsl:template>
    <xsl:template name="post-insert">
        <xsl:param name="langid" />
        <xsl:param name="tablename" />
        <xsl:param name="sp_insert" />
        <xsl:param name="sp_insert_predicate" />
        <xsl:if test="$sp_insert!=''">
            <xsl:variable name="schema_insert" select="util:SchemaXml(string($sp_insert))" />
            <xsl:variable name="params_insert" select="$schema_insert/schema/params" />
            <xsl:variable name="sp_insert_lang" select="$schema_insert/schema/params/param[@name=$langid]" />
            [SprocName("<xsl:value-of select="$sp_insert" />")]
            protected abstract void _postInsert(DbManagerProxy manager, <xsl:if test="$sp_insert_lang">string <xsl:value-of select="$langid"/>, </xsl:if>
                [Direction.InputOutput(<xsl:for-each select="$schema_insert/schema/params/param[@direction='InOut']">
                    <xsl:if test="position()>1">, </xsl:if>"<xsl:value-of select="@name"/>"</xsl:for-each>)] <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj);
            protected void _postInsertPredicate(DbManagerProxy manager, <xsl:if test="$sp_insert_lang">string <xsl:value-of select="$langid"/>, </xsl:if>
                [Direction.InputOutput(<xsl:for-each select="$schema_insert/schema/params/param[@direction='InOut']">
                    <xsl:if test="position()>1">, </xsl:if>"<xsl:value-of select="@name"/>"</xsl:for-each>)] <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                <xsl:if test="$sp_insert_predicate!=''">
                if (new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="$sp_insert_predicate" />)(obj))
                {
                </xsl:if>
                _postInsert(manager, <xsl:if test="$sp_insert_lang"><xsl:value-of select="$langid"/>, </xsl:if>obj);
                <xsl:if test="$sp_insert_predicate!=''">
                }
                </xsl:if>
            }
        </xsl:if>
    </xsl:template>
    <xsl:template name="post-update">
        <xsl:param name="langid" />
        <xsl:param name="tablename" />
        <xsl:param name="sp_update" />
        <xsl:param name="sp_update_predicate" />
        <xsl:if test="$sp_update!=''">
            <xsl:variable name="schema_update" select="util:SchemaXml(string($sp_update))" />
            <xsl:variable name="params_update" select="$schema_update/schema/params" />
            <xsl:variable name="sp_update_lang" select="$schema_update/schema/params/param[@name=$langid]" />
            [SprocName("<xsl:value-of select="$sp_update" />")]
            protected abstract void _postUpdate(DbManagerProxy manager, <xsl:if test="$sp_update_lang">string <xsl:value-of select="$langid"/>, </xsl:if>
                [Direction.InputOutput(<xsl:for-each select="$schema_update/schema/params/param[@direction='InOut']">
                    <xsl:if test="position()>1">, </xsl:if>"<xsl:value-of select="@name"/>"</xsl:for-each>)] <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj);
            protected void _postUpdatePredicate(DbManagerProxy manager, <xsl:if test="$sp_update_lang">string <xsl:value-of select="$langid"/>, </xsl:if>
                [Direction.InputOutput(<xsl:for-each select="$schema_update/schema/params/param[@direction='InOut']">
                    <xsl:if test="position()>1">, </xsl:if>"<xsl:value-of select="@name"/>"</xsl:for-each>)] <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                <xsl:if test="$sp_update_predicate!=''">
                if (new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="$sp_update_predicate" />)(obj))
                {
                </xsl:if>
                _postUpdate(manager, <xsl:if test="$sp_update_lang"><xsl:value-of select="$langid"/>, </xsl:if>obj);
                <xsl:if test="$sp_update_predicate!=''">
                }
                </xsl:if>
            }
        </xsl:if>
    </xsl:template>
    <xsl:template name="post-delete">
        <xsl:param name="tablename" />
        <xsl:param name="sp_delete" />
        <xsl:param name="sp_delete_predicate" />
        <xsl:if test="$sp_delete!=''">
            <xsl:variable name="schema_delete" select="util:SchemaXml(string($sp_delete))" />
            <xsl:variable name="params_delete" select="$schema_delete/schema/params" />
            [SprocName("<xsl:value-of select="$sp_delete" />")]
            protected abstract void _postDelete(DbManagerProxy manager<xsl:for-each select="$schema_delete/schema/params/param">
                , <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/>
            </xsl:for-each>
                );
            protected void _postDeletePredicate(DbManagerProxy manager<xsl:for-each select="$schema_delete/schema/params/param">
                , <xsl:value-of select="@type"/><xsl:text> </xsl:text><xsl:value-of select="@name"/>
            </xsl:for-each>
                )
            {
                <xsl:if test="$sp_delete_predicate!=''">
                if (new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="$sp_delete_predicate" />)(obj))
                {
                </xsl:if>
                _postDelete(manager<xsl:for-each select="$schema_delete/schema/params/param">, <xsl:value-of select="@name"/></xsl:for-each>);
                <xsl:if test="$sp_delete_predicate!=''">
                }
                </xsl:if>
            }
        </xsl:if>
    </xsl:template>
    <xsl:template name="post">
        <xsl:param name="langid" />
        <xsl:param name="tablename" />
        <xsl:param name="namespace" />
        <xsl:param name="hacodable" />
        <xsl:param name="tablekeys" />
        <xsl:param name="sp_candelete" />
        <xsl:param name="sp_candelete_type" />
        <xsl:param name="msg_candelete" />
        <xsl:param name="sp_delete" />
        <xsl:param name="sp_post" />
        <xsl:param name="sp_insert" />
        <xsl:param name="sp_update" />
        <xsl:param name="sp_type" />
        <xsl:param name="sp_post_predicate" />
        <xsl:param name="sp_post_lockNotify" />

        <xsl:variable name="table" select="." />

        <xsl:if test="contains($sp_type,'detailone')">
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        </xsl:if>

        <xsl:choose>
            <xsl:when test="contains($sp_type,'fnlist') and $sp_delete!=''">
            </xsl:when>
            <xsl:when test="$sp_post='' and $sp_insert='' and $sp_update=''">
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            </xsl:when>
        </xsl:choose>
        
        <xsl:if test="$sp_post!='' or $sp_insert!='' or $sp_update!='' or (contains($sp_type,'fnlist') and $sp_delete!='')">
            <xsl:variable name="schema_post" select="util:SchemaXml(string($sp_post))" />
            <xsl:variable name="sp_post_action" select="$schema_post/schema/params/param[@name='Action']" />
            <xsl:variable name="sp_post_lang" select="$schema_post/schema/params/param[@name=$langid]" />

            <xsl:variable name="schema_insert" select="util:SchemaXml(string($sp_insert))" />
            <xsl:variable name="sp_insert_lang" select="$schema_insert/schema/params/param[@name=$langid]" />
            <xsl:variable name="schema_update" select="util:SchemaXml(string($sp_update))" />
            <xsl:variable name="sp_update_lang" select="$schema_update/schema/params/param[@name=$langid]" />

            <xsl:if test="$sp_post!=''">
            [SprocName("<xsl:value-of select="$sp_post" />")]
            protected abstract void _post(DbManagerProxy manager, <xsl:if test="$sp_post_action">int Action, </xsl:if><xsl:if test="$sp_post_lang">string <xsl:value-of select="$langid"/>, </xsl:if>
                [Direction.InputOutput(<xsl:for-each select="$schema_post/schema/params/param[@direction='InOut']">
                    <xsl:if test="position()>1">, </xsl:if>"<xsl:value-of select="@name"/>"</xsl:for-each>)] <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj);
            protected void _postPredicate(DbManagerProxy manager, <xsl:if test="$sp_post_action">int Action, </xsl:if><xsl:if test="$sp_post_lang">string <xsl:value-of select="$langid"/>, </xsl:if>
                [Direction.InputOutput(<xsl:for-each select="$schema_post/schema/params/param[@direction='InOut']">
                    <xsl:if test="position()>1">, </xsl:if>"<xsl:value-of select="@name"/>"</xsl:for-each>)] <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                <xsl:if test="$sp_post_predicate!=''">
                if (new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="$sp_post_predicate" />)(obj))
                {
                </xsl:if>
                <xsl:if test="$sp_post_lockNotify='true'">
                obj.LockNotifyChanges();
                try {
                </xsl:if>
                _post(manager, <xsl:if test="$sp_post_action">Action, </xsl:if><xsl:if test="$sp_post_lang"><xsl:value-of select="$langid"/>, </xsl:if>obj);
                <xsl:if test="$sp_post_lockNotify='true'">
                } finally {
                  obj.UnlockNotifyChanges();
                }
                </xsl:if>
                <xsl:if test="$sp_post_predicate!=''">
                }
                </xsl:if>
            }
            </xsl:if>
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber &lt; iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> bo = obj as <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />;
                        <xsl:if test="bv:properties/@permissionObject">
                        if (!bo.IsNew &amp;&amp; bo.IsMarkedToDelete) // delete
                        {
                            if (!CanDelete)
                                throw new PermissionException("<xsl:value-of select="bv:properties/@permissionObject" />", "Delete");
                        }
                        else if (bo.IsNew &amp;&amp; !bo.IsMarkedToDelete) // insert
                        {
                            if (!CanInsert)
                                throw new PermissionException("<xsl:value-of select="bv:properties/@permissionObject" />", "Insert");
                        }
                        else if (!bo.IsMarkedToDelete &amp;&amp; bo.HasChanges) // update
                        {
                            if (!CanUpdate)
                                throw new PermissionException("<xsl:value-of select="bv:properties/@permissionObject" />", "Update");
                        }
                        </xsl:if>
                        <xsl:if test="bv:properties/@permissionAction">
                        if (!CanExecute("<xsl:value-of select="bv:properties/@permissionAction" />"))
                            throw new PermissionException("<xsl:value-of select="bv:properties/@permissionAction" />", "Execute");
                        </xsl:if>

                        <xsl:if test="bv:properties">
                        long mainObject = bo.<xsl:value-of select="msxsl:node-set($tablekeys)/keys/key[1]/@name" />;
                        </xsl:if>
                        if (!bo.IsNew &amp;&amp; bo.IsMarkedToDelete) // delete
                        {
                        }
                        else if (bo.IsNew &amp;&amp; !bo.IsMarkedToDelete) // insert
                        {
                            <xsl:for-each select="bv:properties/bv:events/bv:create">
                              <xsl:if test="@predicate">
                            if (new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="@predicate" />)(bo))
                              </xsl:if>
                                manager.SetEventParams(<xsl:choose><xsl:when test="@startReplication"><xsl:value-of select="@startReplication"/></xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>, new object[] { EventType.<xsl:value-of select="@name" />, <xsl:choose><xsl:when test="@mainobj">bo.<xsl:value-of select="@mainobj"/></xsl:when><xsl:otherwise>mainObject</xsl:otherwise></xsl:choose>, "<xsl:value-of select="@addinfo"/>" });
                            </xsl:for-each>
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            <xsl:for-each select="bv:properties/bv:events/bv:change">
                              <xsl:if test="@fields">
                              <xsl:variable name="fields" select="util:ExpandXml('field,field1', string(@fields), string(@fields))" />
                            if (<xsl:for-each select="$fields/keys/key"><xsl:if test="position() > 1">||</xsl:if>
                                bo.<xsl:value-of select="@field" /> != bo.<xsl:value-of select="@field" />_Original
                              </xsl:for-each>)
                              </xsl:if>
                              <xsl:if test="@predicate">
                            if (new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="@predicate" />)(bo))
                              </xsl:if>
                                manager.SetEventParams(<xsl:choose><xsl:when test="@startReplication"><xsl:value-of select="@startReplication"/></xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>, new object[] { EventType.<xsl:value-of select="@name" />, <xsl:choose><xsl:when test="@mainobj">bo.<xsl:value-of select="@mainobj"/></xsl:when><xsl:otherwise>mainObject</xsl:otherwise></xsl:choose>, "<xsl:value-of select="@addinfo"/>" });
                            </xsl:for-each>
                        }

                        if (!manager.IsTransactionStarted)
                        {
                            <xsl:if test="bv:properties">
                            <xsl:if test="bv:properties/@auditObject">
                            eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                            </xsl:if>
                            <xsl:if test="bv:properties/bv:lookupcache">
                              eidss.model.Enums.EventType eventType = eidss.model.Enums.EventType.RaiseReferenceCacheChange;
                              <xsl:for-each select="bv:properties/bv:lookupcache/bv:item">
                              manager.SetEventParams(false, "<xsl:value-of select="@name" />", new object[] { eventType, null, "<xsl:value-of select="@name" />" });
                              </xsl:for-each>
                            </xsl:if>
                            if (!bo.IsNew &amp;&amp; bo.IsMarkedToDelete) // delete
                            {
                                <xsl:if test="bv:properties/@auditObject">
                                auditEventType = eidss.model.Enums.AuditEventType.daeDelete;
                                </xsl:if>
                            }
                            else if (bo.IsNew &amp;&amp; !bo.IsMarkedToDelete) // insert
                            {
                                <xsl:if test="bv:properties/@auditObject">
                                auditEventType = eidss.model.Enums.AuditEventType.daeCreate;
                                </xsl:if>
                            }
                            else if (!bo.IsMarkedToDelete) // update
                            {
                                <xsl:if test="bv:properties/@auditObject">
                                auditEventType = eidss.model.Enums.AuditEventType.daeEdit;
                                </xsl:if>
                            }
                            <xsl:if test="bv:properties/@auditObject">
                            eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.<xsl:value-of select="bv:properties/@auditObject" />;
                            eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.<xsl:value-of select="bv:properties/@auditTable" />;
                            manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                            </xsl:if>
                            </xsl:if>
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bChildObject);
                        if (bTransactionStarted)
                        {
                            if (bSuccess)
                            {
                                obj.DeepAcceptChanges();
                                manager.CommitTransaction();
                                <xsl:if test="bv:properties/@lookupcachename">
                                LookupManager.ClearByTable("<xsl:value-of select="bv:properties/@lookupcachename" />");
                                </xsl:if>
                            }
                            else
                            {
                                manager.RollbackTransaction();
                            }
                            <xsl:if test="$table/@auditObject">
                            manager.AuditParams = null;
                            </xsl:if>
                        }
                        if (bSuccess &amp;&amp; bo.IsNew &amp;&amp; !bo.IsMarkedToDelete) // insert
                        {
                            bo.m_IsNew = false;
                        }
                        if (bSuccess &amp;&amp; bTransactionStarted)
                        {
                            bo.OnAfterPost();
                        }
                        
                        break;
                    }
                    catch(Exception e)
                    {
                        if (bTransactionStarted)
                        {
                            manager.RollbackTransaction();
                            <xsl:if test="$table/@auditObject">
                            manager.AuditParams = null;
                            </xsl:if>
                            if (DbModelException.IsDeadlockException(e))
                            {
                                System.Threading.Thread.Sleep(BaseSettings.DeadlockDelay);
                                continue;
                            }
                        }
                    
                        if (e is DataException)
                        {
                            throw DbModelException.Create(obj, e as DataException);
                        }
                        if (e is System.Data.SqlClient.SqlException)
                        {
                            throw DbModelException.Create(obj, e as System.Data.SqlClient.SqlException);
                        }
                        else 
                            throw;
                    }
                }
                return bSuccess;
            }
            private bool _PostNonTransaction(DbManagerProxy manager, <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew &amp;&amp; obj.IsMarkedToDelete) // delete
                {
            <xsl:choose>
                <xsl:when test="$table/bv:deleteorder/bv:item[@name]">
                    <xsl:for-each select="$table/bv:deleteorder/bv:item">
                        <xsl:choose>
                            <xsl:when test="@name='this'">
                    if (!ValidateCanDelete(manager, obj)) return false;
                                <xsl:choose>
                                    <xsl:when test="$sp_post_action">
                    _postPredicate(manager, 8<xsl:if test="$sp_post_lang">, ModelUserContext.CurrentLanguage</xsl:if>, obj);
                                    </xsl:when>
                                    <xsl:otherwise>
                                        <xsl:if test="$sp_delete!=''">
                    _postDeletePredicate(manager<xsl:for-each select="msxsl:node-set($tablekeys)/keys/key">
                        , obj.<xsl:value-of select="@name"/></xsl:for-each>
                        );
                                        </xsl:if>
                                    </xsl:otherwise>
                                </xsl:choose>
                            </xsl:when>
                            <xsl:otherwise>
                                <xsl:variable name="post_name" select="@name" />
                                <xsl:variable name="post_type" select="$table/bv:relations/bv:relation[@name=$post_name]/@type" />
                                <xsl:choose>
                                    <xsl:when test="$post_type='child'">
                    if (obj.<xsl:value-of select="$post_name" /> != null)
                    {
                        foreach (var i in obj.<xsl:value-of select="$post_name" />)
                        {
                            i.MarkToDelete();
                            if (!<xsl:value-of select="@name"/>Accessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                    </xsl:when>
                                    <xsl:otherwise>
                    if (obj.<xsl:value-of select="$post_name" /> != null)
                    {
                        obj.<xsl:value-of select="$post_name" />.MarkToDelete();
                        if (!<xsl:value-of select="@name"/>Accessor.Post(manager, obj.<xsl:value-of select="$post_name" />, true))
                            return false;
                    }
                                    </xsl:otherwise>
                                </xsl:choose>
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:for-each>
                </xsl:when>
                <xsl:otherwise>
                    <xsl:choose>
                        <xsl:when test="$table/bv:postorder/bv:item[@name]">
                            <xsl:for-each select="$table/bv:postorder/bv:item">
                                <xsl:choose>
                                    <xsl:when test="@name='this'">
                    if (!ValidateCanDelete(manager, obj)) return false;
                                        <xsl:choose>
                                            <xsl:when test="$sp_post_action">
                    _postPredicate(manager, 8<xsl:if test="$sp_post_lang">, ModelUserContext.CurrentLanguage</xsl:if>, obj);
                                            </xsl:when>
                                            <xsl:otherwise>
                                                <xsl:if test="$sp_delete!=''">
                    _postDeletePredicate(manager<xsl:for-each select="msxsl:node-set($tablekeys)/keys/key">
                        , obj.<xsl:value-of select="@name"/></xsl:for-each>
                        );
                                                </xsl:if>
                                            </xsl:otherwise>
                                        </xsl:choose>
                                    </xsl:when>
                                    <xsl:otherwise>
                                        <xsl:variable name="post_name" select="@name" />
                                        <xsl:variable name="post_type" select="$table/bv:relations/bv:relation[@name=$post_name]/@type" />
                                        <xsl:choose>
                                            <xsl:when test="$post_type='child'">
                    if (obj.<xsl:value-of select="$post_name" /> != null)
                    {
                        foreach (var i in obj.<xsl:value-of select="$post_name" />)
                        {
                            i.MarkToDelete();
                            if (!<xsl:value-of select="@name"/>Accessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            </xsl:when>
                                            <xsl:otherwise>
                    if (obj.<xsl:value-of select="$post_name" /> != null)
                    {
                        obj.<xsl:value-of select="$post_name" />.MarkToDelete();
                        if (!<xsl:value-of select="@name"/>Accessor.Post(manager, obj.<xsl:value-of select="$post_name" />, true))
                            return false;
                    }
                                            </xsl:otherwise>
                                        </xsl:choose>
                                    </xsl:otherwise>
                                </xsl:choose>
                            </xsl:for-each>
                        </xsl:when>
                        <xsl:otherwise>
                    if (!ValidateCanDelete(manager, obj)) return false;
                            <xsl:choose>
                                <xsl:when test="$sp_post_action">
                    _postPredicate(manager, 8<xsl:if test="$sp_post_lang">, ModelUserContext.CurrentLanguage</xsl:if>, obj);
                                </xsl:when>
                                <xsl:otherwise>
                                    <xsl:if test="$sp_delete!=''">
                    _postDeletePredicate(manager<xsl:for-each select="msxsl:node-set($tablekeys)/keys/key">
                        , obj.<xsl:value-of select="@name"/></xsl:for-each>
                        );
                                    </xsl:if>
                                </xsl:otherwise>
                            </xsl:choose>
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:otherwise>
            </xsl:choose>
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            <xsl:if test="$sp_post!='' or $sp_insert!='' or $sp_update!=''">
                    // posting extenters - begin<xsl:for-each select="bv:extenders/bv:posting/*">
                        <xsl:call-template name="generate-extender">
                            <xsl:with-param name="tablename" select="$tablename" />
                            <xsl:with-param name="hacodable" select="$hacodable" />
                        </xsl:call-template>
                    </xsl:for-each>
                    // posting extenters - end
            <xsl:choose>
                <xsl:when test="$table/bv:postorder/bv:item[@name]">
                    <xsl:for-each select="$table/bv:postorder/bv:item">
                        <xsl:choose>
                            <xsl:when test="@name='this'">
                                <xsl:choose>
                                    <xsl:when test="$sp_insert!='' and $sp_update!=''">
                    if (obj.IsNew &amp;&amp; !obj.IsMarkedToDelete &amp;&amp; obj.HasChanges)
                        _postInsertPredicate(manager<xsl:if test="$sp_insert_lang">, ModelUserContext.CurrentLanguage</xsl:if>, obj);
                    else if (!obj.IsNew &amp;&amp; !obj.IsMarkedToDelete &amp;&amp; obj.HasChanges)
                        _postUpdatePredicate(manager<xsl:if test="$sp_update_lang">, ModelUserContext.CurrentLanguage</xsl:if>, obj);
                                    </xsl:when>
                                    <xsl:when test="$sp_post_action">
                    if (obj.IsNew &amp;&amp; !obj.IsMarkedToDelete &amp;&amp; obj.HasChanges)
                        _postPredicate(manager, 4<xsl:if test="$sp_post_lang">, ModelUserContext.CurrentLanguage</xsl:if>, obj);
                    else if (!obj.IsNew &amp;&amp; !obj.IsMarkedToDelete &amp;&amp; obj.HasChanges)
                        _postPredicate(manager, 16<xsl:if test="$sp_post_lang">, ModelUserContext.CurrentLanguage</xsl:if>, obj);
                                    </xsl:when>
                                    <xsl:otherwise>
                    if (!obj.IsMarkedToDelete &amp;&amp; bHasChanges)
                        _postPredicate(manager<xsl:if test="$sp_post_lang">, ModelUserContext.CurrentLanguage</xsl:if>, obj);
                                    </xsl:otherwise>
                                </xsl:choose>
                            </xsl:when>
                            <xsl:otherwise>
                                <xsl:variable name="post_name" select="@name" />
                                <xsl:variable name="post_type" select="$table/bv:relations/bv:relation[@name=$post_name]/@type" />
                                <xsl:choose>
                                    <xsl:when test="$post_type='child'">
                    if (obj.IsNew)
                    {
                        if (obj.<xsl:value-of select="$post_name" /> != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.<xsl:value-of select="$post_name" />)
                                if (!<xsl:value-of select="@name"/>Accessor.Post(manager, i, true))
                                    return false;
                            obj.<xsl:value-of select="$post_name" />.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.<xsl:value-of select="$post_name" />.Remove(c));
                            obj.<xsl:value-of select="$post_name" />.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._<xsl:value-of select="$post_name" /> != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._<xsl:value-of select="$post_name" />)
                                if (!<xsl:value-of select="@name"/>Accessor.Post(manager, i, true))
                                    return false;
                            obj._<xsl:value-of select="$post_name" />.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._<xsl:value-of select="$post_name" />.Remove(c));
                            obj._<xsl:value-of select="$post_name" />.AcceptChanges();
                        }
                    }
                                    </xsl:when>
                                    <xsl:otherwise>
                    if (obj.IsNew)
                    {
                        if (obj.<xsl:value-of select="$post_name" /> != null) // forced load potential lazy subobject for new object
                            if (!<xsl:value-of select="@name"/>Accessor.Post(manager, obj.<xsl:value-of select="$post_name" />, true))
                                return false;
                    }
                    else
                    {
                        if (obj._<xsl:value-of select="$post_name" /> != null) // do not load lazy subobject for existing object
                            if (!<xsl:value-of select="@name"/>Accessor.Post(manager, obj.<xsl:value-of select="$post_name" />, true))
                                return false;
                    }
                                    </xsl:otherwise>
                                </xsl:choose>
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:for-each>
                </xsl:when>
                <xsl:otherwise>
                    <xsl:choose>
                        <xsl:when test="$sp_insert!='' and $sp_update!=''">
                    if (obj.IsNew &amp;&amp; !obj.IsMarkedToDelete &amp;&amp; obj.HasChanges)
                        _postInsertPredicate(manager<xsl:if test="$sp_insert_lang">, ModelUserContext.CurrentLanguage</xsl:if>, obj);
                    else if (!obj.IsNew &amp;&amp; !obj.IsMarkedToDelete &amp;&amp; obj.HasChanges)
                        _postUpdatePredicate(manager<xsl:if test="$sp_update_lang">, ModelUserContext.CurrentLanguage</xsl:if>, obj);
                        </xsl:when>
                        <xsl:when test="$sp_post_action">
                    if (obj.IsNew &amp;&amp; !obj.IsMarkedToDelete &amp;&amp; obj.HasChanges)
                        _postPredicate(manager, 4<xsl:if test="$sp_post_lang">, ModelUserContext.CurrentLanguage</xsl:if>, obj);
                    else if (!obj.IsNew &amp;&amp; !obj.IsMarkedToDelete &amp;&amp; obj.HasChanges)
                        _postPredicate(manager, 16<xsl:if test="$sp_post_lang">, ModelUserContext.CurrentLanguage</xsl:if>, obj);
                        </xsl:when>
                        <xsl:otherwise>
                    if (!obj.IsMarkedToDelete &amp;&amp; bHasChanges)
                        _postPredicate(manager<xsl:if test="$sp_post_lang">, ModelUserContext.CurrentLanguage</xsl:if>, obj);
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:otherwise>
            </xsl:choose>
                    // posted extenters - begin<xsl:for-each select="bv:extenders/bv:posted/*">
                        <xsl:call-template name="generate-extender">
                            <xsl:with-param name="tablename" select="$tablename" />
                            <xsl:with-param name="hacodable" select="$hacodable" />
                        </xsl:call-template>
                    </xsl:for-each>
                    // posted extenters - end
            </xsl:if>
                }
                //obj.AcceptChanges();
                <xsl:for-each select="bv:fields/bv:calculated[@dependonpost='yes']">
                obj.OnPropertyChanged(_str_<xsl:value-of select="@name" />);
                </xsl:for-each>
                return true;
            }
            
            public bool ValidateCanDelete(<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
            <xsl:if test="$sp_candelete!=''">
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager<xsl:for-each select="msxsl:node-set($tablekeys)/keys/key">
                            , obj.<xsl:value-of select="@name"/></xsl:for-each>
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("<xsl:choose><xsl:when test="$msg_candelete"><xsl:value-of select="$msg_candelete"/></xsl:when><xsl:otherwise>msgCantDelete</xsl:otherwise></xsl:choose>", "_on_delete", "_on_delete", null, null, ValidationEventType.<xsl:value-of select="$sp_candelete_type"/>, obj);
                        }
                     }
                }
                catch(ValidationModelException ex)
                {
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                    else
                        obj.m_IsForcedToDelete = true;
                }
            </xsl:if>
                return true;
            }
        </xsl:if>
      
            protected ValidationModelException ChainsValidate(<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                <xsl:if test="count(bv:validators/bv:chains/*) > 0">
                try
                {
                  <xsl:for-each select="bv:validators/bv:chains/bv:item">
                    <xsl:call-template name="generate-chains">
                      <xsl:with-param name="tablename" select="$tablename" />
                    </xsl:call-template>
                  </xsl:for-each>
                }
                catch(ValidationModelException ex)
                {
                    return ex;
                }
                </xsl:if>
                return null;
            }
            protected bool ChainsValidate(<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                <xsl:if test="count(bv:validators/bv:childchange/*) + count(bv:validators/bv:change/*) + count(bv:validators/bv:post/*) > 0">
                try
                {
                    if (bPostValidation)
                    {
                <xsl:for-each select="bv:validators/bv:post/*">
                    <xsl:choose>
                        <xsl:when test="@container">
                        foreach(var item in obj.<xsl:value-of select="@container"/>.Where(<xsl:value-of select="@filter"/>))
                        {
                            <xsl:call-template name="generate-validator">
                                <xsl:with-param name="tablename" select="$tablename" />
                                <xsl:with-param name="child" select="'item'" />
                            </xsl:call-template>
                        }
                        </xsl:when>
                        <xsl:otherwise>
                            <xsl:call-template name="generate-validator">
                                <xsl:with-param name="tablename" select="$tablename" />
                            </xsl:call-template>
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:for-each>
                <xsl:for-each select="bv:validators/bv:post/bv:container">
                    <xsl:choose>
                        <xsl:when test="@filter">
                        foreach(var item in obj.<xsl:value-of select="@name"/>.Where(<xsl:value-of select="@filter"/>))
                        {
                        </xsl:when>
                        <xsl:otherwise>
                        {
                            var item = obj.<xsl:value-of select="@name"/>;
                        </xsl:otherwise>
                    </xsl:choose>
                    <xsl:for-each select="*">
                        <xsl:call-template name="generate-validator">
                            <xsl:with-param name="tablename" select="$tablename" />
                            <xsl:with-param name="child" select="'item'" />
                        </xsl:call-template>
                    </xsl:for-each>
                        }
                </xsl:for-each>
                  
                    }

                    if (bChangeValidation)
                    {
                <xsl:for-each select="bv:validators/bv:childchange/bv:container">
                    <xsl:choose>
                        <xsl:when test="@filter">
                        foreach(var item in obj.<xsl:value-of select="@name"/>.Where(<xsl:value-of select="@filter"/>))
                        {
                        </xsl:when>
                        <xsl:otherwise>
                        {
                            var item = obj.<xsl:value-of select="@name"/>;
                        </xsl:otherwise>
                    </xsl:choose>
                    <xsl:for-each select="*">
                        <xsl:call-template name="generate-validator">
                            <xsl:with-param name="tablename" select="$tablename" />
                            <xsl:with-param name="child" select="'item'" />
                        </xsl:call-template>
                    </xsl:for-each>
                        }
                </xsl:for-each>
                
                <xsl:for-each select="bv:validators/bv:change/*[not(@type='Question')][not(@type='Warning')][not(@notIfPost='true')]">
                    <xsl:call-template name="generate-validator">
                        <xsl:with-param name="tablename" select="$tablename" />
                    </xsl:call-template>
                </xsl:for-each>
                    }
                    
                    if (bDeepValidation)
                    {
                <xsl:choose>
                    <xsl:when test="$table/bv:postorder/bv:item[@name]">
                        <xsl:for-each select="$table/bv:postorder/bv:item">
                            <xsl:choose>
                                <xsl:when test="@name='this'">
                                </xsl:when>
                                <xsl:otherwise>
                                    <xsl:variable name="post_name" select="@name" />
                                    <xsl:variable name="post_type" select="$table/bv:relations/bv:relation[@name=$post_name]/@type" />
                                    <xsl:variable name="validationprevicate" select="$table/bv:relations/bv:relation[@name=$post_name]/@validationprevicate" />
                                    <xsl:choose>
                                        <xsl:when test="$post_type='child'">
                        if (obj.<xsl:value-of select="$post_name" /> != null)
                            foreach (var i in obj.<xsl:value-of select="$post_name" />.Where(c => !c.IsMarkedToDelete &amp;&amp; c.HasChanges))
                                <xsl:value-of select="@name"/>Accessor.Validate(manager, i, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        </xsl:when>
                                        <xsl:otherwise>
                        if (obj.<xsl:value-of select="$post_name" /> != null<xsl:if test="$validationprevicate"> &amp;&amp; new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="$validationprevicate"/>)(obj)</xsl:if>)
                            <xsl:value-of select="@name"/>Accessor.Validate(manager, obj.<xsl:value-of select="$post_name" />, bPostValidation, bChangeValidation, bDeepValidation, true);
                                        </xsl:otherwise>
                                    </xsl:choose>
                                </xsl:otherwise>
                            </xsl:choose>
                        </xsl:for-each>
                    </xsl:when>
                    <xsl:otherwise>
                    </xsl:otherwise>
                </xsl:choose>
                    }
                }
                catch(ValidationModelException ex)
                {
                    if (bRethrowException)
                        throw;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                </xsl:if>
                return true;
            }
           
    </xsl:template>
    
</xsl:stylesheet>
