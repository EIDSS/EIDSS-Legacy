using System.Linq;
using System.ServiceProcess;
using eidss.model.Trace;
using eidss.model.WindowsService;
using EIDSS.AVR.Service.Scheduler;
using EIDSS.AVR.Service.WcfService;
using StructureMap;

namespace EIDSS.AVR.Service
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = GetStructureMapContainer();
            var service = new EidssService(() => container.GetInstance<AvrHostKeeper>(), TraceHelper.AVRCategory);
            if (args.Contains("/c"))
            {
                service.RunInConsole();
            }
            else
            {
                ServiceBase.Run(service);
            }
        }

        // todo [ivan] implement
        private static Container GetStructureMapContainer()
        {
            Container c = new Container();
            c.Configure(r => { r.For<ISchedulerConfigurationStrategy>().Use<SchedulerConfigurationStrategy>(); });
            return c;
        }
    }
}