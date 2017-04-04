using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bv.winclient.Core
{
    public class Help2
    {
        public const string HomePage = "system_requirements_and_set-up";
        public static void ShowHelp(Control parent, string url)
        {
            if (url.StartsWith("http"))
            {
                url = url + "index.html";
                System.Diagnostics.Process.Start(url);
            }
            else
            {
                string appdir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                string filepath = appdir + "/HM2GO.EXE";
                url = url + "index.html";
                System.Diagnostics.Process.Start(filepath, "/PRJ:\"" + url + "\"");
            }
        }
        public static void ShowHelp(Control parent, string url, string keyword)
        {
            if (url.StartsWith("http"))
            {
                url = url + "index.html?" + keyword + ".htm";
                System.Diagnostics.Process.Start(url);
            }
            else
            {
                string appdir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                string filepath = appdir + "/HM2GO.EXE";
                url = url + "index.html?" + keyword + ".htm";
                System.Diagnostics.Process.Start(filepath, "/PRJ:\"" + url + "\"");
            }
        }
    }
}
