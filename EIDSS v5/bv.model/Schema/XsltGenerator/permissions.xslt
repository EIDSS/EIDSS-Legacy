<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:bv="urn:schemas-bv:objectmodel"
    >

    <xsl:import href="globals.xslt" />

    <xsl:template name="permissions">
        <xsl:param name="tablename" />
            <xsl:if test="bv:properties/@permissionObject or bv:properties/@permissionAction">
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private <xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> m_obj;
            internal Permissions(<xsl:value-of select="$tablename" /><xsl:value-of select="$class_suffix" /> obj)
            {
                m_obj = obj;
            }
            <xsl:if test="bv:properties/@permissionObject">
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionObject" />.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionObject" />.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionObject" />.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionObject" />.Insert"); } }
            </xsl:if>
            <xsl:if test="bv:properties/@permissionAction">
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionAction" />.Execute"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionAction" />.Execute"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionAction" />.Execute"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionAction" />.Execute"); } }
            </xsl:if>
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert &amp;&amp; m_obj.IsNew)); } }
        }
            #endregion
            </xsl:if>
    </xsl:template>

    <xsl:template name="permissions-accessor">
        <xsl:param name="tablename" />
            <xsl:if test="bv:properties/@permissionObject or bv:properties/@permissionAction">
            #region IObjectPermissions
            <xsl:if test="bv:properties/@permissionObject">
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionObject" />.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionObject" />.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionObject" />.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionObject" />.Insert"); } }
            </xsl:if>
            <xsl:if test="bv:properties/@permissionAction">
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionAction" />.Execute"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionAction" />.Execute"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionAction" />.Execute"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("<xsl:value-of select="bv:properties/@permissionAction" />.Execute"); } }
            </xsl:if>
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            </xsl:if>
    </xsl:template>

    
</xsl:stylesheet>
