
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using bv.common.Core;
using System.IO;
using System.Linq;
#if !MONO
using bv.common.Configuration;
using System.Windows.Forms;
#endif

namespace bv.common.Diagnostics
{
    public class Dbg
    {

        //private static Regex s_DebugMethodFilterRegexp;
        //private static bool s_DebugMethodFilterRegexpDefined;
        private static int m_DefaultDetailLevel;

        private Dbg()
        {
            // NOOP
        }

        private static readonly StandardOutput m_StandardOutput = new StandardOutput();
        private static IDebugOutput CreateDefaultOutputMethod()
        {
            #if !MONO
            // TODO: allow configurable output to log file
            m_DefaultDetailLevel = BaseSettings.DebugDetailLevel;
            if (!BaseSettings.DebugOutput)
            {
                return null;
            }
            if (!Utils.IsEmpty(BaseSettings.DebugLogFile))
            {
                string logfile = null;
                DirectoryInfo dir = Directory.GetParent(Application.CommonAppDataPath);
                logfile = dir.FullName + "\\" + BaseSettings.DebugLogFile;
                if (IsValidOutputFile(logfile))
                    return new DebugFileOutput(logfile, false);
                logfile =  Utils.GetExecutingPath() + BaseSettings.DebugLogFile;
                if (IsValidOutputFile(logfile))
                    return new DebugFileOutput(logfile, false);
            }
            #endif
            return m_StandardOutput;
        }

        private static bool IsValidOutputFile(string fileName)
        {
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    FileAttributes attr = System.IO.File.GetAttributes(fileName);
                    if ((attr & FileAttributes.ReadOnly)!=0)
                    {
                        attr = attr & (~FileAttributes.ReadOnly);
                        System.IO.File.SetAttributes(fileName, attr);
                    }
                    System.IO.FileStream fs = System.IO.File.OpenWrite(fileName);
                    fs.Close();
                }
                else
                {
                    System.IO.FileStream fs = System.IO.File.Create(fileName);
                    fs.Close();
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        private static string FormatDataRow(DataRow row)
        {
            var @out = (from DataColumn col in row.Table.Columns
                        select string.Format(":{0} <{1}>", col.ColumnName, FormatValue(row[col]))).ToList();
            return string.Format("#<DataRow {0}>", Utils.Join(" ", @out));
        }

        public static string FormatValue(object value)
        {
            if (value == null)
            {
                return "*Nothing*";
            }
            if (value == DBNull.Value)
            {
                return "*DBNull*";
            }
            if (value is DataRow)
            {
                return FormatDataRow((DataRow)value);
            }
            if (value is DataRowView)
            {
                return FormatDataRow(((DataRowView)value).Row);
            }
            return value.ToString();
        }

        private static IDebugOutput m_OutputMethod;
        public static IDebugOutput OutputMethod
        {
            get
            {
#if !MONO
                if (!Config.IsInitialized)
                    return m_StandardOutput;
#endif
                if (m_OutputMethod == null)
                    m_OutputMethod = CreateDefaultOutputMethod();
                return m_OutputMethod;
                //Dim result As IDebugOutput = Nothing
                //If InitSlot() Then
                //    result = CType(Thread.GetData(s_OutputMethodSlot), IDebugOutput)
                //Else
                //    result = CreateDefaultOutputMethod()
                //    Thread.SetData(s_OutputMethodSlot, result)
                //End If
                //Return result
            }
            set
            {
                m_OutputMethod = value;
                //InitSlot()
                //Thread.SetData(s_OutputMethodSlot, value)
            }
        }

        private static void DoDbg(int detailLevel, string fmt, params object[] args)
        {
            if (OutputMethod != null)
            {
                var trace = new StackTrace(2, true);
                MethodBase method = trace.GetFrame(0).GetMethod();
                if (ShouldIgnore(detailLevel, method))
                {
                    return;
                }
                if (args == null || args.Length == 0)
                {
                    OutputMethod.WriteLine(string.Format("{0} {1}.{2}(): {3}", DateTime.Now,  method.DeclaringType.Name, method.Name, fmt));
                    return;
                }
                var newArgs = new string[args.Length];
                for (int i = 0; i <= args.Length - 1; i++)
                {
                    newArgs[i] = FormatValue(args[i]);
                }
                OutputMethod.WriteLine(string.Format("{0} {1}.{2}(): {3}", DateTime.Now, method.DeclaringType.Name, method.Name, string.Format(fmt, newArgs)));
            }
        }

        public static void WriteLine(string fmt, params object[] args)
        {
            if (OutputMethod != null)
            {
                var newArgs = new string[args.Length];
                for (int i = 0; i <= args.Length - 1; i++)
                    newArgs[i] = FormatValue(args[i]);
                OutputMethod.WriteLine(args.Length == 0 ? fmt : string.Format(fmt, newArgs));
            }
        }

        public static void Debug(string fmt, params object[] args)
        {
            DoDbg(0, fmt, args);
        }
        public static void ConditionalDebug(int detailLevel, string fmt, params object[] args)
        {
            DoDbg(detailLevel, fmt, args);
        }
        public static void ConditionalDebug(DebugDetalizationLevel detailLevel, string fmt, params object[] args)
        {
            DoDbg((int)detailLevel, fmt, args);
        }

        public static void Fail(string fmt, params object[] args)
        {
            string message = "Assertion failed: " + string.Format(fmt, args);
            DoDbg(0, "{0}", message); // TODO: always print failure messages
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
            throw (new InternalErrorException(message));
        }

        public static void Assert(bool value, string fmt, params object[] args)
        {
            if (!value)
            {
                // we duplicate Fail here to make DoDbg work correctly
                string message = "Assertion failed: " + string.Format(fmt, args);
                DoDbg(0, "{0}", message);
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
                throw (new InternalErrorException(message));
            }
        }

        public static void DbgAssert(bool value, string fmt, params object[] args)
        {
            if (!value)
            {
                // we duplicate Fail here to make DoDbg work correctly
                string message = "Assertion failed: " + string.Format(fmt, args);
                DoDbg(0, "{0}", message);
            }
        }

        public static void DbgAssert(int detailLevel, bool value, string fmt, params object[] args)
        {
            if (!value)
            {
                // we duplicate Fail here to make DoDbg work correctly
                string message = "Assertion failed: " + string.Format(fmt, args);
                DoDbg(detailLevel, "{0}", message);
            }
        }
        // TODO: probably System.Diagnostics.SymbolStore.* can be used to display extended error information
        public static void Require(params object[] values)
        {
            for (int i = 0; i <= values.Length - 1; i++)
            {
                if (values[i] == null)
                {
                    // we duplicate Fail here to make DoDbg work correctly
                    string message = string.Format("Require: value #{0} (starting from 1) is Nothing", i + 1);
                    DoDbg(0, "{0}", message);
                    if (Debugger.IsAttached)
                    {
                        Debugger.Break();
                    }
                    throw (new InternalErrorException(message));
                }
            }
        }

        private static bool ShouldIgnore(int detailLevel, MethodBase method)
        {
            if (detailLevel <= m_DefaultDetailLevel)
            {
                return false;
            }
            return true; //TODO: should be implemented to skip some output
        }

        public static void Trace(params object[] argValues)
        {
#if TRACE
            if (OutputMethod == null)
            {
                return;
            }
            var trace = new StackTrace(1, true);
            MethodBase method = trace.GetFrame(0).GetMethod();
            var argStrings = new List<string>();
            if (argValues != null && argValues.Length != 0)
            {
                ParameterInfo[] @params = method.GetParameters();
                int numArgs = Math.Min(@params.Length, argValues.Length);
                for (int i = 0; i <= numArgs - 1; i++)
                {
                    string valString = FormatValue(argValues[i]);
                    argStrings.Add(string.Format("{0} = <{1}>", @params[i].Name, valString));
                }
            }
            OutputMethod.WriteLine(string.Format("--> {0}.{1}({2})", method.DeclaringType.Name, method.Name, Utils.Join(", ", argStrings)));
#endif
        }
    }
}
