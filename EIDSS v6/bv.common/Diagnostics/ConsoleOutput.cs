
using System;

namespace bv.common.Diagnostics
{
    public class ConsoleOutput : IDebugOutput
    {


        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }

}
