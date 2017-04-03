using System.Linq;
using System.ServiceProcess;
using EIDSS.AVR.Service.WcfService;
using eidss.model.Trace;
using eidss.model.WindowsService;

namespace EIDSS.AVR.Service
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var service = new EidssService(() => new AVRHostKeeper(), TraceHelper.AVRCategory);
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