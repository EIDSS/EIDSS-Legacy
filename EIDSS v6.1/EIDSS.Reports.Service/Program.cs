using System.Linq;
using System.ServiceProcess;
using EIDSS.Reports.Service.WcfService;
using eidss.model.Trace;
using eidss.model.WindowsService;

namespace EIDSS.Reports.Service
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var service = new EidssService(() => new ReportHostKeeper(), TraceHelper.ReportsCategory);
            if (args.Contains("/c"))
            {
                service.RunInConsole();
            }
            else
            {
                ServiceBase.Run(service);
            }
        }
    }
}