<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />

  <xsl:template name="generate-chains">
    <xsl:param name="tablename" />
    <xsl:param name="listname" select="''" />
    <xsl:param name="typename" select="''" />

    <xsl:variable name="field" select="@field" />
    <xsl:variable name="container" select="@container" />
    <xsl:variable name="collection" select="@collection" />
    <xsl:variable name="type">
      <xsl:choose>
        <xsl:when test="$typename">
          <xsl:value-of select="$typename"/>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="@type"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="filter">
      <xsl:choose>
        <xsl:when test="@filter">
          <xsl:value-of select="@filter"/>
        </xsl:when>
        <xsl:otherwise>c => !c.IsMarkedToDelete</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="predicate">
      <xsl:choose>
        <xsl:when test="@predicate">
          <xsl:value-of select="@predicate"/>
        </xsl:when>
        <xsl:otherwise>c => true</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="strict">
      <xsl:choose>
        <xsl:when test="@strict">
          <xsl:value-of select="@strict"/>
        </xsl:when>
        <xsl:otherwise>false</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>
    <xsl:variable name="nested">
      <xsl:choose>
        <xsl:when test="@nested">
          <xsl:value-of select="@nested"/>
        </xsl:when>
        <xsl:otherwise>false</xsl:otherwise>
      </xsl:choose>
    </xsl:variable>

    <xsl:if test="@collection and $nested != 'true'">obj.<xsl:value-of select="@collection"/>.Where(<xsl:value-of select="$filter"/>).ToList().ForEach(j =></xsl:if>
    <xsl:if test="$listname"><xsl:value-of select="$listname"/>.Add(</xsl:if>
    new ChainsValidator<xsl:value-of select="$type"/>&lt;<xsl:value-of select="$tablename"/><xsl:value-of select="$class_suffix" />&gt;(obj, "<xsl:value-of select="@field"/>", <xsl:value-of select="$predicate"/>, 
      <xsl:choose><xsl:when test="$nested = 'true'">j.<xsl:value-of select="@field"/></xsl:when><xsl:when test="@collection">j.<xsl:value-of select="@field"/></xsl:when><xsl:when test="@value"><xsl:value-of select="@value"/></xsl:when><xsl:otherwise><xsl:choose><xsl:when test="@container">obj.<xsl:value-of select="@container"/> == null ? null : obj.<xsl:value-of select="@container"/>.<xsl:value-of select="@field"/></xsl:when><xsl:otherwise>obj.<xsl:value-of select="@field"/></xsl:otherwise></xsl:choose></xsl:otherwise></xsl:choose>,
      <xsl:choose><xsl:when test="$nested = 'true'">j.GetType()</xsl:when><xsl:when test="@collection">j.GetType()</xsl:when><xsl:when test="@value">null</xsl:when><xsl:otherwise><xsl:choose><xsl:when test="@container">obj.<xsl:value-of select="@container"/> == null ? null : obj.<xsl:value-of select="@container"/>.GetType()</xsl:when><xsl:otherwise>obj.GetType()</xsl:otherwise></xsl:choose></xsl:otherwise></xsl:choose>,
      <xsl:value-of select="$strict"/>, list<xsl:value-of select="@field"/> => {
    <xsl:for-each select="bv:item">
      <xsl:call-template name="generate-chains">
        <xsl:with-param name="tablename" select="$tablename" />
        <xsl:with-param name="listname" select="concat('list', $field)" />
        <xsl:with-param name="typename" select="$type" />
      </xsl:call-template>
    </xsl:for-each>
    })<xsl:choose><xsl:when test="$listname">)</xsl:when><xsl:otherwise>.Process()</xsl:otherwise></xsl:choose><xsl:if test="@collection and $nested != 'true'">)</xsl:if>;
  </xsl:template>

    <xsl:template name="generate-validator">
        <xsl:param name="tablename" />
        <xsl:param name="child" />
        <xsl:variable name="field">
            <xsl:choose>
                <xsl:when test="@target">
                    <xsl:value-of select="@target"/>
                </xsl:when>
                <xsl:when test="@field">
                    <xsl:value-of select="@field"/>
                </xsl:when>
            </xsl:choose>
        </xsl:variable>
        <xsl:choose>
            <xsl:when test="name()='required_validator'">
                <xsl:variable name="property">
                    <xsl:choose>
                        <xsl:when test="@property"><xsl:value-of select="@property"/></xsl:when>
                        <xsl:otherwise><xsl:value-of select="@target"/></xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
                <xsl:variable name="label">
                    <xsl:choose>
                        <xsl:when test="@label"><xsl:value-of select="@label"/></xsl:when>
                        <xsl:otherwise><xsl:value-of select="@field"/></xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
                <xsl:variable name="func">
                    <xsl:choose>
                        <xsl:when test="@predicate">
                            <xsl:value-of select="@predicate"/>
                        </xsl:when>
                        <xsl:otherwise>
                            <xsl:value-of select="'c => true'"/>
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
                (new RequiredValidator( "<xsl:value-of select="$field"/>", "<xsl:value-of select="$property"/>","<xsl:value-of select="$label"/>",
                ValidationEventType.<xsl:choose><xsl:when test="@type"><xsl:value-of select="@type"/></xsl:when><xsl:otherwise>Error</xsl:otherwise></xsl:choose>
              )).Validate(<xsl:value-of select="$func"/>, <xsl:choose><xsl:when test="@child='true'">item</xsl:when><xsl:otherwise>obj</xsl:otherwise></xsl:choose>, <xsl:choose><xsl:when test="@child='true'">item</xsl:when><xsl:otherwise>obj</xsl:otherwise></xsl:choose>.<xsl:value-of select="@target"/>);
            </xsl:when>
          <xsl:when test="name()='custom_mandatory_validator'">
            (new CustomMandatoryFieldValidator("<xsl:value-of select="@name"/>", "<xsl:value-of select="@name"/>", "<xsl:value-of select="@label"/>",
            ValidationEventType.<xsl:choose><xsl:when test="@type"><xsl:value-of select="@type"/></xsl:when><xsl:otherwise>Error</xsl:otherwise></xsl:choose>
            )).Validate(obj, obj.<xsl:value-of select="@name"/>, CustomMandatoryField.<xsl:value-of select="@fieldId"/>,
            <xsl:choose><xsl:when test="@predicate"><xsl:value-of select="@predicate"/></xsl:when><xsl:otherwise>c => true</xsl:otherwise></xsl:choose>);

          </xsl:when>
            <xsl:when test="name()='predicate_validator'">
                <xsl:variable name="property">
                    <xsl:choose>
                        <xsl:when test="@property"><xsl:value-of select="@property"/></xsl:when>
                        <xsl:when test="@container"><xsl:value-of select="@container"/></xsl:when>
                        <xsl:otherwise><xsl:value-of select="@field"/></xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
               <xsl:variable name="label">
                    <xsl:choose>
                        <xsl:when test="@label"><xsl:value-of select="@label"/></xsl:when>
                        <xsl:otherwise><xsl:value-of select="@field"/></xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
                (new PredicateValidator("<xsl:value-of select="@message"/>", "<xsl:value-of select="$field"/>", "<xsl:value-of select="$property"/>", "<xsl:value-of select="$label"/>",
              new object[] {
              <xsl:for-each select="bv:params/bv:param">
                        <xsl:if test="position() > 1">, </xsl:if>new Func&lt;<xsl:value-of select="$tablename"/><xsl:value-of select="$class_suffix" />, <xsl:value-of select="@type"/>&gt;(<xsl:value-of select="@lambda"/>)(obj)
                        </xsl:for-each>},
                        ValidationEventType.<xsl:choose><xsl:when test="@type"><xsl:value-of select="@type"/></xsl:when><xsl:otherwise>Error</xsl:otherwise></xsl:choose>
                    )).Validate(obj, <xsl:if test="$child"><xsl:value-of select="$child"/>, </xsl:if><xsl:value-of select="@predicate"/>
              <xsl:if test="@messagePredicate">
                      , <xsl:value-of select="@messagePredicate"/>
              </xsl:if>
                    );
            </xsl:when>

          <xsl:when test="name()='duplicate_list_validator'">
              <xsl:variable name="filter">
                  <xsl:choose>
                      <xsl:when test="@filter"><xsl:value-of select="@filter"/></xsl:when>
                      <xsl:otherwise>c => !c.IsMarkedToDelete</xsl:otherwise>
                  </xsl:choose>
              </xsl:variable>
              new DuplicateListValidator("").Validate(obj, 
              o => o.<xsl:value-of select="@collection"/>.Where(<xsl:value-of select="$filter"/>)
                .Aggregate(new List&lt;Tuple&lt;<xsl:value-of select="@type"/>, int&gt;&gt;(), (list, test) => 
                { 
                    var item = list.Find(c => true
                      <xsl:for-each select="bv:item">
                        &amp;&amp; c.Item1.<xsl:value-of select="@field"/> == test.<xsl:value-of select="@field"/>
                      </xsl:for-each>
                      );
                      if (item == null)
                      list.Add(new Tuple&lt;<xsl:value-of select="@type"/>, int&gt;(test, 1));
                    else
                    {
                        list.Remove(item);
                        list.Add(new Tuple&lt;<xsl:value-of select="@type"/>, int&gt;(test, item.Item2 + 1));
                    }
                    return list;
                })
                .Where(c => c.Item2 > 1).Select(c => c.Item1).FirstOrDefault(),
                    (o, i) => new Tuple&lt;
                      <xsl:for-each select="bv:item[@inMsg='true']">
                        <xsl:if test="position()>1">,</xsl:if>string, object
                      </xsl:for-each>
                      &gt;(
                      <xsl:for-each select="bv:item[@inMsg='true']">
                        <xsl:if test="position()>1">,</xsl:if>"<xsl:value-of select="@field"/>", 
                        <xsl:choose>
                          <xsl:when test="@lookup">
                        i.<xsl:value-of select="@lookup"/>Lookup.First(c => c.Key.Equals(i.<xsl:value-of select="@field"/>)).ToStringProp
                          </xsl:when>
                          <xsl:otherwise>
                        i.<xsl:value-of select="@field"/>
                          </xsl:otherwise>
                        </xsl:choose>
                      </xsl:for-each>
                      )
                );
            
          </xsl:when>

          <!--xsl:when test="name()='duplicate_validator'">
                <xsl:variable name="property">
                    <xsl:choose>
                        <xsl:when test="@property"><xsl:value-of select="@property"/></xsl:when>
                        <xsl:when test="@container"><xsl:value-of select="@container"/></xsl:when>
                        <xsl:otherwise><xsl:value-of select="@field"/></xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
               <xsl:variable name="label">
                    <xsl:choose>
                        <xsl:when test="@label"><xsl:value-of select="@label"/></xsl:when>
                        <xsl:otherwise><xsl:value-of select="@field"/></xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
                <xsl:variable name="func">
                    <xsl:choose>
                        <xsl:when test="@predicate">
                            <xsl:value-of select="@predicate"/>
                        </xsl:when>
                        <xsl:otherwise>
                                        (master,i) => master.<xsl:value-of select="@container"/>.Where(c => 
                                                            (long)c.Key != (long)i.Key 
                                                            &amp;&amp; c.<xsl:value-of select="$field"/> == i.<xsl:value-of select="$field"/>
                                                            &amp;&amp; !c.IsMarkedToDelete
                                                            ).Count() == 0
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
                                  (new DuplicateValueValidator("<xsl:value-of select="$field"/>", "<xsl:value-of select="$property"/>","<xsl:value-of select="$label"/>",
                                  <xsl:choose><xsl:when test="@shouldAsk='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>
                                      )).Validate(obj, <xsl:if test="$child"><xsl:value-of select="$child"/>, </xsl:if><xsl:value-of select="$func"/>
                                      );
            </xsl:when>
            <xsl:when test="name()='duplicate_reference_validator'">
                <xsl:variable name="property">
                    <xsl:choose>
                        <xsl:when test="@property"><xsl:value-of select="@property"/></xsl:when>
                        <xsl:when test="@container"><xsl:value-of select="@container"/></xsl:when>
                        <xsl:otherwise><xsl:value-of select="@field"/></xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
               <xsl:variable name="label">
                    <xsl:choose>
                        <xsl:when test="@label"><xsl:value-of select="@label"/></xsl:when>
                        <xsl:otherwise><xsl:value-of select="@field"/></xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
                <xsl:variable name="func">
                    <xsl:choose>
                        <xsl:when test="@predicate">
                            <xsl:value-of select="@predicate"/>
                        </xsl:when>
                        <xsl:otherwise>
                                        (master,i) => master.<xsl:value-of select="@container"/>.Where(c => 
                                                            (long)c.Key != (long)i.Key 
                                                            &amp;&amp; c.<xsl:value-of select="$field"/> == i.<xsl:value-of select="$field"/>
                                                            &amp;&amp; !c.IsMarkedToDelete
                                                            ).Count() == 0
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
                                  (new ReferenceDuplicateValueValidator("<xsl:value-of select="$field"/>", "<xsl:value-of select="$property"/>","<xsl:value-of select="$label"/>",
                                  <xsl:choose><xsl:when test="@shouldAsk='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>
                                      )).Validate(obj, <xsl:if test="$child"><xsl:value-of select="$child"/>, </xsl:if><xsl:value-of select="$func"/>
                                      );
            </xsl:when-->
          <!--xsl:when test="name()='required_child_validator'">
            <xsl:variable name="property">
              <xsl:choose>
                <xsl:when test="@property">
                  <xsl:value-of select="@property"/>
                </xsl:when>
                <xsl:when test="@container">
                  <xsl:value-of select="@container"/>
                </xsl:when>
                <xsl:otherwise>
                  <xsl:value-of select="@field"/>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:variable>
               <xsl:variable name="label">
                    <xsl:choose>
                        <xsl:when test="@label"><xsl:value-of select="@label"/></xsl:when>
                        <xsl:otherwise><xsl:value-of select="@field"/></xsl:otherwise>
                    </xsl:choose>
                </xsl:variable>
            <xsl:variable name="func">
              <xsl:choose>
                <xsl:when test="@predicate">
                  <xsl:value-of select="@predicate"/>
                </xsl:when>
                <xsl:otherwise>                             (c,i) => !string.IsNullOrEmpty(i.<xsl:value-of select="$field"/>)</xsl:otherwise>
              </xsl:choose>
            </xsl:variable>
                                  (new RequiredChildListValidator("<xsl:value-of select="$field"/>", "<xsl:value-of select="$property"/>","<xsl:value-of select="$label"/>",
                                  <xsl:choose><xsl:when test="@shouldAsk='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>
                                      )).Validate(obj, <xsl:if test="$child">
              <xsl:value-of select="$child"/>,
            </xsl:if><xsl:value-of select="$func"/>
                                      );
          </xsl:when-->
          <xsl:when test="name()='custom_validator'">
<xsl:text>
                </xsl:text><xsl:value-of select="@method"/>(obj<xsl:if test="$child">, <xsl:value-of select="$child"/></xsl:if>);
            </xsl:when>
          <xsl:when test="name()='custom_validator_manager'">
<xsl:text>
                </xsl:text><xsl:value-of select="@method"/>(manager, obj);
            </xsl:when>
        </xsl:choose>
    </xsl:template>
    
    
</xsl:stylesheet>
