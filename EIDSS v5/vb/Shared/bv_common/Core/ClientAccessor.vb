Imports bv.model.Model.Core

Namespace Core
    Public Class ClientAccessor
        Private Shared m_IdleManagerFactory As IIdleManagerFactory
        'Private Shared m_BusinessObjectFactory As IBusinessObjectFactory
        'Private Shared m_SecurityManager As ISecurityManager
        'Private Shared m_ReportFactory As IReportFactory
        'Private Shared m_BarcodeFactory As IBarcodeFactory
        Public Shared Property IdleManagerFactorty() As IIdleManagerFactory
            Get
                Return m_IdleManagerFactory
            End Get
            Set(ByVal value As IIdleManagerFactory)
                m_IdleManagerFactory = value
            End Set
        End Property
        'Public Shared Property BusinessObjectFactory() As IBusinessObjectFactory
        '    Get
        '        Return m_BusinessObjectFactory
        '    End Get
        '    Set(ByVal value As IBusinessObjectFactory)
        '        m_BusinessObjectFactory = value
        '    End Set
        'End Property
        'Public Shared Property SecurityManager() As ISecurityManager
        '    Get
        '        Return m_SecurityManager
        '    End Get
        '    Set(ByVal value As ISecurityManager)
        '        m_SecurityManager = value
        '    End Set
        'End Property

        'Public Shared Property ReportFactory() As IReportFactory
        '    Get
        '        Return m_ReportFactory
        '    End Get
        '    Set(ByVal value As IReportFactory)
        '        m_ReportFactory = value
        '    End Set
        'End Property

        'Public Shared Property BarcodeFactory() As IBarcodeFactory
        '    Get
        '        Return m_BarcodeFactory
        '    End Get
        '    Set(ByVal value As IBarcodeFactory)
        '        m_BarcodeFactory = value
        '    End Set
        'End Property
    End Class

End Namespace
