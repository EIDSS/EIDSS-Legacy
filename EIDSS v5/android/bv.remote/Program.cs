using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using bv.model.BLToolkit.RemoteProvider.Server;

namespace bv.remote
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteSqlInstance.ConnectionString = @"Server=.\SQL2008;Database=EIDSS_v4_test;Integrated Security=SSPI";
            ServiceHost host = new ServiceHost(typeof(RemoteSqlServer), new Uri("http://localhost:8734/qqq"));
            host.Open();
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
