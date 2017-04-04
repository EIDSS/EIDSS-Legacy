using System;
using System.IO;
using System.Reflection;
using bv.common.Core;


namespace bv.common.Diagnostics
{
    public class DebugFileOutput : IDebugOutput
    {


        private string m_FileName;
        public const int MaxLogSize = 1000000;

        public void Init(string fileName, bool overwrite, bool useLock)
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
            if (useLock)
            {
                lock (m_LogFileSyncObject)
                {
                    if (overwrite)
                    {
                        DeleteFile(m_FileName);
                    }
                }
            }
            else
            {
                if (overwrite)
                {
                    DeleteFile(m_FileName);
                }
            }
        }

        private void DeleteFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("error during deleting debug log file: {0}", ex.ToString());
            }

        }
        public DebugFileOutput()
        {
            Init(null, false, true);
        }

        public DebugFileOutput(string fileName, bool overwrite)
        {
            Init(fileName, overwrite, true);
        }
        public static object m_LogFileSyncObject = new object();

        private StreamWriter CreateWriter()
        {
            try
            {
                if (!File.Exists(m_FileName))
                {
                    var f = File.Create(m_FileName);
                    f.Close();
                }
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
        public void WriteLine(string line)
        {
            lock (m_LogFileSyncObject)
            {
                StreamWriter writer = CreateWriter();
                if (writer != null)
                {
                    if (writer.BaseStream.Length > MaxLogSize)
                    {
                        try
                        {
                            writer.Close();
                            writer.Dispose();
                            File.Delete(m_FileName);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine("error during deleting debug log file with max log size: {0}", ex.ToString());
                        }
                        finally
                        {
                            Init(null, false, false);
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
                            try
                            {
                                writer.Close();
                            }
                            catch
                            {
                            }
                        }
                    }

                }
            }
        }
    }
}
