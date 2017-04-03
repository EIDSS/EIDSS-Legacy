using System.Diagnostics;

namespace bv.common.Diagnostics
{
    public class StandardOutput : IDebugOutput
    {
        public void WriteLine(string line)
        {
            Debug.WriteLine(line);
        }
    }
}
