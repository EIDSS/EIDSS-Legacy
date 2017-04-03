<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
	xmlns:util="urn:util"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />
    <xsl:import href="fields.xslt" />
    <xsl:import href="relations.xslt" />
    <xsl:import href="other.xslt" />
    <xsl:import href="invisible.xslt" />
    <xsl:import href="readonly.xslt" />
    <xsl:import href="required.xslt" />
    <xsl:import href="dispose.xslt" />
    <xsl:import href="meta.xslt" />
    <xsl:import href="permissions.xslt" />
    <xsl:import href="handlers.xslt" />
    <xsl:import href="lookups.xslt" />
    <xsl:import href="extenders.xslt" />
    <xsl:import href="validators.xslt" />
    <xsl:import href="select.xslt" />
    <xsl:import href="create.xslt" />
    <xsl:import href="post.xslt" />
    <xsl:import href="web.xslt" />
    <xsl:import href="personaldata.xslt" />

    <xsl:strip-space elements="*" />

    <xsl:output method="text"/>
    <xsl:param name="param_namespace" select="''" />
    
    <xsl:variable name="namespace">
        <xsl:choose>
            <xsl:when test="$param_namespace!=''">
                <xsl:value-of select="$param_namespace" />
            </xsl:when>
            <xsl:otherwise>
                <xsl:value-of select="'bv.models.objects'" />
            </xsl:otherwise>
        </xsl:choose>
    </xsl:variable>

    <xsl:template match="/">
        <xsl:apply-templates />
    </xsl:template>

	<xsl:template match="bv:object">#pragma warning disable 0472
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Xml.Serialization;
using BLToolkit.Aspects;
using BLToolkit.DataAccess;
using BLToolkit.EditableObjects;
using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using BLToolkit.Mapping;
using BLToolkit.Reflection;
using bv.common.Configuration;
using bv.common.Enums;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model;
using bv.model.Helpers;
using bv.model.Model.Extenders;
using bv.model.Model.Core;
using bv.model.Model.Handlers;
using bv.model.Model.Validators;
using eidss.model.Core;
using eidss.model.Enums;
		<xsl:variable name="objectname" select="@name" />
        <xsl:variable name="sp_type">
            <xsl:choose>
                <xsl:when test="bv:storage/bv:get/@type">
                    <xsl:value-of select="bv:storage/bv:get/@type"/>
                </xsl:when>
                <xsl:otherwise>
                    <xsl:value-of select="'detailone'"/>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:variable>
        <xsl:variable name="filter_object">
            <xsl:value-of select="bv:storage/bv:get/@filter-object"/>
        </xsl:variable>
        <xsl:variable name="sp_count">
            <xsl:choose>
                <xsl:when test="bv:storage/bv:count/@name"><xsl:value-of select="bv:storage/bv:count/@name"/></xsl:when>
                <xsl:otherwise><xsl:value-of select="''"/></xsl:otherwise>
            </xsl:choose>
        </xsl:variable>
        <xsl:variable name="sp_get">
            <xsl:if test="bv:storage/bv:get">
                <xsl:choose>
                    <xsl:when test="bv:storage/bv:get/@name">
                        <xsl:value-of select="bv:storage/bv:get/@name"/>
                    </xsl:when>
                    <xsl:when test="contains($sp_type,'detailone')">
                        <xsl:value-of select="concat('sp', $objectname, '_SelectDetail')"/>
                    </xsl:when>
                    <xsl:when test="contains($sp_type,'detaillist')">
                        <xsl:value-of select="concat('sp', $objectname, '_SelectDetail')"/>
                    </xsl:when>
                    <xsl:when test="contains($sp_type,'lookuplist')">
                        <xsl:value-of select="concat('sp', $objectname, '_SelectLookup')"/>
                    </xsl:when>
                    <xsl:when test="contains($sp_type,'fnlist')">
                        <xsl:value-of select="concat('fn_', $objectname, '_SelectList')"/>
                    </xsl:when>
                    <xsl:when test="contains($sp_type,'simplelist')">
                        <xsl:value-of select="concat('sp', $objectname, '_SelectList')"/>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:value-of select="concat('sp', $objectname, '_SelectDetail')"/>
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:if>
        </xsl:variable>
    	<xsl:variable name="sp_cache" select="bv:storage/bv:get/@cache" />
        <xsl:variable name="langid">
            <xsl:choose>
                <xsl:when test="@langid"><xsl:value-of select="@langid"/></xsl:when>
                <xsl:otherwise><xsl:value-of select="'LangID'"/></xsl:otherwise>
            </xsl:choose>
        </xsl:variable>

namespace <xsl:value-of select="$namespace" />
{
        <xsl:for-each select="bv:tables/bv:table">
          <xsl:variable name="sp_type_table">
            <xsl:choose>
              <xsl:when test="@type">
                <xsl:value-of select="@type"/>
              </xsl:when>
              <xsl:otherwise>
                <xsl:value-of select="$sp_type"/>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:variable>
            <xsl:call-template name="generate-table">
                <xsl:with-param name="langid" select="$langid" />
                <xsl:with-param name="namespace" select="$namespace" />
                <xsl:with-param name="index" select="position()" />
                <xsl:with-param name="sp_count" select="$sp_count" />
                <xsl:with-param name="sp_get" select="$sp_get" />
                <xsl:with-param name="sp_type" select="$sp_type_table" />
                <xsl:with-param name="sp_cache" select="$sp_cache" />
                <xsl:with-param name="filter_object" select="$filter_object" />
            </xsl:call-template>
        </xsl:for-each>
}
	</xsl:template>

    <xsl:template name="generate-table">
        <xsl:param name="langid" />
        <xsl:param name="namespace" />
        <xsl:param name="index" />
        <xsl:param name="sp_count" />
        <xsl:param name="sp_get" />
        <xsl:param name="sp_type" />
        <xsl:param name="sp_cache" />
        <xsl:param name="filter_object" />
        <xsl:variable name="tablename" select="@name" />
        <xsl:variable name="hacodable" select="@hacodable" />
        <xsl:variable name="detailname">
            <xsl:choose>
                <xsl:when test="@detailname"><xsl:value-of select="@detailname"/></xsl:when>
                <xsl:otherwise><xsl:value-of select="concat(@name, 'Detail')"/></xsl:otherwise>
            </xsl:choose>
        </xsl:variable>

        <xsl:variable name="sp_insert">
            <xsl:if test="bv:storage/bv:insert">
                <xsl:value-of select="bv:storage/bv:insert/@name"/>
            </xsl:if>
        </xsl:variable>
        <xsl:variable name="sp_insert_predicate">
            <xsl:if test="bv:storage/bv:insert">
                <xsl:value-of select="bv:storage/bv:insert/@predicate"/>
            </xsl:if>
        </xsl:variable>
        <xsl:variable name="sp_update">
            <xsl:if test="bv:storage/bv:update">
                <xsl:value-of select="bv:storage/bv:update/@name"/>
            </xsl:if>
        </xsl:variable>
        <xsl:variable name="sp_update_predicate">
            <xsl:if test="bv:storage/bv:update">
                <xsl:value-of select="bv:storage/bv:update/@predicate"/>
            </xsl:if>
        </xsl:variable>
        <xsl:variable name="sp_post">
            <xsl:if test="bv:storage/bv:post">
                <xsl:choose>
                    <xsl:when test="bv:storage/bv:post/@name">
                        <xsl:value-of select="bv:storage/bv:post/@name"/>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:value-of select="concat('sp', $tablename, '_Post')"/>
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:if>
        </xsl:variable>
        <xsl:variable name="sp_post_predicate">
            <xsl:if test="bv:storage/bv:post">
                <xsl:value-of select="bv:storage/bv:post/@predicate"/>
            </xsl:if>
        </xsl:variable>
        <xsl:variable name="sp_delete">
            <xsl:if test="bv:storage/bv:delete">
                <xsl:choose>
                    <xsl:when test="bv:storage/bv:delete/@name">
                        <xsl:value-of select="bv:storage/bv:delete/@name"/>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:value-of select="concat('sp', $tablename, '_Delete')"/>
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:if>
        </xsl:variable>
        <xsl:variable name="sp_delete_predicate">
            <xsl:if test="bv:storage/bv:delete">
                <xsl:value-of select="bv:storage/bv:delete/@predicate"/>
            </xsl:if>
        </xsl:variable>
        <xsl:variable name="sp_candelete">
            <xsl:if test="bv:storage/bv:candelete">
                <xsl:choose>
                    <xsl:when test="bv:storage/bv:candelete/@name">
                        <xsl:value-of select="bv:storage/bv:candelete/@name"/>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:value-of select="concat('sp', $tablename, '_CanDelete')"/>
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:if>
        </xsl:variable>
        <xsl:variable name="sp_candelete_shouldask">
            <xsl:if test="bv:storage/bv:candelete">
                <xsl:choose>
                    <xsl:when test="bv:storage/bv:candelete/@shouldAsk">
                        <xsl:value-of select="bv:storage/bv:candelete/@shouldAsk"/>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:value-of select="'false'"/>
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:if>
        </xsl:variable>
        <xsl:variable name="msg_candelete" select="bv:storage/bv:candelete/@message" />
        <xsl:variable name="schema_get" select="util:SchemaXml(string($sp_get))" />
        <xsl:variable name="params" select="$schema_get/schema/params" />
        <xsl:variable name="columns" select="$schema_get/schema/results/columns[position()=$index]" />
        <xsl:variable name="tablekeys">
            <xsl:choose>
                <xsl:when test="bv:keys">
                    <xsl:element name="keys">
                        <xsl:for-each select="bv:keys/bv:key">
                            <xsl:element name="key">
                                <xsl:attribute name="name">
                                    <xsl:value-of select="@name"/>
                                </xsl:attribute>
                            </xsl:element>
                        </xsl:for-each>
                    </xsl:element>
                    <!--xsl:copy-of select="bv:keys" /-->
                </xsl:when>
                <xsl:otherwise>
                    <xsl:copy-of select="$schema_get/schema/results/keys[position()=$index]" />
                </xsl:otherwise>
            </xsl:choose>
        </xsl:variable>
        
    [XmlType(AnonymousType = true)]
    public abstract partial class <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> : 
        EditableObject&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;
        , IObject
        , IDisposable
        , ILookupUsage
        {
        <xsl:call-template name="sp-fields">
            <xsl:with-param name="tablename" select="$tablename" />
            <xsl:with-param name="columns" select="$columns" />
            <xsl:with-param name="tablekeys" select="$tablekeys" />
            <xsl:with-param name="table" select="." />
        </xsl:call-template>
        <xsl:call-template name="relation-fields">
          <xsl:with-param name="tablename" select="$tablename" />
          <xsl:with-param name="columns" select="$columns" />
          <xsl:with-param name="namespace" select="$namespace" />
        </xsl:call-template>
        <xsl:call-template name="lookup-fields">
          <xsl:with-param name="tablename" select="$tablename" />
          <xsl:with-param name="columns" select="$columns" />
          <xsl:with-param name="namespace" select="$namespace" />
        </xsl:call-template>
        <xsl:call-template name="cust-fields">
            <xsl:with-param name="tablename" select="$tablename" />
            <xsl:with-param name="table" select="." />
        </xsl:call-template>
        <xsl:call-template name="other">
            <xsl:with-param name="tablename" select="$tablename" />
            <xsl:with-param name="hacodable" select="$hacodable" />
            <xsl:with-param name="tablekeys" select="$tablekeys" />
        </xsl:call-template>
        <xsl:call-template name="invisible">
            <xsl:with-param name="tablename" select="$tablename" />
        </xsl:call-template>
        <xsl:call-template name="readonly">
            <xsl:with-param name="tablename" select="$tablename" />
        </xsl:call-template>
        <xsl:call-template name="required">
            <xsl:with-param name="tablename" select="$tablename" />
        </xsl:call-template>
        <xsl:call-template name="personal">
          <xsl:with-param name="tablename" select="$tablename" />
        </xsl:call-template>
      <xsl:call-template name="dispose">
            <xsl:with-param name="tablename" select="$tablename" />
        </xsl:call-template>
        <xsl:call-template name="lookup-usage">
            <xsl:with-param name="tablename" select="$tablename" />
        </xsl:call-template>
        <xsl:call-template name="parse-form-collection">
            <xsl:with-param name="tablename" select="$tablename" />
            <xsl:with-param name="columns" select="$columns" />
            <xsl:with-param name="tablekeys" select="$tablekeys" />
        </xsl:call-template>

        <xsl:call-template name="web-grid">
            <xsl:with-param name="tablename" select="$tablename" />
            <xsl:with-param name="columns" select="$columns" />
            <xsl:with-param name="tablekeys" select="$tablekeys" />
        </xsl:call-template>

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            <xsl:if test="bv:properties/@permissionObject or bv:properties/@permissionAction">
            , IObjectPermissions
            </xsl:if>
            <!--xsl:if test="not(bv:actions/bv:action[@type='Create'][@name='CreateNew'])"-->
            , IObjectCreator
            <!--/xsl:if-->
            <xsl:choose>
                <xsl:when test="contains($sp_type,'fnlist')">
            , IObjectSelectList
                    <xsl:if test="bv:storage/bv:delete">
            , IObjectPost
                    </xsl:if>
                </xsl:when>
                <xsl:when test="contains($sp_type,'lookuplist')">
                </xsl:when>
                <xsl:when test="contains($sp_type,'detaillist')">
            , IObjectSelectDetailList
            , IObjectPost
                </xsl:when>
                <xsl:when test="contains($sp_type,'simplelist')">
            , IObjectPost
                    <xsl:if test="contains($sp_type,'detailone')">
            , IObjectSelectDetail
                    </xsl:if>
                </xsl:when>
                <xsl:when test="contains($sp_type,'detailone')">
                    <!--xsl:if test="$index=1"-->
            , IObjectSelectDetail
            , IObjectPost
            , IObjectDelete
                    <!--/xsl:if-->
                </xsl:when>
            </xsl:choose>
        {
            private delegate void on_action(<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj);
            private static Accessor g_Instance = CreateInstance&lt;Accessor&gt;();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance&lt;Accessor&gt;();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            <xsl:call-template name="select">
                <xsl:with-param name="langid" select="$langid" />
                <xsl:with-param name="namespace" select="$namespace" />
                <xsl:with-param name="index" select="$index" />
                <xsl:with-param name="sp_cache" select="$sp_cache" />
                <xsl:with-param name="sp_type" select="$sp_type" />
                <xsl:with-param name="tablename" select="$tablename" />
                <xsl:with-param name="hacodable" select="$hacodable" />
                <xsl:with-param name="schema_get" select="$schema_get" />
                <xsl:with-param name="sp_get" select="$sp_get" />
                <xsl:with-param name="sp_count" select="$sp_count" />
                <xsl:with-param name="columns" select="$columns" />
                <xsl:with-param name="filter_object" select="$filter_object" />
                <xsl:with-param name="tablekeys" select="$tablekeys" />
            </xsl:call-template>
            <xsl:call-template name="create">
                <xsl:with-param name="tablename" select="$tablename" />
                <xsl:with-param name="hacodable" select="$hacodable" />
            </xsl:call-template>
            <xsl:call-template name="setup-handlers">
                <xsl:with-param name="tablename" select="$tablename" />
            </xsl:call-template>
            <xsl:call-template name="lookups">
                <xsl:with-param name="tablename" select="$tablename" />
                <xsl:with-param name="namespace" select="$namespace" />
                <xsl:with-param name="columns" select="$columns" />
            </xsl:call-template>
            <xsl:call-template name="can-delete">
                <xsl:with-param name="tablename" select="$tablename" />
                <xsl:with-param name="sp_candelete" select="$sp_candelete" />
            </xsl:call-template>
            <xsl:call-template name="post-delete">
                <xsl:with-param name="tablename" select="$tablename" />
                <xsl:with-param name="sp_delete" select="$sp_delete" />
                <xsl:with-param name="sp_delete_predicate" select="$sp_delete_predicate" />
            </xsl:call-template>
            <xsl:call-template name="post-insert">
                <xsl:with-param name="langid" select="$langid" />
                <xsl:with-param name="tablename" select="$tablename" />
                <xsl:with-param name="sp_insert" select="$sp_insert" />
                <xsl:with-param name="sp_insert_predicate" select="$sp_insert_predicate" />
            </xsl:call-template>
            <xsl:call-template name="post-update">
                <xsl:with-param name="langid" select="$langid" />
                <xsl:with-param name="tablename" select="$tablename" />
                <xsl:with-param name="sp_update" select="$sp_update" />
                <xsl:with-param name="sp_update_predicate" select="$sp_update_predicate" />
            </xsl:call-template>
            <xsl:call-template name="post">
                <xsl:with-param name="langid" select="$langid" />
                <xsl:with-param name="tablename" select="$tablename" />
                <xsl:with-param name="namespace" select="$namespace" />
                <xsl:with-param name="hacodable" select="$hacodable" />
                <xsl:with-param name="tablekeys" select="$tablekeys" />
                <xsl:with-param name="sp_candelete" select="$sp_candelete" />
                <xsl:with-param name="sp_candelete_shouldask" select="$sp_candelete_shouldask" />
                <xsl:with-param name="msg_candelete" select="$msg_candelete" />
                <xsl:with-param name="sp_delete" select="$sp_delete" />
                <xsl:with-param name="sp_post" select="$sp_post" />
                <xsl:with-param name="sp_insert" select="$sp_insert" />
                <xsl:with-param name="sp_update" select="$sp_update" />
                <xsl:with-param name="sp_type" select="$sp_type" />
                <xsl:with-param name="sp_post_predicate" select="$sp_post_predicate" />
            </xsl:call-template>
            <xsl:call-template name="permissions-accessor">
                <xsl:with-param name="tablename" select="$tablename" />
            </xsl:call-template>
            <xsl:call-template name="setup-required">
                <xsl:with-param name="tablename" select="$tablename" />
            </xsl:call-template>
            <xsl:call-template name="personal-data">
              <xsl:with-param name="tablename" select="$tablename" />
            </xsl:call-template>
            <xsl:call-template name="metaimp">
                <xsl:with-param name="tablename" select="$tablename" />
                <xsl:with-param name="columns" select="$columns" />
                <xsl:with-param name="detailname" select="$detailname" />
            </xsl:call-template>
        }

        <xsl:call-template name="permissions">
            <xsl:with-param name="tablename" select="$tablename" />
        </xsl:call-template>

        <xsl:call-template name="meta">
            <xsl:with-param name="tablename" select="$tablename" />
            <xsl:with-param name="columns" select="$columns" />
            <xsl:with-param name="sp_type" select="$sp_type" />
            <xsl:with-param name="tablekeys" select="$tablekeys" />

            <xsl:with-param name="sp_get" select="$sp_get" />
            <xsl:with-param name="sp_count" select="$sp_count" />
            <xsl:with-param name="sp_post" select="$sp_post" />
            <xsl:with-param name="sp_insert" select="$sp_insert" />
            <xsl:with-param name="sp_update" select="$sp_update" />
            <xsl:with-param name="sp_delete" select="$sp_delete" />
            <xsl:with-param name="sp_candelete" select="$sp_candelete" />
        </xsl:call-template>

        #endregion
        }
    </xsl:template>

</xsl:stylesheet>
