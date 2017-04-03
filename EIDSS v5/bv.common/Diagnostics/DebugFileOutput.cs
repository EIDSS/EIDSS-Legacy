
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using bv.common.Core;


namespace bv.common.Diagnostics
{
    public class DebugFileOutput : IDebugOutput
    {


        private string m_FileName;
        public static int MAX_LOG_SIZE = 1000000;

        public void Init(string fileName, bool overwrite)
        {
            if (Utils.IsEmpty(fileName) && Utils.IsEmpty(m_FileName))
            {
                Assembly exeAssembly = @Assembly.GetEntryAssembly();
                if (exeAssembly != null)
                {
                    m_FileName = Path.ChangeExtension(exeAssembly.Location, ".log");
                }
            }
            if (!Utils.IsEmpty(fileName))
            {
                m_FileName = fileName;
            }

            lock (LogFileSyncObject)
            {
                if (overwrite && File.Exists(m_FileName))
                {
                    File.Delete(m_FileName);
                }
            }
        }

        public DebugFileOutput()
        {
            Init(null, false);
        }

        public DebugFileOutput(string fileName, bool overwrite)
        {
            Init(fileName, overwrite);
        }
        public static object LogFileSyncObject = new object();
        private StreamWriter CreateWriter()
        {
            lock (LogFileSyncObject)
            {
                try
                {
                    if (!File.Exists(m_FileName))
                        File.Create(m_FileName);
                    FileAttributes attr = File.GetAttributes(m_FileName);
                    if ((attr & FileAttributes.ReadOnly) != 0)
                    {
                        attr = attr & ~FileAttributes.ReadOnly;
                        File.SetAttributes(m_FileName, attr);
                    }
                    return new StreamWriter(m_FileName, true);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("error during opening debug log file writer: {0}", ex.ToString());
                    return null;
                }
            }
        }
        public void WriteLine(string line)
        {
            lock(LogFileSyncObject)
            {
                StreamWriter writer = CreateWriter();
                if (writer != null)
                {
                    if (writer.BaseStream != null && writer.BaseStream.Length > MAX_LOG_SIZE)
                    {
                        try
                        {
                            writer.Close();
                            writer.Dispose();
                            File.Delete(m_FileName);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine("error during opening seleting debug log file: {0}", ex.ToString());
                        }
                        finally
                        {
                            Init(null, false);
                            writer = CreateWriter();
                        }
                    }
                }
                if (writer != null)
                {
                    using (writer)
                    {
                        try
                        {
                            writer.WriteLine(line);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine("error during writing debug log file: {0}", ex.ToString());
                        }
                        finally
                        {
                            writer.Close();
                        }
                    }

                }
            }
        }
    }
}
