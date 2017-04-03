Imports bv.common.db.Security

Namespace Core
    Public Class WinClient
        Public Shared Sub Init()
            bv.common.Core.ClientAccessor.IdleManagerFactorty = New WinIdleManagerFactory
            'bv.common.Core.ClientAccessor.BusinessObjectFactory = New BusinessObjectFactory
            'bv.common.Core.ClientAccessor.SecurityManager = New SecurityManager2()
            'Try
            '    Dim oReportFactory As Object = ClassLoader.LoadClass("ReportFactory")
            '    WinClientContext.ReportFactory = CType(oReportFactory, IReportFactory)
            'Catch ex As Exception
            '    Trace.WriteLine(ex)
            '    MessageForm.Show("Could not load Report Factory", "Error")
            'End Try
            'Try
            '    Dim oBarcodeFactory As Object = ClassLoader.LoadClass("BarcodeFactory")
            '    WinClientContext.BarcodeFactory = CType(oBarcodeFactory, IBarcodeFactory)
            'Catch ex As Exception
            '    Trace.WriteLine(ex)
            '    MessageForm.Show("Could not load Barcode Factory", "Error")
            'End Try

        End Sub
    End Class
End Namespace
