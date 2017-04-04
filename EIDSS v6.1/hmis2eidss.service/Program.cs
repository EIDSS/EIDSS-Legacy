using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using eidss.model.Trace;
using eidss.model.WindowsService;
using hmis2eidss.service.WindowsService;

namespace hmis2eidss.service
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new EidssService(() => new HMIS2EIDSSHostKeeper(), TraceHelper.HMIS2EIDSSCategory);
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
