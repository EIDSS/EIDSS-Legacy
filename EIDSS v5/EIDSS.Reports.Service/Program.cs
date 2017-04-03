using System;
using System.Linq;
using System.ServiceProcess;
using EIDSS.Reports.Service.Trace;
using EIDSS.Reports.Service.WcfService;
using EIDSS.Reports.Service.WindowsService;
using bv.common.Core;

namespace EIDSS.Reports.Service
{
    internal class Program
    {
        private static readonly TraceHelper m_Trace = new TraceHelper();

        private static void Main(string[] args)
        {
            if (args.Contains("/c"))
            {
                try
                {
                    ClassLoader.Init("bv_common.dll", null);
                    ClassLoader.Init("bvwin_common.dll", null);
                    ClassLoader.Init("bv.common.dll", null);
                    ClassLoader.Init("bv.winclient.dll", null);
                    ClassLoader.Init("eidss*.dll", null);

                    using (var hostKeeper = new HostKeeper())
                    {
                        hostKeeper.Open();

                        Console.WriteLine(@"Press Enter to stop Service.");
                        Console.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    m_Trace.TraceError(ex);
                    Console.ReadLine();
                }
            }
            else
            {
                ServiceBase.Run(new ReportService());
            }
        }
    }
}