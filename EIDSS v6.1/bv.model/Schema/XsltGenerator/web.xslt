<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:bv="urn:schemas-bv:objectmodel"
	xmlns:util="urn:util">

    <xsl:import href="globals.xslt" />

    <xsl:template name="parse-form-collection">
        <xsl:param name="tablename" />
        <xsl:param name="columns" />
        <xsl:param name="tablekeys" />
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" &amp;&amp; i._type != "Child" &amp;&amp; i._type != "Relation" &amp;&amp; i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        <xsl:for-each select="bv:relations/bv:relation">
            <xsl:choose>
                <xsl:when test="@type='child' and not(@self) and not(@recursive)">
            if (_<xsl:value-of select="@name" /> != null) _<xsl:value-of select="@name" />.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                </xsl:when>
                <xsl:when test="@type='link'">
            if (_<xsl:value-of select="@name" /> != null) _<xsl:value-of select="@name" />.ParseFormCollection(form, bParseLookups, bParseRelations);
                </xsl:when>
                <xsl:when test="@type='sibling'">
            if (_<xsl:value-of select="@name" /> != null) _<xsl:value-of select="@name" />.ParseFormCollection(form, bParseLookups, bParseRelations);
                </xsl:when>
                <xsl:otherwise>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:for-each>
            }
            ParsedFormCollection(form);
        }
    </xsl:template>

    <xsl:template name="web-grid">
        <xsl:param name="tablename" />
        <xsl:param name="columns" />
        <xsl:param name="tablekeys" />
        <xsl:if test="count(bv:grid/bv:item) > 0">
        #region Class for web grid
        public class <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />GridModel : IGridModelItem<xsl:if test="bv:grid/@sequence='true'">, IGridModelItemSequence</xsl:if>
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        <xsl:for-each select="bv:grid/bv:item">
            <xsl:variable name="name" select="@name" />
            <!--xsl:if test="@required='true'">[Required]</xsl:if>
            <xsl:if test="@readonly='true'">[ReadOnly(true)]</xsl:if>
            <xsl:if test="@datatype">[DataType(<xsl:value-of select="@datatype"/>)]</xsl:if-->
            <xsl:variable name="type">
              <xsl:choose>
                <xsl:when test="@type">
                  <xsl:value-of select="@type"/>
                </xsl:when>
                <xsl:when test="$columns/column[@name=$name]/@type = 'DateTime'">
                  <xsl:text>DateTimeWrap</xsl:text><xsl:value-of select="@format"/>
                </xsl:when>
                <xsl:when test="$columns/column[@name=$name]/@type = 'DateTime?'">
                  <xsl:text>DateTimeWrap</xsl:text><xsl:value-of select="@format"/>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="$columns/column[@name=$name]/@type"/>
                </xsl:otherwise>
              </xsl:choose>            
            </xsl:variable>
            <xsl:if test="@uihint">[System.ComponentModel.DataAnnotations.UIHint("<xsl:value-of select="@uihint"/>")]</xsl:if>
            public <xsl:value-of select="$type"/><xsl:text> </xsl:text><xsl:value-of select="$name"/> { get; set; }
        </xsl:for-each>
        }
        public partial class <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />GridModelList : List&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />GridModel&gt;, IGridModelList, IGridModelListLoad<xsl:if test="bv:grid/@sequence='true'">, IGridModelListSequence</xsl:if>
        {
            public long ListKey { get; protected set; }
            public List&lt;string&gt; Columns { get; protected set; }
            public List&lt;string&gt; Hiddens { get; protected set; }
            public Dictionary&lt;string, string&gt; Labels { get; protected set; }
            public Dictionary&lt;string, ActionMetaItem&gt; Actions { get; protected set; }
            public List&lt;string&gt; Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />GridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;, errMes);
            }
            public <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />GridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;, errMes);
            }
            public <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />GridModelList(long key, IEnumerable&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt; items)
            {
                LoadGridModelList(key, items, null);
            }
            public <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />GridModelList(long key)
            {
                LoadGridModelList(key, new List&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;(), null);
            }
            partial void filter(List&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt; items);
            private void LoadGridModelList(long key, IEnumerable&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt; items, string errMes)
            {
                ListKey = key;
                <xsl:choose>
                    <xsl:when test="bv:grid/bv:item[@predicate]">
                Columns = new List&lt;string&gt;();
                <xsl:for-each select="bv:grid/bv:item[not(@visible='false')]">
                    <xsl:if test="@predicate">
                    if (new Func&lt;bool&gt;(<xsl:value-of select="@predicate" />)())
                    </xsl:if>
                    Columns.Add("<xsl:value-of select="@name" />");
                </xsl:for-each>
                    </xsl:when>
                    <xsl:otherwise>
                Columns = new List&lt;string&gt; {<xsl:for-each select="bv:grid/bv:item[not(@visible='false' or @useInWeb='false')]"><xsl:if test="position()>1">,</xsl:if>_str_<xsl:value-of select="@name" /></xsl:for-each>};
                    </xsl:otherwise>
                </xsl:choose>
                Hiddens = new List&lt;string&gt; {<xsl:for-each select="bv:grid/bv:item[@visible='false' or @useInWeb='false']"><xsl:if test="position()>1">,</xsl:if>_str_<xsl:value-of select="@name" /></xsl:for-each>};
                Keys = new List&lt;string&gt; {<xsl:for-each select="bv:grid/bv:item[@key='true']"><xsl:if test="position()>1">,</xsl:if>_str_<xsl:value-of select="@name" /></xsl:for-each>};
                Labels = new Dictionary&lt;string, string&gt; {<xsl:for-each select="bv:grid/bv:item[not(@visible='false' or @useInWeb='false')]"><xsl:if test="position()>1">,</xsl:if><xsl:variable name="columnname" select="@name"/>{_str_<xsl:value-of select="@name" />, <xsl:choose><xsl:when test="../../bv:labels/bv:item[@name=$columnname]">"<xsl:value-of select="../../bv:labels/bv:item[@name=$columnname]/@labelId" />"</xsl:when><xsl:otherwise>_str_<xsl:value-of select="@name" /></xsl:otherwise></xsl:choose>}</xsl:for-each>};
                Actions = new Dictionary&lt;string, ActionMetaItem&gt; {<xsl:for-each select="bv:grid/bv:item[@action]"><xsl:if test="position()>1">,</xsl:if>{_str_<xsl:value-of select="@name" />, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "<xsl:value-of select="@action" />")}</xsl:for-each>};
                <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />GridModel()
                {
                    <xsl:for-each select="bv:grid/bv:item">
                      <xsl:variable name="itemname" select="@name" />
                        <xsl:choose>
                          <xsl:when test="@key='true'">
                        <xsl:if test="position()>1">,</xsl:if>ItemKey=c.<xsl:value-of select="@name" />
                          </xsl:when>
                          <xsl:when test="count(../../bv:personaldata/bv:group/bv:item[@name=$itemname])>0 and substring($itemname, 1, 3) = 'dat'">
                        <xsl:if test="position()>1">,</xsl:if><xsl:value-of select="@name" />=c.IsHiddenPersonalData("<xsl:value-of select="@name" />")?new DateTimeWrap("****"):new DateTimeWrap(c.<xsl:value-of select="@name" />)
                          </xsl:when>
                          <xsl:when test="count(../../bv:personaldata/bv:group/bv:item[@name=$itemname])>0 and not(@visible='false')">
                        <xsl:if test="position()>1">,</xsl:if><xsl:value-of select="@name" />=c.IsHiddenPersonalData("<xsl:value-of select="@name" />")?"****":c.<xsl:value-of select="@name" />
                          </xsl:when>
                          <xsl:otherwise>
                        <xsl:if test="position()>1">,</xsl:if><xsl:value-of select="@name" />=c.<xsl:value-of select="@name" />
                          </xsl:otherwise>
                        </xsl:choose>
                    </xsl:for-each>
                }));
                if (Count > 0)
                {
                    this.Last().ErrorMessage = errMes;
                }
            }
        }
        #endregion
        </xsl:if>
    </xsl:template>

</xsl:stylesheet>
