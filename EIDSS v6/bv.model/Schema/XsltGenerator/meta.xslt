<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:bv="urn:schemas-bv:objectmodel"
    xmlns:util="urn:util">

    <xsl:import href="globals.xslt" />
    <xsl:import href="personaldata.xslt" />

    <xsl:template name="metaimp">
        <xsl:param name="tablename" />
        <xsl:param name="columns" />
        <xsl:param name="detailname" />
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />) : false; }
            public List&lt;SearchPanelMetaItem&gt; SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List&lt;GridMetaItem&gt; GridMeta { get { return Meta.GridMeta; } }
            public List&lt;ActionMetaItem&gt; Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "<xsl:value-of select="$detailname" />"; } }
            public string HelpIdWin { get { return "<xsl:value-of select="bv:help/@win" />"; } }
            public string HelpIdWeb { get { return "<xsl:value-of select="bv:help/@web" />"; } }
            public string HelpIdHh { get { return "<xsl:value-of select="bv:help/@hh" />"; } }
            #endregion
    </xsl:template>

    <xsl:template name="meta">
        <xsl:param name="tablename" />
        <xsl:param name="columns" />
        <xsl:param name="sp_type" />
        <xsl:param name="tablekeys" />
        <xsl:param name="sp_get"/>
        <xsl:param name="sp_count"/>
        <xsl:param name="sp_post"/>
        <xsl:param name="sp_insert"/>
        <xsl:param name="sp_update"/>
        <xsl:param name="sp_delete"/>
        <xsl:param name="sp_candelete"/>
        #region Meta
        public static class Meta
        {
            public static string spSelect = "<xsl:value-of select="$sp_get" />";
            public static string spCount = "<xsl:value-of select="$sp_count" />";
            public static string spPost = "<xsl:value-of select="$sp_post" />";
            public static string spInsert = "<xsl:value-of select="$sp_insert" />";
            public static string spUpdate = "<xsl:value-of select="$sp_update" />";
            public static string spDelete = "<xsl:value-of select="$sp_delete" />";
            public static string spCanDelete = "<xsl:value-of select="$sp_candelete" />";
        
            public static Dictionary&lt;string, int&gt; Sizes = new Dictionary&lt;string, int&gt;();
            public static Dictionary&lt;string, Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;&gt; RequiredByField = new Dictionary&lt;string, Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;&gt;();
            public static Dictionary&lt;string, Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;&gt; RequiredByProperty = new Dictionary&lt;string, Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;&gt;();
            public static List&lt;SearchPanelMetaItem&gt; SearchPanelMeta = new List&lt;SearchPanelMetaItem&gt;();
            public static List&lt;GridMetaItem&gt; GridMeta = new List&lt;GridMetaItem&gt;();
            public static List&lt;ActionMetaItem&gt; Actions = new List&lt;ActionMetaItem&gt;();
            
            <xsl:call-template name="personal-static">
              <xsl:with-param name="tablename" select="$tablename" />
            </xsl:call-template>
            
            static Meta()
            {
                <xsl:for-each select="$columns/column"><xsl:if test="@size">
                Sizes.Add(_str_<xsl:value-of select="@name" />, <xsl:value-of select="@size" />);</xsl:if></xsl:for-each>
                <xsl:for-each select="bv:validators/bv:post/bv:required_validator">
                    <xsl:variable name="property">
                        <xsl:choose>
                            <xsl:when test="@property"><xsl:value-of select="@property"/></xsl:when>
                            <xsl:otherwise><xsl:value-of select="@target"/></xsl:otherwise>
                        </xsl:choose>
                    </xsl:variable>
                if (!RequiredByField.ContainsKey("<xsl:value-of select="@target" />")) RequiredByField.Add("<xsl:value-of select="@target" />", <xsl:choose>
                    <xsl:when test="@predicate"><xsl:value-of select="@predicate"/></xsl:when>
                    <xsl:otherwise>c => true</xsl:otherwise>
                </xsl:choose>);
                if (!RequiredByProperty.ContainsKey("<xsl:value-of select="$property" />")) RequiredByProperty.Add("<xsl:value-of select="$property" />", <xsl:choose>
                    <xsl:when test="@predicate"><xsl:value-of select="@predicate"/></xsl:when>
                    <xsl:otherwise>c => true</xsl:otherwise>
                </xsl:choose>);
                </xsl:for-each>
                <xsl:for-each select="bv:validators/bv:post/bv:custom_validator[@required='true']">
                if (!RequiredByField.ContainsKey("<xsl:value-of select="@field" />")) RequiredByField.Add("<xsl:value-of select="@field" />", c => true);
                if (!RequiredByProperty.ContainsKey("<xsl:value-of select="@field" />")) RequiredByProperty.Add("<xsl:value-of select="@field" />", c => true);
                </xsl:for-each>
                <xsl:for-each select="bv:searchpanel/bv:item">
                  <xsl:if test="@predicate">
                if (new Func&lt;bool&gt;(<xsl:value-of select="@predicate"/>)())</xsl:if>
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "<xsl:value-of select="@name" />",
                    EditorType.<xsl:value-of select="@editor" />,
                    EditorControlWidth.<xsl:choose><xsl:when test="@editorWidth"><xsl:value-of select="@editorWidth" />, </xsl:when><xsl:otherwise>Normal, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@useInWeb"><xsl:value-of select="@useInWeb" />, </xsl:when><xsl:otherwise>true, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@useInWin"><xsl:value-of select="@useInWin" />, </xsl:when><xsl:otherwise>true, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@range='true'">true, </xsl:when><xsl:otherwise>false, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@rangeDefDates='true'">true, </xsl:when><xsl:otherwise>false, </xsl:otherwise></xsl:choose>
                    "<xsl:value-of select="@labelId" />",
                    <xsl:choose><xsl:when test="@default"><xsl:value-of select="@default" />, </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@defaultoper">"<xsl:value-of select="@defaultoper" />", </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@mandatoryPredicate"><xsl:value-of select="@mandatoryPredicate"/>, </xsl:when><xsl:otherwise><xsl:choose><xsl:when test="@mandatory='true'">c => true, </xsl:when><xsl:otherwise>c => false, </xsl:otherwise></xsl:choose></xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@multiple='true'">true, </xsl:when><xsl:otherwise>false, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@location">SearchPanelLocation.<xsl:value-of select="@location" />, </xsl:when><xsl:otherwise>SearchPanelLocation.Main, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@isParam='true'">true, </xsl:when><xsl:otherwise>false, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@dependent">"<xsl:value-of select="@dependent" />", </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@lookupName">"<xsl:value-of select="@lookupName" />", </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@lookupType">typeof(<xsl:value-of select="@lookupType" />), </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@lookupValue">(o) => { var c = (<xsl:value-of select="@lookupType" />)o; return <xsl:value-of select="@lookupValue" />; }, </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@lookupText">(o) => { var c = (<xsl:value-of select="@lookupType" />)o; return <xsl:value-of select="@lookupText" />; }, </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="bv:columns/bv:column">new List&lt;Tuple&lt;string, string&gt;&gt;(){<xsl:for-each select="bv:columns/bv:column">new Tuple&lt;string, string&gt;("<xsl:value-of select="@name"/>", eidss.model.Resources.EidssFields.Get("<xsl:choose><xsl:when test="@label"><xsl:value-of select="@label"/></xsl:when><xsl:otherwise><xsl:value-of select="@name"/></xsl:otherwise></xsl:choose>")),</xsl:for-each>},</xsl:when><xsl:otherwise>null,</xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@bitmask='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>
                    ));</xsl:for-each>
                <xsl:for-each select="bv:grid/bv:item">
                    <xsl:variable name="name" select="@name" />
                GridMeta.Add(new GridMetaItem(
                    _str_<xsl:value-of select="@name" />,
                    <xsl:choose><xsl:when test="//bv:labels/bv:item[@name=$name]">"<xsl:value-of select="//bv:labels/bv:item[@name=$name]/@labelId" />", </xsl:when><xsl:otherwise>_str_<xsl:value-of select="@name" />, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@format">"<xsl:value-of select="@format" />", </xsl:when><xsl:otherwise>null, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@visible"><xsl:value-of select="@visible" />, </xsl:when><xsl:otherwise>true, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@useInWeb"><xsl:value-of select="@useInWeb" />, </xsl:when><xsl:otherwise>true, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@useInWin"><xsl:value-of select="@useInWin" />, </xsl:when><xsl:otherwise>true, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@sortable"><xsl:value-of select="@sortable" />, </xsl:when><xsl:otherwise>true, </xsl:otherwise></xsl:choose>
                    <xsl:choose><xsl:when test="@defaultSort">ListSortDirection.<xsl:value-of select="@defaultSort" /></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>
                    ));</xsl:for-each>

                <xsl:for-each select="bv:actions/bv:action">
                Actions.Add(new ActionMetaItem(
                    "<xsl:value-of select="@name" />",
                    ActionTypes.<xsl:value-of select="@type" />,
                    true,
                    "<xsl:value-of select="bv:hierarchy/@relatedList" />",
                    "<xsl:value-of select="bv:hierarchy/@container" />",
                    <xsl:choose>
                        <xsl:when test="@type='Container'">
                    null,
                        </xsl:when>
                        <xsl:when test="@type='Create'">
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).<xsl:value-of select="@name" />(manager, c, pars)),
                        </xsl:when>
                        <xsl:when test="@type='Action'">
                    (manager, c, pars) => Accessor.Instance(null).<xsl:value-of select="@name" />(manager, (<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)c, pars),
                        </xsl:when>
                        <xsl:otherwise>
                    (manager, c, pars) => new ActResult(true, c),
                        </xsl:otherwise>
                    </xsl:choose>
                    null,
                    <xsl:choose>
                      <xsl:when test="bv:visual">
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"<xsl:value-of select="bv:visual/bv:regular/@caption" />",
                        "<xsl:value-of select="bv:visual/bv:regular/@icon" />",
                        /*from BvMessages*/"<xsl:value-of select="bv:visual/bv:regular/@tooltip" />",
                        /*from BvMessages*/"<xsl:value-of select="bv:visual/bv:readOnly/@caption" />",
                        "<xsl:value-of select="bv:visual/bv:readOnly/@icon" />",
                        /*from BvMessages*/"<xsl:value-of select="bv:visual/bv:readOnly/@tooltip" />",
                        ActionsAlignment.<xsl:choose><xsl:when test="bv:visual/@alignment"><xsl:value-of select="bv:visual/@alignment" /></xsl:when><xsl:otherwise>Left</xsl:otherwise></xsl:choose>,
                        ActionsPanelType.<xsl:choose><xsl:when test="bv:visual/@panel"><xsl:value-of select="bv:visual/@panel" /></xsl:when><xsl:otherwise>Main</xsl:otherwise></xsl:choose>,
                        ActionsAppType.<xsl:choose><xsl:when test="bv:visual/@app"><xsl:value-of select="bv:visual/@app" /></xsl:when><xsl:otherwise>All</xsl:otherwise></xsl:choose>
                        ),
                      </xsl:when>
                      <xsl:otherwise>
                    null,
                      </xsl:otherwise>
                    </xsl:choose>
                    <xsl:choose><xsl:when test="bv:run/bv:preUI[@webType='JScript']">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="bv:permissions/@type">"<xsl:value-of select="bv:permissions/@type"/>"</xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="bv:permissions/@predicate"><xsl:value-of select="bv:permissions/@predicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="bv:visual/@enablePredicate"><xsl:value-of select="bv:visual/@enablePredicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="bv:visual/@readOnlyPredicate"><xsl:value-of select="bv:visual/@readOnlyPredicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="bv:visual/@visiblePredicate"><xsl:value-of select="bv:visual/@visiblePredicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="@forceClose='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="@onRow='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="bv:run/bv:preUI/@methodName">"<xsl:value-of select="bv:run/bv:preUI/@methodName"/>"</xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="@isSingle='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                    new ActionMetaItem[] {
                      <xsl:apply-templates select="bv:actions" mode="meta">
                        <xsl:with-param name="tablename" select="$tablename" />
                      </xsl:apply-templates>
                      }
                    <xsl:if test="bv:actions/bv:dynamic">
                    , o => 
                    {
                        <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj = (<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)o;
                        return obj.<xsl:value-of select="bv:actions/bv:dynamic/@container"/>Lookup
                            .Where(<xsl:value-of select="bv:actions/bv:dynamic/@filter"/>)
                            .Select(i => 
                                new ActionMetaItem(
                                    new Func&lt;<xsl:value-of select="bv:actions/bv:dynamic/@type" />, string&gt;(<xsl:value-of select="bv:actions/bv:dynamic/@name" />)(i),
                                    ActionTypes.<xsl:value-of select="@type" />,
                                    true,
                                    "<xsl:value-of select="bv:hierarchy/@relatedList" />",
                                    "<xsl:value-of select="bv:hierarchy/@container" />",
                                    (manager, c, pars) => Accessor.Instance(null).<xsl:value-of select="@name" />(manager, (<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)c, 
                                        new Func&lt;<xsl:value-of select="bv:actions/bv:dynamic/@type" />, List&lt;object&gt;&gt;(j => new List&lt;object&gt; { j.<xsl:value-of select="bv:actions/bv:dynamic/@param" /> } )(i)
                                        ),
                                    null,
                                    <xsl:choose>
                                      <xsl:when test="bv:visual">
                                        new ActionMetaItem.VisualItem(
                                        new Func&lt;<xsl:value-of select="bv:actions/bv:dynamic/@type" />, string&gt;(<xsl:value-of select="bv:actions/bv:dynamic/bv:visual/bv:regular/@caption" />)(i),
                                        "<xsl:value-of select="bv:visual/bv:regular/@icon" />",
                                        new Func&lt;<xsl:value-of select="bv:actions/bv:dynamic/@type" />, string&gt;(<xsl:value-of select="bv:actions/bv:dynamic/bv:visual/bv:regular/@tooltip" />)(i),
                                        /*from BvMessages*/"<xsl:value-of select="bv:visual/bv:readOnly/@caption" />",
                                        "<xsl:value-of select="bv:visual/bv:readOnly/@icon" />",
                                        /*from BvMessages*/"<xsl:value-of select="bv:visual/bv:readOnly/@tooltip" />",
                                        ActionsAlignment.<xsl:choose><xsl:when test="bv:visual/@alignment"><xsl:value-of select="bv:visual/@alignment" /></xsl:when><xsl:otherwise>Left</xsl:otherwise></xsl:choose>,
                                        ActionsPanelType.<xsl:choose><xsl:when test="bv:visual/@panel"><xsl:value-of select="bv:visual/@panel" /></xsl:when><xsl:otherwise>Main</xsl:otherwise></xsl:choose>,
                                        ActionsAppType.<xsl:choose><xsl:when test="bv:visual/@app"><xsl:value-of select="bv:visual/@app" /></xsl:when><xsl:otherwise>All</xsl:otherwise></xsl:choose>
                                        ),
                                      </xsl:when>
                                      <xsl:otherwise>
                                    null,
                                      </xsl:otherwise>
                                    </xsl:choose>
                                    <xsl:choose><xsl:when test="bv:run/bv:preUI[@webType='JScript']">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="bv:permissions/@type">"<xsl:value-of select="bv:permissions/@type"/>"</xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="bv:permissions/@predicate"><xsl:value-of select="bv:permissions/@predicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="bv:visual/@enablePredicate"><xsl:value-of select="bv:visual/@enablePredicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="bv:visual/@readOnlyPredicate"><xsl:value-of select="bv:visual/@readOnlyPredicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="bv:visual/@visiblePredicate"><xsl:value-of select="bv:visual/@visiblePredicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="@forceClose='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="@onRow='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="bv:run/bv:preUI/@methodName">"<xsl:value-of select="bv:run/bv:preUI/@methodName"/>"</xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="@isSingle='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                                    new ActionMetaItem[] {
                                      <xsl:apply-templates select="bv:actions"/>
                                      }
                                    )
                            );
                    }
                    </xsl:if>
                    ));
                  </xsl:for-each>
      
                <xsl:variable name="stdactions">
                    <xsl:choose>
                        <xsl:when test="contains($sp_type,'fnlist')"><xsl:value-of select="'SelectAll,Select,Create,Edit,Delete,Refresh,Close,Report'"/></xsl:when>
                        <xsl:when test="contains($sp_type,'detaillist')"><xsl:value-of select="'Create,Edit,Delete,Ok,Cancel'"/></xsl:when>
                        <xsl:otherwise><xsl:value-of select="'Create,Save,Ok,Cancel,Delete'"/></xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
                <xsl:variable name="stdactions_readonly">
                    <xsl:choose>
                        <xsl:when test="contains($sp_type,'fnlist')"><xsl:value-of select="'SelectAll,Select,Create,Edit,Delete,Refresh,Close,Report'"/></xsl:when>
                        <xsl:when test="contains($sp_type,'detaillist')"><xsl:value-of select="'Create,View,Delete,Ok,Cancel'"/></xsl:when>
                        <xsl:otherwise><xsl:value-of select="'Create,Delete,Save,Ok,Cancel'"/></xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
                <xsl:variable name="allactions" select="'SelectAll,Select,Create,Edit,Delete,Refresh,Close,Report,Save,Ok,Cancel'" />
                <xsl:variable name="action_name" select="util:ExpandXml('action,name', $allactions,
                              'SelectAll,Select,Create,Edit,Delete,Refresh,Close,Report,Save,Ok,Cancel')" />
                <xsl:variable name="action_caption" select="util:ExpandXml('action,caption', $allactions,
                              'strSelectAll_Id,strSelect_Id,strCreate_Id,strEdit_Id,strDelete_Id,strRefresh_Id,strClose_Id,strReport_Id,strSave_Id,strOK_Id,strCancel_Id')" />
                <xsl:variable name="action_icon" select="util:ExpandXml('action,icon', $allactions,
                              'selectall,select,add,edit,Delete_Remove,iconRefresh_Id,Close,Report,Save,,')" />
                <xsl:variable name="action_tooltip" select="util:ExpandXml('action,tooltip', $allactions,
                              'tooltipSelectAll_Id,tooltipSelect_Id,tooltipCreate_Id,tooltipEdit_Id,tooltipDelete_Id,tooltipRefresh_Id,tooltipClose_Id,tooltipReport_Id,tooltipSave_Id,tooltipOK_Id,tooltipCancel_Id')" />
                <xsl:variable name="action_caption_readonly" select="util:ExpandXml('action,caption', $allactions,
                              ',,,strView_Id,,,,,,,strOK_Id')" />
                <xsl:variable name="action_icon_readonly" select="util:ExpandXml('action,icon', $allactions,
                              ',,,View1,,,,,,,')" />
                <xsl:variable name="action_tooltip_readonly" select="util:ExpandXml('action,tooltip', $allactions,
                              'tooltipSelectAll_Id,tooltipSelect_Id,tooltipCreate_Id,tooltipEdit_Id,tooltipDelete_Id,tooltipRefresh_Id,tooltipClose_Id,tooltipReport_Id,tooltipSave_Id,tooltipOK_Id,tooltipCancel_Id')" />
                <xsl:variable name="action_permission" select="util:ExpandXml('action,permissionAction', $allactions,
                              ',,,,,,,,,,')" />
                <xsl:variable name="action_align" select="util:ExpandXml('action,align', $allactions,
                              'Right,Right,Right,Right,Right,Right,Right,Left,Right,Right,Right')" />
                <xsl:variable name="action_panel_fnlist" select="util:ExpandXml('action,panel', $allactions,
                              'Top,Top,Top,Top,Top,Main,Main,Main,Main,Main,Main')" />
                <xsl:variable name="action_panel_detaillist" select="util:ExpandXml('action,panel', $allactions,
                              'Top,Top,Group,Group,Group,Main,Main,Main,Main,Main,Main')" />
                <xsl:variable name="action_panel_other" select="util:ExpandXml('action,panel', $allactions,
                              'Top,Top,Main,Main,Main,Main,Main,Main,Main,Main,Main')" />
                <xsl:variable name="action_close" select="util:ExpandXml('action,close', $allactions,
                              'false,false,false,false,true,false,true,false,false,true,true')" />
                <xsl:variable name="actions" select="util:ExpandXml('action,action_readonly', string($stdactions), string($stdactions_readonly))" />
                <xsl:variable name="cur" select="." />
                <xsl:for-each select="$actions/keys/key">
                    <xsl:variable name="action" select="@action" />
                    <xsl:variable name="action_readonly" select="@action_readonly" />

                    <xsl:variable name="action_action">
                        <xsl:choose> <!-- action -->
                            <xsl:when test="$action = 'Create'">
                                <xsl:choose>
                                    <xsl:when test="contains($sp_type,'fnlist')">(manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface&lt;<xsl:value-of select="$cur/bv:actions/@child" /><xsl:value-of select="$class_suffix" />&gt;().CreateNew(manager, c, pars == null ? null : (int?)pars[0]))</xsl:when>
                                    <xsl:when test="contains($sp_type,'detaillist')">(manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars))</xsl:when>
                                    <xsl:otherwise>(manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars))</xsl:otherwise>
                                </xsl:choose>
                            </xsl:when>
                            <xsl:when test="$action = 'Edit'">
                                <xsl:choose>
                                    <xsl:when test="contains($sp_type,'fnlist')">(manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface&lt;<xsl:value-of select="$cur/bv:actions/@child" /><xsl:value-of select="$class_suffix" />&gt;().SelectDetail(manager, pars[0]))</xsl:when>
                                    <xsl:when test="contains($sp_type,'detaillist')">(manager, c, pars) => new ActResult(true, c)</xsl:when>
                                    <xsl:otherwise>(manager, c, pars) => new ActResult(true, c)</xsl:otherwise>
                                </xsl:choose>
                            </xsl:when>
                            <xsl:when test="$action = 'Delete'">
                                <xsl:choose>
                                    <xsl:when test="contains($sp_type,'fnlist')">
                                        <xsl:choose>
                                            <xsl:when test="$cur/bv:storage/bv:delete or $cur/bv:storage/bv:post">(manager, c, pars) => 
                        {
                            if (c == null)
                            {
                                c = ObjectAccessor.CreatorInterface&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;().CreateWithParams(manager, null, pars);
                                ((<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)c).<xsl:value-of select="msxsl:node-set($tablekeys)/keys/key[1]/@name" /> = (long)pars[0];
                                ((<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)c).m_IsNew = false;
                            }
                            return new ActResult(((<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)c).MarkToDelete() &amp;&amp; ObjectAccessor.PostInterface&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;().Post(manager, (<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)c), c);
                        }
                                            </xsl:when>
                                            <xsl:otherwise>(manager, c, pars) => new ActResult(ObjectAccessor.DeleteInterface&lt;<xsl:value-of select="$cur/bv:actions/@child" /><xsl:value-of select="$class_suffix" />&gt;().DeleteObject(manager, c == null ? pars[0] : c.Key), c)</xsl:otherwise>
                                        </xsl:choose>
                                    </xsl:when>
                                    <xsl:when test="contains($sp_type,'detaillist')">(manager, c, pars) => ((<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)c).MarkToDelete()</xsl:when>
                                    <xsl:otherwise>(manager, c, pars) => new ActResult(((<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)c).MarkToDelete() &amp;&amp; ObjectAccessor.PostInterface&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;().Post(manager, (<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)c), c)</xsl:otherwise>
                                </xsl:choose>
                            </xsl:when>
                            <xsl:when test="$action = 'Close'">
                                <xsl:choose>
                                    <xsl:when test="contains($sp_type,'fnlist')">(manager, c, pars) => new ActResult(true, c)</xsl:when>
                                    <xsl:when test="contains($sp_type,'detaillist')">(manager, c, pars) => new ActResult(true, c)</xsl:when>
                                    <xsl:otherwise>(manager, c, pars) => new ActResult(true, c)</xsl:otherwise>
                                </xsl:choose>
                            </xsl:when>
                            <xsl:when test="$action = 'Report'">
                                <xsl:choose>
                                    <xsl:when test="contains($sp_type,'fnlist')">(manager, c, pars) => new ActResult(true, c)</xsl:when>
                                    <xsl:when test="contains($sp_type,'detaillist')">(manager, c, pars) => new ActResult(true, c)</xsl:when>
                                    <xsl:otherwise>(manager, c, pars) => new ActResult(true, c)</xsl:otherwise>
                                </xsl:choose>
                            </xsl:when>
                            <xsl:when test="$action = 'Ok'">
                                <xsl:choose>
                                    <xsl:when test="contains($sp_type,'fnlist')">(manager, c, pars) => new ActResult(true, c)</xsl:when>
                                    <xsl:when test="contains($sp_type,'detaillist')">(manager, c, pars) => new ActResult(true, c)</xsl:when>
                                    <xsl:otherwise>(manager, c, pars) => new ActResult(ObjectAccessor.PostInterface&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;().Post(manager, (<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)c), c)</xsl:otherwise>
                                </xsl:choose>
                            </xsl:when>
                            <xsl:when test="$action = 'Save'">
                                <xsl:choose>
                                    <xsl:when test="contains($sp_type,'fnlist')">null</xsl:when>
                                    <xsl:when test="contains($sp_type,'detaillist')">(manager, c, pars) => true</xsl:when>
                                    <xsl:otherwise>(manager, c, pars) => new ActResult(ObjectAccessor.PostInterface&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;().Post(manager, (<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)c), c)</xsl:otherwise>
                                </xsl:choose>
                            </xsl:when>
                            <xsl:when test="$action = 'Cancel'">
                                <xsl:choose>
                                    <xsl:when test="contains($sp_type,'fnlist')">(manager, c, pars) => new ActResult(true, c)</xsl:when>
                                    <xsl:when test="contains($sp_type,'detaillist')">(manager, c, pars) => new ActResult(true, c)</xsl:when>
                                    <xsl:otherwise>(manager, c, pars) => new ActResult(true, c)</xsl:otherwise>
                                </xsl:choose>
                            </xsl:when>
                            <xsl:otherwise>(manager, c, pars) => new ActResult(true, c)</xsl:otherwise>
                        </xsl:choose>
                    </xsl:variable>

                    <xsl:variable name="enable_predicate">
                        <xsl:choose> <!-- action -->
                            <xsl:when test="$action = 'Delete'">
                                <xsl:choose>
                                  <xsl:when test="contains($sp_type,'fnlist')">null</xsl:when>
                                  <xsl:when test="contains($sp_type,'detaillist')">null</xsl:when>
                                  <xsl:otherwise>(o, p, r) => r &amp;&amp; !o.IsNew &amp;&amp; !o.HasChanges</xsl:otherwise>
                                </xsl:choose>
                            </xsl:when>
                            <xsl:otherwise>null</xsl:otherwise>
                        </xsl:choose>
                    </xsl:variable>
                  
                    <xsl:if test="not($cur/bv:actions/bv:standard/bv:remove[@type=$action])">
                Actions.Add(new ActionMetaItem(
                    "<xsl:value-of select="$action_name/keys/key[@action=$action]/@name" />",
                    ActionTypes.<xsl:value-of select="$action" />,
                    false,
                    String.Empty,
                    String.Empty,
                    <xsl:value-of select="$action_action" />,
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"<xsl:value-of select="$action_caption/keys/key[@action=$action]/@caption" />",
                        "<xsl:value-of select="$action_icon/keys/key[@action=$action]/@icon" />",
                        /*from BvMessages*/"<xsl:value-of select="$action_tooltip/keys/key[@action=$action]/@tooltip" />",
                        /*from BvMessages*/"<xsl:value-of select="$action_caption_readonly/keys/key[@action=$action]/@caption" />",
                        "<xsl:value-of select="$action_icon_readonly/keys/key[@action=$action]/@icon" />",
                        /*from BvMessages*/"<xsl:value-of select="$action_tooltip_readonly/keys/key[@action=$action]/@tooltip" />",
                        ActionsAlignment.<xsl:value-of select="$action_align/keys/key[@action=$action]/@align" />,
                        ActionsPanelType.<xsl:choose>
                            <xsl:when test="contains($sp_type,'fnlist')"><xsl:value-of select="$action_panel_fnlist/keys/key[@action=$action]/@panel" /></xsl:when>
                            <xsl:when test="contains($sp_type,'detaillist')"><xsl:value-of select="$action_panel_detaillist/keys/key[@action=$action]/@panel" /></xsl:when>
                            <xsl:otherwise><xsl:value-of select="$action_panel_other/keys/key[@action=$action]/@panel" /></xsl:otherwise>
                        </xsl:choose>,
                        ActionsAppType.<xsl:choose><xsl:when test="@app"><xsl:value-of select="@app" /></xsl:when><xsl:otherwise>All</xsl:otherwise></xsl:choose>
                      ),
                      false,
                      null,
                      null,
                      <xsl:value-of select="$enable_predicate" />,
                      null,
                      null,
                      false
                      ));
                    </xsl:if>
                  
                </xsl:for-each>
        
                _SetupPersonalDataRestrictions();
            }
            
            <xsl:call-template name="personal-data-static">
              <xsl:with-param name="tablename" select="$tablename" />
            </xsl:call-template>
        }
        #endregion
    </xsl:template>

  <xsl:template match="bv:actions" mode="meta">
    <xsl:param name="tablename" />

    <xsl:for-each select="bv:action">
      <xsl:if test="position() > 1">,</xsl:if>
                new ActionMetaItem(
                    "<xsl:value-of select="@name" />",
                    ActionTypes.<xsl:value-of select="@type" />,
                    true,
                    "<xsl:value-of select="bv:hierarchy/@relatedList" />",
                    "<xsl:value-of select="bv:hierarchy/@container" />",
                    (manager, c, pars) => Accessor.Instance(null).<xsl:value-of select="@name" />(manager, (<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)c, pars),
                    null,
                    <xsl:choose>
                      <xsl:when test="bv:visual">
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"<xsl:value-of select="bv:visual/bv:regular/@caption" />",
                        "<xsl:value-of select="bv:visual/bv:regular/@icon" />",
                        /*from BvMessages*/"<xsl:value-of select="bv:visual/bv:regular/@tooltip" />",
                        /*from BvMessages*/"<xsl:value-of select="bv:visual/bv:readOnly/@caption" />",
                        "<xsl:value-of select="bv:visual/bv:readOnly/@icon" />",
                        /*from BvMessages*/"<xsl:value-of select="bv:visual/bv:readOnly/@tooltip" />",
                        ActionsAlignment.<xsl:choose><xsl:when test="bv:visual/@alignment"><xsl:value-of select="bv:visual/@alignment" /></xsl:when><xsl:otherwise>Left</xsl:otherwise></xsl:choose>,
                        ActionsPanelType.<xsl:choose><xsl:when test="bv:visual/@panel"><xsl:value-of select="bv:visual/@panel" /></xsl:when><xsl:otherwise>Main</xsl:otherwise></xsl:choose>,
                        ActionsAppType.<xsl:choose><xsl:when test="bv:visual/@app"><xsl:value-of select="bv:visual/@app" /></xsl:when><xsl:otherwise>All</xsl:otherwise></xsl:choose>
                        ),
                      </xsl:when>
                      <xsl:otherwise>
                    null,
                      </xsl:otherwise>
                    </xsl:choose>
                    <xsl:choose><xsl:when test="bv:run/bv:preUI[@webType='JScript']">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="bv:permissions/@type">"<xsl:value-of select="bv:permissions/@type"/>"</xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="bv:permissions/@predicate"><xsl:value-of select="bv:permissions/@predicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="bv:visual/@enablePredicate"><xsl:value-of select="bv:visual/@enablePredicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="bv:visual/@readOnlyPredicate"><xsl:value-of select="bv:visual/@readOnlyPredicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="bv:visual/@visiblePredicate"><xsl:value-of select="bv:visual/@visiblePredicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="@forceClose='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="@onRow='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="bv:run/bv:preUI/@methodName">"<xsl:value-of select="bv:run/bv:preUI/@methodName"/>"</xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                    <xsl:choose><xsl:when test="@isSingle='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                    new ActionMetaItem[] {
                      <xsl:apply-templates select="bv:actions"/>
                      }
                    <xsl:if test="bv:actions/bv:dynamic">
                    , o => 
                    {
                        <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj = (<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)o;
                        return obj.<xsl:value-of select="bv:actions/bv:dynamic/@container"/>Lookup
                            .Where(<xsl:value-of select="bv:actions/bv:dynamic/@filter"/>)
                            .Select(i => 
                                new ActionMetaItem(
                                    new Func&lt;<xsl:value-of select="bv:actions/bv:dynamic/@type" />, string&gt;(<xsl:value-of select="bv:actions/bv:dynamic/@name" />)(i),
                                    ActionTypes.<xsl:value-of select="@type" />,
                                    true,
                                    "<xsl:value-of select="bv:hierarchy/@relatedList" />",
                                    "<xsl:value-of select="bv:hierarchy/@container" />",
                                    (manager, c, pars) => Accessor.Instance(null).<xsl:value-of select="@name" />(manager, (<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />)c, 
                                        new Func&lt;<xsl:value-of select="bv:actions/bv:dynamic/@type" />, List&lt;object&gt;&gt;(j => new List&lt;object&gt; { j.<xsl:value-of select="bv:actions/bv:dynamic/@param" /> } )(i)
                                        ),
                                    null,
                                    <xsl:choose>
                                      <xsl:when test="bv:visual">
                                        new ActionMetaItem.VisualItem(
                                        new Func&lt;<xsl:value-of select="bv:actions/bv:dynamic/@type" />, string&gt;(<xsl:value-of select="bv:actions/bv:dynamic/bv:visual/bv:regular/@caption" />)(i),
                                        "<xsl:value-of select="bv:visual/bv:regular/@icon" />",
                                        new Func&lt;<xsl:value-of select="bv:actions/bv:dynamic/@type" />, string&gt;(<xsl:value-of select="bv:actions/bv:dynamic/bv:visual/bv:regular/@tooltip" />)(i),
                                        /*from BvMessages*/"<xsl:value-of select="bv:visual/bv:readOnly/@caption" />",
                                        "<xsl:value-of select="bv:visual/bv:readOnly/@icon" />",
                                        /*from BvMessages*/"<xsl:value-of select="bv:visual/bv:readOnly/@tooltip" />",
                                        ActionsAlignment.<xsl:choose><xsl:when test="bv:visual/@alignment"><xsl:value-of select="bv:visual/@alignment" /></xsl:when><xsl:otherwise>Left</xsl:otherwise></xsl:choose>,
                                        ActionsPanelType.<xsl:choose><xsl:when test="bv:visual/@panel"><xsl:value-of select="bv:visual/@panel" /></xsl:when><xsl:otherwise>Main</xsl:otherwise></xsl:choose>,
                                        ActionsAppType.<xsl:choose><xsl:when test="bv:visual/@app"><xsl:value-of select="bv:visual/@app" /></xsl:when><xsl:otherwise>All</xsl:otherwise></xsl:choose>
                                        ),
                                      </xsl:when>
                                      <xsl:otherwise>
                                    null,
                                      </xsl:otherwise>
                                    </xsl:choose>
                                    <xsl:choose><xsl:when test="bv:run/bv:preUI[@webType='JScript']">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="bv:permissions/@type">"<xsl:value-of select="bv:permissions/@type"/>"</xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="bv:permissions/@predicate"><xsl:value-of select="bv:permissions/@predicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="bv:visual/@enablePredicate"><xsl:value-of select="bv:visual/@enablePredicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="bv:visual/@readOnlyPredicate"><xsl:value-of select="bv:visual/@readOnlyPredicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="bv:visual/@visiblePredicate"><xsl:value-of select="bv:visual/@visiblePredicate"/></xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="@forceClose='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="@onRow='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="bv:run/bv:preUI/@methodName">"<xsl:value-of select="bv:run/bv:preUI/@methodName"/>"</xsl:when><xsl:otherwise>null</xsl:otherwise></xsl:choose>,
                                    <xsl:choose><xsl:when test="@isSingle='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>,
                                    new ActionMetaItem[] {
                                      <xsl:apply-templates select="bv:actions"/>
                                      }
                                    )
                            );
                    }
                    </xsl:if>
                    )
    </xsl:for-each>
  </xsl:template>
    
</xsl:stylesheet>
