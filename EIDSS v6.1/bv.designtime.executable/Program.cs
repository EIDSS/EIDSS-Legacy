using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using bv.designtime.Generator;

namespace bv.designtime.executable
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: bv.designtime.executable full_path_to_xml_file");
            }
            else
            {
                string path = args[0];
                try
                {
                    string content = File.ReadAllText(path);

                    ObjectGenerator gen = new ObjectGenerator();
                    uint cbOutput;
                    IntPtr[] gbOutputFileContents = new IntPtr[1];
                    gen.Generate(path, content, "eidss.model.Schema", gbOutputFileContents, out cbOutput, null);

                    string ext;
                    gen.DefaultExtension(out ext);

                    string outFilename = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + ext;
                    byte[] managedArray = new byte[cbOutput];
                    Marshal.Copy(gbOutputFileContents[0], managedArray, 0, (int)cbOutput);
                    Marshal.FreeCoTaskMem(gbOutputFileContents[0]);
                    File.WriteAllBytes(outFilename, managedArray);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
