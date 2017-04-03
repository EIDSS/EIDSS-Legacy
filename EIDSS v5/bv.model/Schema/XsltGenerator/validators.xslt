<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />

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
                <xsl:choose><xsl:when test="@shouldAsk='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>
              )).Validate(<xsl:value-of select="$func"/>, <xsl:choose><xsl:when test="@child='true'">item</xsl:when><xsl:otherwise>obj</xsl:otherwise></xsl:choose>, <xsl:choose><xsl:when test="@child='true'">item</xsl:when><xsl:otherwise>obj</xsl:otherwise></xsl:choose>.<xsl:value-of select="@target"/>);
            </xsl:when>
          <xsl:when test="name()='custom_mandatory_validator'">
            (new CustomMandatoryFieldValidator("<xsl:value-of select="@name"/>", "<xsl:value-of select="@name"/>", "",
            <xsl:choose><xsl:when test="@shouldAsk='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>
            )).Validate(obj, obj.<xsl:value-of select="@name"/>, CustomMandatoryField.<xsl:value-of select="@fieldId"/>);

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
                        <xsl:choose><xsl:when test="@shouldAsk='true'">true</xsl:when><xsl:otherwise>false</xsl:otherwise></xsl:choose>
                    )).Validate(obj, <xsl:if test="$child"><xsl:value-of select="$child"/>, </xsl:if><xsl:value-of select="@predicate"/>
              <xsl:if test="@messagePredicate">
                      , <xsl:value-of select="@messagePredicate"/>
              </xsl:if>
                    );
            </xsl:when>
            <xsl:when test="name()='duplicate_validator'">
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
            </xsl:when>
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
                </xsl:text><xsl:value-of select="@method"/>(obj);
            </xsl:when>
          <xsl:when test="name()='custom_validator_manager'">
<xsl:text>
                </xsl:text><xsl:value-of select="@method"/>(manager, obj);
            </xsl:when>
        </xsl:choose>
    </xsl:template>
    
    
</xsl:stylesheet>
