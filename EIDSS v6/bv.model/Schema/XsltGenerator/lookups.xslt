<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />

    <xsl:template name="lookup-fields">
        <xsl:param name="tablename" />
        <xsl:param name="columns" />
        <xsl:param name="namespace" />
        <xsl:param name="table" />

      <xsl:for-each select="bv:lookups/bv:lookup">
            <xsl:variable name="parname" select="@source" />
            <xsl:variable name="columnname" select="@name" />
        <xsl:if test="@recursive">[XmlIgnore]</xsl:if>
        [LocalizedDisplayName(<xsl:choose><xsl:when test="msxsl:node-set($table)/bv:labels/bv:item[@name=$columnname]">"<xsl:value-of select="msxsl:node-set($table)/bv:labels/bv:item[@name=$columnname]/@labelId" />"</xsl:when><xsl:otherwise>_str_<xsl:value-of select="@name" /></xsl:otherwise></xsl:choose>)]
        [Relation(typeof(<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />), <xsl:choose><xsl:when test="@target != '' and not(contains(@target,'?'))"><xsl:value-of select="$namespace" />.<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />._str_<xsl:value-of select="@target" /></xsl:when><xsl:otherwise>""</xsl:otherwise></xsl:choose>, _str_<xsl:value-of select="@source" />)]
        public <xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" /><xsl:text>&#32;</xsl:text><xsl:value-of select="@name" />
        {
            get { return _<xsl:value-of select="@name" /><xsl:if test="not(@hintonly='true' or @notaddempty='true')"> == null ? null : ((long)_<xsl:value-of select="@name" />.Key == 0 ? null : _<xsl:value-of select="@name" />)</xsl:if>; }
            set 
            { 
                var oldVal = _<xsl:value-of select="@name" />;
                _<xsl:value-of select="@name" /> = value<xsl:if test="not(@hintonly='true' or @notaddempty='true')"> == null ? null : ((long) value.Key == 0 ? null : value)</xsl:if>;
                if (_<xsl:value-of select="@name" /> != oldVal)
                {
                    if (<xsl:value-of select="@source" /> != (_<xsl:value-of select="@name" /> == null
                            ? <xsl:choose>
                                <xsl:when test="@hintonly='true'"><xsl:value-of select="@source" /></xsl:when>
                                <xsl:when test="$columns/column[@name=$parname]/@type='String'">null</xsl:when>
                                <xsl:when test="$columns/column[@name=$parname]/@type">new <xsl:value-of select="$columns/column[@name=$parname]/@type" />()</xsl:when>
                                <xsl:otherwise>new long?()</xsl:otherwise>
                            </xsl:choose>
                            : <xsl:choose>
                                <xsl:when test="$columns/column[@name=$parname]/@type">(<xsl:value-of select="$columns/column[@name=$parname]/@type" />)</xsl:when>
                                <xsl:otherwise></xsl:otherwise>
                            </xsl:choose>_<xsl:value-of select="@name" />.<xsl:value-of select="@target" />))
                        <xsl:value-of select="@source" /> = _<xsl:value-of select="@name" /> == null 
                            ? <xsl:choose>
                                <xsl:when test="@hintonly='true'"><xsl:value-of select="@source" /></xsl:when>
                                <xsl:when test="$columns/column[@name=$parname]/@type='String'">null</xsl:when>
                                <xsl:when test="$columns/column[@name=$parname]/@type">new <xsl:value-of select="$columns/column[@name=$parname]/@type" />()</xsl:when>
                                <xsl:otherwise>new long?()</xsl:otherwise>
                            </xsl:choose>
                            : <xsl:choose>
                                <xsl:when test="$columns/column[@name=$parname]/@type">(<xsl:value-of select="$columns/column[@name=$parname]/@type" />)</xsl:when>
                                <xsl:otherwise></xsl:otherwise>
                            </xsl:choose>_<xsl:value-of select="@name" />.<xsl:value-of select="@target" />; 
                    OnPropertyChanged(_str_<xsl:value-of select="@name" />); 
                }
            }
        }
        private <xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" /> _<xsl:value-of select="@name" />;

        <xsl:choose>
            <xsl:when test="@existinglookup">
        <xsl:if test="not(@notaddempty='true')">
        private <xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" /> _empty<xsl:value-of select="@name" />;
        </xsl:if>
        public List&lt;<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />&gt; <xsl:value-of select="@name" />Lookup
        {
            get 
            { 
                <xsl:if test="not(@notaddempty='true')">
                if (_empty<xsl:value-of select="@name" /> == null)
                    using(var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                        _empty<xsl:value-of select="@name" /> = <xsl:value-of select="$namespace" />.<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />.Accessor.Instance(null).CreateNewT(manager, this.Parent ?? this);
                </xsl:if>
                var ret = new List&lt;<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />&gt;();
                <xsl:if test="not(@notaddempty='true')">
                ret.Add(_empty<xsl:value-of select="@name" />);
                </xsl:if>
              
                if (<xsl:value-of select="@existinglookup" /> != null)
                {
                    <xsl:if test="@addthis='true'">
                    if (IsNew &amp;&amp; !<xsl:value-of select="@existinglookup" />.Any(c => c.<xsl:value-of select="@target" /> == this.<xsl:value-of select="@target" />))
                        ret.Add(this);
                    </xsl:if>
                    ret.AddRange(<xsl:value-of select="@existinglookup" />
                      <xsl:for-each select="bv:filters/bv:filter">
                        <xsl:choose>
                            <xsl:when test="@predicate">
                        .Where(<xsl:value-of select="@predicate" />)
                            </xsl:when>
                            <xsl:when test="@distinct">
                        .Distinct(new <xsl:value-of select="@distinct" />())
                            </xsl:when>
                            <xsl:otherwise>
                        .Where(c => c.<xsl:value-of select="@target" /> == obj.<xsl:value-of select="@name" />)
                            </xsl:otherwise>
                        </xsl:choose>
                      </xsl:for-each>
                    );
                }
                return ret;
            }
        }
            </xsl:when>
            <xsl:when test="@section">
        public <xsl:value-of select="@table" />List <xsl:value-of select="@name" />Lookup
        {
            get { return _<xsl:value-of select="@name" />Lookup; }
        }
        private <xsl:value-of select="@table" />List _<xsl:value-of select="@name" />Lookup = new <xsl:value-of select="@table" />List("<xsl:value-of select="@section" />");
            </xsl:when>
            <xsl:otherwise>
        public List&lt;<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />&gt; <xsl:value-of select="@name" />Lookup
        {
            get { return _<xsl:value-of select="@name" />Lookup; }
        }
        private List&lt;<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />&gt; _<xsl:value-of select="@name" />Lookup = new List&lt;<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />&gt;();
            </xsl:otherwise>
        </xsl:choose>

        </xsl:for-each>
        private BvSelectList _getList(string name)
        {
        <xsl:if test="count(bv:lookups/bv:lookup) > 0">
            switch(name)
            {
            <xsl:for-each select="bv:lookups/bv:lookup">
                case _str_<xsl:value-of select="@name" />:
                    return new BvSelectList(<xsl:value-of select="@name" />Lookup, <xsl:value-of select="$namespace" />.<xsl:value-of select="@table" /><xsl:value-of select="$class_suffix" />._str_<xsl:value-of select="@target" />, null, <xsl:value-of select="@name" />, _str_<xsl:value-of select="@source" />);
            </xsl:for-each>
            <xsl:for-each select="bv:relations/bv:relation[@type='child']">
                case _str_<xsl:value-of select="@name" />:
                    return new BvSelectList(<xsl:value-of select="@name" />, "", "", null, "");
            </xsl:for-each>
            <xsl:for-each select="bv:fields/bv:calculated[@forList='true']">
                case _str_<xsl:value-of select="@name" />:
                    return new BvSelectList(<xsl:value-of select="@name" />, "", "", null, "");
            </xsl:for-each>
            }
        </xsl:if>
            return null;
        }
    </xsl:template>
    
    
    <xsl:template name="lookup-usage">
        <xsl:param name="tablename" />
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            <xsl:for-each select="bv:lookups/bv:lookup[not(@existinglookup)]">
                <xsl:variable name="lookupname">
                    <xsl:choose>
                        <xsl:when test="@section"><xsl:value-of select="@section"/></xsl:when>
                        <xsl:otherwise><xsl:value-of select="@table"/></xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
            if (lookup_object == "<xsl:value-of select="$lookupname" />")
                _getAccessor().LoadLookup_<xsl:value-of select="@name" />(manager, this);
            </xsl:for-each>
        }
        #endregion
    </xsl:template>
    
    <xsl:template name="lookups">
        <xsl:param name="tablename" />
        <xsl:param name="namespace" />
        <xsl:param name="columns" />
            <xsl:for-each select="bv:lookups/bv:lookup[not(@existinglookup)]">
            public void LoadLookup_<xsl:value-of select="@name" />(DbManagerProxy manager, <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                <xsl:variable name="methodname">
                    <xsl:choose>
                        <xsl:when test="@section"><xsl:value-of select="@section"/>_SelectList</xsl:when>
                        <xsl:otherwise>SelectLookupList</xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
                obj.<xsl:value-of select="@name" />Lookup.Clear();
                <xsl:if test="not(@notaddempty='true')">
                obj.<xsl:value-of select="@name" />Lookup.Add(<xsl:value-of select="@name"/>Accessor.CreateNewT(manager, null));
                <xsl:if test="@emptyTextId">
                obj.<xsl:value-of select="@name" />Lookup.Add(<xsl:value-of select="@name"/>Accessor.CreateNewT(manager, null));
                obj.<xsl:value-of select="@name" />Lookup[1].name = eidss.model.Resources.EidssFields.Get("<xsl:value-of select="@emptyTextId" />");
                obj.<xsl:value-of select="@name" />Lookup[1].SetValue(obj.<xsl:value-of select="@name" />Lookup[1].KeyName, "<xsl:value-of select="@emptyKey" />");
                </xsl:if>
                </xsl:if>
                <xsl:if test="@predicate">
                if (new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="@predicate" />)(obj))
                {
                </xsl:if>
                obj.<xsl:value-of select="@name" />Lookup.AddRange(<xsl:value-of select="@name"/>Accessor.<xsl:value-of select="$methodname"/>(manager
                    <xsl:for-each select="bv:params/bv:param">
                        <xsl:choose>
                            <xsl:when test="@var">
                    , <xsl:value-of select="@var" />
                            </xsl:when>
                            <xsl:when test="@lambda">
                    , new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, <xsl:value-of select="@type" />&gt;(<xsl:value-of select="@lambda" />)(obj)
                            </xsl:when>
                            <xsl:when test="@const">
                    , <xsl:value-of select="@const" />
                            </xsl:when></xsl:choose></xsl:for-each>
                    )<xsl:for-each select="bv:filters/bv:filter">
                    <xsl:choose>
                        <xsl:when test="@predicate">
                    .Where(<xsl:value-of select="@predicate" />)
                        </xsl:when>
                        <xsl:when test="@distinct">
                    .Distinct(new <xsl:value-of select="@distinct" />())
                        </xsl:when>
                        <xsl:otherwise>
                    .Where(c => c.<xsl:value-of select="@target" /> == obj.<xsl:value-of select="@name" />)
                        </xsl:otherwise>
                    </xsl:choose>
                    </xsl:for-each>
                    <xsl:if test="not(@isShowDeleted)">
                    .Where(c => (c.intRowStatus == 0) || (c.<xsl:value-of select="@target" /> == obj.<xsl:value-of select="@source" />))
                    </xsl:if>
                    <xsl:if test="@order">
                    .OrderBy(<xsl:value-of select="@order" />)
                    </xsl:if>
                    .ToList());
                <xsl:variable name="source" select="@source" />
              <xsl:if test="not(@notsetforload)">
                <xsl:choose>
                    <xsl:when test="$columns/column[@name=$source]/@type='String'">
                if (!string.IsNullOrEmpty(obj.<xsl:value-of select="@source" />))</xsl:when>
                    <xsl:otherwise>
                if (<xsl:if test="$columns/column[@name=$source]/@nullable='true' or not($columns/column[@name=$source])">obj.<xsl:value-of select="@source" /> != null &amp;&amp; </xsl:if>obj.<xsl:value-of select="@source" /> != 0)</xsl:otherwise>
                </xsl:choose>
                {
                    obj.<xsl:value-of select="@name" /> = obj.<xsl:value-of select="@name" />Lookup
                        .SingleOrDefault(c => c.<xsl:value-of select="@target" /> == obj.<xsl:value-of select="@source" />);
                    <xsl:if test="@hintonly and not(@addthis)">
                    if (obj.<xsl:value-of select="@name" /> == null)
                    {
                        var a = <xsl:value-of select="@name"/>Accessor.CreateNewT(manager, null);
                        a.<xsl:value-of select="@target" /> = obj.<xsl:value-of select="@source" />;
                        obj.<xsl:value-of select="@name" />Lookup.Add(a);
                        obj.<xsl:value-of select="@name" /> = obj.<xsl:value-of select="@name" />Lookup
                            .SingleOrDefault(c => c.<xsl:value-of select="@target" /> == obj.<xsl:value-of select="@source" />);
                    }
                    </xsl:if>
                }
              </xsl:if>
                <xsl:variable name="lookupname">
                   <xsl:choose>
                       <xsl:when test="@section"><xsl:value-of select="@section"/></xsl:when>
                       <xsl:otherwise><xsl:value-of select="@table"/></xsl:otherwise>
                   </xsl:choose>
                </xsl:variable>
                <xsl:if test="@predicate">
                }
                </xsl:if>
              <xsl:if test="not(@notaddlookupmanager)">
                LookupManager.AddObject("<xsl:value-of select="$lookupname" />", obj, <xsl:value-of select="@name"/>Accessor.GetType(), "<xsl:value-of select="$methodname" />"<xsl:if test="@section">
                  , "SelectLookupList"</xsl:if>);
              </xsl:if>
            }
            </xsl:for-each>

            private void _LoadLookups(DbManagerProxy manager, <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                <xsl:for-each select="bv:lookups/bv:lookup[not(@existinglookup)]">
                LoadLookup_<xsl:value-of select="@name" />(manager, obj);
                </xsl:for-each>
            }
    </xsl:template>

</xsl:stylesheet>
