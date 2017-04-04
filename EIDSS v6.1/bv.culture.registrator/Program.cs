using System;
using bv.common.Core;

namespace bv.culture.registrator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CustomCultureHelper.UnRegisterAll();
                CustomCultureHelper.RegisterAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error during custom cultures registration: {0}", ex);
            }
            Console.WriteLine("The next EIDSS custom cultures are registered:");
            Console.WriteLine(CustomCultureHelper.ListRegisteredCultures());
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
    }
}
