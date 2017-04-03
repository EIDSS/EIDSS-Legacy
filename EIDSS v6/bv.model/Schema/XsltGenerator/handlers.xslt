<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />
    <xsl:import href="validators.xslt" />

    <xsl:template name="setup-handlers">
        <xsl:param name="tablename" />
            private void _SetupChildHandlers(<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj, object newobj)
            {
                <xsl:if test="count(bv:validators/bv:chains//*[@collection]) > 0">
                  <xsl:for-each select="bv:validators/bv:chains//*[@collection]">
                    <xsl:variable name="filter">
                      <xsl:choose>
                        <xsl:when test="@filter">
                          <xsl:value-of select="@filter"/>
                        </xsl:when>
                        <xsl:otherwise>c => !c.IsMarkedToDelete</xsl:otherwise>
                      </xsl:choose>
                    </xsl:variable>
                foreach(var o in obj.<xsl:value-of select="@collection"/>.Where(<xsl:value-of select="$filter"/>))
                {
                    if (newobj == null || newobj == o)
                    {
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "<xsl:value-of select="@field"/>")
                            {
                                var ex = ChainsValidate(obj);
                                if (ex != null &amp;&amp; !obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("<xsl:value-of select="@field"/>");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                            <xsl:for-each select="bv:item[@nested='true']">
                            if (e.PropertyName == "<xsl:value-of select="@field"/>")
                            {
                                var ex = ChainsValidate(obj);
                                if (ex != null &amp;&amp; !obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("<xsl:value-of select="@field"/>");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                            </xsl:for-each>
                        };
                        o._SetupMainHandler();
                    }
                }
                  </xsl:for-each>
                </xsl:if>
            
                <xsl:if test="count(bv:validators/bv:chains//*[@container]) > 0">
                  <xsl:for-each select="bv:validators/bv:chains//*[@container]">
                    if (obj.<xsl:value-of select="@container"/> != null &amp;&amp; (newobj == null || newobj == obj.<xsl:value-of select="@container"/>))
                    {
                        var o = obj.<xsl:value-of select="@container"/>;
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            if (e.PropertyName == "<xsl:value-of select="@field"/>")
                            {
                                var ex = ChainsValidate(obj);
                                if (ex != null &amp;&amp; !obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("<xsl:value-of select="@field"/>");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                    }
                  </xsl:for-each>
                </xsl:if>
            
                <xsl:if test="count(bv:validators/bv:childchange/*) > 0">
                    <xsl:for-each select="bv:validators/bv:childchange/bv:container">
                        <xsl:choose>
                            <xsl:when test="@filter">
                foreach(var o in obj.<xsl:value-of select="@name"/>.Where(<xsl:value-of select="@filter"/>))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            </xsl:when>
                            <xsl:otherwise>
                    if (newobj == null || newobj == obj.<xsl:value-of select="@name"/>)
                    {
                        var o = obj.<xsl:value-of select="@name"/>;
                            </xsl:otherwise>
                        </xsl:choose>
                        var item = o;
                        o._RevokeMainHandler();
                        o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                        {
                            try
                            {
                                if (e.PropertyName == "<xsl:value-of select="@field"/>")
                                {
                                <xsl:for-each select="*">
                                    <xsl:call-template name="generate-validator">
                                        <xsl:with-param name="tablename" select="$tablename" />
                                        <xsl:with-param name="child" select="'item'" />
                                    </xsl:call-template>
                                </xsl:for-each>
                                }
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    item.LockNotifyChanges();
                                    item.CancelMemberLastChanges("<xsl:value-of select="@field"/>");
                                    obj.OnValidationEnd(ex);
                                    item.UnlockNotifyChanges();
                                }
                            }
                        };
                        o._SetupMainHandler();
                        <xsl:choose>
                            <xsl:when test="@filter">
                    }
                }
                            </xsl:when>
                            <xsl:otherwise>
                    }
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:for-each>
                </xsl:if>
            
                <xsl:if test="count(bv:handlers/bv:childhandler/*) > 0">
                    <xsl:for-each select="bv:handlers/bv:childhandler/*">
                        <xsl:choose>
                            <xsl:when test="@filter">
                foreach(var o in obj.<xsl:value-of select="@container"/>.Where(<xsl:value-of select="@filter"/>))
                {
                    if (newobj == null || newobj == o)
                    {                    
                            </xsl:when>
                            <xsl:otherwise>
                    if (newobj == null || newobj == obj.<xsl:value-of select="@container"/>)
                    {
                        var o = obj.<xsl:value-of select="@container"/>;
                            </xsl:otherwise>
                        </xsl:choose>
                        if (o != null)
                        {
                            var item = o;
                            o.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                            {
                                if (e.PropertyName == "<xsl:value-of select="@field"/>")
                                {
                                <xsl:call-template name="generate-handler">
                                    <xsl:with-param name="tablename" select="$tablename" />
                                </xsl:call-template>
                                }
                            };
                        }    
                        <xsl:choose>
                            <xsl:when test="@filter">
                    }
                }
                            </xsl:when>
                            <xsl:otherwise>
                    }
                            </xsl:otherwise>
                        </xsl:choose>
                    </xsl:for-each>
                </xsl:if>
            }
            
            private void _SetupHandlers(<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                <xsl:if test="count(bv:validators/bv:chains//*[@collection]) > 0">
                  <xsl:for-each select="bv:validators/bv:chains//*[@collection]">
                obj.<xsl:value-of select="@collection"/>.ListChanged += delegate(object sender, ListChangedEventArgs e)
                    {
                        if (e.ListChangedType == ListChangedType.ItemAdded)
                        {
                          var ex = ChainsValidate(obj);
                          if (ex != null &amp;&amp; !obj.OnValidation(ex))
                          {
                              if (obj.<xsl:value-of select="@collection"/>.Count > e.NewIndex)
                                  obj.<xsl:value-of select="@collection"/>.RemoveAt(e.NewIndex);
                          }
                        }
                    };
                  </xsl:for-each>
                </xsl:if>
            
            
                <xsl:if test="count(bv:validators/bv:chains//*[not(@container) and not(@collection) and not(@value) and not(@nested='true')]) > 0">
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    <xsl:for-each select="bv:validators/bv:chains//*[not(@container) and not(@collection) and not(@value) and not(@nested='true')]">
                        if (e.PropertyName == _str_<xsl:value-of select="@field"/>)
                        {
                                var ex = ChainsValidate(obj);
                                if (ex != null &amp;&amp; !obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_<xsl:value-of select="@field"/>);
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                        }
                    </xsl:for-each>
                    };
                </xsl:if>
            
            
                <xsl:if test="count(bv:validators/bv:childchangelist/*) > 0">
                    <xsl:for-each select="bv:validators/bv:childchangelist/*">
                obj.<xsl:value-of select="@container"/>.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    if (e.ListChangedType == ListChangedType.ItemAdded)
                    {
                        try
                        {
                            for (int index = 0; index &lt; obj.<xsl:value-of select="@container"/>.Count; index++)
                            {
                                if (index != e.NewIndex)
                                {
                                    var item = obj.<xsl:value-of select="@container"/>[index];
                        <xsl:call-template name="generate-validator">
                            <xsl:with-param name="tablename" select="$tablename" />
                            <xsl:with-param name="child" select="'item'" />
                        </xsl:call-template>
                                }
                            }
                        }
                        catch (ValidationModelException ex)
                        {
                            if (!obj.OnValidation(ex))
                            {
                                if (obj.<xsl:value-of select="@container"/>.Count > e.NewIndex)
                                    obj.<xsl:value-of select="@container"/>.RemoveAt(e.NewIndex);
                                obj.OnValidationEnd(ex);
                            }
                        }
                    }
                };
                    </xsl:for-each>
                </xsl:if>

                <xsl:if test="count(bv:validators/bv:childaddlist/*) > 0">
                    <xsl:for-each select="bv:validators/bv:childaddlist">
                obj.<xsl:value-of select="@container"/>.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    if (e.ListChangedType == ListChangedType.ItemAdded &amp;&amp; obj.<xsl:value-of select="@container"/>.Count > e.NewIndex)
                    {
                        try
                        {
                            var item = obj.<xsl:value-of select="@container"/>[e.NewIndex];
                      <xsl:for-each select="*">
                        <xsl:call-template name="generate-validator">
                          <xsl:with-param name="tablename" select="$tablename" />
                          <xsl:with-param name="child" select="'item'" />
                        </xsl:call-template>
                      </xsl:for-each>
                        }
                        catch (ValidationModelException ex)
                        {
                            if (!obj.OnValidation(ex))
                            {
                                if (obj.<xsl:value-of select="@container"/>.Count > e.NewIndex)
                                    obj.<xsl:value-of select="@container"/>.RemoveAt(e.NewIndex);
                                obj.OnValidationEnd(ex);
                            }
                        }
                    }
                };
                    </xsl:for-each>
                </xsl:if>
      
                <xsl:if test="count(bv:handlers/bv:childaddlist/*) > 0">
                    <xsl:for-each select="bv:handlers/bv:childaddlist/*">
                obj.<xsl:value-of select="@container"/>.ListChanged += delegate(object sender, ListChangedEventArgs e)
                {
                    <xsl:call-template name="generate-handler">
                        <xsl:with-param name="tablename" select="$tablename" />
                    </xsl:call-template>
                };
                    </xsl:for-each>
                </xsl:if>
      
                <xsl:variable name="lookups"><xsl:copy-of select="bv:lookups" /></xsl:variable>
                <xsl:if test="count(bv:validators/bv:change/*) + count(bv:handlers/bv:fieldhandler/*[not(@object)]) > 0">
                obj.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                    <xsl:for-each select="bv:validators/bv:change/*">
                        if (e.PropertyName == _str_<xsl:value-of select="@field"/>)
                        {
                            try
                            {
                            <xsl:call-template name="generate-validator">
                                <xsl:with-param name="tablename" select="$tablename" />
                            </xsl:call-template>
                            }
                            catch(ValidationModelException ex)
                            {
                                if (!obj.OnValidation(ex))
                                {
                                    obj.LockNotifyChanges();
                                    obj.CancelMemberLastChanges(_str_<xsl:value-of select="@field"/>);<xsl:variable name="field" select="@field" /><xsl:for-each select="msxsl:node-set($lookups)/bv:lookups/bv:lookup[@source=$field]">
                                    obj._<xsl:value-of select="@name" /> = obj.<xsl:value-of select="@name" />Lookup.Where(a => a.<xsl:value-of select="@target"/> == obj.<xsl:value-of select="@source"/>).SingleOrDefault();</xsl:for-each>
                                    obj.OnValidationEnd(ex);
                                    obj.UnlockNotifyChanges();
                                }
                                <xsl:if test="@onYesAsk">
                                else if (ex.ShouldAsk)
                                {
                                    obj.LockNotifyChanges();
                                    new Action&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />&gt;(<xsl:value-of select="@onYesAsk" />)(obj);
                                    obj.UnlockNotifyChanges();
                                }
                                </xsl:if>
                            }
                        }
                    </xsl:for-each>
                    <xsl:for-each select="bv:handlers/bv:fieldhandler/*[not(@object)]">
                        if (e.PropertyName == _str_<xsl:value-of select="@field"/>)
                        {
                    <xsl:call-template name="generate-handler">
                        <xsl:with-param name="tablename" select="$tablename" />
                    </xsl:call-template>
                        }
                    </xsl:for-each>
                    };
                </xsl:if>
                <xsl:for-each select="bv:handlers/bv:fieldhandler/*[@object]">
                obj.<xsl:value-of select="@object"/>.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                    {
                        if (e.PropertyName == _str_<xsl:value-of select="@field"/>)
                        {
                        <xsl:call-template name="generate-handler">
                            <xsl:with-param name="tablename" select="$tablename" />
                        </xsl:call-template>
                        }
                    };
                </xsl:for-each>
            }
    </xsl:template>

    <xsl:template name="generate-handler">
        <xsl:param name="tablename" />
        <xsl:choose>
            <xsl:when test="name()='scalar_handler'">
                obj.<xsl:value-of select="@target"/> = (new <xsl:value-of select="@class"/>()).Handler(obj,
                    obj.<xsl:value-of select="@field"/>, obj.<xsl:value-of select="@field"/>_Previous, obj.<xsl:value-of select="@target"/>,
                    <xsl:value-of select="@lambda"/>);
            </xsl:when>
            <xsl:when test="name()='value_handler'">
                obj.<xsl:value-of select="@target"/> = <xsl:value-of select="@value"/>;</xsl:when>
            <xsl:when test="name()='lambda_handler'">
                obj.<xsl:value-of select="@target"/> = new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, <xsl:value-of select="@type" />&gt;(<xsl:value-of select="@lambda" />)(obj);</xsl:when>
            <xsl:when test="name()='copy_list_handler'">
                if (obj.<xsl:value-of select="@list"/> != null) 
                    obj.<xsl:value-of select="@list"/>.ForEach(t => { t.<xsl:value-of select="@target"/> = obj.<xsl:value-of select="@source"/>; } );</xsl:when>
            <xsl:when test="name()='lambda_list_handler'">
                if (obj.<xsl:value-of select="@list"/> != null) 
                    obj.<xsl:value-of select="@list"/>.ForEach(t => { t.<xsl:value-of select="@target"/> = new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, <xsl:value-of select="@type" />&gt;(<xsl:value-of select="@lambda" />)(obj); } );</xsl:when>
            <xsl:when test="name()='lookup_handler'">
              <xsl:if test="@predicate">
                if (new Func&lt;<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" />, bool&gt;(<xsl:value-of select="@predicate"/>)(obj))
              </xsl:if>
                  using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    LoadLookup_<xsl:value-of select="@lookup"/>(manager, obj);</xsl:when>
            <xsl:when test="name()='custom_handler'">
                <xsl:value-of select="bv:text"/>
            </xsl:when>
        </xsl:choose>
    </xsl:template>
    
</xsl:stylesheet>
